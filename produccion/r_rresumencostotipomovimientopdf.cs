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
   public class r_rresumencostotipomovimientopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "produccion.r_rresumencostotipomovimientopdf.aspx")), "produccion.r_rresumencostotipomovimientopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "produccion.r_rresumencostotipomovimientopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "MovCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV29MovCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV30LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV31Prodcod = GetPar( "Prodcod");
                  AV27Hdesde = context.localUtil.ParseDateParm( GetPar( "Hdesde"));
                  AV28HHasta = context.localUtil.ParseDateParm( GetPar( "HHasta"));
                  AV40SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV41FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
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

      public r_rresumencostotipomovimientopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_rresumencostotipomovimientopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MovCod ,
                           ref int aP1_LinCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_Hdesde ,
                           ref DateTime aP4_HHasta ,
                           ref int aP5_SubLCod ,
                           ref int aP6_FamCod )
      {
         this.AV29MovCod = aP0_MovCod;
         this.AV30LinCod = aP1_LinCod;
         this.AV31Prodcod = aP2_Prodcod;
         this.AV27Hdesde = aP3_Hdesde;
         this.AV28HHasta = aP4_HHasta;
         this.AV40SubLCod = aP5_SubLCod;
         this.AV41FamCod = aP6_FamCod;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_SubLCod=this.AV40SubLCod;
         aP6_FamCod=this.AV41FamCod;
      }

      public int executeUdp( ref int aP0_MovCod ,
                             ref int aP1_LinCod ,
                             ref string aP2_Prodcod ,
                             ref DateTime aP3_Hdesde ,
                             ref DateTime aP4_HHasta ,
                             ref int aP5_SubLCod )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_Hdesde, ref aP4_HHasta, ref aP5_SubLCod, ref aP6_FamCod);
         return AV41FamCod ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_Hdesde ,
                                 ref DateTime aP4_HHasta ,
                                 ref int aP5_SubLCod ,
                                 ref int aP6_FamCod )
      {
         r_rresumencostotipomovimientopdf objr_rresumencostotipomovimientopdf;
         objr_rresumencostotipomovimientopdf = new r_rresumencostotipomovimientopdf();
         objr_rresumencostotipomovimientopdf.AV29MovCod = aP0_MovCod;
         objr_rresumencostotipomovimientopdf.AV30LinCod = aP1_LinCod;
         objr_rresumencostotipomovimientopdf.AV31Prodcod = aP2_Prodcod;
         objr_rresumencostotipomovimientopdf.AV27Hdesde = aP3_Hdesde;
         objr_rresumencostotipomovimientopdf.AV28HHasta = aP4_HHasta;
         objr_rresumencostotipomovimientopdf.AV40SubLCod = aP5_SubLCod;
         objr_rresumencostotipomovimientopdf.AV41FamCod = aP6_FamCod;
         objr_rresumencostotipomovimientopdf.context.SetSubmitInitialConfig(context);
         objr_rresumencostotipomovimientopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_rresumencostotipomovimientopdf);
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_SubLCod=this.AV40SubLCod;
         aP6_FamCod=this.AV41FamCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_rresumencostotipomovimientopdf)stateInfo).executePrivate();
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
            AV33Empresa = AV38Session.Get("Empresa");
            AV34EmpDir = AV38Session.Get("EmpDir");
            AV35EmpRUC = AV38Session.Get("EmpRUC");
            AV36Ruta = AV38Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV36Ruta;
            AV54Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            /* Using cursor P00G42 */
            pr_default.execute(0, new Object[] {AV29MovCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A234MovCod = P00G42_A234MovCod[0];
               A1239MovDsc = P00G42_A1239MovDsc[0];
               AV22Filtro1 = A1239MovDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00G43 */
            pr_default.execute(1, new Object[] {AV31Prodcod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P00G43_A28ProdCod[0];
               A55ProdDsc = P00G43_A55ProdDsc[0];
               AV24Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV44TotalG = 0.00m;
            AV45TotalGCant = 0.00m;
            AV48TitTotales = "";
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV29MovCod ,
                                                 AV30LinCod ,
                                                 AV31Prodcod ,
                                                 AV40SubLCod ,
                                                 AV41FamCod ,
                                                 A22MvAMov ,
                                                 A52LinCod ,
                                                 A28ProdCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A25MvAFec ,
                                                 AV27Hdesde ,
                                                 AV28HHasta ,
                                                 A1370MVSts ,
                                                 A1158LinStk ,
                                                 A1269MvAlmCos } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00G44 */
            pr_default.execute(2, new Object[] {AV27Hdesde, AV28HHasta, AV29MovCod, AV30LinCod, AV31Prodcod, AV40SubLCod, AV41FamCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKG45 = false;
               A21MvAlm = P00G44_A21MvAlm[0];
               A28ProdCod = P00G44_A28ProdCod[0];
               A1269MvAlmCos = P00G44_A1269MvAlmCos[0];
               A1278MvARef = P00G44_A1278MvARef[0];
               A24DocNum = P00G44_A24DocNum[0];
               n24DocNum = P00G44_n24DocNum[0];
               A1250MVADPrecio = P00G44_A1250MVADPrecio[0];
               A1249MVADCosto = P00G44_A1249MVADCosto[0];
               A1248MvADCant = P00G44_A1248MvADCant[0];
               A1274MvAMovDsc = P00G44_A1274MvAMovDsc[0];
               A14MvACod = P00G44_A14MvACod[0];
               A13MvATip = P00G44_A13MvATip[0];
               A19MVCDesItem = P00G44_A19MVCDesItem[0];
               n19MVCDesItem = P00G44_n19MVCDesItem[0];
               A25MvAFec = P00G44_A25MvAFec[0];
               A1158LinStk = P00G44_A1158LinStk[0];
               A1370MVSts = P00G44_A1370MVSts[0];
               A50FamCod = P00G44_A50FamCod[0];
               n50FamCod = P00G44_n50FamCod[0];
               A51SublCod = P00G44_A51SublCod[0];
               n51SublCod = P00G44_n51SublCod[0];
               A52LinCod = P00G44_A52LinCod[0];
               A22MvAMov = P00G44_A22MvAMov[0];
               A55ProdDsc = P00G44_A55ProdDsc[0];
               A30MvADItem = P00G44_A30MvADItem[0];
               A50FamCod = P00G44_A50FamCod[0];
               n50FamCod = P00G44_n50FamCod[0];
               A51SublCod = P00G44_A51SublCod[0];
               n51SublCod = P00G44_n51SublCod[0];
               A52LinCod = P00G44_A52LinCod[0];
               A55ProdDsc = P00G44_A55ProdDsc[0];
               A1158LinStk = P00G44_A1158LinStk[0];
               A21MvAlm = P00G44_A21MvAlm[0];
               A1278MvARef = P00G44_A1278MvARef[0];
               A24DocNum = P00G44_A24DocNum[0];
               n24DocNum = P00G44_n24DocNum[0];
               A19MVCDesItem = P00G44_A19MVCDesItem[0];
               n19MVCDesItem = P00G44_n19MVCDesItem[0];
               A25MvAFec = P00G44_A25MvAFec[0];
               A1370MVSts = P00G44_A1370MVSts[0];
               A22MvAMov = P00G44_A22MvAMov[0];
               A1269MvAlmCos = P00G44_A1269MvAlmCos[0];
               A1274MvAMovDsc = P00G44_A1274MvAMovDsc[0];
               AV47ProdDsc = StringUtil.Trim( A55ProdDsc);
               AV49TitProducto = StringUtil.Trim( A28ProdCod) + "  " + StringUtil.Trim( A55ProdDsc);
               AV48TitTotales = "Total " + AV47ProdDsc;
               HG40( false, 23) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TitProducto, "")), 14, Gx_line+6, 637, Gx_line+21, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               AV32TotalP = 0.0000m;
               AV42TotalC = 0.00m;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00G44_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKG45 = false;
                  A21MvAlm = P00G44_A21MvAlm[0];
                  A1269MvAlmCos = P00G44_A1269MvAlmCos[0];
                  A1278MvARef = P00G44_A1278MvARef[0];
                  A24DocNum = P00G44_A24DocNum[0];
                  n24DocNum = P00G44_n24DocNum[0];
                  A1250MVADPrecio = P00G44_A1250MVADPrecio[0];
                  A1249MVADCosto = P00G44_A1249MVADCosto[0];
                  A1248MvADCant = P00G44_A1248MvADCant[0];
                  A1274MvAMovDsc = P00G44_A1274MvAMovDsc[0];
                  A14MvACod = P00G44_A14MvACod[0];
                  A13MvATip = P00G44_A13MvATip[0];
                  A19MVCDesItem = P00G44_A19MVCDesItem[0];
                  n19MVCDesItem = P00G44_n19MVCDesItem[0];
                  A25MvAFec = P00G44_A25MvAFec[0];
                  A22MvAMov = P00G44_A22MvAMov[0];
                  A30MvADItem = P00G44_A30MvADItem[0];
                  A21MvAlm = P00G44_A21MvAlm[0];
                  A1278MvARef = P00G44_A1278MvARef[0];
                  A24DocNum = P00G44_A24DocNum[0];
                  n24DocNum = P00G44_n24DocNum[0];
                  A19MVCDesItem = P00G44_A19MVCDesItem[0];
                  n19MVCDesItem = P00G44_n19MVCDesItem[0];
                  A25MvAFec = P00G44_A25MvAFec[0];
                  A22MvAMov = P00G44_A22MvAMov[0];
                  A1269MvAlmCos = P00G44_A1269MvAlmCos[0];
                  A1274MvAMovDsc = P00G44_A1274MvAMovDsc[0];
                  if ( A1269MvAlmCos == 1 )
                  {
                     AV43MVARef = A1278MvARef;
                     AV46DocNum = A24DocNum;
                     HG40( false, 17) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 4, Gx_line+2, 36, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 40, Gx_line+2, 105, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 107, Gx_line+2, 160, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), 326, Gx_line+2, 542, Gx_line+17, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 518, Gx_line+2, 623, Gx_line+17, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1249MVADCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 696, Gx_line+3, 786, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1250MVADPrecio, "ZZZZZ,ZZZ,ZZ9.999999")), 603, Gx_line+3, 708, Gx_line+16, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46DocNum, "")), 165, Gx_line+3, 239, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MVARef, "")), 241, Gx_line+2, 324, Gx_line+17, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+17);
                     AV32TotalP = (decimal)(AV32TotalP+(((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : A1248MvADCant*-1)));
                     AV42TotalC = (decimal)(AV42TotalC+(((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1249MVADCosto : A1249MVADCosto*-1)));
                  }
                  BRKG45 = true;
                  pr_default.readNext(2);
               }
               AV44TotalG = (decimal)(AV44TotalG+AV42TotalC);
               AV45TotalGCant = (decimal)(AV45TotalGCant+AV32TotalP);
               HG40( false, 28) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TotalP, "ZZZZ,ZZZ,ZZ9.9999")), 534, Gx_line+9, 624, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(544, Gx_line+6, 797, Gx_line+6, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 696, Gx_line+9, 786, Gx_line+22, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TitTotales, "")), 82, Gx_line+9, 500, Gx_line+22, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
               if ( ! BRKG45 )
               {
                  BRKG45 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            HG40( false, 42) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General : ", 410, Gx_line+15, 500, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(536, Gx_line+4, 789, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalGCant, "ZZZZ,ZZZ,ZZ9.9999")), 534, Gx_line+16, 624, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TotalG, "ZZZZZZ,ZZZ,ZZ9.99")), 696, Gx_line+16, 786, Gx_line+29, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+42);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HG40( true, 0) ;
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

      protected void HG40( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 8, Gx_line+182, 31, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Entrada", 42, Gx_line+182, 106, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de movimiento", 344, Gx_line+182, 462, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Costos por Tipo de Movimiento", 213, Gx_line+53, 586, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 118, Gx_line+182, 153, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 566, Gx_line+182, 619, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de movimiento", 117, Gx_line+108, 235, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 117, Gx_line+131, 171, Gx_line+145, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 253, Gx_line+126, 596, Gx_line+150, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 117, Gx_line+152, 154, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27Hdesde, "99/99/99"), 253, Gx_line+147, 337, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 456, Gx_line+151, 491, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28HHasta, "99/99/99"), 511, Gx_line+146, 595, Gx_line+170, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Doc.", 181, Gx_line+183, 224, Gx_line+197, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Logo)) ? AV54Logo_GXI : AV37Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 6, Gx_line+8, 159, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 6, Gx_line+83, 314, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 6, Gx_line+101, 123, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T. Costo", 727, Gx_line+182, 775, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Costo Unit.", 641, Gx_line+182, 706, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia", 251, Gx_line+182, 316, Gx_line+196, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+176, 797, Gx_line+202, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+202);
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
         AV33Empresa = "";
         AV38Session = context.GetSession();
         AV34EmpDir = "";
         AV35EmpRUC = "";
         AV36Ruta = "";
         AV37Logo = "";
         AV54Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P00G42_A234MovCod = new int[1] ;
         P00G42_A1239MovDsc = new string[] {""} ;
         A1239MovDsc = "";
         P00G43_A28ProdCod = new string[] {""} ;
         P00G43_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         AV48TitTotales = "";
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         P00G44_A21MvAlm = new int[1] ;
         P00G44_A28ProdCod = new string[] {""} ;
         P00G44_A1269MvAlmCos = new short[1] ;
         P00G44_A1278MvARef = new string[] {""} ;
         P00G44_A24DocNum = new string[] {""} ;
         P00G44_n24DocNum = new bool[] {false} ;
         P00G44_A1250MVADPrecio = new decimal[1] ;
         P00G44_A1249MVADCosto = new decimal[1] ;
         P00G44_A1248MvADCant = new decimal[1] ;
         P00G44_A1274MvAMovDsc = new string[] {""} ;
         P00G44_A14MvACod = new string[] {""} ;
         P00G44_A13MvATip = new string[] {""} ;
         P00G44_A19MVCDesItem = new int[1] ;
         P00G44_n19MVCDesItem = new bool[] {false} ;
         P00G44_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00G44_A1158LinStk = new short[1] ;
         P00G44_A1370MVSts = new string[] {""} ;
         P00G44_A50FamCod = new int[1] ;
         P00G44_n50FamCod = new bool[] {false} ;
         P00G44_A51SublCod = new int[1] ;
         P00G44_n51SublCod = new bool[] {false} ;
         P00G44_A52LinCod = new int[1] ;
         P00G44_A22MvAMov = new int[1] ;
         P00G44_A55ProdDsc = new string[] {""} ;
         P00G44_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A24DocNum = "";
         A1274MvAMovDsc = "";
         A14MvACod = "";
         A13MvATip = "";
         AV47ProdDsc = "";
         AV49TitProducto = "";
         AV43MVARef = "";
         AV46DocNum = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV37Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_rresumencostotipomovimientopdf__default(),
            new Object[][] {
                new Object[] {
               P00G42_A234MovCod, P00G42_A1239MovDsc
               }
               , new Object[] {
               P00G43_A28ProdCod, P00G43_A55ProdDsc
               }
               , new Object[] {
               P00G44_A21MvAlm, P00G44_A28ProdCod, P00G44_A1269MvAlmCos, P00G44_A1278MvARef, P00G44_A24DocNum, P00G44_n24DocNum, P00G44_A1250MVADPrecio, P00G44_A1249MVADCosto, P00G44_A1248MvADCant, P00G44_A1274MvAMovDsc,
               P00G44_A14MvACod, P00G44_A13MvATip, P00G44_A19MVCDesItem, P00G44_n19MVCDesItem, P00G44_A25MvAFec, P00G44_A1158LinStk, P00G44_A1370MVSts, P00G44_A50FamCod, P00G44_n50FamCod, P00G44_A51SublCod,
               P00G44_n51SublCod, P00G44_A52LinCod, P00G44_A22MvAMov, P00G44_A55ProdDsc, P00G44_A30MvADItem
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
      private int AV29MovCod ;
      private int AV30LinCod ;
      private int AV40SubLCod ;
      private int AV41FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A234MovCod ;
      private int A22MvAMov ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A19MVCDesItem ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV44TotalG ;
      private decimal AV45TotalGCant ;
      private decimal A1250MVADPrecio ;
      private decimal A1249MVADCosto ;
      private decimal A1248MvADCant ;
      private decimal AV32TotalP ;
      private decimal AV42TotalC ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV31Prodcod ;
      private string AV33Empresa ;
      private string AV34EmpDir ;
      private string AV35EmpRUC ;
      private string AV36Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A1239MovDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string AV48TitTotales ;
      private string A1370MVSts ;
      private string A1278MvARef ;
      private string A24DocNum ;
      private string A1274MvAMovDsc ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string AV47ProdDsc ;
      private string AV49TitProducto ;
      private string AV43MVARef ;
      private string AV46DocNum ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV27Hdesde ;
      private DateTime AV28HHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKG45 ;
      private bool n24DocNum ;
      private bool n19MVCDesItem ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV54Logo_GXI ;
      private string AV37Logo ;
      private string Logo ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MovCod ;
      private int aP1_LinCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_Hdesde ;
      private DateTime aP4_HHasta ;
      private int aP5_SubLCod ;
      private int aP6_FamCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00G42_A234MovCod ;
      private string[] P00G42_A1239MovDsc ;
      private string[] P00G43_A28ProdCod ;
      private string[] P00G43_A55ProdDsc ;
      private int[] P00G44_A21MvAlm ;
      private string[] P00G44_A28ProdCod ;
      private short[] P00G44_A1269MvAlmCos ;
      private string[] P00G44_A1278MvARef ;
      private string[] P00G44_A24DocNum ;
      private bool[] P00G44_n24DocNum ;
      private decimal[] P00G44_A1250MVADPrecio ;
      private decimal[] P00G44_A1249MVADCosto ;
      private decimal[] P00G44_A1248MvADCant ;
      private string[] P00G44_A1274MvAMovDsc ;
      private string[] P00G44_A14MvACod ;
      private string[] P00G44_A13MvATip ;
      private int[] P00G44_A19MVCDesItem ;
      private bool[] P00G44_n19MVCDesItem ;
      private DateTime[] P00G44_A25MvAFec ;
      private short[] P00G44_A1158LinStk ;
      private string[] P00G44_A1370MVSts ;
      private int[] P00G44_A50FamCod ;
      private bool[] P00G44_n50FamCod ;
      private int[] P00G44_A51SublCod ;
      private bool[] P00G44_n51SublCod ;
      private int[] P00G44_A52LinCod ;
      private int[] P00G44_A22MvAMov ;
      private string[] P00G44_A55ProdDsc ;
      private int[] P00G44_A30MvADItem ;
   }

   public class r_rresumencostotipomovimientopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G44( IGxContext context ,
                                             int AV29MovCod ,
                                             int AV30LinCod ,
                                             string AV31Prodcod ,
                                             int AV40SubLCod ,
                                             int AV41FamCod ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV27Hdesde ,
                                             DateTime AV28HHasta ,
                                             string A1370MVSts ,
                                             short A1158LinStk ,
                                             short A1269MvAlmCos )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T4.[MvAlm] AS MvAlm, T1.[ProdCod], T5.[AlmCos] AS MvAlmCos, T4.[MvARef], T4.[DocNum], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvADCant], T6.[MovDsc] AS MvAMovDsc, T1.[MvACod], T1.[MvATip], T4.[MVCDesItem], T4.[MvAFec], T3.[LinStk], T4.[MVSts], T2.[FamCod], T2.[SublCod], T2.[LinCod], T4.[MvAMov] AS MvAMov, T2.[ProdDsc], T1.[MvADItem] FROM ((((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T3 ON T3.[LinCod] = T2.[LinCod]) INNER JOIN [AGUIAS] T4 ON T4.[MvATip] = T1.[MvATip] AND T4.[MvACod] = T1.[MvACod]) INNER JOIN [CALMACEN] T5 ON T5.[AlmCod] = T4.[MvAlm]) INNER JOIN [CMOVALMACEN] T6 ON T6.[MovCod] = T4.[MvAMov])";
         AddWhere(sWhereString, "(T4.[MvAFec] >= @AV27Hdesde and T4.[MvAFec] <= @AV28HHasta)");
         AddWhere(sWhereString, "(T4.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T3.[LinStk] = 1)");
         AddWhere(sWhereString, "(T5.[AlmCos] = 1)");
         if ( ! (0==AV29MovCod) )
         {
            AddWhere(sWhereString, "(T4.[MvAMov] = @AV29MovCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV41FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV41FamCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T4.[MvAFec], T4.[MVCDesItem], T1.[MvATip], T1.[MvACod]";
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
                     return conditional_P00G44(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] );
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
          Object[] prmP00G42;
          prmP00G42 = new Object[] {
          new ParDef("@AV29MovCod",GXType.Int32,6,0)
          };
          Object[] prmP00G43;
          prmP00G43 = new Object[] {
          new ParDef("@AV31Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00G44;
          prmP00G44 = new Object[] {
          new ParDef("@AV27Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV28HHasta",GXType.Date,8,0) ,
          new ParDef("@AV29MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV41FamCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G42", "SELECT [MovCod], [MovDsc] FROM [CMOVALMACEN] WHERE [MovCod] = @AV29MovCod ORDER BY [MovCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G43", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV31Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G43,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G44", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G44,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 12);
                ((string[]) buf[11])[0] = rslt.getString(11, 3);
                ((int[]) buf[12])[0] = rslt.getInt(12);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(13);
                ((short[]) buf[15])[0] = rslt.getShort(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 1);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((int[]) buf[19])[0] = rslt.getInt(17);
                ((bool[]) buf[20])[0] = rslt.wasNull(17);
                ((int[]) buf[21])[0] = rslt.getInt(18);
                ((int[]) buf[22])[0] = rslt.getInt(19);
                ((string[]) buf[23])[0] = rslt.getString(20, 100);
                ((int[]) buf[24])[0] = rslt.getInt(21);
                return;
       }
    }

 }

}
