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
   public class r_registrohonorariosexcel : GXProcedure
   {
      public r_registrohonorariosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registrohonorariosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           out string aP2_Filename ,
                           out string aP3_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_Filename=this.AV10Filename;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_Filename, out aP3_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_Filename ,
                                 out string aP3_ErrorMessage )
      {
         r_registrohonorariosexcel objr_registrohonorariosexcel;
         objr_registrohonorariosexcel = new r_registrohonorariosexcel();
         objr_registrohonorariosexcel.AV8Ano = aP0_Ano;
         objr_registrohonorariosexcel.AV9Mes = aP1_Mes;
         objr_registrohonorariosexcel.AV10Filename = "" ;
         objr_registrohonorariosexcel.AV11ErrorMessage = "" ;
         objr_registrohonorariosexcel.context.SetSubmitInitialConfig(context);
         objr_registrohonorariosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registrohonorariosexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_Filename=this.AV10Filename;
         aP3_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registrohonorariosexcel)stateInfo).executePrivate();
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
         AV73Archivo.Source = "Excel/PlantillasHonorarios.xlsx";
         AV72Path = AV73Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV72Path) + "\\PlantillasHonorarios.xlsx";
         AV10Filename = "Excel/RegistroHonorarios" + ".xlsx";
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
         AV14CellRow = 3;
         AV15FirstColumn = 4;
         GXt_char1 = AV68cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV9Mes, out  GXt_char1) ;
         AV68cMes = GXt_char1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0))+"   Mes : "+StringUtil.Trim( AV68cMes);
         AV14CellRow = 8;
         AV15FirstColumn = 1;
         /* Using cursor P009N3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9N2 = false;
            A1915TipRHo = P009N3_A1915TipRHo[0];
            A149TipCod = P009N3_A149TipCod[0];
            A707ComFReg = P009N3_A707ComFReg[0];
            A708ComFVcto = P009N3_A708ComFVcto[0];
            A246ComMon = P009N3_A246ComMon[0];
            A1233MonAbr = P009N3_A1233MonAbr[0];
            n1233MonAbr = P009N3_n1233MonAbr[0];
            A306TipAbr = P009N3_A306TipAbr[0];
            A244PrvCod = P009N3_A244PrvCod[0];
            A247PrvDsc = P009N3_A247PrvDsc[0];
            A249ComRef = P009N3_A249ComRef[0];
            A704ComFecPago = P009N3_A704ComFecPago[0];
            A724ComRefFec = P009N3_A724ComRefFec[0];
            A511TipSigno = P009N3_A511TipSigno[0];
            A243ComCod = P009N3_A243ComCod[0];
            A248ComFec = P009N3_A248ComFec[0];
            A719ComIVADUA = P009N3_A719ComIVADUA[0];
            A718ComRedondeo = P009N3_A718ComRedondeo[0];
            A717ComPorIva = P009N3_A717ComPorIva[0];
            A729ComRete2 = P009N3_A729ComRete2[0];
            A728ComRete1 = P009N3_A728ComRete1[0];
            A698ComDscto = P009N3_A698ComDscto[0];
            A706ComFlete = P009N3_A706ComFlete[0];
            A713ComISC = P009N3_A713ComISC[0];
            A732ComSubIna = P009N3_A732ComSubIna[0];
            A716ComSubAfe = P009N3_A716ComSubAfe[0];
            A1915TipRHo = P009N3_A1915TipRHo[0];
            A306TipAbr = P009N3_A306TipAbr[0];
            A511TipSigno = P009N3_A511TipSigno[0];
            A1233MonAbr = P009N3_A1233MonAbr[0];
            n1233MonAbr = P009N3_n1233MonAbr[0];
            A732ComSubIna = P009N3_A732ComSubIna[0];
            A716ComSubAfe = P009N3_A716ComSubAfe[0];
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV60TipCod = A149TipCod;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009N3_A306TipAbr[0], A306TipAbr) == 0 ) && ( StringUtil.StrCmp(P009N3_A149TipCod[0], AV60TipCod) == 0 ) )
            {
               BRK9N2 = false;
               A149TipCod = P009N3_A149TipCod[0];
               A707ComFReg = P009N3_A707ComFReg[0];
               A708ComFVcto = P009N3_A708ComFVcto[0];
               A246ComMon = P009N3_A246ComMon[0];
               A1233MonAbr = P009N3_A1233MonAbr[0];
               n1233MonAbr = P009N3_n1233MonAbr[0];
               A244PrvCod = P009N3_A244PrvCod[0];
               A247PrvDsc = P009N3_A247PrvDsc[0];
               A249ComRef = P009N3_A249ComRef[0];
               A704ComFecPago = P009N3_A704ComFecPago[0];
               A724ComRefFec = P009N3_A724ComRefFec[0];
               A511TipSigno = P009N3_A511TipSigno[0];
               A243ComCod = P009N3_A243ComCod[0];
               A248ComFec = P009N3_A248ComFec[0];
               A719ComIVADUA = P009N3_A719ComIVADUA[0];
               A718ComRedondeo = P009N3_A718ComRedondeo[0];
               A717ComPorIva = P009N3_A717ComPorIva[0];
               A729ComRete2 = P009N3_A729ComRete2[0];
               A728ComRete1 = P009N3_A728ComRete1[0];
               A698ComDscto = P009N3_A698ComDscto[0];
               A706ComFlete = P009N3_A706ComFlete[0];
               A713ComISC = P009N3_A713ComISC[0];
               A511TipSigno = P009N3_A511TipSigno[0];
               A1233MonAbr = P009N3_A1233MonAbr[0];
               n1233MonAbr = P009N3_n1233MonAbr[0];
               if ( DateTimeUtil.Year( A707ComFReg) == AV8Ano )
               {
                  if ( DateTimeUtil.Month( A707ComFReg) == AV9Mes )
                  {
                     /* Using cursor P009N5 */
                     pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                     if ( (pr_default.getStatus(1) != 101) )
                     {
                        A732ComSubIna = P009N5_A732ComSubIna[0];
                        A716ComSubAfe = P009N5_A716ComSubAfe[0];
                     }
                     else
                     {
                        A732ComSubIna = 0;
                        A716ComSubAfe = 0;
                     }
                     pr_default.close(1);
                     A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                     A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                     A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                     AV61MonCod = A246ComMon;
                     AV60TipCod = A149TipCod;
                     AV53MonAbr = A1233MonAbr;
                     AV62TipVenta = 1.00000m;
                     AV46TipCmb = "";
                     AV36DocAbr = A306TipAbr;
                     AV37DocNum = A243ComCod;
                     AV38DocFec = A248ComFec;
                     AV39PrvCod = StringUtil.Trim( A244PrvCod);
                     AV40PrvDsc = StringUtil.Trim( A247PrvDsc);
                     GXt_char1 = AV63DocSts;
                     new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV39PrvCod, ref  AV60TipCod, ref  AV37DocNum, out  GXt_char1) ;
                     AV63DocSts = GXt_char1;
                     AV67ComRef = A249ComRef;
                     AV66ComFecPago = A704ComFecPago;
                     AV41SubTotal = 0.00m;
                     AV54SubIna = 0.00m;
                     AV42Dscto = 0.00m;
                     AV43Igv = 0.00m;
                     AV44TotalMN = 0.00m;
                     AV74ComRefFec = A724ComRefFec;
                     if ( AV61MonCod != 1 )
                     {
                        AV75Fecha = (((StringUtil.StrCmp(AV60TipCod, "NC")==0)||(StringUtil.StrCmp(AV60TipCod, "ND")==0))&&!(DateTime.MinValue==AV74ComRefFec) ? AV74ComRefFec : AV38DocFec);
                        if ( (DateTime.MinValue==AV66ComFecPago) )
                        {
                           GXt_decimal2 = AV62TipVenta;
                           GXt_char1 = "V";
                           new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV61MonCod, ref  AV75Fecha, ref  GXt_char1, out  GXt_decimal2) ;
                           AV62TipVenta = GXt_decimal2;
                        }
                        else
                        {
                           GXt_decimal2 = AV62TipVenta;
                           GXt_char1 = "V";
                           new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV61MonCod, ref  AV66ComFecPago, ref  GXt_char1, out  GXt_decimal2) ;
                           AV62TipVenta = GXt_decimal2;
                        }
                        AV46TipCmb = StringUtil.Trim( StringUtil.Str( AV62TipVenta, 10, 5));
                     }
                     if ( StringUtil.StrCmp(AV63DocSts, "A") != 0 )
                     {
                        AV41SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV62TipVenta)*A511TipSigno);
                        AV54SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV62TipVenta)*A511TipSigno);
                        AV42Dscto = (decimal)((NumberUtil.Round( A728ComRete1, 2)*AV62TipVenta)*A511TipSigno);
                        AV43Igv = (decimal)((NumberUtil.Round( A729ComRete2, 2)*AV62TipVenta)*A511TipSigno);
                        AV44TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV62TipVenta)*A511TipSigno);
                        AV45TotalMO = NumberUtil.Round( A736ComTotal, 2);
                     }
                     /* Execute user subroutine: 'DETALLECOMPRAS' */
                     S121 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        pr_default.close(1);
                        this.cleanup();
                        if (true) return;
                     }
                  }
               }
               BRK9N2 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK9N2 )
            {
               BRK9N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = "";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = "Total General";
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV52GSubTotal);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV57GIgv);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV55GSubIna);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV58GTotalMN);
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
         /* 'DETALLECOMPRAS' Routine */
         returnInSub = false;
         GXt_dtime3 = DateTimeUtil.ResetTime( AV38DocFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Date = GXt_dtime3;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV37DocNum);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV39PrvCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV40PrvDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV53MonAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV41SubTotal);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV54SubIna);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV42Dscto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV43Igv);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV44TotalMN);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV45TotalMO);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Text = AV46TipCmb;
         AV52GSubTotal = (decimal)(AV52GSubTotal+AV41SubTotal);
         AV55GSubIna = (decimal)(AV55GSubIna+AV54SubIna);
         AV56GDscto = (decimal)(AV56GDscto+AV42Dscto);
         AV57GIgv = (decimal)(AV57GIgv+AV43Igv);
         AV58GTotalMN = (decimal)(AV58GTotalMN+AV44TotalMN);
         AV59GTotalMO = (decimal)(AV59GTotalMO+AV45TotalMO);
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV73Archivo = new GxFile(context.GetPhysicalPath());
         AV72Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV68cMes = "";
         scmdbuf = "";
         P009N3_A1915TipRHo = new short[1] ;
         P009N3_A149TipCod = new string[] {""} ;
         P009N3_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P009N3_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P009N3_A246ComMon = new int[1] ;
         P009N3_A1233MonAbr = new string[] {""} ;
         P009N3_n1233MonAbr = new bool[] {false} ;
         P009N3_A306TipAbr = new string[] {""} ;
         P009N3_A244PrvCod = new string[] {""} ;
         P009N3_A247PrvDsc = new string[] {""} ;
         P009N3_A249ComRef = new string[] {""} ;
         P009N3_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P009N3_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P009N3_A511TipSigno = new short[1] ;
         P009N3_A243ComCod = new string[] {""} ;
         P009N3_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P009N3_A719ComIVADUA = new decimal[1] ;
         P009N3_A718ComRedondeo = new decimal[1] ;
         P009N3_A717ComPorIva = new decimal[1] ;
         P009N3_A729ComRete2 = new decimal[1] ;
         P009N3_A728ComRete1 = new decimal[1] ;
         P009N3_A698ComDscto = new decimal[1] ;
         P009N3_A706ComFlete = new decimal[1] ;
         P009N3_A713ComISC = new decimal[1] ;
         P009N3_A732ComSubIna = new decimal[1] ;
         P009N3_A716ComSubAfe = new decimal[1] ;
         A149TipCod = "";
         A707ComFReg = DateTime.MinValue;
         A708ComFVcto = DateTime.MinValue;
         A1233MonAbr = "";
         A306TipAbr = "";
         A244PrvCod = "";
         A247PrvDsc = "";
         A249ComRef = "";
         A704ComFecPago = DateTime.MinValue;
         A724ComRefFec = DateTime.MinValue;
         A243ComCod = "";
         A248ComFec = DateTime.MinValue;
         AV60TipCod = "";
         P009N5_A732ComSubIna = new decimal[1] ;
         P009N5_A716ComSubAfe = new decimal[1] ;
         AV53MonAbr = "";
         AV46TipCmb = "";
         AV36DocAbr = "";
         AV37DocNum = "";
         AV38DocFec = DateTime.MinValue;
         AV39PrvCod = "";
         AV40PrvDsc = "";
         AV63DocSts = "";
         AV67ComRef = "";
         AV66ComFecPago = DateTime.MinValue;
         AV74ComRefFec = DateTime.MinValue;
         AV75Fecha = DateTime.MinValue;
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_registrohonorariosexcel__default(),
            new Object[][] {
                new Object[] {
               P009N3_A1915TipRHo, P009N3_A149TipCod, P009N3_A707ComFReg, P009N3_A708ComFVcto, P009N3_A246ComMon, P009N3_A1233MonAbr, P009N3_n1233MonAbr, P009N3_A306TipAbr, P009N3_A244PrvCod, P009N3_A247PrvDsc,
               P009N3_A249ComRef, P009N3_A704ComFecPago, P009N3_A724ComRefFec, P009N3_A511TipSigno, P009N3_A243ComCod, P009N3_A248ComFec, P009N3_A719ComIVADUA, P009N3_A718ComRedondeo, P009N3_A717ComPorIva, P009N3_A729ComRete2,
               P009N3_A728ComRete1, P009N3_A698ComDscto, P009N3_A706ComFlete, P009N3_A713ComISC, P009N3_A732ComSubIna, P009N3_A716ComSubAfe
               }
               , new Object[] {
               P009N5_A732ComSubIna, P009N5_A716ComSubAfe
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short A1915TipRHo ;
      private short A511TipSigno ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A246ComMon ;
      private int AV61MonCod ;
      private decimal A719ComIVADUA ;
      private decimal A718ComRedondeo ;
      private decimal A717ComPorIva ;
      private decimal A729ComRete2 ;
      private decimal A728ComRete1 ;
      private decimal A698ComDscto ;
      private decimal A706ComFlete ;
      private decimal A713ComISC ;
      private decimal A732ComSubIna ;
      private decimal A716ComSubAfe ;
      private decimal A715ComIva ;
      private decimal A733ComSubTotal ;
      private decimal A736ComTotal ;
      private decimal AV62TipVenta ;
      private decimal AV41SubTotal ;
      private decimal AV54SubIna ;
      private decimal AV42Dscto ;
      private decimal AV43Igv ;
      private decimal AV44TotalMN ;
      private decimal GXt_decimal2 ;
      private decimal AV45TotalMO ;
      private decimal AV52GSubTotal ;
      private decimal AV57GIgv ;
      private decimal AV55GSubIna ;
      private decimal AV58GTotalMN ;
      private decimal AV56GDscto ;
      private decimal AV59GTotalMO ;
      private string AV72Path ;
      private string AV68cMes ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A306TipAbr ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A249ComRef ;
      private string A243ComCod ;
      private string AV60TipCod ;
      private string AV53MonAbr ;
      private string AV46TipCmb ;
      private string AV36DocAbr ;
      private string AV37DocNum ;
      private string AV39PrvCod ;
      private string AV40PrvDsc ;
      private string AV63DocSts ;
      private string AV67ComRef ;
      private string GXt_char1 ;
      private DateTime GXt_dtime3 ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime A248ComFec ;
      private DateTime AV38DocFec ;
      private DateTime AV66ComFecPago ;
      private DateTime AV74ComRefFec ;
      private DateTime AV75Fecha ;
      private bool returnInSub ;
      private bool BRK9N2 ;
      private bool n1233MonAbr ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private short[] P009N3_A1915TipRHo ;
      private string[] P009N3_A149TipCod ;
      private DateTime[] P009N3_A707ComFReg ;
      private DateTime[] P009N3_A708ComFVcto ;
      private int[] P009N3_A246ComMon ;
      private string[] P009N3_A1233MonAbr ;
      private bool[] P009N3_n1233MonAbr ;
      private string[] P009N3_A306TipAbr ;
      private string[] P009N3_A244PrvCod ;
      private string[] P009N3_A247PrvDsc ;
      private string[] P009N3_A249ComRef ;
      private DateTime[] P009N3_A704ComFecPago ;
      private DateTime[] P009N3_A724ComRefFec ;
      private short[] P009N3_A511TipSigno ;
      private string[] P009N3_A243ComCod ;
      private DateTime[] P009N3_A248ComFec ;
      private decimal[] P009N3_A719ComIVADUA ;
      private decimal[] P009N3_A718ComRedondeo ;
      private decimal[] P009N3_A717ComPorIva ;
      private decimal[] P009N3_A729ComRete2 ;
      private decimal[] P009N3_A728ComRete1 ;
      private decimal[] P009N3_A698ComDscto ;
      private decimal[] P009N3_A706ComFlete ;
      private decimal[] P009N3_A713ComISC ;
      private decimal[] P009N3_A732ComSubIna ;
      private decimal[] P009N3_A716ComSubAfe ;
      private decimal[] P009N5_A732ComSubIna ;
      private decimal[] P009N5_A716ComSubAfe ;
      private string aP2_Filename ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV73Archivo ;
   }

   public class r_registrohonorariosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP009N3;
          prmP009N3 = new Object[] {
          };
          Object[] prmP009N5;
          prmP009N5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009N3", "SELECT T2.[TipRHo], T1.[TipCod], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T3.[MonAbr], T2.[TipAbr], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRefFec], T2.[TipSigno], T1.[ComCod], T1.[ComFec], T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComRete2], T1.[ComRete1], T1.[ComDscto], T1.[ComFlete], T1.[ComISC], COALESCE( T4.[ComSubIna], 0) AS ComSubIna, COALESCE( T4.[ComSubAfe], 0) AS ComSubAfe FROM ((([CPCOMPRAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[ComMon]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[ComCod] = T1.[ComCod] AND T4.[PrvCod] = T1.[PrvCod]) WHERE T2.[TipRHo] = 1 ORDER BY T2.[TipAbr], T1.[TipCod], T1.[ComFec], T1.[ComCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009N5", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009N5,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getString(10, 10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((string[]) buf[14])[0] = rslt.getString(14, 15);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(15);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(16);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(17);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(18);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
