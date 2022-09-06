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
   public class r_registroventasoficialpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.r_registroventasoficialpdf.aspx")), "contabilidad.r_registroventasoficialpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.r_registroventasoficialpdf.aspx")))) ;
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
               AV50jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV51jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
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

      public r_registroventasoficialpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroventasoficialpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_jAno ,
                           ref short aP1_jMes )
      {
         this.AV50jAno = aP0_jAno;
         this.AV51jMes = aP1_jMes;
         initialize();
         executePrivate();
         aP0_jAno=this.AV50jAno;
         aP1_jMes=this.AV51jMes;
      }

      public short executeUdp( ref short aP0_jAno )
      {
         execute(ref aP0_jAno, ref aP1_jMes);
         return AV51jMes ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes )
      {
         r_registroventasoficialpdf objr_registroventasoficialpdf;
         objr_registroventasoficialpdf = new r_registroventasoficialpdf();
         objr_registroventasoficialpdf.AV50jAno = aP0_jAno;
         objr_registroventasoficialpdf.AV51jMes = aP1_jMes;
         objr_registroventasoficialpdf.context.SetSubmitInitialConfig(context);
         objr_registroventasoficialpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroventasoficialpdf);
         aP0_jAno=this.AV50jAno;
         aP1_jMes=this.AV51jMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registroventasoficialpdf)stateInfo).executePrivate();
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
            AV30Empresa = "RAZON SOCIAL : " + AV59Session.Get("Empresa");
            AV28EmpDir = AV59Session.Get("EmpDir");
            AV31EmpRUC = "RUC : " + AV59Session.Get("EmpRUC");
            AV58Ruta = AV59Session.Get("RUTA") + "/Logo.jpg";
            AV52Logo = AV58Ruta;
            AV85Logo_GXI = GXDbFile.PathToUrl( AV58Ruta);
            GXt_char1 = AV10cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV51jMes, out  GXt_char1) ;
            AV10cMes = GXt_char1;
            AV13DocAbr = "";
            AV21DocNum = "";
            AV17DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV8CliCod = "";
            AV9CliDsc = "";
            AV62SubTotal = 0.00m;
            AV27Dscto = 0.00m;
            AV48Igv = 0.00m;
            AV73TotalMN = 0.00m;
            AV74TotalMO = 0.00m;
            AV66TipCmb = "";
            AV76TSubTotal = 0.00m;
            AV77TSubTotalI = 0.00m;
            AV75TSubExp = 0.00m;
            AV78TTDscto = 0.00m;
            AV64TIGV = 0.00m;
            AV71TISC = 0.00m;
            AV79TTotalMN = 0.00m;
            AV38GSubAfePag = 0.00m;
            AV42GSubInaPag = 0.00m;
            AV40GSubExpPag = 0.00m;
            AV35GIGVPag = 0.00m;
            AV46GTotPag = 0.00m;
            AV37GISCPag = 0.00m;
            /* Using cursor P009A2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A306TipAbr = P009A2_A306TipAbr[0];
               A511TipSigno = P009A2_A511TipSigno[0];
               A1921TipVta = P009A2_A1921TipVta[0];
               A149TipCod = P009A2_A149TipCod[0];
               AV43GSubTotal = 0.00m;
               AV41GSubIna = 0.00m;
               AV39GSubExp = 0.00m;
               AV33GDscto = 0.00m;
               AV34GIgv = 0.00m;
               AV36GISC = 0.00m;
               AV44GTotalMN = 0.00m;
               AV45GTotalMO = 0.00m;
               AV67TipCod = A149TipCod;
               AV81ValidaAnulado = 0;
               /* Using cursor P009A4 */
               pr_default.execute(1, new Object[] {AV67TipCod, AV50jAno, AV51jMes});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A157TipSCod = P009A4_A157TipSCod[0];
                  n157TipSCod = P009A4_n157TipSCod[0];
                  A149TipCod = P009A4_A149TipCod[0];
                  A232DocFec = P009A4_A232DocFec[0];
                  A230DocMonCod = P009A4_A230DocMonCod[0];
                  A1233MonAbr = P009A4_A1233MonAbr[0];
                  n1233MonAbr = P009A4_n1233MonAbr[0];
                  A1916TipSAbr = P009A4_A1916TipSAbr[0];
                  A931DocFVcto = P009A4_A931DocFVcto[0];
                  A929DocFecRef = P009A4_A929DocFecRef[0];
                  A939DocRef = P009A4_A939DocRef[0];
                  A950DocTRef = P009A4_A950DocTRef[0];
                  A231DocCliCod = P009A4_A231DocCliCod[0];
                  A887DocCliDsc = P009A4_A887DocCliDsc[0];
                  A936DocObs = P009A4_A936DocObs[0];
                  A941DocSts = P009A4_A941DocSts[0];
                  A946DocTipo = P009A4_A946DocTipo[0];
                  A24DocNum = P009A4_A24DocNum[0];
                  A942DocSubGratuito = P009A4_A942DocSubGratuito[0];
                  A932DocICBPER = P009A4_A932DocICBPER[0];
                  A935DocRedondeo = P009A4_A935DocRedondeo[0];
                  A934DocPorIVA = P009A4_A934DocPorIVA[0];
                  A882DocAnticipos = P009A4_A882DocAnticipos[0];
                  A927DocSubExonerado = P009A4_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P009A4_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P009A4_A921DocSubInafecto[0];
                  A920DocSubAfecto = P009A4_A920DocSubAfecto[0];
                  A899DocDcto = P009A4_A899DocDcto[0];
                  A1233MonAbr = P009A4_A1233MonAbr[0];
                  n1233MonAbr = P009A4_n1233MonAbr[0];
                  A157TipSCod = P009A4_A157TipSCod[0];
                  n157TipSCod = P009A4_n157TipSCod[0];
                  A887DocCliDsc = P009A4_A887DocCliDsc[0];
                  A1916TipSAbr = P009A4_A1916TipSAbr[0];
                  A942DocSubGratuito = P009A4_A942DocSubGratuito[0];
                  A927DocSubExonerado = P009A4_A927DocSubExonerado[0];
                  A922DocSubSelectivo = P009A4_A922DocSubSelectivo[0];
                  A921DocSubInafecto = P009A4_A921DocSubInafecto[0];
                  A920DocSubAfecto = P009A4_A920DocSubAfecto[0];
                  A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                  A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                  A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
                  A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
                  AV54MonCod = A230DocMonCod;
                  AV67TipCod = A149TipCod;
                  AV53MonAbr = A1233MonAbr;
                  AV70TipVenta = 1.00000m;
                  AV66TipCmb = "";
                  AV13DocAbr = A306TipAbr;
                  AV69TipSunat = StringUtil.Trim( A1916TipSAbr);
                  AV55Numero = StringUtil.Trim( A24DocNum);
                  AV82Len = StringUtil.Len( A24DocNum);
                  AV24DocSer = ((AV82Len==10) ? StringUtil.Substring( A24DocNum, 1, 3) : StringUtil.Substring( A24DocNum, 1, 4));
                  AV21DocNum = ((AV82Len==10) ? StringUtil.Substring( A24DocNum, 4, 7) : StringUtil.Substring( A24DocNum, 5, 9));
                  AV17DocFec = A232DocFec;
                  AV20DocFVcto = A931DocFVcto;
                  AV18DocFecRef = A929DocFecRef;
                  AV19DocFRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A939DocRef)) ? "" : context.localUtil.DToC( A929DocFecRef, 2, "/")) : "");
                  AV26DocTRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? A950DocTRef : "");
                  AV8CliCod = A231DocCliCod;
                  AV9CliDsc = ((StringUtil.StrCmp(A231DocCliCod, "0000000000")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A936DocObs)) ? StringUtil.Trim( A887DocCliDsc) : StringUtil.Trim( A936DocObs)) : StringUtil.Trim( A887DocCliDsc));
                  AV25DocSts = A941DocSts;
                  AV12ComRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A950DocTRef)) ? "" : A939DocRef) : "");
                  AV62SubTotal = 0.00m;
                  AV61SubIna = 0.00m;
                  AV60SubExp = 0.00m;
                  AV27Dscto = 0.00m;
                  AV48Igv = 0.00m;
                  AV49Isc = 0.00m;
                  AV73TotalMN = 0.00m;
                  AV74TotalMO = 0.00m;
                  if ( AV54MonCod != 1 )
                  {
                     GXt_decimal2 = AV70TipVenta;
                     GXt_char1 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV54MonCod, ref  AV17DocFec, ref  GXt_char1, out  GXt_decimal2) ;
                     AV70TipVenta = GXt_decimal2;
                     AV66TipCmb = StringUtil.Trim( StringUtil.Str( AV70TipVenta, 10, 5));
                     if ( ( StringUtil.StrCmp(AV67TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV67TipCod, "ND") == 0 ) )
                     {
                        GXt_decimal2 = AV70TipVenta;
                        GXt_char1 = "V";
                        new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV54MonCod, ref  AV18DocFecRef, ref  GXt_char1, out  GXt_decimal2) ;
                        AV70TipVenta = GXt_decimal2;
                        AV66TipCmb = StringUtil.Trim( StringUtil.Str( AV70TipVenta, 10, 5));
                     }
                  }
                  if ( StringUtil.StrCmp(AV25DocSts, "A") != 0 )
                  {
                     if ( StringUtil.StrCmp(A946DocTipo, "E") == 0 )
                     {
                        AV62SubTotal = 0.00m;
                        AV27Dscto = (decimal)((NumberUtil.Round( A918DocDscto, 2)*AV70TipVenta)*A511TipSigno);
                        AV61SubIna = 0.00m;
                        AV14DocAnticipos = (decimal)((NumberUtil.Round( A882DocAnticipos, 2)*AV70TipVenta)*A511TipSigno);
                        AV60SubExp = (decimal)((NumberUtil.Round( (A920DocSubAfecto+A921DocSubInafecto)-(A918DocDscto+A882DocAnticipos), 2)*AV70TipVenta)*A511TipSigno);
                        AV48Igv = (decimal)((NumberUtil.Round( A933DocIVA, 2)*AV70TipVenta)*A511TipSigno);
                        AV49Isc = (decimal)((NumberUtil.Round( A922DocSubSelectivo, 2)*AV70TipVenta)*A511TipSigno);
                        AV73TotalMN = (decimal)((NumberUtil.Round( A948DocTot, 2)*AV70TipVenta)*A511TipSigno);
                        AV74TotalMO = NumberUtil.Round( A948DocTot, 2);
                     }
                     else
                     {
                        AV62SubTotal = (decimal)(((A920DocSubAfecto)*AV70TipVenta)*A511TipSigno);
                        AV27Dscto = (decimal)((NumberUtil.Round( A918DocDscto, 2)*AV70TipVenta)*A511TipSigno);
                        AV61SubIna = (decimal)((NumberUtil.Round( A921DocSubInafecto+A942DocSubGratuito, 2)*AV70TipVenta)*A511TipSigno);
                        AV14DocAnticipos = (decimal)((NumberUtil.Round( A882DocAnticipos, 2)*AV70TipVenta)*A511TipSigno);
                        AV60SubExp = 0.00m;
                        AV48Igv = (decimal)((NumberUtil.Round( A933DocIVA, 2)*AV70TipVenta)*A511TipSigno);
                        AV49Isc = (decimal)((NumberUtil.Round( A922DocSubSelectivo, 2)*AV70TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV27Dscto) || ! (Convert.ToDecimal(0)==AV14DocAnticipos) )
                        {
                           AV62SubTotal = (decimal)(AV62SubTotal-(AV27Dscto+AV14DocAnticipos));
                        }
                        if ( StringUtil.StrCmp(A946DocTipo, "X") == 0 )
                        {
                           AV61SubIna = (decimal)(AV61SubIna+(((Convert.ToDecimal(0)==AV62SubTotal) ? (decimal)(0) : AV62SubTotal)));
                           AV62SubTotal = 0;
                        }
                        AV73TotalMN = (decimal)((NumberUtil.Round( A948DocTot, 2)*AV70TipVenta)*A511TipSigno);
                        AV74TotalMO = NumberUtil.Round( A948DocTot, 2);
                     }
                  }
                  else
                  {
                     AV62SubTotal = 0.00m;
                     AV61SubIna = 0.00m;
                     AV27Dscto = 0.00m;
                     AV48Igv = 0.00m;
                     AV49Isc = 0.00m;
                     AV73TotalMN = 0.00m;
                     AV74TotalMO = 0.00m;
                     AV8CliCod = "";
                     AV69TipSunat = "";
                     AV9CliDsc = "ANULADO";
                     AV81ValidaAnulado = 1;
                  }
                  AV43GSubTotal = (decimal)(AV43GSubTotal+AV62SubTotal);
                  AV41GSubIna = (decimal)(AV41GSubIna+AV61SubIna);
                  AV33GDscto = (decimal)(AV33GDscto+AV27Dscto);
                  AV34GIgv = (decimal)(AV34GIgv+AV48Igv);
                  AV36GISC = (decimal)(AV36GISC+AV49Isc);
                  AV44GTotalMN = (decimal)(AV44GTotalMN+AV73TotalMN);
                  AV45GTotalMO = (decimal)(AV45GTotalMO+AV74TotalMO);
                  AV39GSubExp = (decimal)(AV39GSubExp+AV60SubExp);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DocTRef)) )
                  {
                     AV68Tipo2 = ((StringUtil.StrCmp(AV26DocTRef, "FAC")==0) ? "01" : "03");
                  }
                  H9A0( false, 19) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9CliDsc, "")), 384, Gx_line+1, 609, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8CliCod, "")), 309, Gx_line+1, 383, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocNum, "")), 227, Gx_line+1, 275, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 892, Gx_line+1, 989, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 731, Gx_line+3, 803, Gx_line+14, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12ComRef, "")), 1113, Gx_line+4, 1145, Gx_line+13, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TipCmb, "")), 944, Gx_line+1, 1041, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62SubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 634, Gx_line+1, 731, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49Isc, "ZZZZZZ,ZZZ,ZZ9.99")), 766, Gx_line+1, 863, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV48Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 826, Gx_line+1, 923, Gx_line+15, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV17DocFec, "99/99/99"), 66, Gx_line+3, 98, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24DocSer, "")), 193, Gx_line+1, 220, Gx_line+15, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13DocAbr, "")), 165, Gx_line+2, 185, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Numero, "")), 1, Gx_line+1, 60, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.localUtil.Format( AV20DocFVcto, "99/99/9999"), 115, Gx_line+3, 156, Gx_line+14, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19DocFRef, "")), 1043, Gx_line+2, 1081, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Tipo2, "")), 1083, Gx_line+2, 1106, Gx_line+13, 1, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TipSunat, "")), 282, Gx_line+2, 305, Gx_line+13, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60SubExp, "ZZZZZZ,ZZZ,ZZ9.99")), 596, Gx_line+3, 668, Gx_line+14, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
                  AV38GSubAfePag = (decimal)(AV38GSubAfePag+AV62SubTotal);
                  AV42GSubInaPag = (decimal)(AV42GSubInaPag+AV61SubIna);
                  AV40GSubExpPag = (decimal)(AV40GSubExpPag+AV60SubExp);
                  AV35GIGVPag = (decimal)(AV35GIGVPag+AV48Igv);
                  AV37GISCPag = (decimal)(AV37GISCPag+AV49Isc);
                  AV46GTotPag = (decimal)(AV46GTotPag+AV73TotalMN);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV76TSubTotal = (decimal)(AV76TSubTotal+AV43GSubTotal);
               AV77TSubTotalI = (decimal)(AV77TSubTotalI+AV41GSubIna);
               AV75TSubExp = (decimal)(AV75TSubExp+AV39GSubExp);
               AV78TTDscto = (decimal)(AV78TTDscto+AV33GDscto);
               AV64TIGV = (decimal)(AV64TIGV+AV34GIgv);
               AV71TISC = (decimal)(AV71TISC+AV36GISC);
               AV79TTotalMN = (decimal)(AV79TTotalMN+AV44GTotalMN);
               if ( ! (Convert.ToDecimal(0)==AV44GTotalMN) || ( AV81ValidaAnulado == 1 ) )
               {
                  AV72Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( AV13DocAbr);
                  H9A0( false, 57) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Totales, "")), 115, Gx_line+9, 580, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 634, Gx_line+9, 731, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 826, Gx_line+9, 923, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 892, Gx_line+9, 989, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxDrawLine(633, Gx_line+7, 1073, Gx_line+7, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 731, Gx_line+11, 803, Gx_line+22, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GISC, "ZZZZZZ,ZZZ,ZZ9.99")), 766, Gx_line+9, 863, Gx_line+23, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39GSubExp, "ZZZZZZ,ZZZ,ZZ9.99")), 596, Gx_line+11, 668, Gx_line+22, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+57);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            H9A0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76TSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 634, Gx_line+9, 731, Gx_line+23, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TIGV, "ZZZZZZ,ZZZ,ZZ9.99")), 826, Gx_line+9, 923, Gx_line+23, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 894, Gx_line+9, 989, Gx_line+23, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(633, Gx_line+4, 1074, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 485, Gx_line+11, 541, Gx_line+21, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 731, Gx_line+11, 803, Gx_line+22, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV71TISC, "ZZZZZZ,ZZZ,ZZ9.99")), 766, Gx_line+9, 863, Gx_line+23, 2, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75TSubExp, "ZZZZZZ,ZZZ,ZZ9.99")), 596, Gx_line+11, 668, Gx_line+22, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9A0( true, 0) ;
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

      protected void H9A0( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina : ", 463, Gx_line+20, 522, Gx_line+30, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 527, Gx_line+20, 553, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV38GSubAfePag, "ZZZZZZ,ZZZ,ZZ9.99")), 660, Gx_line+20, 732, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GISCPag, "ZZZZZZ,ZZZ,ZZ9.99")), 774, Gx_line+19, 863, Gx_line+30, 2, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GSubInaPag, "ZZZZZZ,ZZZ,ZZ9.99")), 731, Gx_line+20, 803, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46GTotPag, "ZZZZZZ,ZZZ,ZZ9.99")), 918, Gx_line+20, 990, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35GIGVPag, "ZZZZZZ,ZZZ,ZZ9.99")), 852, Gx_line+20, 924, Gx_line+31, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GSubExpPag, "ZZZZZZ,ZZZ,ZZ9.99")), 596, Gx_line+20, 668, Gx_line+31, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+52);
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
               getPrinter().GxDrawText("Registro de Ventas e Ingresos", 441, Gx_line+53, 697, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 390, Gx_line+93, 436, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 568, Gx_line+93, 614, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV50jAno), "ZZZ9")), 457, Gx_line+93, 496, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV10cMes, "")), 634, Gx_line+93, 744, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 6, Gx_line+110, 377, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Empresa, "")), 6, Gx_line+93, 374, Gx_line+111, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV52Logo)) ? AV85Logo_GXI : AV52Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 7, Gx_line+7, 177, Gx_line+84) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1048, Gx_line+28, 1087, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 998, Gx_line+28, 1042, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FORMATO 14.1", 998, Gx_line+9, 1084, Gx_line+23, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+138);
               getPrinter().GxDrawLine(63, Gx_line+0, 63, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(110, Gx_line+0, 110, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(280, Gx_line+0, 280, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre o", 463, Gx_line+17, 514, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(673, Gx_line+0, 673, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(990, Gx_line+0, 990, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1042, Gx_line+0, 1042, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(606, Gx_line+0, 606, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(925, Gx_line+0, 925, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 70, Gx_line+3, 101, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(163, Gx_line+0, 163, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 122, Gx_line+3, 153, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vcto y/o", 116, Gx_line+17, 161, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 124, Gx_line+30, 151, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Razon Social", 455, Gx_line+29, 521, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(733, Gx_line+0, 733, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Codigo", 16, Gx_line+3, 52, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Unico de", 11, Gx_line+17, 56, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operación", 6, Gx_line+30, 60, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de", 79, Gx_line+17, 93, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 66, Gx_line+30, 107, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(163, Gx_line+21, 281, Gx_line+21, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprobante de Pago", 165, Gx_line+5, 281, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(190, Gx_line+21, 190, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 165, Gx_line+27, 189, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie ", 193, Gx_line+27, 224, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(222, Gx_line+22, 222, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 231, Gx_line+27, 273, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Información de Cliente  ", 348, Gx_line+1, 474, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(280, Gx_line+13, 606, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. de Identidad", 286, Gx_line+16, 378, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(383, Gx_line+13, 383, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(280, Gx_line+27, 384, Gx_line+27, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(307, Gx_line+28, 307, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 283, Gx_line+31, 307, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 324, Gx_line+31, 366, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 689, Gx_line+5, 718, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 939, Gx_line+9, 983, Gx_line+22, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ref. de Comprobante", 1049, Gx_line+2, 1159, Gx_line+15, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1043, Gx_line+15, 1161, Gx_line+15, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1082, Gx_line+15, 1082, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 1084, Gx_line+24, 1105, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1106, Gx_line+16, 1106, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Compr", 1108, Gx_line+24, 1159, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 997, Gx_line+10, 1037, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cambio", 997, Gx_line+23, 1037, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 677, Gx_line+18, 730, Gx_line+31, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 947, Gx_line+24, 975, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1160, Gx_line+46, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 1048, Gx_line+24, 1079, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(863, Gx_line+0, 863, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 755, Gx_line+4, 784, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 744, Gx_line+17, 797, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("IGV", 878, Gx_line+4, 899, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Y/O", 878, Gx_line+17, 900, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("I.S.C.", 823, Gx_line+17, 852, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Gravada", 681, Gx_line+31, 726, Gx_line+44, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Inafecta", 748, Gx_line+30, 793, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("IPM", 877, Gx_line+30, 900, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Valor", 626, Gx_line+4, 655, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Facturado", 615, Gx_line+17, 668, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Exportación", 609, Gx_line+30, 671, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(804, Gx_line+1, 804, Gx_line+46, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+46);
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
         AV30Empresa = "";
         AV59Session = context.GetSession();
         AV28EmpDir = "";
         AV31EmpRUC = "";
         AV58Ruta = "";
         AV52Logo = "";
         AV85Logo_GXI = "";
         AV10cMes = "";
         AV13DocAbr = "";
         AV21DocNum = "";
         AV17DocFec = DateTime.MinValue;
         AV8CliCod = "";
         AV9CliDsc = "";
         AV66TipCmb = "";
         scmdbuf = "";
         P009A2_A306TipAbr = new string[] {""} ;
         P009A2_A511TipSigno = new short[1] ;
         P009A2_A1921TipVta = new short[1] ;
         P009A2_A149TipCod = new string[] {""} ;
         A306TipAbr = "";
         A149TipCod = "";
         AV67TipCod = "";
         P009A4_A157TipSCod = new int[1] ;
         P009A4_n157TipSCod = new bool[] {false} ;
         P009A4_A149TipCod = new string[] {""} ;
         P009A4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009A4_A230DocMonCod = new int[1] ;
         P009A4_A1233MonAbr = new string[] {""} ;
         P009A4_n1233MonAbr = new bool[] {false} ;
         P009A4_A1916TipSAbr = new string[] {""} ;
         P009A4_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         P009A4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P009A4_A939DocRef = new string[] {""} ;
         P009A4_A950DocTRef = new string[] {""} ;
         P009A4_A231DocCliCod = new string[] {""} ;
         P009A4_A887DocCliDsc = new string[] {""} ;
         P009A4_A936DocObs = new string[] {""} ;
         P009A4_A941DocSts = new string[] {""} ;
         P009A4_A946DocTipo = new string[] {""} ;
         P009A4_A24DocNum = new string[] {""} ;
         P009A4_A942DocSubGratuito = new decimal[1] ;
         P009A4_A932DocICBPER = new decimal[1] ;
         P009A4_A935DocRedondeo = new decimal[1] ;
         P009A4_A934DocPorIVA = new decimal[1] ;
         P009A4_A882DocAnticipos = new decimal[1] ;
         P009A4_A927DocSubExonerado = new decimal[1] ;
         P009A4_A922DocSubSelectivo = new decimal[1] ;
         P009A4_A921DocSubInafecto = new decimal[1] ;
         P009A4_A920DocSubAfecto = new decimal[1] ;
         P009A4_A899DocDcto = new decimal[1] ;
         A232DocFec = DateTime.MinValue;
         A1233MonAbr = "";
         A1916TipSAbr = "";
         A931DocFVcto = DateTime.MinValue;
         A929DocFecRef = DateTime.MinValue;
         A939DocRef = "";
         A950DocTRef = "";
         A231DocCliCod = "";
         A887DocCliDsc = "";
         A936DocObs = "";
         A941DocSts = "";
         A946DocTipo = "";
         A24DocNum = "";
         AV53MonAbr = "";
         AV69TipSunat = "";
         AV55Numero = "";
         AV24DocSer = "";
         AV20DocFVcto = DateTime.MinValue;
         AV18DocFecRef = DateTime.MinValue;
         AV19DocFRef = "";
         AV26DocTRef = "";
         AV25DocSts = "";
         AV12ComRef = "";
         GXt_char1 = "";
         AV68Tipo2 = "";
         AV72Totales = "";
         AV52Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroventasoficialpdf__default(),
            new Object[][] {
                new Object[] {
               P009A2_A306TipAbr, P009A2_A511TipSigno, P009A2_A1921TipVta, P009A2_A149TipCod
               }
               , new Object[] {
               P009A4_A157TipSCod, P009A4_n157TipSCod, P009A4_A149TipCod, P009A4_A232DocFec, P009A4_A230DocMonCod, P009A4_A1233MonAbr, P009A4_n1233MonAbr, P009A4_A1916TipSAbr, P009A4_A931DocFVcto, P009A4_A929DocFecRef,
               P009A4_A939DocRef, P009A4_A950DocTRef, P009A4_A231DocCliCod, P009A4_A887DocCliDsc, P009A4_A936DocObs, P009A4_A941DocSts, P009A4_A946DocTipo, P009A4_A24DocNum, P009A4_A942DocSubGratuito, P009A4_A932DocICBPER,
               P009A4_A935DocRedondeo, P009A4_A934DocPorIVA, P009A4_A882DocAnticipos, P009A4_A927DocSubExonerado, P009A4_A922DocSubSelectivo, P009A4_A921DocSubInafecto, P009A4_A920DocSubAfecto, P009A4_A899DocDcto
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV50jAno ;
      private short AV51jMes ;
      private short A511TipSigno ;
      private short A1921TipVta ;
      private short AV81ValidaAnulado ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A157TipSCod ;
      private int A230DocMonCod ;
      private int AV54MonCod ;
      private int Gx_OldLine ;
      private long AV82Len ;
      private decimal AV62SubTotal ;
      private decimal AV27Dscto ;
      private decimal AV48Igv ;
      private decimal AV73TotalMN ;
      private decimal AV74TotalMO ;
      private decimal AV76TSubTotal ;
      private decimal AV77TSubTotalI ;
      private decimal AV75TSubExp ;
      private decimal AV78TTDscto ;
      private decimal AV64TIGV ;
      private decimal AV71TISC ;
      private decimal AV79TTotalMN ;
      private decimal AV38GSubAfePag ;
      private decimal AV42GSubInaPag ;
      private decimal AV40GSubExpPag ;
      private decimal AV35GIGVPag ;
      private decimal AV46GTotPag ;
      private decimal AV37GISCPag ;
      private decimal AV43GSubTotal ;
      private decimal AV41GSubIna ;
      private decimal AV39GSubExp ;
      private decimal AV33GDscto ;
      private decimal AV34GIgv ;
      private decimal AV36GISC ;
      private decimal AV44GTotalMN ;
      private decimal AV45GTotalMO ;
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
      private decimal AV70TipVenta ;
      private decimal AV61SubIna ;
      private decimal AV60SubExp ;
      private decimal AV49Isc ;
      private decimal GXt_decimal2 ;
      private decimal AV14DocAnticipos ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV30Empresa ;
      private string AV28EmpDir ;
      private string AV31EmpRUC ;
      private string AV58Ruta ;
      private string AV10cMes ;
      private string AV13DocAbr ;
      private string AV21DocNum ;
      private string AV8CliCod ;
      private string AV9CliDsc ;
      private string AV66TipCmb ;
      private string scmdbuf ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private string AV67TipCod ;
      private string A1233MonAbr ;
      private string A1916TipSAbr ;
      private string A939DocRef ;
      private string A950DocTRef ;
      private string A231DocCliCod ;
      private string A887DocCliDsc ;
      private string A941DocSts ;
      private string A946DocTipo ;
      private string A24DocNum ;
      private string AV53MonAbr ;
      private string AV69TipSunat ;
      private string AV55Numero ;
      private string AV24DocSer ;
      private string AV19DocFRef ;
      private string AV26DocTRef ;
      private string AV25DocSts ;
      private string AV12ComRef ;
      private string GXt_char1 ;
      private string AV68Tipo2 ;
      private string AV72Totales ;
      private string sImgUrl ;
      private DateTime AV17DocFec ;
      private DateTime A232DocFec ;
      private DateTime A931DocFVcto ;
      private DateTime A929DocFecRef ;
      private DateTime AV20DocFVcto ;
      private DateTime AV18DocFecRef ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n157TipSCod ;
      private bool n1233MonAbr ;
      private string A936DocObs ;
      private string AV85Logo_GXI ;
      private string AV52Logo ;
      private string Logo ;
      private IGxSession AV59Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private IDataStoreProvider pr_default ;
      private string[] P009A2_A306TipAbr ;
      private short[] P009A2_A511TipSigno ;
      private short[] P009A2_A1921TipVta ;
      private string[] P009A2_A149TipCod ;
      private int[] P009A4_A157TipSCod ;
      private bool[] P009A4_n157TipSCod ;
      private string[] P009A4_A149TipCod ;
      private DateTime[] P009A4_A232DocFec ;
      private int[] P009A4_A230DocMonCod ;
      private string[] P009A4_A1233MonAbr ;
      private bool[] P009A4_n1233MonAbr ;
      private string[] P009A4_A1916TipSAbr ;
      private DateTime[] P009A4_A931DocFVcto ;
      private DateTime[] P009A4_A929DocFecRef ;
      private string[] P009A4_A939DocRef ;
      private string[] P009A4_A950DocTRef ;
      private string[] P009A4_A231DocCliCod ;
      private string[] P009A4_A887DocCliDsc ;
      private string[] P009A4_A936DocObs ;
      private string[] P009A4_A941DocSts ;
      private string[] P009A4_A946DocTipo ;
      private string[] P009A4_A24DocNum ;
      private decimal[] P009A4_A942DocSubGratuito ;
      private decimal[] P009A4_A932DocICBPER ;
      private decimal[] P009A4_A935DocRedondeo ;
      private decimal[] P009A4_A934DocPorIVA ;
      private decimal[] P009A4_A882DocAnticipos ;
      private decimal[] P009A4_A927DocSubExonerado ;
      private decimal[] P009A4_A922DocSubSelectivo ;
      private decimal[] P009A4_A921DocSubInafecto ;
      private decimal[] P009A4_A920DocSubAfecto ;
      private decimal[] P009A4_A899DocDcto ;
   }

   public class r_registroventasoficialpdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009A2;
          prmP009A2 = new Object[] {
          };
          Object[] prmP009A4;
          prmP009A4 = new Object[] {
          new ParDef("@AV67TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV50jAno",GXType.Int16,4,0) ,
          new ParDef("@AV51jMes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009A2", "SELECT [TipAbr], [TipSigno], [TipVta], [TipCod] FROM [CTIPDOC] WHERE [TipVta] = 1 ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009A4", "SELECT T3.[TipSCod], T1.[TipCod], T1.[DocFec], T1.[DocMonCod] AS DocMonCod, T2.[MonAbr], T4.[TipSAbr], T1.[DocFVcto], T1.[DocFecRef], T1.[DocRef], T1.[DocTRef], T1.[DocCliCod] AS DocCliCod, T3.[CliDsc] AS DocCliDsc, T1.[DocObs], T1.[DocSts], T1.[DocTipo], T1.[DocNum], COALESCE( T5.[DocSubGratuito], 0) AS DocSubGratuito, T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], COALESCE( T5.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T5.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T5.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T5.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM (((([CLVENTAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[DocMonCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[DocCliCod]) LEFT JOIN [CTIPDOCS] T4 ON T4.[TipSCod] = T3.[TipSCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[DocNum] = T1.[DocNum]) WHERE (T1.[TipCod] = @AV67TipCod) AND (YEAR(T1.[DocFec]) = @AV50jAno) AND (MONTH(T1.[DocFec]) = @AV51jMes) ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009A4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 12);
                ((string[]) buf[11])[0] = rslt.getString(10, 3);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getLongVarchar(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 1);
                ((string[]) buf[16])[0] = rslt.getString(15, 1);
                ((string[]) buf[17])[0] = rslt.getString(16, 12);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                return;
       }
    }

 }

}
