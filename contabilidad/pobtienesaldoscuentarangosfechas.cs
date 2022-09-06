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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.contabilidad {
   public class pobtienesaldoscuentarangosfechas : GXProcedure
   {
      public pobtienesaldoscuentarangosfechas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienesaldoscuentarangosfechas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CueCod ,
                           ref string aP1_CueCodAux ,
                           ref DateTime aP2_cHasta ,
                           out decimal aP3_SaldoDMN ,
                           out decimal aP4_SaldoHMN ,
                           out decimal aP5_SaldoDME ,
                           out decimal aP6_SaldoHME )
      {
         this.AV8CueCod = aP0_CueCod;
         this.AV18CueCodAux = aP1_CueCodAux;
         this.AV17cHasta = aP2_cHasta;
         this.AV12SaldoDMN = 0 ;
         this.AV13SaldoHMN = 0 ;
         this.AV14SaldoDME = 0 ;
         this.AV15SaldoHME = 0 ;
         initialize();
         executePrivate();
         aP0_CueCod=this.AV8CueCod;
         aP1_CueCodAux=this.AV18CueCodAux;
         aP2_cHasta=this.AV17cHasta;
         aP3_SaldoDMN=this.AV12SaldoDMN;
         aP4_SaldoHMN=this.AV13SaldoHMN;
         aP5_SaldoDME=this.AV14SaldoDME;
         aP6_SaldoHME=this.AV15SaldoHME;
      }

      public decimal executeUdp( ref string aP0_CueCod ,
                                 ref string aP1_CueCodAux ,
                                 ref DateTime aP2_cHasta ,
                                 out decimal aP3_SaldoDMN ,
                                 out decimal aP4_SaldoHMN ,
                                 out decimal aP5_SaldoDME )
      {
         execute(ref aP0_CueCod, ref aP1_CueCodAux, ref aP2_cHasta, out aP3_SaldoDMN, out aP4_SaldoHMN, out aP5_SaldoDME, out aP6_SaldoHME);
         return AV15SaldoHME ;
      }

      public void executeSubmit( ref string aP0_CueCod ,
                                 ref string aP1_CueCodAux ,
                                 ref DateTime aP2_cHasta ,
                                 out decimal aP3_SaldoDMN ,
                                 out decimal aP4_SaldoHMN ,
                                 out decimal aP5_SaldoDME ,
                                 out decimal aP6_SaldoHME )
      {
         pobtienesaldoscuentarangosfechas objpobtienesaldoscuentarangosfechas;
         objpobtienesaldoscuentarangosfechas = new pobtienesaldoscuentarangosfechas();
         objpobtienesaldoscuentarangosfechas.AV8CueCod = aP0_CueCod;
         objpobtienesaldoscuentarangosfechas.AV18CueCodAux = aP1_CueCodAux;
         objpobtienesaldoscuentarangosfechas.AV17cHasta = aP2_cHasta;
         objpobtienesaldoscuentarangosfechas.AV12SaldoDMN = 0 ;
         objpobtienesaldoscuentarangosfechas.AV13SaldoHMN = 0 ;
         objpobtienesaldoscuentarangosfechas.AV14SaldoDME = 0 ;
         objpobtienesaldoscuentarangosfechas.AV15SaldoHME = 0 ;
         objpobtienesaldoscuentarangosfechas.context.SetSubmitInitialConfig(context);
         objpobtienesaldoscuentarangosfechas.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienesaldoscuentarangosfechas);
         aP0_CueCod=this.AV8CueCod;
         aP1_CueCodAux=this.AV18CueCodAux;
         aP2_cHasta=this.AV17cHasta;
         aP3_SaldoDMN=this.AV12SaldoDMN;
         aP4_SaldoHMN=this.AV13SaldoHMN;
         aP5_SaldoDME=this.AV14SaldoDME;
         aP6_SaldoHME=this.AV15SaldoHME;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienesaldoscuentarangosfechas)stateInfo).executePrivate();
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
         AV12SaldoDMN = 0.00m;
         AV13SaldoHMN = 0.00m;
         AV14SaldoDME = 0.00m;
         AV15SaldoHME = 0.00m;
         AV19fInicialC = "01/01/" + StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( AV17cHasta)), 10, 0));
         AV20fInicialD = context.localUtil.CToD( AV19fInicialC, 2);
         if ( DateTimeUtil.ResetTime ( AV20fInicialD ) != DateTimeUtil.ResetTime ( AV17cHasta ) )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8CueCod ,
                                                 AV18CueCodAux ,
                                                 A91CueCod ,
                                                 A133CueCodAux ,
                                                 A135VouDFec ,
                                                 AV20fInicialD ,
                                                 AV17cHasta ,
                                                 A2077VouSts } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P00AX2 */
            pr_default.execute(0, new Object[] {AV20fInicialD, AV17cHasta, AV8CueCod, AV18CueCodAux});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A127VouAno = P00AX2_A127VouAno[0];
               A128VouMes = P00AX2_A128VouMes[0];
               A126TASICod = P00AX2_A126TASICod[0];
               A129VouNum = P00AX2_A129VouNum[0];
               A2077VouSts = P00AX2_A2077VouSts[0];
               A133CueCodAux = P00AX2_A133CueCodAux[0];
               A91CueCod = P00AX2_A91CueCod[0];
               A135VouDFec = P00AX2_A135VouDFec[0];
               A2051VouDDeb = P00AX2_A2051VouDDeb[0];
               A2055VouDHab = P00AX2_A2055VouDHab[0];
               A2052VouDDebO = P00AX2_A2052VouDDebO[0];
               A131VouDMon = P00AX2_A131VouDMon[0];
               A2056VouDHabO = P00AX2_A2056VouDHabO[0];
               A130VouDSec = P00AX2_A130VouDSec[0];
               A2077VouSts = P00AX2_A2077VouSts[0];
               AV12SaldoDMN = (decimal)(AV12SaldoDMN+A2051VouDDeb);
               AV13SaldoHMN = (decimal)(AV13SaldoHMN+A2055VouDHab);
               AV14SaldoDME = (decimal)(AV14SaldoDME+(((A131VouDMon==1) ? (decimal)(0) : A2052VouDDebO)));
               AV15SaldoHME = (decimal)(AV15SaldoHME+(((A131VouDMon==1) ? (decimal)(0) : A2056VouDHabO)));
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         this.cleanup();
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
         AV19fInicialC = "";
         AV20fInicialD = DateTime.MinValue;
         scmdbuf = "";
         A91CueCod = "";
         A133CueCodAux = "";
         A135VouDFec = DateTime.MinValue;
         P00AX2_A127VouAno = new short[1] ;
         P00AX2_A128VouMes = new short[1] ;
         P00AX2_A126TASICod = new int[1] ;
         P00AX2_A129VouNum = new string[] {""} ;
         P00AX2_A2077VouSts = new short[1] ;
         P00AX2_A133CueCodAux = new string[] {""} ;
         P00AX2_A91CueCod = new string[] {""} ;
         P00AX2_A135VouDFec = new DateTime[] {DateTime.MinValue} ;
         P00AX2_A2051VouDDeb = new decimal[1] ;
         P00AX2_A2055VouDHab = new decimal[1] ;
         P00AX2_A2052VouDDebO = new decimal[1] ;
         P00AX2_A131VouDMon = new int[1] ;
         P00AX2_A2056VouDHabO = new decimal[1] ;
         P00AX2_A130VouDSec = new int[1] ;
         A129VouNum = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienesaldoscuentarangosfechas__default(),
            new Object[][] {
                new Object[] {
               P00AX2_A127VouAno, P00AX2_A128VouMes, P00AX2_A126TASICod, P00AX2_A129VouNum, P00AX2_A2077VouSts, P00AX2_A133CueCodAux, P00AX2_A91CueCod, P00AX2_A135VouDFec, P00AX2_A2051VouDDeb, P00AX2_A2055VouDHab,
               P00AX2_A2052VouDDebO, P00AX2_A131VouDMon, P00AX2_A2056VouDHabO, P00AX2_A130VouDSec
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2077VouSts ;
      private short A127VouAno ;
      private short A128VouMes ;
      private int A126TASICod ;
      private int A131VouDMon ;
      private int A130VouDSec ;
      private decimal AV12SaldoDMN ;
      private decimal AV13SaldoHMN ;
      private decimal AV14SaldoDME ;
      private decimal AV15SaldoHME ;
      private decimal A2051VouDDeb ;
      private decimal A2055VouDHab ;
      private decimal A2052VouDDebO ;
      private decimal A2056VouDHabO ;
      private string AV8CueCod ;
      private string AV18CueCodAux ;
      private string AV19fInicialC ;
      private string scmdbuf ;
      private string A91CueCod ;
      private string A133CueCodAux ;
      private string A129VouNum ;
      private DateTime AV17cHasta ;
      private DateTime AV20fInicialD ;
      private DateTime A135VouDFec ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CueCod ;
      private string aP1_CueCodAux ;
      private DateTime aP2_cHasta ;
      private IDataStoreProvider pr_default ;
      private short[] P00AX2_A127VouAno ;
      private short[] P00AX2_A128VouMes ;
      private int[] P00AX2_A126TASICod ;
      private string[] P00AX2_A129VouNum ;
      private short[] P00AX2_A2077VouSts ;
      private string[] P00AX2_A133CueCodAux ;
      private string[] P00AX2_A91CueCod ;
      private DateTime[] P00AX2_A135VouDFec ;
      private decimal[] P00AX2_A2051VouDDeb ;
      private decimal[] P00AX2_A2055VouDHab ;
      private decimal[] P00AX2_A2052VouDDebO ;
      private int[] P00AX2_A131VouDMon ;
      private decimal[] P00AX2_A2056VouDHabO ;
      private int[] P00AX2_A130VouDSec ;
      private decimal aP3_SaldoDMN ;
      private decimal aP4_SaldoHMN ;
      private decimal aP5_SaldoDME ;
      private decimal aP6_SaldoHME ;
   }

   public class pobtienesaldoscuentarangosfechas__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AX2( IGxContext context ,
                                             string AV8CueCod ,
                                             string AV18CueCodAux ,
                                             string A91CueCod ,
                                             string A133CueCodAux ,
                                             DateTime A135VouDFec ,
                                             DateTime AV20fInicialD ,
                                             DateTime AV17cHasta ,
                                             short A2077VouSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[4];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[VouAno], T1.[VouMes], T1.[TASICod], T1.[VouNum], T2.[VouSts], T1.[CueCodAux], T1.[CueCod], T1.[VouDFec], T1.[VouDDeb], T1.[VouDHab], T1.[VouDDebO], T1.[VouDMon], T1.[VouDHabO], T1.[VouDSec] FROM ([CBVOUCHERDET] T1 INNER JOIN [CBVOUCHER] T2 ON T2.[VouAno] = T1.[VouAno] AND T2.[VouMes] = T1.[VouMes] AND T2.[TASICod] = T1.[TASICod] AND T2.[VouNum] = T1.[VouNum])";
         AddWhere(sWhereString, "(T1.[VouDFec] >= @AV20fInicialD and T1.[VouDFec] < @AV17cHasta)");
         AddWhere(sWhereString, "(T2.[VouSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CueCod)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV8CueCod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18CueCodAux)) )
         {
            AddWhere(sWhereString, "(T1.[CueCodAux] = @AV18CueCodAux)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AX2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP00AX2;
          prmP00AX2 = new Object[] {
          new ParDef("@AV20fInicialD",GXType.Date,8,0) ,
          new ParDef("@AV17cHasta",GXType.Date,8,0) ,
          new ParDef("@AV8CueCod",GXType.NChar,15,0) ,
          new ParDef("@AV18CueCodAux",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((int[]) buf[11])[0] = rslt.getInt(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((int[]) buf[13])[0] = rslt.getInt(14);
                return;
       }
    }

 }

}
