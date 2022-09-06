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
namespace GeneXus.Programs.compras {
   public class r_registrocompraspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_registrocompraspdf.aspx")), "compras.r_registrocompraspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_registrocompraspdf.aspx")))) ;
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
               AV41jAno = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV42jMes = (short)(NumberUtil.Val( GetPar( "jMes"), "."));
                  AV46Orden = GetPar( "Orden");
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

      public r_registrocompraspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registrocompraspdf( IGxContext context )
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
         this.AV41jAno = aP0_jAno;
         this.AV42jMes = aP1_jMes;
         this.AV46Orden = aP2_Orden;
         initialize();
         executePrivate();
         aP0_jAno=this.AV41jAno;
         aP1_jMes=this.AV42jMes;
         aP2_Orden=this.AV46Orden;
      }

      public string executeUdp( ref short aP0_jAno ,
                                ref short aP1_jMes )
      {
         execute(ref aP0_jAno, ref aP1_jMes, ref aP2_Orden);
         return AV46Orden ;
      }

      public void executeSubmit( ref short aP0_jAno ,
                                 ref short aP1_jMes ,
                                 ref string aP2_Orden )
      {
         r_registrocompraspdf objr_registrocompraspdf;
         objr_registrocompraspdf = new r_registrocompraspdf();
         objr_registrocompraspdf.AV41jAno = aP0_jAno;
         objr_registrocompraspdf.AV42jMes = aP1_jMes;
         objr_registrocompraspdf.AV46Orden = aP2_Orden;
         objr_registrocompraspdf.context.SetSubmitInitialConfig(context);
         objr_registrocompraspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registrocompraspdf);
         aP0_jAno=this.AV41jAno;
         aP1_jMes=this.AV42jMes;
         aP2_Orden=this.AV46Orden;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registrocompraspdf)stateInfo).executePrivate();
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
            AV26Empresa = AV50Session.Get("Empresa");
            AV25EmpDir = AV50Session.Get("EmpDir");
            AV27EmpRUC = AV50Session.Get("EmpRUC");
            AV49Ruta = AV50Session.Get("RUTA") + "/Logo.jpg";
            AV43Logo = AV49Ruta;
            AV67Logo_GXI = GXDbFile.PathToUrl( AV49Ruta);
            GXt_char1 = AV8cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV42jMes, out  GXt_char1) ;
            AV8cMes = GXt_char1;
            AV17DocAbr = "";
            AV21DocNum = "";
            AV20DocFec = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
            AV9ComFecPago = DateTime.MinValue;
            AV47PrvCod = "";
            AV48PrvDsc = "";
            AV52SubTotal = 0.00m;
            AV24Dscto = 0.00m;
            AV40Igv = 0.00m;
            AV59TotalMN = 0.00m;
            AV60TotalMO = 0.00m;
            AV55TipCmb = "";
            AV61TSubTotal = 0.00m;
            AV62TSubTotalI = 0.00m;
            AV63TTDscto = 0.00m;
            AV53TIGV = 0.00m;
            AV64TTotalMN = 0.00m;
            AV33GSubAfePag = 0.00m;
            AV35GSubInaPag = 0.00m;
            AV32GIGVPag = 0.00m;
            AV39GTotPag = 0.00m;
            if ( StringUtil.StrCmp(AV46Orden, "R") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAREGISTRO' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV46Orden, "N") == 0 )
            {
               /* Execute user subroutine: 'ORDENANUMEROREGISTRO' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV46Orden, "F") == 0 )
            {
               /* Execute user subroutine: 'ORDENAFECHAEMISION' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            if ( StringUtil.StrCmp(AV46Orden, "P") == 0 )
            {
               /* Execute user subroutine: 'ORDENAPROVEEDOR' */
               S141 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            HAP0( false, 53) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+10, 613, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV53TIGV, "ZZZZZZ,ZZZ,ZZ9.99")), 601, Gx_line+10, 708, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64TTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 795, Gx_line+10, 902, Gx_line+25, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(478, Gx_line+4, 919, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 372, Gx_line+14, 452, Gx_line+28, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62TSubTotalI, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 810, Gx_line+25, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+53);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HAP0( true, 0) ;
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
         /* Using cursor P00AP3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAP4 = false;
            A1906TipCmp = P00AP3_A1906TipCmp[0];
            A306TipAbr = P00AP3_A306TipAbr[0];
            A707ComFReg = P00AP3_A707ComFReg[0];
            A708ComFVcto = P00AP3_A708ComFVcto[0];
            A246ComMon = P00AP3_A246ComMon[0];
            A149TipCod = P00AP3_A149TipCod[0];
            A1233MonAbr = P00AP3_A1233MonAbr[0];
            n1233MonAbr = P00AP3_n1233MonAbr[0];
            A243ComCod = P00AP3_A243ComCod[0];
            A248ComFec = P00AP3_A248ComFec[0];
            A244PrvCod = P00AP3_A244PrvCod[0];
            A247PrvDsc = P00AP3_A247PrvDsc[0];
            A249ComRef = P00AP3_A249ComRef[0];
            A704ComFecPago = P00AP3_A704ComFecPago[0];
            A724ComRefFec = P00AP3_A724ComRefFec[0];
            A511TipSigno = P00AP3_A511TipSigno[0];
            A729ComRete2 = P00AP3_A729ComRete2[0];
            A728ComRete1 = P00AP3_A728ComRete1[0];
            A732ComSubIna = P00AP3_A732ComSubIna[0];
            A719ComIVADUA = P00AP3_A719ComIVADUA[0];
            A718ComRedondeo = P00AP3_A718ComRedondeo[0];
            A717ComPorIva = P00AP3_A717ComPorIva[0];
            A698ComDscto = P00AP3_A698ComDscto[0];
            A713ComISC = P00AP3_A713ComISC[0];
            A706ComFlete = P00AP3_A706ComFlete[0];
            A716ComSubAfe = P00AP3_A716ComSubAfe[0];
            A1233MonAbr = P00AP3_A1233MonAbr[0];
            n1233MonAbr = P00AP3_n1233MonAbr[0];
            A1906TipCmp = P00AP3_A1906TipCmp[0];
            A306TipAbr = P00AP3_A306TipAbr[0];
            A511TipSigno = P00AP3_A511TipSigno[0];
            A732ComSubIna = P00AP3_A732ComSubIna[0];
            A716ComSubAfe = P00AP3_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV36GSubTotal = 0.00m;
            AV34GSubIna = 0.00m;
            AV30GDscto = 0.00m;
            AV31GIgv = 0.00m;
            AV37GTotalMN = 0.00m;
            AV38GTotalMO = 0.00m;
            AV56TipCod = A149TipCod;
            AV54TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AP3_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAP4 = false;
               A707ComFReg = P00AP3_A707ComFReg[0];
               A708ComFVcto = P00AP3_A708ComFVcto[0];
               A246ComMon = P00AP3_A246ComMon[0];
               A149TipCod = P00AP3_A149TipCod[0];
               A1233MonAbr = P00AP3_A1233MonAbr[0];
               n1233MonAbr = P00AP3_n1233MonAbr[0];
               A243ComCod = P00AP3_A243ComCod[0];
               A248ComFec = P00AP3_A248ComFec[0];
               A244PrvCod = P00AP3_A244PrvCod[0];
               A247PrvDsc = P00AP3_A247PrvDsc[0];
               A249ComRef = P00AP3_A249ComRef[0];
               A704ComFecPago = P00AP3_A704ComFecPago[0];
               A724ComRefFec = P00AP3_A724ComRefFec[0];
               A511TipSigno = P00AP3_A511TipSigno[0];
               A729ComRete2 = P00AP3_A729ComRete2[0];
               A728ComRete1 = P00AP3_A728ComRete1[0];
               A719ComIVADUA = P00AP3_A719ComIVADUA[0];
               A718ComRedondeo = P00AP3_A718ComRedondeo[0];
               A717ComPorIva = P00AP3_A717ComPorIva[0];
               A698ComDscto = P00AP3_A698ComDscto[0];
               A713ComISC = P00AP3_A713ComISC[0];
               A706ComFlete = P00AP3_A706ComFlete[0];
               A1233MonAbr = P00AP3_A1233MonAbr[0];
               n1233MonAbr = P00AP3_n1233MonAbr[0];
               A511TipSigno = P00AP3_A511TipSigno[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV54TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV41jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV42jMes )
                     {
                        /* Using cursor P00AP5 */
                        pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(1) != 101) )
                        {
                           A732ComSubIna = P00AP5_A732ComSubIna[0];
                           A716ComSubAfe = P00AP5_A716ComSubAfe[0];
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
                        AV45MonCod = A246ComMon;
                        AV56TipCod = A149TipCod;
                        AV44MonAbr = A1233MonAbr;
                        AV57TipVenta = 1.00000m;
                        AV55TipCmb = "";
                        AV17DocAbr = A306TipAbr;
                        AV21DocNum = A243ComCod;
                        AV20DocFec = A248ComFec;
                        AV47PrvCod = A244PrvCod;
                        AV48PrvDsc = A247PrvDsc;
                        GXt_char1 = AV23DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV47PrvCod, ref  AV56TipCod, ref  AV21DocNum, out  GXt_char1) ;
                        AV23DocSts = GXt_char1;
                        AV13ComRef = A249ComRef;
                        AV9ComFecPago = A704ComFecPago;
                        AV52SubTotal = 0.00m;
                        AV51SubIna = 0.00m;
                        AV24Dscto = 0.00m;
                        AV40Igv = 0.00m;
                        AV59TotalMN = 0.00m;
                        AV60TotalMO = 0.00m;
                        AV12ComPorIva = A717ComPorIva;
                        AV14ComRefFec = A724ComRefFec;
                        if ( AV45MonCod != 1 )
                        {
                           AV29Fecha = (((StringUtil.StrCmp(AV17DocAbr, "07")==0)||(StringUtil.StrCmp(AV17DocAbr, "08")==0))&&!(DateTime.MinValue==AV14ComRefFec) ? AV14ComRefFec : AV20DocFec);
                           if ( (DateTime.MinValue==AV9ComFecPago) )
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV29Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV9ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           AV55TipCmb = StringUtil.Trim( StringUtil.Str( AV57TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV23DocSts, "A") != 0 )
                        {
                           AV52SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV57TipVenta)*A511TipSigno);
                           AV51SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV57TipVenta)*A511TipSigno);
                           AV24Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV57TipVenta)*A511TipSigno);
                           AV15ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV57TipVenta)*A511TipSigno);
                           AV16ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV57TipVenta)*A511TipSigno);
                           AV10ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV52SubTotal) )
                           {
                              AV52SubTotal = (decimal)((AV52SubTotal+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           else
                           {
                              AV51SubIna = (decimal)((AV51SubIna+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           AV40Igv = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV57TipVenta)*A511TipSigno);
                           AV59TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV57TipVenta)*A511TipSigno);
                           AV60TotalMO = NumberUtil.Round( A736ComTotal, 2);
                           AV11ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV11ComIVADUA) )
                           {
                              AV52SubTotal = (decimal)(AV52SubTotal+NumberUtil.Round( (AV11ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV12ComPorIva) ? (decimal)(1) : AV12ComPorIva)))*100, 2));
                              AV60TotalMO = (decimal)(AV52SubTotal+AV51SubIna+AV40Igv);
                              AV59TotalMN = (decimal)(AV52SubTotal+AV51SubIna+AV40Igv);
                           }
                        }
                        AV36GSubTotal = (decimal)(AV36GSubTotal+AV52SubTotal);
                        AV34GSubIna = (decimal)(AV34GSubIna+AV51SubIna);
                        AV30GDscto = (decimal)(AV30GDscto+AV24Dscto);
                        AV31GIgv = (decimal)(AV31GIgv+AV40Igv);
                        AV37GTotalMN = (decimal)(AV37GTotalMN+AV59TotalMN);
                        AV38GTotalMO = (decimal)(AV38GTotalMO+AV60TotalMO);
                        HAP0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PrvDsc, "")), 293, Gx_line+1, 519, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PrvCod, "@!")), 194, Gx_line+1, 300, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocNum, "")), 104, Gx_line+1, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV20DocFec, "99/99/99"), 5, Gx_line+1, 70, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+1, 613, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+1, 707, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+1, 901, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TipCmb, "")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+1, 810, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocAbr, "")), 72, Gx_line+1, 104, Gx_line+15, 1, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ComRef, "")), 995, Gx_line+1, 1048, Gx_line+16, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 880, Gx_line+1, 987, Gx_line+16, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV33GSubAfePag = (decimal)(AV33GSubAfePag+AV52SubTotal);
                        AV35GSubInaPag = (decimal)(AV35GSubInaPag+AV51SubIna);
                        AV32GIGVPag = (decimal)(AV32GIGVPag+AV40Igv);
                        AV39GTotPag = (decimal)(AV39GTotPag+AV59TotalMN);
                     }
                  }
               }
               BRKAP4 = true;
               pr_default.readNext(0);
            }
            AV61TSubTotal = (decimal)(AV61TSubTotal+AV36GSubTotal);
            AV62TSubTotalI = (decimal)(AV62TSubTotalI+AV34GSubIna);
            AV63TTDscto = (decimal)(AV63TTDscto+AV30GDscto);
            AV53TIGV = (decimal)(AV53TIGV+AV31GIgv);
            AV64TTotalMN = (decimal)(AV64TTotalMN+AV37GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV38GTotalMO) )
            {
               AV58Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAP0( false, 57) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Totales, "")), 42, Gx_line+10, 507, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+11, 613, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+11, 707, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+11, 901, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(478, Gx_line+7, 918, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 810, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+57);
            }
            if ( ! BRKAP4 )
            {
               BRKAP4 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'ORDENANUMEROREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P00AP7 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAP6 = false;
            A1906TipCmp = P00AP7_A1906TipCmp[0];
            A306TipAbr = P00AP7_A306TipAbr[0];
            A707ComFReg = P00AP7_A707ComFReg[0];
            A708ComFVcto = P00AP7_A708ComFVcto[0];
            A246ComMon = P00AP7_A246ComMon[0];
            A149TipCod = P00AP7_A149TipCod[0];
            A1233MonAbr = P00AP7_A1233MonAbr[0];
            n1233MonAbr = P00AP7_n1233MonAbr[0];
            A243ComCod = P00AP7_A243ComCod[0];
            A248ComFec = P00AP7_A248ComFec[0];
            A244PrvCod = P00AP7_A244PrvCod[0];
            A247PrvDsc = P00AP7_A247PrvDsc[0];
            A704ComFecPago = P00AP7_A704ComFecPago[0];
            A724ComRefFec = P00AP7_A724ComRefFec[0];
            A511TipSigno = P00AP7_A511TipSigno[0];
            A249ComRef = P00AP7_A249ComRef[0];
            A729ComRete2 = P00AP7_A729ComRete2[0];
            A728ComRete1 = P00AP7_A728ComRete1[0];
            A732ComSubIna = P00AP7_A732ComSubIna[0];
            A719ComIVADUA = P00AP7_A719ComIVADUA[0];
            A718ComRedondeo = P00AP7_A718ComRedondeo[0];
            A717ComPorIva = P00AP7_A717ComPorIva[0];
            A698ComDscto = P00AP7_A698ComDscto[0];
            A713ComISC = P00AP7_A713ComISC[0];
            A706ComFlete = P00AP7_A706ComFlete[0];
            A716ComSubAfe = P00AP7_A716ComSubAfe[0];
            A1233MonAbr = P00AP7_A1233MonAbr[0];
            n1233MonAbr = P00AP7_n1233MonAbr[0];
            A1906TipCmp = P00AP7_A1906TipCmp[0];
            A306TipAbr = P00AP7_A306TipAbr[0];
            A511TipSigno = P00AP7_A511TipSigno[0];
            A732ComSubIna = P00AP7_A732ComSubIna[0];
            A716ComSubAfe = P00AP7_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV36GSubTotal = 0.00m;
            AV34GSubIna = 0.00m;
            AV30GDscto = 0.00m;
            AV31GIgv = 0.00m;
            AV37GTotalMN = 0.00m;
            AV38GTotalMO = 0.00m;
            AV56TipCod = A149TipCod;
            AV54TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AP7_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAP6 = false;
               A707ComFReg = P00AP7_A707ComFReg[0];
               A708ComFVcto = P00AP7_A708ComFVcto[0];
               A246ComMon = P00AP7_A246ComMon[0];
               A149TipCod = P00AP7_A149TipCod[0];
               A1233MonAbr = P00AP7_A1233MonAbr[0];
               n1233MonAbr = P00AP7_n1233MonAbr[0];
               A243ComCod = P00AP7_A243ComCod[0];
               A248ComFec = P00AP7_A248ComFec[0];
               A244PrvCod = P00AP7_A244PrvCod[0];
               A247PrvDsc = P00AP7_A247PrvDsc[0];
               A704ComFecPago = P00AP7_A704ComFecPago[0];
               A724ComRefFec = P00AP7_A724ComRefFec[0];
               A511TipSigno = P00AP7_A511TipSigno[0];
               A249ComRef = P00AP7_A249ComRef[0];
               A729ComRete2 = P00AP7_A729ComRete2[0];
               A728ComRete1 = P00AP7_A728ComRete1[0];
               A719ComIVADUA = P00AP7_A719ComIVADUA[0];
               A718ComRedondeo = P00AP7_A718ComRedondeo[0];
               A717ComPorIva = P00AP7_A717ComPorIva[0];
               A698ComDscto = P00AP7_A698ComDscto[0];
               A713ComISC = P00AP7_A713ComISC[0];
               A706ComFlete = P00AP7_A706ComFlete[0];
               A1233MonAbr = P00AP7_A1233MonAbr[0];
               n1233MonAbr = P00AP7_n1233MonAbr[0];
               A511TipSigno = P00AP7_A511TipSigno[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV54TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV41jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV42jMes )
                     {
                        /* Using cursor P00AP9 */
                        pr_default.execute(3, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(3) != 101) )
                        {
                           A732ComSubIna = P00AP9_A732ComSubIna[0];
                           A716ComSubAfe = P00AP9_A716ComSubAfe[0];
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
                        AV45MonCod = A246ComMon;
                        AV56TipCod = A149TipCod;
                        AV44MonAbr = A1233MonAbr;
                        AV57TipVenta = 1.00000m;
                        AV55TipCmb = "";
                        AV17DocAbr = A306TipAbr;
                        AV21DocNum = A243ComCod;
                        AV20DocFec = A248ComFec;
                        AV47PrvCod = A244PrvCod;
                        AV48PrvDsc = A247PrvDsc;
                        GXt_char1 = AV23DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV47PrvCod, ref  AV56TipCod, ref  AV21DocNum, out  GXt_char1) ;
                        AV23DocSts = GXt_char1;
                        AV13ComRef = A249ComRef;
                        AV9ComFecPago = A704ComFecPago;
                        AV52SubTotal = 0.00m;
                        AV51SubIna = 0.00m;
                        AV24Dscto = 0.00m;
                        AV40Igv = 0.00m;
                        AV59TotalMN = 0.00m;
                        AV60TotalMO = 0.00m;
                        AV12ComPorIva = A717ComPorIva;
                        AV14ComRefFec = A724ComRefFec;
                        if ( AV45MonCod != 1 )
                        {
                           AV29Fecha = (((StringUtil.StrCmp(AV17DocAbr, "07")==0)||(StringUtil.StrCmp(AV17DocAbr, "08")==0))&&!(DateTime.MinValue==AV14ComRefFec) ? AV14ComRefFec : AV20DocFec);
                           if ( (DateTime.MinValue==AV9ComFecPago) )
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV29Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV9ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           AV55TipCmb = StringUtil.Trim( StringUtil.Str( AV57TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV23DocSts, "A") != 0 )
                        {
                           AV52SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV57TipVenta)*A511TipSigno);
                           AV51SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV57TipVenta)*A511TipSigno);
                           AV24Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV57TipVenta)*A511TipSigno);
                           AV15ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV57TipVenta)*A511TipSigno);
                           AV16ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV57TipVenta)*A511TipSigno);
                           AV10ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV52SubTotal) )
                           {
                              AV52SubTotal = (decimal)((AV52SubTotal+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           else
                           {
                              AV51SubIna = (decimal)((AV51SubIna+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           AV40Igv = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV57TipVenta)*A511TipSigno);
                           AV59TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV57TipVenta)*A511TipSigno);
                           AV60TotalMO = NumberUtil.Round( A736ComTotal, 2);
                           AV11ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV11ComIVADUA) )
                           {
                              AV52SubTotal = (decimal)(AV52SubTotal+NumberUtil.Round( (AV11ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV12ComPorIva) ? (decimal)(1) : AV12ComPorIva)))*100, 2));
                              AV60TotalMO = (decimal)(AV52SubTotal+AV40Igv);
                              AV59TotalMN = (decimal)(AV52SubTotal+AV40Igv);
                           }
                        }
                        AV36GSubTotal = (decimal)(AV36GSubTotal+AV52SubTotal);
                        AV34GSubIna = (decimal)(AV34GSubIna+AV51SubIna);
                        AV30GDscto = (decimal)(AV30GDscto+AV24Dscto);
                        AV31GIgv = (decimal)(AV31GIgv+AV40Igv);
                        AV37GTotalMN = (decimal)(AV37GTotalMN+AV59TotalMN);
                        AV38GTotalMO = (decimal)(AV38GTotalMO+AV60TotalMO);
                        HAP0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PrvDsc, "")), 293, Gx_line+1, 519, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PrvCod, "@!")), 194, Gx_line+1, 300, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocNum, "")), 104, Gx_line+1, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV20DocFec, "99/99/99"), 5, Gx_line+1, 70, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+1, 613, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+1, 707, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+1, 901, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TipCmb, "")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+1, 810, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocAbr, "")), 72, Gx_line+1, 104, Gx_line+15, 1, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ComRef, "")), 995, Gx_line+1, 1048, Gx_line+16, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 880, Gx_line+1, 987, Gx_line+16, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV33GSubAfePag = (decimal)(AV33GSubAfePag+AV52SubTotal);
                        AV35GSubInaPag = (decimal)(AV35GSubInaPag+AV51SubIna);
                        AV32GIGVPag = (decimal)(AV32GIGVPag+AV40Igv);
                        AV39GTotPag = (decimal)(AV39GTotPag+AV59TotalMN);
                     }
                  }
               }
               BRKAP6 = true;
               pr_default.readNext(2);
            }
            AV61TSubTotal = (decimal)(AV61TSubTotal+AV36GSubTotal);
            AV62TSubTotalI = (decimal)(AV62TSubTotalI+AV34GSubIna);
            AV63TTDscto = (decimal)(AV63TTDscto+AV30GDscto);
            AV53TIGV = (decimal)(AV53TIGV+AV31GIgv);
            AV64TTotalMN = (decimal)(AV64TTotalMN+AV37GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV38GTotalMO) )
            {
               AV58Totales = "TOTAL TIPO DE DOCUMENTO " + StringUtil.Trim( A306TipAbr);
               HAP0( false, 57) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Totales, "")), 42, Gx_line+10, 507, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+11, 613, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+11, 707, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+11, 901, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(478, Gx_line+7, 918, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 810, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+57);
            }
            if ( ! BRKAP6 )
            {
               BRKAP6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'ORDENAFECHAEMISION' Routine */
         returnInSub = false;
         /* Using cursor P00AP11 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKAP8 = false;
            A1906TipCmp = P00AP11_A1906TipCmp[0];
            A306TipAbr = P00AP11_A306TipAbr[0];
            A707ComFReg = P00AP11_A707ComFReg[0];
            A708ComFVcto = P00AP11_A708ComFVcto[0];
            A246ComMon = P00AP11_A246ComMon[0];
            A149TipCod = P00AP11_A149TipCod[0];
            A1233MonAbr = P00AP11_A1233MonAbr[0];
            n1233MonAbr = P00AP11_n1233MonAbr[0];
            A243ComCod = P00AP11_A243ComCod[0];
            A244PrvCod = P00AP11_A244PrvCod[0];
            A247PrvDsc = P00AP11_A247PrvDsc[0];
            A249ComRef = P00AP11_A249ComRef[0];
            A704ComFecPago = P00AP11_A704ComFecPago[0];
            A724ComRefFec = P00AP11_A724ComRefFec[0];
            A511TipSigno = P00AP11_A511TipSigno[0];
            A248ComFec = P00AP11_A248ComFec[0];
            A729ComRete2 = P00AP11_A729ComRete2[0];
            A728ComRete1 = P00AP11_A728ComRete1[0];
            A732ComSubIna = P00AP11_A732ComSubIna[0];
            A719ComIVADUA = P00AP11_A719ComIVADUA[0];
            A718ComRedondeo = P00AP11_A718ComRedondeo[0];
            A717ComPorIva = P00AP11_A717ComPorIva[0];
            A698ComDscto = P00AP11_A698ComDscto[0];
            A713ComISC = P00AP11_A713ComISC[0];
            A706ComFlete = P00AP11_A706ComFlete[0];
            A716ComSubAfe = P00AP11_A716ComSubAfe[0];
            A1233MonAbr = P00AP11_A1233MonAbr[0];
            n1233MonAbr = P00AP11_n1233MonAbr[0];
            A1906TipCmp = P00AP11_A1906TipCmp[0];
            A306TipAbr = P00AP11_A306TipAbr[0];
            A511TipSigno = P00AP11_A511TipSigno[0];
            A732ComSubIna = P00AP11_A732ComSubIna[0];
            A716ComSubAfe = P00AP11_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV36GSubTotal = 0.00m;
            AV34GSubIna = 0.00m;
            AV30GDscto = 0.00m;
            AV31GIgv = 0.00m;
            AV37GTotalMN = 0.00m;
            AV38GTotalMO = 0.00m;
            AV56TipCod = A149TipCod;
            AV54TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00AP11_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAP8 = false;
               A707ComFReg = P00AP11_A707ComFReg[0];
               A708ComFVcto = P00AP11_A708ComFVcto[0];
               A246ComMon = P00AP11_A246ComMon[0];
               A149TipCod = P00AP11_A149TipCod[0];
               A1233MonAbr = P00AP11_A1233MonAbr[0];
               n1233MonAbr = P00AP11_n1233MonAbr[0];
               A243ComCod = P00AP11_A243ComCod[0];
               A244PrvCod = P00AP11_A244PrvCod[0];
               A247PrvDsc = P00AP11_A247PrvDsc[0];
               A249ComRef = P00AP11_A249ComRef[0];
               A704ComFecPago = P00AP11_A704ComFecPago[0];
               A724ComRefFec = P00AP11_A724ComRefFec[0];
               A511TipSigno = P00AP11_A511TipSigno[0];
               A248ComFec = P00AP11_A248ComFec[0];
               A729ComRete2 = P00AP11_A729ComRete2[0];
               A728ComRete1 = P00AP11_A728ComRete1[0];
               A719ComIVADUA = P00AP11_A719ComIVADUA[0];
               A718ComRedondeo = P00AP11_A718ComRedondeo[0];
               A717ComPorIva = P00AP11_A717ComPorIva[0];
               A698ComDscto = P00AP11_A698ComDscto[0];
               A713ComISC = P00AP11_A713ComISC[0];
               A706ComFlete = P00AP11_A706ComFlete[0];
               A1233MonAbr = P00AP11_A1233MonAbr[0];
               n1233MonAbr = P00AP11_n1233MonAbr[0];
               A511TipSigno = P00AP11_A511TipSigno[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV54TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV41jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV42jMes )
                     {
                        /* Using cursor P00AP13 */
                        pr_default.execute(5, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(5) != 101) )
                        {
                           A732ComSubIna = P00AP13_A732ComSubIna[0];
                           A716ComSubAfe = P00AP13_A716ComSubAfe[0];
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
                        AV45MonCod = A246ComMon;
                        AV56TipCod = A149TipCod;
                        AV44MonAbr = A1233MonAbr;
                        AV57TipVenta = 1.00000m;
                        AV55TipCmb = "";
                        AV17DocAbr = A306TipAbr;
                        AV21DocNum = A243ComCod;
                        AV20DocFec = A248ComFec;
                        AV47PrvCod = A244PrvCod;
                        AV48PrvDsc = A247PrvDsc;
                        GXt_char1 = AV23DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV47PrvCod, ref  AV56TipCod, ref  AV21DocNum, out  GXt_char1) ;
                        AV23DocSts = GXt_char1;
                        AV13ComRef = A249ComRef;
                        AV9ComFecPago = A704ComFecPago;
                        AV52SubTotal = 0.00m;
                        AV51SubIna = 0.00m;
                        AV24Dscto = 0.00m;
                        AV40Igv = 0.00m;
                        AV59TotalMN = 0.00m;
                        AV60TotalMO = 0.00m;
                        AV12ComPorIva = A717ComPorIva;
                        AV14ComRefFec = A724ComRefFec;
                        if ( AV45MonCod != 1 )
                        {
                           AV29Fecha = (((StringUtil.StrCmp(AV17DocAbr, "07")==0)||(StringUtil.StrCmp(AV17DocAbr, "08")==0))&&!(DateTime.MinValue==AV14ComRefFec) ? AV14ComRefFec : AV20DocFec);
                           if ( (DateTime.MinValue==AV9ComFecPago) )
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV29Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV9ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           AV55TipCmb = StringUtil.Trim( StringUtil.Str( AV57TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV23DocSts, "A") != 0 )
                        {
                           AV52SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV57TipVenta)*A511TipSigno);
                           AV51SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV57TipVenta)*A511TipSigno);
                           AV24Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV57TipVenta)*A511TipSigno);
                           AV15ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV57TipVenta)*A511TipSigno);
                           AV16ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV57TipVenta)*A511TipSigno);
                           AV10ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV52SubTotal) )
                           {
                              AV52SubTotal = (decimal)((AV52SubTotal+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           else
                           {
                              AV51SubIna = (decimal)((AV51SubIna+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           AV40Igv = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV57TipVenta)*A511TipSigno);
                           AV59TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV57TipVenta)*A511TipSigno);
                           AV60TotalMO = NumberUtil.Round( A736ComTotal, 2);
                           AV11ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV11ComIVADUA) )
                           {
                              AV52SubTotal = (decimal)(AV52SubTotal+NumberUtil.Round( (AV11ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV12ComPorIva) ? (decimal)(1) : AV12ComPorIva)))*100, 2));
                              AV60TotalMO = (decimal)(AV52SubTotal+AV40Igv);
                              AV59TotalMN = (decimal)(AV52SubTotal+AV40Igv);
                           }
                        }
                        AV36GSubTotal = (decimal)(AV36GSubTotal+AV52SubTotal);
                        AV34GSubIna = (decimal)(AV34GSubIna+AV51SubIna);
                        AV30GDscto = (decimal)(AV30GDscto+AV24Dscto);
                        AV31GIgv = (decimal)(AV31GIgv+AV40Igv);
                        AV37GTotalMN = (decimal)(AV37GTotalMN+AV59TotalMN);
                        AV38GTotalMO = (decimal)(AV38GTotalMO+AV60TotalMO);
                        HAP0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PrvDsc, "")), 293, Gx_line+1, 519, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PrvCod, "@!")), 194, Gx_line+1, 300, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocNum, "")), 104, Gx_line+1, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV20DocFec, "99/99/99"), 5, Gx_line+1, 70, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+1, 613, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+1, 707, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+1, 901, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TipCmb, "")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+1, 810, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocAbr, "")), 72, Gx_line+1, 104, Gx_line+15, 1, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ComRef, "")), 995, Gx_line+1, 1048, Gx_line+16, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 880, Gx_line+1, 987, Gx_line+16, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV33GSubAfePag = (decimal)(AV33GSubAfePag+AV52SubTotal);
                        AV35GSubInaPag = (decimal)(AV35GSubInaPag+AV51SubIna);
                        AV32GIGVPag = (decimal)(AV32GIGVPag+AV40Igv);
                        AV39GTotPag = (decimal)(AV39GTotPag+AV59TotalMN);
                     }
                  }
               }
               BRKAP8 = true;
               pr_default.readNext(4);
            }
            AV61TSubTotal = (decimal)(AV61TSubTotal+AV36GSubTotal);
            AV62TSubTotalI = (decimal)(AV62TSubTotalI+AV34GSubIna);
            AV63TTDscto = (decimal)(AV63TTDscto+AV30GDscto);
            AV53TIGV = (decimal)(AV53TIGV+AV31GIgv);
            AV64TTotalMN = (decimal)(AV64TTotalMN+AV37GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV38GTotalMO) )
            {
               HAP0( false, 57) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Totales, "")), 42, Gx_line+10, 507, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+11, 613, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+11, 707, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+11, 901, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(478, Gx_line+7, 918, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 810, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+57);
            }
            if ( ! BRKAP8 )
            {
               BRKAP8 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S141( )
      {
         /* 'ORDENAPROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P00AP15 */
         pr_default.execute(6);
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKAP10 = false;
            A1906TipCmp = P00AP15_A1906TipCmp[0];
            A306TipAbr = P00AP15_A306TipAbr[0];
            A707ComFReg = P00AP15_A707ComFReg[0];
            A708ComFVcto = P00AP15_A708ComFVcto[0];
            A246ComMon = P00AP15_A246ComMon[0];
            A149TipCod = P00AP15_A149TipCod[0];
            A1233MonAbr = P00AP15_A1233MonAbr[0];
            n1233MonAbr = P00AP15_n1233MonAbr[0];
            A243ComCod = P00AP15_A243ComCod[0];
            A248ComFec = P00AP15_A248ComFec[0];
            A247PrvDsc = P00AP15_A247PrvDsc[0];
            A249ComRef = P00AP15_A249ComRef[0];
            A704ComFecPago = P00AP15_A704ComFecPago[0];
            A724ComRefFec = P00AP15_A724ComRefFec[0];
            A511TipSigno = P00AP15_A511TipSigno[0];
            A244PrvCod = P00AP15_A244PrvCod[0];
            A729ComRete2 = P00AP15_A729ComRete2[0];
            A728ComRete1 = P00AP15_A728ComRete1[0];
            A732ComSubIna = P00AP15_A732ComSubIna[0];
            A719ComIVADUA = P00AP15_A719ComIVADUA[0];
            A718ComRedondeo = P00AP15_A718ComRedondeo[0];
            A717ComPorIva = P00AP15_A717ComPorIva[0];
            A698ComDscto = P00AP15_A698ComDscto[0];
            A713ComISC = P00AP15_A713ComISC[0];
            A706ComFlete = P00AP15_A706ComFlete[0];
            A716ComSubAfe = P00AP15_A716ComSubAfe[0];
            A1233MonAbr = P00AP15_A1233MonAbr[0];
            n1233MonAbr = P00AP15_n1233MonAbr[0];
            A1906TipCmp = P00AP15_A1906TipCmp[0];
            A306TipAbr = P00AP15_A306TipAbr[0];
            A511TipSigno = P00AP15_A511TipSigno[0];
            A732ComSubIna = P00AP15_A732ComSubIna[0];
            A716ComSubAfe = P00AP15_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV36GSubTotal = 0.00m;
            AV34GSubIna = 0.00m;
            AV30GDscto = 0.00m;
            AV31GIgv = 0.00m;
            AV37GTotalMN = 0.00m;
            AV38GTotalMO = 0.00m;
            AV56TipCod = A149TipCod;
            AV54TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00AP15_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRKAP10 = false;
               A707ComFReg = P00AP15_A707ComFReg[0];
               A708ComFVcto = P00AP15_A708ComFVcto[0];
               A246ComMon = P00AP15_A246ComMon[0];
               A149TipCod = P00AP15_A149TipCod[0];
               A1233MonAbr = P00AP15_A1233MonAbr[0];
               n1233MonAbr = P00AP15_n1233MonAbr[0];
               A243ComCod = P00AP15_A243ComCod[0];
               A248ComFec = P00AP15_A248ComFec[0];
               A247PrvDsc = P00AP15_A247PrvDsc[0];
               A249ComRef = P00AP15_A249ComRef[0];
               A704ComFecPago = P00AP15_A704ComFecPago[0];
               A724ComRefFec = P00AP15_A724ComRefFec[0];
               A511TipSigno = P00AP15_A511TipSigno[0];
               A244PrvCod = P00AP15_A244PrvCod[0];
               A729ComRete2 = P00AP15_A729ComRete2[0];
               A728ComRete1 = P00AP15_A728ComRete1[0];
               A719ComIVADUA = P00AP15_A719ComIVADUA[0];
               A718ComRedondeo = P00AP15_A718ComRedondeo[0];
               A717ComPorIva = P00AP15_A717ComPorIva[0];
               A698ComDscto = P00AP15_A698ComDscto[0];
               A713ComISC = P00AP15_A713ComISC[0];
               A706ComFlete = P00AP15_A706ComFlete[0];
               A1233MonAbr = P00AP15_A1233MonAbr[0];
               n1233MonAbr = P00AP15_n1233MonAbr[0];
               A511TipSigno = P00AP15_A511TipSigno[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV54TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV41jAno )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV42jMes )
                     {
                        /* Using cursor P00AP17 */
                        pr_default.execute(7, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(7) != 101) )
                        {
                           A732ComSubIna = P00AP17_A732ComSubIna[0];
                           A716ComSubAfe = P00AP17_A716ComSubAfe[0];
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
                        AV45MonCod = A246ComMon;
                        AV56TipCod = A149TipCod;
                        AV44MonAbr = A1233MonAbr;
                        AV57TipVenta = 1.00000m;
                        AV55TipCmb = "";
                        AV17DocAbr = A306TipAbr;
                        AV21DocNum = A243ComCod;
                        AV20DocFec = A248ComFec;
                        AV47PrvCod = A244PrvCod;
                        AV48PrvDsc = A247PrvDsc;
                        GXt_char1 = AV23DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV47PrvCod, ref  AV56TipCod, ref  AV21DocNum, out  GXt_char1) ;
                        AV23DocSts = GXt_char1;
                        AV13ComRef = A249ComRef;
                        AV9ComFecPago = A704ComFecPago;
                        AV52SubTotal = 0.00m;
                        AV51SubIna = 0.00m;
                        AV24Dscto = 0.00m;
                        AV40Igv = 0.00m;
                        AV59TotalMN = 0.00m;
                        AV60TotalMO = 0.00m;
                        AV12ComPorIva = A717ComPorIva;
                        AV14ComRefFec = A724ComRefFec;
                        if ( AV45MonCod != 1 )
                        {
                           AV29Fecha = (((StringUtil.StrCmp(AV17DocAbr, "07")==0)||(StringUtil.StrCmp(AV17DocAbr, "08")==0))&&!(DateTime.MinValue==AV14ComRefFec) ? AV14ComRefFec : AV20DocFec);
                           if ( (DateTime.MinValue==AV9ComFecPago) )
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV29Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           else
                           {
                              GXt_decimal2 = AV57TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV45MonCod, ref  AV9ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                              AV57TipVenta = GXt_decimal2;
                           }
                           AV55TipCmb = StringUtil.Trim( StringUtil.Str( AV57TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV23DocSts, "A") != 0 )
                        {
                           AV52SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV57TipVenta)*A511TipSigno);
                           AV51SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV57TipVenta)*A511TipSigno);
                           AV24Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV57TipVenta)*A511TipSigno);
                           AV15ComRet1 = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV57TipVenta)*A511TipSigno);
                           AV16ComRet2 = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV57TipVenta)*A511TipSigno);
                           AV10ComFlete = (decimal)((NumberUtil.Round( A706ComFlete, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV52SubTotal) )
                           {
                              AV52SubTotal = (decimal)((AV52SubTotal+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           else
                           {
                              AV51SubIna = (decimal)((AV51SubIna+AV10ComFlete)-(AV24Dscto+AV15ComRet1+AV16ComRet2));
                           }
                           AV40Igv = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV57TipVenta)*A511TipSigno);
                           AV59TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV57TipVenta)*A511TipSigno);
                           AV60TotalMO = NumberUtil.Round( A736ComTotal, 2);
                           AV11ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV57TipVenta)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV11ComIVADUA) )
                           {
                              AV52SubTotal = (decimal)(AV52SubTotal+NumberUtil.Round( (AV11ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV12ComPorIva) ? (decimal)(1) : AV12ComPorIva)))*100, 2));
                              AV60TotalMO = (decimal)(AV52SubTotal+AV40Igv);
                              AV59TotalMN = (decimal)(AV52SubTotal+AV40Igv);
                           }
                        }
                        AV36GSubTotal = (decimal)(AV36GSubTotal+AV52SubTotal);
                        AV34GSubIna = (decimal)(AV34GSubIna+AV51SubIna);
                        AV30GDscto = (decimal)(AV30GDscto+AV24Dscto);
                        AV31GIgv = (decimal)(AV31GIgv+AV40Igv);
                        AV37GTotalMN = (decimal)(AV37GTotalMN+AV59TotalMN);
                        AV38GTotalMO = (decimal)(AV38GTotalMO+AV60TotalMO);
                        HAP0( false, 19) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PrvDsc, "")), 293, Gx_line+1, 519, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47PrvCod, "@!")), 194, Gx_line+1, 300, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocNum, "")), 104, Gx_line+1, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV20DocFec, "99/99/99"), 5, Gx_line+1, 70, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52SubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+1, 613, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV40Igv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+1, 707, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59TotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+1, 901, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TipCmb, "")), 1041, Gx_line+1, 1138, Gx_line+15, 2, 0, 0, 0) ;
                        getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51SubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+1, 810, Gx_line+16, 2+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocAbr, "")), 72, Gx_line+1, 104, Gx_line+15, 1, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13ComRef, "")), 995, Gx_line+1, 1048, Gx_line+16, 0+256, 0, 0, 0) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TotalMO, "ZZZZZZ,ZZZ,ZZ9.99")), 880, Gx_line+1, 987, Gx_line+16, 2+256, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                        AV33GSubAfePag = (decimal)(AV33GSubAfePag+AV52SubTotal);
                        AV35GSubInaPag = (decimal)(AV35GSubInaPag+AV51SubIna);
                        AV32GIGVPag = (decimal)(AV32GIGVPag+AV40Igv);
                        AV39GTotPag = (decimal)(AV39GTotPag+AV59TotalMN);
                     }
                  }
               }
               BRKAP10 = true;
               pr_default.readNext(6);
            }
            AV61TSubTotal = (decimal)(AV61TSubTotal+AV36GSubTotal);
            AV62TSubTotalI = (decimal)(AV62TSubTotalI+AV34GSubIna);
            AV63TTDscto = (decimal)(AV63TTDscto+AV30GDscto);
            AV53TIGV = (decimal)(AV53TIGV+AV31GIgv);
            AV64TTotalMN = (decimal)(AV64TTotalMN+AV37GTotalMN);
            if ( ! (Convert.ToDecimal(0)==AV38GTotalMO) )
            {
               HAP0( false, 57) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Totales, "")), 42, Gx_line+10, 507, Gx_line+24, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV36GSubTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 516, Gx_line+11, 613, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV31GIgv, "ZZZZZZ,ZZZ,ZZ9.99")), 610, Gx_line+11, 707, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV37GTotalMN, "ZZZZZZ,ZZZ,ZZ9.99")), 804, Gx_line+11, 901, Gx_line+25, 2, 0, 0, 0) ;
               getPrinter().GxDrawLine(478, Gx_line+7, 918, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV34GSubIna, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 810, Gx_line+25, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+57);
            }
            if ( ! BRKAP10 )
            {
               BRKAP10 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void HAP0( bool bFoot ,
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
                  getPrinter().GxDrawText("Total Pagina : ", 321, Gx_line+27, 404, Gx_line+41, 0+256, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV33GSubAfePag, "ZZZZZZ,ZZZ,ZZ9.99")), 506, Gx_line+27, 613, Gx_line+42, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32GIGVPag, "ZZZZZZ,ZZZ,ZZ9.99")), 601, Gx_line+27, 708, Gx_line+42, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV35GSubInaPag, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+27, 810, Gx_line+42, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV39GTotPag, "ZZZZZZ,ZZZ,ZZ9.99")), 795, Gx_line+27, 902, Gx_line+42, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 424, Gx_line+27, 463, Gx_line+42, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+60);
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
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41jAno), "ZZZ9")), 444, Gx_line+93, 483, Gx_line+114, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV8cMes, "")), 621, Gx_line+93, 731, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27EmpRUC, "")), 8, Gx_line+100, 377, Gx_line+118, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Empresa, "")), 8, Gx_line+82, 376, Gx_line+100, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV43Logo)) ? AV67Logo_GXI : AV43Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 8, Gx_line+10, 177, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+28, 1075, Gx_line+43, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Página:", 986, Gx_line+28, 1030, Gx_line+42, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+130);
               getPrinter().GxDrawRect(0, Gx_line+0, 1139, Gx_line+45, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(70, Gx_line+0, 70, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 15, Gx_line+6, 50, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(103, Gx_line+0, 103, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(290, Gx_line+0, 290, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Nombre o", 379, Gx_line+6, 436, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Base", 553, Gx_line+6, 582, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(616, Gx_line+0, 616, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("I.G.V.", 649, Gx_line+15, 680, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(811, Gx_line+0, 811, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MN", 835, Gx_line+15, 887, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(902, Gx_line+0, 902, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1063, Gx_line+0, 1063, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("T.Cambio", 1068, Gx_line+15, 1123, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(519, Gx_line+0, 519, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(710, Gx_line+0, 710, Gx_line+45, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Emisión", 8, Gx_line+21, 54, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 74, Gx_line+15, 97, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(196, Gx_line+0, 196, Gx_line+44, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Comprobante", 108, Gx_line+2, 189, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("de", 142, Gx_line+16, 158, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("pago", 134, Gx_line+27, 164, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("R.U.C.", 224, Gx_line+14, 258, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Razon Social", 370, Gx_line+21, 445, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Imponible", 535, Gx_line+21, 595, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("no Gravadas", 725, Gx_line+21, 800, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Adquisiones", 727, Gx_line+6, 799, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 998, Gx_line+6, 1045, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Registro", 997, Gx_line+21, 1048, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total MO", 920, Gx_line+15, 973, Gx_line+29, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(986, Gx_line+0, 986, Gx_line+45, 1, 0, 0, 0, 0) ;
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
         AV26Empresa = "";
         AV50Session = context.GetSession();
         AV25EmpDir = "";
         AV27EmpRUC = "";
         AV49Ruta = "";
         AV43Logo = "";
         AV67Logo_GXI = "";
         AV8cMes = "";
         AV17DocAbr = "";
         AV21DocNum = "";
         AV20DocFec = DateTime.MinValue;
         AV9ComFecPago = DateTime.MinValue;
         AV47PrvCod = "";
         AV48PrvDsc = "";
         AV55TipCmb = "";
         scmdbuf = "";
         P00AP3_A1906TipCmp = new short[1] ;
         P00AP3_A306TipAbr = new string[] {""} ;
         P00AP3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AP3_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AP3_A246ComMon = new int[1] ;
         P00AP3_A149TipCod = new string[] {""} ;
         P00AP3_A1233MonAbr = new string[] {""} ;
         P00AP3_n1233MonAbr = new bool[] {false} ;
         P00AP3_A243ComCod = new string[] {""} ;
         P00AP3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AP3_A244PrvCod = new string[] {""} ;
         P00AP3_A247PrvDsc = new string[] {""} ;
         P00AP3_A249ComRef = new string[] {""} ;
         P00AP3_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AP3_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AP3_A511TipSigno = new short[1] ;
         P00AP3_A729ComRete2 = new decimal[1] ;
         P00AP3_A728ComRete1 = new decimal[1] ;
         P00AP3_A732ComSubIna = new decimal[1] ;
         P00AP3_A719ComIVADUA = new decimal[1] ;
         P00AP3_A718ComRedondeo = new decimal[1] ;
         P00AP3_A717ComPorIva = new decimal[1] ;
         P00AP3_A698ComDscto = new decimal[1] ;
         P00AP3_A713ComISC = new decimal[1] ;
         P00AP3_A706ComFlete = new decimal[1] ;
         P00AP3_A716ComSubAfe = new decimal[1] ;
         A306TipAbr = "";
         A707ComFReg = DateTime.MinValue;
         A708ComFVcto = DateTime.MinValue;
         A149TipCod = "";
         A1233MonAbr = "";
         A243ComCod = "";
         A248ComFec = DateTime.MinValue;
         A244PrvCod = "";
         A247PrvDsc = "";
         A249ComRef = "";
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         AV56TipCod = "";
         AV54TipAbr = "";
         P00AP5_A732ComSubIna = new decimal[1] ;
         P00AP5_A716ComSubAfe = new decimal[1] ;
         AV44MonAbr = "";
         AV23DocSts = "";
         AV13ComRef = "";
         AV14ComRefFec = DateTime.MinValue;
         AV29Fecha = DateTime.MinValue;
         AV58Totales = "";
         P00AP7_A1906TipCmp = new short[1] ;
         P00AP7_A306TipAbr = new string[] {""} ;
         P00AP7_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AP7_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AP7_A246ComMon = new int[1] ;
         P00AP7_A149TipCod = new string[] {""} ;
         P00AP7_A1233MonAbr = new string[] {""} ;
         P00AP7_n1233MonAbr = new bool[] {false} ;
         P00AP7_A243ComCod = new string[] {""} ;
         P00AP7_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AP7_A244PrvCod = new string[] {""} ;
         P00AP7_A247PrvDsc = new string[] {""} ;
         P00AP7_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AP7_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AP7_A511TipSigno = new short[1] ;
         P00AP7_A249ComRef = new string[] {""} ;
         P00AP7_A729ComRete2 = new decimal[1] ;
         P00AP7_A728ComRete1 = new decimal[1] ;
         P00AP7_A732ComSubIna = new decimal[1] ;
         P00AP7_A719ComIVADUA = new decimal[1] ;
         P00AP7_A718ComRedondeo = new decimal[1] ;
         P00AP7_A717ComPorIva = new decimal[1] ;
         P00AP7_A698ComDscto = new decimal[1] ;
         P00AP7_A713ComISC = new decimal[1] ;
         P00AP7_A706ComFlete = new decimal[1] ;
         P00AP7_A716ComSubAfe = new decimal[1] ;
         P00AP9_A732ComSubIna = new decimal[1] ;
         P00AP9_A716ComSubAfe = new decimal[1] ;
         P00AP11_A1906TipCmp = new short[1] ;
         P00AP11_A306TipAbr = new string[] {""} ;
         P00AP11_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AP11_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AP11_A246ComMon = new int[1] ;
         P00AP11_A149TipCod = new string[] {""} ;
         P00AP11_A1233MonAbr = new string[] {""} ;
         P00AP11_n1233MonAbr = new bool[] {false} ;
         P00AP11_A243ComCod = new string[] {""} ;
         P00AP11_A244PrvCod = new string[] {""} ;
         P00AP11_A247PrvDsc = new string[] {""} ;
         P00AP11_A249ComRef = new string[] {""} ;
         P00AP11_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AP11_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AP11_A511TipSigno = new short[1] ;
         P00AP11_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AP11_A729ComRete2 = new decimal[1] ;
         P00AP11_A728ComRete1 = new decimal[1] ;
         P00AP11_A732ComSubIna = new decimal[1] ;
         P00AP11_A719ComIVADUA = new decimal[1] ;
         P00AP11_A718ComRedondeo = new decimal[1] ;
         P00AP11_A717ComPorIva = new decimal[1] ;
         P00AP11_A698ComDscto = new decimal[1] ;
         P00AP11_A713ComISC = new decimal[1] ;
         P00AP11_A706ComFlete = new decimal[1] ;
         P00AP11_A716ComSubAfe = new decimal[1] ;
         P00AP13_A732ComSubIna = new decimal[1] ;
         P00AP13_A716ComSubAfe = new decimal[1] ;
         P00AP15_A1906TipCmp = new short[1] ;
         P00AP15_A306TipAbr = new string[] {""} ;
         P00AP15_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AP15_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P00AP15_A246ComMon = new int[1] ;
         P00AP15_A149TipCod = new string[] {""} ;
         P00AP15_A1233MonAbr = new string[] {""} ;
         P00AP15_n1233MonAbr = new bool[] {false} ;
         P00AP15_A243ComCod = new string[] {""} ;
         P00AP15_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AP15_A247PrvDsc = new string[] {""} ;
         P00AP15_A249ComRef = new string[] {""} ;
         P00AP15_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00AP15_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00AP15_A511TipSigno = new short[1] ;
         P00AP15_A244PrvCod = new string[] {""} ;
         P00AP15_A729ComRete2 = new decimal[1] ;
         P00AP15_A728ComRete1 = new decimal[1] ;
         P00AP15_A732ComSubIna = new decimal[1] ;
         P00AP15_A719ComIVADUA = new decimal[1] ;
         P00AP15_A718ComRedondeo = new decimal[1] ;
         P00AP15_A717ComPorIva = new decimal[1] ;
         P00AP15_A698ComDscto = new decimal[1] ;
         P00AP15_A713ComISC = new decimal[1] ;
         P00AP15_A706ComFlete = new decimal[1] ;
         P00AP15_A716ComSubAfe = new decimal[1] ;
         P00AP17_A732ComSubIna = new decimal[1] ;
         P00AP17_A716ComSubAfe = new decimal[1] ;
         GXt_char1 = "";
         AV43Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_registrocompraspdf__default(),
            new Object[][] {
                new Object[] {
               P00AP3_A1906TipCmp, P00AP3_A306TipAbr, P00AP3_A707ComFReg, P00AP3_A708ComFVcto, P00AP3_A246ComMon, P00AP3_A149TipCod, P00AP3_A1233MonAbr, P00AP3_n1233MonAbr, P00AP3_A243ComCod, P00AP3_A248ComFec,
               P00AP3_A244PrvCod, P00AP3_A247PrvDsc, P00AP3_A249ComRef, P00AP3_A704ComFecPago, P00AP3_A724ComRefFec, P00AP3_A511TipSigno, P00AP3_A729ComRete2, P00AP3_A728ComRete1, P00AP3_A732ComSubIna, P00AP3_A719ComIVADUA,
               P00AP3_A718ComRedondeo, P00AP3_A717ComPorIva, P00AP3_A698ComDscto, P00AP3_A713ComISC, P00AP3_A706ComFlete, P00AP3_A716ComSubAfe
               }
               , new Object[] {
               P00AP5_A732ComSubIna, P00AP5_A716ComSubAfe
               }
               , new Object[] {
               P00AP7_A1906TipCmp, P00AP7_A306TipAbr, P00AP7_A707ComFReg, P00AP7_A708ComFVcto, P00AP7_A246ComMon, P00AP7_A149TipCod, P00AP7_A1233MonAbr, P00AP7_n1233MonAbr, P00AP7_A243ComCod, P00AP7_A248ComFec,
               P00AP7_A244PrvCod, P00AP7_A247PrvDsc, P00AP7_A704ComFecPago, P00AP7_A724ComRefFec, P00AP7_A511TipSigno, P00AP7_A249ComRef, P00AP7_A729ComRete2, P00AP7_A728ComRete1, P00AP7_A732ComSubIna, P00AP7_A719ComIVADUA,
               P00AP7_A718ComRedondeo, P00AP7_A717ComPorIva, P00AP7_A698ComDscto, P00AP7_A713ComISC, P00AP7_A706ComFlete, P00AP7_A716ComSubAfe
               }
               , new Object[] {
               P00AP9_A732ComSubIna, P00AP9_A716ComSubAfe
               }
               , new Object[] {
               P00AP11_A1906TipCmp, P00AP11_A306TipAbr, P00AP11_A707ComFReg, P00AP11_A708ComFVcto, P00AP11_A246ComMon, P00AP11_A149TipCod, P00AP11_A1233MonAbr, P00AP11_n1233MonAbr, P00AP11_A243ComCod, P00AP11_A244PrvCod,
               P00AP11_A247PrvDsc, P00AP11_A249ComRef, P00AP11_A704ComFecPago, P00AP11_A724ComRefFec, P00AP11_A511TipSigno, P00AP11_A248ComFec, P00AP11_A729ComRete2, P00AP11_A728ComRete1, P00AP11_A732ComSubIna, P00AP11_A719ComIVADUA,
               P00AP11_A718ComRedondeo, P00AP11_A717ComPorIva, P00AP11_A698ComDscto, P00AP11_A713ComISC, P00AP11_A706ComFlete, P00AP11_A716ComSubAfe
               }
               , new Object[] {
               P00AP13_A732ComSubIna, P00AP13_A716ComSubAfe
               }
               , new Object[] {
               P00AP15_A1906TipCmp, P00AP15_A306TipAbr, P00AP15_A707ComFReg, P00AP15_A708ComFVcto, P00AP15_A246ComMon, P00AP15_A149TipCod, P00AP15_A1233MonAbr, P00AP15_n1233MonAbr, P00AP15_A243ComCod, P00AP15_A248ComFec,
               P00AP15_A247PrvDsc, P00AP15_A249ComRef, P00AP15_A704ComFecPago, P00AP15_A724ComRefFec, P00AP15_A511TipSigno, P00AP15_A244PrvCod, P00AP15_A729ComRete2, P00AP15_A728ComRete1, P00AP15_A732ComSubIna, P00AP15_A719ComIVADUA,
               P00AP15_A718ComRedondeo, P00AP15_A717ComPorIva, P00AP15_A698ComDscto, P00AP15_A713ComISC, P00AP15_A706ComFlete, P00AP15_A716ComSubAfe
               }
               , new Object[] {
               P00AP17_A732ComSubIna, P00AP17_A716ComSubAfe
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV41jAno ;
      private short AV42jMes ;
      private short A1906TipCmp ;
      private short A511TipSigno ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV45MonCod ;
      private decimal AV52SubTotal ;
      private decimal AV24Dscto ;
      private decimal AV40Igv ;
      private decimal AV59TotalMN ;
      private decimal AV60TotalMO ;
      private decimal AV61TSubTotal ;
      private decimal AV62TSubTotalI ;
      private decimal AV63TTDscto ;
      private decimal AV53TIGV ;
      private decimal AV64TTotalMN ;
      private decimal AV33GSubAfePag ;
      private decimal AV35GSubInaPag ;
      private decimal AV32GIGVPag ;
      private decimal AV39GTotPag ;
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
      private decimal AV36GSubTotal ;
      private decimal AV34GSubIna ;
      private decimal AV30GDscto ;
      private decimal AV31GIgv ;
      private decimal AV37GTotalMN ;
      private decimal AV38GTotalMO ;
      private decimal AV57TipVenta ;
      private decimal AV51SubIna ;
      private decimal AV12ComPorIva ;
      private decimal AV15ComRet1 ;
      private decimal AV16ComRet2 ;
      private decimal AV10ComFlete ;
      private decimal AV11ComIVADUA ;
      private decimal GXt_decimal2 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV46Orden ;
      private string AV26Empresa ;
      private string AV25EmpDir ;
      private string AV27EmpRUC ;
      private string AV49Ruta ;
      private string AV8cMes ;
      private string AV17DocAbr ;
      private string AV21DocNum ;
      private string AV47PrvCod ;
      private string AV48PrvDsc ;
      private string AV55TipCmb ;
      private string scmdbuf ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A243ComCod ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A249ComRef ;
      private string AV56TipCod ;
      private string AV54TipAbr ;
      private string AV44MonAbr ;
      private string AV23DocSts ;
      private string AV13ComRef ;
      private string AV58Totales ;
      private string GXt_char1 ;
      private string sImgUrl ;
      private DateTime AV20DocFec ;
      private DateTime AV9ComFecPago ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime AV14ComRefFec ;
      private DateTime AV29Fecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRKAP4 ;
      private bool n1233MonAbr ;
      private bool BRKAP6 ;
      private bool BRKAP8 ;
      private bool BRKAP10 ;
      private string AV67Logo_GXI ;
      private string AV43Logo ;
      private string Logo ;
      private IGxSession AV50Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_jAno ;
      private short aP1_jMes ;
      private string aP2_Orden ;
      private IDataStoreProvider pr_default ;
      private short[] P00AP3_A1906TipCmp ;
      private string[] P00AP3_A306TipAbr ;
      private DateTime[] P00AP3_A707ComFReg ;
      private DateTime[] P00AP3_A708ComFVcto ;
      private int[] P00AP3_A246ComMon ;
      private string[] P00AP3_A149TipCod ;
      private string[] P00AP3_A1233MonAbr ;
      private bool[] P00AP3_n1233MonAbr ;
      private string[] P00AP3_A243ComCod ;
      private DateTime[] P00AP3_A248ComFec ;
      private string[] P00AP3_A244PrvCod ;
      private string[] P00AP3_A247PrvDsc ;
      private string[] P00AP3_A249ComRef ;
      private DateTime[] P00AP3_A704ComFecPago ;
      private DateTime[] P00AP3_A724ComRefFec ;
      private short[] P00AP3_A511TipSigno ;
      private decimal[] P00AP3_A729ComRete2 ;
      private decimal[] P00AP3_A728ComRete1 ;
      private decimal[] P00AP3_A732ComSubIna ;
      private decimal[] P00AP3_A719ComIVADUA ;
      private decimal[] P00AP3_A718ComRedondeo ;
      private decimal[] P00AP3_A717ComPorIva ;
      private decimal[] P00AP3_A698ComDscto ;
      private decimal[] P00AP3_A713ComISC ;
      private decimal[] P00AP3_A706ComFlete ;
      private decimal[] P00AP3_A716ComSubAfe ;
      private decimal[] P00AP5_A732ComSubIna ;
      private decimal[] P00AP5_A716ComSubAfe ;
      private short[] P00AP7_A1906TipCmp ;
      private string[] P00AP7_A306TipAbr ;
      private DateTime[] P00AP7_A707ComFReg ;
      private DateTime[] P00AP7_A708ComFVcto ;
      private int[] P00AP7_A246ComMon ;
      private string[] P00AP7_A149TipCod ;
      private string[] P00AP7_A1233MonAbr ;
      private bool[] P00AP7_n1233MonAbr ;
      private string[] P00AP7_A243ComCod ;
      private DateTime[] P00AP7_A248ComFec ;
      private string[] P00AP7_A244PrvCod ;
      private string[] P00AP7_A247PrvDsc ;
      private DateTime[] P00AP7_A704ComFecPago ;
      private DateTime[] P00AP7_A724ComRefFec ;
      private short[] P00AP7_A511TipSigno ;
      private string[] P00AP7_A249ComRef ;
      private decimal[] P00AP7_A729ComRete2 ;
      private decimal[] P00AP7_A728ComRete1 ;
      private decimal[] P00AP7_A732ComSubIna ;
      private decimal[] P00AP7_A719ComIVADUA ;
      private decimal[] P00AP7_A718ComRedondeo ;
      private decimal[] P00AP7_A717ComPorIva ;
      private decimal[] P00AP7_A698ComDscto ;
      private decimal[] P00AP7_A713ComISC ;
      private decimal[] P00AP7_A706ComFlete ;
      private decimal[] P00AP7_A716ComSubAfe ;
      private decimal[] P00AP9_A732ComSubIna ;
      private decimal[] P00AP9_A716ComSubAfe ;
      private short[] P00AP11_A1906TipCmp ;
      private string[] P00AP11_A306TipAbr ;
      private DateTime[] P00AP11_A707ComFReg ;
      private DateTime[] P00AP11_A708ComFVcto ;
      private int[] P00AP11_A246ComMon ;
      private string[] P00AP11_A149TipCod ;
      private string[] P00AP11_A1233MonAbr ;
      private bool[] P00AP11_n1233MonAbr ;
      private string[] P00AP11_A243ComCod ;
      private string[] P00AP11_A244PrvCod ;
      private string[] P00AP11_A247PrvDsc ;
      private string[] P00AP11_A249ComRef ;
      private DateTime[] P00AP11_A704ComFecPago ;
      private DateTime[] P00AP11_A724ComRefFec ;
      private short[] P00AP11_A511TipSigno ;
      private DateTime[] P00AP11_A248ComFec ;
      private decimal[] P00AP11_A729ComRete2 ;
      private decimal[] P00AP11_A728ComRete1 ;
      private decimal[] P00AP11_A732ComSubIna ;
      private decimal[] P00AP11_A719ComIVADUA ;
      private decimal[] P00AP11_A718ComRedondeo ;
      private decimal[] P00AP11_A717ComPorIva ;
      private decimal[] P00AP11_A698ComDscto ;
      private decimal[] P00AP11_A713ComISC ;
      private decimal[] P00AP11_A706ComFlete ;
      private decimal[] P00AP11_A716ComSubAfe ;
      private decimal[] P00AP13_A732ComSubIna ;
      private decimal[] P00AP13_A716ComSubAfe ;
      private short[] P00AP15_A1906TipCmp ;
      private string[] P00AP15_A306TipAbr ;
      private DateTime[] P00AP15_A707ComFReg ;
      private DateTime[] P00AP15_A708ComFVcto ;
      private int[] P00AP15_A246ComMon ;
      private string[] P00AP15_A149TipCod ;
      private string[] P00AP15_A1233MonAbr ;
      private bool[] P00AP15_n1233MonAbr ;
      private string[] P00AP15_A243ComCod ;
      private DateTime[] P00AP15_A248ComFec ;
      private string[] P00AP15_A247PrvDsc ;
      private string[] P00AP15_A249ComRef ;
      private DateTime[] P00AP15_A704ComFecPago ;
      private DateTime[] P00AP15_A724ComRefFec ;
      private short[] P00AP15_A511TipSigno ;
      private string[] P00AP15_A244PrvCod ;
      private decimal[] P00AP15_A729ComRete2 ;
      private decimal[] P00AP15_A728ComRete1 ;
      private decimal[] P00AP15_A732ComSubIna ;
      private decimal[] P00AP15_A719ComIVADUA ;
      private decimal[] P00AP15_A718ComRedondeo ;
      private decimal[] P00AP15_A717ComPorIva ;
      private decimal[] P00AP15_A698ComDscto ;
      private decimal[] P00AP15_A713ComISC ;
      private decimal[] P00AP15_A706ComFlete ;
      private decimal[] P00AP15_A716ComSubAfe ;
      private decimal[] P00AP17_A732ComSubIna ;
      private decimal[] P00AP17_A716ComSubAfe ;
   }

   public class r_registrocompraspdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00AP3;
          prmP00AP3 = new Object[] {
          };
          Object[] prmP00AP5;
          prmP00AP5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AP7;
          prmP00AP7 = new Object[] {
          };
          Object[] prmP00AP9;
          prmP00AP9 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AP11;
          prmP00AP11 = new Object[] {
          };
          Object[] prmP00AP13;
          prmP00AP13 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AP15;
          prmP00AP15 = new Object[] {
          };
          Object[] prmP00AP17;
          prmP00AP17 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AP3", "SELECT T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRefFec], T3.[TipSigno], T1.[ComRete2], T1.[ComRete1], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP5", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP7", "SELECT T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP9", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP11", "SELECT T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T1.[ComCod], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRefFec], T3.[TipSigno], T1.[ComFec], T1.[ComRete2], T1.[ComRete1], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP13", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP15", "SELECT T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T2.[MonAbr], T1.[ComCod], T1.[ComFec], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRefFec], T3.[TipSigno], T1.[PrvCod], T1.[ComRete2], T1.[ComRete1], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP15,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AP17", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AP17,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((string[]) buf[12])[0] = rslt.getString(12, 10);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((short[]) buf[15])[0] = rslt.getShort(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 20);
                ((string[]) buf[11])[0] = rslt.getString(11, 100);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 10);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 15);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getString(11, 10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getString(15, 20);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                return;
             case 7 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
