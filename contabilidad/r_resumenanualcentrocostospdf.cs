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
   public class r_resumenanualcentrocostospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_resumenanualcentrocostospdf.aspx")), "contabilidad.r_resumenanualcentrocostospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_resumenanualcentrocostospdf.aspx")))) ;
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
                  AV19CueCod1 = GetPar( "CueCod1");
                  AV20CueCod2 = GetPar( "CueCod2");
                  AV50nCosCod = GetPar( "nCosCod");
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

      public r_resumenanualcentrocostospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenanualcentrocostospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_VouAno ,
                           ref string aP1_CueCod1 ,
                           ref string aP2_CueCod2 ,
                           ref string aP3_nCosCod )
      {
         this.AV35VouAno = aP0_VouAno;
         this.AV19CueCod1 = aP1_CueCod1;
         this.AV20CueCod2 = aP2_CueCod2;
         this.AV50nCosCod = aP3_nCosCod;
         initialize();
         executePrivate();
         aP0_VouAno=this.AV35VouAno;
         aP1_CueCod1=this.AV19CueCod1;
         aP2_CueCod2=this.AV20CueCod2;
         aP3_nCosCod=this.AV50nCosCod;
      }

      public string executeUdp( ref short aP0_VouAno ,
                                ref string aP1_CueCod1 ,
                                ref string aP2_CueCod2 )
      {
         execute(ref aP0_VouAno, ref aP1_CueCod1, ref aP2_CueCod2, ref aP3_nCosCod);
         return AV50nCosCod ;
      }

      public void executeSubmit( ref short aP0_VouAno ,
                                 ref string aP1_CueCod1 ,
                                 ref string aP2_CueCod2 ,
                                 ref string aP3_nCosCod )
      {
         r_resumenanualcentrocostospdf objr_resumenanualcentrocostospdf;
         objr_resumenanualcentrocostospdf = new r_resumenanualcentrocostospdf();
         objr_resumenanualcentrocostospdf.AV35VouAno = aP0_VouAno;
         objr_resumenanualcentrocostospdf.AV19CueCod1 = aP1_CueCod1;
         objr_resumenanualcentrocostospdf.AV20CueCod2 = aP2_CueCod2;
         objr_resumenanualcentrocostospdf.AV50nCosCod = aP3_nCosCod;
         objr_resumenanualcentrocostospdf.context.SetSubmitInitialConfig(context);
         objr_resumenanualcentrocostospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenanualcentrocostospdf);
         aP0_VouAno=this.AV35VouAno;
         aP1_CueCod1=this.AV19CueCod1;
         aP2_CueCod2=this.AV20CueCod2;
         aP3_nCosCod=this.AV50nCosCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenanualcentrocostospdf)stateInfo).executePrivate();
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
            AV27Empresa = AV30Session.Get("Empresa");
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV31EmpRUC = AV30Session.Get("EmpRUC");
            AV32Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV32Ruta;
            AV68Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            AV13Titulo = "Resumen Anual por Centros de Costos";
            AV14Periodo = "Año " + StringUtil.Trim( StringUtil.Str( (decimal)(AV35VouAno), 10, 0));
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV50nCosCod ,
                                                 AV19CueCod1 ,
                                                 AV20CueCod2 ,
                                                 A79COSCod ,
                                                 A91CueCod ,
                                                 A127VouAno ,
                                                 AV35VouAno } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00BL2 */
            pr_default.execute(0, new Object[] {AV35VouAno, AV50nCosCod, AV19CueCod1, AV20CueCod2});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKBL3 = false;
               A79COSCod = P00BL2_A79COSCod[0];
               n79COSCod = P00BL2_n79COSCod[0];
               A127VouAno = P00BL2_A127VouAno[0];
               A91CueCod = P00BL2_A91CueCod[0];
               A135VouDFec = P00BL2_A135VouDFec[0];
               A761COSDsc = P00BL2_A761COSDsc[0];
               A128VouMes = P00BL2_A128VouMes[0];
               A126TASICod = P00BL2_A126TASICod[0];
               A129VouNum = P00BL2_A129VouNum[0];
               A130VouDSec = P00BL2_A130VouDSec[0];
               A761COSDsc = P00BL2_A761COSDsc[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BL2_A79COSCod[0], A79COSCod) == 0 ) )
               {
                  BRKBL3 = false;
                  A127VouAno = P00BL2_A127VouAno[0];
                  A128VouMes = P00BL2_A128VouMes[0];
                  A126TASICod = P00BL2_A126TASICod[0];
                  A129VouNum = P00BL2_A129VouNum[0];
                  A130VouDSec = P00BL2_A130VouDSec[0];
                  BRKBL3 = true;
                  pr_default.readNext(0);
               }
               AV21CosCod = A79COSCod;
               AV36COSDsc = A761COSDsc;
               AV52TEnero = 0.00m;
               AV53TFebrero = 0.00m;
               AV54TMarzo = 0.00m;
               AV55TAbril = 0.00m;
               AV56TMayo = 0.00m;
               AV57TJunio = 0.00m;
               AV58TJulio = 0.00m;
               AV59TAgosto = 0.00m;
               AV60TSeptiembre = 0.00m;
               AV61TOctubre = 0.00m;
               AV62TNoviembre = 0.00m;
               AV63TDiciembre = 0.00m;
               AV64TTotal = 0.00m;
               HBL0( false, 27) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CosCod, "")), 7, Gx_line+5, 81, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36COSDsc, "")), 75, Gx_line+5, 805, Gx_line+23, 0+256, 0, 0, 0) ;
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
               HBL0( false, 42) ;
               getPrinter().GxDrawLine(205, Gx_line+8, 1100, Gx_line+8, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 995, Gx_line+16, 1102, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 919, Gx_line+16, 1026, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 849, Gx_line+16, 956, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+16, 888, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 714, Gx_line+16, 821, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+16, 754, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58TJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 581, Gx_line+16, 688, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 515, Gx_line+16, 622, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56TMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 445, Gx_line+16, 552, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 377, Gx_line+16, 484, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 315, Gx_line+16, 422, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 244, Gx_line+16, 351, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 179, Gx_line+16, 286, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CosCod, "")), 130, Gx_line+15, 204, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total C.Costo : ", 30, Gx_line+15, 133, Gx_line+33, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+42);
               if ( ! BRKBL3 )
               {
                  BRKBL3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBL0( true, 0) ;
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
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19CueCod1 ,
                                              AV20CueCod2 ,
                                              A91CueCod ,
                                              A79COSCod ,
                                              AV21CosCod ,
                                              A859CueCos ,
                                              A127VouAno ,
                                              AV35VouAno } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00BL3 */
         pr_default.execute(1, new Object[] {AV21CosCod, AV35VouAno, AV19CueCod1, AV20CueCod2});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBL5 = false;
            A133CueCodAux = P00BL3_A133CueCodAux[0];
            A91CueCod = P00BL3_A91CueCod[0];
            A127VouAno = P00BL3_A127VouAno[0];
            A859CueCos = P00BL3_A859CueCos[0];
            A79COSCod = P00BL3_A79COSCod[0];
            n79COSCod = P00BL3_n79COSCod[0];
            A860CueDsc = P00BL3_A860CueDsc[0];
            A128VouMes = P00BL3_A128VouMes[0];
            A126TASICod = P00BL3_A126TASICod[0];
            A129VouNum = P00BL3_A129VouNum[0];
            A130VouDSec = P00BL3_A130VouDSec[0];
            A859CueCos = P00BL3_A859CueCos[0];
            A860CueDsc = P00BL3_A860CueDsc[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BL3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRKBL5 = false;
               A133CueCodAux = P00BL3_A133CueCodAux[0];
               A127VouAno = P00BL3_A127VouAno[0];
               A128VouMes = P00BL3_A128VouMes[0];
               A126TASICod = P00BL3_A126TASICod[0];
               A129VouNum = P00BL3_A129VouNum[0];
               A130VouDSec = P00BL3_A130VouDSec[0];
               BRKBL5 = true;
               pr_default.readNext(1);
            }
            AV25CueCod = A91CueCod;
            AV65Cuenta = StringUtil.Trim( A91CueCod) + " - " + StringUtil.Trim( A860CueDsc);
            AV12Mes = 1;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV37nEnero = AV51Total;
            AV12Mes = 2;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV38nFebrero = AV51Total;
            AV12Mes = 3;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV39nMarzo = AV51Total;
            AV12Mes = 4;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV40nAbril = AV51Total;
            AV12Mes = 5;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV41nMayo = AV51Total;
            AV12Mes = 6;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV42nJunio = AV51Total;
            AV12Mes = 7;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV43nJulio = AV51Total;
            AV12Mes = 8;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV44nAgosto = AV51Total;
            AV12Mes = 9;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV45nSeptiembre = AV51Total;
            AV12Mes = 10;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV46nOctubre = AV51Total;
            AV12Mes = 11;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV47nNoviembre = AV51Total;
            AV12Mes = 12;
            /* Execute user subroutine: 'SALDOMES' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV48nDiciembre = AV51Total;
            AV49nTotal = (decimal)(AV37nEnero+AV38nFebrero+AV39nMarzo+AV40nAbril+AV41nMayo+AV42nJunio+AV43nJulio+AV44nAgosto+AV45nSeptiembre+AV46nOctubre+AV47nNoviembre+AV48nDiciembre);
            HBL0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 179, Gx_line+3, 286, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 244, Gx_line+3, 351, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 315, Gx_line+3, 422, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 377, Gx_line+3, 484, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 445, Gx_line+3, 552, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 515, Gx_line+3, 622, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 581, Gx_line+3, 688, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+3, 754, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45nSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 714, Gx_line+3, 821, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46nOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 781, Gx_line+3, 888, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47nNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 849, Gx_line+3, 956, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48nDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 919, Gx_line+3, 1026, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49nTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 995, Gx_line+3, 1102, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Cuenta, "")), 5, Gx_line+3, 224, Gx_line+17, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV52TEnero = (decimal)(AV52TEnero+AV37nEnero);
            AV53TFebrero = (decimal)(AV53TFebrero+AV38nFebrero);
            AV54TMarzo = (decimal)(AV54TMarzo+AV39nMarzo);
            AV55TAbril = (decimal)(AV55TAbril+AV40nAbril);
            AV56TMayo = (decimal)(AV56TMayo+AV41nMayo);
            AV57TJunio = (decimal)(AV57TJunio+AV42nJunio);
            AV58TJulio = (decimal)(AV58TJulio+AV43nJulio);
            AV59TAgosto = (decimal)(AV59TAgosto+AV44nAgosto);
            AV60TSeptiembre = (decimal)(AV60TSeptiembre+AV45nSeptiembre);
            AV61TOctubre = (decimal)(AV61TOctubre+AV46nOctubre);
            AV62TNoviembre = (decimal)(AV62TNoviembre+AV47nNoviembre);
            AV63TDiciembre = (decimal)(AV63TDiciembre+AV48nDiciembre);
            AV64TTotal = (decimal)(AV64TTotal+AV49nTotal);
            if ( ! BRKBL5 )
            {
               BRKBL5 = true;
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
         /* Using cursor P00BL4 */
         pr_default.execute(2, new Object[] {AV35VouAno, AV12Mes, AV25CueCod, AV21CosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00BL4_A126TASICod[0];
            A129VouNum = P00BL4_A129VouNum[0];
            A2077VouSts = P00BL4_A2077VouSts[0];
            A128VouMes = P00BL4_A128VouMes[0];
            A127VouAno = P00BL4_A127VouAno[0];
            A91CueCod = P00BL4_A91CueCod[0];
            A79COSCod = P00BL4_A79COSCod[0];
            n79COSCod = P00BL4_n79COSCod[0];
            A2055VouDHab = P00BL4_A2055VouDHab[0];
            A2051VouDDeb = P00BL4_A2051VouDDeb[0];
            A130VouDSec = P00BL4_A130VouDSec[0];
            A2077VouSts = P00BL4_A2077VouSts[0];
            AV51Total = (decimal)(AV51Total+(A2051VouDDeb-A2055VouDHab));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HBL0( bool bFoot ,
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
               getPrinter().GxDrawRect(0, Gx_line+145, 1104, Gx_line+171, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 318, Gx_line+25, 774, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 318, Gx_line+56, 774, Gx_line+90, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV68Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+9, 167, Gx_line+87) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1021, Gx_line+25, 1060, Gx_line+40, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 971, Gx_line+25, 1015, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1025, Gx_line+145, 1025, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(957, Gx_line+145, 957, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(823, Gx_line+145, 823, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(891, Gx_line+145, 891, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(623, Gx_line+145, 623, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(555, Gx_line+145, 555, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(690, Gx_line+145, 690, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(756, Gx_line+145, 756, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(354, Gx_line+145, 354, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(288, Gx_line+145, 288, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(422, Gx_line+145, 422, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(489, Gx_line+145, 489, Gx_line+171, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total", 1048, Gx_line+151, 1079, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Diciembre", 960, Gx_line+151, 1020, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Noviembre", 895, Gx_line+151, 960, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Octubre", 834, Gx_line+151, 882, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Enero", 239, Gx_line+151, 273, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Febrero", 302, Gx_line+151, 349, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Marzo", 373, Gx_line+151, 410, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Abril", 445, Gx_line+151, 473, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mayo", 510, Gx_line+151, 543, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Junio", 572, Gx_line+151, 604, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Julio", 645, Gx_line+151, 673, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Agosto", 702, Gx_line+151, 745, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Septiembre", 760, Gx_line+151, 830, Gx_line+165, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(221, Gx_line+145, 221, Gx_line+171, 1, 0, 0, 0, 0) ;
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
         AV68Logo_GXI = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A79COSCod = "";
         A91CueCod = "";
         P00BL2_A79COSCod = new string[] {""} ;
         P00BL2_n79COSCod = new bool[] {false} ;
         P00BL2_A127VouAno = new short[1] ;
         P00BL2_A91CueCod = new string[] {""} ;
         P00BL2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BL2_A761COSDsc = new string[] {""} ;
         P00BL2_A128VouMes = new short[1] ;
         P00BL2_A126TASICod = new int[1] ;
         P00BL2_A129VouNum = new string[] {""} ;
         P00BL2_A130VouDSec = new int[1] ;
         A135VouDFec = DateTime.MinValue;
         A761COSDsc = "";
         A129VouNum = "";
         AV21CosCod = "";
         AV36COSDsc = "";
         P00BL3_A133CueCodAux = new string[] {""} ;
         P00BL3_A91CueCod = new string[] {""} ;
         P00BL3_A127VouAno = new short[1] ;
         P00BL3_A859CueCos = new short[1] ;
         P00BL3_A79COSCod = new string[] {""} ;
         P00BL3_n79COSCod = new bool[] {false} ;
         P00BL3_A860CueDsc = new string[] {""} ;
         P00BL3_A128VouMes = new short[1] ;
         P00BL3_A126TASICod = new int[1] ;
         P00BL3_A129VouNum = new string[] {""} ;
         P00BL3_A130VouDSec = new int[1] ;
         A133CueCodAux = "";
         A860CueDsc = "";
         AV25CueCod = "";
         AV65Cuenta = "";
         P00BL4_A126TASICod = new int[1] ;
         P00BL4_A129VouNum = new string[] {""} ;
         P00BL4_A2077VouSts = new short[1] ;
         P00BL4_A128VouMes = new short[1] ;
         P00BL4_A127VouAno = new short[1] ;
         P00BL4_A91CueCod = new string[] {""} ;
         P00BL4_A79COSCod = new string[] {""} ;
         P00BL4_n79COSCod = new bool[] {false} ;
         P00BL4_A2055VouDHab = new decimal[1] ;
         P00BL4_A2051VouDDeb = new decimal[1] ;
         P00BL4_A130VouDSec = new int[1] ;
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_resumenanualcentrocostospdf__default(),
            new Object[][] {
                new Object[] {
               P00BL2_A79COSCod, P00BL2_n79COSCod, P00BL2_A127VouAno, P00BL2_A91CueCod, P00BL2_A135VouDFec, P00BL2_A761COSDsc, P00BL2_A128VouMes, P00BL2_A126TASICod, P00BL2_A129VouNum, P00BL2_A130VouDSec
               }
               , new Object[] {
               P00BL3_A133CueCodAux, P00BL3_A91CueCod, P00BL3_A127VouAno, P00BL3_A859CueCos, P00BL3_A79COSCod, P00BL3_n79COSCod, P00BL3_A860CueDsc, P00BL3_A128VouMes, P00BL3_A126TASICod, P00BL3_A129VouNum,
               P00BL3_A130VouDSec
               }
               , new Object[] {
               P00BL4_A126TASICod, P00BL4_A129VouNum, P00BL4_A2077VouSts, P00BL4_A128VouMes, P00BL4_A127VouAno, P00BL4_A91CueCod, P00BL4_A79COSCod, P00BL4_n79COSCod, P00BL4_A2055VouDHab, P00BL4_A2051VouDDeb,
               P00BL4_A130VouDSec
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
      private short A127VouAno ;
      private short A128VouMes ;
      private short A859CueCos ;
      private short AV12Mes ;
      private short A2077VouSts ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int Gx_OldLine ;
      private decimal AV52TEnero ;
      private decimal AV53TFebrero ;
      private decimal AV54TMarzo ;
      private decimal AV55TAbril ;
      private decimal AV56TMayo ;
      private decimal AV57TJunio ;
      private decimal AV58TJulio ;
      private decimal AV59TAgosto ;
      private decimal AV60TSeptiembre ;
      private decimal AV61TOctubre ;
      private decimal AV62TNoviembre ;
      private decimal AV63TDiciembre ;
      private decimal AV64TTotal ;
      private decimal AV37nEnero ;
      private decimal AV51Total ;
      private decimal AV38nFebrero ;
      private decimal AV39nMarzo ;
      private decimal AV40nAbril ;
      private decimal AV41nMayo ;
      private decimal AV42nJunio ;
      private decimal AV43nJulio ;
      private decimal AV44nAgosto ;
      private decimal AV45nSeptiembre ;
      private decimal AV46nOctubre ;
      private decimal AV47nNoviembre ;
      private decimal AV48nDiciembre ;
      private decimal AV49nTotal ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV19CueCod1 ;
      private string AV20CueCod2 ;
      private string AV50nCosCod ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV31EmpRUC ;
      private string AV32Ruta ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A91CueCod ;
      private string A761COSDsc ;
      private string A129VouNum ;
      private string AV21CosCod ;
      private string AV36COSDsc ;
      private string A133CueCodAux ;
      private string A860CueDsc ;
      private string AV25CueCod ;
      private string AV65Cuenta ;
      private string sImgUrl ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBL3 ;
      private bool n79COSCod ;
      private bool returnInSub ;
      private bool BRKBL5 ;
      private string AV68Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_VouAno ;
      private string aP1_CueCod1 ;
      private string aP2_CueCod2 ;
      private string aP3_nCosCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00BL2_A79COSCod ;
      private bool[] P00BL2_n79COSCod ;
      private short[] P00BL2_A127VouAno ;
      private string[] P00BL2_A91CueCod ;
      private DateTime[] P00BL2_A135VouDFec ;
      private string[] P00BL2_A761COSDsc ;
      private short[] P00BL2_A128VouMes ;
      private int[] P00BL2_A126TASICod ;
      private string[] P00BL2_A129VouNum ;
      private int[] P00BL2_A130VouDSec ;
      private string[] P00BL3_A133CueCodAux ;
      private string[] P00BL3_A91CueCod ;
      private short[] P00BL3_A127VouAno ;
      private short[] P00BL3_A859CueCos ;
      private string[] P00BL3_A79COSCod ;
      private bool[] P00BL3_n79COSCod ;
      private string[] P00BL3_A860CueDsc ;
      private short[] P00BL3_A128VouMes ;
      private int[] P00BL3_A126TASICod ;
      private string[] P00BL3_A129VouNum ;
      private int[] P00BL3_A130VouDSec ;
      private int[] P00BL4_A126TASICod ;
      private string[] P00BL4_A129VouNum ;
      private short[] P00BL4_A2077VouSts ;
      private short[] P00BL4_A128VouMes ;
      private short[] P00BL4_A127VouAno ;
      private string[] P00BL4_A91CueCod ;
      private string[] P00BL4_A79COSCod ;
      private bool[] P00BL4_n79COSCod ;
      private decimal[] P00BL4_A2055VouDHab ;
      private decimal[] P00BL4_A2051VouDDeb ;
      private int[] P00BL4_A130VouDSec ;
   }

   public class r_resumenanualcentrocostospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BL2( IGxContext context ,
                                             string AV50nCosCod ,
                                             string AV19CueCod1 ,
                                             string AV20CueCod2 ,
                                             string A79COSCod ,
                                             string A91CueCod ,
                                             short A127VouAno ,
                                             short AV35VouAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[COSCod], T1.[VouAno], T1.[CueCod], T1.[VouDFec], T2.[COSDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[COSCod])";
         AddWhere(sWhereString, "(Not (T1.[COSCod] = ''))");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV35VouAno)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50nCosCod)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV50nCosCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV19CueCod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV20CueCod2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[COSCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00BL3( IGxContext context ,
                                             string AV19CueCod1 ,
                                             string AV20CueCod2 ,
                                             string A91CueCod ,
                                             string A79COSCod ,
                                             string AV21CosCod ,
                                             short A859CueCos ,
                                             short A127VouAno ,
                                             short AV35VouAno )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCodAux], T1.[CueCod], T1.[VouAno], T2.[CueCos], T1.[COSCod], T2.[CueDsc], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[COSCod] = @AV21CosCod)");
         AddWhere(sWhereString, "(T2.[CueCos] = 1)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV35VouAno)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV19CueCod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV20CueCod2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux]";
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
                     return conditional_P00BL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_P00BL3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
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
          Object[] prmP00BL4;
          prmP00BL4 = new Object[] {
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV21CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BL2;
          prmP00BL2 = new Object[] {
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV50nCosCod",GXType.NChar,10,0) ,
          new ParDef("@AV19CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV20CueCod2",GXType.Char,15,0)
          };
          Object[] prmP00BL3;
          prmP00BL3 = new Object[] {
          new ParDef("@AV21CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV35VouAno",GXType.Int16,4,0) ,
          new ParDef("@AV19CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV20CueCod2",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BL4", "SELECT T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[VouMes], T1.[VouAno], T1.[CueCod], T1.[COSCod], T1.[VouDHab], T1.[VouDDeb], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum]) WHERE (T1.[VouAno] = @AV35VouAno and T1.[VouMes] = @AV12Mes and T1.[CueCod] = @AV25CueCod) AND (T1.[COSCod] = @AV21CosCod) AND (T2.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BL4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                ((int[]) buf[10])[0] = rslt.getInt(10);
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
       }
    }

 }

}
