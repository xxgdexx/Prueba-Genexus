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
   public class r_registroretencionesexcel : GXProcedure
   {
      public r_registroretencionesexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroretencionesexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           out string aP2_FileName ,
                           out string aP3_ErrorMessage )
      {
         this.AV11Ano = aP0_Ano;
         this.AV30Mes = aP1_Mes;
         this.AV26FileName = "" ;
         this.AV24ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV30Mes;
         aP2_FileName=this.AV26FileName;
         aP3_ErrorMessage=this.AV24ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_FileName )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_FileName, out aP3_ErrorMessage);
         return AV24ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_FileName ,
                                 out string aP3_ErrorMessage )
      {
         r_registroretencionesexcel objr_registroretencionesexcel;
         objr_registroretencionesexcel = new r_registroretencionesexcel();
         objr_registroretencionesexcel.AV11Ano = aP0_Ano;
         objr_registroretencionesexcel.AV30Mes = aP1_Mes;
         objr_registroretencionesexcel.AV26FileName = "" ;
         objr_registroretencionesexcel.AV24ErrorMessage = "" ;
         objr_registroretencionesexcel.context.SetSubmitInitialConfig(context);
         objr_registroretencionesexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroretencionesexcel);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV30Mes;
         aP2_FileName=this.AV26FileName;
         aP3_ErrorMessage=this.AV24ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registroretencionesexcel)stateInfo).executePrivate();
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
         AV12Archivo.Source = "Excel/FORMATO_4_1.xlsx";
         AV31Path = AV12Archivo.GetPath();
         AV27FileNameOrigen = StringUtil.Trim( AV31Path) + "\\FORMATO_4_1.xlsx";
         AV26FileName = "Excel/Registro Retenciones" + ".xlsx";
         AV36RUC = AV38Session.Get("EmpRUC");
         AV23Empresa = AV38Session.Get("Empresa");
         AV25ExcelDocument.Clear();
         AV25ExcelDocument.Template = AV27FileNameOrigen;
         AV25ExcelDocument.Open(AV26FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 3;
         AV28FirstColumn = 7;
         AV32Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + "" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV30Mes), 10, 0)), 2, "0");
         AV25ExcelDocument.get_Cells(3, 2, 1, 1).Text = StringUtil.Trim( AV32Periodo);
         AV25ExcelDocument.get_Cells(4, 2, 1, 1).Text = StringUtil.Trim( AV36RUC);
         AV25ExcelDocument.get_Cells(5, 3, 1, 1).Text = StringUtil.Trim( AV23Empresa);
         AV13CellRow = 9;
         AV28FirstColumn = 1;
         AV32Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + "" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV30Mes), 10, 0)), 2, "0");
         /* Using cursor P009P2 */
         pr_default.execute(0, new Object[] {AV11Ano, AV30Mes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9P2 = false;
            A244PrvCod = P009P2_A244PrvCod[0];
            A304CPRetTipCod = P009P2_A304CPRetTipCod[0];
            A847CPRetSts = P009P2_A847CPRetSts[0];
            A834CPRetFec = P009P2_A834CPRetFec[0];
            A303CPRetPrvCod = P009P2_A303CPRetPrvCod[0];
            A302CPRetCod = P009P2_A302CPRetCod[0];
            A264CPFech = P009P2_A264CPFech[0];
            n264CPFech = P009P2_n264CPFech[0];
            A817CPFVcto = P009P2_A817CPFVcto[0];
            n817CPFVcto = P009P2_n817CPFVcto[0];
            A305CPRetComCod = P009P2_A305CPRetComCod[0];
            A247PrvDsc = P009P2_A247PrvDsc[0];
            A843CPRetRet = P009P2_A843CPRetRet[0];
            A840CPRetTipCmb = P009P2_A840CPRetTipCmb[0];
            A839CPRetTotal = P009P2_A839CPRetTotal[0];
            A833CPRetComMon = P009P2_A833CPRetComMon[0];
            A244PrvCod = P009P2_A244PrvCod[0];
            A847CPRetSts = P009P2_A847CPRetSts[0];
            A834CPRetFec = P009P2_A834CPRetFec[0];
            A840CPRetTipCmb = P009P2_A840CPRetTipCmb[0];
            A247PrvDsc = P009P2_A247PrvDsc[0];
            A264CPFech = P009P2_A264CPFech[0];
            n264CPFech = P009P2_n264CPFech[0];
            A817CPFVcto = P009P2_A817CPFVcto[0];
            n817CPFVcto = P009P2_n817CPFVcto[0];
            A833CPRetComMon = P009P2_A833CPRetComMon[0];
            A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
            A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
            AV34PrvDsc = StringUtil.Trim( A303CPRetPrvCod) + " " + StringUtil.Trim( A247PrvDsc);
            AV33Proveedor = "Total : " + StringUtil.Trim( A247PrvDsc);
            AV19CPRetPrvCod = A303CPRetPrvCod;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P009P2_A303CPRetPrvCod[0], A303CPRetPrvCod) == 0 ) )
            {
               BRK9P2 = false;
               A304CPRetTipCod = P009P2_A304CPRetTipCod[0];
               A847CPRetSts = P009P2_A847CPRetSts[0];
               A834CPRetFec = P009P2_A834CPRetFec[0];
               A302CPRetCod = P009P2_A302CPRetCod[0];
               A264CPFech = P009P2_A264CPFech[0];
               n264CPFech = P009P2_n264CPFech[0];
               A817CPFVcto = P009P2_A817CPFVcto[0];
               n817CPFVcto = P009P2_n817CPFVcto[0];
               A305CPRetComCod = P009P2_A305CPRetComCod[0];
               A843CPRetRet = P009P2_A843CPRetRet[0];
               A840CPRetTipCmb = P009P2_A840CPRetTipCmb[0];
               A839CPRetTotal = P009P2_A839CPRetTotal[0];
               A833CPRetComMon = P009P2_A833CPRetComMon[0];
               A847CPRetSts = P009P2_A847CPRetSts[0];
               A834CPRetFec = P009P2_A834CPRetFec[0];
               A840CPRetTipCmb = P009P2_A840CPRetTipCmb[0];
               A264CPFech = P009P2_A264CPFech[0];
               n264CPFech = P009P2_n264CPFech[0];
               A817CPFVcto = P009P2_A817CPFVcto[0];
               n817CPFVcto = P009P2_n817CPFVcto[0];
               A833CPRetComMon = P009P2_A833CPRetComMon[0];
               if ( DateTimeUtil.Year( A834CPRetFec) == AV11Ano )
               {
                  if ( DateTimeUtil.Month( A834CPRetFec) == AV30Mes )
                  {
                     if ( StringUtil.StrCmp(A847CPRetSts, "A") != 0 )
                     {
                        if ( StringUtil.StrCmp(A303CPRetPrvCod, AV19CPRetPrvCod) == 0 )
                        {
                           A838CPRetTotalMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A839CPRetTotal*A840CPRetTipCmb, 2) : A839CPRetTotal);
                           A842CPRetRetMN = ((A833CPRetComMon==2) ? NumberUtil.Round( A843CPRetRet*A840CPRetTipCmb, 2) : A843CPRetRet);
                           AV16CPRetCod = A302CPRetCod;
                           AV18CPRetFec = A834CPRetFec;
                           AV14CPFech = A264CPFech;
                           AV15CPFVcto = A817CPFVcto;
                           AV39TipAbr = A306TipAbr;
                           AV17CPRetComCod = A305CPRetComCod;
                           AV21CPRetTotalMN = A838CPRetTotalMN;
                           AV20CPRetRetMN = A842CPRetRetMN;
                           AV37Saldo = (decimal)(AV21CPRetTotalMN-AV20CPRetRetMN);
                           /* Execute user subroutine: 'DETALLEEXCEL' */
                           S121 ();
                           if ( returnInSub )
                           {
                              pr_default.close(0);
                              this.cleanup();
                              if (true) return;
                           }
                           AV13CellRow = (int)(AV13CellRow+1);
                        }
                     }
                  }
               }
               BRK9P2 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK9P2 )
            {
               BRK9P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV25ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV25ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV25ExcelDocument.ErrCode != 0 )
         {
            AV26FileName = "";
            AV24ErrorMessage = AV25ExcelDocument.ErrDescription;
            AV25ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLEEXCEL' Routine */
         returnInSub = false;
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV19CPRetPrvCod);
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV34PrvDsc);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV18CPRetFec ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+2, 1, 1).Date = GXt_dtime1;
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV16CPRetCod);
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV39TipAbr);
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV17CPRetComCod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV14CPFech ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+6, 1, 1).Date = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV15CPFVcto ) ;
         AV25ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+7, 1, 1).Date = GXt_dtime1;
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+8, 1, 1).Number = (double)(AV21CPRetTotalMN);
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+9, 1, 1).Number = (double)(AV20CPRetRetMN);
         AV25ExcelDocument.get_Cells(AV13CellRow, AV28FirstColumn+10, 1, 1).Number = (double)(AV37Saldo);
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
         AV26FileName = "";
         AV24ErrorMessage = "";
         AV12Archivo = new GxFile(context.GetPhysicalPath());
         AV31Path = "";
         AV27FileNameOrigen = "";
         AV36RUC = "";
         AV38Session = context.GetSession();
         AV23Empresa = "";
         AV25ExcelDocument = new ExcelDocumentI();
         AV32Periodo = "";
         scmdbuf = "";
         P009P2_A244PrvCod = new string[] {""} ;
         P009P2_A304CPRetTipCod = new string[] {""} ;
         P009P2_A847CPRetSts = new string[] {""} ;
         P009P2_A834CPRetFec = new DateTime[] {DateTime.MinValue} ;
         P009P2_A303CPRetPrvCod = new string[] {""} ;
         P009P2_A302CPRetCod = new string[] {""} ;
         P009P2_A264CPFech = new DateTime[] {DateTime.MinValue} ;
         P009P2_n264CPFech = new bool[] {false} ;
         P009P2_A817CPFVcto = new DateTime[] {DateTime.MinValue} ;
         P009P2_n817CPFVcto = new bool[] {false} ;
         P009P2_A305CPRetComCod = new string[] {""} ;
         P009P2_A247PrvDsc = new string[] {""} ;
         P009P2_A843CPRetRet = new decimal[1] ;
         P009P2_A840CPRetTipCmb = new decimal[1] ;
         P009P2_A839CPRetTotal = new decimal[1] ;
         P009P2_A833CPRetComMon = new int[1] ;
         A244PrvCod = "";
         A304CPRetTipCod = "";
         A847CPRetSts = "";
         A834CPRetFec = DateTime.MinValue;
         A303CPRetPrvCod = "";
         A302CPRetCod = "";
         A264CPFech = DateTime.MinValue;
         A817CPFVcto = DateTime.MinValue;
         A305CPRetComCod = "";
         A247PrvDsc = "";
         AV34PrvDsc = "";
         AV33Proveedor = "";
         AV19CPRetPrvCod = "";
         AV16CPRetCod = "";
         AV18CPRetFec = DateTime.MinValue;
         AV14CPFech = DateTime.MinValue;
         AV15CPFVcto = DateTime.MinValue;
         AV39TipAbr = "";
         A306TipAbr = "";
         AV17CPRetComCod = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.r_registroretencionesexcel__default(),
            new Object[][] {
                new Object[] {
               P009P2_A244PrvCod, P009P2_A304CPRetTipCod, P009P2_A847CPRetSts, P009P2_A834CPRetFec, P009P2_A303CPRetPrvCod, P009P2_A302CPRetCod, P009P2_A264CPFech, P009P2_n264CPFech, P009P2_A817CPFVcto, P009P2_n817CPFVcto,
               P009P2_A305CPRetComCod, P009P2_A247PrvDsc, P009P2_A843CPRetRet, P009P2_A840CPRetTipCmb, P009P2_A839CPRetTotal, P009P2_A833CPRetComMon
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11Ano ;
      private short AV30Mes ;
      private int AV13CellRow ;
      private int AV28FirstColumn ;
      private int A833CPRetComMon ;
      private decimal A843CPRetRet ;
      private decimal A840CPRetTipCmb ;
      private decimal A839CPRetTotal ;
      private decimal A838CPRetTotalMN ;
      private decimal A842CPRetRetMN ;
      private decimal AV21CPRetTotalMN ;
      private decimal AV20CPRetRetMN ;
      private decimal AV37Saldo ;
      private string AV32Periodo ;
      private string scmdbuf ;
      private string A244PrvCod ;
      private string A304CPRetTipCod ;
      private string A847CPRetSts ;
      private string A303CPRetPrvCod ;
      private string A302CPRetCod ;
      private string A305CPRetComCod ;
      private string A247PrvDsc ;
      private string AV34PrvDsc ;
      private string AV19CPRetPrvCod ;
      private string AV16CPRetCod ;
      private string AV39TipAbr ;
      private string A306TipAbr ;
      private string AV17CPRetComCod ;
      private DateTime GXt_dtime1 ;
      private DateTime A834CPRetFec ;
      private DateTime A264CPFech ;
      private DateTime A817CPFVcto ;
      private DateTime AV18CPRetFec ;
      private DateTime AV14CPFech ;
      private DateTime AV15CPFVcto ;
      private bool returnInSub ;
      private bool BRK9P2 ;
      private bool n264CPFech ;
      private bool n817CPFVcto ;
      private string AV26FileName ;
      private string AV24ErrorMessage ;
      private string AV31Path ;
      private string AV27FileNameOrigen ;
      private string AV36RUC ;
      private string AV23Empresa ;
      private string AV33Proveedor ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P009P2_A244PrvCod ;
      private string[] P009P2_A304CPRetTipCod ;
      private string[] P009P2_A847CPRetSts ;
      private DateTime[] P009P2_A834CPRetFec ;
      private string[] P009P2_A303CPRetPrvCod ;
      private string[] P009P2_A302CPRetCod ;
      private DateTime[] P009P2_A264CPFech ;
      private bool[] P009P2_n264CPFech ;
      private DateTime[] P009P2_A817CPFVcto ;
      private bool[] P009P2_n817CPFVcto ;
      private string[] P009P2_A305CPRetComCod ;
      private string[] P009P2_A247PrvDsc ;
      private decimal[] P009P2_A843CPRetRet ;
      private decimal[] P009P2_A840CPRetTipCmb ;
      private decimal[] P009P2_A839CPRetTotal ;
      private int[] P009P2_A833CPRetComMon ;
      private string aP2_FileName ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV25ExcelDocument ;
      private GxFile AV12Archivo ;
   }

   public class r_registroretencionesexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009P2;
          prmP009P2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV30Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009P2", "SELECT T2.[PrvCod], T1.[CPRetTipCod] AS CPRetTipCod, T2.[CPRetSts], T2.[CPRetFec], T1.[CPRetPrvCod] AS CPRetPrvCod, T1.[CPRetCod], T4.[CPFech], T4.[CPFVcto], T1.[CPRetComCod] AS CPRetComCod, T3.[PrvDsc], T1.[CPRetRet], T2.[CPRetTipCmb], T1.[CPRetTotal], T4.[CPMonCod] AS CPRetComMon FROM ((([CPRETENCIONDET] T1 INNER JOIN [CPRETENCION] T2 ON T2.[CPRetCod] = T1.[CPRetCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = T2.[PrvCod]) INNER JOIN [CPCUENTAPAGAR] T4 ON T4.[CPTipCod] = T1.[CPRetTipCod] AND T4.[CPComCod] = T1.[CPRetComCod] AND T4.[CPPrvCod] = T1.[CPRetPrvCod]) WHERE (YEAR(T2.[CPRetFec]) = @AV11Ano) AND (MONTH(T2.[CPRetFec]) = @AV30Mes) AND (T2.[CPRetSts] <> 'A') ORDER BY T1.[CPRetPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009P2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 15);
                ((string[]) buf[11])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((int[]) buf[15])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
