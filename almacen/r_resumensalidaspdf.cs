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
namespace GeneXus.Programs.almacen {
   public class r_resumensalidaspdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_resumensalidaspdf.aspx")), "almacen.r_resumensalidaspdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_resumensalidaspdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "MovCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV29MovCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV30LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AV31Prodcod = GetPar( "Prodcod");
                  AV27Hdesde = context.localUtil.ParseDateParm( GetPar( "Hdesde"));
                  AV28HHasta = context.localUtil.ParseDateParm( GetPar( "HHasta"));
                  AV39AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV40SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
                  AV41FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV44CosCod = GetPar( "CosCod");
                  AV47Tipo = GetPar( "Tipo");
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

      public r_resumensalidaspdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumensalidaspdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MovCod ,
                           ref int aP1_LinCod ,
                           ref string aP2_Prodcod ,
                           ref DateTime aP3_Hdesde ,
                           ref DateTime aP4_HHasta ,
                           ref int aP5_AlmCod ,
                           ref int aP6_SublCod ,
                           ref int aP7_FamCod ,
                           ref string aP8_CosCod ,
                           ref string aP9_Tipo )
      {
         this.AV29MovCod = aP0_MovCod;
         this.AV30LinCod = aP1_LinCod;
         this.AV31Prodcod = aP2_Prodcod;
         this.AV27Hdesde = aP3_Hdesde;
         this.AV28HHasta = aP4_HHasta;
         this.AV39AlmCod = aP5_AlmCod;
         this.AV40SublCod = aP6_SublCod;
         this.AV41FamCod = aP7_FamCod;
         this.AV44CosCod = aP8_CosCod;
         this.AV47Tipo = aP9_Tipo;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_AlmCod=this.AV39AlmCod;
         aP6_SublCod=this.AV40SublCod;
         aP7_FamCod=this.AV41FamCod;
         aP8_CosCod=this.AV44CosCod;
         aP9_Tipo=this.AV47Tipo;
      }

      public string executeUdp( ref int aP0_MovCod ,
                                ref int aP1_LinCod ,
                                ref string aP2_Prodcod ,
                                ref DateTime aP3_Hdesde ,
                                ref DateTime aP4_HHasta ,
                                ref int aP5_AlmCod ,
                                ref int aP6_SublCod ,
                                ref int aP7_FamCod ,
                                ref string aP8_CosCod )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_Hdesde, ref aP4_HHasta, ref aP5_AlmCod, ref aP6_SublCod, ref aP7_FamCod, ref aP8_CosCod, ref aP9_Tipo);
         return AV47Tipo ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_Hdesde ,
                                 ref DateTime aP4_HHasta ,
                                 ref int aP5_AlmCod ,
                                 ref int aP6_SublCod ,
                                 ref int aP7_FamCod ,
                                 ref string aP8_CosCod ,
                                 ref string aP9_Tipo )
      {
         r_resumensalidaspdf objr_resumensalidaspdf;
         objr_resumensalidaspdf = new r_resumensalidaspdf();
         objr_resumensalidaspdf.AV29MovCod = aP0_MovCod;
         objr_resumensalidaspdf.AV30LinCod = aP1_LinCod;
         objr_resumensalidaspdf.AV31Prodcod = aP2_Prodcod;
         objr_resumensalidaspdf.AV27Hdesde = aP3_Hdesde;
         objr_resumensalidaspdf.AV28HHasta = aP4_HHasta;
         objr_resumensalidaspdf.AV39AlmCod = aP5_AlmCod;
         objr_resumensalidaspdf.AV40SublCod = aP6_SublCod;
         objr_resumensalidaspdf.AV41FamCod = aP7_FamCod;
         objr_resumensalidaspdf.AV44CosCod = aP8_CosCod;
         objr_resumensalidaspdf.AV47Tipo = aP9_Tipo;
         objr_resumensalidaspdf.context.SetSubmitInitialConfig(context);
         objr_resumensalidaspdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumensalidaspdf);
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_AlmCod=this.AV39AlmCod;
         aP6_SublCod=this.AV40SublCod;
         aP7_FamCod=this.AV41FamCod;
         aP8_CosCod=this.AV44CosCod;
         aP9_Tipo=this.AV47Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumensalidaspdf)stateInfo).executePrivate();
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
            AV33Empresa = AV38Session.Get("Empresa");
            AV34EmpDir = AV38Session.Get("EmpDir");
            AV35EmpRUC = AV38Session.Get("EmpRUC");
            AV36Ruta = AV38Session.Get("RUTA") + "/Logo.jpg";
            AV37Logo = AV36Ruta;
            AV54Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            /* Using cursor P008G2 */
            pr_default.execute(0, new Object[] {AV39AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P008G2_A63AlmCod[0];
               A436AlmDsc = P008G2_A436AlmDsc[0];
               AV22Filtro1 = StringUtil.Trim( A436AlmDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P008G3 */
            pr_default.execute(1, new Object[] {AV30LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P008G3_A52LinCod[0];
               A1153LinDsc = P008G3_A1153LinDsc[0];
               AV23Filtro2 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P008G4 */
            pr_default.execute(2, new Object[] {AV31Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P008G4_A28ProdCod[0];
               A55ProdDsc = P008G4_A55ProdDsc[0];
               AV24Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV45TTotalP = 0.0000m;
            AV46TTotalC = 0.00m;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV29MovCod ,
                                                 AV30LinCod ,
                                                 AV40SublCod ,
                                                 AV41FamCod ,
                                                 AV31Prodcod ,
                                                 AV44CosCod ,
                                                 AV47Tipo ,
                                                 AV39AlmCod ,
                                                 A22MvAMov ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1287MVCCosto ,
                                                 A1249MVADCosto ,
                                                 A21MvAlm ,
                                                 A13MvATip ,
                                                 A25MvAFec ,
                                                 AV27Hdesde ,
                                                 AV28HHasta ,
                                                 A1370MVSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P008G5 */
            pr_default.execute(3, new Object[] {AV27Hdesde, AV28HHasta, AV29MovCod, AV30LinCod, AV40SublCod, AV41FamCod, AV31Prodcod, AV44CosCod, AV39AlmCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRK8G6 = false;
               A28ProdCod = P008G5_A28ProdCod[0];
               A13MvATip = P008G5_A13MvATip[0];
               A14MvACod = P008G5_A14MvACod[0];
               A1287MVCCosto = P008G5_A1287MVCCosto[0];
               A1278MvARef = P008G5_A1278MvARef[0];
               A1276MvAOcom = P008G5_A1276MvAOcom[0];
               A1250MVADPrecio = P008G5_A1250MVADPrecio[0];
               A1249MVADCosto = P008G5_A1249MVADCosto[0];
               A1248MvADCant = P008G5_A1248MvADCant[0];
               A1274MvAMovDsc = P008G5_A1274MvAMovDsc[0];
               A25MvAFec = P008G5_A25MvAFec[0];
               A1370MVSts = P008G5_A1370MVSts[0];
               A21MvAlm = P008G5_A21MvAlm[0];
               A50FamCod = P008G5_A50FamCod[0];
               n50FamCod = P008G5_n50FamCod[0];
               A51SublCod = P008G5_A51SublCod[0];
               n51SublCod = P008G5_n51SublCod[0];
               A52LinCod = P008G5_A52LinCod[0];
               A22MvAMov = P008G5_A22MvAMov[0];
               A55ProdDsc = P008G5_A55ProdDsc[0];
               A30MvADItem = P008G5_A30MvADItem[0];
               A50FamCod = P008G5_A50FamCod[0];
               n50FamCod = P008G5_n50FamCod[0];
               A51SublCod = P008G5_A51SublCod[0];
               n51SublCod = P008G5_n51SublCod[0];
               A52LinCod = P008G5_A52LinCod[0];
               A55ProdDsc = P008G5_A55ProdDsc[0];
               A1287MVCCosto = P008G5_A1287MVCCosto[0];
               A1278MvARef = P008G5_A1278MvARef[0];
               A1276MvAOcom = P008G5_A1276MvAOcom[0];
               A25MvAFec = P008G5_A25MvAFec[0];
               A1370MVSts = P008G5_A1370MVSts[0];
               A21MvAlm = P008G5_A21MvAlm[0];
               A22MvAMov = P008G5_A22MvAMov[0];
               A1274MvAMovDsc = P008G5_A1274MvAMovDsc[0];
               H8G0( false, 21) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 93, Gx_line+3, 608, Gx_line+18, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 5, Gx_line+3, 83, Gx_line+17, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+21);
               AV32TotalP = 0.0000m;
               AV42TotalC = 0.00m;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008G5_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRK8G6 = false;
                  A13MvATip = P008G5_A13MvATip[0];
                  A14MvACod = P008G5_A14MvACod[0];
                  A1287MVCCosto = P008G5_A1287MVCCosto[0];
                  A1278MvARef = P008G5_A1278MvARef[0];
                  A1276MvAOcom = P008G5_A1276MvAOcom[0];
                  A1250MVADPrecio = P008G5_A1250MVADPrecio[0];
                  A1249MVADCosto = P008G5_A1249MVADCosto[0];
                  A1248MvADCant = P008G5_A1248MvADCant[0];
                  A1274MvAMovDsc = P008G5_A1274MvAMovDsc[0];
                  A25MvAFec = P008G5_A25MvAFec[0];
                  A22MvAMov = P008G5_A22MvAMov[0];
                  A30MvADItem = P008G5_A30MvADItem[0];
                  A1287MVCCosto = P008G5_A1287MVCCosto[0];
                  A1278MvARef = P008G5_A1278MvARef[0];
                  A1276MvAOcom = P008G5_A1276MvAOcom[0];
                  A25MvAFec = P008G5_A25MvAFec[0];
                  A22MvAMov = P008G5_A22MvAMov[0];
                  A1274MvAMovDsc = P008G5_A1274MvAMovDsc[0];
                  AV49MvATip = A13MvATip;
                  AV50MvACod = A14MvACod;
                  AV51MVCCosto = A1287MVCCosto;
                  /* Execute user subroutine: 'VALIDACLIENTE' */
                  S111 ();
                  if ( returnInSub )
                  {
                     pr_default.close(3);
                     this.cleanup();
                     if (true) return;
                  }
                  AV43MVARef = (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom);
                  H8G0( false, 17) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 5, Gx_line+3, 31, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 34, Gx_line+3, 85, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 89, Gx_line+3, 128, Gx_line+16, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), 203, Gx_line+3, 380, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 536, Gx_line+3, 626, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MVARef, "")), 131, Gx_line+3, 201, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1249MVADCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+3, 793, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1250MVADPrecio, "ZZZZZ,ZZZ,ZZ9.999999")), 604, Gx_line+3, 709, Gx_line+16, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Cliente, "")), 383, Gx_line+3, 544, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+17);
                  AV32TotalP = (decimal)(AV32TotalP+A1248MvADCant);
                  AV42TotalC = (decimal)(AV42TotalC+A1249MVADCosto);
                  BRK8G6 = true;
                  pr_default.readNext(3);
               }
               AV46TTotalC = (decimal)(AV46TTotalC+AV42TotalC);
               AV45TTotalP = (decimal)(AV45TTotalP+AV32TotalP);
               H8G0( false, 26) ;
               getPrinter().GxDrawLine(516, Gx_line+4, 793, Gx_line+4, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total : ", 460, Gx_line+9, 501, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TotalP, "ZZZZ,ZZZ,ZZ9.9999")), 536, Gx_line+10, 626, Gx_line+23, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 703, Gx_line+10, 793, Gx_line+23, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+26);
               if ( ! BRK8G6 )
               {
                  BRK8G6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            H8G0( false, 44) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General : ", 422, Gx_line+14, 512, Gx_line+28, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TTotalP, "ZZZZ,ZZZ,ZZ9.9999")), 519, Gx_line+14, 626, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV46TTotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 685, Gx_line+14, 792, Gx_line+29, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(516, Gx_line+7, 793, Gx_line+7, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+44);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8G0( true, 0) ;
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
         /* 'VALIDACLIENTE' Routine */
         returnInSub = false;
         /* Using cursor P008G6 */
         pr_default.execute(4, new Object[] {AV49MvATip, AV50MvACod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A14MvACod = P008G6_A14MvACod[0];
            A13MvATip = P008G6_A13MvATip[0];
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51MVCCosto)) )
         {
            /* Using cursor P008G7 */
            pr_default.execute(5, new Object[] {AV51MVCCosto});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A79COSCod = P008G7_A79COSCod[0];
               A761COSDsc = P008G7_A761COSDsc[0];
               AV48Cliente = StringUtil.Trim( A761COSDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(5);
         }
      }

      protected void H8G0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+45, 696, Gx_line+59, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+63, 708, Gx_line+77, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+27, 703, Gx_line+41, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 731, Gx_line+63, 770, Gx_line+78, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 707, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 8, Gx_line+220, 29, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Salida", 35, Gx_line+220, 83, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de movimiento", 242, Gx_line+220, 345, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+240, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Salidas", 301, Gx_line+53, 472, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 95, Gx_line+220, 126, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 573, Gx_line+220, 620, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Almacen", 118, Gx_line+108, 170, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Linea de productos", 118, Gx_line+130, 230, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 118, Gx_line+150, 172, Gx_line+164, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 253, Gx_line+125, 596, Gx_line+149, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 253, Gx_line+145, 596, Gx_line+169, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 118, Gx_line+173, 155, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27Hdesde, "99/99/99"), 253, Gx_line+168, 337, Gx_line+192, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 456, Gx_line+173, 491, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28HHasta, "99/99/99"), 511, Gx_line+168, 595, Gx_line+192, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia", 135, Gx_line+220, 192, Gx_line+233, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Logo)) ? AV54Logo_GXI : AV37Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 10, Gx_line+3, 168, Gx_line+75) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 11, Gx_line+76, 319, Gx_line+94, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 11, Gx_line+94, 128, Gx_line+112, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 7, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T. Costo", 736, Gx_line+220, 780, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("C.Unit.", 678, Gx_line+220, 713, Gx_line+233, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente / C.Costo", 420, Gx_line+220, 509, Gx_line+233, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+240);
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
         AV33Empresa = "";
         AV38Session = context.GetSession();
         AV34EmpDir = "";
         AV35EmpRUC = "";
         AV36Ruta = "";
         AV37Logo = "";
         AV54Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P008G2_A63AlmCod = new int[1] ;
         P008G2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P008G3_A52LinCod = new int[1] ;
         P008G3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P008G4_A28ProdCod = new string[] {""} ;
         P008G4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A1287MVCCosto = "";
         A13MvATip = "";
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         P008G5_A28ProdCod = new string[] {""} ;
         P008G5_A13MvATip = new string[] {""} ;
         P008G5_A14MvACod = new string[] {""} ;
         P008G5_A1287MVCCosto = new string[] {""} ;
         P008G5_A1278MvARef = new string[] {""} ;
         P008G5_A1276MvAOcom = new string[] {""} ;
         P008G5_A1250MVADPrecio = new decimal[1] ;
         P008G5_A1249MVADCosto = new decimal[1] ;
         P008G5_A1248MvADCant = new decimal[1] ;
         P008G5_A1274MvAMovDsc = new string[] {""} ;
         P008G5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008G5_A1370MVSts = new string[] {""} ;
         P008G5_A21MvAlm = new int[1] ;
         P008G5_A50FamCod = new int[1] ;
         P008G5_n50FamCod = new bool[] {false} ;
         P008G5_A51SublCod = new int[1] ;
         P008G5_n51SublCod = new bool[] {false} ;
         P008G5_A52LinCod = new int[1] ;
         P008G5_A22MvAMov = new int[1] ;
         P008G5_A55ProdDsc = new string[] {""} ;
         P008G5_A30MvADItem = new int[1] ;
         A14MvACod = "";
         A1278MvARef = "";
         A1276MvAOcom = "";
         A1274MvAMovDsc = "";
         AV49MvATip = "";
         AV50MvACod = "";
         AV51MVCCosto = "";
         AV43MVARef = "";
         AV48Cliente = "";
         P008G6_A14MvACod = new string[] {""} ;
         P008G6_A13MvATip = new string[] {""} ;
         P008G7_A79COSCod = new string[] {""} ;
         P008G7_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV37Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumensalidaspdf__default(),
            new Object[][] {
                new Object[] {
               P008G2_A63AlmCod, P008G2_A436AlmDsc
               }
               , new Object[] {
               P008G3_A52LinCod, P008G3_A1153LinDsc
               }
               , new Object[] {
               P008G4_A28ProdCod, P008G4_A55ProdDsc
               }
               , new Object[] {
               P008G5_A28ProdCod, P008G5_A13MvATip, P008G5_A14MvACod, P008G5_A1287MVCCosto, P008G5_A1278MvARef, P008G5_A1276MvAOcom, P008G5_A1250MVADPrecio, P008G5_A1249MVADCosto, P008G5_A1248MvADCant, P008G5_A1274MvAMovDsc,
               P008G5_A25MvAFec, P008G5_A1370MVSts, P008G5_A21MvAlm, P008G5_A50FamCod, P008G5_n50FamCod, P008G5_A51SublCod, P008G5_n51SublCod, P008G5_A52LinCod, P008G5_A22MvAMov, P008G5_A55ProdDsc,
               P008G5_A30MvADItem
               }
               , new Object[] {
               P008G6_A14MvACod, P008G6_A13MvATip
               }
               , new Object[] {
               P008G7_A79COSCod, P008G7_A761COSDsc
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
      private int AV29MovCod ;
      private int AV30LinCod ;
      private int AV39AlmCod ;
      private int AV40SublCod ;
      private int AV41FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A22MvAMov ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV45TTotalP ;
      private decimal AV46TTotalC ;
      private decimal A1249MVADCosto ;
      private decimal A1250MVADPrecio ;
      private decimal A1248MvADCant ;
      private decimal AV32TotalP ;
      private decimal AV42TotalC ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV31Prodcod ;
      private string AV44CosCod ;
      private string AV47Tipo ;
      private string AV33Empresa ;
      private string AV34EmpDir ;
      private string AV35EmpRUC ;
      private string AV36Ruta ;
      private string AV22Filtro1 ;
      private string AV23Filtro2 ;
      private string AV24Filtro3 ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1287MVCCosto ;
      private string A13MvATip ;
      private string A1370MVSts ;
      private string A14MvACod ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A1274MvAMovDsc ;
      private string AV49MvATip ;
      private string AV50MvACod ;
      private string AV51MVCCosto ;
      private string AV43MVARef ;
      private string AV48Cliente ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV27Hdesde ;
      private DateTime AV28HHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK8G6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV54Logo_GXI ;
      private string AV37Logo ;
      private string Logo ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MovCod ;
      private int aP1_LinCod ;
      private string aP2_Prodcod ;
      private DateTime aP3_Hdesde ;
      private DateTime aP4_HHasta ;
      private int aP5_AlmCod ;
      private int aP6_SublCod ;
      private int aP7_FamCod ;
      private string aP8_CosCod ;
      private string aP9_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P008G2_A63AlmCod ;
      private string[] P008G2_A436AlmDsc ;
      private int[] P008G3_A52LinCod ;
      private string[] P008G3_A1153LinDsc ;
      private string[] P008G4_A28ProdCod ;
      private string[] P008G4_A55ProdDsc ;
      private string[] P008G5_A28ProdCod ;
      private string[] P008G5_A13MvATip ;
      private string[] P008G5_A14MvACod ;
      private string[] P008G5_A1287MVCCosto ;
      private string[] P008G5_A1278MvARef ;
      private string[] P008G5_A1276MvAOcom ;
      private decimal[] P008G5_A1250MVADPrecio ;
      private decimal[] P008G5_A1249MVADCosto ;
      private decimal[] P008G5_A1248MvADCant ;
      private string[] P008G5_A1274MvAMovDsc ;
      private DateTime[] P008G5_A25MvAFec ;
      private string[] P008G5_A1370MVSts ;
      private int[] P008G5_A21MvAlm ;
      private int[] P008G5_A50FamCod ;
      private bool[] P008G5_n50FamCod ;
      private int[] P008G5_A51SublCod ;
      private bool[] P008G5_n51SublCod ;
      private int[] P008G5_A52LinCod ;
      private int[] P008G5_A22MvAMov ;
      private string[] P008G5_A55ProdDsc ;
      private int[] P008G5_A30MvADItem ;
      private string[] P008G6_A14MvACod ;
      private string[] P008G6_A13MvATip ;
      private string[] P008G7_A79COSCod ;
      private string[] P008G7_A761COSDsc ;
   }

   public class r_resumensalidaspdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008G5( IGxContext context ,
                                             int AV29MovCod ,
                                             int AV30LinCod ,
                                             int AV40SublCod ,
                                             int AV41FamCod ,
                                             string AV31Prodcod ,
                                             string AV44CosCod ,
                                             string AV47Tipo ,
                                             int AV39AlmCod ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             string A1287MVCCosto ,
                                             decimal A1249MVADCosto ,
                                             int A21MvAlm ,
                                             string A13MvATip ,
                                             DateTime A25MvAFec ,
                                             DateTime AV27Hdesde ,
                                             DateTime AV28HHasta ,
                                             string A1370MVSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ProdCod], T1.[MvATip], T1.[MvACod], T3.[MVCCosto], T3.[MvARef], T3.[MvAOcom], T1.[MVADPrecio], T1.[MVADCosto], T1.[MvADCant], T4.[MovDsc] AS MvAMovDsc, T3.[MvAFec], T3.[MVSts], T3.[MvAlm], T2.[FamCod], T2.[SublCod], T2.[LinCod], T3.[MvAMov] AS MvAMov, T2.[ProdDsc], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T4 ON T4.[MovCod] = T3.[MvAMov])";
         AddWhere(sWhereString, "(T1.[MvATip] <> 'ING')");
         AddWhere(sWhereString, "(T3.[MvAFec] >= @AV27Hdesde and T3.[MvAFec] <= @AV28HHasta)");
         AddWhere(sWhereString, "(T3.[MVSts] <> 'A')");
         if ( ! (0==AV29MovCod) )
         {
            AddWhere(sWhereString, "(T3.[MvAMov] = @AV29MovCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV30LinCod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV30LinCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV40SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SublCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV41FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV41FamCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31Prodcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44CosCod)) )
         {
            AddWhere(sWhereString, "(T3.[MVCCosto] = @AV44CosCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV47Tipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] = 0)");
         }
         if ( StringUtil.StrCmp(AV47Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] <> 0)");
         }
         if ( ! (0==AV39AlmCod) )
         {
            AddWhere(sWhereString, "(T3.[MvAlm] = @AV39AlmCod)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[MvAFec]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 3 :
                     return conditional_P008G5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP008G2;
          prmP008G2 = new Object[] {
          new ParDef("@AV39AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008G3;
          prmP008G3 = new Object[] {
          new ParDef("@AV30LinCod",GXType.Int32,6,0)
          };
          Object[] prmP008G4;
          prmP008G4 = new Object[] {
          new ParDef("@AV31Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008G6;
          prmP008G6 = new Object[] {
          new ParDef("@AV49MvATip",GXType.NChar,3,0) ,
          new ParDef("@AV50MvACod",GXType.NChar,12,0)
          };
          Object[] prmP008G7;
          prmP008G7 = new Object[] {
          new ParDef("@AV51MVCCosto",GXType.NChar,10,0)
          };
          Object[] prmP008G5;
          prmP008G5 = new Object[] {
          new ParDef("@AV27Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV28HHasta",GXType.Date,8,0) ,
          new ParDef("@AV29MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV41FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV31Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV44CosCod",GXType.NChar,10,0) ,
          new ParDef("@AV39AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008G2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV39AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV30LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV31Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008G6", "SELECT [MvACod], [MvATip] FROM [AGUIAS] WHERE [MvATip] = @AV49MvATip and [MvACod] = @AV50MvACod ORDER BY [MvATip], [MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008G7", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV51MVCCosto ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008G7,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 1);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                ((bool[]) buf[14])[0] = rslt.wasNull(14);
                ((int[]) buf[15])[0] = rslt.getInt(15);
                ((bool[]) buf[16])[0] = rslt.wasNull(15);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 100);
                ((int[]) buf[20])[0] = rslt.getInt(19);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
