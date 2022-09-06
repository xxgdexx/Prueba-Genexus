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
   public class r_resumenentradas : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_resumenentradas.aspx")), "almacen.r_resumenentradas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_resumenentradas.aspx")))) ;
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
                  AV40SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV41FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV46Tipo = GetPar( "Tipo");
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

      public r_resumenentradas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenentradas( IGxContext context )
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
                           ref int aP6_SubLCod ,
                           ref int aP7_FamCod ,
                           ref string aP8_Tipo )
      {
         this.AV29MovCod = aP0_MovCod;
         this.AV30LinCod = aP1_LinCod;
         this.AV31Prodcod = aP2_Prodcod;
         this.AV27Hdesde = aP3_Hdesde;
         this.AV28HHasta = aP4_HHasta;
         this.AV39AlmCod = aP5_AlmCod;
         this.AV40SubLCod = aP6_SubLCod;
         this.AV41FamCod = aP7_FamCod;
         this.AV46Tipo = aP8_Tipo;
         initialize();
         executePrivate();
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_AlmCod=this.AV39AlmCod;
         aP6_SubLCod=this.AV40SubLCod;
         aP7_FamCod=this.AV41FamCod;
         aP8_Tipo=this.AV46Tipo;
      }

      public string executeUdp( ref int aP0_MovCod ,
                                ref int aP1_LinCod ,
                                ref string aP2_Prodcod ,
                                ref DateTime aP3_Hdesde ,
                                ref DateTime aP4_HHasta ,
                                ref int aP5_AlmCod ,
                                ref int aP6_SubLCod ,
                                ref int aP7_FamCod )
      {
         execute(ref aP0_MovCod, ref aP1_LinCod, ref aP2_Prodcod, ref aP3_Hdesde, ref aP4_HHasta, ref aP5_AlmCod, ref aP6_SubLCod, ref aP7_FamCod, ref aP8_Tipo);
         return AV46Tipo ;
      }

      public void executeSubmit( ref int aP0_MovCod ,
                                 ref int aP1_LinCod ,
                                 ref string aP2_Prodcod ,
                                 ref DateTime aP3_Hdesde ,
                                 ref DateTime aP4_HHasta ,
                                 ref int aP5_AlmCod ,
                                 ref int aP6_SubLCod ,
                                 ref int aP7_FamCod ,
                                 ref string aP8_Tipo )
      {
         r_resumenentradas objr_resumenentradas;
         objr_resumenentradas = new r_resumenentradas();
         objr_resumenentradas.AV29MovCod = aP0_MovCod;
         objr_resumenentradas.AV30LinCod = aP1_LinCod;
         objr_resumenentradas.AV31Prodcod = aP2_Prodcod;
         objr_resumenentradas.AV27Hdesde = aP3_Hdesde;
         objr_resumenentradas.AV28HHasta = aP4_HHasta;
         objr_resumenentradas.AV39AlmCod = aP5_AlmCod;
         objr_resumenentradas.AV40SubLCod = aP6_SubLCod;
         objr_resumenentradas.AV41FamCod = aP7_FamCod;
         objr_resumenentradas.AV46Tipo = aP8_Tipo;
         objr_resumenentradas.context.SetSubmitInitialConfig(context);
         objr_resumenentradas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenentradas);
         aP0_MovCod=this.AV29MovCod;
         aP1_LinCod=this.AV30LinCod;
         aP2_Prodcod=this.AV31Prodcod;
         aP3_Hdesde=this.AV27Hdesde;
         aP4_HHasta=this.AV28HHasta;
         aP5_AlmCod=this.AV39AlmCod;
         aP6_SubLCod=this.AV40SubLCod;
         aP7_FamCod=this.AV41FamCod;
         aP8_Tipo=this.AV46Tipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenentradas)stateInfo).executePrivate();
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
            AV49Logo_GXI = GXDbFile.PathToUrl( AV36Ruta);
            AV22Filtro1 = "Todos";
            AV23Filtro2 = "Todos";
            AV24Filtro3 = "Todos";
            /* Using cursor P00DR2 */
            pr_default.execute(0, new Object[] {AV39AlmCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P00DR2_A63AlmCod[0];
               A436AlmDsc = P00DR2_A436AlmDsc[0];
               AV22Filtro1 = StringUtil.Trim( A436AlmDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P00DR3 */
            pr_default.execute(1, new Object[] {AV30LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P00DR3_A52LinCod[0];
               A1153LinDsc = P00DR3_A1153LinDsc[0];
               AV23Filtro2 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Using cursor P00DR4 */
            pr_default.execute(2, new Object[] {AV31Prodcod});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A28ProdCod = P00DR4_A28ProdCod[0];
               A55ProdDsc = P00DR4_A55ProdDsc[0];
               AV24Filtro3 = A55ProdDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
            AV44TTotalP = 0.0000m;
            AV45TTotalC = 0.00m;
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV29MovCod ,
                                                 AV30LinCod ,
                                                 AV31Prodcod ,
                                                 AV39AlmCod ,
                                                 AV40SubLCod ,
                                                 AV41FamCod ,
                                                 AV46Tipo ,
                                                 A22MvAMov ,
                                                 A52LinCod ,
                                                 A28ProdCod ,
                                                 A21MvAlm ,
                                                 A51SublCod ,
                                                 A50FamCod ,
                                                 A1249MVADCosto ,
                                                 A25MvAFec ,
                                                 AV27Hdesde ,
                                                 AV28HHasta ,
                                                 A1370MVSts ,
                                                 A13MvATip } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor P00DR5 */
            pr_default.execute(3, new Object[] {AV27Hdesde, AV28HHasta, AV29MovCod, AV30LinCod, AV31Prodcod, AV39AlmCod, AV40SubLCod, AV41FamCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               BRKDR6 = false;
               A1370MVSts = P00DR5_A1370MVSts[0];
               A13MvATip = P00DR5_A13MvATip[0];
               A1249MVADCosto = P00DR5_A1249MVADCosto[0];
               A25MvAFec = P00DR5_A25MvAFec[0];
               A50FamCod = P00DR5_A50FamCod[0];
               n50FamCod = P00DR5_n50FamCod[0];
               A51SublCod = P00DR5_A51SublCod[0];
               n51SublCod = P00DR5_n51SublCod[0];
               A21MvAlm = P00DR5_A21MvAlm[0];
               A28ProdCod = P00DR5_A28ProdCod[0];
               A52LinCod = P00DR5_A52LinCod[0];
               A22MvAMov = P00DR5_A22MvAMov[0];
               A1278MvARef = P00DR5_A1278MvARef[0];
               A1276MvAOcom = P00DR5_A1276MvAOcom[0];
               A1250MVADPrecio = P00DR5_A1250MVADPrecio[0];
               A1248MvADCant = P00DR5_A1248MvADCant[0];
               A1274MvAMovDsc = P00DR5_A1274MvAMovDsc[0];
               A14MvACod = P00DR5_A14MvACod[0];
               A55ProdDsc = P00DR5_A55ProdDsc[0];
               A30MvADItem = P00DR5_A30MvADItem[0];
               A50FamCod = P00DR5_A50FamCod[0];
               n50FamCod = P00DR5_n50FamCod[0];
               A51SublCod = P00DR5_A51SublCod[0];
               n51SublCod = P00DR5_n51SublCod[0];
               A52LinCod = P00DR5_A52LinCod[0];
               A55ProdDsc = P00DR5_A55ProdDsc[0];
               A1370MVSts = P00DR5_A1370MVSts[0];
               A25MvAFec = P00DR5_A25MvAFec[0];
               A21MvAlm = P00DR5_A21MvAlm[0];
               A22MvAMov = P00DR5_A22MvAMov[0];
               A1278MvARef = P00DR5_A1278MvARef[0];
               A1276MvAOcom = P00DR5_A1276MvAOcom[0];
               A1274MvAMovDsc = P00DR5_A1274MvAMovDsc[0];
               HDR0( false, 23) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), 90, Gx_line+6, 605, Gx_line+21, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), 4, Gx_line+6, 82, Gx_line+20, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+23);
               AV32TotalP = 0.0000m;
               AV42TotalC = 0.00m;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DR5_A28ProdCod[0], A28ProdCod) == 0 ) )
               {
                  BRKDR6 = false;
                  A1370MVSts = P00DR5_A1370MVSts[0];
                  A13MvATip = P00DR5_A13MvATip[0];
                  A1249MVADCosto = P00DR5_A1249MVADCosto[0];
                  A25MvAFec = P00DR5_A25MvAFec[0];
                  A50FamCod = P00DR5_A50FamCod[0];
                  n50FamCod = P00DR5_n50FamCod[0];
                  A51SublCod = P00DR5_A51SublCod[0];
                  n51SublCod = P00DR5_n51SublCod[0];
                  A21MvAlm = P00DR5_A21MvAlm[0];
                  A52LinCod = P00DR5_A52LinCod[0];
                  A22MvAMov = P00DR5_A22MvAMov[0];
                  A1278MvARef = P00DR5_A1278MvARef[0];
                  A1276MvAOcom = P00DR5_A1276MvAOcom[0];
                  A1250MVADPrecio = P00DR5_A1250MVADPrecio[0];
                  A1248MvADCant = P00DR5_A1248MvADCant[0];
                  A1274MvAMovDsc = P00DR5_A1274MvAMovDsc[0];
                  A14MvACod = P00DR5_A14MvACod[0];
                  A30MvADItem = P00DR5_A30MvADItem[0];
                  A50FamCod = P00DR5_A50FamCod[0];
                  n50FamCod = P00DR5_n50FamCod[0];
                  A51SublCod = P00DR5_A51SublCod[0];
                  n51SublCod = P00DR5_n51SublCod[0];
                  A52LinCod = P00DR5_A52LinCod[0];
                  A1370MVSts = P00DR5_A1370MVSts[0];
                  A25MvAFec = P00DR5_A25MvAFec[0];
                  A21MvAlm = P00DR5_A21MvAlm[0];
                  A22MvAMov = P00DR5_A22MvAMov[0];
                  A1278MvARef = P00DR5_A1278MvARef[0];
                  A1276MvAOcom = P00DR5_A1276MvAOcom[0];
                  A1274MvAMovDsc = P00DR5_A1274MvAMovDsc[0];
                  if ( DateTimeUtil.ResetTime ( A25MvAFec ) <= DateTimeUtil.ResetTime ( AV28HHasta ) )
                  {
                     if ( DateTimeUtil.ResetTime ( A25MvAFec ) >= DateTimeUtil.ResetTime ( AV27Hdesde ) )
                     {
                        if ( StringUtil.StrCmp(A1370MVSts, "A") != 0 )
                        {
                           if ( StringUtil.StrCmp(A13MvATip, "ING") == 0 )
                           {
                              AV43MVARef = (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom);
                              HDR0( false, 17) ;
                              getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 4, Gx_line+2, 43, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 53, Gx_line+2, 123, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 122, Gx_line+2, 179, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), 277, Gx_line+2, 581, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1248MvADCant, "ZZZZ,ZZZ,ZZ9.9999")), 516, Gx_line+2, 621, Gx_line+17, 2, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43MVARef, "")), 180, Gx_line+2, 275, Gx_line+17, 0, 0, 0, 0) ;
                              getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1249MVADCosto, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+2, 789, Gx_line+17, 2+256, 0, 0, 0) ;
                              getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A1250MVADPrecio, "ZZZZZ,ZZZ,ZZ9.999999")), 576, Gx_line+2, 702, Gx_line+17, 2+256, 0, 0, 0) ;
                              Gx_OldLine = Gx_line;
                              Gx_line = (int)(Gx_line+17);
                              AV32TotalP = (decimal)(AV32TotalP+A1248MvADCant);
                              AV42TotalC = (decimal)(AV42TotalC+A1249MVADCosto);
                           }
                        }
                     }
                  }
                  BRKDR6 = true;
                  pr_default.readNext(3);
               }
               AV45TTotalC = (decimal)(AV45TTotalC+AV42TotalC);
               AV44TTotalP = (decimal)(AV44TTotalP+AV32TotalP);
               HDR0( false, 28) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total : ", 463, Gx_line+9, 504, Gx_line+23, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV32TotalP, "ZZZZ,ZZZ,ZZ9.9999")), 515, Gx_line+9, 622, Gx_line+24, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawLine(544, Gx_line+6, 797, Gx_line+6, 1, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+9, 789, Gx_line+24, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+28);
               if ( ! BRKDR6 )
               {
                  BRKDR6 = true;
                  pr_default.readNext(3);
               }
            }
            pr_default.close(3);
            HDR0( false, 45) ;
            getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Total General : ", 414, Gx_line+15, 504, Gx_line+29, 0+256, 0, 0, 0) ;
            getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV44TTotalP, "ZZZZ,ZZZ,ZZ9.9999")), 515, Gx_line+15, 622, Gx_line+30, 2+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(544, Gx_line+11, 797, Gx_line+11, 1, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV45TTotalC, "ZZZZZZ,ZZZ,ZZ9.99")), 682, Gx_line+15, 789, Gx_line+30, 2+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+45);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            HDR0( true, 0) ;
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

      protected void HDR0( bool bFoot ,
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
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 710, Gx_line+45, 768, Gx_line+59, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 723, Gx_line+27, 770, Gx_line+42, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/D", 14, Gx_line+221, 37, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Entrada", 53, Gx_line+221, 117, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo de movimiento", 344, Gx_line+221, 462, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+214, 797, Gx_line+240, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Resumen de Entradas", 292, Gx_line+53, 477, Gx_line+73, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Fecha", 133, Gx_line+221, 168, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cantidad", 570, Gx_line+221, 623, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen", 117, Gx_line+108, 169, Gx_line+122, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Linea de productos", 117, Gx_line+130, 229, Gx_line+144, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Producto", 117, Gx_line+152, 171, Gx_line+166, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 253, Gx_line+103, 596, Gx_line+127, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23Filtro2, "")), 253, Gx_line+125, 596, Gx_line+149, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro3, "")), 253, Gx_line+147, 596, Gx_line+171, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Desde", 117, Gx_line+173, 154, Gx_line+187, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV27Hdesde, "99/99/99"), 253, Gx_line+168, 337, Gx_line+192, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Hasta", 456, Gx_line+172, 491, Gx_line+186, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( AV28HHasta, "99/99/99"), 511, Gx_line+167, 595, Gx_line+191, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Referencia", 190, Gx_line+222, 255, Gx_line+236, 0+256, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV37Logo)) ? AV49Logo_GXI : AV37Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 6, Gx_line+8, 159, Gx_line+81) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33Empresa, "")), 6, Gx_line+83, 314, Gx_line+101, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35EmpRUC, "")), 6, Gx_line+101, 123, Gx_line+119, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T. Costo", 723, Gx_line+221, 771, Gx_line+235, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("C.Unit.", 656, Gx_line+221, 695, Gx_line+235, 0+256, 0, 0, 0) ;
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
         AV49Logo_GXI = "";
         AV22Filtro1 = "";
         AV23Filtro2 = "";
         AV24Filtro3 = "";
         scmdbuf = "";
         P00DR2_A63AlmCod = new int[1] ;
         P00DR2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P00DR3_A52LinCod = new int[1] ;
         P00DR3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         P00DR4_A28ProdCod = new string[] {""} ;
         P00DR4_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         A25MvAFec = DateTime.MinValue;
         A1370MVSts = "";
         A13MvATip = "";
         P00DR5_A1370MVSts = new string[] {""} ;
         P00DR5_A13MvATip = new string[] {""} ;
         P00DR5_A1249MVADCosto = new decimal[1] ;
         P00DR5_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00DR5_A50FamCod = new int[1] ;
         P00DR5_n50FamCod = new bool[] {false} ;
         P00DR5_A51SublCod = new int[1] ;
         P00DR5_n51SublCod = new bool[] {false} ;
         P00DR5_A21MvAlm = new int[1] ;
         P00DR5_A28ProdCod = new string[] {""} ;
         P00DR5_A52LinCod = new int[1] ;
         P00DR5_A22MvAMov = new int[1] ;
         P00DR5_A1278MvARef = new string[] {""} ;
         P00DR5_A1276MvAOcom = new string[] {""} ;
         P00DR5_A1250MVADPrecio = new decimal[1] ;
         P00DR5_A1248MvADCant = new decimal[1] ;
         P00DR5_A1274MvAMovDsc = new string[] {""} ;
         P00DR5_A14MvACod = new string[] {""} ;
         P00DR5_A55ProdDsc = new string[] {""} ;
         P00DR5_A30MvADItem = new int[1] ;
         A1278MvARef = "";
         A1276MvAOcom = "";
         A1274MvAMovDsc = "";
         A14MvACod = "";
         AV43MVARef = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV37Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_resumenentradas__default(),
            new Object[][] {
                new Object[] {
               P00DR2_A63AlmCod, P00DR2_A436AlmDsc
               }
               , new Object[] {
               P00DR3_A52LinCod, P00DR3_A1153LinDsc
               }
               , new Object[] {
               P00DR4_A28ProdCod, P00DR4_A55ProdDsc
               }
               , new Object[] {
               P00DR5_A1370MVSts, P00DR5_A13MvATip, P00DR5_A1249MVADCosto, P00DR5_A25MvAFec, P00DR5_A50FamCod, P00DR5_n50FamCod, P00DR5_A51SublCod, P00DR5_n51SublCod, P00DR5_A21MvAlm, P00DR5_A28ProdCod,
               P00DR5_A52LinCod, P00DR5_A22MvAMov, P00DR5_A1278MvARef, P00DR5_A1276MvAOcom, P00DR5_A1250MVADPrecio, P00DR5_A1248MvADCant, P00DR5_A1274MvAMovDsc, P00DR5_A14MvACod, P00DR5_A55ProdDsc, P00DR5_A30MvADItem
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
      private int AV40SubLCod ;
      private int AV41FamCod ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A30MvADItem ;
      private int Gx_OldLine ;
      private decimal AV44TTotalP ;
      private decimal AV45TTotalC ;
      private decimal A1249MVADCosto ;
      private decimal A1250MVADPrecio ;
      private decimal A1248MvADCant ;
      private decimal AV32TotalP ;
      private decimal AV42TotalC ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV31Prodcod ;
      private string AV46Tipo ;
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
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A1274MvAMovDsc ;
      private string A14MvACod ;
      private string AV43MVARef ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV27Hdesde ;
      private DateTime AV28HHasta ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRKDR6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV49Logo_GXI ;
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
      private int aP6_SubLCod ;
      private int aP7_FamCod ;
      private string aP8_Tipo ;
      private IDataStoreProvider pr_default ;
      private int[] P00DR2_A63AlmCod ;
      private string[] P00DR2_A436AlmDsc ;
      private int[] P00DR3_A52LinCod ;
      private string[] P00DR3_A1153LinDsc ;
      private string[] P00DR4_A28ProdCod ;
      private string[] P00DR4_A55ProdDsc ;
      private string[] P00DR5_A1370MVSts ;
      private string[] P00DR5_A13MvATip ;
      private decimal[] P00DR5_A1249MVADCosto ;
      private DateTime[] P00DR5_A25MvAFec ;
      private int[] P00DR5_A50FamCod ;
      private bool[] P00DR5_n50FamCod ;
      private int[] P00DR5_A51SublCod ;
      private bool[] P00DR5_n51SublCod ;
      private int[] P00DR5_A21MvAlm ;
      private string[] P00DR5_A28ProdCod ;
      private int[] P00DR5_A52LinCod ;
      private int[] P00DR5_A22MvAMov ;
      private string[] P00DR5_A1278MvARef ;
      private string[] P00DR5_A1276MvAOcom ;
      private decimal[] P00DR5_A1250MVADPrecio ;
      private decimal[] P00DR5_A1248MvADCant ;
      private string[] P00DR5_A1274MvAMovDsc ;
      private string[] P00DR5_A14MvACod ;
      private string[] P00DR5_A55ProdDsc ;
      private int[] P00DR5_A30MvADItem ;
   }

   public class r_resumenentradas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DR5( IGxContext context ,
                                             int AV29MovCod ,
                                             int AV30LinCod ,
                                             string AV31Prodcod ,
                                             int AV39AlmCod ,
                                             int AV40SubLCod ,
                                             int AV41FamCod ,
                                             string AV46Tipo ,
                                             int A22MvAMov ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             decimal A1249MVADCosto ,
                                             DateTime A25MvAFec ,
                                             DateTime AV27Hdesde ,
                                             DateTime AV28HHasta ,
                                             string A1370MVSts ,
                                             string A13MvATip )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[8];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T3.[MVSts], T1.[MvATip], T1.[MVADCosto], T3.[MvAFec], T2.[FamCod], T2.[SublCod], T3.[MvAlm], T1.[ProdCod], T2.[LinCod], T3.[MvAMov] AS MvAMov, T3.[MvARef], T3.[MvAOcom], T1.[MVADPrecio], T1.[MvADCant], T4.[MovDsc] AS MvAMovDsc, T1.[MvACod], T2.[ProdDsc], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [AGUIAS] T3 ON T3.[MvATip] = T1.[MvATip] AND T3.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T4 ON T4.[MovCod] = T3.[MvAMov])";
         AddWhere(sWhereString, "(T3.[MvAFec] >= @AV27Hdesde and T3.[MvAFec] <= @AV28HHasta)");
         AddWhere(sWhereString, "(T3.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T1.[MvATip] = 'ING')");
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV31Prodcod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV39AlmCod) )
         {
            AddWhere(sWhereString, "(T3.[MvAlm] = @AV39AlmCod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV40SubLCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV40SubLCod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV41FamCod) )
         {
            AddWhere(sWhereString, "(T2.[FamCod] = @AV41FamCod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( StringUtil.StrCmp(AV46Tipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] = 0)");
         }
         if ( StringUtil.StrCmp(AV46Tipo, "S") == 0 )
         {
            AddWhere(sWhereString, "(T1.[MVADCosto] <> 0)");
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
                     return conditional_P00DR5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (decimal)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
          Object[] prmP00DR2;
          prmP00DR2 = new Object[] {
          new ParDef("@AV39AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP00DR3;
          prmP00DR3 = new Object[] {
          new ParDef("@AV30LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00DR4;
          prmP00DR4 = new Object[] {
          new ParDef("@AV31Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP00DR5;
          prmP00DR5 = new Object[] {
          new ParDef("@AV27Hdesde",GXType.Date,8,0) ,
          new ParDef("@AV28HHasta",GXType.Date,8,0) ,
          new ParDef("@AV29MovCod",GXType.Int32,6,0) ,
          new ParDef("@AV30LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV31Prodcod",GXType.NChar,15,0) ,
          new ParDef("@AV39AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV40SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV41FamCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DR2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV39AlmCod ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DR3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV30LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DR4", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @AV31Prodcod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DR5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((int[]) buf[8])[0] = rslt.getInt(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 15);
                ((int[]) buf[10])[0] = rslt.getInt(9);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 20);
                ((string[]) buf[13])[0] = rslt.getString(12, 10);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 100);
                ((string[]) buf[17])[0] = rslt.getString(16, 12);
                ((string[]) buf[18])[0] = rslt.getString(17, 100);
                ((int[]) buf[19])[0] = rslt.getInt(18);
                return;
       }
    }

 }

}
