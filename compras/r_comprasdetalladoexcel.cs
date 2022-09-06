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
namespace GeneXus.Programs.compras {
   public class r_comprasdetalladoexcel : GXProcedure
   {
      public r_comprasdetalladoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprasdetalladoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CueCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_PrvCod ,
                           ref int aP3_MonCod ,
                           ref DateTime aP4_Fdesde ,
                           ref DateTime aP5_Fhasta ,
                           out string aP6_Filename ,
                           out string aP7_ErrorMessage )
      {
         this.AV77CueCod = aP0_CueCod;
         this.AV78ProdCod = aP1_ProdCod;
         this.AV39PrvCod = aP2_PrvCod;
         this.AV61MonCod = aP3_MonCod;
         this.AV79Fdesde = aP4_Fdesde;
         this.AV80Fhasta = aP5_Fhasta;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_CueCod=this.AV77CueCod;
         aP1_ProdCod=this.AV78ProdCod;
         aP2_PrvCod=this.AV39PrvCod;
         aP3_MonCod=this.AV61MonCod;
         aP4_Fdesde=this.AV79Fdesde;
         aP5_Fhasta=this.AV80Fhasta;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_CueCod ,
                                ref string aP1_ProdCod ,
                                ref string aP2_PrvCod ,
                                ref int aP3_MonCod ,
                                ref DateTime aP4_Fdesde ,
                                ref DateTime aP5_Fhasta ,
                                out string aP6_Filename )
      {
         execute(ref aP0_CueCod, ref aP1_ProdCod, ref aP2_PrvCod, ref aP3_MonCod, ref aP4_Fdesde, ref aP5_Fhasta, out aP6_Filename, out aP7_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_CueCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_PrvCod ,
                                 ref int aP3_MonCod ,
                                 ref DateTime aP4_Fdesde ,
                                 ref DateTime aP5_Fhasta ,
                                 out string aP6_Filename ,
                                 out string aP7_ErrorMessage )
      {
         r_comprasdetalladoexcel objr_comprasdetalladoexcel;
         objr_comprasdetalladoexcel = new r_comprasdetalladoexcel();
         objr_comprasdetalladoexcel.AV77CueCod = aP0_CueCod;
         objr_comprasdetalladoexcel.AV78ProdCod = aP1_ProdCod;
         objr_comprasdetalladoexcel.AV39PrvCod = aP2_PrvCod;
         objr_comprasdetalladoexcel.AV61MonCod = aP3_MonCod;
         objr_comprasdetalladoexcel.AV79Fdesde = aP4_Fdesde;
         objr_comprasdetalladoexcel.AV80Fhasta = aP5_Fhasta;
         objr_comprasdetalladoexcel.AV10Filename = "" ;
         objr_comprasdetalladoexcel.AV11ErrorMessage = "" ;
         objr_comprasdetalladoexcel.context.SetSubmitInitialConfig(context);
         objr_comprasdetalladoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprasdetalladoexcel);
         aP0_CueCod=this.AV77CueCod;
         aP1_ProdCod=this.AV78ProdCod;
         aP2_PrvCod=this.AV39PrvCod;
         aP3_MonCod=this.AV61MonCod;
         aP4_Fdesde=this.AV79Fdesde;
         aP5_Fhasta=this.AV80Fhasta;
         aP6_Filename=this.AV10Filename;
         aP7_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprasdetalladoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasComprasDetallado.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasComprasDetallado.xlsx";
         AV10Filename = "Excel/ComprasDetallado" + ".xlsx";
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39PrvCod ,
                                              AV61MonCod ,
                                              AV78ProdCod ,
                                              AV77CueCod ,
                                              A244PrvCod ,
                                              A246ComMon ,
                                              A254ComDProCod ,
                                              A253ComDCueCod ,
                                              A707ComFReg ,
                                              AV79Fdesde ,
                                              AV80Fhasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00AV2 */
         pr_default.execute(0, new Object[] {AV79Fdesde, AV80Fhasta, AV39PrvCod, AV61MonCod, AV78ProdCod, AV77CueCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A245ComConpCod = P00AV2_A245ComConpCod[0];
            A253ComDCueCod = P00AV2_A253ComDCueCod[0];
            n253ComDCueCod = P00AV2_n253ComDCueCod[0];
            A254ComDProCod = P00AV2_A254ComDProCod[0];
            n254ComDProCod = P00AV2_n254ComDProCod[0];
            A246ComMon = P00AV2_A246ComMon[0];
            A707ComFReg = P00AV2_A707ComFReg[0];
            A244PrvCod = P00AV2_A244PrvCod[0];
            A149TipCod = P00AV2_A149TipCod[0];
            A1233MonAbr = P00AV2_A1233MonAbr[0];
            n1233MonAbr = P00AV2_n1233MonAbr[0];
            A247PrvDsc = P00AV2_A247PrvDsc[0];
            A306TipAbr = P00AV2_A306TipAbr[0];
            A243ComCod = P00AV2_A243ComCod[0];
            A249ComRef = P00AV2_A249ComRef[0];
            A694ComDDsc = P00AV2_A694ComDDsc[0];
            A511TipSigno = P00AV2_A511TipSigno[0];
            A251ComDOrdCod = P00AV2_A251ComDOrdCod[0];
            A753ConpDsc = P00AV2_A753ConpDsc[0];
            n753ConpDsc = P00AV2_n753ConpDsc[0];
            A252ComCosCod = P00AV2_A252ComCosCod[0];
            n252ComCosCod = P00AV2_n252ComCosCod[0];
            A710ComImpCod = P00AV2_A710ComImpCod[0];
            A248ComFec = P00AV2_A248ComFec[0];
            A689ComDDct = P00AV2_A689ComDDct[0];
            A690ComDTip = P00AV2_A690ComDTip[0];
            A686ComDPre = P00AV2_A686ComDPre[0];
            A685ComDCant = P00AV2_A685ComDCant[0];
            A250ComDItem = P00AV2_A250ComDItem[0];
            A306TipAbr = P00AV2_A306TipAbr[0];
            A511TipSigno = P00AV2_A511TipSigno[0];
            A245ComConpCod = P00AV2_A245ComConpCod[0];
            A246ComMon = P00AV2_A246ComMon[0];
            A707ComFReg = P00AV2_A707ComFReg[0];
            A247PrvDsc = P00AV2_A247PrvDsc[0];
            A249ComRef = P00AV2_A249ComRef[0];
            A710ComImpCod = P00AV2_A710ComImpCod[0];
            A248ComFec = P00AV2_A248ComFec[0];
            A753ConpDsc = P00AV2_A753ConpDsc[0];
            n753ConpDsc = P00AV2_n753ConpDsc[0];
            A1233MonAbr = P00AV2_A1233MonAbr[0];
            n1233MonAbr = P00AV2_n1233MonAbr[0];
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            if ( A690ComDTip == 1 )
            {
               A696ComDIna = A684ComDTot;
            }
            else
            {
               A696ComDIna = 0;
            }
            if ( A690ComDTip == 0 )
            {
               A683ComDAfe = A684ComDTot;
            }
            else
            {
               A683ComDAfe = 0;
            }
            AV38DocFec = A248ComFec;
            AV82DocMonCod = A246ComMon;
            AV60TipCod = A149TipCod;
            AV53MonAbr = A1233MonAbr;
            AV81Codigo = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? A253ComDCueCod : A254ComDProCod);
            AV39PrvCod = A244PrvCod;
            AV40PrvDsc = A247PrvDsc;
            AV88TipAbr = A306TipAbr;
            AV89ComCod = A243ComCod;
            AV69ComRef = StringUtil.Trim( A249ComRef);
            AV83ProdDsc = StringUtil.Trim( A694ComDDsc);
            AV84ComDCant = (decimal)(A685ComDCant*A511TipSigno);
            AV85ComDSub = (decimal)(A688ComDSub*A511TipSigno);
            AV86ComDOrdCod = A251ComDOrdCod;
            AV87ConpDsc = A753ConpDsc;
            AV91Afecto = (decimal)(A683ComDAfe*A511TipSigno);
            AV92InaFecto = (decimal)(A696ComDIna*A511TipSigno);
            AV93ComCosCod = A252ComCosCod;
            AV95ComImpCod = A710ComImpCod;
            /* Execute user subroutine: 'VALIDAPAGO' */
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV38DocFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV39PrvCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV40PrvDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV88TipAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV89ComCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV69ComRef);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV53MonAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV81Codigo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV83ProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV84ComDCant);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV85ComDSub);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Text = AV86ComDOrdCod;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+12, 1, 1).Text = AV87ConpDsc;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+13, 1, 1).Text = StringUtil.Trim( AV90FormaPago);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+14, 1, 1).Text = StringUtil.Trim( AV94CosDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+15, 1, 1).Number = (double)(AV91Afecto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+16, 1, 1).Number = (double)(AV92InaFecto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+17, 1, 1).Text = StringUtil.Trim( AV95ComImpCod);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S131( )
      {
         /* 'VALIDAPAGO' Routine */
         returnInSub = false;
         AV90FormaPago = "PENDIENTE";
         AV94CosDsc = "";
         /* Using cursor P00AV3 */
         pr_default.execute(1, new Object[] {AV60TipCod, AV89ComCod, AV39PrvCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A412PagReg = P00AV3_A412PagReg[0];
            A416PagForCod = P00AV3_A416PagForCod[0];
            A421PagDComCod = P00AV3_A421PagDComCod[0];
            A420PagDTipCod = P00AV3_A420PagDTipCod[0];
            A417PagPrvCod = P00AV3_A417PagPrvCod[0];
            A1485PagForDsc = P00AV3_A1485PagForDsc[0];
            A419PagItem = P00AV3_A419PagItem[0];
            A416PagForCod = P00AV3_A416PagForCod[0];
            A417PagPrvCod = P00AV3_A417PagPrvCod[0];
            A1485PagForDsc = P00AV3_A1485PagForDsc[0];
            AV90FormaPago = StringUtil.Trim( A1485PagForDsc);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00AV4 */
         pr_default.execute(2, new Object[] {AV93ComCosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A79COSCod = P00AV4_A79COSCod[0];
            A761COSDsc = P00AV4_A761COSDsc[0];
            AV94CosDsc = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         A244PrvCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A707ComFReg = DateTime.MinValue;
         P00AV2_A245ComConpCod = new int[1] ;
         P00AV2_A253ComDCueCod = new string[] {""} ;
         P00AV2_n253ComDCueCod = new bool[] {false} ;
         P00AV2_A254ComDProCod = new string[] {""} ;
         P00AV2_n254ComDProCod = new bool[] {false} ;
         P00AV2_A246ComMon = new int[1] ;
         P00AV2_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P00AV2_A244PrvCod = new string[] {""} ;
         P00AV2_A149TipCod = new string[] {""} ;
         P00AV2_A1233MonAbr = new string[] {""} ;
         P00AV2_n1233MonAbr = new bool[] {false} ;
         P00AV2_A247PrvDsc = new string[] {""} ;
         P00AV2_A306TipAbr = new string[] {""} ;
         P00AV2_A243ComCod = new string[] {""} ;
         P00AV2_A249ComRef = new string[] {""} ;
         P00AV2_A694ComDDsc = new string[] {""} ;
         P00AV2_A511TipSigno = new short[1] ;
         P00AV2_A251ComDOrdCod = new string[] {""} ;
         P00AV2_A753ConpDsc = new string[] {""} ;
         P00AV2_n753ConpDsc = new bool[] {false} ;
         P00AV2_A252ComCosCod = new string[] {""} ;
         P00AV2_n252ComCosCod = new bool[] {false} ;
         P00AV2_A710ComImpCod = new string[] {""} ;
         P00AV2_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00AV2_A689ComDDct = new decimal[1] ;
         P00AV2_A690ComDTip = new short[1] ;
         P00AV2_A686ComDPre = new decimal[1] ;
         P00AV2_A685ComDCant = new decimal[1] ;
         P00AV2_A250ComDItem = new short[1] ;
         A149TipCod = "";
         A1233MonAbr = "";
         A247PrvDsc = "";
         A306TipAbr = "";
         A243ComCod = "";
         A249ComRef = "";
         A694ComDDsc = "";
         A251ComDOrdCod = "";
         A753ConpDsc = "";
         A252ComCosCod = "";
         A710ComImpCod = "";
         A248ComFec = DateTime.MinValue;
         AV38DocFec = DateTime.MinValue;
         AV60TipCod = "";
         AV53MonAbr = "";
         AV81Codigo = "";
         AV40PrvDsc = "";
         AV88TipAbr = "";
         AV89ComCod = "";
         AV69ComRef = "";
         AV83ProdDsc = "";
         AV86ComDOrdCod = "";
         AV87ConpDsc = "";
         AV93ComCosCod = "";
         AV95ComImpCod = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV90FormaPago = "";
         AV94CosDsc = "";
         P00AV3_A412PagReg = new long[1] ;
         P00AV3_A416PagForCod = new int[1] ;
         P00AV3_A421PagDComCod = new string[] {""} ;
         P00AV3_A420PagDTipCod = new string[] {""} ;
         P00AV3_A417PagPrvCod = new string[] {""} ;
         P00AV3_A1485PagForDsc = new string[] {""} ;
         P00AV3_A419PagItem = new short[1] ;
         A421PagDComCod = "";
         A420PagDTipCod = "";
         A417PagPrvCod = "";
         A1485PagForDsc = "";
         P00AV4_A79COSCod = new string[] {""} ;
         P00AV4_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_comprasdetalladoexcel__default(),
            new Object[][] {
                new Object[] {
               P00AV2_A245ComConpCod, P00AV2_A253ComDCueCod, P00AV2_n253ComDCueCod, P00AV2_A254ComDProCod, P00AV2_n254ComDProCod, P00AV2_A246ComMon, P00AV2_A707ComFReg, P00AV2_A244PrvCod, P00AV2_A149TipCod, P00AV2_A1233MonAbr,
               P00AV2_n1233MonAbr, P00AV2_A247PrvDsc, P00AV2_A306TipAbr, P00AV2_A243ComCod, P00AV2_A249ComRef, P00AV2_A694ComDDsc, P00AV2_A511TipSigno, P00AV2_A251ComDOrdCod, P00AV2_A753ConpDsc, P00AV2_n753ConpDsc,
               P00AV2_A252ComCosCod, P00AV2_n252ComCosCod, P00AV2_A710ComImpCod, P00AV2_A248ComFec, P00AV2_A689ComDDct, P00AV2_A690ComDTip, P00AV2_A686ComDPre, P00AV2_A685ComDCant, P00AV2_A250ComDItem
               }
               , new Object[] {
               P00AV3_A412PagReg, P00AV3_A416PagForCod, P00AV3_A421PagDComCod, P00AV3_A420PagDTipCod, P00AV3_A417PagPrvCod, P00AV3_A1485PagForDsc, P00AV3_A419PagItem
               }
               , new Object[] {
               P00AV4_A79COSCod, P00AV4_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A511TipSigno ;
      private short A690ComDTip ;
      private short A250ComDItem ;
      private short A419PagItem ;
      private int AV61MonCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A246ComMon ;
      private int A245ComConpCod ;
      private int AV82DocMonCod ;
      private int A416PagForCod ;
      private long A412PagReg ;
      private decimal A689ComDDct ;
      private decimal A686ComDPre ;
      private decimal A685ComDCant ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal A696ComDIna ;
      private decimal A683ComDAfe ;
      private decimal AV84ComDCant ;
      private decimal AV85ComDSub ;
      private decimal AV91Afecto ;
      private decimal AV92InaFecto ;
      private string AV77CueCod ;
      private string AV78ProdCod ;
      private string AV39PrvCod ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A247PrvDsc ;
      private string A306TipAbr ;
      private string A243ComCod ;
      private string A249ComRef ;
      private string A694ComDDsc ;
      private string A251ComDOrdCod ;
      private string A753ConpDsc ;
      private string A252ComCosCod ;
      private string A710ComImpCod ;
      private string AV60TipCod ;
      private string AV53MonAbr ;
      private string AV81Codigo ;
      private string AV40PrvDsc ;
      private string AV88TipAbr ;
      private string AV89ComCod ;
      private string AV69ComRef ;
      private string AV83ProdDsc ;
      private string AV86ComDOrdCod ;
      private string AV87ConpDsc ;
      private string AV93ComCosCod ;
      private string AV95ComImpCod ;
      private string AV90FormaPago ;
      private string AV94CosDsc ;
      private string A421PagDComCod ;
      private string A420PagDTipCod ;
      private string A417PagPrvCod ;
      private string A1485PagForDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV79Fdesde ;
      private DateTime AV80Fhasta ;
      private DateTime A707ComFReg ;
      private DateTime A248ComFec ;
      private DateTime AV38DocFec ;
      private bool returnInSub ;
      private bool n253ComDCueCod ;
      private bool n254ComDProCod ;
      private bool n1233MonAbr ;
      private bool n753ConpDsc ;
      private bool n252ComCosCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CueCod ;
      private string aP1_ProdCod ;
      private string aP2_PrvCod ;
      private int aP3_MonCod ;
      private DateTime aP4_Fdesde ;
      private DateTime aP5_Fhasta ;
      private IDataStoreProvider pr_default ;
      private int[] P00AV2_A245ComConpCod ;
      private string[] P00AV2_A253ComDCueCod ;
      private bool[] P00AV2_n253ComDCueCod ;
      private string[] P00AV2_A254ComDProCod ;
      private bool[] P00AV2_n254ComDProCod ;
      private int[] P00AV2_A246ComMon ;
      private DateTime[] P00AV2_A707ComFReg ;
      private string[] P00AV2_A244PrvCod ;
      private string[] P00AV2_A149TipCod ;
      private string[] P00AV2_A1233MonAbr ;
      private bool[] P00AV2_n1233MonAbr ;
      private string[] P00AV2_A247PrvDsc ;
      private string[] P00AV2_A306TipAbr ;
      private string[] P00AV2_A243ComCod ;
      private string[] P00AV2_A249ComRef ;
      private string[] P00AV2_A694ComDDsc ;
      private short[] P00AV2_A511TipSigno ;
      private string[] P00AV2_A251ComDOrdCod ;
      private string[] P00AV2_A753ConpDsc ;
      private bool[] P00AV2_n753ConpDsc ;
      private string[] P00AV2_A252ComCosCod ;
      private bool[] P00AV2_n252ComCosCod ;
      private string[] P00AV2_A710ComImpCod ;
      private DateTime[] P00AV2_A248ComFec ;
      private decimal[] P00AV2_A689ComDDct ;
      private short[] P00AV2_A690ComDTip ;
      private decimal[] P00AV2_A686ComDPre ;
      private decimal[] P00AV2_A685ComDCant ;
      private short[] P00AV2_A250ComDItem ;
      private long[] P00AV3_A412PagReg ;
      private int[] P00AV3_A416PagForCod ;
      private string[] P00AV3_A421PagDComCod ;
      private string[] P00AV3_A420PagDTipCod ;
      private string[] P00AV3_A417PagPrvCod ;
      private string[] P00AV3_A1485PagForDsc ;
      private short[] P00AV3_A419PagItem ;
      private string[] P00AV4_A79COSCod ;
      private string[] P00AV4_A761COSDsc ;
      private string aP6_Filename ;
      private string aP7_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_comprasdetalladoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AV2( IGxContext context ,
                                             string AV39PrvCod ,
                                             int AV61MonCod ,
                                             string AV78ProdCod ,
                                             string AV77CueCod ,
                                             string A244PrvCod ,
                                             int A246ComMon ,
                                             string A254ComDProCod ,
                                             string A253ComDCueCod ,
                                             DateTime A707ComFReg ,
                                             DateTime AV79Fdesde ,
                                             DateTime AV80Fhasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[ComConpCod] AS ComConpCod, T1.[ComDCueCod], T1.[ComDProCod], T3.[ComMon] AS ComMon, T3.[ComFReg], T1.[PrvCod], T1.[TipCod], T5.[MonAbr], T3.[PrvDsc], T2.[TipAbr], T1.[ComCod], T3.[ComRef], T1.[ComDDsc], T2.[TipSigno], T1.[ComDOrdCod], T4.[ConpDsc], T1.[ComCosCod], T3.[ComImpCod], T3.[ComFec], T1.[ComDDct], T1.[ComDTip], T1.[ComDPre], T1.[ComDCant], T1.[ComDItem] FROM (((([CPCOMPRASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CPCOMPRAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[ComCod] = T1.[ComCod] AND T3.[PrvCod] = T1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T4 ON T4.[Conpcod] = T3.[ComConpCod]) INNER JOIN [CMONEDAS] T5 ON T5.[MonCod] = T3.[ComMon])";
         AddWhere(sWhereString, "(T3.[ComFReg] >= @AV79Fdesde and T3.[ComFReg] <= @AV80Fhasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39PrvCod)) )
         {
            AddWhere(sWhereString, "(T1.[PrvCod] = @AV39PrvCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV61MonCod) )
         {
            AddWhere(sWhereString, "(T3.[ComMon] = @AV61MonCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78ProdCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDProCod] = @AV78ProdCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77CueCod)) )
         {
            AddWhere(sWhereString, "(T1.[ComDCueCod] = @AV77CueCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ComFec]";
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
                     return conditional_P00AV2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AV3;
          prmP00AV3 = new Object[] {
          new ParDef("@AV60TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV89ComCod",GXType.NChar,15,0) ,
          new ParDef("@AV39PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP00AV4;
          prmP00AV4 = new Object[] {
          new ParDef("@AV93ComCosCod",GXType.NChar,10,0)
          };
          Object[] prmP00AV2;
          prmP00AV2 = new Object[] {
          new ParDef("@AV79Fdesde",GXType.Date,8,0) ,
          new ParDef("@AV80Fhasta",GXType.Date,8,0) ,
          new ParDef("@AV39PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV61MonCod",GXType.Int32,6,0) ,
          new ParDef("@AV78ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV77CueCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AV2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AV3", "SELECT T1.[PagReg], T2.[PagForCod] AS PagForCod, T1.[PagDComCod], T1.[PagDTipCod], T2.[PagPrvCod], T3.[ForDsc] AS PagForDsc, T1.[PagItem] FROM (([TSPAGOSDET] T1 INNER JOIN [TSPAGOS] T2 ON T2.[PagReg] = T1.[PagReg]) INNER JOIN [CFORMAPAGO] T3 ON T3.[ForCod] = T2.[PagForCod]) WHERE (T1.[PagDTipCod] = @AV60TipCod and T1.[PagDComCod] = @AV89ComCod) AND (T2.[PagPrvCod] = @AV39PrvCod) ORDER BY T1.[PagDTipCod], T1.[PagDComCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AV4", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV93ComCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AV4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 20);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                ((string[]) buf[9])[0] = rslt.getString(8, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 100);
                ((string[]) buf[12])[0] = rslt.getString(10, 5);
                ((string[]) buf[13])[0] = rslt.getString(11, 15);
                ((string[]) buf[14])[0] = rslt.getString(12, 10);
                ((string[]) buf[15])[0] = rslt.getString(13, 100);
                ((short[]) buf[16])[0] = rslt.getShort(14);
                ((string[]) buf[17])[0] = rslt.getString(15, 10);
                ((string[]) buf[18])[0] = rslt.getString(16, 100);
                ((bool[]) buf[19])[0] = rslt.wasNull(16);
                ((string[]) buf[20])[0] = rslt.getString(17, 10);
                ((bool[]) buf[21])[0] = rslt.wasNull(17);
                ((string[]) buf[22])[0] = rslt.getString(18, 20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(19);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(20);
                ((short[]) buf[25])[0] = rslt.getShort(21);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(23);
                ((short[]) buf[28])[0] = rslt.getShort(24);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
