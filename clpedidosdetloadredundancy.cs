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
   public class clpedidosdetloadredundancy : GXProcedure
   {
      public clpedidosdetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidosdetloadredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         clpedidosdetloadredundancy objclpedidosdetloadredundancy;
         objclpedidosdetloadredundancy = new clpedidosdetloadredundancy();
         objclpedidosdetloadredundancy.context.SetSubmitInitialConfig(context);
         objclpedidosdetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclpedidosdetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clpedidosdetloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLPEDIDOSD2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210PedCod = CLPEDIDOSD2_A210PedCod[0];
            A28ProdCod = CLPEDIDOSD2_A28ProdCod[0];
            A55ProdDsc = CLPEDIDOSD2_A55ProdDsc[0];
            A55ProdDsc = CLPEDIDOSD2_A55ProdDsc[0];
            A1556PedDDct2 = CLPEDIDOSD2_A1556PedDDct2[0];
            A1555PedDDct = CLPEDIDOSD2_A1555PedDDct[0];
            A1551PedDTot = CLPEDIDOSD2_A1551PedDTot[0];
            A1592PedDTotInc = CLPEDIDOSD2_A1592PedDTotInc[0];
            A908ProdValICBPERD = CLPEDIDOSD2_A908ProdValICBPERD[0];
            A907ProdValICBPER = CLPEDIDOSD2_A907ProdValICBPER[0];
            A180MonCod = CLPEDIDOSD2_A180MonCod[0];
            A906ProdAfecICBPER = CLPEDIDOSD2_A906ProdAfecICBPER[0];
            A1566PedDICBPER = CLPEDIDOSD2_A1566PedDICBPER[0];
            A1574PedDPreInc = CLPEDIDOSD2_A1574PedDPreInc[0];
            A1554PedDCan = CLPEDIDOSD2_A1554PedDCan[0];
            A1553PedDPre = CLPEDIDOSD2_A1553PedDPre[0];
            A216PedDItem = CLPEDIDOSD2_A216PedDItem[0];
            O55ProdDsc = A55ProdDsc;
            A180MonCod = CLPEDIDOSD2_A180MonCod[0];
            A55ProdDsc = CLPEDIDOSD2_A55ProdDsc[0];
            A908ProdValICBPERD = CLPEDIDOSD2_A908ProdValICBPERD[0];
            A907ProdValICBPER = CLPEDIDOSD2_A907ProdValICBPER[0];
            A906ProdAfecICBPER = CLPEDIDOSD2_A906ProdAfecICBPER[0];
            O55ProdDsc = A55ProdDsc;
            A1552PedDSub = NumberUtil.Round( A1553PedDPre*A1554PedDCan, 4);
            A1591PedDSubInc = NumberUtil.Round( A1574PedDPreInc*A1554PedDCan, 4);
            A55ProdDsc = O55ProdDsc;
            O55ProdDsc = A55ProdDsc;
            A1551PedDTot = NumberUtil.Round( (A1552PedDSub)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 8);
            A1592PedDTotInc = NumberUtil.Round( (A1591PedDSubInc)*(1-(A1555PedDDct/ (decimal)(100)))*(1-(A1556PedDDct2/ (decimal)(100))), 2);
            A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
            /* Using cursor CLPEDIDOSD3 */
            pr_default.execute(1, new Object[] {A55ProdDsc, A1551PedDTot, A1592PedDTotInc, A1566PedDICBPER, A210PedCod, A216PedDItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
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
         CLPEDIDOSD2_A210PedCod = new string[] {""} ;
         CLPEDIDOSD2_A28ProdCod = new string[] {""} ;
         CLPEDIDOSD2_A55ProdDsc = new string[] {""} ;
         CLPEDIDOSD2_A1556PedDDct2 = new decimal[1] ;
         CLPEDIDOSD2_A1555PedDDct = new decimal[1] ;
         CLPEDIDOSD2_A1551PedDTot = new decimal[1] ;
         CLPEDIDOSD2_A1592PedDTotInc = new decimal[1] ;
         CLPEDIDOSD2_A908ProdValICBPERD = new decimal[1] ;
         CLPEDIDOSD2_A907ProdValICBPER = new decimal[1] ;
         CLPEDIDOSD2_A180MonCod = new int[1] ;
         CLPEDIDOSD2_A906ProdAfecICBPER = new short[1] ;
         CLPEDIDOSD2_A1566PedDICBPER = new decimal[1] ;
         CLPEDIDOSD2_A1574PedDPreInc = new decimal[1] ;
         CLPEDIDOSD2_A1554PedDCan = new decimal[1] ;
         CLPEDIDOSD2_A1553PedDPre = new decimal[1] ;
         CLPEDIDOSD2_A216PedDItem = new short[1] ;
         A210PedCod = "";
         A28ProdCod = "";
         A55ProdDsc = "";
         O55ProdDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidosdetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLPEDIDOSD2_A210PedCod, CLPEDIDOSD2_A28ProdCod, CLPEDIDOSD2_A55ProdDsc, CLPEDIDOSD2_A55ProdDsc, CLPEDIDOSD2_A1556PedDDct2, CLPEDIDOSD2_A1555PedDDct, CLPEDIDOSD2_A1551PedDTot, CLPEDIDOSD2_A1592PedDTotInc, CLPEDIDOSD2_A908ProdValICBPERD, CLPEDIDOSD2_A907ProdValICBPER,
               CLPEDIDOSD2_A180MonCod, CLPEDIDOSD2_A906ProdAfecICBPER, CLPEDIDOSD2_A1566PedDICBPER, CLPEDIDOSD2_A1574PedDPreInc, CLPEDIDOSD2_A1554PedDCan, CLPEDIDOSD2_A1553PedDPre, CLPEDIDOSD2_A216PedDItem
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
      private int A180MonCod ;
      private decimal A1556PedDDct2 ;
      private decimal A1555PedDDct ;
      private decimal A1551PedDTot ;
      private decimal A1592PedDTotInc ;
      private decimal A908ProdValICBPERD ;
      private decimal A907ProdValICBPER ;
      private decimal A1566PedDICBPER ;
      private decimal A1574PedDPreInc ;
      private decimal A1554PedDCan ;
      private decimal A1553PedDPre ;
      private decimal A1552PedDSub ;
      private decimal A1591PedDSubInc ;
      private string scmdbuf ;
      private string A210PedCod ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string O55ProdDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLPEDIDOSD2_A210PedCod ;
      private string[] CLPEDIDOSD2_A28ProdCod ;
      private string[] CLPEDIDOSD2_A55ProdDsc ;
      private decimal[] CLPEDIDOSD2_A1556PedDDct2 ;
      private decimal[] CLPEDIDOSD2_A1555PedDDct ;
      private decimal[] CLPEDIDOSD2_A1551PedDTot ;
      private decimal[] CLPEDIDOSD2_A1592PedDTotInc ;
      private decimal[] CLPEDIDOSD2_A908ProdValICBPERD ;
      private decimal[] CLPEDIDOSD2_A907ProdValICBPER ;
      private int[] CLPEDIDOSD2_A180MonCod ;
      private short[] CLPEDIDOSD2_A906ProdAfecICBPER ;
      private decimal[] CLPEDIDOSD2_A1566PedDICBPER ;
      private decimal[] CLPEDIDOSD2_A1574PedDPreInc ;
      private decimal[] CLPEDIDOSD2_A1554PedDCan ;
      private decimal[] CLPEDIDOSD2_A1553PedDPre ;
      private short[] CLPEDIDOSD2_A216PedDItem ;
   }

   public class clpedidosdetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmCLPEDIDOSD2;
          prmCLPEDIDOSD2 = new Object[] {
          };
          Object[] prmCLPEDIDOSD3;
          prmCLPEDIDOSD3 = new Object[] {
          new ParDef("@ProdDsc",GXType.NChar,100,0) ,
          new ParDef("@PedDTot",GXType.Decimal,18,8) ,
          new ParDef("@PedDTotInc",GXType.Decimal,15,4) ,
          new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@PedDItem",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLPEDIDOSD2", "SELECT T1.[PedCod], T1.[ProdCod], T1.[ProdDsc], T3.[ProdDsc], T1.[PedDDct2], T1.[PedDDct], T1.[PedDTot], T1.[PedDTotInc], T3.[ProdValICBPERD], T3.[ProdValICBPER], T2.[MonCod], T3.[ProdAfecICBPER], T1.[PedDICBPER], T1.[PedDPreInc], T1.[PedDCan], T1.[PedDPre], T1.[PedDItem] FROM (([CLPEDIDOSDET] T1 WITH (UPDLOCK) INNER JOIN [CLPEDIDOS] T2 ON T2.[PedCod] = T1.[PedCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) ORDER BY T1.[PedCod], T1.[PedDItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLPEDIDOSD2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLPEDIDOSD3", "UPDATE [CLPEDIDOSDET] SET [ProdDsc]=@ProdDsc, [PedDTot]=@PedDTot, [PedDTotInc]=@PedDTotInc, [PedDICBPER]=@PedDICBPER  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLPEDIDOSD3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
                ((short[]) buf[16])[0] = rslt.getShort(17);
                return;
       }
    }

 }

}
