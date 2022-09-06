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
   public class r_comprasdetalladopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_comprasdetalladopdf.aspx")), "compras.r_comprasdetalladopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_comprasdetalladopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "CueCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV67CueCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV49ProdCod = GetPar( "ProdCod");
                  AV64PrvCod = GetPar( "PrvCod");
                  AV12MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV50Opc = (short)(NumberUtil.Val( GetPar( "Opc"), "."));
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

      public r_comprasdetalladopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasdetalladopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CueCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_PrvCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref short aP6_Opc )
      {
         this.AV67CueCod = aP0_CueCod;
         this.AV49ProdCod = aP1_ProdCod;
         this.AV64PrvCod = aP2_PrvCod;
         this.AV12MonCod = aP3_MonCod;
         this.AV14FDesde = aP4_FDesde;
         this.AV15FHasta = aP5_FHasta;
         this.AV50Opc = aP6_Opc;
         initialize();
         executePrivate();
         aP0_CueCod=this.AV67CueCod;
         aP1_ProdCod=this.AV49ProdCod;
         aP2_PrvCod=this.AV64PrvCod;
         aP3_MonCod=this.AV12MonCod;
         aP4_FDesde=this.AV14FDesde;
         aP5_FHasta=this.AV15FHasta;
         aP6_Opc=this.AV50Opc;
      }

      public short executeUdp( ref string aP0_CueCod ,
                               ref string aP1_ProdCod ,
                               ref string aP2_PrvCod ,
                               ref int aP3_MonCod ,
                               ref DateTime aP4_FDesde ,
                               ref DateTime aP5_FHasta )
      {
         execute(ref aP0_CueCod, ref aP1_ProdCod, ref aP2_PrvCod, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_Opc);
         return AV50Opc ;
      }

      public void executeSubmit( ref string aP0_CueCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_PrvCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref short aP6_Opc )
      {
         r_comprasdetalladopdf objr_comprasdetalladopdf;
         objr_comprasdetalladopdf = new r_comprasdetalladopdf();
         objr_comprasdetalladopdf.AV67CueCod = aP0_CueCod;
         objr_comprasdetalladopdf.AV49ProdCod = aP1_ProdCod;
         objr_comprasdetalladopdf.AV64PrvCod = aP2_PrvCod;
         objr_comprasdetalladopdf.AV12MonCod = aP3_MonCod;
         objr_comprasdetalladopdf.AV14FDesde = aP4_FDesde;
         objr_comprasdetalladopdf.AV15FHasta = aP5_FHasta;
         objr_comprasdetalladopdf.AV50Opc = aP6_Opc;
         objr_comprasdetalladopdf.context.SetSubmitInitialConfig(context);
         objr_comprasdetalladopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasdetalladopdf);
         aP0_CueCod=this.AV67CueCod;
         aP1_ProdCod=this.AV49ProdCod;
         aP2_PrvCod=this.AV64PrvCod;
         aP3_MonCod=this.AV12MonCod;
         aP4_FDesde=this.AV14FDesde;
         aP5_FHasta=this.AV15FHasta;
         aP6_Opc=this.AV50Opc;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasdetalladopdf)stateInfo).executePrivate();
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
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV42Ruta;
            AV74Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV53Moneda = "(Todos)";
            /* Using cursor P00AU2 */
            pr_default.execute(0, new Object[] {AV12MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00AU2_A180MonCod[0];
               A1234MonDsc = P00AU2_A1234MonDsc[0];
               AV53Moneda = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV61TotGCant = 0.0000m;
            AV65TotGPrecio = 0.00m;
            AV66TotGTotal = 0.00m;
            if ( AV50Opc == 1 )
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV64PrvCod ,
                                                    AV12MonCod ,
                                                    AV49ProdCod ,
                                                    AV67CueCod ,
                                                    A244PrvCod ,
                                                    A246ComMon ,
                                                    A254ComDProCod ,
                                                    A253ComDCueCod ,
                                                    A707ComFReg ,
                                                    AV14FDesde ,
                                                    AV15FHasta } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                    }
               });
               /* Using cursor P00AU3 */
               pr_default.execute(1, new Object[] {AV14FDesde, AV15FHasta, AV64PrvCod, AV12MonCod, AV49ProdCod, AV67CueCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A149TipCod = P00AU3_A149TipCod[0];
                  A245ComConpCod = P00AU3_A245ComConpCod[0];
                  A253ComDCueCod = P00AU3_A253ComDCueCod[0];
                  n253ComDCueCod = P00AU3_n253ComDCueCod[0];
                  A254ComDProCod = P00AU3_A254ComDProCod[0];
                  n254ComDProCod = P00AU3_n254ComDProCod[0];
                  A246ComMon = P00AU3_A246ComMon[0];
                  A707ComFReg = P00AU3_A707ComFReg[0];
                  A244PrvCod = P00AU3_A244PrvCod[0];
                  A511TipSigno = P00AU3_A511TipSigno[0];
                  A681ComConpAbr = P00AU3_A681ComConpAbr[0];
                  A251ComDOrdCod = P00AU3_A251ComDOrdCod[0];
                  A1233MonAbr = P00AU3_A1233MonAbr[0];
                  n1233MonAbr = P00AU3_n1233MonAbr[0];
                  A694ComDDsc = P00AU3_A694ComDDsc[0];
                  A243ComCod = P00AU3_A243ComCod[0];
                  A306TipAbr = P00AU3_A306TipAbr[0];
                  A247PrvDsc = P00AU3_A247PrvDsc[0];
                  A248ComFec = P00AU3_A248ComFec[0];
                  A689ComDDct = P00AU3_A689ComDDct[0];
                  A686ComDPre = P00AU3_A686ComDPre[0];
                  A685ComDCant = P00AU3_A685ComDCant[0];
                  A250ComDItem = P00AU3_A250ComDItem[0];
                  A511TipSigno = P00AU3_A511TipSigno[0];
                  A306TipAbr = P00AU3_A306TipAbr[0];
                  A245ComConpCod = P00AU3_A245ComConpCod[0];
                  A246ComMon = P00AU3_A246ComMon[0];
                  A707ComFReg = P00AU3_A707ComFReg[0];
                  A247PrvDsc = P00AU3_A247PrvDsc[0];
                  A248ComFec = P00AU3_A248ComFec[0];
                  A681ComConpAbr = P00AU3_A681ComConpAbr[0];
                  A1233MonAbr = P00AU3_A1233MonAbr[0];
                  n1233MonAbr = P00AU3_n1233MonAbr[0];
                  A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
                  A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
                  A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
                  AV52DocFec = A248ComFec;
                  AV28DocMonCod = A246ComMon;
                  AV68Codigo = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? A253ComDCueCod : A254ComDProCod);
                  AV71ComDCant = (decimal)(A685ComDCant*A511TipSigno);
                  AV69ComDPre = (decimal)(A686ComDPre*A511TipSigno);
                  AV70ComDTot = (decimal)(A684ComDTot*A511TipSigno);
                  HAU0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 123, Gx_line+2, 347, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A248ComFec, "99/99/99"), 0, Gx_line+1, 44, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69ComDPre, "ZZZZZ,ZZZ,ZZ9.999999")), 831, Gx_line+2, 936, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71ComDCant, "ZZZZ,ZZZ,ZZ9.9999")), 780, Gx_line+2, 870, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), 46, Gx_line+1, 122, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 357, Gx_line+2, 387, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A243ComCod, "")), 390, Gx_line+1, 457, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Codigo, "")), 493, Gx_line+1, 565, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A694ComDDsc, "")), 568, Gx_line+1, 797, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70ComDTot, "ZZZZZZ,ZZZ,ZZ9.99")), 917, Gx_line+2, 1007, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 460, Gx_line+2, 490, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A251ComDOrdCod, "")), 1010, Gx_line+2, 1053, Gx_line+15, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A681ComConpAbr, "")), 1065, Gx_line+2, 1108, Gx_line+15, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  AV61TotGCant = (decimal)(AV61TotGCant+AV71ComDCant);
                  AV65TotGPrecio = (decimal)(AV65TotGPrecio+AV69ComDPre);
                  AV66TotGTotal = (decimal)(AV66TotGTotal+AV70ComDTot);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            else
            {
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    AV64PrvCod ,
                                                    AV12MonCod ,
                                                    AV49ProdCod ,
                                                    AV67CueCod ,
                                                    A244PrvCod ,
                                                    A246ComMon ,
                                                    A254ComDProCod ,
                                                    A253ComDCueCod ,
                                                    A707ComFReg ,
                                                    AV14FDesde ,
                                                    AV15FHasta } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                    }
               });
               /* Using cursor P00AU4 */
               pr_default.execute(2, new Object[] {AV14FDesde, AV15FHasta, AV64PrvCod, AV12MonCod, AV49ProdCod, AV67CueCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A149TipCod = P00AU4_A149TipCod[0];
                  A245ComConpCod = P00AU4_A245ComConpCod[0];
                  A253ComDCueCod = P00AU4_A253ComDCueCod[0];
                  n253ComDCueCod = P00AU4_n253ComDCueCod[0];
                  A254ComDProCod = P00AU4_A254ComDProCod[0];
                  n254ComDProCod = P00AU4_n254ComDProCod[0];
                  A246ComMon = P00AU4_A246ComMon[0];
                  A707ComFReg = P00AU4_A707ComFReg[0];
                  A244PrvCod = P00AU4_A244PrvCod[0];
                  A248ComFec = P00AU4_A248ComFec[0];
                  A511TipSigno = P00AU4_A511TipSigno[0];
                  A681ComConpAbr = P00AU4_A681ComConpAbr[0];
                  A251ComDOrdCod = P00AU4_A251ComDOrdCod[0];
                  A1233MonAbr = P00AU4_A1233MonAbr[0];
                  n1233MonAbr = P00AU4_n1233MonAbr[0];
                  A694ComDDsc = P00AU4_A694ComDDsc[0];
                  A243ComCod = P00AU4_A243ComCod[0];
                  A306TipAbr = P00AU4_A306TipAbr[0];
                  A247PrvDsc = P00AU4_A247PrvDsc[0];
                  A689ComDDct = P00AU4_A689ComDDct[0];
                  A686ComDPre = P00AU4_A686ComDPre[0];
                  A685ComDCant = P00AU4_A685ComDCant[0];
                  A250ComDItem = P00AU4_A250ComDItem[0];
                  A511TipSigno = P00AU4_A511TipSigno[0];
                  A306TipAbr = P00AU4_A306TipAbr[0];
                  A245ComConpCod = P00AU4_A245ComConpCod[0];
                  A246ComMon = P00AU4_A246ComMon[0];
                  A707ComFReg = P00AU4_A707ComFReg[0];
                  A248ComFec = P00AU4_A248ComFec[0];
                  A247PrvDsc = P00AU4_A247PrvDsc[0];
                  A681ComConpAbr = P00AU4_A681ComConpAbr[0];
                  A1233MonAbr = P00AU4_A1233MonAbr[0];
                  n1233MonAbr = P00AU4_n1233MonAbr[0];
                  A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
                  A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
                  A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
                  AV52DocFec = A248ComFec;
                  AV28DocMonCod = A246ComMon;
                  AV68Codigo = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? A253ComDCueCod : A254ComDProCod);
                  AV71ComDCant = (decimal)(A685ComDCant*A511TipSigno);
                  AV69ComDPre = (decimal)(A686ComDPre*A511TipSigno);
                  AV70ComDTot = (decimal)(A684ComDTot*A511TipSigno);
                  HAU0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), 123, Gx_line+2, 347, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A248ComFec, "99/99/99"), 0, Gx_line+1, 44, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69ComDPre, "ZZZZZ,ZZZ,ZZ9.999999")), 831, Gx_line+2, 936, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71ComDCant, "ZZZZ,ZZZ,ZZ9.9999")), 780, Gx_line+2, 870, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), 46, Gx_line+1, 122, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 357, Gx_line+2, 387, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A243ComCod, "")), 390, Gx_line+1, 457, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Codigo, "")), 493, Gx_line+1, 565, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A694ComDDsc, "")), 568, Gx_line+1, 797, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70ComDTot, "ZZZZZZ,ZZZ,ZZ9.99")), 917, Gx_line+2, 1007, Gx_line+15, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 460, Gx_line+2, 490, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A251ComDOrdCod, "")), 1010, Gx_line+2, 1053, Gx_line+15, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A681ComConpAbr, "")), 1065, Gx_line+2, 1108, Gx_line+15, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  AV61TotGCant = (decimal)(AV61TotGCant+AV71ComDCant);
                  AV65TotGPrecio = (decimal)(AV65TotGPrecio+AV69ComDPre);
                  AV66TotGTotal = (decimal)(AV66TotGTotal+AV70ComDTot);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            HAU0( false, 52) ;
            getPrinter().GxDrawLine(768, Gx_line+9, 1107, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 649, Gx_line+15, 729, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TotGCant, "ZZZZ,ZZZ,ZZ9.9999")), 763, Gx_line+15, 870, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotGPrecio, "ZZZZZZ,ZZZ,ZZ9.99")), 829, Gx_line+15, 936, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotGTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 899, Gx_line+15, 1006, Gx_line+30, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAU0( true, 0) ;
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

      protected void HAU0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 981, Gx_line+40, 1013, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 981, Gx_line+59, 1025, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 981, Gx_line+21, 1020, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte de Compras Detallado", 392, Gx_line+44, 654, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+130, 1106, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1028, Gx_line+21, 1075, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1014, Gx_line+40, 1074, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+59, 1075, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 6, Gx_line+136, 37, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 505, Gx_line+136, 541, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio", 891, Gx_line+136, 925, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 392, Gx_line+73, 432, Gx_line+88, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 452, Gx_line+68, 526, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 552, Gx_line+73, 589, Gx_line+88, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 603, Gx_line+68, 677, Gx_line+92, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C", 72, Gx_line+136, 101, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 218, Gx_line+136, 274, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 361, Gx_line+136, 382, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 398, Gx_line+136, 440, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto / Concepto", 621, Gx_line+136, 728, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 810, Gx_line+136, 857, Gx_line+149, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV74Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 16, Gx_line+11, 174, Gx_line+89) ;
               getPrinter().GxDrawLine(47, Gx_line+131, 47, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(119, Gx_line+131, 119, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(357, Gx_line+131, 357, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(388, Gx_line+130, 388, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(458, Gx_line+131, 458, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(565, Gx_line+130, 565, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(798, Gx_line+131, 798, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(869, Gx_line+131, 869, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(936, Gx_line+131, 936, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 16, Gx_line+95, 384, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 16, Gx_line+113, 384, Gx_line+131, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 392, Gx_line+100, 444, Gx_line+115, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Moneda, "")), 452, Gx_line+95, 637, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total", 958, Gx_line+136, 986, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(491, Gx_line+131, 491, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Mon", 464, Gx_line+136, 487, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1006, Gx_line+131, 1006, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1070, Gx_line+131, 1070, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("O/C.", 1023, Gx_line+136, 1048, Gx_line+149, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cond.", 1074, Gx_line+136, 1104, Gx_line+149, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+156);
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
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV38Logo = "";
         AV74Logo_GXI = "";
         AV53Moneda = "";
         scmdbuf = "";
         P00AU2_A180MonCod = new int[1] ;
         P00AU2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         A244PrvCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A707ComFReg = DateTime.MinValue;
         P00AU3_A149TipCod = new string[] {""} ;
         P00AU3_A245ComConpCod = new int[1] ;
         P00AU3_A253ComDCueCod = new string[] {""} ;
         P00AU3_n253ComDCueCod = new bool[] {false} ;
         P00AU3_A254ComDProCod = new string[] {""} ;
         P00AU3_n254ComDProCod = new bool[] {false} ;
         P00AU3_A246ComMon = new int[1] ;
         P00AU3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AU3_A244PrvCod = new string[] {""} ;
         P00AU3_A511TipSigno = new short[1] ;
         P00AU3_A681ComConpAbr = new string[] {""} ;
         P00AU3_A251ComDOrdCod = new string[] {""} ;
         P00AU3_A1233MonAbr = new string[] {""} ;
         P00AU3_n1233MonAbr = new bool[] {false} ;
         P00AU3_A694ComDDsc = new string[] {""} ;
         P00AU3_A243ComCod = new string[] {""} ;
         P00AU3_A306TipAbr = new string[] {""} ;
         P00AU3_A247PrvDsc = new string[] {""} ;
         P00AU3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AU3_A689ComDDct = new decimal[1] ;
         P00AU3_A686ComDPre = new decimal[1] ;
         P00AU3_A685ComDCant = new decimal[1] ;
         P00AU3_A250ComDItem = new short[1] ;
         A149TipCod = "";
         A681ComConpAbr = "";
         A251ComDOrdCod = "";
         A1233MonAbr = "";
         A694ComDDsc = "";
         A243ComCod = "";
         A306TipAbr = "";
         A247PrvDsc = "";
         A248ComFec = DateTime.MinValue;
         AV52DocFec = DateTime.MinValue;
         AV68Codigo = "";
         P00AU4_A149TipCod = new string[] {""} ;
         P00AU4_A245ComConpCod = new int[1] ;
         P00AU4_A253ComDCueCod = new string[] {""} ;
         P00AU4_n253ComDCueCod = new bool[] {false} ;
         P00AU4_A254ComDProCod = new string[] {""} ;
         P00AU4_n254ComDProCod = new bool[] {false} ;
         P00AU4_A246ComMon = new int[1] ;
         P00AU4_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AU4_A244PrvCod = new string[] {""} ;
         P00AU4_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AU4_A511TipSigno = new short[1] ;
         P00AU4_A681ComConpAbr = new string[] {""} ;
         P00AU4_A251ComDOrdCod = new string[] {""} ;
         P00AU4_A1233MonAbr = new string[] {""} ;
         P00AU4_n1233MonAbr = new bool[] {false} ;
         P00AU4_A694ComDDsc = new string[] {""} ;
         P00AU4_A243ComCod = new string[] {""} ;
         P00AU4_A306TipAbr = new string[] {""} ;
         P00AU4_A247PrvDsc = new string[] {""} ;
         P00AU4_A689ComDDct = new decimal[1] ;
         P00AU4_A686ComDPre = new decimal[1] ;
         P00AU4_A685ComDCant = new decimal[1] ;
         P00AU4_A250ComDItem = new short[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasdetalladopdf__default(),
            new Object[][] {
                new Object[] {
               P00AU2_A180MonCod, P00AU2_A1234MonDsc
               }
               , new Object[] {
               P00AU3_A149TipCod, P00AU3_A245ComConpCod, P00AU3_A253ComDCueCod, P00AU3_n253ComDCueCod, P00AU3_A254ComDProCod, P00AU3_n254ComDProCod, P00AU3_A246ComMon, P00AU3_A707ComFReg, P00AU3_A244PrvCod, P00AU3_A511TipSigno,
               P00AU3_A681ComConpAbr, P00AU3_A251ComDOrdCod, P00AU3_A1233MonAbr, P00AU3_n1233MonAbr, P00AU3_A694ComDDsc, P00AU3_A243ComCod, P00AU3_A306TipAbr, P00AU3_A247PrvDsc, P00AU3_A248ComFec, P00AU3_A689ComDDct,
               P00AU3_A686ComDPre, P00AU3_A685ComDCant, P00AU3_A250ComDItem
               }
               , new Object[] {
               P00AU4_A149TipCod, P00AU4_A245ComConpCod, P00AU4_A253ComDCueCod, P00AU4_n253ComDCueCod, P00AU4_A254ComDProCod, P00AU4_n254ComDProCod, P00AU4_A246ComMon, P00AU4_A707ComFReg, P00AU4_A244PrvCod, P00AU4_A248ComFec,
               P00AU4_A511TipSigno, P00AU4_A681ComConpAbr, P00AU4_A251ComDOrdCod, P00AU4_A1233MonAbr, P00AU4_n1233MonAbr, P00AU4_A694ComDDsc, P00AU4_A243ComCod, P00AU4_A306TipAbr, P00AU4_A247PrvDsc, P00AU4_A689ComDDct,
               P00AU4_A686ComDPre, P00AU4_A685ComDCant, P00AU4_A250ComDItem
               }
            }
         );
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_time = context.localUtil.Time( );
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV50Opc ;
      private short A511TipSigno ;
      private short A250ComDItem ;
      private int AV12MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A246ComMon ;
      private int A245ComConpCod ;
      private int AV28DocMonCod ;
      private int Gx_OldLine ;
      private decimal AV61TotGCant ;
      private decimal AV65TotGPrecio ;
      private decimal AV66TotGTotal ;
      private decimal A689ComDDct ;
      private decimal A686ComDPre ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal AV71ComDCant ;
      private decimal AV69ComDPre ;
      private decimal AV70ComDTot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV67CueCod ;
      private string AV49ProdCod ;
      private string AV64PrvCod ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string AV53Moneda ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string A244PrvCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A149TipCod ;
      private string A681ComConpAbr ;
      private string A251ComDOrdCod ;
      private string A1233MonAbr ;
      private string A694ComDDsc ;
      private string A243ComCod ;
      private string A306TipAbr ;
      private string A247PrvDsc ;
      private string AV68Codigo ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime AV52DocFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n253ComDCueCod ;
      private bool n254ComDProCod ;
      private bool n1233MonAbr ;
      private string AV74Logo_GXI ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CueCod ;
      private string aP1_ProdCod ;
      private string aP2_PrvCod ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private short aP6_Opc ;
      private IDataStoreProvider pr_default ;
      private int[] P00AU2_A180MonCod ;
      private string[] P00AU2_A1234MonDsc ;
      private string[] P00AU3_A149TipCod ;
      private int[] P00AU3_A245ComConpCod ;
      private string[] P00AU3_A253ComDCueCod ;
      private bool[] P00AU3_n253ComDCueCod ;
      private string[] P00AU3_A254ComDProCod ;
      private bool[] P00AU3_n254ComDProCod ;
      private int[] P00AU3_A246ComMon ;
      private DateTime[] P00AU3_A707ComFReg ;
      private string[] P00AU3_A244PrvCod ;
      private short[] P00AU3_A511TipSigno ;
      private string[] P00AU3_A681ComConpAbr ;
      private string[] P00AU3_A251ComDOrdCod ;
      private string[] P00AU3_A1233MonAbr ;
      private bool[] P00AU3_n1233MonAbr ;
      private string[] P00AU3_A694ComDDsc ;
      private string[] P00AU3_A243ComCod ;
      private string[] P00AU3_A306TipAbr ;
      private string[] P00AU3_A247PrvDsc ;
      private DateTime[] P00AU3_A248ComFec ;
      private decimal[] P00AU3_A689ComDDct ;
      private decimal[] P00AU3_A686ComDPre ;
      private decimal[] P00AU3_A685ComDCant ;
      private short[] P00AU3_A250ComDItem ;
      private string[] P00AU4_A149TipCod ;
      private int[] P00AU4_A245ComConpCod ;
      private string[] P00AU4_A253ComDCueCod ;
      private bool[] P00AU4_n253ComDCueCod ;
      private string[] P00AU4_A254ComDProCod ;
      private bool[] P00AU4_n254ComDProCod ;
      private int[] P00AU4_A246ComMon ;
      private DateTime[] P00AU4_A707ComFReg ;
      private string[] P00AU4_A244PrvCod ;
      private DateTime[] P00AU4_A248ComFec ;
      private short[] P00AU4_A511TipSigno ;
      private string[] P00AU4_A681ComConpAbr ;
      private string[] P00AU4_A251ComDOrdCod ;
      private string[] P00AU4_A1233MonAbr ;
      private bool[] P00AU4_n1233MonAbr ;
      private string[] P00AU4_A694ComDDsc ;
      private string[] P00AU4_A243ComCod ;
      private string[] P00AU4_A306TipAbr ;
      private string[] P00AU4_A247PrvDsc ;
      private decimal[] P00AU4_A689ComDDct ;
      private decimal[] P00AU4_A686ComDPre ;
      private decimal[] P00AU4_A685ComDCant ;
      private short[] P00AU4_A250ComDItem ;
   }

   public class r_comprasdetalladopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AU3( IGxContext context ,
                                             string AV64PrvCod ,
                                             int AV12MonCod ,
                                             string AV49ProdCod ,
                                             string AV67CueCod ,
                                             string A244PrvCod ,
                                             int A246ComMon ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T3.[ComConpCod] AS ComConpCod, T1.[ComDCueCod], T1.[ComDProCod], T3.[ComMon] AS ComMon, T3.[ComFReg], T1.[PrvCod], T2.[TipSigno], T4.[ConpAbr] AS ComConpAbr, T1.[ComDOrdCod], T5.[MonAbr], T1.[ComDDsc], T1.[ComCod], T2.[TipAbr], T3.[PrvDsc], T3.[ComFec], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem] FROM (((([CPCOMPRASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[ComCod] = T1.[ComCod] AND T3.[PrvCod] = T1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = T3.[ComConpCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T3.[ComMon])";
         AddWhere(sWhereString, "(T3.[ComFReg] >= @AV14FDesde and T3.[ComFReg] <= @AV15FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV64PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV12MonCod) )
         {
            AddWhere(sWhereString, "(T3.[ComMon] = @AV12MonCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV49ProdCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CueCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDCueCod] = @AV67CueCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ComFec]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AU4( IGxContext context ,
                                             string AV64PrvCod ,
                                             int AV12MonCod ,
                                             string AV49ProdCod ,
                                             string AV67CueCod ,
                                             string A244PrvCod ,
                                             int A246ComMon ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T3.[ComConpCod] AS ComConpCod, T1.[ComDCueCod], T1.[ComDProCod], T3.[ComMon] AS ComMon, T3.[ComFReg], T1.[PrvCod], T3.[ComFec], T2.[TipSigno], T4.[ConpAbr] AS ComConpAbr, T1.[ComDOrdCod], T5.[MonAbr], T1.[ComDDsc], T1.[ComCod], T2.[TipAbr], T3.[PrvDsc], T1.[ComDDct], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem] FROM (((([CPCOMPRASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[ComCod] = T1.[ComCod] AND T3.[PrvCod] = T1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = T3.[ComConpCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T3.[ComMon])";
         AddWhere(sWhereString, "(T3.[ComFReg] >= @AV14FDesde and T3.[ComFReg] <= @AV15FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV64PrvCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV12MonCod) )
         {
            AddWhere(sWhereString, "(T3.[ComMon] = @AV12MonCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV49ProdCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67CueCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDCueCod] = @AV67CueCod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PrvCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00AU3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
               case 2 :
                     return conditional_P00AU4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
          Object[] prmP00AU2;
          prmP00AU2 = new Object[] {
          new ParDef("@AV12MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AU3;
          prmP00AU3 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV64PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV12MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV49ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV67CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00AU4;
          prmP00AU4 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV64PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV12MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV49ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV67CueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AU2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV12MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AU4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                ((string[]) buf[12])[0] = rslt.getString(11, 5);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 100);
                ((string[]) buf[15])[0] = rslt.getString(13, 15);
                ((string[]) buf[16])[0] = rslt.getString(14, 5);
                ((string[]) buf[17])[0] = rslt.getString(15, 100);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(16);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((int[]) buf[6])[0] = rslt.getInt(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 5);
                ((string[]) buf[12])[0] = rslt.getString(11, 10);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((bool[]) buf[14])[0] = rslt.wasNull(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 100);
                ((string[]) buf[16])[0] = rslt.getString(14, 15);
                ((string[]) buf[17])[0] = rslt.getString(15, 5);
                ((string[]) buf[18])[0] = rslt.getString(16, 100);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((short[]) buf[22])[0] = rslt.getShort(20);
                return;
       }
    }

 }

}
