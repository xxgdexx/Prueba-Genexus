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
namespace GeneXus.Programs.contabilidad {
   public class r_mayorgeneralanaliticopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_mayorgeneralanaliticopdf.aspx")), "contabilidad.r_mayorgeneralanaliticopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_mayorgeneralanaliticopdf.aspx")))) ;
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
               AV50FDesde = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV51FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV24cCosto = GetPar( "cCosto");
                  AV19cCuenta1 = GetPar( "cCuenta1");
                  AV20cCuenta2 = GetPar( "cCuenta2");
                  AV21CueCodAux = GetPar( "CueCodAux");
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

      public r_mayorgeneralanaliticopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_mayorgeneralanaliticopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_cCosto ,
                           ref string aP3_cCuenta1 ,
                           ref string aP4_cCuenta2 ,
                           ref string aP5_CueCodAux )
      {
         this.AV50FDesde = aP0_FDesde;
         this.AV51FHasta = aP1_FHasta;
         this.AV24cCosto = aP2_cCosto;
         this.AV19cCuenta1 = aP3_cCuenta1;
         this.AV20cCuenta2 = aP4_cCuenta2;
         this.AV21CueCodAux = aP5_CueCodAux;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV50FDesde;
         aP1_FHasta=this.AV51FHasta;
         aP2_cCosto=this.AV24cCosto;
         aP3_cCuenta1=this.AV19cCuenta1;
         aP4_cCuenta2=this.AV20cCuenta2;
         aP5_CueCodAux=this.AV21CueCodAux;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_cCosto ,
                                ref string aP3_cCuenta1 ,
                                ref string aP4_cCuenta2 )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_cCosto, ref aP3_cCuenta1, ref aP4_cCuenta2, ref aP5_CueCodAux);
         return AV21CueCodAux ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_cCosto ,
                                 ref string aP3_cCuenta1 ,
                                 ref string aP4_cCuenta2 ,
                                 ref string aP5_CueCodAux )
      {
         r_mayorgeneralanaliticopdf objr_mayorgeneralanaliticopdf;
         objr_mayorgeneralanaliticopdf = new r_mayorgeneralanaliticopdf();
         objr_mayorgeneralanaliticopdf.AV50FDesde = aP0_FDesde;
         objr_mayorgeneralanaliticopdf.AV51FHasta = aP1_FHasta;
         objr_mayorgeneralanaliticopdf.AV24cCosto = aP2_cCosto;
         objr_mayorgeneralanaliticopdf.AV19cCuenta1 = aP3_cCuenta1;
         objr_mayorgeneralanaliticopdf.AV20cCuenta2 = aP4_cCuenta2;
         objr_mayorgeneralanaliticopdf.AV21CueCodAux = aP5_CueCodAux;
         objr_mayorgeneralanaliticopdf.context.SetSubmitInitialConfig(context);
         objr_mayorgeneralanaliticopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_mayorgeneralanaliticopdf);
         aP0_FDesde=this.AV50FDesde;
         aP1_FHasta=this.AV51FHasta;
         aP2_cCosto=this.AV24cCosto;
         aP3_cCuenta1=this.AV19cCuenta1;
         aP4_cCuenta2=this.AV20cCuenta2;
         aP5_CueCodAux=this.AV21CueCodAux;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_mayorgeneralanaliticopdf)stateInfo).executePrivate();
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
            AV9Empresa = AV15Session.Get("Empresa");
            AV13EmpDir = AV15Session.Get("EmpDir");
            AV10EmpRUC = AV15Session.Get("EmpRUC");
            AV14Ruta = AV15Session.Get("RUTA") + "/Logo.jpg";
            AV8Logo = AV14Ruta;
            AV56Logo_GXI = GXDbFile.PathToUrl( AV14Ruta);
            AV11Titulo = "Mayor General Analitico Bimoneda ";
            AV12Periodo = "Del : " + context.localUtil.DToC( AV50FDesde, 2, "/") + "   Al  " + context.localUtil.DToC( AV51FHasta, 2, "/");
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19cCuenta1 ,
                                                 AV21CueCodAux ,
                                                 A91CueCod ,
                                                 A133CueCodAux ,
                                                 A135VouDFec ,
                                                 AV50FDesde ,
                                                 AV51FHasta ,
                                                 A2077VouSts } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00BH2 */
            pr_default.execute(0, new Object[] {AV50FDesde, AV51FHasta, AV19cCuenta1, AV21CueCodAux});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKBH3 = false;
               A127VouAno = P00BH2_A127VouAno[0];
               A128VouMes = P00BH2_A128VouMes[0];
               A126TASICod = P00BH2_A126TASICod[0];
               A129VouNum = P00BH2_A129VouNum[0];
               A133CueCodAux = P00BH2_A133CueCodAux[0];
               A91CueCod = P00BH2_A91CueCod[0];
               A2077VouSts = P00BH2_A2077VouSts[0];
               A135VouDFec = P00BH2_A135VouDFec[0];
               A860CueDsc = P00BH2_A860CueDsc[0];
               A70TipACod = P00BH2_A70TipACod[0];
               n70TipACod = P00BH2_n70TipACod[0];
               A130VouDSec = P00BH2_A130VouDSec[0];
               A2077VouSts = P00BH2_A2077VouSts[0];
               A860CueDsc = P00BH2_A860CueDsc[0];
               A70TipACod = P00BH2_A70TipACod[0];
               n70TipACod = P00BH2_n70TipACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BH2_A91CueCod[0], A91CueCod) == 0 ) )
               {
                  BRKBH3 = false;
                  A127VouAno = P00BH2_A127VouAno[0];
                  A128VouMes = P00BH2_A128VouMes[0];
                  A126TASICod = P00BH2_A126TASICod[0];
                  A129VouNum = P00BH2_A129VouNum[0];
                  A133CueCodAux = P00BH2_A133CueCodAux[0];
                  A130VouDSec = P00BH2_A130VouDSec[0];
                  BRKBH3 = true;
                  pr_default.readNext(0);
               }
               AV16CueCod = A91CueCod;
               AV17CueDsc = A860CueDsc;
               AV18TipACod = A70TipACod;
               AV38TDebeMN = 0.00m;
               AV37THaberMN = 0.00m;
               AV36TDebeME = 0.00m;
               AV35THaberME = 0.00m;
               HBH0( false, 22) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueCod, "")), 7, Gx_line+2, 86, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17CueDsc, "")), 124, Gx_line+2, 754, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
               /* Execute user subroutine: 'AUXILIAR' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               HBH0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38TDebeMN, "ZZZZZZ,ZZZ,ZZ9.99")), 239, Gx_line+7, 311, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37THaberMN, "ZZZZZZ,ZZZ,ZZ9.99")), 302, Gx_line+7, 374, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36TDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 419, Gx_line+7, 491, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35THaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+7, 561, Gx_line+18, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueCod, "")), 150, Gx_line+5, 229, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(247, Gx_line+5, 565, Gx_line+5, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               if ( ! BRKBH3 )
               {
                  BRKBH3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBH0( true, 0) ;
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
         /* 'AUXILIAR' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV21CueCodAux ,
                                              A133CueCodAux ,
                                              A135VouDFec ,
                                              AV50FDesde ,
                                              AV51FHasta ,
                                              A91CueCod ,
                                              AV16CueCod ,
                                              A2077VouSts } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BH3 */
         pr_default.execute(1, new Object[] {AV50FDesde, AV51FHasta, AV16CueCod, AV21CueCodAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBH5 = false;
            A127VouAno = P00BH3_A127VouAno[0];
            A128VouMes = P00BH3_A128VouMes[0];
            A126TASICod = P00BH3_A126TASICod[0];
            A129VouNum = P00BH3_A129VouNum[0];
            A134CueAuxCod = P00BH3_A134CueAuxCod[0];
            A133CueCodAux = P00BH3_A133CueCodAux[0];
            A2077VouSts = P00BH3_A2077VouSts[0];
            A91CueCod = P00BH3_A91CueCod[0];
            A135VouDFec = P00BH3_A135VouDFec[0];
            A130VouDSec = P00BH3_A130VouDSec[0];
            A2077VouSts = P00BH3_A2077VouSts[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BH3_A133CueCodAux[0], A133CueCodAux) == 0 ) )
            {
               BRKBH5 = false;
               A127VouAno = P00BH3_A127VouAno[0];
               A128VouMes = P00BH3_A128VouMes[0];
               A126TASICod = P00BH3_A126TASICod[0];
               A129VouNum = P00BH3_A129VouNum[0];
               A134CueAuxCod = P00BH3_A134CueAuxCod[0];
               A130VouDSec = P00BH3_A130VouDSec[0];
               BRKBH5 = true;
               pr_default.readNext(1);
            }
            AV28CueDAxu = A133CueCodAux;
            AV39TADebeMN = 0.00m;
            AV40TAHaberMN = 0.00m;
            AV41TADebeME = 0.00m;
            AV42TAHaberME = 0.00m;
            /* Execute user subroutine: 'NOMBREAUXILIAR' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CueDAxu)) )
            {
               HBH0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28CueDAxu, "")), 11, Gx_line+2, 97, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27CueDAxuDsc, "")), 93, Gx_line+1, 723, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            /* Execute user subroutine: 'DOCUMENTOS' */
            S135 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CueDAxu)) )
            {
               HBH0( false, 29) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TADebeMN, "ZZZZZZ,ZZZ,ZZ9.99")), 239, Gx_line+4, 311, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40TAHaberMN, "ZZZZZZ,ZZZ,ZZ9.99")), 302, Gx_line+4, 374, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41TADebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 419, Gx_line+4, 491, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TAHaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+4, 561, Gx_line+15, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28CueDAxu, "")), 150, Gx_line+2, 236, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(247, Gx_line+0, 565, Gx_line+0, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+29);
            }
            AV38TDebeMN = (decimal)(AV38TDebeMN+AV39TADebeMN);
            AV37THaberMN = (decimal)(AV37THaberMN+AV40TAHaberMN);
            AV36TDebeME = (decimal)(AV36TDebeME+AV41TADebeME);
            AV35THaberME = (decimal)(AV35THaberME+AV42TAHaberME);
            if ( ! BRKBH5 )
            {
               BRKBH5 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S135( )
      {
         /* 'DOCUMENTOS' Routine */
         returnInSub = false;
         /* Using cursor P00BH4 */
         pr_default.execute(2, new Object[] {AV16CueCod, AV28CueDAxu, AV50FDesde, AV51FHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBH7 = false;
            A127VouAno = P00BH4_A127VouAno[0];
            A128VouMes = P00BH4_A128VouMes[0];
            A126TASICod = P00BH4_A126TASICod[0];
            A129VouNum = P00BH4_A129VouNum[0];
            A133CueCodAux = P00BH4_A133CueCodAux[0];
            A91CueCod = P00BH4_A91CueCod[0];
            A2077VouSts = P00BH4_A2077VouSts[0];
            A136VouReg = P00BH4_A136VouReg[0];
            A2053VouDDoc = P00BH4_A2053VouDDoc[0];
            A132VouDTipCod = P00BH4_A132VouDTipCod[0];
            A135VouDFec = P00BH4_A135VouDFec[0];
            A130VouDSec = P00BH4_A130VouDSec[0];
            A2077VouSts = P00BH4_A2077VouSts[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BH4_A91CueCod[0], A91CueCod) == 0 ) && ( StringUtil.StrCmp(P00BH4_A133CueCodAux[0], A133CueCodAux) == 0 ) && ( StringUtil.StrCmp(P00BH4_A132VouDTipCod[0], A132VouDTipCod) == 0 ) && ( StringUtil.StrCmp(P00BH4_A2053VouDDoc[0], A2053VouDDoc) == 0 ) )
            {
               BRKBH7 = false;
               A127VouAno = P00BH4_A127VouAno[0];
               A128VouMes = P00BH4_A128VouMes[0];
               A126TASICod = P00BH4_A126TASICod[0];
               A129VouNum = P00BH4_A129VouNum[0];
               A136VouReg = P00BH4_A136VouReg[0];
               A130VouDSec = P00BH4_A130VouDSec[0];
               BRKBH7 = true;
               pr_default.readNext(2);
            }
            AV25VouDTipCod = A132VouDTipCod;
            AV26VouDDoc = A2053VouDDoc;
            AV21CueCodAux = A133CueCodAux;
            AV44TDDebeMN = 0.00m;
            AV43TDHaberMN = 0.00m;
            AV45TDDebeME = 0.00m;
            AV46TDHaberME = 0.00m;
            /* Execute user subroutine: 'DETALLE' */
            S147 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            HBH0( false, 35) ;
            getPrinter().GxDrawLine(247, Gx_line+3, 565, Gx_line+3, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TDDebeMN, "ZZZZZZ,ZZZ,ZZ9.99")), 239, Gx_line+6, 311, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TDHaberMN, "ZZZZZZ,ZZZ,ZZ9.99")), 302, Gx_line+6, 374, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TDHaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+6, 561, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TDDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 419, Gx_line+6, 491, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26VouDDoc, "")), 192, Gx_line+6, 257, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(247, Gx_line+19, 565, Gx_line+19, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDSaldoMN, "ZZZZZZ,ZZZ,ZZ9.99")), 302, Gx_line+22, 374, Gx_line+33, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TDSaldoME, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+22, 561, Gx_line+33, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Saldo : ", 192, Gx_line+21, 223, Gx_line+31, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            AV39TADebeMN = (decimal)(AV39TADebeMN+AV44TDDebeMN);
            AV40TAHaberMN = (decimal)(AV40TAHaberMN+AV43TDHaberMN);
            AV41TADebeME = (decimal)(AV41TADebeME+AV45TDDebeME);
            AV42TAHaberME = (decimal)(AV42TAHaberME+AV46TDHaberME);
            if ( ! BRKBH7 )
            {
               BRKBH7 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S147( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P00BH5 */
         pr_default.execute(3, new Object[] {AV16CueCod, AV28CueDAxu, AV50FDesde, AV51FHasta, AV25VouDTipCod, AV26VouDDoc});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A127VouAno = P00BH5_A127VouAno[0];
            A128VouMes = P00BH5_A128VouMes[0];
            A126TASICod = P00BH5_A126TASICod[0];
            A129VouNum = P00BH5_A129VouNum[0];
            A2077VouSts = P00BH5_A2077VouSts[0];
            A2053VouDDoc = P00BH5_A2053VouDDoc[0];
            A132VouDTipCod = P00BH5_A132VouDTipCod[0];
            A91CueCod = P00BH5_A91CueCod[0];
            A133CueCodAux = P00BH5_A133CueCodAux[0];
            A135VouDFec = P00BH5_A135VouDFec[0];
            A136VouReg = P00BH5_A136VouReg[0];
            A2069VouDTcmb = P00BH5_A2069VouDTcmb[0];
            A2051VouDDeb = P00BH5_A2051VouDDeb[0];
            A2055VouDHab = P00BH5_A2055VouDHab[0];
            A2052VouDDebO = P00BH5_A2052VouDDebO[0];
            A2056VouDHabO = P00BH5_A2056VouDHabO[0];
            A2054VouDGls = P00BH5_A2054VouDGls[0];
            A131VouDMon = P00BH5_A131VouDMon[0];
            A130VouDSec = P00BH5_A130VouDSec[0];
            A2077VouSts = P00BH5_A2077VouSts[0];
            AV33VouDFec = A135VouDFec;
            AV32VouReg = A136VouReg;
            AV31VouDTcmb = A2069VouDTcmb;
            AV30VouDDeb = A2051VouDDeb;
            AV29VouDHab = A2055VouDHab;
            AV53VouDDebE = ((AV49VouDMon>1) ? A2052VouDDebO : NumberUtil.Round( AV30VouDDeb/ (decimal)(A2069VouDTcmb), 2));
            AV52VouDHabE = ((AV49VouDMon>1) ? A2056VouDHabO : NumberUtil.Round( AV29VouDHab/ (decimal)(A2069VouDTcmb), 2));
            AV34VouDGls = A2054VouDGls;
            AV49VouDMon = A131VouDMon;
            HBH0( false, 14) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16CueCod, "")), 3, Gx_line+2, 67, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25VouDTipCod, "")), 160, Gx_line+2, 183, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26VouDDoc, "")), 192, Gx_line+2, 257, Gx_line+12, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV33VouDFec, "99/99/99"), 58, Gx_line+2, 90, Gx_line+13, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32VouReg, "")), 101, Gx_line+2, 155, Gx_line+12, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV30VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 246, Gx_line+2, 310, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31VouDTcmb, "ZZZZZZZZ9.99999")), 357, Gx_line+2, 421, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV29VouDHab, "ZZZ,ZZZ,ZZ9.99")), 310, Gx_line+2, 374, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34VouDGls, "")), 564, Gx_line+2, 816, Gx_line+12, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52VouDHabE, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+2, 561, Gx_line+13, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53VouDDebE, "ZZZZZZ,ZZZ,ZZ9.99")), 419, Gx_line+2, 491, Gx_line+13, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+14);
            AV44TDDebeMN = (decimal)(AV44TDDebeMN+AV30VouDDeb);
            AV43TDHaberMN = (decimal)(AV43TDHaberMN+AV29VouDHab);
            AV45TDDebeME = (decimal)(AV45TDDebeME+AV53VouDDebE);
            AV46TDHaberME = (decimal)(AV46TDHaberME+AV52VouDHabE);
            AV47TDSaldoMN = (decimal)(AV44TDDebeMN-AV43TDHaberMN);
            AV48TDSaldoME = (decimal)(AV45TDDebeME-AV46TDHaberME);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S125( )
      {
         /* 'NOMBREAUXILIAR' Routine */
         returnInSub = false;
         AV67GXLvl147 = 0;
         /* Using cursor P00BH6 */
         pr_default.execute(4, new Object[] {AV18TipACod, AV28CueDAxu});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A71TipADCod = P00BH6_A71TipADCod[0];
            A70TipACod = P00BH6_A70TipACod[0];
            n70TipACod = P00BH6_n70TipACod[0];
            A72TipADDsc = P00BH6_A72TipADDsc[0];
            AV67GXLvl147 = 1;
            AV27CueDAxuDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( AV67GXLvl147 == 0 )
         {
            AV27CueDAxuDsc = "SIN AUXILIAR";
         }
      }

      protected void HBH0( bool bFoot ,
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
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV8Logo)) ? AV56Logo_GXI : AV8Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 7, Gx_line+3, 176, Gx_line+74) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9Empresa, "")), 10, Gx_line+81, 378, Gx_line+99, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10EmpRUC, "")), 10, Gx_line+98, 379, Gx_line+116, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hora:", 698, Gx_line+35, 730, Gx_line+49, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 698, Gx_line+53, 742, Gx_line+67, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 698, Gx_line+18, 737, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 757, Gx_line+17, 804, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 720, Gx_line+34, 804, Gx_line+49, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 766, Gx_line+52, 805, Gx_line+67, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Titulo, "")), 203, Gx_line+10, 659, Gx_line+44, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Periodo, "")), 203, Gx_line+42, 659, Gx_line+76, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+122);
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha ", 65, Gx_line+13, 93, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 61, Gx_line+28, 94, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Nº Registro", 104, Gx_line+21, 152, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 182, Gx_line+6, 231, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo ", 163, Gx_line+28, 184, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("NUEVOS SOLES ", 275, Gx_line+6, 342, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 269, Gx_line+28, 292, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 335, Gx_line+28, 361, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de ", 384, Gx_line+13, 417, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cambio", 385, Gx_line+28, 417, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DOLARES AMERICANOS", 443, Gx_line+6, 542, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 446, Gx_line+28, 469, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 515, Gx_line+28, 541, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa", 670, Gx_line+19, 694, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 196, Gx_line+28, 230, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(155, Gx_line+21, 378, Gx_line+21, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(426, Gx_line+21, 561, Gx_line+21, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cuenta ", 10, Gx_line+13, 42, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Gestión", 10, Gx_line+28, 42, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(100, Gx_line+0, 100, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(155, Gx_line+0, 155, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(188, Gx_line+21, 188, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(252, Gx_line+0, 252, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(53, Gx_line+0, 53, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(377, Gx_line+0, 377, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(316, Gx_line+21, 316, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(425, Gx_line+0, 425, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(490, Gx_line+21, 490, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(560, Gx_line+0, 560, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 817, Gx_line+45, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+45);
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
         AV9Empresa = "";
         AV15Session = context.GetSession();
         AV13EmpDir = "";
         AV10EmpRUC = "";
         AV14Ruta = "";
         AV8Logo = "";
         AV56Logo_GXI = "";
         AV11Titulo = "";
         AV12Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         P00BH2_A127VouAno = new short[1] ;
         P00BH2_A128VouMes = new short[1] ;
         P00BH2_A126TASICod = new int[1] ;
         P00BH2_A129VouNum = new string[] {""} ;
         P00BH2_A133CueCodAux = new string[] {""} ;
         P00BH2_A91CueCod = new string[] {""} ;
         P00BH2_A2077VouSts = new short[1] ;
         P00BH2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BH2_A860CueDsc = new string[] {""} ;
         P00BH2_A70TipACod = new int[1] ;
         P00BH2_n70TipACod = new bool[] {false} ;
         P00BH2_A130VouDSec = new int[1] ;
         A129VouNum = "";
         A860CueDsc = "";
         AV16CueCod = "";
         AV17CueDsc = "";
         P00BH3_A127VouAno = new short[1] ;
         P00BH3_A128VouMes = new short[1] ;
         P00BH3_A126TASICod = new int[1] ;
         P00BH3_A129VouNum = new string[] {""} ;
         P00BH3_A134CueAuxCod = new string[] {""} ;
         P00BH3_A133CueCodAux = new string[] {""} ;
         P00BH3_A2077VouSts = new short[1] ;
         P00BH3_A91CueCod = new string[] {""} ;
         P00BH3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BH3_A130VouDSec = new int[1] ;
         A134CueAuxCod = "";
         AV28CueDAxu = "";
         AV27CueDAxuDsc = "";
         P00BH4_A127VouAno = new short[1] ;
         P00BH4_A128VouMes = new short[1] ;
         P00BH4_A126TASICod = new int[1] ;
         P00BH4_A129VouNum = new string[] {""} ;
         P00BH4_A133CueCodAux = new string[] {""} ;
         P00BH4_A91CueCod = new string[] {""} ;
         P00BH4_A2077VouSts = new short[1] ;
         P00BH4_A136VouReg = new string[] {""} ;
         P00BH4_A2053VouDDoc = new string[] {""} ;
         P00BH4_A132VouDTipCod = new string[] {""} ;
         P00BH4_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BH4_A130VouDSec = new int[1] ;
         A136VouReg = "";
         A2053VouDDoc = "";
         A132VouDTipCod = "";
         AV25VouDTipCod = "";
         AV26VouDDoc = "";
         P00BH5_A127VouAno = new short[1] ;
         P00BH5_A128VouMes = new short[1] ;
         P00BH5_A126TASICod = new int[1] ;
         P00BH5_A129VouNum = new string[] {""} ;
         P00BH5_A2077VouSts = new short[1] ;
         P00BH5_A2053VouDDoc = new string[] {""} ;
         P00BH5_A132VouDTipCod = new string[] {""} ;
         P00BH5_A91CueCod = new string[] {""} ;
         P00BH5_A133CueCodAux = new string[] {""} ;
         P00BH5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BH5_A136VouReg = new string[] {""} ;
         P00BH5_A2069VouDTcmb = new decimal[1] ;
         P00BH5_A2051VouDDeb = new decimal[1] ;
         P00BH5_A2055VouDHab = new decimal[1] ;
         P00BH5_A2052VouDDebO = new decimal[1] ;
         P00BH5_A2056VouDHabO = new decimal[1] ;
         P00BH5_A2054VouDGls = new string[] {""} ;
         P00BH5_A131VouDMon = new int[1] ;
         P00BH5_A130VouDSec = new int[1] ;
         A2054VouDGls = "";
         AV33VouDFec = DateTime.MinValue;
         AV32VouReg = "";
         AV34VouDGls = "";
         P00BH6_A71TipADCod = new string[] {""} ;
         P00BH6_A70TipACod = new int[1] ;
         P00BH6_n70TipACod = new bool[] {false} ;
         P00BH6_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         AV8Logo = "";
         sImgUrl = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_mayorgeneralanaliticopdf__default(),
            new Object[][] {
                new Object[] {
               P00BH2_A127VouAno, P00BH2_A128VouMes, P00BH2_A126TASICod, P00BH2_A129VouNum, P00BH2_A133CueCodAux, P00BH2_A91CueCod, P00BH2_A2077VouSts, P00BH2_A135VouDFec, P00BH2_A860CueDsc, P00BH2_A70TipACod,
               P00BH2_n70TipACod, P00BH2_A130VouDSec
               }
               , new Object[] {
               P00BH3_A127VouAno, P00BH3_A128VouMes, P00BH3_A126TASICod, P00BH3_A129VouNum, P00BH3_A134CueAuxCod, P00BH3_A133CueCodAux, P00BH3_A2077VouSts, P00BH3_A91CueCod, P00BH3_A135VouDFec, P00BH3_A130VouDSec
               }
               , new Object[] {
               P00BH4_A127VouAno, P00BH4_A128VouMes, P00BH4_A126TASICod, P00BH4_A129VouNum, P00BH4_A133CueCodAux, P00BH4_A91CueCod, P00BH4_A2077VouSts, P00BH4_A136VouReg, P00BH4_A2053VouDDoc, P00BH4_A132VouDTipCod,
               P00BH4_A135VouDFec, P00BH4_A130VouDSec
               }
               , new Object[] {
               P00BH5_A127VouAno, P00BH5_A128VouMes, P00BH5_A126TASICod, P00BH5_A129VouNum, P00BH5_A2077VouSts, P00BH5_A2053VouDDoc, P00BH5_A132VouDTipCod, P00BH5_A91CueCod, P00BH5_A133CueCodAux, P00BH5_A135VouDFec,
               P00BH5_A136VouReg, P00BH5_A2069VouDTcmb, P00BH5_A2051VouDDeb, P00BH5_A2055VouDHab, P00BH5_A2052VouDDebO, P00BH5_A2056VouDHabO, P00BH5_A2054VouDGls, P00BH5_A131VouDMon, P00BH5_A130VouDSec
               }
               , new Object[] {
               P00BH6_A71TipADCod, P00BH6_A70TipACod, P00BH6_A72TipADDsc
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
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private short AV67GXLvl147 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int A70TipACod ;
      private int A130VouDSec ;
      private int AV18TipACod ;
      private int Gx_OldLine ;
      private int A131VouDMon ;
      private int AV49VouDMon ;
      private decimal AV38TDebeMN ;
      private decimal AV37THaberMN ;
      private decimal AV36TDebeME ;
      private decimal AV35THaberME ;
      private decimal AV39TADebeMN ;
      private decimal AV40TAHaberMN ;
      private decimal AV41TADebeME ;
      private decimal AV42TAHaberME ;
      private decimal AV44TDDebeMN ;
      private decimal AV43TDHaberMN ;
      private decimal AV45TDDebeME ;
      private decimal AV46TDHaberME ;
      private decimal AV47TDSaldoMN ;
      private decimal AV48TDSaldoME ;
      private decimal A2069VouDTcmb ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal AV31VouDTcmb ;
      private decimal AV30VouDDeb ;
      private decimal AV29VouDHab ;
      private decimal AV53VouDDebE ;
      private decimal AV52VouDHabE ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV24cCosto ;
      private string AV19cCuenta1 ;
      private string AV20cCuenta2 ;
      private string AV21CueCodAux ;
      private string AV9Empresa ;
      private string AV13EmpDir ;
      private string AV10EmpRUC ;
      private string AV14Ruta ;
      private string AV11Titulo ;
      private string AV12Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A129VouNum ;
      private string A860CueDsc ;
      private string AV16CueCod ;
      private string AV17CueDsc ;
      private string A134CueAuxCod ;
      private string AV28CueDAxu ;
      private string AV27CueDAxuDsc ;
      private string A136VouReg ;
      private string A2053VouDDoc ;
      private string A132VouDTipCod ;
      private string AV25VouDTipCod ;
      private string AV26VouDDoc ;
      private string A2054VouDGls ;
      private string AV32VouReg ;
      private string AV34VouDGls ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string sImgUrl ;
      private string Gx_time ;
      private DateTime AV50FDesde ;
      private DateTime AV51FHasta ;
      private DateTime A135VouDFec ;
      private DateTime AV33VouDFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBH3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private bool BRKBH5 ;
      private bool BRKBH7 ;
      private string AV56Logo_GXI ;
      private string AV8Logo ;
      private string Logo ;
      private IGxSession AV15Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_cCosto ;
      private string aP3_cCuenta1 ;
      private string aP4_cCuenta2 ;
      private string aP5_CueCodAux ;
      private IDataStoreProvider pr_default ;
      private short[] P00BH2_A127VouAno ;
      private short[] P00BH2_A128VouMes ;
      private int[] P00BH2_A126TASICod ;
      private string[] P00BH2_A129VouNum ;
      private string[] P00BH2_A133CueCodAux ;
      private string[] P00BH2_A91CueCod ;
      private short[] P00BH2_A2077VouSts ;
      private DateTime[] P00BH2_A135VouDFec ;
      private string[] P00BH2_A860CueDsc ;
      private int[] P00BH2_A70TipACod ;
      private bool[] P00BH2_n70TipACod ;
      private int[] P00BH2_A130VouDSec ;
      private short[] P00BH3_A127VouAno ;
      private short[] P00BH3_A128VouMes ;
      private int[] P00BH3_A126TASICod ;
      private string[] P00BH3_A129VouNum ;
      private string[] P00BH3_A134CueAuxCod ;
      private string[] P00BH3_A133CueCodAux ;
      private short[] P00BH3_A2077VouSts ;
      private string[] P00BH3_A91CueCod ;
      private DateTime[] P00BH3_A135VouDFec ;
      private int[] P00BH3_A130VouDSec ;
      private short[] P00BH4_A127VouAno ;
      private short[] P00BH4_A128VouMes ;
      private int[] P00BH4_A126TASICod ;
      private string[] P00BH4_A129VouNum ;
      private string[] P00BH4_A133CueCodAux ;
      private string[] P00BH4_A91CueCod ;
      private short[] P00BH4_A2077VouSts ;
      private string[] P00BH4_A136VouReg ;
      private string[] P00BH4_A2053VouDDoc ;
      private string[] P00BH4_A132VouDTipCod ;
      private DateTime[] P00BH4_A135VouDFec ;
      private int[] P00BH4_A130VouDSec ;
      private short[] P00BH5_A127VouAno ;
      private short[] P00BH5_A128VouMes ;
      private int[] P00BH5_A126TASICod ;
      private string[] P00BH5_A129VouNum ;
      private short[] P00BH5_A2077VouSts ;
      private string[] P00BH5_A2053VouDDoc ;
      private string[] P00BH5_A132VouDTipCod ;
      private string[] P00BH5_A91CueCod ;
      private string[] P00BH5_A133CueCodAux ;
      private DateTime[] P00BH5_A135VouDFec ;
      private string[] P00BH5_A136VouReg ;
      private decimal[] P00BH5_A2069VouDTcmb ;
      private decimal[] P00BH5_A2051VouDDeb ;
      private decimal[] P00BH5_A2055VouDHab ;
      private decimal[] P00BH5_A2052VouDDebO ;
      private decimal[] P00BH5_A2056VouDHabO ;
      private string[] P00BH5_A2054VouDGls ;
      private int[] P00BH5_A131VouDMon ;
      private int[] P00BH5_A130VouDSec ;
      private string[] P00BH6_A71TipADCod ;
      private int[] P00BH6_A70TipACod ;
      private bool[] P00BH6_n70TipACod ;
      private string[] P00BH6_A72TipADDsc ;
   }

   public class r_mayorgeneralanaliticopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BH2( IGxContext context ,
                                             string AV19cCuenta1 ,
                                             string AV21CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV50FDesde ,
                                             DateTime AV51FHasta ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCodAux], T1.[CueCod], T2.[VouSts], T1.[VouDFec], T3.[CueDsc], T3.[TipACod], T1.[VouDSec] FROM (([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV50FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV51FHasta)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV19cCuenta1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV21CueCodAux)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BH3( IGxContext context ,
                                             string AV21CueCodAux ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV50FDesde ,
                                             DateTime AV51FHasta ,
                                             string A91CueCod ,
                                             string AV16CueCod ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueAuxCod], T1.[CueCodAux], T2.[VouSts], T1.[CueCod], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV50FDesde)");
         AddWhere(sWhereString, "(T1.[VouDFec] <= @AV51FHasta)");
         AddWhere(sWhereString, "(T1.[CueCod] = @AV16CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV21CueCodAux)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCodAux], T1.[CueAuxCod]";
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
               case 0 :
                     return conditional_P00BH2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] );
               case 1 :
                     return conditional_P00BH3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00BH4;
          prmP00BH4 = new Object[] {
          new ParDef("@AV16CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV28CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV51FHasta",GXType.Date,8,0)
          };
          Object[] prmP00BH5;
          prmP00BH5 = new Object[] {
          new ParDef("@AV16CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV28CueDAxu",GXType.NChar,20,0) ,
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV51FHasta",GXType.Date,8,0) ,
          new ParDef("@AV25VouDTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV26VouDDoc",GXType.NChar,20,0)
          };
          Object[] prmP00BH6;
          prmP00BH6 = new Object[] {
          new ParDef("@AV18TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV28CueDAxu",GXType.NChar,20,0)
          };
          Object[] prmP00BH2;
          prmP00BH2 = new Object[] {
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV51FHasta",GXType.Date,8,0) ,
          new ParDef("@AV19cCuenta1",GXType.NChar,15,0) ,
          new ParDef("@AV21CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00BH3;
          prmP00BH3 = new Object[] {
          new ParDef("@AV50FDesde",GXType.Date,8,0) ,
          new ParDef("@AV51FHasta",GXType.Date,8,0) ,
          new ParDef("@AV16CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV21CueCodAux",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BH3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BH4", "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCodAux], T1.[CueCod], T2.[VouSts], T1.[VouReg], T1.[VouDDoc], T1.[VouDTipCod], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[CueCod] = @AV16CueCod and T1.[CueCodAux] = @AV28CueDAxu) AND (T1.[VouDFec] >= @AV50FDesde) AND (T1.[VouDFec] <= @AV51FHasta) AND (T2.[VouSts] = 1) ORDER BY T1.[CueCod], T1.[CueCodAux], T1.[VouDTipCod], T1.[VouDDoc], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BH5", "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouDDoc], T1.[VouDTipCod], T1.[CueCod], T1.[CueCodAux], T1.[VouDFec], T1.[VouReg], T1.[VouDTcmb], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDGls], T1.[VouDMon], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[CueCod] = @AV16CueCod and T1.[CueCodAux] = @AV28CueDAxu) AND (T1.[VouDFec] >= @AV50FDesde) AND (T1.[VouDFec] <= @AV51FHasta) AND (T1.[VouDTipCod] = @AV25VouDTipCod) AND (T1.[VouDDoc] = @AV26VouDDoc) AND (T2.[VouSts] = 1) ORDER BY T1.[CueCod], T1.[CueCodAux] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BH6", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV18TipACod and [TipADCod] = @AV28CueDAxu ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BH6,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 100);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((string[]) buf[7])[0] = rslt.getString(8, 15);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 15);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 100);
                ((int[]) buf[17])[0] = rslt.getInt(18);
                ((int[]) buf[18])[0] = rslt.getInt(19);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
