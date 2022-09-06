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
   public class rrcuentasxcobrarzonas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrcuentasxcobrarzonas.aspx")), "rrcuentasxcobrarzonas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrcuentasxcobrarzonas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV45TipCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV13CliCod = GetPar( "CliCod");
                  AV37MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AV60ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV8Agrupa = (short)(NumberUtil.Val( GetPar( "Agrupa"), "."));
                  AV19DisCod2 = GetPar( "DisCod2");
                  AV25FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public rrcuentasxcobrarzonas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrcuentasxcobrarzonas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TipCod ,
                           ref string aP1_CliCod ,
                           ref int aP2_MonCod ,
                           ref int aP3_ZonCod ,
                           ref short aP4_Agrupa ,
                           ref string aP5_DisCod2 ,
                           ref DateTime aP6_FHasta )
      {
         this.AV45TipCod = aP0_TipCod;
         this.AV13CliCod = aP1_CliCod;
         this.AV37MonCod = aP2_MonCod;
         this.AV60ZonCod = aP3_ZonCod;
         this.AV8Agrupa = aP4_Agrupa;
         this.AV19DisCod2 = aP5_DisCod2;
         this.AV25FHasta = aP6_FHasta;
         initialize();
         executePrivate();
         aP0_TipCod=this.AV45TipCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_MonCod=this.AV37MonCod;
         aP3_ZonCod=this.AV60ZonCod;
         aP4_Agrupa=this.AV8Agrupa;
         aP5_DisCod2=this.AV19DisCod2;
         aP6_FHasta=this.AV25FHasta;
      }

      public DateTime executeUdp( ref string aP0_TipCod ,
                                  ref string aP1_CliCod ,
                                  ref int aP2_MonCod ,
                                  ref int aP3_ZonCod ,
                                  ref short aP4_Agrupa ,
                                  ref string aP5_DisCod2 )
      {
         execute(ref aP0_TipCod, ref aP1_CliCod, ref aP2_MonCod, ref aP3_ZonCod, ref aP4_Agrupa, ref aP5_DisCod2, ref aP6_FHasta);
         return AV25FHasta ;
      }

      public void executeSubmit( ref string aP0_TipCod ,
                                 ref string aP1_CliCod ,
                                 ref int aP2_MonCod ,
                                 ref int aP3_ZonCod ,
                                 ref short aP4_Agrupa ,
                                 ref string aP5_DisCod2 ,
                                 ref DateTime aP6_FHasta )
      {
         rrcuentasxcobrarzonas objrrcuentasxcobrarzonas;
         objrrcuentasxcobrarzonas = new rrcuentasxcobrarzonas();
         objrrcuentasxcobrarzonas.AV45TipCod = aP0_TipCod;
         objrrcuentasxcobrarzonas.AV13CliCod = aP1_CliCod;
         objrrcuentasxcobrarzonas.AV37MonCod = aP2_MonCod;
         objrrcuentasxcobrarzonas.AV60ZonCod = aP3_ZonCod;
         objrrcuentasxcobrarzonas.AV8Agrupa = aP4_Agrupa;
         objrrcuentasxcobrarzonas.AV19DisCod2 = aP5_DisCod2;
         objrrcuentasxcobrarzonas.AV25FHasta = aP6_FHasta;
         objrrcuentasxcobrarzonas.context.SetSubmitInitialConfig(context);
         objrrcuentasxcobrarzonas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrcuentasxcobrarzonas);
         aP0_TipCod=this.AV45TipCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_MonCod=this.AV37MonCod;
         aP3_ZonCod=this.AV60ZonCod;
         aP4_Agrupa=this.AV8Agrupa;
         aP5_DisCod2=this.AV19DisCod2;
         aP6_FHasta=this.AV25FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrcuentasxcobrarzonas)stateInfo).executePrivate();
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
            AV21Empresa = AV43Session.Get("Empresa");
            AV20EmpDir = AV43Session.Get("EmpDir");
            AV22EmpRUC = AV43Session.Get("EmpRUC");
            AV41Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV36Logo = AV41Ruta;
            AV63Logo_GXI = GXDbFile.PathToUrl( AV41Ruta);
            AV26Filtro1 = "Todos";
            AV27Filtro2 = "Todos";
            AV28Filtro3 = "Todos";
            AV29Filtro4 = "Todos";
            AV30Filtro5 = "Todos";
            /* Using cursor P00952 */
            pr_default.execute(0, new Object[] {AV45TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00952_A149TipCod[0];
               A1910TipDsc = P00952_A1910TipDsc[0];
               AV26Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00953 */
            pr_default.execute(1, new Object[] {AV60ZonCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A158ZonCod = P00953_A158ZonCod[0];
               n158ZonCod = P00953_n158ZonCod[0];
               A2094ZonDsc = P00953_A2094ZonDsc[0];
               AV27Filtro2 = A2094ZonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00954 */
            pr_default.execute(2, new Object[] {AV37MonCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A180MonCod = P00954_A180MonCod[0];
               A1234MonDsc = P00954_A1234MonDsc[0];
               n1234MonDsc = P00954_n1234MonDsc[0];
               AV28Filtro3 = A1234MonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00955 */
            pr_default.execute(3, new Object[] {AV24EstCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A140EstCod = P00955_A140EstCod[0];
               A602EstDsc = P00955_A602EstDsc[0];
               A139PaiCod = P00955_A139PaiCod[0];
               AV29Filtro4 = A602EstDsc;
               pr_default.readNext(3);
            }
            pr_default.close(3);
            /* Using cursor P00956 */
            pr_default.execute(4, new Object[] {AV13CliCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A45CliCod = P00956_A45CliCod[0];
               A161CliDsc = P00956_A161CliDsc[0];
               AV30Filtro5 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
            AV48TotGImporte = 0.00m;
            AV49TotGPagos = 0.00m;
            AV50TotGSaldo = 0.00m;
            AV46TotalME = 0.00m;
            AV47TotalMN = 0.00m;
            if ( DateTimeUtil.ResetTime ( AV25FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
            {
               pr_default.dynParam(5, new Object[]{ new Object[]{
                                                    AV60ZonCod ,
                                                    AV19DisCod2 ,
                                                    A158ZonCod ,
                                                    A142DisCod ,
                                                    A506CCEstado } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor P00957 */
               pr_default.execute(5, new Object[] {AV60ZonCod, AV19DisCod2});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  BRK958 = false;
                  A188CCCliCod = P00957_A188CCCliCod[0];
                  A506CCEstado = P00957_A506CCEstado[0];
                  A2094ZonDsc = P00957_A2094ZonDsc[0];
                  A158ZonCod = P00957_A158ZonCod[0];
                  n158ZonCod = P00957_n158ZonCod[0];
                  A142DisCod = P00957_A142DisCod[0];
                  n142DisCod = P00957_n142DisCod[0];
                  A189CCCliDsc = P00957_A189CCCliDsc[0];
                  A184CCTipCod = P00957_A184CCTipCod[0];
                  A185CCDocNum = P00957_A185CCDocNum[0];
                  A158ZonCod = P00957_A158ZonCod[0];
                  n158ZonCod = P00957_n158ZonCod[0];
                  A142DisCod = P00957_A142DisCod[0];
                  n142DisCod = P00957_n142DisCod[0];
                  A2094ZonDsc = P00957_A2094ZonDsc[0];
                  while ( (pr_default.getStatus(5) != 101) && ( P00957_A158ZonCod[0] == A158ZonCod ) )
                  {
                     BRK958 = false;
                     A188CCCliCod = P00957_A188CCCliCod[0];
                     A2094ZonDsc = P00957_A2094ZonDsc[0];
                     A184CCTipCod = P00957_A184CCTipCod[0];
                     A185CCDocNum = P00957_A185CCDocNum[0];
                     A2094ZonDsc = P00957_A2094ZonDsc[0];
                     BRK958 = true;
                     pr_default.readNext(5);
                  }
                  AV52TotImpVend = 0.00m;
                  AV54TotPagoVend = 0.00m;
                  AV56TotSaldoVend = 0.00m;
                  AV13CliCod = "";
                  AV60ZonCod = A158ZonCod;
                  AV59Zona = AV60ZonCod;
                  H950( false, 21) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2094ZonDsc, "")), 8, Gx_line+4, 634, Gx_line+20, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+21);
                  /* Execute user subroutine: 'CUENTACOBRAR' */
                  S141 ();
                  if ( returnInSub )
                  {
                     pr_default.close(5);
                     this.cleanup();
                     if (true) return;
                  }
                  H950( false, 27) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Zona", 188, Gx_line+8, 252, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+8, 675, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(466, Gx_line+3, 788, Gx_line+3, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+8, 779, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2094ZonDsc, "")), 265, Gx_line+8, 468, Gx_line+22, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotImpVend, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+8, 566, Gx_line+23, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+27);
                  if ( ! BRK958 )
                  {
                     BRK958 = true;
                     pr_default.readNext(5);
                  }
               }
               pr_default.close(5);
            }
            else
            {
               pr_default.dynParam(6, new Object[]{ new Object[]{
                                                    AV60ZonCod ,
                                                    AV19DisCod2 ,
                                                    A158ZonCod ,
                                                    A142DisCod } ,
                                                    new int[]{
                                                    TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                    }
               });
               /* Using cursor P00958 */
               pr_default.execute(6, new Object[] {AV60ZonCod, AV19DisCod2});
               while ( (pr_default.getStatus(6) != 101) )
               {
                  BRK9510 = false;
                  A188CCCliCod = P00958_A188CCCliCod[0];
                  A2094ZonDsc = P00958_A2094ZonDsc[0];
                  A158ZonCod = P00958_A158ZonCod[0];
                  n158ZonCod = P00958_n158ZonCod[0];
                  A142DisCod = P00958_A142DisCod[0];
                  n142DisCod = P00958_n142DisCod[0];
                  A189CCCliDsc = P00958_A189CCCliDsc[0];
                  A184CCTipCod = P00958_A184CCTipCod[0];
                  A185CCDocNum = P00958_A185CCDocNum[0];
                  A158ZonCod = P00958_A158ZonCod[0];
                  n158ZonCod = P00958_n158ZonCod[0];
                  A142DisCod = P00958_A142DisCod[0];
                  n142DisCod = P00958_n142DisCod[0];
                  A2094ZonDsc = P00958_A2094ZonDsc[0];
                  while ( (pr_default.getStatus(6) != 101) && ( P00958_A158ZonCod[0] == A158ZonCod ) )
                  {
                     BRK9510 = false;
                     A188CCCliCod = P00958_A188CCCliCod[0];
                     A2094ZonDsc = P00958_A2094ZonDsc[0];
                     A184CCTipCod = P00958_A184CCTipCod[0];
                     A185CCDocNum = P00958_A185CCDocNum[0];
                     A2094ZonDsc = P00958_A2094ZonDsc[0];
                     BRK9510 = true;
                     pr_default.readNext(6);
                  }
                  AV52TotImpVend = 0.00m;
                  AV54TotPagoVend = 0.00m;
                  AV56TotSaldoVend = 0.00m;
                  AV13CliCod = "";
                  AV60ZonCod = A158ZonCod;
                  AV59Zona = AV60ZonCod;
                  /* Execute user subroutine: 'VALIDAMOV' */
                  S1212 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     this.cleanup();
                     if (true) return;
                  }
                  AV32FlaVend = AV31Flag;
                  if ( AV32FlaVend == 1 )
                  {
                     H950( false, 21) ;
                     getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2094ZonDsc, "")), 8, Gx_line+4, 634, Gx_line+20, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+21);
                  }
                  /* Execute user subroutine: 'CUENTACOBRARAL' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(6);
                     this.cleanup();
                     if (true) return;
                  }
                  if ( AV32FlaVend == 1 )
                  {
                     H950( false, 27) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Zona", 188, Gx_line+8, 252, Gx_line+22, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+8, 675, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxDrawLine(466, Gx_line+3, 788, Gx_line+3, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TotPagoVend, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+8, 779, Gx_line+23, 2, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2094ZonDsc, "")), 265, Gx_line+8, 468, Gx_line+22, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TotImpVend, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+8, 566, Gx_line+23, 2, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+27);
                  }
                  if ( ! BRK9510 )
                  {
                     BRK9510 = true;
                     pr_default.readNext(6);
                  }
               }
               pr_default.close(6);
            }
            H950( false, 28) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48TotGImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+9, 566, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49TotGPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+9, 675, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50TotGSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+9, 779, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(465, Gx_line+4, 787, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 360, Gx_line+10, 440, Gx_line+24, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H950( true, 0) ;
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
         /* 'CUENTACOBRARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV37MonCod ,
                                              AV45TipCod ,
                                              AV18DisCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A142DisCod ,
                                              A190CCFech ,
                                              AV25FHasta ,
                                              A506CCEstado ,
                                              A158ZonCod ,
                                              AV59Zona } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00959 */
         pr_default.execute(7, new Object[] {AV25FHasta, AV59Zona, AV13CliCod, AV37MonCod, AV45TipCod, AV18DisCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK9512 = false;
            A189CCCliDsc = P00959_A189CCCliDsc[0];
            A185CCDocNum = P00959_A185CCDocNum[0];
            A511TipSigno = P00959_A511TipSigno[0];
            n511TipSigno = P00959_n511TipSigno[0];
            A513CCImpTotal = P00959_A513CCImpTotal[0];
            A509CCImpPago = P00959_A509CCImpPago[0];
            A187CCmonCod = P00959_A187CCmonCod[0];
            A508CCFVcto = P00959_A508CCFVcto[0];
            A1234MonDsc = P00959_A1234MonDsc[0];
            n1234MonDsc = P00959_n1234MonDsc[0];
            A306TipAbr = P00959_A306TipAbr[0];
            n306TipAbr = P00959_n306TipAbr[0];
            A190CCFech = P00959_A190CCFech[0];
            A184CCTipCod = P00959_A184CCTipCod[0];
            A506CCEstado = P00959_A506CCEstado[0];
            A158ZonCod = P00959_A158ZonCod[0];
            n158ZonCod = P00959_n158ZonCod[0];
            A142DisCod = P00959_A142DisCod[0];
            n142DisCod = P00959_n142DisCod[0];
            A188CCCliCod = P00959_A188CCCliCod[0];
            A1234MonDsc = P00959_A1234MonDsc[0];
            n1234MonDsc = P00959_n1234MonDsc[0];
            A511TipSigno = P00959_A511TipSigno[0];
            n511TipSigno = P00959_n511TipSigno[0];
            A306TipAbr = P00959_A306TipAbr[0];
            n306TipAbr = P00959_n306TipAbr[0];
            A158ZonCod = P00959_A158ZonCod[0];
            n158ZonCod = P00959_n158ZonCod[0];
            A142DisCod = P00959_A142DisCod[0];
            n142DisCod = P00959_n142DisCod[0];
            AV58Vendedor = 0;
            AV13CliCod = A188CCCliCod;
            AV14Cliente = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            /* Execute user subroutine: 'VALIDAMOV' */
            S1212 ();
            if ( returnInSub )
            {
               pr_default.close(7);
               returnInSub = true;
               if (true) return;
            }
            if ( AV31Flag == 1 )
            {
               H950( false, 21) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Cliente, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
            }
            AV51TotImporte = 0.00m;
            AV53TotPagos = 0.00m;
            AV55TotSaldo = 0.00m;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P00959_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK9512 = false;
               A185CCDocNum = P00959_A185CCDocNum[0];
               A511TipSigno = P00959_A511TipSigno[0];
               n511TipSigno = P00959_n511TipSigno[0];
               A513CCImpTotal = P00959_A513CCImpTotal[0];
               A509CCImpPago = P00959_A509CCImpPago[0];
               A187CCmonCod = P00959_A187CCmonCod[0];
               A508CCFVcto = P00959_A508CCFVcto[0];
               A1234MonDsc = P00959_A1234MonDsc[0];
               n1234MonDsc = P00959_n1234MonDsc[0];
               A306TipAbr = P00959_A306TipAbr[0];
               n306TipAbr = P00959_n306TipAbr[0];
               A190CCFech = P00959_A190CCFech[0];
               A184CCTipCod = P00959_A184CCTipCod[0];
               A1234MonDsc = P00959_A1234MonDsc[0];
               n1234MonDsc = P00959_n1234MonDsc[0];
               A511TipSigno = P00959_A511TipSigno[0];
               n511TipSigno = P00959_n511TipSigno[0];
               A306TipAbr = P00959_A306TipAbr[0];
               n306TipAbr = P00959_n306TipAbr[0];
               AV12CCTipCod = A184CCTipCod;
               AV10CCDocNum = A185CCDocNum;
               AV35Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV40Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV11CCmonCod = A187CCmonCod;
               /* Execute user subroutine: 'PAGOS' */
               S1313 ();
               if ( returnInSub )
               {
                  pr_default.close(7);
                  returnInSub = true;
                  if (true) return;
               }
               AV42Saldo = (decimal)((AV35Importe-AV40Pagos)*A511TipSigno);
               AV17Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               if ( ( AV42Saldo != Convert.ToDecimal( 0 )) )
               {
                  AV51TotImporte = (decimal)(AV51TotImporte+AV35Importe);
                  AV53TotPagos = (decimal)(AV53TotPagos+AV40Pagos);
                  AV55TotSaldo = (decimal)(AV55TotSaldo+AV42Saldo);
                  AV47TotalMN = (decimal)(AV47TotalMN+(((AV11CCmonCod==1) ? AV42Saldo : (decimal)(0))));
                  AV46TotalME = (decimal)(AV46TotalME+(((AV11CCmonCod==2) ? AV42Saldo : (decimal)(0))));
                  H950( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
               }
               BRK9512 = true;
               pr_default.readNext(7);
            }
            if ( ( AV55TotSaldo != Convert.ToDecimal( 0 )) )
            {
               H950( false, 24) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
            }
            AV48TotGImporte = (decimal)(AV48TotGImporte+AV51TotImporte);
            AV49TotGPagos = (decimal)(AV49TotGPagos+AV53TotPagos);
            AV50TotGSaldo = (decimal)(AV50TotGSaldo+AV55TotSaldo);
            AV52TotImpVend = (decimal)(AV52TotImpVend+AV51TotImporte);
            AV54TotPagoVend = (decimal)(AV54TotPagoVend+AV53TotPagos);
            AV56TotSaldoVend = (decimal)(AV56TotSaldoVend+AV55TotSaldo);
            if ( ! BRK9512 )
            {
               BRK9512 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S141( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV37MonCod ,
                                              AV18DisCod ,
                                              AV45TipCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A142DisCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              AV59Zona ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009510 */
         pr_default.execute(8, new Object[] {AV59Zona, AV13CliCod, AV37MonCod, AV18DisCod, AV45TipCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRK9514 = false;
            A189CCCliDsc = P009510_A189CCCliDsc[0];
            A511TipSigno = P009510_A511TipSigno[0];
            n511TipSigno = P009510_n511TipSigno[0];
            A513CCImpTotal = P009510_A513CCImpTotal[0];
            A509CCImpPago = P009510_A509CCImpPago[0];
            A508CCFVcto = P009510_A508CCFVcto[0];
            A187CCmonCod = P009510_A187CCmonCod[0];
            A1234MonDsc = P009510_A1234MonDsc[0];
            n1234MonDsc = P009510_n1234MonDsc[0];
            A185CCDocNum = P009510_A185CCDocNum[0];
            A306TipAbr = P009510_A306TipAbr[0];
            n306TipAbr = P009510_n306TipAbr[0];
            A190CCFech = P009510_A190CCFech[0];
            A184CCTipCod = P009510_A184CCTipCod[0];
            A506CCEstado = P009510_A506CCEstado[0];
            A158ZonCod = P009510_A158ZonCod[0];
            n158ZonCod = P009510_n158ZonCod[0];
            A142DisCod = P009510_A142DisCod[0];
            n142DisCod = P009510_n142DisCod[0];
            A188CCCliCod = P009510_A188CCCliCod[0];
            A1234MonDsc = P009510_A1234MonDsc[0];
            n1234MonDsc = P009510_n1234MonDsc[0];
            A511TipSigno = P009510_A511TipSigno[0];
            n511TipSigno = P009510_n511TipSigno[0];
            A306TipAbr = P009510_A306TipAbr[0];
            n306TipAbr = P009510_n306TipAbr[0];
            A158ZonCod = P009510_A158ZonCod[0];
            n158ZonCod = P009510_n158ZonCod[0];
            A142DisCod = P009510_A142DisCod[0];
            n142DisCod = P009510_n142DisCod[0];
            AV58Vendedor = 0;
            AV14Cliente = StringUtil.Trim( A188CCCliCod) + " - " + StringUtil.Trim( A189CCCliDsc);
            H950( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Cliente, "")), 8, Gx_line+4, 612, Gx_line+19, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            AV51TotImporte = 0.00m;
            AV53TotPagos = 0.00m;
            AV55TotSaldo = 0.00m;
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P009510_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK9514 = false;
               A511TipSigno = P009510_A511TipSigno[0];
               n511TipSigno = P009510_n511TipSigno[0];
               A513CCImpTotal = P009510_A513CCImpTotal[0];
               A509CCImpPago = P009510_A509CCImpPago[0];
               A508CCFVcto = P009510_A508CCFVcto[0];
               A187CCmonCod = P009510_A187CCmonCod[0];
               A1234MonDsc = P009510_A1234MonDsc[0];
               n1234MonDsc = P009510_n1234MonDsc[0];
               A185CCDocNum = P009510_A185CCDocNum[0];
               A306TipAbr = P009510_A306TipAbr[0];
               n306TipAbr = P009510_n306TipAbr[0];
               A190CCFech = P009510_A190CCFech[0];
               A184CCTipCod = P009510_A184CCTipCod[0];
               A1234MonDsc = P009510_A1234MonDsc[0];
               n1234MonDsc = P009510_n1234MonDsc[0];
               A511TipSigno = P009510_A511TipSigno[0];
               n511TipSigno = P009510_n511TipSigno[0];
               A306TipAbr = P009510_A306TipAbr[0];
               n306TipAbr = P009510_n306TipAbr[0];
               AV35Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV40Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV42Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV17Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               AV51TotImporte = (decimal)(AV51TotImporte+AV35Importe);
               AV53TotPagos = (decimal)(AV53TotPagos+AV40Pagos);
               AV55TotSaldo = (decimal)(AV55TotSaldo+AV42Saldo);
               AV47TotalMN = (decimal)(AV47TotalMN+(((A187CCmonCod==1) ? AV42Saldo : (decimal)(0))));
               AV46TotalME = (decimal)(AV46TotalME+(((A187CCmonCod==2) ? AV42Saldo : (decimal)(0))));
               H950( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 13, Gx_line+2, 52, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A185CCDocNum, "")), 75, Gx_line+2, 165, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A190CCFech, "99/99/99"), 171, Gx_line+2, 228, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A508CCFVcto, "99/99/99"), 247, Gx_line+2, 304, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 394, Gx_line+2, 451, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35Importe, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+2, 566, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Pagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+2, 675, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42Saldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+2, 779, Gx_line+17, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Dias), "ZZZZ9")), 308, Gx_line+2, 365, Gx_line+17, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               BRK9514 = true;
               pr_default.readNext(8);
            }
            H950( false, 24) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51TotImporte, "ZZZZZZ,ZZZ,ZZ9.99")), 469, Gx_line+6, 566, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TotPagos, "ZZZZZZ,ZZZ,ZZ9.99")), 570, Gx_line+6, 675, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TotSaldo, "ZZZZZZ,ZZZ,ZZ9.99")), 674, Gx_line+6, 779, Gx_line+21, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(466, Gx_line+1, 788, Gx_line+1, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total Cliente", 349, Gx_line+6, 424, Gx_line+20, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+24);
            AV48TotGImporte = (decimal)(AV48TotGImporte+AV51TotImporte);
            AV49TotGPagos = (decimal)(AV49TotGPagos+AV53TotPagos);
            AV50TotGSaldo = (decimal)(AV50TotGSaldo+AV55TotSaldo);
            AV52TotImpVend = (decimal)(AV52TotImpVend+AV51TotImporte);
            AV54TotPagoVend = (decimal)(AV54TotPagoVend+AV53TotPagos);
            AV56TotSaldoVend = (decimal)(AV56TotSaldoVend+AV55TotSaldo);
            if ( ! BRK9514 )
            {
               BRK9514 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S1313( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P009511 */
         pr_default.execute(9, new Object[] {AV12CCTipCod, AV10CCDocNum, AV25FHasta});
         while ( (pr_default.getStatus(9) != 101) )
         {
            A166CobTip = P009511_A166CobTip[0];
            A167CobCod = P009511_A167CobCod[0];
            A661CobSts = P009511_A661CobSts[0];
            A655CobFec = P009511_A655CobFec[0];
            A176CobDocNum = P009511_A176CobDocNum[0];
            A175CobTipCod = P009511_A175CobTipCod[0];
            A172CobMon = P009511_A172CobMon[0];
            A654CobDTot = P009511_A654CobDTot[0];
            A663CobTipCam = P009511_A663CobTipCam[0];
            A173Item = P009511_A173Item[0];
            A661CobSts = P009511_A661CobSts[0];
            A655CobFec = P009511_A655CobFec[0];
            A172CobMon = P009511_A172CobMon[0];
            AV16CobMon = A172CobMon;
            AV15CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV15CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV15CobDtot = (decimal)(AV15CobDtot*-1);
            }
            if ( AV11CCmonCod == AV16CobMon )
            {
               AV40Pagos = (decimal)(AV40Pagos-AV15CobDtot);
            }
            else
            {
               if ( AV11CCmonCod == 1 )
               {
                  AV40Pagos = (decimal)(AV40Pagos-(NumberUtil.Round( AV15CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV40Pagos = (decimal)(AV40Pagos-(NumberUtil.Round( AV15CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(9);
         }
         pr_default.close(9);
      }

      protected void S1212( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV31Flag = 0;
         pr_default.dynParam(10, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV37MonCod ,
                                              AV45TipCod ,
                                              A188CCCliCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A190CCFech ,
                                              AV25FHasta ,
                                              A158ZonCod ,
                                              AV59Zona ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P009512 */
         pr_default.execute(10, new Object[] {AV25FHasta, AV59Zona, AV13CliCod, AV37MonCod, AV45TipCod});
         while ( (pr_default.getStatus(10) != 101) )
         {
            A506CCEstado = P009512_A506CCEstado[0];
            A190CCFech = P009512_A190CCFech[0];
            A158ZonCod = P009512_A158ZonCod[0];
            n158ZonCod = P009512_n158ZonCod[0];
            A184CCTipCod = P009512_A184CCTipCod[0];
            A187CCmonCod = P009512_A187CCmonCod[0];
            A188CCCliCod = P009512_A188CCCliCod[0];
            A513CCImpTotal = P009512_A513CCImpTotal[0];
            A509CCImpPago = P009512_A509CCImpPago[0];
            A511TipSigno = P009512_A511TipSigno[0];
            n511TipSigno = P009512_n511TipSigno[0];
            A508CCFVcto = P009512_A508CCFVcto[0];
            A185CCDocNum = P009512_A185CCDocNum[0];
            A511TipSigno = P009512_A511TipSigno[0];
            n511TipSigno = P009512_n511TipSigno[0];
            A158ZonCod = P009512_A158ZonCod[0];
            n158ZonCod = P009512_n158ZonCod[0];
            AV12CCTipCod = A184CCTipCod;
            AV10CCDocNum = A185CCDocNum;
            AV35Importe = A513CCImpTotal;
            AV40Pagos = A509CCImpPago;
            AV11CCmonCod = A187CCmonCod;
            /* Execute user subroutine: 'PAGOS' */
            S1313 ();
            if ( returnInSub )
            {
               pr_default.close(10);
               returnInSub = true;
               if (true) return;
            }
            AV42Saldo = (decimal)((AV35Importe-AV40Pagos)*A511TipSigno);
            AV17Dias = (int)(DateTimeUtil.DDiff(A508CCFVcto,DateTimeUtil.Today( context)));
            AV51TotImporte = (decimal)(AV51TotImporte+AV35Importe);
            AV53TotPagos = (decimal)(AV53TotPagos+AV40Pagos);
            AV55TotSaldo = (decimal)(AV55TotSaldo+AV42Saldo);
            if ( ( AV42Saldo != Convert.ToDecimal( 0 )) )
            {
               AV31Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(10);
         }
         pr_default.close(10);
      }

      protected void H950( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 675, Gx_line+29, 707, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 675, Gx_line+46, 719, Gx_line+60, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 675, Gx_line+13, 714, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 740, Gx_line+46, 779, Gx_line+61, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 708, Gx_line+29, 777, Gx_line+43, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 731, Gx_line+13, 778, Gx_line+28, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+246, 37, Gx_line+260, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 71, Gx_line+247, 156, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Dias Vcto", 324, Gx_line+247, 379, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 395, Gx_line+247, 443, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe Total", 473, Gx_line+247, 556, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+240, 797, Gx_line+266, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Cuentas por Cobrar por Zonas", 263, Gx_line+70, 517, Gx_line+90, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 174, Gx_line+247, 209, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Vcto", 236, Gx_line+247, 301, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo", 719, Gx_line+247, 752, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 616, Gx_line+247, 646, Gx_line+261, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Documento", 119, Gx_line+108, 234, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Zona", 119, Gx_line+130, 149, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 119, Gx_line+152, 167, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Estado", 119, Gx_line+174, 160, Gx_line+188, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 119, Gx_line+195, 161, Gx_line+209, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro2, "")), 253, Gx_line+125, 596, Gx_line+149, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro3, "")), 253, Gx_line+147, 596, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Filtro4, "")), 253, Gx_line+169, 596, Gx_line+193, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Filtro5, "")), 253, Gx_line+190, 596, Gx_line+214, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20EmpDir, "")), 19, Gx_line+29, 404, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22EmpRUC, "")), 19, Gx_line+46, 404, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Empresa, "")), 19, Gx_line+11, 404, Gx_line+29, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+266);
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
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV43Session = context.GetSession();
         AV20EmpDir = "";
         AV22EmpRUC = "";
         AV41Ruta = "";
         AV36Logo = "";
         AV63Logo_GXI = "";
         AV26Filtro1 = "";
         AV27Filtro2 = "";
         AV28Filtro3 = "";
         AV29Filtro4 = "";
         AV30Filtro5 = "";
         scmdbuf = "";
         P00952_A149TipCod = new string[] {""} ;
         P00952_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00953_A158ZonCod = new int[1] ;
         P00953_n158ZonCod = new bool[] {false} ;
         P00953_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         P00954_A180MonCod = new int[1] ;
         P00954_A1234MonDsc = new string[] {""} ;
         P00954_n1234MonDsc = new bool[] {false} ;
         A1234MonDsc = "";
         AV24EstCod = "";
         P00955_A140EstCod = new string[] {""} ;
         P00955_A602EstDsc = new string[] {""} ;
         P00955_A139PaiCod = new string[] {""} ;
         A140EstCod = "";
         A602EstDsc = "";
         A139PaiCod = "";
         P00956_A45CliCod = new string[] {""} ;
         P00956_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         A142DisCod = "";
         A506CCEstado = "";
         P00957_A188CCCliCod = new string[] {""} ;
         P00957_A506CCEstado = new string[] {""} ;
         P00957_A2094ZonDsc = new string[] {""} ;
         P00957_A158ZonCod = new int[1] ;
         P00957_n158ZonCod = new bool[] {false} ;
         P00957_A142DisCod = new string[] {""} ;
         P00957_n142DisCod = new bool[] {false} ;
         P00957_A189CCCliDsc = new string[] {""} ;
         P00957_A184CCTipCod = new string[] {""} ;
         P00957_A185CCDocNum = new string[] {""} ;
         A188CCCliCod = "";
         A189CCCliDsc = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         P00958_A188CCCliCod = new string[] {""} ;
         P00958_A2094ZonDsc = new string[] {""} ;
         P00958_A158ZonCod = new int[1] ;
         P00958_n158ZonCod = new bool[] {false} ;
         P00958_A142DisCod = new string[] {""} ;
         P00958_n142DisCod = new bool[] {false} ;
         P00958_A189CCCliDsc = new string[] {""} ;
         P00958_A184CCTipCod = new string[] {""} ;
         P00958_A185CCDocNum = new string[] {""} ;
         AV18DisCod = "";
         A190CCFech = DateTime.MinValue;
         P00959_A189CCCliDsc = new string[] {""} ;
         P00959_A185CCDocNum = new string[] {""} ;
         P00959_A511TipSigno = new short[1] ;
         P00959_n511TipSigno = new bool[] {false} ;
         P00959_A513CCImpTotal = new decimal[1] ;
         P00959_A509CCImpPago = new decimal[1] ;
         P00959_A187CCmonCod = new int[1] ;
         P00959_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00959_A1234MonDsc = new string[] {""} ;
         P00959_n1234MonDsc = new bool[] {false} ;
         P00959_A306TipAbr = new string[] {""} ;
         P00959_n306TipAbr = new bool[] {false} ;
         P00959_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00959_A184CCTipCod = new string[] {""} ;
         P00959_A506CCEstado = new string[] {""} ;
         P00959_A158ZonCod = new int[1] ;
         P00959_n158ZonCod = new bool[] {false} ;
         P00959_A142DisCod = new string[] {""} ;
         P00959_n142DisCod = new bool[] {false} ;
         P00959_A188CCCliCod = new string[] {""} ;
         A508CCFVcto = DateTime.MinValue;
         A306TipAbr = "";
         AV14Cliente = "";
         AV12CCTipCod = "";
         AV10CCDocNum = "";
         P009510_A189CCCliDsc = new string[] {""} ;
         P009510_A511TipSigno = new short[1] ;
         P009510_n511TipSigno = new bool[] {false} ;
         P009510_A513CCImpTotal = new decimal[1] ;
         P009510_A509CCImpPago = new decimal[1] ;
         P009510_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P009510_A187CCmonCod = new int[1] ;
         P009510_A1234MonDsc = new string[] {""} ;
         P009510_n1234MonDsc = new bool[] {false} ;
         P009510_A185CCDocNum = new string[] {""} ;
         P009510_A306TipAbr = new string[] {""} ;
         P009510_n306TipAbr = new bool[] {false} ;
         P009510_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009510_A184CCTipCod = new string[] {""} ;
         P009510_A506CCEstado = new string[] {""} ;
         P009510_A158ZonCod = new int[1] ;
         P009510_n158ZonCod = new bool[] {false} ;
         P009510_A142DisCod = new string[] {""} ;
         P009510_n142DisCod = new bool[] {false} ;
         P009510_A188CCCliCod = new string[] {""} ;
         P009511_A166CobTip = new string[] {""} ;
         P009511_A167CobCod = new string[] {""} ;
         P009511_A661CobSts = new string[] {""} ;
         P009511_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P009511_A176CobDocNum = new string[] {""} ;
         P009511_A175CobTipCod = new string[] {""} ;
         P009511_A172CobMon = new int[1] ;
         P009511_A654CobDTot = new decimal[1] ;
         P009511_A663CobTipCam = new decimal[1] ;
         P009511_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         P009512_A506CCEstado = new string[] {""} ;
         P009512_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P009512_A158ZonCod = new int[1] ;
         P009512_n158ZonCod = new bool[] {false} ;
         P009512_A184CCTipCod = new string[] {""} ;
         P009512_A187CCmonCod = new int[1] ;
         P009512_A188CCCliCod = new string[] {""} ;
         P009512_A513CCImpTotal = new decimal[1] ;
         P009512_A509CCImpPago = new decimal[1] ;
         P009512_A511TipSigno = new short[1] ;
         P009512_n511TipSigno = new bool[] {false} ;
         P009512_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P009512_A185CCDocNum = new string[] {""} ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrcuentasxcobrarzonas__default(),
            new Object[][] {
                new Object[] {
               P00952_A149TipCod, P00952_A1910TipDsc
               }
               , new Object[] {
               P00953_A158ZonCod, P00953_A2094ZonDsc
               }
               , new Object[] {
               P00954_A180MonCod, P00954_A1234MonDsc
               }
               , new Object[] {
               P00955_A140EstCod, P00955_A602EstDsc, P00955_A139PaiCod
               }
               , new Object[] {
               P00956_A45CliCod, P00956_A161CliDsc
               }
               , new Object[] {
               P00957_A188CCCliCod, P00957_A506CCEstado, P00957_A2094ZonDsc, P00957_A158ZonCod, P00957_n158ZonCod, P00957_A142DisCod, P00957_n142DisCod, P00957_A189CCCliDsc, P00957_A184CCTipCod, P00957_A185CCDocNum
               }
               , new Object[] {
               P00958_A188CCCliCod, P00958_A2094ZonDsc, P00958_A158ZonCod, P00958_n158ZonCod, P00958_A142DisCod, P00958_n142DisCod, P00958_A189CCCliDsc, P00958_A184CCTipCod, P00958_A185CCDocNum
               }
               , new Object[] {
               P00959_A189CCCliDsc, P00959_A185CCDocNum, P00959_A511TipSigno, P00959_n511TipSigno, P00959_A513CCImpTotal, P00959_A509CCImpPago, P00959_A187CCmonCod, P00959_A508CCFVcto, P00959_A1234MonDsc, P00959_n1234MonDsc,
               P00959_A306TipAbr, P00959_n306TipAbr, P00959_A190CCFech, P00959_A184CCTipCod, P00959_A506CCEstado, P00959_A158ZonCod, P00959_n158ZonCod, P00959_A142DisCod, P00959_n142DisCod, P00959_A188CCCliCod
               }
               , new Object[] {
               P009510_A189CCCliDsc, P009510_A511TipSigno, P009510_n511TipSigno, P009510_A513CCImpTotal, P009510_A509CCImpPago, P009510_A508CCFVcto, P009510_A187CCmonCod, P009510_A1234MonDsc, P009510_n1234MonDsc, P009510_A185CCDocNum,
               P009510_A306TipAbr, P009510_n306TipAbr, P009510_A190CCFech, P009510_A184CCTipCod, P009510_A506CCEstado, P009510_A158ZonCod, P009510_n158ZonCod, P009510_A142DisCod, P009510_n142DisCod, P009510_A188CCCliCod
               }
               , new Object[] {
               P009511_A166CobTip, P009511_A167CobCod, P009511_A661CobSts, P009511_A655CobFec, P009511_A176CobDocNum, P009511_A175CobTipCod, P009511_A172CobMon, P009511_A654CobDTot, P009511_A663CobTipCam, P009511_A173Item
               }
               , new Object[] {
               P009512_A506CCEstado, P009512_A190CCFech, P009512_A158ZonCod, P009512_n158ZonCod, P009512_A184CCTipCod, P009512_A187CCmonCod, P009512_A188CCCliCod, P009512_A513CCImpTotal, P009512_A509CCImpPago, P009512_A511TipSigno,
               P009512_n511TipSigno, P009512_A508CCFVcto, P009512_A185CCDocNum
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
      private short AV8Agrupa ;
      private short AV32FlaVend ;
      private short AV31Flag ;
      private short A511TipSigno ;
      private int AV37MonCod ;
      private int AV60ZonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A158ZonCod ;
      private int A180MonCod ;
      private int AV59Zona ;
      private int Gx_OldLine ;
      private int A187CCmonCod ;
      private int AV58Vendedor ;
      private int AV11CCmonCod ;
      private int AV17Dias ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV16CobMon ;
      private decimal AV48TotGImporte ;
      private decimal AV49TotGPagos ;
      private decimal AV50TotGSaldo ;
      private decimal AV46TotalME ;
      private decimal AV47TotalMN ;
      private decimal AV52TotImpVend ;
      private decimal AV54TotPagoVend ;
      private decimal AV56TotSaldoVend ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV51TotImporte ;
      private decimal AV53TotPagos ;
      private decimal AV55TotSaldo ;
      private decimal AV35Importe ;
      private decimal AV40Pagos ;
      private decimal AV42Saldo ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV15CobDtot ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV45TipCod ;
      private string AV13CliCod ;
      private string AV19DisCod2 ;
      private string AV21Empresa ;
      private string AV20EmpDir ;
      private string AV22EmpRUC ;
      private string AV41Ruta ;
      private string AV26Filtro1 ;
      private string AV27Filtro2 ;
      private string AV28Filtro3 ;
      private string AV29Filtro4 ;
      private string AV30Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A2094ZonDsc ;
      private string A1234MonDsc ;
      private string AV24EstCod ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A142DisCod ;
      private string A506CCEstado ;
      private string A188CCCliCod ;
      private string A189CCCliDsc ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string AV18DisCod ;
      private string A306TipAbr ;
      private string AV12CCTipCod ;
      private string AV10CCDocNum ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string Gx_time ;
      private DateTime AV25FHasta ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime A655CobFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n158ZonCod ;
      private bool n1234MonDsc ;
      private bool BRK958 ;
      private bool n142DisCod ;
      private bool returnInSub ;
      private bool BRK9510 ;
      private bool BRK9512 ;
      private bool n511TipSigno ;
      private bool n306TipAbr ;
      private bool BRK9514 ;
      private string AV63Logo_GXI ;
      private string AV14Cliente ;
      private string AV36Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_TipCod ;
      private string aP1_CliCod ;
      private int aP2_MonCod ;
      private int aP3_ZonCod ;
      private short aP4_Agrupa ;
      private string aP5_DisCod2 ;
      private DateTime aP6_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00952_A149TipCod ;
      private string[] P00952_A1910TipDsc ;
      private int[] P00953_A158ZonCod ;
      private bool[] P00953_n158ZonCod ;
      private string[] P00953_A2094ZonDsc ;
      private int[] P00954_A180MonCod ;
      private string[] P00954_A1234MonDsc ;
      private bool[] P00954_n1234MonDsc ;
      private string[] P00955_A140EstCod ;
      private string[] P00955_A602EstDsc ;
      private string[] P00955_A139PaiCod ;
      private string[] P00956_A45CliCod ;
      private string[] P00956_A161CliDsc ;
      private string[] P00957_A188CCCliCod ;
      private string[] P00957_A506CCEstado ;
      private string[] P00957_A2094ZonDsc ;
      private int[] P00957_A158ZonCod ;
      private bool[] P00957_n158ZonCod ;
      private string[] P00957_A142DisCod ;
      private bool[] P00957_n142DisCod ;
      private string[] P00957_A189CCCliDsc ;
      private string[] P00957_A184CCTipCod ;
      private string[] P00957_A185CCDocNum ;
      private string[] P00958_A188CCCliCod ;
      private string[] P00958_A2094ZonDsc ;
      private int[] P00958_A158ZonCod ;
      private bool[] P00958_n158ZonCod ;
      private string[] P00958_A142DisCod ;
      private bool[] P00958_n142DisCod ;
      private string[] P00958_A189CCCliDsc ;
      private string[] P00958_A184CCTipCod ;
      private string[] P00958_A185CCDocNum ;
      private string[] P00959_A189CCCliDsc ;
      private string[] P00959_A185CCDocNum ;
      private short[] P00959_A511TipSigno ;
      private bool[] P00959_n511TipSigno ;
      private decimal[] P00959_A513CCImpTotal ;
      private decimal[] P00959_A509CCImpPago ;
      private int[] P00959_A187CCmonCod ;
      private DateTime[] P00959_A508CCFVcto ;
      private string[] P00959_A1234MonDsc ;
      private bool[] P00959_n1234MonDsc ;
      private string[] P00959_A306TipAbr ;
      private bool[] P00959_n306TipAbr ;
      private DateTime[] P00959_A190CCFech ;
      private string[] P00959_A184CCTipCod ;
      private string[] P00959_A506CCEstado ;
      private int[] P00959_A158ZonCod ;
      private bool[] P00959_n158ZonCod ;
      private string[] P00959_A142DisCod ;
      private bool[] P00959_n142DisCod ;
      private string[] P00959_A188CCCliCod ;
      private string[] P009510_A189CCCliDsc ;
      private short[] P009510_A511TipSigno ;
      private bool[] P009510_n511TipSigno ;
      private decimal[] P009510_A513CCImpTotal ;
      private decimal[] P009510_A509CCImpPago ;
      private DateTime[] P009510_A508CCFVcto ;
      private int[] P009510_A187CCmonCod ;
      private string[] P009510_A1234MonDsc ;
      private bool[] P009510_n1234MonDsc ;
      private string[] P009510_A185CCDocNum ;
      private string[] P009510_A306TipAbr ;
      private bool[] P009510_n306TipAbr ;
      private DateTime[] P009510_A190CCFech ;
      private string[] P009510_A184CCTipCod ;
      private string[] P009510_A506CCEstado ;
      private int[] P009510_A158ZonCod ;
      private bool[] P009510_n158ZonCod ;
      private string[] P009510_A142DisCod ;
      private bool[] P009510_n142DisCod ;
      private string[] P009510_A188CCCliCod ;
      private string[] P009511_A166CobTip ;
      private string[] P009511_A167CobCod ;
      private string[] P009511_A661CobSts ;
      private DateTime[] P009511_A655CobFec ;
      private string[] P009511_A176CobDocNum ;
      private string[] P009511_A175CobTipCod ;
      private int[] P009511_A172CobMon ;
      private decimal[] P009511_A654CobDTot ;
      private decimal[] P009511_A663CobTipCam ;
      private int[] P009511_A173Item ;
      private string[] P009512_A506CCEstado ;
      private DateTime[] P009512_A190CCFech ;
      private int[] P009512_A158ZonCod ;
      private bool[] P009512_n158ZonCod ;
      private string[] P009512_A184CCTipCod ;
      private int[] P009512_A187CCmonCod ;
      private string[] P009512_A188CCCliCod ;
      private decimal[] P009512_A513CCImpTotal ;
      private decimal[] P009512_A509CCImpPago ;
      private short[] P009512_A511TipSigno ;
      private bool[] P009512_n511TipSigno ;
      private DateTime[] P009512_A508CCFVcto ;
      private string[] P009512_A185CCDocNum ;
   }

   public class rrcuentasxcobrarzonas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00957( IGxContext context ,
                                             int AV60ZonCod ,
                                             string AV19DisCod2 ,
                                             int A158ZonCod ,
                                             string A142DisCod ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T1.[CCEstado], T3.[ZonDsc], T2.[ZonCod], T2.[DisCod], T1.[CCCliDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CZONAS] T3 ON T3.[ZonCod] = T2.[ZonCod])";
         AddWhere(sWhereString, "(T2.[ZonCod] <> 0)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! (0==AV60ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV60ZonCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19DisCod2)) )
         {
            AddWhere(sWhereString, "(T2.[DisCod] = @AV19DisCod2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ZonCod], T3.[ZonDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00958( IGxContext context ,
                                             int AV60ZonCod ,
                                             string AV19DisCod2 ,
                                             int A158ZonCod ,
                                             string A142DisCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliCod] AS CCCliCod, T3.[ZonDsc], T2.[ZonCod], T2.[DisCod], T1.[CCCliDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCDocNum] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CZONAS] T3 ON T3.[ZonCod] = T2.[ZonCod])";
         if ( ! (0==AV60ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV60ZonCod)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19DisCod2)) )
         {
            AddWhere(sWhereString, "(T2.[DisCod] = @AV19DisCod2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ZonCod], T3.[ZonDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00959( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV37MonCod ,
                                             string AV45TipCod ,
                                             string AV18DisCod ,
                                             string A188CCCliCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             string A142DisCod ,
                                             DateTime A190CCFech ,
                                             DateTime AV25FHasta ,
                                             string A506CCEstado ,
                                             int A158ZonCod ,
                                             int AV59Zona )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[6];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T1.[CCDocNum], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T1.[CCFVcto], T2.[MonDsc], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T4.[ZonCod], T4.[DisCod], T1.[CCCliCod] AS CCCliCod FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV25FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T4.[ZonCod] = @AV59Zona)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV37MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV37MonCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18DisCod)) )
         {
            AddWhere(sWhereString, "(T4.[DisCod] = @AV18DisCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech] DESC";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P009510( IGxContext context ,
                                              string AV13CliCod ,
                                              int AV37MonCod ,
                                              string AV18DisCod ,
                                              string AV45TipCod ,
                                              string A188CCCliCod ,
                                              int A187CCmonCod ,
                                              string A142DisCod ,
                                              string A184CCTipCod ,
                                              int A158ZonCod ,
                                              int AV59Zona ,
                                              string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[5];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[CCCliDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCFVcto], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T1.[CCDocNum], T3.[TipAbr], T1.[CCFech], T1.[CCTipCod] AS CCTipCod, T1.[CCEstado], T4.[ZonCod], T4.[DisCod], T1.[CCCliCod] AS CCCliCod FROM ((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T4.[ZonCod] = @AV59Zona)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV37MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV37MonCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18DisCod)) )
         {
            AddWhere(sWhereString, "(T4.[DisCod] = @AV18DisCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCTipCod], T1.[CCFech] DESC";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P009512( IGxContext context ,
                                              string AV13CliCod ,
                                              int AV37MonCod ,
                                              string AV45TipCod ,
                                              string A188CCCliCod ,
                                              int A187CCmonCod ,
                                              string A184CCTipCod ,
                                              DateTime A190CCFech ,
                                              DateTime AV25FHasta ,
                                              int A158ZonCod ,
                                              int AV59Zona ,
                                              string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[5];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CCEstado], T1.[CCFech], T3.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T1.[CCCliCod] AS CCCliCod, T1.[CCImpTotal], T1.[CCImpPago], T2.[TipSigno], T1.[CCFVcto], T1.[CCDocNum] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV25FHasta)");
         AddWhere(sWhereString, "(T3.[ZonCod] = @AV59Zona)");
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ! (0==AV37MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV37MonCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV45TipCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCDocNum]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 5 :
                     return conditional_P00957(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] );
               case 6 :
                     return conditional_P00958(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] );
               case 7 :
                     return conditional_P00959(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
               case 8 :
                     return conditional_P009510(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] );
               case 10 :
                     return conditional_P009512(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00952;
          prmP00952 = new Object[] {
          new ParDef("@AV45TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00953;
          prmP00953 = new Object[] {
          new ParDef("@AV60ZonCod",GXType.Int32,6,0)
          };
          Object[] prmP00954;
          prmP00954 = new Object[] {
          new ParDef("@AV37MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00955;
          prmP00955 = new Object[] {
          new ParDef("@AV24EstCod",GXType.NChar,4,0)
          };
          Object[] prmP00956;
          prmP00956 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0)
          };
          Object[] prmP009511;
          prmP009511 = new Object[] {
          new ParDef("@AV12CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV10CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV25FHasta",GXType.Date,8,0)
          };
          Object[] prmP00957;
          prmP00957 = new Object[] {
          new ParDef("@AV60ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV19DisCod2",GXType.NChar,4,0)
          };
          Object[] prmP00958;
          prmP00958 = new Object[] {
          new ParDef("@AV60ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV19DisCod2",GXType.NChar,4,0)
          };
          Object[] prmP00959;
          prmP00959 = new Object[] {
          new ParDef("@AV25FHasta",GXType.Date,8,0) ,
          new ParDef("@AV59Zona",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV37MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV18DisCod",GXType.NChar,4,0)
          };
          Object[] prmP009510;
          prmP009510 = new Object[] {
          new ParDef("@AV59Zona",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV37MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV18DisCod",GXType.NChar,4,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0)
          };
          Object[] prmP009512;
          prmP009512 = new Object[] {
          new ParDef("@AV25FHasta",GXType.Date,8,0) ,
          new ParDef("@AV59Zona",GXType.Int32,6,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV37MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV45TipCod",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00952", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV45TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00952,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00953", "SELECT [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV60ZonCod ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00953,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00954", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV37MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00954,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00955", "SELECT [EstCod], [EstDsc], [PaiCod] FROM [CESTADOS] WHERE [EstCod] = @AV24EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00955,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00956", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV13CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00956,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00957", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00957,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00958", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00958,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00959", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00959,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009510", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009510,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009511", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV12CCTipCod and T1.[CobDocNum] = @AV10CCDocNum) AND (T2.[CobFec] > @AV25FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009511,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009512", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009512,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 4);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 100);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 100);
                ((string[]) buf[7])[0] = rslt.getString(6, 3);
                ((string[]) buf[8])[0] = rslt.getString(7, 12);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((string[]) buf[17])[0] = rslt.getString(14, 4);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((string[]) buf[19])[0] = rslt.getString(15, 20);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((string[]) buf[14])[0] = rslt.getString(12, 1);
                ((int[]) buf[15])[0] = rslt.getInt(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((string[]) buf[17])[0] = rslt.getString(14, 4);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((string[]) buf[19])[0] = rslt.getString(15, 20);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 12);
                return;
       }
    }

 }

}
