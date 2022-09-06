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
   public class r_reportevariacionpreciospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_reportevariacionpreciospdf.aspx")), "compras.r_reportevariacionpreciospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_reportevariacionpreciospdf.aspx")))) ;
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
               AV62PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV60ProdCod = GetPar( "ProdCod");
                  AV40MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV84Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
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

      public r_reportevariacionpreciospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportevariacionpreciospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_MonCod ,
                           ref short aP3_Ano )
      {
         this.AV62PrvCod = aP0_PrvCod;
         this.AV60ProdCod = aP1_ProdCod;
         this.AV40MonCod = aP2_MonCod;
         this.AV84Ano = aP3_Ano;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV62PrvCod;
         aP1_ProdCod=this.AV60ProdCod;
         aP2_MonCod=this.AV40MonCod;
         aP3_Ano=this.AV84Ano;
      }

      public short executeUdp( ref string aP0_PrvCod ,
                               ref string aP1_ProdCod ,
                               ref int aP2_MonCod )
      {
         execute(ref aP0_PrvCod, ref aP1_ProdCod, ref aP2_MonCod, ref aP3_Ano);
         return AV84Ano ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_MonCod ,
                                 ref short aP3_Ano )
      {
         r_reportevariacionpreciospdf objr_reportevariacionpreciospdf;
         objr_reportevariacionpreciospdf = new r_reportevariacionpreciospdf();
         objr_reportevariacionpreciospdf.AV62PrvCod = aP0_PrvCod;
         objr_reportevariacionpreciospdf.AV60ProdCod = aP1_ProdCod;
         objr_reportevariacionpreciospdf.AV40MonCod = aP2_MonCod;
         objr_reportevariacionpreciospdf.AV84Ano = aP3_Ano;
         objr_reportevariacionpreciospdf.context.SetSubmitInitialConfig(context);
         objr_reportevariacionpreciospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportevariacionpreciospdf);
         aP0_PrvCod=this.AV62PrvCod;
         aP1_ProdCod=this.AV60ProdCod;
         aP2_MonCod=this.AV40MonCod;
         aP3_Ano=this.AV84Ano;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportevariacionpreciospdf)stateInfo).executePrivate();
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
            AV21Empresa = AV67Session.Get("Empresa");
            AV20EmpDir = AV67Session.Get("EmpDir");
            AV22EmpRUC = AV67Session.Get("EmpRUC");
            AV64Ruta = AV67Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV64Ruta;
            AV88Logo_GXI = GXDbFile.PathToUrl( AV64Ruta);
            AV28Filtro1 = "Todos";
            AV29Filtro2 = "Todos";
            AV30Filtro3 = "Todos";
            /* Using cursor P00DE2 */
            pr_default.execute(0, new Object[] {AV62PrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P00DE2_A244PrvCod[0];
               A247PrvDsc = P00DE2_A247PrvDsc[0];
               AV28Filtro1 = "Proveedor : " + StringUtil.Trim( A247PrvDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DE3 */
            pr_default.execute(1, new Object[] {AV84Ano, AV62PrvCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKDE4 = false;
               A149TipCod = P00DE3_A149TipCod[0];
               A243ComCod = P00DE3_A243ComCod[0];
               A244PrvCod = P00DE3_A244PrvCod[0];
               A254ComDProCod = P00DE3_A254ComDProCod[0];
               n254ComDProCod = P00DE3_n254ComDProCod[0];
               A55ProdDsc = P00DE3_A55ProdDsc[0];
               n55ProdDsc = P00DE3_n55ProdDsc[0];
               A248ComFec = P00DE3_A248ComFec[0];
               A250ComDItem = P00DE3_A250ComDItem[0];
               A251ComDOrdCod = P00DE3_A251ComDOrdCod[0];
               A248ComFec = P00DE3_A248ComFec[0];
               A55ProdDsc = P00DE3_A55ProdDsc[0];
               n55ProdDsc = P00DE3_n55ProdDsc[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00DE3_A55ProdDsc[0], A55ProdDsc) == 0 ) )
               {
                  BRKDE4 = false;
                  A149TipCod = P00DE3_A149TipCod[0];
                  A243ComCod = P00DE3_A243ComCod[0];
                  A244PrvCod = P00DE3_A244PrvCod[0];
                  A254ComDProCod = P00DE3_A254ComDProCod[0];
                  n254ComDProCod = P00DE3_n254ComDProCod[0];
                  A250ComDItem = P00DE3_A250ComDItem[0];
                  A251ComDOrdCod = P00DE3_A251ComDOrdCod[0];
                  BRKDE4 = true;
                  pr_default.readNext(1);
               }
               AV60ProdCod = A254ComDProCod;
               AV61ProdDsc = A55ProdDsc;
               AV44nEnero = 0.00m;
               AV45nFebrero = 0.00m;
               AV48nMarzo = 0.00m;
               AV41nAbril = 0.00m;
               AV49nMayo = 0.00m;
               AV47nJunio = 0.00m;
               AV46nJulio = 0.00m;
               AV42nAgosto = 0.00m;
               AV52nSetiembre = 0.00m;
               AV51nOctubre = 0.00m;
               AV50nNoviembre = 0.00m;
               AV43nDiciembre = 0.00m;
               /* Execute user subroutine: 'CONSULTAMESES' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               HDE0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60ProdCod, "@!")), 1, Gx_line+2, 80, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61ProdDsc, "")), 88, Gx_line+2, 344, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 299, Gx_line+2, 406, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 367, Gx_line+2, 474, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 430, Gx_line+2, 537, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 484, Gx_line+2, 591, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 546, Gx_line+2, 653, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 602, Gx_line+2, 709, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 659, Gx_line+2, 766, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 734, Gx_line+2, 841, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52nSetiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 808, Gx_line+2, 915, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51nOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 868, Gx_line+2, 975, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50nNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 944, Gx_line+2, 1051, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43nDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 1015, Gx_line+2, 1122, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               if ( ! BRKDE4 )
               {
                  BRKDE4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDE0( true, 0) ;
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
         /* 'CONSULTAMESES' Routine */
         returnInSub = false;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE4 */
         pr_default.execute(2, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A149TipCod = P00DE4_A149TipCod[0];
            A243ComCod = P00DE4_A243ComCod[0];
            A248ComFec = P00DE4_A248ComFec[0];
            A254ComDProCod = P00DE4_A254ComDProCod[0];
            n254ComDProCod = P00DE4_n254ComDProCod[0];
            A244PrvCod = P00DE4_A244PrvCod[0];
            A246ComMon = P00DE4_A246ComMon[0];
            A686ComDPre = P00DE4_A686ComDPre[0];
            A250ComDItem = P00DE4_A250ComDItem[0];
            A251ComDOrdCod = P00DE4_A251ComDOrdCod[0];
            A248ComFec = P00DE4_A248ComFec[0];
            A246ComMon = P00DE4_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV44nEnero = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE5 */
         pr_default.execute(3, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A149TipCod = P00DE5_A149TipCod[0];
            A243ComCod = P00DE5_A243ComCod[0];
            A248ComFec = P00DE5_A248ComFec[0];
            A254ComDProCod = P00DE5_A254ComDProCod[0];
            n254ComDProCod = P00DE5_n254ComDProCod[0];
            A244PrvCod = P00DE5_A244PrvCod[0];
            A246ComMon = P00DE5_A246ComMon[0];
            A686ComDPre = P00DE5_A686ComDPre[0];
            A250ComDItem = P00DE5_A250ComDItem[0];
            A251ComDOrdCod = P00DE5_A251ComDOrdCod[0];
            A248ComFec = P00DE5_A248ComFec[0];
            A246ComMon = P00DE5_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV45nFebrero = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE6 */
         pr_default.execute(4, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A149TipCod = P00DE6_A149TipCod[0];
            A243ComCod = P00DE6_A243ComCod[0];
            A248ComFec = P00DE6_A248ComFec[0];
            A254ComDProCod = P00DE6_A254ComDProCod[0];
            n254ComDProCod = P00DE6_n254ComDProCod[0];
            A244PrvCod = P00DE6_A244PrvCod[0];
            A246ComMon = P00DE6_A246ComMon[0];
            A686ComDPre = P00DE6_A686ComDPre[0];
            A250ComDItem = P00DE6_A250ComDItem[0];
            A251ComDOrdCod = P00DE6_A251ComDOrdCod[0];
            A248ComFec = P00DE6_A248ComFec[0];
            A246ComMon = P00DE6_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
         AV48nMarzo = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE7 */
         pr_default.execute(5, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A149TipCod = P00DE7_A149TipCod[0];
            A243ComCod = P00DE7_A243ComCod[0];
            A248ComFec = P00DE7_A248ComFec[0];
            A254ComDProCod = P00DE7_A254ComDProCod[0];
            n254ComDProCod = P00DE7_n254ComDProCod[0];
            A244PrvCod = P00DE7_A244PrvCod[0];
            A246ComMon = P00DE7_A246ComMon[0];
            A686ComDPre = P00DE7_A686ComDPre[0];
            A250ComDItem = P00DE7_A250ComDItem[0];
            A251ComDOrdCod = P00DE7_A251ComDOrdCod[0];
            A248ComFec = P00DE7_A248ComFec[0];
            A246ComMon = P00DE7_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV41nAbril = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE8 */
         pr_default.execute(6, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A149TipCod = P00DE8_A149TipCod[0];
            A243ComCod = P00DE8_A243ComCod[0];
            A248ComFec = P00DE8_A248ComFec[0];
            A254ComDProCod = P00DE8_A254ComDProCod[0];
            n254ComDProCod = P00DE8_n254ComDProCod[0];
            A244PrvCod = P00DE8_A244PrvCod[0];
            A246ComMon = P00DE8_A246ComMon[0];
            A686ComDPre = P00DE8_A686ComDPre[0];
            A250ComDItem = P00DE8_A250ComDItem[0];
            A251ComDOrdCod = P00DE8_A251ComDOrdCod[0];
            A248ComFec = P00DE8_A248ComFec[0];
            A246ComMon = P00DE8_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(6);
         }
         pr_default.close(6);
         AV49nMayo = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE9 */
         pr_default.execute(7, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A149TipCod = P00DE9_A149TipCod[0];
            A243ComCod = P00DE9_A243ComCod[0];
            A248ComFec = P00DE9_A248ComFec[0];
            A254ComDProCod = P00DE9_A254ComDProCod[0];
            n254ComDProCod = P00DE9_n254ComDProCod[0];
            A244PrvCod = P00DE9_A244PrvCod[0];
            A246ComMon = P00DE9_A246ComMon[0];
            A686ComDPre = P00DE9_A686ComDPre[0];
            A250ComDItem = P00DE9_A250ComDItem[0];
            A251ComDOrdCod = P00DE9_A251ComDOrdCod[0];
            A248ComFec = P00DE9_A248ComFec[0];
            A246ComMon = P00DE9_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(7);
         }
         pr_default.close(7);
         AV47nJunio = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE10 */
         pr_default.execute(8, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A149TipCod = P00DE10_A149TipCod[0];
            A243ComCod = P00DE10_A243ComCod[0];
            A248ComFec = P00DE10_A248ComFec[0];
            A254ComDProCod = P00DE10_A254ComDProCod[0];
            n254ComDProCod = P00DE10_n254ComDProCod[0];
            A244PrvCod = P00DE10_A244PrvCod[0];
            A246ComMon = P00DE10_A246ComMon[0];
            A686ComDPre = P00DE10_A686ComDPre[0];
            A250ComDItem = P00DE10_A250ComDItem[0];
            A251ComDOrdCod = P00DE10_A251ComDOrdCod[0];
            A248ComFec = P00DE10_A248ComFec[0];
            A246ComMon = P00DE10_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(8);
         }
         pr_default.close(8);
         AV46nJulio = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE11 */
         pr_default.execute(9, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A149TipCod = P00DE11_A149TipCod[0];
            A243ComCod = P00DE11_A243ComCod[0];
            A248ComFec = P00DE11_A248ComFec[0];
            A254ComDProCod = P00DE11_A254ComDProCod[0];
            n254ComDProCod = P00DE11_n254ComDProCod[0];
            A244PrvCod = P00DE11_A244PrvCod[0];
            A246ComMon = P00DE11_A246ComMon[0];
            A686ComDPre = P00DE11_A686ComDPre[0];
            A250ComDItem = P00DE11_A250ComDItem[0];
            A251ComDOrdCod = P00DE11_A251ComDOrdCod[0];
            A248ComFec = P00DE11_A248ComFec[0];
            A246ComMon = P00DE11_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV42nAgosto = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE12 */
         pr_default.execute(10, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A149TipCod = P00DE12_A149TipCod[0];
            A243ComCod = P00DE12_A243ComCod[0];
            A248ComFec = P00DE12_A248ComFec[0];
            A254ComDProCod = P00DE12_A254ComDProCod[0];
            n254ComDProCod = P00DE12_n254ComDProCod[0];
            A244PrvCod = P00DE12_A244PrvCod[0];
            A246ComMon = P00DE12_A246ComMon[0];
            A686ComDPre = P00DE12_A686ComDPre[0];
            A250ComDItem = P00DE12_A250ComDItem[0];
            A251ComDOrdCod = P00DE12_A251ComDOrdCod[0];
            A248ComFec = P00DE12_A248ComFec[0];
            A246ComMon = P00DE12_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
         AV52nSetiembre = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE13 */
         pr_default.execute(11, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(11) != 101) )
         {
            A149TipCod = P00DE13_A149TipCod[0];
            A243ComCod = P00DE13_A243ComCod[0];
            A248ComFec = P00DE13_A248ComFec[0];
            A254ComDProCod = P00DE13_A254ComDProCod[0];
            n254ComDProCod = P00DE13_n254ComDProCod[0];
            A244PrvCod = P00DE13_A244PrvCod[0];
            A246ComMon = P00DE13_A246ComMon[0];
            A686ComDPre = P00DE13_A686ComDPre[0];
            A250ComDItem = P00DE13_A250ComDItem[0];
            A251ComDOrdCod = P00DE13_A251ComDOrdCod[0];
            A248ComFec = P00DE13_A248ComFec[0];
            A246ComMon = P00DE13_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(11);
         }
         pr_default.close(11);
         AV51nOctubre = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE14 */
         pr_default.execute(12, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(12) != 101) )
         {
            A149TipCod = P00DE14_A149TipCod[0];
            A243ComCod = P00DE14_A243ComCod[0];
            A248ComFec = P00DE14_A248ComFec[0];
            A254ComDProCod = P00DE14_A254ComDProCod[0];
            n254ComDProCod = P00DE14_n254ComDProCod[0];
            A244PrvCod = P00DE14_A244PrvCod[0];
            A246ComMon = P00DE14_A246ComMon[0];
            A686ComDPre = P00DE14_A686ComDPre[0];
            A250ComDItem = P00DE14_A250ComDItem[0];
            A251ComDOrdCod = P00DE14_A251ComDOrdCod[0];
            A248ComFec = P00DE14_A248ComFec[0];
            A246ComMon = P00DE14_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(12);
         }
         pr_default.close(12);
         AV50nNoviembre = AV13ComDPre;
         AV13ComDPre = 0.00m;
         /* Using cursor P00DE15 */
         pr_default.execute(13, new Object[] {AV60ProdCod, AV84Ano, AV62PrvCod});
         while ( (pr_default.getStatus(13) != 101) )
         {
            A149TipCod = P00DE15_A149TipCod[0];
            A243ComCod = P00DE15_A243ComCod[0];
            A248ComFec = P00DE15_A248ComFec[0];
            A254ComDProCod = P00DE15_A254ComDProCod[0];
            n254ComDProCod = P00DE15_n254ComDProCod[0];
            A244PrvCod = P00DE15_A244PrvCod[0];
            A246ComMon = P00DE15_A246ComMon[0];
            A686ComDPre = P00DE15_A686ComDPre[0];
            A250ComDItem = P00DE15_A250ComDItem[0];
            A251ComDOrdCod = P00DE15_A251ComDOrdCod[0];
            A248ComFec = P00DE15_A248ComFec[0];
            A246ComMon = P00DE15_A246ComMon[0];
            AV15ComMon = A246ComMon;
            if ( AV40MonCod == AV15ComMon )
            {
               AV13ComDPre = A686ComDPre;
            }
            else
            {
               GXt_decimal1 = AV85TipCompra;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A248ComFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV85TipCompra = GXt_decimal1;
               if ( AV40MonCod == 1 )
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre*AV85TipCompra, 4);
               }
               else
               {
                  AV13ComDPre = NumberUtil.Round( A686ComDPre/ (decimal)(AV85TipCompra), 4);
               }
            }
            pr_default.readNext(13);
         }
         pr_default.close(13);
         AV43nDiciembre = AV13ComDPre;
      }

      protected void HDE0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1031, Gx_line+41, 1063, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1031, Gx_line+60, 1075, Gx_line+74, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1031, Gx_line+22, 1070, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro1, "")), 320, Gx_line+66, 800, Gx_line+86, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+122, 1134, Gx_line+148, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1076, Gx_line+22, 1123, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1061, Gx_line+41, 1121, Gx_line+55, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1084, Gx_line+60, 1123, Gx_line+75, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 16, Gx_line+127, 57, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 164, Gx_line+127, 218, Gx_line+141, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV88Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reporte Variación de Precios por Producto", 383, Gx_line+44, 744, Gx_line+64, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 511, Gx_line+88, 557, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Enero", 368, Gx_line+127, 402, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Febrero", 428, Gx_line+127, 475, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Abril", 568, Gx_line+127, 596, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Marzo", 501, Gx_line+127, 538, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Julio", 744, Gx_line+127, 772, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio", 685, Gx_line+127, 717, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mayo", 627, Gx_line+127, 660, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Agosto", 803, Gx_line+127, 846, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Noviembre", 990, Gx_line+127, 1055, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Octubre", 932, Gx_line+127, 980, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diciembre", 1061, Gx_line+127, 1121, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Setiembre", 860, Gx_line+127, 922, Gx_line+141, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV84Ano), "ZZZ9")), 562, Gx_line+88, 611, Gx_line+109, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+148);
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
         AV21Empresa = "";
         AV67Session = context.GetSession();
         AV20EmpDir = "";
         AV22EmpRUC = "";
         AV64Ruta = "";
         AV38Logo = "";
         AV88Logo_GXI = "";
         AV28Filtro1 = "";
         AV29Filtro2 = "";
         AV30Filtro3 = "";
         scmdbuf = "";
         P00DE2_A244PrvCod = new string[] {""} ;
         P00DE2_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         P00DE3_A149TipCod = new string[] {""} ;
         P00DE3_A243ComCod = new string[] {""} ;
         P00DE3_A244PrvCod = new string[] {""} ;
         P00DE3_A254ComDProCod = new string[] {""} ;
         P00DE3_n254ComDProCod = new bool[] {false} ;
         P00DE3_A55ProdDsc = new string[] {""} ;
         P00DE3_n55ProdDsc = new bool[] {false} ;
         P00DE3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE3_A250ComDItem = new short[1] ;
         P00DE3_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A254ComDProCod = "";
         A55ProdDsc = "";
         A248ComFec = DateTime.MinValue;
         A251ComDOrdCod = "";
         AV61ProdDsc = "";
         P00DE4_A149TipCod = new string[] {""} ;
         P00DE4_A243ComCod = new string[] {""} ;
         P00DE4_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE4_A254ComDProCod = new string[] {""} ;
         P00DE4_n254ComDProCod = new bool[] {false} ;
         P00DE4_A244PrvCod = new string[] {""} ;
         P00DE4_A246ComMon = new int[1] ;
         P00DE4_A686ComDPre = new decimal[1] ;
         P00DE4_A250ComDItem = new short[1] ;
         P00DE4_A251ComDOrdCod = new string[] {""} ;
         P00DE5_A149TipCod = new string[] {""} ;
         P00DE5_A243ComCod = new string[] {""} ;
         P00DE5_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE5_A254ComDProCod = new string[] {""} ;
         P00DE5_n254ComDProCod = new bool[] {false} ;
         P00DE5_A244PrvCod = new string[] {""} ;
         P00DE5_A246ComMon = new int[1] ;
         P00DE5_A686ComDPre = new decimal[1] ;
         P00DE5_A250ComDItem = new short[1] ;
         P00DE5_A251ComDOrdCod = new string[] {""} ;
         P00DE6_A149TipCod = new string[] {""} ;
         P00DE6_A243ComCod = new string[] {""} ;
         P00DE6_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE6_A254ComDProCod = new string[] {""} ;
         P00DE6_n254ComDProCod = new bool[] {false} ;
         P00DE6_A244PrvCod = new string[] {""} ;
         P00DE6_A246ComMon = new int[1] ;
         P00DE6_A686ComDPre = new decimal[1] ;
         P00DE6_A250ComDItem = new short[1] ;
         P00DE6_A251ComDOrdCod = new string[] {""} ;
         P00DE7_A149TipCod = new string[] {""} ;
         P00DE7_A243ComCod = new string[] {""} ;
         P00DE7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE7_A254ComDProCod = new string[] {""} ;
         P00DE7_n254ComDProCod = new bool[] {false} ;
         P00DE7_A244PrvCod = new string[] {""} ;
         P00DE7_A246ComMon = new int[1] ;
         P00DE7_A686ComDPre = new decimal[1] ;
         P00DE7_A250ComDItem = new short[1] ;
         P00DE7_A251ComDOrdCod = new string[] {""} ;
         P00DE8_A149TipCod = new string[] {""} ;
         P00DE8_A243ComCod = new string[] {""} ;
         P00DE8_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE8_A254ComDProCod = new string[] {""} ;
         P00DE8_n254ComDProCod = new bool[] {false} ;
         P00DE8_A244PrvCod = new string[] {""} ;
         P00DE8_A246ComMon = new int[1] ;
         P00DE8_A686ComDPre = new decimal[1] ;
         P00DE8_A250ComDItem = new short[1] ;
         P00DE8_A251ComDOrdCod = new string[] {""} ;
         P00DE9_A149TipCod = new string[] {""} ;
         P00DE9_A243ComCod = new string[] {""} ;
         P00DE9_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE9_A254ComDProCod = new string[] {""} ;
         P00DE9_n254ComDProCod = new bool[] {false} ;
         P00DE9_A244PrvCod = new string[] {""} ;
         P00DE9_A246ComMon = new int[1] ;
         P00DE9_A686ComDPre = new decimal[1] ;
         P00DE9_A250ComDItem = new short[1] ;
         P00DE9_A251ComDOrdCod = new string[] {""} ;
         P00DE10_A149TipCod = new string[] {""} ;
         P00DE10_A243ComCod = new string[] {""} ;
         P00DE10_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE10_A254ComDProCod = new string[] {""} ;
         P00DE10_n254ComDProCod = new bool[] {false} ;
         P00DE10_A244PrvCod = new string[] {""} ;
         P00DE10_A246ComMon = new int[1] ;
         P00DE10_A686ComDPre = new decimal[1] ;
         P00DE10_A250ComDItem = new short[1] ;
         P00DE10_A251ComDOrdCod = new string[] {""} ;
         P00DE11_A149TipCod = new string[] {""} ;
         P00DE11_A243ComCod = new string[] {""} ;
         P00DE11_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE11_A254ComDProCod = new string[] {""} ;
         P00DE11_n254ComDProCod = new bool[] {false} ;
         P00DE11_A244PrvCod = new string[] {""} ;
         P00DE11_A246ComMon = new int[1] ;
         P00DE11_A686ComDPre = new decimal[1] ;
         P00DE11_A250ComDItem = new short[1] ;
         P00DE11_A251ComDOrdCod = new string[] {""} ;
         P00DE12_A149TipCod = new string[] {""} ;
         P00DE12_A243ComCod = new string[] {""} ;
         P00DE12_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE12_A254ComDProCod = new string[] {""} ;
         P00DE12_n254ComDProCod = new bool[] {false} ;
         P00DE12_A244PrvCod = new string[] {""} ;
         P00DE12_A246ComMon = new int[1] ;
         P00DE12_A686ComDPre = new decimal[1] ;
         P00DE12_A250ComDItem = new short[1] ;
         P00DE12_A251ComDOrdCod = new string[] {""} ;
         P00DE13_A149TipCod = new string[] {""} ;
         P00DE13_A243ComCod = new string[] {""} ;
         P00DE13_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE13_A254ComDProCod = new string[] {""} ;
         P00DE13_n254ComDProCod = new bool[] {false} ;
         P00DE13_A244PrvCod = new string[] {""} ;
         P00DE13_A246ComMon = new int[1] ;
         P00DE13_A686ComDPre = new decimal[1] ;
         P00DE13_A250ComDItem = new short[1] ;
         P00DE13_A251ComDOrdCod = new string[] {""} ;
         P00DE14_A149TipCod = new string[] {""} ;
         P00DE14_A243ComCod = new string[] {""} ;
         P00DE14_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE14_A254ComDProCod = new string[] {""} ;
         P00DE14_n254ComDProCod = new bool[] {false} ;
         P00DE14_A244PrvCod = new string[] {""} ;
         P00DE14_A246ComMon = new int[1] ;
         P00DE14_A686ComDPre = new decimal[1] ;
         P00DE14_A250ComDItem = new short[1] ;
         P00DE14_A251ComDOrdCod = new string[] {""} ;
         P00DE15_A149TipCod = new string[] {""} ;
         P00DE15_A243ComCod = new string[] {""} ;
         P00DE15_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DE15_A254ComDProCod = new string[] {""} ;
         P00DE15_n254ComDProCod = new bool[] {false} ;
         P00DE15_A244PrvCod = new string[] {""} ;
         P00DE15_A246ComMon = new int[1] ;
         P00DE15_A686ComDPre = new decimal[1] ;
         P00DE15_A250ComDItem = new short[1] ;
         P00DE15_A251ComDOrdCod = new string[] {""} ;
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_reportevariacionpreciospdf__default(),
            new Object[][] {
                new Object[] {
               P00DE2_A244PrvCod, P00DE2_A247PrvDsc
               }
               , new Object[] {
               P00DE3_A149TipCod, P00DE3_A243ComCod, P00DE3_A244PrvCod, P00DE3_A254ComDProCod, P00DE3_n254ComDProCod, P00DE3_A55ProdDsc, P00DE3_n55ProdDsc, P00DE3_A248ComFec, P00DE3_A250ComDItem, P00DE3_A251ComDOrdCod
               }
               , new Object[] {
               P00DE4_A149TipCod, P00DE4_A243ComCod, P00DE4_A248ComFec, P00DE4_A254ComDProCod, P00DE4_n254ComDProCod, P00DE4_A244PrvCod, P00DE4_A246ComMon, P00DE4_A686ComDPre, P00DE4_A250ComDItem, P00DE4_A251ComDOrdCod
               }
               , new Object[] {
               P00DE5_A149TipCod, P00DE5_A243ComCod, P00DE5_A248ComFec, P00DE5_A254ComDProCod, P00DE5_n254ComDProCod, P00DE5_A244PrvCod, P00DE5_A246ComMon, P00DE5_A686ComDPre, P00DE5_A250ComDItem, P00DE5_A251ComDOrdCod
               }
               , new Object[] {
               P00DE6_A149TipCod, P00DE6_A243ComCod, P00DE6_A248ComFec, P00DE6_A254ComDProCod, P00DE6_n254ComDProCod, P00DE6_A244PrvCod, P00DE6_A246ComMon, P00DE6_A686ComDPre, P00DE6_A250ComDItem, P00DE6_A251ComDOrdCod
               }
               , new Object[] {
               P00DE7_A149TipCod, P00DE7_A243ComCod, P00DE7_A248ComFec, P00DE7_A254ComDProCod, P00DE7_n254ComDProCod, P00DE7_A244PrvCod, P00DE7_A246ComMon, P00DE7_A686ComDPre, P00DE7_A250ComDItem, P00DE7_A251ComDOrdCod
               }
               , new Object[] {
               P00DE8_A149TipCod, P00DE8_A243ComCod, P00DE8_A248ComFec, P00DE8_A254ComDProCod, P00DE8_n254ComDProCod, P00DE8_A244PrvCod, P00DE8_A246ComMon, P00DE8_A686ComDPre, P00DE8_A250ComDItem, P00DE8_A251ComDOrdCod
               }
               , new Object[] {
               P00DE9_A149TipCod, P00DE9_A243ComCod, P00DE9_A248ComFec, P00DE9_A254ComDProCod, P00DE9_n254ComDProCod, P00DE9_A244PrvCod, P00DE9_A246ComMon, P00DE9_A686ComDPre, P00DE9_A250ComDItem, P00DE9_A251ComDOrdCod
               }
               , new Object[] {
               P00DE10_A149TipCod, P00DE10_A243ComCod, P00DE10_A248ComFec, P00DE10_A254ComDProCod, P00DE10_n254ComDProCod, P00DE10_A244PrvCod, P00DE10_A246ComMon, P00DE10_A686ComDPre, P00DE10_A250ComDItem, P00DE10_A251ComDOrdCod
               }
               , new Object[] {
               P00DE11_A149TipCod, P00DE11_A243ComCod, P00DE11_A248ComFec, P00DE11_A254ComDProCod, P00DE11_n254ComDProCod, P00DE11_A244PrvCod, P00DE11_A246ComMon, P00DE11_A686ComDPre, P00DE11_A250ComDItem, P00DE11_A251ComDOrdCod
               }
               , new Object[] {
               P00DE12_A149TipCod, P00DE12_A243ComCod, P00DE12_A248ComFec, P00DE12_A254ComDProCod, P00DE12_n254ComDProCod, P00DE12_A244PrvCod, P00DE12_A246ComMon, P00DE12_A686ComDPre, P00DE12_A250ComDItem, P00DE12_A251ComDOrdCod
               }
               , new Object[] {
               P00DE13_A149TipCod, P00DE13_A243ComCod, P00DE13_A248ComFec, P00DE13_A254ComDProCod, P00DE13_n254ComDProCod, P00DE13_A244PrvCod, P00DE13_A246ComMon, P00DE13_A686ComDPre, P00DE13_A250ComDItem, P00DE13_A251ComDOrdCod
               }
               , new Object[] {
               P00DE14_A149TipCod, P00DE14_A243ComCod, P00DE14_A248ComFec, P00DE14_A254ComDProCod, P00DE14_n254ComDProCod, P00DE14_A244PrvCod, P00DE14_A246ComMon, P00DE14_A686ComDPre, P00DE14_A250ComDItem, P00DE14_A251ComDOrdCod
               }
               , new Object[] {
               P00DE15_A149TipCod, P00DE15_A243ComCod, P00DE15_A248ComFec, P00DE15_A254ComDProCod, P00DE15_n254ComDProCod, P00DE15_A244PrvCod, P00DE15_A246ComMon, P00DE15_A686ComDPre, P00DE15_A250ComDItem, P00DE15_A251ComDOrdCod
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
      private short AV84Ano ;
      private short A250ComDItem ;
      private int AV40MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV15ComMon ;
      private int GXt_int2 ;
      private decimal AV44nEnero ;
      private decimal AV45nFebrero ;
      private decimal AV48nMarzo ;
      private decimal AV41nAbril ;
      private decimal AV49nMayo ;
      private decimal AV47nJunio ;
      private decimal AV46nJulio ;
      private decimal AV42nAgosto ;
      private decimal AV52nSetiembre ;
      private decimal AV51nOctubre ;
      private decimal AV50nNoviembre ;
      private decimal AV43nDiciembre ;
      private decimal AV13ComDPre ;
      private decimal A686ComDPre ;
      private decimal AV85TipCompra ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV62PrvCod ;
      private string AV60ProdCod ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV22EmpRUC ;
      private string AV64Ruta ;
      private string AV28Filtro1 ;
      private string AV29Filtro2 ;
      private string AV30Filtro3 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A254ComDProCod ;
      private string A55ProdDsc ;
      private string A251ComDOrdCod ;
      private string AV61ProdDsc ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime A248ComFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKDE4 ;
      private bool n254ComDProCod ;
      private bool n55ProdDsc ;
      private bool returnInSub ;
      private string AV88Logo_GXI ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV67Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private string aP1_ProdCod ;
      private int aP2_MonCod ;
      private short aP3_Ano ;
      private IDataStoreProvider pr_default ;
      private string[] P00DE2_A244PrvCod ;
      private string[] P00DE2_A247PrvDsc ;
      private string[] P00DE3_A149TipCod ;
      private string[] P00DE3_A243ComCod ;
      private string[] P00DE3_A244PrvCod ;
      private string[] P00DE3_A254ComDProCod ;
      private bool[] P00DE3_n254ComDProCod ;
      private string[] P00DE3_A55ProdDsc ;
      private bool[] P00DE3_n55ProdDsc ;
      private DateTime[] P00DE3_A248ComFec ;
      private short[] P00DE3_A250ComDItem ;
      private string[] P00DE3_A251ComDOrdCod ;
      private string[] P00DE4_A149TipCod ;
      private string[] P00DE4_A243ComCod ;
      private DateTime[] P00DE4_A248ComFec ;
      private string[] P00DE4_A254ComDProCod ;
      private bool[] P00DE4_n254ComDProCod ;
      private string[] P00DE4_A244PrvCod ;
      private int[] P00DE4_A246ComMon ;
      private decimal[] P00DE4_A686ComDPre ;
      private short[] P00DE4_A250ComDItem ;
      private string[] P00DE4_A251ComDOrdCod ;
      private string[] P00DE5_A149TipCod ;
      private string[] P00DE5_A243ComCod ;
      private DateTime[] P00DE5_A248ComFec ;
      private string[] P00DE5_A254ComDProCod ;
      private bool[] P00DE5_n254ComDProCod ;
      private string[] P00DE5_A244PrvCod ;
      private int[] P00DE5_A246ComMon ;
      private decimal[] P00DE5_A686ComDPre ;
      private short[] P00DE5_A250ComDItem ;
      private string[] P00DE5_A251ComDOrdCod ;
      private string[] P00DE6_A149TipCod ;
      private string[] P00DE6_A243ComCod ;
      private DateTime[] P00DE6_A248ComFec ;
      private string[] P00DE6_A254ComDProCod ;
      private bool[] P00DE6_n254ComDProCod ;
      private string[] P00DE6_A244PrvCod ;
      private int[] P00DE6_A246ComMon ;
      private decimal[] P00DE6_A686ComDPre ;
      private short[] P00DE6_A250ComDItem ;
      private string[] P00DE6_A251ComDOrdCod ;
      private string[] P00DE7_A149TipCod ;
      private string[] P00DE7_A243ComCod ;
      private DateTime[] P00DE7_A248ComFec ;
      private string[] P00DE7_A254ComDProCod ;
      private bool[] P00DE7_n254ComDProCod ;
      private string[] P00DE7_A244PrvCod ;
      private int[] P00DE7_A246ComMon ;
      private decimal[] P00DE7_A686ComDPre ;
      private short[] P00DE7_A250ComDItem ;
      private string[] P00DE7_A251ComDOrdCod ;
      private string[] P00DE8_A149TipCod ;
      private string[] P00DE8_A243ComCod ;
      private DateTime[] P00DE8_A248ComFec ;
      private string[] P00DE8_A254ComDProCod ;
      private bool[] P00DE8_n254ComDProCod ;
      private string[] P00DE8_A244PrvCod ;
      private int[] P00DE8_A246ComMon ;
      private decimal[] P00DE8_A686ComDPre ;
      private short[] P00DE8_A250ComDItem ;
      private string[] P00DE8_A251ComDOrdCod ;
      private string[] P00DE9_A149TipCod ;
      private string[] P00DE9_A243ComCod ;
      private DateTime[] P00DE9_A248ComFec ;
      private string[] P00DE9_A254ComDProCod ;
      private bool[] P00DE9_n254ComDProCod ;
      private string[] P00DE9_A244PrvCod ;
      private int[] P00DE9_A246ComMon ;
      private decimal[] P00DE9_A686ComDPre ;
      private short[] P00DE9_A250ComDItem ;
      private string[] P00DE9_A251ComDOrdCod ;
      private string[] P00DE10_A149TipCod ;
      private string[] P00DE10_A243ComCod ;
      private DateTime[] P00DE10_A248ComFec ;
      private string[] P00DE10_A254ComDProCod ;
      private bool[] P00DE10_n254ComDProCod ;
      private string[] P00DE10_A244PrvCod ;
      private int[] P00DE10_A246ComMon ;
      private decimal[] P00DE10_A686ComDPre ;
      private short[] P00DE10_A250ComDItem ;
      private string[] P00DE10_A251ComDOrdCod ;
      private string[] P00DE11_A149TipCod ;
      private string[] P00DE11_A243ComCod ;
      private DateTime[] P00DE11_A248ComFec ;
      private string[] P00DE11_A254ComDProCod ;
      private bool[] P00DE11_n254ComDProCod ;
      private string[] P00DE11_A244PrvCod ;
      private int[] P00DE11_A246ComMon ;
      private decimal[] P00DE11_A686ComDPre ;
      private short[] P00DE11_A250ComDItem ;
      private string[] P00DE11_A251ComDOrdCod ;
      private string[] P00DE12_A149TipCod ;
      private string[] P00DE12_A243ComCod ;
      private DateTime[] P00DE12_A248ComFec ;
      private string[] P00DE12_A254ComDProCod ;
      private bool[] P00DE12_n254ComDProCod ;
      private string[] P00DE12_A244PrvCod ;
      private int[] P00DE12_A246ComMon ;
      private decimal[] P00DE12_A686ComDPre ;
      private short[] P00DE12_A250ComDItem ;
      private string[] P00DE12_A251ComDOrdCod ;
      private string[] P00DE13_A149TipCod ;
      private string[] P00DE13_A243ComCod ;
      private DateTime[] P00DE13_A248ComFec ;
      private string[] P00DE13_A254ComDProCod ;
      private bool[] P00DE13_n254ComDProCod ;
      private string[] P00DE13_A244PrvCod ;
      private int[] P00DE13_A246ComMon ;
      private decimal[] P00DE13_A686ComDPre ;
      private short[] P00DE13_A250ComDItem ;
      private string[] P00DE13_A251ComDOrdCod ;
      private string[] P00DE14_A149TipCod ;
      private string[] P00DE14_A243ComCod ;
      private DateTime[] P00DE14_A248ComFec ;
      private string[] P00DE14_A254ComDProCod ;
      private bool[] P00DE14_n254ComDProCod ;
      private string[] P00DE14_A244PrvCod ;
      private int[] P00DE14_A246ComMon ;
      private decimal[] P00DE14_A686ComDPre ;
      private short[] P00DE14_A250ComDItem ;
      private string[] P00DE14_A251ComDOrdCod ;
      private string[] P00DE15_A149TipCod ;
      private string[] P00DE15_A243ComCod ;
      private DateTime[] P00DE15_A248ComFec ;
      private string[] P00DE15_A254ComDProCod ;
      private bool[] P00DE15_n254ComDProCod ;
      private string[] P00DE15_A244PrvCod ;
      private int[] P00DE15_A246ComMon ;
      private decimal[] P00DE15_A686ComDPre ;
      private short[] P00DE15_A250ComDItem ;
      private string[] P00DE15_A251ComDOrdCod ;
   }

   public class r_reportevariacionpreciospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DE2;
          prmP00DE2 = new Object[] {
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE3;
          prmP00DE3 = new Object[] {
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE4;
          prmP00DE4 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE5;
          prmP00DE5 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE6;
          prmP00DE6 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE7;
          prmP00DE7 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE8;
          prmP00DE8 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE9;
          prmP00DE9 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE10;
          prmP00DE10 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE11;
          prmP00DE11 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE12;
          prmP00DE12 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE13;
          prmP00DE13 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE14;
          prmP00DE14 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00DE15;
          prmP00DE15 = new Object[] {
          new ParDef("@AV60ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV84Ano",GXType.Int16,4,0) ,
          new ParDef("@AV62PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DE2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV62PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DE3", "SELECT T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDProCod] AS ComDProCod, T3.[ProdDsc], T2.[ComFec], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) LEFT JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ComDProCod]) WHERE (YEAR(T2.[ComFec]) = @AV84Ano) AND (Not (T1.[ComDProCod] = '')) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T3.[ProdDsc], T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE4", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 1) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE5", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 2) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE6", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 3) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE7", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 4) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE8", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 5) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE9", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 6) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE10", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 7) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE11", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 8) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE12", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 9) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE13", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 10) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE14", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 11) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DE15", "SELECT T1.[TipCod], T1.[ComCod], T2.[ComFec], T1.[ComDProCod] AS ComDProCod, T1.[PrvCod], T2.[ComMon], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) WHERE (T1.[ComDProCod] = @AV60ProdCod) AND (YEAR(T2.[ComFec]) = @AV84Ano) AND (MONTH(T2.[ComFec]) = 12) AND (T1.[PrvCod] = @AV62PrvCod) ORDER BY T1.[ComDProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DE15,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((short[]) buf[8])[0] = rslt.getShort(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
       }
    }

 }

}
