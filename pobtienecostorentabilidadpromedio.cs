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
   public class pobtienecostorentabilidadpromedio : GXProcedure
   {
      public pobtienecostorentabilidadpromedio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienecostorentabilidadpromedio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_nTipCod ,
                           string aP1_nDocNum ,
                           string aP2_nProdCod ,
                           long aP3_nDocItem ,
                           int aP4_Moneda ,
                           out decimal aP5_Costo )
      {
         this.AV19nTipCod = aP0_nTipCod;
         this.AV17nDocNum = aP1_nDocNum;
         this.AV18nProdCod = aP2_nProdCod;
         this.AV16nDocItem = aP3_nDocItem;
         this.AV14Moneda = aP4_Moneda;
         this.AV8Costo = 0 ;
         initialize();
         executePrivate();
         aP5_Costo=this.AV8Costo;
      }

      public decimal executeUdp( string aP0_nTipCod ,
                                 string aP1_nDocNum ,
                                 string aP2_nProdCod ,
                                 long aP3_nDocItem ,
                                 int aP4_Moneda )
      {
         execute(aP0_nTipCod, aP1_nDocNum, aP2_nProdCod, aP3_nDocItem, aP4_Moneda, out aP5_Costo);
         return AV8Costo ;
      }

      public void executeSubmit( string aP0_nTipCod ,
                                 string aP1_nDocNum ,
                                 string aP2_nProdCod ,
                                 long aP3_nDocItem ,
                                 int aP4_Moneda ,
                                 out decimal aP5_Costo )
      {
         pobtienecostorentabilidadpromedio objpobtienecostorentabilidadpromedio;
         objpobtienecostorentabilidadpromedio = new pobtienecostorentabilidadpromedio();
         objpobtienecostorentabilidadpromedio.AV19nTipCod = aP0_nTipCod;
         objpobtienecostorentabilidadpromedio.AV17nDocNum = aP1_nDocNum;
         objpobtienecostorentabilidadpromedio.AV18nProdCod = aP2_nProdCod;
         objpobtienecostorentabilidadpromedio.AV16nDocItem = aP3_nDocItem;
         objpobtienecostorentabilidadpromedio.AV14Moneda = aP4_Moneda;
         objpobtienecostorentabilidadpromedio.AV8Costo = 0 ;
         objpobtienecostorentabilidadpromedio.context.SetSubmitInitialConfig(context);
         objpobtienecostorentabilidadpromedio.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienecostorentabilidadpromedio);
         aP5_Costo=this.AV8Costo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienecostorentabilidadpromedio)stateInfo).executePrivate();
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
         AV8Costo = 0.00m;
         AV13Flag = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19nTipCod ,
                                              A30MvADItem ,
                                              AV16nDocItem ,
                                              A1370MVSts ,
                                              A23DocTip ,
                                              A24DocNum ,
                                              AV17nDocNum ,
                                              AV18nProdCod ,
                                              A28ProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00EJ2 */
         pr_default.execute(0, new Object[] {AV18nProdCod, AV19nTipCod, AV17nDocNum, AV16nDocItem});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13MvATip = P00EJ2_A13MvATip[0];
            A14MvACod = P00EJ2_A14MvACod[0];
            A1370MVSts = P00EJ2_A1370MVSts[0];
            A30MvADItem = P00EJ2_A30MvADItem[0];
            A28ProdCod = P00EJ2_A28ProdCod[0];
            A24DocNum = P00EJ2_A24DocNum[0];
            n24DocNum = P00EJ2_n24DocNum[0];
            A23DocTip = P00EJ2_A23DocTip[0];
            n23DocTip = P00EJ2_n23DocTip[0];
            A25MvAFec = P00EJ2_A25MvAFec[0];
            A1249MVADCosto = P00EJ2_A1249MVADCosto[0];
            A1370MVSts = P00EJ2_A1370MVSts[0];
            A24DocNum = P00EJ2_A24DocNum[0];
            n24DocNum = P00EJ2_n24DocNum[0];
            A23DocTip = P00EJ2_A23DocTip[0];
            n23DocTip = P00EJ2_n23DocTip[0];
            A25MvAFec = P00EJ2_A25MvAFec[0];
            AV15MVAFec = A25MvAFec;
            AV13Flag = 1;
            if ( ! ( AV14Moneda == 1 ) )
            {
               GXt_decimal1 = AV25TipVenta;
               GXt_char2 = "V";
               new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV14Moneda, ref  AV15MVAFec, ref  GXt_char2, out  GXt_decimal1) ;
               AV25TipVenta = GXt_decimal1;
               AV8Costo = (decimal)(AV8Costo+(NumberUtil.Round( A1249MVADCosto/ (decimal)(AV25TipVenta), 2)));
            }
            else
            {
               AV8Costo = (decimal)(AV8Costo+A1249MVADCosto);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( ( AV13Flag == 0 ) && ( ( StringUtil.StrCmp(AV19nTipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV19nTipCod, "ND") == 0 ) ) )
         {
            /* Using cursor P00EJ3 */
            pr_default.execute(1, new Object[] {AV19nTipCod, AV17nDocNum});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A24DocNum = P00EJ3_A24DocNum[0];
               n24DocNum = P00EJ3_n24DocNum[0];
               A149TipCod = P00EJ3_A149TipCod[0];
               A950DocTRef = P00EJ3_A950DocTRef[0];
               A939DocRef = P00EJ3_A939DocRef[0];
               AV29DocTRef = A950DocTRef;
               AV28DocRef = A939DocRef;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV19nTipCod ,
                                                 A30MvADItem ,
                                                 AV16nDocItem ,
                                                 A1370MVSts ,
                                                 A23DocTip ,
                                                 AV29DocTRef ,
                                                 A24DocNum ,
                                                 AV28DocRef ,
                                                 AV18nProdCod ,
                                                 A28ProdCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P00EJ4 */
            pr_default.execute(2, new Object[] {AV18nProdCod, AV29DocTRef, AV28DocRef, AV16nDocItem});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A13MvATip = P00EJ4_A13MvATip[0];
               A14MvACod = P00EJ4_A14MvACod[0];
               A1370MVSts = P00EJ4_A1370MVSts[0];
               A30MvADItem = P00EJ4_A30MvADItem[0];
               A28ProdCod = P00EJ4_A28ProdCod[0];
               A24DocNum = P00EJ4_A24DocNum[0];
               n24DocNum = P00EJ4_n24DocNum[0];
               A23DocTip = P00EJ4_A23DocTip[0];
               n23DocTip = P00EJ4_n23DocTip[0];
               A25MvAFec = P00EJ4_A25MvAFec[0];
               A1249MVADCosto = P00EJ4_A1249MVADCosto[0];
               A1370MVSts = P00EJ4_A1370MVSts[0];
               A24DocNum = P00EJ4_A24DocNum[0];
               n24DocNum = P00EJ4_n24DocNum[0];
               A23DocTip = P00EJ4_A23DocTip[0];
               n23DocTip = P00EJ4_n23DocTip[0];
               A25MvAFec = P00EJ4_A25MvAFec[0];
               AV15MVAFec = A25MvAFec;
               AV13Flag = 1;
               if ( ! ( AV14Moneda == 1 ) )
               {
                  GXt_decimal1 = AV25TipVenta;
                  GXt_char2 = "V";
                  new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV14Moneda, ref  AV15MVAFec, ref  GXt_char2, out  GXt_decimal1) ;
                  AV25TipVenta = GXt_decimal1;
                  AV8Costo = (decimal)(AV8Costo+(NumberUtil.Round( A1249MVADCosto/ (decimal)(AV25TipVenta), 2)));
               }
               else
               {
                  AV8Costo = (decimal)(AV8Costo+A1249MVADCosto);
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         AV8Costo = ((StringUtil.StrCmp(AV19nTipCod, "NC")==0) ? AV8Costo*-1 : AV8Costo);
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
         A1370MVSts = "";
         A23DocTip = "";
         A24DocNum = "";
         A28ProdCod = "";
         P00EJ2_A13MvATip = new string[] {""} ;
         P00EJ2_A14MvACod = new string[] {""} ;
         P00EJ2_A1370MVSts = new string[] {""} ;
         P00EJ2_A30MvADItem = new int[1] ;
         P00EJ2_A28ProdCod = new string[] {""} ;
         P00EJ2_A24DocNum = new string[] {""} ;
         P00EJ2_n24DocNum = new bool[] {false} ;
         P00EJ2_A23DocTip = new string[] {""} ;
         P00EJ2_n23DocTip = new bool[] {false} ;
         P00EJ2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EJ2_A1249MVADCosto = new decimal[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A25MvAFec = DateTime.MinValue;
         AV15MVAFec = DateTime.MinValue;
         P00EJ3_A24DocNum = new string[] {""} ;
         P00EJ3_n24DocNum = new bool[] {false} ;
         P00EJ3_A149TipCod = new string[] {""} ;
         P00EJ3_A950DocTRef = new string[] {""} ;
         P00EJ3_A939DocRef = new string[] {""} ;
         A149TipCod = "";
         A950DocTRef = "";
         A939DocRef = "";
         AV29DocTRef = "";
         AV28DocRef = "";
         P00EJ4_A13MvATip = new string[] {""} ;
         P00EJ4_A14MvACod = new string[] {""} ;
         P00EJ4_A1370MVSts = new string[] {""} ;
         P00EJ4_A30MvADItem = new int[1] ;
         P00EJ4_A28ProdCod = new string[] {""} ;
         P00EJ4_A24DocNum = new string[] {""} ;
         P00EJ4_n24DocNum = new bool[] {false} ;
         P00EJ4_A23DocTip = new string[] {""} ;
         P00EJ4_n23DocTip = new bool[] {false} ;
         P00EJ4_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P00EJ4_A1249MVADCosto = new decimal[1] ;
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pobtienecostorentabilidadpromedio__default(),
            new Object[][] {
                new Object[] {
               P00EJ2_A13MvATip, P00EJ2_A14MvACod, P00EJ2_A1370MVSts, P00EJ2_A30MvADItem, P00EJ2_A28ProdCod, P00EJ2_A24DocNum, P00EJ2_n24DocNum, P00EJ2_A23DocTip, P00EJ2_n23DocTip, P00EJ2_A25MvAFec,
               P00EJ2_A1249MVADCosto
               }
               , new Object[] {
               P00EJ3_A24DocNum, P00EJ3_A149TipCod, P00EJ3_A950DocTRef, P00EJ3_A939DocRef
               }
               , new Object[] {
               P00EJ4_A13MvATip, P00EJ4_A14MvACod, P00EJ4_A1370MVSts, P00EJ4_A30MvADItem, P00EJ4_A28ProdCod, P00EJ4_A24DocNum, P00EJ4_n24DocNum, P00EJ4_A23DocTip, P00EJ4_n23DocTip, P00EJ4_A25MvAFec,
               P00EJ4_A1249MVADCosto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13Flag ;
      private int AV14Moneda ;
      private int A30MvADItem ;
      private long AV16nDocItem ;
      private decimal AV8Costo ;
      private decimal A1249MVADCosto ;
      private decimal AV25TipVenta ;
      private decimal GXt_decimal1 ;
      private string AV19nTipCod ;
      private string AV17nDocNum ;
      private string AV18nProdCod ;
      private string scmdbuf ;
      private string A1370MVSts ;
      private string A23DocTip ;
      private string A24DocNum ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A149TipCod ;
      private string A950DocTRef ;
      private string A939DocRef ;
      private string AV29DocTRef ;
      private string AV28DocRef ;
      private string GXt_char2 ;
      private DateTime A25MvAFec ;
      private DateTime AV15MVAFec ;
      private bool n24DocNum ;
      private bool n23DocTip ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00EJ2_A13MvATip ;
      private string[] P00EJ2_A14MvACod ;
      private string[] P00EJ2_A1370MVSts ;
      private int[] P00EJ2_A30MvADItem ;
      private string[] P00EJ2_A28ProdCod ;
      private string[] P00EJ2_A24DocNum ;
      private bool[] P00EJ2_n24DocNum ;
      private string[] P00EJ2_A23DocTip ;
      private bool[] P00EJ2_n23DocTip ;
      private DateTime[] P00EJ2_A25MvAFec ;
      private decimal[] P00EJ2_A1249MVADCosto ;
      private string[] P00EJ3_A24DocNum ;
      private bool[] P00EJ3_n24DocNum ;
      private string[] P00EJ3_A149TipCod ;
      private string[] P00EJ3_A950DocTRef ;
      private string[] P00EJ3_A939DocRef ;
      private string[] P00EJ4_A13MvATip ;
      private string[] P00EJ4_A14MvACod ;
      private string[] P00EJ4_A1370MVSts ;
      private int[] P00EJ4_A30MvADItem ;
      private string[] P00EJ4_A28ProdCod ;
      private string[] P00EJ4_A24DocNum ;
      private bool[] P00EJ4_n24DocNum ;
      private string[] P00EJ4_A23DocTip ;
      private bool[] P00EJ4_n23DocTip ;
      private DateTime[] P00EJ4_A25MvAFec ;
      private decimal[] P00EJ4_A1249MVADCosto ;
      private decimal aP5_Costo ;
   }

   public class pobtienecostorentabilidadpromedio__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EJ2( IGxContext context ,
                                             string AV19nTipCod ,
                                             int A30MvADItem ,
                                             long AV16nDocItem ,
                                             string A1370MVSts ,
                                             string A23DocTip ,
                                             string A24DocNum ,
                                             string AV17nDocNum ,
                                             string AV18nProdCod ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[4];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MVSts], T1.[MvADItem], T1.[ProdCod], T2.[DocNum], T2.[DocTip], T2.[MvAFec], T1.[MVADCosto] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV18nProdCod)");
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[DocTip] = @AV19nTipCod)");
         AddWhere(sWhereString, "(T2.[DocNum] = @AV17nDocNum)");
         if ( ! ( StringUtil.StrCmp(AV19nTipCod, "NC") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MvADItem] = @AV16nDocItem)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00EJ4( IGxContext context ,
                                             string AV19nTipCod ,
                                             int A30MvADItem ,
                                             long AV16nDocItem ,
                                             string A1370MVSts ,
                                             string A23DocTip ,
                                             string AV29DocTRef ,
                                             string A24DocNum ,
                                             string AV28DocRef ,
                                             string AV18nProdCod ,
                                             string A28ProdCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[4];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T2.[MVSts], T1.[MvADItem], T1.[ProdCod], T2.[DocNum], T2.[DocTip], T2.[MvAFec], T1.[MVADCosto] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV18nProdCod)");
         AddWhere(sWhereString, "(T2.[MVSts] <> 'A')");
         AddWhere(sWhereString, "(T2.[DocTip] = @AV29DocTRef)");
         AddWhere(sWhereString, "(T2.[DocNum] = @AV28DocRef)");
         if ( ! ( StringUtil.StrCmp(AV19nTipCod, "NC") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MvADItem] = @AV16nDocItem)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
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
                     return conditional_P00EJ2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] );
               case 2 :
                     return conditional_P00EJ4(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (long)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] );
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
          Object[] prmP00EJ3;
          prmP00EJ3 = new Object[] {
          new ParDef("@AV19nTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV17nDocNum",GXType.NChar,12,0)
          };
          Object[] prmP00EJ2;
          prmP00EJ2 = new Object[] {
          new ParDef("@AV18nProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV19nTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV17nDocNum",GXType.NChar,12,0) ,
          new ParDef("@AV16nDocItem",GXType.Decimal,10,0)
          };
          Object[] prmP00EJ4;
          prmP00EJ4 = new Object[] {
          new ParDef("@AV18nProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV29DocTRef",GXType.NChar,3,0) ,
          new ParDef("@AV28DocRef",GXType.NChar,12,0) ,
          new ParDef("@AV16nDocItem",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EJ3", "SELECT [DocNum], [TipCod], [DocTRef], [DocRef] FROM [CLVENTAS] WHERE [TipCod] = @AV19nTipCod and [DocNum] = @AV17nDocNum ORDER BY [TipCod], [DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EJ3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EJ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EJ4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 12);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((string[]) buf[5])[0] = rslt.getString(6, 12);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(9);
                return;
       }
    }

 }

}
