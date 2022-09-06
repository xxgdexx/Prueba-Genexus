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
   public class rrventasclientes : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrventasclientes.aspx")), "rrventasclientes.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrventasclientes.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV36TipCCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10CliCod = GetPar( "CliCod");
                  AV37TipCod = GetPar( "TipCod");
                  AV29PaiCod = GetPar( "PaiCod");
                  AV19FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV21FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV39Tipo = GetPar( "Tipo");
                  AV47VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AV48ZonCod = (int)(NumberUtil.Val( GetPar( "ZonCod"), "."));
                  AV35TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  AV9CheckRec = (short)(NumberUtil.Val( GetPar( "CheckRec"), "."));
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

      public rrventasclientes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrventasclientes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref string aP2_TipCod ,
                           ref string aP3_PaiCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_Tipo ,
                           ref int aP7_VenCod ,
                           ref int aP8_ZonCod ,
                           ref int aP9_TieCod ,
                           ref short aP10_CheckRec )
      {
         this.AV36TipCCod = aP0_TipCCod;
         this.AV10CliCod = aP1_CliCod;
         this.AV37TipCod = aP2_TipCod;
         this.AV29PaiCod = aP3_PaiCod;
         this.AV19FDesde = aP4_FDesde;
         this.AV21FHasta = aP5_FHasta;
         this.AV39Tipo = aP6_Tipo;
         this.AV47VenCod = aP7_VenCod;
         this.AV48ZonCod = aP8_ZonCod;
         this.AV35TieCod = aP9_TieCod;
         this.AV9CheckRec = aP10_CheckRec;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV36TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_TipCod=this.AV37TipCod;
         aP3_PaiCod=this.AV29PaiCod;
         aP4_FDesde=this.AV19FDesde;
         aP5_FHasta=this.AV21FHasta;
         aP6_Tipo=this.AV39Tipo;
         aP7_VenCod=this.AV47VenCod;
         aP8_ZonCod=this.AV48ZonCod;
         aP9_TieCod=this.AV35TieCod;
         aP10_CheckRec=this.AV9CheckRec;
      }

      public short executeUdp( ref int aP0_TipCCod ,
                               ref string aP1_CliCod ,
                               ref string aP2_TipCod ,
                               ref string aP3_PaiCod ,
                               ref DateTime aP4_FDesde ,
                               ref DateTime aP5_FHasta ,
                               ref string aP6_Tipo ,
                               ref int aP7_VenCod ,
                               ref int aP8_ZonCod ,
                               ref int aP9_TieCod )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_TipCod, ref aP3_PaiCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_Tipo, ref aP7_VenCod, ref aP8_ZonCod, ref aP9_TieCod, ref aP10_CheckRec);
         return AV9CheckRec ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref string aP2_TipCod ,
                                 ref string aP3_PaiCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_Tipo ,
                                 ref int aP7_VenCod ,
                                 ref int aP8_ZonCod ,
                                 ref int aP9_TieCod ,
                                 ref short aP10_CheckRec )
      {
         rrventasclientes objrrventasclientes;
         objrrventasclientes = new rrventasclientes();
         objrrventasclientes.AV36TipCCod = aP0_TipCCod;
         objrrventasclientes.AV10CliCod = aP1_CliCod;
         objrrventasclientes.AV37TipCod = aP2_TipCod;
         objrrventasclientes.AV29PaiCod = aP3_PaiCod;
         objrrventasclientes.AV19FDesde = aP4_FDesde;
         objrrventasclientes.AV21FHasta = aP5_FHasta;
         objrrventasclientes.AV39Tipo = aP6_Tipo;
         objrrventasclientes.AV47VenCod = aP7_VenCod;
         objrrventasclientes.AV48ZonCod = aP8_ZonCod;
         objrrventasclientes.AV35TieCod = aP9_TieCod;
         objrrventasclientes.AV9CheckRec = aP10_CheckRec;
         objrrventasclientes.context.SetSubmitInitialConfig(context);
         objrrventasclientes.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrventasclientes);
         aP0_TipCCod=this.AV36TipCCod;
         aP1_CliCod=this.AV10CliCod;
         aP2_TipCod=this.AV37TipCod;
         aP3_PaiCod=this.AV29PaiCod;
         aP4_FDesde=this.AV19FDesde;
         aP5_FHasta=this.AV21FHasta;
         aP6_Tipo=this.AV39Tipo;
         aP7_VenCod=this.AV47VenCod;
         aP8_ZonCod=this.AV48ZonCod;
         aP9_TieCod=this.AV35TieCod;
         aP10_CheckRec=this.AV9CheckRec;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrventasclientes)stateInfo).executePrivate();
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
            AV16Empresa = AV34Session.Get("Empresa");
            AV15EmpDir = AV34Session.Get("EmpDir");
            AV17EmpRUC = AV34Session.Get("EmpRUC");
            AV30Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV27Logo = AV30Ruta;
            AV51Logo_GXI = GXDbFile.PathToUrl( AV30Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = "Todos";
            AV26Filtro5 = "Todos";
            /* Using cursor P00EE2 */
            pr_default.execute(0, new Object[] {AV37TipCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A149TipCod = P00EE2_A149TipCod[0];
               A1910TipDsc = P00EE2_A1910TipDsc[0];
               AV22Filtro1 = A1910TipDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00EE3 */
            pr_default.execute(1, new Object[] {AV36TipCCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A159TipCCod = P00EE3_A159TipCCod[0];
               n159TipCCod = P00EE3_n159TipCCod[0];
               A1905TipCDsc = P00EE3_A1905TipCDsc[0];
               AV23Filtro2 = A1905TipCDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00EE4 */
            pr_default.execute(2, new Object[] {AV29PaiCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A139PaiCod = P00EE4_A139PaiCod[0];
               n139PaiCod = P00EE4_n139PaiCod[0];
               A1500PaiDsc = P00EE4_A1500PaiDsc[0];
               AV24Filtro3 = A1500PaiDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            /* Using cursor P00EE5 */
            pr_default.execute(3, new Object[] {AV10CliCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A45CliCod = P00EE5_A45CliCod[0];
               A161CliDsc = P00EE5_A161CliDsc[0];
               AV25Filtro4 = A161CliDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
            AV41TotalGeneral = 0.00m;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV35TieCod ,
                                                 AV36TipCCod ,
                                                 AV18EstCod ,
                                                 AV10CliCod ,
                                                 AV37TipCod ,
                                                 AV29PaiCod ,
                                                 AV48ZonCod ,
                                                 AV47VenCod ,
                                                 AV9CheckRec ,
                                                 AV39Tipo ,
                                                 A178TieCod ,
                                                 A159TipCCod ,
                                                 A140EstCod ,
                                                 A231DocCliCod ,
                                                 A149TipCod ,
                                                 A139PaiCod ,
                                                 A158ZonCod ,
                                                 A227DocVendCod ,
                                                 A946DocTipo ,
                                                 A232DocFec ,
                                                 AV19FDesde ,
                                                 AV21FHasta ,
                                                 A941DocSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00EE7 */
            pr_default.execute(4, new Object[] {AV19FDesde, AV21FHasta, AV35TieCod, AV36TipCCod, AV18EstCod, AV10CliCod, AV37TipCod, AV29PaiCod, AV48ZonCod, AV47VenCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRKEE7 = false;
               A24DocNum = P00EE7_A24DocNum[0];
               A941DocSts = P00EE7_A941DocSts[0];
               A231DocCliCod = P00EE7_A231DocCliCod[0];
               A149TipCod = P00EE7_A149TipCod[0];
               A232DocFec = P00EE7_A232DocFec[0];
               A230DocMonCod = P00EE7_A230DocMonCod[0];
               A511TipSigno = P00EE7_A511TipSigno[0];
               A882DocAnticipos = P00EE7_A882DocAnticipos[0];
               A929DocFecRef = P00EE7_A929DocFecRef[0];
               A946DocTipo = P00EE7_A946DocTipo[0];
               A227DocVendCod = P00EE7_A227DocVendCod[0];
               A158ZonCod = P00EE7_A158ZonCod[0];
               n158ZonCod = P00EE7_n158ZonCod[0];
               A139PaiCod = P00EE7_A139PaiCod[0];
               n139PaiCod = P00EE7_n139PaiCod[0];
               A140EstCod = P00EE7_A140EstCod[0];
               n140EstCod = P00EE7_n140EstCod[0];
               A159TipCCod = P00EE7_A159TipCCod[0];
               n159TipCCod = P00EE7_n159TipCCod[0];
               A178TieCod = P00EE7_A178TieCod[0];
               n178TieCod = P00EE7_n178TieCod[0];
               A887DocCliDsc = P00EE7_A887DocCliDsc[0];
               A927DocSubExonerado = P00EE7_A927DocSubExonerado[0];
               A922DocSubSelectivo = P00EE7_A922DocSubSelectivo[0];
               A921DocSubInafecto = P00EE7_A921DocSubInafecto[0];
               A920DocSubAfecto = P00EE7_A920DocSubAfecto[0];
               A899DocDcto = P00EE7_A899DocDcto[0];
               A158ZonCod = P00EE7_A158ZonCod[0];
               n158ZonCod = P00EE7_n158ZonCod[0];
               A139PaiCod = P00EE7_A139PaiCod[0];
               n139PaiCod = P00EE7_n139PaiCod[0];
               A140EstCod = P00EE7_A140EstCod[0];
               n140EstCod = P00EE7_n140EstCod[0];
               A159TipCCod = P00EE7_A159TipCCod[0];
               n159TipCCod = P00EE7_n159TipCCod[0];
               A887DocCliDsc = P00EE7_A887DocCliDsc[0];
               A511TipSigno = P00EE7_A511TipSigno[0];
               A927DocSubExonerado = P00EE7_A927DocSubExonerado[0];
               A922DocSubSelectivo = P00EE7_A922DocSubSelectivo[0];
               A921DocSubInafecto = P00EE7_A921DocSubInafecto[0];
               A920DocSubAfecto = P00EE7_A920DocSubAfecto[0];
               A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
               A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
               AV11DocCliCod = A231DocCliCod;
               AV12DocCliDsc = A887DocCliDsc;
               AV45TotalVenta = 0.00m;
               AV46TotalVentaME = 0.00m;
               AV44TotalMN = 0.00m;
               AV43TotalME = 0.00m;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00EE7_A231DocCliCod[0], A231DocCliCod) == 0 ) )
               {
                  BRKEE7 = false;
                  A24DocNum = P00EE7_A24DocNum[0];
                  A941DocSts = P00EE7_A941DocSts[0];
                  A149TipCod = P00EE7_A149TipCod[0];
                  A232DocFec = P00EE7_A232DocFec[0];
                  A230DocMonCod = P00EE7_A230DocMonCod[0];
                  A511TipSigno = P00EE7_A511TipSigno[0];
                  A882DocAnticipos = P00EE7_A882DocAnticipos[0];
                  A929DocFecRef = P00EE7_A929DocFecRef[0];
                  A899DocDcto = P00EE7_A899DocDcto[0];
                  A511TipSigno = P00EE7_A511TipSigno[0];
                  if ( StringUtil.StrCmp(A231DocCliCod, AV11DocCliCod) == 0 )
                  {
                     if ( StringUtil.StrCmp(A941DocSts, "A") != 0 )
                     {
                        /* Using cursor P00EE9 */
                        pr_default.execute(5, new Object[] {A149TipCod, A24DocNum});
                        if ( (pr_default.getStatus(5) != 101) )
                        {
                           A927DocSubExonerado = P00EE9_A927DocSubExonerado[0];
                           A922DocSubSelectivo = P00EE9_A922DocSubSelectivo[0];
                           A921DocSubInafecto = P00EE9_A921DocSubInafecto[0];
                           A920DocSubAfecto = P00EE9_A920DocSubAfecto[0];
                        }
                        else
                        {
                           A920DocSubAfecto = 0;
                           A921DocSubInafecto = 0;
                           A922DocSubSelectivo = 0;
                           A927DocSubExonerado = 0;
                        }
                        pr_default.close(5);
                        A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                        A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                        AV38TipCod2 = A149TipCod;
                        AV20Fecha = A232DocFec;
                        AV28MonCod = A230DocMonCod;
                        AV40Total = NumberUtil.Round( (A919DocSub-(A918DocDscto+A882DocAnticipos))*A511TipSigno, 2);
                        if ( ( StringUtil.StrCmp(AV38TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV38TipCod2, "ND") == 0 ) )
                        {
                           AV20Fecha = A929DocFecRef;
                        }
                        GXt_decimal1 = AV8Cambio;
                        GXt_int2 = 2;
                        GXt_char3 = "V";
                        new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV20Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                        AV8Cambio = GXt_decimal1;
                        AV44TotalMN = ((AV28MonCod==1) ? AV40Total : NumberUtil.Round( AV40Total*AV8Cambio, 2));
                        AV43TotalME = ((AV28MonCod==1) ? NumberUtil.Round( AV40Total/ (decimal)(AV8Cambio), 2) : AV40Total);
                        AV45TotalVenta = (decimal)(AV45TotalVenta+AV44TotalMN);
                        AV46TotalVentaME = (decimal)(AV46TotalVentaME+AV43TotalME);
                     }
                  }
                  BRKEE7 = true;
                  pr_default.readNext(4);
               }
               AV32SDTVentaClientesITem.gxTpr_Clicod = AV11DocCliCod;
               AV32SDTVentaClientesITem.gxTpr_Clidsc = AV12DocCliDsc;
               AV32SDTVentaClientesITem.gxTpr_Importe = AV45TotalVenta;
               AV32SDTVentaClientesITem.gxTpr_Importe1 = AV46TotalVentaME;
               AV31SDTVentaClientes.Add(AV32SDTVentaClientesITem, 0);
               AV32SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
               if ( ! BRKEE7 )
               {
                  BRKEE7 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
            AV31SDTVentaClientes.Sort("[Importe]");
            AV41TotalGeneral = 0.00m;
            AV42TotalGeneralME = 0.00m;
            AV61GXV1 = 1;
            while ( AV61GXV1 <= AV31SDTVentaClientes.Count )
            {
               AV32SDTVentaClientesITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV31SDTVentaClientes.Item(AV61GXV1));
               AV11DocCliCod = AV32SDTVentaClientesITem.gxTpr_Clicod;
               AV12DocCliDsc = AV32SDTVentaClientesITem.gxTpr_Clidsc;
               AV45TotalVenta = AV32SDTVentaClientesITem.gxTpr_Importe;
               AV46TotalVentaME = AV32SDTVentaClientesITem.gxTpr_Importe1;
               HEE0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12DocCliDsc, "")), 121, Gx_line+3, 477, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 495, Gx_line+2, 602, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11DocCliCod, "")), 0, Gx_line+2, 105, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TotalVentaME, "ZZZZZZ,ZZZ,ZZ9.99")), 629, Gx_line+2, 736, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV41TotalGeneral = (decimal)(AV41TotalGeneral+AV45TotalVenta);
               AV42TotalGeneralME = (decimal)(AV42TotalGeneralME+AV46TotalVentaME);
               AV61GXV1 = (int)(AV61GXV1+1);
            }
            HEE0( false, 52) ;
            getPrinter().GxDrawLine(478, Gx_line+9, 766, Gx_line+9, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 375, Gx_line+17, 455, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 501, Gx_line+17, 602, Gx_line+32, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TotalGeneralME, "ZZZZZZ,ZZZ,ZZ9.99")), 629, Gx_line+17, 736, Gx_line+32, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+52);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HEE0( true, 0) ;
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

      protected void HEE0( bool bFoot ,
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
               getPrinter().GxDrawText("Resumen de Ventas por Cliente", 251, Gx_line+58, 519, Gx_line+78, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Documento", 151, Gx_line+146, 266, Gx_line+160, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de Cliente", 151, Gx_line+168, 238, Gx_line+182, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 151, Gx_line+211, 193, Gx_line+225, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 270, Gx_line+141, 613, Gx_line+165, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 270, Gx_line+163, 613, Gx_line+187, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV25Filtro4, "")), 270, Gx_line+206, 613, Gx_line+230, 0, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+246, 797, Gx_line+272, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+24, 769, Gx_line+39, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+43, 767, Gx_line+57, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+63, 769, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Cliente", 9, Gx_line+251, 93, Gx_line+265, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 181, Gx_line+251, 223, Gx_line+265, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta MN", 523, Gx_line+251, 613, Gx_line+265, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Del :", 269, Gx_line+80, 310, Gx_line+100, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19FDesde, "99/99/99"), 318, Gx_line+78, 392, Gx_line+102, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 394, Gx_line+80, 424, Gx_line+100, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV21FHasta, "99/99/99"), 428, Gx_line+78, 502, Gx_line+102, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Pais", 151, Gx_line+190, 176, Gx_line+204, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 270, Gx_line+184, 613, Gx_line+208, 0, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV27Logo)) ? AV51Logo_GXI : AV27Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+19, 176, Gx_line+97) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Expresado en :", 236, Gx_line+103, 363, Gx_line+123, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro5, "")), 369, Gx_line+101, 558, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total Venta ME", 660, Gx_line+251, 749, Gx_line+265, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+272);
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
         pr_default.close(5);
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV16Empresa = "";
         AV34Session = context.GetSession();
         AV15EmpDir = "";
         AV17EmpRUC = "";
         AV30Ruta = "";
         AV27Logo = "";
         AV51Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = "";
         AV26Filtro5 = "";
         scmdbuf = "";
         P00EE2_A149TipCod = new string[] {""} ;
         P00EE2_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         P00EE3_A159TipCCod = new int[1] ;
         P00EE3_n159TipCCod = new bool[] {false} ;
         P00EE3_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00EE4_A139PaiCod = new string[] {""} ;
         P00EE4_n139PaiCod = new bool[] {false} ;
         P00EE4_A1500PaiDsc = new string[] {""} ;
         A139PaiCod = "";
         A1500PaiDsc = "";
         P00EE5_A45CliCod = new string[] {""} ;
         P00EE5_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV18EstCod = "";
         A140EstCod = "";
         A231DocCliCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EE7_A24DocNum = new string[] {""} ;
         P00EE7_A941DocSts = new string[] {""} ;
         P00EE7_A231DocCliCod = new string[] {""} ;
         P00EE7_A149TipCod = new string[] {""} ;
         P00EE7_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EE7_A230DocMonCod = new int[1] ;
         P00EE7_A511TipSigno = new short[1] ;
         P00EE7_A882DocAnticipos = new decimal[1] ;
         P00EE7_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EE7_A946DocTipo = new string[] {""} ;
         P00EE7_A227DocVendCod = new int[1] ;
         P00EE7_A158ZonCod = new int[1] ;
         P00EE7_n158ZonCod = new bool[] {false} ;
         P00EE7_A139PaiCod = new string[] {""} ;
         P00EE7_n139PaiCod = new bool[] {false} ;
         P00EE7_A140EstCod = new string[] {""} ;
         P00EE7_n140EstCod = new bool[] {false} ;
         P00EE7_A159TipCCod = new int[1] ;
         P00EE7_n159TipCCod = new bool[] {false} ;
         P00EE7_A178TieCod = new int[1] ;
         P00EE7_n178TieCod = new bool[] {false} ;
         P00EE7_A887DocCliDsc = new string[] {""} ;
         P00EE7_A927DocSubExonerado = new decimal[1] ;
         P00EE7_A922DocSubSelectivo = new decimal[1] ;
         P00EE7_A921DocSubInafecto = new decimal[1] ;
         P00EE7_A920DocSubAfecto = new decimal[1] ;
         P00EE7_A899DocDcto = new decimal[1] ;
         A24DocNum = "";
         A929DocFecRef = DateTime.MinValue;
         A887DocCliDsc = "";
         AV11DocCliCod = "";
         AV12DocCliDsc = "";
         P00EE9_A927DocSubExonerado = new decimal[1] ;
         P00EE9_A922DocSubSelectivo = new decimal[1] ;
         P00EE9_A921DocSubInafecto = new decimal[1] ;
         P00EE9_A920DocSubAfecto = new decimal[1] ;
         AV38TipCod2 = "";
         AV20Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV32SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV31SDTVentaClientes = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV27Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrventasclientes__default(),
            new Object[][] {
                new Object[] {
               P00EE2_A149TipCod, P00EE2_A1910TipDsc
               }
               , new Object[] {
               P00EE3_A159TipCCod, P00EE3_A1905TipCDsc
               }
               , new Object[] {
               P00EE4_A139PaiCod, P00EE4_A1500PaiDsc
               }
               , new Object[] {
               P00EE5_A45CliCod, P00EE5_A161CliDsc
               }
               , new Object[] {
               P00EE7_A24DocNum, P00EE7_A941DocSts, P00EE7_A231DocCliCod, P00EE7_A149TipCod, P00EE7_A232DocFec, P00EE7_A230DocMonCod, P00EE7_A511TipSigno, P00EE7_A882DocAnticipos, P00EE7_A929DocFecRef, P00EE7_A946DocTipo,
               P00EE7_A227DocVendCod, P00EE7_A158ZonCod, P00EE7_n158ZonCod, P00EE7_A139PaiCod, P00EE7_n139PaiCod, P00EE7_A140EstCod, P00EE7_n140EstCod, P00EE7_A159TipCCod, P00EE7_n159TipCCod, P00EE7_A178TieCod,
               P00EE7_n178TieCod, P00EE7_A887DocCliDsc, P00EE7_A927DocSubExonerado, P00EE7_A922DocSubSelectivo, P00EE7_A921DocSubInafecto, P00EE7_A920DocSubAfecto, P00EE7_A899DocDcto
               }
               , new Object[] {
               P00EE9_A927DocSubExonerado, P00EE9_A922DocSubSelectivo, P00EE9_A921DocSubInafecto, P00EE9_A920DocSubAfecto
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
      private short AV9CheckRec ;
      private short A511TipSigno ;
      private int AV36TipCCod ;
      private int AV47VenCod ;
      private int AV48ZonCod ;
      private int AV35TieCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A159TipCCod ;
      private int A178TieCod ;
      private int A158ZonCod ;
      private int A227DocVendCod ;
      private int A230DocMonCod ;
      private int AV28MonCod ;
      private int GXt_int2 ;
      private int AV61GXV1 ;
      private int Gx_OldLine ;
      private decimal AV41TotalGeneral ;
      private decimal A882DocAnticipos ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal AV45TotalVenta ;
      private decimal AV46TotalVentaME ;
      private decimal AV44TotalMN ;
      private decimal AV43TotalME ;
      private decimal AV40Total ;
      private decimal AV8Cambio ;
      private decimal GXt_decimal1 ;
      private decimal AV42TotalGeneralME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10CliCod ;
      private string AV37TipCod ;
      private string AV29PaiCod ;
      private string AV39Tipo ;
      private string AV16Empresa ;
      private string AV15EmpDir ;
      private string AV17EmpRUC ;
      private string AV30Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string AV25Filtro4 ;
      private string AV26Filtro5 ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private string A1905TipCDsc ;
      private string A139PaiCod ;
      private string A1500PaiDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string AV18EstCod ;
      private string A140EstCod ;
      private string A231DocCliCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A887DocCliDsc ;
      private string AV11DocCliCod ;
      private string AV12DocCliDsc ;
      private string AV38TipCod2 ;
      private string GXt_char3 ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV19FDesde ;
      private DateTime AV21FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV20Fecha ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n139PaiCod ;
      private bool BRKEE7 ;
      private bool n158ZonCod ;
      private bool n140EstCod ;
      private bool n178TieCod ;
      private string AV51Logo_GXI ;
      private string AV27Logo ;
      private string Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private string aP2_TipCod ;
      private string aP3_PaiCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_Tipo ;
      private int aP7_VenCod ;
      private int aP8_ZonCod ;
      private int aP9_TieCod ;
      private short aP10_CheckRec ;
      private IDataStoreProvider pr_default ;
      private string[] P00EE2_A149TipCod ;
      private string[] P00EE2_A1910TipDsc ;
      private int[] P00EE3_A159TipCCod ;
      private bool[] P00EE3_n159TipCCod ;
      private string[] P00EE3_A1905TipCDsc ;
      private string[] P00EE4_A139PaiCod ;
      private bool[] P00EE4_n139PaiCod ;
      private string[] P00EE4_A1500PaiDsc ;
      private string[] P00EE5_A45CliCod ;
      private string[] P00EE5_A161CliDsc ;
      private string[] P00EE7_A24DocNum ;
      private string[] P00EE7_A941DocSts ;
      private string[] P00EE7_A231DocCliCod ;
      private string[] P00EE7_A149TipCod ;
      private DateTime[] P00EE7_A232DocFec ;
      private int[] P00EE7_A230DocMonCod ;
      private short[] P00EE7_A511TipSigno ;
      private decimal[] P00EE7_A882DocAnticipos ;
      private DateTime[] P00EE7_A929DocFecRef ;
      private string[] P00EE7_A946DocTipo ;
      private int[] P00EE7_A227DocVendCod ;
      private int[] P00EE7_A158ZonCod ;
      private bool[] P00EE7_n158ZonCod ;
      private string[] P00EE7_A139PaiCod ;
      private bool[] P00EE7_n139PaiCod ;
      private string[] P00EE7_A140EstCod ;
      private bool[] P00EE7_n140EstCod ;
      private int[] P00EE7_A159TipCCod ;
      private bool[] P00EE7_n159TipCCod ;
      private int[] P00EE7_A178TieCod ;
      private bool[] P00EE7_n178TieCod ;
      private string[] P00EE7_A887DocCliDsc ;
      private decimal[] P00EE7_A927DocSubExonerado ;
      private decimal[] P00EE7_A922DocSubSelectivo ;
      private decimal[] P00EE7_A921DocSubInafecto ;
      private decimal[] P00EE7_A920DocSubAfecto ;
      private decimal[] P00EE7_A899DocDcto ;
      private decimal[] P00EE9_A927DocSubExonerado ;
      private decimal[] P00EE9_A922DocSubSelectivo ;
      private decimal[] P00EE9_A921DocSubInafecto ;
      private decimal[] P00EE9_A920DocSubAfecto ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV31SDTVentaClientes ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV32SDTVentaClientesITem ;
   }

   public class rrventasclientes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EE7( IGxContext context ,
                                             int AV35TieCod ,
                                             int AV36TipCCod ,
                                             string AV18EstCod ,
                                             string AV10CliCod ,
                                             string AV37TipCod ,
                                             string AV29PaiCod ,
                                             int AV48ZonCod ,
                                             int AV47VenCod ,
                                             short AV9CheckRec ,
                                             string AV39Tipo ,
                                             int A178TieCod ,
                                             int A159TipCCod ,
                                             string A140EstCod ,
                                             string A231DocCliCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             int A158ZonCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV19FDesde ,
                                             DateTime AV21FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocNum], T1.[DocSts], T1.[DocCliCod] AS DocCliCod, T1.[TipCod], T1.[DocFec], T1.[DocMonCod], T3.[TipSigno], T1.[DocAnticipos], T1.[DocFecRef], T1.[DocTipo], T1.[DocVendCod], T2.[ZonCod], T2.[PaiCod], T2.[EstCod], T2.[TipCCod], T1.[TieCod], T2.[CliDsc] AS DocCliDsc, COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV19FDesde and T1.[DocFec] <= @AV21FHasta)");
         AddWhere(sWhereString, "(T1.[DocSts] <> 'A')");
         if ( ! (0==AV35TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV35TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV36TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV36TipCCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV18EstCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV10CliCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV37TipCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV29PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV29PaiCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV48ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV48ZonCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV47VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV47VenCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV9CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV39Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocCliCod]";
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
               case 4 :
                     return conditional_P00EE7(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] );
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EE2;
          prmP00EE2 = new Object[] {
          new ParDef("@AV37TipCod",GXType.NChar,3,0)
          };
          Object[] prmP00EE3;
          prmP00EE3 = new Object[] {
          new ParDef("@AV36TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00EE4;
          prmP00EE4 = new Object[] {
          new ParDef("@AV29PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP00EE5;
          prmP00EE5 = new Object[] {
          new ParDef("@AV10CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00EE9;
          prmP00EE9 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EE7;
          prmP00EE7 = new Object[] {
          new ParDef("@AV19FDesde",GXType.Date,8,0) ,
          new ParDef("@AV21FHasta",GXType.Date,8,0) ,
          new ParDef("@AV35TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV36TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV18EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV10CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV37TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV29PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV48ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV47VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EE2", "SELECT [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV37TipCod ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EE3", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV36TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EE4", "SELECT [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV29PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EE5", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV10CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EE7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EE9", "SELECT COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto FROM (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EE9,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 1);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((string[]) buf[13])[0] = rslt.getString(13, 4);
                ((bool[]) buf[14])[0] = rslt.wasNull(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 4);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                ((int[]) buf[17])[0] = rslt.getInt(15);
                ((bool[]) buf[18])[0] = rslt.wasNull(15);
                ((int[]) buf[19])[0] = rslt.getInt(16);
                ((bool[]) buf[20])[0] = rslt.wasNull(16);
                ((string[]) buf[21])[0] = rslt.getString(17, 100);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
