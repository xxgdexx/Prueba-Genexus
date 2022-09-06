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
namespace GeneXus.Programs {
   public class pobtenerventastclientemensual : GXProcedure
   {
      public pobtenerventastclientemensual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtenerventastclientemensual( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_Moneda ,
                           ref int aP1_TipCCod ,
                           ref short aP2_Ano ,
                           ref short aP3_Mes ,
                           out decimal aP4_Total )
      {
         this.AV12Moneda = aP0_Moneda;
         this.AV11TipCCod = aP1_TipCCod;
         this.AV8Ano = aP2_Ano;
         this.AV9Mes = aP3_Mes;
         this.AV10Total = 0 ;
         initialize();
         executePrivate();
         aP0_Moneda=this.AV12Moneda;
         aP1_TipCCod=this.AV11TipCCod;
         aP2_Ano=this.AV8Ano;
         aP3_Mes=this.AV9Mes;
         aP4_Total=this.AV10Total;
      }

      public decimal executeUdp( ref int aP0_Moneda ,
                                 ref int aP1_TipCCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes )
      {
         execute(ref aP0_Moneda, ref aP1_TipCCod, ref aP2_Ano, ref aP3_Mes, out aP4_Total);
         return AV10Total ;
      }

      public void executeSubmit( ref int aP0_Moneda ,
                                 ref int aP1_TipCCod ,
                                 ref short aP2_Ano ,
                                 ref short aP3_Mes ,
                                 out decimal aP4_Total )
      {
         pobtenerventastclientemensual objpobtenerventastclientemensual;
         objpobtenerventastclientemensual = new pobtenerventastclientemensual();
         objpobtenerventastclientemensual.AV12Moneda = aP0_Moneda;
         objpobtenerventastclientemensual.AV11TipCCod = aP1_TipCCod;
         objpobtenerventastclientemensual.AV8Ano = aP2_Ano;
         objpobtenerventastclientemensual.AV9Mes = aP3_Mes;
         objpobtenerventastclientemensual.AV10Total = 0 ;
         objpobtenerventastclientemensual.context.SetSubmitInitialConfig(context);
         objpobtenerventastclientemensual.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtenerventastclientemensual);
         aP0_Moneda=this.AV12Moneda;
         aP1_TipCCod=this.AV11TipCCod;
         aP2_Ano=this.AV8Ano;
         aP3_Mes=this.AV9Mes;
         aP4_Total=this.AV10Total;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtenerventastclientemensual)stateInfo).executePrivate();
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
         AV10Total = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9Mes ,
                                              A232DocFec ,
                                              AV8Ano ,
                                              A941DocSts ,
                                              A159TipCCod ,
                                              AV11TipCCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         /* Using cursor P00ET2 */
         pr_default.execute(0, new Object[] {AV8Ano, AV11TipCCod, AV9Mes});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A231DocCliCod = P00ET2_A231DocCliCod[0];
            A941DocSts = P00ET2_A941DocSts[0];
            A159TipCCod = P00ET2_A159TipCCod[0];
            n159TipCCod = P00ET2_n159TipCCod[0];
            A232DocFec = P00ET2_A232DocFec[0];
            A149TipCod = P00ET2_A149TipCod[0];
            A24DocNum = P00ET2_A24DocNum[0];
            A511TipSigno = P00ET2_A511TipSigno[0];
            A230DocMonCod = P00ET2_A230DocMonCod[0];
            A899DocDcto = P00ET2_A899DocDcto[0];
            A892DocDTot = P00ET2_A892DocDTot[0];
            A929DocFecRef = P00ET2_A929DocFecRef[0];
            A233DocItem = P00ET2_A233DocItem[0];
            A511TipSigno = P00ET2_A511TipSigno[0];
            A231DocCliCod = P00ET2_A231DocCliCod[0];
            A941DocSts = P00ET2_A941DocSts[0];
            A232DocFec = P00ET2_A232DocFec[0];
            A230DocMonCod = P00ET2_A230DocMonCod[0];
            A899DocDcto = P00ET2_A899DocDcto[0];
            A929DocFecRef = P00ET2_A929DocFecRef[0];
            A159TipCCod = P00ET2_A159TipCCod[0];
            n159TipCCod = P00ET2_n159TipCCod[0];
            AV13TipCod = A149TipCod;
            AV16DocNum = A24DocNum;
            AV15TipSigno = A511TipSigno;
            AV14DocMonCod = A230DocMonCod;
            AV17PorDscto = A899DocDcto;
            AV18Descuento = NumberUtil.Round( (A892DocDTot*AV17PorDscto)/ (decimal)(100), 2);
            AV19DocTot = NumberUtil.Round( (A892DocDTot-AV18Descuento)*A511TipSigno, 2);
            AV20DocFec = ((StringUtil.StrCmp(AV13TipCod, "NC")==0)||(StringUtil.StrCmp(AV13TipCod, "ND")==0) ? A929DocFecRef : A232DocFec);
            AV21TipCmb = (decimal)(1);
            if ( AV12Moneda == 1 )
            {
               if ( AV14DocMonCod != 1 )
               {
                  GXt_decimal1 = AV21TipCmb;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV14DocMonCod, ref  AV20DocFec, ref  GXt_char2, out  GXt_decimal1) ;
                  AV21TipCmb = GXt_decimal1;
                  AV19DocTot = NumberUtil.Round( AV19DocTot*AV21TipCmb, 2);
               }
            }
            else
            {
               if ( AV14DocMonCod == 1 )
               {
                  GXt_decimal1 = AV21TipCmb;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV12Moneda, ref  AV20DocFec, ref  GXt_char2, out  GXt_decimal1) ;
                  AV21TipCmb = GXt_decimal1;
                  AV19DocTot = NumberUtil.Round( AV19DocTot/ (decimal)(AV21TipCmb), 2);
               }
            }
            AV10Total = (decimal)(AV10Total+AV19DocTot);
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         A232DocFec = DateTime.MinValue;
         A941DocSts = "";
         P00ET2_A231DocCliCod = new string[] {""} ;
         P00ET2_A941DocSts = new string[] {""} ;
         P00ET2_A159TipCCod = new int[1] ;
         P00ET2_n159TipCCod = new bool[] {false} ;
         P00ET2_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P00ET2_A149TipCod = new string[] {""} ;
         P00ET2_A24DocNum = new string[] {""} ;
         P00ET2_A511TipSigno = new short[1] ;
         P00ET2_A230DocMonCod = new int[1] ;
         P00ET2_A899DocDcto = new decimal[1] ;
         P00ET2_A892DocDTot = new decimal[1] ;
         P00ET2_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P00ET2_A233DocItem = new long[1] ;
         A231DocCliCod = "";
         A149TipCod = "";
         A24DocNum = "";
         A929DocFecRef = DateTime.MinValue;
         AV13TipCod = "";
         AV16DocNum = "";
         AV20DocFec = DateTime.MinValue;
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pobtenerventastclientemensual__default(),
            new Object[][] {
                new Object[] {
               P00ET2_A231DocCliCod, P00ET2_A941DocSts, P00ET2_A159TipCCod, P00ET2_n159TipCCod, P00ET2_A232DocFec, P00ET2_A149TipCod, P00ET2_A24DocNum, P00ET2_A511TipSigno, P00ET2_A230DocMonCod, P00ET2_A899DocDcto,
               P00ET2_A892DocDTot, P00ET2_A929DocFecRef, P00ET2_A233DocItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short A511TipSigno ;
      private short AV15TipSigno ;
      private int AV12Moneda ;
      private int AV11TipCCod ;
      private int A159TipCCod ;
      private int A230DocMonCod ;
      private int AV14DocMonCod ;
      private long A233DocItem ;
      private decimal AV10Total ;
      private decimal A899DocDcto ;
      private decimal A892DocDTot ;
      private decimal AV17PorDscto ;
      private decimal AV18Descuento ;
      private decimal AV19DocTot ;
      private decimal AV21TipCmb ;
      private decimal GXt_decimal1 ;
      private string scmdbuf ;
      private string A941DocSts ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string AV13TipCod ;
      private string AV16DocNum ;
      private string GXt_char2 ;
      private DateTime A232DocFec ;
      private DateTime A929DocFecRef ;
      private DateTime AV20DocFec ;
      private bool n159TipCCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_Moneda ;
      private int aP1_TipCCod ;
      private short aP2_Ano ;
      private short aP3_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P00ET2_A231DocCliCod ;
      private string[] P00ET2_A941DocSts ;
      private int[] P00ET2_A159TipCCod ;
      private bool[] P00ET2_n159TipCCod ;
      private DateTime[] P00ET2_A232DocFec ;
      private string[] P00ET2_A149TipCod ;
      private string[] P00ET2_A24DocNum ;
      private short[] P00ET2_A511TipSigno ;
      private int[] P00ET2_A230DocMonCod ;
      private decimal[] P00ET2_A899DocDcto ;
      private decimal[] P00ET2_A892DocDTot ;
      private DateTime[] P00ET2_A929DocFecRef ;
      private long[] P00ET2_A233DocItem ;
      private decimal aP4_Total ;
   }

   public class pobtenerventastclientemensual__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00ET2( IGxContext context ,
                                             short AV9Mes ,
                                             DateTime A232DocFec ,
                                             short AV8Ano ,
                                             string A941DocSts ,
                                             int A159TipCCod ,
                                             int AV11TipCCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[3];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T3.[DocCliCod] AS DocCliCod, T3.[DocSts], T4.[TipCCod], T3.[DocFec], T1.[TipCod], T1.[DocNum], T2.[TipSigno], T3.[DocMonCod], T3.[DocDcto], T1.[DocDTot], T3.[DocFecRef], T1.[DocItem] FROM ((([CLVENTASDET] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CLVENTAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T3.[DocCliCod])";
         AddWhere(sWhereString, "(YEAR(T3.[DocFec]) = @AV8Ano)");
         AddWhere(sWhereString, "(T3.[DocSts] <> 'A')");
         AddWhere(sWhereString, "(T4.[TipCCod] = @AV11TipCCod)");
         if ( ! (0==AV9Mes) )
         {
            AddWhere(sWhereString, "(MONTH(T3.[DocFec]) = @AV9Mes)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00ET2(context, (short)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] );
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
          Object[] prmP00ET2;
          prmP00ET2 = new Object[] {
          new ParDef("@AV8Ano",GXType.Int16,4,0) ,
          new ParDef("@AV11TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV9Mes",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ET2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ET2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 12);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(10);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(11);
                ((long[]) buf[12])[0] = rslt.getLong(12);
                return;
       }
    }

 }

}
