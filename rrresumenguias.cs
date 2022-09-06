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
   public class rrresumenguias : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "rrresumenguias.aspx")), "rrresumenguias.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "rrresumenguias.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV20SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV10Prodcod = GetPar( "Prodcod");
                  AV28FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV29FHasta = context.localUtil.ParseDateParm( GetPar( "FHasta"));
                  AV31Flag = (short)(NumberUtil.Val( GetPar( "Flag"), "."));
                  AV37CliCod = GetPar( "CliCod");
                  AV38MVCliOrigen = (int)(NumberUtil.Val( GetPar( "MVCliOrigen"), "."));
                  AV39MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
                  AV42MVCCosto = GetPar( "MVCCosto");
                  AV44ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
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

      public rrresumenguias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenguias( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SublCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref short aP5_Flag ,
                           ref string aP6_CliCod ,
                           ref int aP7_MVCliOrigen ,
                           ref int aP8_MovCod ,
                           ref string aP9_MVCCosto ,
                           ref int aP10_ChoCod )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV20SublCod = aP1_SublCod;
         this.AV10Prodcod = aP2_Prodcod;
         this.AV28FDesde = aP3_FDesde;
         this.AV29FHasta = aP4_FHasta;
         this.AV31Flag = aP5_Flag;
         this.AV37CliCod = aP6_CliCod;
         this.AV38MVCliOrigen = aP7_MVCliOrigen;
         this.AV39MovCod = aP8_MovCod;
         this.AV42MVCCosto = aP9_MVCCosto;
         this.AV44ChoCod = aP10_ChoCod;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV20SublCod;
         aP2_Prodcod=this.AV10Prodcod;
         aP3_FDesde=this.AV28FDesde;
         aP4_FHasta=this.AV29FHasta;
         aP5_Flag=this.AV31Flag;
         aP6_CliCod=this.AV37CliCod;
         aP7_MVCliOrigen=this.AV38MVCliOrigen;
         aP8_MovCod=this.AV39MovCod;
         aP9_MVCCosto=this.AV42MVCCosto;
         aP10_ChoCod=this.AV44ChoCod;
      }

      public int executeUdp( ref int aP0_LinCod ,
                             ref int aP1_SublCod ,
                             ref string aP2_Prodcod ,
                             ref DateTime aP3_FDesde ,
                             ref DateTime aP4_FHasta ,
                             ref short aP5_Flag ,
                             ref string aP6_CliCod ,
                             ref int aP7_MVCliOrigen ,
                             ref int aP8_MovCod ,
                             ref string aP9_MVCCosto )
      {
         execute(ref aP0_LinCod, ref aP1_SublCod, ref aP2_Prodcod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Flag, ref aP6_CliCod, ref aP7_MVCliOrigen, ref aP8_MovCod, ref aP9_MVCCosto, ref aP10_ChoCod);
         return AV44ChoCod ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SublCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref short aP5_Flag ,
                                 ref string aP6_CliCod ,
                                 ref int aP7_MVCliOrigen ,
                                 ref int aP8_MovCod ,
                                 ref string aP9_MVCCosto ,
                                 ref int aP10_ChoCod )
      {
         rrresumenguias objrrresumenguias;
         objrrresumenguias = new rrresumenguias();
         objrrresumenguias.AV8LinCod = aP0_LinCod;
         objrrresumenguias.AV20SublCod = aP1_SublCod;
         objrrresumenguias.AV10Prodcod = aP2_Prodcod;
         objrrresumenguias.AV28FDesde = aP3_FDesde;
         objrrresumenguias.AV29FHasta = aP4_FHasta;
         objrrresumenguias.AV31Flag = aP5_Flag;
         objrrresumenguias.AV37CliCod = aP6_CliCod;
         objrrresumenguias.AV38MVCliOrigen = aP7_MVCliOrigen;
         objrrresumenguias.AV39MovCod = aP8_MovCod;
         objrrresumenguias.AV42MVCCosto = aP9_MVCCosto;
         objrrresumenguias.AV44ChoCod = aP10_ChoCod;
         objrrresumenguias.context.SetSubmitInitialConfig(context);
         objrrresumenguias.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenguias);
         aP0_LinCod=this.AV8LinCod;
         aP1_SublCod=this.AV20SublCod;
         aP2_Prodcod=this.AV10Prodcod;
         aP3_FDesde=this.AV28FDesde;
         aP4_FHasta=this.AV29FHasta;
         aP5_Flag=this.AV31Flag;
         aP6_CliCod=this.AV37CliCod;
         aP7_MVCliOrigen=this.AV38MVCliOrigen;
         aP8_MovCod=this.AV39MovCod;
         aP9_MVCCosto=this.AV42MVCCosto;
         aP10_ChoCod=this.AV44ChoCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenguias)stateInfo).executePrivate();
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
            AV21Empresa = AV26Session.Get("Empresa");
            AV22EmpDir = AV26Session.Get("EmpDir");
            AV23EmpRUC = AV26Session.Get("EmpRUC");
            AV24Ruta = AV26Session.Get("RUTA") + "/Logo.jpg";
            AV25Logo = AV24Ruta;
            AV47Logo_GXI = GXDbFile.PathToUrl( AV24Ruta);
            AV12Titulo = "Resumen de Guias de Remisión";
            AV30Titulo2 = "Del : " + context.localUtil.DToC( AV28FDesde, 2, "/") + "   Al : " + context.localUtil.DToC( AV29FHasta, 2, "/");
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV37CliCod ,
                                                 AV39MovCod ,
                                                 AV38MVCliOrigen ,
                                                 AV42MVCCosto ,
                                                 AV44ChoCod ,
                                                 A15MVCliCod ,
                                                 A22MvAMov ,
                                                 A16MVCliOrigen ,
                                                 A1287MVCCosto ,
                                                 A10ChoCod ,
                                                 A25MvAFec ,
                                                 AV28FDesde ,
                                                 AV29FHasta ,
                                                 A13MvATip } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE,
                                                 TypeConstants.DATE
                                                 }
            });
            /* Using cursor P008C2 */
            pr_default.execute(0, new Object[] {AV28FDesde, AV29FHasta, AV37CliCod, AV39MovCod, AV38MVCliOrigen, AV42MVCCosto, AV44ChoCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK8C3 = false;
               A13MvATip = P008C2_A13MvATip[0];
               A1287MVCCosto = P008C2_A1287MVCCosto[0];
               A10ChoCod = P008C2_A10ChoCod[0];
               A16MVCliOrigen = P008C2_A16MVCliOrigen[0];
               n16MVCliOrigen = P008C2_n16MVCliOrigen[0];
               A22MvAMov = P008C2_A22MvAMov[0];
               A15MVCliCod = P008C2_A15MVCliCod[0];
               n15MVCliCod = P008C2_n15MVCliCod[0];
               A25MvAFec = P008C2_A25MvAFec[0];
               A14MvACod = P008C2_A14MvACod[0];
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008C2_A1287MVCCosto[0], A1287MVCCosto) == 0 ) )
               {
                  BRK8C3 = false;
                  A13MvATip = P008C2_A13MvATip[0];
                  A14MvACod = P008C2_A14MvACod[0];
                  BRK8C3 = true;
                  pr_default.readNext(0);
               }
               AV40CosCod = StringUtil.Trim( A1287MVCCosto);
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CosCod)) )
               {
                  /* Execute user subroutine: 'CENTROCOSTO' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
                  H8C0( false, 22) ;
                  getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41CosDsc, "")), 9, Gx_line+3, 635, Gx_line+19, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+22);
               }
               /* Execute user subroutine: 'RESUMENGUIAS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
               if ( ! BRK8C3 )
               {
                  BRK8C3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8C0( true, 0) ;
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
         /* 'RESUMENGUIAS' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV37CliCod ,
                                              AV39MovCod ,
                                              AV38MVCliOrigen ,
                                              A15MVCliCod ,
                                              A22MvAMov ,
                                              A16MVCliOrigen ,
                                              A25MvAFec ,
                                              AV28FDesde ,
                                              AV29FHasta ,
                                              A1287MVCCosto ,
                                              AV40CosCod ,
                                              A13MvATip } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008C3 */
         pr_default.execute(1, new Object[] {AV28FDesde, AV29FHasta, AV40CosCod, AV37CliCod, AV39MovCod, AV38MVCliOrigen});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A14MvACod = P008C3_A14MvACod[0];
            A13MvATip = P008C3_A13MvATip[0];
            A16MVCliOrigen = P008C3_A16MVCliOrigen[0];
            n16MVCliOrigen = P008C3_n16MVCliOrigen[0];
            A22MvAMov = P008C3_A22MvAMov[0];
            A15MVCliCod = P008C3_A15MVCliCod[0];
            n15MVCliCod = P008C3_n15MVCliCod[0];
            A25MvAFec = P008C3_A25MvAFec[0];
            A1287MVCCosto = P008C3_A1287MVCCosto[0];
            A20MVPedCod = P008C3_A20MVPedCod[0];
            n20MVPedCod = P008C3_n20MVPedCod[0];
            A1370MVSts = P008C3_A1370MVSts[0];
            A23DocTip = P008C3_A23DocTip[0];
            n23DocTip = P008C3_n23DocTip[0];
            A24DocNum = P008C3_A24DocNum[0];
            n24DocNum = P008C3_n24DocNum[0];
            A1278MvARef = P008C3_A1278MvARef[0];
            AV32MVPedCod = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A20MVPedCod));
            AV34DocTip = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A23DocTip));
            AV35DocNum = ((StringUtil.StrCmp(A1370MVSts, "A")==0) ? "" : StringUtil.Trim( A24DocNum));
            H8C0( false, 21) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 9, Gx_line+2, 73, Gx_line+17, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 76, Gx_line+2, 127, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32MVPedCod, "")), 601, Gx_line+2, 660, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1278MvARef, "")), 132, Gx_line+2, 210, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33MVCliDsc, "")), 221, Gx_line+2, 577, Gx_line+16, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34DocTip, "")), 668, Gx_line+2, 699, Gx_line+16, 1, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35DocNum, "")), 707, Gx_line+2, 771, Gx_line+17, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+21);
            if ( AV31Flag == 2 )
            {
               /* Using cursor P008C4 */
               pr_default.execute(2, new Object[] {A13MvATip, A14MvACod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A1248MvADCant = P008C4_A1248MvADCant[0];
                  A55ProdDsc = P008C4_A55ProdDsc[0];
                  A28ProdCod = P008C4_A28ProdCod[0];
                  A30MvADItem = P008C4_A30MvADItem[0];
                  A55ProdDsc = P008C4_A55ProdDsc[0];
                  H8C0( false, 20) ;
                  getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 77, Gx_line+3, 155, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 170, Gx_line+3, 580, Gx_line+17, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 590, Gx_line+3, 697, Gx_line+18, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'CENTROCOSTO' Routine */
         returnInSub = false;
         AV41CosDsc = "";
         /* Using cursor P008C5 */
         pr_default.execute(3, new Object[] {AV40CosCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A79COSCod = P008C5_A79COSCod[0];
            A761COSDsc = P008C5_A761COSDsc[0];
            AV41CosDsc = StringUtil.Trim( A79COSCod) + "  -  " + StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void H8C0( bool bFoot ,
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
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+25);
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
               getPrinter().GxDrawText("Hora:", 663, Gx_line+40, 695, Gx_line+54, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 663, Gx_line+57, 707, Gx_line+71, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 663, Gx_line+22, 702, Gx_line+36, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 730, Gx_line+57, 769, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+40, 767, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 722, Gx_line+22, 769, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 189, Gx_line+43, 633, Gx_line+68, 1, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+119, 796, Gx_line+145, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 81, Gx_line+125, 116, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Referencia", 139, Gx_line+125, 204, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 672, Gx_line+125, 695, Gx_line+139, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV25Logo)) ? AV47Logo_GXI : AV25Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 14, Gx_line+4, 152, Gx_line+75) ;
               getPrinter().GxDrawText("Numero", 13, Gx_line+125, 60, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 220, Gx_line+125, 262, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Pedido", 602, Gx_line+125, 659, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Numero", 710, Gx_line+125, 757, Gx_line+139, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30Titulo2, "")), 189, Gx_line+68, 633, Gx_line+93, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21Empresa, "")), 14, Gx_line+76, 382, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23EmpRUC, "")), 14, Gx_line+94, 184, Gx_line+112, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+146);
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
      }

      public override void initialize( )
      {
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         AV21Empresa = "";
         AV26Session = context.GetSession();
         AV22EmpDir = "";
         AV23EmpRUC = "";
         AV24Ruta = "";
         AV25Logo = "";
         AV47Logo_GXI = "";
         AV12Titulo = "";
         AV30Titulo2 = "";
         scmdbuf = "";
         A15MVCliCod = "";
         A1287MVCCosto = "";
         A25MvAFec = DateTime.MinValue;
         A13MvATip = "";
         P008C2_A13MvATip = new string[] {""} ;
         P008C2_A1287MVCCosto = new string[] {""} ;
         P008C2_A10ChoCod = new int[1] ;
         P008C2_A16MVCliOrigen = new int[1] ;
         P008C2_n16MVCliOrigen = new bool[] {false} ;
         P008C2_A22MvAMov = new int[1] ;
         P008C2_A15MVCliCod = new string[] {""} ;
         P008C2_n15MVCliCod = new bool[] {false} ;
         P008C2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008C2_A14MvACod = new string[] {""} ;
         A14MvACod = "";
         AV40CosCod = "";
         AV41CosDsc = "";
         P008C3_A14MvACod = new string[] {""} ;
         P008C3_A13MvATip = new string[] {""} ;
         P008C3_A16MVCliOrigen = new int[1] ;
         P008C3_n16MVCliOrigen = new bool[] {false} ;
         P008C3_A22MvAMov = new int[1] ;
         P008C3_A15MVCliCod = new string[] {""} ;
         P008C3_n15MVCliCod = new bool[] {false} ;
         P008C3_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008C3_A1287MVCCosto = new string[] {""} ;
         P008C3_A20MVPedCod = new string[] {""} ;
         P008C3_n20MVPedCod = new bool[] {false} ;
         P008C3_A1370MVSts = new string[] {""} ;
         P008C3_A23DocTip = new string[] {""} ;
         P008C3_n23DocTip = new bool[] {false} ;
         P008C3_A24DocNum = new string[] {""} ;
         P008C3_n24DocNum = new bool[] {false} ;
         P008C3_A1278MvARef = new string[] {""} ;
         A20MVPedCod = "";
         A1370MVSts = "";
         A23DocTip = "";
         A24DocNum = "";
         A1278MvARef = "";
         AV32MVPedCod = "";
         AV34DocTip = "";
         AV35DocNum = "";
         AV33MVCliDsc = "";
         P008C4_A13MvATip = new string[] {""} ;
         P008C4_A14MvACod = new string[] {""} ;
         P008C4_A1248MvADCant = new decimal[1] ;
         P008C4_A55ProdDsc = new string[] {""} ;
         P008C4_A28ProdCod = new string[] {""} ;
         P008C4_A30MvADItem = new int[1] ;
         A55ProdDsc = "";
         A28ProdCod = "";
         P008C5_A79COSCod = new string[] {""} ;
         P008C5_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV25Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenguias__default(),
            new Object[][] {
                new Object[] {
               P008C2_A13MvATip, P008C2_A1287MVCCosto, P008C2_A10ChoCod, P008C2_A16MVCliOrigen, P008C2_n16MVCliOrigen, P008C2_A22MvAMov, P008C2_A15MVCliCod, P008C2_n15MVCliCod, P008C2_A25MvAFec, P008C2_A14MvACod
               }
               , new Object[] {
               P008C3_A14MvACod, P008C3_A13MvATip, P008C3_A16MVCliOrigen, P008C3_n16MVCliOrigen, P008C3_A22MvAMov, P008C3_A15MVCliCod, P008C3_n15MVCliCod, P008C3_A25MvAFec, P008C3_A1287MVCCosto, P008C3_A20MVPedCod,
               P008C3_n20MVPedCod, P008C3_A1370MVSts, P008C3_A23DocTip, P008C3_n23DocTip, P008C3_A24DocNum, P008C3_n24DocNum, P008C3_A1278MvARef
               }
               , new Object[] {
               P008C4_A13MvATip, P008C4_A14MvACod, P008C4_A1248MvADCant, P008C4_A55ProdDsc, P008C4_A28ProdCod, P008C4_A30MvADItem
               }
               , new Object[] {
               P008C5_A79COSCod, P008C5_A761COSDsc
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
      private short AV31Flag ;
      private int AV8LinCod ;
      private int AV20SublCod ;
      private int AV38MVCliOrigen ;
      private int AV39MovCod ;
      private int AV44ChoCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A22MvAMov ;
      private int A16MVCliOrigen ;
      private int A10ChoCod ;
      private int Gx_OldLine ;
      private int A30MvADItem ;
      private decimal A1248MvADCant ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV37CliCod ;
      private string AV42MVCCosto ;
      private string AV21Empresa ;
      private string AV22EmpDir ;
      private string AV23EmpRUC ;
      private string AV24Ruta ;
      private string AV12Titulo ;
      private string AV30Titulo2 ;
      private string scmdbuf ;
      private string A15MVCliCod ;
      private string A1287MVCCosto ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string AV40CosCod ;
      private string AV41CosDsc ;
      private string A20MVPedCod ;
      private string A1370MVSts ;
      private string A23DocTip ;
      private string A24DocNum ;
      private string A1278MvARef ;
      private string AV32MVPedCod ;
      private string AV34DocTip ;
      private string AV35DocNum ;
      private string AV33MVCliDsc ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV28FDesde ;
      private DateTime AV29FHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK8C3 ;
      private bool n16MVCliOrigen ;
      private bool n15MVCliCod ;
      private bool returnInSub ;
      private bool n20MVPedCod ;
      private bool n23DocTip ;
      private bool n24DocNum ;
      private string AV47Logo_GXI ;
      private string AV25Logo ;
      private string Logo ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SublCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private short aP5_Flag ;
      private string aP6_CliCod ;
      private int aP7_MVCliOrigen ;
      private int aP8_MovCod ;
      private string aP9_MVCCosto ;
      private int aP10_ChoCod ;
      private IDataStoreProvider pr_default ;
      private string[] P008C2_A13MvATip ;
      private string[] P008C2_A1287MVCCosto ;
      private int[] P008C2_A10ChoCod ;
      private int[] P008C2_A16MVCliOrigen ;
      private bool[] P008C2_n16MVCliOrigen ;
      private int[] P008C2_A22MvAMov ;
      private string[] P008C2_A15MVCliCod ;
      private bool[] P008C2_n15MVCliCod ;
      private DateTime[] P008C2_A25MvAFec ;
      private string[] P008C2_A14MvACod ;
      private string[] P008C3_A14MvACod ;
      private string[] P008C3_A13MvATip ;
      private int[] P008C3_A16MVCliOrigen ;
      private bool[] P008C3_n16MVCliOrigen ;
      private int[] P008C3_A22MvAMov ;
      private string[] P008C3_A15MVCliCod ;
      private bool[] P008C3_n15MVCliCod ;
      private DateTime[] P008C3_A25MvAFec ;
      private string[] P008C3_A1287MVCCosto ;
      private string[] P008C3_A20MVPedCod ;
      private bool[] P008C3_n20MVPedCod ;
      private string[] P008C3_A1370MVSts ;
      private string[] P008C3_A23DocTip ;
      private bool[] P008C3_n23DocTip ;
      private string[] P008C3_A24DocNum ;
      private bool[] P008C3_n24DocNum ;
      private string[] P008C3_A1278MvARef ;
      private string[] P008C4_A13MvATip ;
      private string[] P008C4_A14MvACod ;
      private decimal[] P008C4_A1248MvADCant ;
      private string[] P008C4_A55ProdDsc ;
      private string[] P008C4_A28ProdCod ;
      private int[] P008C4_A30MvADItem ;
      private string[] P008C5_A79COSCod ;
      private string[] P008C5_A761COSDsc ;
   }

   public class rrresumenguias__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008C2( IGxContext context ,
                                             string AV37CliCod ,
                                             int AV39MovCod ,
                                             int AV38MVCliOrigen ,
                                             string AV42MVCCosto ,
                                             int AV44ChoCod ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             string A1287MVCCosto ,
                                             int A10ChoCod ,
                                             DateTime A25MvAFec ,
                                             DateTime AV28FDesde ,
                                             DateTime AV29FHasta ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MvATip], [MVCCosto], [ChoCod], [MVCliOrigen], [MvAMov], [MVCliCod], [MvAFec], [MvACod] FROM [AGUIAS]";
         AddWhere(sWhereString, "([MvAFec] >= @AV28FDesde)");
         AddWhere(sWhereString, "([MvAFec] <= @AV29FHasta)");
         AddWhere(sWhereString, "([MvATip] = 'REM')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37CliCod)) )
         {
            AddWhere(sWhereString, "([MVCliCod] = @AV37CliCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV39MovCod) )
         {
            AddWhere(sWhereString, "([MvAMov] = @AV39MovCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV38MVCliOrigen) )
         {
            AddWhere(sWhereString, "([MVCliOrigen] = @AV38MVCliOrigen)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42MVCCosto)) )
         {
            AddWhere(sWhereString, "([MVCCosto] = @AV42MVCCosto)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV44ChoCod) )
         {
            AddWhere(sWhereString, "([ChoCod] = @AV44ChoCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MVCCosto], [MvATip]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008C3( IGxContext context ,
                                             string AV37CliCod ,
                                             int AV39MovCod ,
                                             int AV38MVCliOrigen ,
                                             string A15MVCliCod ,
                                             int A22MvAMov ,
                                             int A16MVCliOrigen ,
                                             DateTime A25MvAFec ,
                                             DateTime AV28FDesde ,
                                             DateTime AV29FHasta ,
                                             string A1287MVCCosto ,
                                             string AV40CosCod ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MvACod], [MvATip], [MVCliOrigen], [MvAMov], [MVCliCod], [MvAFec], [MVCCosto], [MVPedCod], [MVSts], [DocTip], [DocNum], [MvARef] FROM [AGUIAS]";
         AddWhere(sWhereString, "([MvATip] = 'REM')");
         AddWhere(sWhereString, "([MvAFec] >= @AV28FDesde)");
         AddWhere(sWhereString, "([MvAFec] <= @AV29FHasta)");
         AddWhere(sWhereString, "([MVCCosto] = @AV40CosCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37CliCod)) )
         {
            AddWhere(sWhereString, "([MVCliCod] = @AV37CliCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV39MovCod) )
         {
            AddWhere(sWhereString, "([MvAMov] = @AV39MovCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV38MVCliOrigen) )
         {
            AddWhere(sWhereString, "([MVCliOrigen] = @AV38MVCliOrigen)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MvATip], [MvACod]";
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
                     return conditional_P008C2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P008C3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] );
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
          Object[] prmP008C4;
          prmP008C4 = new Object[] {
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0)
          };
          Object[] prmP008C5;
          prmP008C5 = new Object[] {
          new ParDef("@AV40CosCod",GXType.NChar,10,0)
          };
          Object[] prmP008C2;
          prmP008C2 = new Object[] {
          new ParDef("@AV28FDesde",GXType.Date,8,0) ,
          new ParDef("@AV29FHasta",GXType.Date,8,0) ,
          new ParDef("@AV37CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV39MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MVCliOrigen",GXType.Int32,6,0) ,
          new ParDef("@AV42MVCCosto",GXType.NChar,10,0) ,
          new ParDef("@AV44ChoCod",GXType.Int32,6,0)
          };
          Object[] prmP008C3;
          prmP008C3 = new Object[] {
          new ParDef("@AV28FDesde",GXType.Date,8,0) ,
          new ParDef("@AV29FHasta",GXType.Date,8,0) ,
          new ParDef("@AV40CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV37CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV39MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV38MVCliOrigen",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008C4", "SELECT T1.[MvATip], T1.[MvACod], T1.[MvADCant], T2.[ProdDsc], T1.[ProdCod], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) WHERE T1.[MvATip] = @MvATip and T1.[MvACod] = @MvACod ORDER BY T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008C5", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV40CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008C5,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 12);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 10);
                ((string[]) buf[9])[0] = rslt.getString(8, 10);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 1);
                ((string[]) buf[12])[0] = rslt.getString(10, 3);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 12);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
