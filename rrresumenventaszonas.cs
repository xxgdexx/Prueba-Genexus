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
   public class rrresumenventaszonas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenventaszonas.aspx")), "rrresumenventaszonas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenventaszonas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "Ano");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV42Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV43Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public rrresumenventaszonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenventaszonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes )
      {
         this.AV42Ano = aP0_Ano;
         this.AV43Mes = aP1_Mes;
         initialize();
         executePrivate();
         aP0_Ano=this.AV42Ano;
         aP1_Mes=this.AV43Mes;
      }

      public short executeUdp( ref short aP0_Ano )
      {
         execute(ref aP0_Ano, ref aP1_Mes);
         return AV43Mes ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes )
      {
         rrresumenventaszonas objrrresumenventaszonas;
         objrrresumenventaszonas = new rrresumenventaszonas();
         objrrresumenventaszonas.AV42Ano = aP0_Ano;
         objrrresumenventaszonas.AV43Mes = aP1_Mes;
         objrrresumenventaszonas.context.SetSubmitInitialConfig(context);
         objrrresumenventaszonas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenventaszonas);
         aP0_Ano=this.AV42Ano;
         aP1_Mes=this.AV43Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenventaszonas)stateInfo).executePrivate();
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
            AV32Empresa = AV36Session.Get("Empresa");
            AV33EmpDir = AV36Session.Get("EmpDir");
            AV34EmpRUC = AV36Session.Get("EmpRUC");
            AV35Ruta = AV36Session.Get("RUTA") + "/Logo.jpg";
            AV31Logo = AV35Ruta;
            AV67Logo_GXI = GXDbFile.PathToUrl( AV35Ruta);
            GXt_char1 = AV41cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV43Mes, out  GXt_char1) ;
            AV41cMes = GXt_char1;
            AV44Periodo = StringUtil.Trim( AV41cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV42Ano), 10, 0));
            AV46ZonDsc = "(ZONA NO DEFINIDA)";
            AV45ZonCod = 0;
            AV47Sub1 = 0.00m;
            AV48Sub2 = 0.00m;
            AV49Sub3 = 0.00m;
            AV50Sub4 = 0.00m;
            /* Execute user subroutine: 'DETALLECERO' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            if ( ! (Convert.ToDecimal(0)==AV48Sub2) )
            {
               AV38SDTVentaClientesITem.gxTpr_Zoncod = AV45ZonCod;
               AV38SDTVentaClientesITem.gxTpr_Zondsc = AV46ZonDsc;
               AV38SDTVentaClientesITem.gxTpr_Importe1 = AV47Sub1;
               AV38SDTVentaClientesITem.gxTpr_Importe2 = AV48Sub2;
               AV38SDTVentaClientesITem.gxTpr_Importe3 = AV49Sub3;
               AV38SDTVentaClientesITem.gxTpr_Importe4 = AV50Sub4;
               AV39SDTVentaClientes.Add(AV38SDTVentaClientesITem, 0);
               AV38SDTVentaClientesITem = new SdtSdtVentasZonas_SdtVentasClientesItem(context);
            }
            /* Using cursor P009E2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2095ZonSts = P009E2_A2095ZonSts[0];
               A2094ZonDsc = P009E2_A2094ZonDsc[0];
               A158ZonCod = P009E2_A158ZonCod[0];
               n158ZonCod = P009E2_n158ZonCod[0];
               AV46ZonDsc = StringUtil.Trim( A2094ZonDsc);
               AV45ZonCod = A158ZonCod;
               AV47Sub1 = 0.00m;
               AV48Sub2 = 0.00m;
               AV49Sub3 = 0.00m;
               AV50Sub4 = 0.00m;
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV38SDTVentaClientesITem.gxTpr_Zoncod = AV45ZonCod;
               AV38SDTVentaClientesITem.gxTpr_Zondsc = AV46ZonDsc;
               AV38SDTVentaClientesITem.gxTpr_Importe1 = AV47Sub1;
               AV38SDTVentaClientesITem.gxTpr_Importe2 = AV48Sub2;
               AV38SDTVentaClientesITem.gxTpr_Importe3 = AV49Sub3;
               AV38SDTVentaClientesITem.gxTpr_Importe4 = AV50Sub4;
               AV39SDTVentaClientes.Add(AV38SDTVentaClientesITem, 0);
               AV38SDTVentaClientesITem = new SdtSdtVentasZonas_SdtVentasClientesItem(context);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV51TSub1 = 0.00m;
            AV52TSub2 = 0.00m;
            AV53TSub3 = 0.00m;
            AV54TSub4 = 0.00m;
            AV39SDTVentaClientes.Sort("ZonCod");
            AV72GXV1 = 1;
            while ( AV72GXV1 <= AV39SDTVentaClientes.Count )
            {
               AV38SDTVentaClientesITem = ((SdtSdtVentasZonas_SdtVentasClientesItem)AV39SDTVentaClientes.Item(AV72GXV1));
               AV45ZonCod = AV38SDTVentaClientesITem.gxTpr_Zoncod;
               AV46ZonDsc = AV38SDTVentaClientesITem.gxTpr_Zondsc;
               AV47Sub1 = AV38SDTVentaClientesITem.gxTpr_Importe1;
               AV48Sub2 = AV38SDTVentaClientesITem.gxTpr_Importe2;
               AV49Sub3 = AV38SDTVentaClientesITem.gxTpr_Importe3;
               AV50Sub4 = AV38SDTVentaClientesITem.gxTpr_Importe4;
               H9E0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47Sub1, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+2, 386, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Sub2, "ZZZZZZ,ZZZ,ZZ9.99")), 411, Gx_line+2, 518, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Sub3, "ZZZZZZ,ZZZ,ZZ9.99")), 552, Gx_line+2, 659, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50Sub4, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+2, 789, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46ZonDsc, "")), 8, Gx_line+2, 254, Gx_line+16, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV51TSub1 = (decimal)(AV51TSub1+AV47Sub1);
               AV52TSub2 = (decimal)(AV52TSub2+AV48Sub2);
               AV53TSub3 = (decimal)(AV53TSub3+AV49Sub3);
               AV54TSub4 = (decimal)(AV54TSub4+AV50Sub4);
               AV72GXV1 = (int)(AV72GXV1+1);
            }
            H9E0( false, 52) ;
            getPrinter().GxDrawLine(271, Gx_line+7, 793, Gx_line+7, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 184, Gx_line+15, 264, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TSub1, "ZZZZZZ,ZZZ,ZZ9.99")), 279, Gx_line+15, 386, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TSub2, "ZZZZZZ,ZZZ,ZZ9.99")), 411, Gx_line+15, 518, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TSub3, "ZZZZZZ,ZZZ,ZZ9.99")), 552, Gx_line+15, 659, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TSub4, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+15, 789, Gx_line+30, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9E0( true, 0) ;
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P009E4 */
         pr_default.execute(1, new Object[] {AV42Ano, AV43Mes, AV45ZonCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A231DocCliCod = P009E4_A231DocCliCod[0];
            A941DocSts = P009E4_A941DocSts[0];
            A158ZonCod = P009E4_A158ZonCod[0];
            n158ZonCod = P009E4_n158ZonCod[0];
            A232DocFec = P009E4_A232DocFec[0];
            A230DocMonCod = P009E4_A230DocMonCod[0];
            A929DocFecRef = P009E4_A929DocFecRef[0];
            A511TipSigno = P009E4_A511TipSigno[0];
            A882DocAnticipos = P009E4_A882DocAnticipos[0];
            A24DocNum = P009E4_A24DocNum[0];
            A149TipCod = P009E4_A149TipCod[0];
            A920DocSubAfecto = P009E4_A920DocSubAfecto[0];
            A921DocSubInafecto = P009E4_A921DocSubInafecto[0];
            A158ZonCod = P009E4_A158ZonCod[0];
            n158ZonCod = P009E4_n158ZonCod[0];
            A511TipSigno = P009E4_A511TipSigno[0];
            A920DocSubAfecto = P009E4_A920DocSubAfecto[0];
            A921DocSubInafecto = P009E4_A921DocSubInafecto[0];
            AV11TipCod = A149TipCod;
            AV25Fecha = A232DocFec;
            AV12MonCod = A230DocMonCod;
            if ( ( StringUtil.StrCmp(AV11TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV11TipCod, "ND") == 0 ) )
            {
               AV25Fecha = A929DocFecRef;
            }
            GXt_decimal2 = AV26Cambio;
            GXt_int3 = 2;
            GXt_char1 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV25Fecha, ref  GXt_char1, out  GXt_decimal2) ;
            AV26Cambio = GXt_decimal2;
            AV59DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            AV60SubAfecto = (decimal)(NumberUtil.Round( A920DocSubAfecto, 2)*A511TipSigno);
            AV64SubInafecto = (decimal)(NumberUtil.Round( A921DocSubInafecto, 2)*A511TipSigno);
            AV24Total = (decimal)(AV60SubAfecto-(AV58Dscto+AV59DocAnticipos));
            AV57TTotal = (decimal)((AV60SubAfecto+AV64SubInafecto)-(AV58Dscto+AV59DocAnticipos));
            if ( AV12MonCod == 1 )
            {
               AV47Sub1 = (decimal)(AV47Sub1+AV24Total);
               AV48Sub2 = (decimal)(AV48Sub2+AV57TTotal);
               AV49Sub3 = (decimal)(AV49Sub3+(NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2)));
               AV50Sub4 = (decimal)(AV50Sub4+(NumberUtil.Round( AV57TTotal/ (decimal)(AV26Cambio), 2)));
            }
            else
            {
               AV49Sub3 = (decimal)(AV49Sub3+AV24Total);
               AV50Sub4 = (decimal)(AV50Sub4+AV57TTotal);
               AV47Sub1 = (decimal)(AV47Sub1+(NumberUtil.Round( AV24Total*AV26Cambio, 2)));
               AV48Sub2 = (decimal)(AV48Sub2+(NumberUtil.Round( AV57TTotal*AV26Cambio, 2)));
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'DETALLECERO' Routine */
         returnInSub = false;
         /* Using cursor P009E6 */
         pr_default.execute(2, new Object[] {AV42Ano, AV43Mes});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A231DocCliCod = P009E6_A231DocCliCod[0];
            A941DocSts = P009E6_A941DocSts[0];
            A158ZonCod = P009E6_A158ZonCod[0];
            n158ZonCod = P009E6_n158ZonCod[0];
            A232DocFec = P009E6_A232DocFec[0];
            A230DocMonCod = P009E6_A230DocMonCod[0];
            A929DocFecRef = P009E6_A929DocFecRef[0];
            A511TipSigno = P009E6_A511TipSigno[0];
            A882DocAnticipos = P009E6_A882DocAnticipos[0];
            A24DocNum = P009E6_A24DocNum[0];
            A149TipCod = P009E6_A149TipCod[0];
            A920DocSubAfecto = P009E6_A920DocSubAfecto[0];
            A921DocSubInafecto = P009E6_A921DocSubInafecto[0];
            A158ZonCod = P009E6_A158ZonCod[0];
            n158ZonCod = P009E6_n158ZonCod[0];
            A511TipSigno = P009E6_A511TipSigno[0];
            A920DocSubAfecto = P009E6_A920DocSubAfecto[0];
            A921DocSubInafecto = P009E6_A921DocSubInafecto[0];
            AV11TipCod = A149TipCod;
            AV25Fecha = A232DocFec;
            AV12MonCod = A230DocMonCod;
            if ( ( StringUtil.StrCmp(AV11TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV11TipCod, "ND") == 0 ) )
            {
               AV25Fecha = A929DocFecRef;
            }
            GXt_decimal2 = AV26Cambio;
            GXt_int3 = 2;
            GXt_char1 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV25Fecha, ref  GXt_char1, out  GXt_decimal2) ;
            AV26Cambio = GXt_decimal2;
            AV59DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            AV60SubAfecto = (decimal)(NumberUtil.Round( A920DocSubAfecto, 2)*A511TipSigno);
            AV64SubInafecto = (decimal)(NumberUtil.Round( A921DocSubInafecto, 2)*A511TipSigno);
            AV24Total = (decimal)(AV60SubAfecto-(AV58Dscto+AV59DocAnticipos));
            AV57TTotal = (decimal)((AV60SubAfecto+AV64SubInafecto)-(AV58Dscto+AV59DocAnticipos));
            if ( AV12MonCod == 1 )
            {
               AV47Sub1 = (decimal)(AV47Sub1+AV24Total);
               AV48Sub2 = (decimal)(AV48Sub2+AV57TTotal);
               AV49Sub3 = (decimal)(AV49Sub3+(NumberUtil.Round( AV24Total/ (decimal)(AV26Cambio), 2)));
               AV50Sub4 = (decimal)(AV50Sub4+(NumberUtil.Round( AV57TTotal/ (decimal)(AV26Cambio), 2)));
            }
            else
            {
               AV49Sub3 = (decimal)(AV49Sub3+AV24Total);
               AV50Sub4 = (decimal)(AV50Sub4+AV57TTotal);
               AV47Sub1 = (decimal)(AV47Sub1+(NumberUtil.Round( AV24Total*AV26Cambio, 2)));
               AV48Sub2 = (decimal)(AV48Sub2+(NumberUtil.Round( AV57TTotal*AV26Cambio, 2)));
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void H9E0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 670, Gx_line+43, 702, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 670, Gx_line+63, 714, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 670, Gx_line+24, 709, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ventas por Zonas", 271, Gx_line+42, 528, Gx_line+62, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+116, 797, Gx_line+156, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+24, 769, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+43, 767, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+63, 769, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Zona", 115, Gx_line+128, 145, Gx_line+142, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas Gravadas", 282, Gx_line+119, 383, Gx_line+133, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Logo)) ? AV67Logo_GXI : AV31Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxDrawLine(266, Gx_line+117, 266, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(399, Gx_line+116, 399, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas Totales", 421, Gx_line+119, 510, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(525, Gx_line+116, 525, Gx_line+155, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas Gravadas", 543, Gx_line+119, 644, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(666, Gx_line+117, 666, Gx_line+156, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda Nacional", 282, Gx_line+136, 382, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda Nacional", 415, Gx_line+136, 515, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda Extranjera", 536, Gx_line+136, 650, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda Extranjera", 677, Gx_line+136, 791, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas Totales", 690, Gx_line+119, 779, Gx_line+133, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Periodo :", 273, Gx_line+72, 351, Gx_line+92, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Periodo, "")), 355, Gx_line+72, 575, Gx_line+93, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+155);
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
         AV32Empresa = "";
         AV36Session = context.GetSession();
         AV33EmpDir = "";
         AV34EmpRUC = "";
         AV35Ruta = "";
         AV31Logo = "";
         AV67Logo_GXI = "";
         AV41cMes = "";
         AV44Periodo = "";
         AV46ZonDsc = "";
         AV38SDTVentaClientesITem = new SdtSdtVentasZonas_SdtVentasClientesItem(context);
         AV39SDTVentaClientes = new GXBaseCollection<SdtSdtVentasZonas_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         scmdbuf = "";
         P009E2_A2095ZonSts = new short[1] ;
         P009E2_A2094ZonDsc = new string[] {""} ;
         P009E2_A158ZonCod = new int[1] ;
         P009E2_n158ZonCod = new bool[] {false} ;
         A2094ZonDsc = "";
         P009E4_A231DocCliCod = new string[] {""} ;
         P009E4_A941DocSts = new string[] {""} ;
         P009E4_A158ZonCod = new int[1] ;
         P009E4_n158ZonCod = new bool[] {false} ;
         P009E4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009E4_A230DocMonCod = new int[1] ;
         P009E4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P009E4_A511TipSigno = new short[1] ;
         P009E4_A882DocAnticipos = new decimal[1] ;
         P009E4_A24DocNum = new string[] {""} ;
         P009E4_A149TipCod = new string[] {""} ;
         P009E4_A920DocSubAfecto = new decimal[1] ;
         P009E4_A921DocSubInafecto = new decimal[1] ;
         A231DocCliCod = "";
         A941DocSts = "";
         A232DocFec = DateTime.MinValue;
         A929DocFecRef = DateTime.MinValue;
         A24DocNum = "";
         A149TipCod = "";
         AV11TipCod = "";
         AV25Fecha = DateTime.MinValue;
         P009E6_A231DocCliCod = new string[] {""} ;
         P009E6_A941DocSts = new string[] {""} ;
         P009E6_A158ZonCod = new int[1] ;
         P009E6_n158ZonCod = new bool[] {false} ;
         P009E6_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009E6_A230DocMonCod = new int[1] ;
         P009E6_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P009E6_A511TipSigno = new short[1] ;
         P009E6_A882DocAnticipos = new decimal[1] ;
         P009E6_A24DocNum = new string[] {""} ;
         P009E6_A149TipCod = new string[] {""} ;
         P009E6_A920DocSubAfecto = new decimal[1] ;
         P009E6_A921DocSubInafecto = new decimal[1] ;
         GXt_char1 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV31Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenventaszonas__default(),
            new Object[][] {
                new Object[] {
               P009E2_A2095ZonSts, P009E2_A2094ZonDsc, P009E2_A158ZonCod
               }
               , new Object[] {
               P009E4_A231DocCliCod, P009E4_A941DocSts, P009E4_A158ZonCod, P009E4_n158ZonCod, P009E4_A232DocFec, P009E4_A230DocMonCod, P009E4_A929DocFecRef, P009E4_A511TipSigno, P009E4_A882DocAnticipos, P009E4_A24DocNum,
               P009E4_A149TipCod, P009E4_A920DocSubAfecto, P009E4_A921DocSubInafecto
               }
               , new Object[] {
               P009E6_A231DocCliCod, P009E6_A941DocSts, P009E6_A158ZonCod, P009E6_n158ZonCod, P009E6_A232DocFec, P009E6_A230DocMonCod, P009E6_A929DocFecRef, P009E6_A511TipSigno, P009E6_A882DocAnticipos, P009E6_A24DocNum,
               P009E6_A149TipCod, P009E6_A920DocSubAfecto, P009E6_A921DocSubInafecto
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
      private short AV42Ano ;
      private short AV43Mes ;
      private short A2095ZonSts ;
      private short A511TipSigno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int AV45ZonCod ;
      private int A158ZonCod ;
      private int AV72GXV1 ;
      private int Gx_OldLine ;
      private int A230DocMonCod ;
      private int AV12MonCod ;
      private int GXt_int3 ;
      private decimal AV47Sub1 ;
      private decimal AV48Sub2 ;
      private decimal AV49Sub3 ;
      private decimal AV50Sub4 ;
      private decimal AV51TSub1 ;
      private decimal AV52TSub2 ;
      private decimal AV53TSub3 ;
      private decimal AV54TSub4 ;
      private decimal A882DocAnticipos ;
      private decimal A920DocSubAfecto ;
      private decimal A921DocSubInafecto ;
      private decimal AV26Cambio ;
      private decimal AV59DocAnticipos ;
      private decimal AV60SubAfecto ;
      private decimal AV64SubInafecto ;
      private decimal AV24Total ;
      private decimal AV58Dscto ;
      private decimal AV57TTotal ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV32Empresa ;
      private string AV33EmpDir ;
      private string AV34EmpRUC ;
      private string AV35Ruta ;
      private string AV41cMes ;
      private string AV44Periodo ;
      private string AV46ZonDsc ;
      private string scmdbuf ;
      private string A2094ZonDsc ;
      private string A231DocCliCod ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A149TipCod ;
      private string AV11TipCod ;
      private string GXt_char1 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV25Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool n158ZonCod ;
      private string AV67Logo_GXI ;
      private string AV31Logo ;
      private string Logo ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private short[] P009E2_A2095ZonSts ;
      private string[] P009E2_A2094ZonDsc ;
      private int[] P009E2_A158ZonCod ;
      private bool[] P009E2_n158ZonCod ;
      private string[] P009E4_A231DocCliCod ;
      private string[] P009E4_A941DocSts ;
      private int[] P009E4_A158ZonCod ;
      private bool[] P009E4_n158ZonCod ;
      private DateTime[] P009E4_A232DocFec ;
      private int[] P009E4_A230DocMonCod ;
      private DateTime[] P009E4_A929DocFecRef ;
      private short[] P009E4_A511TipSigno ;
      private decimal[] P009E4_A882DocAnticipos ;
      private string[] P009E4_A24DocNum ;
      private string[] P009E4_A149TipCod ;
      private decimal[] P009E4_A920DocSubAfecto ;
      private decimal[] P009E4_A921DocSubInafecto ;
      private string[] P009E6_A231DocCliCod ;
      private string[] P009E6_A941DocSts ;
      private int[] P009E6_A158ZonCod ;
      private bool[] P009E6_n158ZonCod ;
      private DateTime[] P009E6_A232DocFec ;
      private int[] P009E6_A230DocMonCod ;
      private DateTime[] P009E6_A929DocFecRef ;
      private short[] P009E6_A511TipSigno ;
      private decimal[] P009E6_A882DocAnticipos ;
      private string[] P009E6_A24DocNum ;
      private string[] P009E6_A149TipCod ;
      private decimal[] P009E6_A920DocSubAfecto ;
      private decimal[] P009E6_A921DocSubInafecto ;
      private GXBaseCollection<SdtSdtVentasZonas_SdtVentasClientesItem> AV39SDTVentaClientes ;
      private SdtSdtVentasZonas_SdtVentasClientesItem AV38SDTVentaClientesITem ;
   }

   public class rrresumenventaszonas__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP009E2;
          prmP009E2 = new Object[] {
          };
          Object[] prmP009E4;
          prmP009E4 = new Object[] {
          new ParDef("@AV42Ano",GXType.Int16,4,0) ,
          new ParDef("@AV43Mes",GXType.Int16,2,0) ,
          new ParDef("@AV45ZonCod",GXType.Int32,6,0)
          };
          Object[] prmP009E6;
          prmP009E6 = new Object[] {
          new ParDef("@AV42Ano",GXType.Int16,4,0) ,
          new ParDef("@AV43Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009E2", "SELECT [ZonSts], [ZonDsc], [ZonCod] FROM [CZONAS] WHERE [ZonSts] = 1 ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009E4", "SELECT T1.[DocCliCod] AS DocCliCod, T1.[DocSts], T2.[ZonCod], T1.[DocFec], T1.[DocMonCod], T1.[DocFecRef], T3.[TipSigno], T1.[DocAnticipos], T1.[DocNum], T1.[TipCod], COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (YEAR(T1.[DocFec]) = @AV42Ano) AND (MONTH(T1.[DocFec]) = @AV43Mes) AND (T1.[DocSts] <> 'A') AND (T2.[ZonCod] = @AV45ZonCod) ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009E6", "SELECT T1.[DocCliCod] AS DocCliCod, T1.[DocSts], T2.[ZonCod], T1.[DocFec], T1.[DocMonCod], T1.[DocFecRef], T3.[TipSigno], T1.[DocAnticipos], T1.[DocNum], T1.[TipCod], COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (YEAR(T1.[DocFec]) = @AV42Ano) AND (MONTH(T1.[DocFec]) = @AV43Mes) AND ((T2.[ZonCod] = convert(int, 0)) or T2.[ZonCod] IS NULL) AND (T1.[DocSts] <> 'A') ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009E6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 12);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 12);
                ((string[]) buf[10])[0] = rslt.getString(10, 3);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                return;
       }
    }

 }

}
