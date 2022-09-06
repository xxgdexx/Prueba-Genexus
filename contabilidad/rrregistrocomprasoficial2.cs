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
   public class rrregistrocomprasoficial2 : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrregistrocomprasoficial2.aspx")), "contabilidad.rrregistrocomprasoficial2.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrregistrocomprasoficial2.aspx")))) ;
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
               AV71jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV72jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
                  AV76Orden = GetPar( "Orden");
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

      public rrregistrocomprasoficial2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrregistrocomprasoficial2( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_jAno ,
                           ref short aP1_jMes ,
                           ref string aP2_Orden )
      {
         this.AV71jAno = aP0_jAno;
         this.AV72jMes = aP1_jMes;
         this.AV76Orden = aP2_Orden;
         initialize();
         executePrivate();
         aP0_jAno=this.AV71jAno;
         aP1_jMes=this.AV72jMes;
         aP2_Orden=this.AV76Orden;
      }

      public string executeUdp( ref short aP0_jAno ,
                                ref short aP1_jMes )
      {
         execute(ref aP0_jAno, ref aP1_jMes, ref aP2_Orden);
         return AV76Orden ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes ,
                                 ref string aP2_Orden )
      {
         rrregistrocomprasoficial2 objrrregistrocomprasoficial2;
         objrrregistrocomprasoficial2 = new rrregistrocomprasoficial2();
         objrrregistrocomprasoficial2.AV71jAno = aP0_jAno;
         objrrregistrocomprasoficial2.AV72jMes = aP1_jMes;
         objrrregistrocomprasoficial2.AV76Orden = aP2_Orden;
         objrrregistrocomprasoficial2.context.SetSubmitInitialConfig(context);
         objrrregistrocomprasoficial2.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrregistrocomprasoficial2);
         aP0_jAno=this.AV71jAno;
         aP1_jMes=this.AV72jMes;
         aP2_Orden=this.AV76Orden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrregistrocomprasoficial2)stateInfo).executePrivate();
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
            AV34Empresa = "RAZON SOCIAL : " + AV84Session.Get("Empresa");
            AV33EmpDir = AV84Session.Get("EmpDir");
            AV35EmpRUC = "RUC : " + AV84Session.Get("EmpRUC");
            AV82Ruta = AV84Session.Get("RUTA") + "/Logo.jpg";
            AV73Logo = AV82Ruta;
            AV116Logo_GXI = GXDbFile.PathToUrl( AV82Ruta);
            GXt_char1 = AV15cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV72jMes, out  GXt_char1) ;
            AV15cMes = GXt_char1;
            AV26DocAbr = "";
            AV30DocNum = "";
            AV29DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV16ComFecPago = DateTime.MinValue;
            AV80PrvCod = "";
            AV81PrvDsc = "";
            AV86SubTotal = 0.00m;
            AV32Dscto = 0.00m;
            AV63Igv = 0.00m;
            AV102TotalMN = 0.00m;
            AV103TotalMO = 0.00m;
            AV95TipCmb = "";
            AV106TSubTotal1 = 0.00m;
            AV107TSubTotal2 = 0.00m;
            AV108TSubTotal3 = 0.00m;
            AV109TSubTotalI = 0.00m;
            AV91TIGV1 = 0.00m;
            AV92TIGV2 = 0.00m;
            AV93TIGV3 = 0.00m;
            AV100TISC = 0.00m;
            AV111TTotalMN = 0.00m;
            AV77Por1 = 0.00m;
            AV78Por2 = 0.00m;
            AV13Base1 = 0.00m;
            AV14Base2 = 0.00m;
            AV68IgvPor1 = 0.00m;
            AV69IgvPor2 = 0.00m;
            AV50GSubAfePag1 = 0.00m;
            AV51GSubAfePag2 = 0.00m;
            AV52GSubAfePag3 = 0.00m;
            AV54GSubInaPag = 0.00m;
            AV44GIGVPag1 = 0.00m;
            AV45GIGVPag2 = 0.00m;
            AV46GIGVPag3 = 0.00m;
            AV48GISCPag = 0.00m;
            AV61GTotPag = 0.00m;
            if ( StringUtil.StrCmp(AV76Orden, "R") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAREGISTRO' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV76Orden, "N") == 0 )
            {
               /* Execute user subroutine: 'ORDENANUMEROREGISTRO' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV76Orden, "F") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAEMISION' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV76Orden, "P") == 0 )
            {
               /* Execute user subroutine: 'ORDENAPROVEEDOR' */
               S141 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            HAO0( false, 39) ;
            getPrinter().GxDrawLine(505, Gx_line+4, 1074, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 5, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 440, Gx_line+16, 488, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV109TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+16, 869, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV91TIGV1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+16, 615, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV111TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+16, 925, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+16, 569, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV107TSubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+16, 672, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV92TIGV2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+16, 718, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV108TSubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+16, 773, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93TIGV3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+16, 819, Gx_line+25, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+39);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAO0( true, 0) ;
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
         /* 'ORDENAFECHAREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P00AO3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAO4 = false;
            A157TipSCod = P00AO3_A157TipSCod[0];
            n157TipSCod = P00AO3_n157TipSCod[0];
            A1906TipCmp = P00AO3_A1906TipCmp[0];
            A306TipAbr = P00AO3_A306TipAbr[0];
            A707ComFReg = P00AO3_A707ComFReg[0];
            A708ComFVcto = P00AO3_A708ComFVcto[0];
            A246ComMon = P00AO3_A246ComMon[0];
            A149TipCod = P00AO3_A149TipCod[0];
            A1233MonAbr = P00AO3_A1233MonAbr[0];
            n1233MonAbr = P00AO3_n1233MonAbr[0];
            A1916TipSAbr = P00AO3_A1916TipSAbr[0];
            A243ComCod = P00AO3_A243ComCod[0];
            A248ComFec = P00AO3_A248ComFec[0];
            A244PrvCod = P00AO3_A244PrvCod[0];
            A247PrvDsc = P00AO3_A247PrvDsc[0];
            A704ComFecPago = P00AO3_A704ComFecPago[0];
            A727ComRetCod = P00AO3_A727ComRetCod[0];
            A730ComRetFec = P00AO3_A730ComRetFec[0];
            A735ComTipReg = P00AO3_A735ComTipReg[0];
            A725ComRefTDoc = P00AO3_A725ComRefTDoc[0];
            A722ComRefDoc = P00AO3_A722ComRefDoc[0];
            A724ComRefFec = P00AO3_A724ComRefFec[0];
            A511TipSigno = P00AO3_A511TipSigno[0];
            A249ComRef = P00AO3_A249ComRef[0];
            A729ComRete2 = P00AO3_A729ComRete2[0];
            A728ComRete1 = P00AO3_A728ComRete1[0];
            A732ComSubIna = P00AO3_A732ComSubIna[0];
            A719ComIVADUA = P00AO3_A719ComIVADUA[0];
            A718ComRedondeo = P00AO3_A718ComRedondeo[0];
            A717ComPorIva = P00AO3_A717ComPorIva[0];
            A698ComDscto = P00AO3_A698ComDscto[0];
            A713ComISC = P00AO3_A713ComISC[0];
            A706ComFlete = P00AO3_A706ComFlete[0];
            A716ComSubAfe = P00AO3_A716ComSubAfe[0];
            A1233MonAbr = P00AO3_A1233MonAbr[0];
            n1233MonAbr = P00AO3_n1233MonAbr[0];
            A1906TipCmp = P00AO3_A1906TipCmp[0];
            A306TipAbr = P00AO3_A306TipAbr[0];
            A511TipSigno = P00AO3_A511TipSigno[0];
            A157TipSCod = P00AO3_A157TipSCod[0];
            n157TipSCod = P00AO3_n157TipSCod[0];
            A1916TipSAbr = P00AO3_A1916TipSAbr[0];
            A732ComSubIna = P00AO3_A732ComSubIna[0];
            A716ComSubAfe = P00AO3_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV56GSubTotal1 = 0.00m;
            AV57GSubTotal2 = 0.00m;
            AV58GSubTotal3 = 0.00m;
            AV53GSubIna = 0.00m;
            AV38GDscto = 0.00m;
            AV40GIgv1 = 0.00m;
            AV41GIgv2 = 0.00m;
            AV42GIgv3 = 0.00m;
            AV47GISC = 0.00m;
            AV59GTotalMN = 0.00m;
            AV60GTotalMO = 0.00m;
            AV96TipCod = A149TipCod;
            AV94TipAbr = A306TipAbr;
            AV9AnoDUA = "";
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AO3_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAO4 = false;
               A157TipSCod = P00AO3_A157TipSCod[0];
               n157TipSCod = P00AO3_n157TipSCod[0];
               A707ComFReg = P00AO3_A707ComFReg[0];
               A708ComFVcto = P00AO3_A708ComFVcto[0];
               A246ComMon = P00AO3_A246ComMon[0];
               A149TipCod = P00AO3_A149TipCod[0];
               A1233MonAbr = P00AO3_A1233MonAbr[0];
               n1233MonAbr = P00AO3_n1233MonAbr[0];
               A1916TipSAbr = P00AO3_A1916TipSAbr[0];
               A243ComCod = P00AO3_A243ComCod[0];
               A248ComFec = P00AO3_A248ComFec[0];
               A244PrvCod = P00AO3_A244PrvCod[0];
               A247PrvDsc = P00AO3_A247PrvDsc[0];
               A704ComFecPago = P00AO3_A704ComFecPago[0];
               A727ComRetCod = P00AO3_A727ComRetCod[0];
               A730ComRetFec = P00AO3_A730ComRetFec[0];
               A735ComTipReg = P00AO3_A735ComTipReg[0];
               A725ComRefTDoc = P00AO3_A725ComRefTDoc[0];
               A722ComRefDoc = P00AO3_A722ComRefDoc[0];
               A724ComRefFec = P00AO3_A724ComRefFec[0];
               A511TipSigno = P00AO3_A511TipSigno[0];
               A249ComRef = P00AO3_A249ComRef[0];
               A729ComRete2 = P00AO3_A729ComRete2[0];
               A728ComRete1 = P00AO3_A728ComRete1[0];
               A719ComIVADUA = P00AO3_A719ComIVADUA[0];
               A718ComRedondeo = P00AO3_A718ComRedondeo[0];
               A717ComPorIva = P00AO3_A717ComPorIva[0];
               A698ComDscto = P00AO3_A698ComDscto[0];
               A713ComISC = P00AO3_A713ComISC[0];
               A706ComFlete = P00AO3_A706ComFlete[0];
               A1233MonAbr = P00AO3_A1233MonAbr[0];
               n1233MonAbr = P00AO3_n1233MonAbr[0];
               A511TipSigno = P00AO3_A511TipSigno[0];
               A157TipSCod = P00AO3_A157TipSCod[0];
               n157TipSCod = P00AO3_n157TipSCod[0];
               A1916TipSAbr = P00AO3_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV94TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV71jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV72jMes )
                     {
                        /* Using cursor P00AO5 */
                        pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(1) != 101) )
                        {
                           A732ComSubIna = P00AO5_A732ComSubIna[0];
                           A716ComSubAfe = P00AO5_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(1);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV96TipCod = A149TipCod;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV95TipCmb = "";
                        AV26DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV10AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV11AT1 = (int)(AV10AT-1);
                        AV12AT2 = (int)(AV10AT+1);
                        AV83Serie = ((AV10AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV11AT1));
                        AV30DocNum = ((AV10AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV12AT2, 20));
                        AV9AnoDUA = ((StringUtil.StrCmp(AV26DocAbr, "50")==0)||(StringUtil.StrCmp(AV26DocAbr, "52")==0)||(StringUtil.StrCmp(AV26DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV29DocFec = A248ComFec;
                        AV80PrvCod = A244PrvCod;
                        AV81PrvDsc = A247PrvDsc;
                        GXt_char1 = AV31DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV80PrvCod, ref  AV96TipCod, ref  AV30DocNum, out  GXt_char1) ;
                        AV31DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV16ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV23ComRetCod = A727ComRetCod;
                        AV24ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV25ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV104TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV104TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV104TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P00AO3_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV87SubTotal1 = 0.00m;
                        AV88SubTotal2 = 0.00m;
                        AV89SubTotal3 = 0.00m;
                        AV85SubIna = 0.00m;
                        AV32Dscto = 0.00m;
                        AV64Igv1 = 0.00m;
                        AV65Igv2 = 0.00m;
                        AV66Igv3 = 0.00m;
                        AV102TotalMN = 0.00m;
                        AV103TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV37Fecha = (((StringUtil.StrCmp(AV26DocAbr, "07")==0)||(StringUtil.StrCmp(AV26DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV29DocFec);
                           if ( (DateTime.MinValue==AV16ComFecPago) )
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV37Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV16ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           AV95TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV31DocSts, "A") != 0 )
                        {
                           AV86SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV85SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV32Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV112ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV99TipVenta)*A511TipSigno);
                           AV113ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV99TipVenta)*A511TipSigno);
                           AV8ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV99TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV86SubTotal) )
                           {
                              AV86SubTotal = (decimal)((AV86SubTotal+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           else
                           {
                              AV85SubIna = (decimal)((AV85SubIna+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = AV86SubTotal;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = AV86SubTotal;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           }
                           AV102TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV103TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV86SubTotal = NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2);
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV88SubTotal2 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV89SubTotal3 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                           }
                           AV103TotalMO = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                           AV102TotalMN = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                        }
                        AV56GSubTotal1 = (decimal)(AV56GSubTotal1+AV87SubTotal1);
                        AV57GSubTotal2 = (decimal)(AV57GSubTotal2+AV88SubTotal2);
                        AV58GSubTotal3 = (decimal)(AV58GSubTotal3+AV89SubTotal3);
                        AV40GIgv1 = (decimal)(AV40GIgv1+AV64Igv1);
                        AV41GIgv2 = (decimal)(AV41GIgv2+AV65Igv2);
                        AV42GIgv3 = (decimal)(AV42GIgv3+AV66Igv3);
                        AV47GISC = (decimal)(AV47GISC+AV70ISC);
                        AV53GSubIna = (decimal)(AV53GSubIna+AV85SubIna);
                        AV38GDscto = (decimal)(AV38GDscto+AV32Dscto);
                        AV59GTotalMN = (decimal)(AV59GTotalMN+AV102TotalMN);
                        AV60GTotalMO = (decimal)(AV60GTotalMO+AV103TotalMO);
                        HAO0( false, 18) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+4, 925, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 1, Gx_line+4, 33, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV29DocFec, "99/99/99"), 44, Gx_line+4, 76, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV16ComFecPago, "99/99/99"), 78, Gx_line+4, 110, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26DocAbr, "")), 111, Gx_line+3, 133, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DocNum, "")), 207, Gx_line+4, 256, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+4, 868, Gx_line+12, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+4, 569, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+4, 615, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80PrvCod, "@!")), 279, Gx_line+4, 343, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81PrvDsc, "")), 339, Gx_line+1, 512, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ComRetCod, "")), 997, Gx_line+3, 1063, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ComRetFec, "")), 958, Gx_line+4, 993, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TipSunat, "")), 258, Gx_line+4, 272, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Serie, "")), 133, Gx_line+4, 165, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AnoDUA, "")), 168, Gx_line+4, 194, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1103, Gx_line+3, 1154, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1044, Gx_line+4, 1076, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TRef, "")), 1079, Gx_line+3, 1101, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipCmb, "")), 927, Gx_line+4, 959, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88SubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+4, 672, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Igv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+4, 718, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+4, 773, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+4, 819, Gx_line+13, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        AV50GSubAfePag1 = (decimal)(AV50GSubAfePag1+AV87SubTotal1);
                        AV51GSubAfePag2 = (decimal)(AV51GSubAfePag2+AV88SubTotal2);
                        AV52GSubAfePag3 = (decimal)(AV52GSubAfePag3+AV89SubTotal3);
                        AV54GSubInaPag = (decimal)(AV54GSubInaPag+AV85SubIna);
                        AV44GIGVPag1 = (decimal)(AV44GIGVPag1+AV64Igv1);
                        AV45GIGVPag2 = (decimal)(AV45GIGVPag2+AV65Igv2);
                        AV46GIGVPag3 = (decimal)(AV46GIGVPag3+AV66Igv3);
                        AV48GISCPag = (decimal)(AV48GISCPag+AV70ISC);
                        AV61GTotPag = (decimal)(AV61GTotPag+AV102TotalMN);
                     }
                  }
               }
               BRKAO4 = true;
               pr_default.readNext(0);
            }
            AV106TSubTotal1 = (decimal)(AV106TSubTotal1+AV56GSubTotal1);
            AV107TSubTotal2 = (decimal)(AV107TSubTotal2+AV57GSubTotal2);
            AV108TSubTotal3 = (decimal)(AV108TSubTotal3+AV58GSubTotal3);
            AV109TSubTotalI = (decimal)(AV109TSubTotalI+AV53GSubIna);
            AV91TIGV1 = (decimal)(AV91TIGV1+AV40GIgv1);
            AV92TIGV2 = (decimal)(AV92TIGV2+AV41GIgv2);
            AV93TIGV3 = (decimal)(AV93TIGV3+AV42GIgv3);
            AV100TISC = (decimal)(AV100TISC+AV47GISC);
            AV111TTotalMN = (decimal)(AV111TTotalMN+AV59GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV60GTotalMO) )
            {
               AV101Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAO0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Totales, "")), 38, Gx_line+17, 503, Gx_line+31, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+20, 569, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+20, 925, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+20, 615, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+20, 869, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57GSubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+20, 672, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41GIgv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+20, 718, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+20, 773, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+20, 819, Gx_line+29, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRKAO4 )
            {
               BRKAO4 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'ORDENANUMEROREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P00AO7 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAO6 = false;
            A157TipSCod = P00AO7_A157TipSCod[0];
            n157TipSCod = P00AO7_n157TipSCod[0];
            A1906TipCmp = P00AO7_A1906TipCmp[0];
            A306TipAbr = P00AO7_A306TipAbr[0];
            A707ComFReg = P00AO7_A707ComFReg[0];
            A708ComFVcto = P00AO7_A708ComFVcto[0];
            A246ComMon = P00AO7_A246ComMon[0];
            A149TipCod = P00AO7_A149TipCod[0];
            A1233MonAbr = P00AO7_A1233MonAbr[0];
            n1233MonAbr = P00AO7_n1233MonAbr[0];
            A1916TipSAbr = P00AO7_A1916TipSAbr[0];
            A243ComCod = P00AO7_A243ComCod[0];
            A248ComFec = P00AO7_A248ComFec[0];
            A244PrvCod = P00AO7_A244PrvCod[0];
            A247PrvDsc = P00AO7_A247PrvDsc[0];
            A704ComFecPago = P00AO7_A704ComFecPago[0];
            A727ComRetCod = P00AO7_A727ComRetCod[0];
            A730ComRetFec = P00AO7_A730ComRetFec[0];
            A735ComTipReg = P00AO7_A735ComTipReg[0];
            A725ComRefTDoc = P00AO7_A725ComRefTDoc[0];
            A722ComRefDoc = P00AO7_A722ComRefDoc[0];
            A724ComRefFec = P00AO7_A724ComRefFec[0];
            A511TipSigno = P00AO7_A511TipSigno[0];
            A249ComRef = P00AO7_A249ComRef[0];
            A729ComRete2 = P00AO7_A729ComRete2[0];
            A728ComRete1 = P00AO7_A728ComRete1[0];
            A732ComSubIna = P00AO7_A732ComSubIna[0];
            A719ComIVADUA = P00AO7_A719ComIVADUA[0];
            A718ComRedondeo = P00AO7_A718ComRedondeo[0];
            A717ComPorIva = P00AO7_A717ComPorIva[0];
            A698ComDscto = P00AO7_A698ComDscto[0];
            A713ComISC = P00AO7_A713ComISC[0];
            A706ComFlete = P00AO7_A706ComFlete[0];
            A716ComSubAfe = P00AO7_A716ComSubAfe[0];
            A1233MonAbr = P00AO7_A1233MonAbr[0];
            n1233MonAbr = P00AO7_n1233MonAbr[0];
            A1906TipCmp = P00AO7_A1906TipCmp[0];
            A306TipAbr = P00AO7_A306TipAbr[0];
            A511TipSigno = P00AO7_A511TipSigno[0];
            A157TipSCod = P00AO7_A157TipSCod[0];
            n157TipSCod = P00AO7_n157TipSCod[0];
            A1916TipSAbr = P00AO7_A1916TipSAbr[0];
            A732ComSubIna = P00AO7_A732ComSubIna[0];
            A716ComSubAfe = P00AO7_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV56GSubTotal1 = 0.00m;
            AV57GSubTotal2 = 0.00m;
            AV58GSubTotal3 = 0.00m;
            AV53GSubIna = 0.00m;
            AV38GDscto = 0.00m;
            AV40GIgv1 = 0.00m;
            AV41GIgv2 = 0.00m;
            AV42GIgv3 = 0.00m;
            AV47GISC = 0.00m;
            AV59GTotalMN = 0.00m;
            AV60GTotalMO = 0.00m;
            AV96TipCod = A149TipCod;
            AV94TipAbr = A306TipAbr;
            AV9AnoDUA = "";
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AO7_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAO6 = false;
               A157TipSCod = P00AO7_A157TipSCod[0];
               n157TipSCod = P00AO7_n157TipSCod[0];
               A707ComFReg = P00AO7_A707ComFReg[0];
               A708ComFVcto = P00AO7_A708ComFVcto[0];
               A246ComMon = P00AO7_A246ComMon[0];
               A149TipCod = P00AO7_A149TipCod[0];
               A1233MonAbr = P00AO7_A1233MonAbr[0];
               n1233MonAbr = P00AO7_n1233MonAbr[0];
               A1916TipSAbr = P00AO7_A1916TipSAbr[0];
               A243ComCod = P00AO7_A243ComCod[0];
               A248ComFec = P00AO7_A248ComFec[0];
               A244PrvCod = P00AO7_A244PrvCod[0];
               A247PrvDsc = P00AO7_A247PrvDsc[0];
               A704ComFecPago = P00AO7_A704ComFecPago[0];
               A727ComRetCod = P00AO7_A727ComRetCod[0];
               A730ComRetFec = P00AO7_A730ComRetFec[0];
               A735ComTipReg = P00AO7_A735ComTipReg[0];
               A725ComRefTDoc = P00AO7_A725ComRefTDoc[0];
               A722ComRefDoc = P00AO7_A722ComRefDoc[0];
               A724ComRefFec = P00AO7_A724ComRefFec[0];
               A511TipSigno = P00AO7_A511TipSigno[0];
               A249ComRef = P00AO7_A249ComRef[0];
               A729ComRete2 = P00AO7_A729ComRete2[0];
               A728ComRete1 = P00AO7_A728ComRete1[0];
               A719ComIVADUA = P00AO7_A719ComIVADUA[0];
               A718ComRedondeo = P00AO7_A718ComRedondeo[0];
               A717ComPorIva = P00AO7_A717ComPorIva[0];
               A698ComDscto = P00AO7_A698ComDscto[0];
               A713ComISC = P00AO7_A713ComISC[0];
               A706ComFlete = P00AO7_A706ComFlete[0];
               A1233MonAbr = P00AO7_A1233MonAbr[0];
               n1233MonAbr = P00AO7_n1233MonAbr[0];
               A511TipSigno = P00AO7_A511TipSigno[0];
               A157TipSCod = P00AO7_A157TipSCod[0];
               n157TipSCod = P00AO7_n157TipSCod[0];
               A1916TipSAbr = P00AO7_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV94TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV71jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV72jMes )
                     {
                        /* Using cursor P00AO9 */
                        pr_default.execute(3, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(3) != 101) )
                        {
                           A732ComSubIna = P00AO9_A732ComSubIna[0];
                           A716ComSubAfe = P00AO9_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(3);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV96TipCod = A149TipCod;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV95TipCmb = "";
                        AV26DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV10AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV11AT1 = (int)(AV10AT-1);
                        AV12AT2 = (int)(AV10AT+1);
                        AV83Serie = ((AV10AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV11AT1));
                        AV30DocNum = ((AV10AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV12AT2, 20));
                        AV9AnoDUA = ((StringUtil.StrCmp(AV26DocAbr, "50")==0)||(StringUtil.StrCmp(AV26DocAbr, "52")==0)||(StringUtil.StrCmp(AV26DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV29DocFec = A248ComFec;
                        AV80PrvCod = A244PrvCod;
                        AV81PrvDsc = A247PrvDsc;
                        GXt_char1 = AV31DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV80PrvCod, ref  AV96TipCod, ref  AV30DocNum, out  GXt_char1) ;
                        AV31DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV16ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV23ComRetCod = A727ComRetCod;
                        AV24ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV25ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV104TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV104TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV104TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P00AO7_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV87SubTotal1 = 0.00m;
                        AV88SubTotal2 = 0.00m;
                        AV89SubTotal3 = 0.00m;
                        AV85SubIna = 0.00m;
                        AV32Dscto = 0.00m;
                        AV64Igv1 = 0.00m;
                        AV65Igv2 = 0.00m;
                        AV66Igv3 = 0.00m;
                        AV102TotalMN = 0.00m;
                        AV103TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV37Fecha = (((StringUtil.StrCmp(AV26DocAbr, "07")==0)||(StringUtil.StrCmp(AV26DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV29DocFec);
                           if ( (DateTime.MinValue==AV16ComFecPago) )
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV37Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV16ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           AV95TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV31DocSts, "A") != 0 )
                        {
                           AV86SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV85SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV32Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV112ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV99TipVenta)*A511TipSigno);
                           AV113ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV99TipVenta)*A511TipSigno);
                           AV8ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV99TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV86SubTotal) )
                           {
                              AV86SubTotal = (decimal)((AV86SubTotal+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           else
                           {
                              AV85SubIna = (decimal)((AV85SubIna+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = AV86SubTotal;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = AV86SubTotal;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           }
                           AV102TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV103TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV86SubTotal = NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2);
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV88SubTotal2 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV89SubTotal3 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                           }
                           AV103TotalMO = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                           AV102TotalMN = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                        }
                        AV56GSubTotal1 = (decimal)(AV56GSubTotal1+AV87SubTotal1);
                        AV57GSubTotal2 = (decimal)(AV57GSubTotal2+AV88SubTotal2);
                        AV58GSubTotal3 = (decimal)(AV58GSubTotal3+AV89SubTotal3);
                        AV40GIgv1 = (decimal)(AV40GIgv1+AV64Igv1);
                        AV41GIgv2 = (decimal)(AV41GIgv2+AV65Igv2);
                        AV42GIgv3 = (decimal)(AV42GIgv3+AV66Igv3);
                        AV47GISC = (decimal)(AV47GISC+AV70ISC);
                        AV53GSubIna = (decimal)(AV53GSubIna+AV85SubIna);
                        AV38GDscto = (decimal)(AV38GDscto+AV32Dscto);
                        AV59GTotalMN = (decimal)(AV59GTotalMN+AV102TotalMN);
                        AV60GTotalMO = (decimal)(AV60GTotalMO+AV103TotalMO);
                        HAO0( false, 18) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+4, 925, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 1, Gx_line+4, 33, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV29DocFec, "99/99/99"), 44, Gx_line+4, 76, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV16ComFecPago, "99/99/99"), 78, Gx_line+4, 110, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26DocAbr, "")), 111, Gx_line+3, 133, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DocNum, "")), 207, Gx_line+4, 256, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+4, 868, Gx_line+12, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+4, 569, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+4, 615, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80PrvCod, "@!")), 279, Gx_line+4, 343, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81PrvDsc, "")), 339, Gx_line+1, 512, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ComRetCod, "")), 997, Gx_line+3, 1063, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ComRetFec, "")), 958, Gx_line+4, 993, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TipSunat, "")), 258, Gx_line+4, 272, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Serie, "")), 133, Gx_line+4, 165, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AnoDUA, "")), 168, Gx_line+4, 194, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1103, Gx_line+3, 1154, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1044, Gx_line+4, 1076, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TRef, "")), 1079, Gx_line+3, 1101, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipCmb, "")), 927, Gx_line+4, 959, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88SubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+4, 672, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Igv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+4, 718, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+4, 773, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+4, 819, Gx_line+13, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        AV50GSubAfePag1 = (decimal)(AV50GSubAfePag1+AV87SubTotal1);
                        AV51GSubAfePag2 = (decimal)(AV51GSubAfePag2+AV88SubTotal2);
                        AV52GSubAfePag3 = (decimal)(AV52GSubAfePag3+AV89SubTotal3);
                        AV54GSubInaPag = (decimal)(AV54GSubInaPag+AV85SubIna);
                        AV44GIGVPag1 = (decimal)(AV44GIGVPag1+AV64Igv1);
                        AV45GIGVPag2 = (decimal)(AV45GIGVPag2+AV65Igv2);
                        AV46GIGVPag3 = (decimal)(AV46GIGVPag3+AV66Igv3);
                        AV48GISCPag = (decimal)(AV48GISCPag+AV70ISC);
                        AV61GTotPag = (decimal)(AV61GTotPag+AV102TotalMN);
                     }
                  }
               }
               BRKAO6 = true;
               pr_default.readNext(2);
            }
            AV106TSubTotal1 = (decimal)(AV106TSubTotal1+AV56GSubTotal1);
            AV107TSubTotal2 = (decimal)(AV107TSubTotal2+AV57GSubTotal2);
            AV108TSubTotal3 = (decimal)(AV108TSubTotal3+AV58GSubTotal3);
            AV109TSubTotalI = (decimal)(AV109TSubTotalI+AV53GSubIna);
            AV91TIGV1 = (decimal)(AV91TIGV1+AV40GIgv1);
            AV92TIGV2 = (decimal)(AV92TIGV2+AV41GIgv2);
            AV93TIGV3 = (decimal)(AV93TIGV3+AV42GIgv3);
            AV100TISC = (decimal)(AV100TISC+AV47GISC);
            AV111TTotalMN = (decimal)(AV111TTotalMN+AV59GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV60GTotalMO) )
            {
               AV101Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAO0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Totales, "")), 38, Gx_line+17, 503, Gx_line+31, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+20, 569, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+20, 925, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+20, 615, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+20, 869, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57GSubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+20, 672, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41GIgv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+20, 718, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+20, 773, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+20, 819, Gx_line+29, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRKAO6 )
            {
               BRKAO6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'ORDENAFECHAEMISION' Routine */
         returnInSub = false;
         /* Using cursor P00AO11 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKAO8 = false;
            A157TipSCod = P00AO11_A157TipSCod[0];
            n157TipSCod = P00AO11_n157TipSCod[0];
            A1906TipCmp = P00AO11_A1906TipCmp[0];
            A306TipAbr = P00AO11_A306TipAbr[0];
            A707ComFReg = P00AO11_A707ComFReg[0];
            A708ComFVcto = P00AO11_A708ComFVcto[0];
            A246ComMon = P00AO11_A246ComMon[0];
            A149TipCod = P00AO11_A149TipCod[0];
            A1233MonAbr = P00AO11_A1233MonAbr[0];
            n1233MonAbr = P00AO11_n1233MonAbr[0];
            A1916TipSAbr = P00AO11_A1916TipSAbr[0];
            A243ComCod = P00AO11_A243ComCod[0];
            A244PrvCod = P00AO11_A244PrvCod[0];
            A247PrvDsc = P00AO11_A247PrvDsc[0];
            A249ComRef = P00AO11_A249ComRef[0];
            A704ComFecPago = P00AO11_A704ComFecPago[0];
            A727ComRetCod = P00AO11_A727ComRetCod[0];
            A730ComRetFec = P00AO11_A730ComRetFec[0];
            A735ComTipReg = P00AO11_A735ComTipReg[0];
            A725ComRefTDoc = P00AO11_A725ComRefTDoc[0];
            A722ComRefDoc = P00AO11_A722ComRefDoc[0];
            A724ComRefFec = P00AO11_A724ComRefFec[0];
            A511TipSigno = P00AO11_A511TipSigno[0];
            A248ComFec = P00AO11_A248ComFec[0];
            A729ComRete2 = P00AO11_A729ComRete2[0];
            A728ComRete1 = P00AO11_A728ComRete1[0];
            A732ComSubIna = P00AO11_A732ComSubIna[0];
            A719ComIVADUA = P00AO11_A719ComIVADUA[0];
            A718ComRedondeo = P00AO11_A718ComRedondeo[0];
            A717ComPorIva = P00AO11_A717ComPorIva[0];
            A698ComDscto = P00AO11_A698ComDscto[0];
            A713ComISC = P00AO11_A713ComISC[0];
            A706ComFlete = P00AO11_A706ComFlete[0];
            A716ComSubAfe = P00AO11_A716ComSubAfe[0];
            A1233MonAbr = P00AO11_A1233MonAbr[0];
            n1233MonAbr = P00AO11_n1233MonAbr[0];
            A1906TipCmp = P00AO11_A1906TipCmp[0];
            A306TipAbr = P00AO11_A306TipAbr[0];
            A511TipSigno = P00AO11_A511TipSigno[0];
            A157TipSCod = P00AO11_A157TipSCod[0];
            n157TipSCod = P00AO11_n157TipSCod[0];
            A1916TipSAbr = P00AO11_A1916TipSAbr[0];
            A732ComSubIna = P00AO11_A732ComSubIna[0];
            A716ComSubAfe = P00AO11_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV56GSubTotal1 = 0.00m;
            AV57GSubTotal2 = 0.00m;
            AV58GSubTotal3 = 0.00m;
            AV53GSubIna = 0.00m;
            AV38GDscto = 0.00m;
            AV40GIgv1 = 0.00m;
            AV41GIgv2 = 0.00m;
            AV42GIgv3 = 0.00m;
            AV47GISC = 0.00m;
            AV59GTotalMN = 0.00m;
            AV60GTotalMO = 0.00m;
            AV96TipCod = A149TipCod;
            AV94TipAbr = A306TipAbr;
            AV9AnoDUA = "";
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00AO11_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAO8 = false;
               A157TipSCod = P00AO11_A157TipSCod[0];
               n157TipSCod = P00AO11_n157TipSCod[0];
               A707ComFReg = P00AO11_A707ComFReg[0];
               A708ComFVcto = P00AO11_A708ComFVcto[0];
               A246ComMon = P00AO11_A246ComMon[0];
               A149TipCod = P00AO11_A149TipCod[0];
               A1233MonAbr = P00AO11_A1233MonAbr[0];
               n1233MonAbr = P00AO11_n1233MonAbr[0];
               A1916TipSAbr = P00AO11_A1916TipSAbr[0];
               A243ComCod = P00AO11_A243ComCod[0];
               A244PrvCod = P00AO11_A244PrvCod[0];
               A247PrvDsc = P00AO11_A247PrvDsc[0];
               A249ComRef = P00AO11_A249ComRef[0];
               A704ComFecPago = P00AO11_A704ComFecPago[0];
               A727ComRetCod = P00AO11_A727ComRetCod[0];
               A730ComRetFec = P00AO11_A730ComRetFec[0];
               A735ComTipReg = P00AO11_A735ComTipReg[0];
               A725ComRefTDoc = P00AO11_A725ComRefTDoc[0];
               A722ComRefDoc = P00AO11_A722ComRefDoc[0];
               A724ComRefFec = P00AO11_A724ComRefFec[0];
               A511TipSigno = P00AO11_A511TipSigno[0];
               A248ComFec = P00AO11_A248ComFec[0];
               A729ComRete2 = P00AO11_A729ComRete2[0];
               A728ComRete1 = P00AO11_A728ComRete1[0];
               A719ComIVADUA = P00AO11_A719ComIVADUA[0];
               A718ComRedondeo = P00AO11_A718ComRedondeo[0];
               A717ComPorIva = P00AO11_A717ComPorIva[0];
               A698ComDscto = P00AO11_A698ComDscto[0];
               A713ComISC = P00AO11_A713ComISC[0];
               A706ComFlete = P00AO11_A706ComFlete[0];
               A1233MonAbr = P00AO11_A1233MonAbr[0];
               n1233MonAbr = P00AO11_n1233MonAbr[0];
               A511TipSigno = P00AO11_A511TipSigno[0];
               A157TipSCod = P00AO11_A157TipSCod[0];
               n157TipSCod = P00AO11_n157TipSCod[0];
               A1916TipSAbr = P00AO11_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV94TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV71jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV72jMes )
                     {
                        /* Using cursor P00AO13 */
                        pr_default.execute(5, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(5) != 101) )
                        {
                           A732ComSubIna = P00AO13_A732ComSubIna[0];
                           A716ComSubAfe = P00AO13_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(5);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV96TipCod = A149TipCod;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV95TipCmb = "";
                        AV26DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV10AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV11AT1 = (int)(AV10AT-1);
                        AV12AT2 = (int)(AV10AT+1);
                        AV83Serie = ((AV10AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV11AT1));
                        AV30DocNum = ((AV10AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV12AT2, 20));
                        AV9AnoDUA = ((StringUtil.StrCmp(AV26DocAbr, "50")==0)||(StringUtil.StrCmp(AV26DocAbr, "52")==0)||(StringUtil.StrCmp(AV26DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV29DocFec = A248ComFec;
                        AV80PrvCod = A244PrvCod;
                        AV81PrvDsc = A247PrvDsc;
                        GXt_char1 = AV31DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV80PrvCod, ref  AV96TipCod, ref  AV30DocNum, out  GXt_char1) ;
                        AV31DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV16ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV23ComRetCod = A727ComRetCod;
                        AV24ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV25ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV104TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV104TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV104TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P00AO11_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV87SubTotal1 = 0.00m;
                        AV88SubTotal2 = 0.00m;
                        AV89SubTotal3 = 0.00m;
                        AV85SubIna = 0.00m;
                        AV32Dscto = 0.00m;
                        AV64Igv1 = 0.00m;
                        AV65Igv2 = 0.00m;
                        AV66Igv3 = 0.00m;
                        AV102TotalMN = 0.00m;
                        AV103TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV37Fecha = (((StringUtil.StrCmp(AV26DocAbr, "07")==0)||(StringUtil.StrCmp(AV26DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV29DocFec);
                           if ( (DateTime.MinValue==AV16ComFecPago) )
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV37Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV16ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           AV95TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV31DocSts, "A") != 0 )
                        {
                           AV86SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV85SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV32Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV112ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV99TipVenta)*A511TipSigno);
                           AV113ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV99TipVenta)*A511TipSigno);
                           AV8ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV99TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV86SubTotal) )
                           {
                              AV86SubTotal = (decimal)((AV86SubTotal+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           else
                           {
                              AV85SubIna = (decimal)((AV85SubIna+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = AV86SubTotal;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = AV86SubTotal;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           }
                           AV102TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV103TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV86SubTotal = NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2);
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV88SubTotal2 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV89SubTotal3 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                           }
                           AV103TotalMO = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                           AV102TotalMN = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                        }
                        AV56GSubTotal1 = (decimal)(AV56GSubTotal1+AV87SubTotal1);
                        AV57GSubTotal2 = (decimal)(AV57GSubTotal2+AV88SubTotal2);
                        AV58GSubTotal3 = (decimal)(AV58GSubTotal3+AV89SubTotal3);
                        AV40GIgv1 = (decimal)(AV40GIgv1+AV64Igv1);
                        AV41GIgv2 = (decimal)(AV41GIgv2+AV65Igv2);
                        AV42GIgv3 = (decimal)(AV42GIgv3+AV66Igv3);
                        AV47GISC = (decimal)(AV47GISC+AV70ISC);
                        AV53GSubIna = (decimal)(AV53GSubIna+AV85SubIna);
                        AV38GDscto = (decimal)(AV38GDscto+AV32Dscto);
                        AV59GTotalMN = (decimal)(AV59GTotalMN+AV102TotalMN);
                        AV60GTotalMO = (decimal)(AV60GTotalMO+AV103TotalMO);
                        HAO0( false, 18) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+4, 925, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 1, Gx_line+4, 33, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV29DocFec, "99/99/99"), 44, Gx_line+4, 76, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV16ComFecPago, "99/99/99"), 78, Gx_line+4, 110, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26DocAbr, "")), 111, Gx_line+3, 133, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DocNum, "")), 207, Gx_line+4, 256, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+4, 868, Gx_line+12, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+4, 569, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+4, 615, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80PrvCod, "@!")), 279, Gx_line+4, 343, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81PrvDsc, "")), 339, Gx_line+1, 512, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ComRetCod, "")), 997, Gx_line+3, 1063, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ComRetFec, "")), 958, Gx_line+4, 993, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TipSunat, "")), 258, Gx_line+4, 272, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Serie, "")), 133, Gx_line+4, 165, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AnoDUA, "")), 168, Gx_line+4, 194, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1103, Gx_line+3, 1154, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1044, Gx_line+4, 1076, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TRef, "")), 1079, Gx_line+3, 1101, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipCmb, "")), 927, Gx_line+4, 959, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88SubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+4, 672, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Igv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+4, 718, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+4, 773, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+4, 819, Gx_line+13, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        AV50GSubAfePag1 = (decimal)(AV50GSubAfePag1+AV87SubTotal1);
                        AV51GSubAfePag2 = (decimal)(AV51GSubAfePag2+AV88SubTotal2);
                        AV52GSubAfePag3 = (decimal)(AV52GSubAfePag3+AV89SubTotal3);
                        AV54GSubInaPag = (decimal)(AV54GSubInaPag+AV85SubIna);
                        AV44GIGVPag1 = (decimal)(AV44GIGVPag1+AV64Igv1);
                        AV45GIGVPag2 = (decimal)(AV45GIGVPag2+AV65Igv2);
                        AV46GIGVPag3 = (decimal)(AV46GIGVPag3+AV66Igv3);
                        AV48GISCPag = (decimal)(AV48GISCPag+AV70ISC);
                        AV61GTotPag = (decimal)(AV61GTotPag+AV102TotalMN);
                     }
                  }
               }
               BRKAO8 = true;
               pr_default.readNext(4);
            }
            AV106TSubTotal1 = (decimal)(AV106TSubTotal1+AV56GSubTotal1);
            AV107TSubTotal2 = (decimal)(AV107TSubTotal2+AV57GSubTotal2);
            AV108TSubTotal3 = (decimal)(AV108TSubTotal3+AV58GSubTotal3);
            AV109TSubTotalI = (decimal)(AV109TSubTotalI+AV53GSubIna);
            AV91TIGV1 = (decimal)(AV91TIGV1+AV40GIgv1);
            AV92TIGV2 = (decimal)(AV92TIGV2+AV41GIgv2);
            AV93TIGV3 = (decimal)(AV93TIGV3+AV42GIgv3);
            AV100TISC = (decimal)(AV100TISC+AV47GISC);
            AV111TTotalMN = (decimal)(AV111TTotalMN+AV59GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV60GTotalMO) )
            {
               AV101Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAO0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Totales, "")), 38, Gx_line+17, 503, Gx_line+31, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+20, 569, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+20, 925, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+20, 615, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+20, 869, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57GSubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+20, 672, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41GIgv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+20, 718, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+20, 773, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+20, 819, Gx_line+29, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRKAO8 )
            {
               BRKAO8 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S141( )
      {
         /* 'ORDENAPROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P00AO15 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKAO10 = false;
            A157TipSCod = P00AO15_A157TipSCod[0];
            n157TipSCod = P00AO15_n157TipSCod[0];
            A1906TipCmp = P00AO15_A1906TipCmp[0];
            A306TipAbr = P00AO15_A306TipAbr[0];
            A707ComFReg = P00AO15_A707ComFReg[0];
            A708ComFVcto = P00AO15_A708ComFVcto[0];
            A246ComMon = P00AO15_A246ComMon[0];
            A149TipCod = P00AO15_A149TipCod[0];
            A1233MonAbr = P00AO15_A1233MonAbr[0];
            n1233MonAbr = P00AO15_n1233MonAbr[0];
            A1916TipSAbr = P00AO15_A1916TipSAbr[0];
            A243ComCod = P00AO15_A243ComCod[0];
            A248ComFec = P00AO15_A248ComFec[0];
            A244PrvCod = P00AO15_A244PrvCod[0];
            A249ComRef = P00AO15_A249ComRef[0];
            A704ComFecPago = P00AO15_A704ComFecPago[0];
            A727ComRetCod = P00AO15_A727ComRetCod[0];
            A730ComRetFec = P00AO15_A730ComRetFec[0];
            A735ComTipReg = P00AO15_A735ComTipReg[0];
            A725ComRefTDoc = P00AO15_A725ComRefTDoc[0];
            A722ComRefDoc = P00AO15_A722ComRefDoc[0];
            A724ComRefFec = P00AO15_A724ComRefFec[0];
            A511TipSigno = P00AO15_A511TipSigno[0];
            A247PrvDsc = P00AO15_A247PrvDsc[0];
            A729ComRete2 = P00AO15_A729ComRete2[0];
            A728ComRete1 = P00AO15_A728ComRete1[0];
            A732ComSubIna = P00AO15_A732ComSubIna[0];
            A719ComIVADUA = P00AO15_A719ComIVADUA[0];
            A718ComRedondeo = P00AO15_A718ComRedondeo[0];
            A717ComPorIva = P00AO15_A717ComPorIva[0];
            A698ComDscto = P00AO15_A698ComDscto[0];
            A713ComISC = P00AO15_A713ComISC[0];
            A706ComFlete = P00AO15_A706ComFlete[0];
            A716ComSubAfe = P00AO15_A716ComSubAfe[0];
            A1233MonAbr = P00AO15_A1233MonAbr[0];
            n1233MonAbr = P00AO15_n1233MonAbr[0];
            A1906TipCmp = P00AO15_A1906TipCmp[0];
            A306TipAbr = P00AO15_A306TipAbr[0];
            A511TipSigno = P00AO15_A511TipSigno[0];
            A157TipSCod = P00AO15_A157TipSCod[0];
            n157TipSCod = P00AO15_n157TipSCod[0];
            A1916TipSAbr = P00AO15_A1916TipSAbr[0];
            A732ComSubIna = P00AO15_A732ComSubIna[0];
            A716ComSubAfe = P00AO15_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV56GSubTotal1 = 0.00m;
            AV57GSubTotal2 = 0.00m;
            AV58GSubTotal3 = 0.00m;
            AV53GSubIna = 0.00m;
            AV38GDscto = 0.00m;
            AV40GIgv1 = 0.00m;
            AV41GIgv2 = 0.00m;
            AV42GIgv3 = 0.00m;
            AV47GISC = 0.00m;
            AV59GTotalMN = 0.00m;
            AV60GTotalMO = 0.00m;
            AV96TipCod = A149TipCod;
            AV94TipAbr = A306TipAbr;
            AV9AnoDUA = "";
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00AO15_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAO10 = false;
               A157TipSCod = P00AO15_A157TipSCod[0];
               n157TipSCod = P00AO15_n157TipSCod[0];
               A707ComFReg = P00AO15_A707ComFReg[0];
               A708ComFVcto = P00AO15_A708ComFVcto[0];
               A246ComMon = P00AO15_A246ComMon[0];
               A149TipCod = P00AO15_A149TipCod[0];
               A1233MonAbr = P00AO15_A1233MonAbr[0];
               n1233MonAbr = P00AO15_n1233MonAbr[0];
               A1916TipSAbr = P00AO15_A1916TipSAbr[0];
               A243ComCod = P00AO15_A243ComCod[0];
               A248ComFec = P00AO15_A248ComFec[0];
               A244PrvCod = P00AO15_A244PrvCod[0];
               A249ComRef = P00AO15_A249ComRef[0];
               A704ComFecPago = P00AO15_A704ComFecPago[0];
               A727ComRetCod = P00AO15_A727ComRetCod[0];
               A730ComRetFec = P00AO15_A730ComRetFec[0];
               A735ComTipReg = P00AO15_A735ComTipReg[0];
               A725ComRefTDoc = P00AO15_A725ComRefTDoc[0];
               A722ComRefDoc = P00AO15_A722ComRefDoc[0];
               A724ComRefFec = P00AO15_A724ComRefFec[0];
               A511TipSigno = P00AO15_A511TipSigno[0];
               A247PrvDsc = P00AO15_A247PrvDsc[0];
               A729ComRete2 = P00AO15_A729ComRete2[0];
               A728ComRete1 = P00AO15_A728ComRete1[0];
               A719ComIVADUA = P00AO15_A719ComIVADUA[0];
               A718ComRedondeo = P00AO15_A718ComRedondeo[0];
               A717ComPorIva = P00AO15_A717ComPorIva[0];
               A698ComDscto = P00AO15_A698ComDscto[0];
               A713ComISC = P00AO15_A713ComISC[0];
               A706ComFlete = P00AO15_A706ComFlete[0];
               A1233MonAbr = P00AO15_A1233MonAbr[0];
               n1233MonAbr = P00AO15_n1233MonAbr[0];
               A511TipSigno = P00AO15_A511TipSigno[0];
               A157TipSCod = P00AO15_A157TipSCod[0];
               n157TipSCod = P00AO15_n157TipSCod[0];
               A1916TipSAbr = P00AO15_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV94TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV71jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV72jMes )
                     {
                        /* Using cursor P00AO17 */
                        pr_default.execute(7, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(7) != 101) )
                        {
                           A732ComSubIna = P00AO17_A732ComSubIna[0];
                           A716ComSubAfe = P00AO17_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(7);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV96TipCod = A149TipCod;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV95TipCmb = "";
                        AV26DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV10AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV11AT1 = (int)(AV10AT-1);
                        AV12AT2 = (int)(AV10AT+1);
                        AV83Serie = ((AV10AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV11AT1));
                        AV30DocNum = ((AV10AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV12AT2, 20));
                        AV9AnoDUA = ((StringUtil.StrCmp(AV26DocAbr, "50")==0)||(StringUtil.StrCmp(AV26DocAbr, "52")==0)||(StringUtil.StrCmp(AV26DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV29DocFec = A248ComFec;
                        AV80PrvCod = A244PrvCod;
                        AV81PrvDsc = A247PrvDsc;
                        GXt_char1 = AV31DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV80PrvCod, ref  AV96TipCod, ref  AV30DocNum, out  GXt_char1) ;
                        AV31DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV16ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV23ComRetCod = A727ComRetCod;
                        AV24ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV25ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV104TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV104TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV104TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P00AO15_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV87SubTotal1 = 0.00m;
                        AV88SubTotal2 = 0.00m;
                        AV89SubTotal3 = 0.00m;
                        AV85SubIna = 0.00m;
                        AV32Dscto = 0.00m;
                        AV64Igv1 = 0.00m;
                        AV65Igv2 = 0.00m;
                        AV66Igv3 = 0.00m;
                        AV102TotalMN = 0.00m;
                        AV103TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV37Fecha = (((StringUtil.StrCmp(AV26DocAbr, "07")==0)||(StringUtil.StrCmp(AV26DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV29DocFec);
                           if ( (DateTime.MinValue==AV16ComFecPago) )
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV37Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV16ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV99TipVenta = GXt_decimal2;
                           }
                           AV95TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV31DocSts, "A") != 0 )
                        {
                           AV86SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV85SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV32Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV112ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV99TipVenta)*A511TipSigno);
                           AV113ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV99TipVenta)*A511TipSigno);
                           AV8ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV99TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV86SubTotal) )
                           {
                              AV86SubTotal = (decimal)((AV86SubTotal+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           else
                           {
                              AV85SubIna = (decimal)((AV85SubIna+AV8ComFlete)-(AV32Dscto+AV112ComRet1+AV113ComRet2));
                           }
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = AV86SubTotal;
                              AV89SubTotal3 = 0.00m;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                              AV66Igv3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = AV86SubTotal;
                              AV64Igv1 = 0.00m;
                              AV65Igv2 = 0.00m;
                              AV66Igv3 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           }
                           AV102TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV103TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV86SubTotal = NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2);
                           if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25ComTipReg)) )
                           {
                              AV87SubTotal1 = AV86SubTotal;
                              AV88SubTotal2 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "A") == 0 )
                           {
                              AV88SubTotal2 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV89SubTotal3 = 0.00m;
                           }
                           if ( StringUtil.StrCmp(AV25ComTipReg, "B") == 0 )
                           {
                              AV89SubTotal3 = AV86SubTotal;
                              AV87SubTotal1 = 0.00m;
                              AV88SubTotal2 = 0.00m;
                           }
                           AV103TotalMO = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                           AV102TotalMN = (decimal)(AV87SubTotal1+AV88SubTotal2+AV89SubTotal3+AV85SubIna+AV64Igv1+AV65Igv2+AV66Igv3);
                        }
                        AV56GSubTotal1 = (decimal)(AV56GSubTotal1+AV87SubTotal1);
                        AV57GSubTotal2 = (decimal)(AV57GSubTotal2+AV88SubTotal2);
                        AV58GSubTotal3 = (decimal)(AV58GSubTotal3+AV89SubTotal3);
                        AV40GIgv1 = (decimal)(AV40GIgv1+AV64Igv1);
                        AV41GIgv2 = (decimal)(AV41GIgv2+AV65Igv2);
                        AV42GIgv3 = (decimal)(AV42GIgv3+AV66Igv3);
                        AV47GISC = (decimal)(AV47GISC+AV70ISC);
                        AV53GSubIna = (decimal)(AV53GSubIna+AV85SubIna);
                        AV38GDscto = (decimal)(AV38GDscto+AV32Dscto);
                        AV59GTotalMN = (decimal)(AV59GTotalMN+AV102TotalMN);
                        AV60GTotalMO = (decimal)(AV60GTotalMO+AV103TotalMO);
                        HAO0( false, 18) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+4, 925, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 1, Gx_line+4, 33, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV29DocFec, "99/99/99"), 44, Gx_line+4, 76, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV16ComFecPago, "99/99/99"), 78, Gx_line+4, 110, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26DocAbr, "")), 111, Gx_line+3, 133, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30DocNum, "")), 207, Gx_line+4, 256, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+4, 868, Gx_line+12, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+4, 569, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+4, 615, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80PrvCod, "@!")), 279, Gx_line+4, 343, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81PrvDsc, "")), 339, Gx_line+1, 512, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23ComRetCod, "")), 997, Gx_line+3, 1063, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24ComRetFec, "")), 958, Gx_line+4, 993, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98TipSunat, "")), 258, Gx_line+4, 272, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Serie, "")), 133, Gx_line+4, 165, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV9AnoDUA, "")), 168, Gx_line+4, 194, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1103, Gx_line+3, 1154, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1044, Gx_line+4, 1076, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TRef, "")), 1079, Gx_line+3, 1101, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95TipCmb, "")), 927, Gx_line+4, 959, Gx_line+13, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV88SubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+4, 672, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65Igv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+4, 718, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+4, 773, Gx_line+13, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+4, 819, Gx_line+13, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+18);
                        AV50GSubAfePag1 = (decimal)(AV50GSubAfePag1+AV87SubTotal1);
                        AV51GSubAfePag2 = (decimal)(AV51GSubAfePag2+AV88SubTotal2);
                        AV52GSubAfePag3 = (decimal)(AV52GSubAfePag3+AV89SubTotal3);
                        AV54GSubInaPag = (decimal)(AV54GSubInaPag+AV85SubIna);
                        AV44GIGVPag1 = (decimal)(AV44GIGVPag1+AV64Igv1);
                        AV45GIGVPag2 = (decimal)(AV45GIGVPag2+AV65Igv2);
                        AV46GIGVPag3 = (decimal)(AV46GIGVPag3+AV66Igv3);
                        AV48GISCPag = (decimal)(AV48GISCPag+AV70ISC);
                        AV61GTotPag = (decimal)(AV61GTotPag+AV102TotalMN);
                     }
                  }
               }
               BRKAO10 = true;
               pr_default.readNext(6);
            }
            AV106TSubTotal1 = (decimal)(AV106TSubTotal1+AV56GSubTotal1);
            AV107TSubTotal2 = (decimal)(AV107TSubTotal2+AV57GSubTotal2);
            AV108TSubTotal3 = (decimal)(AV108TSubTotal3+AV58GSubTotal3);
            AV109TSubTotalI = (decimal)(AV109TSubTotalI+AV53GSubIna);
            AV91TIGV1 = (decimal)(AV91TIGV1+AV40GIgv1);
            AV92TIGV2 = (decimal)(AV92TIGV2+AV41GIgv2);
            AV93TIGV3 = (decimal)(AV93TIGV3+AV42GIgv3);
            AV100TISC = (decimal)(AV100TISC+AV47GISC);
            AV111TTotalMN = (decimal)(AV111TTotalMN+AV59GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV60GTotalMO) )
            {
               AV101Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAO0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Totales, "")), 38, Gx_line+17, 503, Gx_line+31, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+20, 569, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+20, 925, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+20, 615, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+20, 869, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57GSubTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+20, 672, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41GIgv2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+20, 718, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+20, 773, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+20, 819, Gx_line+29, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRKAO10 )
            {
               BRKAO10 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void HAO0( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 5, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina : ", 398, Gx_line+15, 450, Gx_line+23, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 455, Gx_line+15, 481, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV54GSubInaPag, "ZZZZZZ,ZZZ,ZZ9.99")), 797, Gx_line+15, 869, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50GSubAfePag1, "ZZZZZZ,ZZZ,ZZ9.99")), 497, Gx_line+15, 569, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61GTotPag, "ZZZZZZ,ZZZ,ZZ9.99")), 853, Gx_line+15, 925, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44GIGVPag1, "ZZZZZZ,ZZZ,ZZ9.99")), 543, Gx_line+15, 615, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51GSubAfePag2, "ZZZZZZ,ZZZ,ZZ9.99")), 600, Gx_line+15, 672, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45GIGVPag2, "ZZZZZZ,ZZZ,ZZ9.99")), 646, Gx_line+15, 718, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52GSubAfePag3, "ZZZZZZ,ZZZ,ZZ9.99")), 701, Gx_line+15, 773, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46GIGVPag3, "ZZZZZZ,ZZZ,ZZ9.99")), 747, Gx_line+15, 819, Gx_line+24, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+35);
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
               getPrinter().GxDrawText("Registro de Compras", 471, Gx_line+53, 649, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 376, Gx_line+93, 422, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Mes :", 554, Gx_line+93, 600, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV71jAno), "ZZZ9")), 444, Gx_line+93, 483, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15cMes, "")), 621, Gx_line+93, 731, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 8, Gx_line+100, 377, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34Empresa, "")), 8, Gx_line+82, 376, Gx_line+100, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV73Logo)) ? AV116Logo_GXI : AV73Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+10, 177, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+28, 1075, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 986, Gx_line+28, 1030, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FORMATO 8.1", 986, Gx_line+14, 1065, Gx_line+28, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
               getPrinter().GxDrawLine(43, Gx_line+0, 43, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(76, Gx_line+0, 76, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(208, Gx_line+0, 208, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 5, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre o", 405, Gx_line+17, 440, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(570, Gx_line+24, 570, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(923, Gx_line+0, 923, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(513, Gx_line+0, 513, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(870, Gx_line+0, 870, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 50, Gx_line+4, 72, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(111, Gx_line+0, 111, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 83, Gx_line+4, 105, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vcto y/o", 79, Gx_line+17, 111, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 85, Gx_line+31, 104, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Razon Social", 401, Gx_line+30, 447, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(615, Gx_line+0, 615, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 7, Gx_line+4, 36, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Correlativo", 2, Gx_line+17, 43, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Registro", 6, Gx_line+31, 37, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de", 55, Gx_line+17, 64, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 46, Gx_line+31, 75, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(111, Gx_line+17, 209, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprobante de Pago", 119, Gx_line+3, 198, Gx_line+11, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(132, Gx_line+18, 132, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 115, Gx_line+27, 131, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año Emisión", 164, Gx_line+20, 209, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Información de Proveedor", 339, Gx_line+2, 433, Gx_line+10, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(256, Gx_line+13, 512, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. de Identidad", 261, Gx_line+15, 323, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(332, Gx_line+13, 332, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(256, Gx_line+26, 333, Gx_line+26, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(275, Gx_line+26, 275, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 258, Gx_line+31, 274, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 288, Gx_line+31, 317, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 533, Gx_line+24, 554, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 882, Gx_line+10, 912, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia de Comprobante", 1050, Gx_line+4, 1150, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1016, Gx_line+17, 1157, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1076, Gx_line+18, 1076, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 1081, Gx_line+26, 1097, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1102, Gx_line+18, 1102, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 1104, Gx_line+25, 1151, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 927, Gx_line+10, 953, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cambio", 927, Gx_line+25, 955, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 523, Gx_line+33, 559, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 888, Gx_line+25, 907, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1157, Gx_line+46, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 1049, Gx_line+26, 1071, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(816, Gx_line+0, 816, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 834, Gx_line+4, 855, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 827, Gx_line+18, 863, Gx_line+26, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("IGV", 584, Gx_line+31, 599, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Inafecta", 829, Gx_line+31, 860, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1043, Gx_line+0, 1043, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(957, Gx_line+0, 957, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 963, Gx_line+26, 985, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cons. Detracción", 970, Gx_line+4, 1031, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(957, Gx_line+17, 1018, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(992, Gx_line+18, 992, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 995, Gx_line+26, 1042, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(256, Gx_line+0, 256, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 210, Gx_line+4, 257, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° de DUA", 215, Gx_line+18, 254, Gx_line+26, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Otros", 223, Gx_line+31, 244, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie", 139, Gx_line+27, 158, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(161, Gx_line+17, 161, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DUA o DSI", 167, Gx_line+32, 204, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(513, Gx_line+24, 615, Gx_line+24, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Adquisiciones Gravadas", 522, Gx_line+1, 607, Gx_line+9, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operaciones G. y/o Exp.", 520, Gx_line+13, 605, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Adquisiciones Gravadas", 624, Gx_line+1, 709, Gx_line+9, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Exporta. y NO Gravadas", 622, Gx_line+13, 706, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 635, Gx_line+24, 656, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 625, Gx_line+33, 661, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(672, Gx_line+24, 672, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("IGV", 686, Gx_line+31, 701, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(615, Gx_line+24, 717, Gx_line+24, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(716, Gx_line+0, 716, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Operaciones NO Gravadas", 722, Gx_line+13, 815, Gx_line+21, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Adquisiciones Gravadas", 724, Gx_line+1, 809, Gx_line+9, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 736, Gx_line+24, 757, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 726, Gx_line+33, 762, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(716, Gx_line+24, 816, Gx_line+24, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(773, Gx_line+24, 773, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("IGV", 788, Gx_line+31, 803, Gx_line+39, 0+256, 0, 0, 0) ;
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
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(1);
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV34Empresa = "";
         AV84Session = context.GetSession();
         AV33EmpDir = "";
         AV35EmpRUC = "";
         AV82Ruta = "";
         AV73Logo = "";
         AV116Logo_GXI = "";
         AV15cMes = "";
         AV26DocAbr = "";
         AV30DocNum = "";
         AV29DocFec = DateTime.MinValue;
         AV16ComFecPago = DateTime.MinValue;
         AV80PrvCod = "";
         AV81PrvDsc = "";
         AV95TipCmb = "";
         scmdbuf = "";
         P00AO3_A157TipSCod = new int[1] ;
         P00AO3_n157TipSCod = new bool[] {false} ;
         P00AO3_A1906TipCmp = new short[1] ;
         P00AO3_A306TipAbr = new string[] {""} ;
         P00AO3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A246ComMon = new int[1] ;
         P00AO3_A149TipCod = new string[] {""} ;
         P00AO3_A1233MonAbr = new string[] {""} ;
         P00AO3_n1233MonAbr = new bool[] {false} ;
         P00AO3_A1916TipSAbr = new string[] {""} ;
         P00AO3_A243ComCod = new string[] {""} ;
         P00AO3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A244PrvCod = new string[] {""} ;
         P00AO3_A247PrvDsc = new string[] {""} ;
         P00AO3_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A727ComRetCod = new string[] {""} ;
         P00AO3_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A735ComTipReg = new string[] {""} ;
         P00AO3_A725ComRefTDoc = new string[] {""} ;
         P00AO3_A722ComRefDoc = new string[] {""} ;
         P00AO3_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AO3_A511TipSigno = new short[1] ;
         P00AO3_A249ComRef = new string[] {""} ;
         P00AO3_A729ComRete2 = new decimal[1] ;
         P00AO3_A728ComRete1 = new decimal[1] ;
         P00AO3_A732ComSubIna = new decimal[1] ;
         P00AO3_A719ComIVADUA = new decimal[1] ;
         P00AO3_A718ComRedondeo = new decimal[1] ;
         P00AO3_A717ComPorIva = new decimal[1] ;
         P00AO3_A698ComDscto = new decimal[1] ;
         P00AO3_A713ComISC = new decimal[1] ;
         P00AO3_A706ComFlete = new decimal[1] ;
         P00AO3_A716ComSubAfe = new decimal[1] ;
         A306TipAbr = "";
         A707ComFReg = DateTime.MinValue;
         A708ComFVcto = DateTime.MinValue;
         A149TipCod = "";
         A1233MonAbr = "";
         A1916TipSAbr = "";
         A243ComCod = "";
         A248ComFec = DateTime.MinValue;
         A244PrvCod = "";
         A247PrvDsc = "";
         A704ComFecPago = DateTime.MinValue;
         A727ComRetCod = "";
         A730ComRetFec = DateTime.MinValue;
         A735ComTipReg = "";
         A725ComRefTDoc = "";
         A722ComRefDoc = "";
         A724ComRefFec = DateTime.MinValue;
         A249ComRef = "";
         AV96TipCod = "";
         AV94TipAbr = "";
         AV9AnoDUA = "";
         P00AO5_A732ComSubIna = new decimal[1] ;
         P00AO5_A716ComSubAfe = new decimal[1] ;
         AV74MonAbr = "";
         AV98TipSunat = "";
         AV83Serie = "";
         AV31DocSts = "";
         AV19ComRef = "";
         AV23ComRetCod = "";
         AV24ComRetFec = "";
         AV25ComTipReg = "";
         AV22ComRefTDoc = "";
         AV104TRef = "";
         AV20ComRefDoc = "";
         AV21ComRefFec = "";
         P00AO3_n724ComRefFec = new bool[] {false} ;
         AV37Fecha = DateTime.MinValue;
         AV101Totales = "";
         P00AO7_A157TipSCod = new int[1] ;
         P00AO7_n157TipSCod = new bool[] {false} ;
         P00AO7_A1906TipCmp = new short[1] ;
         P00AO7_A306TipAbr = new string[] {""} ;
         P00AO7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A246ComMon = new int[1] ;
         P00AO7_A149TipCod = new string[] {""} ;
         P00AO7_A1233MonAbr = new string[] {""} ;
         P00AO7_n1233MonAbr = new bool[] {false} ;
         P00AO7_A1916TipSAbr = new string[] {""} ;
         P00AO7_A243ComCod = new string[] {""} ;
         P00AO7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A244PrvCod = new string[] {""} ;
         P00AO7_A247PrvDsc = new string[] {""} ;
         P00AO7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A727ComRetCod = new string[] {""} ;
         P00AO7_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A735ComTipReg = new string[] {""} ;
         P00AO7_A725ComRefTDoc = new string[] {""} ;
         P00AO7_A722ComRefDoc = new string[] {""} ;
         P00AO7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AO7_A511TipSigno = new short[1] ;
         P00AO7_A249ComRef = new string[] {""} ;
         P00AO7_A729ComRete2 = new decimal[1] ;
         P00AO7_A728ComRete1 = new decimal[1] ;
         P00AO7_A732ComSubIna = new decimal[1] ;
         P00AO7_A719ComIVADUA = new decimal[1] ;
         P00AO7_A718ComRedondeo = new decimal[1] ;
         P00AO7_A717ComPorIva = new decimal[1] ;
         P00AO7_A698ComDscto = new decimal[1] ;
         P00AO7_A713ComISC = new decimal[1] ;
         P00AO7_A706ComFlete = new decimal[1] ;
         P00AO7_A716ComSubAfe = new decimal[1] ;
         P00AO9_A732ComSubIna = new decimal[1] ;
         P00AO9_A716ComSubAfe = new decimal[1] ;
         P00AO7_n724ComRefFec = new bool[] {false} ;
         P00AO11_A157TipSCod = new int[1] ;
         P00AO11_n157TipSCod = new bool[] {false} ;
         P00AO11_A1906TipCmp = new short[1] ;
         P00AO11_A306TipAbr = new string[] {""} ;
         P00AO11_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A246ComMon = new int[1] ;
         P00AO11_A149TipCod = new string[] {""} ;
         P00AO11_A1233MonAbr = new string[] {""} ;
         P00AO11_n1233MonAbr = new bool[] {false} ;
         P00AO11_A1916TipSAbr = new string[] {""} ;
         P00AO11_A243ComCod = new string[] {""} ;
         P00AO11_A244PrvCod = new string[] {""} ;
         P00AO11_A247PrvDsc = new string[] {""} ;
         P00AO11_A249ComRef = new string[] {""} ;
         P00AO11_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A727ComRetCod = new string[] {""} ;
         P00AO11_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A735ComTipReg = new string[] {""} ;
         P00AO11_A725ComRefTDoc = new string[] {""} ;
         P00AO11_A722ComRefDoc = new string[] {""} ;
         P00AO11_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A511TipSigno = new short[1] ;
         P00AO11_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AO11_A729ComRete2 = new decimal[1] ;
         P00AO11_A728ComRete1 = new decimal[1] ;
         P00AO11_A732ComSubIna = new decimal[1] ;
         P00AO11_A719ComIVADUA = new decimal[1] ;
         P00AO11_A718ComRedondeo = new decimal[1] ;
         P00AO11_A717ComPorIva = new decimal[1] ;
         P00AO11_A698ComDscto = new decimal[1] ;
         P00AO11_A713ComISC = new decimal[1] ;
         P00AO11_A706ComFlete = new decimal[1] ;
         P00AO11_A716ComSubAfe = new decimal[1] ;
         P00AO13_A732ComSubIna = new decimal[1] ;
         P00AO13_A716ComSubAfe = new decimal[1] ;
         P00AO11_n724ComRefFec = new bool[] {false} ;
         P00AO15_A157TipSCod = new int[1] ;
         P00AO15_n157TipSCod = new bool[] {false} ;
         P00AO15_A1906TipCmp = new short[1] ;
         P00AO15_A306TipAbr = new string[] {""} ;
         P00AO15_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A246ComMon = new int[1] ;
         P00AO15_A149TipCod = new string[] {""} ;
         P00AO15_A1233MonAbr = new string[] {""} ;
         P00AO15_n1233MonAbr = new bool[] {false} ;
         P00AO15_A1916TipSAbr = new string[] {""} ;
         P00AO15_A243ComCod = new string[] {""} ;
         P00AO15_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A244PrvCod = new string[] {""} ;
         P00AO15_A249ComRef = new string[] {""} ;
         P00AO15_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A727ComRetCod = new string[] {""} ;
         P00AO15_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A735ComTipReg = new string[] {""} ;
         P00AO15_A725ComRefTDoc = new string[] {""} ;
         P00AO15_A722ComRefDoc = new string[] {""} ;
         P00AO15_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AO15_A511TipSigno = new short[1] ;
         P00AO15_A247PrvDsc = new string[] {""} ;
         P00AO15_A729ComRete2 = new decimal[1] ;
         P00AO15_A728ComRete1 = new decimal[1] ;
         P00AO15_A732ComSubIna = new decimal[1] ;
         P00AO15_A719ComIVADUA = new decimal[1] ;
         P00AO15_A718ComRedondeo = new decimal[1] ;
         P00AO15_A717ComPorIva = new decimal[1] ;
         P00AO15_A698ComDscto = new decimal[1] ;
         P00AO15_A713ComISC = new decimal[1] ;
         P00AO15_A706ComFlete = new decimal[1] ;
         P00AO15_A716ComSubAfe = new decimal[1] ;
         P00AO17_A732ComSubIna = new decimal[1] ;
         P00AO17_A716ComSubAfe = new decimal[1] ;
         P00AO15_n724ComRefFec = new bool[] {false} ;
         GXt_char1 = "";
         AV73Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrregistrocomprasoficial2__default(),
            new Object[][] {
                new Object[] {
               P00AO3_A157TipSCod, P00AO3_n157TipSCod, P00AO3_A1906TipCmp, P00AO3_A306TipAbr, P00AO3_A707ComFReg, P00AO3_A708ComFVcto, P00AO3_A246ComMon, P00AO3_A149TipCod, P00AO3_A1233MonAbr, P00AO3_n1233MonAbr,
               P00AO3_A1916TipSAbr, P00AO3_A243ComCod, P00AO3_A248ComFec, P00AO3_A244PrvCod, P00AO3_A247PrvDsc, P00AO3_A704ComFecPago, P00AO3_A727ComRetCod, P00AO3_A730ComRetFec, P00AO3_A735ComTipReg, P00AO3_A725ComRefTDoc,
               P00AO3_A722ComRefDoc, P00AO3_A724ComRefFec, P00AO3_A511TipSigno, P00AO3_A249ComRef, P00AO3_A729ComRete2, P00AO3_A728ComRete1, P00AO3_A732ComSubIna, P00AO3_A719ComIVADUA, P00AO3_A718ComRedondeo, P00AO3_A717ComPorIva,
               P00AO3_A698ComDscto, P00AO3_A713ComISC, P00AO3_A706ComFlete, P00AO3_A716ComSubAfe
               }
               , new Object[] {
               P00AO5_A732ComSubIna, P00AO5_A716ComSubAfe
               }
               , new Object[] {
               P00AO7_A157TipSCod, P00AO7_n157TipSCod, P00AO7_A1906TipCmp, P00AO7_A306TipAbr, P00AO7_A707ComFReg, P00AO7_A708ComFVcto, P00AO7_A246ComMon, P00AO7_A149TipCod, P00AO7_A1233MonAbr, P00AO7_n1233MonAbr,
               P00AO7_A1916TipSAbr, P00AO7_A243ComCod, P00AO7_A248ComFec, P00AO7_A244PrvCod, P00AO7_A247PrvDsc, P00AO7_A704ComFecPago, P00AO7_A727ComRetCod, P00AO7_A730ComRetFec, P00AO7_A735ComTipReg, P00AO7_A725ComRefTDoc,
               P00AO7_A722ComRefDoc, P00AO7_A724ComRefFec, P00AO7_A511TipSigno, P00AO7_A249ComRef, P00AO7_A729ComRete2, P00AO7_A728ComRete1, P00AO7_A732ComSubIna, P00AO7_A719ComIVADUA, P00AO7_A718ComRedondeo, P00AO7_A717ComPorIva,
               P00AO7_A698ComDscto, P00AO7_A713ComISC, P00AO7_A706ComFlete, P00AO7_A716ComSubAfe
               }
               , new Object[] {
               P00AO9_A732ComSubIna, P00AO9_A716ComSubAfe
               }
               , new Object[] {
               P00AO11_A157TipSCod, P00AO11_n157TipSCod, P00AO11_A1906TipCmp, P00AO11_A306TipAbr, P00AO11_A707ComFReg, P00AO11_A708ComFVcto, P00AO11_A246ComMon, P00AO11_A149TipCod, P00AO11_A1233MonAbr, P00AO11_n1233MonAbr,
               P00AO11_A1916TipSAbr, P00AO11_A243ComCod, P00AO11_A244PrvCod, P00AO11_A247PrvDsc, P00AO11_A249ComRef, P00AO11_A704ComFecPago, P00AO11_A727ComRetCod, P00AO11_A730ComRetFec, P00AO11_A735ComTipReg, P00AO11_A725ComRefTDoc,
               P00AO11_A722ComRefDoc, P00AO11_A724ComRefFec, P00AO11_A511TipSigno, P00AO11_A248ComFec, P00AO11_A729ComRete2, P00AO11_A728ComRete1, P00AO11_A732ComSubIna, P00AO11_A719ComIVADUA, P00AO11_A718ComRedondeo, P00AO11_A717ComPorIva,
               P00AO11_A698ComDscto, P00AO11_A713ComISC, P00AO11_A706ComFlete, P00AO11_A716ComSubAfe
               }
               , new Object[] {
               P00AO13_A732ComSubIna, P00AO13_A716ComSubAfe
               }
               , new Object[] {
               P00AO15_A157TipSCod, P00AO15_n157TipSCod, P00AO15_A1906TipCmp, P00AO15_A306TipAbr, P00AO15_A707ComFReg, P00AO15_A708ComFVcto, P00AO15_A246ComMon, P00AO15_A149TipCod, P00AO15_A1233MonAbr, P00AO15_n1233MonAbr,
               P00AO15_A1916TipSAbr, P00AO15_A243ComCod, P00AO15_A248ComFec, P00AO15_A244PrvCod, P00AO15_A249ComRef, P00AO15_A704ComFecPago, P00AO15_A727ComRetCod, P00AO15_A730ComRetFec, P00AO15_A735ComTipReg, P00AO15_A725ComRefTDoc,
               P00AO15_A722ComRefDoc, P00AO15_A724ComRefFec, P00AO15_A511TipSigno, P00AO15_A247PrvDsc, P00AO15_A729ComRete2, P00AO15_A728ComRete1, P00AO15_A732ComSubIna, P00AO15_A719ComIVADUA, P00AO15_A718ComRedondeo, P00AO15_A717ComPorIva,
               P00AO15_A698ComDscto, P00AO15_A713ComISC, P00AO15_A706ComFlete, P00AO15_A716ComSubAfe
               }
               , new Object[] {
               P00AO17_A732ComSubIna, P00AO17_A716ComSubAfe
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV71jAno ;
      private short AV72jMes ;
      private short A1906TipCmp ;
      private short A511TipSigno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A157TipSCod ;
      private int A246ComMon ;
      private int AV75MonCod ;
      private int AV11AT1 ;
      private int AV12AT2 ;
      private decimal AV86SubTotal ;
      private decimal AV32Dscto ;
      private decimal AV63Igv ;
      private decimal AV102TotalMN ;
      private decimal AV103TotalMO ;
      private decimal AV106TSubTotal1 ;
      private decimal AV107TSubTotal2 ;
      private decimal AV108TSubTotal3 ;
      private decimal AV109TSubTotalI ;
      private decimal AV91TIGV1 ;
      private decimal AV92TIGV2 ;
      private decimal AV93TIGV3 ;
      private decimal AV100TISC ;
      private decimal AV111TTotalMN ;
      private decimal AV77Por1 ;
      private decimal AV78Por2 ;
      private decimal AV13Base1 ;
      private decimal AV14Base2 ;
      private decimal AV68IgvPor1 ;
      private decimal AV69IgvPor2 ;
      private decimal AV50GSubAfePag1 ;
      private decimal AV51GSubAfePag2 ;
      private decimal AV52GSubAfePag3 ;
      private decimal AV54GSubInaPag ;
      private decimal AV44GIGVPag1 ;
      private decimal AV45GIGVPag2 ;
      private decimal AV46GIGVPag3 ;
      private decimal AV48GISCPag ;
      private decimal AV61GTotPag ;
      private decimal A729ComRete2 ;
      private decimal A728ComRete1 ;
      private decimal A732ComSubIna ;
      private decimal A719ComIVADUA ;
      private decimal A718ComRedondeo ;
      private decimal A717ComPorIva ;
      private decimal A698ComDscto ;
      private decimal A713ComISC ;
      private decimal A706ComFlete ;
      private decimal A716ComSubAfe ;
      private decimal A733ComSubTotal ;
      private decimal A715ComIva ;
      private decimal A736ComTotal ;
      private decimal AV56GSubTotal1 ;
      private decimal AV57GSubTotal2 ;
      private decimal AV58GSubTotal3 ;
      private decimal AV53GSubIna ;
      private decimal AV38GDscto ;
      private decimal AV40GIgv1 ;
      private decimal AV41GIgv2 ;
      private decimal AV42GIgv3 ;
      private decimal AV47GISC ;
      private decimal AV59GTotalMN ;
      private decimal AV60GTotalMO ;
      private decimal AV99TipVenta ;
      private decimal AV10AT ;
      private decimal AV18ComPorIva ;
      private decimal AV87SubTotal1 ;
      private decimal AV88SubTotal2 ;
      private decimal AV89SubTotal3 ;
      private decimal AV85SubIna ;
      private decimal AV64Igv1 ;
      private decimal AV65Igv2 ;
      private decimal AV66Igv3 ;
      private decimal AV70ISC ;
      private decimal AV112ComRet1 ;
      private decimal AV113ComRet2 ;
      private decimal AV8ComFlete ;
      private decimal AV17ComIVADUA ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV76Orden ;
      private string AV34Empresa ;
      private string AV33EmpDir ;
      private string AV35EmpRUC ;
      private string AV82Ruta ;
      private string AV15cMes ;
      private string AV26DocAbr ;
      private string AV30DocNum ;
      private string AV80PrvCod ;
      private string AV81PrvDsc ;
      private string AV95TipCmb ;
      private string scmdbuf ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A1916TipSAbr ;
      private string A243ComCod ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A727ComRetCod ;
      private string A735ComTipReg ;
      private string A725ComRefTDoc ;
      private string A722ComRefDoc ;
      private string A249ComRef ;
      private string AV96TipCod ;
      private string AV94TipAbr ;
      private string AV9AnoDUA ;
      private string AV74MonAbr ;
      private string AV98TipSunat ;
      private string AV83Serie ;
      private string AV31DocSts ;
      private string AV19ComRef ;
      private string AV23ComRetCod ;
      private string AV24ComRetFec ;
      private string AV25ComTipReg ;
      private string AV22ComRefTDoc ;
      private string AV104TRef ;
      private string AV20ComRefDoc ;
      private string AV21ComRefFec ;
      private string AV101Totales ;
      private string GXt_char1 ;
      private string sImgUrl ;
      private DateTime AV29DocFec ;
      private DateTime AV16ComFecPago ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A730ComRetFec ;
      private DateTime A724ComRefFec ;
      private DateTime AV37Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRKAO4 ;
      private bool n157TipSCod ;
      private bool n1233MonAbr ;
      private bool BRKAO6 ;
      private bool BRKAO8 ;
      private bool BRKAO10 ;
      private string AV116Logo_GXI ;
      private string AV73Logo ;
      private string Logo ;
      private IGxSession AV84Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private string aP2_Orden ;
      private IDataStoreProvider pr_default ;
      private int[] P00AO3_A157TipSCod ;
      private bool[] P00AO3_n157TipSCod ;
      private short[] P00AO3_A1906TipCmp ;
      private string[] P00AO3_A306TipAbr ;
      private DateTime[] P00AO3_A707ComFReg ;
      private DateTime[] P00AO3_A708ComFVcto ;
      private int[] P00AO3_A246ComMon ;
      private string[] P00AO3_A149TipCod ;
      private string[] P00AO3_A1233MonAbr ;
      private bool[] P00AO3_n1233MonAbr ;
      private string[] P00AO3_A1916TipSAbr ;
      private string[] P00AO3_A243ComCod ;
      private DateTime[] P00AO3_A248ComFec ;
      private string[] P00AO3_A244PrvCod ;
      private string[] P00AO3_A247PrvDsc ;
      private DateTime[] P00AO3_A704ComFecPago ;
      private string[] P00AO3_A727ComRetCod ;
      private DateTime[] P00AO3_A730ComRetFec ;
      private string[] P00AO3_A735ComTipReg ;
      private string[] P00AO3_A725ComRefTDoc ;
      private string[] P00AO3_A722ComRefDoc ;
      private DateTime[] P00AO3_A724ComRefFec ;
      private short[] P00AO3_A511TipSigno ;
      private string[] P00AO3_A249ComRef ;
      private decimal[] P00AO3_A729ComRete2 ;
      private decimal[] P00AO3_A728ComRete1 ;
      private decimal[] P00AO3_A732ComSubIna ;
      private decimal[] P00AO3_A719ComIVADUA ;
      private decimal[] P00AO3_A718ComRedondeo ;
      private decimal[] P00AO3_A717ComPorIva ;
      private decimal[] P00AO3_A698ComDscto ;
      private decimal[] P00AO3_A713ComISC ;
      private decimal[] P00AO3_A706ComFlete ;
      private decimal[] P00AO3_A716ComSubAfe ;
      private decimal[] P00AO5_A732ComSubIna ;
      private decimal[] P00AO5_A716ComSubAfe ;
      private bool[] P00AO3_n724ComRefFec ;
      private int[] P00AO7_A157TipSCod ;
      private bool[] P00AO7_n157TipSCod ;
      private short[] P00AO7_A1906TipCmp ;
      private string[] P00AO7_A306TipAbr ;
      private DateTime[] P00AO7_A707ComFReg ;
      private DateTime[] P00AO7_A708ComFVcto ;
      private int[] P00AO7_A246ComMon ;
      private string[] P00AO7_A149TipCod ;
      private string[] P00AO7_A1233MonAbr ;
      private bool[] P00AO7_n1233MonAbr ;
      private string[] P00AO7_A1916TipSAbr ;
      private string[] P00AO7_A243ComCod ;
      private DateTime[] P00AO7_A248ComFec ;
      private string[] P00AO7_A244PrvCod ;
      private string[] P00AO7_A247PrvDsc ;
      private DateTime[] P00AO7_A704ComFecPago ;
      private string[] P00AO7_A727ComRetCod ;
      private DateTime[] P00AO7_A730ComRetFec ;
      private string[] P00AO7_A735ComTipReg ;
      private string[] P00AO7_A725ComRefTDoc ;
      private string[] P00AO7_A722ComRefDoc ;
      private DateTime[] P00AO7_A724ComRefFec ;
      private short[] P00AO7_A511TipSigno ;
      private string[] P00AO7_A249ComRef ;
      private decimal[] P00AO7_A729ComRete2 ;
      private decimal[] P00AO7_A728ComRete1 ;
      private decimal[] P00AO7_A732ComSubIna ;
      private decimal[] P00AO7_A719ComIVADUA ;
      private decimal[] P00AO7_A718ComRedondeo ;
      private decimal[] P00AO7_A717ComPorIva ;
      private decimal[] P00AO7_A698ComDscto ;
      private decimal[] P00AO7_A713ComISC ;
      private decimal[] P00AO7_A706ComFlete ;
      private decimal[] P00AO7_A716ComSubAfe ;
      private decimal[] P00AO9_A732ComSubIna ;
      private decimal[] P00AO9_A716ComSubAfe ;
      private bool[] P00AO7_n724ComRefFec ;
      private int[] P00AO11_A157TipSCod ;
      private bool[] P00AO11_n157TipSCod ;
      private short[] P00AO11_A1906TipCmp ;
      private string[] P00AO11_A306TipAbr ;
      private DateTime[] P00AO11_A707ComFReg ;
      private DateTime[] P00AO11_A708ComFVcto ;
      private int[] P00AO11_A246ComMon ;
      private string[] P00AO11_A149TipCod ;
      private string[] P00AO11_A1233MonAbr ;
      private bool[] P00AO11_n1233MonAbr ;
      private string[] P00AO11_A1916TipSAbr ;
      private string[] P00AO11_A243ComCod ;
      private string[] P00AO11_A244PrvCod ;
      private string[] P00AO11_A247PrvDsc ;
      private string[] P00AO11_A249ComRef ;
      private DateTime[] P00AO11_A704ComFecPago ;
      private string[] P00AO11_A727ComRetCod ;
      private DateTime[] P00AO11_A730ComRetFec ;
      private string[] P00AO11_A735ComTipReg ;
      private string[] P00AO11_A725ComRefTDoc ;
      private string[] P00AO11_A722ComRefDoc ;
      private DateTime[] P00AO11_A724ComRefFec ;
      private short[] P00AO11_A511TipSigno ;
      private DateTime[] P00AO11_A248ComFec ;
      private decimal[] P00AO11_A729ComRete2 ;
      private decimal[] P00AO11_A728ComRete1 ;
      private decimal[] P00AO11_A732ComSubIna ;
      private decimal[] P00AO11_A719ComIVADUA ;
      private decimal[] P00AO11_A718ComRedondeo ;
      private decimal[] P00AO11_A717ComPorIva ;
      private decimal[] P00AO11_A698ComDscto ;
      private decimal[] P00AO11_A713ComISC ;
      private decimal[] P00AO11_A706ComFlete ;
      private decimal[] P00AO11_A716ComSubAfe ;
      private decimal[] P00AO13_A732ComSubIna ;
      private decimal[] P00AO13_A716ComSubAfe ;
      private bool[] P00AO11_n724ComRefFec ;
      private int[] P00AO15_A157TipSCod ;
      private bool[] P00AO15_n157TipSCod ;
      private short[] P00AO15_A1906TipCmp ;
      private string[] P00AO15_A306TipAbr ;
      private DateTime[] P00AO15_A707ComFReg ;
      private DateTime[] P00AO15_A708ComFVcto ;
      private int[] P00AO15_A246ComMon ;
      private string[] P00AO15_A149TipCod ;
      private string[] P00AO15_A1233MonAbr ;
      private bool[] P00AO15_n1233MonAbr ;
      private string[] P00AO15_A1916TipSAbr ;
      private string[] P00AO15_A243ComCod ;
      private DateTime[] P00AO15_A248ComFec ;
      private string[] P00AO15_A244PrvCod ;
      private string[] P00AO15_A249ComRef ;
      private DateTime[] P00AO15_A704ComFecPago ;
      private string[] P00AO15_A727ComRetCod ;
      private DateTime[] P00AO15_A730ComRetFec ;
      private string[] P00AO15_A735ComTipReg ;
      private string[] P00AO15_A725ComRefTDoc ;
      private string[] P00AO15_A722ComRefDoc ;
      private DateTime[] P00AO15_A724ComRefFec ;
      private short[] P00AO15_A511TipSigno ;
      private string[] P00AO15_A247PrvDsc ;
      private decimal[] P00AO15_A729ComRete2 ;
      private decimal[] P00AO15_A728ComRete1 ;
      private decimal[] P00AO15_A732ComSubIna ;
      private decimal[] P00AO15_A719ComIVADUA ;
      private decimal[] P00AO15_A718ComRedondeo ;
      private decimal[] P00AO15_A717ComPorIva ;
      private decimal[] P00AO15_A698ComDscto ;
      private decimal[] P00AO15_A713ComISC ;
      private decimal[] P00AO15_A706ComFlete ;
      private decimal[] P00AO15_A716ComSubAfe ;
      private decimal[] P00AO17_A732ComSubIna ;
      private decimal[] P00AO17_A716ComSubAfe ;
      private bool[] P00AO15_n724ComRefFec ;
   }

   public class rrregistrocomprasoficial2__default : DataStoreHelperBase, IDataStoreHelper
   {
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AO3;
          prmP00AO3 = new Object[] {
          };
          Object[] prmP00AO5;
          prmP00AO5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AO7;
          prmP00AO7 = new Object[] {
          };
          Object[] prmP00AO9;
          prmP00AO9 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AO11;
          prmP00AO11 = new Object[] {
          };
          Object[] prmP00AO13;
          prmP00AO13 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AO15;
          prmP00AO15 = new Object[] {
          };
          Object[] prmP00AO17;
          prmP00AO17 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AO3", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO5", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO7", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO9", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO11", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComFec], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO13", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO15", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[PrvDsc], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[PrvDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AO17", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AO17,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 15);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 100);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 1);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((string[]) buf[23])[0] = rslt.getString(22, 10);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 15);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 100);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 1);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((string[]) buf[23])[0] = rslt.getString(22, 10);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 15);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((string[]) buf[14])[0] = rslt.getString(13, 10);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 1);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(22);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 5);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((string[]) buf[11])[0] = rslt.getString(10, 15);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 10);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 20);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 1);
                ((string[]) buf[19])[0] = rslt.getString(18, 3);
                ((string[]) buf[20])[0] = rslt.getString(19, 20);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((string[]) buf[23])[0] = rslt.getString(22, 100);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
