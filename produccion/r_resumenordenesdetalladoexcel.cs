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
   public class r_resumenordenesdetalladoexcel : GXProcedure
   {
      public r_resumenordenesdetalladoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordenesdetalladoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_ProCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV83ProdCod = aP0_ProdCod;
         this.AV84FDesde = aP1_FDesde;
         this.AV85FHasta = aP2_FHasta;
         this.AV100ProCod = aP3_ProCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV83ProdCod;
         aP1_FDesde=this.AV84FDesde;
         aP2_FHasta=this.AV85FHasta;
         aP3_ProCod=this.AV100ProCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref string aP3_ProCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumenordenesdetalladoexcel objr_resumenordenesdetalladoexcel;
         objr_resumenordenesdetalladoexcel = new r_resumenordenesdetalladoexcel();
         objr_resumenordenesdetalladoexcel.AV83ProdCod = aP0_ProdCod;
         objr_resumenordenesdetalladoexcel.AV84FDesde = aP1_FDesde;
         objr_resumenordenesdetalladoexcel.AV85FHasta = aP2_FHasta;
         objr_resumenordenesdetalladoexcel.AV100ProCod = aP3_ProCod;
         objr_resumenordenesdetalladoexcel.AV10Filename = "" ;
         objr_resumenordenesdetalladoexcel.AV11ErrorMessage = "" ;
         objr_resumenordenesdetalladoexcel.context.SetSubmitInitialConfig(context);
         objr_resumenordenesdetalladoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordenesdetalladoexcel);
         aP0_ProdCod=this.AV83ProdCod;
         aP1_FDesde=this.AV84FDesde;
         aP2_FHasta=this.AV85FHasta;
         aP3_ProCod=this.AV100ProCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordenesdetalladoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillaResumenOPDetalle.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillaResumenOPDetalle.xlsx";
         AV10Filename = "Excel/ResumenOPDetalle" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         AV87TotalGeneral = 0.00m;
         AV88TCantidad1 = 0.0000m;
         AV89TCantidad2 = 0.0000m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV83ProdCod ,
                                              AV100ProCod ,
                                              AV84FDesde ,
                                              AV85FHasta ,
                                              A323ProProdCod ,
                                              A322ProCod ,
                                              A325ProFec } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00FJ2 */
         pr_default.execute(0, new Object[] {AV83ProdCod, AV100ProCod, AV84FDesde, AV85FHasta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A325ProFec = P00FJ2_A325ProFec[0];
            A322ProCod = P00FJ2_A322ProCod[0];
            A323ProProdCod = P00FJ2_A323ProProdCod[0];
            A1738ProProdDsc = P00FJ2_A1738ProProdDsc[0];
            A1655ProCantProdIng = P00FJ2_A1655ProCantProdIng[0];
            A1654ProCantProd = P00FJ2_A1654ProCantProd[0];
            A1738ProProdDsc = P00FJ2_A1738ProProdDsc[0];
            AV105Orden = A322ProCod;
            AV101ProFec = A325ProFec;
            AV102ProProdCod = A323ProProdCod;
            AV104ProProdDsc = A1738ProProdDsc;
            AV91ProCantProdIng = A1655ProCantProdIng;
            AV90ProCantProd = A1654ProCantProd;
            AV118TotalCosto = 0.00m;
            /* Using cursor P00FJ3 */
            pr_default.execute(1, new Object[] {AV105Orden});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1680ProDConcepto = P00FJ3_A1680ProDConcepto[0];
               A322ProCod = P00FJ3_A322ProCod[0];
               A326ProDItem = P00FJ3_A326ProDItem[0];
               A327ProDProdCod = P00FJ3_A327ProDProdCod[0];
               n327ProDProdCod = P00FJ3_n327ProDProdCod[0];
               A1704ProDProdDsc = P00FJ3_A1704ProDProdDsc[0];
               A1656ProCosto = P00FJ3_A1656ProCosto[0];
               A1678ProDCantIng = P00FJ3_A1678ProDCantIng[0];
               A1704ProDProdDsc = P00FJ3_A1704ProDProdDsc[0];
               AV106ProDProdCod = A327ProDProdCod;
               AV116ProDProdDsc = A1704ProDProdDsc;
               AV115ProdCosto = ((Convert.ToDecimal(0)==A1678ProDCantIng) ? (decimal)(0) : NumberUtil.Round( A1656ProCosto/ (decimal)(A1678ProDCantIng), 6));
               AV114ProCosto = A1656ProCosto;
               AV113ProDCantIng = A1678ProDCantIng;
               /* Execute user subroutine: 'DETALLE' */
               S134 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Execute user subroutine: 'SERVICIOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'MANOOBRA' */
            S141 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'MAQUINA' */
            S151 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DISTIBUYE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV95CostoUnit = ((AV91ProCantProdIng>Convert.ToDecimal(0)) ? NumberUtil.Round( AV118TotalCosto/ (decimal)(AV91ProCantProdIng), 4) : (decimal)(0));
            AV14CellRow = (int)(AV14CellRow+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'SERVICIOS' Routine */
         returnInSub = false;
         /* Using cursor P00FJ4 */
         pr_default.execute(2, new Object[] {AV105Orden});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A322ProCod = P00FJ4_A322ProCod[0];
            A328ProGasCod = P00FJ4_A328ProGasCod[0];
            A1725ProGasConcepto = P00FJ4_A1725ProGasConcepto[0];
            A1726ProGasCosto = P00FJ4_A1726ProGasCosto[0];
            AV106ProDProdCod = StringUtil.Trim( StringUtil.Str( (decimal)(A328ProGasCod), 10, 0));
            AV116ProDProdDsc = A1725ProGasConcepto;
            AV115ProdCosto = A1726ProGasCosto;
            AV114ProCosto = A1726ProGasCosto;
            AV113ProDCantIng = (decimal)(1);
            /* Execute user subroutine: 'DETALLE' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(2);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S141( )
      {
         /* 'MANOOBRA' Routine */
         returnInSub = false;
         /* Using cursor P00FJ5 */
         pr_default.execute(3, new Object[] {AV105Orden});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A322ProCod = P00FJ5_A322ProCod[0];
            A321OPECod = P00FJ5_A321OPECod[0];
            A1457OrdOpeHora = P00FJ5_A1457OrdOpeHora[0];
            AV106ProDProdCod = A321OPECod;
            AV116ProDProdDsc = "HORAS MANO DE OBRA";
            AV115ProdCosto = 0;
            AV114ProCosto = 0;
            AV113ProDCantIng = A1457OrdOpeHora;
            /* Execute user subroutine: 'DETALLE' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S151( )
      {
         /* 'MAQUINA' Routine */
         returnInSub = false;
         /* Using cursor P00FJ6 */
         pr_default.execute(4, new Object[] {AV105Orden});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A322ProCod = P00FJ6_A322ProCod[0];
            A1727ProMaqCosto = P00FJ6_A1727ProMaqCosto[0];
            A320MAQCod = P00FJ6_A320MAQCod[0];
            A1729ProMaqHora = P00FJ6_A1729ProMaqHora[0];
            AV106ProDProdCod = A320MAQCod;
            AV116ProDProdDsc = "HORAS MAQUINA";
            AV115ProdCosto = 0;
            AV114ProCosto = 0;
            AV113ProDCantIng = A1729ProMaqHora;
            /* Execute user subroutine: 'DETALLE' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(4);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void S161( )
      {
         /* 'DISTIBUYE' Routine */
         returnInSub = false;
         /* Using cursor P00FJ7 */
         pr_default.execute(5, new Object[] {AV105Orden});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A1680ProDConcepto = P00FJ7_A1680ProDConcepto[0];
            A322ProCod = P00FJ7_A322ProCod[0];
            A326ProDItem = P00FJ7_A326ProDItem[0];
            A1677ProDCantFormula = P00FJ7_A1677ProDCantFormula[0];
            A1656ProCosto = P00FJ7_A1656ProCosto[0];
            A327ProDProdCod = P00FJ7_A327ProDProdCod[0];
            n327ProDProdCod = P00FJ7_n327ProDProdCod[0];
            AV117Porcentaje = NumberUtil.Round( A1677ProDCantFormula*100, 4);
            AV115ProdCosto = ((AV91ProCantProdIng>Convert.ToDecimal(0)) ? NumberUtil.Round( A1656ProCosto/ (decimal)(AV91ProCantProdIng), 4) : (decimal)(0));
            AV106ProDProdCod = A327ProDProdCod;
            AV116ProDProdDsc = StringUtil.Trim( A1680ProDConcepto);
            AV114ProCosto = A1656ProCosto;
            AV113ProDCantIng = AV117Porcentaje;
            /* Execute user subroutine: 'DETALLE' */
            S134 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S134( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV105Orden);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV101ProFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV102ProProdCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV104ProProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Number = (double)(AV90ProCantProd);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV91ProCantProdIng);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV106ProDProdCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV116ProDProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV113ProDCantIng);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV115ProdCosto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV114ProCosto);
         AV14CellRow = (int)(AV14CellRow+1);
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV72Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A323ProProdCod = "";
         A322ProCod = "";
         A325ProFec = DateTime.MinValue;
         P00FJ2_A325ProFec = new DateTime[] {DateTime.MinValue} ;
         P00FJ2_A322ProCod = new string[] {""} ;
         P00FJ2_A323ProProdCod = new string[] {""} ;
         P00FJ2_A1738ProProdDsc = new string[] {""} ;
         P00FJ2_A1655ProCantProdIng = new decimal[1] ;
         P00FJ2_A1654ProCantProd = new decimal[1] ;
         A1738ProProdDsc = "";
         AV105Orden = "";
         AV101ProFec = DateTime.MinValue;
         AV102ProProdCod = "";
         AV104ProProdDsc = "";
         P00FJ3_A1680ProDConcepto = new string[] {""} ;
         P00FJ3_A322ProCod = new string[] {""} ;
         P00FJ3_A326ProDItem = new int[1] ;
         P00FJ3_A327ProDProdCod = new string[] {""} ;
         P00FJ3_n327ProDProdCod = new bool[] {false} ;
         P00FJ3_A1704ProDProdDsc = new string[] {""} ;
         P00FJ3_A1656ProCosto = new decimal[1] ;
         P00FJ3_A1678ProDCantIng = new decimal[1] ;
         A1680ProDConcepto = "";
         A327ProDProdCod = "";
         A1704ProDProdDsc = "";
         AV106ProDProdCod = "";
         AV116ProDProdDsc = "";
         P00FJ4_A322ProCod = new string[] {""} ;
         P00FJ4_A328ProGasCod = new short[1] ;
         P00FJ4_A1725ProGasConcepto = new string[] {""} ;
         P00FJ4_A1726ProGasCosto = new decimal[1] ;
         A1725ProGasConcepto = "";
         P00FJ5_A322ProCod = new string[] {""} ;
         P00FJ5_A321OPECod = new string[] {""} ;
         P00FJ5_A1457OrdOpeHora = new decimal[1] ;
         A321OPECod = "";
         P00FJ6_A322ProCod = new string[] {""} ;
         P00FJ6_A1727ProMaqCosto = new decimal[1] ;
         P00FJ6_A320MAQCod = new string[] {""} ;
         P00FJ6_A1729ProMaqHora = new decimal[1] ;
         A320MAQCod = "";
         P00FJ7_A1680ProDConcepto = new string[] {""} ;
         P00FJ7_A322ProCod = new string[] {""} ;
         P00FJ7_A326ProDItem = new int[1] ;
         P00FJ7_A1677ProDCantFormula = new decimal[1] ;
         P00FJ7_A1656ProCosto = new decimal[1] ;
         P00FJ7_A327ProDProdCod = new string[] {""} ;
         P00FJ7_n327ProDProdCod = new bool[] {false} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumenordenesdetalladoexcel__default(),
            new Object[][] {
                new Object[] {
               P00FJ2_A325ProFec, P00FJ2_A322ProCod, P00FJ2_A323ProProdCod, P00FJ2_A1738ProProdDsc, P00FJ2_A1655ProCantProdIng, P00FJ2_A1654ProCantProd
               }
               , new Object[] {
               P00FJ3_A1680ProDConcepto, P00FJ3_A322ProCod, P00FJ3_A326ProDItem, P00FJ3_A327ProDProdCod, P00FJ3_n327ProDProdCod, P00FJ3_A1704ProDProdDsc, P00FJ3_A1656ProCosto, P00FJ3_A1678ProDCantIng
               }
               , new Object[] {
               P00FJ4_A322ProCod, P00FJ4_A328ProGasCod, P00FJ4_A1725ProGasConcepto, P00FJ4_A1726ProGasCosto
               }
               , new Object[] {
               P00FJ5_A322ProCod, P00FJ5_A321OPECod, P00FJ5_A1457OrdOpeHora
               }
               , new Object[] {
               P00FJ6_A322ProCod, P00FJ6_A1727ProMaqCosto, P00FJ6_A320MAQCod, P00FJ6_A1729ProMaqHora
               }
               , new Object[] {
               P00FJ7_A1680ProDConcepto, P00FJ7_A322ProCod, P00FJ7_A326ProDItem, P00FJ7_A1677ProDCantFormula, P00FJ7_A1656ProCosto, P00FJ7_A327ProDProdCod, P00FJ7_n327ProDProdCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A328ProGasCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A326ProDItem ;
      private decimal AV87TotalGeneral ;
      private decimal AV88TCantidad1 ;
      private decimal AV89TCantidad2 ;
      private decimal A1655ProCantProdIng ;
      private decimal A1654ProCantProd ;
      private decimal AV91ProCantProdIng ;
      private decimal AV90ProCantProd ;
      private decimal AV118TotalCosto ;
      private decimal A1656ProCosto ;
      private decimal A1678ProDCantIng ;
      private decimal AV115ProdCosto ;
      private decimal AV114ProCosto ;
      private decimal AV113ProDCantIng ;
      private decimal AV95CostoUnit ;
      private decimal A1726ProGasCosto ;
      private decimal A1457OrdOpeHora ;
      private decimal A1727ProMaqCosto ;
      private decimal A1729ProMaqHora ;
      private decimal A1677ProDCantFormula ;
      private decimal AV117Porcentaje ;
      private string AV83ProdCod ;
      private string AV100ProCod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A323ProProdCod ;
      private string A322ProCod ;
      private string A1738ProProdDsc ;
      private string AV105Orden ;
      private string AV102ProProdCod ;
      private string AV104ProProdDsc ;
      private string A1680ProDConcepto ;
      private string A327ProDProdCod ;
      private string A1704ProDProdDsc ;
      private string AV106ProDProdCod ;
      private string AV116ProDProdDsc ;
      private string A321OPECod ;
      private string A320MAQCod ;
      private DateTime GXt_dtime1 ;
      private DateTime AV84FDesde ;
      private DateTime AV85FHasta ;
      private DateTime A325ProFec ;
      private DateTime AV101ProFec ;
      private bool returnInSub ;
      private bool n327ProDProdCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string A1725ProGasConcepto ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProCod ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00FJ2_A325ProFec ;
      private string[] P00FJ2_A322ProCod ;
      private string[] P00FJ2_A323ProProdCod ;
      private string[] P00FJ2_A1738ProProdDsc ;
      private decimal[] P00FJ2_A1655ProCantProdIng ;
      private decimal[] P00FJ2_A1654ProCantProd ;
      private string[] P00FJ3_A1680ProDConcepto ;
      private string[] P00FJ3_A322ProCod ;
      private int[] P00FJ3_A326ProDItem ;
      private string[] P00FJ3_A327ProDProdCod ;
      private bool[] P00FJ3_n327ProDProdCod ;
      private string[] P00FJ3_A1704ProDProdDsc ;
      private decimal[] P00FJ3_A1656ProCosto ;
      private decimal[] P00FJ3_A1678ProDCantIng ;
      private string[] P00FJ4_A322ProCod ;
      private short[] P00FJ4_A328ProGasCod ;
      private string[] P00FJ4_A1725ProGasConcepto ;
      private decimal[] P00FJ4_A1726ProGasCosto ;
      private string[] P00FJ5_A322ProCod ;
      private string[] P00FJ5_A321OPECod ;
      private decimal[] P00FJ5_A1457OrdOpeHora ;
      private string[] P00FJ6_A322ProCod ;
      private decimal[] P00FJ6_A1727ProMaqCosto ;
      private string[] P00FJ6_A320MAQCod ;
      private decimal[] P00FJ6_A1729ProMaqHora ;
      private string[] P00FJ7_A1680ProDConcepto ;
      private string[] P00FJ7_A322ProCod ;
      private int[] P00FJ7_A326ProDItem ;
      private decimal[] P00FJ7_A1677ProDCantFormula ;
      private decimal[] P00FJ7_A1656ProCosto ;
      private string[] P00FJ7_A327ProDProdCod ;
      private bool[] P00FJ7_n327ProDProdCod ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_resumenordenesdetalladoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FJ2( IGxContext context ,
                                             string AV83ProdCod ,
                                             string AV100ProCod ,
                                             DateTime AV84FDesde ,
                                             DateTime AV85FHasta ,
                                             string A323ProProdCod ,
                                             string A322ProCod ,
                                             DateTime A325ProFec )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProFec], T1.[ProCod], T1.[ProProdCod] AS ProProdCod, T2.[ProdDsc] AS ProProdDsc, T1.[ProCantProdIng], T1.[ProCantProd] FROM ([POORDENES] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProProdCod])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProProdCod] = @AV83ProdCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100ProCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProCod] = @AV100ProCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV84FDesde) && ! (DateTime.MinValue==AV85FHasta) )
         {
            AddWhere(sWhereString, "(T1.[ProFec] >= @AV84FDesde and T1.[ProFec] <= @AV85FHasta)");
         }
         else
         {
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProFec]";
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
                     return conditional_P00FJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (DateTime)dynConstraints[2] , (DateTime)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP00FJ3;
          prmP00FJ3 = new Object[] {
          new ParDef("@AV105Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FJ4;
          prmP00FJ4 = new Object[] {
          new ParDef("@AV105Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FJ5;
          prmP00FJ5 = new Object[] {
          new ParDef("@AV105Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FJ6;
          prmP00FJ6 = new Object[] {
          new ParDef("@AV105Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FJ7;
          prmP00FJ7 = new Object[] {
          new ParDef("@AV105Orden",GXType.NChar,10,0)
          };
          Object[] prmP00FJ2;
          prmP00FJ2 = new Object[] {
          new ParDef("@AV83ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV100ProCod",GXType.NChar,10,0) ,
          new ParDef("@AV84FDesde",GXType.Date,8,0) ,
          new ParDef("@AV85FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FJ3", "SELECT T1.[ProDConcepto], T1.[ProCod], T1.[ProDItem], T1.[ProDProdCod] AS ProDProdCod, T2.[ProdDsc] AS ProDProdDsc, T1.[ProCosto], T1.[ProDCantIng] FROM ([POORDENESDET] T1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProDProdCod]) WHERE (T1.[ProCod] = @AV105Orden) AND ((T1.[ProDConcepto] = '')) ORDER BY T1.[ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FJ4", "SELECT [ProCod], [ProGasCod], [ProGasConcepto], [ProGasCosto] FROM [POORDENGASTO] WHERE [ProCod] = @AV105Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FJ5", "SELECT [ProCod], [OPECod], [OrdOpeHora] FROM [POORDENOPERARIO] WHERE [ProCod] = @AV105Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FJ6", "SELECT [ProCod], [ProMaqCosto], [MAQCod], [ProMaqHora] FROM [POORDENMAQ] WHERE [ProCod] = @AV105Orden ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FJ7", "SELECT [ProDConcepto], [ProCod], [ProDItem], [ProDCantFormula], [ProCosto], [ProDProdCod] AS ProDProdCod FROM [POORDENESDET] WHERE ([ProCod] = @AV105Orden) AND (Not ([ProDConcepto] = '')) ORDER BY [ProCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FJ7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
