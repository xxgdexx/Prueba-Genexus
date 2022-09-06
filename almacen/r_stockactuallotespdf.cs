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
   public class r_stockactuallotespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_stockactuallotespdf.aspx")), "almacen.r_stockactuallotespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_stockactuallotespdf.aspx")))) ;
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
               AV19LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV38SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV15FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV22Prodcod = GetPar( "Prodcod");
                  AV21nOrden = (short)(NumberUtil.Val( GetPar( "nOrden"), "."));
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

      public r_stockactuallotespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactuallotespdf( IGxContext context )
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
                           ref short aP5_nOrden )
      {
         this.AV19LinCod = aP0_LinCod;
         this.AV38SubLCod = aP1_SubLCod;
         this.AV15FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV22Prodcod = aP4_Prodcod;
         this.AV21nOrden = aP5_nOrden;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV19LinCod;
         aP1_SubLCod=this.AV38SubLCod;
         aP2_FamCod=this.AV15FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV22Prodcod;
         aP5_nOrden=this.AV21nOrden;
      }

      public short executeUdp( ref int aP0_LinCod ,
                               ref int aP1_SubLCod ,
                               ref int aP2_FamCod ,
                               ref int aP3_AlmCod ,
                               ref string aP4_Prodcod )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_nOrden);
         return AV21nOrden ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_nOrden )
      {
         r_stockactuallotespdf objr_stockactuallotespdf;
         objr_stockactuallotespdf = new r_stockactuallotespdf();
         objr_stockactuallotespdf.AV19LinCod = aP0_LinCod;
         objr_stockactuallotespdf.AV38SubLCod = aP1_SubLCod;
         objr_stockactuallotespdf.AV15FamCod = aP2_FamCod;
         objr_stockactuallotespdf.AV9AlmCod = aP3_AlmCod;
         objr_stockactuallotespdf.AV22Prodcod = aP4_Prodcod;
         objr_stockactuallotespdf.AV21nOrden = aP5_nOrden;
         objr_stockactuallotespdf.context.SetSubmitInitialConfig(context);
         objr_stockactuallotespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockactuallotespdf);
         aP0_LinCod=this.AV19LinCod;
         aP1_SubLCod=this.AV38SubLCod;
         aP2_FamCod=this.AV15FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV22Prodcod;
         aP5_nOrden=this.AV21nOrden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockactuallotespdf)stateInfo).executePrivate();
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
            AV12Empresa = AV26Session.Get("Empresa");
            AV11EmpDir = AV26Session.Get("EmpDir");
            AV13EmpRUC = AV26Session.Get("EmpRUC");
            AV24Ruta = AV26Session.Get("RUTA") + "/Logo.jpg";
            AV20Logo = AV24Ruta;
            AV43Logo_GXI = GXDbFile.PathToUrl( AV24Ruta);
            AV39Titulo = "Stock Actual por Lotes";
            AV8Almacen = "(Todos)";
            AV16FDesde = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV40Titulo2 = "Al : " + context.localUtil.DToC( AV16FDesde, 2, "/");
            /* Using cursor P00842 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00842_A63AlmCod[0];
               A436AlmDsc = P00842_A436AlmDsc[0];
               AV8Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV9AlmCod ,
                                                 AV19LinCod ,
                                                 AV38SubLCod ,
                                                 AV15FamCod ,
                                                 AV22Prodcod ,
                                                 A63AlmCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A438AlmSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00843 */
            pr_default.execute(1, new Object[] {AV9AlmCod, AV19LinCod, AV38SubLCod, AV15FamCod, AV22Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRK844 = false;
               A28ProdCod = P00843_A28ProdCod[0];
               A63AlmCod = P00843_A63AlmCod[0];
               A438AlmSts = P00843_A438AlmSts[0];
               A50FamCod = P00843_A50FamCod[0];
               n50FamCod = P00843_n50FamCod[0];
               A51SublCod = P00843_A51SublCod[0];
               n51SublCod = P00843_n51SublCod[0];
               A52LinCod = P00843_A52LinCod[0];
               A436AlmDsc = P00843_A436AlmDsc[0];
               A50FamCod = P00843_A50FamCod[0];
               n50FamCod = P00843_n50FamCod[0];
               A51SublCod = P00843_A51SublCod[0];
               n51SublCod = P00843_n51SublCod[0];
               A52LinCod = P00843_A52LinCod[0];
               A438AlmSts = P00843_A438AlmSts[0];
               A436AlmDsc = P00843_A436AlmDsc[0];
               while ( (pr_default.getStatus(1) != 101) && ( P00843_A63AlmCod[0] == A63AlmCod ) )
               {
                  BRK844 = false;
                  A28ProdCod = P00843_A28ProdCod[0];
                  BRK844 = true;
                  pr_default.readNext(1);
               }
               AV9AlmCod = A63AlmCod;
               AV18ITemProd = 1;
               H840( false, 23) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A436AlmDsc, "")), 4, Gx_line+5, 630, Gx_line+21, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               /* Execute user subroutine: 'DETALLES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK844 )
               {
                  BRK844 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H840( true, 0) ;
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
         /* 'DETALLES' Routine */
         returnInSub = false;
         if ( AV21nOrden == 1 )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV19LinCod ,
                                                 AV38SubLCod ,
                                                 AV15FamCod ,
                                                 AV22Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV9AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00844 */
            pr_default.execute(2, new Object[] {AV9AlmCod, AV19LinCod, AV38SubLCod, AV15FamCod, AV22Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P00844_A49UniCod[0];
               A1158LinStk = P00844_A1158LinStk[0];
               A28ProdCod = P00844_A28ProdCod[0];
               A50FamCod = P00844_A50FamCod[0];
               n50FamCod = P00844_n50FamCod[0];
               A51SublCod = P00844_A51SublCod[0];
               n51SublCod = P00844_n51SublCod[0];
               A52LinCod = P00844_A52LinCod[0];
               A63AlmCod = P00844_A63AlmCod[0];
               A1997UniAbr = P00844_A1997UniAbr[0];
               A55ProdDsc = P00844_A55ProdDsc[0];
               A1882StkSal = P00844_A1882StkSal[0];
               A1881StkIng = P00844_A1881StkIng[0];
               A49UniCod = P00844_A49UniCod[0];
               A50FamCod = P00844_A50FamCod[0];
               n50FamCod = P00844_n50FamCod[0];
               A51SublCod = P00844_A51SublCod[0];
               n51SublCod = P00844_n51SublCod[0];
               A52LinCod = P00844_A52LinCod[0];
               A55ProdDsc = P00844_A55ProdDsc[0];
               A1997UniAbr = P00844_A1997UniAbr[0];
               A1158LinStk = P00844_A1158LinStk[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               AV10Codigo = A28ProdCod;
               AV37Stock = A1880StkAct;
               AV27StkAct = A1880StkAct;
               AV31StkIng = A1881StkIng;
               AV36StkSal = A1882StkSal;
               if ( ! (Convert.ToDecimal(0)==AV37Stock) )
               {
                  H840( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 49, Gx_line+0, 144, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 147, Gx_line+0, 478, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 481, Gx_line+0, 513, Gx_line+20, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ITemProd), "ZZZZ9")), 4, Gx_line+3, 41, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31StkIng, "ZZZZ,ZZZ,ZZ9.9999")), 500, Gx_line+3, 607, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36StkSal, "ZZZZ,ZZZ,ZZ9.9999")), 577, Gx_line+3, 684, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 658, Gx_line+3, 765, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  /* Execute user subroutine: 'LOTESPRODUCTO' */
                  S126 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     returnInSub = true;
                     if (true) return;
                  }
                  AV18ITemProd = (int)(AV18ITemProd+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV19LinCod ,
                                                 AV38SubLCod ,
                                                 AV15FamCod ,
                                                 AV22Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV9AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00845 */
            pr_default.execute(3, new Object[] {AV9AlmCod, AV19LinCod, AV38SubLCod, AV15FamCod, AV22Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49UniCod = P00845_A49UniCod[0];
               A63AlmCod = P00845_A63AlmCod[0];
               A1158LinStk = P00845_A1158LinStk[0];
               A28ProdCod = P00845_A28ProdCod[0];
               A50FamCod = P00845_A50FamCod[0];
               n50FamCod = P00845_n50FamCod[0];
               A51SublCod = P00845_A51SublCod[0];
               n51SublCod = P00845_n51SublCod[0];
               A52LinCod = P00845_A52LinCod[0];
               A1997UniAbr = P00845_A1997UniAbr[0];
               A55ProdDsc = P00845_A55ProdDsc[0];
               A1882StkSal = P00845_A1882StkSal[0];
               A1881StkIng = P00845_A1881StkIng[0];
               A49UniCod = P00845_A49UniCod[0];
               A50FamCod = P00845_A50FamCod[0];
               n50FamCod = P00845_n50FamCod[0];
               A51SublCod = P00845_A51SublCod[0];
               n51SublCod = P00845_n51SublCod[0];
               A52LinCod = P00845_A52LinCod[0];
               A55ProdDsc = P00845_A55ProdDsc[0];
               A1997UniAbr = P00845_A1997UniAbr[0];
               A1158LinStk = P00845_A1158LinStk[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               AV10Codigo = A28ProdCod;
               AV37Stock = A1880StkAct;
               AV27StkAct = A1880StkAct;
               AV31StkIng = A1881StkIng;
               AV36StkSal = A1882StkSal;
               if ( ! (Convert.ToDecimal(0)==AV37Stock) )
               {
                  H840( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 49, Gx_line+0, 144, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 147, Gx_line+0, 478, Gx_line+20, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 481, Gx_line+0, 513, Gx_line+20, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18ITemProd), "ZZZZ9")), 4, Gx_line+3, 41, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31StkIng, "ZZZZ,ZZZ,ZZ9.9999")), 500, Gx_line+3, 607, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36StkSal, "ZZZZ,ZZZ,ZZ9.9999")), 577, Gx_line+3, 684, Gx_line+18, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 658, Gx_line+3, 765, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  /* Execute user subroutine: 'LOTESPRODUCTO' */
                  S126 ();
                  if ( returnInSub )
                  {
                     pr_default.close(3);
                     returnInSub = true;
                     if (true) return;
                  }
                  AV18ITemProd = (int)(AV18ITemProd+1);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
      }

      protected void S126( )
      {
         /* 'LOTESPRODUCTO' Routine */
         returnInSub = false;
         /* Using cursor P00846 */
         pr_default.execute(4, new Object[] {AV9AlmCod, AV10Codigo});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A28ProdCod = P00846_A28ProdCod[0];
            A63AlmCod = P00846_A63AlmCod[0];
            A64StkRef1 = P00846_A64StkRef1[0];
            A1888StkRef2 = P00846_A1888StkRef2[0];
            A1889StkRef3 = P00846_A1889StkRef3[0];
            A1890StkRef4 = P00846_A1890StkRef4[0];
            A1887StkDSts = P00846_A1887StkDSts[0];
            A1885StkDSal = P00846_A1885StkDSal[0];
            A1884StkDIng = P00846_A1884StkDIng[0];
            A1883StkDAct = (decimal)(A1884StkDIng-A1885StkDSal);
            AV32StkRef1 = A64StkRef1;
            AV33StkRef2 = A1888StkRef2;
            AV34StkRef3 = A1889StkRef3;
            AV35StkRef4 = A1890StkRef4;
            AV29StkDIng = A1884StkDIng;
            AV30StkDSal = A1885StkDSal;
            AV28StkDAct = A1883StkDAct;
            AV23Referencia = StringUtil.Trim( AV32StkRef1) + " " + StringUtil.Trim( AV33StkRef2) + " " + StringUtil.Trim( AV34StkRef3) + " " + StringUtil.Trim( AV35StkRef4);
            AV14Estado = ((A1887StkDSts==1) ? "P" : "");
            if ( ( AV28StkDAct > Convert.ToDecimal( 0 )) )
            {
               H840( false, 16) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Referencia, "")), 58, Gx_line+0, 511, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV28StkDAct, "ZZZZ,ZZZ,ZZ9.9999")), 500, Gx_line+0, 607, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Estado, "")), 769, Gx_line+0, 780, Gx_line+15, 1+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+16);
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void H840( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 663, Gx_line+40, 695, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 663, Gx_line+57, 707, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 663, Gx_line+22, 702, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 728, Gx_line+57, 767, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 708, Gx_line+40, 765, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 720, Gx_line+22, 767, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Titulo2, "")), 189, Gx_line+57, 645, Gx_line+82, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 796, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 68, Gx_line+118, 109, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 170, Gx_line+118, 239, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Ing.", 527, Gx_line+118, 587, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Sal.", 605, Gx_line+118, 663, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 676, Gx_line+118, 751, Gx_line+132, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20Logo)) ? AV43Logo_GXI : AV20Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+5, 159, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Titulo, "")), 189, Gx_line+32, 645, Gx_line+57, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNM", 484, Gx_line+118, 511, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°", 20, Gx_line+118, 35, Gx_line+132, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Empresa, "")), 17, Gx_line+76, 325, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13EmpRUC, "")), 17, Gx_line+94, 134, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8Almacen, "")), 189, Gx_line+82, 645, Gx_line+107, 1, 0, 0, 0) ;
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
         AV12Empresa = "";
         AV26Session = context.GetSession();
         AV11EmpDir = "";
         AV13EmpRUC = "";
         AV24Ruta = "";
         AV20Logo = "";
         AV43Logo_GXI = "";
         AV39Titulo = "";
         AV8Almacen = "";
         AV16FDesde = DateTime.MinValue;
         AV40Titulo2 = "";
         scmdbuf = "";
         P00842_A63AlmCod = new int[1] ;
         P00842_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         A28ProdCod = "";
         P00843_A28ProdCod = new string[] {""} ;
         P00843_A63AlmCod = new int[1] ;
         P00843_A438AlmSts = new short[1] ;
         P00843_A50FamCod = new int[1] ;
         P00843_n50FamCod = new bool[] {false} ;
         P00843_A51SublCod = new int[1] ;
         P00843_n51SublCod = new bool[] {false} ;
         P00843_A52LinCod = new int[1] ;
         P00843_A436AlmDsc = new string[] {""} ;
         P00844_A49UniCod = new int[1] ;
         P00844_A1158LinStk = new short[1] ;
         P00844_A28ProdCod = new string[] {""} ;
         P00844_A50FamCod = new int[1] ;
         P00844_n50FamCod = new bool[] {false} ;
         P00844_A51SublCod = new int[1] ;
         P00844_n51SublCod = new bool[] {false} ;
         P00844_A52LinCod = new int[1] ;
         P00844_A63AlmCod = new int[1] ;
         P00844_A1997UniAbr = new string[] {""} ;
         P00844_A55ProdDsc = new string[] {""} ;
         P00844_A1882StkSal = new decimal[1] ;
         P00844_A1881StkIng = new decimal[1] ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         AV10Codigo = "";
         P00845_A49UniCod = new int[1] ;
         P00845_A63AlmCod = new int[1] ;
         P00845_A1158LinStk = new short[1] ;
         P00845_A28ProdCod = new string[] {""} ;
         P00845_A50FamCod = new int[1] ;
         P00845_n50FamCod = new bool[] {false} ;
         P00845_A51SublCod = new int[1] ;
         P00845_n51SublCod = new bool[] {false} ;
         P00845_A52LinCod = new int[1] ;
         P00845_A1997UniAbr = new string[] {""} ;
         P00845_A55ProdDsc = new string[] {""} ;
         P00845_A1882StkSal = new decimal[1] ;
         P00845_A1881StkIng = new decimal[1] ;
         P00846_A28ProdCod = new string[] {""} ;
         P00846_A63AlmCod = new int[1] ;
         P00846_A64StkRef1 = new string[] {""} ;
         P00846_A1888StkRef2 = new string[] {""} ;
         P00846_A1889StkRef3 = new string[] {""} ;
         P00846_A1890StkRef4 = new string[] {""} ;
         P00846_A1887StkDSts = new short[1] ;
         P00846_A1885StkDSal = new decimal[1] ;
         P00846_A1884StkDIng = new decimal[1] ;
         A64StkRef1 = "";
         A1888StkRef2 = "";
         A1889StkRef3 = "";
         A1890StkRef4 = "";
         AV32StkRef1 = "";
         AV33StkRef2 = "";
         AV34StkRef3 = "";
         AV35StkRef4 = "";
         AV23Referencia = "";
         AV14Estado = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV20Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactuallotespdf__default(),
            new Object[][] {
                new Object[] {
               P00842_A63AlmCod, P00842_A436AlmDsc
               }
               , new Object[] {
               P00843_A28ProdCod, P00843_A63AlmCod, P00843_A438AlmSts, P00843_A50FamCod, P00843_n50FamCod, P00843_A51SublCod, P00843_n51SublCod, P00843_A52LinCod, P00843_A436AlmDsc
               }
               , new Object[] {
               P00844_A49UniCod, P00844_A1158LinStk, P00844_A28ProdCod, P00844_A50FamCod, P00844_n50FamCod, P00844_A51SublCod, P00844_n51SublCod, P00844_A52LinCod, P00844_A63AlmCod, P00844_A1997UniAbr,
               P00844_A55ProdDsc, P00844_A1882StkSal, P00844_A1881StkIng
               }
               , new Object[] {
               P00845_A49UniCod, P00845_A63AlmCod, P00845_A1158LinStk, P00845_A28ProdCod, P00845_A50FamCod, P00845_n50FamCod, P00845_A51SublCod, P00845_n51SublCod, P00845_A52LinCod, P00845_A1997UniAbr,
               P00845_A55ProdDsc, P00845_A1882StkSal, P00845_A1881StkIng
               }
               , new Object[] {
               P00846_A28ProdCod, P00846_A63AlmCod, P00846_A64StkRef1, P00846_A1888StkRef2, P00846_A1889StkRef3, P00846_A1890StkRef4, P00846_A1887StkDSts, P00846_A1885StkDSal, P00846_A1884StkDIng
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
      private short AV21nOrden ;
      private short A438AlmSts ;
      private short A1158LinStk ;
      private short A1887StkDSts ;
      private int AV19LinCod ;
      private int AV38SubLCod ;
      private int AV15FamCod ;
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
      private int AV18ITemProd ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private decimal A1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1880StkAct ;
      private decimal AV37Stock ;
      private decimal AV27StkAct ;
      private decimal AV31StkIng ;
      private decimal AV36StkSal ;
      private decimal A1885StkDSal ;
      private decimal A1884StkDIng ;
      private decimal A1883StkDAct ;
      private decimal AV29StkDIng ;
      private decimal AV30StkDSal ;
      private decimal AV28StkDAct ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV22Prodcod ;
      private string AV12Empresa ;
      private string AV11EmpDir ;
      private string AV13EmpRUC ;
      private string AV24Ruta ;
      private string AV39Titulo ;
      private string AV8Almacen ;
      private string AV40Titulo2 ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string A28ProdCod ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string AV10Codigo ;
      private string AV14Estado ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV16FDesde ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK844 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV43Logo_GXI ;
      private string A64StkRef1 ;
      private string A1888StkRef2 ;
      private string A1889StkRef3 ;
      private string A1890StkRef4 ;
      private string AV32StkRef1 ;
      private string AV33StkRef2 ;
      private string AV34StkRef3 ;
      private string AV35StkRef4 ;
      private string AV23Referencia ;
      private string AV20Logo ;
      private string Logo ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_nOrden ;
      private IDataStoreProvider pr_default ;
      private int[] P00842_A63AlmCod ;
      private string[] P00842_A436AlmDsc ;
      private string[] P00843_A28ProdCod ;
      private int[] P00843_A63AlmCod ;
      private short[] P00843_A438AlmSts ;
      private int[] P00843_A50FamCod ;
      private bool[] P00843_n50FamCod ;
      private int[] P00843_A51SublCod ;
      private bool[] P00843_n51SublCod ;
      private int[] P00843_A52LinCod ;
      private string[] P00843_A436AlmDsc ;
      private int[] P00844_A49UniCod ;
      private short[] P00844_A1158LinStk ;
      private string[] P00844_A28ProdCod ;
      private int[] P00844_A50FamCod ;
      private bool[] P00844_n50FamCod ;
      private int[] P00844_A51SublCod ;
      private bool[] P00844_n51SublCod ;
      private int[] P00844_A52LinCod ;
      private int[] P00844_A63AlmCod ;
      private string[] P00844_A1997UniAbr ;
      private string[] P00844_A55ProdDsc ;
      private decimal[] P00844_A1882StkSal ;
      private decimal[] P00844_A1881StkIng ;
      private int[] P00845_A49UniCod ;
      private int[] P00845_A63AlmCod ;
      private short[] P00845_A1158LinStk ;
      private string[] P00845_A28ProdCod ;
      private int[] P00845_A50FamCod ;
      private bool[] P00845_n50FamCod ;
      private int[] P00845_A51SublCod ;
      private bool[] P00845_n51SublCod ;
      private int[] P00845_A52LinCod ;
      private string[] P00845_A1997UniAbr ;
      private string[] P00845_A55ProdDsc ;
      private decimal[] P00845_A1882StkSal ;
      private decimal[] P00845_A1881StkIng ;
      private string[] P00846_A28ProdCod ;
      private int[] P00846_A63AlmCod ;
      private string[] P00846_A64StkRef1 ;
      private string[] P00846_A1888StkRef2 ;
      private string[] P00846_A1889StkRef3 ;
      private string[] P00846_A1890StkRef4 ;
      private short[] P00846_A1887StkDSts ;
      private decimal[] P00846_A1885StkDSal ;
      private decimal[] P00846_A1884StkDIng ;
   }

   public class r_stockactuallotespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00843( IGxContext context ,
                                             int AV9AlmCod ,
                                             int AV19LinCod ,
                                             int AV38SubLCod ,
                                             int AV15FamCod ,
                                             string AV22Prodcod ,
                                             int A63AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A438AlmSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[AlmCod], T3.[AlmSts], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[AlmDsc] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(T3.[AlmSts] = 1)");
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV19LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV19LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV38SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV38SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV15FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV15FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV22Prodcod)");
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

      protected Object[] conditional_P00844( IGxContext context ,
                                             int AV19LinCod ,
                                             int AV38SubLCod ,
                                             int AV15FamCod ,
                                             string AV22Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV9AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T1.[AlmCod], T3.[UniAbr], T2.[ProdDsc], T1.[StkSal], T1.[StkIng] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV19LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV19LinCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV38SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV38SubLCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV15FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV15FamCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV22Prodcod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00845( IGxContext context ,
                                             int AV19LinCod ,
                                             int AV38SubLCod ,
                                             int AV15FamCod ,
                                             string AV22Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV9AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[AlmCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr], T2.[ProdDsc], T1.[StkSal], T1.[StkIng] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV19LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV19LinCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV38SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV38SubLCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV15FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV15FamCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV22Prodcod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T2.[ProdDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00843(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 2 :
                     return conditional_P00844(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 3 :
                     return conditional_P00845(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmP00842;
          prmP00842 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00846;
          prmP00846 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Codigo",GXType.NChar,15,0)
          };
          Object[] prmP00843;
          prmP00843 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV19LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV38SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV15FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV22Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00844;
          prmP00844 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV19LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV38SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV15FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV22Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00845;
          prmP00845 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV19LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV38SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV15FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV22Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00842", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00842,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00843", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00843,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00844", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00844,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00845", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00845,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00846", "SELECT [ProdCod], [AlmCod], [StkRef1], [StkRef2], [StkRef3], [StkRef4], [StkDSts], [StkDSal], [StkDIng] FROM [ASTOCKACTUALDET] WHERE [AlmCod] = @AV9AlmCod and [ProdCod] = @AV10Codigo ORDER BY [AlmCod], [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00846,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((int[]) buf[7])[0] = rslt.getInt(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                return;
       }
    }

 }

}
