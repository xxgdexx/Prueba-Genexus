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
   public class r_stockactualconsolidadopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_stockactualconsolidadopdf.aspx")), "almacen.r_stockactualconsolidadopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_stockactualconsolidadopdf.aspx")))) ;
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
               AV33LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV53SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV28FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV16AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV39Prodcod = GetPar( "Prodcod");
                  AV38nOrden = (short)(NumberUtil.Val( GetPar( "nOrden"), "."));
                  AV29FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV37nAgrupa = GetPar( "nAgrupa");
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

      public r_stockactualconsolidadopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactualconsolidadopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_nOrden ,
                           ref DateTime aP6_FDesde ,
                           ref string aP7_nAgrupa )
      {
         this.AV33LinCod = aP0_LinCod;
         this.AV53SubLCod = aP1_SubLCod;
         this.AV28FamCod = aP2_FamCod;
         this.AV16AlmCod = aP3_AlmCod;
         this.AV39Prodcod = aP4_Prodcod;
         this.AV38nOrden = aP5_nOrden;
         this.AV29FDesde = aP6_FDesde;
         this.AV37nAgrupa = aP7_nAgrupa;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV33LinCod;
         aP1_SubLCod=this.AV53SubLCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_AlmCod=this.AV16AlmCod;
         aP4_Prodcod=this.AV39Prodcod;
         aP5_nOrden=this.AV38nOrden;
         aP6_FDesde=this.AV29FDesde;
         aP7_nAgrupa=this.AV37nAgrupa;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                ref string aP4_Prodcod ,
                                ref short aP5_nOrden ,
                                ref DateTime aP6_FDesde )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_nOrden, ref aP6_FDesde, ref aP7_nAgrupa);
         return AV37nAgrupa ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_nOrden ,
                                 ref DateTime aP6_FDesde ,
                                 ref string aP7_nAgrupa )
      {
         r_stockactualconsolidadopdf objr_stockactualconsolidadopdf;
         objr_stockactualconsolidadopdf = new r_stockactualconsolidadopdf();
         objr_stockactualconsolidadopdf.AV33LinCod = aP0_LinCod;
         objr_stockactualconsolidadopdf.AV53SubLCod = aP1_SubLCod;
         objr_stockactualconsolidadopdf.AV28FamCod = aP2_FamCod;
         objr_stockactualconsolidadopdf.AV16AlmCod = aP3_AlmCod;
         objr_stockactualconsolidadopdf.AV39Prodcod = aP4_Prodcod;
         objr_stockactualconsolidadopdf.AV38nOrden = aP5_nOrden;
         objr_stockactualconsolidadopdf.AV29FDesde = aP6_FDesde;
         objr_stockactualconsolidadopdf.AV37nAgrupa = aP7_nAgrupa;
         objr_stockactualconsolidadopdf.context.SetSubmitInitialConfig(context);
         objr_stockactualconsolidadopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockactualconsolidadopdf);
         aP0_LinCod=this.AV33LinCod;
         aP1_SubLCod=this.AV53SubLCod;
         aP2_FamCod=this.AV28FamCod;
         aP3_AlmCod=this.AV16AlmCod;
         aP4_Prodcod=this.AV39Prodcod;
         aP5_nOrden=this.AV38nOrden;
         aP6_FDesde=this.AV29FDesde;
         aP7_nAgrupa=this.AV37nAgrupa;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockactualconsolidadopdf)stateInfo).executePrivate();
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
            AV26Empresa = AV42Session.Get("Empresa");
            AV25EmpDir = AV42Session.Get("EmpDir");
            AV27EmpRUC = AV42Session.Get("EmpRUC");
            AV40Ruta = AV42Session.Get("RUTA") + "/Logo.jpg";
            AV36Logo = AV40Ruta;
            AV69Logo_GXI = GXDbFile.PathToUrl( AV40Ruta);
            AV54Titulo = "Stock Actual Consolidado";
            AV8Almacen = "(Todos)";
            AV55Titulo2 = "Al : " + context.localUtil.DToC( AV29FDesde, 2, "/");
            AV9Almacen1 = "";
            AV10Almacen2 = "";
            AV11Almacen3 = "";
            AV12Almacen4 = "";
            AV13Almacen5 = "";
            AV14Almacen6 = "";
            AV15Almacen7 = "";
            AV17Cod1 = 0;
            AV18Cod2 = 0;
            AV19Cod3 = 0;
            AV20Cod4 = 0;
            AV21Cod5 = 0;
            AV22Cod6 = 0;
            AV23Cod7 = 0;
            AV66SubLineaCod = AV53SubLCod;
            AV35LineaCod = AV33LinCod;
            AV31i = 1;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16AlmCod ,
                                                 AV33LinCod ,
                                                 AV53SubLCod ,
                                                 AV28FamCod ,
                                                 AV39Prodcod ,
                                                 A63AlmCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 A438AlmSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P007Q2 */
            pr_default.execute(0, new Object[] {AV16AlmCod, AV33LinCod, AV53SubLCod, AV28FamCod, AV39Prodcod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK7Q3 = false;
               A28ProdCod = P007Q2_A28ProdCod[0];
               A63AlmCod = P007Q2_A63AlmCod[0];
               A438AlmSts = P007Q2_A438AlmSts[0];
               A1158LinStk = P007Q2_A1158LinStk[0];
               A50FamCod = P007Q2_A50FamCod[0];
               n50FamCod = P007Q2_n50FamCod[0];
               A51SublCod = P007Q2_A51SublCod[0];
               n51SublCod = P007Q2_n51SublCod[0];
               A52LinCod = P007Q2_A52LinCod[0];
               A433AlmAbr = P007Q2_A433AlmAbr[0];
               A50FamCod = P007Q2_A50FamCod[0];
               n50FamCod = P007Q2_n50FamCod[0];
               A51SublCod = P007Q2_A51SublCod[0];
               n51SublCod = P007Q2_n51SublCod[0];
               A52LinCod = P007Q2_A52LinCod[0];
               A1158LinStk = P007Q2_A1158LinStk[0];
               A438AlmSts = P007Q2_A438AlmSts[0];
               A433AlmAbr = P007Q2_A433AlmAbr[0];
               while ( (pr_default.getStatus(0) != 101) && ( P007Q2_A63AlmCod[0] == A63AlmCod ) )
               {
                  BRK7Q3 = false;
                  A28ProdCod = P007Q2_A28ProdCod[0];
                  BRK7Q3 = true;
                  pr_default.readNext(0);
               }
               if ( AV31i == 1 )
               {
                  AV17Cod1 = A63AlmCod;
                  AV9Almacen1 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 2 )
               {
                  AV18Cod2 = A63AlmCod;
                  AV10Almacen2 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 3 )
               {
                  AV19Cod3 = A63AlmCod;
                  AV11Almacen3 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 4 )
               {
                  AV20Cod4 = A63AlmCod;
                  AV12Almacen4 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 5 )
               {
                  AV21Cod5 = A63AlmCod;
                  AV13Almacen5 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 6 )
               {
                  AV22Cod6 = A63AlmCod;
                  AV14Almacen6 = StringUtil.Trim( A433AlmAbr);
               }
               if ( AV31i == 7 )
               {
                  AV23Cod7 = A63AlmCod;
                  AV15Almacen7 = StringUtil.Trim( A433AlmAbr);
               }
               AV31i = (long)(AV31i+1);
               if ( ! BRK7Q3 )
               {
                  BRK7Q3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            if ( StringUtil.StrCmp(AV37nAgrupa, "L") == 0 )
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV33LinCod ,
                                                    A52LinCod ,
                                                    A1880StkAct ,
                                                    A1159LinSts } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT
                                                    }
               });
               /* Using cursor P007Q3 */
               pr_default.execute(1, new Object[] {AV33LinCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  BRK7Q5 = false;
                  A28ProdCod = P007Q3_A28ProdCod[0];
                  A1159LinSts = P007Q3_A1159LinSts[0];
                  A52LinCod = P007Q3_A52LinCod[0];
                  A1153LinDsc = P007Q3_A1153LinDsc[0];
                  A1880StkAct = P007Q3_A1880StkAct[0];
                  A1881StkIng = P007Q3_A1881StkIng[0];
                  A1882StkSal = P007Q3_A1882StkSal[0];
                  A63AlmCod = P007Q3_A63AlmCod[0];
                  A52LinCod = P007Q3_A52LinCod[0];
                  A1159LinSts = P007Q3_A1159LinSts[0];
                  A1153LinDsc = P007Q3_A1153LinDsc[0];
                  while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007Q3_A1153LinDsc[0], A1153LinDsc) == 0 ) )
                  {
                     BRK7Q5 = false;
                     A28ProdCod = P007Q3_A28ProdCod[0];
                     A52LinCod = P007Q3_A52LinCod[0];
                     A63AlmCod = P007Q3_A63AlmCod[0];
                     A52LinCod = P007Q3_A52LinCod[0];
                     BRK7Q5 = true;
                     pr_default.readNext(1);
                  }
                  AV35LineaCod = A52LinCod;
                  AV34Linea = A1153LinDsc;
                  AV58TStk1 = 0.0000m;
                  AV59TStk2 = 0.0000m;
                  AV60TStk3 = 0.0000m;
                  AV61TStk4 = 0.0000m;
                  AV62TStk5 = 0.0000m;
                  AV63TStk6 = 0.0000m;
                  AV64TStk7 = 0.0000m;
                  AV57TStk = 0.0000m;
                  H7Q0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Linea, "")), 14, Gx_line+3, 413, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  /* Execute user subroutine: 'VALIDAPRODUCTOS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
                  H7Q0( false, 28) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Linea, "")), 22, Gx_line+9, 421, Gx_line+20, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TStk1, "ZZZZ,ZZZ,ZZ9.9999")), 446, Gx_line+8, 536, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TStk2, "ZZZZ,ZZZ,ZZ9.9999")), 524, Gx_line+8, 614, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TStk3, "ZZZZ,ZZZ,ZZ9.9999")), 609, Gx_line+8, 699, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TStk4, "ZZZZ,ZZZ,ZZ9.9999")), 699, Gx_line+8, 789, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TStk5, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+8, 875, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TStk6, "ZZZZ,ZZZ,ZZ9.9999")), 871, Gx_line+8, 961, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TStk7, "ZZZZ,ZZZ,ZZ9.9999")), 967, Gx_line+8, 1057, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TStk, "ZZZZ,ZZZ,ZZ9.9999")), 1054, Gx_line+8, 1143, Gx_line+19, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+28);
                  if ( ! BRK7Q5 )
                  {
                     BRK7Q5 = true;
                     pr_default.readNext(1);
                  }
               }
               pr_default.close(1);
            }
            if ( StringUtil.StrCmp(AV37nAgrupa, "S") == 0 )
            {
               pr_default.dynParam(2, new Object[]{ new Object[]{
                                                    AV53SubLCod ,
                                                    A51SublCod ,
                                                    A1880StkAct ,
                                                    A1893SublSts } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT
                                                    }
               });
               /* Using cursor P007Q4 */
               pr_default.execute(2, new Object[] {AV53SubLCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  BRK7Q7 = false;
                  A28ProdCod = P007Q4_A28ProdCod[0];
                  A1893SublSts = P007Q4_A1893SublSts[0];
                  A51SublCod = P007Q4_A51SublCod[0];
                  n51SublCod = P007Q4_n51SublCod[0];
                  A1892SublDsc = P007Q4_A1892SublDsc[0];
                  A1880StkAct = P007Q4_A1880StkAct[0];
                  A1881StkIng = P007Q4_A1881StkIng[0];
                  A1882StkSal = P007Q4_A1882StkSal[0];
                  A63AlmCod = P007Q4_A63AlmCod[0];
                  A51SublCod = P007Q4_A51SublCod[0];
                  n51SublCod = P007Q4_n51SublCod[0];
                  A1893SublSts = P007Q4_A1893SublSts[0];
                  A1892SublDsc = P007Q4_A1892SublDsc[0];
                  while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007Q4_A1892SublDsc[0], A1892SublDsc) == 0 ) )
                  {
                     BRK7Q7 = false;
                     A28ProdCod = P007Q4_A28ProdCod[0];
                     A51SublCod = P007Q4_A51SublCod[0];
                     n51SublCod = P007Q4_n51SublCod[0];
                     A63AlmCod = P007Q4_A63AlmCod[0];
                     A51SublCod = P007Q4_A51SublCod[0];
                     n51SublCod = P007Q4_n51SublCod[0];
                     BRK7Q7 = true;
                     pr_default.readNext(2);
                  }
                  AV66SubLineaCod = A51SublCod;
                  AV65SubLinea = A1892SublDsc;
                  AV58TStk1 = 0.0000m;
                  AV59TStk2 = 0.0000m;
                  AV60TStk3 = 0.0000m;
                  AV61TStk4 = 0.0000m;
                  AV62TStk5 = 0.0000m;
                  AV63TStk6 = 0.0000m;
                  AV64TStk7 = 0.0000m;
                  AV57TStk = 0.0000m;
                  H7Q0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65SubLinea, "")), 14, Gx_line+4, 413, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  /* Execute user subroutine: 'VALIDAPRODUCTOS' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     this.cleanup();
                     if (true) return;
                  }
                  H7Q0( false, 27) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TStk7, "ZZZZ,ZZZ,ZZ9.9999")), 942, Gx_line+7, 1032, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TStk6, "ZZZZ,ZZZ,ZZ9.9999")), 846, Gx_line+7, 936, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TStk5, "ZZZZ,ZZZ,ZZ9.9999")), 760, Gx_line+7, 850, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TStk4, "ZZZZ,ZZZ,ZZ9.9999")), 674, Gx_line+7, 764, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TStk3, "ZZZZ,ZZZ,ZZ9.9999")), 584, Gx_line+7, 674, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TStk2, "ZZZZ,ZZZ,ZZ9.9999")), 499, Gx_line+7, 589, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TStk1, "ZZZZ,ZZZ,ZZ9.9999")), 421, Gx_line+7, 511, Gx_line+20, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65SubLinea, "")), 22, Gx_line+8, 421, Gx_line+19, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TStk, "ZZZZ,ZZZ,ZZ9.9999")), 1054, Gx_line+8, 1143, Gx_line+19, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+27);
                  if ( ! BRK7Q7 )
                  {
                     BRK7Q7 = true;
                     pr_default.readNext(2);
                  }
               }
               pr_default.close(2);
            }
            if ( StringUtil.StrCmp(AV37nAgrupa, "N") == 0 )
            {
               /* Execute user subroutine: 'VALIDAPRODUCTOS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7Q0( true, 0) ;
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
         /* 'VALIDAPRODUCTOS' Routine */
         returnInSub = false;
         AV32ITemProd = 1;
         if ( AV38nOrden == 1 )
         {
            /* Execute user subroutine: 'STOCKCODIGO' */
            S121 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'STOCKNOMBRE' */
            S131 ();
            if (returnInSub) return;
         }
      }

      protected void S121( )
      {
         /* 'STOCKCODIGO' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV16AlmCod ,
                                              AV35LineaCod ,
                                              AV66SubLineaCod ,
                                              AV28FamCod ,
                                              AV39Prodcod ,
                                              A63AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P007Q5 */
         pr_default.execute(3, new Object[] {AV16AlmCod, AV35LineaCod, AV66SubLineaCod, AV28FamCod, AV39Prodcod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7Q9 = false;
            A49UniCod = P007Q5_A49UniCod[0];
            A63AlmCod = P007Q5_A63AlmCod[0];
            A28ProdCod = P007Q5_A28ProdCod[0];
            A1158LinStk = P007Q5_A1158LinStk[0];
            A50FamCod = P007Q5_A50FamCod[0];
            n50FamCod = P007Q5_n50FamCod[0];
            A51SublCod = P007Q5_A51SublCod[0];
            n51SublCod = P007Q5_n51SublCod[0];
            A52LinCod = P007Q5_A52LinCod[0];
            A1997UniAbr = P007Q5_A1997UniAbr[0];
            A55ProdDsc = P007Q5_A55ProdDsc[0];
            A49UniCod = P007Q5_A49UniCod[0];
            A50FamCod = P007Q5_A50FamCod[0];
            n50FamCod = P007Q5_n50FamCod[0];
            A51SublCod = P007Q5_A51SublCod[0];
            n51SublCod = P007Q5_n51SublCod[0];
            A52LinCod = P007Q5_A52LinCod[0];
            A55ProdDsc = P007Q5_A55ProdDsc[0];
            A1997UniAbr = P007Q5_A1997UniAbr[0];
            A1158LinStk = P007Q5_A1158LinStk[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007Q5_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK7Q9 = false;
               A63AlmCod = P007Q5_A63AlmCod[0];
               BRK7Q9 = true;
               pr_default.readNext(3);
            }
            AV24Codigo = A28ProdCod;
            AV43Stk1 = 0.0000m;
            AV44Stk2 = 0.0000m;
            AV45Stk3 = 0.0000m;
            AV46Stk4 = 0.0000m;
            AV47Stk5 = 0.0000m;
            AV48Stk6 = 0.0000m;
            AV49Stk7 = 0.0000m;
            if ( ! (0==AV17Cod1) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV17Cod1, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV43Stk1) ;
            }
            if ( ! (0==AV18Cod2) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV18Cod2, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV44Stk2) ;
            }
            if ( ! (0==AV19Cod3) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV19Cod3, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV45Stk3) ;
            }
            if ( ! (0==AV20Cod4) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV20Cod4, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV46Stk4) ;
            }
            if ( ! (0==AV21Cod5) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV21Cod5, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV47Stk5) ;
            }
            if ( ! (0==AV22Cod6) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV22Cod6, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV48Stk6) ;
            }
            if ( ! (0==AV23Cod7) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV23Cod7, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV49Stk7) ;
            }
            AV50StkAct = (decimal)(AV43Stk1+AV44Stk2+AV45Stk3+AV46Stk4+AV47Stk5+AV48Stk6+AV49Stk7);
            if ( ! (Convert.ToDecimal(0)==AV50StkAct) )
            {
               H7Q0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 33, Gx_line+4, 109, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 1054, Gx_line+4, 1143, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 130, Gx_line+4, 391, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 398, Gx_line+4, 441, Gx_line+17, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32ITemProd), "ZZZZ9")), 0, Gx_line+4, 30, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43Stk1, "ZZZZ,ZZZ,ZZ9.9999")), 446, Gx_line+4, 536, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44Stk2, "ZZZZ,ZZZ,ZZ9.9999")), 524, Gx_line+4, 614, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Stk3, "ZZZZ,ZZZ,ZZ9.9999")), 609, Gx_line+4, 699, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Stk4, "ZZZZ,ZZZ,ZZ9.9999")), 699, Gx_line+4, 789, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Stk5, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+4, 875, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Stk6, "ZZZZ,ZZZ,ZZ9.9999")), 871, Gx_line+4, 961, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Stk7, "ZZZZ,ZZZ,ZZ9.9999")), 967, Gx_line+4, 1057, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV32ITemProd = (int)(AV32ITemProd+1);
            }
            AV58TStk1 = (decimal)(AV58TStk1+AV43Stk1);
            AV59TStk2 = (decimal)(AV59TStk2+AV44Stk2);
            AV60TStk3 = (decimal)(AV60TStk3+AV45Stk3);
            AV61TStk4 = (decimal)(AV61TStk4+AV46Stk4);
            AV62TStk5 = (decimal)(AV62TStk5+AV47Stk5);
            AV63TStk6 = (decimal)(AV63TStk6+AV48Stk6);
            AV64TStk7 = (decimal)(AV64TStk7+AV49Stk7);
            AV57TStk = (decimal)(AV57TStk+AV50StkAct);
            if ( ! BRK7Q9 )
            {
               BRK7Q9 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'STOCKNOMBRE' Routine */
         returnInSub = false;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV16AlmCod ,
                                              AV35LineaCod ,
                                              AV66SubLineaCod ,
                                              AV28FamCod ,
                                              AV39Prodcod ,
                                              A63AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P007Q6 */
         pr_default.execute(4, new Object[] {AV16AlmCod, AV35LineaCod, AV66SubLineaCod, AV28FamCod, AV39Prodcod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7Q11 = false;
            A49UniCod = P007Q6_A49UniCod[0];
            A1158LinStk = P007Q6_A1158LinStk[0];
            A63AlmCod = P007Q6_A63AlmCod[0];
            A55ProdDsc = P007Q6_A55ProdDsc[0];
            A28ProdCod = P007Q6_A28ProdCod[0];
            A50FamCod = P007Q6_A50FamCod[0];
            n50FamCod = P007Q6_n50FamCod[0];
            A51SublCod = P007Q6_A51SublCod[0];
            n51SublCod = P007Q6_n51SublCod[0];
            A52LinCod = P007Q6_A52LinCod[0];
            A1997UniAbr = P007Q6_A1997UniAbr[0];
            A49UniCod = P007Q6_A49UniCod[0];
            A55ProdDsc = P007Q6_A55ProdDsc[0];
            A50FamCod = P007Q6_A50FamCod[0];
            n50FamCod = P007Q6_n50FamCod[0];
            A51SublCod = P007Q6_A51SublCod[0];
            n51SublCod = P007Q6_n51SublCod[0];
            A52LinCod = P007Q6_A52LinCod[0];
            A1997UniAbr = P007Q6_A1997UniAbr[0];
            A1158LinStk = P007Q6_A1158LinStk[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P007Q6_A55ProdDsc[0], A55ProdDsc) == 0 ) )
            {
               BRK7Q11 = false;
               A63AlmCod = P007Q6_A63AlmCod[0];
               A28ProdCod = P007Q6_A28ProdCod[0];
               BRK7Q11 = true;
               pr_default.readNext(4);
            }
            AV24Codigo = A28ProdCod;
            AV43Stk1 = 0.0000m;
            AV44Stk2 = 0.0000m;
            AV45Stk3 = 0.0000m;
            AV46Stk4 = 0.0000m;
            AV47Stk5 = 0.0000m;
            AV48Stk6 = 0.0000m;
            AV49Stk7 = 0.0000m;
            if ( ! (0==AV17Cod1) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV17Cod1, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV43Stk1) ;
            }
            if ( ! (0==AV18Cod2) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV18Cod2, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV44Stk2) ;
            }
            if ( ! (0==AV19Cod3) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV19Cod3, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV45Stk3) ;
            }
            if ( ! (0==AV20Cod4) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV20Cod4, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV46Stk4) ;
            }
            if ( ! (0==AV21Cod5) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV21Cod5, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV47Stk5) ;
            }
            if ( ! (0==AV22Cod6) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV22Cod6, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV48Stk6) ;
            }
            if ( ! (0==AV23Cod7) )
            {
               new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV24Codigo, ref  AV23Cod7, ref  AV29FDesde, out  AV51StkIng, out  AV52StkSal, out  AV49Stk7) ;
            }
            AV50StkAct = (decimal)(AV43Stk1+AV44Stk2+AV45Stk3+AV46Stk4+AV47Stk5+AV48Stk6+AV49Stk7);
            if ( ! (Convert.ToDecimal(0)==AV50StkAct) )
            {
               H7Q0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 33, Gx_line+4, 109, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 1054, Gx_line+4, 1143, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 130, Gx_line+4, 391, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 398, Gx_line+4, 441, Gx_line+17, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32ITemProd), "ZZZZ9")), 0, Gx_line+4, 30, Gx_line+16, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43Stk1, "ZZZZ,ZZZ,ZZ9.9999")), 446, Gx_line+4, 536, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44Stk2, "ZZZZ,ZZZ,ZZ9.9999")), 524, Gx_line+4, 614, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Stk3, "ZZZZ,ZZZ,ZZ9.9999")), 609, Gx_line+4, 699, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Stk4, "ZZZZ,ZZZ,ZZ9.9999")), 699, Gx_line+4, 789, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Stk5, "ZZZZ,ZZZ,ZZ9.9999")), 785, Gx_line+4, 875, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Stk6, "ZZZZ,ZZZ,ZZ9.9999")), 871, Gx_line+4, 961, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Stk7, "ZZZZ,ZZZ,ZZ9.9999")), 967, Gx_line+4, 1057, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV32ITemProd = (int)(AV32ITemProd+1);
            }
            AV58TStk1 = (decimal)(AV58TStk1+AV43Stk1);
            AV59TStk2 = (decimal)(AV59TStk2+AV44Stk2);
            AV60TStk3 = (decimal)(AV60TStk3+AV45Stk3);
            AV61TStk4 = (decimal)(AV61TStk4+AV46Stk4);
            AV62TStk5 = (decimal)(AV62TStk5+AV47Stk5);
            AV63TStk6 = (decimal)(AV63TStk6+AV48Stk6);
            AV64TStk7 = (decimal)(AV64TStk7+AV49Stk7);
            AV57TStk = (decimal)(AV57TStk+AV50StkAct);
            if ( ! BRK7Q11 )
            {
               BRK7Q11 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void H7Q0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1029, Gx_line+31, 1061, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1029, Gx_line+49, 1073, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1029, Gx_line+14, 1068, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1095, Gx_line+49, 1134, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1075, Gx_line+31, 1132, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1086, Gx_line+14, 1133, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Titulo2, "")), 382, Gx_line+67, 838, Gx_line+92, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 1149, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 61, Gx_line+121, 97, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 174, Gx_line+121, 234, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Total", 1078, Gx_line+121, 1137, Gx_line+134, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV36Logo)) ? AV69Logo_GXI : AV36Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+5, 159, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Titulo, "")), 382, Gx_line+42, 838, Gx_line+67, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNM", 406, Gx_line+121, 431, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°", 16, Gx_line+121, 30, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Empresa, "")), 17, Gx_line+76, 325, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpRUC, "")), 17, Gx_line+94, 134, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Almacen1, "")), 480, Gx_line+121, 533, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Almacen2, "")), 558, Gx_line+121, 611, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen3, "")), 642, Gx_line+121, 695, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Almacen4, "")), 731, Gx_line+121, 784, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Almacen5, "")), 821, Gx_line+121, 874, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Almacen6, "")), 905, Gx_line+121, 958, Gx_line+134, 1+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Almacen7, "")), 997, Gx_line+121, 1050, Gx_line+134, 1+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+140);
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV42Session = context.GetSession();
         AV25EmpDir = "";
         AV27EmpRUC = "";
         AV40Ruta = "";
         AV36Logo = "";
         AV69Logo_GXI = "";
         AV54Titulo = "";
         AV8Almacen = "";
         AV55Titulo2 = "";
         AV9Almacen1 = "";
         AV10Almacen2 = "";
         AV11Almacen3 = "";
         AV12Almacen4 = "";
         AV13Almacen5 = "";
         AV14Almacen6 = "";
         AV15Almacen7 = "";
         scmdbuf = "";
         A28ProdCod = "";
         P007Q2_A28ProdCod = new string[] {""} ;
         P007Q2_A63AlmCod = new int[1] ;
         P007Q2_A438AlmSts = new short[1] ;
         P007Q2_A1158LinStk = new short[1] ;
         P007Q2_A50FamCod = new int[1] ;
         P007Q2_n50FamCod = new bool[] {false} ;
         P007Q2_A51SublCod = new int[1] ;
         P007Q2_n51SublCod = new bool[] {false} ;
         P007Q2_A52LinCod = new int[1] ;
         P007Q2_A433AlmAbr = new string[] {""} ;
         A433AlmAbr = "";
         P007Q3_A28ProdCod = new string[] {""} ;
         P007Q3_A1159LinSts = new short[1] ;
         P007Q3_A52LinCod = new int[1] ;
         P007Q3_A1153LinDsc = new string[] {""} ;
         P007Q3_A1880StkAct = new decimal[1] ;
         P007Q3_A1881StkIng = new decimal[1] ;
         P007Q3_A1882StkSal = new decimal[1] ;
         P007Q3_A63AlmCod = new int[1] ;
         A1153LinDsc = "";
         AV34Linea = "";
         P007Q4_A28ProdCod = new string[] {""} ;
         P007Q4_A1893SublSts = new short[1] ;
         P007Q4_A51SublCod = new int[1] ;
         P007Q4_n51SublCod = new bool[] {false} ;
         P007Q4_A1892SublDsc = new string[] {""} ;
         P007Q4_A1880StkAct = new decimal[1] ;
         P007Q4_A1881StkIng = new decimal[1] ;
         P007Q4_A1882StkSal = new decimal[1] ;
         P007Q4_A63AlmCod = new int[1] ;
         A1892SublDsc = "";
         AV65SubLinea = "";
         P007Q5_A49UniCod = new int[1] ;
         P007Q5_A63AlmCod = new int[1] ;
         P007Q5_A28ProdCod = new string[] {""} ;
         P007Q5_A1158LinStk = new short[1] ;
         P007Q5_A50FamCod = new int[1] ;
         P007Q5_n50FamCod = new bool[] {false} ;
         P007Q5_A51SublCod = new int[1] ;
         P007Q5_n51SublCod = new bool[] {false} ;
         P007Q5_A52LinCod = new int[1] ;
         P007Q5_A1997UniAbr = new string[] {""} ;
         P007Q5_A55ProdDsc = new string[] {""} ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         AV24Codigo = "";
         P007Q6_A49UniCod = new int[1] ;
         P007Q6_A1158LinStk = new short[1] ;
         P007Q6_A63AlmCod = new int[1] ;
         P007Q6_A55ProdDsc = new string[] {""} ;
         P007Q6_A28ProdCod = new string[] {""} ;
         P007Q6_A50FamCod = new int[1] ;
         P007Q6_n50FamCod = new bool[] {false} ;
         P007Q6_A51SublCod = new int[1] ;
         P007Q6_n51SublCod = new bool[] {false} ;
         P007Q6_A52LinCod = new int[1] ;
         P007Q6_A1997UniAbr = new string[] {""} ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV36Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactualconsolidadopdf__default(),
            new Object[][] {
                new Object[] {
               P007Q2_A28ProdCod, P007Q2_A63AlmCod, P007Q2_A438AlmSts, P007Q2_A1158LinStk, P007Q2_A50FamCod, P007Q2_n50FamCod, P007Q2_A51SublCod, P007Q2_n51SublCod, P007Q2_A52LinCod, P007Q2_A433AlmAbr
               }
               , new Object[] {
               P007Q3_A28ProdCod, P007Q3_A1159LinSts, P007Q3_A52LinCod, P007Q3_A1153LinDsc, P007Q3_A1880StkAct, P007Q3_A1881StkIng, P007Q3_A1882StkSal, P007Q3_A63AlmCod
               }
               , new Object[] {
               P007Q4_A28ProdCod, P007Q4_A1893SublSts, P007Q4_A51SublCod, P007Q4_n51SublCod, P007Q4_A1892SublDsc, P007Q4_A1880StkAct, P007Q4_A1881StkIng, P007Q4_A1882StkSal, P007Q4_A63AlmCod
               }
               , new Object[] {
               P007Q5_A49UniCod, P007Q5_A63AlmCod, P007Q5_A28ProdCod, P007Q5_A1158LinStk, P007Q5_A50FamCod, P007Q5_n50FamCod, P007Q5_A51SublCod, P007Q5_n51SublCod, P007Q5_A52LinCod, P007Q5_A1997UniAbr,
               P007Q5_A55ProdDsc
               }
               , new Object[] {
               P007Q6_A49UniCod, P007Q6_A1158LinStk, P007Q6_A63AlmCod, P007Q6_A55ProdDsc, P007Q6_A28ProdCod, P007Q6_A50FamCod, P007Q6_n50FamCod, P007Q6_A51SublCod, P007Q6_n51SublCod, P007Q6_A52LinCod,
               P007Q6_A1997UniAbr
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
      private short AV38nOrden ;
      private short A1158LinStk ;
      private short A438AlmSts ;
      private short A1159LinSts ;
      private short A1893SublSts ;
      private int AV33LinCod ;
      private int AV53SubLCod ;
      private int AV28FamCod ;
      private int AV16AlmCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV17Cod1 ;
      private int AV18Cod2 ;
      private int AV19Cod3 ;
      private int AV20Cod4 ;
      private int AV21Cod5 ;
      private int AV22Cod6 ;
      private int AV23Cod7 ;
      private int AV66SubLineaCod ;
      private int AV35LineaCod ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int Gx_OldLine ;
      private int AV32ITemProd ;
      private int A49UniCod ;
      private long AV31i ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV58TStk1 ;
      private decimal AV59TStk2 ;
      private decimal AV60TStk3 ;
      private decimal AV61TStk4 ;
      private decimal AV62TStk5 ;
      private decimal AV63TStk6 ;
      private decimal AV64TStk7 ;
      private decimal AV57TStk ;
      private decimal AV43Stk1 ;
      private decimal AV44Stk2 ;
      private decimal AV45Stk3 ;
      private decimal AV46Stk4 ;
      private decimal AV47Stk5 ;
      private decimal AV48Stk6 ;
      private decimal AV49Stk7 ;
      private decimal AV51StkIng ;
      private decimal AV52StkSal ;
      private decimal AV50StkAct ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV39Prodcod ;
      private string AV26Empresa ;
      private string AV25EmpDir ;
      private string AV27EmpRUC ;
      private string AV40Ruta ;
      private string AV54Titulo ;
      private string AV8Almacen ;
      private string AV55Titulo2 ;
      private string AV9Almacen1 ;
      private string AV10Almacen2 ;
      private string AV11Almacen3 ;
      private string AV12Almacen4 ;
      private string AV13Almacen5 ;
      private string AV14Almacen6 ;
      private string AV15Almacen7 ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A433AlmAbr ;
      private string A1153LinDsc ;
      private string AV34Linea ;
      private string A1892SublDsc ;
      private string AV65SubLinea ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string AV24Codigo ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV29FDesde ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK7Q3 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool BRK7Q5 ;
      private bool returnInSub ;
      private bool BRK7Q7 ;
      private bool BRK7Q9 ;
      private bool BRK7Q11 ;
      private string AV37nAgrupa ;
      private string AV69Logo_GXI ;
      private string AV36Logo ;
      private string Logo ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_nOrden ;
      private DateTime aP6_FDesde ;
      private string aP7_nAgrupa ;
      private IDataStoreProvider pr_default ;
      private string[] P007Q2_A28ProdCod ;
      private int[] P007Q2_A63AlmCod ;
      private short[] P007Q2_A438AlmSts ;
      private short[] P007Q2_A1158LinStk ;
      private int[] P007Q2_A50FamCod ;
      private bool[] P007Q2_n50FamCod ;
      private int[] P007Q2_A51SublCod ;
      private bool[] P007Q2_n51SublCod ;
      private int[] P007Q2_A52LinCod ;
      private string[] P007Q2_A433AlmAbr ;
      private string[] P007Q3_A28ProdCod ;
      private short[] P007Q3_A1159LinSts ;
      private int[] P007Q3_A52LinCod ;
      private string[] P007Q3_A1153LinDsc ;
      private decimal[] P007Q3_A1880StkAct ;
      private decimal[] P007Q3_A1881StkIng ;
      private decimal[] P007Q3_A1882StkSal ;
      private int[] P007Q3_A63AlmCod ;
      private string[] P007Q4_A28ProdCod ;
      private short[] P007Q4_A1893SublSts ;
      private int[] P007Q4_A51SublCod ;
      private bool[] P007Q4_n51SublCod ;
      private string[] P007Q4_A1892SublDsc ;
      private decimal[] P007Q4_A1880StkAct ;
      private decimal[] P007Q4_A1881StkIng ;
      private decimal[] P007Q4_A1882StkSal ;
      private int[] P007Q4_A63AlmCod ;
      private int[] P007Q5_A49UniCod ;
      private int[] P007Q5_A63AlmCod ;
      private string[] P007Q5_A28ProdCod ;
      private short[] P007Q5_A1158LinStk ;
      private int[] P007Q5_A50FamCod ;
      private bool[] P007Q5_n50FamCod ;
      private int[] P007Q5_A51SublCod ;
      private bool[] P007Q5_n51SublCod ;
      private int[] P007Q5_A52LinCod ;
      private string[] P007Q5_A1997UniAbr ;
      private string[] P007Q5_A55ProdDsc ;
      private int[] P007Q6_A49UniCod ;
      private short[] P007Q6_A1158LinStk ;
      private int[] P007Q6_A63AlmCod ;
      private string[] P007Q6_A55ProdDsc ;
      private string[] P007Q6_A28ProdCod ;
      private int[] P007Q6_A50FamCod ;
      private bool[] P007Q6_n50FamCod ;
      private int[] P007Q6_A51SublCod ;
      private bool[] P007Q6_n51SublCod ;
      private int[] P007Q6_A52LinCod ;
      private string[] P007Q6_A1997UniAbr ;
   }

   public class r_stockactualconsolidadopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Q2( IGxContext context ,
                                             int AV16AlmCod ,
                                             int AV33LinCod ,
                                             int AV53SubLCod ,
                                             int AV28FamCod ,
                                             string AV39Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             short A438AlmSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[AlmCod], T4.[AlmSts], T3.[LinStk], T2.[FamCod], T2.[SublCod], T2.[LinCod], T4.[AlmAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [CALMACEN] T4 ON T4.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T4.[AlmSts] = 1)");
         if ( ! (0==AV16AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV16AlmCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV33LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV33LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV53SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV53SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV28FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV28FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV39Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007Q3( IGxContext context ,
                                             int AV33LinCod ,
                                             int A52LinCod ,
                                             decimal A1880StkAct ,
                                             short A1159LinSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T3.[LinSts], T2.[LinCod], T3.[LinDsc], T1.[StkIng] - T1.[StkSal] AS StkAct, T1.[StkIng], T1.[StkSal], T1.[AlmCod] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(Not (T1.[StkIng] - T1.[StkSal] = convert(int, 0)))");
         AddWhere(sWhereString, "(Not (T2.[LinCod] = convert(int, 0)))");
         AddWhere(sWhereString, "(T3.[LinSts] = 1)");
         if ( ! (0==AV33LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV33LinCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[LinDsc], T2.[LinCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007Q4( IGxContext context ,
                                             int AV53SubLCod ,
                                             int A51SublCod ,
                                             decimal A1880StkAct ,
                                             short A1893SublSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T3.[SublSts], T2.[SublCod], T3.[SublDsc], T1.[StkIng] - T1.[StkSal] AS StkAct, T1.[StkIng], T1.[StkSal], T1.[AlmCod] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) LEFT JOIN [CSUBLPROD] T3 ON T3.[SublCod] = T2.[SublCod])";
         AddWhere(sWhereString, "(Not (T1.[StkIng] - T1.[StkSal] = convert(int, 0)))");
         AddWhere(sWhereString, "(Not (T2.[SublCod] = convert(int, 0)))");
         AddWhere(sWhereString, "(T3.[SublSts] = 1)");
         if ( ! (0==AV53SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV53SubLCod)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[SublDsc], T2.[SublCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007Q5( IGxContext context ,
                                             int AV16AlmCod ,
                                             int AV35LineaCod ,
                                             int AV66SubLineaCod ,
                                             int AV28FamCod ,
                                             string AV39Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[5];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[AlmCod], T1.[ProdCod], T4.[LinStk], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr], T2.[ProdDsc] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV16AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV16AlmCod)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV35LineaCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35LineaCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV66SubLineaCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV66SubLineaCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV28FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV28FamCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV39Prodcod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T1.[AlmCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P007Q6( IGxContext context ,
                                             int AV16AlmCod ,
                                             int AV35LineaCod ,
                                             int AV66SubLineaCod ,
                                             int AV28FamCod ,
                                             string AV39Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[5];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[LinStk], T1.[AlmCod], T2.[ProdDsc], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV16AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV16AlmCod)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ! (0==AV35LineaCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35LineaCod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (0==AV66SubLineaCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV66SubLineaCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV28FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV28FamCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV39Prodcod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProdDsc], T1.[AlmCod]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007Q2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] );
               case 1 :
                     return conditional_P007Q3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] );
               case 2 :
                     return conditional_P007Q4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] );
               case 3 :
                     return conditional_P007Q5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 4 :
                     return conditional_P007Q6(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007Q2;
          prmP007Q2 = new Object[] {
          new ParDef("@AV16AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV33LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV53SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV28FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV39Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007Q3;
          prmP007Q3 = new Object[] {
          new ParDef("@AV33LinCod",GXType.Int32,6,0)
          };
          Object[] prmP007Q4;
          prmP007Q4 = new Object[] {
          new ParDef("@AV53SubLCod",GXType.Int32,6,0)
          };
          Object[] prmP007Q5;
          prmP007Q5 = new Object[] {
          new ParDef("@AV16AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV66SubLineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV28FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV39Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007Q6;
          prmP007Q6 = new Object[] {
          new ParDef("@AV16AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35LineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV66SubLineaCod",GXType.Int32,6,0) ,
          new ParDef("@AV28FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV39Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Q5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007Q6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Q6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                return;
       }
    }

 }

}
