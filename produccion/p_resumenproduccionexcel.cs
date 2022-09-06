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
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.produccion {
   public class p_resumenproduccionexcel : GXProcedure
   {
      public p_resumenproduccionexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public p_resumenproduccionexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_ProSts ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV83ProdCod = aP0_ProdCod;
         this.AV38FDesde = aP1_FDesde;
         this.AV41FHasta = aP2_FHasta;
         this.AV91ProSts = aP3_ProSts;
         this.AV42Filename = "" ;
         this.AV35ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV83ProdCod;
         aP1_FDesde=this.AV38FDesde;
         aP2_FHasta=this.AV41FHasta;
         aP3_ProSts=this.AV91ProSts;
         aP4_Filename=this.AV42Filename;
         aP5_ErrorMessage=this.AV35ErrorMessage;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref string aP3_ProSts ,
                                out string aP4_Filename )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProSts, out aP4_Filename, out aP5_ErrorMessage);
         return AV35ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProSts ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         p_resumenproduccionexcel objp_resumenproduccionexcel;
         objp_resumenproduccionexcel = new p_resumenproduccionexcel();
         objp_resumenproduccionexcel.AV83ProdCod = aP0_ProdCod;
         objp_resumenproduccionexcel.AV38FDesde = aP1_FDesde;
         objp_resumenproduccionexcel.AV41FHasta = aP2_FHasta;
         objp_resumenproduccionexcel.AV91ProSts = aP3_ProSts;
         objp_resumenproduccionexcel.AV42Filename = "" ;
         objp_resumenproduccionexcel.AV35ErrorMessage = "" ;
         objp_resumenproduccionexcel.context.SetSubmitInitialConfig(context);
         objp_resumenproduccionexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objp_resumenproduccionexcel);
         aP0_ProdCod=this.AV83ProdCod;
         aP1_FDesde=this.AV38FDesde;
         aP2_FHasta=this.AV41FHasta;
         aP3_ProSts=this.AV91ProSts;
         aP4_Filename=this.AV42Filename;
         aP5_ErrorMessage=this.AV35ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((p_resumenproduccionexcel)stateInfo).executePrivate();
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
         AV12Archivo.Source = "Excel/PlantillasResumenProduccion.xlsx";
         AV78Path = AV12Archivo.GetPath();
         AV43FilenameOrigen = StringUtil.Trim( AV78Path) + "\\PlantillasResumenProduccion.xlsx";
         AV42Filename = "Excel/RegistroProduccion" + ".xlsx";
         AV37ExcelDocument.Clear();
         AV37ExcelDocument.Template = AV43FilenameOrigen;
         AV37ExcelDocument.Open(AV42Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 6;
         AV44FirstColumn = 1;
         AV111TotalGeneral = 0.00m;
         AV100TCantidad1 = 0.0000m;
         AV101TCantidad2 = 0.0000m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV83ProdCod ,
                                              AV91ProSts ,
                                              A323ProProdCod ,
                                              A1740ProSts ,
                                              A325ProFec ,
                                              AV38FDesde ,
                                              AV41FHasta } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00FH2 */
         pr_default.execute(0, new Object[] {AV38FDesde, AV41FHasta, AV83ProdCod, AV91ProSts});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A325ProFec = P00FH2_A325ProFec[0];
            A1740ProSts = P00FH2_A1740ProSts[0];
            A323ProProdCod = P00FH2_A323ProProdCod[0];
            A1739ProRef = P00FH2_A1739ProRef[0];
            A1738ProProdDsc = P00FH2_A1738ProProdDsc[0];
            A1654ProCantProd = P00FH2_A1654ProCantProd[0];
            A1655ProCantProdIng = P00FH2_A1655ProCantProdIng[0];
            A1706ProdRef10 = P00FH2_A1706ProdRef10[0];
            n1706ProdRef10 = P00FH2_n1706ProdRef10[0];
            A322ProCod = P00FH2_A322ProCod[0];
            A1738ProProdDsc = P00FH2_A1738ProProdDsc[0];
            A1706ProdRef10 = P00FH2_A1706ProdRef10[0];
            n1706ProdRef10 = P00FH2_n1706ProdRef10[0];
            AV82ProCod = A322ProCod;
            AV87ProFec = A325ProFec;
            AV90ProRef = A1739ProRef;
            AV88ProProdCod = A323ProProdCod;
            /* Execute user subroutine: 'REFERENCIAS' */
            S151 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV89ProProdDsc = A1738ProProdDsc;
            AV79ProCantProd = A1654ProCantProd;
            AV80ProCantProdIng = A1655ProCantProdIng;
            AV36Estado = ((StringUtil.StrCmp(A1740ProSts, "T")==0) ? "TERMINADO" : "PENDIENTE");
            AV86ProdRef10 = StringUtil.Trim( A1706ProdRef10);
            AV77Orden = A322ProCod;
            AV19CostoT = 0.00m;
            AV102TCosto = 0.00m;
            AV20CostoUnit = 0.0000m;
            AV95Servicios = 0.00m;
            AV61HM = 0.00m;
            AV62HO = 0.00m;
            /* Execute user subroutine: 'OBTIENECOSTOORDEN' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV19CostoT = AV102TCosto;
            AV20CostoUnit = ((AV80ProCantProdIng==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV102TCosto/ (decimal)(AV80ProCantProdIng), 4));
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV114TServicios = (decimal)(AV114TServicios+AV95Servicios);
            AV104THO = (decimal)(AV104THO+AV62HO);
            AV103THM = (decimal)(AV103THM+AV61HM);
            AV111TotalGeneral = (decimal)(AV111TotalGeneral+AV19CostoT);
            AV100TCantidad1 = (decimal)(AV100TCantidad1+AV79ProCantProd);
            AV101TCantidad2 = (decimal)(AV101TCantidad2+AV80ProCantProdIng);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13CellRow = (int)(AV13CellRow+1);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+0, 1, 1).Text = "";
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+1, 1, 1).Text = "";
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+2, 1, 1).Text = "";
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+3, 1, 1).Text = "";
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+6, 1, 1).Text = "Total General";
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+7, 1, 1).Number = (double)(AV100TCantidad1);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+8, 1, 1).Number = (double)(AV101TCantidad2);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+10, 1, 1).Number = (double)(AV111TotalGeneral);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+11, 1, 1).Number = (double)(AV114TServicios);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+12, 1, 1).Number = (double)(AV103THM);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+13, 1, 1).Number = (double)(AV104THO);
         AV37ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV37ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV37ExcelDocument.ErrCode != 0 )
         {
            AV42Filename = "";
            AV35ErrorMessage = AV37ExcelDocument.ErrDescription;
            AV37ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV82ProCod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV87ProFec ) ;
         AV37ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+1, 1, 1).Date = GXt_dtime1;
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV90ProRef);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV8LinDsc);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV98SubLDsc);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV88ProProdCod);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV89ProProdDsc);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+7, 1, 1).Number = (double)(AV79ProCantProd);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+8, 1, 1).Number = (double)(AV80ProCantProdIng);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+9, 1, 1).Number = (double)(AV20CostoUnit);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+10, 1, 1).Number = (double)(AV102TCosto);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+11, 1, 1).Number = (double)(AV95Servicios);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+12, 1, 1).Number = (double)(AV61HM);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+13, 1, 1).Number = (double)(AV62HO);
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+14, 1, 1).Text = AV36Estado;
         AV37ExcelDocument.get_Cells(AV13CellRow, AV44FirstColumn+15, 1, 1).Text = StringUtil.Trim( AV86ProdRef10);
         AV13CellRow = (int)(AV13CellRow+1);
      }

      protected void S131( )
      {
         /* 'OBTIENECOSTOORDEN' Routine */
         returnInSub = false;
         AV18Costo = 0.00m;
         AV102TCosto = 0.00m;
         AV109TManoObra = 0.00m;
         AV110TMaquina = 0.00m;
         AV95Servicios = 0.00m;
         /* Using cursor P00FH3 */
         pr_default.execute(1, new Object[] {AV77Orden});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A1680ProDConcepto = P00FH3_A1680ProDConcepto[0];
            A322ProCod = P00FH3_A322ProCod[0];
            A327ProDProdCod = P00FH3_A327ProDProdCod[0];
            n327ProDProdCod = P00FH3_n327ProDProdCod[0];
            A326ProDItem = P00FH3_A326ProDItem[0];
            AV85ProDProdCod = A327ProDProdCod;
            AV18Costo = 0.00m;
            /* Execute user subroutine: 'OBTIENECOSTOALMACEN' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV102TCosto = (decimal)(AV102TCosto+AV18Costo);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Optimized group. */
         /* Using cursor P00FH4 */
         pr_default.execute(2, new Object[] {AV77Orden});
         c1656ProCosto = P00FH4_A1656ProCosto[0];
         pr_default.close(2);
         AV102TCosto = (decimal)(AV102TCosto+c1656ProCosto);
         /* End optimized group. */
         /* Using cursor P00FH5 */
         pr_default.execute(3, new Object[] {AV77Orden});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A322ProCod = P00FH5_A322ProCod[0];
            A1455OrdOpeCosto = P00FH5_A1455OrdOpeCosto[0];
            A1457OrdOpeHora = P00FH5_A1457OrdOpeHora[0];
            A321OPECod = P00FH5_A321OPECod[0];
            A1456OrdOpeCostoTotal = NumberUtil.Round( A1457OrdOpeHora*A1455OrdOpeCosto, 2);
            AV109TManoObra = (decimal)(AV109TManoObra+A1456OrdOpeCostoTotal);
            AV62HO = (decimal)(AV62HO+A1457OrdOpeHora);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P00FH6 */
         pr_default.execute(4, new Object[] {AV77Orden});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A322ProCod = P00FH6_A322ProCod[0];
            A1727ProMaqCosto = P00FH6_A1727ProMaqCosto[0];
            A1729ProMaqHora = P00FH6_A1729ProMaqHora[0];
            A320MAQCod = P00FH6_A320MAQCod[0];
            A1728ProMaqCostoTotal = NumberUtil.Round( A1729ProMaqHora*A1727ProMaqCosto, 2);
            AV110TMaquina = (decimal)(AV110TMaquina+A1728ProMaqCostoTotal);
            AV61HM = (decimal)(AV61HM+A1729ProMaqHora);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         /* Optimized group. */
         /* Using cursor P00FH7 */
         pr_default.execute(5, new Object[] {AV77Orden});
         c1726ProGasCosto = P00FH7_A1726ProGasCosto[0];
         pr_default.close(5);
         AV95Servicios = (decimal)(AV95Servicios+c1726ProGasCosto);
         /* End optimized group. */
         AV102TCosto = (decimal)(AV102TCosto+(AV109TManoObra+AV110TMaquina+AV95Servicios));
      }

      protected void S143( )
      {
         /* 'OBTIENECOSTOALMACEN' Routine */
         returnInSub = false;
         /* Using cursor P00FH8 */
         pr_default.execute(6, new Object[] {AV85ProDProdCod, AV77Orden});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A14MvACod = P00FH8_A14MvACod[0];
            A1370MVSts = P00FH8_A1370MVSts[0];
            A13MvATip = P00FH8_A13MvATip[0];
            A1276MvAOcom = P00FH8_A1276MvAOcom[0];
            A1286MvATMov = P00FH8_A1286MvATMov[0];
            A28ProdCod = P00FH8_A28ProdCod[0];
            A1248MvADCant = P00FH8_A1248MvADCant[0];
            A1250MVADPrecio = P00FH8_A1250MVADPrecio[0];
            A30MvADItem = P00FH8_A30MvADItem[0];
            A1370MVSts = P00FH8_A1370MVSts[0];
            A1276MvAOcom = P00FH8_A1276MvAOcom[0];
            A1286MvATMov = P00FH8_A1286MvATMov[0];
            AV70MvADCant = A1248MvADCant;
            AV71MVADPrecio = A1250MVADPrecio;
            AV18Costo = (decimal)(AV18Costo+(NumberUtil.Round( AV70MvADCant*AV71MVADPrecio, 2)));
            pr_default.readNext(6);
         }
         pr_default.close(6);
      }

      protected void S151( )
      {
         /* 'REFERENCIAS' Routine */
         returnInSub = false;
         AV8LinDsc = "";
         AV98SubLDsc = "";
         /* Using cursor P00FH9 */
         pr_default.execute(7, new Object[] {AV88ProProdCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A52LinCod = P00FH9_A52LinCod[0];
            A28ProdCod = P00FH9_A28ProdCod[0];
            A1153LinDsc = P00FH9_A1153LinDsc[0];
            A51SublCod = P00FH9_A51SublCod[0];
            n51SublCod = P00FH9_n51SublCod[0];
            A1153LinDsc = P00FH9_A1153LinDsc[0];
            AV8LinDsc = A1153LinDsc;
            AV97SubLCod = A51SublCod;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
         /* Using cursor P00FH10 */
         pr_default.execute(8, new Object[] {AV97SubLCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A51SublCod = P00FH10_A51SublCod[0];
            n51SublCod = P00FH10_n51SublCod[0];
            A1892SublDsc = P00FH10_A1892SublDsc[0];
            AV98SubLDsc = A1892SublDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(8);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV42Filename = "";
         AV35ErrorMessage = "";
         AV12Archivo = new GxFile(context.GetPhysicalPath());
         AV78Path = "";
         AV43FilenameOrigen = "";
         AV37ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A323ProProdCod = "";
         A1740ProSts = "";
         A325ProFec = DateTime.MinValue;
         P00FH2_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         P00FH2_A1740ProSts = new string[] {""} ;
         P00FH2_A323ProProdCod = new string[] {""} ;
         P00FH2_A1739ProRef = new string[] {""} ;
         P00FH2_A1738ProProdDsc = new string[] {""} ;
         P00FH2_A1654ProCantProd = new decimal[1] ;
         P00FH2_A1655ProCantProdIng = new decimal[1] ;
         P00FH2_A1706ProdRef10 = new string[] {""} ;
         P00FH2_n1706ProdRef10 = new bool[] {false} ;
         P00FH2_A322ProCod = new string[] {""} ;
         A1739ProRef = "";
         A1738ProProdDsc = "";
         A1706ProdRef10 = "";
         A322ProCod = "";
         AV82ProCod = "";
         AV87ProFec = DateTime.MinValue;
         AV90ProRef = "";
         AV88ProProdCod = "";
         AV89ProProdDsc = "";
         AV36Estado = "";
         AV86ProdRef10 = "";
         AV77Orden = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV8LinDsc = "";
         AV98SubLDsc = "";
         P00FH3_A1680ProDConcepto = new string[] {""} ;
         P00FH3_A322ProCod = new string[] {""} ;
         P00FH3_A327ProDProdCod = new string[] {""} ;
         P00FH3_n327ProDProdCod = new bool[] {false} ;
         P00FH3_A326ProDItem = new int[1] ;
         A1680ProDConcepto = "";
         A327ProDProdCod = "";
         AV85ProDProdCod = "";
         P00FH4_A1656ProCosto = new decimal[1] ;
         P00FH5_A322ProCod = new string[] {""} ;
         P00FH5_A1455OrdOpeCosto = new decimal[1] ;
         P00FH5_A1457OrdOpeHora = new decimal[1] ;
         P00FH5_A321OPECod = new string[] {""} ;
         A321OPECod = "";
         P00FH6_A322ProCod = new string[] {""} ;
         P00FH6_A1727ProMaqCosto = new decimal[1] ;
         P00FH6_A1729ProMaqHora = new decimal[1] ;
         P00FH6_A320MAQCod = new string[] {""} ;
         A320MAQCod = "";
         P00FH7_A1726ProGasCosto = new decimal[1] ;
         P00FH8_A14MvACod = new string[] {""} ;
         P00FH8_A1370MVSts = new string[] {""} ;
         P00FH8_A13MvATip = new string[] {""} ;
         P00FH8_A1276MvAOcom = new string[] {""} ;
         P00FH8_A1286MvATMov = new short[1] ;
         P00FH8_A28ProdCod = new string[] {""} ;
         P00FH8_A1248MvADCant = new decimal[1] ;
         P00FH8_A1250MVADPrecio = new decimal[1] ;
         P00FH8_A30MvADItem = new int[1] ;
         A14MvACod = "";
         A1370MVSts = "";
         A13MvATip = "";
         A1276MvAOcom = "";
         A28ProdCod = "";
         P00FH9_A52LinCod = new int[1] ;
         P00FH9_A28ProdCod = new string[] {""} ;
         P00FH9_A1153LinDsc = new string[] {""} ;
         P00FH9_A51SublCod = new int[1] ;
         P00FH9_n51SublCod = new bool[] {false} ;
         A1153LinDsc = "";
         P00FH10_A51SublCod = new int[1] ;
         P00FH10_n51SublCod = new bool[] {false} ;
         P00FH10_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.p_resumenproduccionexcel__default(),
            new Object[][] {
                new Object[] {
               P00FH2_A325ProFec, P00FH2_A1740ProSts, P00FH2_A323ProProdCod, P00FH2_A1739ProRef, P00FH2_A1738ProProdDsc, P00FH2_A1654ProCantProd, P00FH2_A1655ProCantProdIng, P00FH2_A1706ProdRef10, P00FH2_n1706ProdRef10, P00FH2_A322ProCod
               }
               , new Object[] {
               P00FH3_A1680ProDConcepto, P00FH3_A322ProCod, P00FH3_A327ProDProdCod, P00FH3_n327ProDProdCod, P00FH3_A326ProDItem
               }
               , new Object[] {
               P00FH4_A1656ProCosto
               }
               , new Object[] {
               P00FH5_A322ProCod, P00FH5_A1455OrdOpeCosto, P00FH5_A1457OrdOpeHora, P00FH5_A321OPECod
               }
               , new Object[] {
               P00FH6_A322ProCod, P00FH6_A1727ProMaqCosto, P00FH6_A1729ProMaqHora, P00FH6_A320MAQCod
               }
               , new Object[] {
               P00FH7_A1726ProGasCosto
               }
               , new Object[] {
               P00FH8_A14MvACod, P00FH8_A1370MVSts, P00FH8_A13MvATip, P00FH8_A1276MvAOcom, P00FH8_A1286MvATMov, P00FH8_A28ProdCod, P00FH8_A1248MvADCant, P00FH8_A1250MVADPrecio, P00FH8_A30MvADItem
               }
               , new Object[] {
               P00FH9_A52LinCod, P00FH9_A28ProdCod, P00FH9_A1153LinDsc, P00FH9_A51SublCod, P00FH9_n51SublCod
               }
               , new Object[] {
               P00FH10_A51SublCod, P00FH10_A1892SublDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1286MvATMov ;
      private int AV13CellRow ;
      private int AV44FirstColumn ;
      private int A326ProDItem ;
      private int A30MvADItem ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int AV97SubLCod ;
      private decimal AV111TotalGeneral ;
      private decimal AV100TCantidad1 ;
      private decimal AV101TCantidad2 ;
      private decimal A1654ProCantProd ;
      private decimal A1655ProCantProdIng ;
      private decimal AV79ProCantProd ;
      private decimal AV80ProCantProdIng ;
      private decimal AV19CostoT ;
      private decimal AV102TCosto ;
      private decimal AV20CostoUnit ;
      private decimal AV95Servicios ;
      private decimal AV61HM ;
      private decimal AV62HO ;
      private decimal AV114TServicios ;
      private decimal AV104THO ;
      private decimal AV103THM ;
      private decimal AV18Costo ;
      private decimal AV109TManoObra ;
      private decimal AV110TMaquina ;
      private decimal c1656ProCosto ;
      private decimal A1455OrdOpeCosto ;
      private decimal A1457OrdOpeHora ;
      private decimal A1456OrdOpeCostoTotal ;
      private decimal A1727ProMaqCosto ;
      private decimal A1729ProMaqHora ;
      private decimal A1728ProMaqCostoTotal ;
      private decimal c1726ProGasCosto ;
      private decimal A1248MvADCant ;
      private decimal A1250MVADPrecio ;
      private decimal AV70MvADCant ;
      private decimal AV71MVADPrecio ;
      private string AV83ProdCod ;
      private string AV91ProSts ;
      private string AV78Path ;
      private string scmdbuf ;
      private string A323ProProdCod ;
      private string A1740ProSts ;
      private string A1739ProRef ;
      private string A1738ProProdDsc ;
      private string A1706ProdRef10 ;
      private string A322ProCod ;
      private string AV82ProCod ;
      private string AV90ProRef ;
      private string AV88ProProdCod ;
      private string AV89ProProdDsc ;
      private string AV86ProdRef10 ;
      private string AV77Orden ;
      private string AV8LinDsc ;
      private string AV98SubLDsc ;
      private string A1680ProDConcepto ;
      private string A327ProDProdCod ;
      private string AV85ProDProdCod ;
      private string A321OPECod ;
      private string A320MAQCod ;
      private string A14MvACod ;
      private string A1370MVSts ;
      private string A13MvATip ;
      private string A1276MvAOcom ;
      private string A28ProdCod ;
      private string A1153LinDsc ;
      private string A1892SublDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV38FDesde ;
      private DateTime AV41FHasta ;
      private DateTime A325ProFec ;
      private DateTime AV87ProFec ;
      private bool returnInSub ;
      private bool n1706ProdRef10 ;
      private bool n327ProDProdCod ;
      private bool n51SublCod ;
      private string AV42Filename ;
      private string AV35ErrorMessage ;
      private string AV43FilenameOrigen ;
      private string AV36Estado ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProSts ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00FH2_A325ProFec ;
      private string[] P00FH2_A1740ProSts ;
      private string[] P00FH2_A323ProProdCod ;
      private string[] P00FH2_A1739ProRef ;
      private string[] P00FH2_A1738ProProdDsc ;
      private decimal[] P00FH2_A1654ProCantProd ;
      private decimal[] P00FH2_A1655ProCantProdIng ;
      private string[] P00FH2_A1706ProdRef10 ;
      private bool[] P00FH2_n1706ProdRef10 ;
      private string[] P00FH2_A322ProCod ;
      private string[] P00FH3_A1680ProDConcepto ;
      private string[] P00FH3_A322ProCod ;
      private string[] P00FH3_A327ProDProdCod ;
      private bool[] P00FH3_n327ProDProdCod ;
      private int[] P00FH3_A326ProDItem ;
      private decimal[] P00FH4_A1656ProCosto ;
      private string[] P00FH5_A322ProCod ;
      private decimal[] P00FH5_A1455OrdOpeCosto ;
      private decimal[] P00FH5_A1457OrdOpeHora ;
      private string[] P00FH5_A321OPECod ;
      private string[] P00FH6_A322ProCod ;
      private decimal[] P00FH6_A1727ProMaqCosto ;
      private decimal[] P00FH6_A1729ProMaqHora ;
      private string[] P00FH6_A320MAQCod ;
      private decimal[] P00FH7_A1726ProGasCosto ;
      private string[] P00FH8_A14MvACod ;
      private string[] P00FH8_A1370MVSts ;
      private string[] P00FH8_A13MvATip ;
      private string[] P00FH8_A1276MvAOcom ;
      private short[] P00FH8_A1286MvATMov ;
      private string[] P00FH8_A28ProdCod ;
      private decimal[] P00FH8_A1248MvADCant ;
      private decimal[] P00FH8_A1250MVADPrecio ;
      private int[] P00FH8_A30MvADItem ;
      private int[] P00FH9_A52LinCod ;
      private string[] P00FH9_A28ProdCod ;
      private string[] P00FH9_A1153LinDsc ;
      private int[] P00FH9_A51SublCod ;
      private bool[] P00FH9_n51SublCod ;
      private int[] P00FH10_A51SublCod ;
      private bool[] P00FH10_n51SublCod ;
      private string[] P00FH10_A1892SublDsc ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV37ExcelDocument ;
      private GxFile AV12Archivo ;
   }

   public class p_resumenproduccionexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FH2( IGxContext context ,
                                             string AV83ProdCod ,
                                             string AV91ProSts ,
                                             string A323ProProdCod ,
                                             string A1740ProSts ,
                                             DateTime A325ProFec ,
                                             DateTime AV38FDesde ,
                                             DateTime AV41FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProFec], T1.[ProSts], T1.[ProProdCod] AS ProProdCod, T1.[ProRef], T2.[ProdDsc] AS ProProdDsc, T1.[ProCantProd], T1.[ProCantProdIng], T2.[ProdRef10], T1.[ProCod] FROM ([POORDENES] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProProdCod])";
         AddWhere(sWhereString, "(T1.[ProFec] >= @AV38FDesde and T1.[ProFec] <= @AV41FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProProdCod] = @AV83ProdCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91ProSts)) )
         {
            AddWhere(sWhereString, "(T1.[ProSts] = @AV91ProSts)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProCod]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00FH2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00FH3;
          prmP00FH3 = new Object[] {
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH4;
          prmP00FH4 = new Object[] {
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH5;
          prmP00FH5 = new Object[] {
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH6;
          prmP00FH6 = new Object[] {
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH7;
          prmP00FH7 = new Object[] {
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH8;
          prmP00FH8 = new Object[] {
          new ParDef("@AV85ProDProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV77Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FH9;
          prmP00FH9 = new Object[] {
          new ParDef("@AV88ProProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00FH10;
          prmP00FH10 = new Object[] {
          new ParDef("@AV97SubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00FH2;
          prmP00FH2 = new Object[] {
          new ParDef("@AV38FDesde",GXType.Date,8,0) ,
          new ParDef("@AV41FHasta",GXType.Date,8,0) ,
          new ParDef("@AV83ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV91ProSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FH3", "SELECT [ProDConcepto], [ProCod], [ProDProdCod], [ProDItem] FROM [POORDENESDET] WHERE ([ProCod] = @AV77Orden) AND (([ProDConcepto] = '')) ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FH4", "SELECT SUM([ProCosto]) FROM [POORDENESDET] WHERE ([ProCod] = @AV77Orden) AND (Not ([ProDConcepto] = '')) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FH5", "SELECT [ProCod], [OrdOpeCosto], [OrdOpeHora], [OPECod] FROM [POORDENOPERARIO] WHERE [ProCod] = @AV77Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FH6", "SELECT [ProCod], [ProMaqCosto], [ProMaqHora], [MAQCod] FROM [POORDENMAQ] WHERE [ProCod] = @AV77Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FH7", "SELECT SUM([ProGasCosto]) FROM [POORDENGASTO] WHERE [ProCod] = @AV77Orden ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FH8", "SELECT T1.[MvACod], T2.[MVSts], T1.[MvATip], T2.[MvAOcom], T2.[MvATMov], T1.[ProdCod], T1.[MvADCant], T1.[MVADPrecio], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) WHERE (T1.[ProdCod] = @AV85ProDProdCod) AND (T1.[MvATip] <> 'ING') AND (T2.[MVSts] <> 'A') AND (T2.[MvATMov] = 2) AND (T2.[MvAOcom] = @AV77Orden) ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00FH9", "SELECT T1.[LinCod], T1.[ProdCod], T2.[LinDsc], T1.[SublCod] FROM ([APRODUCTOS] T1 INNER JOIN [CLINEAPROD] T2 ON T2.[LinCod] = T1.[LinCod]) WHERE T1.[ProdCod] = @AV88ProProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00FH10", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV97SubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FH10,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getString(9, 10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
