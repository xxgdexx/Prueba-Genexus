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
   public class r_resumenchequesdiferidospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_resumenchequesdiferidospdf.aspx")), "compras.r_resumenchequesdiferidospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_resumenchequesdiferidospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipPCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV104TipPCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV105PrvCod = GetPar( "PrvCod");
                  AV14MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV10FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV79Flag = (short)(NumberUtil.Val( GetPar( "Flag"), "."));
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

      public r_resumenchequesdiferidospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenchequesdiferidospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipPCod ,
                           ref string aP1_PrvCod ,
                           ref int aP2_MonCod ,
                           ref DateTime aP3_FDesde ,
                           ref short aP4_Flag )
      {
         this.AV104TipPCod = aP0_TipPCod;
         this.AV105PrvCod = aP1_PrvCod;
         this.AV14MonCod = aP2_MonCod;
         this.AV10FDesde = aP3_FDesde;
         this.AV79Flag = aP4_Flag;
         initialize();
         executePrivate();
         aP0_TipPCod=this.AV104TipPCod;
         aP1_PrvCod=this.AV105PrvCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV10FDesde;
         aP4_Flag=this.AV79Flag;
      }

      public short executeUdp( ref int aP0_TipPCod ,
                               ref string aP1_PrvCod ,
                               ref int aP2_MonCod ,
                               ref DateTime aP3_FDesde )
      {
         execute(ref aP0_TipPCod, ref aP1_PrvCod, ref aP2_MonCod, ref aP3_FDesde, ref aP4_Flag);
         return AV79Flag ;
      }

      public void executeSubmit( ref int aP0_TipPCod ,
                                 ref string aP1_PrvCod ,
                                 ref int aP2_MonCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref short aP4_Flag )
      {
         r_resumenchequesdiferidospdf objr_resumenchequesdiferidospdf;
         objr_resumenchequesdiferidospdf = new r_resumenchequesdiferidospdf();
         objr_resumenchequesdiferidospdf.AV104TipPCod = aP0_TipPCod;
         objr_resumenchequesdiferidospdf.AV105PrvCod = aP1_PrvCod;
         objr_resumenchequesdiferidospdf.AV14MonCod = aP2_MonCod;
         objr_resumenchequesdiferidospdf.AV10FDesde = aP3_FDesde;
         objr_resumenchequesdiferidospdf.AV79Flag = aP4_Flag;
         objr_resumenchequesdiferidospdf.context.SetSubmitInitialConfig(context);
         objr_resumenchequesdiferidospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenchequesdiferidospdf);
         aP0_TipPCod=this.AV104TipPCod;
         aP1_PrvCod=this.AV105PrvCod;
         aP2_MonCod=this.AV14MonCod;
         aP3_FDesde=this.AV10FDesde;
         aP4_Flag=this.AV79Flag;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenchequesdiferidospdf)stateInfo).executePrivate();
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
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 2, 1, 12240, 15840, 0, 1, 1, 0, 1, 1) )
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
            AV19Empresa = AV23Session.Get("Empresa");
            AV20EmpDir = AV23Session.Get("EmpDir");
            AV21EmpRUC = AV23Session.Get("EmpRUC");
            AV22Ruta = AV23Session.Get("RUTA") + "/Logo.jpg";
            AV24Logo = AV22Ruta;
            AV111Logo_GXI = GXDbFile.PathToUrl( AV22Ruta);
            AV31Filtro1 = "(Todos)";
            /* Using cursor P00AM2 */
            pr_default.execute(0, new Object[] {AV105PrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P00AM2_A244PrvCod[0];
               A247PrvDsc = P00AM2_A247PrvDsc[0];
               AV31Filtro1 = StringUtil.Trim( A247PrvDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV102Filtro2 = "(Todos)";
            /* Using cursor P00AM3 */
            pr_default.execute(1, new Object[] {AV14MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00AM3_A180MonCod[0];
               A1234MonDsc = P00AM3_A1234MonDsc[0];
               AV102Filtro2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            if ( AV79Flag == 1 )
            {
               /* Execute user subroutine: 'SEMANAS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'MESES' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            HAM0( false, 51) ;
            getPrinter().GxDrawLine(435, Gx_line+11, 1083, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 356, Gx_line+23, 428, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 408, Gx_line+23, 498, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72TImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 489, Gx_line+23, 579, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 561, Gx_line+23, 651, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74TImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 651, Gx_line+23, 741, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 734, Gx_line+23, 824, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 814, Gx_line+23, 904, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77TImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 900, Gx_line+23, 990, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 986, Gx_line+23, 1076, Gx_line+36, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAM0( true, 0) ;
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
         /* 'SEMANAS' Routine */
         returnInSub = false;
         AV71TImp1 = 0.00m;
         AV72TImp2 = 0.00m;
         AV73TImp3 = 0.00m;
         AV74TImp4 = 0.00m;
         AV75TImp5 = 0.00m;
         AV76TImp6 = 0.00m;
         AV77TImp7 = 0.00m;
         AV78TTotal = 0.00m;
         AV55I = 0;
         AV53Fecha1 = AV10FDesde;
         AV54Fecha11 = AV10FDesde;
         if ( DateTimeUtil.Dow( AV10FDesde) == 2 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(6)));
         }
         if ( DateTimeUtil.Dow( AV10FDesde) == 3 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(5)));
         }
         if ( DateTimeUtil.Dow( AV10FDesde) == 4 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(4)));
         }
         if ( DateTimeUtil.Dow( AV10FDesde) == 5 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(3)));
         }
         if ( DateTimeUtil.Dow( AV10FDesde) == 6 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(2)));
         }
         if ( DateTimeUtil.Dow( AV10FDesde) == 7 )
         {
            AV54Fecha11 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(1)));
         }
         AV57Fecha2 = DateTimeUtil.DAdd(AV54Fecha11,+((int)(1)));
         AV56Fecha22 = DateTimeUtil.DAdd(AV57Fecha2,+((int)(6)));
         AV58Fecha3 = DateTimeUtil.DAdd(AV56Fecha22,+((int)(1)));
         AV59Fecha33 = DateTimeUtil.DAdd(AV56Fecha22,+((int)(7)));
         AV60Fecha4 = DateTimeUtil.DAdd(AV59Fecha33,+((int)(1)));
         AV61Fecha44 = DateTimeUtil.DAdd(AV59Fecha33,+((int)(7)));
         AV62Fecha5 = DateTimeUtil.DAdd(AV61Fecha44,+((int)(1)));
         AV63Fecha55 = DateTimeUtil.DAdd(AV61Fecha44,+((int)(7)));
         AV64Fecha6 = DateTimeUtil.DAdd(AV63Fecha55,+((int)(1)));
         AV65Fecha66 = DateTimeUtil.DAdd(AV63Fecha55,+((int)(7)));
         AV66Fecha7 = DateTimeUtil.DAdd(AV65Fecha66,+((int)(1)));
         AV67Fecha77 = DateTimeUtil.DAdd(AV65Fecha66,+((int)(7)));
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV105PrvCod ,
                                              AV104TipPCod ,
                                              AV14MonCod ,
                                              A262CPPrvCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A817CPFVcto ,
                                              AV10FDesde ,
                                              AV67Fecha77 ,
                                              A260CPTipCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AM4 */
         pr_default.execute(2, new Object[] {AV10FDesde, AV67Fecha77, AV105PrvCod, AV104TipPCod, AV14MonCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A260CPTipCod = P00AM4_A260CPTipCod[0];
            A817CPFVcto = P00AM4_A817CPFVcto[0];
            A263CPMonCod = P00AM4_A263CPMonCod[0];
            A298TprvCod = P00AM4_A298TprvCod[0];
            n298TprvCod = P00AM4_n298TprvCod[0];
            A262CPPrvCod = P00AM4_A262CPPrvCod[0];
            A264CPFech = P00AM4_A264CPFech[0];
            A831CPPrvDsc = P00AM4_A831CPPrvDsc[0];
            A261CPComCod = P00AM4_A261CPComCod[0];
            A818CPImpPago = P00AM4_A818CPImpPago[0];
            A820CPImpTotal = P00AM4_A820CPImpTotal[0];
            A511TipSigno = P00AM4_A511TipSigno[0];
            n511TipSigno = P00AM4_n511TipSigno[0];
            A511TipSigno = P00AM4_A511TipSigno[0];
            n511TipSigno = P00AM4_n511TipSigno[0];
            A298TprvCod = P00AM4_A298TprvCod[0];
            n298TprvCod = P00AM4_n298TprvCod[0];
            A831CPPrvDsc = P00AM4_A831CPPrvDsc[0];
            A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
            A821CPImpSaldoSig = (decimal)(A819CPImpSaldo*A511TipSigno);
            AV106CPTipCod = A260CPTipCod;
            AV107CPComCod = A261CPComCod;
            AV108CPFVcto = A817CPFVcto;
            AV52Saldo = A821CPImpSaldoSig;
            AV45Imp1 = 0.00m;
            AV46Imp2 = 0.00m;
            AV47Imp3 = 0.00m;
            AV48Imp4 = 0.00m;
            AV49Imp5 = 0.00m;
            AV50Imp6 = 0.00m;
            AV69Imp7 = 0.00m;
            AV70Total = 0.00m;
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV53Fecha1 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV54Fecha11 ) ) )
            {
               AV45Imp1 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV57Fecha2 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV56Fecha22 ) ) )
            {
               AV46Imp2 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV58Fecha3 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV59Fecha33 ) ) )
            {
               AV47Imp3 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV60Fecha4 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV61Fecha44 ) ) )
            {
               AV48Imp4 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV62Fecha5 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV63Fecha55 ) ) )
            {
               AV49Imp5 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV64Fecha6 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV65Fecha66 ) ) )
            {
               AV50Imp6 = AV52Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV108CPFVcto ) >= DateTimeUtil.ResetTime ( AV66Fecha7 ) ) && ( DateTimeUtil.ResetTime ( AV108CPFVcto ) <= DateTimeUtil.ResetTime ( AV67Fecha77 ) ) )
            {
               AV69Imp7 = AV52Saldo;
            }
            AV70Total = (decimal)(AV45Imp1+AV46Imp2+AV47Imp3+AV48Imp4+AV49Imp5+AV50Imp6+AV69Imp7);
            if ( ( AV52Saldo > Convert.ToDecimal( 0 )) )
            {
               if ( (0==AV30VenCod) )
               {
                  HAM0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107CPComCod, "")), 1, Gx_line+4, 80, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), 69, Gx_line+4, 312, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 316, Gx_line+4, 355, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV108CPFVcto, "99/99/99"), 370, Gx_line+4, 409, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  AV71TImp1 = (decimal)(AV71TImp1+AV45Imp1);
                  AV72TImp2 = (decimal)(AV72TImp2+AV46Imp2);
                  AV73TImp3 = (decimal)(AV73TImp3+AV47Imp3);
                  AV74TImp4 = (decimal)(AV74TImp4+AV48Imp4);
                  AV75TImp5 = (decimal)(AV75TImp5+AV49Imp5);
                  AV76TImp6 = (decimal)(AV76TImp6+AV50Imp6);
                  AV77TImp7 = (decimal)(AV77TImp7+AV69Imp7);
                  AV78TTotal = (decimal)(AV78TTotal+AV70Total);
               }
               else
               {
                  if ( AV30VenCod == AV103Vendedor )
                  {
                     HAM0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107CPComCod, "")), 1, Gx_line+4, 80, Gx_line+18, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), 69, Gx_line+4, 312, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 316, Gx_line+4, 355, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV108CPFVcto, "99/99/99"), 370, Gx_line+4, 409, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                     AV71TImp1 = (decimal)(AV71TImp1+AV45Imp1);
                     AV72TImp2 = (decimal)(AV72TImp2+AV46Imp2);
                     AV73TImp3 = (decimal)(AV73TImp3+AV47Imp3);
                     AV74TImp4 = (decimal)(AV74TImp4+AV48Imp4);
                     AV75TImp5 = (decimal)(AV75TImp5+AV49Imp5);
                     AV76TImp6 = (decimal)(AV76TImp6+AV50Imp6);
                     AV77TImp7 = (decimal)(AV77TImp7+AV69Imp7);
                     AV78TTotal = (decimal)(AV78TTotal+AV70Total);
                  }
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'MESES' Routine */
         returnInSub = false;
         AV71TImp1 = 0.00m;
         AV72TImp2 = 0.00m;
         AV73TImp3 = 0.00m;
         AV74TImp4 = 0.00m;
         AV75TImp5 = 0.00m;
         AV76TImp6 = 0.00m;
         AV77TImp7 = 0.00m;
         AV78TTotal = 0.00m;
         AV55I = 0;
         AV80Ano1 = (short)(DateTimeUtil.Year( AV10FDesde));
         AV81Mes1 = (short)(DateTimeUtil.Month( AV10FDesde));
         GXt_char1 = AV82Periodo1;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV81Mes1, out  GXt_char1) ;
         AV82Periodo1 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV80Ano1), 10, 0));
         if ( AV81Mes1 == 12 )
         {
            AV83Ano2 = (short)(AV80Ano1+1);
            AV84Mes2 = 1;
         }
         else
         {
            AV83Ano2 = AV80Ano1;
            AV84Mes2 = (short)(AV81Mes1+1);
         }
         if ( AV84Mes2 == 12 )
         {
            AV85Ano3 = (short)(AV83Ano2+1);
            AV86Mes3 = 1;
         }
         else
         {
            AV85Ano3 = AV83Ano2;
            AV86Mes3 = (short)(AV84Mes2+1);
         }
         if ( AV86Mes3 == 12 )
         {
            AV87Ano4 = (short)(AV85Ano3+1);
            AV88Mes4 = 1;
         }
         else
         {
            AV87Ano4 = AV85Ano3;
            AV88Mes4 = (short)(AV86Mes3+1);
         }
         if ( AV88Mes4 == 12 )
         {
            AV89Ano5 = (short)(AV87Ano4+1);
            AV90Mes5 = 1;
         }
         else
         {
            AV89Ano5 = AV87Ano4;
            AV90Mes5 = (short)(AV88Mes4+1);
         }
         if ( AV90Mes5 == 12 )
         {
            AV91Ano6 = (short)(AV89Ano5+1);
            AV92Mes6 = 1;
         }
         else
         {
            AV91Ano6 = AV89Ano5;
            AV92Mes6 = (short)(AV90Mes5+1);
         }
         if ( AV92Mes6 == 12 )
         {
            AV93Ano7 = (short)(AV91Ano6+1);
            AV94Mes7 = 1;
         }
         else
         {
            AV93Ano7 = AV91Ano6;
            AV94Mes7 = (short)(AV92Mes6+1);
         }
         GXt_char1 = AV95Periodo2;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV84Mes2, out  GXt_char1) ;
         AV95Periodo2 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV83Ano2), 10, 0));
         GXt_char1 = AV96Periodo3;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV86Mes3, out  GXt_char1) ;
         AV96Periodo3 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV85Ano3), 10, 0));
         GXt_char1 = AV97Periodo4;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV88Mes4, out  GXt_char1) ;
         AV97Periodo4 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV87Ano4), 10, 0));
         GXt_char1 = AV98Periodo5;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV90Mes5, out  GXt_char1) ;
         AV98Periodo5 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV89Ano5), 10, 0));
         GXt_char1 = AV99Periodo6;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV92Mes6, out  GXt_char1) ;
         AV99Periodo6 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV91Ano6), 10, 0));
         GXt_char1 = AV100Periodo7;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV94Mes7, out  GXt_char1) ;
         AV100Periodo7 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV93Ano7), 10, 0));
         AV101FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV81Mes1), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV80Ano1), 10, 0));
         AV10FDesde = context.localUtil.CToD( AV101FechaC, 2);
         AV101FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV94Mes7), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV93Ano7), 10, 0));
         AV53Fecha1 = context.localUtil.CToD( AV101FechaC, 2);
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV105PrvCod ,
                                              AV104TipPCod ,
                                              AV14MonCod ,
                                              A262CPPrvCod ,
                                              A298TprvCod ,
                                              A263CPMonCod ,
                                              A817CPFVcto ,
                                              AV10FDesde ,
                                              AV11FHasta ,
                                              A260CPTipCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AM5 */
         pr_default.execute(3, new Object[] {AV10FDesde, AV11FHasta, AV105PrvCod, AV104TipPCod, AV14MonCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A260CPTipCod = P00AM5_A260CPTipCod[0];
            A817CPFVcto = P00AM5_A817CPFVcto[0];
            A263CPMonCod = P00AM5_A263CPMonCod[0];
            A298TprvCod = P00AM5_A298TprvCod[0];
            n298TprvCod = P00AM5_n298TprvCod[0];
            A262CPPrvCod = P00AM5_A262CPPrvCod[0];
            A264CPFech = P00AM5_A264CPFech[0];
            A831CPPrvDsc = P00AM5_A831CPPrvDsc[0];
            A261CPComCod = P00AM5_A261CPComCod[0];
            A818CPImpPago = P00AM5_A818CPImpPago[0];
            A820CPImpTotal = P00AM5_A820CPImpTotal[0];
            A511TipSigno = P00AM5_A511TipSigno[0];
            n511TipSigno = P00AM5_n511TipSigno[0];
            A511TipSigno = P00AM5_A511TipSigno[0];
            n511TipSigno = P00AM5_n511TipSigno[0];
            A298TprvCod = P00AM5_A298TprvCod[0];
            n298TprvCod = P00AM5_n298TprvCod[0];
            A831CPPrvDsc = P00AM5_A831CPPrvDsc[0];
            A819CPImpSaldo = (decimal)(A820CPImpTotal-A818CPImpPago);
            A821CPImpSaldoSig = (decimal)(A819CPImpSaldo*A511TipSigno);
            AV106CPTipCod = A260CPTipCod;
            AV107CPComCod = A261CPComCod;
            AV108CPFVcto = A817CPFVcto;
            AV52Saldo = A821CPImpSaldoSig;
            AV45Imp1 = 0.00m;
            AV46Imp2 = 0.00m;
            AV47Imp3 = 0.00m;
            AV48Imp4 = 0.00m;
            AV49Imp5 = 0.00m;
            AV50Imp6 = 0.00m;
            AV69Imp7 = 0.00m;
            AV70Total = 0.00m;
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV80Ano1 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV81Mes1 ) )
            {
               AV45Imp1 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV83Ano2 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV84Mes2 ) )
            {
               AV46Imp2 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV85Ano3 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV86Mes3 ) )
            {
               AV47Imp3 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV87Ano4 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV88Mes4 ) )
            {
               AV48Imp4 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV89Ano5 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV90Mes5 ) )
            {
               AV49Imp5 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV91Ano6 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV92Mes6 ) )
            {
               AV50Imp6 = AV52Saldo;
            }
            if ( ( DateTimeUtil.Year( AV108CPFVcto) == AV93Ano7 ) && ( DateTimeUtil.Month( AV108CPFVcto) == AV94Mes7 ) )
            {
               AV69Imp7 = AV52Saldo;
            }
            AV70Total = (decimal)(AV45Imp1+AV46Imp2+AV47Imp3+AV48Imp4+AV49Imp5+AV50Imp6+AV69Imp7);
            if ( ( AV52Saldo > Convert.ToDecimal( 0 )) )
            {
               if ( (0==AV30VenCod) )
               {
                  HAM0( false, 20) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107CPComCod, "")), 1, Gx_line+4, 80, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), 69, Gx_line+4, 312, Gx_line+18, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 316, Gx_line+4, 355, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV108CPFVcto, "99/99/99"), 370, Gx_line+4, 409, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  AV71TImp1 = (decimal)(AV71TImp1+AV45Imp1);
                  AV72TImp2 = (decimal)(AV72TImp2+AV46Imp2);
                  AV73TImp3 = (decimal)(AV73TImp3+AV47Imp3);
                  AV74TImp4 = (decimal)(AV74TImp4+AV48Imp4);
                  AV75TImp5 = (decimal)(AV75TImp5+AV49Imp5);
                  AV76TImp6 = (decimal)(AV76TImp6+AV50Imp6);
                  AV77TImp7 = (decimal)(AV77TImp7+AV69Imp7);
                  AV78TTotal = (decimal)(AV78TTotal+AV70Total);
               }
               else
               {
                  if ( AV30VenCod == AV103Vendedor )
                  {
                     HAM0( false, 20) ;
                     getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107CPComCod, "")), 1, Gx_line+4, 80, Gx_line+18, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A831CPPrvDsc, "")), 69, Gx_line+4, 312, Gx_line+18, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( A264CPFech, "99/99/99"), 316, Gx_line+4, 355, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV108CPFVcto, "99/99/99"), 370, Gx_line+4, 409, Gx_line+17, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                     AV71TImp1 = (decimal)(AV71TImp1+AV45Imp1);
                     AV72TImp2 = (decimal)(AV72TImp2+AV46Imp2);
                     AV73TImp3 = (decimal)(AV73TImp3+AV47Imp3);
                     AV74TImp4 = (decimal)(AV74TImp4+AV48Imp4);
                     AV75TImp5 = (decimal)(AV75TImp5+AV49Imp5);
                     AV76TImp6 = (decimal)(AV76TImp6+AV50Imp6);
                     AV77TImp7 = (decimal)(AV77TImp7+AV69Imp7);
                     AV78TTotal = (decimal)(AV78TTotal+AV70Total);
                  }
               }
            }
            AV71TImp1 = (decimal)(AV71TImp1+AV45Imp1);
            AV72TImp2 = (decimal)(AV72TImp2+AV46Imp2);
            AV73TImp3 = (decimal)(AV73TImp3+AV47Imp3);
            AV74TImp4 = (decimal)(AV74TImp4+AV48Imp4);
            AV75TImp5 = (decimal)(AV75TImp5+AV49Imp5);
            AV76TImp6 = (decimal)(AV76TImp6+AV50Imp6);
            AV77TImp7 = (decimal)(AV77TImp7+AV69Imp7);
            AV78TTotal = (decimal)(AV78TTotal+AV70Total);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HAM0( bool bFoot ,
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
               if ( AV79Flag == 1 )
               {
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Vencimiento de Cheques por Periodos", 376, Gx_line+32, 698, Gx_line+52, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Página:", 949, Gx_line+51, 993, Gx_line+65, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Hora:", 949, Gx_line+32, 981, Gx_line+46, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha:", 949, Gx_line+15, 988, Gx_line+29, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1000, Gx_line+15, 1047, Gx_line+30, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 982, Gx_line+32, 1046, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1008, Gx_line+51, 1047, Gx_line+66, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+106, 1095, Gx_line+136, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("N° Cheque", 9, Gx_line+117, 64, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Proveedor", 110, Gx_line+117, 166, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Emisión", 314, Gx_line+117, 364, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Proveedor :", 365, Gx_line+60, 457, Gx_line+79, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Filtro1, "")), 460, Gx_line+59, 683, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 10, Gx_line+69, 350, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EmpRUC, "")), 10, Gx_line+86, 148, Gx_line+104, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24Logo)) ? AV111Logo_GXI : AV24Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 150, Gx_line+69) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("F.Vcto", 374, Gx_line+117, 407, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 1045, Gx_line+117, 1073, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV53Fecha1, "99/99/99"), 457, Gx_line+107, 512, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV54Fecha11, "99/99/99"), 457, Gx_line+124, 512, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV57Fecha2, "99/99/99"), 535, Gx_line+107, 590, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV56Fecha22, "99/99/99"), 535, Gx_line+124, 590, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV58Fecha3, "99/99/99"), 613, Gx_line+107, 668, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV59Fecha33, "99/99/99"), 613, Gx_line+124, 668, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV60Fecha4, "99/99/99"), 701, Gx_line+107, 756, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV61Fecha44, "99/99/99"), 701, Gx_line+124, 756, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV63Fecha55, "99/99/99"), 779, Gx_line+124, 834, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV62Fecha5, "99/99/99"), 779, Gx_line+109, 834, Gx_line+122, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV64Fecha6, "99/99/99"), 856, Gx_line+107, 911, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV65Fecha66, "99/99/99"), 856, Gx_line+124, 911, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV66Fecha7, "99/99/99"), 946, Gx_line+107, 1001, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV67Fecha77, "99/99/99"), 946, Gx_line+124, 1001, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda :", 365, Gx_line+80, 436, Gx_line+99, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102Filtro2, "")), 460, Gx_line+79, 683, Gx_line+99, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+137);
               }
               else
               {
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Vencimiento de Cheques por Periodos", 376, Gx_line+33, 698, Gx_line+53, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Página:", 949, Gx_line+51, 993, Gx_line+65, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Hora:", 949, Gx_line+32, 981, Gx_line+46, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha:", 949, Gx_line+15, 988, Gx_line+29, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1000, Gx_line+15, 1047, Gx_line+30, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 982, Gx_line+32, 1046, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1008, Gx_line+51, 1047, Gx_line+66, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+106, 1095, Gx_line+136, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("N° Cheque", 9, Gx_line+116, 64, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Proveedor", 110, Gx_line+116, 166, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Emisión", 314, Gx_line+116, 364, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Proveedor :", 365, Gx_line+60, 457, Gx_line+79, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Filtro1, "")), 460, Gx_line+59, 683, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Empresa, "")), 10, Gx_line+69, 350, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21EmpRUC, "")), 10, Gx_line+86, 148, Gx_line+104, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV24Logo)) ? AV111Logo_GXI : AV24Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 150, Gx_line+69) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("F.Vcto", 374, Gx_line+116, 407, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 1045, Gx_line+116, 1073, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82Periodo1, "")), 457, Gx_line+116, 510, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Periodo2, "")), 535, Gx_line+116, 588, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96Periodo3, "")), 613, Gx_line+116, 666, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97Periodo4, "")), 701, Gx_line+116, 754, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98Periodo5, "")), 779, Gx_line+116, 832, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99Periodo6, "")), 856, Gx_line+116, 909, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100Periodo7, "")), 946, Gx_line+116, 999, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda :", 364, Gx_line+80, 435, Gx_line+99, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102Filtro2, "")), 459, Gx_line+79, 682, Gx_line+99, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+136);
               }
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
         AV19Empresa = "";
         AV23Session = context.GetSession();
         AV20EmpDir = "";
         AV21EmpRUC = "";
         AV22Ruta = "";
         AV24Logo = "";
         AV111Logo_GXI = "";
         AV31Filtro1 = "";
         scmdbuf = "";
         P00AM2_A244PrvCod = new string[] {""} ;
         P00AM2_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         AV102Filtro2 = "";
         P00AM3_A180MonCod = new int[1] ;
         P00AM3_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV53Fecha1 = DateTime.MinValue;
         AV54Fecha11 = DateTime.MinValue;
         AV57Fecha2 = DateTime.MinValue;
         AV56Fecha22 = DateTime.MinValue;
         AV58Fecha3 = DateTime.MinValue;
         AV59Fecha33 = DateTime.MinValue;
         AV60Fecha4 = DateTime.MinValue;
         AV61Fecha44 = DateTime.MinValue;
         AV62Fecha5 = DateTime.MinValue;
         AV63Fecha55 = DateTime.MinValue;
         AV64Fecha6 = DateTime.MinValue;
         AV65Fecha66 = DateTime.MinValue;
         AV66Fecha7 = DateTime.MinValue;
         AV67Fecha77 = DateTime.MinValue;
         A262CPPrvCod = "";
         A817CPFVcto = DateTime.MinValue;
         A260CPTipCod = "";
         P00AM4_A260CPTipCod = new string[] {""} ;
         P00AM4_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AM4_A263CPMonCod = new int[1] ;
         P00AM4_A298TprvCod = new int[1] ;
         P00AM4_n298TprvCod = new bool[] {false} ;
         P00AM4_A262CPPrvCod = new string[] {""} ;
         P00AM4_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P00AM4_A831CPPrvDsc = new string[] {""} ;
         P00AM4_A261CPComCod = new string[] {""} ;
         P00AM4_A818CPImpPago = new decimal[1] ;
         P00AM4_A820CPImpTotal = new decimal[1] ;
         P00AM4_A511TipSigno = new short[1] ;
         P00AM4_n511TipSigno = new bool[] {false} ;
         A264CPFech = DateTime.MinValue;
         A831CPPrvDsc = "";
         A261CPComCod = "";
         AV106CPTipCod = "";
         AV107CPComCod = "";
         AV108CPFVcto = DateTime.MinValue;
         AV82Periodo1 = "";
         AV95Periodo2 = "";
         AV96Periodo3 = "";
         AV97Periodo4 = "";
         AV98Periodo5 = "";
         AV99Periodo6 = "";
         AV100Periodo7 = "";
         GXt_char1 = "";
         AV101FechaC = "";
         AV11FHasta = DateTime.MinValue;
         P00AM5_A260CPTipCod = new string[] {""} ;
         P00AM5_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AM5_A263CPMonCod = new int[1] ;
         P00AM5_A298TprvCod = new int[1] ;
         P00AM5_n298TprvCod = new bool[] {false} ;
         P00AM5_A262CPPrvCod = new string[] {""} ;
         P00AM5_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P00AM5_A831CPPrvDsc = new string[] {""} ;
         P00AM5_A261CPComCod = new string[] {""} ;
         P00AM5_A818CPImpPago = new decimal[1] ;
         P00AM5_A820CPImpTotal = new decimal[1] ;
         P00AM5_A511TipSigno = new short[1] ;
         P00AM5_n511TipSigno = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV24Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenchequesdiferidospdf__default(),
            new Object[][] {
                new Object[] {
               P00AM2_A244PrvCod, P00AM2_A247PrvDsc
               }
               , new Object[] {
               P00AM3_A180MonCod, P00AM3_A1234MonDsc
               }
               , new Object[] {
               P00AM4_A260CPTipCod, P00AM4_A817CPFVcto, P00AM4_A263CPMonCod, P00AM4_A298TprvCod, P00AM4_n298TprvCod, P00AM4_A262CPPrvCod, P00AM4_A264CPFech, P00AM4_A831CPPrvDsc, P00AM4_A261CPComCod, P00AM4_A818CPImpPago,
               P00AM4_A820CPImpTotal, P00AM4_A511TipSigno, P00AM4_n511TipSigno
               }
               , new Object[] {
               P00AM5_A260CPTipCod, P00AM5_A817CPFVcto, P00AM5_A263CPMonCod, P00AM5_A298TprvCod, P00AM5_n298TprvCod, P00AM5_A262CPPrvCod, P00AM5_A264CPFech, P00AM5_A831CPPrvDsc, P00AM5_A261CPComCod, P00AM5_A818CPImpPago,
               P00AM5_A820CPImpTotal, P00AM5_A511TipSigno, P00AM5_n511TipSigno
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
      private short AV79Flag ;
      private short A511TipSigno ;
      private short AV80Ano1 ;
      private short AV81Mes1 ;
      private short AV83Ano2 ;
      private short AV84Mes2 ;
      private short AV85Ano3 ;
      private short AV86Mes3 ;
      private short AV87Ano4 ;
      private short AV88Mes4 ;
      private short AV89Ano5 ;
      private short AV90Mes5 ;
      private short AV91Ano6 ;
      private short AV92Mes6 ;
      private short AV93Ano7 ;
      private short AV94Mes7 ;
      private int AV104TipPCod ;
      private int AV14MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A298TprvCod ;
      private int A263CPMonCod ;
      private int AV30VenCod ;
      private int AV103Vendedor ;
      private long AV55I ;
      private decimal AV71TImp1 ;
      private decimal AV72TImp2 ;
      private decimal AV73TImp3 ;
      private decimal AV74TImp4 ;
      private decimal AV75TImp5 ;
      private decimal AV76TImp6 ;
      private decimal AV77TImp7 ;
      private decimal AV78TTotal ;
      private decimal A818CPImpPago ;
      private decimal A820CPImpTotal ;
      private decimal A819CPImpSaldo ;
      private decimal A821CPImpSaldoSig ;
      private decimal AV52Saldo ;
      private decimal AV45Imp1 ;
      private decimal AV46Imp2 ;
      private decimal AV47Imp3 ;
      private decimal AV48Imp4 ;
      private decimal AV49Imp5 ;
      private decimal AV50Imp6 ;
      private decimal AV69Imp7 ;
      private decimal AV70Total ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV105PrvCod ;
      private string AV19Empresa ;
      private string AV20EmpDir ;
      private string AV21EmpRUC ;
      private string AV22Ruta ;
      private string AV31Filtro1 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string AV102Filtro2 ;
      private string A1234MonDsc ;
      private string A262CPPrvCod ;
      private string A260CPTipCod ;
      private string A831CPPrvDsc ;
      private string A261CPComCod ;
      private string AV106CPTipCod ;
      private string AV107CPComCod ;
      private string AV82Periodo1 ;
      private string AV95Periodo2 ;
      private string AV96Periodo3 ;
      private string AV97Periodo4 ;
      private string AV98Periodo5 ;
      private string AV99Periodo6 ;
      private string AV100Periodo7 ;
      private string GXt_char1 ;
      private string AV101FechaC ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV10FDesde ;
      private DateTime AV53Fecha1 ;
      private DateTime AV54Fecha11 ;
      private DateTime AV57Fecha2 ;
      private DateTime AV56Fecha22 ;
      private DateTime AV58Fecha3 ;
      private DateTime AV59Fecha33 ;
      private DateTime AV60Fecha4 ;
      private DateTime AV61Fecha44 ;
      private DateTime AV62Fecha5 ;
      private DateTime AV63Fecha55 ;
      private DateTime AV64Fecha6 ;
      private DateTime AV65Fecha66 ;
      private DateTime AV66Fecha7 ;
      private DateTime AV67Fecha77 ;
      private DateTime A817CPFVcto ;
      private DateTime A264CPFech ;
      private DateTime AV108CPFVcto ;
      private DateTime AV11FHasta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n298TprvCod ;
      private bool n511TipSigno ;
      private string AV111Logo_GXI ;
      private string AV24Logo ;
      private string Logo ;
      private IGxSession AV23Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipPCod ;
      private string aP1_PrvCod ;
      private int aP2_MonCod ;
      private DateTime aP3_FDesde ;
      private short aP4_Flag ;
      private IDataStoreProvider pr_default ;
      private string[] P00AM2_A244PrvCod ;
      private string[] P00AM2_A247PrvDsc ;
      private int[] P00AM3_A180MonCod ;
      private string[] P00AM3_A1234MonDsc ;
      private string[] P00AM4_A260CPTipCod ;
      private DateTime[] P00AM4_A817CPFVcto ;
      private int[] P00AM4_A263CPMonCod ;
      private int[] P00AM4_A298TprvCod ;
      private bool[] P00AM4_n298TprvCod ;
      private string[] P00AM4_A262CPPrvCod ;
      private DateTime[] P00AM4_A264CPFech ;
      private string[] P00AM4_A831CPPrvDsc ;
      private string[] P00AM4_A261CPComCod ;
      private decimal[] P00AM4_A818CPImpPago ;
      private decimal[] P00AM4_A820CPImpTotal ;
      private short[] P00AM4_A511TipSigno ;
      private bool[] P00AM4_n511TipSigno ;
      private string[] P00AM5_A260CPTipCod ;
      private DateTime[] P00AM5_A817CPFVcto ;
      private int[] P00AM5_A263CPMonCod ;
      private int[] P00AM5_A298TprvCod ;
      private bool[] P00AM5_n298TprvCod ;
      private string[] P00AM5_A262CPPrvCod ;
      private DateTime[] P00AM5_A264CPFech ;
      private string[] P00AM5_A831CPPrvDsc ;
      private string[] P00AM5_A261CPComCod ;
      private decimal[] P00AM5_A818CPImpPago ;
      private decimal[] P00AM5_A820CPImpTotal ;
      private short[] P00AM5_A511TipSigno ;
      private bool[] P00AM5_n511TipSigno ;
   }

   public class r_resumenchequesdiferidospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AM4( IGxContext context ,
                                             string AV105PrvCod ,
                                             int AV104TipPCod ,
                                             int AV14MonCod ,
                                             string A262CPPrvCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             DateTime A817CPFVcto ,
                                             DateTime AV10FDesde ,
                                             DateTime AV67Fecha77 ,
                                             string A260CPTipCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[5];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CPTipCod] AS CPTipCod, T1.[CPFVcto], T1.[CPMonCod], T3.[TprvCod], T1.[CPPrvCod] AS CPPrvCod, T1.[CPFech], T3.[PrvDsc] AS CPPrvDsc, T1.[CPComCod], T1.[CPImpPago], T1.[CPImpTotal], T2.[TipSigno] FROM (([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPTipCod] = 'CHQ')");
         AddWhere(sWhereString, "(T1.[CPFVcto] >= @AV10FDesde)");
         AddWhere(sWhereString, "(T1.[CPFVcto] <= @AV67Fecha77)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV105PrvCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV104TipPCod) )
         {
            AddWhere(sWhereString, "(T3.[TprvCod] = @AV104TipPCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AM5( IGxContext context ,
                                             string AV105PrvCod ,
                                             int AV104TipPCod ,
                                             int AV14MonCod ,
                                             string A262CPPrvCod ,
                                             int A298TprvCod ,
                                             int A263CPMonCod ,
                                             DateTime A817CPFVcto ,
                                             DateTime AV10FDesde ,
                                             DateTime AV11FHasta ,
                                             string A260CPTipCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[CPTipCod] AS CPTipCod, T1.[CPFVcto], T1.[CPMonCod], T3.[TprvCod], T1.[CPPrvCod] AS CPPrvCod, T1.[CPFech], T3.[PrvDsc] AS CPPrvDsc, T1.[CPComCod], T1.[CPImpPago], T1.[CPImpTotal], T2.[TipSigno] FROM (([CPCUENTAPAGAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CPTipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[CPPrvCod])";
         AddWhere(sWhereString, "(T1.[CPTipCod] = 'CHQ')");
         AddWhere(sWhereString, "(T1.[CPFVcto] >= @AV10FDesde)");
         AddWhere(sWhereString, "(T1.[CPFVcto] <= @AV11FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPPrvCod] = @AV105PrvCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV104TipPCod) )
         {
            AddWhere(sWhereString, "(T3.[TprvCod] = @AV104TipPCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV14MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CPMonCod] = @AV14MonCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPTipCod], T1.[CPComCod]";
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
               case 2 :
                     return conditional_P00AM4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] );
               case 3 :
                     return conditional_P00AM5(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP00AM2;
          prmP00AM2 = new Object[] {
          new ParDef("@AV105PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AM3;
          prmP00AM3 = new Object[] {
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AM4;
          prmP00AM4 = new Object[] {
          new ParDef("@AV10FDesde",GXType.Date,8,0) ,
          new ParDef("@AV67Fecha77",GXType.Date,8,0) ,
          new ParDef("@AV105PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV104TipPCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00AM5;
          prmP00AM5 = new Object[] {
          new ParDef("@AV10FDesde",GXType.Date,8,0) ,
          new ParDef("@AV11FHasta",GXType.Date,8,0) ,
          new ParDef("@AV105PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV104TipPCod",GXType.Int32,6,0) ,
          new ParDef("@AV14MonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AM2", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV105PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AM3", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AM4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AM5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AM5,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
