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
   public class rreporteantiguedadsaldos : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rreporteantiguedadsaldos.aspx")), "rreporteantiguedadsaldos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rreporteantiguedadsaldos.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "VenCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV129VenCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV110TipCod = GetPar( "TipCod");
                  AV131ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV109TipCCod = (int)(NumberUtil.Val( GetPar( "TipCCod"), "."));
                  AV24CliCod = GetPar( "CliCod");
                  AV87MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV54Flag = (short)(NumberUtil.Val( GetPar( "Flag"), "."));
                  AV55Flag2 = (short)(NumberUtil.Val( GetPar( "Flag2"), "."));
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

      public rreporteantiguedadsaldos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rreporteantiguedadsaldos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_VenCod ,
                           ref string aP1_TipCod ,
                           ref int aP2_ZonCod ,
                           ref int aP3_TipCCod ,
                           ref string aP4_CliCod ,
                           ref int aP5_MonCod ,
                           ref short aP6_Flag ,
                           ref short aP7_Flag2 )
      {
         this.AV129VenCod = aP0_VenCod;
         this.AV110TipCod = aP1_TipCod;
         this.AV131ZonCod = aP2_ZonCod;
         this.AV109TipCCod = aP3_TipCCod;
         this.AV24CliCod = aP4_CliCod;
         this.AV87MonCod = aP5_MonCod;
         this.AV54Flag = aP6_Flag;
         this.AV55Flag2 = aP7_Flag2;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV129VenCod;
         aP1_TipCod=this.AV110TipCod;
         aP2_ZonCod=this.AV131ZonCod;
         aP3_TipCCod=this.AV109TipCCod;
         aP4_CliCod=this.AV24CliCod;
         aP5_MonCod=this.AV87MonCod;
         aP6_Flag=this.AV54Flag;
         aP7_Flag2=this.AV55Flag2;
      }

      public short executeUdp( ref int aP0_VenCod ,
                               ref string aP1_TipCod ,
                               ref int aP2_ZonCod ,
                               ref int aP3_TipCCod ,
                               ref string aP4_CliCod ,
                               ref int aP5_MonCod ,
                               ref short aP6_Flag )
      {
         execute(ref aP0_VenCod, ref aP1_TipCod, ref aP2_ZonCod, ref aP3_TipCCod, ref aP4_CliCod, ref aP5_MonCod, ref aP6_Flag, ref aP7_Flag2);
         return AV55Flag2 ;
      }

      public void executeSubmit( ref int aP0_VenCod ,
                                 ref string aP1_TipCod ,
                                 ref int aP2_ZonCod ,
                                 ref int aP3_TipCCod ,
                                 ref string aP4_CliCod ,
                                 ref int aP5_MonCod ,
                                 ref short aP6_Flag ,
                                 ref short aP7_Flag2 )
      {
         rreporteantiguedadsaldos objrreporteantiguedadsaldos;
         objrreporteantiguedadsaldos = new rreporteantiguedadsaldos();
         objrreporteantiguedadsaldos.AV129VenCod = aP0_VenCod;
         objrreporteantiguedadsaldos.AV110TipCod = aP1_TipCod;
         objrreporteantiguedadsaldos.AV131ZonCod = aP2_ZonCod;
         objrreporteantiguedadsaldos.AV109TipCCod = aP3_TipCCod;
         objrreporteantiguedadsaldos.AV24CliCod = aP4_CliCod;
         objrreporteantiguedadsaldos.AV87MonCod = aP5_MonCod;
         objrreporteantiguedadsaldos.AV54Flag = aP6_Flag;
         objrreporteantiguedadsaldos.AV55Flag2 = aP7_Flag2;
         objrreporteantiguedadsaldos.context.SetSubmitInitialConfig(context);
         objrreporteantiguedadsaldos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrreporteantiguedadsaldos);
         aP0_VenCod=this.AV129VenCod;
         aP1_TipCod=this.AV110TipCod;
         aP2_ZonCod=this.AV131ZonCod;
         aP3_TipCCod=this.AV109TipCCod;
         aP4_CliCod=this.AV24CliCod;
         aP5_MonCod=this.AV87MonCod;
         aP6_Flag=this.AV54Flag;
         aP7_Flag2=this.AV55Flag2;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rreporteantiguedadsaldos)stateInfo).executePrivate();
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
            AV31Empresa = AV99Session.Get("Empresa");
            AV30EmpDir = AV99Session.Get("EmpDir");
            AV32EmpRUC = AV99Session.Get("EmpRUC");
            AV96Ruta = AV99Session.Get("RUTA") + "/Logo.jpg";
            AV77Logo = AV96Ruta;
            AV134Logo_GXI = GXDbFile.PathToUrl( AV96Ruta);
            AV34FDesde = DateTimeUtil.Today( context);
            AV52Filtro1 = "(Todos)";
            if ( AV54Flag == 1 )
            {
               AV88Periodo = "<" + context.localUtil.DToC( AV34FDesde, 2, "/");
            }
            else
            {
               AV78Mes = (short)(DateTimeUtil.Month( AV34FDesde));
               AV8Ano = (short)(DateTimeUtil.Year( AV34FDesde));
               AV50FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV78Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0));
               AV35Fecha = context.localUtil.CToD( AV50FechaC, 2);
               AV56FMesAnt = DateTimeUtil.DAdd(AV35Fecha,-((int)(1)));
               AV88Periodo = "<=" + context.localUtil.DToC( AV56FMesAnt, 2, "/");
            }
            /* Using cursor P00982 */
            pr_default.execute(0, new Object[] {AV129VenCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A309VenCod = P00982_A309VenCod[0];
               A2045VenDsc = P00982_A2045VenDsc[0];
               AV52Filtro1 = StringUtil.Trim( A2045VenDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV53Filtro2 = "(Todos)";
            /* Using cursor P00983 */
            pr_default.execute(1, new Object[] {AV87MonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A180MonCod = P00983_A180MonCod[0];
               A1234MonDsc = P00983_A1234MonDsc[0];
               AV53Filtro2 = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV118TTImp1 = 0.00m;
            AV119TTImp2 = 0.00m;
            AV120TTImp3 = 0.00m;
            AV121TTImp4 = 0.00m;
            AV122TTImp5 = 0.00m;
            AV123TTImp6 = 0.00m;
            AV124TTImp7 = 0.00m;
            AV128TTTotal = 0.00m;
            if ( AV54Flag == 1 )
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
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            H980( false, 51) ;
            getPrinter().GxDrawLine(367, Gx_line+11, 1084, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 278, Gx_line+23, 350, Gx_line+36, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV118TTImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+23, 499, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV119TTImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+23, 580, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV120TTImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+23, 653, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV121TTImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+23, 742, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV122TTImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+23, 825, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV123TTImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+23, 905, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV124TTImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+23, 991, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV128TTTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+23, 1078, Gx_line+36, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV117TTImp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+23, 432, Gx_line+36, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+51);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H980( true, 0) ;
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
         AV60I = 0;
         AV36Fecha1 = AV34FDesde;
         AV37Fecha11 = AV34FDesde;
         if ( DateTimeUtil.Dow( AV34FDesde) == 2 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(6)));
         }
         if ( DateTimeUtil.Dow( AV34FDesde) == 3 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(5)));
         }
         if ( DateTimeUtil.Dow( AV34FDesde) == 4 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(4)));
         }
         if ( DateTimeUtil.Dow( AV34FDesde) == 5 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(3)));
         }
         if ( DateTimeUtil.Dow( AV34FDesde) == 6 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(2)));
         }
         if ( DateTimeUtil.Dow( AV34FDesde) == 7 )
         {
            AV37Fecha11 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(1)));
         }
         AV38Fecha2 = DateTimeUtil.DAdd(AV37Fecha11,+((int)(1)));
         AV39Fecha22 = DateTimeUtil.DAdd(AV38Fecha2,+((int)(6)));
         AV40Fecha3 = DateTimeUtil.DAdd(AV39Fecha22,+((int)(1)));
         AV41Fecha33 = DateTimeUtil.DAdd(AV39Fecha22,+((int)(7)));
         AV42Fecha4 = DateTimeUtil.DAdd(AV41Fecha33,+((int)(1)));
         AV43Fecha44 = DateTimeUtil.DAdd(AV41Fecha33,+((int)(7)));
         AV44Fecha5 = DateTimeUtil.DAdd(AV43Fecha44,+((int)(1)));
         AV45Fecha55 = DateTimeUtil.DAdd(AV43Fecha44,+((int)(7)));
         AV46Fecha6 = DateTimeUtil.DAdd(AV45Fecha55,+((int)(1)));
         AV47Fecha66 = DateTimeUtil.DAdd(AV45Fecha55,+((int)(7)));
         AV48Fecha7 = DateTimeUtil.DAdd(AV47Fecha66,+((int)(1)));
         AV49Fecha77 = DateTimeUtil.DAdd(AV47Fecha66,+((int)(7)));
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV129VenCod ,
                                              AV110TipCod ,
                                              AV131ZonCod ,
                                              AV109TipCCod ,
                                              AV24CliCod ,
                                              AV87MonCod ,
                                              A186CCVendCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00984 */
         pr_default.execute(2, new Object[] {AV129VenCod, AV110TipCod, AV131ZonCod, AV109TipCCod, AV24CliCod, AV87MonCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK985 = false;
            A189CCCliDsc = P00984_A189CCCliDsc[0];
            A188CCCliCod = P00984_A188CCCliCod[0];
            A506CCEstado = P00984_A506CCEstado[0];
            A187CCmonCod = P00984_A187CCmonCod[0];
            A159TipCCod = P00984_A159TipCCod[0];
            n159TipCCod = P00984_n159TipCCod[0];
            A158ZonCod = P00984_A158ZonCod[0];
            n158ZonCod = P00984_n158ZonCod[0];
            A184CCTipCod = P00984_A184CCTipCod[0];
            A186CCVendCod = P00984_A186CCVendCod[0];
            A185CCDocNum = P00984_A185CCDocNum[0];
            A159TipCCod = P00984_A159TipCCod[0];
            n159TipCCod = P00984_n159TipCCod[0];
            A158ZonCod = P00984_A158ZonCod[0];
            n158ZonCod = P00984_n158ZonCod[0];
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00984_A188CCCliCod[0], A188CCCliCod) == 0 ) )
            {
               BRK985 = false;
               A189CCCliDsc = P00984_A189CCCliDsc[0];
               A184CCTipCod = P00984_A184CCTipCod[0];
               A185CCDocNum = P00984_A185CCDocNum[0];
               BRK985 = true;
               pr_default.readNext(2);
            }
            AV18CCCliCod = A188CCCliCod;
            AV19CCCliDsc = StringUtil.Trim( A189CCCliDsc);
            AV100TImp0 = 0.00m;
            AV101TImp1 = 0.00m;
            AV102TImp2 = 0.00m;
            AV103TImp3 = 0.00m;
            AV104TImp4 = 0.00m;
            AV105TImp5 = 0.00m;
            AV106TImp6 = 0.00m;
            AV107TImp7 = 0.00m;
            AV125TTotal = 0.00m;
            if ( (0==AV55Flag2) )
            {
               H980( false, 21) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 7, Gx_line+4, 481, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            /* Execute user subroutine: 'DETALLESEMANAS' */
            S125 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            AV117TTImp0 = (decimal)(AV117TTImp0+AV100TImp0);
            AV118TTImp1 = (decimal)(AV118TTImp1+AV101TImp1);
            AV119TTImp2 = (decimal)(AV119TTImp2+AV102TImp2);
            AV120TTImp3 = (decimal)(AV120TTImp3+AV103TImp3);
            AV121TTImp4 = (decimal)(AV121TTImp4+AV104TImp4);
            AV122TTImp5 = (decimal)(AV122TTImp5+AV105TImp5);
            AV123TTImp6 = (decimal)(AV123TTImp6+AV106TImp6);
            AV124TTImp7 = (decimal)(AV124TTImp7+AV107TImp7);
            AV128TTTotal = (decimal)(AV128TTTotal+AV125TTotal);
            if ( (0==AV55Flag2) )
            {
               H980( false, 31) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 0, Gx_line+12, 358, Gx_line+26, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV125TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+12, 1078, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+12, 991, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+12, 905, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105TImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+12, 825, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+12, 742, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103TImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+12, 653, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+12, 580, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101TImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+12, 499, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(365, Gx_line+0, 1082, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100TImp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+12, 432, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
            }
            else
            {
               H980( false, 22) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100TImp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+3, 432, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101TImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+3, 499, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+3, 580, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103TImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 562, Gx_line+3, 652, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+3, 742, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105TImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+3, 825, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+3, 905, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+3, 991, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV125TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+3, 1078, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 7, Gx_line+3, 342, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
            }
            if ( ! BRK985 )
            {
               BRK985 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S125( )
      {
         /* 'DETALLESEMANAS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV129VenCod ,
                                              AV110TipCod ,
                                              AV131ZonCod ,
                                              AV109TipCCod ,
                                              AV87MonCod ,
                                              A186CCVendCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV18CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00985 */
         pr_default.execute(3, new Object[] {AV18CCCliCod, AV129VenCod, AV110TipCod, AV131ZonCod, AV109TipCCod, AV87MonCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A188CCCliCod = P00985_A188CCCliCod[0];
            A506CCEstado = P00985_A506CCEstado[0];
            A187CCmonCod = P00985_A187CCmonCod[0];
            A159TipCCod = P00985_A159TipCCod[0];
            n159TipCCod = P00985_n159TipCCod[0];
            A158ZonCod = P00985_A158ZonCod[0];
            n158ZonCod = P00985_n158ZonCod[0];
            A184CCTipCod = P00985_A184CCTipCod[0];
            A186CCVendCod = P00985_A186CCVendCod[0];
            A185CCDocNum = P00985_A185CCDocNum[0];
            A306TipAbr = P00985_A306TipAbr[0];
            n306TipAbr = P00985_n306TipAbr[0];
            A190CCFech = P00985_A190CCFech[0];
            A1233MonAbr = P00985_A1233MonAbr[0];
            n1233MonAbr = P00985_n1233MonAbr[0];
            A508CCFVcto = P00985_A508CCFVcto[0];
            A509CCImpPago = P00985_A509CCImpPago[0];
            A513CCImpTotal = P00985_A513CCImpTotal[0];
            A511TipSigno = P00985_A511TipSigno[0];
            n511TipSigno = P00985_n511TipSigno[0];
            A159TipCCod = P00985_A159TipCCod[0];
            n159TipCCod = P00985_n159TipCCod[0];
            A158ZonCod = P00985_A158ZonCod[0];
            n158ZonCod = P00985_n158ZonCod[0];
            A1233MonAbr = P00985_A1233MonAbr[0];
            n1233MonAbr = P00985_n1233MonAbr[0];
            A306TipAbr = P00985_A306TipAbr[0];
            n306TipAbr = P00985_n306TipAbr[0];
            A511TipSigno = P00985_A511TipSigno[0];
            n511TipSigno = P00985_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV20CCDocNum = A185CCDocNum;
            AV23CCTipCod = A184CCTipCod;
            AV108TipAbr = A306TipAbr;
            AV21CCFech = A190CCFech;
            AV22CCFvcto = A508CCFVcto;
            AV97Saldo = A514CCImpSaldoSig;
            AV61Imp0 = 0.00m;
            AV62Imp1 = 0.00m;
            AV63Imp2 = 0.00m;
            AV64Imp3 = 0.00m;
            AV65Imp4 = 0.00m;
            AV66Imp5 = 0.00m;
            AV67Imp6 = 0.00m;
            AV68Imp7 = 0.00m;
            AV112Total = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV22CCFvcto ) < DateTimeUtil.ResetTime ( AV34FDesde ) )
            {
               AV61Imp0 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV36Fecha1 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV37Fecha11 ) ) )
            {
               AV62Imp1 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV38Fecha2 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV39Fecha22 ) ) )
            {
               AV63Imp2 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV40Fecha3 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV41Fecha33 ) ) )
            {
               AV64Imp3 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV42Fecha4 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV43Fecha44 ) ) )
            {
               AV65Imp4 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV44Fecha5 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV45Fecha55 ) ) )
            {
               AV66Imp5 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV46Fecha6 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV47Fecha66 ) ) )
            {
               AV67Imp6 = AV97Saldo;
            }
            if ( ( DateTimeUtil.ResetTime ( AV22CCFvcto ) >= DateTimeUtil.ResetTime ( AV48Fecha7 ) ) && ( DateTimeUtil.ResetTime ( AV22CCFvcto ) <= DateTimeUtil.ResetTime ( AV49Fecha77 ) ) )
            {
               AV68Imp7 = AV97Saldo;
            }
            AV112Total = (decimal)(AV61Imp0+AV62Imp1+AV63Imp2+AV64Imp3+AV65Imp4+AV66Imp5+AV67Imp6+AV68Imp7);
            if ( ( AV97Saldo > Convert.ToDecimal( 0 )) )
            {
               if ( (0==AV55Flag2) )
               {
                  H980( false, 20) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108TipAbr, "")), 4, Gx_line+4, 34, Gx_line+18, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV21CCFech, "99/99/99"), 149, Gx_line+4, 188, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV22CCFvcto, "99/99/99"), 203, Gx_line+4, 242, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV112Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CCDocNum, "")), 47, Gx_line+4, 111, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61Imp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+4, 432, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 265, Gx_line+4, 297, Gx_line+16, 1, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
               AV100TImp0 = (decimal)(AV100TImp0+AV61Imp0);
               AV101TImp1 = (decimal)(AV101TImp1+AV62Imp1);
               AV102TImp2 = (decimal)(AV102TImp2+AV63Imp2);
               AV103TImp3 = (decimal)(AV103TImp3+AV64Imp3);
               AV104TImp4 = (decimal)(AV104TImp4+AV65Imp4);
               AV105TImp5 = (decimal)(AV105TImp5+AV66Imp5);
               AV106TImp6 = (decimal)(AV106TImp6+AV67Imp6);
               AV107TImp7 = (decimal)(AV107TImp7+AV68Imp7);
               AV125TTotal = (decimal)(AV125TTotal+AV112Total);
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'MESES' Routine */
         returnInSub = false;
         AV60I = 0;
         AV10Ano1 = (short)(DateTimeUtil.Year( AV34FDesde));
         AV80Mes1 = (short)(DateTimeUtil.Month( AV34FDesde));
         GXt_char1 = AV89Periodo1;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV80Mes1, out  GXt_char1) ;
         AV89Periodo1 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV10Ano1), 10, 0));
         if ( AV80Mes1 == 12 )
         {
            AV11Ano2 = (short)(AV10Ano1+1);
            AV81Mes2 = 1;
         }
         else
         {
            AV11Ano2 = AV10Ano1;
            AV81Mes2 = (short)(AV80Mes1+1);
         }
         if ( AV81Mes2 == 12 )
         {
            AV12Ano3 = (short)(AV11Ano2+1);
            AV82Mes3 = 1;
         }
         else
         {
            AV12Ano3 = AV11Ano2;
            AV82Mes3 = (short)(AV81Mes2+1);
         }
         if ( AV82Mes3 == 12 )
         {
            AV13Ano4 = (short)(AV12Ano3+1);
            AV83Mes4 = 1;
         }
         else
         {
            AV13Ano4 = AV12Ano3;
            AV83Mes4 = (short)(AV82Mes3+1);
         }
         if ( AV83Mes4 == 12 )
         {
            AV14Ano5 = (short)(AV13Ano4+1);
            AV84Mes5 = 1;
         }
         else
         {
            AV14Ano5 = AV13Ano4;
            AV84Mes5 = (short)(AV83Mes4+1);
         }
         if ( AV84Mes5 == 12 )
         {
            AV15Ano6 = (short)(AV14Ano5+1);
            AV85Mes6 = 1;
         }
         else
         {
            AV15Ano6 = AV14Ano5;
            AV85Mes6 = (short)(AV84Mes5+1);
         }
         if ( AV85Mes6 == 12 )
         {
            AV16Ano7 = (short)(AV15Ano6+1);
            AV86Mes7 = 1;
         }
         else
         {
            AV16Ano7 = AV15Ano6;
            AV86Mes7 = (short)(AV85Mes6+1);
         }
         GXt_char1 = AV90Periodo2;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV81Mes2, out  GXt_char1) ;
         AV90Periodo2 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano2), 10, 0));
         GXt_char1 = AV91Periodo3;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV82Mes3, out  GXt_char1) ;
         AV91Periodo3 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV12Ano3), 10, 0));
         GXt_char1 = AV92Periodo4;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV83Mes4, out  GXt_char1) ;
         AV92Periodo4 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV13Ano4), 10, 0));
         GXt_char1 = AV93Periodo5;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV84Mes5, out  GXt_char1) ;
         AV93Periodo5 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV14Ano5), 10, 0));
         GXt_char1 = AV94Periodo6;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV85Mes6, out  GXt_char1) ;
         AV94Periodo6 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Ano6), 10, 0));
         GXt_char1 = AV95Periodo7;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV86Mes7, out  GXt_char1) ;
         AV95Periodo7 = StringUtil.Substring( GXt_char1, 1, 3) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV16Ano7), 10, 0));
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV129VenCod ,
                                              AV110TipCod ,
                                              AV131ZonCod ,
                                              AV109TipCCod ,
                                              AV24CliCod ,
                                              AV87MonCod ,
                                              A186CCVendCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00986 */
         pr_default.execute(4, new Object[] {AV129VenCod, AV110TipCod, AV131ZonCod, AV109TipCCod, AV24CliCod, AV87MonCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK988 = false;
            A189CCCliDsc = P00986_A189CCCliDsc[0];
            A188CCCliCod = P00986_A188CCCliCod[0];
            A506CCEstado = P00986_A506CCEstado[0];
            A187CCmonCod = P00986_A187CCmonCod[0];
            A159TipCCod = P00986_A159TipCCod[0];
            n159TipCCod = P00986_n159TipCCod[0];
            A158ZonCod = P00986_A158ZonCod[0];
            n158ZonCod = P00986_n158ZonCod[0];
            A184CCTipCod = P00986_A184CCTipCod[0];
            A186CCVendCod = P00986_A186CCVendCod[0];
            A185CCDocNum = P00986_A185CCDocNum[0];
            A159TipCCod = P00986_A159TipCCod[0];
            n159TipCCod = P00986_n159TipCCod[0];
            A158ZonCod = P00986_A158ZonCod[0];
            n158ZonCod = P00986_n158ZonCod[0];
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00986_A188CCCliCod[0], A188CCCliCod) == 0 ) )
            {
               BRK988 = false;
               A189CCCliDsc = P00986_A189CCCliDsc[0];
               A184CCTipCod = P00986_A184CCTipCod[0];
               A185CCDocNum = P00986_A185CCDocNum[0];
               BRK988 = true;
               pr_default.readNext(4);
            }
            AV18CCCliCod = A188CCCliCod;
            AV19CCCliDsc = StringUtil.Trim( A189CCCliDsc);
            AV100TImp0 = 0.00m;
            AV101TImp1 = 0.00m;
            AV102TImp2 = 0.00m;
            AV103TImp3 = 0.00m;
            AV104TImp4 = 0.00m;
            AV105TImp5 = 0.00m;
            AV106TImp6 = 0.00m;
            AV107TImp7 = 0.00m;
            AV125TTotal = 0.00m;
            if ( (0==AV55Flag2) )
            {
               H980( false, 21) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 7, Gx_line+4, 481, Gx_line+18, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            /* Execute user subroutine: 'DETALLEMESES' */
            S148 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            AV117TTImp0 = (decimal)(AV117TTImp0+AV100TImp0);
            AV118TTImp1 = (decimal)(AV118TTImp1+AV101TImp1);
            AV119TTImp2 = (decimal)(AV119TTImp2+AV102TImp2);
            AV120TTImp3 = (decimal)(AV120TTImp3+AV103TImp3);
            AV121TTImp4 = (decimal)(AV121TTImp4+AV104TImp4);
            AV122TTImp5 = (decimal)(AV122TTImp5+AV105TImp5);
            AV123TTImp6 = (decimal)(AV123TTImp6+AV106TImp6);
            AV124TTImp7 = (decimal)(AV124TTImp7+AV107TImp7);
            AV128TTTotal = (decimal)(AV128TTTotal+AV125TTotal);
            if ( (0==AV55Flag2) )
            {
               H980( false, 31) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 0, Gx_line+12, 358, Gx_line+26, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV125TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+12, 1078, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+12, 991, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+12, 905, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105TImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+12, 825, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+12, 742, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103TImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+12, 653, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+12, 580, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101TImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+12, 499, Gx_line+25, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(365, Gx_line+0, 1082, Gx_line+0, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100TImp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+12, 432, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
            }
            else
            {
               H980( false, 22) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV100TImp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+3, 432, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV101TImp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+3, 499, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TImp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+3, 580, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV103TImp3, "ZZZZZZ,ZZZ,ZZ9.99")), 562, Gx_line+3, 652, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TImp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+3, 742, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV105TImp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+3, 825, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TImp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+3, 905, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TImp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+3, 991, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV125TTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+3, 1078, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19CCCliDsc, "")), 7, Gx_line+3, 342, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
            }
            if ( ! BRK988 )
            {
               BRK988 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S148( )
      {
         /* 'DETALLEMESES' Routine */
         returnInSub = false;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV129VenCod ,
                                              AV110TipCod ,
                                              AV131ZonCod ,
                                              AV109TipCCod ,
                                              AV87MonCod ,
                                              A186CCVendCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV18CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00987 */
         pr_default.execute(5, new Object[] {AV18CCCliCod, AV129VenCod, AV110TipCod, AV131ZonCod, AV109TipCCod, AV87MonCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A188CCCliCod = P00987_A188CCCliCod[0];
            A506CCEstado = P00987_A506CCEstado[0];
            A187CCmonCod = P00987_A187CCmonCod[0];
            A159TipCCod = P00987_A159TipCCod[0];
            n159TipCCod = P00987_n159TipCCod[0];
            A158ZonCod = P00987_A158ZonCod[0];
            n158ZonCod = P00987_n158ZonCod[0];
            A184CCTipCod = P00987_A184CCTipCod[0];
            A186CCVendCod = P00987_A186CCVendCod[0];
            A185CCDocNum = P00987_A185CCDocNum[0];
            A306TipAbr = P00987_A306TipAbr[0];
            n306TipAbr = P00987_n306TipAbr[0];
            A190CCFech = P00987_A190CCFech[0];
            A1233MonAbr = P00987_A1233MonAbr[0];
            n1233MonAbr = P00987_n1233MonAbr[0];
            A508CCFVcto = P00987_A508CCFVcto[0];
            A509CCImpPago = P00987_A509CCImpPago[0];
            A513CCImpTotal = P00987_A513CCImpTotal[0];
            A511TipSigno = P00987_A511TipSigno[0];
            n511TipSigno = P00987_n511TipSigno[0];
            A159TipCCod = P00987_A159TipCCod[0];
            n159TipCCod = P00987_n159TipCCod[0];
            A158ZonCod = P00987_A158ZonCod[0];
            n158ZonCod = P00987_n158ZonCod[0];
            A1233MonAbr = P00987_A1233MonAbr[0];
            n1233MonAbr = P00987_n1233MonAbr[0];
            A306TipAbr = P00987_A306TipAbr[0];
            n306TipAbr = P00987_n306TipAbr[0];
            A511TipSigno = P00987_A511TipSigno[0];
            n511TipSigno = P00987_n511TipSigno[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            A514CCImpSaldoSig = (decimal)(A512CCImpSaldo*A511TipSigno);
            AV20CCDocNum = A185CCDocNum;
            AV23CCTipCod = A184CCTipCod;
            AV108TipAbr = A306TipAbr;
            AV21CCFech = A190CCFech;
            AV22CCFvcto = A508CCFVcto;
            AV97Saldo = A514CCImpSaldoSig;
            AV61Imp0 = 0.00m;
            AV62Imp1 = 0.00m;
            AV63Imp2 = 0.00m;
            AV64Imp3 = 0.00m;
            AV65Imp4 = 0.00m;
            AV66Imp5 = 0.00m;
            AV67Imp6 = 0.00m;
            AV68Imp7 = 0.00m;
            AV112Total = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV22CCFvcto ) < DateTimeUtil.ResetTime ( AV56FMesAnt ) )
            {
               AV61Imp0 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV10Ano1 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV80Mes1 ) )
            {
               AV62Imp1 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV11Ano2 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV81Mes2 ) )
            {
               AV63Imp2 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV12Ano3 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV82Mes3 ) )
            {
               AV64Imp3 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV13Ano4 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV83Mes4 ) )
            {
               AV65Imp4 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV14Ano5 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV84Mes5 ) )
            {
               AV66Imp5 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV15Ano6 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV85Mes6 ) )
            {
               AV67Imp6 = AV97Saldo;
            }
            if ( ( DateTimeUtil.Year( AV22CCFvcto) == AV16Ano7 ) && ( DateTimeUtil.Month( AV22CCFvcto) == AV86Mes7 ) )
            {
               AV68Imp7 = AV97Saldo;
            }
            AV112Total = (decimal)(AV61Imp0+AV62Imp1+AV63Imp2+AV64Imp3+AV65Imp4+AV66Imp5+AV67Imp6+AV68Imp7);
            if ( ( AV97Saldo > Convert.ToDecimal( 0 )) )
            {
               if ( (0==AV55Flag2) )
               {
                  H980( false, 20) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108TipAbr, "")), 4, Gx_line+4, 34, Gx_line+18, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV21CCFech, "99/99/99"), 149, Gx_line+4, 188, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV22CCFvcto, "99/99/99"), 203, Gx_line+4, 242, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62Imp1, "ZZZZZZ,ZZZ,ZZ9.99")), 409, Gx_line+4, 499, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63Imp2, "ZZZZZZ,ZZZ,ZZ9.99")), 490, Gx_line+4, 580, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Imp3, "ZZZZZZ,ZZZ,ZZ9.99")), 563, Gx_line+4, 653, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Imp4, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Imp5, "ZZZZZZ,ZZZ,ZZ9.99")), 735, Gx_line+4, 825, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67Imp6, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+4, 905, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68Imp7, "ZZZZZZ,ZZZ,ZZ9.99")), 901, Gx_line+4, 991, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV112Total, "ZZZZZZ,ZZZ,ZZ9.99")), 988, Gx_line+4, 1078, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20CCDocNum, "")), 47, Gx_line+4, 111, Gx_line+18, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61Imp0, "ZZZZZZ,ZZZ,ZZ9.99")), 342, Gx_line+4, 432, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 265, Gx_line+4, 297, Gx_line+16, 1, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
               AV100TImp0 = (decimal)(AV100TImp0+AV61Imp0);
               AV101TImp1 = (decimal)(AV101TImp1+AV62Imp1);
               AV102TImp2 = (decimal)(AV102TImp2+AV63Imp2);
               AV103TImp3 = (decimal)(AV103TImp3+AV64Imp3);
               AV104TImp4 = (decimal)(AV104TImp4+AV65Imp4);
               AV105TImp5 = (decimal)(AV105TImp5+AV66Imp5);
               AV106TImp6 = (decimal)(AV106TImp6+AV67Imp6);
               AV107TImp7 = (decimal)(AV107TImp7+AV68Imp7);
               AV125TTotal = (decimal)(AV125TTotal+AV112Total);
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void H980( bool bFoot ,
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
               if ( AV54Flag == 1 )
               {
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Reporte de Antiguedad de Saldos", 408, Gx_line+32, 693, Gx_line+52, 0+256, 0, 0, 0) ;
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
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Vendedor :", 397, Gx_line+60, 481, Gx_line+79, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Filtro1, "")), 493, Gx_line+59, 716, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Empresa, "")), 10, Gx_line+69, 350, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpRUC, "")), 10, Gx_line+86, 148, Gx_line+104, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV77Logo)) ? AV134Logo_GXI : AV77Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 150, Gx_line+69) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total", 1045, Gx_line+117, 1073, Gx_line+130, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV36Fecha1, "99/99/99"), 457, Gx_line+107, 512, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV37Fecha11, "99/99/99"), 457, Gx_line+124, 512, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV38Fecha2, "99/99/99"), 535, Gx_line+107, 590, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV39Fecha22, "99/99/99"), 535, Gx_line+124, 590, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV40Fecha3, "99/99/99"), 613, Gx_line+107, 668, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV41Fecha33, "99/99/99"), 613, Gx_line+124, 668, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV42Fecha4, "99/99/99"), 701, Gx_line+107, 756, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV43Fecha44, "99/99/99"), 701, Gx_line+124, 756, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV45Fecha55, "99/99/99"), 779, Gx_line+124, 834, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV44Fecha5, "99/99/99"), 779, Gx_line+109, 834, Gx_line+122, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV46Fecha6, "99/99/99"), 856, Gx_line+107, 911, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV47Fecha66, "99/99/99"), 856, Gx_line+124, 911, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV48Fecha7, "99/99/99"), 946, Gx_line+107, 1001, Gx_line+120, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV49Fecha77, "99/99/99"), 946, Gx_line+124, 1001, Gx_line+137, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda :", 397, Gx_line+80, 468, Gx_line+99, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Filtro2, "")), 493, Gx_line+79, 716, Gx_line+99, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Periodo, "")), 369, Gx_line+115, 422, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda", 259, Gx_line+115, 301, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("N° Documento", 46, Gx_line+115, 120, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Vcto", 207, Gx_line+115, 240, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Emisión", 147, Gx_line+115, 197, Gx_line+128, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("T/D", 9, Gx_line+115, 30, Gx_line+128, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+137);
               }
               else
               {
                  getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Reporte de Antiguedad de Saldos", 376, Gx_line+33, 661, Gx_line+53, 0+256, 0, 0, 0) ;
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
                  getPrinter().GxDrawText("T/D", 9, Gx_line+116, 30, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("F.Emisión", 147, Gx_line+116, 197, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Vendedor :", 365, Gx_line+60, 449, Gx_line+79, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Filtro1, "")), 460, Gx_line+59, 683, Gx_line+79, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31Empresa, "")), 10, Gx_line+69, 350, Gx_line+87, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32EmpRUC, "")), 10, Gx_line+86, 148, Gx_line+104, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV77Logo)) ? AV134Logo_GXI : AV77Logo);
                  getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 150, Gx_line+69) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("F.Vcto", 207, Gx_line+116, 240, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 1045, Gx_line+116, 1073, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89Periodo1, "")), 457, Gx_line+116, 510, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90Periodo2, "")), 535, Gx_line+116, 588, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91Periodo3, "")), 613, Gx_line+116, 666, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92Periodo4, "")), 701, Gx_line+116, 754, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93Periodo5, "")), 779, Gx_line+116, 832, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94Periodo6, "")), 856, Gx_line+116, 909, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Periodo7, "")), 946, Gx_line+116, 999, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda :", 364, Gx_line+80, 435, Gx_line+99, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 11, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Filtro2, "")), 459, Gx_line+79, 682, Gx_line+99, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("N° Documento", 46, Gx_line+116, 120, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Moneda", 259, Gx_line+116, 301, Gx_line+129, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Periodo, "")), 369, Gx_line+116, 422, Gx_line+129, 0+256, 0, 0, 0) ;
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
         AV31Empresa = "";
         AV99Session = context.GetSession();
         AV30EmpDir = "";
         AV32EmpRUC = "";
         AV96Ruta = "";
         AV77Logo = "";
         AV134Logo_GXI = "";
         AV34FDesde = DateTime.MinValue;
         AV52Filtro1 = "";
         AV88Periodo = "";
         AV50FechaC = "";
         AV35Fecha = DateTime.MinValue;
         AV56FMesAnt = DateTime.MinValue;
         scmdbuf = "";
         P00982_A309VenCod = new int[1] ;
         P00982_A2045VenDsc = new string[] {""} ;
         A2045VenDsc = "";
         AV53Filtro2 = "";
         P00983_A180MonCod = new int[1] ;
         P00983_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV36Fecha1 = DateTime.MinValue;
         AV37Fecha11 = DateTime.MinValue;
         AV38Fecha2 = DateTime.MinValue;
         AV39Fecha22 = DateTime.MinValue;
         AV40Fecha3 = DateTime.MinValue;
         AV41Fecha33 = DateTime.MinValue;
         AV42Fecha4 = DateTime.MinValue;
         AV43Fecha44 = DateTime.MinValue;
         AV44Fecha5 = DateTime.MinValue;
         AV45Fecha55 = DateTime.MinValue;
         AV46Fecha6 = DateTime.MinValue;
         AV47Fecha66 = DateTime.MinValue;
         AV48Fecha7 = DateTime.MinValue;
         AV49Fecha77 = DateTime.MinValue;
         A184CCTipCod = "";
         A188CCCliCod = "";
         A506CCEstado = "";
         P00984_A189CCCliDsc = new string[] {""} ;
         P00984_A188CCCliCod = new string[] {""} ;
         P00984_A506CCEstado = new string[] {""} ;
         P00984_A187CCmonCod = new int[1] ;
         P00984_A159TipCCod = new int[1] ;
         P00984_n159TipCCod = new bool[] {false} ;
         P00984_A158ZonCod = new int[1] ;
         P00984_n158ZonCod = new bool[] {false} ;
         P00984_A184CCTipCod = new string[] {""} ;
         P00984_A186CCVendCod = new int[1] ;
         P00984_A185CCDocNum = new string[] {""} ;
         A189CCCliDsc = "";
         A185CCDocNum = "";
         AV18CCCliCod = "";
         AV19CCCliDsc = "";
         P00985_A188CCCliCod = new string[] {""} ;
         P00985_A506CCEstado = new string[] {""} ;
         P00985_A187CCmonCod = new int[1] ;
         P00985_A159TipCCod = new int[1] ;
         P00985_n159TipCCod = new bool[] {false} ;
         P00985_A158ZonCod = new int[1] ;
         P00985_n158ZonCod = new bool[] {false} ;
         P00985_A184CCTipCod = new string[] {""} ;
         P00985_A186CCVendCod = new int[1] ;
         P00985_A185CCDocNum = new string[] {""} ;
         P00985_A306TipAbr = new string[] {""} ;
         P00985_n306TipAbr = new bool[] {false} ;
         P00985_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00985_A1233MonAbr = new string[] {""} ;
         P00985_n1233MonAbr = new bool[] {false} ;
         P00985_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00985_A509CCImpPago = new decimal[1] ;
         P00985_A513CCImpTotal = new decimal[1] ;
         P00985_A511TipSigno = new short[1] ;
         P00985_n511TipSigno = new bool[] {false} ;
         A306TipAbr = "";
         A190CCFech = DateTime.MinValue;
         A1233MonAbr = "";
         A508CCFVcto = DateTime.MinValue;
         AV20CCDocNum = "";
         AV23CCTipCod = "";
         AV108TipAbr = "";
         AV21CCFech = DateTime.MinValue;
         AV22CCFvcto = DateTime.MinValue;
         AV89Periodo1 = "";
         AV90Periodo2 = "";
         AV91Periodo3 = "";
         AV92Periodo4 = "";
         AV93Periodo5 = "";
         AV94Periodo6 = "";
         AV95Periodo7 = "";
         GXt_char1 = "";
         P00986_A189CCCliDsc = new string[] {""} ;
         P00986_A188CCCliCod = new string[] {""} ;
         P00986_A506CCEstado = new string[] {""} ;
         P00986_A187CCmonCod = new int[1] ;
         P00986_A159TipCCod = new int[1] ;
         P00986_n159TipCCod = new bool[] {false} ;
         P00986_A158ZonCod = new int[1] ;
         P00986_n158ZonCod = new bool[] {false} ;
         P00986_A184CCTipCod = new string[] {""} ;
         P00986_A186CCVendCod = new int[1] ;
         P00986_A185CCDocNum = new string[] {""} ;
         P00987_A188CCCliCod = new string[] {""} ;
         P00987_A506CCEstado = new string[] {""} ;
         P00987_A187CCmonCod = new int[1] ;
         P00987_A159TipCCod = new int[1] ;
         P00987_n159TipCCod = new bool[] {false} ;
         P00987_A158ZonCod = new int[1] ;
         P00987_n158ZonCod = new bool[] {false} ;
         P00987_A184CCTipCod = new string[] {""} ;
         P00987_A186CCVendCod = new int[1] ;
         P00987_A185CCDocNum = new string[] {""} ;
         P00987_A306TipAbr = new string[] {""} ;
         P00987_n306TipAbr = new bool[] {false} ;
         P00987_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00987_A1233MonAbr = new string[] {""} ;
         P00987_n1233MonAbr = new bool[] {false} ;
         P00987_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00987_A509CCImpPago = new decimal[1] ;
         P00987_A513CCImpTotal = new decimal[1] ;
         P00987_A511TipSigno = new short[1] ;
         P00987_n511TipSigno = new bool[] {false} ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV77Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rreporteantiguedadsaldos__default(),
            new Object[][] {
                new Object[] {
               P00982_A309VenCod, P00982_A2045VenDsc
               }
               , new Object[] {
               P00983_A180MonCod, P00983_A1234MonDsc
               }
               , new Object[] {
               P00984_A189CCCliDsc, P00984_A188CCCliCod, P00984_A506CCEstado, P00984_A187CCmonCod, P00984_A159TipCCod, P00984_n159TipCCod, P00984_A158ZonCod, P00984_n158ZonCod, P00984_A184CCTipCod, P00984_A186CCVendCod,
               P00984_A185CCDocNum
               }
               , new Object[] {
               P00985_A188CCCliCod, P00985_A506CCEstado, P00985_A187CCmonCod, P00985_A159TipCCod, P00985_n159TipCCod, P00985_A158ZonCod, P00985_n158ZonCod, P00985_A184CCTipCod, P00985_A186CCVendCod, P00985_A185CCDocNum,
               P00985_A306TipAbr, P00985_n306TipAbr, P00985_A190CCFech, P00985_A1233MonAbr, P00985_n1233MonAbr, P00985_A508CCFVcto, P00985_A509CCImpPago, P00985_A513CCImpTotal, P00985_A511TipSigno, P00985_n511TipSigno
               }
               , new Object[] {
               P00986_A189CCCliDsc, P00986_A188CCCliCod, P00986_A506CCEstado, P00986_A187CCmonCod, P00986_A159TipCCod, P00986_n159TipCCod, P00986_A158ZonCod, P00986_n158ZonCod, P00986_A184CCTipCod, P00986_A186CCVendCod,
               P00986_A185CCDocNum
               }
               , new Object[] {
               P00987_A188CCCliCod, P00987_A506CCEstado, P00987_A187CCmonCod, P00987_A159TipCCod, P00987_n159TipCCod, P00987_A158ZonCod, P00987_n158ZonCod, P00987_A184CCTipCod, P00987_A186CCVendCod, P00987_A185CCDocNum,
               P00987_A306TipAbr, P00987_n306TipAbr, P00987_A190CCFech, P00987_A1233MonAbr, P00987_n1233MonAbr, P00987_A508CCFVcto, P00987_A509CCImpPago, P00987_A513CCImpTotal, P00987_A511TipSigno, P00987_n511TipSigno
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
      private short AV54Flag ;
      private short AV55Flag2 ;
      private short AV78Mes ;
      private short AV8Ano ;
      private short A511TipSigno ;
      private short AV10Ano1 ;
      private short AV80Mes1 ;
      private short AV11Ano2 ;
      private short AV81Mes2 ;
      private short AV12Ano3 ;
      private short AV82Mes3 ;
      private short AV13Ano4 ;
      private short AV83Mes4 ;
      private short AV14Ano5 ;
      private short AV84Mes5 ;
      private short AV15Ano6 ;
      private short AV85Mes6 ;
      private short AV16Ano7 ;
      private short AV86Mes7 ;
      private int AV129VenCod ;
      private int AV131ZonCod ;
      private int AV109TipCCod ;
      private int AV87MonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A309VenCod ;
      private int A180MonCod ;
      private int Gx_OldLine ;
      private int A186CCVendCod ;
      private int A158ZonCod ;
      private int A159TipCCod ;
      private int A187CCmonCod ;
      private long AV60I ;
      private decimal AV118TTImp1 ;
      private decimal AV119TTImp2 ;
      private decimal AV120TTImp3 ;
      private decimal AV121TTImp4 ;
      private decimal AV122TTImp5 ;
      private decimal AV123TTImp6 ;
      private decimal AV124TTImp7 ;
      private decimal AV128TTTotal ;
      private decimal AV117TTImp0 ;
      private decimal AV100TImp0 ;
      private decimal AV101TImp1 ;
      private decimal AV102TImp2 ;
      private decimal AV103TImp3 ;
      private decimal AV104TImp4 ;
      private decimal AV105TImp5 ;
      private decimal AV106TImp6 ;
      private decimal AV107TImp7 ;
      private decimal AV125TTotal ;
      private decimal A509CCImpPago ;
      private decimal A513CCImpTotal ;
      private decimal A512CCImpSaldo ;
      private decimal A514CCImpSaldoSig ;
      private decimal AV97Saldo ;
      private decimal AV61Imp0 ;
      private decimal AV62Imp1 ;
      private decimal AV63Imp2 ;
      private decimal AV64Imp3 ;
      private decimal AV65Imp4 ;
      private decimal AV66Imp5 ;
      private decimal AV67Imp6 ;
      private decimal AV68Imp7 ;
      private decimal AV112Total ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV110TipCod ;
      private string AV24CliCod ;
      private string AV31Empresa ;
      private string AV30EmpDir ;
      private string AV32EmpRUC ;
      private string AV96Ruta ;
      private string AV52Filtro1 ;
      private string AV88Periodo ;
      private string AV50FechaC ;
      private string scmdbuf ;
      private string A2045VenDsc ;
      private string AV53Filtro2 ;
      private string A1234MonDsc ;
      private string A184CCTipCod ;
      private string A188CCCliCod ;
      private string A506CCEstado ;
      private string A189CCCliDsc ;
      private string A185CCDocNum ;
      private string AV18CCCliCod ;
      private string AV19CCCliDsc ;
      private string A306TipAbr ;
      private string A1233MonAbr ;
      private string AV20CCDocNum ;
      private string AV23CCTipCod ;
      private string AV108TipAbr ;
      private string AV89Periodo1 ;
      private string AV90Periodo2 ;
      private string AV91Periodo3 ;
      private string AV92Periodo4 ;
      private string AV93Periodo5 ;
      private string AV94Periodo6 ;
      private string AV95Periodo7 ;
      private string GXt_char1 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV34FDesde ;
      private DateTime AV35Fecha ;
      private DateTime AV56FMesAnt ;
      private DateTime AV36Fecha1 ;
      private DateTime AV37Fecha11 ;
      private DateTime AV38Fecha2 ;
      private DateTime AV39Fecha22 ;
      private DateTime AV40Fecha3 ;
      private DateTime AV41Fecha33 ;
      private DateTime AV42Fecha4 ;
      private DateTime AV43Fecha44 ;
      private DateTime AV44Fecha5 ;
      private DateTime AV45Fecha55 ;
      private DateTime AV46Fecha6 ;
      private DateTime AV47Fecha66 ;
      private DateTime AV48Fecha7 ;
      private DateTime AV49Fecha77 ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV21CCFech ;
      private DateTime AV22CCFvcto ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRK985 ;
      private bool n159TipCCod ;
      private bool n158ZonCod ;
      private bool n306TipAbr ;
      private bool n1233MonAbr ;
      private bool n511TipSigno ;
      private bool BRK988 ;
      private string AV134Logo_GXI ;
      private string AV77Logo ;
      private string Logo ;
      private IGxSession AV99Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_VenCod ;
      private string aP1_TipCod ;
      private int aP2_ZonCod ;
      private int aP3_TipCCod ;
      private string aP4_CliCod ;
      private int aP5_MonCod ;
      private short aP6_Flag ;
      private short aP7_Flag2 ;
      private IDataStoreProvider pr_default ;
      private int[] P00982_A309VenCod ;
      private string[] P00982_A2045VenDsc ;
      private int[] P00983_A180MonCod ;
      private string[] P00983_A1234MonDsc ;
      private string[] P00984_A189CCCliDsc ;
      private string[] P00984_A188CCCliCod ;
      private string[] P00984_A506CCEstado ;
      private int[] P00984_A187CCmonCod ;
      private int[] P00984_A159TipCCod ;
      private bool[] P00984_n159TipCCod ;
      private int[] P00984_A158ZonCod ;
      private bool[] P00984_n158ZonCod ;
      private string[] P00984_A184CCTipCod ;
      private int[] P00984_A186CCVendCod ;
      private string[] P00984_A185CCDocNum ;
      private string[] P00985_A188CCCliCod ;
      private string[] P00985_A506CCEstado ;
      private int[] P00985_A187CCmonCod ;
      private int[] P00985_A159TipCCod ;
      private bool[] P00985_n159TipCCod ;
      private int[] P00985_A158ZonCod ;
      private bool[] P00985_n158ZonCod ;
      private string[] P00985_A184CCTipCod ;
      private int[] P00985_A186CCVendCod ;
      private string[] P00985_A185CCDocNum ;
      private string[] P00985_A306TipAbr ;
      private bool[] P00985_n306TipAbr ;
      private DateTime[] P00985_A190CCFech ;
      private string[] P00985_A1233MonAbr ;
      private bool[] P00985_n1233MonAbr ;
      private DateTime[] P00985_A508CCFVcto ;
      private decimal[] P00985_A509CCImpPago ;
      private decimal[] P00985_A513CCImpTotal ;
      private short[] P00985_A511TipSigno ;
      private bool[] P00985_n511TipSigno ;
      private string[] P00986_A189CCCliDsc ;
      private string[] P00986_A188CCCliCod ;
      private string[] P00986_A506CCEstado ;
      private int[] P00986_A187CCmonCod ;
      private int[] P00986_A159TipCCod ;
      private bool[] P00986_n159TipCCod ;
      private int[] P00986_A158ZonCod ;
      private bool[] P00986_n158ZonCod ;
      private string[] P00986_A184CCTipCod ;
      private int[] P00986_A186CCVendCod ;
      private string[] P00986_A185CCDocNum ;
      private string[] P00987_A188CCCliCod ;
      private string[] P00987_A506CCEstado ;
      private int[] P00987_A187CCmonCod ;
      private int[] P00987_A159TipCCod ;
      private bool[] P00987_n159TipCCod ;
      private int[] P00987_A158ZonCod ;
      private bool[] P00987_n158ZonCod ;
      private string[] P00987_A184CCTipCod ;
      private int[] P00987_A186CCVendCod ;
      private string[] P00987_A185CCDocNum ;
      private string[] P00987_A306TipAbr ;
      private bool[] P00987_n306TipAbr ;
      private DateTime[] P00987_A190CCFech ;
      private string[] P00987_A1233MonAbr ;
      private bool[] P00987_n1233MonAbr ;
      private DateTime[] P00987_A508CCFVcto ;
      private decimal[] P00987_A509CCImpPago ;
      private decimal[] P00987_A513CCImpTotal ;
      private short[] P00987_A511TipSigno ;
      private bool[] P00987_n511TipSigno ;
   }

   public class rreporteantiguedadsaldos__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00984( IGxContext context ,
                                             int AV129VenCod ,
                                             string AV110TipCod ,
                                             int AV131ZonCod ,
                                             int AV109TipCCod ,
                                             string AV24CliCod ,
                                             int AV87MonCod ,
                                             int A186CCVendCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCmonCod] AS CCmonCod, T2.[TipCCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCVendCod], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "((T1.[CCEstado] = ''))");
         if ( ! (0==AV129VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV129VenCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV110TipCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV131ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV131ZonCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV109TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV109TipCCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV24CliCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV87MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV87MonCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliCod], T1.[CCCliDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00985( IGxContext context ,
                                             int AV129VenCod ,
                                             string AV110TipCod ,
                                             int AV131ZonCod ,
                                             int AV109TipCCod ,
                                             int AV87MonCod ,
                                             int A186CCVendCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A506CCEstado ,
                                             string A188CCCliCod ,
                                             string AV18CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCmonCod] AS CCmonCod, T2.[TipCCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCVendCod], T1.[CCDocNum], T4.[TipAbr], T1.[CCFech], T3.[MonAbr], T1.[CCFVcto], T1.[CCImpPago], T1.[CCImpTotal], T4.[TipSigno] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "((T1.[CCEstado] = ''))");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV18CCCliCod)");
         if ( ! (0==AV129VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV129VenCod)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV110TipCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV131ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV131ZonCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV109TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV109TipCCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV87MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV87MonCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCFVcto]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00986( IGxContext context ,
                                             int AV129VenCod ,
                                             string AV110TipCod ,
                                             int AV131ZonCod ,
                                             int AV109TipCCod ,
                                             string AV24CliCod ,
                                             int AV87MonCod ,
                                             int A186CCVendCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[6];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCmonCod] AS CCmonCod, T2.[TipCCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCVendCod], T1.[CCDocNum] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "((T1.[CCEstado] = ''))");
         if ( ! (0==AV129VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV129VenCod)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV110TipCod)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ! (0==AV131ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV131ZonCod)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV109TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV109TipCCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV24CliCod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! (0==AV87MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV87MonCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliCod], T1.[CCCliDsc]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00987( IGxContext context ,
                                             int AV129VenCod ,
                                             string AV110TipCod ,
                                             int AV131ZonCod ,
                                             int AV109TipCCod ,
                                             int AV87MonCod ,
                                             int A186CCVendCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A506CCEstado ,
                                             string A188CCCliCod ,
                                             string AV18CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[6];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T1.[CCmonCod] AS CCmonCod, T2.[TipCCod], T2.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCVendCod], T1.[CCDocNum], T4.[TipAbr], T1.[CCFech], T3.[MonAbr], T1.[CCFVcto], T1.[CCImpPago], T1.[CCImpTotal], T4.[TipSigno] FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T4 ON T4.[TipCod] = T1.[CCTipCod])";
         AddWhere(sWhereString, "((T1.[CCEstado] = ''))");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV18CCCliCod)");
         if ( ! (0==AV129VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV129VenCod)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV110TipCod)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! (0==AV131ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV131ZonCod)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ! (0==AV109TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV109TipCCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV87MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV87MonCod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCFVcto]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P00984(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] );
               case 3 :
                     return conditional_P00985(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
               case 4 :
                     return conditional_P00986(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] );
               case 5 :
                     return conditional_P00987(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] );
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00982;
          prmP00982 = new Object[] {
          new ParDef("@AV129VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00983;
          prmP00983 = new Object[] {
          new ParDef("@AV87MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00984;
          prmP00984 = new Object[] {
          new ParDef("@AV129VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV110TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV131ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV109TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV24CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV87MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00985;
          prmP00985 = new Object[] {
          new ParDef("@AV18CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV129VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV110TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV131ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV109TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV87MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00986;
          prmP00986 = new Object[] {
          new ParDef("@AV129VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV110TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV131ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV109TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV24CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV87MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00987;
          prmP00987 = new Object[] {
          new ParDef("@AV18CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV129VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV110TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV131ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV109TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV87MonCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00982", "SELECT [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV129VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00982,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00983", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV87MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00983,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00984", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00984,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00985", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00985,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00986", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00986,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00987", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00987,100, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 12);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 5);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((short[]) buf[18])[0] = rslt.getShort(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 12);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 5);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(12);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((short[]) buf[18])[0] = rslt.getShort(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                return;
       }
    }

 }

}
