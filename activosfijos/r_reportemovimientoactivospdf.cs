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
namespace GeneXus.Programs.activosfijos {
   public class r_reportemovimientoactivospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_reportemovimientoactivospdf.aspx")), "activosfijos.r_reportemovimientoactivospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_reportemovimientoactivospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ACTClaCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16ACTClaCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17ACTGrupCod = GetPar( "ACTGrupCod");
                  AV8ACTActCod = GetPar( "ACTActCod");
                  AV11ActActItem = GetPar( "ActActItem");
                  AV33dDesde = context.localUtil.ParseDateParm( GetPar( "dDesde"));
                  AV34dHasta = context.localUtil.ParseDateParm( GetPar( "dHasta"));
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

      public r_reportemovimientoactivospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportemovimientoactivospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTClaCod ,
                           ref string aP1_ACTGrupCod ,
                           ref string aP2_ACTActCod ,
                           ref string aP3_ActActItem ,
                           ref DateTime aP4_dDesde ,
                           ref DateTime aP5_dHasta )
      {
         this.AV16ACTClaCod = aP0_ACTClaCod;
         this.AV17ACTGrupCod = aP1_ACTGrupCod;
         this.AV8ACTActCod = aP2_ACTActCod;
         this.AV11ActActItem = aP3_ActActItem;
         this.AV33dDesde = aP4_dDesde;
         this.AV34dHasta = aP5_dHasta;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV17ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_dDesde=this.AV33dDesde;
         aP5_dHasta=this.AV34dHasta;
      }

      public DateTime executeUdp( ref string aP0_ACTClaCod ,
                                  ref string aP1_ACTGrupCod ,
                                  ref string aP2_ACTActCod ,
                                  ref string aP3_ActActItem ,
                                  ref DateTime aP4_dDesde )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_ACTActCod, ref aP3_ActActItem, ref aP4_dDesde, ref aP5_dHasta);
         return AV34dHasta ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref string aP2_ACTActCod ,
                                 ref string aP3_ActActItem ,
                                 ref DateTime aP4_dDesde ,
                                 ref DateTime aP5_dHasta )
      {
         r_reportemovimientoactivospdf objr_reportemovimientoactivospdf;
         objr_reportemovimientoactivospdf = new r_reportemovimientoactivospdf();
         objr_reportemovimientoactivospdf.AV16ACTClaCod = aP0_ACTClaCod;
         objr_reportemovimientoactivospdf.AV17ACTGrupCod = aP1_ACTGrupCod;
         objr_reportemovimientoactivospdf.AV8ACTActCod = aP2_ACTActCod;
         objr_reportemovimientoactivospdf.AV11ActActItem = aP3_ActActItem;
         objr_reportemovimientoactivospdf.AV33dDesde = aP4_dDesde;
         objr_reportemovimientoactivospdf.AV34dHasta = aP5_dHasta;
         objr_reportemovimientoactivospdf.context.SetSubmitInitialConfig(context);
         objr_reportemovimientoactivospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportemovimientoactivospdf);
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV17ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_dDesde=this.AV33dDesde;
         aP5_dHasta=this.AV34dHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportemovimientoactivospdf)stateInfo).executePrivate();
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
            AV36Empresa = AV71Session.Get("Empresa");
            AV35EmpDir = AV71Session.Get("EmpDir");
            AV37EmpRUC = AV71Session.Get("EmpRUC");
            AV67Ruta = AV71Session.Get("RUTA") + "/Logo.jpg";
            AV53Logo = AV67Ruta;
            AV96Logo_GXI = GXDbFile.PathToUrl( AV67Ruta);
            AV79Titulo = "Reporte de Movimientos de Activos Fijos";
            GXt_char1 = AV27cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV54Mes, out  GXt_char1) ;
            AV27cMes = GXt_char1;
            AV80Titulo2 = "(Todos)";
            AV81Titulo3 = "(Todos)";
            /* Using cursor P00F42 */
            pr_default.execute(0, new Object[] {AV16ACTClaCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A426ACTClaCod = P00F42_A426ACTClaCod[0];
               A2184ACTClaDsc = P00F42_A2184ACTClaDsc[0];
               AV80Titulo2 = A2184ACTClaDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00F43 */
            pr_default.execute(1, new Object[] {AV16ACTClaCod, AV17ACTGrupCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2103ACTGrupCod = P00F43_A2103ACTGrupCod[0];
               A426ACTClaCod = P00F43_A426ACTClaCod[0];
               A2196ACTGrupDsc = P00F43_A2196ACTGrupDsc[0];
               AV81Titulo3 = A2196ACTGrupDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV16ACTClaCod ,
                                                 AV17ACTGrupCod ,
                                                 AV8ACTActCod ,
                                                 AV11ActActItem ,
                                                 A426ACTClaCod ,
                                                 A2103ACTGrupCod ,
                                                 A2100ACTActCod ,
                                                 A2104ActActItem ,
                                                 A2200AMovFec ,
                                                 AV33dDesde ,
                                                 AV34dHasta } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00F44 */
            pr_default.execute(2, new Object[] {AV33dDesde, AV34dHasta, AV16ACTClaCod, AV17ACTGrupCod, AV8ACTActCod, AV11ActActItem});
            while ( (pr_default.getStatus(2) != 101) )
            {
               BRKF45 = false;
               A2122ACTActDsc = P00F44_A2122ACTActDsc[0];
               A2100ACTActCod = P00F44_A2100ACTActCod[0];
               A2200AMovFec = P00F44_A2200AMovFec[0];
               A2104ActActItem = P00F44_A2104ActActItem[0];
               n2104ActActItem = P00F44_n2104ActActItem[0];
               A2103ACTGrupCod = P00F44_A2103ACTGrupCod[0];
               A426ACTClaCod = P00F44_A426ACTClaCod[0];
               A2109AMovCod = P00F44_A2109AMovCod[0];
               A2122ACTActDsc = P00F44_A2122ACTActDsc[0];
               A2103ACTGrupCod = P00F44_A2103ACTGrupCod[0];
               A426ACTClaCod = P00F44_A426ACTClaCod[0];
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00F44_A2100ACTActCod[0], A2100ACTActCod) == 0 ) )
               {
                  BRKF45 = false;
                  A2122ACTActDsc = P00F44_A2122ACTActDsc[0];
                  A2109AMovCod = P00F44_A2109AMovCod[0];
                  A2122ACTActDsc = P00F44_A2122ACTActDsc[0];
                  BRKF45 = true;
                  pr_default.readNext(2);
               }
               AV28Codigo = A2100ACTActCod;
               AV48Item = A2104ActActItem;
               AV60Nombre = StringUtil.Trim( A2100ACTActCod) + " - " + StringUtil.Trim( A2122ACTActDsc);
               HF40( false, 15) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Nombre, "")), 7, Gx_line+2, 112, Gx_line+13, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+15);
               /* Execute user subroutine: 'MOVIMIENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               HF40( false, 19) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               if ( ! BRKF45 )
               {
                  BRKF45 = true;
                  pr_default.readNext(2);
               }
            }
            pr_default.close(2);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HF40( true, 0) ;
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
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV16ACTClaCod ,
                                              AV17ACTGrupCod ,
                                              A426ACTClaCod ,
                                              A2103ACTGrupCod ,
                                              A2200AMovFec ,
                                              AV33dDesde ,
                                              AV34dHasta ,
                                              AV28Codigo ,
                                              AV48Item ,
                                              A2100ACTActCod ,
                                              A2104ActActItem } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00F45 */
         pr_default.execute(3, new Object[] {AV28Codigo, AV48Item, AV33dDesde, AV34dHasta, AV16ACTClaCod, AV17ACTGrupCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A2110AMovCosCod = P00F45_A2110AMovCosCod[0];
            n2110AMovCosCod = P00F45_n2110AMovCosCod[0];
            A2200AMovFec = P00F45_A2200AMovFec[0];
            A2104ActActItem = P00F45_A2104ActActItem[0];
            n2104ActActItem = P00F45_n2104ActActItem[0];
            A2100ACTActCod = P00F45_A2100ACTActCod[0];
            A2103ACTGrupCod = P00F45_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F45_A426ACTClaCod[0];
            A2109AMovCod = P00F45_A2109AMovCod[0];
            A2203AMovTipo = P00F45_A2203AMovTipo[0];
            A2111AMovAreaCod = P00F45_A2111AMovAreaCod[0];
            n2111AMovAreaCod = P00F45_n2111AMovAreaCod[0];
            A2199AMovCosDsc = P00F45_A2199AMovCosDsc[0];
            A2199AMovCosDsc = P00F45_A2199AMovCosDsc[0];
            A2103ACTGrupCod = P00F45_A2103ACTGrupCod[0];
            A426ACTClaCod = P00F45_A426ACTClaCod[0];
            AV22AMovCod = A2109AMovCod;
            AV24AMovFec = A2200AMovFec;
            AV25AMovTipo = A2203AMovTipo;
            AV20AMovAreaCod = A2111AMovAreaCod;
            AV21AMovAreaDsc = "";
            AV23AMovCosDsc = A2199AMovCosDsc;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20AMovAreaCod)) )
            {
               /* Execute user subroutine: 'AREA' */
               S127 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  returnInSub = true;
                  if (true) return;
               }
            }
            HF40( false, 17) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22AMovCod, "")), 10, Gx_line+3, 53, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV24AMovFec, "99/99/99"), 91, Gx_line+3, 123, Gx_line+14, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21AMovAreaDsc, "")), 431, Gx_line+3, 600, Gx_line+13, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23AMovCosDsc, "")), 621, Gx_line+3, 791, Gx_line+13, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25AMovTipo, "")), 161, Gx_line+3, 245, Gx_line+14, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+17);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S127( )
      {
         /* 'AREA' Routine */
         returnInSub = false;
         /* Using cursor P00F46 */
         pr_default.execute(4, new Object[] {AV20AMovAreaCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A2102ACTAreaCod = P00F46_A2102ACTAreaCod[0];
            A2172ACTAreaDsc = P00F46_A2172ACTAreaDsc[0];
            AV21AMovAreaDsc = A2172ACTAreaDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HF40( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 693, Gx_line+24, 725, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 693, Gx_line+42, 737, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 693, Gx_line+6, 732, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 758, Gx_line+42, 797, Gx_line+57, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 739, Gx_line+24, 796, Gx_line+38, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 750, Gx_line+6, 797, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("FECHA", 97, Gx_line+125, 125, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° MOVIMIENTO", 7, Gx_line+125, 78, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Empresa, "")), 8, Gx_line+14, 233, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37EmpRUC, "")), 8, Gx_line+31, 178, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde :", 263, Gx_line+86, 328, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta :", 415, Gx_line+86, 476, Gx_line+106, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV33dDesde, "99/99/99"), 335, Gx_line+86, 405, Gx_line+107, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV34dHasta, "99/99/99"), 484, Gx_line+86, 554, Gx_line+107, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("AREA", 488, Gx_line+125, 511, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CENTRO DE COSTOS", 676, Gx_line+125, 760, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(83, Gx_line+115, 83, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(141, Gx_line+116, 141, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(414, Gx_line+115, 414, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(604, Gx_line+116, 604, Gx_line+146, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("TIPO DE MOVIMIENTO", 214, Gx_line+125, 309, Gx_line+135, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+115, 800, Gx_line+146, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79Titulo, "")), 217, Gx_line+18, 606, Gx_line+43, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80Titulo2, "")), 217, Gx_line+39, 606, Gx_line+64, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Titulo3, "")), 217, Gx_line+59, 606, Gx_line+84, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+146);
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
         AV36Empresa = "";
         AV71Session = context.GetSession();
         AV35EmpDir = "";
         AV37EmpRUC = "";
         AV67Ruta = "";
         AV53Logo = "";
         AV96Logo_GXI = "";
         AV79Titulo = "";
         AV27cMes = "";
         GXt_char1 = "";
         AV80Titulo2 = "";
         AV81Titulo3 = "";
         scmdbuf = "";
         P00F42_A426ACTClaCod = new string[] {""} ;
         P00F42_A2184ACTClaDsc = new string[] {""} ;
         A426ACTClaCod = "";
         A2184ACTClaDsc = "";
         P00F43_A2103ACTGrupCod = new string[] {""} ;
         P00F43_A426ACTClaCod = new string[] {""} ;
         P00F43_A2196ACTGrupDsc = new string[] {""} ;
         A2103ACTGrupCod = "";
         A2196ACTGrupDsc = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         A2200AMovFec = DateTime.MinValue;
         P00F44_A2122ACTActDsc = new string[] {""} ;
         P00F44_A2100ACTActCod = new string[] {""} ;
         P00F44_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         P00F44_A2104ActActItem = new string[] {""} ;
         P00F44_n2104ActActItem = new bool[] {false} ;
         P00F44_A2103ACTGrupCod = new string[] {""} ;
         P00F44_A426ACTClaCod = new string[] {""} ;
         P00F44_A2109AMovCod = new string[] {""} ;
         A2122ACTActDsc = "";
         A2109AMovCod = "";
         AV28Codigo = "";
         AV48Item = "";
         AV60Nombre = "";
         P00F45_A2110AMovCosCod = new string[] {""} ;
         P00F45_n2110AMovCosCod = new bool[] {false} ;
         P00F45_A2200AMovFec = new DateTime[] {DateTime.MinValue} ;
         P00F45_A2104ActActItem = new string[] {""} ;
         P00F45_n2104ActActItem = new bool[] {false} ;
         P00F45_A2100ACTActCod = new string[] {""} ;
         P00F45_A2103ACTGrupCod = new string[] {""} ;
         P00F45_A426ACTClaCod = new string[] {""} ;
         P00F45_A2109AMovCod = new string[] {""} ;
         P00F45_A2203AMovTipo = new string[] {""} ;
         P00F45_A2111AMovAreaCod = new string[] {""} ;
         P00F45_n2111AMovAreaCod = new bool[] {false} ;
         P00F45_A2199AMovCosDsc = new string[] {""} ;
         A2110AMovCosCod = "";
         A2203AMovTipo = "";
         A2111AMovAreaCod = "";
         A2199AMovCosDsc = "";
         AV22AMovCod = "";
         AV24AMovFec = DateTime.MinValue;
         AV25AMovTipo = "";
         AV20AMovAreaCod = "";
         AV21AMovAreaDsc = "";
         AV23AMovCosDsc = "";
         P00F46_A2102ACTAreaCod = new string[] {""} ;
         P00F46_A2172ACTAreaDsc = new string[] {""} ;
         A2102ACTAreaCod = "";
         A2172ACTAreaDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_reportemovimientoactivospdf__default(),
            new Object[][] {
                new Object[] {
               P00F42_A426ACTClaCod, P00F42_A2184ACTClaDsc
               }
               , new Object[] {
               P00F43_A2103ACTGrupCod, P00F43_A426ACTClaCod, P00F43_A2196ACTGrupDsc
               }
               , new Object[] {
               P00F44_A2122ACTActDsc, P00F44_A2100ACTActCod, P00F44_A2200AMovFec, P00F44_A2104ActActItem, P00F44_n2104ActActItem, P00F44_A2103ACTGrupCod, P00F44_A426ACTClaCod, P00F44_A2109AMovCod
               }
               , new Object[] {
               P00F45_A2110AMovCosCod, P00F45_n2110AMovCosCod, P00F45_A2200AMovFec, P00F45_A2104ActActItem, P00F45_n2104ActActItem, P00F45_A2100ACTActCod, P00F45_A2103ACTGrupCod, P00F45_A426ACTClaCod, P00F45_A2109AMovCod, P00F45_A2203AMovTipo,
               P00F45_A2111AMovAreaCod, P00F45_n2111AMovAreaCod, P00F45_A2199AMovCosDsc
               }
               , new Object[] {
               P00F46_A2102ACTAreaCod, P00F46_A2172ACTAreaDsc
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
      private short AV54Mes ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV36Empresa ;
      private string AV35EmpDir ;
      private string AV37EmpRUC ;
      private string AV67Ruta ;
      private string AV79Titulo ;
      private string AV27cMes ;
      private string GXt_char1 ;
      private string AV80Titulo2 ;
      private string AV81Titulo3 ;
      private string scmdbuf ;
      private string A2110AMovCosCod ;
      private string A2199AMovCosDsc ;
      private string AV23AMovCosDsc ;
      private string Gx_time ;
      private DateTime AV33dDesde ;
      private DateTime AV34dHasta ;
      private DateTime A2200AMovFec ;
      private DateTime AV24AMovFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKF45 ;
      private bool n2104ActActItem ;
      private bool returnInSub ;
      private bool n2110AMovCosCod ;
      private bool n2111AMovAreaCod ;
      private string AV16ACTClaCod ;
      private string AV17ACTGrupCod ;
      private string AV8ACTActCod ;
      private string AV11ActActItem ;
      private string AV96Logo_GXI ;
      private string A426ACTClaCod ;
      private string A2184ACTClaDsc ;
      private string A2103ACTGrupCod ;
      private string A2196ACTGrupDsc ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2122ACTActDsc ;
      private string A2109AMovCod ;
      private string AV28Codigo ;
      private string AV48Item ;
      private string AV60Nombre ;
      private string A2203AMovTipo ;
      private string A2111AMovAreaCod ;
      private string AV22AMovCod ;
      private string AV25AMovTipo ;
      private string AV20AMovAreaCod ;
      private string AV21AMovAreaDsc ;
      private string A2102ACTAreaCod ;
      private string A2172ACTAreaDsc ;
      private string AV53Logo ;
      private IGxSession AV71Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private string aP2_ACTActCod ;
      private string aP3_ActActItem ;
      private DateTime aP4_dDesde ;
      private DateTime aP5_dHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00F42_A426ACTClaCod ;
      private string[] P00F42_A2184ACTClaDsc ;
      private string[] P00F43_A2103ACTGrupCod ;
      private string[] P00F43_A426ACTClaCod ;
      private string[] P00F43_A2196ACTGrupDsc ;
      private string[] P00F44_A2122ACTActDsc ;
      private string[] P00F44_A2100ACTActCod ;
      private DateTime[] P00F44_A2200AMovFec ;
      private string[] P00F44_A2104ActActItem ;
      private bool[] P00F44_n2104ActActItem ;
      private string[] P00F44_A2103ACTGrupCod ;
      private string[] P00F44_A426ACTClaCod ;
      private string[] P00F44_A2109AMovCod ;
      private string[] P00F45_A2110AMovCosCod ;
      private bool[] P00F45_n2110AMovCosCod ;
      private DateTime[] P00F45_A2200AMovFec ;
      private string[] P00F45_A2104ActActItem ;
      private bool[] P00F45_n2104ActActItem ;
      private string[] P00F45_A2100ACTActCod ;
      private string[] P00F45_A2103ACTGrupCod ;
      private string[] P00F45_A426ACTClaCod ;
      private string[] P00F45_A2109AMovCod ;
      private string[] P00F45_A2203AMovTipo ;
      private string[] P00F45_A2111AMovAreaCod ;
      private bool[] P00F45_n2111AMovAreaCod ;
      private string[] P00F45_A2199AMovCosDsc ;
      private string[] P00F46_A2102ACTAreaCod ;
      private string[] P00F46_A2172ACTAreaDsc ;
   }

   public class r_reportemovimientoactivospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F44( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV17ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             DateTime A2200AMovFec ,
                                             DateTime AV33dDesde ,
                                             DateTime AV34dHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[ACTActDsc], T1.[ACTActCod], T1.[AMovFec], T1.[ActActItem], T2.[ACTGrupCod], T2.[ACTClaCod], T1.[AMovCod] FROM ([ACTMOVACTIVO] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod])";
         AddWhere(sWhereString, "(T1.[AMovFec] >= @AV33dDesde)");
         AddWhere(sWhereString, "(T1.[AMovFec] <= @AV34dHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTClaCod] = @AV16ACTClaCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T2.[ACTGrupCod] = @AV17ACTGrupCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ACTActCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTActCod] = @AV8ACTActCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ActActItem)) )
         {
            AddWhere(sWhereString, "(T1.[ActActItem] = @AV11ActActItem)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod], T2.[ACTActDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00F45( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV17ACTGrupCod ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             DateTime A2200AMovFec ,
                                             DateTime AV33dDesde ,
                                             DateTime AV34dHasta ,
                                             string AV28Codigo ,
                                             string AV48Item ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[AMovCosCod] AS AMovCosCod, T1.[AMovFec], T1.[ActActItem], T1.[ACTActCod], T3.[ACTGrupCod], T3.[ACTClaCod], T1.[AMovCod], T1.[AMovTipo], T1.[AMovAreaCod], T2.[COSDsc] AS AMovCosDsc FROM (([ACTMOVACTIVO] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[AMovCosCod]) INNER JOIN [ACTACTIVOS] T3 ON T3.[ACTActCod] = T1.[ACTActCod])";
         AddWhere(sWhereString, "(T1.[ACTActCod] = @AV28Codigo and T1.[ActActItem] = @AV48Item)");
         AddWhere(sWhereString, "(T1.[AMovFec] >= @AV33dDesde)");
         AddWhere(sWhereString, "(T1.[AMovFec] <= @AV34dHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T3.[ACTClaCod] = @AV16ACTClaCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T3.[ACTGrupCod] = @AV17ACTGrupCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod], T1.[ActActItem]";
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
                     return conditional_P00F44(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
               case 3 :
                     return conditional_P00F45(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] );
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
          Object[] prmP00F42;
          prmP00F42 = new Object[] {
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F43;
          prmP00F43 = new Object[] {
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV17ACTGrupCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F46;
          prmP00F46 = new Object[] {
          new ParDef("@AV20AMovAreaCod",GXType.NVarChar,5,0)
          };
          Object[] prmP00F44;
          prmP00F44 = new Object[] {
          new ParDef("@AV33dDesde",GXType.Date,8,0) ,
          new ParDef("@AV34dHasta",GXType.Date,8,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV17ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00F45;
          prmP00F45 = new Object[] {
          new ParDef("@AV28Codigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV48Item",GXType.NVarChar,5,0) ,
          new ParDef("@AV33dDesde",GXType.Date,8,0) ,
          new ParDef("@AV34dHasta",GXType.Date,8,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV17ACTGrupCod",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F42", "SELECT [ACTClaCod], [ACTClaDsc] FROM [ACTCLASE] WHERE [ACTClaCod] = @AV16ACTClaCod ORDER BY [ACTClaCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F43", "SELECT [ACTGrupCod], [ACTClaCod], [ACTGrupDsc] FROM [ACTGRUPO] WHERE [ACTClaCod] = @AV16ACTClaCod and [ACTGrupCod] = @AV17ACTGrupCod ORDER BY [ACTClaCod], [ACTGrupCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F43,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00F44", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F44,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F45", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F45,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00F46", "SELECT [ACTAreaCod], [ACTAreaDsc] FROM [ACTAREA] WHERE [ACTAreaCod] = @AV20AMovAreaCod ORDER BY [ACTAreaCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F46,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((string[]) buf[7])[0] = rslt.getVarchar(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
