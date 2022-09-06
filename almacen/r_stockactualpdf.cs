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
   public class r_stockactualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_stockactualpdf.aspx")), "almacen.r_stockactualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_stockactualpdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "n_LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV35n_LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV37n_SubLCod = (int)(NumberUtil.Val( GetPar( "n_SubLCod"), "."));
                  AV34n_FamCod = (int)(NumberUtil.Val( GetPar( "n_FamCod"), "."));
                  AV33n_AlmCod = (int)(NumberUtil.Val( GetPar( "n_AlmCod"), "."));
                  AV31c_Prodcod = GetPar( "c_Prodcod");
                  AV36n_nOrden = (short)(NumberUtil.Val( GetPar( "n_nOrden"), "."));
                  AV32d_FDesde = context.localUtil.ParseDateParm( GetPar( "d_FDesde"));
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

      public r_stockactualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockactualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_n_LinCod ,
                           ref int aP1_n_SubLCod ,
                           ref int aP2_n_FamCod ,
                           ref int aP3_n_AlmCod ,
                           ref string aP4_c_Prodcod ,
                           ref short aP5_n_nOrden ,
                           ref DateTime aP6_d_FDesde )
      {
         this.AV35n_LinCod = aP0_n_LinCod;
         this.AV37n_SubLCod = aP1_n_SubLCod;
         this.AV34n_FamCod = aP2_n_FamCod;
         this.AV33n_AlmCod = aP3_n_AlmCod;
         this.AV31c_Prodcod = aP4_c_Prodcod;
         this.AV36n_nOrden = aP5_n_nOrden;
         this.AV32d_FDesde = aP6_d_FDesde;
         initialize();
         executePrivate();
         aP0_n_LinCod=this.AV35n_LinCod;
         aP1_n_SubLCod=this.AV37n_SubLCod;
         aP2_n_FamCod=this.AV34n_FamCod;
         aP3_n_AlmCod=this.AV33n_AlmCod;
         aP4_c_Prodcod=this.AV31c_Prodcod;
         aP5_n_nOrden=this.AV36n_nOrden;
         aP6_d_FDesde=this.AV32d_FDesde;
      }

      public DateTime executeUdp( ref int aP0_n_LinCod ,
                                  ref int aP1_n_SubLCod ,
                                  ref int aP2_n_FamCod ,
                                  ref int aP3_n_AlmCod ,
                                  ref string aP4_c_Prodcod ,
                                  ref short aP5_n_nOrden )
      {
         execute(ref aP0_n_LinCod, ref aP1_n_SubLCod, ref aP2_n_FamCod, ref aP3_n_AlmCod, ref aP4_c_Prodcod, ref aP5_n_nOrden, ref aP6_d_FDesde);
         return AV32d_FDesde ;
      }

      public void executeSubmit( ref int aP0_n_LinCod ,
                                 ref int aP1_n_SubLCod ,
                                 ref int aP2_n_FamCod ,
                                 ref int aP3_n_AlmCod ,
                                 ref string aP4_c_Prodcod ,
                                 ref short aP5_n_nOrden ,
                                 ref DateTime aP6_d_FDesde )
      {
         r_stockactualpdf objr_stockactualpdf;
         objr_stockactualpdf = new r_stockactualpdf();
         objr_stockactualpdf.AV35n_LinCod = aP0_n_LinCod;
         objr_stockactualpdf.AV37n_SubLCod = aP1_n_SubLCod;
         objr_stockactualpdf.AV34n_FamCod = aP2_n_FamCod;
         objr_stockactualpdf.AV33n_AlmCod = aP3_n_AlmCod;
         objr_stockactualpdf.AV31c_Prodcod = aP4_c_Prodcod;
         objr_stockactualpdf.AV36n_nOrden = aP5_n_nOrden;
         objr_stockactualpdf.AV32d_FDesde = aP6_d_FDesde;
         objr_stockactualpdf.context.SetSubmitInitialConfig(context);
         objr_stockactualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockactualpdf);
         aP0_n_LinCod=this.AV35n_LinCod;
         aP1_n_SubLCod=this.AV37n_SubLCod;
         aP2_n_FamCod=this.AV34n_FamCod;
         aP3_n_AlmCod=this.AV33n_AlmCod;
         aP4_c_Prodcod=this.AV31c_Prodcod;
         aP5_n_nOrden=this.AV36n_nOrden;
         aP6_d_FDesde=this.AV32d_FDesde;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockactualpdf)stateInfo).executePrivate();
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
            AV12Empresa = AV23Session.Get("Empresa");
            AV11EmpDir = AV23Session.Get("EmpDir");
            AV13EmpRUC = AV23Session.Get("EmpRUC");
            AV21Ruta = AV23Session.Get("RUTA") + "/Logo.jpg";
            AV18Logo = AV21Ruta;
            AV40Logo_GXI = GXDbFile.PathToUrl( AV21Ruta);
            AV28Titulo = "Stock Actual";
            AV8Almacen = "(Todos)";
            AV29Titulo2 = "Al : " + context.localUtil.DToC( AV32d_FDesde, 2, "/");
            AV30Total = 0;
            /* Using cursor P007K2 */
            pr_default.execute(0, new Object[] {AV33n_AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P007K2_A63AlmCod[0];
               A436AlmDsc = P007K2_A436AlmDsc[0];
               AV8Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV33n_AlmCod ,
                                                 AV35n_LinCod ,
                                                 AV37n_SubLCod ,
                                                 AV34n_FamCod ,
                                                 AV31c_Prodcod ,
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
            /* Using cursor P007K3 */
            pr_default.execute(1, new Object[] {AV33n_AlmCod, AV35n_LinCod, AV37n_SubLCod, AV34n_FamCod, AV31c_Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRK7K4 = false;
               A28ProdCod = P007K3_A28ProdCod[0];
               A63AlmCod = P007K3_A63AlmCod[0];
               A438AlmSts = P007K3_A438AlmSts[0];
               A50FamCod = P007K3_A50FamCod[0];
               n50FamCod = P007K3_n50FamCod[0];
               A51SublCod = P007K3_A51SublCod[0];
               n51SublCod = P007K3_n51SublCod[0];
               A52LinCod = P007K3_A52LinCod[0];
               A436AlmDsc = P007K3_A436AlmDsc[0];
               A50FamCod = P007K3_A50FamCod[0];
               n50FamCod = P007K3_n50FamCod[0];
               A51SublCod = P007K3_A51SublCod[0];
               n51SublCod = P007K3_n51SublCod[0];
               A52LinCod = P007K3_A52LinCod[0];
               A438AlmSts = P007K3_A438AlmSts[0];
               A436AlmDsc = P007K3_A436AlmDsc[0];
               while ( (pr_default.getStatus(1) != 101) && ( P007K3_A63AlmCod[0] == A63AlmCod ) )
               {
                  BRK7K4 = false;
                  A28ProdCod = P007K3_A28ProdCod[0];
                  BRK7K4 = true;
                  pr_default.readNext(1);
               }
               AV33n_AlmCod = A63AlmCod;
               AV16ITemProd = 1;
               H7K0( false, 23) ;
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
               if ( ! BRK7K4 )
               {
                  BRK7K4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            H7K0( false, 25) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total :", 600, Gx_line+7, 637, Gx_line+21, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30Total, "ZZZZ,ZZZ,ZZ9.9999")), 657, Gx_line+7, 764, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(655, Gx_line+3, 771, Gx_line+3, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+25);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H7K0( true, 0) ;
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
         if ( AV36n_nOrden == 1 )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV35n_LinCod ,
                                                 AV37n_SubLCod ,
                                                 AV34n_FamCod ,
                                                 AV31c_Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV33n_AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P007K4 */
            pr_default.execute(2, new Object[] {AV33n_AlmCod, AV35n_LinCod, AV37n_SubLCod, AV34n_FamCod, AV31c_Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A49UniCod = P007K4_A49UniCod[0];
               A1158LinStk = P007K4_A1158LinStk[0];
               A28ProdCod = P007K4_A28ProdCod[0];
               A50FamCod = P007K4_A50FamCod[0];
               n50FamCod = P007K4_n50FamCod[0];
               A51SublCod = P007K4_A51SublCod[0];
               n51SublCod = P007K4_n51SublCod[0];
               A52LinCod = P007K4_A52LinCod[0];
               A63AlmCod = P007K4_A63AlmCod[0];
               A1997UniAbr = P007K4_A1997UniAbr[0];
               A55ProdDsc = P007K4_A55ProdDsc[0];
               A1882StkSal = P007K4_A1882StkSal[0];
               A1881StkIng = P007K4_A1881StkIng[0];
               A49UniCod = P007K4_A49UniCod[0];
               A50FamCod = P007K4_A50FamCod[0];
               n50FamCod = P007K4_n50FamCod[0];
               A51SublCod = P007K4_A51SublCod[0];
               n51SublCod = P007K4_n51SublCod[0];
               A52LinCod = P007K4_A52LinCod[0];
               A55ProdDsc = P007K4_A55ProdDsc[0];
               A1997UniAbr = P007K4_A1997UniAbr[0];
               A1158LinStk = P007K4_A1158LinStk[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               AV10Codigo = A28ProdCod;
               AV26StkSal = A1882StkSal;
               AV25StkIng = A1881StkIng;
               AV24StkAct = A1880StkAct;
               if ( DateTimeUtil.ResetTime ( AV32d_FDesde ) != DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
               {
                  new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV10Codigo, ref  AV33n_AlmCod, ref  AV32d_FDesde, out  AV25StkIng, out  AV26StkSal, out  AV24StkAct) ;
               }
               if ( ! (Convert.ToDecimal(0)==AV24StkAct) )
               {
                  H7K0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 49, Gx_line+1, 144, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 657, Gx_line+1, 764, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 147, Gx_line+1, 563, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 578, Gx_line+1, 610, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16ITemProd), "ZZZZ9")), 4, Gx_line+1, 36, Gx_line+16, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV16ITemProd = (int)(AV16ITemProd+1);
                  AV30Total = (decimal)(AV30Total+AV24StkAct);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV35n_LinCod ,
                                                 AV37n_SubLCod ,
                                                 AV34n_FamCod ,
                                                 AV31c_Prodcod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1158LinStk ,
                                                 AV33n_AlmCod ,
                                                 A63AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P007K5 */
            pr_default.execute(3, new Object[] {AV33n_AlmCod, AV35n_LinCod, AV37n_SubLCod, AV34n_FamCod, AV31c_Prodcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49UniCod = P007K5_A49UniCod[0];
               A63AlmCod = P007K5_A63AlmCod[0];
               A1158LinStk = P007K5_A1158LinStk[0];
               A28ProdCod = P007K5_A28ProdCod[0];
               A50FamCod = P007K5_A50FamCod[0];
               n50FamCod = P007K5_n50FamCod[0];
               A51SublCod = P007K5_A51SublCod[0];
               n51SublCod = P007K5_n51SublCod[0];
               A52LinCod = P007K5_A52LinCod[0];
               A1997UniAbr = P007K5_A1997UniAbr[0];
               A55ProdDsc = P007K5_A55ProdDsc[0];
               A1882StkSal = P007K5_A1882StkSal[0];
               A1881StkIng = P007K5_A1881StkIng[0];
               A49UniCod = P007K5_A49UniCod[0];
               A50FamCod = P007K5_A50FamCod[0];
               n50FamCod = P007K5_n50FamCod[0];
               A51SublCod = P007K5_A51SublCod[0];
               n51SublCod = P007K5_n51SublCod[0];
               A52LinCod = P007K5_A52LinCod[0];
               A55ProdDsc = P007K5_A55ProdDsc[0];
               A1997UniAbr = P007K5_A1997UniAbr[0];
               A1158LinStk = P007K5_A1158LinStk[0];
               A1880StkAct = (decimal)(A1881StkIng-A1882StkSal);
               AV10Codigo = A28ProdCod;
               AV26StkSal = A1882StkSal;
               AV25StkIng = A1881StkIng;
               AV24StkAct = A1880StkAct;
               if ( DateTimeUtil.ResetTime ( AV32d_FDesde ) != DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
               {
                  new GeneXus.Programs.almacen.pobtenersaldoproductostockal(context ).execute( ref  AV10Codigo, ref  AV33n_AlmCod, ref  AV32d_FDesde, out  AV25StkIng, out  AV26StkSal, out  AV24StkAct) ;
               }
               if ( ! (Convert.ToDecimal(0)==AV24StkAct) )
               {
                  H7K0( false, 18) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 49, Gx_line+1, 144, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV24StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 657, Gx_line+1, 764, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 147, Gx_line+1, 563, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 578, Gx_line+1, 610, Gx_line+16, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV16ITemProd), "ZZZZ9")), 4, Gx_line+1, 36, Gx_line+16, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+18);
                  AV30Total = (decimal)(AV30Total+AV24StkAct);
                  AV16ITemProd = (int)(AV16ITemProd+1);
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
      }

      protected void H7K0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Titulo2, "")), 189, Gx_line+57, 645, Gx_line+82, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 796, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 68, Gx_line+119, 109, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 170, Gx_line+119, 239, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 680, Gx_line+119, 755, Gx_line+133, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV18Logo)) ? AV40Logo_GXI : AV18Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+5, 159, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Titulo, "")), 189, Gx_line+32, 645, Gx_line+57, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNM", 581, Gx_line+119, 608, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°", 20, Gx_line+119, 35, Gx_line+133, 0+256, 0, 0, 0) ;
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
         AV12Empresa = "";
         AV23Session = context.GetSession();
         AV11EmpDir = "";
         AV13EmpRUC = "";
         AV21Ruta = "";
         AV18Logo = "";
         AV40Logo_GXI = "";
         AV28Titulo = "";
         AV8Almacen = "";
         AV29Titulo2 = "";
         scmdbuf = "";
         P007K2_A63AlmCod = new int[1] ;
         P007K2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         A28ProdCod = "";
         P007K3_A28ProdCod = new string[] {""} ;
         P007K3_A63AlmCod = new int[1] ;
         P007K3_A438AlmSts = new short[1] ;
         P007K3_A50FamCod = new int[1] ;
         P007K3_n50FamCod = new bool[] {false} ;
         P007K3_A51SublCod = new int[1] ;
         P007K3_n51SublCod = new bool[] {false} ;
         P007K3_A52LinCod = new int[1] ;
         P007K3_A436AlmDsc = new string[] {""} ;
         P007K4_A49UniCod = new int[1] ;
         P007K4_A1158LinStk = new short[1] ;
         P007K4_A28ProdCod = new string[] {""} ;
         P007K4_A50FamCod = new int[1] ;
         P007K4_n50FamCod = new bool[] {false} ;
         P007K4_A51SublCod = new int[1] ;
         P007K4_n51SublCod = new bool[] {false} ;
         P007K4_A52LinCod = new int[1] ;
         P007K4_A63AlmCod = new int[1] ;
         P007K4_A1997UniAbr = new string[] {""} ;
         P007K4_A55ProdDsc = new string[] {""} ;
         P007K4_A1882StkSal = new decimal[1] ;
         P007K4_A1881StkIng = new decimal[1] ;
         A1997UniAbr = "";
         A55ProdDsc = "";
         AV10Codigo = "";
         P007K5_A49UniCod = new int[1] ;
         P007K5_A63AlmCod = new int[1] ;
         P007K5_A1158LinStk = new short[1] ;
         P007K5_A28ProdCod = new string[] {""} ;
         P007K5_A50FamCod = new int[1] ;
         P007K5_n50FamCod = new bool[] {false} ;
         P007K5_A51SublCod = new int[1] ;
         P007K5_n51SublCod = new bool[] {false} ;
         P007K5_A52LinCod = new int[1] ;
         P007K5_A1997UniAbr = new string[] {""} ;
         P007K5_A55ProdDsc = new string[] {""} ;
         P007K5_A1882StkSal = new decimal[1] ;
         P007K5_A1881StkIng = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV18Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockactualpdf__default(),
            new Object[][] {
                new Object[] {
               P007K2_A63AlmCod, P007K2_A436AlmDsc
               }
               , new Object[] {
               P007K3_A28ProdCod, P007K3_A63AlmCod, P007K3_A438AlmSts, P007K3_A50FamCod, P007K3_n50FamCod, P007K3_A51SublCod, P007K3_n51SublCod, P007K3_A52LinCod, P007K3_A436AlmDsc
               }
               , new Object[] {
               P007K4_A49UniCod, P007K4_A1158LinStk, P007K4_A28ProdCod, P007K4_A50FamCod, P007K4_n50FamCod, P007K4_A51SublCod, P007K4_n51SublCod, P007K4_A52LinCod, P007K4_A63AlmCod, P007K4_A1997UniAbr,
               P007K4_A55ProdDsc, P007K4_A1882StkSal, P007K4_A1881StkIng
               }
               , new Object[] {
               P007K5_A49UniCod, P007K5_A63AlmCod, P007K5_A1158LinStk, P007K5_A28ProdCod, P007K5_A50FamCod, P007K5_n50FamCod, P007K5_A51SublCod, P007K5_n51SublCod, P007K5_A52LinCod, P007K5_A1997UniAbr,
               P007K5_A55ProdDsc, P007K5_A1882StkSal, P007K5_A1881StkIng
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
      private short AV36n_nOrden ;
      private short A438AlmSts ;
      private short A1158LinStk ;
      private int AV35n_LinCod ;
      private int AV37n_SubLCod ;
      private int AV34n_FamCod ;
      private int AV33n_AlmCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int AV16ITemProd ;
      private int Gx_OldLine ;
      private int A49UniCod ;
      private decimal AV30Total ;
      private decimal A1882StkSal ;
      private decimal A1881StkIng ;
      private decimal A1880StkAct ;
      private decimal AV26StkSal ;
      private decimal AV25StkIng ;
      private decimal AV24StkAct ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV31c_Prodcod ;
      private string AV12Empresa ;
      private string AV11EmpDir ;
      private string AV13EmpRUC ;
      private string AV21Ruta ;
      private string AV28Titulo ;
      private string AV8Almacen ;
      private string AV29Titulo2 ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string A28ProdCod ;
      private string A1997UniAbr ;
      private string A55ProdDsc ;
      private string AV10Codigo ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV32d_FDesde ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK7K4 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV40Logo_GXI ;
      private string AV18Logo ;
      private string Logo ;
      private IGxSession AV23Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_n_LinCod ;
      private int aP1_n_SubLCod ;
      private int aP2_n_FamCod ;
      private int aP3_n_AlmCod ;
      private string aP4_c_Prodcod ;
      private short aP5_n_nOrden ;
      private DateTime aP6_d_FDesde ;
      private IDataStoreProvider pr_default ;
      private int[] P007K2_A63AlmCod ;
      private string[] P007K2_A436AlmDsc ;
      private string[] P007K3_A28ProdCod ;
      private int[] P007K3_A63AlmCod ;
      private short[] P007K3_A438AlmSts ;
      private int[] P007K3_A50FamCod ;
      private bool[] P007K3_n50FamCod ;
      private int[] P007K3_A51SublCod ;
      private bool[] P007K3_n51SublCod ;
      private int[] P007K3_A52LinCod ;
      private string[] P007K3_A436AlmDsc ;
      private int[] P007K4_A49UniCod ;
      private short[] P007K4_A1158LinStk ;
      private string[] P007K4_A28ProdCod ;
      private int[] P007K4_A50FamCod ;
      private bool[] P007K4_n50FamCod ;
      private int[] P007K4_A51SublCod ;
      private bool[] P007K4_n51SublCod ;
      private int[] P007K4_A52LinCod ;
      private int[] P007K4_A63AlmCod ;
      private string[] P007K4_A1997UniAbr ;
      private string[] P007K4_A55ProdDsc ;
      private decimal[] P007K4_A1882StkSal ;
      private decimal[] P007K4_A1881StkIng ;
      private int[] P007K5_A49UniCod ;
      private int[] P007K5_A63AlmCod ;
      private short[] P007K5_A1158LinStk ;
      private string[] P007K5_A28ProdCod ;
      private int[] P007K5_A50FamCod ;
      private bool[] P007K5_n50FamCod ;
      private int[] P007K5_A51SublCod ;
      private bool[] P007K5_n51SublCod ;
      private int[] P007K5_A52LinCod ;
      private string[] P007K5_A1997UniAbr ;
      private string[] P007K5_A55ProdDsc ;
      private decimal[] P007K5_A1882StkSal ;
      private decimal[] P007K5_A1881StkIng ;
   }

   public class r_stockactualpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007K3( IGxContext context ,
                                             int AV33n_AlmCod ,
                                             int AV35n_LinCod ,
                                             int AV37n_SubLCod ,
                                             int AV34n_FamCod ,
                                             string AV31c_Prodcod ,
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
         if ( ! (0==AV33n_AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV33n_AlmCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV35n_LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35n_LinCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV37n_SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV37n_SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV34n_FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV34n_FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31c_Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31c_Prodcod)");
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

      protected Object[] conditional_P007K4( IGxContext context ,
                                             int AV35n_LinCod ,
                                             int AV37n_SubLCod ,
                                             int AV34n_FamCod ,
                                             string AV31c_Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV33n_AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T1.[AlmCod], T3.[UniAbr], T2.[ProdDsc], T1.[StkSal], T1.[StkIng] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV33n_AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV35n_LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35n_LinCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV37n_SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV37n_SubLCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV34n_FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV34n_FamCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31c_Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31c_Prodcod)");
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

      protected Object[] conditional_P007K5( IGxContext context ,
                                             int AV35n_LinCod ,
                                             int AV37n_SubLCod ,
                                             int AV34n_FamCod ,
                                             string AV31c_Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             short A1158LinStk ,
                                             int AV33n_AlmCod ,
                                             int A63AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[AlmCod], T4.[LinStk], T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[UniAbr], T2.[ProdDsc], T1.[StkSal], T1.[StkIng] FROM ((([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T2.[LinCod])";
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV33n_AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV35n_LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35n_LinCod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (0==AV37n_SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV37n_SubLCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV34n_FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV34n_FamCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31c_Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31c_Prodcod)");
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
                     return conditional_P007K3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 2 :
                     return conditional_P007K4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 3 :
                     return conditional_P007K5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
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
          Object[] prmP007K2;
          prmP007K2 = new Object[] {
          new ParDef("@AV33n_AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP007K3;
          prmP007K3 = new Object[] {
          new ParDef("@AV33n_AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35n_LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV37n_SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV34n_FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV31c_Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007K4;
          prmP007K4 = new Object[] {
          new ParDef("@AV33n_AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35n_LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV37n_SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV34n_FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV31c_Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP007K5;
          prmP007K5 = new Object[] {
          new ParDef("@AV33n_AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35n_LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV37n_SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV34n_FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV31c_Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007K2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV33n_AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007K5,100, GxCacheFrequency.OFF ,true,false )
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
       }
    }

 }

}
