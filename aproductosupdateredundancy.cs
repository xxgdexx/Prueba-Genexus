using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class aproductosupdateredundancy : GXProcedure
   {
      public aproductosupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aproductosupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod )
      {
         this.A28ProdCod = aP0_ProdCod;
         initialize();
         executePrivate();
         aP0_ProdCod=this.A28ProdCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_ProdCod);
         return A28ProdCod ;
      }

      public void executeSubmit( ref string aP0_ProdCod )
      {
         aproductosupdateredundancy objaproductosupdateredundancy;
         objaproductosupdateredundancy = new aproductosupdateredundancy();
         objaproductosupdateredundancy.A28ProdCod = aP0_ProdCod;
         objaproductosupdateredundancy.context.SetSubmitInitialConfig(context);
         objaproductosupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaproductosupdateredundancy);
         aP0_ProdCod=this.A28ProdCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aproductosupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor APRODUCTOS2 */
         pr_default.execute(0, new Object[] {A28ProdCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A908ProdValICBPERD = APRODUCTOS2_A908ProdValICBPERD[0];
            A907ProdValICBPER = APRODUCTOS2_A907ProdValICBPER[0];
            A906ProdAfecICBPER = APRODUCTOS2_A906ProdAfecICBPER[0];
            A55ProdDsc = APRODUCTOS2_A55ProdDsc[0];
            /* Using cursor APRODUCTOS3 */
            pr_default.execute(1, new Object[] {A28ProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A149TipCod = APRODUCTOS3_A149TipCod[0];
               A24DocNum = APRODUCTOS3_A24DocNum[0];
               A932DocICBPER = APRODUCTOS3_A932DocICBPER[0];
               A905DocDICBPER = APRODUCTOS3_A905DocDICBPER[0];
               A895DocDCan = APRODUCTOS3_A895DocDCan[0];
               A230DocMonCod = APRODUCTOS3_A230DocMonCod[0];
               A233DocItem = APRODUCTOS3_A233DocItem[0];
               O905DocDICBPER = A905DocDICBPER;
               A932DocICBPER = APRODUCTOS3_A932DocICBPER[0];
               A230DocMonCod = APRODUCTOS3_A230DocMonCod[0];
               O932DocICBPER = A932DocICBPER;
               A932DocICBPER = (decimal)(O932DocICBPER+A905DocDICBPER-O905DocDICBPER);
               O905DocDICBPER = A905DocDICBPER;
               O932DocICBPER = A932DocICBPER;
               A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
               /* Using cursor APRODUCTOS4 */
               pr_default.execute(2, new Object[] {A905DocDICBPER, A149TipCod, A24DocNum, A233DocItem});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor APRODUCTOS5 */
            pr_default.execute(3, new Object[] {A28ProdCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A210PedCod = APRODUCTOS5_A210PedCod[0];
               A1598PedICBPER = APRODUCTOS5_A1598PedICBPER[0];
               A1566PedDICBPER = APRODUCTOS5_A1566PedDICBPER[0];
               A1554PedDCan = APRODUCTOS5_A1554PedDCan[0];
               A180MonCod = APRODUCTOS5_A180MonCod[0];
               A216PedDItem = APRODUCTOS5_A216PedDItem[0];
               O1566PedDICBPER = A1566PedDICBPER;
               A1598PedICBPER = APRODUCTOS5_A1598PedICBPER[0];
               A180MonCod = APRODUCTOS5_A180MonCod[0];
               O1598PedICBPER = A1598PedICBPER;
               A1598PedICBPER = (decimal)(O1598PedICBPER+A1566PedDICBPER-O1566PedDICBPER);
               O1566PedDICBPER = A1566PedDICBPER;
               O1598PedICBPER = A1598PedICBPER;
               A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
               /* Using cursor APRODUCTOS6 */
               pr_default.execute(4, new Object[] {A1566PedDICBPER, A210PedCod, A216PedDItem});
               pr_default.close(4);
               dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV2GXV55 = A55ProdDsc;
            /* Using cursor APRODUCTOS7 */
            pr_default.execute(5, new Object[] {A28ProdCod});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A210PedCod = APRODUCTOS7_A210PedCod[0];
               A1598PedICBPER = APRODUCTOS7_A1598PedICBPER[0];
               A1566PedDICBPER = APRODUCTOS7_A1566PedDICBPER[0];
               A55ProdDsc = APRODUCTOS7_A55ProdDsc[0];
               A216PedDItem = APRODUCTOS7_A216PedDItem[0];
               O1566PedDICBPER = A1566PedDICBPER;
               A1598PedICBPER = APRODUCTOS7_A1598PedICBPER[0];
               O1598PedICBPER = A1598PedICBPER;
               A1598PedICBPER = (decimal)(O1598PedICBPER+A1566PedDICBPER-O1566PedDICBPER);
               O1566PedDICBPER = A1566PedDICBPER;
               O1598PedICBPER = A1598PedICBPER;
               A55ProdDsc = AV2GXV55;
               /* Using cursor APRODUCTOS8 */
               pr_default.execute(6, new Object[] {A55ProdDsc, A210PedCod, A216PedDItem});
               pr_default.close(6);
               dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
               pr_default.readNext(5);
            }
            pr_default.close(5);
            /* Exiting from a For First loop. */
            if (true) break;
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
         APRODUCTOS2_A28ProdCod = new string[] {""} ;
         APRODUCTOS2_A908ProdValICBPERD = new decimal[1] ;
         APRODUCTOS2_A907ProdValICBPER = new decimal[1] ;
         APRODUCTOS2_A906ProdAfecICBPER = new short[1] ;
         APRODUCTOS2_A55ProdDsc = new string[] {""} ;
         A55ProdDsc = "";
         APRODUCTOS3_A149TipCod = new string[] {""} ;
         APRODUCTOS3_A24DocNum = new string[] {""} ;
         APRODUCTOS3_A28ProdCod = new string[] {""} ;
         APRODUCTOS3_A932DocICBPER = new decimal[1] ;
         APRODUCTOS3_A905DocDICBPER = new decimal[1] ;
         APRODUCTOS3_A895DocDCan = new decimal[1] ;
         APRODUCTOS3_A230DocMonCod = new int[1] ;
         APRODUCTOS3_A233DocItem = new long[1] ;
         A149TipCod = "";
         A24DocNum = "";
         APRODUCTOS5_A210PedCod = new string[] {""} ;
         APRODUCTOS5_A28ProdCod = new string[] {""} ;
         APRODUCTOS5_A1598PedICBPER = new decimal[1] ;
         APRODUCTOS5_A1566PedDICBPER = new decimal[1] ;
         APRODUCTOS5_A1554PedDCan = new decimal[1] ;
         APRODUCTOS5_A180MonCod = new int[1] ;
         APRODUCTOS5_A216PedDItem = new short[1] ;
         A210PedCod = "";
         AV2GXV55 = "";
         APRODUCTOS7_A210PedCod = new string[] {""} ;
         APRODUCTOS7_A28ProdCod = new string[] {""} ;
         APRODUCTOS7_A1598PedICBPER = new decimal[1] ;
         APRODUCTOS7_A1566PedDICBPER = new decimal[1] ;
         APRODUCTOS7_A55ProdDsc = new string[] {""} ;
         APRODUCTOS7_A216PedDItem = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductosupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               APRODUCTOS2_A28ProdCod, APRODUCTOS2_A908ProdValICBPERD, APRODUCTOS2_A907ProdValICBPER, APRODUCTOS2_A906ProdAfecICBPER, APRODUCTOS2_A55ProdDsc
               }
               , new Object[] {
               APRODUCTOS3_A149TipCod, APRODUCTOS3_A24DocNum, APRODUCTOS3_A28ProdCod, APRODUCTOS3_A932DocICBPER, APRODUCTOS3_A905DocDICBPER, APRODUCTOS3_A895DocDCan, APRODUCTOS3_A230DocMonCod, APRODUCTOS3_A233DocItem
               }
               , new Object[] {
               }
               , new Object[] {
               APRODUCTOS5_A210PedCod, APRODUCTOS5_A28ProdCod, APRODUCTOS5_A1598PedICBPER, APRODUCTOS5_A1566PedDICBPER, APRODUCTOS5_A1554PedDCan, APRODUCTOS5_A180MonCod, APRODUCTOS5_A216PedDItem
               }
               , new Object[] {
               }
               , new Object[] {
               APRODUCTOS7_A210PedCod, APRODUCTOS7_A28ProdCod, APRODUCTOS7_A1598PedICBPER, APRODUCTOS7_A1566PedDICBPER, APRODUCTOS7_A55ProdDsc, APRODUCTOS7_A216PedDItem
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A906ProdAfecICBPER ;
      private short A216PedDItem ;
      private int A230DocMonCod ;
      private int A180MonCod ;
      private long A233DocItem ;
      private decimal A908ProdValICBPERD ;
      private decimal A907ProdValICBPER ;
      private decimal A932DocICBPER ;
      private decimal A905DocDICBPER ;
      private decimal A895DocDCan ;
      private decimal O905DocDICBPER ;
      private decimal O932DocICBPER ;
      private decimal A1598PedICBPER ;
      private decimal A1566PedDICBPER ;
      private decimal A1554PedDCan ;
      private decimal O1566PedDICBPER ;
      private decimal O1598PedICBPER ;
      private string A28ProdCod ;
      private string scmdbuf ;
      private string A55ProdDsc ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A210PedCod ;
      private string AV2GXV55 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private IDataStoreProvider pr_default ;
      private string[] APRODUCTOS2_A28ProdCod ;
      private decimal[] APRODUCTOS2_A908ProdValICBPERD ;
      private decimal[] APRODUCTOS2_A907ProdValICBPER ;
      private short[] APRODUCTOS2_A906ProdAfecICBPER ;
      private string[] APRODUCTOS2_A55ProdDsc ;
      private string[] APRODUCTOS3_A149TipCod ;
      private string[] APRODUCTOS3_A24DocNum ;
      private string[] APRODUCTOS3_A28ProdCod ;
      private decimal[] APRODUCTOS3_A932DocICBPER ;
      private decimal[] APRODUCTOS3_A905DocDICBPER ;
      private decimal[] APRODUCTOS3_A895DocDCan ;
      private int[] APRODUCTOS3_A230DocMonCod ;
      private long[] APRODUCTOS3_A233DocItem ;
      private string[] APRODUCTOS5_A210PedCod ;
      private string[] APRODUCTOS5_A28ProdCod ;
      private decimal[] APRODUCTOS5_A1598PedICBPER ;
      private decimal[] APRODUCTOS5_A1566PedDICBPER ;
      private decimal[] APRODUCTOS5_A1554PedDCan ;
      private int[] APRODUCTOS5_A180MonCod ;
      private short[] APRODUCTOS5_A216PedDItem ;
      private string[] APRODUCTOS7_A210PedCod ;
      private string[] APRODUCTOS7_A28ProdCod ;
      private decimal[] APRODUCTOS7_A1598PedICBPER ;
      private decimal[] APRODUCTOS7_A1566PedDICBPER ;
      private string[] APRODUCTOS7_A55ProdDsc ;
      private short[] APRODUCTOS7_A216PedDItem ;
   }

   public class aproductosupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmAPRODUCTOS2;
          prmAPRODUCTOS2 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0)
          };
          Object[] prmAPRODUCTOS3;
          prmAPRODUCTOS3 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0)
          };
          Object[] prmAPRODUCTOS4;
          prmAPRODUCTOS4 = new Object[] {
          new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0) ,
          new ParDef("@DocItem",GXType.Decimal,10,0)
          };
          Object[] prmAPRODUCTOS5;
          prmAPRODUCTOS5 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0)
          };
          Object[] prmAPRODUCTOS6;
          prmAPRODUCTOS6 = new Object[] {
          new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@PedDItem",GXType.Int16,4,0)
          };
          Object[] prmAPRODUCTOS7;
          prmAPRODUCTOS7 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0)
          };
          Object[] prmAPRODUCTOS8;
          prmAPRODUCTOS8 = new Object[] {
          new ParDef("@ProdDsc",GXType.NChar,100,0) ,
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@PedDItem",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("APRODUCTOS2", "SELECT [ProdCod], [ProdValICBPERD], [ProdValICBPER], [ProdAfecICBPER], [ProdDsc] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAPRODUCTOS2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("APRODUCTOS3", "SELECT T1.[TipCod], T1.[DocNum], T1.[ProdCod], T2.[DocICBPER], T1.[DocDICBPER], T1.[DocDCan], T2.[DocMonCod], T1.[DocItem] FROM ([CLVENTASDET] T1 WITH (UPDLOCK) INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) WHERE T1.[ProdCod] = @ProdCod ORDER BY T1.[ProdCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAPRODUCTOS3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("APRODUCTOS4", "UPDATE [CLVENTASDET] SET [DocDICBPER]=@DocDICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmAPRODUCTOS4)
             ,new CursorDef("APRODUCTOS5", "SELECT T1.[PedCod], T1.[ProdCod], T2.[PedICBPER], T1.[PedDICBPER], T1.[PedDCan], T2.[MonCod], T1.[PedDItem] FROM ([CLPEDIDOSDET] T1 WITH (UPDLOCK) INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = T1.[PedCod]) WHERE T1.[ProdCod] = @ProdCod ORDER BY T1.[ProdCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAPRODUCTOS5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("APRODUCTOS6", "UPDATE [CLPEDIDOSDET] SET [PedDICBPER]=@PedDICBPER  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmAPRODUCTOS6)
             ,new CursorDef("APRODUCTOS7", "SELECT T1.[PedCod], T1.[ProdCod], T2.[PedICBPER], T1.[PedDICBPER], T1.[ProdDsc], T1.[PedDItem] FROM ([CLPEDIDOSDET] T1 WITH (UPDLOCK) INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = T1.[PedCod]) WHERE T1.[ProdCod] = @ProdCod ORDER BY T1.[ProdCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAPRODUCTOS7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("APRODUCTOS8", "UPDATE [CLPEDIDOSDET] SET [ProdDsc]=@ProdDsc  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmAPRODUCTOS8)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
