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
namespace GeneXus.Programs.ventas {
   public class r_resumencobranzaexcel : GXProcedure
   {
      public r_resumencobranzaexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumencobranzaexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_FDesde ,
                           ref DateTime aP1_FHasta ,
                           ref string aP2_CliCod ,
                           ref int aP3_ForCod ,
                           ref int aP4_MonCod ,
                           ref string aP5_TipCod ,
                           ref string aP6_Serie ,
                           ref int aP7_VenCod ,
                           out string aP8_Filename ,
                           out string aP9_ErrorMessage )
      {
         this.AV40FDesde = aP0_FDesde;
         this.AV41FHasta = aP1_FHasta;
         this.AV14CliCod = aP2_CliCod;
         this.AV45ForCod = aP3_ForCod;
         this.AV48MonCod = aP4_MonCod;
         this.AV52TipCod = aP5_TipCod;
         this.AV50Serie = aP6_Serie;
         this.AV56VenCod = aP7_VenCod;
         this.AV42Filename = "" ;
         this.AV38ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_FDesde=this.AV40FDesde;
         aP1_FHasta=this.AV41FHasta;
         aP2_CliCod=this.AV14CliCod;
         aP3_ForCod=this.AV45ForCod;
         aP4_MonCod=this.AV48MonCod;
         aP5_TipCod=this.AV52TipCod;
         aP6_Serie=this.AV50Serie;
         aP7_VenCod=this.AV56VenCod;
         aP8_Filename=this.AV42Filename;
         aP9_ErrorMessage=this.AV38ErrorMessage;
      }

      public string executeUdp( ref DateTime aP0_FDesde ,
                                ref DateTime aP1_FHasta ,
                                ref string aP2_CliCod ,
                                ref int aP3_ForCod ,
                                ref int aP4_MonCod ,
                                ref string aP5_TipCod ,
                                ref string aP6_Serie ,
                                ref int aP7_VenCod ,
                                out string aP8_Filename )
      {
         execute(ref aP0_FDesde, ref aP1_FHasta, ref aP2_CliCod, ref aP3_ForCod, ref aP4_MonCod, ref aP5_TipCod, ref aP6_Serie, ref aP7_VenCod, out aP8_Filename, out aP9_ErrorMessage);
         return AV38ErrorMessage ;
      }

      public void executeSubmit( ref DateTime aP0_FDesde ,
                                 ref DateTime aP1_FHasta ,
                                 ref string aP2_CliCod ,
                                 ref int aP3_ForCod ,
                                 ref int aP4_MonCod ,
                                 ref string aP5_TipCod ,
                                 ref string aP6_Serie ,
                                 ref int aP7_VenCod ,
                                 out string aP8_Filename ,
                                 out string aP9_ErrorMessage )
      {
         r_resumencobranzaexcel objr_resumencobranzaexcel;
         objr_resumencobranzaexcel = new r_resumencobranzaexcel();
         objr_resumencobranzaexcel.AV40FDesde = aP0_FDesde;
         objr_resumencobranzaexcel.AV41FHasta = aP1_FHasta;
         objr_resumencobranzaexcel.AV14CliCod = aP2_CliCod;
         objr_resumencobranzaexcel.AV45ForCod = aP3_ForCod;
         objr_resumencobranzaexcel.AV48MonCod = aP4_MonCod;
         objr_resumencobranzaexcel.AV52TipCod = aP5_TipCod;
         objr_resumencobranzaexcel.AV50Serie = aP6_Serie;
         objr_resumencobranzaexcel.AV56VenCod = aP7_VenCod;
         objr_resumencobranzaexcel.AV42Filename = "" ;
         objr_resumencobranzaexcel.AV38ErrorMessage = "" ;
         objr_resumencobranzaexcel.context.SetSubmitInitialConfig(context);
         objr_resumencobranzaexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumencobranzaexcel);
         aP0_FDesde=this.AV40FDesde;
         aP1_FHasta=this.AV41FHasta;
         aP2_CliCod=this.AV14CliCod;
         aP3_ForCod=this.AV45ForCod;
         aP4_MonCod=this.AV48MonCod;
         aP5_TipCod=this.AV52TipCod;
         aP6_Serie=this.AV50Serie;
         aP7_VenCod=this.AV56VenCod;
         aP8_Filename=this.AV42Filename;
         aP9_ErrorMessage=this.AV38ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumencobranzaexcel)stateInfo).executePrivate();
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
         AV9Archivo.Source = "Excel/PlantillasResumenCobranza.xlsx";
         AV49Path = AV9Archivo.GetPath();
         AV43FilenameOrigen = StringUtil.Trim( AV49Path) + "\\PlantillasResumenCobranza.xlsx";
         AV42Filename = "Excel/ResumenCobranza" + ".xlsx";
         AV39ExcelDocument.Clear();
         AV39ExcelDocument.Template = AV43FilenameOrigen;
         AV39ExcelDocument.Open(AV42Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 5;
         AV44FirstColumn = 1;
         AV55TotMN = 0.00m;
         AV54TotME = 0.00m;
         AV47LenSerie = (short)(StringUtil.Len( AV50Serie));
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV52TipCod ,
                                              AV14CliCod ,
                                              AV45ForCod ,
                                              AV48MonCod ,
                                              AV56VenCod ,
                                              AV50Serie ,
                                              A166CobTip ,
                                              A645CobCliCod ,
                                              A143ForCod ,
                                              A172CobMon ,
                                              A175CobTipCod ,
                                              A171CobVendCod ,
                                              A176CobDocNum ,
                                              AV47LenSerie ,
                                              A661CobSts ,
                                              AV40FDesde ,
                                              A655CobFec ,
                                              AV41FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P007O2 */
         pr_default.execute(0, new Object[] {AV40FDesde, AV41FHasta, AV14CliCod, AV45ForCod, AV48MonCod, AV52TipCod, AV56VenCod, AV47LenSerie, AV50Serie});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A139PaiCod = P007O2_A139PaiCod[0];
            n139PaiCod = P007O2_n139PaiCod[0];
            A140EstCod = P007O2_A140EstCod[0];
            n140EstCod = P007O2_n140EstCod[0];
            A141ProvCod = P007O2_A141ProvCod[0];
            n141ProvCod = P007O2_n141ProvCod[0];
            A142DisCod = P007O2_A142DisCod[0];
            n142DisCod = P007O2_n142DisCod[0];
            A661CobSts = P007O2_A661CobSts[0];
            A176CobDocNum = P007O2_A176CobDocNum[0];
            A171CobVendCod = P007O2_A171CobVendCod[0];
            A175CobTipCod = P007O2_A175CobTipCod[0];
            A172CobMon = P007O2_A172CobMon[0];
            A143ForCod = P007O2_A143ForCod[0];
            A645CobCliCod = P007O2_A645CobCliCod[0];
            A655CobFec = P007O2_A655CobFec[0];
            A166CobTip = P007O2_A166CobTip[0];
            A663CobTipCam = P007O2_A663CobTipCam[0];
            A306TipAbr = P007O2_A306TipAbr[0];
            n306TipAbr = P007O2_n306TipAbr[0];
            A649CobDRecibo = P007O2_A649CobDRecibo[0];
            A646CobCliDsc = P007O2_A646CobCliDsc[0];
            A988ForDsc = P007O2_A988ForDsc[0];
            A659CobRef = P007O2_A659CobRef[0];
            A657CobMonDsc = P007O2_A657CobMonDsc[0];
            A167CobCod = P007O2_A167CobCod[0];
            A654CobDTot = P007O2_A654CobDTot[0];
            A667CobVendDsc = P007O2_A667CobVendDsc[0];
            A158ZonCod = P007O2_A158ZonCod[0];
            n158ZonCod = P007O2_n158ZonCod[0];
            A604DisDsc = P007O2_A604DisDsc[0];
            A596CliDir = P007O2_A596CliDir[0];
            n596CliDir = P007O2_n596CliDir[0];
            A643CobAfecta = P007O2_A643CobAfecta[0];
            A169CobBanCod = P007O2_A169CobBanCod[0];
            n169CobBanCod = P007O2_n169CobBanCod[0];
            A170CobCbCod = P007O2_A170CobCbCod[0];
            n170CobCbCod = P007O2_n170CobCbCod[0];
            A660CobRegistro = P007O2_A660CobRegistro[0];
            n660CobRegistro = P007O2_n660CobRegistro[0];
            A168CobConBCod = P007O2_A168CobConBCod[0];
            n168CobConBCod = P007O2_n168CobConBCod[0];
            A173Item = P007O2_A173Item[0];
            A645CobCliCod = P007O2_A645CobCliCod[0];
            A646CobCliDsc = P007O2_A646CobCliDsc[0];
            A139PaiCod = P007O2_A139PaiCod[0];
            n139PaiCod = P007O2_n139PaiCod[0];
            A140EstCod = P007O2_A140EstCod[0];
            n140EstCod = P007O2_n140EstCod[0];
            A141ProvCod = P007O2_A141ProvCod[0];
            n141ProvCod = P007O2_n141ProvCod[0];
            A142DisCod = P007O2_A142DisCod[0];
            n142DisCod = P007O2_n142DisCod[0];
            A158ZonCod = P007O2_A158ZonCod[0];
            n158ZonCod = P007O2_n158ZonCod[0];
            A596CliDir = P007O2_A596CliDir[0];
            n596CliDir = P007O2_n596CliDir[0];
            A604DisDsc = P007O2_A604DisDsc[0];
            A306TipAbr = P007O2_A306TipAbr[0];
            n306TipAbr = P007O2_n306TipAbr[0];
            A988ForDsc = P007O2_A988ForDsc[0];
            A661CobSts = P007O2_A661CobSts[0];
            A171CobVendCod = P007O2_A171CobVendCod[0];
            A172CobMon = P007O2_A172CobMon[0];
            A655CobFec = P007O2_A655CobFec[0];
            A643CobAfecta = P007O2_A643CobAfecta[0];
            A169CobBanCod = P007O2_A169CobBanCod[0];
            n169CobBanCod = P007O2_n169CobBanCod[0];
            A170CobCbCod = P007O2_A170CobCbCod[0];
            n170CobCbCod = P007O2_n170CobCbCod[0];
            A660CobRegistro = P007O2_A660CobRegistro[0];
            n660CobRegistro = P007O2_n660CobRegistro[0];
            A168CobConBCod = P007O2_A168CobConBCod[0];
            n168CobConBCod = P007O2_n168CobConBCod[0];
            A667CobVendDsc = P007O2_A667CobVendDsc[0];
            A657CobMonDsc = P007O2_A657CobMonDsc[0];
            AV53TipVenta = A663CobTipCam;
            if ( ( AV53TipVenta == Convert.ToDecimal( 0 )) || ( AV53TipVenta == Convert.ToDecimal( 1 )) )
            {
               GXt_decimal1 = AV53TipVenta;
               GXt_int2 = 2;
               GXt_char3 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  A655CobFec, ref  GXt_char3, out  GXt_decimal1) ;
               AV53TipVenta = GXt_decimal1;
            }
            AV52TipCod = A175CobTipCod;
            AV51TipAbr = StringUtil.Trim( A306TipAbr);
            AV23CobDocNum = A176CobDocNum;
            AV8CobDRecibo = A649CobDRecibo;
            AV19CobCliCod = A645CobCliCod;
            AV20CobCliDsc = A646CobCliDsc;
            AV46ForDsc = A988ForDsc;
            AV33CobRef = A659CobRef;
            AV30CobMon = A172CobMon;
            AV31CobMonDsc = A657CobMonDsc;
            AV21CobCod = A167CobCod;
            AV27CobFec = A655CobFec;
            AV24CobDTot = A654CobDTot;
            AV32Cobrador = StringUtil.Trim( A667CobVendDsc);
            AV57Vendedor = "";
            AV59ZonCod = A158ZonCod;
            AV37DisDsc = StringUtil.Trim( A604DisDsc);
            AV15CliDir = StringUtil.Trim( A596CliDir);
            AV29CobMN = ((A172CobMon==1) ? AV24CobDTot : (decimal)(0));
            AV28CobME = ((A172CobMon==1) ? (decimal)(0) : AV24CobDTot);
            AV26CobExpMN = ((AV30CobMon==1) ? AV24CobDTot : NumberUtil.Round( AV24CobDTot*AV53TipVenta, 2));
            AV25CobExpME = ((AV30CobMon==2) ? AV24CobDTot : NumberUtil.Round( AV24CobDTot/ (decimal)(AV53TipVenta), 2));
            AV16CobAfecta = A643CobAfecta;
            AV17CobBanCod = A169CobBanCod;
            AV18CobCbCod = A170CobCbCod;
            AV34CobRegistro = A660CobRegistro;
            AV22CobConBCod = A168CobConBCod;
            AV55TotMN = (decimal)(AV55TotMN+AV29CobMN);
            AV54TotME = (decimal)(AV54TotME+AV28CobME);
            /* Execute user subroutine: 'BANCO' */
            S141 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'ZONA' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV39ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV39ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV39ExcelDocument.ErrCode != 0 )
         {
            AV42Filename = "";
            AV38ErrorMessage = AV39ExcelDocument.ErrDescription;
            AV39ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P007O3 */
         pr_default.execute(1, new Object[] {AV52TipCod, AV23CobDocNum});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A186CCVendCod = P007O3_A186CCVendCod[0];
            A185CCDocNum = P007O3_A185CCDocNum[0];
            A184CCTipCod = P007O3_A184CCTipCod[0];
            A190CCFech = P007O3_A190CCFech[0];
            A508CCFVcto = P007O3_A508CCFVcto[0];
            A2045VenDsc = P007O3_A2045VenDsc[0];
            n2045VenDsc = P007O3_n2045VenDsc[0];
            A2045VenDsc = P007O3_A2045VenDsc[0];
            n2045VenDsc = P007O3_n2045VenDsc[0];
            AV11CCFech = A190CCFech;
            AV12CCFVcto = A508CCFVcto;
            AV57Vendedor = StringUtil.Trim( A2045VenDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV51TipAbr);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV23CobDocNum);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV11CCFech ) ;
         AV39ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+2), 1, 1).Date = GXt_dtime4;
         GXt_dtime4 = DateTimeUtil.ResetTime( AV12CCFVcto ) ;
         AV39ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+3), 1, 1).Date = GXt_dtime4;
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV19CobCliCod);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV20CobCliDsc);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV46ForDsc);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV33CobRef);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+8), 1, 1).Text = StringUtil.Trim( AV8CobDRecibo);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+9), 1, 1).Number = (double)(AV53TipVenta);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+10), 1, 1).Text = StringUtil.Trim( AV31CobMonDsc);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+11), 1, 1).Number = (double)(AV29CobMN);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+12), 1, 1).Number = (double)(AV28CobME);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+13), 1, 1).Text = StringUtil.Trim( AV21CobCod);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV27CobFec ) ;
         AV39ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+14), 1, 1).Date = GXt_dtime4;
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+15), 1, 1).Text = ((AV16CobAfecta==1) ? "SI" : "NO");
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+16), 1, 1).Text = StringUtil.Trim( AV10Banco);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+17), 1, 1).Text = StringUtil.Trim( AV18CobCbCod);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+18), 1, 1).Text = StringUtil.Trim( AV35Concepto);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+19), 1, 1).Text = StringUtil.Trim( AV36Cuenta);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+20), 1, 1).Text = StringUtil.Trim( AV34CobRegistro);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+21), 1, 1).Text = StringUtil.Trim( AV32Cobrador);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+22), 1, 1).Text = StringUtil.Trim( AV57Vendedor);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+23), 1, 1).Number = (double)(AV26CobExpMN);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+24), 1, 1).Number = (double)(AV25CobExpME);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+25), 1, 1).Text = StringUtil.Trim( AV15CliDir);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+26), 1, 1).Text = StringUtil.Trim( AV37DisDsc);
         AV39ExcelDocument.get_Cells((int)(AV13CellRow), (int)(AV44FirstColumn+27), 1, 1).Text = StringUtil.Trim( AV58Zona);
         AV13CellRow = (long)(AV13CellRow+1);
      }

      protected void S131( )
      {
         /* 'ZONA' Routine */
         returnInSub = false;
         AV58Zona = "";
         /* Using cursor P007O4 */
         pr_default.execute(2, new Object[] {AV59ZonCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A158ZonCod = P007O4_A158ZonCod[0];
            n158ZonCod = P007O4_n158ZonCod[0];
            A2094ZonDsc = P007O4_A2094ZonDsc[0];
            AV58Zona = StringUtil.Trim( A2094ZonDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S141( )
      {
         /* 'BANCO' Routine */
         returnInSub = false;
         AV10Banco = "";
         AV35Concepto = "";
         AV36Cuenta = "";
         /* Using cursor P007O5 */
         pr_default.execute(3, new Object[] {AV17CobBanCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A372BanCod = P007O5_A372BanCod[0];
            A481BanAbr = P007O5_A481BanAbr[0];
            AV10Banco = StringUtil.Trim( A481BanAbr);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(3);
         /* Using cursor P007O6 */
         pr_default.execute(4, new Object[] {AV22CobConBCod});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A355ConBCod = P007O6_A355ConBCod[0];
            A745ConBDsc = P007O6_A745ConBDsc[0];
            A374ConBCueCod = P007O6_A374ConBCueCod[0];
            AV35Concepto = StringUtil.Trim( A745ConBDsc);
            AV36Cuenta = StringUtil.Trim( A374ConBCueCod);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
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
         AV38ErrorMessage = "";
         AV9Archivo = new GxFile(context.GetPhysicalPath());
         AV49Path = "";
         AV43FilenameOrigen = "";
         AV39ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A166CobTip = "";
         A645CobCliCod = "";
         A175CobTipCod = "";
         A176CobDocNum = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         P007O2_A139PaiCod = new string[] {""} ;
         P007O2_n139PaiCod = new bool[] {false} ;
         P007O2_A140EstCod = new string[] {""} ;
         P007O2_n140EstCod = new bool[] {false} ;
         P007O2_A141ProvCod = new string[] {""} ;
         P007O2_n141ProvCod = new bool[] {false} ;
         P007O2_A142DisCod = new string[] {""} ;
         P007O2_n142DisCod = new bool[] {false} ;
         P007O2_A661CobSts = new string[] {""} ;
         P007O2_A176CobDocNum = new string[] {""} ;
         P007O2_A171CobVendCod = new int[1] ;
         P007O2_A175CobTipCod = new string[] {""} ;
         P007O2_A172CobMon = new int[1] ;
         P007O2_A143ForCod = new int[1] ;
         P007O2_A645CobCliCod = new string[] {""} ;
         P007O2_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P007O2_A166CobTip = new string[] {""} ;
         P007O2_A663CobTipCam = new decimal[1] ;
         P007O2_A306TipAbr = new string[] {""} ;
         P007O2_n306TipAbr = new bool[] {false} ;
         P007O2_A649CobDRecibo = new string[] {""} ;
         P007O2_A646CobCliDsc = new string[] {""} ;
         P007O2_A988ForDsc = new string[] {""} ;
         P007O2_A659CobRef = new string[] {""} ;
         P007O2_A657CobMonDsc = new string[] {""} ;
         P007O2_A167CobCod = new string[] {""} ;
         P007O2_A654CobDTot = new decimal[1] ;
         P007O2_A667CobVendDsc = new string[] {""} ;
         P007O2_A158ZonCod = new int[1] ;
         P007O2_n158ZonCod = new bool[] {false} ;
         P007O2_A604DisDsc = new string[] {""} ;
         P007O2_A596CliDir = new string[] {""} ;
         P007O2_n596CliDir = new bool[] {false} ;
         P007O2_A643CobAfecta = new short[1] ;
         P007O2_A169CobBanCod = new int[1] ;
         P007O2_n169CobBanCod = new bool[] {false} ;
         P007O2_A170CobCbCod = new string[] {""} ;
         P007O2_n170CobCbCod = new bool[] {false} ;
         P007O2_A660CobRegistro = new string[] {""} ;
         P007O2_n660CobRegistro = new bool[] {false} ;
         P007O2_A168CobConBCod = new int[1] ;
         P007O2_n168CobConBCod = new bool[] {false} ;
         P007O2_A173Item = new int[1] ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         A306TipAbr = "";
         A649CobDRecibo = "";
         A646CobCliDsc = "";
         A988ForDsc = "";
         A659CobRef = "";
         A657CobMonDsc = "";
         A167CobCod = "";
         A667CobVendDsc = "";
         A604DisDsc = "";
         A596CliDir = "";
         A170CobCbCod = "";
         A660CobRegistro = "";
         GXt_char3 = "";
         AV51TipAbr = "";
         AV23CobDocNum = "";
         AV8CobDRecibo = "";
         AV19CobCliCod = "";
         AV20CobCliDsc = "";
         AV46ForDsc = "";
         AV33CobRef = "";
         AV31CobMonDsc = "";
         AV21CobCod = "";
         AV27CobFec = DateTime.MinValue;
         AV32Cobrador = "";
         AV57Vendedor = "";
         AV37DisDsc = "";
         AV15CliDir = "";
         AV18CobCbCod = "";
         AV34CobRegistro = "";
         P007O3_A186CCVendCod = new int[1] ;
         P007O3_A185CCDocNum = new string[] {""} ;
         P007O3_A184CCTipCod = new string[] {""} ;
         P007O3_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P007O3_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P007O3_A2045VenDsc = new string[] {""} ;
         P007O3_n2045VenDsc = new bool[] {false} ;
         A185CCDocNum = "";
         A184CCTipCod = "";
         A190CCFech = DateTime.MinValue;
         A508CCFVcto = DateTime.MinValue;
         A2045VenDsc = "";
         AV11CCFech = DateTime.MinValue;
         AV12CCFVcto = DateTime.MinValue;
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV10Banco = "";
         AV35Concepto = "";
         AV36Cuenta = "";
         AV58Zona = "";
         P007O4_A158ZonCod = new int[1] ;
         P007O4_n158ZonCod = new bool[] {false} ;
         P007O4_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         P007O5_A372BanCod = new int[1] ;
         P007O5_A481BanAbr = new string[] {""} ;
         A481BanAbr = "";
         P007O6_A355ConBCod = new int[1] ;
         P007O6_A745ConBDsc = new string[] {""} ;
         P007O6_A374ConBCueCod = new string[] {""} ;
         A745ConBDsc = "";
         A374ConBCueCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_resumencobranzaexcel__default(),
            new Object[][] {
                new Object[] {
               P007O2_A139PaiCod, P007O2_n139PaiCod, P007O2_A140EstCod, P007O2_n140EstCod, P007O2_A141ProvCod, P007O2_n141ProvCod, P007O2_A142DisCod, P007O2_n142DisCod, P007O2_A661CobSts, P007O2_A176CobDocNum,
               P007O2_A171CobVendCod, P007O2_A175CobTipCod, P007O2_A172CobMon, P007O2_A143ForCod, P007O2_A645CobCliCod, P007O2_A655CobFec, P007O2_A166CobTip, P007O2_A663CobTipCam, P007O2_A306TipAbr, P007O2_n306TipAbr,
               P007O2_A649CobDRecibo, P007O2_A646CobCliDsc, P007O2_A988ForDsc, P007O2_A659CobRef, P007O2_A657CobMonDsc, P007O2_A167CobCod, P007O2_A654CobDTot, P007O2_A667CobVendDsc, P007O2_A158ZonCod, P007O2_n158ZonCod,
               P007O2_A604DisDsc, P007O2_A596CliDir, P007O2_n596CliDir, P007O2_A643CobAfecta, P007O2_A169CobBanCod, P007O2_n169CobBanCod, P007O2_A170CobCbCod, P007O2_n170CobCbCod, P007O2_A660CobRegistro, P007O2_n660CobRegistro,
               P007O2_A168CobConBCod, P007O2_n168CobConBCod, P007O2_A173Item
               }
               , new Object[] {
               P007O3_A186CCVendCod, P007O3_A185CCDocNum, P007O3_A184CCTipCod, P007O3_A190CCFech, P007O3_A508CCFVcto, P007O3_A2045VenDsc, P007O3_n2045VenDsc
               }
               , new Object[] {
               P007O4_A158ZonCod, P007O4_A2094ZonDsc
               }
               , new Object[] {
               P007O5_A372BanCod, P007O5_A481BanAbr
               }
               , new Object[] {
               P007O6_A355ConBCod, P007O6_A745ConBDsc, P007O6_A374ConBCueCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV47LenSerie ;
      private short A643CobAfecta ;
      private short AV16CobAfecta ;
      private int AV45ForCod ;
      private int AV48MonCod ;
      private int AV56VenCod ;
      private int A143ForCod ;
      private int A172CobMon ;
      private int A171CobVendCod ;
      private int A158ZonCod ;
      private int A169CobBanCod ;
      private int A168CobConBCod ;
      private int A173Item ;
      private int GXt_int2 ;
      private int AV30CobMon ;
      private int AV59ZonCod ;
      private int AV17CobBanCod ;
      private int AV22CobConBCod ;
      private int A186CCVendCod ;
      private int A372BanCod ;
      private int A355ConBCod ;
      private long AV13CellRow ;
      private long AV44FirstColumn ;
      private decimal AV55TotMN ;
      private decimal AV54TotME ;
      private decimal A663CobTipCam ;
      private decimal A654CobDTot ;
      private decimal AV53TipVenta ;
      private decimal GXt_decimal1 ;
      private decimal AV24CobDTot ;
      private decimal AV29CobMN ;
      private decimal AV28CobME ;
      private decimal AV26CobExpMN ;
      private decimal AV25CobExpME ;
      private string AV14CliCod ;
      private string AV52TipCod ;
      private string scmdbuf ;
      private string A166CobTip ;
      private string A645CobCliCod ;
      private string A175CobTipCod ;
      private string A176CobDocNum ;
      private string A661CobSts ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string A306TipAbr ;
      private string A649CobDRecibo ;
      private string A646CobCliDsc ;
      private string A988ForDsc ;
      private string A659CobRef ;
      private string A657CobMonDsc ;
      private string A167CobCod ;
      private string A667CobVendDsc ;
      private string A604DisDsc ;
      private string A596CliDir ;
      private string A170CobCbCod ;
      private string A660CobRegistro ;
      private string GXt_char3 ;
      private string AV51TipAbr ;
      private string AV23CobDocNum ;
      private string AV8CobDRecibo ;
      private string AV19CobCliCod ;
      private string AV20CobCliDsc ;
      private string AV46ForDsc ;
      private string AV33CobRef ;
      private string AV31CobMonDsc ;
      private string AV21CobCod ;
      private string AV32Cobrador ;
      private string AV57Vendedor ;
      private string AV37DisDsc ;
      private string AV15CliDir ;
      private string AV18CobCbCod ;
      private string AV34CobRegistro ;
      private string A185CCDocNum ;
      private string A184CCTipCod ;
      private string A2045VenDsc ;
      private string A2094ZonDsc ;
      private string A481BanAbr ;
      private string A745ConBDsc ;
      private string A374ConBCueCod ;
      private DateTime GXt_dtime4 ;
      private DateTime AV40FDesde ;
      private DateTime AV41FHasta ;
      private DateTime A655CobFec ;
      private DateTime AV27CobFec ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV11CCFech ;
      private DateTime AV12CCFVcto ;
      private bool returnInSub ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n141ProvCod ;
      private bool n142DisCod ;
      private bool n306TipAbr ;
      private bool n158ZonCod ;
      private bool n596CliDir ;
      private bool n169CobBanCod ;
      private bool n170CobCbCod ;
      private bool n660CobRegistro ;
      private bool n168CobConBCod ;
      private bool n2045VenDsc ;
      private string AV50Serie ;
      private string AV42Filename ;
      private string AV38ErrorMessage ;
      private string AV49Path ;
      private string AV43FilenameOrigen ;
      private string AV10Banco ;
      private string AV35Concepto ;
      private string AV36Cuenta ;
      private string AV58Zona ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_FDesde ;
      private DateTime aP1_FHasta ;
      private string aP2_CliCod ;
      private int aP3_ForCod ;
      private int aP4_MonCod ;
      private string aP5_TipCod ;
      private string aP6_Serie ;
      private int aP7_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P007O2_A139PaiCod ;
      private bool[] P007O2_n139PaiCod ;
      private string[] P007O2_A140EstCod ;
      private bool[] P007O2_n140EstCod ;
      private string[] P007O2_A141ProvCod ;
      private bool[] P007O2_n141ProvCod ;
      private string[] P007O2_A142DisCod ;
      private bool[] P007O2_n142DisCod ;
      private string[] P007O2_A661CobSts ;
      private string[] P007O2_A176CobDocNum ;
      private int[] P007O2_A171CobVendCod ;
      private string[] P007O2_A175CobTipCod ;
      private int[] P007O2_A172CobMon ;
      private int[] P007O2_A143ForCod ;
      private string[] P007O2_A645CobCliCod ;
      private DateTime[] P007O2_A655CobFec ;
      private string[] P007O2_A166CobTip ;
      private decimal[] P007O2_A663CobTipCam ;
      private string[] P007O2_A306TipAbr ;
      private bool[] P007O2_n306TipAbr ;
      private string[] P007O2_A649CobDRecibo ;
      private string[] P007O2_A646CobCliDsc ;
      private string[] P007O2_A988ForDsc ;
      private string[] P007O2_A659CobRef ;
      private string[] P007O2_A657CobMonDsc ;
      private string[] P007O2_A167CobCod ;
      private decimal[] P007O2_A654CobDTot ;
      private string[] P007O2_A667CobVendDsc ;
      private int[] P007O2_A158ZonCod ;
      private bool[] P007O2_n158ZonCod ;
      private string[] P007O2_A604DisDsc ;
      private string[] P007O2_A596CliDir ;
      private bool[] P007O2_n596CliDir ;
      private short[] P007O2_A643CobAfecta ;
      private int[] P007O2_A169CobBanCod ;
      private bool[] P007O2_n169CobBanCod ;
      private string[] P007O2_A170CobCbCod ;
      private bool[] P007O2_n170CobCbCod ;
      private string[] P007O2_A660CobRegistro ;
      private bool[] P007O2_n660CobRegistro ;
      private int[] P007O2_A168CobConBCod ;
      private bool[] P007O2_n168CobConBCod ;
      private int[] P007O2_A173Item ;
      private int[] P007O3_A186CCVendCod ;
      private string[] P007O3_A185CCDocNum ;
      private string[] P007O3_A184CCTipCod ;
      private DateTime[] P007O3_A190CCFech ;
      private DateTime[] P007O3_A508CCFVcto ;
      private string[] P007O3_A2045VenDsc ;
      private bool[] P007O3_n2045VenDsc ;
      private int[] P007O4_A158ZonCod ;
      private bool[] P007O4_n158ZonCod ;
      private string[] P007O4_A2094ZonDsc ;
      private int[] P007O5_A372BanCod ;
      private string[] P007O5_A481BanAbr ;
      private int[] P007O6_A355ConBCod ;
      private string[] P007O6_A745ConBDsc ;
      private string[] P007O6_A374ConBCueCod ;
      private string aP8_Filename ;
      private string aP9_ErrorMessage ;
      private ExcelDocumentI AV39ExcelDocument ;
      private GxFile AV9Archivo ;
   }

   public class r_resumencobranzaexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007O2( IGxContext context ,
                                             string AV52TipCod ,
                                             string AV14CliCod ,
                                             int AV45ForCod ,
                                             int AV48MonCod ,
                                             int AV56VenCod ,
                                             string AV50Serie ,
                                             string A166CobTip ,
                                             string A645CobCliCod ,
                                             int A143ForCod ,
                                             int A172CobMon ,
                                             string A175CobTipCod ,
                                             int A171CobVendCod ,
                                             string A176CobDocNum ,
                                             short AV47LenSerie ,
                                             string A661CobSts ,
                                             DateTime AV40FDesde ,
                                             DateTime A655CobFec ,
                                             DateTime AV41FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T3.[PaiCod], T3.[EstCod], T3.[ProvCod], T3.[DisCod], T7.[CobSts], T1.[CobDocNum] AS CobDocNum, T7.[CobVendCod] AS CobVendCod, T1.[CobTipCod] AS CobTipCod, T7.[CobMon] AS CobMon, T1.[ForCod], T2.[CCCliCod] AS CobCliCod, T7.[CobFec], T1.[CobTip], T1.[CobTipCam], T5.[TipAbr], T1.[CobDRecibo], T2.[CCCliDsc] AS CobCliDsc, T6.[ForDsc], T1.[CobRef], T9.[MonDsc] AS CobMonDsc, T1.[CobCod], T1.[CobDTot], T8.[VenDsc] AS CobVendDsc, T3.[ZonCod], T4.[DisDsc], T3.[CliDir], T7.[CobAfecta], T7.[CobBanCod], T7.[CobCbCod], T7.[CobRegistro], T7.[CobConBCod], T1.[Item] FROM (((((((([CLCOBRANZADET] T1 INNER JOIN [CLCUENTACOBRAR] T2 ON T2.[CCTipCod] = T1.[CobTipCod] AND T2.[CCDocNum] = T1.[CobDocNum]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T2.[CCCliCod]) LEFT JOIN [CDISTRITOS] T4 ON T4.[PaiCod] = T3.[PaiCod] AND T4.[EstCod] = T3.[EstCod] AND T4.[ProvCod] = T3.[ProvCod] AND T4.[DisCod] = T3.[DisCod]) INNER JOIN [CTIPDOC] T5 ON T5.[TipCod] = T1.[CobTipCod]) INNER JOIN [CFORMAPAGO] T6 ON T6.[ForCod] = T1.[ForCod]) INNER JOIN [CLCOBRANZA] T7 ON T7.[CobTip] = T1.[CobTip] AND T7.[CobCod] = T1.[CobCod]) INNER JOIN [CVENDEDORES] T8 ON T8.[VenCod] = T7.[CobVendCod]) INNER JOIN [CMONEDAS] T9 ON T9.[MonCod] = T7.[CobMon])";
         AddWhere(sWhereString, "(T7.[CobFec] >= @AV40FDesde)");
         AddWhere(sWhereString, "((T7.[CobSts] = ''))");
         AddWhere(sWhereString, "(T7.[CobFec] <= @AV41FHasta)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTip] = 'C')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[CCCliCod] = @AV14CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV45ForCod) )
         {
            AddWhere(sWhereString, "(T1.[ForCod] = @AV45ForCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV48MonCod) )
         {
            AddWhere(sWhereString, "(T7.[CobMon] = @AV48MonCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CobTipCod] = @AV52TipCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV56VenCod) )
         {
            AddWhere(sWhereString, "(T7.[CobVendCod] = @AV56VenCod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CobDocNum], 1, @AV47LenSerie) = @AV50Serie)");
         }
         else
         {
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T7.[CobFec], T1.[CobTipCod], T1.[CobDocNum]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007O2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] );
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
          Object[] prmP007O3;
          prmP007O3 = new Object[] {
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV23CobDocNum",GXType.NChar,12,0)
          };
          Object[] prmP007O4;
          prmP007O4 = new Object[] {
          new ParDef("@AV59ZonCod",GXType.Int32,6,0)
          };
          Object[] prmP007O5;
          prmP007O5 = new Object[] {
          new ParDef("@AV17CobBanCod",GXType.Int32,6,0)
          };
          Object[] prmP007O6;
          prmP007O6 = new Object[] {
          new ParDef("@AV22CobConBCod",GXType.Int32,6,0)
          };
          Object[] prmP007O2;
          prmP007O2 = new Object[] {
          new ParDef("@AV40FDesde",GXType.Date,8,0) ,
          new ParDef("@AV41FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV45ForCod",GXType.Int32,6,0) ,
          new ParDef("@AV48MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV52TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV56VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV47LenSerie",GXType.Int16,4,0) ,
          new ParDef("@AV50Serie",GXType.VarChar,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007O3", "SELECT T1.[CCVendCod] AS CCVendCod, T1.[CCDocNum], T1.[CCTipCod], T1.[CCFech], T1.[CCFVcto], T2.[VenDsc] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod]) WHERE T1.[CCTipCod] = @AV52TipCod and T1.[CCDocNum] = @AV23CobDocNum ORDER BY T1.[CCTipCod], T1.[CCDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007O4", "SELECT [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV59ZonCod ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007O5", "SELECT [BanCod], [BanAbr] FROM [TSBANCOS] WHERE [BanCod] = @AV17CobBanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007O6", "SELECT [ConBCod], [ConBDsc], [ConBCueCod] FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AV22CobConBCod ORDER BY [ConBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007O6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 1);
                ((string[]) buf[9])[0] = rslt.getString(6, 12);
                ((int[]) buf[10])[0] = rslt.getInt(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 3);
                ((int[]) buf[12])[0] = rslt.getInt(9);
                ((int[]) buf[13])[0] = rslt.getInt(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 1);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(14);
                ((string[]) buf[18])[0] = rslt.getString(15, 5);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 20);
                ((string[]) buf[21])[0] = rslt.getString(17, 100);
                ((string[]) buf[22])[0] = rslt.getString(18, 100);
                ((string[]) buf[23])[0] = rslt.getString(19, 20);
                ((string[]) buf[24])[0] = rslt.getString(20, 100);
                ((string[]) buf[25])[0] = rslt.getString(21, 12);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
                ((string[]) buf[27])[0] = rslt.getString(23, 100);
                ((int[]) buf[28])[0] = rslt.getInt(24);
                ((bool[]) buf[29])[0] = rslt.wasNull(24);
                ((string[]) buf[30])[0] = rslt.getString(25, 100);
                ((string[]) buf[31])[0] = rslt.getString(26, 100);
                ((bool[]) buf[32])[0] = rslt.wasNull(26);
                ((short[]) buf[33])[0] = rslt.getShort(27);
                ((int[]) buf[34])[0] = rslt.getInt(28);
                ((bool[]) buf[35])[0] = rslt.wasNull(28);
                ((string[]) buf[36])[0] = rslt.getString(29, 20);
                ((bool[]) buf[37])[0] = rslt.wasNull(29);
                ((string[]) buf[38])[0] = rslt.getString(30, 10);
                ((bool[]) buf[39])[0] = rslt.wasNull(30);
                ((int[]) buf[40])[0] = rslt.getInt(31);
                ((bool[]) buf[41])[0] = rslt.wasNull(31);
                ((int[]) buf[42])[0] = rslt.getInt(32);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                return;
       }
    }

 }

}
