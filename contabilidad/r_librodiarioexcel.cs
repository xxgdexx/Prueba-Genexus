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
namespace GeneXus.Programs.contabilidad {
   public class r_librodiarioexcel : GXProcedure
   {
      public r_librodiarioexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_librodiarioexcel( IGxContext context )
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
         this.AV23Mes = aP1_Mes;
         this.AV19FileName = "" ;
         this.AV17ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV23Mes;
         aP2_FileName=this.AV19FileName;
         aP3_ErrorMessage=this.AV17ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_FileName )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_FileName, out aP3_ErrorMessage);
         return AV17ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_FileName ,
                                 out string aP3_ErrorMessage )
      {
         r_librodiarioexcel objr_librodiarioexcel;
         objr_librodiarioexcel = new r_librodiarioexcel();
         objr_librodiarioexcel.AV11Ano = aP0_Ano;
         objr_librodiarioexcel.AV23Mes = aP1_Mes;
         objr_librodiarioexcel.AV19FileName = "" ;
         objr_librodiarioexcel.AV17ErrorMessage = "" ;
         objr_librodiarioexcel.context.SetSubmitInitialConfig(context);
         objr_librodiarioexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_librodiarioexcel);
         aP0_Ano=this.AV11Ano;
         aP1_Mes=this.AV23Mes;
         aP2_FileName=this.AV19FileName;
         aP3_ErrorMessage=this.AV17ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_librodiarioexcel)stateInfo).executePrivate();
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
         AV12Archivo.Source = "Excel/FORMATO_5_1.xlsx";
         AV25Path = AV12Archivo.GetPath();
         AV20FileNameOrigen = StringUtil.Trim( AV25Path) + "\\FORMATO_5_1.xlsx";
         AV19FileName = "Excel/Libro Diario" + ".xlsx";
         AV28RUC = AV29Session.Get("EmpRUC");
         AV16Empresa = AV29Session.Get("Empresa");
         AV18ExcelDocument.Clear();
         AV18ExcelDocument.Template = AV20FileNameOrigen;
         AV18ExcelDocument.Open(AV19FileName);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 3;
         AV21FirstColumn = 7;
         AV26Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + "" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV23Mes), 10, 0)), 2, "0");
         AV18ExcelDocument.get_Cells(3, 2, 1, 1).Text = StringUtil.Trim( AV26Periodo);
         AV18ExcelDocument.get_Cells(4, 2, 1, 1).Text = StringUtil.Trim( AV28RUC);
         AV18ExcelDocument.get_Cells(5, 3, 1, 1).Text = StringUtil.Trim( AV16Empresa);
         AV13CellRow = 9;
         AV21FirstColumn = 1;
         AV26Periodo = StringUtil.Trim( StringUtil.Str( (decimal)(AV11Ano), 10, 0)) + "" + StringUtil.PadL( StringUtil.Trim( StringUtil.Str( (decimal)(AV23Mes), 10, 0)), 2, "0");
         /* Using cursor P00BX2 */
         pr_default.execute(0, new Object[] {AV11Ano, AV23Mes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A126TASICod = P00BX2_A126TASICod[0];
            A128VouMes = P00BX2_A128VouMes[0];
            A127VouAno = P00BX2_A127VouAno[0];
            A129VouNum = P00BX2_A129VouNum[0];
            A1894TASIAbr = P00BX2_A1894TASIAbr[0];
            A2075VouGls = P00BX2_A2075VouGls[0];
            A2256TASISunat = P00BX2_A2256TASISunat[0];
            A2077VouSts = P00BX2_A2077VouSts[0];
            A1894TASIAbr = P00BX2_A1894TASIAbr[0];
            A2256TASISunat = P00BX2_A2256TASISunat[0];
            AV31TDebe = 0.00m;
            AV32THaber = 0.00m;
            /* Using cursor P00BX3 */
            pr_default.execute(1, new Object[] {A127VouAno, A128VouMes, A126TASICod, A129VouNum});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2054VouDGls = P00BX3_A2054VouDGls[0];
               A2053VouDDoc = P00BX3_A2053VouDDoc[0];
               A91CueCod = P00BX3_A91CueCod[0];
               A860CueDsc = P00BX3_A860CueDsc[0];
               A2051VouDDeb = P00BX3_A2051VouDDeb[0];
               A2055VouDHab = P00BX3_A2055VouDHab[0];
               A136VouReg = P00BX3_A136VouReg[0];
               A135VouDFec = P00BX3_A135VouDFec[0];
               A130VouDSec = P00BX3_A130VouDSec[0];
               A860CueDsc = P00BX3_A860CueDsc[0];
               AV27Registro = StringUtil.Trim( A1894TASIAbr) + "-" + StringUtil.Trim( A129VouNum);
               AV22Glosa = (String.IsNullOrEmpty(StringUtil.RTrim( A2054VouDGls)) ? StringUtil.Trim( A2075VouGls) : StringUtil.Trim( A2054VouDGls));
               AV34VouDFec = A135VouDFec;
               AV9TasiSunat = A2256TASISunat;
               AV37VouReg = A136VouReg;
               AV10VouDDoc = A2053VouDDoc;
               AV8CueCod = A91CueCod;
               AV14CueDsc = A860CueDsc;
               AV33VouDDeb = NumberUtil.Round( A2051VouDDeb, 2);
               AV35VouDHab = NumberUtil.Round( A2055VouDHab, 2);
               /* Execute user subroutine: 'DETALLEEXCEL' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
               AV31TDebe = (decimal)(AV31TDebe+(NumberUtil.Round( A2051VouDDeb, 2)));
               AV32THaber = (decimal)(AV32THaber+(NumberUtil.Round( A2055VouDHab, 2)));
               AV13CellRow = (int)(AV13CellRow+1);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV18ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
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
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV18ExcelDocument.ErrCode != 0 )
         {
            AV19FileName = "";
            AV17ErrorMessage = AV18ExcelDocument.ErrDescription;
            AV18ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLEEXCEL' Routine */
         returnInSub = false;
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV27Registro);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV34VouDFec ) ;
         AV18ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+1, 1, 1).Date = GXt_dtime1;
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV22Glosa);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV9TasiSunat);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV37VouReg);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV10VouDDoc);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV8CueCod);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV14CueDsc);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+8, 1, 1).Number = (double)(AV33VouDDeb);
         AV18ExcelDocument.get_Cells(AV13CellRow, AV21FirstColumn+9, 1, 1).Number = (double)(AV35VouDHab);
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
         AV19FileName = "";
         AV17ErrorMessage = "";
         AV12Archivo = new GxFile(context.GetPhysicalPath());
         AV25Path = "";
         AV20FileNameOrigen = "";
         AV28RUC = "";
         AV29Session = context.GetSession();
         AV16Empresa = "";
         AV18ExcelDocument = new ExcelDocumentI();
         AV26Periodo = "";
         scmdbuf = "";
         P00BX2_A126TASICod = new int[1] ;
         P00BX2_A128VouMes = new short[1] ;
         P00BX2_A127VouAno = new short[1] ;
         P00BX2_A129VouNum = new string[] {""} ;
         P00BX2_A1894TASIAbr = new string[] {""} ;
         P00BX2_A2075VouGls = new string[] {""} ;
         P00BX2_A2256TASISunat = new string[] {""} ;
         P00BX2_A2077VouSts = new short[1] ;
         A129VouNum = "";
         A1894TASIAbr = "";
         A2075VouGls = "";
         A2256TASISunat = "";
         P00BX3_A127VouAno = new short[1] ;
         P00BX3_A128VouMes = new short[1] ;
         P00BX3_A126TASICod = new int[1] ;
         P00BX3_A129VouNum = new string[] {""} ;
         P00BX3_A2054VouDGls = new string[] {""} ;
         P00BX3_A2053VouDDoc = new string[] {""} ;
         P00BX3_A91CueCod = new string[] {""} ;
         P00BX3_A860CueDsc = new string[] {""} ;
         P00BX3_A2051VouDDeb = new decimal[1] ;
         P00BX3_A2055VouDHab = new decimal[1] ;
         P00BX3_A136VouReg = new string[] {""} ;
         P00BX3_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00BX3_A130VouDSec = new int[1] ;
         A2054VouDGls = "";
         A2053VouDDoc = "";
         A91CueCod = "";
         A860CueDsc = "";
         A136VouReg = "";
         A135VouDFec = DateTime.MinValue;
         AV27Registro = "";
         AV22Glosa = "";
         AV34VouDFec = DateTime.MinValue;
         AV9TasiSunat = "";
         AV37VouReg = "";
         AV10VouDDoc = "";
         AV8CueCod = "";
         AV14CueDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_librodiarioexcel__default(),
            new Object[][] {
                new Object[] {
               P00BX2_A126TASICod, P00BX2_A128VouMes, P00BX2_A127VouAno, P00BX2_A129VouNum, P00BX2_A1894TASIAbr, P00BX2_A2075VouGls, P00BX2_A2256TASISunat, P00BX2_A2077VouSts
               }
               , new Object[] {
               P00BX3_A127VouAno, P00BX3_A128VouMes, P00BX3_A126TASICod, P00BX3_A129VouNum, P00BX3_A2054VouDGls, P00BX3_A2053VouDDoc, P00BX3_A91CueCod, P00BX3_A860CueDsc, P00BX3_A2051VouDDeb, P00BX3_A2055VouDHab,
               P00BX3_A136VouReg, P00BX3_A135VouDFec, P00BX3_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11Ano ;
      private short AV23Mes ;
      private short A128VouMes ;
      private short A127VouAno ;
      private short A2077VouSts ;
      private int AV13CellRow ;
      private int AV21FirstColumn ;
      private int A126TASICod ;
      private int A130VouDSec ;
      private decimal AV31TDebe ;
      private decimal AV32THaber ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal AV33VouDDeb ;
      private decimal AV35VouDHab ;
      private string AV26Periodo ;
      private string scmdbuf ;
      private string A129VouNum ;
      private string A1894TASIAbr ;
      private string A2075VouGls ;
      private string A2256TASISunat ;
      private string A2054VouDGls ;
      private string A2053VouDDoc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A136VouReg ;
      private string AV9TasiSunat ;
      private string AV37VouReg ;
      private string AV10VouDDoc ;
      private string AV8CueCod ;
      private string AV14CueDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime A135VouDFec ;
      private DateTime AV34VouDFec ;
      private bool returnInSub ;
      private string AV19FileName ;
      private string AV17ErrorMessage ;
      private string AV25Path ;
      private string AV20FileNameOrigen ;
      private string AV28RUC ;
      private string AV16Empresa ;
      private string AV27Registro ;
      private string AV22Glosa ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private int[] P00BX2_A126TASICod ;
      private short[] P00BX2_A128VouMes ;
      private short[] P00BX2_A127VouAno ;
      private string[] P00BX2_A129VouNum ;
      private string[] P00BX2_A1894TASIAbr ;
      private string[] P00BX2_A2075VouGls ;
      private string[] P00BX2_A2256TASISunat ;
      private short[] P00BX2_A2077VouSts ;
      private short[] P00BX3_A127VouAno ;
      private short[] P00BX3_A128VouMes ;
      private int[] P00BX3_A126TASICod ;
      private string[] P00BX3_A129VouNum ;
      private string[] P00BX3_A2054VouDGls ;
      private string[] P00BX3_A2053VouDDoc ;
      private string[] P00BX3_A91CueCod ;
      private string[] P00BX3_A860CueDsc ;
      private decimal[] P00BX3_A2051VouDDeb ;
      private decimal[] P00BX3_A2055VouDHab ;
      private string[] P00BX3_A136VouReg ;
      private DateTime[] P00BX3_A135VouDFec ;
      private int[] P00BX3_A130VouDSec ;
      private string aP2_FileName ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV18ExcelDocument ;
      private GxFile AV12Archivo ;
   }

   public class r_librodiarioexcel__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BX2;
          prmP00BX2 = new Object[] {
          new ParDef("@AV11Ano",GXType.Int16,4,0) ,
          new ParDef("@AV23Mes",GXType.Int16,2,0)
          };
          Object[] prmP00BX3;
          prmP00BX3 = new Object[] {
          new ParDef("@VouAno",GXType.Int16,4,0) ,
          new ParDef("@VouMes",GXType.Int16,2,0) ,
          new ParDef("@TASICod",GXType.Int32,6,0) ,
          new ParDef("@VouNum",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BX2", "SELECT T1.[TASICod], T1.[VouMes], T1.[VouAno], T1.[VouNum], T2.[TASIAbr], T1.[VouGls], T2.[TASISunat], T1.[VouSts] FROM ([CBVOUCHER] T1 INNER JOIN [CBTIPOASIENTO] T2 ON T2.[TASICod] = T1.[TASICod]) WHERE (T1.[VouAno] = @AV11Ano and T1.[VouMes] = @AV23Mes) AND (T1.[VouSts] = 1) ORDER BY T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BX3", "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T1.[VouDGls], T1.[VouDDoc], T1.[CueCod], T2.[CueDsc], T1.[VouDDeb], T1.[VouDHab], T1.[VouReg], T1.[VouDFec], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE (T1.[VouAno] = @VouAno) AND (T1.[VouMes] = @VouMes) AND (T1.[TASICod] = @TASICod) AND (T1.[VouNum] = @VouNum) ORDER BY T1.[VouDFec], T1.[VouReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BX3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(12);
                ((int[]) buf[12])[0] = rslt.getInt(13);
                return;
       }
    }

 }

}
