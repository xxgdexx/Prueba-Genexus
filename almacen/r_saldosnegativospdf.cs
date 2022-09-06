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
   public class r_saldosnegativospdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_saldosnegativospdf.aspx")), "almacen.r_saldosnegativospdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_saldosnegativospdf.aspx")))) ;
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
                  AV38SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV39FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV47AlmCodigo = (int)(NumberUtil.Val( GetPar( "AlmCodigo"), "."));
                  AV10Prodcod = GetPar( "Prodcod");
                  AV20cAno = (short)(NumberUtil.Val( GetPar( "cAno"), "."));
                  AV21cMes = (short)(NumberUtil.Val( GetPar( "cMes"), "."));
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

      public r_saldosnegativospdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_saldosnegativospdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCodigo ,
                           ref string aP4_Prodcod ,
                           ref short aP5_cAno ,
                           ref short aP6_cMes )
      {
         this.AV8LinCod = aP0_LinCod;
         this.AV38SubLCod = aP1_SubLCod;
         this.AV39FamCod = aP2_FamCod;
         this.AV47AlmCodigo = aP3_AlmCodigo;
         this.AV10Prodcod = aP4_Prodcod;
         this.AV20cAno = aP5_cAno;
         this.AV21cMes = aP6_cMes;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV8LinCod;
         aP1_SubLCod=this.AV38SubLCod;
         aP2_FamCod=this.AV39FamCod;
         aP3_AlmCodigo=this.AV47AlmCodigo;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_cAno=this.AV20cAno;
         aP6_cMes=this.AV21cMes;
      }

      public short executeUdp( ref int aP0_LinCod ,
                               ref int aP1_SubLCod ,
                               ref int aP2_FamCod ,
                               ref int aP3_AlmCodigo ,
                               ref string aP4_Prodcod ,
                               ref short aP5_cAno )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCodigo, ref aP4_Prodcod, ref aP5_cAno, ref aP6_cMes);
         return AV21cMes ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCodigo ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_cAno ,
                                 ref short aP6_cMes )
      {
         r_saldosnegativospdf objr_saldosnegativospdf;
         objr_saldosnegativospdf = new r_saldosnegativospdf();
         objr_saldosnegativospdf.AV8LinCod = aP0_LinCod;
         objr_saldosnegativospdf.AV38SubLCod = aP1_SubLCod;
         objr_saldosnegativospdf.AV39FamCod = aP2_FamCod;
         objr_saldosnegativospdf.AV47AlmCodigo = aP3_AlmCodigo;
         objr_saldosnegativospdf.AV10Prodcod = aP4_Prodcod;
         objr_saldosnegativospdf.AV20cAno = aP5_cAno;
         objr_saldosnegativospdf.AV21cMes = aP6_cMes;
         objr_saldosnegativospdf.context.SetSubmitInitialConfig(context);
         objr_saldosnegativospdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_saldosnegativospdf);
         aP0_LinCod=this.AV8LinCod;
         aP1_SubLCod=this.AV38SubLCod;
         aP2_FamCod=this.AV39FamCod;
         aP3_AlmCodigo=this.AV47AlmCodigo;
         aP4_Prodcod=this.AV10Prodcod;
         aP5_cAno=this.AV20cAno;
         aP6_cMes=this.AV21cMes;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_saldosnegativospdf)stateInfo).executePrivate();
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
            AV29Empresa = AV34Session.Get("NombreObra");
            AV30EmpDir = AV34Session.Get("EmpDir");
            AV31EmpRUC = AV34Session.Get("EmpRUC");
            AV32Ruta = AV34Session.Get("RUTA") + "/Logo.jpg";
            AV33Logo = AV32Ruta;
            AV53Logo_GXI = GXDbFile.PathToUrl( AV32Ruta);
            AV12Titulo = "Reporte de Saldos Negativos";
            AV22Filtro1 = "(Todos)";
            AV24Filtro2 = "(Todos)";
            /* Using cursor P008I2 */
            pr_default.execute(0, new Object[] {AV47AlmCodigo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A63AlmCod = P008I2_A63AlmCod[0];
               A436AlmDsc = P008I2_A436AlmDsc[0];
               AV24Filtro2 = A436AlmDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Using cursor P008I3 */
            pr_default.execute(1, new Object[] {AV8LinCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52LinCod = P008I3_A52LinCod[0];
               A1153LinDsc = P008I3_A1153LinDsc[0];
               AV22Filtro1 = A1153LinDsc;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            AV25Fecha = "01/" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV21cMes), 10, 0)), 2, "0") + "/" + StringUtil.Trim( StringUtil.Str( (decimal)(AV20cAno), 10, 0));
            AV13cDesde = context.localUtil.CToD( AV25Fecha, 2);
            AV37Mes = (short)(DateTimeUtil.Month( context.localUtil.CToD( AV25Fecha, 2)));
            GXt_char1 = AV23DMes;
            new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV37Mes, out  GXt_char1) ;
            AV23DMes = GXt_char1;
            AV16Saldo = 0.0000m;
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV47AlmCodigo ,
                                                 A63AlmCod ,
                                                 A438AlmSts } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P008I4 */
            pr_default.execute(2, new Object[] {AV47AlmCodigo});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A63AlmCod = P008I4_A63AlmCod[0];
               A438AlmSts = P008I4_A438AlmSts[0];
               A436AlmDsc = P008I4_A436AlmDsc[0];
               AV9AlmCod = A63AlmCod;
               AV11Almacen = StringUtil.Trim( A436AlmDsc);
               H8I0( false, 24) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 25, Gx_line+4, 651, Gx_line+20, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+24);
               /* Execute user subroutine: 'SALDOSNEGATIVOS' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               if ( AV45FlagNeg == 1 )
               {
                  /* Eject command */
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(P_lines+1);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV34Session.Set("Reporte", "S");
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H8I0( true, 0) ;
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
         /* 'SALDOSNEGATIVOS' Routine */
         returnInSub = false;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV8LinCod ,
                                              AV38SubLCod ,
                                              AV39FamCod ,
                                              AV10Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A28ProdCod ,
                                              A21MvAlm ,
                                              AV9AlmCod ,
                                              A1158LinStk } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008I5 */
         pr_default.execute(3, new Object[] {AV9AlmCod, AV8LinCod, AV38SubLCod, AV39FamCod, AV10Prodcod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8I6 = false;
            A13MvATip = P008I5_A13MvATip[0];
            A14MvACod = P008I5_A14MvACod[0];
            A28ProdCod = P008I5_A28ProdCod[0];
            A1158LinStk = P008I5_A1158LinStk[0];
            A21MvAlm = P008I5_A21MvAlm[0];
            A50FamCod = P008I5_A50FamCod[0];
            n50FamCod = P008I5_n50FamCod[0];
            A51SublCod = P008I5_A51SublCod[0];
            n51SublCod = P008I5_n51SublCod[0];
            A52LinCod = P008I5_A52LinCod[0];
            A55ProdDsc = P008I5_A55ProdDsc[0];
            A30MvADItem = P008I5_A30MvADItem[0];
            A21MvAlm = P008I5_A21MvAlm[0];
            A50FamCod = P008I5_A50FamCod[0];
            n50FamCod = P008I5_n50FamCod[0];
            A51SublCod = P008I5_A51SublCod[0];
            n51SublCod = P008I5_n51SublCod[0];
            A52LinCod = P008I5_A52LinCod[0];
            A55ProdDsc = P008I5_A55ProdDsc[0];
            A1158LinStk = P008I5_A1158LinStk[0];
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008I5_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK8I6 = false;
               A13MvATip = P008I5_A13MvATip[0];
               A14MvACod = P008I5_A14MvACod[0];
               A30MvADItem = P008I5_A30MvADItem[0];
               BRK8I6 = true;
               pr_default.readNext(3);
            }
            AV44Codigo = A28ProdCod;
            AV15Producto = A55ProdDsc;
            GXt_decimal2 = AV16Saldo;
            GXt_decimal3 = 0;
            GXt_decimal4 = 0;
            new GeneXus.Programs.almacen.pobtenersaldoproducto(context ).execute( ref  AV44Codigo, ref  AV9AlmCod, ref  AV13cDesde, out  GXt_decimal2, out  GXt_decimal3, out  GXt_decimal4) ;
            AV16Saldo = GXt_decimal2;
            AV17Final = AV16Saldo;
            /* Execute user subroutine: 'VALIDANEGATIVO' */
            S126 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'MOVIMIENTOS' */
            S136 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            if ( ! BRK8I6 )
            {
               BRK8I6 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S141( )
      {
         /* 'VALIDA' Routine */
         returnInSub = false;
         AV26Flag = 1;
         if ( ! ( AV16Saldo == Convert.ToDecimal( 0 )) )
         {
            AV26Flag = 0;
         }
         else
         {
            /* Using cursor P008I6 */
            pr_default.execute(4, new Object[] {AV44Codigo, AV21cMes, AV20cAno, AV9AlmCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A13MvATip = P008I6_A13MvATip[0];
               A14MvACod = P008I6_A14MvACod[0];
               A1370MVSts = P008I6_A1370MVSts[0];
               A25MvAFec = P008I6_A25MvAFec[0];
               A21MvAlm = P008I6_A21MvAlm[0];
               A28ProdCod = P008I6_A28ProdCod[0];
               A30MvADItem = P008I6_A30MvADItem[0];
               A1370MVSts = P008I6_A1370MVSts[0];
               A25MvAFec = P008I6_A25MvAFec[0];
               A21MvAlm = P008I6_A21MvAlm[0];
               AV26Flag = 0;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
               pr_default.readNext(4);
            }
            pr_default.close(4);
         }
      }

      protected void S126( )
      {
         /* 'VALIDANEGATIVO' Routine */
         returnInSub = false;
         AV45FlagNeg = 0;
         AV46SaldoNeg = AV17Final;
         if ( ( AV46SaldoNeg < Convert.ToDecimal( 0 )) )
         {
            AV45FlagNeg = 1;
         }
         /* Using cursor P008I7 */
         pr_default.execute(5, new Object[] {AV21cMes, AV20cAno, AV44Codigo, AV9AlmCod});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A28ProdCod = P008I7_A28ProdCod[0];
            A21MvAlm = P008I7_A21MvAlm[0];
            A1370MVSts = P008I7_A1370MVSts[0];
            A25MvAFec = P008I7_A25MvAFec[0];
            A1248MvADCant = P008I7_A1248MvADCant[0];
            A14MvACod = P008I7_A14MvACod[0];
            A13MvATip = P008I7_A13MvATip[0];
            A30MvADItem = P008I7_A30MvADItem[0];
            A21MvAlm = P008I7_A21MvAlm[0];
            A1370MVSts = P008I7_A1370MVSts[0];
            A25MvAFec = P008I7_A25MvAFec[0];
            AV46SaldoNeg = (decimal)(AV46SaldoNeg+(((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : A1248MvADCant*-1)));
            if ( ( AV46SaldoNeg < Convert.ToDecimal( 0 )) )
            {
               AV45FlagNeg = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S151( )
      {
         /* 'VALIDACLIENTE' Routine */
         returnInSub = false;
         if ( ! ( StringUtil.StrCmp(AV48MvATip, "ING") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV50MVCliCod)) )
         {
            /* Using cursor P008I8 */
            pr_default.execute(6, new Object[] {AV50MVCliCod});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A45CliCod = P008I8_A45CliCod[0];
               A161CliDsc = P008I8_A161CliDsc[0];
               AV40Cliente = StringUtil.Trim( A161CliDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
         }
      }

      protected void S136( )
      {
         /* 'MOVIMIENTOS' Routine */
         returnInSub = false;
         if ( AV45FlagNeg == 1 )
         {
            /* Execute user subroutine: 'VALIDA' */
            S141 ();
            if (returnInSub) return;
            if ( AV26Flag == 0 )
            {
               H8I0( false, 22) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Producto : ", 25, Gx_line+4, 89, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Saldo :", 546, Gx_line+4, 586, Gx_line+18, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV16Saldo, "ZZZZ,ZZZ,ZZ9.9999")), 592, Gx_line+4, 717, Gx_line+19, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Codigo, "@!")), 84, Gx_line+2, 177, Gx_line+20, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 180, Gx_line+2, 540, Gx_line+20, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+22);
            }
            AV18Ingresa = 0.0000m;
            AV19Salida = 0.0000m;
            AV35TIngresa = 0.0000m;
            AV36TSalida = 0.0000m;
            /* Using cursor P008I9 */
            pr_default.execute(7, new Object[] {AV21cMes, AV20cAno, AV44Codigo, AV9AlmCod});
            while ( (pr_default.getStatus(7) != 101) )
            {
               A22MvAMov = P008I9_A22MvAMov[0];
               A28ProdCod = P008I9_A28ProdCod[0];
               A21MvAlm = P008I9_A21MvAlm[0];
               A1370MVSts = P008I9_A1370MVSts[0];
               A25MvAFec = P008I9_A25MvAFec[0];
               A15MVCliCod = P008I9_A15MVCliCod[0];
               n15MVCliCod = P008I9_n15MVCliCod[0];
               A1278MvARef = P008I9_A1278MvARef[0];
               A1276MvAOcom = P008I9_A1276MvAOcom[0];
               A24DocNum = P008I9_A24DocNum[0];
               n24DocNum = P008I9_n24DocNum[0];
               A1248MvADCant = P008I9_A1248MvADCant[0];
               A1274MvAMovDsc = P008I9_A1274MvAMovDsc[0];
               A14MvACod = P008I9_A14MvACod[0];
               A13MvATip = P008I9_A13MvATip[0];
               A30MvADItem = P008I9_A30MvADItem[0];
               A22MvAMov = P008I9_A22MvAMov[0];
               A21MvAlm = P008I9_A21MvAlm[0];
               A1370MVSts = P008I9_A1370MVSts[0];
               A25MvAFec = P008I9_A25MvAFec[0];
               A15MVCliCod = P008I9_A15MVCliCod[0];
               n15MVCliCod = P008I9_n15MVCliCod[0];
               A1278MvARef = P008I9_A1278MvARef[0];
               A1276MvAOcom = P008I9_A1276MvAOcom[0];
               A24DocNum = P008I9_A24DocNum[0];
               n24DocNum = P008I9_n24DocNum[0];
               A1274MvAMovDsc = P008I9_A1274MvAMovDsc[0];
               AV40Cliente = "";
               AV48MvATip = A13MvATip;
               AV49MvACod = A14MvACod;
               AV50MVCliCod = A15MVCliCod;
               /* Execute user subroutine: 'VALIDACLIENTE' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(7);
                  returnInSub = true;
                  if (true) return;
               }
               AV41DocRef = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? (String.IsNullOrEmpty(StringUtil.RTrim( A1276MvAOcom)) ? A1278MvARef : A1276MvAOcom) : A24DocNum);
               AV18Ingresa = ((StringUtil.StrCmp(A13MvATip, "ING")==0) ? A1248MvADCant : (decimal)(0));
               AV19Salida = ((StringUtil.StrCmp(A13MvATip, "ING")!=0) ? A1248MvADCant : (decimal)(0));
               AV17Final = (decimal)(AV17Final+(AV18Ingresa-AV19Salida));
               AV35TIngresa = (decimal)(AV35TIngresa+AV18Ingresa);
               AV36TSalida = (decimal)(AV36TSalida+AV19Salida);
               H8I0( false, 17) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 708, Gx_line+2, 815, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV19Salida, "ZZZZ,ZZZ,ZZ9.9999")), 624, Gx_line+2, 731, Gx_line+17, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40Cliente, "")), 429, Gx_line+1, 601, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), 263, Gx_line+1, 435, Gx_line+17, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41DocRef, "")), 177, Gx_line+2, 261, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( A25MvAFec, "99/99/99"), 114, Gx_line+2, 175, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), 36, Gx_line+2, 112, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), 2, Gx_line+2, 34, Gx_line+16, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV18Ingresa, "ZZZZ,ZZZ,ZZ9.9999")), 559, Gx_line+2, 666, Gx_line+17, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+17);
               pr_default.readNext(7);
            }
            pr_default.close(7);
            if ( AV26Flag == 0 )
            {
               H8I0( false, 25) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15Producto, "")), 102, Gx_line+3, 544, Gx_line+21, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TIngresos, "ZZZZZZ,ZZZ,ZZ9.99")), 559, Gx_line+5, 666, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV43TSalidas, "ZZZZZZ,ZZZ,ZZ9.99")), 624, Gx_line+5, 731, Gx_line+20, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV17Final, "ZZZZ,ZZZ,ZZ9.9999")), 708, Gx_line+5, 815, Gx_line+20, 2+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+25);
            }
         }
      }

      protected void H8I0( bool bFoot ,
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
               getPrinter().GxDrawText("Hora:", 663, Gx_line+41, 695, Gx_line+55, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Página:", 663, Gx_line+58, 707, Gx_line+72, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha:", 663, Gx_line+23, 702, Gx_line+37, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 725, Gx_line+57, 764, Gx_line+72, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( Gx_time, "")), 702, Gx_line+40, 762, Gx_line+54, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 717, Gx_line+22, 764, Gx_line+37, 2+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV11Almacen, "")), 195, Gx_line+56, 651, Gx_line+81, 1, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Linea :", 184, Gx_line+86, 227, Gx_line+101, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Almacen :", 184, Gx_line+106, 246, Gx_line+121, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Año :", 184, Gx_line+128, 219, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22Filtro1, "")), 265, Gx_line+81, 630, Gx_line+105, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24Filtro2, "")), 265, Gx_line+101, 630, Gx_line+125, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV20cAno), "ZZZ9")), 266, Gx_line+123, 334, Gx_line+147, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, true, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Mes :", 390, Gx_line+128, 424, Gx_line+143, 0+256, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23DMes, "")), 471, Gx_line+123, 567, Gx_line+147, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 12, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12Titulo, "")), 195, Gx_line+29, 651, Gx_line+54, 1, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV33Logo)) ? AV53Logo_GXI : AV33Logo);
               getPrinter().GxDrawBitMap(sImgUrl, 4, Gx_line+36, 182, Gx_line+118) ;
               getPrinter().GxAttris("Tahoma", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("T/G", 8, Gx_line+158, 31, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("N° Guia", 57, Gx_line+158, 101, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Ing.", 599, Gx_line+158, 659, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Sal.", 671, Gx_line+158, 729, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Stock Actual", 739, Gx_line+158, 814, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Fecha", 127, Gx_line+159, 162, Gx_line+173, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Doc. Ref.", 196, Gx_line+158, 248, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Tipo Movimiento", 301, Gx_line+158, 400, Gx_line+172, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente", 486, Gx_line+157, 528, Gx_line+171, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawRect(0, Gx_line+152, 818, Gx_line+178, 1, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Tahoma", 8, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV29Empresa, "")), 4, Gx_line+4, 372, Gx_line+22, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31EmpRUC, "")), 4, Gx_line+22, 174, Gx_line+40, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+178);
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
         AV29Empresa = "";
         AV34Session = context.GetSession();
         AV30EmpDir = "";
         AV31EmpRUC = "";
         AV32Ruta = "";
         AV33Logo = "";
         AV53Logo_GXI = "";
         AV12Titulo = "";
         AV22Filtro1 = "";
         AV24Filtro2 = "";
         scmdbuf = "";
         P008I2_A63AlmCod = new int[1] ;
         P008I2_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         P008I3_A52LinCod = new int[1] ;
         P008I3_A1153LinDsc = new string[] {""} ;
         A1153LinDsc = "";
         AV25Fecha = "";
         AV13cDesde = DateTime.MinValue;
         AV23DMes = "";
         GXt_char1 = "";
         P008I4_A63AlmCod = new int[1] ;
         P008I4_A438AlmSts = new short[1] ;
         P008I4_A436AlmDsc = new string[] {""} ;
         AV11Almacen = "";
         A28ProdCod = "";
         P008I5_A13MvATip = new string[] {""} ;
         P008I5_A14MvACod = new string[] {""} ;
         P008I5_A28ProdCod = new string[] {""} ;
         P008I5_A1158LinStk = new short[1] ;
         P008I5_A21MvAlm = new int[1] ;
         P008I5_A50FamCod = new int[1] ;
         P008I5_n50FamCod = new bool[] {false} ;
         P008I5_A51SublCod = new int[1] ;
         P008I5_n51SublCod = new bool[] {false} ;
         P008I5_A52LinCod = new int[1] ;
         P008I5_A55ProdDsc = new string[] {""} ;
         P008I5_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         AV44Codigo = "";
         AV15Producto = "";
         P008I6_A13MvATip = new string[] {""} ;
         P008I6_A14MvACod = new string[] {""} ;
         P008I6_A1370MVSts = new string[] {""} ;
         P008I6_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008I6_A21MvAlm = new int[1] ;
         P008I6_A28ProdCod = new string[] {""} ;
         P008I6_A30MvADItem = new int[1] ;
         A1370MVSts = "";
         A25MvAFec = DateTime.MinValue;
         P008I7_A28ProdCod = new string[] {""} ;
         P008I7_A21MvAlm = new int[1] ;
         P008I7_A1370MVSts = new string[] {""} ;
         P008I7_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008I7_A1248MvADCant = new decimal[1] ;
         P008I7_A14MvACod = new string[] {""} ;
         P008I7_A13MvATip = new string[] {""} ;
         P008I7_A30MvADItem = new int[1] ;
         AV48MvATip = "";
         AV50MVCliCod = "";
         P008I8_A45CliCod = new string[] {""} ;
         P008I8_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         AV40Cliente = "";
         P008I9_A22MvAMov = new int[1] ;
         P008I9_A28ProdCod = new string[] {""} ;
         P008I9_A21MvAlm = new int[1] ;
         P008I9_A1370MVSts = new string[] {""} ;
         P008I9_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008I9_A15MVCliCod = new string[] {""} ;
         P008I9_n15MVCliCod = new bool[] {false} ;
         P008I9_A1278MvARef = new string[] {""} ;
         P008I9_A1276MvAOcom = new string[] {""} ;
         P008I9_A24DocNum = new string[] {""} ;
         P008I9_n24DocNum = new bool[] {false} ;
         P008I9_A1248MvADCant = new decimal[1] ;
         P008I9_A1274MvAMovDsc = new string[] {""} ;
         P008I9_A14MvACod = new string[] {""} ;
         P008I9_A13MvATip = new string[] {""} ;
         P008I9_A30MvADItem = new int[1] ;
         A15MVCliCod = "";
         A1278MvARef = "";
         A1276MvAOcom = "";
         A24DocNum = "";
         A1274MvAMovDsc = "";
         AV49MvACod = "";
         AV41DocRef = "";
         Gx_time = "";
         Gx_date = DateTime.MinValue;
         AV33Logo = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_saldosnegativospdf__default(),
            new Object[][] {
                new Object[] {
               P008I2_A63AlmCod, P008I2_A436AlmDsc
               }
               , new Object[] {
               P008I3_A52LinCod, P008I3_A1153LinDsc
               }
               , new Object[] {
               P008I4_A63AlmCod, P008I4_A438AlmSts, P008I4_A436AlmDsc
               }
               , new Object[] {
               P008I5_A13MvATip, P008I5_A14MvACod, P008I5_A28ProdCod, P008I5_A1158LinStk, P008I5_A21MvAlm, P008I5_A50FamCod, P008I5_n50FamCod, P008I5_A51SublCod, P008I5_n51SublCod, P008I5_A52LinCod,
               P008I5_A55ProdDsc, P008I5_A30MvADItem
               }
               , new Object[] {
               P008I6_A13MvATip, P008I6_A14MvACod, P008I6_A1370MVSts, P008I6_A25MvAFec, P008I6_A21MvAlm, P008I6_A28ProdCod, P008I6_A30MvADItem
               }
               , new Object[] {
               P008I7_A28ProdCod, P008I7_A21MvAlm, P008I7_A1370MVSts, P008I7_A25MvAFec, P008I7_A1248MvADCant, P008I7_A14MvACod, P008I7_A13MvATip, P008I7_A30MvADItem
               }
               , new Object[] {
               P008I8_A45CliCod, P008I8_A161CliDsc
               }
               , new Object[] {
               P008I9_A22MvAMov, P008I9_A28ProdCod, P008I9_A21MvAlm, P008I9_A1370MVSts, P008I9_A25MvAFec, P008I9_A15MVCliCod, P008I9_n15MVCliCod, P008I9_A1278MvARef, P008I9_A1276MvAOcom, P008I9_A24DocNum,
               P008I9_n24DocNum, P008I9_A1248MvADCant, P008I9_A1274MvAMovDsc, P008I9_A14MvACod, P008I9_A13MvATip, P008I9_A30MvADItem
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
      private short AV20cAno ;
      private short AV21cMes ;
      private short AV37Mes ;
      private short A438AlmSts ;
      private short AV45FlagNeg ;
      private short A1158LinStk ;
      private short AV26Flag ;
      private int AV8LinCod ;
      private int AV38SubLCod ;
      private int AV39FamCod ;
      private int AV47AlmCodigo ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int A63AlmCod ;
      private int A52LinCod ;
      private int AV9AlmCod ;
      private int Gx_OldLine ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private int A22MvAMov ;
      private decimal AV16Saldo ;
      private decimal GXt_decimal2 ;
      private decimal GXt_decimal3 ;
      private decimal GXt_decimal4 ;
      private decimal AV17Final ;
      private decimal AV46SaldoNeg ;
      private decimal A1248MvADCant ;
      private decimal AV18Ingresa ;
      private decimal AV19Salida ;
      private decimal AV35TIngresa ;
      private decimal AV36TSalida ;
      private decimal AV42TIngresos ;
      private decimal AV43TSalidas ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV10Prodcod ;
      private string AV29Empresa ;
      private string AV30EmpDir ;
      private string AV31EmpRUC ;
      private string AV32Ruta ;
      private string AV12Titulo ;
      private string AV22Filtro1 ;
      private string AV24Filtro2 ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string A1153LinDsc ;
      private string AV25Fecha ;
      private string AV23DMes ;
      private string GXt_char1 ;
      private string AV11Almacen ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string AV44Codigo ;
      private string AV15Producto ;
      private string A1370MVSts ;
      private string AV48MvATip ;
      private string AV50MVCliCod ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string AV40Cliente ;
      private string A15MVCliCod ;
      private string A1278MvARef ;
      private string A1276MvAOcom ;
      private string A24DocNum ;
      private string A1274MvAMovDsc ;
      private string AV49MvACod ;
      private string AV41DocRef ;
      private string Gx_time ;
      private string sImgUrl ;
      private DateTime AV13cDesde ;
      private DateTime A25MvAFec ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool BRK8I6 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private bool n15MVCliCod ;
      private bool n24DocNum ;
      private string AV53Logo_GXI ;
      private string AV33Logo ;
      private string Logo ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCodigo ;
      private string aP4_Prodcod ;
      private short aP5_cAno ;
      private short aP6_cMes ;
      private IDataStoreProvider pr_default ;
      private int[] P008I2_A63AlmCod ;
      private string[] P008I2_A436AlmDsc ;
      private int[] P008I3_A52LinCod ;
      private string[] P008I3_A1153LinDsc ;
      private int[] P008I4_A63AlmCod ;
      private short[] P008I4_A438AlmSts ;
      private string[] P008I4_A436AlmDsc ;
      private string[] P008I5_A13MvATip ;
      private string[] P008I5_A14MvACod ;
      private string[] P008I5_A28ProdCod ;
      private short[] P008I5_A1158LinStk ;
      private int[] P008I5_A21MvAlm ;
      private int[] P008I5_A50FamCod ;
      private bool[] P008I5_n50FamCod ;
      private int[] P008I5_A51SublCod ;
      private bool[] P008I5_n51SublCod ;
      private int[] P008I5_A52LinCod ;
      private string[] P008I5_A55ProdDsc ;
      private int[] P008I5_A30MvADItem ;
      private string[] P008I6_A13MvATip ;
      private string[] P008I6_A14MvACod ;
      private string[] P008I6_A1370MVSts ;
      private DateTime[] P008I6_A25MvAFec ;
      private int[] P008I6_A21MvAlm ;
      private string[] P008I6_A28ProdCod ;
      private int[] P008I6_A30MvADItem ;
      private string[] P008I7_A28ProdCod ;
      private int[] P008I7_A21MvAlm ;
      private string[] P008I7_A1370MVSts ;
      private DateTime[] P008I7_A25MvAFec ;
      private decimal[] P008I7_A1248MvADCant ;
      private string[] P008I7_A14MvACod ;
      private string[] P008I7_A13MvATip ;
      private int[] P008I7_A30MvADItem ;
      private string[] P008I8_A45CliCod ;
      private string[] P008I8_A161CliDsc ;
      private int[] P008I9_A22MvAMov ;
      private string[] P008I9_A28ProdCod ;
      private int[] P008I9_A21MvAlm ;
      private string[] P008I9_A1370MVSts ;
      private DateTime[] P008I9_A25MvAFec ;
      private string[] P008I9_A15MVCliCod ;
      private bool[] P008I9_n15MVCliCod ;
      private string[] P008I9_A1278MvARef ;
      private string[] P008I9_A1276MvAOcom ;
      private string[] P008I9_A24DocNum ;
      private bool[] P008I9_n24DocNum ;
      private decimal[] P008I9_A1248MvADCant ;
      private string[] P008I9_A1274MvAMovDsc ;
      private string[] P008I9_A14MvACod ;
      private string[] P008I9_A13MvATip ;
      private int[] P008I9_A30MvADItem ;
   }

   public class r_saldosnegativospdf__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008I4( IGxContext context ,
                                             int AV47AlmCodigo ,
                                             int A63AlmCod ,
                                             short A438AlmSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [AlmCod], [AlmSts], [AlmDsc] FROM [CALMACEN]";
         AddWhere(sWhereString, "([AlmSts] = 1)");
         if ( ! (0==AV47AlmCodigo) )
         {
            AddWhere(sWhereString, "([AlmCod] = @AV47AlmCodigo)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AlmCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008I5( IGxContext context ,
                                             int AV8LinCod ,
                                             int AV38SubLCod ,
                                             int AV39FamCod ,
                                             string AV10Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             string A28ProdCod ,
                                             int A21MvAlm ,
                                             int AV9AlmCod ,
                                             short A1158LinStk )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[5];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T1.[ProdCod], T4.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T3.[ProdDsc], T1.[MvADItem] FROM ((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLINEAPROD] T4 ON T4.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T2.[MvAlm] = @AV9AlmCod)");
         AddWhere(sWhereString, "(T4.[LinStk] = 1)");
         if ( ! (0==AV8LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV8LinCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV38SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV38SubLCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! (0==AV39FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV39FamCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10Prodcod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV10Prodcod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T1.[MvACod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 2 :
                     return conditional_P008I4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (short)dynConstraints[2] );
               case 3 :
                     return conditional_P008I5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (short)dynConstraints[10] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008I2;
          prmP008I2 = new Object[] {
          new ParDef("@AV47AlmCodigo",GXType.Int32,6,0)
          };
          Object[] prmP008I3;
          prmP008I3 = new Object[] {
          new ParDef("@AV8LinCod",GXType.Int32,6,0)
          };
          Object[] prmP008I6;
          prmP008I6 = new Object[] {
          new ParDef("@AV44Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV21cMes",GXType.Int16,2,0) ,
          new ParDef("@AV20cAno",GXType.Int16,4,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008I7;
          prmP008I7 = new Object[] {
          new ParDef("@AV21cMes",GXType.Int16,2,0) ,
          new ParDef("@AV20cAno",GXType.Int16,4,0) ,
          new ParDef("@AV44Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008I8;
          prmP008I8 = new Object[] {
          new ParDef("@AV50MVCliCod",GXType.NChar,20,0)
          };
          Object[] prmP008I9;
          prmP008I9 = new Object[] {
          new ParDef("@AV21cMes",GXType.Int16,2,0) ,
          new ParDef("@AV20cAno",GXType.Int16,4,0) ,
          new ParDef("@AV44Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP008I4;
          prmP008I4 = new Object[] {
          new ParDef("@AV47AlmCodigo",GXType.Int32,6,0)
          };
          Object[] prmP008I5;
          prmP008I5 = new Object[] {
          new ParDef("@AV9AlmCod",GXType.Int32,6,0) ,
          new ParDef("@AV8LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV38SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV39FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV10Prodcod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008I2", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] WHERE [AlmCod] = @AV47AlmCodigo ORDER BY [AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I3", "SELECT [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV8LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008I6", "SELECT TOP 1 T1.[MvATip], T1.[MvACod], T2.[MVSts], T2.[MvAFec], T2.[MvAlm], T1.[ProdCod], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[ProdCod] = @AV44Codigo) AND (MONTH(T2.[MvAFec]) = @AV21cMes) AND (YEAR(T2.[MvAFec]) = @AV20cAno) AND (T2.[MVSts] <> 'A') AND (T2.[MvAlm] = @AV9AlmCod) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I7", "SELECT T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T1.[MvADCant], T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (MONTH(T2.[MvAFec]) = @AV21cMes) AND (YEAR(T2.[MvAFec]) = @AV20cAno) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV44Codigo) AND (T2.[MvAlm] = @AV9AlmCod) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008I8", "SELECT [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliCod] = @AV50MVCliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008I9", "SELECT T2.[MvAMov] AS MvAMov, T1.[ProdCod], T2.[MvAlm], T2.[MVSts], T2.[MvAFec], T2.[MVCliCod], T2.[MvARef], T2.[MvAOcom], T2.[DocNum], T1.[MvADCant], T3.[MovDsc] AS MvAMovDsc, T1.[MvACod], T1.[MvATip], T1.[MvADItem] FROM (([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [CMOVALMACEN] T3 ON T3.[MovCod] = T2.[MvAMov]) WHERE (MONTH(T2.[MvAFec]) = @AV21cMes) AND (YEAR(T2.[MvAFec]) = @AV20cAno) AND (T2.[MVSts] <> 'A') AND (T1.[ProdCod] = @AV44Codigo) AND (T2.[MvAlm] = @AV9AlmCod) ORDER BY T2.[MvAFec], T1.[MvATip], T1.[MvACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008I9,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((int[]) buf[9])[0] = rslt.getInt(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 100);
                ((int[]) buf[11])[0] = rslt.getInt(10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 12);
                ((string[]) buf[6])[0] = rslt.getString(7, 3);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 20);
                ((string[]) buf[8])[0] = rslt.getString(8, 10);
                ((string[]) buf[9])[0] = rslt.getString(9, 12);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 100);
                ((string[]) buf[13])[0] = rslt.getString(12, 12);
                ((string[]) buf[14])[0] = rslt.getString(13, 3);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
