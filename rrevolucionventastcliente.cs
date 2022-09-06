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
   public class rrevolucionventastcliente : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrevolucionventastcliente.aspx")), "rrevolucionventastcliente.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrevolucionventastcliente.aspx")))) ;
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
               AV17Ano = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV18Ano2 = (short)(NumberUtil.Val( GetPar( "Ano2"), "."));
                  AV19TipoGrafico = GetPar( "TipoGrafico");
                  AV53Moneda = (int)(NumberUtil.Val( GetPar( "Moneda"), "."));
                  AV86MesDesde = (short)(NumberUtil.Val( GetPar( "MesDesde"), "."));
                  AV87MesHasta = (short)(NumberUtil.Val( GetPar( "MesHasta"), "."));
                  AV92TipoCliente = (int)(NumberUtil.Val( GetPar( "TipoCliente"), "."));
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

      public rrevolucionventastcliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrevolucionventastcliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Ano2 ,
                           ref string aP2_TipoGrafico ,
                           ref int aP3_Moneda ,
                           ref short aP4_MesDesde ,
                           ref short aP5_MesHasta ,
                           ref int aP6_TipoCliente )
      {
         this.AV17Ano = aP0_Ano;
         this.AV18Ano2 = aP1_Ano2;
         this.AV19TipoGrafico = aP2_TipoGrafico;
         this.AV53Moneda = aP3_Moneda;
         this.AV86MesDesde = aP4_MesDesde;
         this.AV87MesHasta = aP5_MesHasta;
         this.AV92TipoCliente = aP6_TipoCliente;
         initialize();
         executePrivate();
         aP0_Ano=this.AV17Ano;
         aP1_Ano2=this.AV18Ano2;
         aP2_TipoGrafico=this.AV19TipoGrafico;
         aP3_Moneda=this.AV53Moneda;
         aP4_MesDesde=this.AV86MesDesde;
         aP5_MesHasta=this.AV87MesHasta;
         aP6_TipoCliente=this.AV92TipoCliente;
      }

      public int executeUdp( ref short aP0_Ano ,
                             ref short aP1_Ano2 ,
                             ref string aP2_TipoGrafico ,
                             ref int aP3_Moneda ,
                             ref short aP4_MesDesde ,
                             ref short aP5_MesHasta )
      {
         execute(ref aP0_Ano, ref aP1_Ano2, ref aP2_TipoGrafico, ref aP3_Moneda, ref aP4_MesDesde, ref aP5_MesHasta, ref aP6_TipoCliente);
         return AV92TipoCliente ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Ano2 ,
                                 ref string aP2_TipoGrafico ,
                                 ref int aP3_Moneda ,
                                 ref short aP4_MesDesde ,
                                 ref short aP5_MesHasta ,
                                 ref int aP6_TipoCliente )
      {
         rrevolucionventastcliente objrrevolucionventastcliente;
         objrrevolucionventastcliente = new rrevolucionventastcliente();
         objrrevolucionventastcliente.AV17Ano = aP0_Ano;
         objrrevolucionventastcliente.AV18Ano2 = aP1_Ano2;
         objrrevolucionventastcliente.AV19TipoGrafico = aP2_TipoGrafico;
         objrrevolucionventastcliente.AV53Moneda = aP3_Moneda;
         objrrevolucionventastcliente.AV86MesDesde = aP4_MesDesde;
         objrrevolucionventastcliente.AV87MesHasta = aP5_MesHasta;
         objrrevolucionventastcliente.AV92TipoCliente = aP6_TipoCliente;
         objrrevolucionventastcliente.context.SetSubmitInitialConfig(context);
         objrrevolucionventastcliente.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrevolucionventastcliente);
         aP0_Ano=this.AV17Ano;
         aP1_Ano2=this.AV18Ano2;
         aP2_TipoGrafico=this.AV19TipoGrafico;
         aP3_Moneda=this.AV53Moneda;
         aP4_MesDesde=this.AV86MesDesde;
         aP5_MesHasta=this.AV87MesHasta;
         aP6_TipoCliente=this.AV92TipoCliente;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrevolucionventastcliente)stateInfo).executePrivate();
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
            AV24Empresa = AV91Session.Get("Empresa");
            AV23EmpDir = AV91Session.Get("EmpDir");
            AV89EmpRUC = AV91Session.Get("EmpRUC");
            AV90Ruta = AV91Session.Get("RUTA") + "/Logo.jpg";
            AV88Logo = AV90Ruta;
            AV95Logo_GXI = GXDbFile.PathToUrl( AV90Ruta);
            HES0( false, 99) ;
            getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Evolución de Ventas por Tipo de Cliente", 400, Gx_line+25, 739, Gx_line+45, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Hora:", 1001, Gx_line+32, 1033, Gx_line+46, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Fecha:", 1001, Gx_line+15, 1040, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Página:", 1001, Gx_line+51, 1045, Gx_line+65, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 1054, Gx_line+51, 1093, Gx_line+66, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 1028, Gx_line+32, 1092, Gx_line+47, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 1046, Gx_line+15, 1093, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Año :", 502, Gx_line+52, 548, Gx_line+72, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Ano), "ZZZ9")), 570, Gx_line+52, 609, Gx_line+73, 2+256, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV88Logo)) ? AV95Logo_GXI : AV88Logo);
            getPrinter().GxDrawBitMap(sImgUrl, 18, Gx_line+4, 167, Gx_line+74) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Empresa, "")), 17, Gx_line+77, 388, Gx_line+95, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+99);
            HES0( false, 55) ;
            getPrinter().GxDrawRect(0, Gx_line+27, 1153, Gx_line+55, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(170, Gx_line+27, 170, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(251, Gx_line+27, 251, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(320, Gx_line+27, 320, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(391, Gx_line+27, 391, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(461, Gx_line+27, 461, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(884, Gx_line+27, 884, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(816, Gx_line+27, 816, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(744, Gx_line+27, 744, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(666, Gx_line+27, 666, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(530, Gx_line+27, 530, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(954, Gx_line+27, 954, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(1024, Gx_line+27, 1024, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(1108, Gx_line+27, 1108, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Cliente", 41, Gx_line+34, 120, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Enero", 193, Gx_line+34, 224, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Febrero", 263, Gx_line+34, 306, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Marzo", 336, Gx_line+34, 369, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Abril", 410, Gx_line+34, 437, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Mayo", 480, Gx_line+34, 509, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Junio", 550, Gx_line+34, 578, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Agosto", 684, Gx_line+34, 721, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Septiembre", 751, Gx_line+34, 811, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Octubre", 831, Gx_line+34, 874, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Noviembre", 890, Gx_line+34, 947, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Diciembre", 965, Gx_line+34, 1018, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total", 1050, Gx_line+34, 1078, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("%", 1123, Gx_line+35, 1137, Gx_line+48, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Año :", 494, Gx_line+6, 531, Gx_line+24, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18Ano2), "ZZZ9")), 561, Gx_line+6, 591, Gx_line+24, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(595, Gx_line+27, 595, Gx_line+55, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Julio", 613, Gx_line+34, 638, Gx_line+47, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+0, 1153, Gx_line+28, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+55);
            AV11UrlCliente = "";
            AV12UrlAno2 = "";
            AV13UrlAno1 = "";
            /* Execute user subroutine: 'AGREGADATOSGRID2' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV99GXV1 = 1;
            while ( AV99GXV1 <= AV9SdtTabla.Count )
            {
               AV10SdtTablaItem = ((SdtSdtTabla_SdtCuentaItem)AV9SdtTabla.Item(AV99GXV1));
               AV54Codigo2 = AV10SdtTablaItem.gxTpr_Tabitem;
               AV55Nombre2 = AV10SdtTablaItem.gxTpr_Tabnombre;
               AV56nEnero2 = AV10SdtTablaItem.gxTpr_Tabmes11;
               AV57nFebrero2 = AV10SdtTablaItem.gxTpr_Tabmes22;
               AV58nMarzo2 = AV10SdtTablaItem.gxTpr_Tabmes33;
               AV59nAbril2 = AV10SdtTablaItem.gxTpr_Tabmes44;
               AV60nMayo2 = AV10SdtTablaItem.gxTpr_Tabmes55;
               AV61nJunio2 = AV10SdtTablaItem.gxTpr_Tabmes66;
               AV62nJulio2 = AV10SdtTablaItem.gxTpr_Tabmes77;
               AV63nAgosto2 = AV10SdtTablaItem.gxTpr_Tabmes88;
               AV64nSeptiembre2 = AV10SdtTablaItem.gxTpr_Tabmes99;
               AV65nOctubre2 = AV10SdtTablaItem.gxTpr_Tabmes1010;
               AV66nNoviembre2 = AV10SdtTablaItem.gxTpr_Tabmes01111;
               AV67nDiciembre2 = AV10SdtTablaItem.gxTpr_Tabmes01212;
               AV68nTotal2 = AV10SdtTablaItem.gxTpr_Tabtotal2;
               AV69Por2 = ((AV52nTotalGeneral2==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV68nTotal2/ (decimal)(AV52nTotalGeneral2))*100, 2));
               HES0( false, 23) ;
               getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Nombre2, "")), 0, Gx_line+3, 171, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV56nEnero2, "ZZZZZZ,ZZZ,ZZ9.99")), 159, Gx_line+4, 249, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV57nFebrero2, "ZZZZZZ,ZZZ,ZZ9.99")), 228, Gx_line+4, 318, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV58nMarzo2, "ZZZZZZ,ZZZ,ZZ9.99")), 298, Gx_line+4, 388, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV59nAbril2, "ZZZZZZ,ZZZ,ZZ9.99")), 369, Gx_line+4, 459, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV60nMayo2, "ZZZZZZ,ZZZ,ZZ9.99")), 438, Gx_line+4, 528, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV62nJulio2, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+4, 663, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV63nAgosto2, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+4, 742, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV64nSeptiembre2, "ZZZZZZ,ZZZ,ZZ9.99")), 724, Gx_line+4, 814, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV65nOctubre2, "ZZZZZZ,ZZZ,ZZ9.99")), 791, Gx_line+4, 881, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV66nNoviembre2, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+4, 950, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV67nDiciembre2, "ZZZZZZ,ZZZ,ZZ9.99")), 930, Gx_line+4, 1020, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV68nTotal2, "ZZZZZZ,ZZZ,ZZ9.99")), 1014, Gx_line+4, 1104, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV69Por2, "ZZZZZZ,ZZZ,ZZ9.99")), 1058, Gx_line+4, 1148, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV61nJunio2, "ZZZZZZ,ZZZ,ZZ9.99")), 501, Gx_line+4, 591, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               AV99GXV1 = (int)(AV99GXV1+1);
            }
            HES0( false, 86) ;
            getPrinter().GxDrawLine(170, Gx_line+58, 170, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(251, Gx_line+58, 251, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(320, Gx_line+58, 320, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(391, Gx_line+58, 391, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(461, Gx_line+58, 461, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(884, Gx_line+58, 884, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(816, Gx_line+58, 816, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(744, Gx_line+58, 744, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(666, Gx_line+58, 666, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(530, Gx_line+58, 530, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(954, Gx_line+58, 954, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(1024, Gx_line+58, 1024, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(1108, Gx_line+58, 1108, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Cliente", 41, Gx_line+66, 120, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Enero", 193, Gx_line+66, 224, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Febrero", 263, Gx_line+66, 306, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Marzo", 336, Gx_line+66, 369, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Abril", 410, Gx_line+66, 437, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Mayo", 480, Gx_line+66, 509, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Junio", 550, Gx_line+66, 578, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Agosto", 684, Gx_line+66, 721, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Septiembre", 751, Gx_line+66, 811, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Octubre", 831, Gx_line+66, 874, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Noviembre", 890, Gx_line+66, 947, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Diciembre", 965, Gx_line+66, 1018, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Total", 1050, Gx_line+66, 1078, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("%", 1123, Gx_line+67, 1137, Gx_line+80, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(595, Gx_line+58, 595, Gx_line+86, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText("Julio", 613, Gx_line+66, 638, Gx_line+79, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17Ano), "ZZZ9")), 561, Gx_line+36, 591, Gx_line+54, 2+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 10, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Año :", 494, Gx_line+36, 531, Gx_line+54, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+58, 1153, Gx_line+86, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            getPrinter().GxDrawRect(0, Gx_line+31, 1153, Gx_line+59, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+86);
            AV100GXV2 = 1;
            while ( AV100GXV2 <= AV9SdtTabla.Count )
            {
               AV10SdtTablaItem = ((SdtSdtTabla_SdtCuentaItem)AV9SdtTabla.Item(AV100GXV2));
               AV70Codigo = AV10SdtTablaItem.gxTpr_Tabitem;
               AV71Nombre = AV10SdtTablaItem.gxTpr_Tabnombre;
               AV72nEnero = AV10SdtTablaItem.gxTpr_Tabmes1;
               AV73nFebrero = AV10SdtTablaItem.gxTpr_Tabmes2;
               AV74nMarzo = AV10SdtTablaItem.gxTpr_Tabmes3;
               AV75nAbril = AV10SdtTablaItem.gxTpr_Tabmes4;
               AV76nMayo = AV10SdtTablaItem.gxTpr_Tabmes5;
               AV77nJunio = AV10SdtTablaItem.gxTpr_Tabmes6;
               AV78nJulio = AV10SdtTablaItem.gxTpr_Tabmes7;
               AV79nAgosto = AV10SdtTablaItem.gxTpr_Tabmes8;
               AV80nSeptiembre = AV10SdtTablaItem.gxTpr_Tabmes9;
               AV82nOctubre = AV10SdtTablaItem.gxTpr_Tabmes10;
               AV81nNoviembre = AV10SdtTablaItem.gxTpr_Tabmes011;
               AV83nDiciembre = AV10SdtTablaItem.gxTpr_Tabmes012;
               AV84nTotal = AV10SdtTablaItem.gxTpr_Tabtotal1;
               AV85Por = ((AV38nTotalGeneral==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV84nTotal/ (decimal)(AV38nTotalGeneral))*100, 2));
               HES0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 159, Gx_line+3, 249, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 228, Gx_line+3, 318, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 298, Gx_line+3, 388, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 369, Gx_line+3, 459, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 438, Gx_line+3, 528, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 663, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+3, 742, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80nSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 724, Gx_line+3, 814, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82nOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 791, Gx_line+3, 881, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81nNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+3, 950, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83nDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 930, Gx_line+3, 1020, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84nTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1014, Gx_line+3, 1104, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 501, Gx_line+3, 591, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Nombre, "")), 0, Gx_line+2, 171, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85Por, "ZZZZZZ,ZZZ,ZZ9.99")), 1058, Gx_line+3, 1148, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               AV70Codigo = 99;
               AV71Nombre = "% Crecimiento";
               AV72nEnero = ((AV10SdtTablaItem.gxTpr_Tabmes11==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes1/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes11))*100, 2));
               AV73nFebrero = ((AV10SdtTablaItem.gxTpr_Tabmes22==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes2/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes22))*100, 2));
               AV74nMarzo = ((AV10SdtTablaItem.gxTpr_Tabmes33==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes3/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes33))*100, 2));
               AV75nAbril = ((AV10SdtTablaItem.gxTpr_Tabmes44==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes4/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes44))*100, 2));
               AV76nMayo = ((AV10SdtTablaItem.gxTpr_Tabmes55==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes5/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes55))*100, 2));
               AV77nJunio = ((AV10SdtTablaItem.gxTpr_Tabmes66==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes6/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes66))*100, 2));
               AV78nJulio = ((AV10SdtTablaItem.gxTpr_Tabmes77==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes7/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes77))*100, 2));
               AV79nAgosto = ((AV10SdtTablaItem.gxTpr_Tabmes88==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes8/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes88))*100, 2));
               AV80nSeptiembre = ((AV10SdtTablaItem.gxTpr_Tabmes99==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes9/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes99))*100, 2));
               AV82nOctubre = ((AV10SdtTablaItem.gxTpr_Tabmes1010==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes10/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes1010))*100, 2));
               AV81nNoviembre = ((AV10SdtTablaItem.gxTpr_Tabmes01111==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes011/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes01111))*100, 2));
               AV83nDiciembre = ((AV10SdtTablaItem.gxTpr_Tabmes01212==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabmes012/ (decimal)(AV10SdtTablaItem.gxTpr_Tabmes01212))*100, 2));
               AV84nTotal = ((AV10SdtTablaItem.gxTpr_Tabtotal2==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( (AV10SdtTablaItem.gxTpr_Tabtotal1/ (decimal)(AV10SdtTablaItem.gxTpr_Tabtotal2))*100, 2));
               AV85Por = 0;
               HES0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV72nEnero, "ZZZZZZ,ZZZ,ZZ9.99")), 159, Gx_line+3, 249, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV73nFebrero, "ZZZZZZ,ZZZ,ZZ9.99")), 228, Gx_line+3, 318, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV74nMarzo, "ZZZZZZ,ZZZ,ZZ9.99")), 298, Gx_line+3, 388, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV75nAbril, "ZZZZZZ,ZZZ,ZZ9.99")), 369, Gx_line+3, 459, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV76nMayo, "ZZZZZZ,ZZZ,ZZ9.99")), 438, Gx_line+3, 528, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV78nJulio, "ZZZZZZ,ZZZ,ZZ9.99")), 573, Gx_line+3, 663, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV79nAgosto, "ZZZZZZ,ZZZ,ZZ9.99")), 652, Gx_line+3, 742, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV80nSeptiembre, "ZZZZZZ,ZZZ,ZZ9.99")), 724, Gx_line+3, 814, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV82nOctubre, "ZZZZZZ,ZZZ,ZZ9.99")), 791, Gx_line+3, 881, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV81nNoviembre, "ZZZZZZ,ZZZ,ZZ9.99")), 860, Gx_line+3, 950, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV83nDiciembre, "ZZZZZZ,ZZZ,ZZ9.99")), 930, Gx_line+3, 1020, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV84nTotal, "ZZZZZZ,ZZZ,ZZ9.99")), 1014, Gx_line+3, 1104, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV77nJunio, "ZZZZZZ,ZZZ,ZZ9.99")), 501, Gx_line+3, 591, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Verdana", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Nombre, "")), 0, Gx_line+2, 171, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV85Por, "ZZZZZZ,ZZZ,ZZ9.99")), 1058, Gx_line+3, 1148, Gx_line+16, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               AV100GXV2 = (int)(AV100GXV2+1);
            }
            AV14Len = (long)(StringUtil.Len( AV11UrlCliente)-1);
            AV11UrlCliente = StringUtil.Substring( AV11UrlCliente, 1, (int)(AV14Len));
            AV14Len = (long)(StringUtil.Len( AV13UrlAno1)-1);
            AV13UrlAno1 = StringUtil.Substring( AV13UrlAno1, 1, (int)(AV14Len));
            AV14Len = (long)(StringUtil.Len( AV12UrlAno2)-1);
            AV12UrlAno2 = StringUtil.Substring( AV12UrlAno2, 1, (int)(AV14Len));
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HES0( true, 0) ;
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
         /* 'AGREGADATOSGRID2' Routine */
         returnInSub = false;
         AV25TnEnero = 0;
         AV26TnFebrero = 0;
         AV27TnMarzo = 0;
         AV28TnAbril = 0;
         AV29TnMayo = 0;
         AV30TnJunio = 0;
         AV31TnJulio = 0;
         AV32TnAgosto = 0;
         AV33TnSeptiembre = 0;
         AV34TnOctubre = 0;
         AV35TnNoviembre = 0;
         AV36TnDiciembre = 0;
         AV37TnTotal = 0;
         AV38nTotalGeneral = 0;
         AV39TnEnero2 = 0;
         AV40TnFebrero2 = 0;
         AV41TnMarzo2 = 0;
         AV42TnAbril2 = 0;
         AV43TnMayo2 = 0;
         AV44TnJunio2 = 0;
         AV45TnJulio2 = 0;
         AV46TnAgosto2 = 0;
         AV47TnSeptiembre2 = 0;
         AV48TnOctubre2 = 0;
         AV49TnNoviembre2 = 0;
         AV50TnDiciembre2 = 0;
         AV51TnTotal2 = 0;
         AV52nTotalGeneral2 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV92TipoCliente ,
                                              A159TipCCod ,
                                              A1908TipCSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P00ES2 */
         pr_default.execute(0, new Object[] {AV92TipoCliente});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A159TipCCod = P00ES2_A159TipCCod[0];
            A1908TipCSts = P00ES2_A1908TipCSts[0];
            A1905TipCDsc = P00ES2_A1905TipCDsc[0];
            AV10SdtTablaItem.gxTpr_Tabitem = A159TipCCod;
            AV10SdtTablaItem.gxTpr_Tabnombre = A1905TipCDsc;
            if ( ( AV86MesDesde == 1 ) && ( AV87MesHasta >= 1 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 1;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes11 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 2 ) && ( AV87MesHasta >= 2 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 2;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes22 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 3 ) && ( AV87MesHasta >= 3 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 3;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes33 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 4 ) && ( AV87MesHasta >= 4 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 4;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes44 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 5 ) && ( AV87MesHasta >= 5 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 5;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes55 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 6 ) && ( AV87MesHasta >= 6 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 6;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes66 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 7 ) && ( AV87MesHasta >= 7 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 7;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes77 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 8 ) && ( AV87MesHasta >= 8 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 8;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes88 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 9 ) && ( AV87MesHasta >= 9 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 9;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes99 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 10 ) && ( AV87MesHasta >= 10 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 10;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes1010 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 11 ) && ( AV87MesHasta >= 11 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 11;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes01111 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 12 ) && ( AV87MesHasta >= 12 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 12;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV18Ano2, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes01212 = GXt_decimal1;
            }
            AV10SdtTablaItem.gxTpr_Tabtotal2 = (decimal)(AV10SdtTablaItem.gxTpr_Tabmes11+AV10SdtTablaItem.gxTpr_Tabmes22+AV10SdtTablaItem.gxTpr_Tabmes33+AV10SdtTablaItem.gxTpr_Tabmes44+AV10SdtTablaItem.gxTpr_Tabmes55+AV10SdtTablaItem.gxTpr_Tabmes66+AV10SdtTablaItem.gxTpr_Tabmes77+AV10SdtTablaItem.gxTpr_Tabmes88+AV10SdtTablaItem.gxTpr_Tabmes99+AV10SdtTablaItem.gxTpr_Tabmes1010+AV10SdtTablaItem.gxTpr_Tabmes01111+AV10SdtTablaItem.gxTpr_Tabmes01212);
            AV52nTotalGeneral2 = (decimal)(AV52nTotalGeneral2+(AV10SdtTablaItem.gxTpr_Tabtotal2));
            if ( ( AV86MesDesde == 1 ) && ( AV87MesHasta >= 1 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 1;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes1 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 2 ) && ( AV87MesHasta >= 2 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 2;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes2 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 3 ) && ( AV87MesHasta >= 3 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 3;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes3 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 4 ) && ( AV87MesHasta >= 4 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 4;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes4 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 5 ) && ( AV87MesHasta >= 5 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 5;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes5 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 6 ) && ( AV87MesHasta >= 6 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 6;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes6 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 7 ) && ( AV87MesHasta >= 7 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 7;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes7 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 8 ) && ( AV87MesHasta >= 8 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 8;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes8 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 9 ) && ( AV87MesHasta >= 9 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 9;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes9 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 10 ) && ( AV87MesHasta >= 10 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 10;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes10 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 11 ) && ( AV87MesHasta >= 11 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 11;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes011 = GXt_decimal1;
            }
            if ( ( AV86MesDesde <= 12 ) && ( AV87MesHasta >= 12 ) )
            {
               GXt_decimal1 = 0;
               GXt_int2 = AV10SdtTablaItem.gxTpr_Tabitem;
               GXt_int3 = 12;
               new pobtenerventastclientemensual(context ).execute( ref  AV53Moneda, ref  GXt_int2, ref  AV17Ano, ref  GXt_int3, out  GXt_decimal1) ;
               AV10SdtTablaItem.gxTpr_Tabitem = GXt_int2;
               AV10SdtTablaItem.gxTpr_Tabmes012 = GXt_decimal1;
            }
            AV10SdtTablaItem.gxTpr_Tabtotal1 = (decimal)(AV10SdtTablaItem.gxTpr_Tabmes1+AV10SdtTablaItem.gxTpr_Tabmes2+AV10SdtTablaItem.gxTpr_Tabmes3+AV10SdtTablaItem.gxTpr_Tabmes4+AV10SdtTablaItem.gxTpr_Tabmes5+AV10SdtTablaItem.gxTpr_Tabmes6+AV10SdtTablaItem.gxTpr_Tabmes7+AV10SdtTablaItem.gxTpr_Tabmes8+AV10SdtTablaItem.gxTpr_Tabmes9+AV10SdtTablaItem.gxTpr_Tabmes10+AV10SdtTablaItem.gxTpr_Tabmes011+AV10SdtTablaItem.gxTpr_Tabmes012);
            AV38nTotalGeneral = (decimal)(AV38nTotalGeneral+(AV10SdtTablaItem.gxTpr_Tabtotal1));
            AV39TnEnero2 = (decimal)(AV39TnEnero2+(AV10SdtTablaItem.gxTpr_Tabmes11));
            AV40TnFebrero2 = (decimal)(AV40TnFebrero2+(AV10SdtTablaItem.gxTpr_Tabmes22));
            AV41TnMarzo2 = (decimal)(AV41TnMarzo2+(AV10SdtTablaItem.gxTpr_Tabmes33));
            AV42TnAbril2 = (decimal)(AV42TnAbril2+(AV10SdtTablaItem.gxTpr_Tabmes44));
            AV43TnMayo2 = (decimal)(AV43TnMayo2+(AV10SdtTablaItem.gxTpr_Tabmes55));
            AV44TnJunio2 = (decimal)(AV44TnJunio2+(AV10SdtTablaItem.gxTpr_Tabmes66));
            AV45TnJulio2 = (decimal)(AV45TnJulio2+(AV10SdtTablaItem.gxTpr_Tabmes77));
            AV46TnAgosto2 = (decimal)(AV46TnAgosto2+(AV10SdtTablaItem.gxTpr_Tabmes88));
            AV47TnSeptiembre2 = (decimal)(AV47TnSeptiembre2+(AV10SdtTablaItem.gxTpr_Tabmes99));
            AV48TnOctubre2 = (decimal)(AV48TnOctubre2+(AV10SdtTablaItem.gxTpr_Tabmes1010));
            AV49TnNoviembre2 = (decimal)(AV49TnNoviembre2+(AV10SdtTablaItem.gxTpr_Tabmes01111));
            AV50TnDiciembre2 = (decimal)(AV50TnDiciembre2+(AV10SdtTablaItem.gxTpr_Tabmes01212));
            AV51TnTotal2 = (decimal)(AV51TnTotal2+(AV10SdtTablaItem.gxTpr_Tabtotal2));
            AV25TnEnero = (decimal)(AV25TnEnero+(AV10SdtTablaItem.gxTpr_Tabmes1));
            AV26TnFebrero = (decimal)(AV26TnFebrero+(AV10SdtTablaItem.gxTpr_Tabmes2));
            AV27TnMarzo = (decimal)(AV27TnMarzo+(AV10SdtTablaItem.gxTpr_Tabmes3));
            AV28TnAbril = (decimal)(AV28TnAbril+(AV10SdtTablaItem.gxTpr_Tabmes4));
            AV29TnMayo = (decimal)(AV29TnMayo+(AV10SdtTablaItem.gxTpr_Tabmes5));
            AV30TnJunio = (decimal)(AV30TnJunio+(AV10SdtTablaItem.gxTpr_Tabmes6));
            AV31TnJulio = (decimal)(AV31TnJulio+(AV10SdtTablaItem.gxTpr_Tabmes7));
            AV32TnAgosto = (decimal)(AV32TnAgosto+(AV10SdtTablaItem.gxTpr_Tabmes8));
            AV33TnSeptiembre = (decimal)(AV33TnSeptiembre+(AV10SdtTablaItem.gxTpr_Tabmes9));
            AV34TnOctubre = (decimal)(AV34TnOctubre+(AV10SdtTablaItem.gxTpr_Tabmes10));
            AV35TnNoviembre = (decimal)(AV35TnNoviembre+(AV10SdtTablaItem.gxTpr_Tabmes011));
            AV36TnDiciembre = (decimal)(AV36TnDiciembre+(AV10SdtTablaItem.gxTpr_Tabmes012));
            AV37TnTotal = (decimal)(AV37TnTotal+(AV10SdtTablaItem.gxTpr_Tabtotal1));
            AV9SdtTabla.Add(AV10SdtTablaItem, 0);
            AV10SdtTablaItem = new SdtSdtTabla_SdtCuentaItem(context);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV10SdtTablaItem.gxTpr_Tabitem = 0;
         AV10SdtTablaItem.gxTpr_Tabnombre = "Total General";
         AV10SdtTablaItem.gxTpr_Tabmes11 = AV39TnEnero2;
         AV10SdtTablaItem.gxTpr_Tabmes22 = AV40TnFebrero2;
         AV10SdtTablaItem.gxTpr_Tabmes33 = AV41TnMarzo2;
         AV10SdtTablaItem.gxTpr_Tabmes44 = AV42TnAbril2;
         AV10SdtTablaItem.gxTpr_Tabmes55 = AV43TnMayo2;
         AV10SdtTablaItem.gxTpr_Tabmes66 = AV44TnJunio2;
         AV10SdtTablaItem.gxTpr_Tabmes77 = AV45TnJulio2;
         AV10SdtTablaItem.gxTpr_Tabmes88 = AV46TnAgosto2;
         AV10SdtTablaItem.gxTpr_Tabmes99 = AV47TnSeptiembre2;
         AV10SdtTablaItem.gxTpr_Tabmes1010 = AV48TnOctubre2;
         AV10SdtTablaItem.gxTpr_Tabmes01111 = AV49TnNoviembre2;
         AV10SdtTablaItem.gxTpr_Tabmes01212 = AV50TnDiciembre2;
         AV10SdtTablaItem.gxTpr_Tabtotal2 = AV51TnTotal2;
         AV10SdtTablaItem.gxTpr_Tabmes1 = AV25TnEnero;
         AV10SdtTablaItem.gxTpr_Tabmes2 = AV26TnFebrero;
         AV10SdtTablaItem.gxTpr_Tabmes3 = AV27TnMarzo;
         AV10SdtTablaItem.gxTpr_Tabmes4 = AV28TnAbril;
         AV10SdtTablaItem.gxTpr_Tabmes5 = AV29TnMayo;
         AV10SdtTablaItem.gxTpr_Tabmes6 = AV30TnJunio;
         AV10SdtTablaItem.gxTpr_Tabmes7 = AV31TnJulio;
         AV10SdtTablaItem.gxTpr_Tabmes8 = AV32TnAgosto;
         AV10SdtTablaItem.gxTpr_Tabmes9 = AV33TnSeptiembre;
         AV10SdtTablaItem.gxTpr_Tabmes10 = AV34TnOctubre;
         AV10SdtTablaItem.gxTpr_Tabmes011 = AV35TnNoviembre;
         AV10SdtTablaItem.gxTpr_Tabmes012 = AV36TnDiciembre;
         AV10SdtTablaItem.gxTpr_Tabtotal1 = AV37TnTotal;
         AV9SdtTabla.Add(AV10SdtTablaItem, 0);
         AV10SdtTablaItem = new SdtSdtTabla_SdtCuentaItem(context);
         AV102GXV3 = 1;
         while ( AV102GXV3 <= AV9SdtTabla.Count )
         {
            AV10SdtTablaItem = ((SdtSdtTabla_SdtCuentaItem)AV9SdtTabla.Item(AV102GXV3));
            if ( AV10SdtTablaItem.gxTpr_Tabitem != 0 )
            {
               AV11UrlCliente += StringUtil.Trim( AV10SdtTablaItem.gxTpr_Tabnombre) + ",";
               AV12UrlAno2 += StringUtil.Trim( StringUtil.Str( AV10SdtTablaItem.gxTpr_Tabtotal1, 15, 2)) + ",";
               AV13UrlAno1 += StringUtil.Trim( StringUtil.Str( AV10SdtTablaItem.gxTpr_Tabtotal2, 15, 2)) + ",";
            }
            AV102GXV3 = (int)(AV102GXV3+1);
         }
      }

      protected void HES0( bool bFoot ,
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
         add_metrics2( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Tahoma", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Tahoma", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Verdana", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
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
         AV24Empresa = "";
         AV91Session = context.GetSession();
         AV23EmpDir = "";
         AV89EmpRUC = "";
         AV90Ruta = "";
         AV88Logo = "";
         AV95Logo_GXI = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV88Logo = "";
         sImgUrl = "";
         AV11UrlCliente = "";
         AV12UrlAno2 = "";
         AV13UrlAno1 = "";
         AV9SdtTabla = new GXBaseCollection<SdtSdtTabla_SdtCuentaItem>( context, "SdtCuentaItem", "SIGERP_ADVANCED");
         AV10SdtTablaItem = new SdtSdtTabla_SdtCuentaItem(context);
         AV55Nombre2 = "";
         AV71Nombre = "";
         scmdbuf = "";
         P00ES2_A159TipCCod = new int[1] ;
         P00ES2_A1908TipCSts = new short[1] ;
         P00ES2_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrevolucionventastcliente__default(),
            new Object[][] {
                new Object[] {
               P00ES2_A159TipCCod, P00ES2_A1908TipCSts, P00ES2_A1905TipCDsc
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
      private short AV17Ano ;
      private short AV18Ano2 ;
      private short AV86MesDesde ;
      private short AV87MesHasta ;
      private short A1908TipCSts ;
      private short GXt_int3 ;
      private int AV53Moneda ;
      private int AV92TipoCliente ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV99GXV1 ;
      private int AV54Codigo2 ;
      private int AV100GXV2 ;
      private int AV70Codigo ;
      private int A159TipCCod ;
      private int GXt_int2 ;
      private int AV102GXV3 ;
      private long AV14Len ;
      private decimal AV56nEnero2 ;
      private decimal AV57nFebrero2 ;
      private decimal AV58nMarzo2 ;
      private decimal AV59nAbril2 ;
      private decimal AV60nMayo2 ;
      private decimal AV61nJunio2 ;
      private decimal AV62nJulio2 ;
      private decimal AV63nAgosto2 ;
      private decimal AV64nSeptiembre2 ;
      private decimal AV65nOctubre2 ;
      private decimal AV66nNoviembre2 ;
      private decimal AV67nDiciembre2 ;
      private decimal AV68nTotal2 ;
      private decimal AV69Por2 ;
      private decimal AV52nTotalGeneral2 ;
      private decimal AV72nEnero ;
      private decimal AV73nFebrero ;
      private decimal AV74nMarzo ;
      private decimal AV75nAbril ;
      private decimal AV76nMayo ;
      private decimal AV77nJunio ;
      private decimal AV78nJulio ;
      private decimal AV79nAgosto ;
      private decimal AV80nSeptiembre ;
      private decimal AV82nOctubre ;
      private decimal AV81nNoviembre ;
      private decimal AV83nDiciembre ;
      private decimal AV84nTotal ;
      private decimal AV85Por ;
      private decimal AV38nTotalGeneral ;
      private decimal AV25TnEnero ;
      private decimal AV26TnFebrero ;
      private decimal AV27TnMarzo ;
      private decimal AV28TnAbril ;
      private decimal AV29TnMayo ;
      private decimal AV30TnJunio ;
      private decimal AV31TnJulio ;
      private decimal AV32TnAgosto ;
      private decimal AV33TnSeptiembre ;
      private decimal AV34TnOctubre ;
      private decimal AV35TnNoviembre ;
      private decimal AV36TnDiciembre ;
      private decimal AV37TnTotal ;
      private decimal AV39TnEnero2 ;
      private decimal AV40TnFebrero2 ;
      private decimal AV41TnMarzo2 ;
      private decimal AV42TnAbril2 ;
      private decimal AV43TnMayo2 ;
      private decimal AV44TnJunio2 ;
      private decimal AV45TnJulio2 ;
      private decimal AV46TnAgosto2 ;
      private decimal AV47TnSeptiembre2 ;
      private decimal AV48TnOctubre2 ;
      private decimal AV49TnNoviembre2 ;
      private decimal AV50TnDiciembre2 ;
      private decimal AV51TnTotal2 ;
      private decimal GXt_decimal1 ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV19TipoGrafico ;
      private string AV24Empresa ;
      private string AV23EmpDir ;
      private string AV89EmpRUC ;
      private string AV90Ruta ;
      private string Gx_time ;
      private string sImgUrl ;
      private string AV11UrlCliente ;
      private string AV12UrlAno2 ;
      private string AV13UrlAno1 ;
      private string AV55Nombre2 ;
      private string AV71Nombre ;
      private string scmdbuf ;
      private string A1905TipCDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private string AV95Logo_GXI ;
      private string AV88Logo ;
      private string Logo ;
      private IGxSession AV91Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Ano2 ;
      private string aP2_TipoGrafico ;
      private int aP3_Moneda ;
      private short aP4_MesDesde ;
      private short aP5_MesHasta ;
      private int aP6_TipoCliente ;
      private IDataStoreProvider pr_default ;
      private int[] P00ES2_A159TipCCod ;
      private short[] P00ES2_A1908TipCSts ;
      private string[] P00ES2_A1905TipCDsc ;
      private GXBaseCollection<SdtSdtTabla_SdtCuentaItem> AV9SdtTabla ;
      private SdtSdtTabla_SdtCuentaItem AV10SdtTablaItem ;
   }

   public class rrevolucionventastcliente__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00ES2( IGxContext context ,
                                             int AV92TipoCliente ,
                                             int A159TipCCod ,
                                             short A1908TipCSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TipCCod], [TipCSts], [TipCDsc] FROM [CTIPOCLIENTE]";
         AddWhere(sWhereString, "([TipCSts] = 1)");
         if ( ! (0==AV92TipoCliente) )
         {
            AddWhere(sWhereString, "([TipCCod] = @AV92TipoCliente)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipCCod]";
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
                     return conditional_P00ES2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00ES2;
          prmP00ES2 = new Object[] {
          new ParDef("@AV92TipoCliente",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ES2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ES2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
