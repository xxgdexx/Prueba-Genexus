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
   public class pcuentacorrienteexcel : GXProcedure
   {
      public pcuentacorrienteexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pcuentacorrienteexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_CliCod ,
                           ref string aP2_TipCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_FHasta ,
                           ref int aP5_ZonCod ,
                           ref string aP6_Serie ,
                           ref short aP7_TipLetras ,
                           ref int aP8_VenCod ,
                           out string aP9_Filename ,
                           out string aP10_ErrorMessage )
      {
         this.AV94TipCCod = aP0_TipCCod;
         this.AV19CliCod = aP1_CliCod;
         this.AV96TipCod = aP2_TipCod;
         this.AV75MonCod = aP3_MonCod;
         this.AV44FHasta = aP4_FHasta;
         this.AV114ZonCod = aP5_ZonCod;
         this.AV89Serie = aP6_Serie;
         this.AV97TipLetras = aP7_TipLetras;
         this.AV111VenCod = aP8_VenCod;
         this.AV45Filename = "" ;
         this.AV38ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV94TipCCod;
         aP1_CliCod=this.AV19CliCod;
         aP2_TipCod=this.AV96TipCod;
         aP3_MonCod=this.AV75MonCod;
         aP4_FHasta=this.AV44FHasta;
         aP5_ZonCod=this.AV114ZonCod;
         aP6_Serie=this.AV89Serie;
         aP7_TipLetras=this.AV97TipLetras;
         aP8_VenCod=this.AV111VenCod;
         aP9_Filename=this.AV45Filename;
         aP10_ErrorMessage=this.AV38ErrorMessage;
      }

      public string executeUdp( ref int aP0_TipCCod ,
                                ref string aP1_CliCod ,
                                ref string aP2_TipCod ,
                                ref int aP3_MonCod ,
                                ref DateTime aP4_FHasta ,
                                ref int aP5_ZonCod ,
                                ref string aP6_Serie ,
                                ref short aP7_TipLetras ,
                                ref int aP8_VenCod ,
                                out string aP9_Filename )
      {
         execute(ref aP0_TipCCod, ref aP1_CliCod, ref aP2_TipCod, ref aP3_MonCod, ref aP4_FHasta, ref aP5_ZonCod, ref aP6_Serie, ref aP7_TipLetras, ref aP8_VenCod, out aP9_Filename, out aP10_ErrorMessage);
         return AV38ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_CliCod ,
                                 ref string aP2_TipCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_FHasta ,
                                 ref int aP5_ZonCod ,
                                 ref string aP6_Serie ,
                                 ref short aP7_TipLetras ,
                                 ref int aP8_VenCod ,
                                 out string aP9_Filename ,
                                 out string aP10_ErrorMessage )
      {
         pcuentacorrienteexcel objpcuentacorrienteexcel;
         objpcuentacorrienteexcel = new pcuentacorrienteexcel();
         objpcuentacorrienteexcel.AV94TipCCod = aP0_TipCCod;
         objpcuentacorrienteexcel.AV19CliCod = aP1_CliCod;
         objpcuentacorrienteexcel.AV96TipCod = aP2_TipCod;
         objpcuentacorrienteexcel.AV75MonCod = aP3_MonCod;
         objpcuentacorrienteexcel.AV44FHasta = aP4_FHasta;
         objpcuentacorrienteexcel.AV114ZonCod = aP5_ZonCod;
         objpcuentacorrienteexcel.AV89Serie = aP6_Serie;
         objpcuentacorrienteexcel.AV97TipLetras = aP7_TipLetras;
         objpcuentacorrienteexcel.AV111VenCod = aP8_VenCod;
         objpcuentacorrienteexcel.AV45Filename = "" ;
         objpcuentacorrienteexcel.AV38ErrorMessage = "" ;
         objpcuentacorrienteexcel.context.SetSubmitInitialConfig(context);
         objpcuentacorrienteexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpcuentacorrienteexcel);
         aP0_TipCCod=this.AV94TipCCod;
         aP1_CliCod=this.AV19CliCod;
         aP2_TipCod=this.AV96TipCod;
         aP3_MonCod=this.AV75MonCod;
         aP4_FHasta=this.AV44FHasta;
         aP5_ZonCod=this.AV114ZonCod;
         aP6_Serie=this.AV89Serie;
         aP7_TipLetras=this.AV97TipLetras;
         aP8_VenCod=this.AV111VenCod;
         aP9_Filename=this.AV45Filename;
         aP10_ErrorMessage=this.AV38ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pcuentacorrienteexcel)stateInfo).executePrivate();
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
         AV10Archivo.Source = "Excel/PlantillasCuentaCobrar.xlsx";
         AV84Path = AV10Archivo.GetPath();
         AV46FilenameOrigen = StringUtil.Trim( AV84Path) + "\\PlantillasCuentaCobrar.xlsx";
         AV45Filename = "Excel/CuentaCobrar" + ".xlsx";
         AV41ExcelDocument.Clear();
         AV41ExcelDocument.Template = AV46FilenameOrigen;
         AV41ExcelDocument.Open(AV45Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV18CellRow = 3;
         AV47FirstColumn = 0;
         GXt_char1 = AV21cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV73Mes, out  GXt_char1) ;
         AV21cMes = GXt_char1;
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+1, 1, 1).Text = "Al "+context.localUtil.DToC( AV44FHasta, 2, "/");
         AV18CellRow = 5;
         AV47FirstColumn = 1;
         if ( DateTimeUtil.ResetTime ( AV44FHasta ) == DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
         {
            /* Execute user subroutine: 'CUENTACOBRAR' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'CUENTACOBRARAL' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV41ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV41ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CUENTACOBRARAL' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19CliCod ,
                                              AV94TipCCod ,
                                              AV75MonCod ,
                                              AV96TipCod ,
                                              AV114ZonCod ,
                                              AV111VenCod ,
                                              AV97TipLetras ,
                                              AV89Serie ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV44FHasta ,
                                              A190CCFech ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00912 */
         pr_default.execute(0, new Object[] {AV44FHasta, AV44FHasta, AV19CliCod, AV94TipCCod, AV75MonCod, AV96TipCod, AV114ZonCod, AV111VenCod, AV89Serie});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK912 = false;
            A139PaiCod = P00912_A139PaiCod[0];
            n139PaiCod = P00912_n139PaiCod[0];
            A140EstCod = P00912_A140EstCod[0];
            n140EstCod = P00912_n140EstCod[0];
            A141ProvCod = P00912_A141ProvCod[0];
            n141ProvCod = P00912_n141ProvCod[0];
            A142DisCod = P00912_A142DisCod[0];
            n142DisCod = P00912_n142DisCod[0];
            A189CCCliDsc = P00912_A189CCCliDsc[0];
            A306TipAbr = P00912_A306TipAbr[0];
            n306TipAbr = P00912_n306TipAbr[0];
            A185CCDocNum = P00912_A185CCDocNum[0];
            A190CCFech = P00912_A190CCFech[0];
            A511TipSigno = P00912_A511TipSigno[0];
            n511TipSigno = P00912_n511TipSigno[0];
            A513CCImpTotal = P00912_A513CCImpTotal[0];
            A509CCImpPago = P00912_A509CCImpPago[0];
            A187CCmonCod = P00912_A187CCmonCod[0];
            A1234MonDsc = P00912_A1234MonDsc[0];
            n1234MonDsc = P00912_n1234MonDsc[0];
            A506CCEstado = P00912_A506CCEstado[0];
            A2045VenDsc = P00912_A2045VenDsc[0];
            n2045VenDsc = P00912_n2045VenDsc[0];
            A184CCTipCod = P00912_A184CCTipCod[0];
            A508CCFVcto = P00912_A508CCFVcto[0];
            A507CCFecUltPago = P00912_A507CCFecUltPago[0];
            A186CCVendCod = P00912_A186CCVendCod[0];
            A158ZonCod = P00912_A158ZonCod[0];
            n158ZonCod = P00912_n158ZonCod[0];
            A159TipCCod = P00912_A159TipCCod[0];
            n159TipCCod = P00912_n159TipCCod[0];
            A188CCCliCod = P00912_A188CCCliCod[0];
            A604DisDsc = P00912_A604DisDsc[0];
            A596CliDir = P00912_A596CliDir[0];
            n596CliDir = P00912_n596CliDir[0];
            A618CliRef1 = P00912_A618CliRef1[0];
            n618CliRef1 = P00912_n618CliRef1[0];
            A619CliRef2 = P00912_A619CliRef2[0];
            n619CliRef2 = P00912_n619CliRef2[0];
            A620CliRef3 = P00912_A620CliRef3[0];
            n620CliRef3 = P00912_n620CliRef3[0];
            A621CliRef4 = P00912_A621CliRef4[0];
            n621CliRef4 = P00912_n621CliRef4[0];
            A1234MonDsc = P00912_A1234MonDsc[0];
            n1234MonDsc = P00912_n1234MonDsc[0];
            A306TipAbr = P00912_A306TipAbr[0];
            n306TipAbr = P00912_n306TipAbr[0];
            A511TipSigno = P00912_A511TipSigno[0];
            n511TipSigno = P00912_n511TipSigno[0];
            A2045VenDsc = P00912_A2045VenDsc[0];
            n2045VenDsc = P00912_n2045VenDsc[0];
            A139PaiCod = P00912_A139PaiCod[0];
            n139PaiCod = P00912_n139PaiCod[0];
            A140EstCod = P00912_A140EstCod[0];
            n140EstCod = P00912_n140EstCod[0];
            A141ProvCod = P00912_A141ProvCod[0];
            n141ProvCod = P00912_n141ProvCod[0];
            A142DisCod = P00912_A142DisCod[0];
            n142DisCod = P00912_n142DisCod[0];
            A158ZonCod = P00912_A158ZonCod[0];
            n158ZonCod = P00912_n158ZonCod[0];
            A159TipCCod = P00912_A159TipCCod[0];
            n159TipCCod = P00912_n159TipCCod[0];
            A596CliDir = P00912_A596CliDir[0];
            n596CliDir = P00912_n596CliDir[0];
            A618CliRef1 = P00912_A618CliRef1[0];
            n618CliRef1 = P00912_n618CliRef1[0];
            A619CliRef2 = P00912_A619CliRef2[0];
            n619CliRef2 = P00912_n619CliRef2[0];
            A620CliRef3 = P00912_A620CliRef3[0];
            n620CliRef3 = P00912_n620CliRef3[0];
            A621CliRef4 = P00912_A621CliRef4[0];
            n621CliRef4 = P00912_n621CliRef4[0];
            A604DisDsc = P00912_A604DisDsc[0];
            AV12CCCliCod = A188CCCliCod;
            AV20CliDsc = A189CCCliDsc;
            AV114ZonCod = A158ZonCod;
            AV116DisDsc = StringUtil.Trim( A604DisDsc);
            AV117CliDir = StringUtil.Trim( A596CliDir);
            AV118CliRef1 = StringUtil.Trim( A618CliRef1);
            AV121CliRef2 = StringUtil.Trim( A619CliRef2);
            AV122CliRef3 = StringUtil.Trim( A620CliRef3);
            AV123CliRef4 = StringUtil.Trim( A621CliRef4);
            AV94TipCCod = A159TipCCod;
            /* Execute user subroutine: 'ZONA' */
            S122 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            /* Execute user subroutine: 'VALIDAMOV' */
            S132 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            if ( AV48Flag == 1 )
            {
            }
            AV104TotImporte = 0.00m;
            AV105TotPagos = 0.00m;
            AV106TotSaldo = 0.00m;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00912_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK912 = false;
               A306TipAbr = P00912_A306TipAbr[0];
               n306TipAbr = P00912_n306TipAbr[0];
               A185CCDocNum = P00912_A185CCDocNum[0];
               A190CCFech = P00912_A190CCFech[0];
               A511TipSigno = P00912_A511TipSigno[0];
               n511TipSigno = P00912_n511TipSigno[0];
               A513CCImpTotal = P00912_A513CCImpTotal[0];
               A509CCImpPago = P00912_A509CCImpPago[0];
               A187CCmonCod = P00912_A187CCmonCod[0];
               A1234MonDsc = P00912_A1234MonDsc[0];
               n1234MonDsc = P00912_n1234MonDsc[0];
               A506CCEstado = P00912_A506CCEstado[0];
               A2045VenDsc = P00912_A2045VenDsc[0];
               n2045VenDsc = P00912_n2045VenDsc[0];
               A184CCTipCod = P00912_A184CCTipCod[0];
               A508CCFVcto = P00912_A508CCFVcto[0];
               A186CCVendCod = P00912_A186CCVendCod[0];
               A1234MonDsc = P00912_A1234MonDsc[0];
               n1234MonDsc = P00912_n1234MonDsc[0];
               A306TipAbr = P00912_A306TipAbr[0];
               n306TipAbr = P00912_n306TipAbr[0];
               A511TipSigno = P00912_A511TipSigno[0];
               n511TipSigno = P00912_n511TipSigno[0];
               A2045VenDsc = P00912_A2045VenDsc[0];
               n2045VenDsc = P00912_n2045VenDsc[0];
               AV93TipAbr = A306TipAbr;
               AV17CCTipCod = A184CCTipCod;
               AV13CCDocNum = A185CCDocNum;
               AV14CCFech = A190CCFech;
               AV15CCFVcto = A508CCFVcto;
               AV66Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV83Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV63ImpDoc = A513CCImpTotal;
               AV82PagoDoc = A509CCImpPago;
               AV16CCmonCod = A187CCmonCod;
               AV76MonDsc = A1234MonDsc;
               AV39Estado = A506CCEstado;
               AV112VenDsc = A2045VenDsc;
               GXt_decimal2 = AV95TipCmb;
               GXt_int3 = 2;
               GXt_char1 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV14CCFech, ref  GXt_char1, out  GXt_decimal2) ;
               AV95TipCmb = GXt_decimal2;
               AV71LetCBanNum = "";
               AV72LetCSec = 0;
               AV70LetCBanCod = 0;
               AV11BanAbr = "";
               AV40EstadoLet = "";
               /* Execute user subroutine: 'PAGOS' */
               S143 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( ( AV82PagoDoc < Convert.ToDecimal( 0 )) )
               {
                  AV83Pagos = 0;
                  AV82PagoDoc = 0;
               }
               AV66Importe = (decimal)(AV63ImpDoc*A511TipSigno);
               AV83Pagos = (decimal)(AV82PagoDoc*A511TipSigno);
               AV88Saldo = (decimal)((AV63ImpDoc-AV82PagoDoc)*A511TipSigno);
               AV65ImpExpMN = ((AV16CCmonCod==2) ? NumberUtil.Round( AV88Saldo*AV95TipCmb, 2) : NumberUtil.Round( AV88Saldo, 2));
               AV64ImpExpME = ((AV16CCmonCod==1) ? NumberUtil.Round( AV88Saldo/ (decimal)(AV95TipCmb), 2) : NumberUtil.Round( AV88Saldo, 2));
               AV31Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               if ( ( AV88Saldo != Convert.ToDecimal( 0 )) )
               {
                  if ( StringUtil.StrCmp(AV17CCTipCod, "LET") == 0 )
                  {
                     /* Execute user subroutine: 'DATOSLETRAS' */
                     S153 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        returnInSub = true;
                        if (true) return;
                     }
                  }
                  AV104TotImporte = (decimal)(AV104TotImporte+AV66Importe);
                  AV105TotPagos = (decimal)(AV105TotPagos+AV83Pagos);
                  AV106TotSaldo = (decimal)(AV106TotSaldo+AV88Saldo);
                  /* Execute user subroutine: 'DETALLE' */
                  S163 ();
                  if ( returnInSub )
                  {
                     pr_default.close(0);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               BRK912 = true;
               pr_default.readNext(0);
            }
            if ( ( AV106TotSaldo != Convert.ToDecimal( 0 )) )
            {
            }
            AV101TotGImporte = (decimal)(AV101TotGImporte+AV104TotImporte);
            AV102TotGPagos = (decimal)(AV102TotGPagos+AV105TotPagos);
            AV103TotGSaldo = (decimal)(AV103TotGSaldo+AV106TotSaldo);
            if ( ! BRK912 )
            {
               BRK912 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S171( )
      {
         /* 'CUENTACOBRAR' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19CliCod ,
                                              AV94TipCCod ,
                                              AV75MonCod ,
                                              AV96TipCod ,
                                              AV114ZonCod ,
                                              AV111VenCod ,
                                              AV97TipLetras ,
                                              AV89Serie ,
                                              A188CCCliCod ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A506CCEstado } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         /* Using cursor P00913 */
         pr_default.execute(1, new Object[] {AV19CliCod, AV94TipCCod, AV75MonCod, AV96TipCod, AV114ZonCod, AV111VenCod, AV89Serie});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK914 = false;
            A139PaiCod = P00913_A139PaiCod[0];
            n139PaiCod = P00913_n139PaiCod[0];
            A140EstCod = P00913_A140EstCod[0];
            n140EstCod = P00913_n140EstCod[0];
            A141ProvCod = P00913_A141ProvCod[0];
            n141ProvCod = P00913_n141ProvCod[0];
            A142DisCod = P00913_A142DisCod[0];
            n142DisCod = P00913_n142DisCod[0];
            A189CCCliDsc = P00913_A189CCCliDsc[0];
            A306TipAbr = P00913_A306TipAbr[0];
            n306TipAbr = P00913_n306TipAbr[0];
            A185CCDocNum = P00913_A185CCDocNum[0];
            A190CCFech = P00913_A190CCFech[0];
            A187CCmonCod = P00913_A187CCmonCod[0];
            A1234MonDsc = P00913_A1234MonDsc[0];
            n1234MonDsc = P00913_n1234MonDsc[0];
            A511TipSigno = P00913_A511TipSigno[0];
            n511TipSigno = P00913_n511TipSigno[0];
            A513CCImpTotal = P00913_A513CCImpTotal[0];
            A509CCImpPago = P00913_A509CCImpPago[0];
            A506CCEstado = P00913_A506CCEstado[0];
            A2045VenDsc = P00913_A2045VenDsc[0];
            n2045VenDsc = P00913_n2045VenDsc[0];
            A184CCTipCod = P00913_A184CCTipCod[0];
            A508CCFVcto = P00913_A508CCFVcto[0];
            A186CCVendCod = P00913_A186CCVendCod[0];
            A158ZonCod = P00913_A158ZonCod[0];
            n158ZonCod = P00913_n158ZonCod[0];
            A159TipCCod = P00913_A159TipCCod[0];
            n159TipCCod = P00913_n159TipCCod[0];
            A188CCCliCod = P00913_A188CCCliCod[0];
            A604DisDsc = P00913_A604DisDsc[0];
            A596CliDir = P00913_A596CliDir[0];
            n596CliDir = P00913_n596CliDir[0];
            A618CliRef1 = P00913_A618CliRef1[0];
            n618CliRef1 = P00913_n618CliRef1[0];
            A619CliRef2 = P00913_A619CliRef2[0];
            n619CliRef2 = P00913_n619CliRef2[0];
            A620CliRef3 = P00913_A620CliRef3[0];
            n620CliRef3 = P00913_n620CliRef3[0];
            A621CliRef4 = P00913_A621CliRef4[0];
            n621CliRef4 = P00913_n621CliRef4[0];
            A1234MonDsc = P00913_A1234MonDsc[0];
            n1234MonDsc = P00913_n1234MonDsc[0];
            A306TipAbr = P00913_A306TipAbr[0];
            n306TipAbr = P00913_n306TipAbr[0];
            A511TipSigno = P00913_A511TipSigno[0];
            n511TipSigno = P00913_n511TipSigno[0];
            A2045VenDsc = P00913_A2045VenDsc[0];
            n2045VenDsc = P00913_n2045VenDsc[0];
            A139PaiCod = P00913_A139PaiCod[0];
            n139PaiCod = P00913_n139PaiCod[0];
            A140EstCod = P00913_A140EstCod[0];
            n140EstCod = P00913_n140EstCod[0];
            A141ProvCod = P00913_A141ProvCod[0];
            n141ProvCod = P00913_n141ProvCod[0];
            A142DisCod = P00913_A142DisCod[0];
            n142DisCod = P00913_n142DisCod[0];
            A158ZonCod = P00913_A158ZonCod[0];
            n158ZonCod = P00913_n158ZonCod[0];
            A159TipCCod = P00913_A159TipCCod[0];
            n159TipCCod = P00913_n159TipCCod[0];
            A596CliDir = P00913_A596CliDir[0];
            n596CliDir = P00913_n596CliDir[0];
            A618CliRef1 = P00913_A618CliRef1[0];
            n618CliRef1 = P00913_n618CliRef1[0];
            A619CliRef2 = P00913_A619CliRef2[0];
            n619CliRef2 = P00913_n619CliRef2[0];
            A620CliRef3 = P00913_A620CliRef3[0];
            n620CliRef3 = P00913_n620CliRef3[0];
            A621CliRef4 = P00913_A621CliRef4[0];
            n621CliRef4 = P00913_n621CliRef4[0];
            A604DisDsc = P00913_A604DisDsc[0];
            AV12CCCliCod = A188CCCliCod;
            AV20CliDsc = A189CCCliDsc;
            AV114ZonCod = A158ZonCod;
            AV116DisDsc = StringUtil.Trim( A604DisDsc);
            AV117CliDir = StringUtil.Trim( A596CliDir);
            AV118CliRef1 = StringUtil.Trim( A618CliRef1);
            AV121CliRef2 = StringUtil.Trim( A619CliRef2);
            AV122CliRef3 = StringUtil.Trim( A620CliRef3);
            AV123CliRef4 = StringUtil.Trim( A621CliRef4);
            AV94TipCCod = A159TipCCod;
            /* Execute user subroutine: 'ZONA' */
            S122 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            AV104TotImporte = 0.00m;
            AV105TotPagos = 0.00m;
            AV106TotSaldo = 0.00m;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00913_A189CCCliDsc[0], A189CCCliDsc) == 0 ) )
            {
               BRK914 = false;
               A306TipAbr = P00913_A306TipAbr[0];
               n306TipAbr = P00913_n306TipAbr[0];
               A185CCDocNum = P00913_A185CCDocNum[0];
               A190CCFech = P00913_A190CCFech[0];
               A187CCmonCod = P00913_A187CCmonCod[0];
               A1234MonDsc = P00913_A1234MonDsc[0];
               n1234MonDsc = P00913_n1234MonDsc[0];
               A511TipSigno = P00913_A511TipSigno[0];
               n511TipSigno = P00913_n511TipSigno[0];
               A513CCImpTotal = P00913_A513CCImpTotal[0];
               A509CCImpPago = P00913_A509CCImpPago[0];
               A506CCEstado = P00913_A506CCEstado[0];
               A2045VenDsc = P00913_A2045VenDsc[0];
               n2045VenDsc = P00913_n2045VenDsc[0];
               A184CCTipCod = P00913_A184CCTipCod[0];
               A508CCFVcto = P00913_A508CCFVcto[0];
               A186CCVendCod = P00913_A186CCVendCod[0];
               A1234MonDsc = P00913_A1234MonDsc[0];
               n1234MonDsc = P00913_n1234MonDsc[0];
               A306TipAbr = P00913_A306TipAbr[0];
               n306TipAbr = P00913_n306TipAbr[0];
               A511TipSigno = P00913_A511TipSigno[0];
               n511TipSigno = P00913_n511TipSigno[0];
               A2045VenDsc = P00913_A2045VenDsc[0];
               n2045VenDsc = P00913_n2045VenDsc[0];
               AV93TipAbr = A306TipAbr;
               AV17CCTipCod = A184CCTipCod;
               AV13CCDocNum = A185CCDocNum;
               AV14CCFech = A190CCFech;
               AV15CCFVcto = A508CCFVcto;
               AV16CCmonCod = A187CCmonCod;
               AV76MonDsc = A1234MonDsc;
               GXt_decimal2 = AV95TipCmb;
               GXt_int3 = 2;
               GXt_char1 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  GXt_int3, ref  AV14CCFech, ref  GXt_char1, out  GXt_decimal2) ;
               AV95TipCmb = GXt_decimal2;
               AV66Importe = (decimal)(A513CCImpTotal*A511TipSigno);
               AV83Pagos = (decimal)(A509CCImpPago*A511TipSigno);
               AV88Saldo = (decimal)((A513CCImpTotal-A509CCImpPago)*A511TipSigno);
               AV65ImpExpMN = ((AV16CCmonCod==2) ? NumberUtil.Round( AV88Saldo*AV95TipCmb, 2) : NumberUtil.Round( AV88Saldo, 2));
               AV64ImpExpME = ((AV16CCmonCod==1) ? NumberUtil.Round( AV88Saldo/ (decimal)(AV95TipCmb), 2) : NumberUtil.Round( AV88Saldo, 2));
               AV31Dias = (int)(DateTimeUtil.DDiff(DateTimeUtil.Today( context),A508CCFVcto));
               AV39Estado = A506CCEstado;
               AV112VenDsc = A2045VenDsc;
               AV71LetCBanNum = "";
               AV72LetCSec = 0;
               AV70LetCBanCod = 0;
               AV11BanAbr = "";
               AV40EstadoLet = "";
               if ( StringUtil.StrCmp(AV17CCTipCod, "LET") == 0 )
               {
                  /* Execute user subroutine: 'DATOSLETRAS' */
                  S153 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
               AV104TotImporte = (decimal)(AV104TotImporte+AV66Importe);
               AV105TotPagos = (decimal)(AV105TotPagos+AV83Pagos);
               AV106TotSaldo = (decimal)(AV106TotSaldo+AV88Saldo);
               /* Execute user subroutine: 'DETALLE' */
               S163 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  returnInSub = true;
                  if (true) return;
               }
               BRK914 = true;
               pr_default.readNext(1);
            }
            AV101TotGImporte = (decimal)(AV101TotGImporte+AV104TotImporte);
            AV102TotGPagos = (decimal)(AV102TotGPagos+AV105TotPagos);
            AV103TotGSaldo = (decimal)(AV103TotGSaldo+AV106TotSaldo);
            if ( ! BRK914 )
            {
               BRK914 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S143( )
      {
         /* 'PAGOS' Routine */
         returnInSub = false;
         /* Using cursor P00914 */
         pr_default.execute(2, new Object[] {AV17CCTipCod, AV13CCDocNum, AV44FHasta});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A166CobTip = P00914_A166CobTip[0];
            A167CobCod = P00914_A167CobCod[0];
            A661CobSts = P00914_A661CobSts[0];
            A655CobFec = P00914_A655CobFec[0];
            A176CobDocNum = P00914_A176CobDocNum[0];
            A175CobTipCod = P00914_A175CobTipCod[0];
            A172CobMon = P00914_A172CobMon[0];
            A654CobDTot = P00914_A654CobDTot[0];
            A663CobTipCam = P00914_A663CobTipCam[0];
            A173Item = P00914_A173Item[0];
            A661CobSts = P00914_A661CobSts[0];
            A655CobFec = P00914_A655CobFec[0];
            A172CobMon = P00914_A172CobMon[0];
            AV23CobMon = A172CobMon;
            AV22CobDtot = NumberUtil.Round( A654CobDTot, 2);
            if ( ( AV22CobDtot < Convert.ToDecimal( 0 )) )
            {
               AV22CobDtot = (decimal)(AV22CobDtot*-1);
            }
            if ( AV16CCmonCod == AV23CobMon )
            {
               AV82PagoDoc = (decimal)(AV82PagoDoc-AV22CobDtot);
            }
            else
            {
               if ( AV16CCmonCod == 1 )
               {
                  AV82PagoDoc = (decimal)(AV82PagoDoc-(NumberUtil.Round( AV22CobDtot*A663CobTipCam, 2)));
               }
               else
               {
                  AV82PagoDoc = (decimal)(AV82PagoDoc-(NumberUtil.Round( AV22CobDtot/ (decimal)(A663CobTipCam), 2)));
               }
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S132( )
      {
         /* 'VALIDAMOV' Routine */
         returnInSub = false;
         AV48Flag = 0;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV94TipCCod ,
                                              AV75MonCod ,
                                              AV96TipCod ,
                                              AV114ZonCod ,
                                              AV111VenCod ,
                                              AV97TipLetras ,
                                              AV89Serie ,
                                              A159TipCCod ,
                                              A187CCmonCod ,
                                              A184CCTipCod ,
                                              A158ZonCod ,
                                              A186CCVendCod ,
                                              A185CCDocNum ,
                                              A507CCFecUltPago ,
                                              AV44FHasta ,
                                              A190CCFech ,
                                              A506CCEstado ,
                                              A188CCCliCod ,
                                              AV12CCCliCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00915 */
         pr_default.execute(3, new Object[] {AV44FHasta, AV44FHasta, AV12CCCliCod, AV94TipCCod, AV75MonCod, AV96TipCod, AV114ZonCod, AV111VenCod, AV89Serie});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A506CCEstado = P00915_A506CCEstado[0];
            A185CCDocNum = P00915_A185CCDocNum[0];
            A190CCFech = P00915_A190CCFech[0];
            A507CCFecUltPago = P00915_A507CCFecUltPago[0];
            A186CCVendCod = P00915_A186CCVendCod[0];
            A158ZonCod = P00915_A158ZonCod[0];
            n158ZonCod = P00915_n158ZonCod[0];
            A184CCTipCod = P00915_A184CCTipCod[0];
            A187CCmonCod = P00915_A187CCmonCod[0];
            A159TipCCod = P00915_A159TipCCod[0];
            n159TipCCod = P00915_n159TipCCod[0];
            A188CCCliCod = P00915_A188CCCliCod[0];
            A513CCImpTotal = P00915_A513CCImpTotal[0];
            A509CCImpPago = P00915_A509CCImpPago[0];
            A511TipSigno = P00915_A511TipSigno[0];
            n511TipSigno = P00915_n511TipSigno[0];
            A511TipSigno = P00915_A511TipSigno[0];
            n511TipSigno = P00915_n511TipSigno[0];
            A158ZonCod = P00915_A158ZonCod[0];
            n158ZonCod = P00915_n158ZonCod[0];
            A159TipCCod = P00915_A159TipCCod[0];
            n159TipCCod = P00915_n159TipCCod[0];
            AV17CCTipCod = A184CCTipCod;
            AV13CCDocNum = A185CCDocNum;
            AV66Importe = A513CCImpTotal;
            AV83Pagos = A509CCImpPago;
            AV16CCmonCod = A187CCmonCod;
            AV82PagoDoc = A509CCImpPago;
            /* Execute user subroutine: 'PAGOS' */
            S143 ();
            if ( returnInSub )
            {
               pr_default.close(3);
               returnInSub = true;
               if (true) return;
            }
            if ( AV82PagoDoc < 0.02m )
            {
               AV83Pagos = 0;
               AV82PagoDoc = 0;
            }
            AV66Importe = (decimal)(AV66Importe*A511TipSigno);
            AV83Pagos = (decimal)(AV82PagoDoc*A511TipSigno);
            AV88Saldo = (decimal)((AV66Importe-AV82PagoDoc)*A511TipSigno);
            if ( ( AV88Saldo != Convert.ToDecimal( 0 )) )
            {
               AV48Flag = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S181( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV41ExcelDocument.ErrCode != 0 )
         {
            AV45Filename = "";
            AV38ErrorMessage = AV41ExcelDocument.ErrDescription;
            AV41ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S163( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV115PedCod = "";
         AV119DocRef = "";
         /* Using cursor P00916 */
         pr_default.execute(4, new Object[] {AV17CCTipCod, AV13CCDocNum});
         while ( (pr_default.getStatus(4) != 101) )
         {
            A24DocNum = P00916_A24DocNum[0];
            A149TipCod = P00916_A149TipCod[0];
            A931DocFVcto = P00916_A931DocFVcto[0];
            A937DocPedCod = P00916_A937DocPedCod[0];
            A939DocRef = P00916_A939DocRef[0];
            AV115PedCod = A937DocPedCod;
            AV119DocRef = A939DocRef;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(4);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV12CCCliCod);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV20CliDsc);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV93TipAbr);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV13CCDocNum);
         GXt_dtime4 = DateTimeUtil.ResetTime( AV14CCFech ) ;
         AV41ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+4, 1, 1).Date = GXt_dtime4;
         GXt_dtime4 = DateTimeUtil.ResetTime( AV15CCFVcto ) ;
         AV41ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+5, 1, 1).Date = GXt_dtime4;
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+6, 1, 1).Number = AV31Dias;
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV76MonDsc);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+8, 1, 1).Number = (double)(AV66Importe);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+9, 1, 1).Number = (double)(AV83Pagos);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+10, 1, 1).Number = (double)(AV88Saldo);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+11, 1, 1).Text = StringUtil.Trim( AV112VenDsc);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+12, 1, 1).Number = (double)(AV95TipCmb);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+13, 1, 1).Number = (double)(AV65ImpExpMN);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+14, 1, 1).Number = (double)(AV64ImpExpME);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+15, 1, 1).Text = StringUtil.Trim( AV11BanAbr);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+16, 1, 1).Text = StringUtil.Trim( AV71LetCBanNum);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+17, 1, 1).Text = StringUtil.Trim( AV40EstadoLet);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+18, 1, 1).Text = StringUtil.Trim( AV116DisDsc);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+19, 1, 1).Text = StringUtil.Trim( AV117CliDir);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+20, 1, 1).Text = StringUtil.Trim( AV113Zona);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+21, 1, 1).Text = StringUtil.Trim( AV115PedCod);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+22, 1, 1).Text = StringUtil.Trim( AV119DocRef);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+23, 1, 1).Text = StringUtil.Trim( AV120TipCDsc);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+24, 1, 1).Text = StringUtil.Trim( AV118CliRef1);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+25, 1, 1).Text = StringUtil.Trim( AV121CliRef2);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+26, 1, 1).Text = StringUtil.Trim( AV122CliRef3);
         AV41ExcelDocument.get_Cells(AV18CellRow, AV47FirstColumn+27, 1, 1).Text = StringUtil.Trim( AV123CliRef4);
         AV18CellRow = (int)(AV18CellRow+1);
      }

      protected void S153( )
      {
         /* 'DATOSLETRAS' Routine */
         returnInSub = false;
         /* Using cursor P00917 */
         pr_default.execute(5, new Object[] {AV13CCDocNum});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A1120LetCTipo = P00917_A1120LetCTipo[0];
            A209LetCDocNum = P00917_A209LetCDocNum[0];
            n209LetCDocNum = P00917_n209LetCDocNum[0];
            A1105LetCBanNum = P00917_A1105LetCBanNum[0];
            A1116LetCSec = P00917_A1116LetCSec[0];
            A1104LetCBanCod = P00917_A1104LetCBanCod[0];
            A204LetCLetCod = P00917_A204LetCLetCod[0];
            A207LetCItem = P00917_A207LetCItem[0];
            AV71LetCBanNum = A1105LetCBanNum;
            AV72LetCSec = A1116LetCSec;
            AV70LetCBanCod = A1104LetCBanCod;
            AV11BanAbr = "";
            AV40EstadoLet = "";
            /* Execute user subroutine: 'BANCO' */
            S199 ();
            if ( returnInSub )
            {
               pr_default.close(5);
               returnInSub = true;
               if (true) return;
            }
            if ( AV72LetCSec == 1 )
            {
               AV40EstadoLet = "Por Aceptar";
            }
            if ( AV72LetCSec == 2 )
            {
               AV40EstadoLet = "Descuento";
            }
            if ( AV72LetCSec == 3 )
            {
               AV40EstadoLet = "Cobranza";
            }
            if ( AV72LetCSec == 4 )
            {
               AV40EstadoLet = "Cobranza Libre";
            }
            if ( AV72LetCSec == 5 )
            {
               AV40EstadoLet = "Garantia";
            }
            if ( AV72LetCSec == 6 )
            {
               AV40EstadoLet = "Protestado";
            }
            if ( AV72LetCSec == 7 )
            {
               AV40EstadoLet = "Refinanciado";
            }
            if ( AV72LetCSec == 8 )
            {
               AV40EstadoLet = "Cartera";
            }
            if ( AV72LetCSec == 9 )
            {
               AV40EstadoLet = "Aceptada";
            }
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void S199( )
      {
         /* 'BANCO' Routine */
         returnInSub = false;
         /* Using cursor P00918 */
         pr_default.execute(6, new Object[] {AV70LetCBanCod});
         while ( (pr_default.getStatus(6) != 101) )
         {
            A372BanCod = P00918_A372BanCod[0];
            A481BanAbr = P00918_A481BanAbr[0];
            AV11BanAbr = StringUtil.Trim( A481BanAbr);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(6);
      }

      protected void S122( )
      {
         /* 'ZONA' Routine */
         returnInSub = false;
         AV113Zona = "";
         /* Using cursor P00919 */
         pr_default.execute(7, new Object[] {AV114ZonCod});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A158ZonCod = P00919_A158ZonCod[0];
            n158ZonCod = P00919_n158ZonCod[0];
            A2094ZonDsc = P00919_A2094ZonDsc[0];
            AV113Zona = StringUtil.Trim( A2094ZonDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(7);
         AV120TipCDsc = "";
         /* Using cursor P009110 */
         pr_default.execute(8, new Object[] {AV94TipCCod});
         while ( (pr_default.getStatus(8) != 101) )
         {
            A159TipCCod = P009110_A159TipCCod[0];
            n159TipCCod = P009110_n159TipCCod[0];
            A1905TipCDsc = P009110_A1905TipCDsc[0];
            AV120TipCDsc = StringUtil.Trim( A1905TipCDsc);
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
         AV45Filename = "";
         AV38ErrorMessage = "";
         AV10Archivo = new GxFile(context.GetPhysicalPath());
         AV84Path = "";
         AV46FilenameOrigen = "";
         AV41ExcelDocument = new ExcelDocumentI();
         AV21cMes = "";
         scmdbuf = "";
         A188CCCliCod = "";
         A184CCTipCod = "";
         A185CCDocNum = "";
         A507CCFecUltPago = DateTime.MinValue;
         A190CCFech = DateTime.MinValue;
         A506CCEstado = "";
         P00912_A139PaiCod = new string[] {""} ;
         P00912_n139PaiCod = new bool[] {false} ;
         P00912_A140EstCod = new string[] {""} ;
         P00912_n140EstCod = new bool[] {false} ;
         P00912_A141ProvCod = new string[] {""} ;
         P00912_n141ProvCod = new bool[] {false} ;
         P00912_A142DisCod = new string[] {""} ;
         P00912_n142DisCod = new bool[] {false} ;
         P00912_A189CCCliDsc = new string[] {""} ;
         P00912_A306TipAbr = new string[] {""} ;
         P00912_n306TipAbr = new bool[] {false} ;
         P00912_A185CCDocNum = new string[] {""} ;
         P00912_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00912_A511TipSigno = new short[1] ;
         P00912_n511TipSigno = new bool[] {false} ;
         P00912_A513CCImpTotal = new decimal[1] ;
         P00912_A509CCImpPago = new decimal[1] ;
         P00912_A187CCmonCod = new int[1] ;
         P00912_A1234MonDsc = new string[] {""} ;
         P00912_n1234MonDsc = new bool[] {false} ;
         P00912_A506CCEstado = new string[] {""} ;
         P00912_A2045VenDsc = new string[] {""} ;
         P00912_n2045VenDsc = new bool[] {false} ;
         P00912_A184CCTipCod = new string[] {""} ;
         P00912_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00912_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00912_A186CCVendCod = new int[1] ;
         P00912_A158ZonCod = new int[1] ;
         P00912_n158ZonCod = new bool[] {false} ;
         P00912_A159TipCCod = new int[1] ;
         P00912_n159TipCCod = new bool[] {false} ;
         P00912_A188CCCliCod = new string[] {""} ;
         P00912_A604DisDsc = new string[] {""} ;
         P00912_A596CliDir = new string[] {""} ;
         P00912_n596CliDir = new bool[] {false} ;
         P00912_A618CliRef1 = new string[] {""} ;
         P00912_n618CliRef1 = new bool[] {false} ;
         P00912_A619CliRef2 = new string[] {""} ;
         P00912_n619CliRef2 = new bool[] {false} ;
         P00912_A620CliRef3 = new string[] {""} ;
         P00912_n620CliRef3 = new bool[] {false} ;
         P00912_A621CliRef4 = new string[] {""} ;
         P00912_n621CliRef4 = new bool[] {false} ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         A142DisCod = "";
         A189CCCliDsc = "";
         A306TipAbr = "";
         A1234MonDsc = "";
         A2045VenDsc = "";
         A508CCFVcto = DateTime.MinValue;
         A604DisDsc = "";
         A596CliDir = "";
         A618CliRef1 = "";
         A619CliRef2 = "";
         A620CliRef3 = "";
         A621CliRef4 = "";
         AV12CCCliCod = "";
         AV20CliDsc = "";
         AV116DisDsc = "";
         AV117CliDir = "";
         AV118CliRef1 = "";
         AV121CliRef2 = "";
         AV122CliRef3 = "";
         AV123CliRef4 = "";
         AV93TipAbr = "";
         AV17CCTipCod = "";
         AV13CCDocNum = "";
         AV14CCFech = DateTime.MinValue;
         AV15CCFVcto = DateTime.MinValue;
         AV76MonDsc = "";
         AV39Estado = "";
         AV112VenDsc = "";
         AV71LetCBanNum = "";
         AV11BanAbr = "";
         AV40EstadoLet = "";
         P00913_A139PaiCod = new string[] {""} ;
         P00913_n139PaiCod = new bool[] {false} ;
         P00913_A140EstCod = new string[] {""} ;
         P00913_n140EstCod = new bool[] {false} ;
         P00913_A141ProvCod = new string[] {""} ;
         P00913_n141ProvCod = new bool[] {false} ;
         P00913_A142DisCod = new string[] {""} ;
         P00913_n142DisCod = new bool[] {false} ;
         P00913_A189CCCliDsc = new string[] {""} ;
         P00913_A306TipAbr = new string[] {""} ;
         P00913_n306TipAbr = new bool[] {false} ;
         P00913_A185CCDocNum = new string[] {""} ;
         P00913_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00913_A187CCmonCod = new int[1] ;
         P00913_A1234MonDsc = new string[] {""} ;
         P00913_n1234MonDsc = new bool[] {false} ;
         P00913_A511TipSigno = new short[1] ;
         P00913_n511TipSigno = new bool[] {false} ;
         P00913_A513CCImpTotal = new decimal[1] ;
         P00913_A509CCImpPago = new decimal[1] ;
         P00913_A506CCEstado = new string[] {""} ;
         P00913_A2045VenDsc = new string[] {""} ;
         P00913_n2045VenDsc = new bool[] {false} ;
         P00913_A184CCTipCod = new string[] {""} ;
         P00913_A508CCFVcto = new DateTime[] {DateTime.MinValue} ;
         P00913_A186CCVendCod = new int[1] ;
         P00913_A158ZonCod = new int[1] ;
         P00913_n158ZonCod = new bool[] {false} ;
         P00913_A159TipCCod = new int[1] ;
         P00913_n159TipCCod = new bool[] {false} ;
         P00913_A188CCCliCod = new string[] {""} ;
         P00913_A604DisDsc = new string[] {""} ;
         P00913_A596CliDir = new string[] {""} ;
         P00913_n596CliDir = new bool[] {false} ;
         P00913_A618CliRef1 = new string[] {""} ;
         P00913_n618CliRef1 = new bool[] {false} ;
         P00913_A619CliRef2 = new string[] {""} ;
         P00913_n619CliRef2 = new bool[] {false} ;
         P00913_A620CliRef3 = new string[] {""} ;
         P00913_n620CliRef3 = new bool[] {false} ;
         P00913_A621CliRef4 = new string[] {""} ;
         P00913_n621CliRef4 = new bool[] {false} ;
         GXt_char1 = "";
         P00914_A166CobTip = new string[] {""} ;
         P00914_A167CobCod = new string[] {""} ;
         P00914_A661CobSts = new string[] {""} ;
         P00914_A655CobFec = new DateTime[] {DateTime.MinValue} ;
         P00914_A176CobDocNum = new string[] {""} ;
         P00914_A175CobTipCod = new string[] {""} ;
         P00914_A172CobMon = new int[1] ;
         P00914_A654CobDTot = new decimal[1] ;
         P00914_A663CobTipCam = new decimal[1] ;
         P00914_A173Item = new int[1] ;
         A166CobTip = "";
         A167CobCod = "";
         A661CobSts = "";
         A655CobFec = DateTime.MinValue;
         A176CobDocNum = "";
         A175CobTipCod = "";
         P00915_A506CCEstado = new string[] {""} ;
         P00915_A185CCDocNum = new string[] {""} ;
         P00915_A190CCFech = new DateTime[] {DateTime.MinValue} ;
         P00915_A507CCFecUltPago = new DateTime[] {DateTime.MinValue} ;
         P00915_A186CCVendCod = new int[1] ;
         P00915_A158ZonCod = new int[1] ;
         P00915_n158ZonCod = new bool[] {false} ;
         P00915_A184CCTipCod = new string[] {""} ;
         P00915_A187CCmonCod = new int[1] ;
         P00915_A159TipCCod = new int[1] ;
         P00915_n159TipCCod = new bool[] {false} ;
         P00915_A188CCCliCod = new string[] {""} ;
         P00915_A513CCImpTotal = new decimal[1] ;
         P00915_A509CCImpPago = new decimal[1] ;
         P00915_A511TipSigno = new short[1] ;
         P00915_n511TipSigno = new bool[] {false} ;
         AV115PedCod = "";
         AV119DocRef = "";
         P00916_A24DocNum = new string[] {""} ;
         P00916_A149TipCod = new string[] {""} ;
         P00916_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         P00916_A937DocPedCod = new string[] {""} ;
         P00916_A939DocRef = new string[] {""} ;
         A24DocNum = "";
         A149TipCod = "";
         A931DocFVcto = DateTime.MinValue;
         A937DocPedCod = "";
         A939DocRef = "";
         GXt_dtime4 = (DateTime)(DateTime.MinValue);
         AV113Zona = "";
         AV120TipCDsc = "";
         P00917_A1120LetCTipo = new string[] {""} ;
         P00917_A209LetCDocNum = new string[] {""} ;
         P00917_n209LetCDocNum = new bool[] {false} ;
         P00917_A1105LetCBanNum = new string[] {""} ;
         P00917_A1116LetCSec = new int[1] ;
         P00917_A1104LetCBanCod = new int[1] ;
         P00917_A204LetCLetCod = new string[] {""} ;
         P00917_A207LetCItem = new int[1] ;
         A1120LetCTipo = "";
         A209LetCDocNum = "";
         A1105LetCBanNum = "";
         A204LetCLetCod = "";
         P00918_A372BanCod = new int[1] ;
         P00918_A481BanAbr = new string[] {""} ;
         A481BanAbr = "";
         P00919_A158ZonCod = new int[1] ;
         P00919_n158ZonCod = new bool[] {false} ;
         P00919_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         P009110_A159TipCCod = new int[1] ;
         P009110_n159TipCCod = new bool[] {false} ;
         P009110_A1905TipCDsc = new string[] {""} ;
         A1905TipCDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pcuentacorrienteexcel__default(),
            new Object[][] {
                new Object[] {
               P00912_A139PaiCod, P00912_n139PaiCod, P00912_A140EstCod, P00912_n140EstCod, P00912_A141ProvCod, P00912_n141ProvCod, P00912_A142DisCod, P00912_n142DisCod, P00912_A189CCCliDsc, P00912_A306TipAbr,
               P00912_n306TipAbr, P00912_A185CCDocNum, P00912_A190CCFech, P00912_A511TipSigno, P00912_n511TipSigno, P00912_A513CCImpTotal, P00912_A509CCImpPago, P00912_A187CCmonCod, P00912_A1234MonDsc, P00912_n1234MonDsc,
               P00912_A506CCEstado, P00912_A2045VenDsc, P00912_n2045VenDsc, P00912_A184CCTipCod, P00912_A508CCFVcto, P00912_A507CCFecUltPago, P00912_A186CCVendCod, P00912_A158ZonCod, P00912_n158ZonCod, P00912_A159TipCCod,
               P00912_n159TipCCod, P00912_A188CCCliCod, P00912_A604DisDsc, P00912_A596CliDir, P00912_n596CliDir, P00912_A618CliRef1, P00912_n618CliRef1, P00912_A619CliRef2, P00912_n619CliRef2, P00912_A620CliRef3,
               P00912_n620CliRef3, P00912_A621CliRef4, P00912_n621CliRef4
               }
               , new Object[] {
               P00913_A139PaiCod, P00913_n139PaiCod, P00913_A140EstCod, P00913_n140EstCod, P00913_A141ProvCod, P00913_n141ProvCod, P00913_A142DisCod, P00913_n142DisCod, P00913_A189CCCliDsc, P00913_A306TipAbr,
               P00913_n306TipAbr, P00913_A185CCDocNum, P00913_A190CCFech, P00913_A187CCmonCod, P00913_A1234MonDsc, P00913_n1234MonDsc, P00913_A511TipSigno, P00913_n511TipSigno, P00913_A513CCImpTotal, P00913_A509CCImpPago,
               P00913_A506CCEstado, P00913_A2045VenDsc, P00913_n2045VenDsc, P00913_A184CCTipCod, P00913_A508CCFVcto, P00913_A186CCVendCod, P00913_A158ZonCod, P00913_n158ZonCod, P00913_A159TipCCod, P00913_n159TipCCod,
               P00913_A188CCCliCod, P00913_A604DisDsc, P00913_A596CliDir, P00913_n596CliDir, P00913_A618CliRef1, P00913_n618CliRef1, P00913_A619CliRef2, P00913_n619CliRef2, P00913_A620CliRef3, P00913_n620CliRef3,
               P00913_A621CliRef4, P00913_n621CliRef4
               }
               , new Object[] {
               P00914_A166CobTip, P00914_A167CobCod, P00914_A661CobSts, P00914_A655CobFec, P00914_A176CobDocNum, P00914_A175CobTipCod, P00914_A172CobMon, P00914_A654CobDTot, P00914_A663CobTipCam, P00914_A173Item
               }
               , new Object[] {
               P00915_A506CCEstado, P00915_A185CCDocNum, P00915_A190CCFech, P00915_A507CCFecUltPago, P00915_A186CCVendCod, P00915_A158ZonCod, P00915_n158ZonCod, P00915_A184CCTipCod, P00915_A187CCmonCod, P00915_A159TipCCod,
               P00915_n159TipCCod, P00915_A188CCCliCod, P00915_A513CCImpTotal, P00915_A509CCImpPago, P00915_A511TipSigno, P00915_n511TipSigno
               }
               , new Object[] {
               P00916_A24DocNum, P00916_A149TipCod, P00916_A931DocFVcto, P00916_A937DocPedCod, P00916_A939DocRef
               }
               , new Object[] {
               P00917_A1120LetCTipo, P00917_A209LetCDocNum, P00917_n209LetCDocNum, P00917_A1105LetCBanNum, P00917_A1116LetCSec, P00917_A1104LetCBanCod, P00917_A204LetCLetCod, P00917_A207LetCItem
               }
               , new Object[] {
               P00918_A372BanCod, P00918_A481BanAbr
               }
               , new Object[] {
               P00919_A158ZonCod, P00919_A2094ZonDsc
               }
               , new Object[] {
               P009110_A159TipCCod, P009110_A1905TipCDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV97TipLetras ;
      private short AV73Mes ;
      private short A511TipSigno ;
      private short AV48Flag ;
      private int AV94TipCCod ;
      private int AV75MonCod ;
      private int AV114ZonCod ;
      private int AV111VenCod ;
      private int AV18CellRow ;
      private int AV47FirstColumn ;
      private int A159TipCCod ;
      private int A187CCmonCod ;
      private int A158ZonCod ;
      private int A186CCVendCod ;
      private int AV16CCmonCod ;
      private int AV72LetCSec ;
      private int AV70LetCBanCod ;
      private int AV31Dias ;
      private int GXt_int3 ;
      private int A172CobMon ;
      private int A173Item ;
      private int AV23CobMon ;
      private int A1116LetCSec ;
      private int A1104LetCBanCod ;
      private int A207LetCItem ;
      private int A372BanCod ;
      private decimal A513CCImpTotal ;
      private decimal A509CCImpPago ;
      private decimal AV104TotImporte ;
      private decimal AV105TotPagos ;
      private decimal AV106TotSaldo ;
      private decimal AV66Importe ;
      private decimal AV83Pagos ;
      private decimal AV63ImpDoc ;
      private decimal AV82PagoDoc ;
      private decimal AV95TipCmb ;
      private decimal AV88Saldo ;
      private decimal AV65ImpExpMN ;
      private decimal AV64ImpExpME ;
      private decimal AV101TotGImporte ;
      private decimal AV102TotGPagos ;
      private decimal AV103TotGSaldo ;
      private decimal GXt_decimal2 ;
      private decimal A654CobDTot ;
      private decimal A663CobTipCam ;
      private decimal AV22CobDtot ;
      private string AV19CliCod ;
      private string AV96TipCod ;
      private string AV89Serie ;
      private string AV84Path ;
      private string AV21cMes ;
      private string scmdbuf ;
      private string A188CCCliCod ;
      private string A184CCTipCod ;
      private string A185CCDocNum ;
      private string A506CCEstado ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string A189CCCliDsc ;
      private string A306TipAbr ;
      private string A1234MonDsc ;
      private string A2045VenDsc ;
      private string A604DisDsc ;
      private string A596CliDir ;
      private string A618CliRef1 ;
      private string A619CliRef2 ;
      private string A620CliRef3 ;
      private string A621CliRef4 ;
      private string AV12CCCliCod ;
      private string AV20CliDsc ;
      private string AV116DisDsc ;
      private string AV117CliDir ;
      private string AV118CliRef1 ;
      private string AV121CliRef2 ;
      private string AV122CliRef3 ;
      private string AV123CliRef4 ;
      private string AV93TipAbr ;
      private string AV17CCTipCod ;
      private string AV13CCDocNum ;
      private string AV76MonDsc ;
      private string AV39Estado ;
      private string AV112VenDsc ;
      private string AV71LetCBanNum ;
      private string AV11BanAbr ;
      private string GXt_char1 ;
      private string A166CobTip ;
      private string A167CobCod ;
      private string A661CobSts ;
      private string A176CobDocNum ;
      private string A175CobTipCod ;
      private string AV115PedCod ;
      private string AV119DocRef ;
      private string A24DocNum ;
      private string A149TipCod ;
      private string A937DocPedCod ;
      private string A939DocRef ;
      private string AV120TipCDsc ;
      private string A1120LetCTipo ;
      private string A209LetCDocNum ;
      private string A1105LetCBanNum ;
      private string A204LetCLetCod ;
      private string A481BanAbr ;
      private string A2094ZonDsc ;
      private string A1905TipCDsc ;
      private DateTime GXt_dtime4 ;
      private DateTime AV44FHasta ;
      private DateTime A507CCFecUltPago ;
      private DateTime A190CCFech ;
      private DateTime A508CCFVcto ;
      private DateTime AV14CCFech ;
      private DateTime AV15CCFVcto ;
      private DateTime A655CobFec ;
      private DateTime A931DocFVcto ;
      private bool returnInSub ;
      private bool BRK912 ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n141ProvCod ;
      private bool n142DisCod ;
      private bool n306TipAbr ;
      private bool n511TipSigno ;
      private bool n1234MonDsc ;
      private bool n2045VenDsc ;
      private bool n158ZonCod ;
      private bool n159TipCCod ;
      private bool n596CliDir ;
      private bool n618CliRef1 ;
      private bool n619CliRef2 ;
      private bool n620CliRef3 ;
      private bool n621CliRef4 ;
      private bool BRK914 ;
      private bool n209LetCDocNum ;
      private string AV45Filename ;
      private string AV38ErrorMessage ;
      private string AV46FilenameOrigen ;
      private string AV40EstadoLet ;
      private string AV113Zona ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_CliCod ;
      private string aP2_TipCod ;
      private int aP3_MonCod ;
      private DateTime aP4_FHasta ;
      private int aP5_ZonCod ;
      private string aP6_Serie ;
      private short aP7_TipLetras ;
      private int aP8_VenCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00912_A139PaiCod ;
      private bool[] P00912_n139PaiCod ;
      private string[] P00912_A140EstCod ;
      private bool[] P00912_n140EstCod ;
      private string[] P00912_A141ProvCod ;
      private bool[] P00912_n141ProvCod ;
      private string[] P00912_A142DisCod ;
      private bool[] P00912_n142DisCod ;
      private string[] P00912_A189CCCliDsc ;
      private string[] P00912_A306TipAbr ;
      private bool[] P00912_n306TipAbr ;
      private string[] P00912_A185CCDocNum ;
      private DateTime[] P00912_A190CCFech ;
      private short[] P00912_A511TipSigno ;
      private bool[] P00912_n511TipSigno ;
      private decimal[] P00912_A513CCImpTotal ;
      private decimal[] P00912_A509CCImpPago ;
      private int[] P00912_A187CCmonCod ;
      private string[] P00912_A1234MonDsc ;
      private bool[] P00912_n1234MonDsc ;
      private string[] P00912_A506CCEstado ;
      private string[] P00912_A2045VenDsc ;
      private bool[] P00912_n2045VenDsc ;
      private string[] P00912_A184CCTipCod ;
      private DateTime[] P00912_A508CCFVcto ;
      private DateTime[] P00912_A507CCFecUltPago ;
      private int[] P00912_A186CCVendCod ;
      private int[] P00912_A158ZonCod ;
      private bool[] P00912_n158ZonCod ;
      private int[] P00912_A159TipCCod ;
      private bool[] P00912_n159TipCCod ;
      private string[] P00912_A188CCCliCod ;
      private string[] P00912_A604DisDsc ;
      private string[] P00912_A596CliDir ;
      private bool[] P00912_n596CliDir ;
      private string[] P00912_A618CliRef1 ;
      private bool[] P00912_n618CliRef1 ;
      private string[] P00912_A619CliRef2 ;
      private bool[] P00912_n619CliRef2 ;
      private string[] P00912_A620CliRef3 ;
      private bool[] P00912_n620CliRef3 ;
      private string[] P00912_A621CliRef4 ;
      private bool[] P00912_n621CliRef4 ;
      private string[] P00913_A139PaiCod ;
      private bool[] P00913_n139PaiCod ;
      private string[] P00913_A140EstCod ;
      private bool[] P00913_n140EstCod ;
      private string[] P00913_A141ProvCod ;
      private bool[] P00913_n141ProvCod ;
      private string[] P00913_A142DisCod ;
      private bool[] P00913_n142DisCod ;
      private string[] P00913_A189CCCliDsc ;
      private string[] P00913_A306TipAbr ;
      private bool[] P00913_n306TipAbr ;
      private string[] P00913_A185CCDocNum ;
      private DateTime[] P00913_A190CCFech ;
      private int[] P00913_A187CCmonCod ;
      private string[] P00913_A1234MonDsc ;
      private bool[] P00913_n1234MonDsc ;
      private short[] P00913_A511TipSigno ;
      private bool[] P00913_n511TipSigno ;
      private decimal[] P00913_A513CCImpTotal ;
      private decimal[] P00913_A509CCImpPago ;
      private string[] P00913_A506CCEstado ;
      private string[] P00913_A2045VenDsc ;
      private bool[] P00913_n2045VenDsc ;
      private string[] P00913_A184CCTipCod ;
      private DateTime[] P00913_A508CCFVcto ;
      private int[] P00913_A186CCVendCod ;
      private int[] P00913_A158ZonCod ;
      private bool[] P00913_n158ZonCod ;
      private int[] P00913_A159TipCCod ;
      private bool[] P00913_n159TipCCod ;
      private string[] P00913_A188CCCliCod ;
      private string[] P00913_A604DisDsc ;
      private string[] P00913_A596CliDir ;
      private bool[] P00913_n596CliDir ;
      private string[] P00913_A618CliRef1 ;
      private bool[] P00913_n618CliRef1 ;
      private string[] P00913_A619CliRef2 ;
      private bool[] P00913_n619CliRef2 ;
      private string[] P00913_A620CliRef3 ;
      private bool[] P00913_n620CliRef3 ;
      private string[] P00913_A621CliRef4 ;
      private bool[] P00913_n621CliRef4 ;
      private string[] P00914_A166CobTip ;
      private string[] P00914_A167CobCod ;
      private string[] P00914_A661CobSts ;
      private DateTime[] P00914_A655CobFec ;
      private string[] P00914_A176CobDocNum ;
      private string[] P00914_A175CobTipCod ;
      private int[] P00914_A172CobMon ;
      private decimal[] P00914_A654CobDTot ;
      private decimal[] P00914_A663CobTipCam ;
      private int[] P00914_A173Item ;
      private string[] P00915_A506CCEstado ;
      private string[] P00915_A185CCDocNum ;
      private DateTime[] P00915_A190CCFech ;
      private DateTime[] P00915_A507CCFecUltPago ;
      private int[] P00915_A186CCVendCod ;
      private int[] P00915_A158ZonCod ;
      private bool[] P00915_n158ZonCod ;
      private string[] P00915_A184CCTipCod ;
      private int[] P00915_A187CCmonCod ;
      private int[] P00915_A159TipCCod ;
      private bool[] P00915_n159TipCCod ;
      private string[] P00915_A188CCCliCod ;
      private decimal[] P00915_A513CCImpTotal ;
      private decimal[] P00915_A509CCImpPago ;
      private short[] P00915_A511TipSigno ;
      private bool[] P00915_n511TipSigno ;
      private string[] P00916_A24DocNum ;
      private string[] P00916_A149TipCod ;
      private DateTime[] P00916_A931DocFVcto ;
      private string[] P00916_A937DocPedCod ;
      private string[] P00916_A939DocRef ;
      private string[] P00917_A1120LetCTipo ;
      private string[] P00917_A209LetCDocNum ;
      private bool[] P00917_n209LetCDocNum ;
      private string[] P00917_A1105LetCBanNum ;
      private int[] P00917_A1116LetCSec ;
      private int[] P00917_A1104LetCBanCod ;
      private string[] P00917_A204LetCLetCod ;
      private int[] P00917_A207LetCItem ;
      private int[] P00918_A372BanCod ;
      private string[] P00918_A481BanAbr ;
      private int[] P00919_A158ZonCod ;
      private bool[] P00919_n158ZonCod ;
      private string[] P00919_A2094ZonDsc ;
      private int[] P009110_A159TipCCod ;
      private bool[] P009110_n159TipCCod ;
      private string[] P009110_A1905TipCDsc ;
      private string aP9_Filename ;
      private string aP10_ErrorMessage ;
      private ExcelDocumentI AV41ExcelDocument ;
      private GxFile AV10Archivo ;
   }

   public class pcuentacorrienteexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00912( IGxContext context ,
                                             string AV19CliCod ,
                                             int AV94TipCCod ,
                                             int AV75MonCod ,
                                             string AV96TipCod ,
                                             int AV114ZonCod ,
                                             int AV111VenCod ,
                                             short AV97TipLetras ,
                                             string AV89Serie ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV44FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T5.[PaiCod], T5.[EstCod], T5.[ProvCod], T5.[DisCod], T1.[CCCliDsc], T3.[TipAbr], T1.[CCDocNum], T1.[CCFech], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T1.[CCEstado], T4.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCFVcto], T1.[CCFecUltPago], T1.[CCVendCod] AS CCVendCod, T5.[ZonCod], T5.[TipCCod], T1.[CCCliCod] AS CCCliCod, T6.[DisDsc], T5.[CliDir], T5.[CliRef1], T5.[CliRef2], T5.[CliRef3], T5.[CliRef4] FROM ((((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = T1.[CCVendCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CDISTRITOS] T6 ON T6.[PaiCod] = T5.[PaiCod] AND T6.[EstCod] = T5.[EstCod] AND T6.[ProvCod] = T5.[ProvCod] AND T6.[DisCod] = T5.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV44FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV44FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV19CliCod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV94TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV94TipCCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! (0==AV75MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV75MonCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV96TipCod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV114ZonCod) )
         {
            AddWhere(sWhereString, "(T5.[ZonCod] = @AV114ZonCod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV111VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV111VenCod)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (0==AV97TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV89Serie)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFVcto], T1.[CCTipCod]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00913( IGxContext context ,
                                             string AV19CliCod ,
                                             int AV94TipCCod ,
                                             int AV75MonCod ,
                                             string AV96TipCod ,
                                             int AV114ZonCod ,
                                             int AV111VenCod ,
                                             short AV97TipLetras ,
                                             string AV89Serie ,
                                             string A188CCCliCod ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             string A506CCEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[7];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T5.[PaiCod], T5.[EstCod], T5.[ProvCod], T5.[DisCod], T1.[CCCliDsc], T3.[TipAbr], T1.[CCDocNum], T1.[CCFech], T1.[CCmonCod] AS CCmonCod, T2.[MonDsc], T3.[TipSigno], T1.[CCImpTotal], T1.[CCImpPago], T1.[CCEstado], T4.[VenDsc], T1.[CCTipCod] AS CCTipCod, T1.[CCFVcto], T1.[CCVendCod] AS CCVendCod, T5.[ZonCod], T5.[TipCCod], T1.[CCCliCod] AS CCCliCod, T6.[DisDsc], T5.[CliDir], T5.[CliRef1], T5.[CliRef2], T5.[CliRef3], T5.[CliRef4] FROM ((((([CLCUENTACOBRAR] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[CCmonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[CCTipCod]) INNER JOIN [CVENDEDORES] T4 ON T4.[VenCod] = T1.[CCVendCod]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[CCCliCod]) LEFT JOIN [CDISTRITOS] T6 ON T6.[PaiCod] = T5.[PaiCod] AND T6.[EstCod] = T5.[EstCod] AND T6.[ProvCod] = T5.[ProvCod] AND T6.[DisCod] = T5.[DisCod])";
         AddWhere(sWhereString, "(T1.[CCEstado] = '')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCCliCod] = @AV19CliCod)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV94TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV94TipCCod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (0==AV75MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV75MonCod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV96TipCod)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV114ZonCod) )
         {
            AddWhere(sWhereString, "(T5.[ZonCod] = @AV114ZonCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV111VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV111VenCod)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV97TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV89Serie)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCCliDsc], T1.[CCFVcto], T1.[CCTipCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00915( IGxContext context ,
                                             int AV94TipCCod ,
                                             int AV75MonCod ,
                                             string AV96TipCod ,
                                             int AV114ZonCod ,
                                             int AV111VenCod ,
                                             short AV97TipLetras ,
                                             string AV89Serie ,
                                             int A159TipCCod ,
                                             int A187CCmonCod ,
                                             string A184CCTipCod ,
                                             int A158ZonCod ,
                                             int A186CCVendCod ,
                                             string A185CCDocNum ,
                                             DateTime A507CCFecUltPago ,
                                             DateTime AV44FHasta ,
                                             DateTime A190CCFech ,
                                             string A506CCEstado ,
                                             string A188CCCliCod ,
                                             string AV12CCCliCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[9];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[CCEstado], T1.[CCDocNum], T1.[CCFech], T1.[CCFecUltPago], T1.[CCVendCod] AS CCVendCod, T3.[ZonCod], T1.[CCTipCod] AS CCTipCod, T1.[CCmonCod] AS CCmonCod, T3.[TipCCod], T1.[CCCliCod] AS CCCliCod, T1.[CCImpTotal], T1.[CCImpPago], T2.[TipSigno] FROM (([CLCUENTACOBRAR] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[CCTipCod]) INNER JOIN [CLCLIENTES] T3 ON T3.[CliCod] = T1.[CCCliCod])";
         AddWhere(sWhereString, "(T1.[CCFecUltPago] > @AV44FHasta or (T1.[CCFecUltPago] = convert( DATETIME, '17530101', 112 )))");
         AddWhere(sWhereString, "(T1.[CCFech] <= @AV44FHasta)");
         AddWhere(sWhereString, "(T1.[CCEstado] <> 'A')");
         AddWhere(sWhereString, "(T1.[CCCliCod] = @AV12CCCliCod)");
         if ( ! (0==AV94TipCCod) )
         {
            AddWhere(sWhereString, "(T3.[TipCCod] = @AV94TipCCod)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV75MonCod) )
         {
            AddWhere(sWhereString, "(T1.[CCmonCod] = @AV75MonCod)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] = @AV96TipCod)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (0==AV114ZonCod) )
         {
            AddWhere(sWhereString, "(T3.[ZonCod] = @AV114ZonCod)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! (0==AV111VenCod) )
         {
            AddWhere(sWhereString, "(T1.[CCVendCod] = @AV111VenCod)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! (0==AV97TipLetras) )
         {
            AddWhere(sWhereString, "(T1.[CCTipCod] <> 'LET')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[CCDocNum], 1, 3) = @AV89Serie)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CCTipCod], T1.[CCDocNum]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00912(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] );
               case 1 :
                     return conditional_P00913(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] );
               case 3 :
                     return conditional_P00915(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] );
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
          Object[] prmP00914;
          prmP00914 = new Object[] {
          new ParDef("@AV17CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13CCDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV44FHasta",GXType.Date,8,0)
          };
          Object[] prmP00916;
          prmP00916 = new Object[] {
          new ParDef("@AV17CCTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV13CCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00917;
          prmP00917 = new Object[] {
          new ParDef("@AV13CCDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00918;
          prmP00918 = new Object[] {
          new ParDef("@AV70LetCBanCod",GXType.Int32,6,0)
          };
          Object[] prmP00919;
          prmP00919 = new Object[] {
          new ParDef("@AV114ZonCod",GXType.Int32,6,0)
          };
          Object[] prmP009110;
          prmP009110 = new Object[] {
          new ParDef("@AV94TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00912;
          prmP00912 = new Object[] {
          new ParDef("@AV44FHasta",GXType.Date,8,0) ,
          new ParDef("@AV44FHasta",GXType.Date,8,0) ,
          new ParDef("@AV19CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV94TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV75MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV114ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV111VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV89Serie",GXType.Char,3,0)
          };
          Object[] prmP00913;
          prmP00913 = new Object[] {
          new ParDef("@AV19CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV94TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV75MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV114ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV111VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV89Serie",GXType.Char,3,0)
          };
          Object[] prmP00915;
          prmP00915 = new Object[] {
          new ParDef("@AV44FHasta",GXType.Date,8,0) ,
          new ParDef("@AV44FHasta",GXType.Date,8,0) ,
          new ParDef("@AV12CCCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV94TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV75MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV96TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV114ZonCod",GXType.Int32,6,0) ,
          new ParDef("@AV111VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV89Serie",GXType.Char,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00912", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00912,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00913", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00913,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00914", "SELECT T1.[CobTip], T1.[CobCod], T2.[CobSts], T2.[CobFec], T1.[CobDocNum], T1.[CobTipCod], T2.[CobMon], T1.[CobDTot], T1.[CobTipCam], T1.[Item] FROM ([CLCOBRANZADET] T1 INNER JOIN [CLCOBRANZA] T2 ON T2.[CobTip] = T1.[CobTip] AND T2.[CobCod] = T1.[CobCod]) WHERE (T1.[CobTipCod] = @AV17CCTipCod and T1.[CobDocNum] = @AV13CCDocNum) AND (T2.[CobFec] > @AV44FHasta) AND (T2.[CobSts] <> 'A') ORDER BY T1.[CobTipCod], T1.[CobDocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00914,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00915", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00915,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00916", "SELECT [DocNum], [TipCod], [DocFVcto], [DocPedCod], [DocRef] FROM [CLVENTAS] WHERE [TipCod] = @AV17CCTipCod and [DocNum] = @AV13CCDocNum ORDER BY [TipCod], [DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00916,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00917", "SELECT [LetCTipo], [LetCDocNum], [LetCBanNum], [LetCSec], [LetCBanCod], [LetCLetCod], [LetCItem] FROM [CLLETRASDET] WHERE ([LetCDocNum] = @AV13CCDocNum) AND ([LetCTipo] = 'L') ORDER BY [LetCLetCod], [LetCItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00917,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00918", "SELECT [BanCod], [BanAbr] FROM [TSBANCOS] WHERE [BanCod] = @AV70LetCBanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00918,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00919", "SELECT [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV114ZonCod ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00919,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009110", "SELECT [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV94TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009110,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[8])[0] = rslt.getString(5, 100);
                ((string[]) buf[9])[0] = rslt.getString(6, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
                ((short[]) buf[13])[0] = rslt.getShort(9);
                ((bool[]) buf[14])[0] = rslt.wasNull(9);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(11);
                ((int[]) buf[17])[0] = rslt.getInt(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 100);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 1);
                ((string[]) buf[21])[0] = rslt.getString(15, 100);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((string[]) buf[23])[0] = rslt.getString(16, 3);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(18);
                ((int[]) buf[26])[0] = rslt.getInt(19);
                ((int[]) buf[27])[0] = rslt.getInt(20);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((int[]) buf[29])[0] = rslt.getInt(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((string[]) buf[31])[0] = rslt.getString(22, 20);
                ((string[]) buf[32])[0] = rslt.getString(23, 100);
                ((string[]) buf[33])[0] = rslt.getString(24, 100);
                ((bool[]) buf[34])[0] = rslt.wasNull(24);
                ((string[]) buf[35])[0] = rslt.getString(25, 50);
                ((bool[]) buf[36])[0] = rslt.wasNull(25);
                ((string[]) buf[37])[0] = rslt.getString(26, 50);
                ((bool[]) buf[38])[0] = rslt.wasNull(26);
                ((string[]) buf[39])[0] = rslt.getString(27, 50);
                ((bool[]) buf[40])[0] = rslt.wasNull(27);
                ((string[]) buf[41])[0] = rslt.getString(28, 50);
                ((bool[]) buf[42])[0] = rslt.wasNull(28);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 4);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 4);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 100);
                ((string[]) buf[9])[0] = rslt.getString(6, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getString(7, 12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
                ((int[]) buf[13])[0] = rslt.getInt(9);
                ((string[]) buf[14])[0] = rslt.getString(10, 100);
                ((bool[]) buf[15])[0] = rslt.wasNull(10);
                ((short[]) buf[16])[0] = rslt.getShort(11);
                ((bool[]) buf[17])[0] = rslt.wasNull(11);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 1);
                ((string[]) buf[21])[0] = rslt.getString(15, 100);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((string[]) buf[23])[0] = rslt.getString(16, 3);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(17);
                ((int[]) buf[25])[0] = rslt.getInt(18);
                ((int[]) buf[26])[0] = rslt.getInt(19);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((int[]) buf[28])[0] = rslt.getInt(20);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 20);
                ((string[]) buf[31])[0] = rslt.getString(22, 100);
                ((string[]) buf[32])[0] = rslt.getString(23, 100);
                ((bool[]) buf[33])[0] = rslt.wasNull(23);
                ((string[]) buf[34])[0] = rslt.getString(24, 50);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((string[]) buf[36])[0] = rslt.getString(25, 50);
                ((bool[]) buf[37])[0] = rslt.wasNull(25);
                ((string[]) buf[38])[0] = rslt.getString(26, 50);
                ((bool[]) buf[39])[0] = rslt.wasNull(26);
                ((string[]) buf[40])[0] = rslt.getString(27, 50);
                ((bool[]) buf[41])[0] = rslt.wasNull(27);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((int[]) buf[9])[0] = rslt.getInt(10);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((int[]) buf[9])[0] = rslt.getInt(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((short[]) buf[14])[0] = rslt.getShort(13);
                ((bool[]) buf[15])[0] = rslt.wasNull(13);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 12);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 10);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
