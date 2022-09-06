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
   public class r_analisiscuentaspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_analisiscuentaspdf.aspx")), "contabilidad.r_analisiscuentaspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_analisiscuentaspdf.aspx")))) ;
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
                  AV17FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV18Fhasta = context.localUtil.ParseDateParm( GetPar( "Fhasta"));
                  AV19CueCod1 = GetPar( "CueCod1");
                  AV20CueCod2 = GetPar( "CueCod2");
                  AV40cCueCodAux = GetPar( "cCueCodAux");
                  AV35Tipo = GetPar( "Tipo");
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

      public r_analisiscuentaspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_analisiscuentaspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_Fhasta ,
                           ref string aP4_CueCod1 ,
                           ref string aP5_CueCod2 ,
                           ref string aP6_cCueCodAux ,
                           ref string aP7_Tipo )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV17FDesde = aP2_FDesde;
         this.AV18Fhasta = aP3_Fhasta;
         this.AV19CueCod1 = aP4_CueCod1;
         this.AV20CueCod2 = aP5_CueCod2;
         this.AV40cCueCodAux = aP6_cCueCodAux;
         this.AV35Tipo = aP7_Tipo;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_FDesde=this.AV17FDesde;
         aP3_Fhasta=this.AV18Fhasta;
         aP4_CueCod1=this.AV19CueCod1;
         aP5_CueCod2=this.AV20CueCod2;
         aP6_cCueCodAux=this.AV40cCueCodAux;
         aP7_Tipo=this.AV35Tipo;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_Fhasta ,
                                ref string aP4_CueCod1 ,
                                ref string aP5_CueCod2 ,
                                ref string aP6_cCueCodAux )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_FDesde, ref aP3_Fhasta, ref aP4_CueCod1, ref aP5_CueCod2, ref aP6_cCueCodAux, ref aP7_Tipo);
         return AV35Tipo ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_Fhasta ,
                                 ref string aP4_CueCod1 ,
                                 ref string aP5_CueCod2 ,
                                 ref string aP6_cCueCodAux ,
                                 ref string aP7_Tipo )
      {
         r_analisiscuentaspdf objr_analisiscuentaspdf;
         objr_analisiscuentaspdf = new r_analisiscuentaspdf();
         objr_analisiscuentaspdf.AV11Ano = aP0_Ano;
         objr_analisiscuentaspdf.AV12Mes = aP1_Mes;
         objr_analisiscuentaspdf.AV17FDesde = aP2_FDesde;
         objr_analisiscuentaspdf.AV18Fhasta = aP3_Fhasta;
         objr_analisiscuentaspdf.AV19CueCod1 = aP4_CueCod1;
         objr_analisiscuentaspdf.AV20CueCod2 = aP5_CueCod2;
         objr_analisiscuentaspdf.AV40cCueCodAux = aP6_cCueCodAux;
         objr_analisiscuentaspdf.AV35Tipo = aP7_Tipo;
         objr_analisiscuentaspdf.context.SetSubmitInitialConfig(context);
         objr_analisiscuentaspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_analisiscuentaspdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_FDesde=this.AV17FDesde;
         aP3_Fhasta=this.AV18Fhasta;
         aP4_CueCod1=this.AV19CueCod1;
         aP5_CueCod2=this.AV20CueCod2;
         aP6_cCueCodAux=this.AV40cCueCodAux;
         aP7_Tipo=this.AV35Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_analisiscuentaspdf)stateInfo).executePrivate();
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
            AV63Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            AV13Titulo = "Analisis de Cuenta";
            if ( StringUtil.StrCmp(AV35Tipo, "G") == 0 )
            {
               AV36cAno = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 4, 0));
               GXt_char1 = AV37cMes;
               new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
               AV37cMes = GXt_char1;
               AV14Periodo = "Periodo : " + StringUtil.Trim( AV37cMes) + " " + StringUtil.Trim( AV36cAno);
            }
            else
            {
               AV14Periodo = "Periodo : " + context.localUtil.DToC( AV17FDesde, 2, "/") + " Al " + context.localUtil.DToC( AV18Fhasta, 2, "/");
            }
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV19CueCod1 ,
                                                 AV20CueCod2 ,
                                                 AV40cCueCodAux ,
                                                 A91CueCod ,
                                                 A133CueCodAux ,
                                                 A2077VouSts ,
                                                 A127VouAno ,
                                                 AV11Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00AZ2 */
            pr_default.execute(0, new Object[] {AV11Ano, AV19CueCod1, AV20CueCod2, AV40cCueCodAux});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRKAZ3 = false;
               A2074VouFec = P00AZ2_A2074VouFec[0];
               A136VouReg = P00AZ2_A136VouReg[0];
               A133CueCodAux = P00AZ2_A133CueCodAux[0];
               A70TipACod = P00AZ2_A70TipACod[0];
               n70TipACod = P00AZ2_n70TipACod[0];
               A132VouDTipCod = P00AZ2_A132VouDTipCod[0];
               A126TASICod = P00AZ2_A126TASICod[0];
               A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
               A129VouNum = P00AZ2_A129VouNum[0];
               A2054VouDGls = P00AZ2_A2054VouDGls[0];
               A2053VouDDoc = P00AZ2_A2053VouDDoc[0];
               A135VouDFec = P00AZ2_A135VouDFec[0];
               A128VouMes = P00AZ2_A128VouMes[0];
               A127VouAno = P00AZ2_A127VouAno[0];
               A2077VouSts = P00AZ2_A2077VouSts[0];
               A91CueCod = P00AZ2_A91CueCod[0];
               A131VouDMon = P00AZ2_A131VouDMon[0];
               A2055VouDHab = P00AZ2_A2055VouDHab[0];
               A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
               A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
               A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
               A860CueDsc = P00AZ2_A860CueDsc[0];
               A130VouDSec = P00AZ2_A130VouDSec[0];
               A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
               A2074VouFec = P00AZ2_A2074VouFec[0];
               A2077VouSts = P00AZ2_A2077VouSts[0];
               A70TipACod = P00AZ2_A70TipACod[0];
               n70TipACod = P00AZ2_n70TipACod[0];
               A860CueDsc = P00AZ2_A860CueDsc[0];
               AV25CueCod = A91CueCod;
               AV39CueDsc = A860CueDsc;
               AV52TSaldoS = 0.00m;
               AV53TSaldoD = 0.00m;
               AV41TipACod = A70TipACod;
               /* Execute user subroutine: 'VALIDASALDOCUENTA' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! (Convert.ToDecimal(0)==AV57SaldoVerCuenta) )
               {
                  HAZ0( false, 30) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 78, Gx_line+8, 173, Gx_line+23, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39CueDsc, "")), 167, Gx_line+8, 649, Gx_line+22, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Cuenta : ", 6, Gx_line+8, 58, Gx_line+22, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if ( (0==AV41TipACod) )
               {
                  AV44SaldoS = 0.00m;
                  AV45SaldoD = 0.00m;
                  while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AZ2_A91CueCod[0], A91CueCod) == 0 ) )
                  {
                     BRKAZ3 = false;
                     A126TASICod = P00AZ2_A126TASICod[0];
                     A129VouNum = P00AZ2_A129VouNum[0];
                     A135VouDFec = P00AZ2_A135VouDFec[0];
                     A128VouMes = P00AZ2_A128VouMes[0];
                     A127VouAno = P00AZ2_A127VouAno[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     A131VouDMon = P00AZ2_A131VouDMon[0];
                     A2055VouDHab = P00AZ2_A2055VouDHab[0];
                     A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
                     A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
                     A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
                     A130VouDSec = P00AZ2_A130VouDSec[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                     {
                        if ( A2077VouSts == 1 )
                        {
                           if ( A127VouAno == AV11Ano )
                           {
                              if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A128VouMes < AV12Mes ) ) )
                              {
                                 if ( ( StringUtil.StrCmp(AV35Tipo, "R") != 0 ) || ( ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( AV17FDesde ) ) && ( DateTimeUtil.ResetTime ( A135VouDFec ) <= DateTimeUtil.ResetTime ( AV18Fhasta ) ) ) )
                                 {
                                    AV51VouDMon = A131VouDMon;
                                    AV44SaldoS = (decimal)(AV44SaldoS+((A2051VouDDeb-A2055VouDHab)));
                                    if ( ! ( AV51VouDMon == 1 ) )
                                    {
                                       AV45SaldoD = (decimal)(AV45SaldoD+((A2052VouDDebO-A2056VouDHabO)));
                                    }
                                 }
                              }
                           }
                        }
                     }
                     BRKAZ3 = true;
                     pr_default.readNext(0);
                  }
                  AV52TSaldoS = AV44SaldoS;
                  AV53TSaldoD = AV45SaldoD;
                  HAZ0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Saldo Anterior", 452, Gx_line+2, 537, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44SaldoS, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+2, 657, Gx_line+17, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45SaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+2, 774, Gx_line+17, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AZ2_A91CueCod[0], A91CueCod) == 0 ) )
                  {
                     BRKAZ3 = false;
                     A132VouDTipCod = P00AZ2_A132VouDTipCod[0];
                     A126TASICod = P00AZ2_A126TASICod[0];
                     A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                     A129VouNum = P00AZ2_A129VouNum[0];
                     A2054VouDGls = P00AZ2_A2054VouDGls[0];
                     A2053VouDDoc = P00AZ2_A2053VouDDoc[0];
                     A135VouDFec = P00AZ2_A135VouDFec[0];
                     A128VouMes = P00AZ2_A128VouMes[0];
                     A127VouAno = P00AZ2_A127VouAno[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     A131VouDMon = P00AZ2_A131VouDMon[0];
                     A2055VouDHab = P00AZ2_A2055VouDHab[0];
                     A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
                     A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
                     A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
                     A130VouDSec = P00AZ2_A130VouDSec[0];
                     A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                     {
                        if ( A2077VouSts == 1 )
                        {
                           if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A127VouAno == AV11Ano ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A128VouMes == AV12Mes ) ) )
                              {
                                 if ( ( StringUtil.StrCmp(AV35Tipo, "R") != 0 ) || ( ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( AV17FDesde ) ) && ( DateTimeUtil.ResetTime ( A135VouDFec ) <= DateTimeUtil.ResetTime ( AV18Fhasta ) ) ) )
                                 {
                                    AV60VouDTipCod = A132VouDTipCod;
                                    AV51VouDMon = A131VouDMon;
                                    AV46TasiCod = A126TASICod;
                                    AV50TasiAbr = A1894TASIAbr;
                                    AV47VouNum = A129VouNum;
                                    AV48VouDFec = A135VouDFec;
                                    AV49VouDGls = A2054VouDGls;
                                    AV38VouDDoc = A2053VouDDoc;
                                    AV44SaldoS = (decimal)((A2051VouDDeb-A2055VouDHab));
                                    /* Execute user subroutine: 'TIPODOCUMENTO' */
                                    S131 ();
                                    if ( returnInSub )
                                    {
                                       pr_default.close(0);
                                       this.cleanup();
                                       if (true) return;
                                    }
                                    if ( ! ( AV51VouDMon == 1 ) )
                                    {
                                       AV45SaldoD = (decimal)((A2052VouDDebO-A2056VouDHabO));
                                    }
                                    AV52TSaldoS = (decimal)(AV52TSaldoS+AV44SaldoS);
                                    AV53TSaldoD = (decimal)(AV53TSaldoD+AV45SaldoD);
                                    HAZ0( false, 18) ;
                                    getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                    getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45SaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+2, 774, Gx_line+17, 2+256, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44SaldoS, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+2, 657, Gx_line+17, 2+256, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38VouDDoc, "")), 73, Gx_line+2, 178, Gx_line+17, 0+256, 0, 0, 0) ;
                                    getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                    getPrinter().GxDrawText(context.localUtil.Format( AV48VouDFec, "99/99/99"), 263, Gx_line+2, 309, Gx_line+16, 0, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49VouDGls, "")), 321, Gx_line+1, 537, Gx_line+17, 0, 0, 0, 0) ;
                                    getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TipAbr, "")), 26, Gx_line+2, 61, Gx_line+16, 1, 0, 0, 0) ;
                                    getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59VouReg, "")), 177, Gx_line+2, 256, Gx_line+17, 0+256, 0, 0, 0) ;
                                    Gx_OldLine = Gx_line;
                                    Gx_line = (int)(Gx_line+18);
                                 }
                              }
                           }
                        }
                     }
                     BRKAZ3 = true;
                     pr_default.readNext(0);
                  }
                  if ( ! (Convert.ToDecimal(0)==AV57SaldoVerCuenta) )
                  {
                     HAZ0( false, 42) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Cuenta", 372, Gx_line+15, 448, Gx_line+29, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 460, Gx_line+15, 539, Gx_line+30, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(542, Gx_line+4, 791, Gx_line+4, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TSaldoS, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+14, 657, Gx_line+29, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TSaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+14, 774, Gx_line+29, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+42);
                  }
               }
               else
               {
                  while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AZ2_A91CueCod[0], A91CueCod) == 0 ) )
                  {
                     BRKAZ3 = false;
                     A2074VouFec = P00AZ2_A2074VouFec[0];
                     A136VouReg = P00AZ2_A136VouReg[0];
                     A133CueCodAux = P00AZ2_A133CueCodAux[0];
                     A70TipACod = P00AZ2_A70TipACod[0];
                     n70TipACod = P00AZ2_n70TipACod[0];
                     A132VouDTipCod = P00AZ2_A132VouDTipCod[0];
                     A126TASICod = P00AZ2_A126TASICod[0];
                     A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                     A129VouNum = P00AZ2_A129VouNum[0];
                     A2054VouDGls = P00AZ2_A2054VouDGls[0];
                     A2053VouDDoc = P00AZ2_A2053VouDDoc[0];
                     A135VouDFec = P00AZ2_A135VouDFec[0];
                     A128VouMes = P00AZ2_A128VouMes[0];
                     A127VouAno = P00AZ2_A127VouAno[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     A131VouDMon = P00AZ2_A131VouDMon[0];
                     A2055VouDHab = P00AZ2_A2055VouDHab[0];
                     A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
                     A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
                     A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
                     A130VouDSec = P00AZ2_A130VouDSec[0];
                     A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                     A2074VouFec = P00AZ2_A2074VouFec[0];
                     A2077VouSts = P00AZ2_A2077VouSts[0];
                     A70TipACod = P00AZ2_A70TipACod[0];
                     n70TipACod = P00AZ2_n70TipACod[0];
                     if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                     {
                        if ( A2077VouSts == 1 )
                        {
                           if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A127VouAno == AV11Ano ) ) )
                           {
                              if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A128VouMes <= AV12Mes ) ) )
                              {
                                 if ( ( StringUtil.StrCmp(AV35Tipo, "R") != 0 ) || ( ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( AV17FDesde ) ) && ( DateTimeUtil.ResetTime ( A135VouDFec ) <= DateTimeUtil.ResetTime ( AV18Fhasta ) ) ) )
                                 {
                                    AV34CueCodAux = A133CueCodAux;
                                    AV41TipACod = A70TipACod;
                                    AV54TDebeA = 0.00m;
                                    AV55THaberA = 0.00m;
                                    /* Execute user subroutine: 'VALIDAAUXILIAR' */
                                    S111 ();
                                    if ( returnInSub )
                                    {
                                       pr_default.close(0);
                                       this.cleanup();
                                       if (true) return;
                                    }
                                    if ( ! (Convert.ToDecimal(0)==AV56SaldoVer) )
                                    {
                                       HAZ0( false, 27) ;
                                       getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                       getPrinter().GxDrawText("Auxiliar : ", 18, Gx_line+7, 73, Gx_line+21, 0+256, 0, 0, 0) ;
                                       getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                       getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34CueCodAux, "")), 80, Gx_line+7, 185, Gx_line+22, 0+256, 0, 0, 0) ;
                                       getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                       getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TipADDsc, "")), 190, Gx_line+7, 711, Gx_line+21, 0, 0, 0, 0) ;
                                       Gx_OldLine = Gx_line;
                                       Gx_line = (int)(Gx_line+27);
                                    }
                                    if ( ! (Convert.ToDecimal(0)==AV56SaldoVer) )
                                    {
                                       while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AZ2_A91CueCod[0], A91CueCod) == 0 ) && ( StringUtil.StrCmp(P00AZ2_A133CueCodAux[0], A133CueCodAux) == 0 ) )
                                       {
                                          BRKAZ3 = false;
                                          A2074VouFec = P00AZ2_A2074VouFec[0];
                                          A136VouReg = P00AZ2_A136VouReg[0];
                                          A132VouDTipCod = P00AZ2_A132VouDTipCod[0];
                                          A126TASICod = P00AZ2_A126TASICod[0];
                                          A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                                          A129VouNum = P00AZ2_A129VouNum[0];
                                          A2054VouDGls = P00AZ2_A2054VouDGls[0];
                                          A2053VouDDoc = P00AZ2_A2053VouDDoc[0];
                                          A135VouDFec = P00AZ2_A135VouDFec[0];
                                          A128VouMes = P00AZ2_A128VouMes[0];
                                          A127VouAno = P00AZ2_A127VouAno[0];
                                          A2077VouSts = P00AZ2_A2077VouSts[0];
                                          A131VouDMon = P00AZ2_A131VouDMon[0];
                                          A2055VouDHab = P00AZ2_A2055VouDHab[0];
                                          A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
                                          A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
                                          A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
                                          A130VouDSec = P00AZ2_A130VouDSec[0];
                                          A1894TASIAbr = P00AZ2_A1894TASIAbr[0];
                                          A2074VouFec = P00AZ2_A2074VouFec[0];
                                          A2077VouSts = P00AZ2_A2077VouSts[0];
                                          if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                                          {
                                             if ( StringUtil.StrCmp(A133CueCodAux, AV34CueCodAux) == 0 )
                                             {
                                                if ( A2077VouSts == 1 )
                                                {
                                                   if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A127VouAno == AV11Ano ) ) )
                                                   {
                                                      if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A128VouMes <= AV12Mes ) ) )
                                                      {
                                                         if ( ( StringUtil.StrCmp(AV35Tipo, "R") != 0 ) || ( ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( AV17FDesde ) ) && ( DateTimeUtil.ResetTime ( A135VouDFec ) <= DateTimeUtil.ResetTime ( AV18Fhasta ) ) ) )
                                                         {
                                                            AV51VouDMon = A131VouDMon;
                                                            AV46TasiCod = A126TASICod;
                                                            AV50TasiAbr = A1894TASIAbr;
                                                            AV47VouNum = A129VouNum;
                                                            AV48VouDFec = A135VouDFec;
                                                            AV49VouDGls = A2054VouDGls;
                                                            AV60VouDTipCod = A132VouDTipCod;
                                                            AV38VouDDoc = A2053VouDDoc;
                                                            AV59VouReg = A136VouReg;
                                                            AV44SaldoS = 0.00m;
                                                            AV45SaldoD = 0.00m;
                                                            /* Execute user subroutine: 'TIPODOCUMENTO' */
                                                            S131 ();
                                                            if ( returnInSub )
                                                            {
                                                               pr_default.close(0);
                                                               this.cleanup();
                                                               if (true) return;
                                                            }
                                                            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AZ2_A91CueCod[0], A91CueCod) == 0 ) && ( StringUtil.StrCmp(P00AZ2_A133CueCodAux[0], A133CueCodAux) == 0 ) && ( StringUtil.StrCmp(P00AZ2_A132VouDTipCod[0], A132VouDTipCod) == 0 ) && ( StringUtil.StrCmp(P00AZ2_A2053VouDDoc[0], A2053VouDDoc) == 0 ) )
                                                            {
                                                               BRKAZ3 = false;
                                                               A2074VouFec = P00AZ2_A2074VouFec[0];
                                                               A126TASICod = P00AZ2_A126TASICod[0];
                                                               A129VouNum = P00AZ2_A129VouNum[0];
                                                               A135VouDFec = P00AZ2_A135VouDFec[0];
                                                               A128VouMes = P00AZ2_A128VouMes[0];
                                                               A127VouAno = P00AZ2_A127VouAno[0];
                                                               A2077VouSts = P00AZ2_A2077VouSts[0];
                                                               A2055VouDHab = P00AZ2_A2055VouDHab[0];
                                                               A2051VouDDeb = P00AZ2_A2051VouDDeb[0];
                                                               A2056VouDHabO = P00AZ2_A2056VouDHabO[0];
                                                               A2052VouDDebO = P00AZ2_A2052VouDDebO[0];
                                                               A130VouDSec = P00AZ2_A130VouDSec[0];
                                                               A2074VouFec = P00AZ2_A2074VouFec[0];
                                                               A2077VouSts = P00AZ2_A2077VouSts[0];
                                                               if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                                                               {
                                                                  if ( StringUtil.StrCmp(A132VouDTipCod, AV60VouDTipCod) == 0 )
                                                                  {
                                                                     if ( StringUtil.StrCmp(A2053VouDDoc, AV38VouDDoc) == 0 )
                                                                     {
                                                                        if ( StringUtil.StrCmp(A133CueCodAux, AV34CueCodAux) == 0 )
                                                                        {
                                                                           if ( A2077VouSts == 1 )
                                                                           {
                                                                              if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A127VouAno == AV11Ano ) ) )
                                                                              {
                                                                                 if ( ( StringUtil.StrCmp(AV35Tipo, "G") != 0 ) || ( ( A128VouMes <= AV12Mes ) ) )
                                                                                 {
                                                                                    if ( ( StringUtil.StrCmp(AV35Tipo, "R") != 0 ) || ( ( DateTimeUtil.ResetTime ( A135VouDFec ) >= DateTimeUtil.ResetTime ( AV17FDesde ) ) && ( DateTimeUtil.ResetTime ( A135VouDFec ) <= DateTimeUtil.ResetTime ( AV18Fhasta ) ) ) )
                                                                                    {
                                                                                       AV44SaldoS = (decimal)(AV44SaldoS+((A2051VouDDeb-A2055VouDHab)));
                                                                                       if ( ! ( AV51VouDMon == 1 ) )
                                                                                       {
                                                                                          AV45SaldoD = (decimal)(AV45SaldoD+((A2052VouDDebO-A2056VouDHabO)));
                                                                                       }
                                                                                    }
                                                                                 }
                                                                              }
                                                                           }
                                                                        }
                                                                     }
                                                                  }
                                                               }
                                                               BRKAZ3 = true;
                                                               pr_default.readNext(0);
                                                            }
                                                            AV52TSaldoS = (decimal)(AV52TSaldoS+AV44SaldoS);
                                                            AV53TSaldoD = (decimal)(AV53TSaldoD+AV45SaldoD);
                                                            AV54TDebeA = (decimal)(AV54TDebeA+AV44SaldoS);
                                                            AV55THaberA = (decimal)(AV55THaberA+AV45SaldoD);
                                                            if ( ! (Convert.ToDecimal(0)==AV44SaldoS) )
                                                            {
                                                               HAZ0( false, 18) ;
                                                               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                                               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45SaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+2, 774, Gx_line+17, 2+256, 0, 0, 0) ;
                                                               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44SaldoS, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+2, 657, Gx_line+17, 2+256, 0, 0, 0) ;
                                                               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38VouDDoc, "")), 73, Gx_line+2, 178, Gx_line+17, 0+256, 0, 0, 0) ;
                                                               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                                               getPrinter().GxDrawText(context.localUtil.Format( AV48VouDFec, "99/99/99"), 263, Gx_line+2, 309, Gx_line+16, 0, 0, 0, 0) ;
                                                               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49VouDGls, "")), 321, Gx_line+1, 537, Gx_line+17, 0, 0, 0, 0) ;
                                                               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                                               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58TipAbr, "")), 26, Gx_line+2, 61, Gx_line+16, 1, 0, 0, 0) ;
                                                               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59VouReg, "")), 177, Gx_line+2, 256, Gx_line+17, 0+256, 0, 0, 0) ;
                                                               Gx_OldLine = Gx_line;
                                                               Gx_line = (int)(Gx_line+18);
                                                            }
                                                         }
                                                      }
                                                   }
                                                }
                                             }
                                          }
                                          if ( ! BRKAZ3 )
                                          {
                                             BRKAZ3 = true;
                                             pr_default.readNext(0);
                                          }
                                       }
                                    }
                                    if ( ! (Convert.ToDecimal(0)==AV56SaldoVer) )
                                    {
                                       HAZ0( false, 29) ;
                                       getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                       getPrinter().GxDrawText("Total Auxiliar", 340, Gx_line+10, 419, Gx_line+24, 0+256, 0, 0, 0) ;
                                       getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                       getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54TDebeA, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+10, 657, Gx_line+25, 2+256, 0, 0, 0) ;
                                       getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55THaberA, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+10, 774, Gx_line+25, 2+256, 0, 0, 0) ;
                                       getPrinter().GxDrawLine(543, Gx_line+1, 792, Gx_line+1, 1, 0, 0, 0, 0) ;
                                       getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34CueCodAux, "")), 427, Gx_line+10, 532, Gx_line+25, 0+256, 0, 0, 0) ;
                                       Gx_OldLine = Gx_line;
                                       Gx_line = (int)(Gx_line+29);
                                    }
                                 }
                              }
                           }
                        }
                     }
                     if ( ! BRKAZ3 )
                     {
                        BRKAZ3 = true;
                        pr_default.readNext(0);
                     }
                  }
                  if ( ! (Convert.ToDecimal(0)==AV57SaldoVerCuenta) )
                  {
                     HAZ0( false, 42) ;
                     getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Total Cuenta", 372, Gx_line+15, 448, Gx_line+29, 0+256, 0, 0, 0) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 460, Gx_line+15, 539, Gx_line+30, 0+256, 0, 0, 0) ;
                     getPrinter().GxDrawLine(542, Gx_line+4, 791, Gx_line+4, 1, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52TSaldoS, "ZZZZZZ,ZZZ,ZZ9.99")), 550, Gx_line+14, 657, Gx_line+29, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TSaldoD, "ZZZZZZ,ZZZ,ZZ9.99")), 667, Gx_line+14, 774, Gx_line+29, 2+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+42);
                  }
               }
               if ( ! BRKAZ3 )
               {
                  BRKAZ3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAZ0( true, 0) ;
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
         /* 'VALIDAAUXILIAR' Routine */
         returnInSub = false;
         AV42TipADDsc = "";
         /* Using cursor P00AZ3 */
         pr_default.execute(1, new Object[] {AV41TipACod, AV34CueCodAux});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A71TipADCod = P00AZ3_A71TipADCod[0];
            A70TipACod = P00AZ3_A70TipACod[0];
            n70TipACod = P00AZ3_n70TipACod[0];
            A72TipADDsc = P00AZ3_A72TipADDsc[0];
            AV42TipADDsc = A72TipADDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV56SaldoVer = 0.00m;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV34CueCodAux ,
                                              AV35Tipo ,
                                              A133CueCodAux ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A128VouMes ,
                                              AV12Mes ,
                                              A135VouDFec ,
                                              AV17FDesde ,
                                              AV18Fhasta ,
                                              A91CueCod ,
                                              AV25CueCod ,
                                              A2077VouSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AZ4 */
         pr_default.execute(2, new Object[] {AV25CueCod, AV34CueCodAux, AV11Ano, AV12Mes, AV17FDesde, AV18Fhasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A126TASICod = P00AZ4_A126TASICod[0];
            A91CueCod = P00AZ4_A91CueCod[0];
            A2077VouSts = P00AZ4_A2077VouSts[0];
            A135VouDFec = P00AZ4_A135VouDFec[0];
            A128VouMes = P00AZ4_A128VouMes[0];
            A127VouAno = P00AZ4_A127VouAno[0];
            A133CueCodAux = P00AZ4_A133CueCodAux[0];
            A129VouNum = P00AZ4_A129VouNum[0];
            A2055VouDHab = P00AZ4_A2055VouDHab[0];
            A2051VouDDeb = P00AZ4_A2051VouDDeb[0];
            A2074VouFec = P00AZ4_A2074VouFec[0];
            A130VouDSec = P00AZ4_A130VouDSec[0];
            A2077VouSts = P00AZ4_A2077VouSts[0];
            A2074VouFec = P00AZ4_A2074VouFec[0];
            AV56SaldoVer = (decimal)(AV56SaldoVer+((A2051VouDDeb-A2055VouDHab)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'VALIDASALDOCUENTA' Routine */
         returnInSub = false;
         AV57SaldoVerCuenta = 0.00m;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV35Tipo ,
                                              A127VouAno ,
                                              AV11Ano ,
                                              A128VouMes ,
                                              AV12Mes ,
                                              A135VouDFec ,
                                              AV17FDesde ,
                                              AV18Fhasta ,
                                              A91CueCod ,
                                              AV25CueCod ,
                                              A2077VouSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00AZ5 */
         pr_default.execute(3, new Object[] {AV25CueCod, AV11Ano, AV12Mes, AV17FDesde, AV18Fhasta});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A126TASICod = P00AZ5_A126TASICod[0];
            A91CueCod = P00AZ5_A91CueCod[0];
            A2077VouSts = P00AZ5_A2077VouSts[0];
            A135VouDFec = P00AZ5_A135VouDFec[0];
            A128VouMes = P00AZ5_A128VouMes[0];
            A127VouAno = P00AZ5_A127VouAno[0];
            A129VouNum = P00AZ5_A129VouNum[0];
            A2055VouDHab = P00AZ5_A2055VouDHab[0];
            A2051VouDDeb = P00AZ5_A2051VouDDeb[0];
            A2074VouFec = P00AZ5_A2074VouFec[0];
            A130VouDSec = P00AZ5_A130VouDSec[0];
            A2077VouSts = P00AZ5_A2077VouSts[0];
            A2074VouFec = P00AZ5_A2074VouFec[0];
            AV57SaldoVerCuenta = (decimal)(AV57SaldoVerCuenta+((A2051VouDDeb-A2055VouDHab)));
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'TIPODOCUMENTO' Routine */
         returnInSub = false;
         AV58TipAbr = "";
         /* Using cursor P00AZ6 */
         pr_default.execute(4, new Object[] {AV60VouDTipCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A149TipCod = P00AZ6_A149TipCod[0];
            A306TipAbr = P00AZ6_A306TipAbr[0];
            AV58TipAbr = StringUtil.Trim( A306TipAbr);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void HAZ0( bool bFoot ,
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
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 32, Gx_line+152, 55, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 272, Gx_line+152, 307, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Glosa", 369, Gx_line+152, 402, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo MN", 592, Gx_line+152, 646, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo ME", 704, Gx_line+152, 757, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+145, 797, Gx_line+171, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 173, Gx_line+25, 629, Gx_line+59, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 173, Gx_line+56, 629, Gx_line+90, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Documento", 74, Gx_line+152, 159, Gx_line+166, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV63Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+9, 167, Gx_line+87) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 743, Gx_line+18, 782, Gx_line+33, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 693, Gx_line+18, 737, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° Registro", 176, Gx_line+152, 244, Gx_line+166, 0+256, 0, 0, 0) ;
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
         AV27Empresa = "";
         AV30Session = context.GetSession();
         AV28EmpDir = "";
         AV31EmpRUC = "";
         AV32Ruta = "";
         AV33Logo = "";
         AV63Logo_GXI = "";
         AV13Titulo = "";
         AV36cAno = "";
         AV37cMes = "";
         GXt_char1 = "";
         AV14Periodo = "";
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         P00AZ2_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ2_A136VouReg = new string[] {""} ;
         P00AZ2_A133CueCodAux = new string[] {""} ;
         P00AZ2_A70TipACod = new int[1] ;
         P00AZ2_n70TipACod = new bool[] {false} ;
         P00AZ2_A132VouDTipCod = new string[] {""} ;
         P00AZ2_A126TASICod = new int[1] ;
         P00AZ2_A1894TASIAbr = new string[] {""} ;
         P00AZ2_A129VouNum = new string[] {""} ;
         P00AZ2_A2054VouDGls = new string[] {""} ;
         P00AZ2_A2053VouDDoc = new string[] {""} ;
         P00AZ2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ2_A128VouMes = new short[1] ;
         P00AZ2_A127VouAno = new short[1] ;
         P00AZ2_A2077VouSts = new short[1] ;
         P00AZ2_A91CueCod = new string[] {""} ;
         P00AZ2_A131VouDMon = new int[1] ;
         P00AZ2_A2055VouDHab = new decimal[1] ;
         P00AZ2_A2051VouDDeb = new decimal[1] ;
         P00AZ2_A2056VouDHabO = new decimal[1] ;
         P00AZ2_A2052VouDDebO = new decimal[1] ;
         P00AZ2_A860CueDsc = new string[] {""} ;
         P00AZ2_A130VouDSec = new int[1] ;
         A2074VouFec = DateTime.MinValue;
         A136VouReg = "";
         A132VouDTipCod = "";
         A1894TASIAbr = "";
         A129VouNum = "";
         A2054VouDGls = "";
         A2053VouDDoc = "";
         A135VouDFec = DateTime.MinValue;
         A860CueDsc = "";
         AV25CueCod = "";
         AV39CueDsc = "";
         AV60VouDTipCod = "";
         AV50TasiAbr = "";
         AV47VouNum = "";
         AV48VouDFec = DateTime.MinValue;
         AV49VouDGls = "";
         AV38VouDDoc = "";
         AV58TipAbr = "";
         AV59VouReg = "";
         AV34CueCodAux = "";
         AV42TipADDsc = "";
         P00AZ3_A71TipADCod = new string[] {""} ;
         P00AZ3_A70TipACod = new int[1] ;
         P00AZ3_n70TipACod = new bool[] {false} ;
         P00AZ3_A72TipADDsc = new string[] {""} ;
         A71TipADCod = "";
         A72TipADDsc = "";
         P00AZ4_A126TASICod = new int[1] ;
         P00AZ4_A91CueCod = new string[] {""} ;
         P00AZ4_A2077VouSts = new short[1] ;
         P00AZ4_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ4_A128VouMes = new short[1] ;
         P00AZ4_A127VouAno = new short[1] ;
         P00AZ4_A133CueCodAux = new string[] {""} ;
         P00AZ4_A129VouNum = new string[] {""} ;
         P00AZ4_A2055VouDHab = new decimal[1] ;
         P00AZ4_A2051VouDDeb = new decimal[1] ;
         P00AZ4_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ4_A130VouDSec = new int[1] ;
         P00AZ5_A126TASICod = new int[1] ;
         P00AZ5_A91CueCod = new string[] {""} ;
         P00AZ5_A2077VouSts = new short[1] ;
         P00AZ5_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ5_A128VouMes = new short[1] ;
         P00AZ5_A127VouAno = new short[1] ;
         P00AZ5_A129VouNum = new string[] {""} ;
         P00AZ5_A2055VouDHab = new decimal[1] ;
         P00AZ5_A2051VouDDeb = new decimal[1] ;
         P00AZ5_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         P00AZ5_A130VouDSec = new int[1] ;
         P00AZ6_A149TipCod = new string[] {""} ;
         P00AZ6_A306TipAbr = new string[] {""} ;
         A149TipCod = "";
         A306TipAbr = "";
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_analisiscuentaspdf__default(),
            new Object[][] {
                new Object[] {
               P00AZ2_A2074VouFec, P00AZ2_A136VouReg, P00AZ2_A133CueCodAux, P00AZ2_A70TipACod, P00AZ2_n70TipACod, P00AZ2_A132VouDTipCod, P00AZ2_A126TASICod, P00AZ2_A1894TASIAbr, P00AZ2_A129VouNum, P00AZ2_A2054VouDGls,
               P00AZ2_A2053VouDDoc, P00AZ2_A135VouDFec, P00AZ2_A128VouMes, P00AZ2_A127VouAno, P00AZ2_A2077VouSts, P00AZ2_A91CueCod, P00AZ2_A131VouDMon, P00AZ2_A2055VouDHab, P00AZ2_A2051VouDDeb, P00AZ2_A2056VouDHabO,
               P00AZ2_A2052VouDDebO, P00AZ2_A860CueDsc, P00AZ2_A130VouDSec
               }
               , new Object[] {
               P00AZ3_A71TipADCod, P00AZ3_A70TipACod, P00AZ3_A72TipADDsc
               }
               , new Object[] {
               P00AZ4_A126TASICod, P00AZ4_A91CueCod, P00AZ4_A2077VouSts, P00AZ4_A135VouDFec, P00AZ4_A128VouMes, P00AZ4_A127VouAno, P00AZ4_A133CueCodAux, P00AZ4_A129VouNum, P00AZ4_A2055VouDHab, P00AZ4_A2051VouDDeb,
               P00AZ4_A2074VouFec, P00AZ4_A130VouDSec
               }
               , new Object[] {
               P00AZ5_A126TASICod, P00AZ5_A91CueCod, P00AZ5_A2077VouSts, P00AZ5_A135VouDFec, P00AZ5_A128VouMes, P00AZ5_A127VouAno, P00AZ5_A129VouNum, P00AZ5_A2055VouDHab, P00AZ5_A2051VouDDeb, P00AZ5_A2074VouFec,
               P00AZ5_A130VouDSec
               }
               , new Object[] {
               P00AZ6_A149TipCod, P00AZ6_A306TipAbr
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
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A70TipACod ;
      private int A126TASICod ;
      private int A131VouDMon ;
      private int A130VouDSec ;
      private int AV41TipACod ;
      private int Gx_OldLine ;
      private int AV51VouDMon ;
      private int AV46TasiCod ;
      private decimal A2055VouDHab ;
      private decimal A2051VouDDeb ;
      private decimal A2056VouDHabO ;
      private decimal A2052VouDDebO ;
      private decimal AV52TSaldoS ;
      private decimal AV53TSaldoD ;
      private decimal AV57SaldoVerCuenta ;
      private decimal AV44SaldoS ;
      private decimal AV45SaldoD ;
      private decimal AV54TDebeA ;
      private decimal AV55THaberA ;
      private decimal AV56SaldoVer ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV19CueCod1 ;
      private string AV20CueCod2 ;
      private string AV40cCueCodAux ;
      private string AV35Tipo ;
      private string AV27Empresa ;
      private string AV28EmpDir ;
      private string AV31EmpRUC ;
      private string AV32Ruta ;
      private string AV13Titulo ;
      private string AV36cAno ;
      private string AV37cMes ;
      private string GXt_char1 ;
      private string AV14Periodo ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A136VouReg ;
      private string A132VouDTipCod ;
      private string A1894TASIAbr ;
      private string A129VouNum ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string AV25CueCod ;
      private string AV39CueDsc ;
      private string AV60VouDTipCod ;
      private string AV50TasiAbr ;
      private string AV47VouNum ;
      private string AV49VouDGls ;
      private string AV38VouDDoc ;
      private string AV58TipAbr ;
      private string AV59VouReg ;
      private string AV34CueCodAux ;
      private string AV42TipADDsc ;
      private string A71TipADCod ;
      private string A72TipADDsc ;
      private string A149TipCod ;
      private string A306TipAbr ;
      private string sImgUrl ;
      private DateTime AV17FDesde ;
      private DateTime AV18Fhasta ;
      private DateTime A2074VouFec ;
      private DateTime A135VouDFec ;
      private DateTime AV48VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKAZ3 ;
      private bool n70TipACod ;
      private bool returnInSub ;
      private string AV63Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_Fhasta ;
      private string aP4_CueCod1 ;
      private string aP5_CueCod2 ;
      private string aP6_cCueCodAux ;
      private string aP7_Tipo ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00AZ2_A2074VouFec ;
      private string[] P00AZ2_A136VouReg ;
      private string[] P00AZ2_A133CueCodAux ;
      private int[] P00AZ2_A70TipACod ;
      private bool[] P00AZ2_n70TipACod ;
      private string[] P00AZ2_A132VouDTipCod ;
      private int[] P00AZ2_A126TASICod ;
      private string[] P00AZ2_A1894TASIAbr ;
      private string[] P00AZ2_A129VouNum ;
      private string[] P00AZ2_A2054VouDGls ;
      private string[] P00AZ2_A2053VouDDoc ;
      private DateTime[] P00AZ2_A135VouDFec ;
      private short[] P00AZ2_A128VouMes ;
      private short[] P00AZ2_A127VouAno ;
      private short[] P00AZ2_A2077VouSts ;
      private string[] P00AZ2_A91CueCod ;
      private int[] P00AZ2_A131VouDMon ;
      private decimal[] P00AZ2_A2055VouDHab ;
      private decimal[] P00AZ2_A2051VouDDeb ;
      private decimal[] P00AZ2_A2056VouDHabO ;
      private decimal[] P00AZ2_A2052VouDDebO ;
      private string[] P00AZ2_A860CueDsc ;
      private int[] P00AZ2_A130VouDSec ;
      private string[] P00AZ3_A71TipADCod ;
      private int[] P00AZ3_A70TipACod ;
      private bool[] P00AZ3_n70TipACod ;
      private string[] P00AZ3_A72TipADDsc ;
      private int[] P00AZ4_A126TASICod ;
      private string[] P00AZ4_A91CueCod ;
      private short[] P00AZ4_A2077VouSts ;
      private DateTime[] P00AZ4_A135VouDFec ;
      private short[] P00AZ4_A128VouMes ;
      private short[] P00AZ4_A127VouAno ;
      private string[] P00AZ4_A133CueCodAux ;
      private string[] P00AZ4_A129VouNum ;
      private decimal[] P00AZ4_A2055VouDHab ;
      private decimal[] P00AZ4_A2051VouDDeb ;
      private DateTime[] P00AZ4_A2074VouFec ;
      private int[] P00AZ4_A130VouDSec ;
      private int[] P00AZ5_A126TASICod ;
      private string[] P00AZ5_A91CueCod ;
      private short[] P00AZ5_A2077VouSts ;
      private DateTime[] P00AZ5_A135VouDFec ;
      private short[] P00AZ5_A128VouMes ;
      private short[] P00AZ5_A127VouAno ;
      private string[] P00AZ5_A129VouNum ;
      private decimal[] P00AZ5_A2055VouDHab ;
      private decimal[] P00AZ5_A2051VouDDeb ;
      private DateTime[] P00AZ5_A2074VouFec ;
      private int[] P00AZ5_A130VouDSec ;
      private string[] P00AZ6_A149TipCod ;
      private string[] P00AZ6_A306TipAbr ;
   }

   public class r_analisiscuentaspdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AZ2( IGxContext context ,
                                             string AV19CueCod1 ,
                                             string AV20CueCod2 ,
                                             string AV40cCueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             short A2077VouSts ,
                                             short A127VouAno ,
                                             short AV11Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[VouFec], T1.[VouReg], T1.[CueCodAux], T4.[TipACod], T1.[VouDTipCod], T1.[TASICod], T2.[TASIAbr], T1.[VouNum], T1.[VouDGls], T1.[VouDDoc], T1.[VouDFec], T1.[VouMes], T1.[VouAno], T3.[VouSts], T1.[CueCod], T1.[VouDMon], T1.[VouDHab], T1.[VouDDeb], T1.[VouDHabO], T1.[VouDDebO], T4.[CueDsc], T1.[VouDSec] FROM ((([CBVOUCHERDET] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) INNER JOIN [CBVOUCHER] T3 ON T3.[VouAno] = T1.[VouAno] AND T3.[VouMes] = T1.[VouMes] AND T3.[TASICod] = T1.[TASICod] AND T3.[VouNum] = T1.[VouNum]) INNER JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T3.[VouSts] = 1)");
         AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CueCod1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV19CueCod1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CueCod2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV20CueCod2)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40cCueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV40cCueCodAux)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod], T1.[CueCodAux], T1.[VouDTipCod], T1.[VouDDoc], T3.[VouFec]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AZ4( IGxContext context ,
                                             string AV34CueCodAux ,
                                             string AV35Tipo ,
                                             string A133CueCodAux ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta ,
                                             string A91CueCod ,
                                             string AV25CueCod ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[6];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[CueCod], T2.[VouSts], T1.[VouDFec], T1.[VouMes], T1.[VouAno], T1.[CueCodAux], T1.[VouNum], T1.[VouDHab], T1.[VouDDeb], T2.[VouFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV34CueCodAux)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV35Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( StringUtil.StrCmp(AV35Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouMes] <= @AV12Mes)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV35Tipo, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouDFec] >= @AV17FDesde and T1.[VouDFec] <= @AV18Fhasta)");
         }
         else
         {
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[VouFec]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AZ5( IGxContext context ,
                                             string AV35Tipo ,
                                             short A127VouAno ,
                                             short AV11Ano ,
                                             short A128VouMes ,
                                             short AV12Mes ,
                                             DateTime A135VouDFec ,
                                             DateTime AV17FDesde ,
                                             DateTime AV18Fhasta ,
                                             string A91CueCod ,
                                             string AV25CueCod ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[5];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TASICod], T1.[CueCod], T2.[VouSts], T1.[VouDFec], T1.[VouMes], T1.[VouAno], T1.[VouNum], T1.[VouDHab], T1.[VouDDeb], T2.[VouFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[CueCod] = @AV25CueCod)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( StringUtil.StrCmp(AV35Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouAno] = @AV11Ano)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( StringUtil.StrCmp(AV35Tipo, "G") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouMes] <= @AV12Mes)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( StringUtil.StrCmp(AV35Tipo, "R") == 0 )
         {
            AddWhere(sWhereString, "(T1.[VouDFec] >= @AV17FDesde and T1.[VouDFec] <= @AV18Fhasta)");
         }
         else
         {
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[VouFec]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AZ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] );
               case 2 :
                     return conditional_P00AZ4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] );
               case 3 :
                     return conditional_P00AZ5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP00AZ3;
          prmP00AZ3 = new Object[] {
          new ParDef("@AV41TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV34CueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00AZ6;
          prmP00AZ6 = new Object[] {
          new ParDef("@AV60VouDTipCod",GXType.NChar,3,0)
          };
          Object[] prmP00AZ2;
          prmP00AZ2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV19CueCod1",GXType.Char,15,0) ,
          new ParDef("@AV20CueCod2",GXType.Char,15,0) ,
          new ParDef("@AV40cCueCodAux",GXType.NChar,20,0)
          };
          Object[] prmP00AZ4;
          prmP00AZ4 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV34CueCodAux",GXType.NChar,20,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0)
          };
          Object[] prmP00AZ5;
          prmP00AZ5 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV18Fhasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AZ3", "SELECT [TipADCod], [TipACod], [TipADDsc] FROM [CBAUXILIARES] WHERE [TipACod] = @AV41TipACod and [TipADCod] = @AV34CueCodAux ORDER BY [TipACod], [TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00AZ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AZ5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AZ6", "SELECT [TipCod], [TipAbr] FROM [CTIPDOC] WHERE [TipCod] = @AV60VouDTipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AZ6,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 15);
                ((int[]) buf[16])[0] = rslt.getInt(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 100);
                ((int[]) buf[22])[0] = rslt.getInt(22);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 10);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
