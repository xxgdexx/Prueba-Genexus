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
namespace GeneXus.Programs.bancos {
   public class r_resumenpagosproveedorespdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.r_resumenpagosproveedorespdf.aspx")), "bancos.r_resumenpagosproveedorespdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.r_resumenpagosproveedorespdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "FDesde");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV10FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV11FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV12CliCod = GetPar( "CliCod");
                  AV13ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV18TipCod = GetPar( "TipCod");
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

      public r_resumenpagosproveedorespdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenpagosproveedorespdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CliCod ,
                           ref int aP3_ForCod ,
                           ref int aP4_MonCod ,
                           ref string aP5_TipCod )
      {
         this.AV10FDesde = aP0_FDesde;
         this.AV11FHasta = aP1_FHasta;
         this.AV12CliCod = aP2_CliCod;
         this.AV13ForCod = aP3_ForCod;
         this.AV14MonCod = aP4_MonCod;
         this.AV18TipCod = aP5_TipCod;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV10FDesde;
         aP1_FHasta=this.AV11FHasta;
         aP2_CliCod=this.AV12CliCod;
         aP3_ForCod=this.AV13ForCod;
         aP4_MonCod=this.AV14MonCod;
         aP5_TipCod=this.AV18TipCod;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_CliCod ,
                                ref int aP3_ForCod ,
                                ref int aP4_MonCod )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CliCod, ref aP3_ForCod, ref aP4_MonCod, ref aP5_TipCod);
         return AV18TipCod ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CliCod ,
                                 ref int aP3_ForCod ,
                                 ref int aP4_MonCod ,
                                 ref string aP5_TipCod )
      {
         r_resumenpagosproveedorespdf objr_resumenpagosproveedorespdf;
         objr_resumenpagosproveedorespdf = new r_resumenpagosproveedorespdf();
         objr_resumenpagosproveedorespdf.AV10FDesde = aP0_FDesde;
         objr_resumenpagosproveedorespdf.AV11FHasta = aP1_FHasta;
         objr_resumenpagosproveedorespdf.AV12CliCod = aP2_CliCod;
         objr_resumenpagosproveedorespdf.AV13ForCod = aP3_ForCod;
         objr_resumenpagosproveedorespdf.AV14MonCod = aP4_MonCod;
         objr_resumenpagosproveedorespdf.AV18TipCod = aP5_TipCod;
         objr_resumenpagosproveedorespdf.context.SetSubmitInitialConfig(context);
         objr_resumenpagosproveedorespdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenpagosproveedorespdf);
         aP0_FDesde=this.AV10FDesde;
         aP1_FHasta=this.AV11FHasta;
         aP2_CliCod=this.AV12CliCod;
         aP3_ForCod=this.AV13ForCod;
         aP4_MonCod=this.AV14MonCod;
         aP5_TipCod=this.AV18TipCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenpagosproveedorespdf)stateInfo).executePrivate();
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
            AV19Empresa = AV24Session.Get("Empresa");
            AV20EmpDir = AV24Session.Get("EmpDir");
            AV21EmpRUC = AV24Session.Get("EmpRUC");
            AV22Ruta = AV24Session.Get("RUTA") + "/Logo.jpg";
            AV23Logo = AV22Ruta;
            AV27Logo_GXI = GXDbFile.PathToUrl( AV22Ruta);
            AV15TotMN = 0.00m;
            AV16TotME = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV12CliCod ,
                                                 AV13ForCod ,
                                                 AV14MonCod ,
                                                 AV18TipCod ,
                                                 A417PagPrvCod ,
                                                 A416PagForCod ,
                                                 A413PagMonCod ,
                                                 A149TipCod ,
                                                 A418PagFech ,
                                                 AV10FDesde ,
                                                 AV11FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00812 */
            pr_default.execute(0, new Object[] {AV10FDesde, AV11FHasta, AV12CliCod, AV13ForCod, AV14MonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A412PagReg = P00812_A412PagReg[0];
               A296PrvBanCod1 = P00812_A296PrvBanCod1[0];
               n296PrvBanCod1 = P00812_n296PrvBanCod1[0];
               A420PagDTipCod = P00812_A420PagDTipCod[0];
               A422PagDPrvCod = P00812_A422PagDPrvCod[0];
               A413PagMonCod = P00812_A413PagMonCod[0];
               A416PagForCod = P00812_A416PagForCod[0];
               A417PagPrvCod = P00812_A417PagPrvCod[0];
               A418PagFech = P00812_A418PagFech[0];
               A1481PagDTot = P00812_A1481PagDTot[0];
               A481BanAbr = P00812_A481BanAbr[0];
               n481BanAbr = P00812_n481BanAbr[0];
               A1488PagPrvDsc = P00812_A1488PagPrvDsc[0];
               A1486PagMonDsc = P00812_A1486PagMonDsc[0];
               A1475PagCheque = P00812_A1475PagCheque[0];
               A1485PagForDsc = P00812_A1485PagForDsc[0];
               A264CPFech = P00812_A264CPFech[0];
               n264CPFech = P00812_n264CPFech[0];
               A421PagDComCod = P00812_A421PagDComCod[0];
               A306TipAbr = P00812_A306TipAbr[0];
               n306TipAbr = P00812_n306TipAbr[0];
               A419PagItem = P00812_A419PagItem[0];
               A413PagMonCod = P00812_A413PagMonCod[0];
               A416PagForCod = P00812_A416PagForCod[0];
               A417PagPrvCod = P00812_A417PagPrvCod[0];
               A418PagFech = P00812_A418PagFech[0];
               A1475PagCheque = P00812_A1475PagCheque[0];
               A1486PagMonDsc = P00812_A1486PagMonDsc[0];
               A1485PagForDsc = P00812_A1485PagForDsc[0];
               A296PrvBanCod1 = P00812_A296PrvBanCod1[0];
               n296PrvBanCod1 = P00812_n296PrvBanCod1[0];
               A1488PagPrvDsc = P00812_A1488PagPrvDsc[0];
               A481BanAbr = P00812_A481BanAbr[0];
               n481BanAbr = P00812_n481BanAbr[0];
               A306TipAbr = P00812_A306TipAbr[0];
               n306TipAbr = P00812_n306TipAbr[0];
               A264CPFech = P00812_A264CPFech[0];
               n264CPFech = P00812_n264CPFech[0];
               AV17CobDTot = A1481PagDTot;
               AV15TotMN = (decimal)(AV15TotMN+(((A413PagMonCod==1) ? AV17CobDTot : (decimal)(0))));
               AV16TotME = (decimal)(AV16TotME+(((A413PagMonCod==1) ? (decimal)(0) : AV17CobDTot)));
               H810( false, 22) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 15, Gx_line+2, 68, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A421PagDComCod, "")), 65, Gx_line+2, 144, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 159, Gx_line+2, 206, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1485PagForDsc, "")), 590, Gx_line+1, 738, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1475PagCheque, "")), 797, Gx_line+2, 902, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1486PagMonDsc, "")), 463, Gx_line+2, 587, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17CobDTot, "ZZZZZZ,ZZZ,ZZ9.99")), 892, Gx_line+2, 999, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A418PagFech, "99/99/99"), 1034, Gx_line+2, 1081, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1488PagPrvDsc, "")), 218, Gx_line+1, 461, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A481BanAbr, "")), 739, Gx_line+2, 792, Gx_line+17, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H810( false, 57) ;
            getPrinter().GxDrawLine(705, Gx_line+11, 1075, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total MN", 747, Gx_line+18, 799, Gx_line+32, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total ME", 747, Gx_line+36, 798, Gx_line+50, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV15TotMN, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+17, 904, Gx_line+32, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16TotME, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+35, 904, Gx_line+50, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+57);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H810( true, 0) ;
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

      protected void H810( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 377, Gx_line+65, 442, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 535, Gx_line+65, 596, Gx_line+85, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Resumen de Pagos a Proveedores", 369, Gx_line+25, 658, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 952, Gx_line+51, 996, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hora:", 952, Gx_line+32, 984, Gx_line+46, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 952, Gx_line+15, 991, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1000, Gx_line+15, 1047, Gx_line+30, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 982, Gx_line+32, 1046, Gx_line+47, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1008, Gx_line+51, 1047, Gx_line+66, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV10FDesde, "99/99/99"), 452, Gx_line+65, 522, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV11FHasta, "99/99/99"), 602, Gx_line+65, 672, Gx_line+86, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+126, 1101, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 21, Gx_line+133, 44, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N°Documento", 66, Gx_line+133, 148, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 170, Gx_line+128, 205, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 304, Gx_line+133, 366, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Forma de Pago", 597, Gx_line+133, 686, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Cheque", 813, Gx_line+133, 874, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe pago", 924, Gx_line+133, 1006, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 1036, Gx_line+128, 1071, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 499, Gx_line+133, 547, Gx_line+147, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Banco", 747, Gx_line+132, 783, Gx_line+146, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV23Logo)) ? AV27Logo_GXI : AV23Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+0, 147, Gx_line+71) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 7, Gx_line+71, 375, Gx_line+89, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpDir, "")), 7, Gx_line+89, 378, Gx_line+107, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EmpRUC, "")), 7, Gx_line+105, 378, Gx_line+123, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Emisión", 165, Gx_line+141, 211, Gx_line+155, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 1038, Gx_line+141, 1068, Gx_line+155, 0+256, 0, 0, 0) ;
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
         AV19Empresa = "";
         AV24Session = context.GetSession();
         AV20EmpDir = "";
         AV21EmpRUC = "";
         AV22Ruta = "";
         AV23Logo = "";
         AV27Logo_GXI = "";
         scmdbuf = "";
         A417PagPrvCod = "";
         A149TipCod = "";
         A418PagFech = DateTime.MinValue;
         P00812_A412PagReg = new long[1] ;
         P00812_A296PrvBanCod1 = new int[1] ;
         P00812_n296PrvBanCod1 = new bool[] {false} ;
         P00812_A420PagDTipCod = new string[] {""} ;
         P00812_A422PagDPrvCod = new string[] {""} ;
         P00812_A413PagMonCod = new int[1] ;
         P00812_A416PagForCod = new int[1] ;
         P00812_A417PagPrvCod = new string[] {""} ;
         P00812_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         P00812_A1481PagDTot = new decimal[1] ;
         P00812_A481BanAbr = new string[] {""} ;
         P00812_n481BanAbr = new bool[] {false} ;
         P00812_A1488PagPrvDsc = new string[] {""} ;
         P00812_A1486PagMonDsc = new string[] {""} ;
         P00812_A1475PagCheque = new string[] {""} ;
         P00812_A1485PagForDsc = new string[] {""} ;
         P00812_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P00812_n264CPFech = new bool[] {false} ;
         P00812_A421PagDComCod = new string[] {""} ;
         P00812_A306TipAbr = new string[] {""} ;
         P00812_n306TipAbr = new bool[] {false} ;
         P00812_A419PagItem = new short[1] ;
         A420PagDTipCod = "";
         A422PagDPrvCod = "";
         A481BanAbr = "";
         A1488PagPrvDsc = "";
         A1486PagMonDsc = "";
         A1475PagCheque = "";
         A1485PagForDsc = "";
         A264CPFech = DateTime.MinValue;
         A421PagDComCod = "";
         A306TipAbr = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV23Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumenpagosproveedorespdf__default(),
            new Object[][] {
                new Object[] {
               P00812_A412PagReg, P00812_A296PrvBanCod1, P00812_n296PrvBanCod1, P00812_A420PagDTipCod, P00812_A422PagDPrvCod, P00812_A413PagMonCod, P00812_A416PagForCod, P00812_A417PagPrvCod, P00812_A418PagFech, P00812_A1481PagDTot,
               P00812_A481BanAbr, P00812_n481BanAbr, P00812_A1488PagPrvDsc, P00812_A1486PagMonDsc, P00812_A1475PagCheque, P00812_A1485PagForDsc, P00812_A264CPFech, P00812_n264CPFech, P00812_A421PagDComCod, P00812_A306TipAbr,
               P00812_n306TipAbr, P00812_A419PagItem
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
      private short A419PagItem ;
      private int AV13ForCod ;
      private int AV14MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A416PagForCod ;
      private int A413PagMonCod ;
      private int A296PrvBanCod1 ;
      private int Gx_OldLine ;
      private long A412PagReg ;
      private decimal AV15TotMN ;
      private decimal AV16TotME ;
      private decimal A1481PagDTot ;
      private decimal AV17CobDTot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV12CliCod ;
      private string AV18TipCod ;
      private string AV19Empresa ;
      private string AV20EmpDir ;
      private string AV21EmpRUC ;
      private string AV22Ruta ;
      private string scmdbuf ;
      private string A417PagPrvCod ;
      private string A149TipCod ;
      private string A420PagDTipCod ;
      private string A422PagDPrvCod ;
      private string A481BanAbr ;
      private string A1488PagPrvDsc ;
      private string A1486PagMonDsc ;
      private string A1475PagCheque ;
      private string A1485PagForDsc ;
      private string A421PagDComCod ;
      private string A306TipAbr ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV10FDesde ;
      private DateTime AV11FHasta ;
      private DateTime A418PagFech ;
      private DateTime A264CPFech ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n296PrvBanCod1 ;
      private bool n481BanAbr ;
      private bool n264CPFech ;
      private bool n306TipAbr ;
      private string AV27Logo_GXI ;
      private string AV23Logo ;
      private string Logo ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CliCod ;
      private int aP3_ForCod ;
      private int aP4_MonCod ;
      private string aP5_TipCod ;
      private IDataStoreProvider pr_default ;
      private long[] P00812_A412PagReg ;
      private int[] P00812_A296PrvBanCod1 ;
      private bool[] P00812_n296PrvBanCod1 ;
      private string[] P00812_A420PagDTipCod ;
      private string[] P00812_A422PagDPrvCod ;
      private int[] P00812_A413PagMonCod ;
      private int[] P00812_A416PagForCod ;
      private string[] P00812_A417PagPrvCod ;
      private DateTime[] P00812_A418PagFech ;
      private decimal[] P00812_A1481PagDTot ;
      private string[] P00812_A481BanAbr ;
      private bool[] P00812_n481BanAbr ;
      private string[] P00812_A1488PagPrvDsc ;
      private string[] P00812_A1486PagMonDsc ;
      private string[] P00812_A1475PagCheque ;
      private string[] P00812_A1485PagForDsc ;
      private DateTime[] P00812_A264CPFech ;
      private bool[] P00812_n264CPFech ;
      private string[] P00812_A421PagDComCod ;
      private string[] P00812_A306TipAbr ;
      private bool[] P00812_n306TipAbr ;
      private short[] P00812_A419PagItem ;
   }

   public class r_resumenpagosproveedorespdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00812( IGxContext context ,
                                             string AV12CliCod ,
                                             int AV13ForCod ,
                                             int AV14MonCod ,
                                             string AV18TipCod ,
                                             string A417PagPrvCod ,
                                             int A416PagForCod ,
                                             int A413PagMonCod ,
                                             string A149TipCod ,
                                             DateTime A418PagFech ,
                                             DateTime AV10FDesde ,
                                             DateTime AV11FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PagReg], T5.[PrvBanCod1] AS PrvBanCod1, T1.[PagDTipCod] AS PagDTipCod, T1.[PagDPrvCod] AS PagDPrvCod, T2.[PagMonCod] AS PagMonCod, T2.[PagForCod] AS PagForCod, T2.[PagPrvCod] AS PagPrvCod, T2.[PagFech], T1.[PagDTot], T6.[BanAbr], T5.[PrvDsc] AS PagPrvDsc, T3.[MonDsc] AS PagMonDsc, T2.[PagCheque], T4.[ForDsc] AS PagForDsc, T8.[CPFech], T1.[PagDComCod] AS PagDComCod, T7.[TipAbr], T1.[PagItem] FROM ((((((([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[PagMonCod]) INNER JOIN [CFORMAPAGO] T4 ON T4.[ForCod] = T2.[PagForCod]) INNER JOIN [CPPROVEEDORES] T5 ON T5.[PrvCod] = T2.[PagPrvCod]) LEFT JOIN [TSBANCOS] T6 ON T6.[BanCod] = T5.[PrvBanCod1]) INNER JOIN [CTIPDOC] T7 ON T7.[TipCod] = T1.[PagDTipCod]) INNER JOIN [CPCUENTAPAGAR] T8 ON T8.[CPTipCod] = T1.[PagDTipCod] AND T8.[CPComCod] = T1.[PagDComCod] AND T8.[CPPrvCod] = T1.[PagDPrvCod])";
         AddWhere(sWhereString, "(T2.[PagFech] >= @AV10FDesde)");
         AddWhere(sWhereString, "(T2.[PagFech] <= @AV11FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[PagPrvCod] = @AV12CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV13ForCod) )
         {
            AddWhere(sWhereString, "(T2.[PagForCod] = @AV13ForCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T2.[PagMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PagReg], T1.[PagItem]";
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
               case 0 :
                     return conditional_P00812(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00812;
          prmP00812 = new Object[] {
          new ParDef("@AV10FDesde",GXType.Date,8,0) ,
          new ParDef("@AV11FHasta",GXType.Date,8,0) ,
          new ParDef("@AV12CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV13ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00812", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00812,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 100);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((bool[]) buf[17])[0] = rslt.wasNull(15);
                ((string[]) buf[18])[0] = rslt.getString(16, 15);
                ((string[]) buf[19])[0] = rslt.getString(17, 5);
                ((bool[]) buf[20])[0] = rslt.wasNull(17);
                ((short[]) buf[21])[0] = rslt.getShort(18);
                return;
       }
    }

 }

}
