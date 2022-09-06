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
   public class r_registrocostoresumidopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registrocostoresumidopdf.aspx")), "contabilidad.r_registrocostoresumidopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registrocostoresumidopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "VouAno");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV35VouAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV66VouMes = (short)(NumberUtil.Val( GetPar( "VouMes"), "."));
                  AV50nCosCod = GetPar( "nCosCod");
                  AV69cTipo = GetPar( "cTipo");
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

      public r_registrocostoresumidopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registrocostoresumidopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_VouAno ,
                           ref short aP1_VouMes ,
                           ref string aP2_nCosCod ,
                           ref string aP3_cTipo )
      {
         this.AV35VouAno = aP0_VouAno;
         this.AV66VouMes = aP1_VouMes;
         this.AV50nCosCod = aP2_nCosCod;
         this.AV69cTipo = aP3_cTipo;
         initialize();
         executePrivate();
         aP0_VouAno=this.AV35VouAno;
         aP1_VouMes=this.AV66VouMes;
         aP2_nCosCod=this.AV50nCosCod;
         aP3_cTipo=this.AV69cTipo;
      }

      public string executeUdp( ref short aP0_VouAno ,
                                ref short aP1_VouMes ,
                                ref string aP2_nCosCod )
      {
         execute(ref aP0_VouAno, ref aP1_VouMes, ref aP2_nCosCod, ref aP3_cTipo);
         return AV69cTipo ;
      }

      public void executeSubmit( ref short aP0_VouAno ,
                                 ref short aP1_VouMes ,
                                 ref string aP2_nCosCod ,
                                 ref string aP3_cTipo )
      {
         r_registrocostoresumidopdf objr_registrocostoresumidopdf;
         objr_registrocostoresumidopdf = new r_registrocostoresumidopdf();
         objr_registrocostoresumidopdf.AV35VouAno = aP0_VouAno;
         objr_registrocostoresumidopdf.AV66VouMes = aP1_VouMes;
         objr_registrocostoresumidopdf.AV50nCosCod = aP2_nCosCod;
         objr_registrocostoresumidopdf.AV69cTipo = aP3_cTipo;
         objr_registrocostoresumidopdf.context.SetSubmitInitialConfig(context);
         objr_registrocostoresumidopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registrocostoresumidopdf);
         aP0_VouAno=this.AV35VouAno;
         aP1_VouMes=this.AV66VouMes;
         aP2_nCosCod=this.AV50nCosCod;
         aP3_cTipo=this.AV69cTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registrocostoresumidopdf)stateInfo).executePrivate();
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
            AV27Empresa = AV30Session.Get("Empresa");
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV31EmpRUC = AV30Session.Get("EmpRUC");
            AV32Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV32Ruta;
            AV73Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            AV13Titulo = "Registro de Costos (Resumido)";
            if ( StringUtil.StrCmp(AV69cTipo, "M") == 0 )
            {
               GXt_char1 = AV14Periodo;
               new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV66VouMes, out  GXt_char1) ;
               AV14Periodo = "Mes : " + StringUtil.Trim( GXt_char1) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV35VouAno), 10, 0));
            }
            else
            {
               GXt_char1 = AV14Periodo;
               new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV66VouMes, out  GXt_char1) ;
               AV14Periodo = "Al  : " + StringUtil.Trim( GXt_char1) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV35VouAno), 10, 0));
            }
            AV68TotalGeneral = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV50nCosCod ,
                                                 A79COSCod ,
                                                 A91CueCod ,
                                                 A128VouMes ,
                                                 AV66VouMes ,
                                                 A127VouAno ,
                                                 AV35VouAno } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00CT2 */
            pr_default.execute(0, new Object[] {AV66VouMes, AV35VouAno, AV50nCosCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKCT3 = false;
               A79COSCod = P00CT2_A79COSCod[0];
               n79COSCod = P00CT2_n79COSCod[0];
               A127VouAno = P00CT2_A127VouAno[0];
               A128VouMes = P00CT2_A128VouMes[0];
               A91CueCod = P00CT2_A91CueCod[0];
               A135VouDFec = P00CT2_A135VouDFec[0];
               A761COSDsc = P00CT2_A761COSDsc[0];
               A126TASICod = P00CT2_A126TASICod[0];
               A129VouNum = P00CT2_A129VouNum[0];
               A130VouDSec = P00CT2_A130VouDSec[0];
               A761COSDsc = P00CT2_A761COSDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CT2_A79COSCod[0], A79COSCod) == 0 ) )
               {
                  BRKCT3 = false;
                  A127VouAno = P00CT2_A127VouAno[0];
                  A128VouMes = P00CT2_A128VouMes[0];
                  A126TASICod = P00CT2_A126TASICod[0];
                  A129VouNum = P00CT2_A129VouNum[0];
                  A130VouDSec = P00CT2_A130VouDSec[0];
                  BRKCT3 = true;
                  pr_default.readNext(0);
               }
               AV21CosCod = A79COSCod;
               AV36COSDsc = "Centro de Costo : " + StringUtil.Trim( A79COSCod) + " - " + StringUtil.Trim( A761COSDsc);
               AV67CostoTotal = "Total Centro de Costo : " + StringUtil.Trim( A79COSCod) + " - " + StringUtil.Trim( A761COSDsc);
               AV52TEnero = 0.00m;
               /* Execute user subroutine: 'VALIDACENTROCOSTO' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV70Flag == 0 )
               {
                  HCT0( false, 27) ;
                  getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36COSDsc, "")), 5, Gx_line+5, 735, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+27);
                  /* Execute user subroutine: 'SALDOCUENTACENTROCOSTO' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  HCT0( false, 42) ;
                  getPrinter().GxDrawLine(627, Gx_line+10, 792, Gx_line+10, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 663, Gx_line+19, 770, Gx_line+34, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67CostoTotal, "")), 83, Gx_line+18, 587, Gx_line+35, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+42);
               }
               AV68TotalGeneral = (decimal)(AV68TotalGeneral+AV52TEnero);
               if ( ! BRKCT3 )
               {
                  BRKCT3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            HCT0( false, 57) ;
            getPrinter().GxDrawLine(628, Gx_line+10, 792, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 658, Gx_line+22, 765, Gx_line+37, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 496, Gx_line+20, 589, Gx_line+34, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+57);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HCT0( true, 0) ;
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
         /* 'SALDOCUENTACENTROCOSTO' Routine */
         returnInSub = false;
         /* Using cursor P00CT3 */
         pr_default.execute(1, new Object[] {AV21CosCod, AV35VouAno, AV66VouMes});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCT5 = false;
            A128VouMes = P00CT3_A128VouMes[0];
            A91CueCod = P00CT3_A91CueCod[0];
            A127VouAno = P00CT3_A127VouAno[0];
            A859CueCos = P00CT3_A859CueCos[0];
            A79COSCod = P00CT3_A79COSCod[0];
            n79COSCod = P00CT3_n79COSCod[0];
            A860CueDsc = P00CT3_A860CueDsc[0];
            A126TASICod = P00CT3_A126TASICod[0];
            A129VouNum = P00CT3_A129VouNum[0];
            A130VouDSec = P00CT3_A130VouDSec[0];
            A859CueCos = P00CT3_A859CueCos[0];
            A860CueDsc = P00CT3_A860CueDsc[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CT3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKCT5 = false;
               A128VouMes = P00CT3_A128VouMes[0];
               A127VouAno = P00CT3_A127VouAno[0];
               A126TASICod = P00CT3_A126TASICod[0];
               A129VouNum = P00CT3_A129VouNum[0];
               A130VouDSec = P00CT3_A130VouDSec[0];
               BRKCT5 = true;
               pr_default.readNext(1);
            }
            AV25CueCod = A91CueCod;
            AV65Cuenta = StringUtil.Trim( A860CueDsc);
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV37nEnero = AV51Total;
            HCT0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 663, Gx_line+3, 770, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Cuenta, "")), 110, Gx_line+3, 623, Gx_line+17, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 11, Gx_line+3, 106, Gx_line+18, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV52TEnero = (decimal)(AV52TEnero+AV37nEnero);
            if ( ! BRKCT5 )
            {
               BRKCT5 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S125( )
      {
         /* 'SALDOMES' Routine */
         returnInSub = false;
         AV51Total = 0.00m;
         if ( StringUtil.StrCmp(AV69cTipo, "M") == 0 )
         {
            /* Using cursor P00CT4 */
            pr_default.execute(2, new Object[] {AV35VouAno, AV66VouMes, AV25CueCod, AV21CosCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A126TASICod = P00CT4_A126TASICod[0];
               A129VouNum = P00CT4_A129VouNum[0];
               A2077VouSts = P00CT4_A2077VouSts[0];
               A128VouMes = P00CT4_A128VouMes[0];
               A127VouAno = P00CT4_A127VouAno[0];
               A91CueCod = P00CT4_A91CueCod[0];
               A79COSCod = P00CT4_A79COSCod[0];
               n79COSCod = P00CT4_n79COSCod[0];
               A2055VouDHab = P00CT4_A2055VouDHab[0];
               A2051VouDDeb = P00CT4_A2051VouDDeb[0];
               A130VouDSec = P00CT4_A130VouDSec[0];
               A2077VouSts = P00CT4_A2077VouSts[0];
               AV51Total = (decimal)(AV51Total+(A2051VouDDeb-A2055VouDHab));
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            /* Using cursor P00CT5 */
            pr_default.execute(3, new Object[] {AV35VouAno, AV21CosCod, AV25CueCod, AV66VouMes});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A126TASICod = P00CT5_A126TASICod[0];
               A129VouNum = P00CT5_A129VouNum[0];
               A2077VouSts = P00CT5_A2077VouSts[0];
               A128VouMes = P00CT5_A128VouMes[0];
               A127VouAno = P00CT5_A127VouAno[0];
               A91CueCod = P00CT5_A91CueCod[0];
               A79COSCod = P00CT5_A79COSCod[0];
               n79COSCod = P00CT5_n79COSCod[0];
               A2055VouDHab = P00CT5_A2055VouDHab[0];
               A2051VouDDeb = P00CT5_A2051VouDDeb[0];
               A130VouDSec = P00CT5_A130VouDSec[0];
               A2077VouSts = P00CT5_A2077VouSts[0];
               AV51Total = (decimal)(AV51Total+(A2051VouDDeb-A2055VouDHab));
               pr_default.readNext(3);
            }
            pr_default.close(3);
         }
      }

      protected void S131( )
      {
         /* 'VALIDACENTROCOSTO' Routine */
         returnInSub = false;
         AV70Flag = 0;
         /* Using cursor P00CT6 */
         pr_default.execute(4, new Object[] {AV21CosCod, AV35VouAno, AV66VouMes});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKCT9 = false;
            A128VouMes = P00CT6_A128VouMes[0];
            A91CueCod = P00CT6_A91CueCod[0];
            A127VouAno = P00CT6_A127VouAno[0];
            A859CueCos = P00CT6_A859CueCos[0];
            A79COSCod = P00CT6_A79COSCod[0];
            n79COSCod = P00CT6_n79COSCod[0];
            A860CueDsc = P00CT6_A860CueDsc[0];
            A126TASICod = P00CT6_A126TASICod[0];
            A129VouNum = P00CT6_A129VouNum[0];
            A130VouDSec = P00CT6_A130VouDSec[0];
            A859CueCos = P00CT6_A859CueCos[0];
            A860CueDsc = P00CT6_A860CueDsc[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00CT6_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKCT9 = false;
               A128VouMes = P00CT6_A128VouMes[0];
               A127VouAno = P00CT6_A127VouAno[0];
               A126TASICod = P00CT6_A126TASICod[0];
               A129VouNum = P00CT6_A129VouNum[0];
               A130VouDSec = P00CT6_A130VouDSec[0];
               BRKCT9 = true;
               pr_default.readNext(4);
            }
            AV25CueCod = A91CueCod;
            AV65Cuenta = StringUtil.Trim( A860CueDsc);
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV52TEnero = (decimal)(AV52TEnero+AV51Total);
            if ( ! BRKCT9 )
            {
               BRKCT9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
         if ( (Convert.ToDecimal(0)==AV52TEnero) )
         {
            AV70Flag = 1;
         }
         AV52TEnero = 0.00m;
      }

      protected void HCT0( bool bFoot ,
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
               getPrinter().GxDrawRect(0, Gx_line+128, 783, Gx_line+171, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 193, Gx_line+25, 649, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 193, Gx_line+56, 649, Gx_line+90, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV73Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+9, 167, Gx_line+87) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 735, Gx_line+18, 774, Gx_line+33, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 685, Gx_line+18, 729, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(640, Gx_line+128, 640, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CUENTA", 28, Gx_line+145, 74, Gx_line+159, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(106, Gx_line+129, 106, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DESCRIPCION", 328, Gx_line+145, 407, Gx_line+159, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("IMPORTE", 686, Gx_line+132, 740, Gx_line+146, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("TOTAL", 695, Gx_line+152, 734, Gx_line+166, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+171);
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
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV28EmpDir = "";
         AV31EmpRUC = "";
         AV32Ruta = "";
         AV33Logo = "";
         AV73Logo_GXI = "";
         AV13Titulo = "";
         AV14Periodo = "";
         GXt_char1 = "";
         scmdbuf = "";
         A79COSCod = "";
         A91CueCod = "";
         P00CT2_A79COSCod = new string[] {""} ;
         P00CT2_n79COSCod = new bool[] {false} ;
         P00CT2_A127VouAno = new short[1] ;
         P00CT2_A128VouMes = new short[1] ;
         P00CT2_A91CueCod = new string[] {""} ;
         P00CT2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00CT2_A761COSDsc = new string[] {""} ;
         P00CT2_A126TASICod = new int[1] ;
         P00CT2_A129VouNum = new string[] {""} ;
         P00CT2_A130VouDSec = new int[1] ;
         A135VouDFec = DateTime.MinValue;
         A761COSDsc = "";
         A129VouNum = "";
         AV21CosCod = "";
         AV36COSDsc = "";
         AV67CostoTotal = "";
         P00CT3_A128VouMes = new short[1] ;
         P00CT3_A91CueCod = new string[] {""} ;
         P00CT3_A127VouAno = new short[1] ;
         P00CT3_A859CueCos = new short[1] ;
         P00CT3_A79COSCod = new string[] {""} ;
         P00CT3_n79COSCod = new bool[] {false} ;
         P00CT3_A860CueDsc = new string[] {""} ;
         P00CT3_A126TASICod = new int[1] ;
         P00CT3_A129VouNum = new string[] {""} ;
         P00CT3_A130VouDSec = new int[1] ;
         A860CueDsc = "";
         AV25CueCod = "";
         AV65Cuenta = "";
         P00CT4_A126TASICod = new int[1] ;
         P00CT4_A129VouNum = new string[] {""} ;
         P00CT4_A2077VouSts = new short[1] ;
         P00CT4_A128VouMes = new short[1] ;
         P00CT4_A127VouAno = new short[1] ;
         P00CT4_A91CueCod = new string[] {""} ;
         P00CT4_A79COSCod = new string[] {""} ;
         P00CT4_n79COSCod = new bool[] {false} ;
         P00CT4_A2055VouDHab = new decimal[1] ;
         P00CT4_A2051VouDDeb = new decimal[1] ;
         P00CT4_A130VouDSec = new int[1] ;
         P00CT5_A126TASICod = new int[1] ;
         P00CT5_A129VouNum = new string[] {""} ;
         P00CT5_A2077VouSts = new short[1] ;
         P00CT5_A128VouMes = new short[1] ;
         P00CT5_A127VouAno = new short[1] ;
         P00CT5_A91CueCod = new string[] {""} ;
         P00CT5_A79COSCod = new string[] {""} ;
         P00CT5_n79COSCod = new bool[] {false} ;
         P00CT5_A2055VouDHab = new decimal[1] ;
         P00CT5_A2051VouDDeb = new decimal[1] ;
         P00CT5_A130VouDSec = new int[1] ;
         P00CT6_A128VouMes = new short[1] ;
         P00CT6_A91CueCod = new string[] {""} ;
         P00CT6_A127VouAno = new short[1] ;
         P00CT6_A859CueCos = new short[1] ;
         P00CT6_A79COSCod = new string[] {""} ;
         P00CT6_n79COSCod = new bool[] {false} ;
         P00CT6_A860CueDsc = new string[] {""} ;
         P00CT6_A126TASICod = new int[1] ;
         P00CT6_A129VouNum = new string[] {""} ;
         P00CT6_A130VouDSec = new int[1] ;
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registrocostoresumidopdf__default(),
            new Object[][] {
                new Object[] {
               P00CT2_A79COSCod, P00CT2_n79COSCod, P00CT2_A127VouAno, P00CT2_A128VouMes, P00CT2_A91CueCod, P00CT2_A135VouDFec, P00CT2_A761COSDsc, P00CT2_A126TASICod, P00CT2_A129VouNum, P00CT2_A130VouDSec
               }
               , new Object[] {
               P00CT3_A128VouMes, P00CT3_A91CueCod, P00CT3_A127VouAno, P00CT3_A859CueCos, P00CT3_A79COSCod, P00CT3_n79COSCod, P00CT3_A860CueDsc, P00CT3_A126TASICod, P00CT3_A129VouNum, P00CT3_A130VouDSec
               }
               , new Object[] {
               P00CT4_A126TASICod, P00CT4_A129VouNum, P00CT4_A2077VouSts, P00CT4_A128VouMes, P00CT4_A127VouAno, P00CT4_A91CueCod, P00CT4_A79COSCod, P00CT4_n79COSCod, P00CT4_A2055VouDHab, P00CT4_A2051VouDDeb,
               P00CT4_A130VouDSec
               }
               , new Object[] {
               P00CT5_A126TASICod, P00CT5_A129VouNum, P00CT5_A2077VouSts, P00CT5_A128VouMes, P00CT5_A127VouAno, P00CT5_A91CueCod, P00CT5_A79COSCod, P00CT5_n79COSCod, P00CT5_A2055VouDHab, P00CT5_A2051VouDDeb,
               P00CT5_A130VouDSec
               }
               , new Object[] {
               P00CT6_A128VouMes, P00CT6_A91CueCod, P00CT6_A127VouAno, P00CT6_A859CueCos, P00CT6_A79COSCod, P00CT6_n79COSCod, P00CT6_A860CueDsc, P00CT6_A126TASICod, P00CT6_A129VouNum, P00CT6_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV35VouAno ;
      private short AV66VouMes ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short AV70Flag ;
      private short A859CueCos ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int Gx_OldLine ;
      private decimal AV68TotalGeneral ;
      private decimal AV52TEnero ;
      private decimal AV37nEnero ;
      private decimal AV51Total ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV50nCosCod ;
      private string AV69cTipo ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV31EmpRUC ;
      private string AV32Ruta ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string GXt_char1 ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A91CueCod ;
      private string A761COSDsc ;
      private string A129VouNum ;
      private string AV21CosCod ;
      private string AV36COSDsc ;
      private string AV67CostoTotal ;
      private string A860CueDsc ;
      private string AV25CueCod ;
      private string AV65Cuenta ;
      private string sImgUrl ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKCT3 ;
      private bool n79COSCod ;
      private bool returnInSub ;
      private bool BRKCT5 ;
      private bool BRKCT9 ;
      private string AV73Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_VouAno ;
      private short aP1_VouMes ;
      private string aP2_nCosCod ;
      private string aP3_cTipo ;
      private IDataStoreProvider pr_default ;
      private string[] P00CT2_A79COSCod ;
      private bool[] P00CT2_n79COSCod ;
      private short[] P00CT2_A127VouAno ;
      private short[] P00CT2_A128VouMes ;
      private string[] P00CT2_A91CueCod ;
      private DateTime[] P00CT2_A135VouDFec ;
      private string[] P00CT2_A761COSDsc ;
      private int[] P00CT2_A126TASICod ;
      private string[] P00CT2_A129VouNum ;
      private int[] P00CT2_A130VouDSec ;
      private short[] P00CT3_A128VouMes ;
      private string[] P00CT3_A91CueCod ;
      private short[] P00CT3_A127VouAno ;
      private short[] P00CT3_A859CueCos ;
      private string[] P00CT3_A79COSCod ;
      private bool[] P00CT3_n79COSCod ;
      private string[] P00CT3_A860CueDsc ;
      private int[] P00CT3_A126TASICod ;
      private string[] P00CT3_A129VouNum ;
      private int[] P00CT3_A130VouDSec ;
      private int[] P00CT4_A126TASICod ;
      private string[] P00CT4_A129VouNum ;
      private short[] P00CT4_A2077VouSts ;
      private short[] P00CT4_A128VouMes ;
      private short[] P00CT4_A127VouAno ;
      private string[] P00CT4_A91CueCod ;
      private string[] P00CT4_A79COSCod ;
      private bool[] P00CT4_n79COSCod ;
      private decimal[] P00CT4_A2055VouDHab ;
      private decimal[] P00CT4_A2051VouDDeb ;
      private int[] P00CT4_A130VouDSec ;
      private int[] P00CT5_A126TASICod ;
      private string[] P00CT5_A129VouNum ;
      private short[] P00CT5_A2077VouSts ;
      private short[] P00CT5_A128VouMes ;
      private short[] P00CT5_A127VouAno ;
      private string[] P00CT5_A91CueCod ;
      private string[] P00CT5_A79COSCod ;
      private bool[] P00CT5_n79COSCod ;
      private decimal[] P00CT5_A2055VouDHab ;
      private decimal[] P00CT5_A2051VouDDeb ;
      private int[] P00CT5_A130VouDSec ;
      private short[] P00CT6_A128VouMes ;
      private string[] P00CT6_A91CueCod ;
      private short[] P00CT6_A127VouAno ;
      private short[] P00CT6_A859CueCos ;
      private string[] P00CT6_A79COSCod ;
      private bool[] P00CT6_n79COSCod ;
      private string[] P00CT6_A860CueDsc ;
      private int[] P00CT6_A126TASICod ;
      private string[] P00CT6_A129VouNum ;
      private int[] P00CT6_A130VouDSec ;
   }

   public class r_registrocostoresumidopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CT2( IGxContext context ,
                                             string AV50nCosCod ,
                                             string A79COSCod ,
                                             string A91CueCod ,
                                             short A128VouMes ,
                                             short AV66VouMes ,
                                             short A127VouAno ,
                                             short AV35VouAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[COSCod], T1.[VouAno], T1.[VouMes], T1.[CueCod], T1.[VouDFec], T2.[COSDsc], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[COSCod])";
         AddWhere(sWhereString, "(Not (T1.[COSCod] = ''))");
         AddWhere(sWhereString, "(SUBSTRING(T1.[CueCod], 1, 2) = '90')");
         AddWhere(sWhereString, "(T1.[VouMes] = @AV66VouMes)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV35VouAno)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50nCosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV50nCosCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[COSCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00CT2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmP00CT3;
          prmP00CT3 = new Object[] {
          new ParDef("@AV21CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV66VouMes",GXType.Int16,2,0)
          };
          Object[] prmP00CT4;
          prmP00CT4 = new Object[] {
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV66VouMes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00CT5;
          prmP00CT5 = new Object[] {
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV66VouMes",GXType.Int16,2,0)
          };
          Object[] prmP00CT6;
          prmP00CT6 = new Object[] {
          new ParDef("@AV21CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV66VouMes",GXType.Int16,2,0)
          };
          Object[] prmP00CT2;
          prmP00CT2 = new Object[] {
          new ParDef("@AV66VouMes",GXType.Int16,2,0) ,
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV50nCosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CT3", "SELECT T1.[VouMes], T1.[CueCod], T1.[VouAno], T2.[CueCos], T1.[COSCod], T2.[CueDsc], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '90') AND (T1.[COSCod] = @AV21CosCod) AND (T2.[CueCos] = 1) AND (T1.[VouAno] = @AV35VouAno) AND (T1.[VouMes] = @AV66VouMes) ORDER BY T1.[CueCod], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CT4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[CueCod], T1.[COSCod], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV35VouAno and T1.[VouMes] = @AV66VouMes and T1.[CueCod] = @AV25CueCod) AND (T1.[COSCod] = @AV21CosCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CT5", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[CueCod], T1.[COSCod], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV35VouAno) AND (T1.[COSCod] = @AV21CosCod) AND (T1.[CueCod] = @AV25CueCod) AND (T2.[VouSts] = 1) AND (T1.[VouMes] <= @AV66VouMes) ORDER BY T1.[VouAno] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00CT6", "SELECT T1.[VouMes], T1.[CueCod], T1.[VouAno], T2.[CueCos], T1.[COSCod], T2.[CueDsc], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (SUBSTRING(T1.[CueCod], 1, 2) = '90') AND (T1.[COSCod] = @AV21CosCod) AND (T2.[CueCos] = 1) AND (T1.[VouAno] = @AV35VouAno) AND (T1.[VouMes] = @AV66VouMes) ORDER BY T1.[CueCod], T1.[VouMes] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CT6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 15);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
