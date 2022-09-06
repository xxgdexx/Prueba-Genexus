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
   public class rrdaotventas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "contabilidad.rrdaotventas.aspx")), "contabilidad.rrdaotventas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "contabilidad.rrdaotventas.aspx")))) ;
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
                  AV13DocMonCod = (int)(NumberUtil.Val( GetPar( "DocMonCod"), "."));
                  AV44nImporte = NumberUtil.Val( GetPar( "nImporte"), ".");
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

      public rrdaotventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrdaotventas( IGxContext context )
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
         this.AV13DocMonCod = aP1_DocMonCod;
         this.AV44nImporte = aP2_nImporte;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_DocMonCod=this.AV13DocMonCod;
         aP2_nImporte=this.AV44nImporte;
      }

      public decimal executeUdp( ref short aP0_Ano ,
                                 ref int aP1_DocMonCod )
      {
         execute(ref aP0_Ano, ref aP1_DocMonCod, ref aP2_nImporte);
         return AV44nImporte ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref int aP1_DocMonCod ,
                                 ref decimal aP2_nImporte )
      {
         rrdaotventas objrrdaotventas;
         objrrdaotventas = new rrdaotventas();
         objrrdaotventas.AV8Ano = aP0_Ano;
         objrrdaotventas.AV13DocMonCod = aP1_DocMonCod;
         objrrdaotventas.AV44nImporte = aP2_nImporte;
         objrrdaotventas.context.SetSubmitInitialConfig(context);
         objrrdaotventas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrdaotventas);
         aP0_Ano=this.AV8Ano;
         aP1_DocMonCod=this.AV13DocMonCod;
         aP2_nImporte=this.AV44nImporte;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrdaotventas)stateInfo).executePrivate();
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
            AV16Empresa = AV36Session.Get("Empresa");
            AV15EmpDir = AV36Session.Get("EmpDir");
            AV17EmpRUC = AV36Session.Get("EmpRUC");
            AV32Ruta = AV36Session.Get("RUTA") + "/Logo.jpg";
            AV28Logo = AV32Ruta;
            AV47Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            /* Using cursor P00BT2 */
            pr_default.execute(0, new Object[] {AV13DocMonCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A180MonCod = P00BT2_A180MonCod[0];
               A1234MonDsc = P00BT2_A1234MonDsc[0];
               AV30Moneda = StringUtil.Trim( A1234MonDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            AV42TotalGeneral = 0.00m;
            /* Using cursor P00BT4 */
            pr_default.execute(1, new Object[] {AV8Ano});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKBT4 = false;
               A24DocNum = P00BT4_A24DocNum[0];
               A1921TipVta = P00BT4_A1921TipVta[0];
               A941DocSts = P00BT4_A941DocSts[0];
               A946DocTipo = P00BT4_A946DocTipo[0];
               A231DocCliCod = P00BT4_A231DocCliCod[0];
               A149TipCod = P00BT4_A149TipCod[0];
               A232DocFec = P00BT4_A232DocFec[0];
               A230DocMonCod = P00BT4_A230DocMonCod[0];
               A511TipSigno = P00BT4_A511TipSigno[0];
               A882DocAnticipos = P00BT4_A882DocAnticipos[0];
               A929DocFecRef = P00BT4_A929DocFecRef[0];
               A887DocCliDsc = P00BT4_A887DocCliDsc[0];
               A927DocSubExonerado = P00BT4_A927DocSubExonerado[0];
               A922DocSubSelectivo = P00BT4_A922DocSubSelectivo[0];
               A921DocSubInafecto = P00BT4_A921DocSubInafecto[0];
               A920DocSubAfecto = P00BT4_A920DocSubAfecto[0];
               A899DocDcto = P00BT4_A899DocDcto[0];
               A887DocCliDsc = P00BT4_A887DocCliDsc[0];
               A1921TipVta = P00BT4_A1921TipVta[0];
               A511TipSigno = P00BT4_A511TipSigno[0];
               A927DocSubExonerado = P00BT4_A927DocSubExonerado[0];
               A922DocSubSelectivo = P00BT4_A922DocSubSelectivo[0];
               A921DocSubInafecto = P00BT4_A921DocSubInafecto[0];
               A920DocSubAfecto = P00BT4_A920DocSubAfecto[0];
               A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
               A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
               AV11DocCliCod = A231DocCliCod;
               AV12DocCliDsc = A887DocCliDsc;
               AV43TotalVenta = 0.00m;
               AV41Total = 0.00m;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BT4_A231DocCliCod[0], A231DocCliCod) == 0 ) )
               {
                  BRKBT4 = false;
                  A24DocNum = P00BT4_A24DocNum[0];
                  A1921TipVta = P00BT4_A1921TipVta[0];
                  A941DocSts = P00BT4_A941DocSts[0];
                  A946DocTipo = P00BT4_A946DocTipo[0];
                  A149TipCod = P00BT4_A149TipCod[0];
                  A232DocFec = P00BT4_A232DocFec[0];
                  A230DocMonCod = P00BT4_A230DocMonCod[0];
                  A511TipSigno = P00BT4_A511TipSigno[0];
                  A882DocAnticipos = P00BT4_A882DocAnticipos[0];
                  A929DocFecRef = P00BT4_A929DocFecRef[0];
                  A899DocDcto = P00BT4_A899DocDcto[0];
                  A1921TipVta = P00BT4_A1921TipVta[0];
                  A511TipSigno = P00BT4_A511TipSigno[0];
                  if ( StringUtil.StrCmp(A231DocCliCod, AV11DocCliCod) == 0 )
                  {
                     if ( A1921TipVta == 1 )
                     {
                        if ( StringUtil.StrCmp(A946DocTipo, "M") != 0 )
                        {
                           if ( StringUtil.StrCmp(A946DocTipo, "X") != 0 )
                           {
                              if ( StringUtil.StrCmp(A941DocSts, "A") != 0 )
                              {
                                 /* Using cursor P00BT6 */
                                 pr_default.execute(2, new Object[] {A149TipCod, A24DocNum});
                                 if ( (pr_default.getStatus(2) != 101) )
                                 {
                                    A927DocSubExonerado = P00BT6_A927DocSubExonerado[0];
                                    A922DocSubSelectivo = P00BT6_A922DocSubSelectivo[0];
                                    A921DocSubInafecto = P00BT6_A921DocSubInafecto[0];
                                    A920DocSubAfecto = P00BT6_A920DocSubAfecto[0];
                                 }
                                 else
                                 {
                                    A920DocSubAfecto = 0;
                                    A921DocSubInafecto = 0;
                                    A922DocSubSelectivo = 0;
                                    A927DocSubExonerado = 0;
                                 }
                                 pr_default.close(2);
                                 A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                                 A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                                 AV40TipCod2 = A149TipCod;
                                 AV20Fecha = A232DocFec;
                                 AV29MonCod = A230DocMonCod;
                                 AV37SubTotal = NumberUtil.Round( (A919DocSub-(A918DocDscto+A882DocAnticipos))*A511TipSigno, 2);
                                 if ( ( StringUtil.StrCmp(AV40TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV40TipCod2, "ND") == 0 ) )
                                 {
                                    AV20Fecha = A929DocFecRef;
                                 }
                                 if ( AV13DocMonCod == 1 )
                                 {
                                    if ( AV29MonCod == 2 )
                                    {
                                       GXt_decimal1 = AV9Cambio;
                                       GXt_int2 = 2;
                                       GXt_char3 = "V";
                                       new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV20Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                                       AV9Cambio = GXt_decimal1;
                                       AV41Total = NumberUtil.Round( AV37SubTotal*AV9Cambio, 2);
                                    }
                                    else
                                    {
                                       AV41Total = AV37SubTotal;
                                    }
                                 }
                                 else
                                 {
                                    if ( AV29MonCod == 1 )
                                    {
                                       GXt_decimal1 = AV9Cambio;
                                       GXt_int2 = 2;
                                       GXt_char3 = "V";
                                       new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV20Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                                       AV9Cambio = GXt_decimal1;
                                       AV41Total = NumberUtil.Round( AV37SubTotal/ (decimal)(AV9Cambio), 2);
                                    }
                                    else
                                    {
                                       AV41Total = AV37SubTotal;
                                    }
                                 }
                                 AV43TotalVenta = (decimal)(AV43TotalVenta+AV41Total);
                              }
                           }
                        }
                     }
                  }
                  BRKBT4 = true;
                  pr_default.readNext(1);
               }
               if ( ( AV43TotalVenta > AV44nImporte ) && ! (Convert.ToDecimal(0)==AV44nImporte) )
               {
                  AV34SDTVentaClientesITem.gxTpr_Clicod = AV11DocCliCod;
                  AV34SDTVentaClientesITem.gxTpr_Clidsc = AV12DocCliDsc;
                  AV34SDTVentaClientesITem.gxTpr_Importe = AV43TotalVenta;
                  AV33SDTVentaClientes.Add(AV34SDTVentaClientesITem, 0);
                  AV34SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
                  AV42TotalGeneral = (decimal)(AV42TotalGeneral+AV43TotalVenta);
               }
               if ( (Convert.ToDecimal(0)==AV44nImporte) )
               {
                  AV34SDTVentaClientesITem.gxTpr_Clicod = AV11DocCliCod;
                  AV34SDTVentaClientesITem.gxTpr_Clidsc = AV12DocCliDsc;
                  AV34SDTVentaClientesITem.gxTpr_Importe = AV43TotalVenta;
                  AV33SDTVentaClientes.Add(AV34SDTVentaClientesITem, 0);
                  AV34SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
                  AV42TotalGeneral = (decimal)(AV42TotalGeneral+AV43TotalVenta);
               }
               if ( ! BRKBT4 )
               {
                  BRKBT4 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            AV33SDTVentaClientes.Sort("[Importe]");
            AV54GXV1 = 1;
            while ( AV54GXV1 <= AV33SDTVentaClientes.Count )
            {
               AV34SDTVentaClientesITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV33SDTVentaClientes.Item(AV54GXV1));
               AV11DocCliCod = AV34SDTVentaClientesITem.gxTpr_Clicod;
               AV12DocCliDsc = AV34SDTVentaClientesITem.gxTpr_Clidsc;
               AV43TotalVenta = AV34SDTVentaClientesITem.gxTpr_Importe;
               HBT0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12DocCliDsc, "")), 159, Gx_line+3, 593, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 606, Gx_line+1, 713, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11DocCliCod, "")), 0, Gx_line+1, 105, Gx_line+16, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV54GXV1 = (int)(AV54GXV1+1);
            }
            HBT0( false, 52) ;
            getPrinter().GxDrawLine(571, Gx_line+9, 766, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 500, Gx_line+17, 580, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 614, Gx_line+16, 715, Gx_line+31, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HBT0( true, 0) ;
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

      protected void HBT0( bool bFoot ,
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
               getPrinter().GxDrawText("Daot - Ventas", 361, Gx_line+38, 479, Gx_line+58, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+115, 797, Gx_line+141, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+24, 769, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+43, 767, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+63, 769, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("R.U.C.", 25, Gx_line+122, 59, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 220, Gx_line+122, 262, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta", 652, Gx_line+122, 721, Gx_line+136, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Año :", 375, Gx_line+59, 421, Gx_line+79, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV28Logo)) ? AV47Logo_GXI : AV28Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+7, 169, Gx_line+76) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Ano), "ZZZ9")), 425, Gx_line+60, 464, Gx_line+81, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16Empresa, "")), 18, Gx_line+76, 324, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpRUC, "")), 18, Gx_line+94, 156, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda :", 342, Gx_line+83, 421, Gx_line+103, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Moneda, "")), 425, Gx_line+84, 630, Gx_line+104, 0, 0, 0, 0) ;
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
         pr_default.close(2);
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV16Empresa = "";
         AV36Session = context.GetSession();
         AV15EmpDir = "";
         AV17EmpRUC = "";
         AV32Ruta = "";
         AV28Logo = "";
         AV47Logo_GXI = "";
         scmdbuf = "";
         P00BT2_A180MonCod = new int[1] ;
         P00BT2_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         AV30Moneda = "";
         P00BT4_A24DocNum = new string[] {""} ;
         P00BT4_A1921TipVta = new short[1] ;
         P00BT4_A941DocSts = new string[] {""} ;
         P00BT4_A946DocTipo = new string[] {""} ;
         P00BT4_A231DocCliCod = new string[] {""} ;
         P00BT4_A149TipCod = new string[] {""} ;
         P00BT4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00BT4_A230DocMonCod = new int[1] ;
         P00BT4_A511TipSigno = new short[1] ;
         P00BT4_A882DocAnticipos = new decimal[1] ;
         P00BT4_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00BT4_A887DocCliDsc = new string[] {""} ;
         P00BT4_A927DocSubExonerado = new decimal[1] ;
         P00BT4_A922DocSubSelectivo = new decimal[1] ;
         P00BT4_A921DocSubInafecto = new decimal[1] ;
         P00BT4_A920DocSubAfecto = new decimal[1] ;
         P00BT4_A899DocDcto = new decimal[1] ;
         A24DocNum = "";
         A941DocSts = "";
         A946DocTipo = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A232DocFec = DateTime.MinValue;
         A929DocFecRef = DateTime.MinValue;
         A887DocCliDsc = "";
         AV11DocCliCod = "";
         AV12DocCliDsc = "";
         P00BT6_A927DocSubExonerado = new decimal[1] ;
         P00BT6_A922DocSubSelectivo = new decimal[1] ;
         P00BT6_A921DocSubInafecto = new decimal[1] ;
         P00BT6_A920DocSubAfecto = new decimal[1] ;
         AV40TipCod2 = "";
         AV20Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV34SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV33SDTVentaClientes = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV28Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rrdaotventas__default(),
            new Object[][] {
                new Object[] {
               P00BT2_A180MonCod, P00BT2_A1234MonDsc
               }
               , new Object[] {
               P00BT4_A24DocNum, P00BT4_A1921TipVta, P00BT4_A941DocSts, P00BT4_A946DocTipo, P00BT4_A231DocCliCod, P00BT4_A149TipCod, P00BT4_A232DocFec, P00BT4_A230DocMonCod, P00BT4_A511TipSigno, P00BT4_A882DocAnticipos,
               P00BT4_A929DocFecRef, P00BT4_A887DocCliDsc, P00BT4_A927DocSubExonerado, P00BT4_A922DocSubSelectivo, P00BT4_A921DocSubInafecto, P00BT4_A920DocSubAfecto, P00BT4_A899DocDcto
               }
               , new Object[] {
               P00BT6_A927DocSubExonerado, P00BT6_A922DocSubSelectivo, P00BT6_A921DocSubInafecto, P00BT6_A920DocSubAfecto
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
      private short A1921TipVta ;
      private short A511TipSigno ;
      private int AV13DocMonCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A180MonCod ;
      private int A230DocMonCod ;
      private int AV29MonCod ;
      private int GXt_int2 ;
      private int AV54GXV1 ;
      private int Gx_OldLine ;
      private decimal AV44nImporte ;
      private decimal AV42TotalGeneral ;
      private decimal A882DocAnticipos ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal AV43TotalVenta ;
      private decimal AV41Total ;
      private decimal AV37SubTotal ;
      private decimal AV9Cambio ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV16Empresa ;
      private string AV15EmpDir ;
      private string AV17EmpRUC ;
      private string AV32Ruta ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private string AV30Moneda ;
      private string A24DocNum ;
      private string A941DocSts ;
      private string A946DocTipo ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A887DocCliDsc ;
      private string AV11DocCliCod ;
      private string AV12DocCliDsc ;
      private string AV40TipCod2 ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV20Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKBT4 ;
      private string AV47Logo_GXI ;
      private string AV28Logo ;
      private string Logo ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private int aP1_DocMonCod ;
      private decimal aP2_nImporte ;
      private IDataStoreProvider pr_default ;
      private int[] P00BT2_A180MonCod ;
      private string[] P00BT2_A1234MonDsc ;
      private string[] P00BT4_A24DocNum ;
      private short[] P00BT4_A1921TipVta ;
      private string[] P00BT4_A941DocSts ;
      private string[] P00BT4_A946DocTipo ;
      private string[] P00BT4_A231DocCliCod ;
      private string[] P00BT4_A149TipCod ;
      private DateTime[] P00BT4_A232DocFec ;
      private int[] P00BT4_A230DocMonCod ;
      private short[] P00BT4_A511TipSigno ;
      private decimal[] P00BT4_A882DocAnticipos ;
      private DateTime[] P00BT4_A929DocFecRef ;
      private string[] P00BT4_A887DocCliDsc ;
      private decimal[] P00BT4_A927DocSubExonerado ;
      private decimal[] P00BT4_A922DocSubSelectivo ;
      private decimal[] P00BT4_A921DocSubInafecto ;
      private decimal[] P00BT4_A920DocSubAfecto ;
      private decimal[] P00BT4_A899DocDcto ;
      private decimal[] P00BT6_A927DocSubExonerado ;
      private decimal[] P00BT6_A922DocSubSelectivo ;
      private decimal[] P00BT6_A921DocSubInafecto ;
      private decimal[] P00BT6_A920DocSubAfecto ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV33SDTVentaClientes ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV34SDTVentaClientesITem ;
   }

   public class rrdaotventas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BT2;
          prmP00BT2 = new Object[] {
          new ParDef("@AV13DocMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00BT4;
          prmP00BT4 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0)
          };
          Object[] prmP00BT6;
          prmP00BT6 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BT2", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV13DocMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BT4", "SELECT T1.[DocNum], T3.[TipVta], T1.[DocSts], T1.[DocTipo], T1.[DocCliCod] AS DocCliCod, T1.[TipCod], T1.[DocFec], T1.[DocMonCod], T3.[TipSigno], T1.[DocAnticipos], T1.[DocFecRef], T2.[CliDsc] AS DocCliDsc, COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) WHERE (YEAR(T1.[DocFec]) = @AV8Ano) AND (T1.[DocTipo] <> 'M') AND (T1.[DocTipo] <> 'X') AND (T1.[DocSts] <> 'A') AND (T3.[TipVta] = 1) ORDER BY T1.[DocCliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BT6", "SELECT COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto FROM (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT6,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 100);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
