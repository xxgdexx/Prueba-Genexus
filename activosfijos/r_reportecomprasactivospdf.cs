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
namespace GeneXus.Programs.activosfijos {
   public class r_reportecomprasactivospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "activosfijos.r_reportecomprasactivospdf.aspx")), "activosfijos.r_reportecomprasactivospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "activosfijos.r_reportecomprasactivospdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "ACTClaCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV16ACTClaCod = gxfirstwebparm;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV27ACTGrupCod = GetPar( "ACTGrupCod");
                  AV8ACTActCod = GetPar( "ACTActCod");
                  AV11ActActItem = GetPar( "ActActItem");
                  AV38Ano = (short)(NumberUtil.Val( GetPar( "Ano"), "."));
                  AV69Mes = (short)(NumberUtil.Val( GetPar( "Mes"), "."));
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

      public r_reportecomprasactivospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportecomprasactivospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ACTClaCod ,
                           ref string aP1_ACTGrupCod ,
                           ref string aP2_ACTActCod ,
                           ref string aP3_ActActItem ,
                           ref short aP4_Ano ,
                           ref short aP5_Mes )
      {
         this.AV16ACTClaCod = aP0_ACTClaCod;
         this.AV27ACTGrupCod = aP1_ACTGrupCod;
         this.AV8ACTActCod = aP2_ACTActCod;
         this.AV11ActActItem = aP3_ActActItem;
         this.AV38Ano = aP4_Ano;
         this.AV69Mes = aP5_Mes;
         initialize();
         executePrivate();
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV69Mes;
      }

      public short executeUdp( ref string aP0_ACTClaCod ,
                               ref string aP1_ACTGrupCod ,
                               ref string aP2_ACTActCod ,
                               ref string aP3_ActActItem ,
                               ref short aP4_Ano )
      {
         execute(ref aP0_ACTClaCod, ref aP1_ACTGrupCod, ref aP2_ACTActCod, ref aP3_ActActItem, ref aP4_Ano, ref aP5_Mes);
         return AV69Mes ;
      }

      public void executeSubmit( ref string aP0_ACTClaCod ,
                                 ref string aP1_ACTGrupCod ,
                                 ref string aP2_ACTActCod ,
                                 ref string aP3_ActActItem ,
                                 ref short aP4_Ano ,
                                 ref short aP5_Mes )
      {
         r_reportecomprasactivospdf objr_reportecomprasactivospdf;
         objr_reportecomprasactivospdf = new r_reportecomprasactivospdf();
         objr_reportecomprasactivospdf.AV16ACTClaCod = aP0_ACTClaCod;
         objr_reportecomprasactivospdf.AV27ACTGrupCod = aP1_ACTGrupCod;
         objr_reportecomprasactivospdf.AV8ACTActCod = aP2_ACTActCod;
         objr_reportecomprasactivospdf.AV11ActActItem = aP3_ActActItem;
         objr_reportecomprasactivospdf.AV38Ano = aP4_Ano;
         objr_reportecomprasactivospdf.AV69Mes = aP5_Mes;
         objr_reportecomprasactivospdf.context.SetSubmitInitialConfig(context);
         objr_reportecomprasactivospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportecomprasactivospdf);
         aP0_ACTClaCod=this.AV16ACTClaCod;
         aP1_ACTGrupCod=this.AV27ACTGrupCod;
         aP2_ACTActCod=this.AV8ACTActCod;
         aP3_ActActItem=this.AV11ActActItem;
         aP4_Ano=this.AV38Ano;
         aP5_Mes=this.AV69Mes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportecomprasactivospdf)stateInfo).executePrivate();
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
            AV50Empresa = AV87Session.Get("Empresa");
            AV49EmpDir = AV87Session.Get("EmpDir");
            AV51EmpRUC = AV87Session.Get("EmpRUC");
            AV83Ruta = AV87Session.Get("RUTA") + "/Logo.jpg";
            AV68Logo = AV83Ruta;
            AV119Logo_GXI = GXDbFile.PathToUrl( AV83Ruta);
            AV95Titulo = "Reporte de Compra de Activos";
            GXt_char1 = AV40cMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV69Mes, out  GXt_char1) ;
            AV40cMes = ((AV69Mes==0) ? "" : GXt_char1);
            AV78Periodo = "Periodo : " + StringUtil.Trim( AV40cMes) + " " + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV54FechaC = "01/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV69Mes), 10, 0)) + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV38Ano), 10, 0));
            AV55FechaIni = context.localUtil.CToD( AV54FechaC, 2);
            GXt_date2 = AV56FechaUlt;
            new GeneXus.Programs.generales.pobtieneultimodiames(context ).execute(  AV55FechaIni, out  GXt_date2) ;
            AV56FechaUlt = GXt_date2;
            AV93Tipo = "D";
            AV65jAnoAnt = AV38Ano;
            AV66jMesAnt = AV69Mes;
            if ( AV69Mes == 12 )
            {
               AV66jMesAnt = 1;
               AV65jAnoAnt = (short)(AV38Ano-1);
            }
            else
            {
               AV66jMesAnt = (short)(AV69Mes-1);
            }
            AV106TValor = 0;
            AV108TValorOver = 0;
            AV109TValorTotal = 0;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV16ACTClaCod ,
                                                 AV27ACTGrupCod ,
                                                 AV8ACTActCod ,
                                                 AV11ActActItem ,
                                                 AV69Mes ,
                                                 A426ACTClaCod ,
                                                 A2103ACTGrupCod ,
                                                 A2100ACTActCod ,
                                                 A2104ActActItem ,
                                                 A2123ACTActFech ,
                                                 AV38Ano } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00FC2 */
            pr_default.execute(0, new Object[] {AV38Ano, AV16ACTClaCod, AV27ACTGrupCod, AV8ACTActCod, AV11ActActItem, AV69Mes});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A2114ACTSGrupCod = P00FC2_A2114ACTSGrupCod[0];
               A2123ACTActFech = P00FC2_A2123ACTActFech[0];
               A2104ActActItem = P00FC2_A2104ActActItem[0];
               A2100ACTActCod = P00FC2_A2100ACTActCod[0];
               A2103ACTGrupCod = P00FC2_A2103ACTGrupCod[0];
               A426ACTClaCod = P00FC2_A426ACTClaCod[0];
               n426ACTClaCod = P00FC2_n426ACTClaCod[0];
               A2143ACTDetFecIni = P00FC2_A2143ACTDetFecIni[0];
               A2134ACTActReg = P00FC2_A2134ACTActReg[0];
               A2118ACTActCodEQV = P00FC2_A2118ACTActCodEQV[0];
               A2155ACTSGrupDsc = P00FC2_A2155ACTSGrupDsc[0];
               A2122ACTActDsc = P00FC2_A2122ACTActDsc[0];
               A2156ACTSGrupPor = P00FC2_A2156ACTSGrupPor[0];
               A2123ACTActFech = P00FC2_A2123ACTActFech[0];
               A2134ACTActReg = P00FC2_A2134ACTActReg[0];
               A2118ACTActCodEQV = P00FC2_A2118ACTActCodEQV[0];
               A2122ACTActDsc = P00FC2_A2122ACTActDsc[0];
               A2155ACTSGrupDsc = P00FC2_A2155ACTSGrupDsc[0];
               A2156ACTSGrupPor = P00FC2_A2156ACTSGrupPor[0];
               AV10ACTActFech = A2123ACTActFech;
               AV19ACTDetFecIni = A2143ACTDetFecIni;
               AV114ACTActReg = A2134ACTActReg;
               AV115PrvDsc = "";
               AV116PrvCod = "";
               /* Execute user subroutine: 'PROVEEDOR' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV17ActCod = A2100ACTActCod;
               AV28ActItem = A2104ActActItem;
               AV18ActCodEQV = StringUtil.Trim( A2118ACTActCodEQV);
               AV29ACTSGrupDsc = StringUtil.Trim( A2155ACTSGrupDsc);
               AV26ActDsc = StringUtil.Trim( A2122ACTActDsc) + " - " + StringUtil.Trim( AV29ACTSGrupDsc);
               AV80Porcentaje = A2156ACTSGrupPor;
               AV110Valor = 0;
               /* Execute user subroutine: 'VALORACTIVO' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               AV110Valor = AV24ACTDetValorNeto;
               HFC0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 6, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV10ACTActFech, "99/99/99"), 9, Gx_line+3, 41, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ActCodEQV, "")), 584, Gx_line+3, 668, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV110Valor, "ZZZZZZ,ZZZ,ZZ9.99")), 1002, Gx_line+3, 1081, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26ActDsc, "")), 678, Gx_line+3, 969, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80Porcentaje, "ZZ9.99")), 1088, Gx_line+3, 1122, Gx_line+13, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV19ACTDetFecIni, "99/99/99"), 80, Gx_line+3, 112, Gx_line+14, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV116PrvCod, "@!")), 148, Gx_line+3, 227, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115PrvDsc, "")), 239, Gx_line+3, 575, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               AV106TValor = (decimal)(AV106TValor+AV110Valor);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            HFC0( false, 65) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV106TValor, "ZZZZZZ,ZZZ,ZZ9.99")), 1002, Gx_line+17, 1081, Gx_line+31, 2, 0, 0, 0) ;
            getPrinter().GxDrawLine(949, Gx_line+10, 1130, Gx_line+10, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("TOTAL GENERAL", 820, Gx_line+17, 913, Gx_line+31, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+65);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HFC0( true, 0) ;
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
         /* 'VALORACTIVO' Routine */
         returnInSub = false;
         AV24ACTDetValorNeto = 0;
         AV25ACTDetValorReparacion = 0;
         AV23ACTDetValorCompras = 0;
         /* Using cursor P00FC3 */
         pr_default.execute(1, new Object[] {AV17ActCod, AV28ActItem});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A2104ActActItem = P00FC3_A2104ActActItem[0];
            A2100ACTActCod = P00FC3_A2100ACTActCod[0];
            A2150ACTDetValorNeto = P00FC3_A2150ACTDetValorNeto[0];
            AV24ACTDetValorNeto = A2150ACTDetValorNeto;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'PROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P00FC4 */
         pr_default.execute(2, new Object[] {AV114ACTActReg});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A249ComRef = P00FC4_A249ComRef[0];
            A244PrvCod = P00FC4_A244PrvCod[0];
            A247PrvDsc = P00FC4_A247PrvDsc[0];
            A149TipCod = P00FC4_A149TipCod[0];
            A243ComCod = P00FC4_A243ComCod[0];
            AV116PrvCod = StringUtil.Trim( A244PrvCod);
            AV115PrvDsc = StringUtil.Trim( A247PrvDsc);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void HFC0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 1033, Gx_line+24, 1065, Gx_line+38, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 1033, Gx_line+42, 1077, Gx_line+56, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 1033, Gx_line+6, 1072, Gx_line+20, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1099, Gx_line+42, 1138, Gx_line+57, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1079, Gx_line+24, 1136, Gx_line+38, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1091, Gx_line+6, 1138, Gx_line+21, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("COD. ACTIVO", 597, Gx_line+84, 652, Gx_line+94, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA", 12, Gx_line+85, 40, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Empresa, "")), 8, Gx_line+14, 233, Gx_line+32, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51EmpRUC, "")), 8, Gx_line+31, 178, Gx_line+49, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78Periodo, "")), 441, Gx_line+44, 734, Gx_line+65, 1+256, 0, 0, 1) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("VALOR ACTIVO", 1005, Gx_line+85, 1067, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(56, Gx_line+74, 56, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(665, Gx_line+74, 665, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(1093, Gx_line+74, 1093, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("CONCEPTO", 793, Gx_line+84, 839, Gx_line+94, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+74, 1139, Gx_line+105, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95Titulo, "")), 391, Gx_line+16, 780, Gx_line+41, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 6, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("%", 1104, Gx_line+85, 1115, Gx_line+95, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(973, Gx_line+74, 973, Gx_line+104, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(140, Gx_line+74, 140, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("FECHA INIC.", 71, Gx_line+79, 124, Gx_line+89, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("DEPRECIACIÓN", 66, Gx_line+92, 132, Gx_line+102, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(583, Gx_line+74, 583, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(230, Gx_line+74, 230, Gx_line+105, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("R.U.C.", 167, Gx_line+86, 195, Gx_line+96, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("PROVEEDOR", 373, Gx_line+85, 426, Gx_line+95, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+106);
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
         AV50Empresa = "";
         AV87Session = context.GetSession();
         AV49EmpDir = "";
         AV51EmpRUC = "";
         AV83Ruta = "";
         AV68Logo = "";
         AV119Logo_GXI = "";
         AV95Titulo = "";
         AV40cMes = "";
         GXt_char1 = "";
         AV78Periodo = "";
         AV54FechaC = "";
         AV55FechaIni = DateTime.MinValue;
         AV56FechaUlt = DateTime.MinValue;
         GXt_date2 = DateTime.MinValue;
         AV93Tipo = "";
         scmdbuf = "";
         A426ACTClaCod = "";
         A2103ACTGrupCod = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
         A2123ACTActFech = DateTime.MinValue;
         P00FC2_A2114ACTSGrupCod = new string[] {""} ;
         P00FC2_A2123ACTActFech = new DateTime[] {DateTime.MinValue} ;
         P00FC2_A2104ActActItem = new string[] {""} ;
         P00FC2_A2100ACTActCod = new string[] {""} ;
         P00FC2_A2103ACTGrupCod = new string[] {""} ;
         P00FC2_A426ACTClaCod = new string[] {""} ;
         P00FC2_n426ACTClaCod = new bool[] {false} ;
         P00FC2_A2143ACTDetFecIni = new DateTime[] {DateTime.MinValue} ;
         P00FC2_A2134ACTActReg = new string[] {""} ;
         P00FC2_A2118ACTActCodEQV = new string[] {""} ;
         P00FC2_A2155ACTSGrupDsc = new string[] {""} ;
         P00FC2_A2122ACTActDsc = new string[] {""} ;
         P00FC2_A2156ACTSGrupPor = new decimal[1] ;
         A2114ACTSGrupCod = "";
         A2143ACTDetFecIni = DateTime.MinValue;
         A2134ACTActReg = "";
         A2118ACTActCodEQV = "";
         A2155ACTSGrupDsc = "";
         A2122ACTActDsc = "";
         AV10ACTActFech = DateTime.MinValue;
         AV19ACTDetFecIni = DateTime.MinValue;
         AV114ACTActReg = "";
         AV115PrvDsc = "";
         AV116PrvCod = "";
         AV17ActCod = "";
         AV28ActItem = "";
         AV18ActCodEQV = "";
         AV29ACTSGrupDsc = "";
         AV26ActDsc = "";
         P00FC3_A2104ActActItem = new string[] {""} ;
         P00FC3_A2100ACTActCod = new string[] {""} ;
         P00FC3_A2150ACTDetValorNeto = new decimal[1] ;
         P00FC4_A249ComRef = new string[] {""} ;
         P00FC4_A244PrvCod = new string[] {""} ;
         P00FC4_A247PrvDsc = new string[] {""} ;
         P00FC4_A149TipCod = new string[] {""} ;
         P00FC4_A243ComCod = new string[] {""} ;
         A249ComRef = "";
         A244PrvCod = "";
         A247PrvDsc = "";
         A149TipCod = "";
         A243ComCod = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.activosfijos.r_reportecomprasactivospdf__default(),
            new Object[][] {
                new Object[] {
               P00FC2_A2114ACTSGrupCod, P00FC2_A2123ACTActFech, P00FC2_A2104ActActItem, P00FC2_A2100ACTActCod, P00FC2_A2103ACTGrupCod, P00FC2_A426ACTClaCod, P00FC2_n426ACTClaCod, P00FC2_A2143ACTDetFecIni, P00FC2_A2134ACTActReg, P00FC2_A2118ACTActCodEQV,
               P00FC2_A2155ACTSGrupDsc, P00FC2_A2122ACTActDsc, P00FC2_A2156ACTSGrupPor
               }
               , new Object[] {
               P00FC3_A2104ActActItem, P00FC3_A2100ACTActCod, P00FC3_A2150ACTDetValorNeto
               }
               , new Object[] {
               P00FC4_A249ComRef, P00FC4_A244PrvCod, P00FC4_A247PrvDsc, P00FC4_A149TipCod, P00FC4_A243ComCod
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
      private short AV38Ano ;
      private short AV69Mes ;
      private short AV65jAnoAnt ;
      private short AV66jMesAnt ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal AV106TValor ;
      private decimal AV108TValorOver ;
      private decimal AV109TValorTotal ;
      private decimal A2156ACTSGrupPor ;
      private decimal AV80Porcentaje ;
      private decimal AV110Valor ;
      private decimal AV24ACTDetValorNeto ;
      private decimal AV25ACTDetValorReparacion ;
      private decimal AV23ACTDetValorCompras ;
      private decimal A2150ACTDetValorNeto ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV50Empresa ;
      private string AV49EmpDir ;
      private string AV51EmpRUC ;
      private string AV83Ruta ;
      private string AV95Titulo ;
      private string AV40cMes ;
      private string GXt_char1 ;
      private string AV54FechaC ;
      private string AV93Tipo ;
      private string scmdbuf ;
      private string A2134ACTActReg ;
      private string A2155ACTSGrupDsc ;
      private string AV114ACTActReg ;
      private string AV115PrvDsc ;
      private string AV116PrvCod ;
      private string AV29ACTSGrupDsc ;
      private string A249ComRef ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string Gx_time ;
      private DateTime AV55FechaIni ;
      private DateTime AV56FechaUlt ;
      private DateTime GXt_date2 ;
      private DateTime A2123ACTActFech ;
      private DateTime A2143ACTDetFecIni ;
      private DateTime AV10ACTActFech ;
      private DateTime AV19ACTDetFecIni ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n426ACTClaCod ;
      private bool returnInSub ;
      private string AV16ACTClaCod ;
      private string AV27ACTGrupCod ;
      private string AV8ACTActCod ;
      private string AV11ActActItem ;
      private string AV119Logo_GXI ;
      private string AV78Periodo ;
      private string A426ACTClaCod ;
      private string A2103ACTGrupCod ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string A2114ACTSGrupCod ;
      private string A2118ACTActCodEQV ;
      private string A2122ACTActDsc ;
      private string AV17ActCod ;
      private string AV28ActItem ;
      private string AV18ActCodEQV ;
      private string AV26ActDsc ;
      private string AV68Logo ;
      private IGxSession AV87Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ACTClaCod ;
      private string aP1_ACTGrupCod ;
      private string aP2_ACTActCod ;
      private string aP3_ActActItem ;
      private short aP4_Ano ;
      private short aP5_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P00FC2_A2114ACTSGrupCod ;
      private DateTime[] P00FC2_A2123ACTActFech ;
      private string[] P00FC2_A2104ActActItem ;
      private string[] P00FC2_A2100ACTActCod ;
      private string[] P00FC2_A2103ACTGrupCod ;
      private string[] P00FC2_A426ACTClaCod ;
      private bool[] P00FC2_n426ACTClaCod ;
      private DateTime[] P00FC2_A2143ACTDetFecIni ;
      private string[] P00FC2_A2134ACTActReg ;
      private string[] P00FC2_A2118ACTActCodEQV ;
      private string[] P00FC2_A2155ACTSGrupDsc ;
      private string[] P00FC2_A2122ACTActDsc ;
      private decimal[] P00FC2_A2156ACTSGrupPor ;
      private string[] P00FC3_A2104ActActItem ;
      private string[] P00FC3_A2100ACTActCod ;
      private decimal[] P00FC3_A2150ACTDetValorNeto ;
      private string[] P00FC4_A249ComRef ;
      private string[] P00FC4_A244PrvCod ;
      private string[] P00FC4_A247PrvDsc ;
      private string[] P00FC4_A149TipCod ;
      private string[] P00FC4_A243ComCod ;
   }

   public class r_reportecomprasactivospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FC2( IGxContext context ,
                                             string AV16ACTClaCod ,
                                             string AV27ACTGrupCod ,
                                             string AV8ACTActCod ,
                                             string AV11ActActItem ,
                                             short AV69Mes ,
                                             string A426ACTClaCod ,
                                             string A2103ACTGrupCod ,
                                             string A2100ACTActCod ,
                                             string A2104ActActItem ,
                                             DateTime A2123ACTActFech ,
                                             short AV38Ano )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ACTSGrupCod], T2.[ACTActFech], T1.[ActActItem], T1.[ACTActCod], T1.[ACTGrupCod], T1.[ACTClaCod], T1.[ACTDetFecIni], T2.[ACTActReg], T2.[ACTActCodEQV], T3.[ACTSGrupDsc], T2.[ACTActDsc], T3.[ACTSGrupPor] FROM (([ACTACTIVOSDET] T1 INNER JOIN [ACTACTIVOS] T2 ON T2.[ACTActCod] = T1.[ACTActCod]) LEFT JOIN [ACTSUBGRUPO] T3 ON T3.[ACTClaCod] = T1.[ACTClaCod] AND T3.[ACTGrupCod] = T1.[ACTGrupCod] AND T3.[ACTSGrupCod] = T1.[ACTSGrupCod])";
         AddWhere(sWhereString, "(YEAR(T2.[ACTActFech]) = @AV38Ano)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ACTClaCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTClaCod] = @AV16ACTClaCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27ACTGrupCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTGrupCod] = @AV27ACTGrupCod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8ACTActCod)) )
         {
            AddWhere(sWhereString, "(T1.[ACTActCod] = @AV8ACTActCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ActActItem)) )
         {
            AddWhere(sWhereString, "(T1.[ActActItem] = @AV11ActActItem)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV69Mes) )
         {
            AddWhere(sWhereString, "(MONTH(T2.[ACTActFech]) = @AV69Mes)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ACTActCod]";
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
               case 0 :
                     return conditional_P00FC2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FC3;
          prmP00FC3 = new Object[] {
          new ParDef("@AV17ActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV28ActItem",GXType.NVarChar,5,0)
          };
          Object[] prmP00FC4;
          prmP00FC4 = new Object[] {
          new ParDef("@AV114ACTActReg",GXType.NChar,10,0)
          };
          Object[] prmP00FC2;
          prmP00FC2 = new Object[] {
          new ParDef("@AV38Ano",GXType.Int16,4,0) ,
          new ParDef("@AV16ACTClaCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV27ACTGrupCod",GXType.NVarChar,5,0) ,
          new ParDef("@AV8ACTActCod",GXType.NVarChar,20,0) ,
          new ParDef("@AV11ActActItem",GXType.NVarChar,5,0) ,
          new ParDef("@AV69Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FC3", "SELECT [ActActItem], [ACTActCod], [ACTDetValorNeto] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @AV17ActCod and [ActActItem] = @AV28ActItem ORDER BY [ACTActCod], [ActActItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FC4", "SELECT [ComRef], [PrvCod], [PrvDsc], [TipCod], [ComCod] FROM [CPCOMPRAS] WHERE [ComRef] = @AV114ACTActReg ORDER BY [ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FC4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                return;
       }
    }

 }

}
