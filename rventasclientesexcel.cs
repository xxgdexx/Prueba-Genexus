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
   public class rventasclientesexcel : GXProcedure
   {
      public rventasclientesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rventasclientesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref string aP2_TipCod ,
                           ref string aP3_PaiCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_Tipo ,
                           ref int aP7_VenCod ,
                           ref int aP8_ZonCod ,
                           ref int aP9_TieCod ,
                           ref short aP10_CheckRec ,
                           out string aP11_Filename ,
                           out string aP12_ErrorMessage )
      {
         this.AV61TipCCod = aP0_TipCCod;
         this.AV13CliCod = aP1_CliCod;
         this.AV62TipCod = aP2_TipCod;
         this.AV35PaiCod = aP3_PaiCod;
         this.AV20FDesde = aP4_FDesde;
         this.AV22FHasta = aP5_FHasta;
         this.AV64Tipo = aP6_Tipo;
         this.AV74VenCod = aP7_VenCod;
         this.AV77ZonCod = aP8_ZonCod;
         this.AV79TieCod = aP9_TieCod;
         this.AV80CheckRec = aP10_CheckRec;
         this.AV23Filename = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV61TipCCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_TipCod=this.AV62TipCod;
         aP3_PaiCod=this.AV35PaiCod;
         aP4_FDesde=this.AV20FDesde;
         aP5_FHasta=this.AV22FHasta;
         aP6_Tipo=this.AV64Tipo;
         aP7_VenCod=this.AV74VenCod;
         aP8_ZonCod=this.AV77ZonCod;
         aP9_TieCod=this.AV79TieCod;
         aP10_CheckRec=this.AV80CheckRec;
         aP11_Filename=this.AV23Filename;
         aP12_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( ref int aP0_TipCCod ,
                                ref string aP1_CliCod ,
                                ref string aP2_TipCod ,
                                ref string aP3_PaiCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta ,
                                ref string aP6_Tipo ,
                                ref int aP7_VenCod ,
                                ref int aP8_ZonCod ,
                                ref int aP9_TieCod ,
                                ref short aP10_CheckRec ,
                                out string aP11_Filename )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_TipCod, ref aP3_PaiCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_Tipo, ref aP7_VenCod, ref aP8_ZonCod, ref aP9_TieCod, ref aP10_CheckRec, out aP11_Filename, out aP12_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref string aP2_TipCod ,
                                 ref string aP3_PaiCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_Tipo ,
                                 ref int aP7_VenCod ,
                                 ref int aP8_ZonCod ,
                                 ref int aP9_TieCod ,
                                 ref short aP10_CheckRec ,
                                 out string aP11_Filename ,
                                 out string aP12_ErrorMessage )
      {
         rventasclientesexcel objrventasclientesexcel;
         objrventasclientesexcel = new rventasclientesexcel();
         objrventasclientesexcel.AV61TipCCod = aP0_TipCCod;
         objrventasclientesexcel.AV13CliCod = aP1_CliCod;
         objrventasclientesexcel.AV62TipCod = aP2_TipCod;
         objrventasclientesexcel.AV35PaiCod = aP3_PaiCod;
         objrventasclientesexcel.AV20FDesde = aP4_FDesde;
         objrventasclientesexcel.AV22FHasta = aP5_FHasta;
         objrventasclientesexcel.AV64Tipo = aP6_Tipo;
         objrventasclientesexcel.AV74VenCod = aP7_VenCod;
         objrventasclientesexcel.AV77ZonCod = aP8_ZonCod;
         objrventasclientesexcel.AV79TieCod = aP9_TieCod;
         objrventasclientesexcel.AV80CheckRec = aP10_CheckRec;
         objrventasclientesexcel.AV23Filename = "" ;
         objrventasclientesexcel.AV17ErrorMessage = "" ;
         objrventasclientesexcel.context.SetSubmitInitialConfig(context);
         objrventasclientesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrventasclientesexcel);
         aP0_TipCCod=this.AV61TipCCod;
         aP1_CliCod=this.AV13CliCod;
         aP2_TipCod=this.AV62TipCod;
         aP3_PaiCod=this.AV35PaiCod;
         aP4_FDesde=this.AV20FDesde;
         aP5_FHasta=this.AV22FHasta;
         aP6_Tipo=this.AV64Tipo;
         aP7_VenCod=this.AV74VenCod;
         aP8_ZonCod=this.AV77ZonCod;
         aP9_TieCod=this.AV79TieCod;
         aP10_CheckRec=this.AV80CheckRec;
         aP11_Filename=this.AV23Filename;
         aP12_ErrorMessage=this.AV17ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rventasclientesexcel)stateInfo).executePrivate();
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
         AV10Archivo.Source = "Excel/PlantillasRVentasClientes.xlsx";
         AV36Path = AV10Archivo.GetPath();
         AV24FilenameOrigen = StringUtil.Trim( AV36Path) + "\\PlantillasRVentasClientes.xlsx";
         AV23Filename = "Excel/VentasClientes" + ".xlsx";
         AV18ExcelDocument.Clear();
         AV18ExcelDocument.Template = AV24FilenameOrigen;
         AV18ExcelDocument.Open(AV23Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 6;
         AV28FirstColumn = 1;
         AV29Item = 0;
         AV25Filtro1 = "Del : " + context.localUtil.DToC( AV20FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV22FHasta, 2, "/");
         AV18ExcelDocument.get_Cells(3, (int)(AV28FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV25Filtro1);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV79TieCod ,
                                              AV61TipCCod ,
                                              AV8EstCod ,
                                              AV13CliCod ,
                                              AV62TipCod ,
                                              AV35PaiCod ,
                                              AV77ZonCod ,
                                              AV74VenCod ,
                                              AV80CheckRec ,
                                              AV64Tipo ,
                                              A178TieCod ,
                                              A159TipCCod ,
                                              A140EstCod ,
                                              A231DocCliCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A158ZonCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A232DocFec ,
                                              AV20FDesde ,
                                              AV22FHasta ,
                                              A941DocSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00EF3 */
         pr_default.execute(0, new Object[] {AV20FDesde, AV22FHasta, AV79TieCod, AV61TipCCod, AV8EstCod, AV13CliCod, AV62TipCod, AV35PaiCod, AV77ZonCod, AV74VenCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEF2 = false;
            A24DocNum = P00EF3_A24DocNum[0];
            A941DocSts = P00EF3_A941DocSts[0];
            A231DocCliCod = P00EF3_A231DocCliCod[0];
            A149TipCod = P00EF3_A149TipCod[0];
            A232DocFec = P00EF3_A232DocFec[0];
            A230DocMonCod = P00EF3_A230DocMonCod[0];
            A511TipSigno = P00EF3_A511TipSigno[0];
            A929DocFecRef = P00EF3_A929DocFecRef[0];
            A946DocTipo = P00EF3_A946DocTipo[0];
            A227DocVendCod = P00EF3_A227DocVendCod[0];
            A158ZonCod = P00EF3_A158ZonCod[0];
            n158ZonCod = P00EF3_n158ZonCod[0];
            A139PaiCod = P00EF3_A139PaiCod[0];
            n139PaiCod = P00EF3_n139PaiCod[0];
            A140EstCod = P00EF3_A140EstCod[0];
            n140EstCod = P00EF3_n140EstCod[0];
            A159TipCCod = P00EF3_A159TipCCod[0];
            n159TipCCod = P00EF3_n159TipCCod[0];
            A178TieCod = P00EF3_A178TieCod[0];
            n178TieCod = P00EF3_n178TieCod[0];
            A887DocCliDsc = P00EF3_A887DocCliDsc[0];
            A927DocSubExonerado = P00EF3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EF3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EF3_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EF3_A920DocSubAfecto[0];
            A899DocDcto = P00EF3_A899DocDcto[0];
            A158ZonCod = P00EF3_A158ZonCod[0];
            n158ZonCod = P00EF3_n158ZonCod[0];
            A139PaiCod = P00EF3_A139PaiCod[0];
            n139PaiCod = P00EF3_n139PaiCod[0];
            A140EstCod = P00EF3_A140EstCod[0];
            n140EstCod = P00EF3_n140EstCod[0];
            A159TipCCod = P00EF3_A159TipCCod[0];
            n159TipCCod = P00EF3_n159TipCCod[0];
            A887DocCliDsc = P00EF3_A887DocCliDsc[0];
            A511TipSigno = P00EF3_A511TipSigno[0];
            A927DocSubExonerado = P00EF3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P00EF3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P00EF3_A921DocSubInafecto[0];
            A920DocSubAfecto = P00EF3_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            AV15DocCliCod = A231DocCliCod;
            AV16DocCliDsc = A887DocCliDsc;
            AV71TotalVenta = 0.00m;
            AV72TotalVentaME = 0.00m;
            AV70TotalMN = 0.00m;
            AV69TotalME = 0.00m;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EF3_A231DocCliCod[0], A231DocCliCod) == 0 ) )
            {
               BRKEF2 = false;
               A24DocNum = P00EF3_A24DocNum[0];
               A941DocSts = P00EF3_A941DocSts[0];
               A149TipCod = P00EF3_A149TipCod[0];
               A232DocFec = P00EF3_A232DocFec[0];
               A230DocMonCod = P00EF3_A230DocMonCod[0];
               A511TipSigno = P00EF3_A511TipSigno[0];
               A929DocFecRef = P00EF3_A929DocFecRef[0];
               A899DocDcto = P00EF3_A899DocDcto[0];
               A511TipSigno = P00EF3_A511TipSigno[0];
               if ( StringUtil.StrCmp(A231DocCliCod, AV15DocCliCod) == 0 )
               {
                  if ( StringUtil.StrCmp(A941DocSts, "A") != 0 )
                  {
                     /* Using cursor P00EF5 */
                     pr_default.execute(1, new Object[] {A149TipCod, A24DocNum});
                     if ( (pr_default.getStatus(1) != 101) )
                     {
                        A927DocSubExonerado = P00EF5_A927DocSubExonerado[0];
                        A922DocSubSelectivo = P00EF5_A922DocSubSelectivo[0];
                        A921DocSubInafecto = P00EF5_A921DocSubInafecto[0];
                        A920DocSubAfecto = P00EF5_A920DocSubAfecto[0];
                     }
                     else
                     {
                        A920DocSubAfecto = 0;
                        A921DocSubInafecto = 0;
                        A922DocSubSelectivo = 0;
                        A927DocSubExonerado = 0;
                     }
                     pr_default.close(1);
                     A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                     A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                     AV63TipCod2 = A149TipCod;
                     AV21Fecha = A232DocFec;
                     AV32MonCod = A230DocMonCod;
                     AV9Total = NumberUtil.Round( (A919DocSub-A918DocDscto)*A511TipSigno, 2);
                     if ( ( StringUtil.StrCmp(AV63TipCod2, "NC") == 0 ) || ( StringUtil.StrCmp(AV63TipCod2, "ND") == 0 ) )
                     {
                        AV21Fecha = A929DocFecRef;
                     }
                     GXt_decimal1 = AV11Cambio;
                     GXt_int2 = 2;
                     GXt_char3 = "V";
                     new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int2, ref  AV21Fecha, ref  GXt_char3, out  GXt_decimal1) ;
                     AV11Cambio = GXt_decimal1;
                     AV70TotalMN = ((AV32MonCod==1) ? AV9Total : NumberUtil.Round( AV9Total*AV11Cambio, 2));
                     AV69TotalME = ((AV32MonCod==1) ? NumberUtil.Round( AV9Total/ (decimal)(AV11Cambio), 2) : AV9Total);
                     AV71TotalVenta = (decimal)(AV71TotalVenta+AV70TotalMN);
                     AV72TotalVentaME = (decimal)(AV72TotalVentaME+AV69TotalME);
                  }
               }
               BRKEF2 = true;
               pr_default.readNext(0);
            }
            AV56SDTVentaClientesITem.gxTpr_Clicod = AV15DocCliCod;
            AV56SDTVentaClientesITem.gxTpr_Clidsc = AV16DocCliDsc;
            AV56SDTVentaClientesITem.gxTpr_Importe = AV71TotalVenta;
            AV56SDTVentaClientesITem.gxTpr_Importe1 = AV72TotalVentaME;
            AV55SDTVentaClientes.Add(AV56SDTVentaClientesITem, 0);
            AV56SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
            if ( ! BRKEF2 )
            {
               BRKEF2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV55SDTVentaClientes.Sort("[Importe]");
         AV71TotalVenta = 0.00m;
         AV72TotalVentaME = 0.00m;
         AV85GXV1 = 1;
         while ( AV85GXV1 <= AV55SDTVentaClientes.Count )
         {
            AV56SDTVentaClientesITem = ((SdtSdtVentasClientes_SdtVentasClientesItem)AV55SDTVentaClientes.Item(AV85GXV1));
            AV15DocCliCod = AV56SDTVentaClientesITem.gxTpr_Clicod;
            AV16DocCliDsc = AV56SDTVentaClientesITem.gxTpr_Clidsc;
            AV71TotalVenta = AV56SDTVentaClientesITem.gxTpr_Importe;
            AV72TotalVentaME = AV56SDTVentaClientesITem.gxTpr_Importe1;
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV85GXV1 = (int)(AV85GXV1+1);
         }
         AV18ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV18ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV28FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV15DocCliCod);
         AV18ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV28FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV16DocCliDsc);
         AV18ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV28FirstColumn+2), 1, 1).Number = (double)(AV71TotalVenta);
         AV18ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV28FirstColumn+3), 1, 1).Number = (double)(AV72TotalVentaME);
         AV12CellRow = (long)(AV12CellRow+1);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV18ExcelDocument.ErrCode != 0 )
         {
            AV23Filename = "";
            AV17ErrorMessage = AV18ExcelDocument.ErrDescription;
            AV18ExcelDocument.Close();
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV23Filename = "";
         AV17ErrorMessage = "";
         AV10Archivo = new GxFile(context.GetPhysicalPath());
         AV36Path = "";
         AV24FilenameOrigen = "";
         AV18ExcelDocument = new ExcelDocumentI();
         AV25Filtro1 = "";
         scmdbuf = "";
         AV8EstCod = "";
         A140EstCod = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A139PaiCod = "";
         A946DocTipo = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00EF3_A24DocNum = new string[] {""} ;
         P00EF3_A941DocSts = new string[] {""} ;
         P00EF3_A231DocCliCod = new string[] {""} ;
         P00EF3_A149TipCod = new string[] {""} ;
         P00EF3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00EF3_A230DocMonCod = new int[1] ;
         P00EF3_A511TipSigno = new short[1] ;
         P00EF3_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00EF3_A946DocTipo = new string[] {""} ;
         P00EF3_A227DocVendCod = new int[1] ;
         P00EF3_A158ZonCod = new int[1] ;
         P00EF3_n158ZonCod = new bool[] {false} ;
         P00EF3_A139PaiCod = new string[] {""} ;
         P00EF3_n139PaiCod = new bool[] {false} ;
         P00EF3_A140EstCod = new string[] {""} ;
         P00EF3_n140EstCod = new bool[] {false} ;
         P00EF3_A159TipCCod = new int[1] ;
         P00EF3_n159TipCCod = new bool[] {false} ;
         P00EF3_A178TieCod = new int[1] ;
         P00EF3_n178TieCod = new bool[] {false} ;
         P00EF3_A887DocCliDsc = new string[] {""} ;
         P00EF3_A927DocSubExonerado = new decimal[1] ;
         P00EF3_A922DocSubSelectivo = new decimal[1] ;
         P00EF3_A921DocSubInafecto = new decimal[1] ;
         P00EF3_A920DocSubAfecto = new decimal[1] ;
         P00EF3_A899DocDcto = new decimal[1] ;
         A24DocNum = "";
         A929DocFecRef = DateTime.MinValue;
         A887DocCliDsc = "";
         AV15DocCliCod = "";
         AV16DocCliDsc = "";
         P00EF5_A927DocSubExonerado = new decimal[1] ;
         P00EF5_A922DocSubSelectivo = new decimal[1] ;
         P00EF5_A921DocSubInafecto = new decimal[1] ;
         P00EF5_A920DocSubAfecto = new decimal[1] ;
         AV63TipCod2 = "";
         AV21Fecha = DateTime.MinValue;
         GXt_char3 = "";
         AV56SDTVentaClientesITem = new SdtSdtVentasClientes_SdtVentasClientesItem(context);
         AV55SDTVentaClientes = new GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem>( context, "SdtVentasClientesItem", "SIGERP_ADVANCED");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rventasclientesexcel__default(),
            new Object[][] {
                new Object[] {
               P00EF3_A24DocNum, P00EF3_A941DocSts, P00EF3_A231DocCliCod, P00EF3_A149TipCod, P00EF3_A232DocFec, P00EF3_A230DocMonCod, P00EF3_A511TipSigno, P00EF3_A929DocFecRef, P00EF3_A946DocTipo, P00EF3_A227DocVendCod,
               P00EF3_A158ZonCod, P00EF3_n158ZonCod, P00EF3_A139PaiCod, P00EF3_n139PaiCod, P00EF3_A140EstCod, P00EF3_n140EstCod, P00EF3_A159TipCCod, P00EF3_n159TipCCod, P00EF3_A178TieCod, P00EF3_n178TieCod,
               P00EF3_A887DocCliDsc, P00EF3_A927DocSubExonerado, P00EF3_A922DocSubSelectivo, P00EF3_A921DocSubInafecto, P00EF3_A920DocSubAfecto, P00EF3_A899DocDcto
               }
               , new Object[] {
               P00EF5_A927DocSubExonerado, P00EF5_A922DocSubSelectivo, P00EF5_A921DocSubInafecto, P00EF5_A920DocSubAfecto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV80CheckRec ;
      private short A511TipSigno ;
      private int AV61TipCCod ;
      private int AV74VenCod ;
      private int AV77ZonCod ;
      private int AV79TieCod ;
      private int AV29Item ;
      private int A178TieCod ;
      private int A159TipCCod ;
      private int A158ZonCod ;
      private int A227DocVendCod ;
      private int A230DocMonCod ;
      private int AV32MonCod ;
      private int GXt_int2 ;
      private int AV85GXV1 ;
      private long AV12CellRow ;
      private long AV28FirstColumn ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal AV71TotalVenta ;
      private decimal AV72TotalVentaME ;
      private decimal AV70TotalMN ;
      private decimal AV69TotalME ;
      private decimal AV9Total ;
      private decimal AV11Cambio ;
      private decimal GXt_decimal1 ;
      private string AV13CliCod ;
      private string AV62TipCod ;
      private string AV35PaiCod ;
      private string AV64Tipo ;
      private string AV36Path ;
      private string scmdbuf ;
      private string AV8EstCod ;
      private string A140EstCod ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A139PaiCod ;
      private string A946DocTipo ;
      private string A941DocSts ;
      private string A24DocNum ;
      private string A887DocCliDsc ;
      private string AV15DocCliCod ;
      private string AV16DocCliDsc ;
      private string AV63TipCod2 ;
      private string GXt_char3 ;
      private DateTime AV20FDesde ;
      private DateTime AV22FHasta ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV21Fecha ;
      private bool returnInSub ;
      private bool BRKEF2 ;
      private bool n158ZonCod ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n159TipCCod ;
      private bool n178TieCod ;
      private string AV23Filename ;
      private string AV17ErrorMessage ;
      private string AV24FilenameOrigen ;
      private string AV25Filtro1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private string aP2_TipCod ;
      private string aP3_PaiCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_Tipo ;
      private int aP7_VenCod ;
      private int aP8_ZonCod ;
      private int aP9_TieCod ;
      private short aP10_CheckRec ;
      private IDataStoreProvider pr_default ;
      private string[] P00EF3_A24DocNum ;
      private string[] P00EF3_A941DocSts ;
      private string[] P00EF3_A231DocCliCod ;
      private string[] P00EF3_A149TipCod ;
      private DateTime[] P00EF3_A232DocFec ;
      private int[] P00EF3_A230DocMonCod ;
      private short[] P00EF3_A511TipSigno ;
      private DateTime[] P00EF3_A929DocFecRef ;
      private string[] P00EF3_A946DocTipo ;
      private int[] P00EF3_A227DocVendCod ;
      private int[] P00EF3_A158ZonCod ;
      private bool[] P00EF3_n158ZonCod ;
      private string[] P00EF3_A139PaiCod ;
      private bool[] P00EF3_n139PaiCod ;
      private string[] P00EF3_A140EstCod ;
      private bool[] P00EF3_n140EstCod ;
      private int[] P00EF3_A159TipCCod ;
      private bool[] P00EF3_n159TipCCod ;
      private int[] P00EF3_A178TieCod ;
      private bool[] P00EF3_n178TieCod ;
      private string[] P00EF3_A887DocCliDsc ;
      private decimal[] P00EF3_A927DocSubExonerado ;
      private decimal[] P00EF3_A922DocSubSelectivo ;
      private decimal[] P00EF3_A921DocSubInafecto ;
      private decimal[] P00EF3_A920DocSubAfecto ;
      private decimal[] P00EF3_A899DocDcto ;
      private decimal[] P00EF5_A927DocSubExonerado ;
      private decimal[] P00EF5_A922DocSubSelectivo ;
      private decimal[] P00EF5_A921DocSubInafecto ;
      private decimal[] P00EF5_A920DocSubAfecto ;
      private string aP11_Filename ;
      private string aP12_ErrorMessage ;
      private ExcelDocumentI AV18ExcelDocument ;
      private GXBaseCollection<SdtSdtVentasClientes_SdtVentasClientesItem> AV55SDTVentaClientes ;
      private GxFile AV10Archivo ;
      private SdtSdtVentasClientes_SdtVentasClientesItem AV56SDTVentaClientesITem ;
   }

   public class rventasclientesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EF3( IGxContext context ,
                                             int AV79TieCod ,
                                             int AV61TipCCod ,
                                             string AV8EstCod ,
                                             string AV13CliCod ,
                                             string AV62TipCod ,
                                             string AV35PaiCod ,
                                             int AV77ZonCod ,
                                             int AV74VenCod ,
                                             short AV80CheckRec ,
                                             string AV64Tipo ,
                                             int A178TieCod ,
                                             int A159TipCCod ,
                                             string A140EstCod ,
                                             string A231DocCliCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             int A158ZonCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             DateTime A232DocFec ,
                                             DateTime AV20FDesde ,
                                             DateTime AV22FHasta ,
                                             string A941DocSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DocNum], T1.[DocSts], T1.[DocCliCod] AS DocCliCod, T1.[TipCod], T1.[DocFec], T1.[DocMonCod], T3.[TipSigno], T1.[DocFecRef], T1.[DocTipo], T1.[DocVendCod], T2.[ZonCod], T2.[PaiCod], T2.[EstCod], T2.[TipCCod], T1.[TieCod], T2.[CliDsc] AS DocCliDsc, COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM ((([CLVENTAS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[DocCliCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV20FDesde and T1.[DocFec] <= @AV22FHasta)");
         AddWhere(sWhereString, "(T1.[DocSts] <> 'A')");
         if ( ! (0==AV79TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV79TieCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV61TipCCod) )
         {
            AddWhere(sWhereString, "(T2.[TipCCod] = @AV61TipCCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8EstCod)) )
         {
            AddWhere(sWhereString, "(T2.[EstCod] = @AV8EstCod)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV62TipCod)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35PaiCod)) )
         {
            AddWhere(sWhereString, "(T2.[PaiCod] = @AV35PaiCod)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV77ZonCod) )
         {
            AddWhere(sWhereString, "(T2.[ZonCod] = @AV77ZonCod)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV74VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV74VenCod)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV80CheckRec == 0 )
         {
            AddWhere(sWhereString, "(Not T1.[TipCod] = 'REC')");
         }
         if ( StringUtil.StrCmp(AV64Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = 'M')");
         }
         if ( StringUtil.StrCmp(AV64Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DocCliCod]";
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
                     return conditional_P00EF3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EF5;
          prmP00EF5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EF3;
          prmP00EF3 = new Object[] {
          new ParDef("@AV20FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV79TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV61TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV8EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV62TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV35PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV77ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV74VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EF3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EF3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EF5", "SELECT COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto FROM (SELECT SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EF5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 1);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((bool[]) buf[11])[0] = rslt.wasNull(11);
                ((string[]) buf[12])[0] = rslt.getString(12, 4);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 4);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                ((int[]) buf[16])[0] = rslt.getInt(14);
                ((bool[]) buf[17])[0] = rslt.wasNull(14);
                ((int[]) buf[18])[0] = rslt.getInt(15);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((string[]) buf[20])[0] = rslt.getString(16, 100);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(21);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
       }
    }

 }

}
