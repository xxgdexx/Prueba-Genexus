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
   public class rrregistroventas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrregistroventas.aspx")), "rrregistroventas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrregistroventas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "jAno");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV46jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV47jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
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

      public rrregistroventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrregistroventas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_jAno ,
                           ref short aP1_jMes )
      {
         this.AV46jAno = aP0_jAno;
         this.AV47jMes = aP1_jMes;
         initialize();
         executePrivate();
         aP0_jAno=this.AV46jAno;
         aP1_jMes=this.AV47jMes;
      }

      public short executeUdp( ref short aP0_jAno )
      {
         execute(ref aP0_jAno, ref aP1_jMes);
         return AV47jMes ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes )
      {
         rrregistroventas objrrregistroventas;
         objrrregistroventas = new rrregistroventas();
         objrrregistroventas.AV46jAno = aP0_jAno;
         objrrregistroventas.AV47jMes = aP1_jMes;
         objrrregistroventas.context.SetSubmitInitialConfig(context);
         objrrregistroventas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrregistroventas);
         aP0_jAno=this.AV46jAno;
         aP1_jMes=this.AV47jMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrregistroventas)stateInfo).executePrivate();
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
            Gx_out = "SCR" ;
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
            AV28Empresa = AV55Session.Get("Empresa");
            AV26EmpDir = AV55Session.Get("EmpDir");
            AV29EmpRUC = AV55Session.Get("EmpRUC");
            AV54Ruta = AV55Session.Get("RUTA") + "/Logo.jpg";
            AV49Logo = AV54Ruta;
            AV74Logo_GXI = GXDbFile.PathToUrl( AV54Ruta);
            GXt_char1 = AV11cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV47jMes, out  GXt_char1) ;
            AV11cMes = GXt_char1;
            AV14DocAbr = "";
            AV20DocNum = "";
            AV18DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV9CliCod = "";
            AV10CliDsc = "";
            AV57SubTotal = 0.00m;
            AV25Dscto = 0.00m;
            AV44Igv = 0.00m;
            AV45Isc = 0.00m;
            AV65TotalMN = 0.00m;
            AV66TotalMO = 0.00m;
            AV60TipCmb = "";
            AV67TSubTotal = 0.00m;
            AV68TSubTotalI = 0.00m;
            AV69TTDscto = 0.00m;
            AV59TIGV = 0.00m;
            AV63TISC = 0.00m;
            AV70TTotalMN = 0.00m;
            AV36GSubAfePag = 0.00m;
            AV38GSubInaPag = 0.00m;
            AV33GIGVPag = 0.00m;
            AV35GISCPag = 0.00m;
            AV42GTotPag = 0.00m;
            /* Using cursor P008Z2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A306TipAbr = P008Z2_A306TipAbr[0];
               A511TipSigno = P008Z2_A511TipSigno[0];
               A1921TipVta = P008Z2_A1921TipVta[0];
               A149TipCod = P008Z2_A149TipCod[0];
               AV39GSubTotal = 0.00m;
               AV37GSubIna = 0.00m;
               AV31GDscto = 0.00m;
               AV32GIgv = 0.00m;
               AV34GIsc = 0.00m;
               AV40GTotalMN = 0.00m;
               AV41GTotalMO = 0.00m;
               AV61TipCod = A149TipCod;
               AV71ValidaAnulado = 0;
               /* Using cursor P008Z4 */
               pr_default.execute(1, new Object[] {AV61TipCod, AV46jAno, AV47jMes});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A149TipCod = P008Z4_A149TipCod[0];
                  A232DocFec = P008Z4_A232DocFec[0];
                  A230DocMonCod = P008Z4_A230DocMonCod[0];
                  A1233MonAbr = P008Z4_A1233MonAbr[0];
                  n1233MonAbr = P008Z4_n1233MonAbr[0];
                  A929DocFecRef = P008Z4_A929DocFecRef[0];
                  A231DocCliCod = P008Z4_A231DocCliCod[0];
                  A887DocCliDsc = P008Z4_A887DocCliDsc[0];
                  A936DocObs = P008Z4_A936DocObs[0];
                  A941DocSts = P008Z4_A941DocSts[0];
                  A939DocRef = P008Z4_A939DocRef[0];
                  A946DocTipo = P008Z4_A946DocTipo[0];
                  A24DocNum = P008Z4_A24DocNum[0];
                  A943DocSubGratuitoIna = P008Z4_A943DocSubGratuitoIna[0];
                  A942DocSubGratuito = P008Z4_A942DocSubGratuito[0];
                  A932DocICBPER = P008Z4_A932DocICBPER[0];
                  A935DocRedondeo = P008Z4_A935DocRedondeo[0];
                  A934DocPorIVA = P008Z4_A934DocPorIVA[0];
                  A882DocAnticipos = P008Z4_A882DocAnticipos[0];
                  A927DocSubExonerado = P008Z4_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P008Z4_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P008Z4_A921DocSubInafecto[0];
                  A920DocSubAfecto = P008Z4_A920DocSubAfecto[0];
                  A899DocDcto = P008Z4_A899DocDcto[0];
                  A1233MonAbr = P008Z4_A1233MonAbr[0];
                  n1233MonAbr = P008Z4_n1233MonAbr[0];
                  A887DocCliDsc = P008Z4_A887DocCliDsc[0];
                  A943DocSubGratuitoIna = P008Z4_A943DocSubGratuitoIna[0];
                  A942DocSubGratuito = P008Z4_A942DocSubGratuito[0];
                  A927DocSubExonerado = P008Z4_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P008Z4_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P008Z4_A921DocSubInafecto[0];
                  A920DocSubAfecto = P008Z4_A920DocSubAfecto[0];
                  A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                  A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                  A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
                  A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
                  AV51MonCod = A230DocMonCod;
                  AV61TipCod = A149TipCod;
                  AV50MonAbr = A1233MonAbr;
                  AV62TipVenta = 1.00000m;
                  AV60TipCmb = "";
                  AV14DocAbr = A306TipAbr;
                  AV48Len = StringUtil.Len( A24DocNum);
                  AV23DocSer = ((AV48Len==10) ? StringUtil.Substring( A24DocNum, 1, 3) : StringUtil.Substring( A24DocNum, 1, 4));
                  AV20DocNum = ((AV48Len==10) ? StringUtil.Substring( A24DocNum, 4, 7) : StringUtil.Substring( A24DocNum, 5, 9));
                  AV18DocFec = A232DocFec;
                  AV19DocFecRef = A929DocFecRef;
                  AV9CliCod = A231DocCliCod;
                  AV10CliDsc = ((StringUtil.StrCmp(A231DocCliCod, "0000000000")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A936DocObs)) ? StringUtil.Trim( A887DocCliDsc) : StringUtil.Trim( A936DocObs)) : StringUtil.Trim( A887DocCliDsc));
                  AV24DocSts = A941DocSts;
                  AV13ComRef = A939DocRef;
                  AV57SubTotal = 0.00m;
                  AV56SubIna = 0.00m;
                  AV25Dscto = 0.00m;
                  AV44Igv = 0.00m;
                  AV45Isc = 0.00m;
                  AV65TotalMN = 0.00m;
                  AV66TotalMO = 0.00m;
                  AV8DocTipo = A946DocTipo;
                  if ( AV51MonCod != 1 )
                  {
                     GXt_decimal2 = AV62TipVenta;
                     GXt_char1 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV51MonCod, ref  AV18DocFec, ref  GXt_char1, out  GXt_decimal2) ;
                     AV62TipVenta = GXt_decimal2;
                     AV60TipCmb = StringUtil.Trim( StringUtil.Str( AV62TipVenta, 10, 5));
                     if ( ( StringUtil.StrCmp(AV61TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV61TipCod, "ND") == 0 ) )
                     {
                        GXt_decimal2 = AV62TipVenta;
                        GXt_char1 = "V";
                        new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV51MonCod, ref  AV19DocFecRef, ref  GXt_char1, out  GXt_decimal2) ;
                        AV62TipVenta = GXt_decimal2;
                        AV60TipCmb = StringUtil.Trim( StringUtil.Str( AV62TipVenta, 10, 5));
                     }
                  }
                  if ( StringUtil.StrCmp(AV24DocSts, "A") != 0 )
                  {
                     AV57SubTotal = (decimal)(((A920DocSubAfecto)*AV62TipVenta)*A511TipSigno);
                     AV25Dscto = (decimal)((NumberUtil.Round( A918DocDscto, 2)*AV62TipVenta)*A511TipSigno);
                     AV15DocAnticipos = (decimal)((NumberUtil.Round( A882DocAnticipos, 2)*AV62TipVenta)*A511TipSigno);
                     AV56SubIna = (decimal)((NumberUtil.Round( A921DocSubInafecto+A942DocSubGratuito+A943DocSubGratuitoIna, 2)*AV62TipVenta)*A511TipSigno);
                     AV57SubTotal = (decimal)(AV57SubTotal-(AV25Dscto+AV15DocAnticipos));
                     if ( StringUtil.StrCmp(AV8DocTipo, "X") == 0 )
                     {
                        AV56SubIna = (decimal)(AV56SubIna+(((Convert.ToDecimal(0)==AV57SubTotal) ? (decimal)(0) : AV57SubTotal)));
                        AV57SubTotal = 0;
                     }
                     AV44Igv = (decimal)((NumberUtil.Round( A933DocIVA, 2)*AV62TipVenta)*A511TipSigno);
                     AV45Isc = (decimal)((NumberUtil.Round( A922DocSubSelectivo, 2)*AV62TipVenta)*A511TipSigno);
                     AV65TotalMN = (decimal)((NumberUtil.Round( A948DocTot, 2)*AV62TipVenta)*A511TipSigno);
                     AV66TotalMO = (decimal)(NumberUtil.Round( A948DocTot, 2)*A511TipSigno);
                  }
                  else
                  {
                     AV57SubTotal = 0.00m;
                     AV56SubIna = 0.00m;
                     AV25Dscto = 0.00m;
                     AV44Igv = 0.00m;
                     AV45Isc = 0.00m;
                     AV65TotalMN = 0.00m;
                     AV66TotalMO = 0.00m;
                     AV9CliCod = "";
                     AV10CliDsc = "ANULADO";
                     AV71ValidaAnulado = 1;
                  }
                  AV39GSubTotal = (decimal)(AV39GSubTotal+AV57SubTotal);
                  AV37GSubIna = (decimal)(AV37GSubIna+AV56SubIna);
                  AV31GDscto = (decimal)(AV31GDscto+AV25Dscto);
                  AV32GIgv = (decimal)(AV32GIgv+AV44Igv);
                  AV34GIsc = (decimal)(AV34GIsc+AV45Isc);
                  AV40GTotalMN = (decimal)(AV40GTotalMN+AV65TotalMN);
                  AV41GTotalMO = (decimal)(AV41GTotalMO+AV66TotalMO);
                  H8Z0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10CliDsc, "")), 349, Gx_line+1, 587, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9CliCod, "")), 270, Gx_line+1, 342, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20DocNum, "")), 119, Gx_line+1, 182, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV18DocFec, "99/99/99"), 2, Gx_line+1, 49, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57SubTotal, "ZZ,ZZZ,ZZ9.99")), 569, Gx_line+1, 666, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 650, Gx_line+1, 747, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 891, Gx_line+1, 988, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TipCmb, "")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+1, 828, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14DocAbr, "")), 55, Gx_line+1, 87, Gx_line+15, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23DocSer, "")), 90, Gx_line+1, 122, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ComRef, "")), 179, Gx_line+1, 259, Gx_line+16, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 976, Gx_line+1, 1073, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45Isc, "ZZZZZZ,ZZZ,ZZ9.99")), 806, Gx_line+1, 903, Gx_line+15, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  AV36GSubAfePag = (decimal)(AV36GSubAfePag+AV57SubTotal);
                  AV38GSubInaPag = (decimal)(AV38GSubInaPag+AV56SubIna);
                  AV33GIGVPag = (decimal)(AV33GIGVPag+AV44Igv);
                  AV35GISCPag = (decimal)(AV35GISCPag+AV45Isc);
                  AV42GTotPag = (decimal)(AV42GTotPag+AV65TotalMN);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV67TSubTotal = (decimal)(AV67TSubTotal+AV39GSubTotal);
               AV68TSubTotalI = (decimal)(AV68TSubTotalI+AV37GSubIna);
               AV69TTDscto = (decimal)(AV69TTDscto+AV31GDscto);
               AV59TIGV = (decimal)(AV59TIGV+AV32GIgv);
               AV63TISC = (decimal)(AV63TISC+AV34GIsc);
               AV70TTotalMN = (decimal)(AV70TTotalMN+AV40GTotalMN);
               if ( ! (Convert.ToDecimal(0)==AV40GTotalMN) || ( AV71ValidaAnulado == 1 ) )
               {
                  AV64Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
                  H8Z0( false, 57) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Totales, "")), 96, Gx_line+10, 561, Gx_line+24, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+11, 666, Gx_line+25, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 650, Gx_line+11, 747, Gx_line+25, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 891, Gx_line+11, 988, Gx_line+25, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(573, Gx_line+7, 1073, Gx_line+7, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+10, 828, Gx_line+25, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GIsc, "ZZZZZZ,ZZZ,ZZ9.99")), 806, Gx_line+11, 903, Gx_line+25, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+57);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H8Z0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67TSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 569, Gx_line+10, 666, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TIGV, "ZZZZZZ,ZZZ,ZZ9.99")), 650, Gx_line+10, 747, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV70TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 891, Gx_line+10, 988, Gx_line+24, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(571, Gx_line+4, 1074, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 481, Gx_line+14, 561, Gx_line+28, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+10, 828, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63TISC, "ZZZZZZ,ZZZ,ZZ9.99")), 806, Gx_line+10, 903, Gx_line+24, 2, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8Z0( true, 0) ;
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

      protected void H8Z0( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina : ", 435, Gx_line+32, 518, Gx_line+46, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 523, Gx_line+32, 562, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GSubAfePag, "ZZ,ZZZ,ZZ9.99")), 559, Gx_line+32, 654, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33GIGVPag, "ZZ,ZZZ,ZZ9.99")), 641, Gx_line+32, 736, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38GSubInaPag, "ZZZZZZ,ZZZ,ZZ9.99")), 721, Gx_line+32, 828, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GTotPag, "ZZZZZZ,ZZZ,ZZ9.99")), 881, Gx_line+32, 988, Gx_line+47, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35GISCPag, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+32, 904, Gx_line+47, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+68);
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
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Registro de Ventas", 471, Gx_line+53, 633, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 376, Gx_line+93, 422, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 554, Gx_line+93, 600, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46jAno), "ZZZ9")), 444, Gx_line+93, 483, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11cMes, "")), 621, Gx_line+93, 731, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29EmpRUC, "")), 6, Gx_line+110, 377, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Empresa, "")), 6, Gx_line+93, 374, Gx_line+111, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV49Logo)) ? AV74Logo_GXI : AV49Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 7, Gx_line+7, 177, Gx_line+84) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1048, Gx_line+28, 1087, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 998, Gx_line+28, 1042, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+138);
               getPrinter().GxDrawRect(0, Gx_line+0, 1139, Gx_line+45, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(54, Gx_line+0, 54, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 13, Gx_line+6, 48, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(86, Gx_line+0, 86, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(347, Gx_line+0, 347, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre o", 442, Gx_line+6, 499, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas", 605, Gx_line+6, 647, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(667, Gx_line+0, 667, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("I.G.V.", 693, Gx_line+15, 724, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(828, Gx_line+0, 828, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MN", 920, Gx_line+15, 972, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(989, Gx_line+0, 989, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T.Cambio", 1080, Gx_line+15, 1135, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(585, Gx_line+0, 585, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(750, Gx_line+0, 750, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 6, Gx_line+21, 52, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 60, Gx_line+15, 83, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(176, Gx_line+0, 176, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprobante", 92, Gx_line+2, 173, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de pago", 110, Gx_line+16, 158, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ser.   Numero", 91, Gx_line+27, 170, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("R.U.C.", 284, Gx_line+21, 318, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 277, Gx_line+6, 324, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Razon Social", 432, Gx_line+21, 507, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia", 185, Gx_line+21, 250, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(260, Gx_line+0, 260, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Gravadas", 598, Gx_line+21, 655, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ventas", 769, Gx_line+6, 811, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("No Gravadas", 753, Gx_line+21, 828, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1075, Gx_line+0, 1075, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MO", 1005, Gx_line+15, 1058, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Documento", 183, Gx_line+6, 252, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(904, Gx_line+0, 904, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("I.S.C.", 852, Gx_line+15, 882, Gx_line+29, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+45);
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
         AV28Empresa = "";
         AV55Session = context.GetSession();
         AV26EmpDir = "";
         AV29EmpRUC = "";
         AV54Ruta = "";
         AV49Logo = "";
         AV74Logo_GXI = "";
         AV11cMes = "";
         AV14DocAbr = "";
         AV20DocNum = "";
         AV18DocFec = DateTime.MinValue;
         AV9CliCod = "";
         AV10CliDsc = "";
         AV60TipCmb = "";
         scmdbuf = "";
         P008Z2_A306TipAbr = new string[] {""} ;
         P008Z2_A511TipSigno = new short[1] ;
         P008Z2_A1921TipVta = new short[1] ;
         P008Z2_A149TipCod = new string[] {""} ;
         A306TipAbr = "";
         A149TipCod = "";
         AV61TipCod = "";
         P008Z4_A149TipCod = new string[] {""} ;
         P008Z4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P008Z4_A230DocMonCod = new int[1] ;
         P008Z4_A1233MonAbr = new string[] {""} ;
         P008Z4_n1233MonAbr = new bool[] {false} ;
         P008Z4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P008Z4_A231DocCliCod = new string[] {""} ;
         P008Z4_A887DocCliDsc = new string[] {""} ;
         P008Z4_A936DocObs = new string[] {""} ;
         P008Z4_A941DocSts = new string[] {""} ;
         P008Z4_A939DocRef = new string[] {""} ;
         P008Z4_A946DocTipo = new string[] {""} ;
         P008Z4_A24DocNum = new string[] {""} ;
         P008Z4_A943DocSubGratuitoIna = new decimal[1] ;
         P008Z4_A942DocSubGratuito = new decimal[1] ;
         P008Z4_A932DocICBPER = new decimal[1] ;
         P008Z4_A935DocRedondeo = new decimal[1] ;
         P008Z4_A934DocPorIVA = new decimal[1] ;
         P008Z4_A882DocAnticipos = new decimal[1] ;
         P008Z4_A927DocSubExonerado = new decimal[1] ;
         P008Z4_A922DocSubSelectivo = new decimal[1] ;
         P008Z4_A921DocSubInafecto = new decimal[1] ;
         P008Z4_A920DocSubAfecto = new decimal[1] ;
         P008Z4_A899DocDcto = new decimal[1] ;
         A232DocFec = DateTime.MinValue;
         A1233MonAbr = "";
         A929DocFecRef = DateTime.MinValue;
         A231DocCliCod = "";
         A887DocCliDsc = "";
         A936DocObs = "";
         A941DocSts = "";
         A939DocRef = "";
         A946DocTipo = "";
         A24DocNum = "";
         AV50MonAbr = "";
         AV23DocSer = "";
         AV19DocFecRef = DateTime.MinValue;
         AV24DocSts = "";
         AV13ComRef = "";
         AV8DocTipo = "";
         GXt_char1 = "";
         AV64Totales = "";
         AV49Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrregistroventas__default(),
            new Object[][] {
                new Object[] {
               P008Z2_A306TipAbr, P008Z2_A511TipSigno, P008Z2_A1921TipVta, P008Z2_A149TipCod
               }
               , new Object[] {
               P008Z4_A149TipCod, P008Z4_A232DocFec, P008Z4_A230DocMonCod, P008Z4_A1233MonAbr, P008Z4_n1233MonAbr, P008Z4_A929DocFecRef, P008Z4_A231DocCliCod, P008Z4_A887DocCliDsc, P008Z4_A936DocObs, P008Z4_A941DocSts,
               P008Z4_A939DocRef, P008Z4_A946DocTipo, P008Z4_A24DocNum, P008Z4_A943DocSubGratuitoIna, P008Z4_A942DocSubGratuito, P008Z4_A932DocICBPER, P008Z4_A935DocRedondeo, P008Z4_A934DocPorIVA, P008Z4_A882DocAnticipos, P008Z4_A927DocSubExonerado,
               P008Z4_A922DocSubSelectivo, P008Z4_A921DocSubInafecto, P008Z4_A920DocSubAfecto, P008Z4_A899DocDcto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV46jAno ;
      private short AV47jMes ;
      private short A511TipSigno ;
      private short A1921TipVta ;
      private short AV71ValidaAnulado ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A230DocMonCod ;
      private int AV51MonCod ;
      private int Gx_OldLine ;
      private long AV48Len ;
      private decimal AV57SubTotal ;
      private decimal AV25Dscto ;
      private decimal AV44Igv ;
      private decimal AV45Isc ;
      private decimal AV65TotalMN ;
      private decimal AV66TotalMO ;
      private decimal AV67TSubTotal ;
      private decimal AV68TSubTotalI ;
      private decimal AV69TTDscto ;
      private decimal AV59TIGV ;
      private decimal AV63TISC ;
      private decimal AV70TTotalMN ;
      private decimal AV36GSubAfePag ;
      private decimal AV38GSubInaPag ;
      private decimal AV33GIGVPag ;
      private decimal AV35GISCPag ;
      private decimal AV42GTotPag ;
      private decimal AV39GSubTotal ;
      private decimal AV37GSubIna ;
      private decimal AV31GDscto ;
      private decimal AV32GIgv ;
      private decimal AV34GIsc ;
      private decimal AV40GTotalMN ;
      private decimal AV41GTotalMO ;
      private decimal A943DocSubGratuitoIna ;
      private decimal A942DocSubGratuito ;
      private decimal A932DocICBPER ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A882DocAnticipos ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV62TipVenta ;
      private decimal AV56SubIna ;
      private decimal GXt_decimal2 ;
      private decimal AV15DocAnticipos ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV28Empresa ;
      private string AV26EmpDir ;
      private string AV29EmpRUC ;
      private string AV54Ruta ;
      private string AV11cMes ;
      private string AV14DocAbr ;
      private string AV20DocNum ;
      private string AV9CliCod ;
      private string AV10CliDsc ;
      private string AV60TipCmb ;
      private string scmdbuf ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private string AV61TipCod ;
      private string A1233MonAbr ;
      private string A231DocCliCod ;
      private string A887DocCliDsc ;
      private string A941DocSts ;
      private string A939DocRef ;
      private string A946DocTipo ;
      private string A24DocNum ;
      private string AV50MonAbr ;
      private string AV23DocSer ;
      private string AV24DocSts ;
      private string AV13ComRef ;
      private string AV8DocTipo ;
      private string GXt_char1 ;
      private string AV64Totales ;
      private string sImgUrl ;
      private DateTime AV18DocFec ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV19DocFecRef ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1233MonAbr ;
      private string A936DocObs ;
      private string AV74Logo_GXI ;
      private string AV49Logo ;
      private string Logo ;
      private IGxSession AV55Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private IDataStoreProvider pr_default ;
      private string[] P008Z2_A306TipAbr ;
      private short[] P008Z2_A511TipSigno ;
      private short[] P008Z2_A1921TipVta ;
      private string[] P008Z2_A149TipCod ;
      private string[] P008Z4_A149TipCod ;
      private DateTime[] P008Z4_A232DocFec ;
      private int[] P008Z4_A230DocMonCod ;
      private string[] P008Z4_A1233MonAbr ;
      private bool[] P008Z4_n1233MonAbr ;
      private DateTime[] P008Z4_A929DocFecRef ;
      private string[] P008Z4_A231DocCliCod ;
      private string[] P008Z4_A887DocCliDsc ;
      private string[] P008Z4_A936DocObs ;
      private string[] P008Z4_A941DocSts ;
      private string[] P008Z4_A939DocRef ;
      private string[] P008Z4_A946DocTipo ;
      private string[] P008Z4_A24DocNum ;
      private decimal[] P008Z4_A943DocSubGratuitoIna ;
      private decimal[] P008Z4_A942DocSubGratuito ;
      private decimal[] P008Z4_A932DocICBPER ;
      private decimal[] P008Z4_A935DocRedondeo ;
      private decimal[] P008Z4_A934DocPorIVA ;
      private decimal[] P008Z4_A882DocAnticipos ;
      private decimal[] P008Z4_A927DocSubExonerado ;
      private decimal[] P008Z4_A922DocSubSelectivo ;
      private decimal[] P008Z4_A921DocSubInafecto ;
      private decimal[] P008Z4_A920DocSubAfecto ;
      private decimal[] P008Z4_A899DocDcto ;
   }

   public class rrregistroventas__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008Z2;
          prmP008Z2 = new Object[] {
          };
          Object[] prmP008Z4;
          prmP008Z4 = new Object[] {
          new ParDef("@AV61TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV46jAno",GXType.Int16,4,0) ,
          new ParDef("@AV47jMes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Z2", "SELECT [TipAbr], [TipSigno], [TipVta], [TipCod] FROM [CTIPDOC] WHERE [TipVta] = 1 ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008Z4", "SELECT T1.[TipCod], T1.[DocFec], T1.[DocMonCod] AS DocMonCod, T2.[MonAbr], T1.[DocFecRef], T1.[DocCliCod] AS DocCliCod, T3.[CliDsc] AS DocCliDsc, T1.[DocObs], T1.[DocSts], T1.[DocRef], T1.[DocTipo], T1.[DocNum], COALESCE( T4.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T4.[DocSubGratuito], 0) AS DocSubGratuito, T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM ((([CLVENTAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[DocMonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[DocCliCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (T1.[TipCod] = @AV61TipCod) AND (YEAR(T1.[DocFec]) = @AV46jAno) AND (MONTH(T1.[DocFec]) = @AV47jMes) ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Z4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 1);
                ((string[]) buf[10])[0] = rslt.getString(10, 12);
                ((string[]) buf[11])[0] = rslt.getString(11, 1);
                ((string[]) buf[12])[0] = rslt.getString(12, 12);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                return;
       }
    }

 }

}
