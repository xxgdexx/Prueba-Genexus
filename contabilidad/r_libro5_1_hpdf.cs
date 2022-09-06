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
   public class r_libro5_1_hpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_libro5_1_hpdf.aspx")), "contabilidad.r_libro5_1_hpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_libro5_1_hpdf.aspx")))) ;
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
               AV11Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
                  AV31TASICod = (int)(NumberUtil.Val( GetPar( "TASICod"), "."));
                  AV34cCuenta1 = GetPar( "cCuenta1");
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

      public r_libro5_1_hpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_libro5_1_hpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref int aP2_TASICod ,
                           ref string aP3_cCuenta1 )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV31TASICod = aP2_TASICod;
         this.AV34cCuenta1 = aP3_cCuenta1;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_TASICod=this.AV31TASICod;
         aP3_cCuenta1=this.AV34cCuenta1;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref int aP2_TASICod )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_TASICod, ref aP3_cCuenta1);
         return AV34cCuenta1 ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref int aP2_TASICod ,
                                 ref string aP3_cCuenta1 )
      {
         r_libro5_1_hpdf objr_libro5_1_hpdf;
         objr_libro5_1_hpdf = new r_libro5_1_hpdf();
         objr_libro5_1_hpdf.AV11Ano = aP0_Ano;
         objr_libro5_1_hpdf.AV12Mes = aP1_Mes;
         objr_libro5_1_hpdf.AV31TASICod = aP2_TASICod;
         objr_libro5_1_hpdf.AV34cCuenta1 = aP3_cCuenta1;
         objr_libro5_1_hpdf.context.SetSubmitInitialConfig(context);
         objr_libro5_1_hpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_libro5_1_hpdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_TASICod=this.AV31TASICod;
         aP3_cCuenta1=this.AV34cCuenta1;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_libro5_1_hpdf)stateInfo).executePrivate();
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
         M_bot = 2;
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
            P_lines = (int)(gxYPage-(lineHeight*2));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            AV27Empresa = AV30Session.Get("Empresa");
            AV28EmpDir = AV30Session.Get("EmpDir");
            AV52EmpRUC = AV30Session.Get("EmpRUC");
            AV54Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV53Logo = AV54Ruta;
            AV62Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV13Titulo = "FORMATO 5.1: LIBRO DIARIO";
            AV14Periodo = StringUtil.Upper( AV50cMes) + " - " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV47TDebeMO = 0.00m;
            AV48ThaberMO = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31TASICod ,
                                                 A126TASICod ,
                                                 A2077VouSts ,
                                                 AV11Ano ,
                                                 AV12Mes ,
                                                 A127VouAno ,
                                                 A128VouMes } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00C82 */
            pr_default.execute(0, new Object[] {AV11Ano, AV12Mes, AV31TASICod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A126TASICod = P00C82_A126TASICod[0];
               A128VouMes = P00C82_A128VouMes[0];
               A127VouAno = P00C82_A127VouAno[0];
               A129VouNum = P00C82_A129VouNum[0];
               A1894TASIAbr = P00C82_A1894TASIAbr[0];
               A2075VouGls = P00C82_A2075VouGls[0];
               A2256TASISunat = P00C82_A2256TASISunat[0];
               A2077VouSts = P00C82_A2077VouSts[0];
               A1894TASIAbr = P00C82_A1894TASIAbr[0];
               A2256TASISunat = P00C82_A2256TASISunat[0];
               AV22TDebe = 0.00m;
               AV23THaber = 0.00m;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV34cCuenta1 ,
                                                    A91CueCod ,
                                                    A127VouAno ,
                                                    A128VouMes ,
                                                    A126TASICod ,
                                                    A129VouNum } ,
                                                    new int[]{
                                                    TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT
                                                    }
               });
               /* Using cursor P00C83 */
               pr_default.execute(1, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, AV34cCuenta1});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A91CueCod = P00C83_A91CueCod[0];
                  A2054VouDGls = P00C83_A2054VouDGls[0];
                  A860CueDsc = P00C83_A860CueDsc[0];
                  A2053VouDDoc = P00C83_A2053VouDDoc[0];
                  A2055VouDHab = P00C83_A2055VouDHab[0];
                  A2051VouDDeb = P00C83_A2051VouDDeb[0];
                  A136VouReg = P00C83_A136VouReg[0];
                  A135VouDFec = P00C83_A135VouDFec[0];
                  A130VouDSec = P00C83_A130VouDSec[0];
                  A860CueDsc = P00C83_A860CueDsc[0];
                  AV59VouReg = StringUtil.Trim( A1894TASIAbr) + "-" + StringUtil.Trim( A129VouNum);
                  AV49Glosa = (String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) ? StringUtil.Trim( A2075VouGls) : StringUtil.Trim( A2054VouDGls));
                  HC80( false, 11) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 142, Gx_line+0, 174, Gx_line+11, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 920, Gx_line+0, 984, Gx_line+11, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 1002, Gx_line+0, 1066, Gx_line+11, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Glosa, "")), 196, Gx_line+0, 453, Gx_line+11, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 578, Gx_line+0, 656, Gx_line+11, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59VouReg, "")), 42, Gx_line+0, 126, Gx_line+11, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A860CueDsc, "")), 724, Gx_line+0, 902, Gx_line+11, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 666, Gx_line+0, 716, Gx_line+11, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 508, Gx_line+0, 572, Gx_line+11, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2256TASISunat, "")), 464, Gx_line+0, 501, Gx_line+11, 1+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+11);
                  AV22TDebe = (decimal)(AV22TDebe+A2051VouDDeb);
                  AV23THaber = (decimal)(AV23THaber+A2055VouDHab);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               if ( ! (Convert.ToDecimal(0)==AV22TDebe) || ! (Convert.ToDecimal(0)==AV23THaber) )
               {
                  HC80( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Asiento :", 800, Gx_line+3, 859, Gx_line+13, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 911, Gx_line+3, 983, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 994, Gx_line+3, 1066, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(900, Gx_line+0, 1068, Gx_line+0, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
               AV47TDebeMO = (decimal)(AV47TDebeMO+AV22TDebe);
               AV48ThaberMO = (decimal)(AV48ThaberMO+AV23THaber);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HC80( false, 26) ;
            getPrinter().GxDrawLine(900, Gx_line+0, 1069, Gx_line+0, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General :", 800, Gx_line+6, 861, Gx_line+16, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 911, Gx_line+6, 983, Gx_line+17, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 994, Gx_line+6, 1066, Gx_line+17, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+26);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HC80( true, 0) ;
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

      protected void HC80( bool bFoot ,
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
               getPrinter().GxDrawText("P�gina:", 958, Gx_line+17, 1002, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1017, Gx_line+17, 1056, Gx_line+32, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 58, Gx_line+0, 372, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 125, Gx_line+17, 647, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 58, Gx_line+49, 509, Gx_line+63, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 125, Gx_line+33, 230, Gx_line+48, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("PERIODO:", 58, Gx_line+17, 114, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("RUC :", 58, Gx_line+33, 89, Gx_line+47, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+63);
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("C�digo", 674, Gx_line+19, 703, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Denominaci�n", 783, Gx_line+19, 843, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa o Descripci�n de la operaci�n", 242, Gx_line+11, 387, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(133, Gx_line+0, 133, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(657, Gx_line+0, 657, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("MOVIMIENTO", 965, Gx_line+2, 1023, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 151, Gx_line+1, 177, Gx_line+11, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(42, Gx_line+0, 1073, Gx_line+33, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Debe", 942, Gx_line+19, 965, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(458, Gx_line+13, 1072, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N�mero", 73, Gx_line+1, 107, Gx_line+11, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("del Registro", 65, Gx_line+22, 115, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(192, Gx_line+0, 192, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Operaci�n", 143, Gx_line+22, 186, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(908, Gx_line+0, 908, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(993, Gx_line+14, 993, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Haber", 1019, Gx_line+19, 1045, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("CUENTA CONTABLE ASOCIADA", 700, Gx_line+2, 825, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(721, Gx_line+14, 721, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N�mero de", 590, Gx_line+15, 637, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 589, Gx_line+23, 638, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(458, Gx_line+0, 458, Gx_line+33, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Correlativo", 67, Gx_line+12, 113, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de", 158, Gx_line+12, 169, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(571, Gx_line+14, 571, Gx_line+34, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(508, Gx_line+14, 508, Gx_line+34, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N�mero", 521, Gx_line+15, 555, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Correlativo", 518, Gx_line+23, 564, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 471, Gx_line+15, 500, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Libro", 476, Gx_line+23, 498, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("REFERENCIA DE LA OPERACION", 493, Gx_line+2, 626, Gx_line+12, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+34);
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
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV28EmpDir = "";
         AV52EmpRUC = "";
         AV54Ruta = "";
         AV53Logo = "";
         AV62Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         P00C82_A126TASICod = new int[1] ;
         P00C82_A128VouMes = new short[1] ;
         P00C82_A127VouAno = new short[1] ;
         P00C82_A129VouNum = new string[] {""} ;
         P00C82_A1894TASIAbr = new string[] {""} ;
         P00C82_A2075VouGls = new string[] {""} ;
         P00C82_A2256TASISunat = new string[] {""} ;
         P00C82_A2077VouSts = new short[1] ;
         A129VouNum = "";
         A1894TASIAbr = "";
         A2075VouGls = "";
         A2256TASISunat = "";
         A91CueCod = "";
         P00C83_A127VouAno = new short[1] ;
         P00C83_A128VouMes = new short[1] ;
         P00C83_A126TASICod = new int[1] ;
         P00C83_A129VouNum = new string[] {""} ;
         P00C83_A91CueCod = new string[] {""} ;
         P00C83_A2054VouDGls = new string[] {""} ;
         P00C83_A860CueDsc = new string[] {""} ;
         P00C83_A2053VouDDoc = new string[] {""} ;
         P00C83_A2055VouDHab = new decimal[1] ;
         P00C83_A2051VouDDeb = new decimal[1] ;
         P00C83_A136VouReg = new string[] {""} ;
         P00C83_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00C83_A130VouDSec = new int[1] ;
         A2054VouDGls = "";
         A860CueDsc = "";
         A2053VouDDoc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV59VouReg = "";
         AV49Glosa = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_libro5_1_hpdf__default(),
            new Object[][] {
                new Object[] {
               P00C82_A126TASICod, P00C82_A128VouMes, P00C82_A127VouAno, P00C82_A129VouNum, P00C82_A1894TASIAbr, P00C82_A2075VouGls, P00C82_A2256TASISunat, P00C82_A2077VouSts
               }
               , new Object[] {
               P00C83_A127VouAno, P00C83_A128VouMes, P00C83_A126TASICod, P00C83_A129VouNum, P00C83_A91CueCod, P00C83_A2054VouDGls, P00C83_A860CueDsc, P00C83_A2053VouDDoc, P00C83_A2055VouDHab, P00C83_A2051VouDDeb,
               P00C83_A136VouReg, P00C83_A135VouDFec, P00C83_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV11Ano ;
      private short AV12Mes ;
      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private int AV31TASICod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private int Gx_OldLine ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV34cCuenta1 ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV52EmpRUC ;
      private string AV54Ruta ;
      private string AV51FechaC ;
      private string AV50cMes ;
      private string GXt_char1 ;
      private string AV13Titulo ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A129VouNum ;
      private string A1894TASIAbr ;
      private string A2075VouGls ;
      private string A2256TASISunat ;
      private string A91CueCod ;
      private string A2054VouDGls ;
      private string A860CueDsc ;
      private string A2053VouDDoc ;
      private string A136VouReg ;
      private string AV59VouReg ;
      private string AV49Glosa ;
      private DateTime AV16FechaD ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string AV62Logo_GXI ;
      private string AV53Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private int aP2_TASICod ;
      private string aP3_cCuenta1 ;
      private IDataStoreProvider pr_default ;
      private int[] P00C82_A126TASICod ;
      private short[] P00C82_A128VouMes ;
      private short[] P00C82_A127VouAno ;
      private string[] P00C82_A129VouNum ;
      private string[] P00C82_A1894TASIAbr ;
      private string[] P00C82_A2075VouGls ;
      private string[] P00C82_A2256TASISunat ;
      private short[] P00C82_A2077VouSts ;
      private short[] P00C83_A127VouAno ;
      private short[] P00C83_A128VouMes ;
      private int[] P00C83_A126TASICod ;
      private string[] P00C83_A129VouNum ;
      private string[] P00C83_A91CueCod ;
      private string[] P00C83_A2054VouDGls ;
      private string[] P00C83_A860CueDsc ;
      private string[] P00C83_A2053VouDDoc ;
      private decimal[] P00C83_A2055VouDHab ;
      private decimal[] P00C83_A2051VouDDeb ;
      private string[] P00C83_A136VouReg ;
      private DateTime[] P00C83_A135VouDFec ;
      private int[] P00C83_A130VouDSec ;
   }

   public class r_libro5_1_hpdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00C82( IGxContext context ,
                                             int AV31TASICod ,
                                             int A126TASICod ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV12Mes ,
                                             short A127VouAno ,
                                             short A128VouMes )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[VouMes], T1.[VouAno], T1.[VouNum], T2.[TASIAbr], T1.[VouGls], T2.[TASISunat], T1.[VouSts] FROM ([CBVOUCHER] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV12Mes)");
         AddWhere(sWhereString, "(T1.[VouSts] = 1)");
         if ( ! (0==AV31TASICod) )
         {
            AddWhere(sWhereString, "(T1.[TASICod] = @AV31TASICod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00C83( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string A91CueCod ,
                                             short A127VouAno ,
                                             short A128VouMes ,
                                             int A126TASICod ,
                                             string A129VouNum )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[5];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCod], T1.[VouDGls], T2.[CueDsc], T1.[VouDDoc], T1.[VouDHab], T1.[VouDDeb], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @VouAno)");
         AddWhere(sWhereString, "(T1.[VouMes] = @VouMes)");
         AddWhere(sWhereString, "(T1.[TASICod] = @TASICod)");
         AddWhere(sWhereString, "(T1.[VouNum] = @VouNum)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV34cCuenta1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouDFec], T1.[VouReg]";
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
               case 0 :
                     return conditional_P00C82(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_P00C83(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00C82;
          prmP00C82 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV31TASICod",GXType.Int32,6,0)
          };
          Object[] prmP00C83;
          prmP00C83 = new Object[] {
          new ParDef("@VouAno",GXType.Int16,4,0) ,
          new ParDef("@VouMes",GXType.Int16,2,0) ,
          new ParDef("@TASICod",GXType.Int32,6,0) ,
          new ParDef("@VouNum",GXType.NChar,10,0) ,
          new ParDef("@AV34cCuenta1",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00C82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00C83", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00C83,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
