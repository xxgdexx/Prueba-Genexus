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
   public class rrresumenventas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenventas.aspx")), "rrresumenventas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenventas.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "TipCod2");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV30TipCod2 = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV55TipCCod2 = (int)(NumberUtil.Val( GetPar( "TipCCod2"), "."));
                  AV56DocConpCod2 = (int)(NumberUtil.Val( GetPar( "DocConpCod2"), "."));
                  AV57CliCod2 = GetPar( "CliCod2");
                  AV58MonCod2 = (int)(NumberUtil.Val( GetPar( "MonCod2"), "."));
                  AV14FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV15FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV54Serie = GetPar( "Serie");
                  AV59VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AV62Tipo = GetPar( "Tipo");
                  AV63TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
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

      public rrresumenventas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenventas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TipCod2 ,
                           ref int aP1_TipCCod2 ,
                           ref int aP2_DocConpCod2 ,
                           ref string aP3_CliCod2 ,
                           ref int aP4_MonCod2 ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta ,
                           ref string aP7_Serie ,
                           ref int aP8_VenCod ,
                           ref string aP9_Tipo ,
                           ref int aP10_TieCod )
      {
         this.AV30TipCod2 = aP0_TipCod2;
         this.AV55TipCCod2 = aP1_TipCCod2;
         this.AV56DocConpCod2 = aP2_DocConpCod2;
         this.AV57CliCod2 = aP3_CliCod2;
         this.AV58MonCod2 = aP4_MonCod2;
         this.AV14FDesde = aP5_FDesde;
         this.AV15FHasta = aP6_FHasta;
         this.AV54Serie = aP7_Serie;
         this.AV59VenCod = aP8_VenCod;
         this.AV62Tipo = aP9_Tipo;
         this.AV63TieCod = aP10_TieCod;
         initialize();
         executePrivate();
         aP0_TipCod2=this.AV30TipCod2;
         aP1_TipCCod2=this.AV55TipCCod2;
         aP2_DocConpCod2=this.AV56DocConpCod2;
         aP3_CliCod2=this.AV57CliCod2;
         aP4_MonCod2=this.AV58MonCod2;
         aP5_FDesde=this.AV14FDesde;
         aP6_FHasta=this.AV15FHasta;
         aP7_Serie=this.AV54Serie;
         aP8_VenCod=this.AV59VenCod;
         aP9_Tipo=this.AV62Tipo;
         aP10_TieCod=this.AV63TieCod;
      }

      public int executeUdp( ref string aP0_TipCod2 ,
                             ref int aP1_TipCCod2 ,
                             ref int aP2_DocConpCod2 ,
                             ref string aP3_CliCod2 ,
                             ref int aP4_MonCod2 ,
                             ref DateTime aP5_FDesde ,
                             ref DateTime aP6_FHasta ,
                             ref string aP7_Serie ,
                             ref int aP8_VenCod ,
                             ref string aP9_Tipo )
      {
         execute(ref aP0_TipCod2, ref aP1_TipCCod2, ref aP2_DocConpCod2, ref aP3_CliCod2, ref aP4_MonCod2, ref aP5_FDesde, ref aP6_FHasta, ref aP7_Serie, ref aP8_VenCod, ref aP9_Tipo, ref aP10_TieCod);
         return AV63TieCod ;
      }

      public void executeSubmit( ref string aP0_TipCod2 ,
                                 ref int aP1_TipCCod2 ,
                                 ref int aP2_DocConpCod2 ,
                                 ref string aP3_CliCod2 ,
                                 ref int aP4_MonCod2 ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta ,
                                 ref string aP7_Serie ,
                                 ref int aP8_VenCod ,
                                 ref string aP9_Tipo ,
                                 ref int aP10_TieCod )
      {
         rrresumenventas objrrresumenventas;
         objrrresumenventas = new rrresumenventas();
         objrrresumenventas.AV30TipCod2 = aP0_TipCod2;
         objrrresumenventas.AV55TipCCod2 = aP1_TipCCod2;
         objrrresumenventas.AV56DocConpCod2 = aP2_DocConpCod2;
         objrrresumenventas.AV57CliCod2 = aP3_CliCod2;
         objrrresumenventas.AV58MonCod2 = aP4_MonCod2;
         objrrresumenventas.AV14FDesde = aP5_FDesde;
         objrrresumenventas.AV15FHasta = aP6_FHasta;
         objrrresumenventas.AV54Serie = aP7_Serie;
         objrrresumenventas.AV59VenCod = aP8_VenCod;
         objrrresumenventas.AV62Tipo = aP9_Tipo;
         objrrresumenventas.AV63TieCod = aP10_TieCod;
         objrrresumenventas.context.SetSubmitInitialConfig(context);
         objrrresumenventas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenventas);
         aP0_TipCod2=this.AV30TipCod2;
         aP1_TipCCod2=this.AV55TipCCod2;
         aP2_DocConpCod2=this.AV56DocConpCod2;
         aP3_CliCod2=this.AV57CliCod2;
         aP4_MonCod2=this.AV58MonCod2;
         aP5_FDesde=this.AV14FDesde;
         aP6_FHasta=this.AV15FHasta;
         aP7_Serie=this.AV54Serie;
         aP8_VenCod=this.AV59VenCod;
         aP9_Tipo=this.AV62Tipo;
         aP10_TieCod=this.AV63TieCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenventas)stateInfo).executePrivate();
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
            AV39Empresa = AV43Session.Get("Empresa");
            AV40EmpDir = AV43Session.Get("EmpDir");
            AV41EmpRUC = AV43Session.Get("EmpRUC");
            AV42Ruta = AV43Session.Get("RUTA") + "/Logo.jpg";
            AV38Logo = AV42Ruta;
            AV66Logo_GXI = GXDbFile.PathToUrl( AV42Ruta);
            AV27TotalGeneral = 0.00m;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV63TieCod ,
                                                 AV30TipCod2 ,
                                                 AV55TipCCod2 ,
                                                 AV56DocConpCod2 ,
                                                 AV57CliCod2 ,
                                                 AV58MonCod2 ,
                                                 AV59VenCod ,
                                                 AV54Serie ,
                                                 AV62Tipo ,
                                                 A178TieCod ,
                                                 A149TipCod ,
                                                 A159TipCCod ,
                                                 A229DocConpCod ,
                                                 A231DocCliCod ,
                                                 A230DocMonCod ,
                                                 A227DocVendCod ,
                                                 A24DocNum ,
                                                 A946DocTipo ,
                                                 A232DocFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P009C3 */
            pr_default.execute(0, new Object[] {AV14FDesde, AV15FHasta, AV63TieCod, AV30TipCod2, AV55TipCCod2, AV56DocConpCod2, AV57CliCod2, AV58MonCod2, AV59VenCod, AV54Serie});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A232DocFec = P009C3_A232DocFec[0];
               A946DocTipo = P009C3_A946DocTipo[0];
               A24DocNum = P009C3_A24DocNum[0];
               A227DocVendCod = P009C3_A227DocVendCod[0];
               A230DocMonCod = P009C3_A230DocMonCod[0];
               A231DocCliCod = P009C3_A231DocCliCod[0];
               A229DocConpCod = P009C3_A229DocConpCod[0];
               A159TipCCod = P009C3_A159TipCCod[0];
               n159TipCCod = P009C3_n159TipCCod[0];
               A149TipCod = P009C3_A149TipCod[0];
               A178TieCod = P009C3_A178TieCod[0];
               n178TieCod = P009C3_n178TieCod[0];
               A941DocSts = P009C3_A941DocSts[0];
               A887DocCliDsc = P009C3_A887DocCliDsc[0];
               A511TipSigno = P009C3_A511TipSigno[0];
               A953DocVendDsc = P009C3_A953DocVendDsc[0];
               A1233MonAbr = P009C3_A1233MonAbr[0];
               n1233MonAbr = P009C3_n1233MonAbr[0];
               A306TipAbr = P009C3_A306TipAbr[0];
               A935DocRedondeo = P009C3_A935DocRedondeo[0];
               A934DocPorIVA = P009C3_A934DocPorIVA[0];
               A899DocDcto = P009C3_A899DocDcto[0];
               A927DocSubExonerado = P009C3_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009C3_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009C3_A921DocSubInafecto[0];
               A920DocSubAfecto = P009C3_A920DocSubAfecto[0];
               A932DocICBPER = P009C3_A932DocICBPER[0];
               A882DocAnticipos = P009C3_A882DocAnticipos[0];
               A953DocVendDsc = P009C3_A953DocVendDsc[0];
               A1233MonAbr = P009C3_A1233MonAbr[0];
               n1233MonAbr = P009C3_n1233MonAbr[0];
               A159TipCCod = P009C3_A159TipCCod[0];
               n159TipCCod = P009C3_n159TipCCod[0];
               A887DocCliDsc = P009C3_A887DocCliDsc[0];
               A511TipSigno = P009C3_A511TipSigno[0];
               A306TipAbr = P009C3_A306TipAbr[0];
               A927DocSubExonerado = P009C3_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009C3_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009C3_A921DocSubInafecto[0];
               A920DocSubAfecto = P009C3_A920DocSubAfecto[0];
               A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
               A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
               A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
               A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
               AV11TipCod = A149TipCod;
               AV29DocNum = A24DocNum;
               AV36DocSts = A941DocSts;
               AV21DocCliCod = A231DocCliCod;
               AV22DocCliDsc = A887DocCliDsc;
               AV35Signo = A511TipSigno;
               AV23TotalVenta = (decimal)(NumberUtil.Round( A948DocTot, 2)*AV35Signo);
               AV46CantProd = 0;
               AV45VenDsc = A953DocVendDsc;
               AV48ConpCod = A229DocConpCod;
               GXt_char1 = AV47ConpDsc;
               new GeneXus.Programs.contabilidad.pobtienecondicionpago(context ).execute( ref  AV48ConpCod, out  GXt_char1) ;
               AV47ConpDsc = GXt_char1;
               /* Execute user subroutine: 'CANTIDADPRODUCTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( StringUtil.StrCmp(AV36DocSts, "A") == 0 )
               {
                  AV21DocCliCod = "";
                  AV22DocCliDsc = "ANULADO";
                  AV35Signo = 1;
                  AV23TotalVenta = 0.00m;
               }
               H9C0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22DocCliDsc, "")), 191, Gx_line+3, 454, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV23TotalVenta, "ZZZZZZ,ZZZ,ZZ9.99")), 815, Gx_line+2, 922, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), 6, Gx_line+2, 45, Gx_line+16, 1, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), 44, Gx_line+2, 125, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A232DocFec, "99/99/99"), 131, Gx_line+2, 178, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), 772, Gx_line+2, 825, Gx_line+17, 1+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47ConpDsc, "")), 948, Gx_line+0, 1106, Gx_line+19, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45VenDsc, "")), 460, Gx_line+2, 698, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV46CantProd), "ZZZZZZZZZ9")), 680, Gx_line+2, 744, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
               AV27TotalGeneral = (decimal)(AV27TotalGeneral+AV23TotalVenta);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( ! (0==AV58MonCod2) )
            {
               H9C0( false, 31) ;
               getPrinter().GxDrawLine(768, Gx_line+7, 1107, Gx_line+7, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total General", 649, Gx_line+13, 729, Gx_line+27, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV27TotalGeneral, "ZZZZZZZZZ,ZZ9.99")), 821, Gx_line+14, 922, Gx_line+29, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+31);
            }
            H9C0( false, 44) ;
            getPrinter().GxDrawRect(319, Gx_line+20, 764, Gx_line+44, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(530, Gx_line+21, 530, Gx_line+44, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(647, Gx_line+21, 647, Gx_line+44, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Forma de Pago", 367, Gx_line+25, 456, Gx_line+39, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total MN", 559, Gx_line+25, 611, Gx_line+39, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total ME", 679, Gx_line+25, 730, Gx_line+39, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+44);
            /* Execute user subroutine: 'RESUMEN' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            H9C0( false, 29) ;
            getPrinter().GxDrawLine(527, Gx_line+4, 763, Gx_line+4, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General", 413, Gx_line+8, 493, Gx_line+22, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60TImpMN, "ZZZZZZ,ZZZ,ZZ9.99")), 530, Gx_line+8, 637, Gx_line+23, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61TImpME, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+8, 754, Gx_line+23, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+29);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H9C0( true, 0) ;
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
         /* 'CANTIDADPRODUCTOS' Routine */
         returnInSub = false;
         /* Optimized group. */
         /* Using cursor P009C4 */
         pr_default.execute(1, new Object[] {AV11TipCod, AV29DocNum});
         cV46CantProd = P009C4_AV46CantProd[0];
         pr_default.close(1);
         AV46CantProd = (long)(AV46CantProd+cV46CantProd*1);
         /* End optimized group. */
      }

      protected void S121( )
      {
         /* 'RESUMEN' Routine */
         returnInSub = false;
         AV60TImpMN = 0.00m;
         AV61TImpME = 0.00m;
         /* Using cursor P009C5 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A137Conpcod = P009C5_A137Conpcod[0];
            n137Conpcod = P009C5_n137Conpcod[0];
            A753ConpDsc = P009C5_A753ConpDsc[0];
            /* Using cursor P009C6 */
            pr_default.execute(3, new Object[] {n137Conpcod, A137Conpcod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A231DocCliCod = P009C6_A231DocCliCod[0];
               A149TipCod = P009C6_A149TipCod[0];
               A24DocNum = P009C6_A24DocNum[0];
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV49ForCod = A137Conpcod;
            AV50ForDsc = A753ConpDsc;
            AV52ImpMN = 0.00m;
            AV51ImpME = 0.00m;
            pr_default.dynParam(4, new Object[]{ new Object[]{
                                                 AV63TieCod ,
                                                 AV30TipCod2 ,
                                                 AV55TipCCod2 ,
                                                 AV56DocConpCod2 ,
                                                 AV57CliCod2 ,
                                                 AV58MonCod2 ,
                                                 AV59VenCod ,
                                                 AV54Serie ,
                                                 AV62Tipo ,
                                                 A178TieCod ,
                                                 A149TipCod ,
                                                 A159TipCCod ,
                                                 A229DocConpCod ,
                                                 A231DocCliCod ,
                                                 A230DocMonCod ,
                                                 A227DocVendCod ,
                                                 A24DocNum ,
                                                 A946DocTipo ,
                                                 A232DocFec ,
                                                 AV14FDesde ,
                                                 AV15FHasta ,
                                                 AV49ForCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT
                                                 }
            });
            /* Using cursor P009C8 */
            pr_default.execute(4, new Object[] {AV14FDesde, AV15FHasta, AV49ForCod, AV63TieCod, AV30TipCod2, AV55TipCCod2, AV56DocConpCod2, AV57CliCod2, AV58MonCod2, AV59VenCod, AV54Serie});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A232DocFec = P009C8_A232DocFec[0];
               A946DocTipo = P009C8_A946DocTipo[0];
               A24DocNum = P009C8_A24DocNum[0];
               A227DocVendCod = P009C8_A227DocVendCod[0];
               A230DocMonCod = P009C8_A230DocMonCod[0];
               A231DocCliCod = P009C8_A231DocCliCod[0];
               A229DocConpCod = P009C8_A229DocConpCod[0];
               A159TipCCod = P009C8_A159TipCCod[0];
               n159TipCCod = P009C8_n159TipCCod[0];
               A149TipCod = P009C8_A149TipCod[0];
               A178TieCod = P009C8_A178TieCod[0];
               n178TieCod = P009C8_n178TieCod[0];
               A511TipSigno = P009C8_A511TipSigno[0];
               A941DocSts = P009C8_A941DocSts[0];
               A935DocRedondeo = P009C8_A935DocRedondeo[0];
               A934DocPorIVA = P009C8_A934DocPorIVA[0];
               A899DocDcto = P009C8_A899DocDcto[0];
               A927DocSubExonerado = P009C8_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009C8_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009C8_A921DocSubInafecto[0];
               A920DocSubAfecto = P009C8_A920DocSubAfecto[0];
               A932DocICBPER = P009C8_A932DocICBPER[0];
               A882DocAnticipos = P009C8_A882DocAnticipos[0];
               A159TipCCod = P009C8_A159TipCCod[0];
               n159TipCCod = P009C8_n159TipCCod[0];
               A511TipSigno = P009C8_A511TipSigno[0];
               A927DocSubExonerado = P009C8_A927DocSubExonerado[0];
               A922DocSubSelectivo = P009C8_A922DocSubSelectivo[0];
               A921DocSubInafecto = P009C8_A921DocSubInafecto[0];
               A920DocSubAfecto = P009C8_A920DocSubAfecto[0];
               A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
               A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
               A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
               A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
               AV24Total = ((StringUtil.StrCmp(A941DocSts, "A")==0) ? (decimal)(0) : NumberUtil.Round( A948DocTot, 2)*A511TipSigno);
               AV53Moneda = A230DocMonCod;
               AV52ImpMN = (decimal)(AV52ImpMN+(((AV53Moneda==1) ? AV24Total : (decimal)(0))));
               AV51ImpME = (decimal)(AV51ImpME+(((AV53Moneda==1) ? (decimal)(0) : AV24Total)));
               pr_default.readNext(4);
            }
            pr_default.close(4);
            if ( ! (Convert.ToDecimal(0)==AV52ImpMN) || ! (Convert.ToDecimal(0)==AV51ImpME) )
            {
               H9C0( false, 19) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50ForDsc, "")), 330, Gx_line+1, 526, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52ImpMN, "ZZZZZZ,ZZZ,ZZ9.99")), 530, Gx_line+2, 637, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV51ImpME, "ZZZZZZ,ZZZ,ZZ9.99")), 647, Gx_line+2, 754, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
            AV60TImpMN = (decimal)(AV60TImpMN+AV52ImpMN);
            AV61TImpME = (decimal)(AV61TImpME+AV51ImpME);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void H9C0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 981, Gx_line+40, 1013, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 981, Gx_line+59, 1025, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 981, Gx_line+21, 1020, Gx_line+35, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Ventas", 443, Gx_line+67, 612, Gx_line+87, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+131, 1106, Gx_line+157, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1028, Gx_line+21, 1075, Gx_line+36, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1014, Gx_line+40, 1074, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1036, Gx_line+59, 1075, Gx_line+74, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 15, Gx_line+138, 38, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 197, Gx_line+138, 239, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Venta", 860, Gx_line+138, 929, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Doc.", 66, Gx_line+138, 109, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 130, Gx_line+138, 165, Gx_line+152, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Moneda", 775, Gx_line+136, 823, Gx_line+150, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV38Logo)) ? AV66Logo_GXI : AV38Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 9, Gx_line+11, 167, Gx_line+89) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39Empresa, "")), 9, Gx_line+93, 377, Gx_line+111, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41EmpRUC, "")), 9, Gx_line+110, 238, Gx_line+128, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Condición de Pago", 954, Gx_line+136, 1061, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Vendedor", 459, Gx_line+139, 516, Gx_line+153, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Total Art.", 703, Gx_line+136, 759, Gx_line+150, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 396, Gx_line+94, 436, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV14FDesde, "99/99/99"), 456, Gx_line+89, 530, Gx_line+113, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 556, Gx_line+94, 593, Gx_line+109, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV15FHasta, "99/99/99"), 607, Gx_line+89, 681, Gx_line+113, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+157);
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
         AV39Empresa = "";
         AV43Session = context.GetSession();
         AV40EmpDir = "";
         AV41EmpRUC = "";
         AV42Ruta = "";
         AV38Logo = "";
         AV66Logo_GXI = "";
         scmdbuf = "";
         A149TipCod = "";
         A231DocCliCod = "";
         A24DocNum = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         P009C3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009C3_A946DocTipo = new string[] {""} ;
         P009C3_A24DocNum = new string[] {""} ;
         P009C3_A227DocVendCod = new int[1] ;
         P009C3_A230DocMonCod = new int[1] ;
         P009C3_A231DocCliCod = new string[] {""} ;
         P009C3_A229DocConpCod = new int[1] ;
         P009C3_A159TipCCod = new int[1] ;
         P009C3_n159TipCCod = new bool[] {false} ;
         P009C3_A149TipCod = new string[] {""} ;
         P009C3_A178TieCod = new int[1] ;
         P009C3_n178TieCod = new bool[] {false} ;
         P009C3_A941DocSts = new string[] {""} ;
         P009C3_A887DocCliDsc = new string[] {""} ;
         P009C3_A511TipSigno = new short[1] ;
         P009C3_A953DocVendDsc = new string[] {""} ;
         P009C3_A1233MonAbr = new string[] {""} ;
         P009C3_n1233MonAbr = new bool[] {false} ;
         P009C3_A306TipAbr = new string[] {""} ;
         P009C3_A935DocRedondeo = new decimal[1] ;
         P009C3_A934DocPorIVA = new decimal[1] ;
         P009C3_A899DocDcto = new decimal[1] ;
         P009C3_A927DocSubExonerado = new decimal[1] ;
         P009C3_A922DocSubSelectivo = new decimal[1] ;
         P009C3_A921DocSubInafecto = new decimal[1] ;
         P009C3_A920DocSubAfecto = new decimal[1] ;
         P009C3_A932DocICBPER = new decimal[1] ;
         P009C3_A882DocAnticipos = new decimal[1] ;
         A941DocSts = "";
         A887DocCliDsc = "";
         A953DocVendDsc = "";
         A1233MonAbr = "";
         A306TipAbr = "";
         AV11TipCod = "";
         AV29DocNum = "";
         AV36DocSts = "";
         AV21DocCliCod = "";
         AV22DocCliDsc = "";
         AV45VenDsc = "";
         AV47ConpDsc = "";
         GXt_char1 = "";
         P009C4_AV46CantProd = new long[1] ;
         P009C5_A137Conpcod = new int[1] ;
         P009C5_n137Conpcod = new bool[] {false} ;
         P009C5_A753ConpDsc = new string[] {""} ;
         A753ConpDsc = "";
         P009C6_A231DocCliCod = new string[] {""} ;
         P009C6_A137Conpcod = new int[1] ;
         P009C6_n137Conpcod = new bool[] {false} ;
         P009C6_A149TipCod = new string[] {""} ;
         P009C6_A24DocNum = new string[] {""} ;
         AV50ForDsc = "";
         P009C8_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009C8_A946DocTipo = new string[] {""} ;
         P009C8_A24DocNum = new string[] {""} ;
         P009C8_A227DocVendCod = new int[1] ;
         P009C8_A230DocMonCod = new int[1] ;
         P009C8_A231DocCliCod = new string[] {""} ;
         P009C8_A229DocConpCod = new int[1] ;
         P009C8_A159TipCCod = new int[1] ;
         P009C8_n159TipCCod = new bool[] {false} ;
         P009C8_A149TipCod = new string[] {""} ;
         P009C8_A178TieCod = new int[1] ;
         P009C8_n178TieCod = new bool[] {false} ;
         P009C8_A511TipSigno = new short[1] ;
         P009C8_A941DocSts = new string[] {""} ;
         P009C8_A935DocRedondeo = new decimal[1] ;
         P009C8_A934DocPorIVA = new decimal[1] ;
         P009C8_A899DocDcto = new decimal[1] ;
         P009C8_A927DocSubExonerado = new decimal[1] ;
         P009C8_A922DocSubSelectivo = new decimal[1] ;
         P009C8_A921DocSubInafecto = new decimal[1] ;
         P009C8_A920DocSubAfecto = new decimal[1] ;
         P009C8_A932DocICBPER = new decimal[1] ;
         P009C8_A882DocAnticipos = new decimal[1] ;
         Gx_date = DateTime.MinValue;
         Gx_time = "";
         AV38Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenventas__default(),
            new Object[][] {
                new Object[] {
               P009C3_A232DocFec, P009C3_A946DocTipo, P009C3_A24DocNum, P009C3_A227DocVendCod, P009C3_A230DocMonCod, P009C3_A231DocCliCod, P009C3_A229DocConpCod, P009C3_A159TipCCod, P009C3_n159TipCCod, P009C3_A149TipCod,
               P009C3_A178TieCod, P009C3_n178TieCod, P009C3_A941DocSts, P009C3_A887DocCliDsc, P009C3_A511TipSigno, P009C3_A953DocVendDsc, P009C3_A1233MonAbr, P009C3_n1233MonAbr, P009C3_A306TipAbr, P009C3_A935DocRedondeo,
               P009C3_A934DocPorIVA, P009C3_A899DocDcto, P009C3_A927DocSubExonerado, P009C3_A922DocSubSelectivo, P009C3_A921DocSubInafecto, P009C3_A920DocSubAfecto, P009C3_A932DocICBPER, P009C3_A882DocAnticipos
               }
               , new Object[] {
               P009C4_AV46CantProd
               }
               , new Object[] {
               P009C5_A137Conpcod, P009C5_A753ConpDsc
               }
               , new Object[] {
               P009C6_A231DocCliCod, P009C6_A137Conpcod, P009C6_n137Conpcod, P009C6_A149TipCod, P009C6_A24DocNum
               }
               , new Object[] {
               P009C8_A232DocFec, P009C8_A946DocTipo, P009C8_A24DocNum, P009C8_A227DocVendCod, P009C8_A230DocMonCod, P009C8_A231DocCliCod, P009C8_A229DocConpCod, P009C8_A159TipCCod, P009C8_n159TipCCod, P009C8_A149TipCod,
               P009C8_A178TieCod, P009C8_n178TieCod, P009C8_A511TipSigno, P009C8_A941DocSts, P009C8_A935DocRedondeo, P009C8_A934DocPorIVA, P009C8_A899DocDcto, P009C8_A927DocSubExonerado, P009C8_A922DocSubSelectivo, P009C8_A921DocSubInafecto,
               P009C8_A920DocSubAfecto, P009C8_A932DocICBPER, P009C8_A882DocAnticipos
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
      private short A511TipSigno ;
      private short AV35Signo ;
      private int AV55TipCCod2 ;
      private int AV56DocConpCod2 ;
      private int AV58MonCod2 ;
      private int AV59VenCod ;
      private int AV63TieCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A178TieCod ;
      private int A159TipCCod ;
      private int A229DocConpCod ;
      private int A230DocMonCod ;
      private int A227DocVendCod ;
      private int AV48ConpCod ;
      private int Gx_OldLine ;
      private int A137Conpcod ;
      private int AV49ForCod ;
      private int AV53Moneda ;
      private long AV46CantProd ;
      private long cV46CantProd ;
      private decimal AV27TotalGeneral ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A899DocDcto ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A932DocICBPER ;
      private decimal A882DocAnticipos ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV23TotalVenta ;
      private decimal AV60TImpMN ;
      private decimal AV61TImpME ;
      private decimal AV52ImpMN ;
      private decimal AV51ImpME ;
      private decimal AV24Total ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV30TipCod2 ;
      private string AV57CliCod2 ;
      private string AV54Serie ;
      private string AV62Tipo ;
      private string AV39Empresa ;
      private string AV40EmpDir ;
      private string AV41EmpRUC ;
      private string AV42Ruta ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A231DocCliCod ;
      private string A24DocNum ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A887DocCliDsc ;
      private string A953DocVendDsc ;
      private string A1233MonAbr ;
      private string A306TipAbr ;
      private string AV11TipCod ;
      private string AV29DocNum ;
      private string AV36DocSts ;
      private string AV21DocCliCod ;
      private string AV22DocCliDsc ;
      private string AV45VenDsc ;
      private string AV47ConpDsc ;
      private string GXt_char1 ;
      private string A753ConpDsc ;
      private string AV50ForDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV14FDesde ;
      private DateTime AV15FHasta ;
      private DateTime A232DocFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n159TipCCod ;
      private bool n178TieCod ;
      private bool n1233MonAbr ;
      private bool returnInSub ;
      private bool n137Conpcod ;
      private string AV66Logo_GXI ;
      private string AV38Logo ;
      private string Logo ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_TipCod2 ;
      private int aP1_TipCCod2 ;
      private int aP2_DocConpCod2 ;
      private string aP3_CliCod2 ;
      private int aP4_MonCod2 ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private string aP7_Serie ;
      private int aP8_VenCod ;
      private string aP9_Tipo ;
      private int aP10_TieCod ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P009C3_A232DocFec ;
      private string[] P009C3_A946DocTipo ;
      private string[] P009C3_A24DocNum ;
      private int[] P009C3_A227DocVendCod ;
      private int[] P009C3_A230DocMonCod ;
      private string[] P009C3_A231DocCliCod ;
      private int[] P009C3_A229DocConpCod ;
      private int[] P009C3_A159TipCCod ;
      private bool[] P009C3_n159TipCCod ;
      private string[] P009C3_A149TipCod ;
      private int[] P009C3_A178TieCod ;
      private bool[] P009C3_n178TieCod ;
      private string[] P009C3_A941DocSts ;
      private string[] P009C3_A887DocCliDsc ;
      private short[] P009C3_A511TipSigno ;
      private string[] P009C3_A953DocVendDsc ;
      private string[] P009C3_A1233MonAbr ;
      private bool[] P009C3_n1233MonAbr ;
      private string[] P009C3_A306TipAbr ;
      private decimal[] P009C3_A935DocRedondeo ;
      private decimal[] P009C3_A934DocPorIVA ;
      private decimal[] P009C3_A899DocDcto ;
      private decimal[] P009C3_A927DocSubExonerado ;
      private decimal[] P009C3_A922DocSubSelectivo ;
      private decimal[] P009C3_A921DocSubInafecto ;
      private decimal[] P009C3_A920DocSubAfecto ;
      private decimal[] P009C3_A932DocICBPER ;
      private decimal[] P009C3_A882DocAnticipos ;
      private long[] P009C4_AV46CantProd ;
      private int[] P009C5_A137Conpcod ;
      private bool[] P009C5_n137Conpcod ;
      private string[] P009C5_A753ConpDsc ;
      private string[] P009C6_A231DocCliCod ;
      private int[] P009C6_A137Conpcod ;
      private bool[] P009C6_n137Conpcod ;
      private string[] P009C6_A149TipCod ;
      private string[] P009C6_A24DocNum ;
      private DateTime[] P009C8_A232DocFec ;
      private string[] P009C8_A946DocTipo ;
      private string[] P009C8_A24DocNum ;
      private int[] P009C8_A227DocVendCod ;
      private int[] P009C8_A230DocMonCod ;
      private string[] P009C8_A231DocCliCod ;
      private int[] P009C8_A229DocConpCod ;
      private int[] P009C8_A159TipCCod ;
      private bool[] P009C8_n159TipCCod ;
      private string[] P009C8_A149TipCod ;
      private int[] P009C8_A178TieCod ;
      private bool[] P009C8_n178TieCod ;
      private short[] P009C8_A511TipSigno ;
      private string[] P009C8_A941DocSts ;
      private decimal[] P009C8_A935DocRedondeo ;
      private decimal[] P009C8_A934DocPorIVA ;
      private decimal[] P009C8_A899DocDcto ;
      private decimal[] P009C8_A927DocSubExonerado ;
      private decimal[] P009C8_A922DocSubSelectivo ;
      private decimal[] P009C8_A921DocSubInafecto ;
      private decimal[] P009C8_A920DocSubAfecto ;
      private decimal[] P009C8_A932DocICBPER ;
      private decimal[] P009C8_A882DocAnticipos ;
   }

   public class rrresumenventas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009C3( IGxContext context ,
                                             int AV63TieCod ,
                                             string AV30TipCod2 ,
                                             int AV55TipCCod2 ,
                                             int AV56DocConpCod2 ,
                                             string AV57CliCod2 ,
                                             int AV58MonCod2 ,
                                             int AV59VenCod ,
                                             string AV54Serie ,
                                             string AV62Tipo ,
                                             int A178TieCod ,
                                             string A149TipCod ,
                                             int A159TipCCod ,
                                             int A229DocConpCod ,
                                             string A231DocCliCod ,
                                             int A230DocMonCod ,
                                             int A227DocVendCod ,
                                             string A24DocNum ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocFec], T1.[DocTipo], T1.[DocNum], T1.[DocVendCod] AS DocVendCod, T1.[DocMonCod] AS DocMonCod, T1.[DocCliCod] AS DocCliCod, T1.[DocConpCod], T4.[TipCCod], T1.[TipCod], T1.[TieCod], T1.[DocSts], T4.[CliDsc] AS DocCliDsc, T5.[TipSigno], T2.[VenDsc] AS DocVendDsc, T3.[MonAbr], T5.[TipAbr], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocDcto], COALESCE( T6.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T6.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T6.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T6.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocICBPER], T1.[DocAnticipos] FROM ((((([CLVENTAS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[DocVendCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[DocMonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T5 ON T5.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV14FDesde and T1.[DocFec] <= @AV15FHasta)");
         if ( ! (0==AV63TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV63TieCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TipCod2)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV30TipCod2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV55TipCCod2) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV55TipCCod2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (0==AV56DocConpCod2) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV56DocConpCod2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57CliCod2)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV57CliCod2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV58MonCod2) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV58MonCod2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV59VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV59VenCod)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV54Serie)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV62Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV62Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV62Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P009C8( IGxContext context ,
                                             int AV63TieCod ,
                                             string AV30TipCod2 ,
                                             int AV55TipCCod2 ,
                                             int AV56DocConpCod2 ,
                                             string AV57CliCod2 ,
                                             int AV58MonCod2 ,
                                             int AV59VenCod ,
                                             string AV54Serie ,
                                             string AV62Tipo ,
                                             int A178TieCod ,
                                             string A149TipCod ,
                                             int A159TipCCod ,
                                             int A229DocConpCod ,
                                             string A231DocCliCod ,
                                             int A230DocMonCod ,
                                             int A227DocVendCod ,
                                             string A24DocNum ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV14FDesde ,
                                             DateTime AV15FHasta ,
                                             int AV49ForCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[11];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocFec], T1.[DocTipo], T1.[DocNum], T1.[DocVendCod] AS DocVendCod, T1.[DocMonCod] AS DocMonCod, T1.[DocCliCod] AS DocCliCod, T1.[DocConpCod], T2.[TipCCod], T1.[TipCod], T1.[TieCod], T3.[TipSigno], T1.[DocSts], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocDcto], COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocICBPER], T1.[DocAnticipos] FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV14FDesde and T1.[DocFec] <= @AV15FHasta)");
         AddWhere(sWhereString, "(T1.[DocConpCod] = @AV49ForCod)");
         if ( ! (0==AV63TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV63TieCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TipCod2)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV30TipCod2)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! (0==AV55TipCCod2) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV55TipCCod2)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV56DocConpCod2) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV56DocConpCod2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57CliCod2)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV57CliCod2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV58MonCod2) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV58MonCod2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV59VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV59VenCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV54Serie)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV62Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV62Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV62Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
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
                     return conditional_P009C3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] );
               case 4 :
                     return conditional_P009C8(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (int)dynConstraints[21] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009C4;
          prmP009C4 = new Object[] {
          new ParDef("@AV11TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV29DocNum",GXType.NChar,12,0)
          };
          Object[] prmP009C5;
          prmP009C5 = new Object[] {
          };
          Object[] prmP009C6;
          prmP009C6 = new Object[] {
          new ParDef("@Conpcod",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmP009C3;
          prmP009C3 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV63TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV30TipCod2",GXType.NChar,3,0) ,
          new ParDef("@AV55TipCCod2",GXType.Int32,6,0) ,
          new ParDef("@AV56DocConpCod2",GXType.Int32,6,0) ,
          new ParDef("@AV57CliCod2",GXType.NChar,20,0) ,
          new ParDef("@AV58MonCod2",GXType.Int32,6,0) ,
          new ParDef("@AV59VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV54Serie",GXType.Char,3,0)
          };
          Object[] prmP009C8;
          prmP009C8 = new Object[] {
          new ParDef("@AV14FDesde",GXType.Date,8,0) ,
          new ParDef("@AV15FHasta",GXType.Date,8,0) ,
          new ParDef("@AV49ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV63TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV30TipCod2",GXType.NChar,3,0) ,
          new ParDef("@AV55TipCCod2",GXType.Int32,6,0) ,
          new ParDef("@AV56DocConpCod2",GXType.Int32,6,0) ,
          new ParDef("@AV57CliCod2",GXType.NChar,20,0) ,
          new ParDef("@AV58MonCod2",GXType.Int32,6,0) ,
          new ParDef("@AV59VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV54Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009C4", "SELECT COUNT(*) FROM [CLVENTASDET] WHERE [TipCod] = @AV11TipCod and [DocNum] = @AV29DocNum ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009C5", "SELECT [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009C6", "SELECT T1.[DocCliCod] AS DocCliCod, T2.[Conpcod], T1.[TipCod], T1.[DocNum] FROM ([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) WHERE T2.[Conpcod] = @Conpcod ORDER BY T2.[Conpcod], T1.[TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P009C8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009C8,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 1);
                ((string[]) buf[13])[0] = rslt.getString(12, 100);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((string[]) buf[16])[0] = rslt.getString(15, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(15);
                ((string[]) buf[18])[0] = rslt.getString(16, 5);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(25);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 12);
                return;
             case 4 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 3);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 1);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(21);
                return;
       }
    }

 }

}
