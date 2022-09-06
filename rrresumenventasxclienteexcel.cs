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
namespace GeneXus.Programs {
   public class rrresumenventasxclienteexcel : GXProcedure
   {
      public rrresumenventasxclienteexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrresumenventasxclienteexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_VenCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_CliCod ,
                           ref DateTime aP3_FDesde ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_Lincod ,
                           ref int aP6_SublCod ,
                           ref string aP7_Tipo ,
                           ref int aP8_TieCod ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV104VenCod = aP0_VenCod;
         this.AV68ProdCod = aP1_ProdCod;
         this.AV14CliCod = aP2_CliCod;
         this.AV37FDesde = aP3_FDesde;
         this.AV39FHasta = aP4_FHasta;
         this.AV47Lincod = aP5_Lincod;
         this.AV78SublCod = aP6_SublCod;
         this.AV88Tipo = aP7_Tipo;
         this.AV83TieCod = aP8_TieCod;
         this.AV40Filename = "" ;
         this.AV31ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_VenCod=this.AV104VenCod;
         aP1_ProdCod=this.AV68ProdCod;
         aP2_CliCod=this.AV14CliCod;
         aP3_FDesde=this.AV37FDesde;
         aP4_FHasta=this.AV39FHasta;
         aP5_Lincod=this.AV47Lincod;
         aP6_SublCod=this.AV78SublCod;
         aP7_Tipo=this.AV88Tipo;
         aP8_TieCod=this.AV83TieCod;
         aP9_Filename=this.AV40Filename;
         aP10_ErrorMessage=this.AV31ErrorMessage;
      }

      public string executeUdp( ref int aP0_VenCod ,
                                ref string aP1_ProdCod ,
                                ref string aP2_CliCod ,
                                ref DateTime aP3_FDesde ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_Lincod ,
                                ref int aP6_SublCod ,
                                ref string aP7_Tipo ,
                                ref int aP8_TieCod ,
                                out string aP9_Filename )
      {
         execute(ref aP0_VenCod, ref aP1_ProdCod, ref aP2_CliCod, ref aP3_FDesde, ref aP4_FHasta, ref aP5_Lincod, ref aP6_SublCod, ref aP7_Tipo, ref aP8_TieCod, out aP9_Filename, out aP10_ErrorMessage);
         return AV31ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_VenCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_CliCod ,
                                 ref DateTime aP3_FDesde ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_Lincod ,
                                 ref int aP6_SublCod ,
                                 ref string aP7_Tipo ,
                                 ref int aP8_TieCod ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         rrresumenventasxclienteexcel objrrresumenventasxclienteexcel;
         objrrresumenventasxclienteexcel = new rrresumenventasxclienteexcel();
         objrrresumenventasxclienteexcel.AV104VenCod = aP0_VenCod;
         objrrresumenventasxclienteexcel.AV68ProdCod = aP1_ProdCod;
         objrrresumenventasxclienteexcel.AV14CliCod = aP2_CliCod;
         objrrresumenventasxclienteexcel.AV37FDesde = aP3_FDesde;
         objrrresumenventasxclienteexcel.AV39FHasta = aP4_FHasta;
         objrrresumenventasxclienteexcel.AV47Lincod = aP5_Lincod;
         objrrresumenventasxclienteexcel.AV78SublCod = aP6_SublCod;
         objrrresumenventasxclienteexcel.AV88Tipo = aP7_Tipo;
         objrrresumenventasxclienteexcel.AV83TieCod = aP8_TieCod;
         objrrresumenventasxclienteexcel.AV40Filename = "" ;
         objrrresumenventasxclienteexcel.AV31ErrorMessage = "" ;
         objrrresumenventasxclienteexcel.context.SetSubmitInitialConfig(context);
         objrrresumenventasxclienteexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrresumenventasxclienteexcel);
         aP0_VenCod=this.AV104VenCod;
         aP1_ProdCod=this.AV68ProdCod;
         aP2_CliCod=this.AV14CliCod;
         aP3_FDesde=this.AV37FDesde;
         aP4_FHasta=this.AV39FHasta;
         aP5_Lincod=this.AV47Lincod;
         aP6_SublCod=this.AV78SublCod;
         aP7_Tipo=this.AV88Tipo;
         aP8_TieCod=this.AV83TieCod;
         aP9_Filename=this.AV40Filename;
         aP10_ErrorMessage=this.AV31ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrresumenventasxclienteexcel)stateInfo).executePrivate();
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
         AV9Archivo.Source = "Excel/PlantillasResumenVentaxCliente.xlsx";
         AV53Path = AV9Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV53Path) + "\\PlantillasResumenVentaxCliente.xlsx";
         AV40Filename = "Excel/ResumenVentaxCliente" + ".xlsx";
         AV33ExcelDocument.Clear();
         AV33ExcelDocument.Template = AV41FilenameOrigen;
         AV33ExcelDocument.Open(AV40Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 5;
         AV45FirstColumn = 0;
         AV46Item = 0;
         AV93TotalGeneral = 0.00m;
         AV97TotalSub = 0.00m;
         AV94TotalIVA = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV83TieCod ,
                                              AV85TipCCod ,
                                              AV32EstCod ,
                                              AV14CliCod ,
                                              AV86TipCod ,
                                              AV52PaiCod ,
                                              AV26DocMonCod ,
                                              AV20DocConpCod ,
                                              AV104VenCod ,
                                              AV88Tipo ,
                                              AV75Serie ,
                                              A178TieCod ,
                                              A159TipCCod ,
                                              A140EstCod ,
                                              A231DocCliCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A230DocMonCod ,
                                              A229DocConpCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A24DocNum ,
                                              A232DocFec ,
                                              AV37FDesde ,
                                              AV39FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EP3 */
         pr_default.execute(0, new Object[] {AV37FDesde, AV39FHasta, AV83TieCod, AV85TipCCod, AV32EstCod, AV14CliCod, AV86TipCod, AV52PaiCod, AV26DocMonCod, AV20DocConpCod, AV104VenCod, AV88Tipo, AV75Serie});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A232DocFec = P00EP3_A232DocFec[0];
            A24DocNum = P00EP3_A24DocNum[0];
            A946DocTipo = P00EP3_A946DocTipo[0];
            A227DocVendCod = P00EP3_A227DocVendCod[0];
            A229DocConpCod = P00EP3_A229DocConpCod[0];
            A230DocMonCod = P00EP3_A230DocMonCod[0];
            A139PaiCod = P00EP3_A139PaiCod[0];
            n139PaiCod = P00EP3_n139PaiCod[0];
            A149TipCod = P00EP3_A149TipCod[0];
            A231DocCliCod = P00EP3_A231DocCliCod[0];
            A140EstCod = P00EP3_A140EstCod[0];
            n140EstCod = P00EP3_n140EstCod[0];
            A159TipCCod = P00EP3_A159TipCCod[0];
            n159TipCCod = P00EP3_n159TipCCod[0];
            A178TieCod = P00EP3_A178TieCod[0];
            n178TieCod = P00EP3_n178TieCod[0];
            A941DocSts = P00EP3_A941DocSts[0];
            A887DocCliDsc = P00EP3_A887DocCliDsc[0];
            A511TipSigno = P00EP3_A511TipSigno[0];
            A932DocICBPER = P00EP3_A932DocICBPER[0];
            A935DocRedondeo = P00EP3_A935DocRedondeo[0];
            A934DocPorIVA = P00EP3_A934DocPorIVA[0];
            A882DocAnticipos = P00EP3_A882DocAnticipos[0];
            A899DocDcto = P00EP3_A899DocDcto[0];
            A927DocSubExonerado = P00EP3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EP3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EP3_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EP3_A920DocSubAfecto[0];
            A511TipSigno = P00EP3_A511TipSigno[0];
            A927DocSubExonerado = P00EP3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EP3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EP3_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EP3_A920DocSubAfecto[0];
            A139PaiCod = P00EP3_A139PaiCod[0];
            n139PaiCod = P00EP3_n139PaiCod[0];
            A140EstCod = P00EP3_A140EstCod[0];
            n140EstCod = P00EP3_n140EstCod[0];
            A159TipCCod = P00EP3_A159TipCCod[0];
            n159TipCCod = P00EP3_n159TipCCod[0];
            A887DocCliDsc = P00EP3_A887DocCliDsc[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
            A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
            AV29DocSts = A941DocSts;
            AV18DocCliCod = A231DocCliCod;
            AV19DocCliDsc = A887DocCliDsc;
            AV76Signo = A511TipSigno;
            AV30DocSub = (decimal)(A919DocSub*AV76Signo);
            AV22DocDscto = (decimal)(A918DocDscto*AV76Signo);
            AV25DocIVA = (decimal)(A933DocIVA*AV76Signo);
            AV98TotalVenta = (decimal)(A948DocTot*AV76Signo);
            AV30DocSub = (decimal)(AV30DocSub-AV22DocDscto);
            AV89TipoVenta = ((StringUtil.StrCmp(A946DocTipo, "M")==0) ? "MUESTRA" : ((StringUtil.StrCmp(A946DocTipo, "A")==0) ? "ANTICIPO" : ((StringUtil.StrCmp(A946DocTipo, "E")==0) ? "EXPORTACION" : ((StringUtil.StrCmp(A946DocTipo, "X")==0) ? "MUESTRA EXPORTACION" : "NORMAL"))));
            if ( StringUtil.StrCmp(AV29DocSts, "A") == 0 )
            {
               AV18DocCliCod = "";
               AV19DocCliDsc = "ANULADO";
               AV76Signo = 1;
               AV30DocSub = 0.00m;
               AV25DocIVA = 0.00m;
               AV98TotalVenta = 0.00m;
            }
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV97TotalSub = (decimal)(AV97TotalSub+AV30DocSub);
            AV94TotalIVA = (decimal)(AV94TotalIVA+AV25DocIVA);
            AV93TotalGeneral = (decimal)(AV93TotalGeneral+AV98TotalVenta);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV33ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV33ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV83TieCod ,
                                              AV47Lincod ,
                                              AV68ProdCod ,
                                              AV78SublCod ,
                                              AV104VenCod ,
                                              AV88Tipo ,
                                              A178TieCod ,
                                              A52LinCod ,
                                              A28ProdCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV37FDesde ,
                                              AV39FHasta ,
                                              A941DocSts ,
                                              A231DocCliCod ,
                                              AV18DocCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EP4 */
         pr_default.execute(1, new Object[] {AV37FDesde, AV39FHasta, AV18DocCliCod, AV83TieCod, AV47Lincod, AV68ProdCod, AV78SublCod, AV104VenCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEP3 = false;
            A149TipCod = P00EP4_A149TipCod[0];
            A24DocNum = P00EP4_A24DocNum[0];
            A49UniCod = P00EP4_A49UniCod[0];
            A55ProdDsc = P00EP4_A55ProdDsc[0];
            A28ProdCod = P00EP4_A28ProdCod[0];
            A941DocSts = P00EP4_A941DocSts[0];
            A946DocTipo = P00EP4_A946DocTipo[0];
            A227DocVendCod = P00EP4_A227DocVendCod[0];
            A51SublCod = P00EP4_A51SublCod[0];
            n51SublCod = P00EP4_n51SublCod[0];
            A52LinCod = P00EP4_A52LinCod[0];
            A178TieCod = P00EP4_A178TieCod[0];
            n178TieCod = P00EP4_n178TieCod[0];
            A231DocCliCod = P00EP4_A231DocCliCod[0];
            A232DocFec = P00EP4_A232DocFec[0];
            A894DocDpre = P00EP4_A894DocDpre[0];
            A1997UniAbr = P00EP4_A1997UniAbr[0];
            A233DocItem = P00EP4_A233DocItem[0];
            A941DocSts = P00EP4_A941DocSts[0];
            A946DocTipo = P00EP4_A946DocTipo[0];
            A227DocVendCod = P00EP4_A227DocVendCod[0];
            A178TieCod = P00EP4_A178TieCod[0];
            n178TieCod = P00EP4_n178TieCod[0];
            A231DocCliCod = P00EP4_A231DocCliCod[0];
            A232DocFec = P00EP4_A232DocFec[0];
            A49UniCod = P00EP4_A49UniCod[0];
            A55ProdDsc = P00EP4_A55ProdDsc[0];
            A51SublCod = P00EP4_A51SublCod[0];
            n51SublCod = P00EP4_n51SublCod[0];
            A52LinCod = P00EP4_A52LinCod[0];
            A1997UniAbr = P00EP4_A1997UniAbr[0];
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EP4_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRKEP3 = false;
               A149TipCod = P00EP4_A149TipCod[0];
               A24DocNum = P00EP4_A24DocNum[0];
               A55ProdDsc = P00EP4_A55ProdDsc[0];
               A233DocItem = P00EP4_A233DocItem[0];
               A55ProdDsc = P00EP4_A55ProdDsc[0];
               BRKEP3 = true;
               pr_default.readNext(1);
            }
            AV72Producto = StringUtil.Trim( A28ProdCod);
            AV70ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV103UniAbr = StringUtil.Trim( A1997UniAbr);
            AV11Cantidad = 0.00m;
            AV96TotalMN = 0.00m;
            AV95TotalME = 0.00m;
            AV36ExpresadoMN = 0.00m;
            AV35ExpresadoME = 0.00m;
            /* Execute user subroutine: 'PRODUCTO' */
            S123 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLEEXCEL' */
            S133 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV80TCantidad = (decimal)(AV80TCantidad+AV11Cantidad);
            AV102TTotalMN = (decimal)(AV102TTotalMN+AV96TotalMN);
            AV101TTotalME = (decimal)(AV101TTotalME+AV95TotalME);
            AV82TExpresadoMN = (decimal)(AV82TExpresadoMN+AV36ExpresadoMN);
            AV81TExpresadoME = (decimal)(AV81TExpresadoME+AV35ExpresadoME);
            if ( ! BRKEP3 )
            {
               BRKEP3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S123( )
      {
         /* 'PRODUCTO' Routine */
         returnInSub = false;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV83TieCod ,
                                              AV47Lincod ,
                                              AV78SublCod ,
                                              AV104VenCod ,
                                              AV88Tipo ,
                                              A178TieCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV37FDesde ,
                                              AV39FHasta ,
                                              A941DocSts ,
                                              A231DocCliCod ,
                                              AV18DocCliCod ,
                                              AV72Producto ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EP5 */
         pr_default.execute(2, new Object[] {AV72Producto, AV37FDesde, AV39FHasta, AV18DocCliCod, AV83TieCod, AV47Lincod, AV78SublCod, AV104VenCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A941DocSts = P00EP5_A941DocSts[0];
            A946DocTipo = P00EP5_A946DocTipo[0];
            A227DocVendCod = P00EP5_A227DocVendCod[0];
            A51SublCod = P00EP5_A51SublCod[0];
            n51SublCod = P00EP5_n51SublCod[0];
            A28ProdCod = P00EP5_A28ProdCod[0];
            A52LinCod = P00EP5_A52LinCod[0];
            A178TieCod = P00EP5_A178TieCod[0];
            n178TieCod = P00EP5_n178TieCod[0];
            A231DocCliCod = P00EP5_A231DocCliCod[0];
            A232DocFec = P00EP5_A232DocFec[0];
            A894DocDpre = P00EP5_A894DocDpre[0];
            A149TipCod = P00EP5_A149TipCod[0];
            A24DocNum = P00EP5_A24DocNum[0];
            A230DocMonCod = P00EP5_A230DocMonCod[0];
            A226DocMovCod = P00EP5_A226DocMovCod[0];
            A899DocDcto = P00EP5_A899DocDcto[0];
            A892DocDTot = P00EP5_A892DocDTot[0];
            A511TipSigno = P00EP5_A511TipSigno[0];
            A895DocDCan = P00EP5_A895DocDCan[0];
            A882DocAnticipos = P00EP5_A882DocAnticipos[0];
            A929DocFecRef = P00EP5_A929DocFecRef[0];
            A233DocItem = P00EP5_A233DocItem[0];
            A51SublCod = P00EP5_A51SublCod[0];
            n51SublCod = P00EP5_n51SublCod[0];
            A52LinCod = P00EP5_A52LinCod[0];
            A511TipSigno = P00EP5_A511TipSigno[0];
            A941DocSts = P00EP5_A941DocSts[0];
            A946DocTipo = P00EP5_A946DocTipo[0];
            A227DocVendCod = P00EP5_A227DocVendCod[0];
            A178TieCod = P00EP5_A178TieCod[0];
            n178TieCod = P00EP5_n178TieCod[0];
            A231DocCliCod = P00EP5_A231DocCliCod[0];
            A232DocFec = P00EP5_A232DocFec[0];
            A230DocMonCod = P00EP5_A230DocMonCod[0];
            A226DocMovCod = P00EP5_A226DocMovCod[0];
            A899DocDcto = P00EP5_A899DocDcto[0];
            A882DocAnticipos = P00EP5_A882DocAnticipos[0];
            A929DocFecRef = P00EP5_A929DocFecRef[0];
            AV86TipCod = A149TipCod;
            AV28DocNum = A24DocNum;
            AV38Fecha = A232DocFec;
            AV49MonCod = A230DocMonCod;
            AV27DocMovCod = A226DocMovCod;
            AV65PorDscto = A899DocDcto;
            AV16Descuento = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)*AV65PorDscto)/ (decimal)(100), 2);
            AV92Total = NumberUtil.Round( (NumberUtil.Round( A892DocDTot, 2)-AV16Descuento)*A511TipSigno, 2);
            AV21DocDCan = NumberUtil.Round( A895DocDCan*A511TipSigno, 4);
            AV17DocAnticipos = (decimal)(NumberUtil.Round( A882DocAnticipos, 2)*A511TipSigno);
            if ( ( StringUtil.StrCmp(AV86TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV86TipCod, "ND") == 0 ) )
            {
               /* Execute user subroutine: 'VALIDATIPOMOVIMIENTO' */
               S145 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV38Fecha = ((StringUtil.StrCmp(AV86TipCod, "NC")==0)||(StringUtil.StrCmp(AV86TipCod, "ND")==0) ? A929DocFecRef : A232DocFec);
            }
            if ( ! (Convert.ToDecimal(0)==AV17DocAnticipos) )
            {
               /* Execute user subroutine: 'SUBTOTAL' */
               S155 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  returnInSub = true;
                  if (true) return;
               }
               AV64Porcentaje = NumberUtil.Round( AV92Total/ (decimal)(((Convert.ToDecimal(0)==AV79SubTotal) ? (decimal)(1) : AV79SubTotal)), 10);
               AV8Anticipo = NumberUtil.Round( AV64Porcentaje*AV17DocAnticipos, 2);
            }
            else
            {
               AV64Porcentaje = 0.00m;
               AV8Anticipo = 0.00m;
               AV79SubTotal = 0.00m;
            }
            AV92Total = (decimal)(AV92Total-(AV8Anticipo+AV16Descuento));
            AV11Cantidad = (decimal)(AV11Cantidad+AV21DocDCan);
            GXt_decimal1 = AV10Cambio;
            GXt_int2 = 2;
            GXt_char3 = "V";
            new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV38Fecha, ref  GXt_char3, out  GXt_decimal1) ;
            AV10Cambio = GXt_decimal1;
            AV96TotalMN = (decimal)(AV96TotalMN+(((AV49MonCod==1) ? AV92Total : (decimal)(0))));
            AV95TotalME = (decimal)(AV95TotalME+(((AV49MonCod==1) ? (decimal)(0) : AV92Total)));
            AV36ExpresadoMN = (decimal)(AV36ExpresadoMN+(((AV49MonCod==1) ? AV92Total : NumberUtil.Round( AV92Total*AV10Cambio, 2))));
            AV35ExpresadoME = (decimal)(AV35ExpresadoME+(((AV49MonCod==1) ? NumberUtil.Round( AV92Total/ (decimal)(AV10Cambio), 2) : AV92Total)));
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S145( )
      {
         /* 'VALIDATIPOMOVIMIENTO' Routine */
         returnInSub = false;
         /* Using cursor P00EP6 */
         pr_default.execute(3, new Object[] {AV27DocMovCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A235MovVCod = P00EP6_A235MovVCod[0];
            A1242MovVAbr = P00EP6_A1242MovVAbr[0];
            if ( ! ( StringUtil.StrCmp(A1242MovVAbr, "SI") == 0 ) )
            {
               AV21DocDCan = 0.00m;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
      }

      protected void S155( )
      {
         /* 'SUBTOTAL' Routine */
         returnInSub = false;
         /* Using cursor P00EP8 */
         pr_default.execute(4, new Object[] {AV86TipCod, AV28DocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00EP8_A24DocNum[0];
            A149TipCod = P00EP8_A149TipCod[0];
            A927DocSubExonerado = P00EP8_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EP8_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EP8_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EP8_A920DocSubAfecto[0];
            A927DocSubExonerado = P00EP8_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EP8_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EP8_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EP8_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            AV79SubTotal = NumberUtil.Round( A919DocSub, 2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
      }

      protected void S133( )
      {
         /* 'DETALLEEXCEL' Routine */
         returnInSub = false;
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV18DocCliCod);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV19DocCliDsc);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV72Producto);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV70ProdDsc);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV103UniAbr);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+6), 1, 1).Number = (double)(AV11Cantidad);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+7), 1, 1).Number = (double)(AV96TotalMN);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+8), 1, 1).Number = (double)(AV95TotalME);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+9), 1, 1).Number = (double)(AV36ExpresadoMN);
         AV33ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV45FirstColumn+10), 1, 1).Number = (double)(AV35ExpresadoME);
         AV12CellRow = (long)(AV12CellRow+1);
      }

      protected void S161( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV33ExcelDocument.ErrCode != 0 )
         {
            AV40Filename = "";
            AV31ErrorMessage = AV33ExcelDocument.ErrDescription;
            AV33ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
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
         AV40Filename = "";
         AV31ErrorMessage = "";
         AV9Archivo = new GxFile(context.GetPhysicalPath());
         AV53Path = "";
         AV41FilenameOrigen = "";
         AV33ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         AV32EstCod = "";
         AV86TipCod = "";
         AV52PaiCod = "";
         AV75Serie = "";
         A140EstCod = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A139PaiCod = "";
         A946DocTipo = "";
         A24DocNum = "";
         A232DocFec = DateTime.MinValue;
         P00EP3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EP3_A24DocNum = new string[] {""} ;
         P00EP3_A946DocTipo = new string[] {""} ;
         P00EP3_A227DocVendCod = new int[1] ;
         P00EP3_A229DocConpCod = new int[1] ;
         P00EP3_A230DocMonCod = new int[1] ;
         P00EP3_A139PaiCod = new string[] {""} ;
         P00EP3_n139PaiCod = new bool[] {false} ;
         P00EP3_A149TipCod = new string[] {""} ;
         P00EP3_A231DocCliCod = new string[] {""} ;
         P00EP3_A140EstCod = new string[] {""} ;
         P00EP3_n140EstCod = new bool[] {false} ;
         P00EP3_A159TipCCod = new int[1] ;
         P00EP3_n159TipCCod = new bool[] {false} ;
         P00EP3_A178TieCod = new int[1] ;
         P00EP3_n178TieCod = new bool[] {false} ;
         P00EP3_A941DocSts = new string[] {""} ;
         P00EP3_A887DocCliDsc = new string[] {""} ;
         P00EP3_A511TipSigno = new short[1] ;
         P00EP3_A932DocICBPER = new decimal[1] ;
         P00EP3_A935DocRedondeo = new decimal[1] ;
         P00EP3_A934DocPorIVA = new decimal[1] ;
         P00EP3_A882DocAnticipos = new decimal[1] ;
         P00EP3_A899DocDcto = new decimal[1] ;
         P00EP3_A927DocSubExonerado = new decimal[1] ;
         P00EP3_A922DocSubSelectivo = new decimal[1] ;
         P00EP3_A921DocSubInafecto = new decimal[1] ;
         P00EP3_A920DocSubAfecto = new decimal[1] ;
         A941DocSts = "";
         A887DocCliDsc = "";
         AV29DocSts = "";
         AV18DocCliCod = "";
         AV19DocCliDsc = "";
         AV89TipoVenta = "";
         A28ProdCod = "";
         P00EP4_A149TipCod = new string[] {""} ;
         P00EP4_A24DocNum = new string[] {""} ;
         P00EP4_A49UniCod = new int[1] ;
         P00EP4_A55ProdDsc = new string[] {""} ;
         P00EP4_A28ProdCod = new string[] {""} ;
         P00EP4_A941DocSts = new string[] {""} ;
         P00EP4_A946DocTipo = new string[] {""} ;
         P00EP4_A227DocVendCod = new int[1] ;
         P00EP4_A51SublCod = new int[1] ;
         P00EP4_n51SublCod = new bool[] {false} ;
         P00EP4_A52LinCod = new int[1] ;
         P00EP4_A178TieCod = new int[1] ;
         P00EP4_n178TieCod = new bool[] {false} ;
         P00EP4_A231DocCliCod = new string[] {""} ;
         P00EP4_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EP4_A894DocDpre = new decimal[1] ;
         P00EP4_A1997UniAbr = new string[] {""} ;
         P00EP4_A233DocItem = new long[1] ;
         A55ProdDsc = "";
         A1997UniAbr = "";
         AV72Producto = "";
         AV70ProdDsc = "";
         AV103UniAbr = "";
         P00EP5_A941DocSts = new string[] {""} ;
         P00EP5_A946DocTipo = new string[] {""} ;
         P00EP5_A227DocVendCod = new int[1] ;
         P00EP5_A51SublCod = new int[1] ;
         P00EP5_n51SublCod = new bool[] {false} ;
         P00EP5_A28ProdCod = new string[] {""} ;
         P00EP5_A52LinCod = new int[1] ;
         P00EP5_A178TieCod = new int[1] ;
         P00EP5_n178TieCod = new bool[] {false} ;
         P00EP5_A231DocCliCod = new string[] {""} ;
         P00EP5_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EP5_A894DocDpre = new decimal[1] ;
         P00EP5_A149TipCod = new string[] {""} ;
         P00EP5_A24DocNum = new string[] {""} ;
         P00EP5_A230DocMonCod = new int[1] ;
         P00EP5_A226DocMovCod = new int[1] ;
         P00EP5_A899DocDcto = new decimal[1] ;
         P00EP5_A892DocDTot = new decimal[1] ;
         P00EP5_A511TipSigno = new short[1] ;
         P00EP5_A895DocDCan = new decimal[1] ;
         P00EP5_A882DocAnticipos = new decimal[1] ;
         P00EP5_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EP5_A233DocItem = new long[1] ;
         A929DocFecRef = DateTime.MinValue;
         AV28DocNum = "";
         AV38Fecha = DateTime.MinValue;
         GXt_char3 = "";
         P00EP6_A235MovVCod = new int[1] ;
         P00EP6_A1242MovVAbr = new string[] {""} ;
         A1242MovVAbr = "";
         P00EP8_A24DocNum = new string[] {""} ;
         P00EP8_A149TipCod = new string[] {""} ;
         P00EP8_A927DocSubExonerado = new decimal[1] ;
         P00EP8_A922DocSubSelectivo = new decimal[1] ;
         P00EP8_A921DocSubInafecto = new decimal[1] ;
         P00EP8_A920DocSubAfecto = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rrresumenventasxclienteexcel__default(),
            new Object[][] {
                new Object[] {
               P00EP3_A232DocFec, P00EP3_A24DocNum, P00EP3_A946DocTipo, P00EP3_A227DocVendCod, P00EP3_A229DocConpCod, P00EP3_A230DocMonCod, P00EP3_A139PaiCod, P00EP3_n139PaiCod, P00EP3_A149TipCod, P00EP3_A231DocCliCod,
               P00EP3_A140EstCod, P00EP3_n140EstCod, P00EP3_A159TipCCod, P00EP3_n159TipCCod, P00EP3_A178TieCod, P00EP3_n178TieCod, P00EP3_A941DocSts, P00EP3_A887DocCliDsc, P00EP3_A511TipSigno, P00EP3_A932DocICBPER,
               P00EP3_A935DocRedondeo, P00EP3_A934DocPorIVA, P00EP3_A882DocAnticipos, P00EP3_A899DocDcto, P00EP3_A927DocSubExonerado, P00EP3_A922DocSubSelectivo, P00EP3_A921DocSubInafecto, P00EP3_A920DocSubAfecto
               }
               , new Object[] {
               P00EP4_A149TipCod, P00EP4_A24DocNum, P00EP4_A49UniCod, P00EP4_A55ProdDsc, P00EP4_A28ProdCod, P00EP4_A941DocSts, P00EP4_A946DocTipo, P00EP4_A227DocVendCod, P00EP4_A51SublCod, P00EP4_n51SublCod,
               P00EP4_A52LinCod, P00EP4_A178TieCod, P00EP4_n178TieCod, P00EP4_A231DocCliCod, P00EP4_A232DocFec, P00EP4_A894DocDpre, P00EP4_A1997UniAbr, P00EP4_A233DocItem
               }
               , new Object[] {
               P00EP5_A941DocSts, P00EP5_A946DocTipo, P00EP5_A227DocVendCod, P00EP5_A51SublCod, P00EP5_n51SublCod, P00EP5_A28ProdCod, P00EP5_A52LinCod, P00EP5_A178TieCod, P00EP5_n178TieCod, P00EP5_A231DocCliCod,
               P00EP5_A232DocFec, P00EP5_A894DocDpre, P00EP5_A149TipCod, P00EP5_A24DocNum, P00EP5_A230DocMonCod, P00EP5_A226DocMovCod, P00EP5_A899DocDcto, P00EP5_A892DocDTot, P00EP5_A511TipSigno, P00EP5_A895DocDCan,
               P00EP5_A882DocAnticipos, P00EP5_A929DocFecRef, P00EP5_A233DocItem
               }
               , new Object[] {
               P00EP6_A235MovVCod, P00EP6_A1242MovVAbr
               }
               , new Object[] {
               P00EP8_A24DocNum, P00EP8_A149TipCod, P00EP8_A927DocSubExonerado, P00EP8_A922DocSubSelectivo, P00EP8_A921DocSubInafecto, P00EP8_A920DocSubAfecto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A511TipSigno ;
      private short AV76Signo ;
      private int AV104VenCod ;
      private int AV47Lincod ;
      private int AV78SublCod ;
      private int AV83TieCod ;
      private int AV46Item ;
      private int AV85TipCCod ;
      private int AV26DocMonCod ;
      private int AV20DocConpCod ;
      private int A178TieCod ;
      private int A159TipCCod ;
      private int A230DocMonCod ;
      private int A229DocConpCod ;
      private int A227DocVendCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A49UniCod ;
      private int A226DocMovCod ;
      private int AV49MonCod ;
      private int AV27DocMovCod ;
      private int GXt_int2 ;
      private int A235MovVCod ;
      private long AV12CellRow ;
      private long AV45FirstColumn ;
      private long A233DocItem ;
      private decimal AV93TotalGeneral ;
      private decimal AV97TotalSub ;
      private decimal AV94TotalIVA ;
      private decimal A932DocICBPER ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A882DocAnticipos ;
      private decimal A899DocDcto ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV30DocSub ;
      private decimal AV22DocDscto ;
      private decimal AV25DocIVA ;
      private decimal AV98TotalVenta ;
      private decimal A894DocDpre ;
      private decimal AV11Cantidad ;
      private decimal AV96TotalMN ;
      private decimal AV95TotalME ;
      private decimal AV36ExpresadoMN ;
      private decimal AV35ExpresadoME ;
      private decimal AV80TCantidad ;
      private decimal AV102TTotalMN ;
      private decimal AV101TTotalME ;
      private decimal AV82TExpresadoMN ;
      private decimal AV81TExpresadoME ;
      private decimal A892DocDTot ;
      private decimal A895DocDCan ;
      private decimal AV65PorDscto ;
      private decimal AV16Descuento ;
      private decimal AV92Total ;
      private decimal AV21DocDCan ;
      private decimal AV17DocAnticipos ;
      private decimal AV64Porcentaje ;
      private decimal AV79SubTotal ;
      private decimal AV8Anticipo ;
      private decimal AV10Cambio ;
      private decimal GXt_decimal1 ;
      private string AV68ProdCod ;
      private string AV14CliCod ;
      private string AV88Tipo ;
      private string AV53Path ;
      private string scmdbuf ;
      private string AV32EstCod ;
      private string AV86TipCod ;
      private string AV52PaiCod ;
      private string AV75Serie ;
      private string A140EstCod ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A139PaiCod ;
      private string A946DocTipo ;
      private string A24DocNum ;
      private string A941DocSts ;
      private string A887DocCliDsc ;
      private string AV29DocSts ;
      private string AV18DocCliCod ;
      private string AV19DocCliDsc ;
      private string AV89TipoVenta ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string AV72Producto ;
      private string AV70ProdDsc ;
      private string AV103UniAbr ;
      private string AV28DocNum ;
      private string GXt_char3 ;
      private string A1242MovVAbr ;
      private DateTime AV37FDesde ;
      private DateTime AV39FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV38Fecha ;
      private bool returnInSub ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n159TipCCod ;
      private bool n178TieCod ;
      private bool BRKEP3 ;
      private bool n51SublCod ;
      private string AV40Filename ;
      private string AV31ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_VenCod ;
      private string aP1_ProdCod ;
      private string aP2_CliCod ;
      private DateTime aP3_FDesde ;
      private DateTime aP4_FHasta ;
      private int aP5_Lincod ;
      private int aP6_SublCod ;
      private string aP7_Tipo ;
      private int aP8_TieCod ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00EP3_A232DocFec ;
      private string[] P00EP3_A24DocNum ;
      private string[] P00EP3_A946DocTipo ;
      private int[] P00EP3_A227DocVendCod ;
      private int[] P00EP3_A229DocConpCod ;
      private int[] P00EP3_A230DocMonCod ;
      private string[] P00EP3_A139PaiCod ;
      private bool[] P00EP3_n139PaiCod ;
      private string[] P00EP3_A149TipCod ;
      private string[] P00EP3_A231DocCliCod ;
      private string[] P00EP3_A140EstCod ;
      private bool[] P00EP3_n140EstCod ;
      private int[] P00EP3_A159TipCCod ;
      private bool[] P00EP3_n159TipCCod ;
      private int[] P00EP3_A178TieCod ;
      private bool[] P00EP3_n178TieCod ;
      private string[] P00EP3_A941DocSts ;
      private string[] P00EP3_A887DocCliDsc ;
      private short[] P00EP3_A511TipSigno ;
      private decimal[] P00EP3_A932DocICBPER ;
      private decimal[] P00EP3_A935DocRedondeo ;
      private decimal[] P00EP3_A934DocPorIVA ;
      private decimal[] P00EP3_A882DocAnticipos ;
      private decimal[] P00EP3_A899DocDcto ;
      private decimal[] P00EP3_A927DocSubExonerado ;
      private decimal[] P00EP3_A922DocSubSelectivo ;
      private decimal[] P00EP3_A921DocSubInafecto ;
      private decimal[] P00EP3_A920DocSubAfecto ;
      private string[] P00EP4_A149TipCod ;
      private string[] P00EP4_A24DocNum ;
      private int[] P00EP4_A49UniCod ;
      private string[] P00EP4_A55ProdDsc ;
      private string[] P00EP4_A28ProdCod ;
      private string[] P00EP4_A941DocSts ;
      private string[] P00EP4_A946DocTipo ;
      private int[] P00EP4_A227DocVendCod ;
      private int[] P00EP4_A51SublCod ;
      private bool[] P00EP4_n51SublCod ;
      private int[] P00EP4_A52LinCod ;
      private int[] P00EP4_A178TieCod ;
      private bool[] P00EP4_n178TieCod ;
      private string[] P00EP4_A231DocCliCod ;
      private DateTime[] P00EP4_A232DocFec ;
      private decimal[] P00EP4_A894DocDpre ;
      private string[] P00EP4_A1997UniAbr ;
      private long[] P00EP4_A233DocItem ;
      private string[] P00EP5_A941DocSts ;
      private string[] P00EP5_A946DocTipo ;
      private int[] P00EP5_A227DocVendCod ;
      private int[] P00EP5_A51SublCod ;
      private bool[] P00EP5_n51SublCod ;
      private string[] P00EP5_A28ProdCod ;
      private int[] P00EP5_A52LinCod ;
      private int[] P00EP5_A178TieCod ;
      private bool[] P00EP5_n178TieCod ;
      private string[] P00EP5_A231DocCliCod ;
      private DateTime[] P00EP5_A232DocFec ;
      private decimal[] P00EP5_A894DocDpre ;
      private string[] P00EP5_A149TipCod ;
      private string[] P00EP5_A24DocNum ;
      private int[] P00EP5_A230DocMonCod ;
      private int[] P00EP5_A226DocMovCod ;
      private decimal[] P00EP5_A899DocDcto ;
      private decimal[] P00EP5_A892DocDTot ;
      private short[] P00EP5_A511TipSigno ;
      private decimal[] P00EP5_A895DocDCan ;
      private decimal[] P00EP5_A882DocAnticipos ;
      private DateTime[] P00EP5_A929DocFecRef ;
      private long[] P00EP5_A233DocItem ;
      private int[] P00EP6_A235MovVCod ;
      private string[] P00EP6_A1242MovVAbr ;
      private string[] P00EP8_A24DocNum ;
      private string[] P00EP8_A149TipCod ;
      private decimal[] P00EP8_A927DocSubExonerado ;
      private decimal[] P00EP8_A922DocSubSelectivo ;
      private decimal[] P00EP8_A921DocSubInafecto ;
      private decimal[] P00EP8_A920DocSubAfecto ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private ExcelDocumentI AV33ExcelDocument ;
      private GxFile AV9Archivo ;
   }

   public class rrresumenventasxclienteexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EP3( IGxContext context ,
                                             int AV83TieCod ,
                                             int AV85TipCCod ,
                                             string AV32EstCod ,
                                             string AV14CliCod ,
                                             string AV86TipCod ,
                                             string AV52PaiCod ,
                                             int AV26DocMonCod ,
                                             int AV20DocConpCod ,
                                             int AV104VenCod ,
                                             string AV88Tipo ,
                                             string AV75Serie ,
                                             int A178TieCod ,
                                             int A159TipCCod ,
                                             string A140EstCod ,
                                             string A231DocCliCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             int A230DocMonCod ,
                                             int A229DocConpCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             string A24DocNum ,
                                             DateTime A232DocFec ,
                                             DateTime AV37FDesde ,
                                             DateTime AV39FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[13];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocFec], T1.[DocNum], T1.[DocTipo], T1.[DocVendCod], T1.[DocConpCod], T1.[DocMonCod], T4.[PaiCod], T1.[TipCod], T1.[DocCliCod] AS DocCliCod, T4.[EstCod], T4.[TipCCod], T1.[TieCod], T1.[DocSts], T4.[CliDsc] AS DocCliDsc, T2.[TipSigno], T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], T1.[DocDcto], COALESCE( T3.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T3.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T3.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T3.[DocSubAfecto], 0) AS DocSubAfecto FROM ((([CLVENTAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[DocCliCod])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV37FDesde and T1.[DocFec] <= @AV39FHasta)");
         if ( ! (0==AV83TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV83TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV85TipCCod) )
         {
            AddWhere(sWhereString, "(T4.[TipCCod] = @AV85TipCCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32EstCod)) )
         {
            AddWhere(sWhereString, "(T4.[EstCod] = @AV32EstCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV86TipCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52PaiCod)) )
         {
            AddWhere(sWhereString, "(T4.[PaiCod] = @AV52PaiCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV26DocMonCod) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV26DocMonCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV20DocConpCod) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV20DocConpCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV104VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV104VenCod)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV88Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = @AV88Tipo)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV75Serie)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EP4( IGxContext context ,
                                             int AV83TieCod ,
                                             int AV47Lincod ,
                                             string AV68ProdCod ,
                                             int AV78SublCod ,
                                             int AV104VenCod ,
                                             string AV88Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             string A28ProdCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV37FDesde ,
                                             DateTime AV39FHasta ,
                                             string A941DocSts ,
                                             string A231DocCliCod ,
                                             string AV18DocCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[8];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[TipCod], T1.[DocNum], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T2.[DocSts], T2.[DocTipo], T2.[DocVendCod], T3.[SublCod], T3.[LinCod], T2.[TieCod], T2.[DocCliCod] AS DocCliCod, T2.[DocFec], T1.[DocDpre], T4.[UniAbr], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod])";
         AddWhere(sWhereString, "(T2.[DocFec] >= @AV37FDesde)");
         AddWhere(sWhereString, "(T2.[DocFec] <= @AV39FHasta)");
         AddWhere(sWhereString, "(T2.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[DocCliCod] = @AV18DocCliCod)");
         if ( ! (0==AV83TieCod) )
         {
            AddWhere(sWhereString, "(T2.[TieCod] = @AV83TieCod)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV47Lincod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV47Lincod)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV68ProdCod)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV78SublCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV78SublCod)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV104VenCod) )
         {
            AddWhere(sWhereString, "(T2.[DocVendCod] = @AV104VenCod)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV88Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T2.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00EP5( IGxContext context ,
                                             int AV83TieCod ,
                                             int AV47Lincod ,
                                             int AV78SublCod ,
                                             int AV104VenCod ,
                                             string AV88Tipo ,
                                             int A178TieCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV37FDesde ,
                                             DateTime AV39FHasta ,
                                             string A941DocSts ,
                                             string A231DocCliCod ,
                                             string AV18DocCliCod ,
                                             string AV72Producto ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[8];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T4.[DocSts], T4.[DocTipo], T4.[DocVendCod], T2.[SublCod], T1.[ProdCod], T2.[LinCod], T4.[TieCod], T4.[DocCliCod] AS DocCliCod, T4.[DocFec], T1.[DocDpre], T1.[TipCod], T1.[DocNum], T4.[DocMonCod], T4.[DocMovCod], T4.[DocDcto], T1.[DocDTot], T3.[TipSigno], T1.[DocDCan], T4.[DocAnticipos], T4.[DocFecRef], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV72Producto)");
         AddWhere(sWhereString, "(T4.[DocFec] >= @AV37FDesde)");
         AddWhere(sWhereString, "(T4.[DocFec] <= @AV39FHasta)");
         AddWhere(sWhereString, "(T4.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[DocCliCod] = @AV18DocCliCod)");
         if ( ! (0==AV83TieCod) )
         {
            AddWhere(sWhereString, "(T4.[TieCod] = @AV83TieCod)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! (0==AV47Lincod) )
         {
            AddWhere(sWhereString, "(T2.[LinCod] = @AV47Lincod)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV78SublCod) )
         {
            AddWhere(sWhereString, "(T2.[SublCod] = @AV78SublCod)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV104VenCod) )
         {
            AddWhere(sWhereString, "(T4.[DocVendCod] = @AV104VenCod)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV88Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV88Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T4.[DocTipo] <> 'X')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EP3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] );
               case 1 :
                     return conditional_P00EP4(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 2 :
                     return conditional_P00EP5(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00EP6;
          prmP00EP6 = new Object[] {
          new ParDef("@AV27DocMovCod",GXType.Int32,6,0)
          };
          Object[] prmP00EP8;
          prmP00EP8 = new Object[] {
          new ParDef("@AV86TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV28DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EP3;
          prmP00EP3 = new Object[] {
          new ParDef("@AV37FDesde",GXType.Date,8,0) ,
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV83TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV85TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV32EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV86TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV52PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV26DocMonCod",GXType.Int32,6,0) ,
          new ParDef("@AV20DocConpCod",GXType.Int32,6,0) ,
          new ParDef("@AV104VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV88Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV75Serie",GXType.Char,4,0)
          };
          Object[] prmP00EP4;
          prmP00EP4 = new Object[] {
          new ParDef("@AV37FDesde",GXType.Date,8,0) ,
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV18DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV83TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV47Lincod",GXType.Int32,6,0) ,
          new ParDef("@AV68ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV78SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV104VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00EP5;
          prmP00EP5 = new Object[] {
          new ParDef("@AV72Producto",GXType.NChar,100,0) ,
          new ParDef("@AV37FDesde",GXType.Date,8,0) ,
          new ParDef("@AV39FHasta",GXType.Date,8,0) ,
          new ParDef("@AV18DocCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV83TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV47Lincod",GXType.Int32,6,0) ,
          new ParDef("@AV78SublCod",GXType.Int32,6,0) ,
          new ParDef("@AV104VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EP3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EP4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EP5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EP6", "SELECT [MovVCod], [MovVAbr] FROM [CMOVVENTAS] WHERE [MovVCod] = @AV27DocMovCod ORDER BY [MovVCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EP8", "SELECT T1.[DocNum], T1.[TipCod], COALESCE( T2.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T2.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T2.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T2.[DocSubAfecto], 0) AS DocSubAfecto FROM ([CLVENTAS] T1 LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @AV86TipCod and T1.[DocNum] = @AV28DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EP8,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 4);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 1);
                ((string[]) buf[17])[0] = rslt.getString(14, 100);
                ((short[]) buf[18])[0] = rslt.getShort(15);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(24);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 1);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((int[]) buf[11])[0] = rslt.getInt(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 5);
                ((long[]) buf[17])[0] = rslt.getLong(16);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((string[]) buf[12])[0] = rslt.getString(11, 3);
                ((string[]) buf[13])[0] = rslt.getString(12, 12);
                ((int[]) buf[14])[0] = rslt.getInt(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(16);
                ((short[]) buf[18])[0] = rslt.getShort(17);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((DateTime[]) buf[21])[0] = rslt.getGXDate(20);
                ((long[]) buf[22])[0] = rslt.getLong(21);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
