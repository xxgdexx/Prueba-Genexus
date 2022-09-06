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
   public class presumenletrasexcel : GXProcedure
   {
      public presumenletrasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public presumenletrasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref int aP1_BanCod ,
                           ref int aP2_LetPSec ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FDesde ,
                           ref DateTime aP5_FHasta ,
                           ref string aP6_CCEstado ,
                           ref string aP7_TipFecha ,
                           ref int aP8_VenCod ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV13CliCod = aP0_CliCod;
         this.AV10BanCod = aP1_BanCod;
         this.AV50LetPSec = aP2_LetPSec;
         this.AV53MonCod = aP3_MonCod;
         this.AV31FDesde = aP4_FDesde;
         this.AV32FHasta = aP5_FHasta;
         this.AV11CCEstado = aP6_CCEstado;
         this.AV60TipFecha = aP7_TipFecha;
         this.AV66VenCod = aP8_VenCod;
         this.AV33Filename = "" ;
         this.AV27ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV13CliCod;
         aP1_BanCod=this.AV10BanCod;
         aP2_LetPSec=this.AV50LetPSec;
         aP3_MonCod=this.AV53MonCod;
         aP4_FDesde=this.AV31FDesde;
         aP5_FHasta=this.AV32FHasta;
         aP6_CCEstado=this.AV11CCEstado;
         aP7_TipFecha=this.AV60TipFecha;
         aP8_VenCod=this.AV66VenCod;
         aP9_Filename=this.AV33Filename;
         aP10_ErrorMessage=this.AV27ErrorMessage;
      }

      public string executeUdp( ref string aP0_CliCod ,
                                ref int aP1_BanCod ,
                                ref int aP2_LetPSec ,
                                ref int aP3_MonCod ,
                                ref DateTime aP4_FDesde ,
                                ref DateTime aP5_FHasta ,
                                ref string aP6_CCEstado ,
                                ref string aP7_TipFecha ,
                                ref int aP8_VenCod ,
                                out string aP9_Filename )
      {
         execute(ref aP0_CliCod, ref aP1_BanCod, ref aP2_LetPSec, ref aP3_MonCod, ref aP4_FDesde, ref aP5_FHasta, ref aP6_CCEstado, ref aP7_TipFecha, ref aP8_VenCod, out aP9_Filename, out aP10_ErrorMessage);
         return AV27ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref int aP1_BanCod ,
                                 ref int aP2_LetPSec ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FDesde ,
                                 ref DateTime aP5_FHasta ,
                                 ref string aP6_CCEstado ,
                                 ref string aP7_TipFecha ,
                                 ref int aP8_VenCod ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         presumenletrasexcel objpresumenletrasexcel;
         objpresumenletrasexcel = new presumenletrasexcel();
         objpresumenletrasexcel.AV13CliCod = aP0_CliCod;
         objpresumenletrasexcel.AV10BanCod = aP1_BanCod;
         objpresumenletrasexcel.AV50LetPSec = aP2_LetPSec;
         objpresumenletrasexcel.AV53MonCod = aP3_MonCod;
         objpresumenletrasexcel.AV31FDesde = aP4_FDesde;
         objpresumenletrasexcel.AV32FHasta = aP5_FHasta;
         objpresumenletrasexcel.AV11CCEstado = aP6_CCEstado;
         objpresumenletrasexcel.AV60TipFecha = aP7_TipFecha;
         objpresumenletrasexcel.AV66VenCod = aP8_VenCod;
         objpresumenletrasexcel.AV33Filename = "" ;
         objpresumenletrasexcel.AV27ErrorMessage = "" ;
         objpresumenletrasexcel.context.SetSubmitInitialConfig(context);
         objpresumenletrasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpresumenletrasexcel);
         aP0_CliCod=this.AV13CliCod;
         aP1_BanCod=this.AV10BanCod;
         aP2_LetPSec=this.AV50LetPSec;
         aP3_MonCod=this.AV53MonCod;
         aP4_FDesde=this.AV31FDesde;
         aP5_FHasta=this.AV32FHasta;
         aP6_CCEstado=this.AV11CCEstado;
         aP7_TipFecha=this.AV60TipFecha;
         aP8_VenCod=this.AV66VenCod;
         aP9_Filename=this.AV33Filename;
         aP10_ErrorMessage=this.AV27ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((presumenletrasexcel)stateInfo).executePrivate();
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
         AV8Archivo.Source = "Excel/PlantillasResumenLetras.xlsx";
         AV54Path = AV8Archivo.GetPath();
         AV34FilenameOrigen = StringUtil.Trim( AV54Path) + "\\PlantillasResumenLetras.xlsx";
         AV33Filename = "Excel/ResumenLetras" + ".xlsx";
         AV30ExcelDocument.Clear();
         AV30ExcelDocument.Template = AV34FilenameOrigen;
         AV30ExcelDocument.Open(AV33Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 6;
         AV35FirstColumn = 1;
         AV62TotImporte = 0.00m;
         AV65TotSaldo = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV13CliCod ,
                                              AV10BanCod ,
                                              AV50LetPSec ,
                                              AV53MonCod ,
                                              AV60TipFecha ,
                                              AV66VenCod ,
                                              A206LetCCliCod ,
                                              A1104LetCBanCod ,
                                              A1116LetCSec ,
                                              A205LetCMonCod ,
                                              A1108LetCFecLet ,
                                              AV31FDesde ,
                                              AV32FHasta ,
                                              A1109LetCFecVcto ,
                                              A1123LetCVendCod ,
                                              A1120LetCTipo } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT
                                              }
         });
         /* Using cursor P00E72 */
         pr_default.execute(0, new Object[] {AV13CliCod, AV10BanCod, AV50LetPSec, AV53MonCod, AV31FDesde, AV32FHasta, AV31FDesde, AV32FHasta, AV66VenCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1120LetCTipo = P00E72_A1120LetCTipo[0];
            A1123LetCVendCod = P00E72_A1123LetCVendCod[0];
            A1109LetCFecVcto = P00E72_A1109LetCFecVcto[0];
            A1108LetCFecLet = P00E72_A1108LetCFecLet[0];
            A205LetCMonCod = P00E72_A205LetCMonCod[0];
            A1116LetCSec = P00E72_A1116LetCSec[0];
            A1104LetCBanCod = P00E72_A1104LetCBanCod[0];
            A206LetCCliCod = P00E72_A206LetCCliCod[0];
            A1114LetCLetFec = P00E72_A1114LetCLetFec[0];
            A161CliDsc = P00E72_A161CliDsc[0];
            n161CliDsc = P00E72_n161CliDsc[0];
            A204LetCLetCod = P00E72_A204LetCLetCod[0];
            A208LetCTipCod = P00E72_A208LetCTipCod[0];
            n208LetCTipCod = P00E72_n208LetCTipCod[0];
            A1105LetCBanNum = P00E72_A1105LetCBanNum[0];
            A1112LetCImpDet = P00E72_A1112LetCImpDet[0];
            A1107LetCDias = P00E72_A1107LetCDias[0];
            A1233MonAbr = P00E72_A1233MonAbr[0];
            n1233MonAbr = P00E72_n1233MonAbr[0];
            A209LetCDocNum = P00E72_A209LetCDocNum[0];
            n209LetCDocNum = P00E72_n209LetCDocNum[0];
            A207LetCItem = P00E72_A207LetCItem[0];
            A205LetCMonCod = P00E72_A205LetCMonCod[0];
            A206LetCCliCod = P00E72_A206LetCCliCod[0];
            A1114LetCLetFec = P00E72_A1114LetCLetFec[0];
            A1233MonAbr = P00E72_A1233MonAbr[0];
            n1233MonAbr = P00E72_n1233MonAbr[0];
            A161CliDsc = P00E72_A161CliDsc[0];
            n161CliDsc = P00E72_n161CliDsc[0];
            A1123LetCVendCod = P00E72_A1123LetCVendCod[0];
            AV48LetCLetFec = A1114LetCLetFec;
            AV14CliDsc = A161CliDsc;
            AV47LetCLetCod = A204LetCLetCod;
            AV49LetCTipCod = A208LetCTipCod;
            AV44LetCDocNum = A209LetCDocNum;
            AV41LetCBanCod = A1104LetCBanCod;
            AV42LetCBanNum = A1105LetCBanNum;
            AV46LetCImpDet = A1112LetCImpDet;
            AV43LetCDias = A1107LetCDias;
            AV45LetCFecVcto = A1109LetCFecVcto;
            AV52MonAbr = StringUtil.Trim( A1233MonAbr);
            AV56Seccion = "";
            AV67VenDsc = "";
            /* Execute user subroutine: 'BANCO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'SALDOCXC' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DOCUMENTOS' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( A1116LetCSec == 1 )
            {
               AV56Seccion = "Por Aceptar";
            }
            if ( A1116LetCSec == 8 )
            {
               AV56Seccion = "Cartera";
            }
            if ( A1116LetCSec == 2 )
            {
               AV56Seccion = "Descuento";
            }
            if ( A1116LetCSec == 3 )
            {
               AV56Seccion = "Cobranza";
            }
            if ( A1116LetCSec == 4 )
            {
               AV56Seccion = "Cobranza Libre";
            }
            if ( A1116LetCSec == 5 )
            {
               AV56Seccion = "Garantia";
            }
            if ( A1116LetCSec == 6 )
            {
               AV56Seccion = "Protestado";
            }
            if ( A1116LetCSec == 7 )
            {
               AV56Seccion = "Refinanciado";
            }
            if ( A1116LetCSec == 10 )
            {
               AV56Seccion = "Refinanciamiento Amort.";
            }
            if ( A1116LetCSec == 11 )
            {
               AV56Seccion = "Factura Negociable-Descuento";
            }
            if ( A1116LetCSec == 12 )
            {
               AV56Seccion = "Factura Negociable-Cobranza";
            }
            if ( A1116LetCSec == 9 )
            {
               AV56Seccion = "Aceptada";
            }
            if ( A1116LetCSec == 0 )
            {
               AV56Seccion = "(Ninguno)";
            }
            AV29EstadoLetra = ((StringUtil.StrCmp(AV28Estado, "T")==0) ? "TERMINADO" : ((StringUtil.StrCmp(AV28Estado, "A")==0) ? "ANULADO" : "PENDIENTE"));
            if ( StringUtil.StrCmp(AV11CCEstado, "O") == 0 )
            {
               AV62TotImporte = (decimal)(AV62TotImporte+A1112LetCImpDet);
               AV65TotSaldo = (decimal)(AV65TotSaldo+AV55Saldo);
               AV51Lineas = LVCharUtil.LinesWrap( AV25DocObs, 22);
               AV39I = 1;
               while ( AV39I <= AV51Lineas )
               {
                  AV24Comen = LVCharUtil.GetLineWrap( AV25DocObs, (int)(AV39I), 22);
                  AV39I = (long)(AV39I+1);
               }
               /* Execute user subroutine: 'DETALLES' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  this.cleanup();
                  if (true) return;
               }
            }
            else
            {
               if ( StringUtil.StrCmp(AV28Estado, AV11CCEstado) == 0 )
               {
                  AV62TotImporte = (decimal)(AV62TotImporte+A1112LetCImpDet);
                  AV65TotSaldo = (decimal)(AV65TotSaldo+AV55Saldo);
                  AV51Lineas = LVCharUtil.LinesWrap( AV25DocObs, 22);
                  AV39I = 1;
                  while ( AV39I <= AV51Lineas )
                  {
                     AV24Comen = LVCharUtil.GetLineWrap( AV25DocObs, (int)(AV39I), 22);
                     AV39I = (long)(AV39I+1);
                  }
                  /* Execute user subroutine: 'DETALLES' */
                  S151 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     this.cleanup();
                     if (true) return;
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV30ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV30ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'BANCO' Routine */
         returnInSub = false;
         AV9Banco = "";
         /* Using cursor P00E73 */
         pr_default.execute(1, new Object[] {AV41LetCBanCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A372BanCod = P00E73_A372BanCod[0];
            A482BanDsc = P00E73_A482BanDsc[0];
            AV9Banco = A482BanDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S121( )
      {
         /* 'SALDOCXC' Routine */
         returnInSub = false;
         AV55Saldo = 0.00m;
         AV28Estado = "";
         /* Using cursor P00E74 */
         pr_default.execute(2, new Object[] {AV49LetCTipCod, AV44LetCDocNum});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A186CCVendCod = P00E74_A186CCVendCod[0];
            A185CCDocNum = P00E74_A185CCDocNum[0];
            A184CCTipCod = P00E74_A184CCTipCod[0];
            A506CCEstado = P00E74_A506CCEstado[0];
            A2045VenDsc = P00E74_A2045VenDsc[0];
            n2045VenDsc = P00E74_n2045VenDsc[0];
            A509CCImpPago = P00E74_A509CCImpPago[0];
            A513CCImpTotal = P00E74_A513CCImpTotal[0];
            A2045VenDsc = P00E74_A2045VenDsc[0];
            n2045VenDsc = P00E74_n2045VenDsc[0];
            A512CCImpSaldo = (decimal)(A513CCImpTotal-A509CCImpPago);
            AV55Saldo = A512CCImpSaldo;
            AV28Estado = A506CCEstado;
            AV67VenDsc = A2045VenDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
      }

      protected void S131( )
      {
         /* 'DOCUMENTOS' Routine */
         returnInSub = false;
         AV36Flag = 0;
         AV25DocObs = "";
         /* Using cursor P00E75 */
         pr_default.execute(3, new Object[] {AV47LetCLetCod});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1120LetCTipo = P00E75_A1120LetCTipo[0];
            A204LetCLetCod = P00E75_A204LetCLetCod[0];
            A209LetCDocNum = P00E75_A209LetCDocNum[0];
            n209LetCDocNum = P00E75_n209LetCDocNum[0];
            A207LetCItem = P00E75_A207LetCItem[0];
            AV25DocObs += StringUtil.Trim( A209LetCDocNum) + "-";
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV40Len = (long)(StringUtil.Len( AV25DocObs)-1);
         AV25DocObs = StringUtil.Substring( AV25DocObs, 1, (int)(AV40Len));
         AV26Documento1 = StringUtil.Trim( AV25DocObs);
      }

      protected void S141( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV30ExcelDocument.ErrCode != 0 )
         {
            AV33Filename = "";
            AV27ErrorMessage = AV30ExcelDocument.ErrDescription;
            AV30ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S151( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV48LetCLetFec ) ;
         AV30ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+0), 1, 1).Date = GXt_dtime1;
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV14CliDsc);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV44LetCDocNum);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV9Banco);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV56Seccion);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV42LetCBanNum);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV52MonAbr);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+7), 1, 1).Number = (double)(AV46LetCImpDet);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+8), 1, 1).Number = AV43LetCDias;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV45LetCFecVcto ) ;
         AV30ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+9), 1, 1).Date = GXt_dtime1;
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+10), 1, 1).Number = (double)(AV46LetCImpDet);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+11), 1, 1).Number = (double)(AV55Saldo);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+12), 1, 1).Text = StringUtil.Trim( AV26Documento1);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+13), 1, 1).Text = StringUtil.Trim( AV67VenDsc);
         AV30ExcelDocument.get_Cells((int)(AV12CellRow), (int)(AV35FirstColumn+14), 1, 1).Text = StringUtil.Trim( AV29EstadoLetra);
         AV12CellRow = (long)(AV12CellRow+1);
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
         AV33Filename = "";
         AV27ErrorMessage = "";
         AV8Archivo = new GxFile(context.GetPhysicalPath());
         AV54Path = "";
         AV34FilenameOrigen = "";
         AV30ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A206LetCCliCod = "";
         A1108LetCFecLet = DateTime.MinValue;
         A1109LetCFecVcto = DateTime.MinValue;
         A1120LetCTipo = "";
         P00E72_A1120LetCTipo = new string[] {""} ;
         P00E72_A1123LetCVendCod = new int[1] ;
         P00E72_A1109LetCFecVcto = new DateTime[] {DateTime.MinValue} ;
         P00E72_A1108LetCFecLet = new DateTime[] {DateTime.MinValue} ;
         P00E72_A205LetCMonCod = new int[1] ;
         P00E72_A1116LetCSec = new int[1] ;
         P00E72_A1104LetCBanCod = new int[1] ;
         P00E72_A206LetCCliCod = new string[] {""} ;
         P00E72_A1114LetCLetFec = new DateTime[] {DateTime.MinValue} ;
         P00E72_A161CliDsc = new string[] {""} ;
         P00E72_n161CliDsc = new bool[] {false} ;
         P00E72_A204LetCLetCod = new string[] {""} ;
         P00E72_A208LetCTipCod = new string[] {""} ;
         P00E72_n208LetCTipCod = new bool[] {false} ;
         P00E72_A1105LetCBanNum = new string[] {""} ;
         P00E72_A1112LetCImpDet = new decimal[1] ;
         P00E72_A1107LetCDias = new short[1] ;
         P00E72_A1233MonAbr = new string[] {""} ;
         P00E72_n1233MonAbr = new bool[] {false} ;
         P00E72_A209LetCDocNum = new string[] {""} ;
         P00E72_n209LetCDocNum = new bool[] {false} ;
         P00E72_A207LetCItem = new int[1] ;
         A1114LetCLetFec = DateTime.MinValue;
         A161CliDsc = "";
         A204LetCLetCod = "";
         A208LetCTipCod = "";
         A1105LetCBanNum = "";
         A1233MonAbr = "";
         A209LetCDocNum = "";
         AV48LetCLetFec = DateTime.MinValue;
         AV14CliDsc = "";
         AV47LetCLetCod = "";
         AV49LetCTipCod = "";
         AV44LetCDocNum = "";
         AV42LetCBanNum = "";
         AV45LetCFecVcto = DateTime.MinValue;
         AV52MonAbr = "";
         AV56Seccion = "";
         AV67VenDsc = "";
         AV29EstadoLetra = "";
         AV28Estado = "";
         AV25DocObs = "";
         AV24Comen = "";
         AV9Banco = "";
         P00E73_A372BanCod = new int[1] ;
         P00E73_A482BanDsc = new string[] {""} ;
         A482BanDsc = "";
         P00E74_A186CCVendCod = new int[1] ;
         P00E74_A185CCDocNum = new string[] {""} ;
         P00E74_A184CCTipCod = new string[] {""} ;
         P00E74_A506CCEstado = new string[] {""} ;
         P00E74_A2045VenDsc = new string[] {""} ;
         P00E74_n2045VenDsc = new bool[] {false} ;
         P00E74_A509CCImpPago = new decimal[1] ;
         P00E74_A513CCImpTotal = new decimal[1] ;
         A185CCDocNum = "";
         A184CCTipCod = "";
         A506CCEstado = "";
         A2045VenDsc = "";
         P00E75_A1120LetCTipo = new string[] {""} ;
         P00E75_A204LetCLetCod = new string[] {""} ;
         P00E75_A209LetCDocNum = new string[] {""} ;
         P00E75_n209LetCDocNum = new bool[] {false} ;
         P00E75_A207LetCItem = new int[1] ;
         AV26Documento1 = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.presumenletrasexcel__default(),
            new Object[][] {
                new Object[] {
               P00E72_A1120LetCTipo, P00E72_A1123LetCVendCod, P00E72_A1109LetCFecVcto, P00E72_A1108LetCFecLet, P00E72_A205LetCMonCod, P00E72_A1116LetCSec, P00E72_A1104LetCBanCod, P00E72_A206LetCCliCod, P00E72_A1114LetCLetFec, P00E72_A161CliDsc,
               P00E72_n161CliDsc, P00E72_A204LetCLetCod, P00E72_A208LetCTipCod, P00E72_n208LetCTipCod, P00E72_A1105LetCBanNum, P00E72_A1112LetCImpDet, P00E72_A1107LetCDias, P00E72_A1233MonAbr, P00E72_n1233MonAbr, P00E72_A209LetCDocNum,
               P00E72_n209LetCDocNum, P00E72_A207LetCItem
               }
               , new Object[] {
               P00E73_A372BanCod, P00E73_A482BanDsc
               }
               , new Object[] {
               P00E74_A186CCVendCod, P00E74_A185CCDocNum, P00E74_A184CCTipCod, P00E74_A506CCEstado, P00E74_A2045VenDsc, P00E74_n2045VenDsc, P00E74_A509CCImpPago, P00E74_A513CCImpTotal
               }
               , new Object[] {
               P00E75_A1120LetCTipo, P00E75_A204LetCLetCod, P00E75_A209LetCDocNum, P00E75_n209LetCDocNum, P00E75_A207LetCItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1107LetCDias ;
      private short AV43LetCDias ;
      private short AV36Flag ;
      private int AV10BanCod ;
      private int AV50LetPSec ;
      private int AV53MonCod ;
      private int AV66VenCod ;
      private int A1104LetCBanCod ;
      private int A1116LetCSec ;
      private int A205LetCMonCod ;
      private int A1123LetCVendCod ;
      private int A207LetCItem ;
      private int AV41LetCBanCod ;
      private int A372BanCod ;
      private int A186CCVendCod ;
      private long AV12CellRow ;
      private long AV35FirstColumn ;
      private long AV51Lineas ;
      private long AV39I ;
      private long AV40Len ;
      private decimal AV62TotImporte ;
      private decimal AV65TotSaldo ;
      private decimal A1112LetCImpDet ;
      private decimal AV46LetCImpDet ;
      private decimal AV55Saldo ;
      private decimal A509CCImpPago ;
      private decimal A513CCImpTotal ;
      private decimal A512CCImpSaldo ;
      private string AV13CliCod ;
      private string AV11CCEstado ;
      private string AV60TipFecha ;
      private string scmdbuf ;
      private string A206LetCCliCod ;
      private string A1120LetCTipo ;
      private string A161CliDsc ;
      private string A204LetCLetCod ;
      private string A208LetCTipCod ;
      private string A1105LetCBanNum ;
      private string A1233MonAbr ;
      private string A209LetCDocNum ;
      private string AV14CliDsc ;
      private string AV47LetCLetCod ;
      private string AV49LetCTipCod ;
      private string AV44LetCDocNum ;
      private string AV42LetCBanNum ;
      private string AV52MonAbr ;
      private string AV56Seccion ;
      private string AV67VenDsc ;
      private string AV29EstadoLetra ;
      private string AV28Estado ;
      private string AV24Comen ;
      private string AV9Banco ;
      private string A482BanDsc ;
      private string A185CCDocNum ;
      private string A184CCTipCod ;
      private string A506CCEstado ;
      private string A2045VenDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV31FDesde ;
      private DateTime AV32FHasta ;
      private DateTime A1108LetCFecLet ;
      private DateTime A1109LetCFecVcto ;
      private DateTime A1114LetCLetFec ;
      private DateTime AV48LetCLetFec ;
      private DateTime AV45LetCFecVcto ;
      private bool returnInSub ;
      private bool n161CliDsc ;
      private bool n208LetCTipCod ;
      private bool n1233MonAbr ;
      private bool n209LetCDocNum ;
      private bool n2045VenDsc ;
      private string AV25DocObs ;
      private string AV26Documento1 ;
      private string AV33Filename ;
      private string AV27ErrorMessage ;
      private string AV54Path ;
      private string AV34FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private int aP1_BanCod ;
      private int aP2_LetPSec ;
      private int aP3_MonCod ;
      private DateTime aP4_FDesde ;
      private DateTime aP5_FHasta ;
      private string aP6_CCEstado ;
      private string aP7_TipFecha ;
      private int aP8_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00E72_A1120LetCTipo ;
      private int[] P00E72_A1123LetCVendCod ;
      private DateTime[] P00E72_A1109LetCFecVcto ;
      private DateTime[] P00E72_A1108LetCFecLet ;
      private int[] P00E72_A205LetCMonCod ;
      private int[] P00E72_A1116LetCSec ;
      private int[] P00E72_A1104LetCBanCod ;
      private string[] P00E72_A206LetCCliCod ;
      private DateTime[] P00E72_A1114LetCLetFec ;
      private string[] P00E72_A161CliDsc ;
      private bool[] P00E72_n161CliDsc ;
      private string[] P00E72_A204LetCLetCod ;
      private string[] P00E72_A208LetCTipCod ;
      private bool[] P00E72_n208LetCTipCod ;
      private string[] P00E72_A1105LetCBanNum ;
      private decimal[] P00E72_A1112LetCImpDet ;
      private short[] P00E72_A1107LetCDias ;
      private string[] P00E72_A1233MonAbr ;
      private bool[] P00E72_n1233MonAbr ;
      private string[] P00E72_A209LetCDocNum ;
      private bool[] P00E72_n209LetCDocNum ;
      private int[] P00E72_A207LetCItem ;
      private int[] P00E73_A372BanCod ;
      private string[] P00E73_A482BanDsc ;
      private int[] P00E74_A186CCVendCod ;
      private string[] P00E74_A185CCDocNum ;
      private string[] P00E74_A184CCTipCod ;
      private string[] P00E74_A506CCEstado ;
      private string[] P00E74_A2045VenDsc ;
      private bool[] P00E74_n2045VenDsc ;
      private decimal[] P00E74_A509CCImpPago ;
      private decimal[] P00E74_A513CCImpTotal ;
      private string[] P00E75_A1120LetCTipo ;
      private string[] P00E75_A204LetCLetCod ;
      private string[] P00E75_A209LetCDocNum ;
      private bool[] P00E75_n209LetCDocNum ;
      private int[] P00E75_A207LetCItem ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private ExcelDocumentI AV30ExcelDocument ;
      private GxFile AV8Archivo ;
   }

   public class presumenletrasexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E72( IGxContext context ,
                                             string AV13CliCod ,
                                             int AV10BanCod ,
                                             int AV50LetPSec ,
                                             int AV53MonCod ,
                                             string AV60TipFecha ,
                                             int AV66VenCod ,
                                             string A206LetCCliCod ,
                                             int A1104LetCBanCod ,
                                             int A1116LetCSec ,
                                             int A205LetCMonCod ,
                                             DateTime A1108LetCFecLet ,
                                             DateTime AV31FDesde ,
                                             DateTime AV32FHasta ,
                                             DateTime A1109LetCFecVcto ,
                                             int A1123LetCVendCod ,
                                             string A1120LetCTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[LetCTipo], T5.[CCVendCod] AS LetCVendCod, T1.[LetCFecVcto], T1.[LetCFecLet], T2.[LetCMonCod] AS LetCMonCod, T1.[LetCSec], T1.[LetCBanCod], T2.[LetCCliCod] AS LetCCliCod, T2.[LetCLetFec], T4.[CliDsc], T1.[LetCLetCod], T1.[LetCTipCod] AS LetCTipCod, T1.[LetCBanNum], T1.[LetCImpDet], T1.[LetCDias], T3.[MonAbr], T1.[LetCDocNum] AS LetCDocNum, T1.[LetCItem] FROM (((([CLLETRASDET] T1 INNER JOIN [CLLETRAS] T2 ON T2.[LetCLetCod] = T1.[LetCLetCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[LetCMonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T2.[LetCCliCod]) LEFT JOIN [CLCUENTACOBRAR] T5 ON T5.[CCTipCod] = T1.[LetCTipCod] AND T5.[CCDocNum] = T1.[LetCDocNum])";
         AddWhere(sWhereString, "(T1.[LetCTipo] = 'L')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T2.[LetCCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV10BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LetCBanCod] = @AV10BanCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV50LetPSec) )
         {
            AddWhere(sWhereString, "(T1.[LetCSec] = @AV50LetPSec)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV53MonCod) )
         {
            AddWhere(sWhereString, "(T2.[LetCMonCod] = @AV53MonCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] >= @AV31FDesde)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecLet] <= @AV32FHasta)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] >= @AV31FDesde)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV60TipFecha, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LetCFecVcto] <= @AV32FHasta)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV66VenCod) )
         {
            AddWhere(sWhereString, "(T5.[CCVendCod] = @AV66VenCod)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LetCDocNum]";
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
                     return conditional_P00E72(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] );
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
          Object[] prmP00E73;
          prmP00E73 = new Object[] {
          new ParDef("@AV41LetCBanCod",GXType.Int32,6,0)
          };
          Object[] prmP00E74;
          prmP00E74 = new Object[] {
          new ParDef("@AV49LetCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV44LetCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00E75;
          prmP00E75 = new Object[] {
          new ParDef("@AV47LetCLetCod",GXType.NChar,10,0)
          };
          Object[] prmP00E72;
          prmP00E72 = new Object[] {
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV10BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV50LetPSec",GXType.Int32,6,0) ,
          new ParDef("@AV53MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV31FDesde",GXType.Date,8,0) ,
          new ParDef("@AV32FHasta",GXType.Date,8,0) ,
          new ParDef("@AV66VenCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00E72", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E72,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E73", "SELECT [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV41LetCBanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E73,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E74", "SELECT T1.[CCVendCod] AS CCVendCod, T1.[CCDocNum], T1.[CCTipCod], T1.[CCEstado], T2.[VenDsc], T1.[CCImpPago], T1.[CCImpTotal] FROM ([CLCUENTACOBRAR] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[CCVendCod]) WHERE T1.[CCTipCod] = @AV49LetCTipCod and T1.[CCDocNum] = @AV44LetCDocNum ORDER BY T1.[CCTipCod], T1.[CCDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E74,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00E75", "SELECT [LetCTipo], [LetCLetCod], [LetCDocNum] AS LetCDocNum, [LetCItem] FROM [CLLETRASDET] WHERE ([LetCLetCod] = @AV47LetCLetCod) AND ([LetCTipo] = 'D') ORDER BY [LetCLetCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E75,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 100);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 10);
                ((string[]) buf[12])[0] = rslt.getString(12, 3);
                ((bool[]) buf[13])[0] = rslt.wasNull(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((short[]) buf[16])[0] = rslt.getShort(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 5);
                ((bool[]) buf[18])[0] = rslt.wasNull(16);
                ((string[]) buf[19])[0] = rslt.getString(17, 12);
                ((bool[]) buf[20])[0] = rslt.wasNull(17);
                ((int[]) buf[21])[0] = rslt.getInt(18);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
