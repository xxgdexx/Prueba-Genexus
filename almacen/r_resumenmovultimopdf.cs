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
   public class r_resumenmovultimopdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_resumenmovultimopdf.aspx")), "almacen.r_resumenmovultimopdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_resumenmovultimopdf.aspx")))) ;
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
            gxfirstwebparm = GetFirstPar( "Lincod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV35Lincod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV53SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV22FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV45ProdCod = GetPar( "ProdCod");
                  AV23FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
                  AV40nOrden = (short)(NumberUtil.Val( GetPar( "nOrden"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV57TipInforme = GetPar( "TipInforme");
                  AV38MovCod = (int)(NumberUtil.Val( GetPar( "MovCod"), "."));
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

      public r_resumenmovultimopdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenmovultimopdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_Lincod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref string aP3_ProdCod ,
                           ref DateTime aP4_FDesde ,
                           ref short aP5_nOrden ,
                           ref int aP6_AlmCod ,
                           ref string aP7_TipInforme ,
                           ref int aP8_MovCod )
      {
         this.AV35Lincod = aP0_Lincod;
         this.AV53SubLCod = aP1_SubLCod;
         this.AV22FamCod = aP2_FamCod;
         this.AV45ProdCod = aP3_ProdCod;
         this.AV23FDesde = aP4_FDesde;
         this.AV40nOrden = aP5_nOrden;
         this.AV9AlmCod = aP6_AlmCod;
         this.AV57TipInforme = aP7_TipInforme;
         this.AV38MovCod = aP8_MovCod;
         initialize();
         executePrivate();
         aP0_Lincod=this.AV35Lincod;
         aP1_SubLCod=this.AV53SubLCod;
         aP2_FamCod=this.AV22FamCod;
         aP3_ProdCod=this.AV45ProdCod;
         aP4_FDesde=this.AV23FDesde;
         aP5_nOrden=this.AV40nOrden;
         aP6_AlmCod=this.AV9AlmCod;
         aP7_TipInforme=this.AV57TipInforme;
         aP8_MovCod=this.AV38MovCod;
      }

      public int executeUdp( ref int aP0_Lincod ,
                             ref int aP1_SubLCod ,
                             ref int aP2_FamCod ,
                             ref string aP3_ProdCod ,
                             ref DateTime aP4_FDesde ,
                             ref short aP5_nOrden ,
                             ref int aP6_AlmCod ,
                             ref string aP7_TipInforme )
      {
         execute(ref aP0_Lincod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_ProdCod, ref aP4_FDesde, ref aP5_nOrden, ref aP6_AlmCod, ref aP7_TipInforme, ref aP8_MovCod);
         return AV38MovCod ;
      }

      public void executeSubmit( ref int aP0_Lincod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref string aP3_ProdCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref short aP5_nOrden ,
                                 ref int aP6_AlmCod ,
                                 ref string aP7_TipInforme ,
                                 ref int aP8_MovCod )
      {
         r_resumenmovultimopdf objr_resumenmovultimopdf;
         objr_resumenmovultimopdf = new r_resumenmovultimopdf();
         objr_resumenmovultimopdf.AV35Lincod = aP0_Lincod;
         objr_resumenmovultimopdf.AV53SubLCod = aP1_SubLCod;
         objr_resumenmovultimopdf.AV22FamCod = aP2_FamCod;
         objr_resumenmovultimopdf.AV45ProdCod = aP3_ProdCod;
         objr_resumenmovultimopdf.AV23FDesde = aP4_FDesde;
         objr_resumenmovultimopdf.AV40nOrden = aP5_nOrden;
         objr_resumenmovultimopdf.AV9AlmCod = aP6_AlmCod;
         objr_resumenmovultimopdf.AV57TipInforme = aP7_TipInforme;
         objr_resumenmovultimopdf.AV38MovCod = aP8_MovCod;
         objr_resumenmovultimopdf.context.SetSubmitInitialConfig(context);
         objr_resumenmovultimopdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenmovultimopdf);
         aP0_Lincod=this.AV35Lincod;
         aP1_SubLCod=this.AV53SubLCod;
         aP2_FamCod=this.AV22FamCod;
         aP3_ProdCod=this.AV45ProdCod;
         aP4_FDesde=this.AV23FDesde;
         aP5_nOrden=this.AV40nOrden;
         aP6_AlmCod=this.AV9AlmCod;
         aP7_TipInforme=this.AV57TipInforme;
         aP8_MovCod=this.AV38MovCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenmovultimopdf)stateInfo).executePrivate();
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
            AV18Empresa = AV51Session.Get("NombreObra");
            AV17EmpDir = AV51Session.Get("EmpDir");
            AV19EmpRUC = AV51Session.Get("EmpRUC");
            AV49Ruta = AV51Session.Get("RUTA") + "/Logo.jpg";
            AV36Logo = AV49Ruta;
            AV68Logo_GXI = GXDbFile.PathToUrl( AV49Ruta);
            AV26Filtro1 = "Todos";
            AV27Filtro2 = "Todos";
            /* Using cursor P008T2 */
            pr_default.execute(0, new Object[] {AV35Lincod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A52LinCod = P008T2_A52LinCod[0];
               A1153LinDsc = P008T2_A1153LinDsc[0];
               AV26Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P008T3 */
            pr_default.execute(1, new Object[] {AV45ProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = P008T3_A28ProdCod[0];
               A55ProdDsc = P008T3_A55ProdDsc[0];
               AV27Filtro2 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P008T4 */
            pr_default.execute(2, new Object[] {AV9AlmCod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A63AlmCod = P008T4_A63AlmCod[0];
               A436AlmDsc = P008T4_A436AlmDsc[0];
               AV28Filtro3 = StringUtil.Trim( A436AlmDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV34Item = 1;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV35Lincod ,
                                                 AV53SubLCod ,
                                                 AV22FamCod ,
                                                 AV45ProdCod ,
                                                 A52LinCod ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A28ProdCod ,
                                                 A1880StkAct ,
                                                 A63AlmCod ,
                                                 AV9AlmCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P008T5 */
            pr_default.execute(3, new Object[] {AV9AlmCod, AV35Lincod, AV53SubLCod, AV22FamCod, AV45ProdCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A49UniCod = P008T5_A49UniCod[0];
               A63AlmCod = P008T5_A63AlmCod[0];
               A1880StkAct = P008T5_A1880StkAct[0];
               A28ProdCod = P008T5_A28ProdCod[0];
               A50FamCod = P008T5_A50FamCod[0];
               n50FamCod = P008T5_n50FamCod[0];
               A51SublCod = P008T5_A51SublCod[0];
               n51SublCod = P008T5_n51SublCod[0];
               A52LinCod = P008T5_A52LinCod[0];
               A55ProdDsc = P008T5_A55ProdDsc[0];
               A1997UniAbr = P008T5_A1997UniAbr[0];
               A1881StkIng = P008T5_A1881StkIng[0];
               A1882StkSal = P008T5_A1882StkSal[0];
               A49UniCod = P008T5_A49UniCod[0];
               A50FamCod = P008T5_A50FamCod[0];
               n50FamCod = P008T5_n50FamCod[0];
               A51SublCod = P008T5_A51SublCod[0];
               n51SublCod = P008T5_n51SublCod[0];
               A52LinCod = P008T5_A52LinCod[0];
               A55ProdDsc = P008T5_A55ProdDsc[0];
               A1997UniAbr = P008T5_A1997UniAbr[0];
               AV45ProdCod = A28ProdCod;
               AV46ProdDsc = A55ProdDsc;
               AV52StkAct = A1880StkAct;
               AV24Fecha = DateTime.MinValue;
               AV65UniAbr = StringUtil.Trim( A1997UniAbr);
               AV11ComCod = "";
               AV39MVATip = "";
               /* Execute user subroutine: 'VALIDADOCUMENTOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(3);
                  this.cleanup();
                  if (true) return;
               }
               H8T0( false, 18) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34Item), "ZZZZ9")), 6, Gx_line+2, 38, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45ProdCod, "@!")), 50, Gx_line+2, 129, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46ProdDsc, "")), 141, Gx_line+2, 472, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV24Fecha, "99/99/99"), 611, Gx_line+2, 658, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11ComCod, "")), 715, Gx_line+2, 794, Gx_line+17, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV52StkAct, "ZZZZ,ZZZ,ZZ9.9999")), 494, Gx_line+1, 601, Gx_line+16, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39MVATip, "")), 670, Gx_line+1, 702, Gx_line+16, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65UniAbr, "")), 479, Gx_line+1, 507, Gx_line+16, 1, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+18);
               AV34Item = (int)(AV34Item+1);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            H8T0( false, 28) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+28);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8T0( true, 0) ;
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
         /* 'VALIDADOCUMENTOS' Routine */
         returnInSub = false;
         AV31Flag = 0;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV38MovCod ,
                                              AV57TipInforme ,
                                              A22MvAMov ,
                                              A1286MvATMov ,
                                              A1370MVSts ,
                                              A21MvAlm ,
                                              AV9AlmCod ,
                                              A28ProdCod ,
                                              AV45ProdCod ,
                                              AV23FDesde } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008T6 */
         pr_default.execute(4, new Object[] {AV23FDesde, AV9AlmCod, AV45ProdCod, AV38MovCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A21MvAlm = P008T6_A21MvAlm[0];
            A28ProdCod = P008T6_A28ProdCod[0];
            A1286MvATMov = P008T6_A1286MvATMov[0];
            A22MvAMov = P008T6_A22MvAMov[0];
            A25MvAFec = P008T6_A25MvAFec[0];
            A1370MVSts = P008T6_A1370MVSts[0];
            A14MvACod = P008T6_A14MvACod[0];
            A13MvATip = P008T6_A13MvATip[0];
            A30MvADItem = P008T6_A30MvADItem[0];
            A21MvAlm = P008T6_A21MvAlm[0];
            A1286MvATMov = P008T6_A1286MvATMov[0];
            A22MvAMov = P008T6_A22MvAMov[0];
            A25MvAFec = P008T6_A25MvAFec[0];
            A1370MVSts = P008T6_A1370MVSts[0];
            AV11ComCod = A14MvACod;
            AV24Fecha = A25MvAFec;
            AV39MVATip = A13MvATip;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void H8T0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 664, Gx_line+31, 696, Gx_line+45, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 664, Gx_line+49, 708, Gx_line+63, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 664, Gx_line+14, 703, Gx_line+28, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 733, Gx_line+49, 772, Gx_line+64, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+31, 770, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 725, Gx_line+14, 772, Gx_line+29, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo", 56, Gx_line+194, 97, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 141, Gx_line+194, 195, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+189, 797, Gx_line+215, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Productos Ultimo Movimiento de Stock", 211, Gx_line+71, 650, Gx_line+91, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("F. Ult. Mov", 604, Gx_line+194, 665, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Documento", 707, Gx_line+194, 792, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Linea", 191, Gx_line+120, 223, Gx_line+134, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 191, Gx_line+143, 245, Gx_line+157, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26Filtro1, "")), 253, Gx_line+115, 596, Gx_line+139, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27Filtro2, "")), 253, Gx_line+138, 596, Gx_line+162, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19EmpRUC, "")), 14, Gx_line+46, 399, Gx_line+64, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17EmpDir, "")), 14, Gx_line+29, 399, Gx_line+47, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18Empresa, "")), 14, Gx_line+11, 399, Gx_line+29, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Al :", 351, Gx_line+93, 381, Gx_line+113, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV23FDesde, "99/99/99"), 391, Gx_line+93, 473, Gx_line+114, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Items.", 7, Gx_line+194, 47, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 191, Gx_line+166, 243, Gx_line+180, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28Filtro3, "")), 253, Gx_line+160, 596, Gx_line+184, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Stock", 555, Gx_line+194, 589, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("T/D", 675, Gx_line+194, 698, Gx_line+208, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("UM", 482, Gx_line+196, 502, Gx_line+210, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+215);
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
         AV51Session = context.GetSession();
         AV17EmpDir = "";
         AV19EmpRUC = "";
         AV49Ruta = "";
         AV36Logo = "";
         AV68Logo_GXI = "";
         AV26Filtro1 = "";
         AV27Filtro2 = "";
         scmdbuf = "";
         P008T2_A52LinCod = new int[1] ;
         P008T2_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P008T3_A28ProdCod = new string[] {""} ;
         P008T3_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         P008T4_A63AlmCod = new int[1] ;
         P008T4_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         AV28Filtro3 = "";
         P008T5_A49UniCod = new int[1] ;
         P008T5_A63AlmCod = new int[1] ;
         P008T5_A1880StkAct = new decimal[1] ;
         P008T5_A28ProdCod = new string[] {""} ;
         P008T5_A50FamCod = new int[1] ;
         P008T5_n50FamCod = new bool[] {false} ;
         P008T5_A51SublCod = new int[1] ;
         P008T5_n51SublCod = new bool[] {false} ;
         P008T5_A52LinCod = new int[1] ;
         P008T5_A55ProdDsc = new string[] {""} ;
         P008T5_A1997UniAbr = new string[] {""} ;
         P008T5_A1881StkIng = new decimal[1] ;
         P008T5_A1882StkSal = new decimal[1] ;
         A1997UniAbr = "";
         AV46ProdDsc = "";
         AV24Fecha = DateTime.MinValue;
         AV65UniAbr = "";
         AV11ComCod = "";
         AV39MVATip = "";
         A1370MVSts = "";
         P008T6_A21MvAlm = new int[1] ;
         P008T6_A28ProdCod = new string[] {""} ;
         P008T6_A1286MvATMov = new short[1] ;
         P008T6_A22MvAMov = new int[1] ;
         P008T6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008T6_A1370MVSts = new string[] {""} ;
         P008T6_A14MvACod = new string[] {""} ;
         P008T6_A13MvATip = new string[] {""} ;
         P008T6_A30MvADItem = new int[1] ;
         A25MvAFec = DateTime.MinValue;
         A14MvACod = "";
         A13MvATip = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenmovultimopdf__default(),
            new Object[][] {
                new Object[] {
               P008T2_A52LinCod, P008T2_A1153LinDsc
               }
               , new Object[] {
               P008T3_A28ProdCod, P008T3_A55ProdDsc
               }
               , new Object[] {
               P008T4_A63AlmCod, P008T4_A436AlmDsc
               }
               , new Object[] {
               P008T5_A49UniCod, P008T5_A63AlmCod, P008T5_A1880StkAct, P008T5_A28ProdCod, P008T5_A50FamCod, P008T5_n50FamCod, P008T5_A51SublCod, P008T5_n51SublCod, P008T5_A52LinCod, P008T5_A55ProdDsc,
               P008T5_A1997UniAbr, P008T5_A1881StkIng, P008T5_A1882StkSal
               }
               , new Object[] {
               P008T6_A21MvAlm, P008T6_A28ProdCod, P008T6_A1286MvATMov, P008T6_A22MvAMov, P008T6_A25MvAFec, P008T6_A1370MVSts, P008T6_A14MvACod, P008T6_A13MvATip, P008T6_A30MvADItem
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
      private short AV40nOrden ;
      private short AV31Flag ;
      private short A1286MvATMov ;
      private int AV35Lincod ;
      private int AV53SubLCod ;
      private int AV22FamCod ;
      private int AV9AlmCod ;
      private int AV38MovCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A52LinCod ;
      private int A63AlmCod ;
      private int AV34Item ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A49UniCod ;
      private int Gx_OldLine ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV52StkAct ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV45ProdCod ;
      private string AV57TipInforme ;
      private string AV18Empresa ;
      private string AV17EmpDir ;
      private string AV19EmpRUC ;
      private string AV49Ruta ;
      private string AV26Filtro1 ;
      private string AV27Filtro2 ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A436AlmDsc ;
      private string AV28Filtro3 ;
      private string A1997UniAbr ;
      private string AV46ProdDsc ;
      private string AV65UniAbr ;
      private string AV11ComCod ;
      private string AV39MVATip ;
      private string A1370MVSts ;
      private string A14MvACod ;
      private string A13MvATip ;
      private string Gx_time ;
      private DateTime AV23FDesde ;
      private DateTime AV24Fecha ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool returnInSub ;
      private string AV68Logo_GXI ;
      private string AV36Logo ;
      private IGxSession AV51Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_Lincod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private string aP3_ProdCod ;
      private DateTime aP4_FDesde ;
      private short aP5_nOrden ;
      private int aP6_AlmCod ;
      private string aP7_TipInforme ;
      private int aP8_MovCod ;
      private IDataStoreProvider pr_default ;
      private int[] P008T2_A52LinCod ;
      private string[] P008T2_A1153LinDsc ;
      private string[] P008T3_A28ProdCod ;
      private string[] P008T3_A55ProdDsc ;
      private int[] P008T4_A63AlmCod ;
      private string[] P008T4_A436AlmDsc ;
      private int[] P008T5_A49UniCod ;
      private int[] P008T5_A63AlmCod ;
      private decimal[] P008T5_A1880StkAct ;
      private string[] P008T5_A28ProdCod ;
      private int[] P008T5_A50FamCod ;
      private bool[] P008T5_n50FamCod ;
      private int[] P008T5_A51SublCod ;
      private bool[] P008T5_n51SublCod ;
      private int[] P008T5_A52LinCod ;
      private string[] P008T5_A55ProdDsc ;
      private string[] P008T5_A1997UniAbr ;
      private decimal[] P008T5_A1881StkIng ;
      private decimal[] P008T5_A1882StkSal ;
      private int[] P008T6_A21MvAlm ;
      private string[] P008T6_A28ProdCod ;
      private short[] P008T6_A1286MvATMov ;
      private int[] P008T6_A22MvAMov ;
      private DateTime[] P008T6_A25MvAFec ;
      private string[] P008T6_A1370MVSts ;
      private string[] P008T6_A14MvACod ;
      private string[] P008T6_A13MvATip ;
      private int[] P008T6_A30MvADItem ;
   }

   public class r_resumenmovultimopdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008T5( IGxContext context ,
                                             int AV35Lincod ,
                                             int AV53SubLCod ,
                                             int AV22FamCod ,
                                             string AV45ProdCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             decimal A1880StkAct ,
                                             int A63AlmCod ,
                                             int AV9AlmCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.[UniCod], T1.[AlmCod], T1.[StkIng] - T1.[StkSal] AS StkAct, T1.[ProdCod], T2.[FamCod], T2.[SublCod], T2.[LinCod], T2.[ProdDsc], T3.[UniAbr], T1.[StkIng], T1.[StkSal] FROM (([ASTOCKACTUAL] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod])";
         AddWhere(sWhereString, "(T1.[StkIng] - T1.[StkSal] <> 0)");
         AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         if ( ! (0==AV35Lincod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV35Lincod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV53SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV53SubLCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV22FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV22FamCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV45ProdCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [StkAct]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008T6( IGxContext context ,
                                             int AV38MovCod ,
                                             string AV57TipInforme ,
                                             int A22MvAMov ,
                                             short A1286MvATMov ,
                                             string A1370MVSts ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             string A28ProdCod ,
                                             string AV45ProdCod ,
                                             DateTime AV23FDesde )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT TOP 1 T2.[MvAlm], T1.[ProdCod], T2.[MvATMov], T2.[MvAMov], T2.[MvAFec], T2.[MVSts], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
         AddWhere(sWhereString, "(T2.[MvAFec] <= @AV23FDesde)");
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV45ProdCod)");
         if ( ! (0==AV38MovCod) )
         {
            AddWhere(sWhereString, "(T2.[MvAMov] = @AV38MovCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV57TipInforme, "C") == 0 )
         {
            AddWhere(sWhereString, "(T2.[MvATMov] = 1)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MvAFec] DESC";
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
               case 3 :
                     return conditional_P008T5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] );
               case 4 :
                     return conditional_P008T6(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] );
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
          Object[] prmP008T2;
          prmP008T2 = new Object[] {
          new ParDef("@AV35Lincod",GXType.Int32,6,0)
          };
          Object[] prmP008T3;
          prmP008T3 = new Object[] {
          new ParDef("@AV45ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP008T4;
          prmP008T4 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008T5;
          prmP008T5 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV35Lincod",GXType.Int32,6,0) ,
          new ParDef("@AV53SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV22FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV45ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP008T6;
          prmP008T6 = new Object[] {
          new ParDef("@AV23FDesde",GXType.Date,8,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV45ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV38MovCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008T2", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV35Lincod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008T3", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV45ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008T4", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV9AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008T5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008T6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008T6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 100);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((string[]) buf[6])[0] = rslt.getString(7, 12);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
       }
    }

 }

}
