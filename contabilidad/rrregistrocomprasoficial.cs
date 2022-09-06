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
   public class rrregistrocomprasoficial : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrregistrocomprasoficial.aspx")), "contabilidad.rrregistrocomprasoficial.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrregistrocomprasoficial.aspx")))) ;
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
               AV73jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV74jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
                  AV78Orden = GetPar( "Orden");
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

      public rrregistrocomprasoficial( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrregistrocomprasoficial( IGxContext context )
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
         this.AV73jAno = aP0_jAno;
         this.AV74jMes = aP1_jMes;
         this.AV78Orden = aP2_Orden;
         initialize();
         executePrivate();
         aP0_jAno=this.AV73jAno;
         aP1_jMes=this.AV74jMes;
         aP2_Orden=this.AV78Orden;
      }

      public string executeUdp( ref short aP0_jAno ,
                                ref short aP1_jMes )
      {
         execute(ref aP0_jAno, ref aP1_jMes, ref aP2_Orden);
         return AV78Orden ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes ,
                                 ref string aP2_Orden )
      {
         rrregistrocomprasoficial objrrregistrocomprasoficial;
         objrrregistrocomprasoficial = new rrregistrocomprasoficial();
         objrrregistrocomprasoficial.AV73jAno = aP0_jAno;
         objrrregistrocomprasoficial.AV74jMes = aP1_jMes;
         objrrregistrocomprasoficial.AV78Orden = aP2_Orden;
         objrrregistrocomprasoficial.context.SetSubmitInitialConfig(context);
         objrrregistrocomprasoficial.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrregistrocomprasoficial);
         aP0_jAno=this.AV73jAno;
         aP1_jMes=this.AV74jMes;
         aP2_Orden=this.AV78Orden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrregistrocomprasoficial)stateInfo).executePrivate();
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
            AV36Empresa = "RAZON SOCIAL : " + AV86Session.Get("Empresa");
            AV35EmpDir = AV86Session.Get("EmpDir");
            AV37EmpRUC = "RUC : " + AV86Session.Get("EmpRUC");
            AV84Ruta = AV86Session.Get("RUTA") + "/Logo.jpg";
            AV75Logo = AV84Ruta;
            AV116Logo_GXI = GXDbFile.PathToUrl( AV84Ruta);
            GXt_char1 = AV14cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV74jMes, out  GXt_char1) ;
            AV14cMes = GXt_char1;
            AV28DocAbr = "";
            AV32DocNum = "";
            AV31DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV15ComFecPago = DateTime.MinValue;
            AV82PrvCod = "";
            AV83PrvDsc = "";
            AV88SubTotal = 0.00m;
            AV34Dscto = 0.00m;
            AV65Igv = 0.00m;
            AV104TotalMN = 0.00m;
            AV105TotalMO = 0.00m;
            AV97TipCmb = "";
            AV108TSubTotal1 = 0.00m;
            AV109TSubTotal2 = 0.00m;
            AV110TSubTotal3 = 0.00m;
            AV111TSubTotalI = 0.00m;
            AV93TIGV1 = 0.00m;
            AV94TIGV2 = 0.00m;
            AV95TIGV3 = 0.00m;
            AV102TISC = 0.00m;
            AV113TTotalMN = 0.00m;
            AV79Por1 = 0.00m;
            AV80Por2 = 0.00m;
            AV12Base1 = 0.00m;
            AV13Base2 = 0.00m;
            AV70IgvPor1 = 0.00m;
            AV71IgvPor2 = 0.00m;
            AV52GSubAfePag1 = 0.00m;
            AV53GSubAfePag2 = 0.00m;
            AV54GSubAfePag3 = 0.00m;
            AV56GSubInaPag = 0.00m;
            AV46GIGVPag1 = 0.00m;
            AV47GIGVPag2 = 0.00m;
            AV48GIGVPag3 = 0.00m;
            AV50GISCPag = 0.00m;
            AV63GTotPag = 0.00m;
            if ( StringUtil.StrCmp(AV78Orden, "R") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAREGISTRO' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV78Orden, "N") == 0 )
            {
               /* Execute user subroutine: 'ORDENANUMEROREGISTRO' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV78Orden, "F") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAEMISION' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV78Orden, "P") == 0 )
            {
               /* Execute user subroutine: 'ORDENAPROVEEDOR' */
               S141 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            H9L0( false, 39) ;
            getPrinter().GxDrawLine(505, Gx_line+4, 1074, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 403, Gx_line+11, 475, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV111TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+13, 765, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV93TIGV1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+13, 698, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV102TISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+13, 820, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV113TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 810, Gx_line+13, 882, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV108TSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+13, 645, Gx_line+24, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+39);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9L0( true, 0) ;
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
         /* Using cursor P009L3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9L4 = false;
            A157TipSCod = P009L3_A157TipSCod[0];
            n157TipSCod = P009L3_n157TipSCod[0];
            A1906TipCmp = P009L3_A1906TipCmp[0];
            A306TipAbr = P009L3_A306TipAbr[0];
            A707ComFReg = P009L3_A707ComFReg[0];
            A708ComFVcto = P009L3_A708ComFVcto[0];
            A246ComMon = P009L3_A246ComMon[0];
            A149TipCod = P009L3_A149TipCod[0];
            A1233MonAbr = P009L3_A1233MonAbr[0];
            n1233MonAbr = P009L3_n1233MonAbr[0];
            A1916TipSAbr = P009L3_A1916TipSAbr[0];
            A243ComCod = P009L3_A243ComCod[0];
            A248ComFec = P009L3_A248ComFec[0];
            A244PrvCod = P009L3_A244PrvCod[0];
            A247PrvDsc = P009L3_A247PrvDsc[0];
            A704ComFecPago = P009L3_A704ComFecPago[0];
            A727ComRetCod = P009L3_A727ComRetCod[0];
            A730ComRetFec = P009L3_A730ComRetFec[0];
            A735ComTipReg = P009L3_A735ComTipReg[0];
            A725ComRefTDoc = P009L3_A725ComRefTDoc[0];
            A722ComRefDoc = P009L3_A722ComRefDoc[0];
            A724ComRefFec = P009L3_A724ComRefFec[0];
            A511TipSigno = P009L3_A511TipSigno[0];
            A249ComRef = P009L3_A249ComRef[0];
            A729ComRete2 = P009L3_A729ComRete2[0];
            A728ComRete1 = P009L3_A728ComRete1[0];
            A732ComSubIna = P009L3_A732ComSubIna[0];
            A719ComIVADUA = P009L3_A719ComIVADUA[0];
            A718ComRedondeo = P009L3_A718ComRedondeo[0];
            A717ComPorIva = P009L3_A717ComPorIva[0];
            A698ComDscto = P009L3_A698ComDscto[0];
            A713ComISC = P009L3_A713ComISC[0];
            A706ComFlete = P009L3_A706ComFlete[0];
            A716ComSubAfe = P009L3_A716ComSubAfe[0];
            A1233MonAbr = P009L3_A1233MonAbr[0];
            n1233MonAbr = P009L3_n1233MonAbr[0];
            A1906TipCmp = P009L3_A1906TipCmp[0];
            A306TipAbr = P009L3_A306TipAbr[0];
            A511TipSigno = P009L3_A511TipSigno[0];
            A157TipSCod = P009L3_A157TipSCod[0];
            n157TipSCod = P009L3_n157TipSCod[0];
            A1916TipSAbr = P009L3_A1916TipSAbr[0];
            A732ComSubIna = P009L3_A732ComSubIna[0];
            A716ComSubAfe = P009L3_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV58GSubTotal1 = 0.00m;
            AV59GSubTotal2 = 0.00m;
            AV60GSubTotal3 = 0.00m;
            AV55GSubIna = 0.00m;
            AV40GDscto = 0.00m;
            AV42GIgv1 = 0.00m;
            AV43GIgv2 = 0.00m;
            AV44GIgv3 = 0.00m;
            AV49GISC = 0.00m;
            AV61GTotalMN = 0.00m;
            AV62GTotalMO = 0.00m;
            AV98TipCod = A149TipCod;
            AV96TipAbr = A306TipAbr;
            AV8AnoDUA = "";
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009L3_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK9L4 = false;
               A157TipSCod = P009L3_A157TipSCod[0];
               n157TipSCod = P009L3_n157TipSCod[0];
               A707ComFReg = P009L3_A707ComFReg[0];
               A708ComFVcto = P009L3_A708ComFVcto[0];
               A246ComMon = P009L3_A246ComMon[0];
               A149TipCod = P009L3_A149TipCod[0];
               A1233MonAbr = P009L3_A1233MonAbr[0];
               n1233MonAbr = P009L3_n1233MonAbr[0];
               A1916TipSAbr = P009L3_A1916TipSAbr[0];
               A243ComCod = P009L3_A243ComCod[0];
               A248ComFec = P009L3_A248ComFec[0];
               A244PrvCod = P009L3_A244PrvCod[0];
               A247PrvDsc = P009L3_A247PrvDsc[0];
               A704ComFecPago = P009L3_A704ComFecPago[0];
               A727ComRetCod = P009L3_A727ComRetCod[0];
               A730ComRetFec = P009L3_A730ComRetFec[0];
               A735ComTipReg = P009L3_A735ComTipReg[0];
               A725ComRefTDoc = P009L3_A725ComRefTDoc[0];
               A722ComRefDoc = P009L3_A722ComRefDoc[0];
               A724ComRefFec = P009L3_A724ComRefFec[0];
               A511TipSigno = P009L3_A511TipSigno[0];
               A249ComRef = P009L3_A249ComRef[0];
               A729ComRete2 = P009L3_A729ComRete2[0];
               A728ComRete1 = P009L3_A728ComRete1[0];
               A719ComIVADUA = P009L3_A719ComIVADUA[0];
               A718ComRedondeo = P009L3_A718ComRedondeo[0];
               A717ComPorIva = P009L3_A717ComPorIva[0];
               A698ComDscto = P009L3_A698ComDscto[0];
               A713ComISC = P009L3_A713ComISC[0];
               A706ComFlete = P009L3_A706ComFlete[0];
               A1233MonAbr = P009L3_A1233MonAbr[0];
               n1233MonAbr = P009L3_n1233MonAbr[0];
               A511TipSigno = P009L3_A511TipSigno[0];
               A157TipSCod = P009L3_A157TipSCod[0];
               n157TipSCod = P009L3_n157TipSCod[0];
               A1916TipSAbr = P009L3_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV96TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV73jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV74jMes )
                     {
                        /* Using cursor P009L5 */
                        pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(1) != 101) )
                        {
                           A732ComSubIna = P009L5_A732ComSubIna[0];
                           A716ComSubAfe = P009L5_A716ComSubAfe[0];
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
                        AV77MonCod = A246ComMon;
                        AV98TipCod = A149TipCod;
                        AV76MonAbr = A1233MonAbr;
                        AV101TipVenta = 1.00000m;
                        AV97TipCmb = "";
                        AV28DocAbr = A306TipAbr;
                        AV100TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV9AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV10AT1 = (int)(AV9AT-1);
                        AV11AT2 = (int)(AV9AT+1);
                        AV85Serie = ((AV9AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV10AT1));
                        AV32DocNum = ((AV9AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV11AT2, 20));
                        AV8AnoDUA = ((StringUtil.StrCmp(AV28DocAbr, "50")==0)||(StringUtil.StrCmp(AV28DocAbr, "52")==0)||(StringUtil.StrCmp(AV28DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV31DocFec = A248ComFec;
                        AV82PrvCod = A244PrvCod;
                        AV83PrvDsc = A247PrvDsc;
                        GXt_char1 = AV33DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV98TipCod, ref  AV32DocNum, out  GXt_char1) ;
                        AV33DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV15ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV25ComRetCod = A727ComRetCod;
                        AV26ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV27ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV106TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV106TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV106TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P009L3_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV34Dscto = 0.00m;
                        AV66Igv1 = 0.00m;
                        AV67Igv2 = 0.00m;
                        AV68Igv3 = 0.00m;
                        AV104TotalMN = 0.00m;
                        AV105TotalMO = 0.00m;
                        AV72ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV77MonCod != 1 )
                        {
                           AV39Fecha = (((StringUtil.StrCmp(AV28DocAbr, "07")==0)||(StringUtil.StrCmp(AV28DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV31DocFec);
                           if ( (DateTime.MinValue==AV15ComFecPago) )
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV39Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV15ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           AV97TipCmb = StringUtil.Trim( StringUtil.Str( AV101TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV33DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV101TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV101TipVenta)*A511TipSigno);
                           AV34Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV101TipVenta)*A511TipSigno);
                           AV72ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV101TipVenta)*A511TipSigno);
                           AV23ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV101TipVenta)*A511TipSigno);
                           AV24ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV101TipVenta)*A511TipSigno);
                           AV16ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV101TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV88SubTotal) )
                           {
                              AV88SubTotal = (decimal)((AV88SubTotal+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           else
                           {
                              AV87SubIna = (decimal)((AV87SubIna+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           AV89SubTotal1 = AV88SubTotal;
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV66Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV101TipVenta)*A511TipSigno);
                           AV67Igv2 = 0.00m;
                           AV68Igv3 = 0.00m;
                           AV104TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV101TipVenta)*A511TipSigno);
                           AV105TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV101TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2));
                           AV105TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                           AV104TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                        }
                        AV58GSubTotal1 = (decimal)(AV58GSubTotal1+AV89SubTotal1);
                        AV59GSubTotal2 = (decimal)(AV59GSubTotal2+AV90SubTotal2);
                        AV60GSubTotal3 = (decimal)(AV60GSubTotal3+AV91SubTotal3);
                        AV42GIgv1 = (decimal)(AV42GIgv1+AV66Igv1);
                        AV43GIgv2 = (decimal)(AV43GIgv2+AV67Igv2);
                        AV44GIgv3 = (decimal)(AV44GIgv3+AV68Igv3);
                        AV49GISC = (decimal)(AV49GISC+AV72ISC);
                        AV55GSubIna = (decimal)(AV55GSubIna+AV87SubIna);
                        AV40GDscto = (decimal)(AV40GDscto+AV34Dscto);
                        AV61GTotalMN = (decimal)(AV61GTotalMN+AV104TotalMN);
                        AV62GTotalMO = (decimal)(AV62GTotalMO+AV105TotalMO);
                        H9L0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+1, 881, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 2, Gx_line+3, 45, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV31DocFec, "99/99/99"), 50, Gx_line+3, 82, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV15ComFecPago, "99/99/99"), 90, Gx_line+3, 122, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DocAbr, "")), 125, Gx_line+3, 147, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DocNum, "")), 232, Gx_line+3, 297, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 695, Gx_line+3, 767, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 645, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+3, 698, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72ISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+3, 820, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82PrvCod, "@!")), 324, Gx_line+3, 408, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83PrvDsc, "")), 390, Gx_line+1, 591, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ComRetCod, "")), 972, Gx_line+3, 1036, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ComRetFec, "")), 932, Gx_line+4, 965, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TipCmb, "")), 885, Gx_line+3, 928, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TipSunat, "")), 301, Gx_line+2, 319, Gx_line+15, 1+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Serie, "")), 150, Gx_line+3, 187, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8AnoDUA, "")), 195, Gx_line+3, 225, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1100, Gx_line+3, 1151, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1034, Gx_line+3, 1074, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TRef, "")), 1076, Gx_line+3, 1098, Gx_line+13, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV52GSubAfePag1 = (decimal)(AV52GSubAfePag1+AV89SubTotal1);
                        AV53GSubAfePag2 = (decimal)(AV53GSubAfePag2+AV90SubTotal2);
                        AV54GSubAfePag3 = (decimal)(AV54GSubAfePag3+AV91SubTotal3);
                        AV56GSubInaPag = (decimal)(AV56GSubInaPag+AV87SubIna);
                        AV46GIGVPag1 = (decimal)(AV46GIGVPag1+AV66Igv1);
                        AV47GIGVPag2 = (decimal)(AV47GIGVPag2+AV67Igv2);
                        AV48GIGVPag3 = (decimal)(AV48GIGVPag3+AV68Igv3);
                        AV50GISCPag = (decimal)(AV50GISCPag+AV72ISC);
                        AV63GTotPag = (decimal)(AV63GTotPag+AV104TotalMN);
                     }
                  }
               }
               BRK9L4 = true;
               pr_default.readNext(0);
            }
            AV108TSubTotal1 = (decimal)(AV108TSubTotal1+AV58GSubTotal1);
            AV109TSubTotal2 = (decimal)(AV109TSubTotal2+AV59GSubTotal2);
            AV110TSubTotal3 = (decimal)(AV110TSubTotal3+AV60GSubTotal3);
            AV111TSubTotalI = (decimal)(AV111TSubTotalI+AV55GSubIna);
            AV93TIGV1 = (decimal)(AV93TIGV1+AV42GIgv1);
            AV94TIGV2 = (decimal)(AV94TIGV2+AV43GIgv2);
            AV95TIGV3 = (decimal)(AV95TIGV3+AV44GIgv3);
            AV102TISC = (decimal)(AV102TISC+AV49GISC);
            AV113TTotalMN = (decimal)(AV113TTotalMN+AV61GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV62GTotalMO) )
            {
               AV103Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               H9L0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103Totales, "")), 96, Gx_line+18, 561, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+20, 645, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+18, 881, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+20, 698, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49GISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+20, 820, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+20, 765, Gx_line+31, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRK9L4 )
            {
               BRK9L4 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'ORDENANUMEROREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P009L7 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK9L6 = false;
            A157TipSCod = P009L7_A157TipSCod[0];
            n157TipSCod = P009L7_n157TipSCod[0];
            A1906TipCmp = P009L7_A1906TipCmp[0];
            A306TipAbr = P009L7_A306TipAbr[0];
            A707ComFReg = P009L7_A707ComFReg[0];
            A708ComFVcto = P009L7_A708ComFVcto[0];
            A246ComMon = P009L7_A246ComMon[0];
            A149TipCod = P009L7_A149TipCod[0];
            A1233MonAbr = P009L7_A1233MonAbr[0];
            n1233MonAbr = P009L7_n1233MonAbr[0];
            A1916TipSAbr = P009L7_A1916TipSAbr[0];
            A243ComCod = P009L7_A243ComCod[0];
            A248ComFec = P009L7_A248ComFec[0];
            A244PrvCod = P009L7_A244PrvCod[0];
            A247PrvDsc = P009L7_A247PrvDsc[0];
            A704ComFecPago = P009L7_A704ComFecPago[0];
            A727ComRetCod = P009L7_A727ComRetCod[0];
            A730ComRetFec = P009L7_A730ComRetFec[0];
            A735ComTipReg = P009L7_A735ComTipReg[0];
            A725ComRefTDoc = P009L7_A725ComRefTDoc[0];
            A722ComRefDoc = P009L7_A722ComRefDoc[0];
            A724ComRefFec = P009L7_A724ComRefFec[0];
            A511TipSigno = P009L7_A511TipSigno[0];
            A249ComRef = P009L7_A249ComRef[0];
            A729ComRete2 = P009L7_A729ComRete2[0];
            A728ComRete1 = P009L7_A728ComRete1[0];
            A732ComSubIna = P009L7_A732ComSubIna[0];
            A719ComIVADUA = P009L7_A719ComIVADUA[0];
            A718ComRedondeo = P009L7_A718ComRedondeo[0];
            A717ComPorIva = P009L7_A717ComPorIva[0];
            A698ComDscto = P009L7_A698ComDscto[0];
            A713ComISC = P009L7_A713ComISC[0];
            A706ComFlete = P009L7_A706ComFlete[0];
            A716ComSubAfe = P009L7_A716ComSubAfe[0];
            A1233MonAbr = P009L7_A1233MonAbr[0];
            n1233MonAbr = P009L7_n1233MonAbr[0];
            A1906TipCmp = P009L7_A1906TipCmp[0];
            A306TipAbr = P009L7_A306TipAbr[0];
            A511TipSigno = P009L7_A511TipSigno[0];
            A157TipSCod = P009L7_A157TipSCod[0];
            n157TipSCod = P009L7_n157TipSCod[0];
            A1916TipSAbr = P009L7_A1916TipSAbr[0];
            A732ComSubIna = P009L7_A732ComSubIna[0];
            A716ComSubAfe = P009L7_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV58GSubTotal1 = 0.00m;
            AV59GSubTotal2 = 0.00m;
            AV60GSubTotal3 = 0.00m;
            AV55GSubIna = 0.00m;
            AV40GDscto = 0.00m;
            AV42GIgv1 = 0.00m;
            AV43GIgv2 = 0.00m;
            AV44GIgv3 = 0.00m;
            AV49GISC = 0.00m;
            AV61GTotalMN = 0.00m;
            AV62GTotalMO = 0.00m;
            AV98TipCod = A149TipCod;
            AV96TipAbr = A306TipAbr;
            AV8AnoDUA = "";
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P009L7_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK9L6 = false;
               A157TipSCod = P009L7_A157TipSCod[0];
               n157TipSCod = P009L7_n157TipSCod[0];
               A707ComFReg = P009L7_A707ComFReg[0];
               A708ComFVcto = P009L7_A708ComFVcto[0];
               A246ComMon = P009L7_A246ComMon[0];
               A149TipCod = P009L7_A149TipCod[0];
               A1233MonAbr = P009L7_A1233MonAbr[0];
               n1233MonAbr = P009L7_n1233MonAbr[0];
               A1916TipSAbr = P009L7_A1916TipSAbr[0];
               A243ComCod = P009L7_A243ComCod[0];
               A248ComFec = P009L7_A248ComFec[0];
               A244PrvCod = P009L7_A244PrvCod[0];
               A247PrvDsc = P009L7_A247PrvDsc[0];
               A704ComFecPago = P009L7_A704ComFecPago[0];
               A727ComRetCod = P009L7_A727ComRetCod[0];
               A730ComRetFec = P009L7_A730ComRetFec[0];
               A735ComTipReg = P009L7_A735ComTipReg[0];
               A725ComRefTDoc = P009L7_A725ComRefTDoc[0];
               A722ComRefDoc = P009L7_A722ComRefDoc[0];
               A724ComRefFec = P009L7_A724ComRefFec[0];
               A511TipSigno = P009L7_A511TipSigno[0];
               A249ComRef = P009L7_A249ComRef[0];
               A729ComRete2 = P009L7_A729ComRete2[0];
               A728ComRete1 = P009L7_A728ComRete1[0];
               A719ComIVADUA = P009L7_A719ComIVADUA[0];
               A718ComRedondeo = P009L7_A718ComRedondeo[0];
               A717ComPorIva = P009L7_A717ComPorIva[0];
               A698ComDscto = P009L7_A698ComDscto[0];
               A713ComISC = P009L7_A713ComISC[0];
               A706ComFlete = P009L7_A706ComFlete[0];
               A1233MonAbr = P009L7_A1233MonAbr[0];
               n1233MonAbr = P009L7_n1233MonAbr[0];
               A511TipSigno = P009L7_A511TipSigno[0];
               A157TipSCod = P009L7_A157TipSCod[0];
               n157TipSCod = P009L7_n157TipSCod[0];
               A1916TipSAbr = P009L7_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV96TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV73jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV74jMes )
                     {
                        /* Using cursor P009L9 */
                        pr_default.execute(3, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(3) != 101) )
                        {
                           A732ComSubIna = P009L9_A732ComSubIna[0];
                           A716ComSubAfe = P009L9_A716ComSubAfe[0];
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
                        AV77MonCod = A246ComMon;
                        AV98TipCod = A149TipCod;
                        AV76MonAbr = A1233MonAbr;
                        AV101TipVenta = 1.00000m;
                        AV97TipCmb = "";
                        AV28DocAbr = A306TipAbr;
                        AV100TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV9AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV10AT1 = (int)(AV9AT-1);
                        AV11AT2 = (int)(AV9AT+1);
                        AV85Serie = ((AV9AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV10AT1));
                        AV32DocNum = ((AV9AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV11AT2, 20));
                        AV8AnoDUA = ((StringUtil.StrCmp(AV28DocAbr, "50")==0)||(StringUtil.StrCmp(AV28DocAbr, "52")==0)||(StringUtil.StrCmp(AV28DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV31DocFec = A248ComFec;
                        AV82PrvCod = A244PrvCod;
                        AV83PrvDsc = A247PrvDsc;
                        GXt_char1 = AV33DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV98TipCod, ref  AV32DocNum, out  GXt_char1) ;
                        AV33DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV15ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV25ComRetCod = A727ComRetCod;
                        AV26ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV27ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV106TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV106TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV106TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P009L7_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV34Dscto = 0.00m;
                        AV66Igv1 = 0.00m;
                        AV67Igv2 = 0.00m;
                        AV68Igv3 = 0.00m;
                        AV104TotalMN = 0.00m;
                        AV105TotalMO = 0.00m;
                        AV72ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV77MonCod != 1 )
                        {
                           AV39Fecha = (((StringUtil.StrCmp(AV28DocAbr, "07")==0)||(StringUtil.StrCmp(AV28DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV31DocFec);
                           if ( (DateTime.MinValue==AV15ComFecPago) )
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV39Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV15ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           AV97TipCmb = StringUtil.Trim( StringUtil.Str( AV101TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV33DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV101TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV101TipVenta)*A511TipSigno);
                           AV34Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV101TipVenta)*A511TipSigno);
                           AV72ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV101TipVenta)*A511TipSigno);
                           AV23ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV101TipVenta)*A511TipSigno);
                           AV24ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV101TipVenta)*A511TipSigno);
                           AV16ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV101TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV88SubTotal) )
                           {
                              AV88SubTotal = (decimal)((AV88SubTotal+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           else
                           {
                              AV87SubIna = (decimal)((AV87SubIna+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           AV89SubTotal1 = AV88SubTotal;
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV66Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV101TipVenta)*A511TipSigno);
                           AV67Igv2 = 0.00m;
                           AV68Igv3 = 0.00m;
                           AV104TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV101TipVenta)*A511TipSigno);
                           AV105TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV101TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2));
                           AV105TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                           AV104TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                        }
                        AV58GSubTotal1 = (decimal)(AV58GSubTotal1+AV89SubTotal1);
                        AV59GSubTotal2 = (decimal)(AV59GSubTotal2+AV90SubTotal2);
                        AV60GSubTotal3 = (decimal)(AV60GSubTotal3+AV91SubTotal3);
                        AV42GIgv1 = (decimal)(AV42GIgv1+AV66Igv1);
                        AV43GIgv2 = (decimal)(AV43GIgv2+AV67Igv2);
                        AV44GIgv3 = (decimal)(AV44GIgv3+AV68Igv3);
                        AV49GISC = (decimal)(AV49GISC+AV72ISC);
                        AV55GSubIna = (decimal)(AV55GSubIna+AV87SubIna);
                        AV40GDscto = (decimal)(AV40GDscto+AV34Dscto);
                        AV61GTotalMN = (decimal)(AV61GTotalMN+AV104TotalMN);
                        AV62GTotalMO = (decimal)(AV62GTotalMO+AV105TotalMO);
                        H9L0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+1, 881, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 2, Gx_line+3, 45, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV31DocFec, "99/99/99"), 50, Gx_line+3, 82, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV15ComFecPago, "99/99/99"), 90, Gx_line+3, 122, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DocAbr, "")), 125, Gx_line+3, 147, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DocNum, "")), 232, Gx_line+3, 297, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 695, Gx_line+3, 767, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 645, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+3, 698, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72ISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+3, 820, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82PrvCod, "@!")), 324, Gx_line+3, 408, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83PrvDsc, "")), 390, Gx_line+1, 591, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ComRetCod, "")), 972, Gx_line+3, 1036, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ComRetFec, "")), 932, Gx_line+4, 965, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TipCmb, "")), 885, Gx_line+3, 928, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TipSunat, "")), 301, Gx_line+2, 319, Gx_line+15, 1+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Serie, "")), 150, Gx_line+3, 187, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8AnoDUA, "")), 195, Gx_line+3, 225, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1100, Gx_line+3, 1151, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1034, Gx_line+3, 1074, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TRef, "")), 1076, Gx_line+3, 1098, Gx_line+13, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV52GSubAfePag1 = (decimal)(AV52GSubAfePag1+AV89SubTotal1);
                        AV53GSubAfePag2 = (decimal)(AV53GSubAfePag2+AV90SubTotal2);
                        AV54GSubAfePag3 = (decimal)(AV54GSubAfePag3+AV91SubTotal3);
                        AV56GSubInaPag = (decimal)(AV56GSubInaPag+AV87SubIna);
                        AV46GIGVPag1 = (decimal)(AV46GIGVPag1+AV66Igv1);
                        AV47GIGVPag2 = (decimal)(AV47GIGVPag2+AV67Igv2);
                        AV48GIGVPag3 = (decimal)(AV48GIGVPag3+AV68Igv3);
                        AV50GISCPag = (decimal)(AV50GISCPag+AV72ISC);
                        AV63GTotPag = (decimal)(AV63GTotPag+AV104TotalMN);
                     }
                  }
               }
               BRK9L6 = true;
               pr_default.readNext(2);
            }
            AV108TSubTotal1 = (decimal)(AV108TSubTotal1+AV58GSubTotal1);
            AV109TSubTotal2 = (decimal)(AV109TSubTotal2+AV59GSubTotal2);
            AV110TSubTotal3 = (decimal)(AV110TSubTotal3+AV60GSubTotal3);
            AV111TSubTotalI = (decimal)(AV111TSubTotalI+AV55GSubIna);
            AV93TIGV1 = (decimal)(AV93TIGV1+AV42GIgv1);
            AV94TIGV2 = (decimal)(AV94TIGV2+AV43GIgv2);
            AV95TIGV3 = (decimal)(AV95TIGV3+AV44GIgv3);
            AV102TISC = (decimal)(AV102TISC+AV49GISC);
            AV113TTotalMN = (decimal)(AV113TTotalMN+AV61GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV62GTotalMO) )
            {
               AV103Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               H9L0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103Totales, "")), 96, Gx_line+18, 561, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+20, 645, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+18, 881, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+20, 698, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49GISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+20, 820, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+20, 765, Gx_line+31, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRK9L6 )
            {
               BRK9L6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'ORDENAFECHAEMISION' Routine */
         returnInSub = false;
         /* Using cursor P009L11 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK9L8 = false;
            A157TipSCod = P009L11_A157TipSCod[0];
            n157TipSCod = P009L11_n157TipSCod[0];
            A1906TipCmp = P009L11_A1906TipCmp[0];
            A306TipAbr = P009L11_A306TipAbr[0];
            A707ComFReg = P009L11_A707ComFReg[0];
            A708ComFVcto = P009L11_A708ComFVcto[0];
            A246ComMon = P009L11_A246ComMon[0];
            A149TipCod = P009L11_A149TipCod[0];
            A1233MonAbr = P009L11_A1233MonAbr[0];
            n1233MonAbr = P009L11_n1233MonAbr[0];
            A1916TipSAbr = P009L11_A1916TipSAbr[0];
            A243ComCod = P009L11_A243ComCod[0];
            A244PrvCod = P009L11_A244PrvCod[0];
            A247PrvDsc = P009L11_A247PrvDsc[0];
            A249ComRef = P009L11_A249ComRef[0];
            A704ComFecPago = P009L11_A704ComFecPago[0];
            A727ComRetCod = P009L11_A727ComRetCod[0];
            A730ComRetFec = P009L11_A730ComRetFec[0];
            A735ComTipReg = P009L11_A735ComTipReg[0];
            A725ComRefTDoc = P009L11_A725ComRefTDoc[0];
            A722ComRefDoc = P009L11_A722ComRefDoc[0];
            A724ComRefFec = P009L11_A724ComRefFec[0];
            A511TipSigno = P009L11_A511TipSigno[0];
            A248ComFec = P009L11_A248ComFec[0];
            A729ComRete2 = P009L11_A729ComRete2[0];
            A728ComRete1 = P009L11_A728ComRete1[0];
            A732ComSubIna = P009L11_A732ComSubIna[0];
            A719ComIVADUA = P009L11_A719ComIVADUA[0];
            A718ComRedondeo = P009L11_A718ComRedondeo[0];
            A717ComPorIva = P009L11_A717ComPorIva[0];
            A698ComDscto = P009L11_A698ComDscto[0];
            A713ComISC = P009L11_A713ComISC[0];
            A706ComFlete = P009L11_A706ComFlete[0];
            A716ComSubAfe = P009L11_A716ComSubAfe[0];
            A1233MonAbr = P009L11_A1233MonAbr[0];
            n1233MonAbr = P009L11_n1233MonAbr[0];
            A1906TipCmp = P009L11_A1906TipCmp[0];
            A306TipAbr = P009L11_A306TipAbr[0];
            A511TipSigno = P009L11_A511TipSigno[0];
            A157TipSCod = P009L11_A157TipSCod[0];
            n157TipSCod = P009L11_n157TipSCod[0];
            A1916TipSAbr = P009L11_A1916TipSAbr[0];
            A732ComSubIna = P009L11_A732ComSubIna[0];
            A716ComSubAfe = P009L11_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV58GSubTotal1 = 0.00m;
            AV59GSubTotal2 = 0.00m;
            AV60GSubTotal3 = 0.00m;
            AV55GSubIna = 0.00m;
            AV40GDscto = 0.00m;
            AV42GIgv1 = 0.00m;
            AV43GIgv2 = 0.00m;
            AV44GIgv3 = 0.00m;
            AV49GISC = 0.00m;
            AV61GTotalMN = 0.00m;
            AV62GTotalMO = 0.00m;
            AV98TipCod = A149TipCod;
            AV96TipAbr = A306TipAbr;
            AV8AnoDUA = "";
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P009L11_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK9L8 = false;
               A157TipSCod = P009L11_A157TipSCod[0];
               n157TipSCod = P009L11_n157TipSCod[0];
               A707ComFReg = P009L11_A707ComFReg[0];
               A708ComFVcto = P009L11_A708ComFVcto[0];
               A246ComMon = P009L11_A246ComMon[0];
               A149TipCod = P009L11_A149TipCod[0];
               A1233MonAbr = P009L11_A1233MonAbr[0];
               n1233MonAbr = P009L11_n1233MonAbr[0];
               A1916TipSAbr = P009L11_A1916TipSAbr[0];
               A243ComCod = P009L11_A243ComCod[0];
               A244PrvCod = P009L11_A244PrvCod[0];
               A247PrvDsc = P009L11_A247PrvDsc[0];
               A249ComRef = P009L11_A249ComRef[0];
               A704ComFecPago = P009L11_A704ComFecPago[0];
               A727ComRetCod = P009L11_A727ComRetCod[0];
               A730ComRetFec = P009L11_A730ComRetFec[0];
               A735ComTipReg = P009L11_A735ComTipReg[0];
               A725ComRefTDoc = P009L11_A725ComRefTDoc[0];
               A722ComRefDoc = P009L11_A722ComRefDoc[0];
               A724ComRefFec = P009L11_A724ComRefFec[0];
               A511TipSigno = P009L11_A511TipSigno[0];
               A248ComFec = P009L11_A248ComFec[0];
               A729ComRete2 = P009L11_A729ComRete2[0];
               A728ComRete1 = P009L11_A728ComRete1[0];
               A719ComIVADUA = P009L11_A719ComIVADUA[0];
               A718ComRedondeo = P009L11_A718ComRedondeo[0];
               A717ComPorIva = P009L11_A717ComPorIva[0];
               A698ComDscto = P009L11_A698ComDscto[0];
               A713ComISC = P009L11_A713ComISC[0];
               A706ComFlete = P009L11_A706ComFlete[0];
               A1233MonAbr = P009L11_A1233MonAbr[0];
               n1233MonAbr = P009L11_n1233MonAbr[0];
               A511TipSigno = P009L11_A511TipSigno[0];
               A157TipSCod = P009L11_A157TipSCod[0];
               n157TipSCod = P009L11_n157TipSCod[0];
               A1916TipSAbr = P009L11_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV96TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV73jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV74jMes )
                     {
                        /* Using cursor P009L13 */
                        pr_default.execute(5, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(5) != 101) )
                        {
                           A732ComSubIna = P009L13_A732ComSubIna[0];
                           A716ComSubAfe = P009L13_A716ComSubAfe[0];
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
                        AV77MonCod = A246ComMon;
                        AV98TipCod = A149TipCod;
                        AV76MonAbr = A1233MonAbr;
                        AV101TipVenta = 1.00000m;
                        AV97TipCmb = "";
                        AV28DocAbr = A306TipAbr;
                        AV100TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV9AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV10AT1 = (int)(AV9AT-1);
                        AV11AT2 = (int)(AV9AT+1);
                        AV85Serie = ((AV9AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV10AT1));
                        AV32DocNum = ((AV9AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV11AT2, 20));
                        AV8AnoDUA = ((StringUtil.StrCmp(AV28DocAbr, "50")==0)||(StringUtil.StrCmp(AV28DocAbr, "52")==0)||(StringUtil.StrCmp(AV28DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV31DocFec = A248ComFec;
                        AV82PrvCod = A244PrvCod;
                        AV83PrvDsc = A247PrvDsc;
                        GXt_char1 = AV33DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV98TipCod, ref  AV32DocNum, out  GXt_char1) ;
                        AV33DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV15ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV25ComRetCod = A727ComRetCod;
                        AV26ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV27ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV106TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV106TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV106TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P009L11_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV34Dscto = 0.00m;
                        AV66Igv1 = 0.00m;
                        AV67Igv2 = 0.00m;
                        AV68Igv3 = 0.00m;
                        AV104TotalMN = 0.00m;
                        AV105TotalMO = 0.00m;
                        AV72ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV77MonCod != 1 )
                        {
                           AV39Fecha = (((StringUtil.StrCmp(AV28DocAbr, "07")==0)||(StringUtil.StrCmp(AV28DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV31DocFec);
                           if ( (DateTime.MinValue==AV15ComFecPago) )
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV39Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV15ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           AV97TipCmb = StringUtil.Trim( StringUtil.Str( AV101TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV33DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV101TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV101TipVenta)*A511TipSigno);
                           AV34Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV101TipVenta)*A511TipSigno);
                           AV72ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV101TipVenta)*A511TipSigno);
                           AV23ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV101TipVenta)*A511TipSigno);
                           AV24ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV101TipVenta)*A511TipSigno);
                           AV16ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV101TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV88SubTotal) )
                           {
                              AV88SubTotal = (decimal)((AV88SubTotal+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           else
                           {
                              AV87SubIna = (decimal)((AV87SubIna+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           AV89SubTotal1 = AV88SubTotal;
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV66Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV101TipVenta)*A511TipSigno);
                           AV67Igv2 = 0.00m;
                           AV68Igv3 = 0.00m;
                           AV104TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV101TipVenta)*A511TipSigno);
                           AV105TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV101TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2));
                           AV105TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                           AV104TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                        }
                        AV58GSubTotal1 = (decimal)(AV58GSubTotal1+AV89SubTotal1);
                        AV59GSubTotal2 = (decimal)(AV59GSubTotal2+AV90SubTotal2);
                        AV60GSubTotal3 = (decimal)(AV60GSubTotal3+AV91SubTotal3);
                        AV42GIgv1 = (decimal)(AV42GIgv1+AV66Igv1);
                        AV43GIgv2 = (decimal)(AV43GIgv2+AV67Igv2);
                        AV44GIgv3 = (decimal)(AV44GIgv3+AV68Igv3);
                        AV49GISC = (decimal)(AV49GISC+AV72ISC);
                        AV55GSubIna = (decimal)(AV55GSubIna+AV87SubIna);
                        AV40GDscto = (decimal)(AV40GDscto+AV34Dscto);
                        AV61GTotalMN = (decimal)(AV61GTotalMN+AV104TotalMN);
                        AV62GTotalMO = (decimal)(AV62GTotalMO+AV105TotalMO);
                        H9L0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+1, 881, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 2, Gx_line+3, 45, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV31DocFec, "99/99/99"), 50, Gx_line+3, 82, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV15ComFecPago, "99/99/99"), 90, Gx_line+3, 122, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DocAbr, "")), 125, Gx_line+3, 147, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DocNum, "")), 232, Gx_line+3, 297, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 695, Gx_line+3, 767, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 645, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+3, 698, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72ISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+3, 820, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82PrvCod, "@!")), 324, Gx_line+3, 408, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83PrvDsc, "")), 390, Gx_line+1, 591, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ComRetCod, "")), 972, Gx_line+3, 1036, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ComRetFec, "")), 932, Gx_line+4, 965, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TipCmb, "")), 885, Gx_line+3, 928, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TipSunat, "")), 301, Gx_line+2, 319, Gx_line+15, 1+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Serie, "")), 150, Gx_line+3, 187, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8AnoDUA, "")), 195, Gx_line+3, 225, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1100, Gx_line+3, 1151, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1034, Gx_line+3, 1074, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TRef, "")), 1076, Gx_line+3, 1098, Gx_line+13, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV52GSubAfePag1 = (decimal)(AV52GSubAfePag1+AV89SubTotal1);
                        AV53GSubAfePag2 = (decimal)(AV53GSubAfePag2+AV90SubTotal2);
                        AV54GSubAfePag3 = (decimal)(AV54GSubAfePag3+AV91SubTotal3);
                        AV56GSubInaPag = (decimal)(AV56GSubInaPag+AV87SubIna);
                        AV46GIGVPag1 = (decimal)(AV46GIGVPag1+AV66Igv1);
                        AV47GIGVPag2 = (decimal)(AV47GIGVPag2+AV67Igv2);
                        AV48GIGVPag3 = (decimal)(AV48GIGVPag3+AV68Igv3);
                        AV50GISCPag = (decimal)(AV50GISCPag+AV72ISC);
                        AV63GTotPag = (decimal)(AV63GTotPag+AV104TotalMN);
                     }
                  }
               }
               BRK9L8 = true;
               pr_default.readNext(4);
            }
            AV108TSubTotal1 = (decimal)(AV108TSubTotal1+AV58GSubTotal1);
            AV109TSubTotal2 = (decimal)(AV109TSubTotal2+AV59GSubTotal2);
            AV110TSubTotal3 = (decimal)(AV110TSubTotal3+AV60GSubTotal3);
            AV111TSubTotalI = (decimal)(AV111TSubTotalI+AV55GSubIna);
            AV93TIGV1 = (decimal)(AV93TIGV1+AV42GIgv1);
            AV94TIGV2 = (decimal)(AV94TIGV2+AV43GIgv2);
            AV95TIGV3 = (decimal)(AV95TIGV3+AV44GIgv3);
            AV102TISC = (decimal)(AV102TISC+AV49GISC);
            AV113TTotalMN = (decimal)(AV113TTotalMN+AV61GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV62GTotalMO) )
            {
               AV103Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               H9L0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103Totales, "")), 96, Gx_line+18, 561, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+20, 645, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+18, 881, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+20, 698, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49GISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+20, 820, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+20, 765, Gx_line+31, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRK9L8 )
            {
               BRK9L8 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S141( )
      {
         /* 'ORDENAPROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P009L15 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK9L10 = false;
            A157TipSCod = P009L15_A157TipSCod[0];
            n157TipSCod = P009L15_n157TipSCod[0];
            A1906TipCmp = P009L15_A1906TipCmp[0];
            A306TipAbr = P009L15_A306TipAbr[0];
            A707ComFReg = P009L15_A707ComFReg[0];
            A708ComFVcto = P009L15_A708ComFVcto[0];
            A246ComMon = P009L15_A246ComMon[0];
            A149TipCod = P009L15_A149TipCod[0];
            A1233MonAbr = P009L15_A1233MonAbr[0];
            n1233MonAbr = P009L15_n1233MonAbr[0];
            A1916TipSAbr = P009L15_A1916TipSAbr[0];
            A243ComCod = P009L15_A243ComCod[0];
            A248ComFec = P009L15_A248ComFec[0];
            A244PrvCod = P009L15_A244PrvCod[0];
            A249ComRef = P009L15_A249ComRef[0];
            A704ComFecPago = P009L15_A704ComFecPago[0];
            A727ComRetCod = P009L15_A727ComRetCod[0];
            A730ComRetFec = P009L15_A730ComRetFec[0];
            A735ComTipReg = P009L15_A735ComTipReg[0];
            A725ComRefTDoc = P009L15_A725ComRefTDoc[0];
            A722ComRefDoc = P009L15_A722ComRefDoc[0];
            A724ComRefFec = P009L15_A724ComRefFec[0];
            A511TipSigno = P009L15_A511TipSigno[0];
            A247PrvDsc = P009L15_A247PrvDsc[0];
            A729ComRete2 = P009L15_A729ComRete2[0];
            A728ComRete1 = P009L15_A728ComRete1[0];
            A732ComSubIna = P009L15_A732ComSubIna[0];
            A719ComIVADUA = P009L15_A719ComIVADUA[0];
            A718ComRedondeo = P009L15_A718ComRedondeo[0];
            A717ComPorIva = P009L15_A717ComPorIva[0];
            A698ComDscto = P009L15_A698ComDscto[0];
            A713ComISC = P009L15_A713ComISC[0];
            A706ComFlete = P009L15_A706ComFlete[0];
            A716ComSubAfe = P009L15_A716ComSubAfe[0];
            A1233MonAbr = P009L15_A1233MonAbr[0];
            n1233MonAbr = P009L15_n1233MonAbr[0];
            A1906TipCmp = P009L15_A1906TipCmp[0];
            A306TipAbr = P009L15_A306TipAbr[0];
            A511TipSigno = P009L15_A511TipSigno[0];
            A157TipSCod = P009L15_A157TipSCod[0];
            n157TipSCod = P009L15_n157TipSCod[0];
            A1916TipSAbr = P009L15_A1916TipSAbr[0];
            A732ComSubIna = P009L15_A732ComSubIna[0];
            A716ComSubAfe = P009L15_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV58GSubTotal1 = 0.00m;
            AV59GSubTotal2 = 0.00m;
            AV60GSubTotal3 = 0.00m;
            AV55GSubIna = 0.00m;
            AV40GDscto = 0.00m;
            AV42GIgv1 = 0.00m;
            AV43GIgv2 = 0.00m;
            AV44GIgv3 = 0.00m;
            AV49GISC = 0.00m;
            AV61GTotalMN = 0.00m;
            AV62GTotalMO = 0.00m;
            AV98TipCod = A149TipCod;
            AV96TipAbr = A306TipAbr;
            AV8AnoDUA = "";
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P009L15_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK9L10 = false;
               A157TipSCod = P009L15_A157TipSCod[0];
               n157TipSCod = P009L15_n157TipSCod[0];
               A707ComFReg = P009L15_A707ComFReg[0];
               A708ComFVcto = P009L15_A708ComFVcto[0];
               A246ComMon = P009L15_A246ComMon[0];
               A149TipCod = P009L15_A149TipCod[0];
               A1233MonAbr = P009L15_A1233MonAbr[0];
               n1233MonAbr = P009L15_n1233MonAbr[0];
               A1916TipSAbr = P009L15_A1916TipSAbr[0];
               A243ComCod = P009L15_A243ComCod[0];
               A248ComFec = P009L15_A248ComFec[0];
               A244PrvCod = P009L15_A244PrvCod[0];
               A249ComRef = P009L15_A249ComRef[0];
               A704ComFecPago = P009L15_A704ComFecPago[0];
               A727ComRetCod = P009L15_A727ComRetCod[0];
               A730ComRetFec = P009L15_A730ComRetFec[0];
               A735ComTipReg = P009L15_A735ComTipReg[0];
               A725ComRefTDoc = P009L15_A725ComRefTDoc[0];
               A722ComRefDoc = P009L15_A722ComRefDoc[0];
               A724ComRefFec = P009L15_A724ComRefFec[0];
               A511TipSigno = P009L15_A511TipSigno[0];
               A247PrvDsc = P009L15_A247PrvDsc[0];
               A729ComRete2 = P009L15_A729ComRete2[0];
               A728ComRete1 = P009L15_A728ComRete1[0];
               A719ComIVADUA = P009L15_A719ComIVADUA[0];
               A718ComRedondeo = P009L15_A718ComRedondeo[0];
               A717ComPorIva = P009L15_A717ComPorIva[0];
               A698ComDscto = P009L15_A698ComDscto[0];
               A713ComISC = P009L15_A713ComISC[0];
               A706ComFlete = P009L15_A706ComFlete[0];
               A1233MonAbr = P009L15_A1233MonAbr[0];
               n1233MonAbr = P009L15_n1233MonAbr[0];
               A511TipSigno = P009L15_A511TipSigno[0];
               A157TipSCod = P009L15_A157TipSCod[0];
               n157TipSCod = P009L15_n157TipSCod[0];
               A1916TipSAbr = P009L15_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV96TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV73jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV74jMes )
                     {
                        /* Using cursor P009L17 */
                        pr_default.execute(7, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(7) != 101) )
                        {
                           A732ComSubIna = P009L17_A732ComSubIna[0];
                           A716ComSubAfe = P009L17_A716ComSubAfe[0];
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
                        AV77MonCod = A246ComMon;
                        AV98TipCod = A149TipCod;
                        AV76MonAbr = A1233MonAbr;
                        AV101TipVenta = 1.00000m;
                        AV97TipCmb = "";
                        AV28DocAbr = A306TipAbr;
                        AV100TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV9AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV10AT1 = (int)(AV9AT-1);
                        AV11AT2 = (int)(AV9AT+1);
                        AV85Serie = ((AV9AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV10AT1));
                        AV32DocNum = ((AV9AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV11AT2, 20));
                        AV8AnoDUA = ((StringUtil.StrCmp(AV28DocAbr, "50")==0)||(StringUtil.StrCmp(AV28DocAbr, "52")==0)||(StringUtil.StrCmp(AV28DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV31DocFec = A248ComFec;
                        AV82PrvCod = A244PrvCod;
                        AV83PrvDsc = A247PrvDsc;
                        GXt_char1 = AV33DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV98TipCod, ref  AV32DocNum, out  GXt_char1) ;
                        AV33DocSts = GXt_char1;
                        AV19ComRef = A249ComRef;
                        AV15ComFecPago = A704ComFecPago;
                        AV18ComPorIva = A717ComPorIva;
                        AV25ComRetCod = A727ComRetCod;
                        AV26ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV27ComTipReg = A735ComTipReg;
                        AV22ComRefTDoc = A725ComRefTDoc;
                        AV106TRef = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV106TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV106TRef = GXt_char1;
                        }
                        AV20ComRefDoc = A722ComRefDoc;
                        AV21ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P009L15_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV34Dscto = 0.00m;
                        AV66Igv1 = 0.00m;
                        AV67Igv2 = 0.00m;
                        AV68Igv3 = 0.00m;
                        AV104TotalMN = 0.00m;
                        AV105TotalMO = 0.00m;
                        AV72ISC = 0.00m;
                        AV18ComPorIva = A717ComPorIva;
                        if ( AV77MonCod != 1 )
                        {
                           AV39Fecha = (((StringUtil.StrCmp(AV28DocAbr, "07")==0)||(StringUtil.StrCmp(AV28DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV31DocFec);
                           if ( (DateTime.MinValue==AV15ComFecPago) )
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV39Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV101TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV77MonCod, ref  AV15ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV101TipVenta = GXt_decimal2;
                           }
                           AV97TipCmb = StringUtil.Trim( StringUtil.Str( AV101TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV33DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV101TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV101TipVenta)*A511TipSigno);
                           AV34Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV101TipVenta)*A511TipSigno);
                           AV72ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV101TipVenta)*A511TipSigno);
                           AV23ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV101TipVenta)*A511TipSigno);
                           AV24ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV101TipVenta)*A511TipSigno);
                           AV16ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV101TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV88SubTotal) )
                           {
                              AV88SubTotal = (decimal)((AV88SubTotal+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           else
                           {
                              AV87SubIna = (decimal)((AV87SubIna+AV16ComFlete)-(AV34Dscto+AV23ComRet1+AV24ComRet2));
                           }
                           AV89SubTotal1 = AV88SubTotal;
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV66Igv1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV101TipVenta)*A511TipSigno);
                           AV67Igv2 = 0.00m;
                           AV68Igv3 = 0.00m;
                           AV104TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV101TipVenta)*A511TipSigno);
                           AV105TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV17ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV101TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV17ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV17ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV18ComPorIva) ? (decimal)(1) : AV18ComPorIva)))*100, 2));
                           AV105TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                           AV104TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV66Igv1+AV67Igv2+AV68Igv3);
                        }
                        AV58GSubTotal1 = (decimal)(AV58GSubTotal1+AV89SubTotal1);
                        AV59GSubTotal2 = (decimal)(AV59GSubTotal2+AV90SubTotal2);
                        AV60GSubTotal3 = (decimal)(AV60GSubTotal3+AV91SubTotal3);
                        AV42GIgv1 = (decimal)(AV42GIgv1+AV66Igv1);
                        AV43GIgv2 = (decimal)(AV43GIgv2+AV67Igv2);
                        AV44GIgv3 = (decimal)(AV44GIgv3+AV68Igv3);
                        AV49GISC = (decimal)(AV49GISC+AV72ISC);
                        AV55GSubIna = (decimal)(AV55GSubIna+AV87SubIna);
                        AV40GDscto = (decimal)(AV40GDscto+AV34Dscto);
                        AV61GTotalMN = (decimal)(AV61GTotalMN+AV104TotalMN);
                        AV62GTotalMO = (decimal)(AV62GTotalMO+AV105TotalMO);
                        H9L0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV104TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+1, 881, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19ComRef, "")), 2, Gx_line+3, 45, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV31DocFec, "99/99/99"), 50, Gx_line+3, 82, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV15ComFecPago, "99/99/99"), 90, Gx_line+3, 122, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28DocAbr, "")), 125, Gx_line+3, 147, Gx_line+13, 1, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32DocNum, "")), 232, Gx_line+3, 297, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV87SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 695, Gx_line+3, 767, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV89SubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 645, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66Igv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+3, 698, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72ISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+3, 820, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82PrvCod, "@!")), 324, Gx_line+3, 408, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83PrvDsc, "")), 390, Gx_line+1, 591, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25ComRetCod, "")), 972, Gx_line+3, 1036, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ComRetFec, "")), 932, Gx_line+4, 965, Gx_line+12, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TipCmb, "")), 885, Gx_line+3, 928, Gx_line+14, 2+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100TipSunat, "")), 301, Gx_line+2, 319, Gx_line+15, 1+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Serie, "")), 150, Gx_line+3, 187, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8AnoDUA, "")), 195, Gx_line+3, 225, Gx_line+14, 0+256, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 5, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20ComRefDoc, "")), 1100, Gx_line+3, 1151, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21ComRefFec, "")), 1034, Gx_line+3, 1074, Gx_line+13, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TRef, "")), 1076, Gx_line+3, 1098, Gx_line+13, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV52GSubAfePag1 = (decimal)(AV52GSubAfePag1+AV89SubTotal1);
                        AV53GSubAfePag2 = (decimal)(AV53GSubAfePag2+AV90SubTotal2);
                        AV54GSubAfePag3 = (decimal)(AV54GSubAfePag3+AV91SubTotal3);
                        AV56GSubInaPag = (decimal)(AV56GSubInaPag+AV87SubIna);
                        AV46GIGVPag1 = (decimal)(AV46GIGVPag1+AV66Igv1);
                        AV47GIGVPag2 = (decimal)(AV47GIGVPag2+AV67Igv2);
                        AV48GIGVPag3 = (decimal)(AV48GIGVPag3+AV68Igv3);
                        AV50GISCPag = (decimal)(AV50GISCPag+AV72ISC);
                        AV63GTotPag = (decimal)(AV63GTotPag+AV104TotalMN);
                     }
                  }
               }
               BRK9L10 = true;
               pr_default.readNext(6);
            }
            AV108TSubTotal1 = (decimal)(AV108TSubTotal1+AV58GSubTotal1);
            AV109TSubTotal2 = (decimal)(AV109TSubTotal2+AV59GSubTotal2);
            AV110TSubTotal3 = (decimal)(AV110TSubTotal3+AV60GSubTotal3);
            AV111TSubTotalI = (decimal)(AV111TSubTotalI+AV55GSubIna);
            AV93TIGV1 = (decimal)(AV93TIGV1+AV42GIgv1);
            AV94TIGV2 = (decimal)(AV94TIGV2+AV43GIgv2);
            AV95TIGV3 = (decimal)(AV95TIGV3+AV44GIgv3);
            AV102TISC = (decimal)(AV102TISC+AV49GISC);
            AV113TTotalMN = (decimal)(AV113TTotalMN+AV61GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV62GTotalMO) )
            {
               AV103Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               H9L0( false, 38) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103Totales, "")), 96, Gx_line+18, 561, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58GSubTotal1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+20, 645, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 784, Gx_line+18, 881, Gx_line+32, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(505, Gx_line+7, 1074, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42GIgv1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+20, 698, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV49GISC, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+20, 820, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV55GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+20, 765, Gx_line+31, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+38);
            }
            if ( ! BRK9L10 )
            {
               BRK9L10 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void H9L0( bool bFoot ,
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
                  getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Total Pagina : ", 352, Gx_line+11, 428, Gx_line+24, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 455, Gx_line+11, 487, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56GSubInaPag, "ZZZZZZ,ZZZ,ZZ9.99")), 693, Gx_line+13, 765, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV50GISCPag, "ZZZZZZ,ZZZ,ZZ9.99")), 748, Gx_line+13, 820, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52GSubAfePag1, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+13, 645, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63GTotPag, "ZZZZZZ,ZZZ,ZZ9.99")), 810, Gx_line+13, 882, Gx_line+24, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46GIGVPag1, "ZZZZZZ,ZZZ,ZZ9.99")), 626, Gx_line+13, 698, Gx_line+24, 2+256, 0, 0, 0) ;
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
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV73jAno), "ZZZ9")), 444, Gx_line+93, 483, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV14cMes, "")), 621, Gx_line+93, 731, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37EmpRUC, "")), 8, Gx_line+100, 377, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36Empresa, "")), 8, Gx_line+82, 376, Gx_line+100, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV75Logo)) ? AV116Logo_GXI : AV75Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+10, 177, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+28, 1075, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 986, Gx_line+28, 1030, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FORMATO 8.1", 986, Gx_line+14, 1065, Gx_line+28, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
               getPrinter().GxDrawLine(46, Gx_line+0, 46, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(83, Gx_line+0, 83, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(231, Gx_line+0, 231, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre o", 470, Gx_line+17, 512, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(645, Gx_line+24, 645, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(880, Gx_line+0, 880, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(592, Gx_line+0, 592, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(820, Gx_line+0, 820, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 53, Gx_line+4, 79, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(124, Gx_line+0, 124, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 92, Gx_line+4, 118, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vcto y/o", 86, Gx_line+17, 122, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Pago", 94, Gx_line+31, 116, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Razon Social", 466, Gx_line+30, 519, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(703, Gx_line+0, 703, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 5, Gx_line+4, 39, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Correlativo", 1, Gx_line+17, 47, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Registro", 4, Gx_line+31, 39, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de", 60, Gx_line+17, 71, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 49, Gx_line+31, 82, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(124, Gx_line+17, 231, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprobante de Pago", 131, Gx_line+3, 224, Gx_line+13, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(149, Gx_line+18, 149, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 128, Gx_line+27, 147, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año Emisión", 182, Gx_line+20, 233, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Información de Proveedor", 394, Gx_line+2, 503, Gx_line+12, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(295, Gx_line+13, 593, Gx_line+13, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. de Identidad", 298, Gx_line+15, 373, Gx_line+25, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(388, Gx_line+13, 388, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(295, Gx_line+26, 389, Gx_line+26, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(324, Gx_line+26, 324, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 302, Gx_line+29, 321, Gx_line+39, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Número", 340, Gx_line+30, 374, Gx_line+40, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 608, Gx_line+24, 631, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Importe", 838, Gx_line+10, 873, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia de Comprobante", 1036, Gx_line+4, 1153, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1016, Gx_line+17, 1157, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1073, Gx_line+18, 1073, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo", 1077, Gx_line+24, 1096, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1099, Gx_line+18, 1099, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 1101, Gx_line+23, 1155, Gx_line+33, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de", 889, Gx_line+10, 920, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cambio", 889, Gx_line+25, 921, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 598, Gx_line+33, 642, Gx_line+43, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total", 844, Gx_line+25, 866, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+0, 1157, Gx_line+46, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 1041, Gx_line+24, 1067, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(765, Gx_line+0, 765, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Base ", 727, Gx_line+4, 750, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 717, Gx_line+18, 761, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("IGV", 665, Gx_line+31, 682, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("I.S.C.", 780, Gx_line+17, 805, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Inafecta", 721, Gx_line+31, 757, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(1033, Gx_line+0, 1033, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(931, Gx_line+0, 931, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 935, Gx_line+24, 961, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cons. Detracción", 948, Gx_line+4, 1018, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(932, Gx_line+17, 1018, Gx_line+17, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(971, Gx_line+18, 971, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 974, Gx_line+24, 1028, Gx_line+34, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(295, Gx_line+0, 295, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Comprob.", 236, Gx_line+4, 290, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° de DUA", 242, Gx_line+18, 286, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Otros", 252, Gx_line+31, 275, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Serie", 154, Gx_line+27, 176, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(181, Gx_line+17, 181, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("DUA o DSI", 185, Gx_line+32, 229, Gx_line+42, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(592, Gx_line+24, 705, Gx_line+24, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Adquisiciones Gravadas", 600, Gx_line+1, 698, Gx_line+11, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Operaciones G. y/o Exp.", 598, Gx_line+13, 700, Gx_line+23, 0+256, 0, 0, 0) ;
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
         AV36Empresa = "";
         AV86Session = context.GetSession();
         AV35EmpDir = "";
         AV37EmpRUC = "";
         AV84Ruta = "";
         AV75Logo = "";
         AV116Logo_GXI = "";
         AV14cMes = "";
         AV28DocAbr = "";
         AV32DocNum = "";
         AV31DocFec = DateTime.MinValue;
         AV15ComFecPago = DateTime.MinValue;
         AV82PrvCod = "";
         AV83PrvDsc = "";
         AV97TipCmb = "";
         scmdbuf = "";
         P009L3_A157TipSCod = new int[1] ;
         P009L3_n157TipSCod = new bool[] {false} ;
         P009L3_A1906TipCmp = new short[1] ;
         P009L3_A306TipAbr = new string[] {""} ;
         P009L3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009L3_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009L3_A246ComMon = new int[1] ;
         P009L3_A149TipCod = new string[] {""} ;
         P009L3_A1233MonAbr = new string[] {""} ;
         P009L3_n1233MonAbr = new bool[] {false} ;
         P009L3_A1916TipSAbr = new string[] {""} ;
         P009L3_A243ComCod = new string[] {""} ;
         P009L3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009L3_A244PrvCod = new string[] {""} ;
         P009L3_A247PrvDsc = new string[] {""} ;
         P009L3_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P009L3_A727ComRetCod = new string[] {""} ;
         P009L3_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P009L3_A735ComTipReg = new string[] {""} ;
         P009L3_A725ComRefTDoc = new string[] {""} ;
         P009L3_A722ComRefDoc = new string[] {""} ;
         P009L3_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P009L3_A511TipSigno = new short[1] ;
         P009L3_A249ComRef = new string[] {""} ;
         P009L3_A729ComRete2 = new decimal[1] ;
         P009L3_A728ComRete1 = new decimal[1] ;
         P009L3_A732ComSubIna = new decimal[1] ;
         P009L3_A719ComIVADUA = new decimal[1] ;
         P009L3_A718ComRedondeo = new decimal[1] ;
         P009L3_A717ComPorIva = new decimal[1] ;
         P009L3_A698ComDscto = new decimal[1] ;
         P009L3_A713ComISC = new decimal[1] ;
         P009L3_A706ComFlete = new decimal[1] ;
         P009L3_A716ComSubAfe = new decimal[1] ;
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
         AV98TipCod = "";
         AV96TipAbr = "";
         AV8AnoDUA = "";
         P009L5_A732ComSubIna = new decimal[1] ;
         P009L5_A716ComSubAfe = new decimal[1] ;
         AV76MonAbr = "";
         AV100TipSunat = "";
         AV85Serie = "";
         AV33DocSts = "";
         AV19ComRef = "";
         AV25ComRetCod = "";
         AV26ComRetFec = "";
         AV27ComTipReg = "";
         AV22ComRefTDoc = "";
         AV106TRef = "";
         AV20ComRefDoc = "";
         AV21ComRefFec = "";
         P009L3_n724ComRefFec = new bool[] {false} ;
         AV39Fecha = DateTime.MinValue;
         AV103Totales = "";
         P009L7_A157TipSCod = new int[1] ;
         P009L7_n157TipSCod = new bool[] {false} ;
         P009L7_A1906TipCmp = new short[1] ;
         P009L7_A306TipAbr = new string[] {""} ;
         P009L7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009L7_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009L7_A246ComMon = new int[1] ;
         P009L7_A149TipCod = new string[] {""} ;
         P009L7_A1233MonAbr = new string[] {""} ;
         P009L7_n1233MonAbr = new bool[] {false} ;
         P009L7_A1916TipSAbr = new string[] {""} ;
         P009L7_A243ComCod = new string[] {""} ;
         P009L7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009L7_A244PrvCod = new string[] {""} ;
         P009L7_A247PrvDsc = new string[] {""} ;
         P009L7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P009L7_A727ComRetCod = new string[] {""} ;
         P009L7_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P009L7_A735ComTipReg = new string[] {""} ;
         P009L7_A725ComRefTDoc = new string[] {""} ;
         P009L7_A722ComRefDoc = new string[] {""} ;
         P009L7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P009L7_A511TipSigno = new short[1] ;
         P009L7_A249ComRef = new string[] {""} ;
         P009L7_A729ComRete2 = new decimal[1] ;
         P009L7_A728ComRete1 = new decimal[1] ;
         P009L7_A732ComSubIna = new decimal[1] ;
         P009L7_A719ComIVADUA = new decimal[1] ;
         P009L7_A718ComRedondeo = new decimal[1] ;
         P009L7_A717ComPorIva = new decimal[1] ;
         P009L7_A698ComDscto = new decimal[1] ;
         P009L7_A713ComISC = new decimal[1] ;
         P009L7_A706ComFlete = new decimal[1] ;
         P009L7_A716ComSubAfe = new decimal[1] ;
         P009L9_A732ComSubIna = new decimal[1] ;
         P009L9_A716ComSubAfe = new decimal[1] ;
         P009L7_n724ComRefFec = new bool[] {false} ;
         P009L11_A157TipSCod = new int[1] ;
         P009L11_n157TipSCod = new bool[] {false} ;
         P009L11_A1906TipCmp = new short[1] ;
         P009L11_A306TipAbr = new string[] {""} ;
         P009L11_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009L11_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009L11_A246ComMon = new int[1] ;
         P009L11_A149TipCod = new string[] {""} ;
         P009L11_A1233MonAbr = new string[] {""} ;
         P009L11_n1233MonAbr = new bool[] {false} ;
         P009L11_A1916TipSAbr = new string[] {""} ;
         P009L11_A243ComCod = new string[] {""} ;
         P009L11_A244PrvCod = new string[] {""} ;
         P009L11_A247PrvDsc = new string[] {""} ;
         P009L11_A249ComRef = new string[] {""} ;
         P009L11_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P009L11_A727ComRetCod = new string[] {""} ;
         P009L11_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P009L11_A735ComTipReg = new string[] {""} ;
         P009L11_A725ComRefTDoc = new string[] {""} ;
         P009L11_A722ComRefDoc = new string[] {""} ;
         P009L11_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P009L11_A511TipSigno = new short[1] ;
         P009L11_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009L11_A729ComRete2 = new decimal[1] ;
         P009L11_A728ComRete1 = new decimal[1] ;
         P009L11_A732ComSubIna = new decimal[1] ;
         P009L11_A719ComIVADUA = new decimal[1] ;
         P009L11_A718ComRedondeo = new decimal[1] ;
         P009L11_A717ComPorIva = new decimal[1] ;
         P009L11_A698ComDscto = new decimal[1] ;
         P009L11_A713ComISC = new decimal[1] ;
         P009L11_A706ComFlete = new decimal[1] ;
         P009L11_A716ComSubAfe = new decimal[1] ;
         P009L13_A732ComSubIna = new decimal[1] ;
         P009L13_A716ComSubAfe = new decimal[1] ;
         P009L11_n724ComRefFec = new bool[] {false} ;
         P009L15_A157TipSCod = new int[1] ;
         P009L15_n157TipSCod = new bool[] {false} ;
         P009L15_A1906TipCmp = new short[1] ;
         P009L15_A306TipAbr = new string[] {""} ;
         P009L15_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009L15_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009L15_A246ComMon = new int[1] ;
         P009L15_A149TipCod = new string[] {""} ;
         P009L15_A1233MonAbr = new string[] {""} ;
         P009L15_n1233MonAbr = new bool[] {false} ;
         P009L15_A1916TipSAbr = new string[] {""} ;
         P009L15_A243ComCod = new string[] {""} ;
         P009L15_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009L15_A244PrvCod = new string[] {""} ;
         P009L15_A249ComRef = new string[] {""} ;
         P009L15_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P009L15_A727ComRetCod = new string[] {""} ;
         P009L15_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P009L15_A735ComTipReg = new string[] {""} ;
         P009L15_A725ComRefTDoc = new string[] {""} ;
         P009L15_A722ComRefDoc = new string[] {""} ;
         P009L15_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P009L15_A511TipSigno = new short[1] ;
         P009L15_A247PrvDsc = new string[] {""} ;
         P009L15_A729ComRete2 = new decimal[1] ;
         P009L15_A728ComRete1 = new decimal[1] ;
         P009L15_A732ComSubIna = new decimal[1] ;
         P009L15_A719ComIVADUA = new decimal[1] ;
         P009L15_A718ComRedondeo = new decimal[1] ;
         P009L15_A717ComPorIva = new decimal[1] ;
         P009L15_A698ComDscto = new decimal[1] ;
         P009L15_A713ComISC = new decimal[1] ;
         P009L15_A706ComFlete = new decimal[1] ;
         P009L15_A716ComSubAfe = new decimal[1] ;
         P009L17_A732ComSubIna = new decimal[1] ;
         P009L17_A716ComSubAfe = new decimal[1] ;
         P009L15_n724ComRefFec = new bool[] {false} ;
         GXt_char1 = "";
         AV75Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrregistrocomprasoficial__default(),
            new Object[][] {
                new Object[] {
               P009L3_A157TipSCod, P009L3_n157TipSCod, P009L3_A1906TipCmp, P009L3_A306TipAbr, P009L3_A707ComFReg, P009L3_A708ComFVcto, P009L3_A246ComMon, P009L3_A149TipCod, P009L3_A1233MonAbr, P009L3_n1233MonAbr,
               P009L3_A1916TipSAbr, P009L3_A243ComCod, P009L3_A248ComFec, P009L3_A244PrvCod, P009L3_A247PrvDsc, P009L3_A704ComFecPago, P009L3_A727ComRetCod, P009L3_A730ComRetFec, P009L3_A735ComTipReg, P009L3_A725ComRefTDoc,
               P009L3_A722ComRefDoc, P009L3_A724ComRefFec, P009L3_A511TipSigno, P009L3_A249ComRef, P009L3_A729ComRete2, P009L3_A728ComRete1, P009L3_A732ComSubIna, P009L3_A719ComIVADUA, P009L3_A718ComRedondeo, P009L3_A717ComPorIva,
               P009L3_A698ComDscto, P009L3_A713ComISC, P009L3_A706ComFlete, P009L3_A716ComSubAfe
               }
               , new Object[] {
               P009L5_A732ComSubIna, P009L5_A716ComSubAfe
               }
               , new Object[] {
               P009L7_A157TipSCod, P009L7_n157TipSCod, P009L7_A1906TipCmp, P009L7_A306TipAbr, P009L7_A707ComFReg, P009L7_A708ComFVcto, P009L7_A246ComMon, P009L7_A149TipCod, P009L7_A1233MonAbr, P009L7_n1233MonAbr,
               P009L7_A1916TipSAbr, P009L7_A243ComCod, P009L7_A248ComFec, P009L7_A244PrvCod, P009L7_A247PrvDsc, P009L7_A704ComFecPago, P009L7_A727ComRetCod, P009L7_A730ComRetFec, P009L7_A735ComTipReg, P009L7_A725ComRefTDoc,
               P009L7_A722ComRefDoc, P009L7_A724ComRefFec, P009L7_A511TipSigno, P009L7_A249ComRef, P009L7_A729ComRete2, P009L7_A728ComRete1, P009L7_A732ComSubIna, P009L7_A719ComIVADUA, P009L7_A718ComRedondeo, P009L7_A717ComPorIva,
               P009L7_A698ComDscto, P009L7_A713ComISC, P009L7_A706ComFlete, P009L7_A716ComSubAfe
               }
               , new Object[] {
               P009L9_A732ComSubIna, P009L9_A716ComSubAfe
               }
               , new Object[] {
               P009L11_A157TipSCod, P009L11_n157TipSCod, P009L11_A1906TipCmp, P009L11_A306TipAbr, P009L11_A707ComFReg, P009L11_A708ComFVcto, P009L11_A246ComMon, P009L11_A149TipCod, P009L11_A1233MonAbr, P009L11_n1233MonAbr,
               P009L11_A1916TipSAbr, P009L11_A243ComCod, P009L11_A244PrvCod, P009L11_A247PrvDsc, P009L11_A249ComRef, P009L11_A704ComFecPago, P009L11_A727ComRetCod, P009L11_A730ComRetFec, P009L11_A735ComTipReg, P009L11_A725ComRefTDoc,
               P009L11_A722ComRefDoc, P009L11_A724ComRefFec, P009L11_A511TipSigno, P009L11_A248ComFec, P009L11_A729ComRete2, P009L11_A728ComRete1, P009L11_A732ComSubIna, P009L11_A719ComIVADUA, P009L11_A718ComRedondeo, P009L11_A717ComPorIva,
               P009L11_A698ComDscto, P009L11_A713ComISC, P009L11_A706ComFlete, P009L11_A716ComSubAfe
               }
               , new Object[] {
               P009L13_A732ComSubIna, P009L13_A716ComSubAfe
               }
               , new Object[] {
               P009L15_A157TipSCod, P009L15_n157TipSCod, P009L15_A1906TipCmp, P009L15_A306TipAbr, P009L15_A707ComFReg, P009L15_A708ComFVcto, P009L15_A246ComMon, P009L15_A149TipCod, P009L15_A1233MonAbr, P009L15_n1233MonAbr,
               P009L15_A1916TipSAbr, P009L15_A243ComCod, P009L15_A248ComFec, P009L15_A244PrvCod, P009L15_A249ComRef, P009L15_A704ComFecPago, P009L15_A727ComRetCod, P009L15_A730ComRetFec, P009L15_A735ComTipReg, P009L15_A725ComRefTDoc,
               P009L15_A722ComRefDoc, P009L15_A724ComRefFec, P009L15_A511TipSigno, P009L15_A247PrvDsc, P009L15_A729ComRete2, P009L15_A728ComRete1, P009L15_A732ComSubIna, P009L15_A719ComIVADUA, P009L15_A718ComRedondeo, P009L15_A717ComPorIva,
               P009L15_A698ComDscto, P009L15_A713ComISC, P009L15_A706ComFlete, P009L15_A716ComSubAfe
               }
               , new Object[] {
               P009L17_A732ComSubIna, P009L17_A716ComSubAfe
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV73jAno ;
      private short AV74jMes ;
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
      private int AV77MonCod ;
      private int AV10AT1 ;
      private int AV11AT2 ;
      private decimal AV88SubTotal ;
      private decimal AV34Dscto ;
      private decimal AV65Igv ;
      private decimal AV104TotalMN ;
      private decimal AV105TotalMO ;
      private decimal AV108TSubTotal1 ;
      private decimal AV109TSubTotal2 ;
      private decimal AV110TSubTotal3 ;
      private decimal AV111TSubTotalI ;
      private decimal AV93TIGV1 ;
      private decimal AV94TIGV2 ;
      private decimal AV95TIGV3 ;
      private decimal AV102TISC ;
      private decimal AV113TTotalMN ;
      private decimal AV79Por1 ;
      private decimal AV80Por2 ;
      private decimal AV12Base1 ;
      private decimal AV13Base2 ;
      private decimal AV70IgvPor1 ;
      private decimal AV71IgvPor2 ;
      private decimal AV52GSubAfePag1 ;
      private decimal AV53GSubAfePag2 ;
      private decimal AV54GSubAfePag3 ;
      private decimal AV56GSubInaPag ;
      private decimal AV46GIGVPag1 ;
      private decimal AV47GIGVPag2 ;
      private decimal AV48GIGVPag3 ;
      private decimal AV50GISCPag ;
      private decimal AV63GTotPag ;
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
      private decimal AV58GSubTotal1 ;
      private decimal AV59GSubTotal2 ;
      private decimal AV60GSubTotal3 ;
      private decimal AV55GSubIna ;
      private decimal AV40GDscto ;
      private decimal AV42GIgv1 ;
      private decimal AV43GIgv2 ;
      private decimal AV44GIgv3 ;
      private decimal AV49GISC ;
      private decimal AV61GTotalMN ;
      private decimal AV62GTotalMO ;
      private decimal AV101TipVenta ;
      private decimal AV9AT ;
      private decimal AV18ComPorIva ;
      private decimal AV89SubTotal1 ;
      private decimal AV90SubTotal2 ;
      private decimal AV91SubTotal3 ;
      private decimal AV87SubIna ;
      private decimal AV66Igv1 ;
      private decimal AV67Igv2 ;
      private decimal AV68Igv3 ;
      private decimal AV72ISC ;
      private decimal AV23ComRet1 ;
      private decimal AV24ComRet2 ;
      private decimal AV16ComFlete ;
      private decimal AV17ComIVADUA ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV78Orden ;
      private string AV36Empresa ;
      private string AV35EmpDir ;
      private string AV37EmpRUC ;
      private string AV84Ruta ;
      private string AV14cMes ;
      private string AV28DocAbr ;
      private string AV32DocNum ;
      private string AV82PrvCod ;
      private string AV83PrvDsc ;
      private string AV97TipCmb ;
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
      private string AV98TipCod ;
      private string AV96TipAbr ;
      private string AV8AnoDUA ;
      private string AV76MonAbr ;
      private string AV100TipSunat ;
      private string AV85Serie ;
      private string AV33DocSts ;
      private string AV19ComRef ;
      private string AV25ComRetCod ;
      private string AV26ComRetFec ;
      private string AV27ComTipReg ;
      private string AV22ComRefTDoc ;
      private string AV106TRef ;
      private string AV20ComRefDoc ;
      private string AV21ComRefFec ;
      private string AV103Totales ;
      private string GXt_char1 ;
      private string sImgUrl ;
      private DateTime AV31DocFec ;
      private DateTime AV15ComFecPago ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A730ComRetFec ;
      private DateTime A724ComRefFec ;
      private DateTime AV39Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRK9L4 ;
      private bool n157TipSCod ;
      private bool n1233MonAbr ;
      private bool BRK9L6 ;
      private bool BRK9L8 ;
      private bool BRK9L10 ;
      private string AV116Logo_GXI ;
      private string AV75Logo ;
      private string Logo ;
      private IGxSession AV86Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private string aP2_Orden ;
      private IDataStoreProvider pr_default ;
      private int[] P009L3_A157TipSCod ;
      private bool[] P009L3_n157TipSCod ;
      private short[] P009L3_A1906TipCmp ;
      private string[] P009L3_A306TipAbr ;
      private DateTime[] P009L3_A707ComFReg ;
      private DateTime[] P009L3_A708ComFVcto ;
      private int[] P009L3_A246ComMon ;
      private string[] P009L3_A149TipCod ;
      private string[] P009L3_A1233MonAbr ;
      private bool[] P009L3_n1233MonAbr ;
      private string[] P009L3_A1916TipSAbr ;
      private string[] P009L3_A243ComCod ;
      private DateTime[] P009L3_A248ComFec ;
      private string[] P009L3_A244PrvCod ;
      private string[] P009L3_A247PrvDsc ;
      private DateTime[] P009L3_A704ComFecPago ;
      private string[] P009L3_A727ComRetCod ;
      private DateTime[] P009L3_A730ComRetFec ;
      private string[] P009L3_A735ComTipReg ;
      private string[] P009L3_A725ComRefTDoc ;
      private string[] P009L3_A722ComRefDoc ;
      private DateTime[] P009L3_A724ComRefFec ;
      private short[] P009L3_A511TipSigno ;
      private string[] P009L3_A249ComRef ;
      private decimal[] P009L3_A729ComRete2 ;
      private decimal[] P009L3_A728ComRete1 ;
      private decimal[] P009L3_A732ComSubIna ;
      private decimal[] P009L3_A719ComIVADUA ;
      private decimal[] P009L3_A718ComRedondeo ;
      private decimal[] P009L3_A717ComPorIva ;
      private decimal[] P009L3_A698ComDscto ;
      private decimal[] P009L3_A713ComISC ;
      private decimal[] P009L3_A706ComFlete ;
      private decimal[] P009L3_A716ComSubAfe ;
      private decimal[] P009L5_A732ComSubIna ;
      private decimal[] P009L5_A716ComSubAfe ;
      private bool[] P009L3_n724ComRefFec ;
      private int[] P009L7_A157TipSCod ;
      private bool[] P009L7_n157TipSCod ;
      private short[] P009L7_A1906TipCmp ;
      private string[] P009L7_A306TipAbr ;
      private DateTime[] P009L7_A707ComFReg ;
      private DateTime[] P009L7_A708ComFVcto ;
      private int[] P009L7_A246ComMon ;
      private string[] P009L7_A149TipCod ;
      private string[] P009L7_A1233MonAbr ;
      private bool[] P009L7_n1233MonAbr ;
      private string[] P009L7_A1916TipSAbr ;
      private string[] P009L7_A243ComCod ;
      private DateTime[] P009L7_A248ComFec ;
      private string[] P009L7_A244PrvCod ;
      private string[] P009L7_A247PrvDsc ;
      private DateTime[] P009L7_A704ComFecPago ;
      private string[] P009L7_A727ComRetCod ;
      private DateTime[] P009L7_A730ComRetFec ;
      private string[] P009L7_A735ComTipReg ;
      private string[] P009L7_A725ComRefTDoc ;
      private string[] P009L7_A722ComRefDoc ;
      private DateTime[] P009L7_A724ComRefFec ;
      private short[] P009L7_A511TipSigno ;
      private string[] P009L7_A249ComRef ;
      private decimal[] P009L7_A729ComRete2 ;
      private decimal[] P009L7_A728ComRete1 ;
      private decimal[] P009L7_A732ComSubIna ;
      private decimal[] P009L7_A719ComIVADUA ;
      private decimal[] P009L7_A718ComRedondeo ;
      private decimal[] P009L7_A717ComPorIva ;
      private decimal[] P009L7_A698ComDscto ;
      private decimal[] P009L7_A713ComISC ;
      private decimal[] P009L7_A706ComFlete ;
      private decimal[] P009L7_A716ComSubAfe ;
      private decimal[] P009L9_A732ComSubIna ;
      private decimal[] P009L9_A716ComSubAfe ;
      private bool[] P009L7_n724ComRefFec ;
      private int[] P009L11_A157TipSCod ;
      private bool[] P009L11_n157TipSCod ;
      private short[] P009L11_A1906TipCmp ;
      private string[] P009L11_A306TipAbr ;
      private DateTime[] P009L11_A707ComFReg ;
      private DateTime[] P009L11_A708ComFVcto ;
      private int[] P009L11_A246ComMon ;
      private string[] P009L11_A149TipCod ;
      private string[] P009L11_A1233MonAbr ;
      private bool[] P009L11_n1233MonAbr ;
      private string[] P009L11_A1916TipSAbr ;
      private string[] P009L11_A243ComCod ;
      private string[] P009L11_A244PrvCod ;
      private string[] P009L11_A247PrvDsc ;
      private string[] P009L11_A249ComRef ;
      private DateTime[] P009L11_A704ComFecPago ;
      private string[] P009L11_A727ComRetCod ;
      private DateTime[] P009L11_A730ComRetFec ;
      private string[] P009L11_A735ComTipReg ;
      private string[] P009L11_A725ComRefTDoc ;
      private string[] P009L11_A722ComRefDoc ;
      private DateTime[] P009L11_A724ComRefFec ;
      private short[] P009L11_A511TipSigno ;
      private DateTime[] P009L11_A248ComFec ;
      private decimal[] P009L11_A729ComRete2 ;
      private decimal[] P009L11_A728ComRete1 ;
      private decimal[] P009L11_A732ComSubIna ;
      private decimal[] P009L11_A719ComIVADUA ;
      private decimal[] P009L11_A718ComRedondeo ;
      private decimal[] P009L11_A717ComPorIva ;
      private decimal[] P009L11_A698ComDscto ;
      private decimal[] P009L11_A713ComISC ;
      private decimal[] P009L11_A706ComFlete ;
      private decimal[] P009L11_A716ComSubAfe ;
      private decimal[] P009L13_A732ComSubIna ;
      private decimal[] P009L13_A716ComSubAfe ;
      private bool[] P009L11_n724ComRefFec ;
      private int[] P009L15_A157TipSCod ;
      private bool[] P009L15_n157TipSCod ;
      private short[] P009L15_A1906TipCmp ;
      private string[] P009L15_A306TipAbr ;
      private DateTime[] P009L15_A707ComFReg ;
      private DateTime[] P009L15_A708ComFVcto ;
      private int[] P009L15_A246ComMon ;
      private string[] P009L15_A149TipCod ;
      private string[] P009L15_A1233MonAbr ;
      private bool[] P009L15_n1233MonAbr ;
      private string[] P009L15_A1916TipSAbr ;
      private string[] P009L15_A243ComCod ;
      private DateTime[] P009L15_A248ComFec ;
      private string[] P009L15_A244PrvCod ;
      private string[] P009L15_A249ComRef ;
      private DateTime[] P009L15_A704ComFecPago ;
      private string[] P009L15_A727ComRetCod ;
      private DateTime[] P009L15_A730ComRetFec ;
      private string[] P009L15_A735ComTipReg ;
      private string[] P009L15_A725ComRefTDoc ;
      private string[] P009L15_A722ComRefDoc ;
      private DateTime[] P009L15_A724ComRefFec ;
      private short[] P009L15_A511TipSigno ;
      private string[] P009L15_A247PrvDsc ;
      private decimal[] P009L15_A729ComRete2 ;
      private decimal[] P009L15_A728ComRete1 ;
      private decimal[] P009L15_A732ComSubIna ;
      private decimal[] P009L15_A719ComIVADUA ;
      private decimal[] P009L15_A718ComRedondeo ;
      private decimal[] P009L15_A717ComPorIva ;
      private decimal[] P009L15_A698ComDscto ;
      private decimal[] P009L15_A713ComISC ;
      private decimal[] P009L15_A706ComFlete ;
      private decimal[] P009L15_A716ComSubAfe ;
      private decimal[] P009L17_A732ComSubIna ;
      private decimal[] P009L17_A716ComSubAfe ;
      private bool[] P009L15_n724ComRefFec ;
   }

   public class rrregistrocomprasoficial__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009L3;
          prmP009L3 = new Object[] {
          };
          Object[] prmP009L5;
          prmP009L5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009L7;
          prmP009L7 = new Object[] {
          };
          Object[] prmP009L9;
          prmP009L9 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009L11;
          prmP009L11 = new Object[] {
          };
          Object[] prmP009L13;
          prmP009L13 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP009L15;
          prmP009L15 = new Object[] {
          };
          Object[] prmP009L17;
          prmP009L17 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009L3", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L5", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L7", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L9", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L11", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComFec], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L13", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L15", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[PrvDsc], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[PrvDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009L17", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009L17,1, GxCacheFrequency.OFF ,true,false )
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
