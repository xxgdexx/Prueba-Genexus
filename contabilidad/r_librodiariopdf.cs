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
   public class r_librodiariopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_librodiariopdf.aspx")), "contabilidad.r_librodiariopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_librodiariopdf.aspx")))) ;
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
                  AV32VouNum = GetPar( "VouNum");
                  AV33cCosto = GetPar( "cCosto");
                  AV34cCuenta1 = GetPar( "cCuenta1");
                  AV35cCuenta2 = GetPar( "cCuenta2");
                  AV42cOpc = (short)(NumberUtil.Val( GetPar( "cOpc"), "."));
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

      public r_librodiariopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_librodiariopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref int aP2_TASICod ,
                           ref string aP3_VouNum ,
                           ref string aP4_cCosto ,
                           ref string aP5_cCuenta1 ,
                           ref string aP6_cCuenta2 ,
                           ref short aP7_cOpc )
      {
         this.AV11Ano = aP0_Ano;
         this.AV12Mes = aP1_Mes;
         this.AV31TASICod = aP2_TASICod;
         this.AV32VouNum = aP3_VouNum;
         this.AV33cCosto = aP4_cCosto;
         this.AV34cCuenta1 = aP5_cCuenta1;
         this.AV35cCuenta2 = aP6_cCuenta2;
         this.AV42cOpc = aP7_cOpc;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_TASICod=this.AV31TASICod;
         aP3_VouNum=this.AV32VouNum;
         aP4_cCosto=this.AV33cCosto;
         aP5_cCuenta1=this.AV34cCuenta1;
         aP6_cCuenta2=this.AV35cCuenta2;
         aP7_cOpc=this.AV42cOpc;
      }

      public short executeUdp( ref short aP0_Ano ,
                               ref short aP1_Mes ,
                               ref int aP2_TASICod ,
                               ref string aP3_VouNum ,
                               ref string aP4_cCosto ,
                               ref string aP5_cCuenta1 ,
                               ref string aP6_cCuenta2 )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_TASICod, ref aP3_VouNum, ref aP4_cCosto, ref aP5_cCuenta1, ref aP6_cCuenta2, ref aP7_cOpc);
         return AV42cOpc ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref int aP2_TASICod ,
                                 ref string aP3_VouNum ,
                                 ref string aP4_cCosto ,
                                 ref string aP5_cCuenta1 ,
                                 ref string aP6_cCuenta2 ,
                                 ref short aP7_cOpc )
      {
         r_librodiariopdf objr_librodiariopdf;
         objr_librodiariopdf = new r_librodiariopdf();
         objr_librodiariopdf.AV11Ano = aP0_Ano;
         objr_librodiariopdf.AV12Mes = aP1_Mes;
         objr_librodiariopdf.AV31TASICod = aP2_TASICod;
         objr_librodiariopdf.AV32VouNum = aP3_VouNum;
         objr_librodiariopdf.AV33cCosto = aP4_cCosto;
         objr_librodiariopdf.AV34cCuenta1 = aP5_cCuenta1;
         objr_librodiariopdf.AV35cCuenta2 = aP6_cCuenta2;
         objr_librodiariopdf.AV42cOpc = aP7_cOpc;
         objr_librodiariopdf.context.SetSubmitInitialConfig(context);
         objr_librodiariopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_librodiariopdf);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV12Mes;
         aP2_TASICod=this.AV31TASICod;
         aP3_VouNum=this.AV32VouNum;
         aP4_cCosto=this.AV33cCosto;
         aP5_cCuenta1=this.AV34cCuenta1;
         aP6_cCuenta2=this.AV35cCuenta2;
         aP7_cOpc=this.AV42cOpc;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_librodiariopdf)stateInfo).executePrivate();
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
            AV52EmpRUC = AV30Session.Get("EmpRUC");
            AV54Ruta = AV30Session.Get("RUTA") + "/Logo.jpg";
            AV53Logo = AV54Ruta;
            AV61Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            AV51FechaC = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV12Mes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0));
            AV16FechaD = context.localUtil.CToD( AV51FechaC, 2);
            GXt_char1 = AV50cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV12Mes, out  GXt_char1) ;
            AV50cMes = GXt_char1;
            AV13Titulo = "Libro Diario";
            AV14Periodo = "Año : " + StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + " Mes : " + AV50cMes;
            AV55TDebePagMo = 0.00m;
            AV56THaberPagMo = 0.00m;
            AV57TDebePagMe = 0.00m;
            AV58THaberPagMe = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV31TASICod ,
                                                 AV32VouNum ,
                                                 A126TASICod ,
                                                 A129VouNum ,
                                                 A2077VouSts ,
                                                 AV11Ano ,
                                                 AV12Mes ,
                                                 A127VouAno ,
                                                 A128VouMes } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00B12 */
            pr_default.execute(0, new Object[] {AV11Ano, AV12Mes, AV31TASICod, AV32VouNum});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A129VouNum = P00B12_A129VouNum[0];
               A126TASICod = P00B12_A126TASICod[0];
               A128VouMes = P00B12_A128VouMes[0];
               A127VouAno = P00B12_A127VouAno[0];
               A2077VouSts = P00B12_A2077VouSts[0];
               A2075VouGls = P00B12_A2075VouGls[0];
               A1895TASIDsc = P00B12_A1895TASIDsc[0];
               A2074VouFec = P00B12_A2074VouFec[0];
               A1895TASIDsc = P00B12_A1895TASIDsc[0];
               AV47TDebeMO = 0.00m;
               AV48ThaberMO = 0.00m;
               AV39TDebeME = 0.00m;
               AV40THaberME = 0.00m;
               AV49Glosa = StringUtil.Trim( A2075VouGls);
               HB10( false, 20) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2075VouGls, "")), 307, Gx_line+3, 829, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A2074VouFec, "99/99/99"), 239, Gx_line+3, 286, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 147, Gx_line+3, 200, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1895TASIDsc, "")), 16, Gx_line+3, 144, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV34cCuenta1 ,
                                                    AV35cCuenta2 ,
                                                    AV33cCosto ,
                                                    A91CueCod ,
                                                    A79COSCod ,
                                                    A126TASICod ,
                                                    A129VouNum ,
                                                    A127VouAno ,
                                                    A128VouMes } ,
                                                    new int[]{
                                                    TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                                    }
               });
               /* Using cursor P00B13 */
               pr_default.execute(1, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum, AV34cCuenta1, AV35cCuenta2, AV33cCosto});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  BRKB14 = false;
                  A91CueCod = P00B13_A91CueCod[0];
                  A131VouDMon = P00B13_A131VouDMon[0];
                  A2051VouDDeb = P00B13_A2051VouDDeb[0];
                  A2055VouDHab = P00B13_A2055VouDHab[0];
                  A2052VouDDebO = P00B13_A2052VouDDebO[0];
                  A2056VouDHabO = P00B13_A2056VouDHabO[0];
                  A2054VouDGls = P00B13_A2054VouDGls[0];
                  A136VouReg = P00B13_A136VouReg[0];
                  A133CueCodAux = P00B13_A133CueCodAux[0];
                  A135VouDFec = P00B13_A135VouDFec[0];
                  A2053VouDDoc = P00B13_A2053VouDDoc[0];
                  A79COSCod = P00B13_A79COSCod[0];
                  n79COSCod = P00B13_n79COSCod[0];
                  A2069VouDTcmb = P00B13_A2069VouDTcmb[0];
                  A860CueDsc = P00B13_A860CueDsc[0];
                  A130VouDSec = P00B13_A130VouDSec[0];
                  A860CueDsc = P00B13_A860CueDsc[0];
                  AV25CueCod = A91CueCod;
                  AV41CueDsc = A860CueDsc;
                  AV22TDebe = 0.00m;
                  AV23THaber = 0.00m;
                  AV45TDebeE = 0.00m;
                  AV46THaberE = 0.00m;
                  while ( (pr_default.getStatus(1) != 101) && ( P00B13_A127VouAno[0] == A127VouAno ) && ( P00B13_A128VouMes[0] == A128VouMes ) && ( StringUtil.StrCmp(P00B13_A91CueCod[0], A91CueCod) == 0 ) )
                  {
                     BRKB14 = false;
                     A131VouDMon = P00B13_A131VouDMon[0];
                     A2051VouDDeb = P00B13_A2051VouDDeb[0];
                     A2055VouDHab = P00B13_A2055VouDHab[0];
                     A2052VouDDebO = P00B13_A2052VouDDebO[0];
                     A2056VouDHabO = P00B13_A2056VouDHabO[0];
                     A2054VouDGls = P00B13_A2054VouDGls[0];
                     A136VouReg = P00B13_A136VouReg[0];
                     A133CueCodAux = P00B13_A133CueCodAux[0];
                     A135VouDFec = P00B13_A135VouDFec[0];
                     A2053VouDDoc = P00B13_A2053VouDDoc[0];
                     A79COSCod = P00B13_A79COSCod[0];
                     n79COSCod = P00B13_n79COSCod[0];
                     A130VouDSec = P00B13_A130VouDSec[0];
                     if ( P00B13_A126TASICod[0] == A126TASICod )
                     {
                        if ( StringUtil.StrCmp(P00B13_A129VouNum[0], A129VouNum) == 0 )
                        {
                           if ( StringUtil.StrCmp(A91CueCod, AV25CueCod) == 0 )
                           {
                              AV36VouDMon = A131VouDMon;
                              AV44VouDDeb = A2051VouDDeb;
                              AV43VouDHab = A2055VouDHab;
                              AV37DebeME = ((AV36VouDMon!=1) ? A2052VouDDebO : (decimal)(0));
                              AV38HaberME = ((AV36VouDMon!=1) ? A2056VouDHabO : (decimal)(0));
                              if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) )
                              {
                                 AV49Glosa = StringUtil.Trim( A2054VouDGls);
                              }
                              if ( AV42cOpc == 1 )
                              {
                                 HB10( false, 17) ;
                                 getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), 96, Gx_line+1, 175, Gx_line+16, 0+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A79COSCod, "")), 192, Gx_line+1, 245, Gx_line+16, 0+256, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2051VouDDeb, "ZZZ,ZZZ,ZZ9.99")), 325, Gx_line+1, 420, Gx_line+16, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A2055VouDHab, "ZZZ,ZZZ,ZZ9.99")), 424, Gx_line+1, 519, Gx_line+16, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2053VouDDoc, "")), 998, Gx_line+1, 1105, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxDrawText(context.localUtil.Format( A135VouDFec, "99/99/99"), 1102, Gx_line+1, 1149, Gx_line+16, 0+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A133CueCodAux, "")), 263, Gx_line+1, 368, Gx_line+16, 0+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37DebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 510, Gx_line+1, 617, Gx_line+16, 2+256, 0, 0, 0) ;
                                 getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38HaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 603, Gx_line+1, 710, Gx_line+16, 2+256, 0, 0, 0) ;
                                 getPrinter().GxAttris("Verdana", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A136VouReg, "")), 0, Gx_line+1, 88, Gx_line+15, 0, 0, 0, 0) ;
                                 getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                                 getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Glosa, "")), 740, Gx_line+1, 988, Gx_line+15, 0, 0, 0, 0) ;
                                 Gx_OldLine = Gx_line;
                                 Gx_line = (int)(Gx_line+17);
                              }
                              AV22TDebe = (decimal)(AV22TDebe+AV44VouDDeb);
                              AV23THaber = (decimal)(AV23THaber+AV43VouDHab);
                              AV45TDebeE = (decimal)(AV45TDebeE+AV37DebeME);
                              AV46THaberE = (decimal)(AV46THaberE+AV38HaberME);
                              AV55TDebePagMo = (decimal)(AV55TDebePagMo+AV44VouDDeb);
                              AV56THaberPagMo = (decimal)(AV56THaberPagMo+AV43VouDHab);
                              AV57TDebePagMe = (decimal)(AV57TDebePagMe+AV37DebeME);
                              AV58THaberPagMe = (decimal)(AV58THaberPagMe+AV38HaberME);
                           }
                        }
                     }
                     BRKB14 = true;
                     pr_default.readNext(1);
                  }
                  if ( AV42cOpc == 2 )
                  {
                     HB10( false, 20) ;
                     getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV22TDebe, "ZZZZZZ,ZZZ,ZZ9.99")), 375, Gx_line+2, 482, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23THaber, "ZZZZZZ,ZZZ,ZZ9.99")), 482, Gx_line+2, 589, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TDebeE, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+2, 693, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46THaberE, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+2, 798, Gx_line+17, 2+256, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CueDsc, "")), 110, Gx_line+2, 411, Gx_line+16, 0, 0, 0, 0) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25CueCod, "")), 18, Gx_line+2, 97, Gx_line+17, 0+256, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  AV47TDebeMO = (decimal)(AV47TDebeMO+AV22TDebe);
                  AV48ThaberMO = (decimal)(AV48ThaberMO+AV23THaber);
                  AV39TDebeME = (decimal)(AV39TDebeME+AV45TDebeE);
                  AV40THaberME = (decimal)(AV40THaberME+AV46THaberE);
                  if ( ! BRKB14 )
                  {
                     BRKB14 = true;
                     pr_default.readNext(1);
                  }
               }
               pr_default.close(1);
               if ( AV42cOpc == 1 )
               {
                  HB10( false, 39) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Asiento :", 157, Gx_line+8, 242, Gx_line+22, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(318, Gx_line+3, 738, Gx_line+3, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 325, Gx_line+8, 432, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 424, Gx_line+8, 531, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 510, Gx_line+8, 617, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40THaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 603, Gx_line+8, 710, Gx_line+23, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 258, Gx_line+8, 311, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
               }
               else
               {
                  HB10( false, 50) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Asiento :", 208, Gx_line+16, 293, Gx_line+30, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(405, Gx_line+10, 825, Gx_line+10, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TDebeMO, "ZZZZZZ,ZZZ,ZZ9.99")), 375, Gx_line+16, 482, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48ThaberMO, "ZZZZZZ,ZZZ,ZZ9.99")), 482, Gx_line+16, 589, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39TDebeME, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+16, 693, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40THaberME, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+16, 798, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A129VouNum, "")), 309, Gx_line+16, 362, Gx_line+31, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HB10( false, 46) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 273, Gx_line+13, 353, Gx_line+27, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 375, Gx_line+14, 482, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 482, Gx_line+14, 589, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TDebePagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+14, 693, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58THaberPagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+14, 798, Gx_line+29, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+46);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HB10( true, 0) ;
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

      protected void HB10( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 322, Gx_line+6, 361, Gx_line+21, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina ", 236, Gx_line+6, 313, Gx_line+20, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55TDebePagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 375, Gx_line+7, 482, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56THaberPagMo, "ZZZZZZ,ZZZ,ZZ9.99")), 482, Gx_line+7, 589, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57TDebePagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 586, Gx_line+7, 693, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58THaberPagMe, "ZZZZZZ,ZZZ,ZZ9.99")), 691, Gx_line+7, 798, Gx_line+22, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+26);
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
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13Titulo, "")), 361, Gx_line+20, 817, Gx_line+54, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14Periodo, "")), 361, Gx_line+51, 817, Gx_line+85, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Empresa, "")), 9, Gx_line+90, 377, Gx_line+108, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52EmpRUC, "")), 9, Gx_line+107, 380, Gx_line+125, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV53Logo)) ? AV61Logo_GXI : AV53Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+9, 167, Gx_line+87) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 1027, Gx_line+27, 1071, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1077, Gx_line+27, 1116, Gx_line+42, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
               if ( AV42cOpc == 1 )
               {
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Cuenta", 118, Gx_line+14, 161, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("C.Costos", 196, Gx_line+14, 247, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Debe", 396, Gx_line+21, 427, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Haber", 486, Gx_line+21, 522, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Documento", 1003, Gx_line+21, 1072, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Fecha", 1111, Gx_line+21, 1146, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Auxiliar", 288, Gx_line+14, 334, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Debe", 581, Gx_line+20, 612, Gx_line+34, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Haber", 666, Gx_line+20, 702, Gx_line+34, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(93, Gx_line+1, 93, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(365, Gx_line+0, 365, Gx_line+35, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(555, Gx_line+1, 555, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(734, Gx_line+1, 734, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Registro", 23, Gx_line+14, 74, Gx_line+28, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Moneda Nacional", 404, Gx_line+2, 504, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Moneda Extranjera", 592, Gx_line+2, 706, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Documento Referencia", 997, Gx_line+3, 1132, Gx_line+17, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+0, 1155, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(365, Gx_line+19, 736, Gx_line+19, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(990, Gx_line+0, 990, Gx_line+35, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(990, Gx_line+19, 1156, Gx_line+19, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Glosa", 842, Gx_line+11, 875, Gx_line+25, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+35);
               }
               else
               {
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Descripción", 203, Gx_line+11, 272, Gx_line+25, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Debe", 445, Gx_line+21, 476, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Haber", 542, Gx_line+21, 578, Gx_line+35, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Debe", 656, Gx_line+20, 687, Gx_line+34, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Haber", 747, Gx_line+20, 783, Gx_line+34, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Cuenta", 26, Gx_line+11, 69, Gx_line+25, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Importe Moneda Nacional", 430, Gx_line+2, 582, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText("Importe Moneda Extranjera", 624, Gx_line+2, 790, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawRect(0, Gx_line+0, 1023, Gx_line+36, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(104, Gx_line+1, 104, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(410, Gx_line+0, 410, Gx_line+35, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(615, Gx_line+1, 615, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(821, Gx_line+1, 821, Gx_line+36, 1, 0, 0, 0, 0) ;
                  getPrinter().GxDrawLine(410, Gx_line+18, 821, Gx_line+18, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
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
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
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
         AV61Logo_GXI = "";
         AV51FechaC = "";
         AV16FechaD = DateTime.MinValue;
         AV50cMes = "";
         GXt_char1 = "";
         AV13Titulo = "";
         AV14Periodo = "";
         scmdbuf = "";
         A129VouNum = "";
         P00B12_A129VouNum = new string[] {""} ;
         P00B12_A126TASICod = new int[1] ;
         P00B12_A128VouMes = new short[1] ;
         P00B12_A127VouAno = new short[1] ;
         P00B12_A2077VouSts = new short[1] ;
         P00B12_A2075VouGls = new string[] {""} ;
         P00B12_A1895TASIDsc = new string[] {""} ;
         P00B12_A2074VouFec = new DateTime[] {DateTime.MinValue} ;
         A2075VouGls = "";
         A1895TASIDsc = "";
         A2074VouFec = DateTime.MinValue;
         AV49Glosa = "";
         A91CueCod = "";
         A79COSCod = "";
         P00B13_A127VouAno = new short[1] ;
         P00B13_A128VouMes = new short[1] ;
         P00B13_A126TASICod = new int[1] ;
         P00B13_A129VouNum = new string[] {""} ;
         P00B13_A91CueCod = new string[] {""} ;
         P00B13_A131VouDMon = new int[1] ;
         P00B13_A2051VouDDeb = new decimal[1] ;
         P00B13_A2055VouDHab = new decimal[1] ;
         P00B13_A2052VouDDebO = new decimal[1] ;
         P00B13_A2056VouDHabO = new decimal[1] ;
         P00B13_A2054VouDGls = new string[] {""} ;
         P00B13_A136VouReg = new string[] {""} ;
         P00B13_A133CueCodAux = new string[] {""} ;
         P00B13_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00B13_A2053VouDDoc = new string[] {""} ;
         P00B13_A79COSCod = new string[] {""} ;
         P00B13_n79COSCod = new bool[] {false} ;
         P00B13_A2069VouDTcmb = new decimal[1] ;
         P00B13_A860CueDsc = new string[] {""} ;
         P00B13_A130VouDSec = new int[1] ;
         A2054VouDGls = "";
         A136VouReg = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         A2053VouDDoc = "";
         A860CueDsc = "";
         AV25CueCod = "";
         AV41CueDsc = "";
         AV53Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_librodiariopdf__default(),
            new Object[][] {
                new Object[] {
               P00B12_A129VouNum, P00B12_A126TASICod, P00B12_A128VouMes, P00B12_A127VouAno, P00B12_A2077VouSts, P00B12_A2075VouGls, P00B12_A1895TASIDsc, P00B12_A2074VouFec
               }
               , new Object[] {
               P00B13_A127VouAno, P00B13_A128VouMes, P00B13_A126TASICod, P00B13_A129VouNum, P00B13_A91CueCod, P00B13_A131VouDMon, P00B13_A2051VouDDeb, P00B13_A2055VouDHab, P00B13_A2052VouDDebO, P00B13_A2056VouDHabO,
               P00B13_A2054VouDGls, P00B13_A136VouReg, P00B13_A133CueCodAux, P00B13_A135VouDFec, P00B13_A2053VouDDoc, P00B13_A79COSCod, P00B13_n79COSCod, P00B13_A2069VouDTcmb, P00B13_A860CueDsc, P00B13_A130VouDSec
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
      private short AV42cOpc ;
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
      private int Gx_OldLine ;
      private int A131VouDMon ;
      private int A130VouDSec ;
      private int AV36VouDMon ;
      private decimal AV55TDebePagMo ;
      private decimal AV56THaberPagMo ;
      private decimal AV57TDebePagMe ;
      private decimal AV58THaberPagMe ;
      private decimal AV47TDebeMO ;
      private decimal AV48ThaberMO ;
      private decimal AV39TDebeME ;
      private decimal AV40THaberME ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private decimal A2069VouDTcmb ;
      private decimal AV22TDebe ;
      private decimal AV23THaber ;
      private decimal AV45TDebeE ;
      private decimal AV46THaberE ;
      private decimal AV44VouDDeb ;
      private decimal AV43VouDHab ;
      private decimal AV37DebeME ;
      private decimal AV38HaberME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV32VouNum ;
      private string AV33cCosto ;
      private string AV34cCuenta1 ;
      private string AV35cCuenta2 ;
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
      private string A2075VouGls ;
      private string A1895TASIDsc ;
      private string AV49Glosa ;
      private string A91CueCod ;
      private string A79COSCod ;
      private string A2054VouDGls ;
      private string A136VouReg ;
      private string A133CueCodAux ;
      private string A2053VouDDoc ;
      private string A860CueDsc ;
      private string AV25CueCod ;
      private string AV41CueDsc ;
      private string sImgUrl ;
      private DateTime AV16FechaD ;
      private DateTime A2074VouFec ;
      private DateTime A135VouDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKB14 ;
      private bool n79COSCod ;
      private string AV61Logo_GXI ;
      private string AV53Logo ;
      private string Logo ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private int aP2_TASICod ;
      private string aP3_VouNum ;
      private string aP4_cCosto ;
      private string aP5_cCuenta1 ;
      private string aP6_cCuenta2 ;
      private short aP7_cOpc ;
      private IDataStoreProvider pr_default ;
      private string[] P00B12_A129VouNum ;
      private int[] P00B12_A126TASICod ;
      private short[] P00B12_A128VouMes ;
      private short[] P00B12_A127VouAno ;
      private short[] P00B12_A2077VouSts ;
      private string[] P00B12_A2075VouGls ;
      private string[] P00B12_A1895TASIDsc ;
      private DateTime[] P00B12_A2074VouFec ;
      private short[] P00B13_A127VouAno ;
      private short[] P00B13_A128VouMes ;
      private int[] P00B13_A126TASICod ;
      private string[] P00B13_A129VouNum ;
      private string[] P00B13_A91CueCod ;
      private int[] P00B13_A131VouDMon ;
      private decimal[] P00B13_A2051VouDDeb ;
      private decimal[] P00B13_A2055VouDHab ;
      private decimal[] P00B13_A2052VouDDebO ;
      private decimal[] P00B13_A2056VouDHabO ;
      private string[] P00B13_A2054VouDGls ;
      private string[] P00B13_A136VouReg ;
      private string[] P00B13_A133CueCodAux ;
      private DateTime[] P00B13_A135VouDFec ;
      private string[] P00B13_A2053VouDDoc ;
      private string[] P00B13_A79COSCod ;
      private bool[] P00B13_n79COSCod ;
      private decimal[] P00B13_A2069VouDTcmb ;
      private string[] P00B13_A860CueDsc ;
      private int[] P00B13_A130VouDSec ;
   }

   public class r_librodiariopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B12( IGxContext context ,
                                             int AV31TASICod ,
                                             string AV32VouNum ,
                                             int A126TASICod ,
                                             string A129VouNum ,
                                             short A2077VouSts ,
                                             short AV11Ano ,
                                             short AV12Mes ,
                                             short A127VouAno ,
                                             short A128VouMes )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[VouNum], T1.[TASICod], T1.[VouMes], T1.[VouAno], T1.[VouSts], T1.[VouGls], T2.[TASIDsc], T1.[VouFec] FROM ([CBVOUCHER] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod])";
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32VouNum)) )
         {
            AddWhere(sWhereString, "(T1.[VouNum] = @AV32VouNum)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00B13( IGxContext context ,
                                             string AV34cCuenta1 ,
                                             string AV35cCuenta2 ,
                                             string AV33cCosto ,
                                             string A91CueCod ,
                                             string A79COSCod ,
                                             int A126TASICod ,
                                             string A129VouNum ,
                                             short A127VouAno ,
                                             short A128VouMes )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[7];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[CueCod], T1.[VouDMon], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDHabO], T1.[VouDGls], T1.[VouReg], T1.[CueCodAux], T1.[VouDFec], T1.[VouDDoc], T1.[COSCod], T1.[VouDTcmb], T2.[CueDsc], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         AddWhere(sWhereString, "(T1.[VouAno] = @VouAno and T1.[VouMes] = @VouMes)");
         AddWhere(sWhereString, "(T1.[TASICod] = @TASICod)");
         AddWhere(sWhereString, "(T1.[VouNum] = @VouNum)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34cCuenta1)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] >= @AV34cCuenta1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35cCuenta2)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] <= @AV35cCuenta2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33cCosto)) )
         {
            AddWhere(sWhereString, "(T1.[COSCod] = @AV33cCosto)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VouAno], T1.[VouMes], T1.[CueCod]";
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
                     return conditional_P00B12(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
               case 1 :
                     return conditional_P00B13(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmP00B12;
          prmP00B12 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV12Mes",GXType.Int16,2,0) ,
          new ParDef("@AV31TASICod",GXType.Int32,6,0) ,
          new ParDef("@AV32VouNum",GXType.NChar,10,0)
          };
          Object[] prmP00B13;
          prmP00B13 = new Object[] {
          new ParDef("@VouAno",GXType.Int16,4,0) ,
          new ParDef("@VouMes",GXType.Int16,2,0) ,
          new ParDef("@TASICod",GXType.Int32,6,0) ,
          new ParDef("@VouNum",GXType.NChar,10,0) ,
          new ParDef("@AV34cCuenta1",GXType.Char,15,0) ,
          new ParDef("@AV35cCuenta2",GXType.Char,15,0) ,
          new ParDef("@AV33cCosto",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B13,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 100);
                ((string[]) buf[11])[0] = rslt.getString(12, 15);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 10);
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 100);
                ((int[]) buf[19])[0] = rslt.getInt(19);
                return;
       }
    }

 }

}
