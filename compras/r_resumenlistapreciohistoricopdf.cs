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
   public class r_resumenlistapreciohistoricopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "compras.r_resumenlistapreciohistoricopdf.aspx")), "compras.r_resumenlistapreciohistoricopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "compras.r_resumenlistapreciohistoricopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "PrvCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV37PrvCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV45ProdCod = GetPar( "ProdCod");
                  AV49LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV30FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV31FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
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

      public r_resumenlistapreciohistoricopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenlistapreciohistoricopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref string aP1_ProdCod ,
                           ref int aP2_LinCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta )
      {
         this.AV37PrvCod = aP0_PrvCod;
         this.AV45ProdCod = aP1_ProdCod;
         this.AV49LinCod = aP2_LinCod;
         this.AV30FDesde = aP3_FDesde;
         this.AV31FHasta = aP4_FHasta;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV37PrvCod;
         aP1_ProdCod=this.AV45ProdCod;
         aP2_LinCod=this.AV49LinCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
      }

      public DateTime executeUdp( ref string aP0_PrvCod ,
                                  ref string aP1_ProdCod ,
                                  ref int aP2_LinCod ,
                                  ref DateTime aP3_FDesde )
      {
         execute(ref aP0_PrvCod, ref aP1_ProdCod, ref aP2_LinCod, ref aP3_FDesde, ref aP4_FHasta);
         return AV31FHasta ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref string aP1_ProdCod ,
                                 ref int aP2_LinCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta )
      {
         r_resumenlistapreciohistoricopdf objr_resumenlistapreciohistoricopdf;
         objr_resumenlistapreciohistoricopdf = new r_resumenlistapreciohistoricopdf();
         objr_resumenlistapreciohistoricopdf.AV37PrvCod = aP0_PrvCod;
         objr_resumenlistapreciohistoricopdf.AV45ProdCod = aP1_ProdCod;
         objr_resumenlistapreciohistoricopdf.AV49LinCod = aP2_LinCod;
         objr_resumenlistapreciohistoricopdf.AV30FDesde = aP3_FDesde;
         objr_resumenlistapreciohistoricopdf.AV31FHasta = aP4_FHasta;
         objr_resumenlistapreciohistoricopdf.context.SetSubmitInitialConfig(context);
         objr_resumenlistapreciohistoricopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenlistapreciohistoricopdf);
         aP0_PrvCod=this.AV37PrvCod;
         aP1_ProdCod=this.AV45ProdCod;
         aP2_LinCod=this.AV49LinCod;
         aP3_FDesde=this.AV30FDesde;
         aP4_FHasta=this.AV31FHasta;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenlistapreciohistoricopdf)stateInfo).executePrivate();
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
            AV38Empresa = AV43Session.Get("Empresa");
            AV39EmpDir = AV43Session.Get("EmpDir");
            AV40EmpRUC = AV43Session.Get("EmpRUC");
            AV41Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV42Logo = AV41Ruta;
            AV61Logo_GXI = GXDbFile.PathToUrl( AV41Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            AV25Filtro4 = AV30FDesde;
            AV26Filtro5 = AV31FHasta;
            /* Using cursor P00A92 */
            pr_default.execute(0, new Object[] {AV37PrvCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A244PrvCod = P00A92_A244PrvCod[0];
               A247PrvDsc = P00A92_A247PrvDsc[0];
               AV22Filtro1 = A247PrvDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV37PrvCod ,
                                                 AV45ProdCod ,
                                                 AV49LinCod ,
                                                 A287CPLisHisPrvCod ,
                                                 A286CPLisHisProdCod ,
                                                 A52LinCod ,
                                                 A288CPLisHisFecha ,
                                                 AV30FDesde ,
                                                 AV31FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00A93 */
            pr_default.execute(1, new Object[] {AV30FDesde, AV31FHasta, AV37PrvCod, AV45ProdCod, AV49LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               BRKA94 = false;
               A825CPLisHisProdDsc = P00A93_A825CPLisHisProdDsc[0];
               A286CPLisHisProdCod = P00A93_A286CPLisHisProdCod[0];
               A288CPLisHisFecha = P00A93_A288CPLisHisFecha[0];
               A52LinCod = P00A93_A52LinCod[0];
               n52LinCod = P00A93_n52LinCod[0];
               A287CPLisHisPrvCod = P00A93_A287CPLisHisPrvCod[0];
               A825CPLisHisProdDsc = P00A93_A825CPLisHisProdDsc[0];
               A52LinCod = P00A93_A52LinCod[0];
               n52LinCod = P00A93_n52LinCod[0];
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00A93_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) )
               {
                  BRKA94 = false;
                  A825CPLisHisProdDsc = P00A93_A825CPLisHisProdDsc[0];
                  A288CPLisHisFecha = P00A93_A288CPLisHisFecha[0];
                  A287CPLisHisPrvCod = P00A93_A287CPLisHisPrvCod[0];
                  A825CPLisHisProdDsc = P00A93_A825CPLisHisProdDsc[0];
                  BRKA94 = true;
                  pr_default.readNext(1);
               }
               AV51Codigo = A286CPLisHisProdCod;
               AV50Producto = StringUtil.Trim( A286CPLisHisProdCod) + " - " + StringUtil.Trim( A825CPLisHisProdDsc);
               /* Execute user subroutine: 'DETALLE' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRKA94 )
               {
                  BRKA94 = true;
                  pr_default.readNext(1);
               }
            }
            pr_default.close(1);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HA90( true, 0) ;
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV37PrvCod ,
                                              AV49LinCod ,
                                              A287CPLisHisPrvCod ,
                                              A52LinCod ,
                                              A288CPLisHisFecha ,
                                              AV30FDesde ,
                                              AV31FHasta ,
                                              AV51Codigo ,
                                              A286CPLisHisProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00A94 */
         pr_default.execute(2, new Object[] {AV51Codigo, AV30FDesde, AV31FHasta, AV37PrvCod, AV49LinCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A288CPLisHisFecha = P00A94_A288CPLisHisFecha[0];
            A286CPLisHisProdCod = P00A94_A286CPLisHisProdCod[0];
            A52LinCod = P00A94_A52LinCod[0];
            n52LinCod = P00A94_n52LinCod[0];
            A287CPLisHisPrvCod = P00A94_A287CPLisHisPrvCod[0];
            A824CPLisHisImpMN = P00A94_A824CPLisHisImpMN[0];
            A823CPLisHisImpME = P00A94_A823CPLisHisImpME[0];
            A826CPLisHisPrvDsc = P00A94_A826CPLisHisPrvDsc[0];
            A52LinCod = P00A94_A52LinCod[0];
            n52LinCod = P00A94_n52LinCod[0];
            A826CPLisHisPrvDsc = P00A94_A826CPLisHisPrvDsc[0];
            AV52Proveedor = A287CPLisHisPrvCod;
            AV53CPLisHisFecha = A288CPLisHisFecha;
            AV55CPLisHisImpMN = A824CPLisHisImpMN;
            AV54CPLisHisImpME = A823CPLisHisImpME;
            /* Execute user subroutine: 'ULTIMO PRECIO' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            HA90( false, 18) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A288CPLisHisFecha, "99/99/99"), 920, Gx_line+3, 967, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A823CPLisHisImpME, "ZZZZ,ZZZ,ZZ9.9999")), 1032, Gx_line+3, 1139, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A824CPLisHisImpMN, "ZZZZ,ZZZ,ZZ9.9999")), 947, Gx_line+3, 1054, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Producto, "")), 6, Gx_line+1, 298, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A826CPLisHisPrvDsc, "")), 307, Gx_line+1, 635, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV58FechaANT, "99/99/99"), 651, Gx_line+3, 698, Gx_line+18, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56PrecioANTMN, "ZZZZ,ZZZ,ZZ9.9999")), 700, Gx_line+3, 807, Gx_line+18, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57PrecioANTME, "ZZZZ,ZZZ,ZZ9.9999")), 790, Gx_line+3, 897, Gx_line+18, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+18);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S126( )
      {
         /* 'ULTIMO PRECIO' Routine */
         returnInSub = false;
         AV56PrecioANTMN = AV55CPLisHisImpMN;
         AV57PrecioANTME = AV54CPLisHisImpME;
         AV58FechaANT = AV53CPLisHisFecha;
         /* Using cursor P00A95 */
         pr_default.execute(3, new Object[] {AV51Codigo, AV52Proveedor, AV30FDesde});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A288CPLisHisFecha = P00A95_A288CPLisHisFecha[0];
            A286CPLisHisProdCod = P00A95_A286CPLisHisProdCod[0];
            A287CPLisHisPrvCod = P00A95_A287CPLisHisPrvCod[0];
            A824CPLisHisImpMN = P00A95_A824CPLisHisImpMN[0];
            A823CPLisHisImpME = P00A95_A823CPLisHisImpME[0];
            AV56PrecioANTMN = A824CPLisHisImpMN;
            AV57PrecioANTME = A823CPLisHisImpME;
            AV58FechaANT = A288CPLisHisFecha;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void HA90( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1007, Gx_line+33, 1039, Gx_line+47, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1007, Gx_line+51, 1051, Gx_line+65, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1007, Gx_line+16, 1046, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1075, Gx_line+51, 1114, Gx_line+66, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1052, Gx_line+33, 1112, Gx_line+47, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1067, Gx_line+16, 1114, Gx_line+31, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto", 13, Gx_line+120, 67, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+114, 1144, Gx_line+140, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Lista de Precios Historicos", 447, Gx_line+10, 779, Gx_line+30, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Proveedor", 314, Gx_line+120, 376, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Proveedor", 447, Gx_line+43, 509, Gx_line+57, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Desde", 447, Gx_line+65, 484, Gx_line+79, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Hasta", 447, Gx_line+85, 482, Gx_line+99, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 520, Gx_line+38, 863, Gx_line+62, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV25Filtro4, "99/99/99"), 520, Gx_line+59, 863, Gx_line+83, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV26Filtro5, "99/99/99"), 520, Gx_line+80, 863, Gx_line+104, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ult. Precio MN", 724, Gx_line+120, 805, Gx_line+134, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV42Logo)) ? AV61Logo_GXI : AV42Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 11, Gx_line+2, 166, Gx_line+78) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38Empresa, "")), 11, Gx_line+73, 240, Gx_line+91, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40EmpRUC, "")), 11, Gx_line+91, 185, Gx_line+109, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("F. Ult. Precio", 639, Gx_line+120, 712, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha Modif.", 909, Gx_line+120, 983, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio MN", 993, Gx_line+120, 1051, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Ult. Precio ME", 816, Gx_line+120, 896, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Precio ME", 1073, Gx_line+120, 1130, Gx_line+134, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+140);
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
         AV38Empresa = "";
         AV43Session = context.GetSession();
         AV39EmpDir = "";
         AV40EmpRUC = "";
         AV41Ruta = "";
         AV42Logo = "";
         AV61Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         AV25Filtro4 = DateTime.MinValue;
         AV26Filtro5 = DateTime.MinValue;
         scmdbuf = "";
         P00A92_A244PrvCod = new string[] {""} ;
         P00A92_A247PrvDsc = new string[] {""} ;
         A244PrvCod = "";
         A247PrvDsc = "";
         A287CPLisHisPrvCod = "";
         A286CPLisHisProdCod = "";
         A288CPLisHisFecha = DateTime.MinValue;
         P00A93_A825CPLisHisProdDsc = new string[] {""} ;
         P00A93_A286CPLisHisProdCod = new string[] {""} ;
         P00A93_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         P00A93_A52LinCod = new int[1] ;
         P00A93_n52LinCod = new bool[] {false} ;
         P00A93_A287CPLisHisPrvCod = new string[] {""} ;
         A825CPLisHisProdDsc = "";
         AV51Codigo = "";
         AV50Producto = "";
         P00A94_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         P00A94_A286CPLisHisProdCod = new string[] {""} ;
         P00A94_A52LinCod = new int[1] ;
         P00A94_n52LinCod = new bool[] {false} ;
         P00A94_A287CPLisHisPrvCod = new string[] {""} ;
         P00A94_A824CPLisHisImpMN = new decimal[1] ;
         P00A94_A823CPLisHisImpME = new decimal[1] ;
         P00A94_A826CPLisHisPrvDsc = new string[] {""} ;
         A826CPLisHisPrvDsc = "";
         AV52Proveedor = "";
         AV53CPLisHisFecha = DateTime.MinValue;
         AV58FechaANT = DateTime.MinValue;
         P00A95_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         P00A95_A286CPLisHisProdCod = new string[] {""} ;
         P00A95_A287CPLisHisPrvCod = new string[] {""} ;
         P00A95_A824CPLisHisImpMN = new decimal[1] ;
         P00A95_A823CPLisHisImpME = new decimal[1] ;
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV42Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_resumenlistapreciohistoricopdf__default(),
            new Object[][] {
                new Object[] {
               P00A92_A244PrvCod, P00A92_A247PrvDsc
               }
               , new Object[] {
               P00A93_A825CPLisHisProdDsc, P00A93_A286CPLisHisProdCod, P00A93_A288CPLisHisFecha, P00A93_A52LinCod, P00A93_n52LinCod, P00A93_A287CPLisHisPrvCod
               }
               , new Object[] {
               P00A94_A288CPLisHisFecha, P00A94_A286CPLisHisProdCod, P00A94_A52LinCod, P00A94_n52LinCod, P00A94_A287CPLisHisPrvCod, P00A94_A824CPLisHisImpMN, P00A94_A823CPLisHisImpME, P00A94_A826CPLisHisPrvDsc
               }
               , new Object[] {
               P00A95_A288CPLisHisFecha, P00A95_A286CPLisHisProdCod, P00A95_A287CPLisHisPrvCod, P00A95_A824CPLisHisImpMN, P00A95_A823CPLisHisImpME
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         Gx_time = context.localUtil.Time( );
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private int AV49LinCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int Gx_OldLine ;
      private decimal A824CPLisHisImpMN ;
      private decimal A823CPLisHisImpME ;
      private decimal AV55CPLisHisImpMN ;
      private decimal AV54CPLisHisImpME ;
      private decimal AV56PrecioANTMN ;
      private decimal AV57PrecioANTME ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV37PrvCod ;
      private string AV45ProdCod ;
      private string AV38Empresa ;
      private string AV39EmpDir ;
      private string AV40EmpRUC ;
      private string AV41Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A287CPLisHisPrvCod ;
      private string A286CPLisHisProdCod ;
      private string A825CPLisHisProdDsc ;
      private string AV51Codigo ;
      private string AV50Producto ;
      private string A826CPLisHisPrvDsc ;
      private string AV52Proveedor ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV30FDesde ;
      private DateTime AV31FHasta ;
      private DateTime AV25Filtro4 ;
      private DateTime AV26Filtro5 ;
      private DateTime A288CPLisHisFecha ;
      private DateTime AV53CPLisHisFecha ;
      private DateTime AV58FechaANT ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKA94 ;
      private bool n52LinCod ;
      private bool returnInSub ;
      private string AV61Logo_GXI ;
      private string AV42Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private string aP1_ProdCod ;
      private int aP2_LinCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00A92_A244PrvCod ;
      private string[] P00A92_A247PrvDsc ;
      private string[] P00A93_A825CPLisHisProdDsc ;
      private string[] P00A93_A286CPLisHisProdCod ;
      private DateTime[] P00A93_A288CPLisHisFecha ;
      private int[] P00A93_A52LinCod ;
      private bool[] P00A93_n52LinCod ;
      private string[] P00A93_A287CPLisHisPrvCod ;
      private DateTime[] P00A94_A288CPLisHisFecha ;
      private string[] P00A94_A286CPLisHisProdCod ;
      private int[] P00A94_A52LinCod ;
      private bool[] P00A94_n52LinCod ;
      private string[] P00A94_A287CPLisHisPrvCod ;
      private decimal[] P00A94_A824CPLisHisImpMN ;
      private decimal[] P00A94_A823CPLisHisImpME ;
      private string[] P00A94_A826CPLisHisPrvDsc ;
      private DateTime[] P00A95_A288CPLisHisFecha ;
      private string[] P00A95_A286CPLisHisProdCod ;
      private string[] P00A95_A287CPLisHisPrvCod ;
      private decimal[] P00A95_A824CPLisHisImpMN ;
      private decimal[] P00A95_A823CPLisHisImpME ;
   }

   public class r_resumenlistapreciohistoricopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00A93( IGxContext context ,
                                             string AV37PrvCod ,
                                             string AV45ProdCod ,
                                             int AV49LinCod ,
                                             string A287CPLisHisPrvCod ,
                                             string A286CPLisHisProdCod ,
                                             int A52LinCod ,
                                             DateTime A288CPLisHisFecha ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[ProdDsc] AS CPLisHisProdDsc, T1.[CPLisHisProdCod] AS CPLisHisProdCod, T1.[CPLisHisFecha], T2.[LinCod], T1.[CPLisHisPrvCod] AS CPLisHisPrvCod FROM ([CPLISTAPRECIOSHIS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CPLisHisProdCod])";
         AddWhere(sWhereString, "(T1.[CPLisHisFecha] >= @AV30FDesde)");
         AddWhere(sWhereString, "(T1.[CPLisHisFecha] <= @AV31FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPLisHisPrvCod] = @AV37PrvCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPLisHisProdCod] = @AV45ProdCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV49LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV49LinCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPLisHisProdCod], T2.[ProdDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00A94( IGxContext context ,
                                             string AV37PrvCod ,
                                             int AV49LinCod ,
                                             string A287CPLisHisPrvCod ,
                                             int A52LinCod ,
                                             DateTime A288CPLisHisFecha ,
                                             DateTime AV30FDesde ,
                                             DateTime AV31FHasta ,
                                             string AV51Codigo ,
                                             string A286CPLisHisProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[5];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CPLisHisFecha], T1.[CPLisHisProdCod] AS CPLisHisProdCod, T2.[LinCod], T1.[CPLisHisPrvCod] AS CPLisHisPrvCod, T1.[CPLisHisImpMN], T1.[CPLisHisImpME], T3.[PrvDsc] AS CPLisHisPrvDsc FROM (([CPLISTAPRECIOSHIS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CPLisHisProdCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T1.[CPLisHisPrvCod])";
         AddWhere(sWhereString, "(T1.[CPLisHisProdCod] = @AV51Codigo)");
         AddWhere(sWhereString, "(T1.[CPLisHisFecha] >= @AV30FDesde)");
         AddWhere(sWhereString, "(T1.[CPLisHisFecha] <= @AV31FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[CPLisHisPrvCod] = @AV37PrvCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV49LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV49LinCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CPLisHisProdCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00A93(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] );
               case 2 :
                     return conditional_P00A94(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00A92;
          prmP00A92 = new Object[] {
          new ParDef("@AV37PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00A95;
          prmP00A95 = new Object[] {
          new ParDef("@AV51Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV52Proveedor",GXType.NChar,20,0) ,
          new ParDef("@AV30FDesde",GXType.Date,8,0)
          };
          Object[] prmP00A93;
          prmP00A93 = new Object[] {
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0) ,
          new ParDef("@AV37PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV45ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV49LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00A94;
          prmP00A94 = new Object[] {
          new ParDef("@AV51Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV30FDesde",GXType.Date,8,0) ,
          new ParDef("@AV31FHasta",GXType.Date,8,0) ,
          new ParDef("@AV37PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV49LinCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00A92", "SELECT [PrvCod], [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @AV37PrvCod ORDER BY [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A92,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00A93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A93,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A94", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A94,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00A95", "SELECT [CPLisHisFecha], [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod, [CPLisHisImpMN], [CPLisHisImpME] FROM [CPLISTAPRECIOSHIS] WHERE ([CPLisHisProdCod] = @AV51Codigo and [CPLisHisPrvCod] = @AV52Proveedor) AND ([CPLisHisFecha] < @AV30FDesde) ORDER BY [CPLisHisProdCod], [CPLisHisPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A95,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                return;
             case 2 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                return;
             case 3 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
       }
    }

 }

}
