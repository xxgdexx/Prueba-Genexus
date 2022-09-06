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
   public class rrinventariofisico : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrinventariofisico.aspx")), "rrinventariofisico.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrinventariofisico.aspx")))) ;
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
                  AV15SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV23FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV22nOrden = (short)(NumberUtil.Val( GetPar( "nOrden"), "."));
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

      public rrinventariofisico( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrinventariofisico( IGxContext context )
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
                           ref short aP4_nOrden )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV15SubLCod = aP1_SubLCod;
         this.AV23FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV22nOrden = aP4_nOrden;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SubLCod=this.AV15SubLCod;
         aP2_FamCod=this.AV23FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_nOrden=this.AV22nOrden;
      }

      public short executeUdp( ref int aP0_LinCod ,
                               ref int aP1_SubLCod ,
                               ref int aP2_FamCod ,
                               ref int aP3_AlmCod )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_nOrden);
         return AV22nOrden ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref short aP4_nOrden )
      {
         rrinventariofisico objrrinventariofisico;
         objrrinventariofisico = new rrinventariofisico();
         objrrinventariofisico.AV8LinCod = aP0_LinCod;
         objrrinventariofisico.AV15SubLCod = aP1_SubLCod;
         objrrinventariofisico.AV23FamCod = aP2_FamCod;
         objrrinventariofisico.AV9AlmCod = aP3_AlmCod;
         objrrinventariofisico.AV22nOrden = aP4_nOrden;
         objrrinventariofisico.context.SetSubmitInitialConfig(context);
         objrrinventariofisico.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrinventariofisico);
         aP0_LinCod=this.AV8LinCod;
         aP1_SubLCod=this.AV15SubLCod;
         aP2_FamCod=this.AV23FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_nOrden=this.AV22nOrden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrinventariofisico)stateInfo).executePrivate();
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
            AV16Empresa = AV21Session.Get("Empresa");
            AV17EmpDir = AV21Session.Get("EmpDir");
            AV18EmpRUC = AV21Session.Get("EmpRUC");
            AV19Ruta = AV21Session.Get("RUTA") + "/Logo.jpg";
            AV20Logo = AV19Ruta;
            AV40Logo_GXI = GXDbFile.PathToUrl( AV19Ruta);
            AV12Titulo = "Toma de Inventario Fisico";
            AV11Almacen = "(Todos)";
            AV14Fecha = DateTimeUtil.Today( context);
            AV37MVAlm = AV9AlmCod;
            /* Using cursor P008J2 */
            pr_default.execute(0, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P008J2_A63AlmCod[0];
               A436AlmDsc = P008J2_A436AlmDsc[0];
               AV11Almacen = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( (0==AV9AlmCod) )
            {
               AV9AlmCod = 99;
            }
            AV24ITemProd = 1;
            /* Execute user subroutine: 'DETALLES' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8J0( true, 0) ;
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
         if ( AV22nOrden == 1 )
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV15SubLCod ,
                                                 AV23FamCod ,
                                                 AV9AlmCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A21MvAlm ,
                                                 A1158LinStk ,
                                                 A1718ProdSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P008J3 */
            pr_default.execute(1, new Object[] {AV8LinCod, AV15SubLCod, AV23FamCod, AV9AlmCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRK8J4 = false;
               A13MvATip = P008J3_A13MvATip[0];
               A14MvACod = P008J3_A14MvACod[0];
               A49UniCod = P008J3_A49UniCod[0];
               A55ProdDsc = P008J3_A55ProdDsc[0];
               A28ProdCod = P008J3_A28ProdCod[0];
               A1718ProdSts = P008J3_A1718ProdSts[0];
               A1158LinStk = P008J3_A1158LinStk[0];
               A21MvAlm = P008J3_A21MvAlm[0];
               A50FamCod = P008J3_A50FamCod[0];
               n50FamCod = P008J3_n50FamCod[0];
               A51SublCod = P008J3_A51SublCod[0];
               n51SublCod = P008J3_n51SublCod[0];
               A52LinCod = P008J3_A52LinCod[0];
               A1997UniAbr = P008J3_A1997UniAbr[0];
               A30MvADItem = P008J3_A30MvADItem[0];
               A21MvAlm = P008J3_A21MvAlm[0];
               A49UniCod = P008J3_A49UniCod[0];
               A55ProdDsc = P008J3_A55ProdDsc[0];
               A1718ProdSts = P008J3_A1718ProdSts[0];
               A50FamCod = P008J3_A50FamCod[0];
               n50FamCod = P008J3_n50FamCod[0];
               A51SublCod = P008J3_A51SublCod[0];
               n51SublCod = P008J3_n51SublCod[0];
               A52LinCod = P008J3_A52LinCod[0];
               A1997UniAbr = P008J3_A1997UniAbr[0];
               A1158LinStk = P008J3_A1158LinStk[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008J3_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRK8J4 = false;
                  A13MvATip = P008J3_A13MvATip[0];
                  A14MvACod = P008J3_A14MvACod[0];
                  A55ProdDsc = P008J3_A55ProdDsc[0];
                  A30MvADItem = P008J3_A30MvADItem[0];
                  A55ProdDsc = P008J3_A55ProdDsc[0];
                  BRK8J4 = true;
                  pr_default.readNext(1);
               }
               AV10Prodcod = A28ProdCod;
               AV32ProdDsc = StringUtil.Trim( A55ProdDsc);
               AV31UniAbr = StringUtil.Trim( A1997UniAbr);
               GXt_decimal1 = AV29StkAct;
               new GeneXus.Programs.generales.pbuscastock(context ).execute(  AV9AlmCod,  AV10Prodcod, out  GXt_decimal1) ;
               AV29StkAct = GXt_decimal1;
               AV34CostoUnit = ((Convert.ToDecimal(0)==AV36CostoU) ? "" : StringUtil.Trim( StringUtil.Str( AV36CostoU, 15, 4)));
               AV35CostoT = ((Convert.ToDecimal(0)==AV36CostoU) ? "" : StringUtil.Trim( StringUtil.Str( AV36CostoU*AV29StkAct, 15, 2)));
               AV33StkFisico = 0.0000m;
               H8J0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Prodcod, "@!")), 45, Gx_line+3, 124, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProdDsc, "")), 127, Gx_line+3, 443, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31UniAbr, "")), 445, Gx_line+3, 498, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24ITemProd), "ZZZZ9")), 4, Gx_line+3, 41, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(606, Gx_line+18, 696, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(705, Gx_line+18, 795, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(902, Gx_line+18, 992, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1001, Gx_line+18, 1091, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(808, Gx_line+18, 898, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(510, Gx_line+18, 600, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 493, Gx_line+4, 600, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34CostoUnit, "")), 815, Gx_line+4, 894, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35CostoT, "")), 908, Gx_line+3, 987, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV24ITemProd = (int)(AV24ITemProd+1);
               if ( ! BRK8J4 )
               {
                  BRK8J4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
         }
         else
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV8LinCod ,
                                                 AV15SubLCod ,
                                                 AV23FamCod ,
                                                 AV9AlmCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A21MvAlm ,
                                                 A1158LinStk ,
                                                 A1718ProdSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P008J4 */
            pr_default.execute(2, new Object[] {AV8LinCod, AV15SubLCod, AV23FamCod, AV9AlmCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRK8J6 = false;
               A13MvATip = P008J4_A13MvATip[0];
               A14MvACod = P008J4_A14MvACod[0];
               A49UniCod = P008J4_A49UniCod[0];
               A1158LinStk = P008J4_A1158LinStk[0];
               A1718ProdSts = P008J4_A1718ProdSts[0];
               A28ProdCod = P008J4_A28ProdCod[0];
               A55ProdDsc = P008J4_A55ProdDsc[0];
               A21MvAlm = P008J4_A21MvAlm[0];
               A50FamCod = P008J4_A50FamCod[0];
               n50FamCod = P008J4_n50FamCod[0];
               A51SublCod = P008J4_A51SublCod[0];
               n51SublCod = P008J4_n51SublCod[0];
               A52LinCod = P008J4_A52LinCod[0];
               A1997UniAbr = P008J4_A1997UniAbr[0];
               A30MvADItem = P008J4_A30MvADItem[0];
               A21MvAlm = P008J4_A21MvAlm[0];
               A49UniCod = P008J4_A49UniCod[0];
               A1718ProdSts = P008J4_A1718ProdSts[0];
               A55ProdDsc = P008J4_A55ProdDsc[0];
               A50FamCod = P008J4_A50FamCod[0];
               n50FamCod = P008J4_n50FamCod[0];
               A51SublCod = P008J4_A51SublCod[0];
               n51SublCod = P008J4_n51SublCod[0];
               A52LinCod = P008J4_A52LinCod[0];
               A1997UniAbr = P008J4_A1997UniAbr[0];
               A1158LinStk = P008J4_A1158LinStk[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008J4_A55ProdDsc[0], A55ProdDsc) == 0 ) )
               {
                  BRK8J6 = false;
                  A13MvATip = P008J4_A13MvATip[0];
                  A14MvACod = P008J4_A14MvACod[0];
                  A28ProdCod = P008J4_A28ProdCod[0];
                  A30MvADItem = P008J4_A30MvADItem[0];
                  BRK8J6 = true;
                  pr_default.readNext(2);
               }
               AV10Prodcod = A28ProdCod;
               AV32ProdDsc = StringUtil.Trim( A55ProdDsc);
               AV31UniAbr = StringUtil.Trim( A1997UniAbr);
               GXt_decimal1 = AV29StkAct;
               new GeneXus.Programs.generales.pbuscastock(context ).execute(  AV9AlmCod,  AV10Prodcod, out  GXt_decimal1) ;
               AV29StkAct = GXt_decimal1;
               AV34CostoUnit = ((Convert.ToDecimal(0)==AV36CostoU) ? "" : StringUtil.Trim( StringUtil.Str( AV36CostoU, 15, 4)));
               AV35CostoT = ((Convert.ToDecimal(0)==AV36CostoU) ? "" : StringUtil.Trim( StringUtil.Str( AV36CostoU*AV29StkAct, 15, 2)));
               H8J0( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10Prodcod, "@!")), 45, Gx_line+3, 124, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32ProdDsc, "")), 127, Gx_line+3, 443, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31UniAbr, "")), 445, Gx_line+3, 498, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV24ITemProd), "ZZZZ9")), 4, Gx_line+3, 41, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(606, Gx_line+18, 696, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(705, Gx_line+18, 795, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(902, Gx_line+18, 992, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1001, Gx_line+18, 1091, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(808, Gx_line+18, 898, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(510, Gx_line+18, 600, Gx_line+18, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 493, Gx_line+4, 600, Gx_line+19, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34CostoUnit, "")), 815, Gx_line+4, 894, Gx_line+19, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35CostoT, "")), 908, Gx_line+3, 987, Gx_line+18, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               AV24ITemProd = (int)(AV24ITemProd+1);
               if ( ! BRK8J6 )
               {
                  BRK8J6 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
         }
      }

      protected void H8J0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 949, Gx_line+32, 981, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 949, Gx_line+50, 993, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 949, Gx_line+15, 988, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1015, Gx_line+50, 1054, Gx_line+65, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 995, Gx_line+32, 1052, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1006, Gx_line+15, 1053, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 1086, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 58, Gx_line+120, 99, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Descripción", 236, Gx_line+120, 305, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 517, Gx_line+120, 592, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Fisico", 617, Gx_line+120, 687, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diferencia", 719, Gx_line+120, 779, Gx_line+134, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV20Logo)) ? AV40Logo_GXI : AV20Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 15, Gx_line+5, 159, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 356, Gx_line+20, 812, Gx_line+45, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("UNM", 453, Gx_line+120, 480, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°", 20, Gx_line+120, 35, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Empresa, "")), 17, Gx_line+76, 325, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18EmpRUC, "")), 17, Gx_line+94, 134, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 356, Gx_line+45, 812, Gx_line+70, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Costo Unit.", 815, Gx_line+120, 880, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo Total", 914, Gx_line+120, 982, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dif. Costo", 1014, Gx_line+120, 1070, Gx_line+134, 0+256, 0, 0, 0) ;
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
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
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
         AV16Empresa = "";
         AV21Session = context.GetSession();
         AV17EmpDir = "";
         AV18EmpRUC = "";
         AV19Ruta = "";
         AV20Logo = "";
         AV40Logo_GXI = "";
         AV12Titulo = "";
         AV11Almacen = "";
         AV14Fecha = DateTime.MinValue;
         scmdbuf = "";
         P008J2_A63AlmCod = new int[1] ;
         P008J2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P008J3_A13MvATip = new string[] {""} ;
         P008J3_A14MvACod = new string[] {""} ;
         P008J3_A49UniCod = new int[1] ;
         P008J3_A55ProdDsc = new string[] {""} ;
         P008J3_A28ProdCod = new string[] {""} ;
         P008J3_A1718ProdSts = new short[1] ;
         P008J3_A1158LinStk = new short[1] ;
         P008J3_A21MvAlm = new int[1] ;
         P008J3_A50FamCod = new int[1] ;
         P008J3_n50FamCod = new bool[] {false} ;
         P008J3_A51SublCod = new int[1] ;
         P008J3_n51SublCod = new bool[] {false} ;
         P008J3_A52LinCod = new int[1] ;
         P008J3_A1997UniAbr = new string[] {""} ;
         P008J3_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A28ProdCod = "";
         A1997UniAbr = "";
         AV10Prodcod = "";
         AV32ProdDsc = "";
         AV31UniAbr = "";
         AV34CostoUnit = "";
         AV35CostoT = "";
         P008J4_A13MvATip = new string[] {""} ;
         P008J4_A14MvACod = new string[] {""} ;
         P008J4_A49UniCod = new int[1] ;
         P008J4_A1158LinStk = new short[1] ;
         P008J4_A1718ProdSts = new short[1] ;
         P008J4_A28ProdCod = new string[] {""} ;
         P008J4_A55ProdDsc = new string[] {""} ;
         P008J4_A21MvAlm = new int[1] ;
         P008J4_A50FamCod = new int[1] ;
         P008J4_n50FamCod = new bool[] {false} ;
         P008J4_A51SublCod = new int[1] ;
         P008J4_n51SublCod = new bool[] {false} ;
         P008J4_A52LinCod = new int[1] ;
         P008J4_A1997UniAbr = new string[] {""} ;
         P008J4_A30MvADItem = new int[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV20Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrinventariofisico__default(),
            new Object[][] {
                new Object[] {
               P008J2_A63AlmCod, P008J2_A436AlmDsc
               }
               , new Object[] {
               P008J3_A13MvATip, P008J3_A14MvACod, P008J3_A49UniCod, P008J3_A55ProdDsc, P008J3_A28ProdCod, P008J3_A1718ProdSts, P008J3_A1158LinStk, P008J3_A21MvAlm, P008J3_A50FamCod, P008J3_n50FamCod,
               P008J3_A51SublCod, P008J3_n51SublCod, P008J3_A52LinCod, P008J3_A1997UniAbr, P008J3_A30MvADItem
               }
               , new Object[] {
               P008J4_A13MvATip, P008J4_A14MvACod, P008J4_A49UniCod, P008J4_A1158LinStk, P008J4_A1718ProdSts, P008J4_A28ProdCod, P008J4_A55ProdDsc, P008J4_A21MvAlm, P008J4_A50FamCod, P008J4_n50FamCod,
               P008J4_A51SublCod, P008J4_n51SublCod, P008J4_A52LinCod, P008J4_A1997UniAbr, P008J4_A30MvADItem
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
      private short AV22nOrden ;
      private short A1158LinStk ;
      private short A1718ProdSts ;
      private int AV8LinCod ;
      private int AV15SubLCod ;
      private int AV23FamCod ;
      private int AV9AlmCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV37MVAlm ;
      private int A63AlmCod ;
      private int AV24ITemProd ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV29StkAct ;
      private decimal AV36CostoU ;
      private decimal AV33StkFisico ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV16Empresa ;
      private string AV17EmpDir ;
      private string AV18EmpRUC ;
      private string AV19Ruta ;
      private string AV12Titulo ;
      private string AV11Almacen ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string A1997UniAbr ;
      private string AV10Prodcod ;
      private string AV32ProdDsc ;
      private string AV31UniAbr ;
      private string AV34CostoUnit ;
      private string AV35CostoT ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRK8J4 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool BRK8J6 ;
      private string AV40Logo_GXI ;
      private string AV20Logo ;
      private string Logo ;
      private IGxSession AV21Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private short aP4_nOrden ;
      private IDataStoreProvider pr_default ;
      private int[] P008J2_A63AlmCod ;
      private string[] P008J2_A436AlmDsc ;
      private string[] P008J3_A13MvATip ;
      private string[] P008J3_A14MvACod ;
      private int[] P008J3_A49UniCod ;
      private string[] P008J3_A55ProdDsc ;
      private string[] P008J3_A28ProdCod ;
      private short[] P008J3_A1718ProdSts ;
      private short[] P008J3_A1158LinStk ;
      private int[] P008J3_A21MvAlm ;
      private int[] P008J3_A50FamCod ;
      private bool[] P008J3_n50FamCod ;
      private int[] P008J3_A51SublCod ;
      private bool[] P008J3_n51SublCod ;
      private int[] P008J3_A52LinCod ;
      private string[] P008J3_A1997UniAbr ;
      private int[] P008J3_A30MvADItem ;
      private string[] P008J4_A13MvATip ;
      private string[] P008J4_A14MvACod ;
      private int[] P008J4_A49UniCod ;
      private short[] P008J4_A1158LinStk ;
      private short[] P008J4_A1718ProdSts ;
      private string[] P008J4_A28ProdCod ;
      private string[] P008J4_A55ProdDsc ;
      private int[] P008J4_A21MvAlm ;
      private int[] P008J4_A50FamCod ;
      private bool[] P008J4_n50FamCod ;
      private int[] P008J4_A51SublCod ;
      private bool[] P008J4_n51SublCod ;
      private int[] P008J4_A52LinCod ;
      private string[] P008J4_A1997UniAbr ;
      private int[] P008J4_A30MvADItem ;
   }

   public class rrinventariofisico__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008J3( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV15SubLCod ,
                                             int AV23FamCod ,
                                             int AV9AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             short A1158LinStk ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T3.[ProdSts], T5.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T4.[UniAbr], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[ProdSts] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV15SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV15SubLCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV23FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV23FamCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! ( AV9AlmCod == 99 ) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P008J4( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV15SubLCod ,
                                             int AV23FamCod ,
                                             int AV9AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             short A1158LinStk ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T5.[LinStk], T3.[ProdSts], T1.[ProdCod], T3.[ProdDsc], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T4.[UniAbr], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[ProdSts] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV15SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV15SubLCod)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV23FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV23FamCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! ( AV9AlmCod == 99 ) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ProdDsc], T1.[ProdCod]";
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
               case 1 :
                     return conditional_P008J3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
               case 2 :
                     return conditional_P008J4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP008J2;
          prmP008J2 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008J3;
          prmP008J3 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV15SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV23FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008J4;
          prmP008J4 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV15SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV23FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008J2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008J4,100, GxCacheFrequency.OFF ,true,false )
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
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 5);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
