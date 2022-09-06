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
   public class rrdaotcompras : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrdaotcompras.aspx")), "contabilidad.rrdaotcompras.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrdaotcompras.aspx")))) ;
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
               AV8Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV14DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV48nImporte = NumberUtil.Val( GetPar( "nImporte"), ".");
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

      public rrdaotcompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrdaotcompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref int aP1_DocMonCod ,
                           ref decimal aP2_nImporte )
      {
         this.AV8Ano = aP0_Ano;
         this.AV14DocMonCod = aP1_DocMonCod;
         this.AV48nImporte = aP2_nImporte;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_DocMonCod=this.AV14DocMonCod;
         aP2_nImporte=this.AV48nImporte;
      }

      public decimal executeUdp( ref short aP0_Ano ,
                                 ref int aP1_DocMonCod )
      {
         execute(ref aP0_Ano, ref aP1_DocMonCod, ref aP2_nImporte);
         return AV48nImporte ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref int aP1_DocMonCod ,
                                 ref decimal aP2_nImporte )
      {
         rrdaotcompras objrrdaotcompras;
         objrrdaotcompras = new rrdaotcompras();
         objrrdaotcompras.AV8Ano = aP0_Ano;
         objrrdaotcompras.AV14DocMonCod = aP1_DocMonCod;
         objrrdaotcompras.AV48nImporte = aP2_nImporte;
         objrrdaotcompras.context.SetSubmitInitialConfig(context);
         objrrdaotcompras.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrdaotcompras);
         aP0_Ano=this.AV8Ano;
         aP1_DocMonCod=this.AV14DocMonCod;
         aP2_nImporte=this.AV48nImporte;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrdaotcompras)stateInfo).executePrivate();
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
            AV18Empresa = AV39Session.Get("Empresa");
            AV17EmpDir = AV39Session.Get("EmpDir");
            AV19EmpRUC = AV39Session.Get("EmpRUC");
            AV35Ruta = AV39Session.Get("RUTA") + "/Logo.jpg";
            AV30Logo = AV35Ruta;
            AV51Logo_GXI = GXDbFile.PathToUrl( AV35Ruta);
            /* Using cursor P00BU2 */
            pr_default.execute(0, new Object[] {AV14DocMonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00BU2_A180MonCod[0];
               A1234MonDsc = P00BU2_A1234MonDsc[0];
               AV32Moneda = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV46TotalGeneral = 0.00m;
            /* Using cursor P00BU3 */
            pr_default.execute(1, new Object[] {AV8Ano});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKBU4 = false;
               A149TipCod = P00BU3_A149TipCod[0];
               A1763PrvDir = P00BU3_A1763PrvDir[0];
               A244PrvCod = P00BU3_A244PrvCod[0];
               A707ComFReg = P00BU3_A707ComFReg[0];
               A1906TipCmp = P00BU3_A1906TipCmp[0];
               A247PrvDsc = P00BU3_A247PrvDsc[0];
               A243ComCod = P00BU3_A243ComCod[0];
               A1906TipCmp = P00BU3_A1906TipCmp[0];
               A1763PrvDir = P00BU3_A1763PrvDir[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BU3_A244PrvCod[0], A244PrvCod) == 0 ) )
               {
                  BRKBU4 = false;
                  A149TipCod = P00BU3_A149TipCod[0];
                  A1763PrvDir = P00BU3_A1763PrvDir[0];
                  A243ComCod = P00BU3_A243ComCod[0];
                  A1763PrvDir = P00BU3_A1763PrvDir[0];
                  BRKBU4 = true;
                  pr_default.readNext(1);
               }
               AV12DocCliCod = A244PrvCod;
               AV13DocCliDsc = A247PrvDsc;
               AV47TotalVenta = 0.00m;
               AV45Total = 0.00m;
               /* Execute user subroutine: 'COMPRAS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( ( AV47TotalVenta > AV48nImporte ) && ! (Convert.ToDecimal(0)==AV48nImporte) )
               {
                  AV37SDTVentaClientesITem.gxTpr_Clicod = AV12DocCliCod;
                  AV37SDTVentaClientesITem.gxTpr_Clidsc = AV13DocCliDsc;
                  AV37SDTVentaClientesITem.gxTpr_Importe = NumberUtil.Round( AV47TotalVenta, 0);
                  AV36SDTVentaClientes.Add(AV37SDTVentaClientesITem, 0);
                  AV37SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
                  AV46TotalGeneral = (decimal)(AV46TotalGeneral+AV47TotalVenta);
               }
               if ( (Convert.ToDecimal(0)==AV48nImporte) )
               {
                  AV37SDTVentaClientesITem.gxTpr_Clicod = AV12DocCliCod;
                  AV37SDTVentaClientesITem.gxTpr_Clidsc = AV13DocCliDsc;
                  AV37SDTVentaClientesITem.gxTpr_Importe = NumberUtil.Round( AV47TotalVenta, 0);
                  AV36SDTVentaClientes.Add(AV37SDTVentaClientesITem, 0);
                  AV37SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
                  AV46TotalGeneral = (decimal)(AV46TotalGeneral+AV47TotalVenta);
               }
               if ( ! BRKBU4 )
               {
                  BRKBU4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            AV36SDTVentaClientes.Sort("[Importe]");
            AV58GXV1 = 1;
            while ( AV58GXV1 <= AV36SDTVentaClientes.Count )
            {
               AV37SDTVentaClientesITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV36SDTVentaClientes.Item(AV58GXV1));
               AV12DocCliCod = AV37SDTVentaClientesITem.gxTpr_Clicod;
               AV13DocCliDsc = AV37SDTVentaClientesITem.gxTpr_Clidsc;
               AV47TotalVenta = AV37SDTVentaClientesITem.gxTpr_Importe;
               HBU0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13DocCliDsc, "")), 159, Gx_line+3, 593, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV47TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 606, Gx_line+1, 713, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12DocCliCod, "")), 0, Gx_line+1, 105, Gx_line+16, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV58GXV1 = (int)(AV58GXV1+1);
            }
            HBU0( false, 52) ;
            getPrinter().GxDrawLine(571, Gx_line+9, 766, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 500, Gx_line+17, 580, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotalGeneral, "ZZZZZZ,ZZZ,ZZ9.99")), 614, Gx_line+16, 721, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBU0( true, 0) ;
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
         /* 'COMPRAS' Routine */
         returnInSub = false;
         /* Using cursor P00BU5 */
         pr_default.execute(2, new Object[] {AV12DocCliCod, AV8Ano});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A707ComFReg = P00BU5_A707ComFReg[0];
            A1906TipCmp = P00BU5_A1906TipCmp[0];
            A244PrvCod = P00BU5_A244PrvCod[0];
            A149TipCod = P00BU5_A149TipCod[0];
            A243ComCod = P00BU5_A243ComCod[0];
            A248ComFec = P00BU5_A248ComFec[0];
            A724ComRefFec = P00BU5_A724ComRefFec[0];
            A246ComMon = P00BU5_A246ComMon[0];
            A511TipSigno = P00BU5_A511TipSigno[0];
            A729ComRete2 = P00BU5_A729ComRete2[0];
            A728ComRete1 = P00BU5_A728ComRete1[0];
            A698ComDscto = P00BU5_A698ComDscto[0];
            A706ComFlete = P00BU5_A706ComFlete[0];
            A704ComFecPago = P00BU5_A704ComFecPago[0];
            A732ComSubIna = P00BU5_A732ComSubIna[0];
            A716ComSubAfe = P00BU5_A716ComSubAfe[0];
            A1906TipCmp = P00BU5_A1906TipCmp[0];
            A511TipSigno = P00BU5_A511TipSigno[0];
            A732ComSubIna = P00BU5_A732ComSubIna[0];
            A716ComSubAfe = P00BU5_A716ComSubAfe[0];
            AV44TipCod2 = A149TipCod;
            AV15DocNum = A243ComCod;
            AV22Fecha = (((StringUtil.StrCmp(AV44TipCod2, "NC")==0)||(StringUtil.StrCmp(AV44TipCod2, "ND")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : A248ComFec);
            AV31MonCod = A246ComMon;
            AV40SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2))*A511TipSigno);
            if ( ! (DateTime.MinValue==A704ComFecPago) )
            {
               AV22Fecha = A704ComFecPago;
            }
            if ( AV14DocMonCod != 1 )
            {
               if ( AV31MonCod == 1 )
               {
                  GXt_decimal1 = AV9Cambio;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV22Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                  AV9Cambio = GXt_decimal1;
                  AV45Total = NumberUtil.Round( AV40SubTotal/ (decimal)(AV9Cambio), 2);
               }
               else
               {
                  AV45Total = AV40SubTotal;
               }
            }
            else
            {
               if ( AV31MonCod != 1 )
               {
                  GXt_decimal1 = AV9Cambio;
                  GXt_int2 = 2;
                  GXt_char3 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV22Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                  AV9Cambio = GXt_decimal1;
                  AV45Total = NumberUtil.Round( AV40SubTotal*AV9Cambio, 2);
               }
               else
               {
                  AV45Total = AV40SubTotal;
               }
            }
            AV47TotalVenta = (decimal)(AV47TotalVenta+AV45Total);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HBU0( bool bFoot ,
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
               getPrinter().GxDrawText("Daot - Compras", 361, Gx_line+38, 494, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+115, 797, Gx_line+141, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+24, 769, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+43, 767, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+63, 769, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 25, Gx_line+122, 59, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 220, Gx_line+122, 282, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Compra", 652, Gx_line+122, 732, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Año :", 375, Gx_line+59, 421, Gx_line+79, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV30Logo)) ? AV51Logo_GXI : AV30Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+7, 169, Gx_line+76) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Ano), "ZZZ9")), 425, Gx_line+60, 464, Gx_line+81, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 18, Gx_line+76, 324, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 18, Gx_line+94, 156, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda :", 342, Gx_line+85, 421, Gx_line+105, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32Moneda, "")), 428, Gx_line+86, 633, Gx_line+106, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+141);
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
         AV18Empresa = "";
         AV39Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV35Ruta = "";
         AV30Logo = "";
         AV51Logo_GXI = "";
         scmdbuf = "";
         P00BU2_A180MonCod = new int[1] ;
         P00BU2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV32Moneda = "";
         P00BU3_A149TipCod = new string[] {""} ;
         P00BU3_A1763PrvDir = new string[] {""} ;
         P00BU3_A244PrvCod = new string[] {""} ;
         P00BU3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00BU3_A1906TipCmp = new short[1] ;
         P00BU3_A247PrvDsc = new string[] {""} ;
         P00BU3_A243ComCod = new string[] {""} ;
         A149TipCod = "";
         A1763PrvDir = "";
         A244PrvCod = "";
         A707ComFReg = DateTime.MinValue;
         A247PrvDsc = "";
         A243ComCod = "";
         AV12DocCliCod = "";
         AV13DocCliDsc = "";
         AV37SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV36SDTVentaClientes = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         P00BU5_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00BU5_A1906TipCmp = new short[1] ;
         P00BU5_A244PrvCod = new string[] {""} ;
         P00BU5_A149TipCod = new string[] {""} ;
         P00BU5_A243ComCod = new string[] {""} ;
         P00BU5_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00BU5_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P00BU5_A246ComMon = new int[1] ;
         P00BU5_A511TipSigno = new short[1] ;
         P00BU5_A729ComRete2 = new decimal[1] ;
         P00BU5_A728ComRete1 = new decimal[1] ;
         P00BU5_A698ComDscto = new decimal[1] ;
         P00BU5_A706ComFlete = new decimal[1] ;
         P00BU5_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P00BU5_A732ComSubIna = new decimal[1] ;
         P00BU5_A716ComSubAfe = new decimal[1] ;
         A248ComFec = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         A704ComFecPago = DateTime.MinValue;
         AV44TipCod2 = "";
         AV15DocNum = "";
         AV22Fecha = DateTime.MinValue;
         GXt_char3 = "";
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV30Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrdaotcompras__default(),
            new Object[][] {
                new Object[] {
               P00BU2_A180MonCod, P00BU2_A1234MonDsc
               }
               , new Object[] {
               P00BU3_A149TipCod, P00BU3_A1763PrvDir, P00BU3_A244PrvCod, P00BU3_A707ComFReg, P00BU3_A1906TipCmp, P00BU3_A247PrvDsc, P00BU3_A243ComCod
               }
               , new Object[] {
               P00BU5_A707ComFReg, P00BU5_A1906TipCmp, P00BU5_A244PrvCod, P00BU5_A149TipCod, P00BU5_A243ComCod, P00BU5_A248ComFec, P00BU5_A724ComRefFec, P00BU5_A246ComMon, P00BU5_A511TipSigno, P00BU5_A729ComRete2,
               P00BU5_A728ComRete1, P00BU5_A698ComDscto, P00BU5_A706ComFlete, P00BU5_A704ComFecPago, P00BU5_A732ComSubIna, P00BU5_A716ComSubAfe
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
      private short AV8Ano ;
      private short A1906TipCmp ;
      private short A511TipSigno ;
      private int AV14DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int AV58GXV1 ;
      private int Gx_OldLine ;
      private int A246ComMon ;
      private int AV31MonCod ;
      private int GXt_int2 ;
      private decimal AV48nImporte ;
      private decimal AV46TotalGeneral ;
      private decimal AV47TotalVenta ;
      private decimal AV45Total ;
      private decimal A729ComRete2 ;
      private decimal A728ComRete1 ;
      private decimal A698ComDscto ;
      private decimal A706ComFlete ;
      private decimal A732ComSubIna ;
      private decimal A716ComSubAfe ;
      private decimal AV40SubTotal ;
      private decimal AV9Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV35Ruta ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string AV32Moneda ;
      private string A149TipCod ;
      private string A1763PrvDir ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A243ComCod ;
      private string AV12DocCliCod ;
      private string AV13DocCliDsc ;
      private string AV44TipCod2 ;
      private string AV15DocNum ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime A724ComRefFec ;
      private DateTime A704ComFecPago ;
      private DateTime AV22Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBU4 ;
      private bool returnInSub ;
      private string AV51Logo_GXI ;
      private string AV30Logo ;
      private string Logo ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private int aP1_DocMonCod ;
      private decimal aP2_nImporte ;
      private IDataStoreProvider pr_default ;
      private int[] P00BU2_A180MonCod ;
      private string[] P00BU2_A1234MonDsc ;
      private string[] P00BU3_A149TipCod ;
      private string[] P00BU3_A1763PrvDir ;
      private string[] P00BU3_A244PrvCod ;
      private DateTime[] P00BU3_A707ComFReg ;
      private short[] P00BU3_A1906TipCmp ;
      private string[] P00BU3_A247PrvDsc ;
      private string[] P00BU3_A243ComCod ;
      private DateTime[] P00BU5_A707ComFReg ;
      private short[] P00BU5_A1906TipCmp ;
      private string[] P00BU5_A244PrvCod ;
      private string[] P00BU5_A149TipCod ;
      private string[] P00BU5_A243ComCod ;
      private DateTime[] P00BU5_A248ComFec ;
      private DateTime[] P00BU5_A724ComRefFec ;
      private int[] P00BU5_A246ComMon ;
      private short[] P00BU5_A511TipSigno ;
      private decimal[] P00BU5_A729ComRete2 ;
      private decimal[] P00BU5_A728ComRete1 ;
      private decimal[] P00BU5_A698ComDscto ;
      private decimal[] P00BU5_A706ComFlete ;
      private DateTime[] P00BU5_A704ComFecPago ;
      private decimal[] P00BU5_A732ComSubIna ;
      private decimal[] P00BU5_A716ComSubAfe ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV36SDTVentaClientes ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV37SDTVentaClientesITem ;
   }

   public class rrdaotcompras__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BU2;
          prmP00BU2 = new Object[] {
          new ParDef("@AV14DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00BU3;
          prmP00BU3 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00BU5;
          prmP00BU5 = new Object[] {
          new ParDef("@AV12DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BU2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV14DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BU3", "SELECT T1.[TipCod], T3.[PrvDir], T1.[PrvCod], T1.[ComFReg], T2.[TipCmp], T1.[PrvDsc], T1.[ComCod] FROM (([CPCOMPRAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[PrvCod]) WHERE (YEAR(T1.[ComFReg]) = @AV8Ano) AND (T2.[TipCmp] = 1) ORDER BY T1.[PrvCod], T3.[PrvDir] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BU5", "SELECT T1.[ComFReg], T2.[TipCmp], T1.[PrvCod], T1.[TipCod], T1.[ComCod], T1.[ComFec], T1.[ComRefFec], T1.[ComMon], T2.[TipSigno], T1.[ComRete2], T1.[ComRete1], T1.[ComDscto], T1.[ComFlete], T1.[ComFecPago], COALESCE( T3.[ComSubIna], 0) AS ComSubIna, COALESCE( T3.[ComSubAfe], 0) AS ComSubAfe FROM (([CPCOMPRAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[ComCod] = T1.[ComCod] AND T3.[PrvCod] = T1.[PrvCod]) WHERE (T1.[PrvCod] = @AV12DocCliCod) AND (YEAR(T1.[ComFReg]) = @AV8Ano) AND (T2.[TipCmp] = 1) ORDER BY T1.[PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BU5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                return;
       }
    }

 }

}
