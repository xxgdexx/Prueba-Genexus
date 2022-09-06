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
   public class clpedidosupdateredundancy : GXProcedure
   {
      public clpedidosupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidosupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PedCod )
      {
         this.A210PedCod = aP0_PedCod;
         initialize();
         executePrivate();
         aP0_PedCod=this.A210PedCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_PedCod);
         return A210PedCod ;
      }

      public void executeSubmit( ref string aP0_PedCod )
      {
         clpedidosupdateredundancy objclpedidosupdateredundancy;
         objclpedidosupdateredundancy = new clpedidosupdateredundancy();
         objclpedidosupdateredundancy.A210PedCod = aP0_PedCod;
         objclpedidosupdateredundancy.context.SetSubmitInitialConfig(context);
         objclpedidosupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclpedidosupdateredundancy);
         aP0_PedCod=this.A210PedCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clpedidosupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLPEDIDOSU2 */
         pr_default.execute(0, new Object[] {A210PedCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A180MonCod = CLPEDIDOSU2_A180MonCod[0];
            /* Using cursor CLPEDIDOSU3 */
            pr_default.execute(1, new Object[] {A210PedCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = CLPEDIDOSU3_A28ProdCod[0];
               A1598PedICBPER = CLPEDIDOSU3_A1598PedICBPER[0];
               A1566PedDICBPER = CLPEDIDOSU3_A1566PedDICBPER[0];
               A908ProdValICBPERD = CLPEDIDOSU3_A908ProdValICBPERD[0];
               A1554PedDCan = CLPEDIDOSU3_A1554PedDCan[0];
               A907ProdValICBPER = CLPEDIDOSU3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLPEDIDOSU3_A906ProdAfecICBPER[0];
               A216PedDItem = CLPEDIDOSU3_A216PedDItem[0];
               O1566PedDICBPER = A1566PedDICBPER;
               A908ProdValICBPERD = CLPEDIDOSU3_A908ProdValICBPERD[0];
               A907ProdValICBPER = CLPEDIDOSU3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLPEDIDOSU3_A906ProdAfecICBPER[0];
               A1598PedICBPER = CLPEDIDOSU3_A1598PedICBPER[0];
               O1598PedICBPER = A1598PedICBPER;
               A1598PedICBPER = (decimal)(O1598PedICBPER+A1566PedDICBPER-O1566PedDICBPER);
               O1566PedDICBPER = A1566PedDICBPER;
               O1598PedICBPER = A1598PedICBPER;
               A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
               /* Using cursor CLPEDIDOSU4 */
               pr_default.execute(2, new Object[] {A1566PedDICBPER, A210PedCod, A216PedDItem});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
               pr_default.readNext(1);
            }
            pr_default.close(1);
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
         CLPEDIDOSU2_A210PedCod = new string[] {""} ;
         CLPEDIDOSU2_A180MonCod = new int[1] ;
         CLPEDIDOSU3_A28ProdCod = new string[] {""} ;
         CLPEDIDOSU3_A210PedCod = new string[] {""} ;
         CLPEDIDOSU3_A1598PedICBPER = new decimal[1] ;
         CLPEDIDOSU3_A1566PedDICBPER = new decimal[1] ;
         CLPEDIDOSU3_A908ProdValICBPERD = new decimal[1] ;
         CLPEDIDOSU3_A1554PedDCan = new decimal[1] ;
         CLPEDIDOSU3_A907ProdValICBPER = new decimal[1] ;
         CLPEDIDOSU3_A906ProdAfecICBPER = new short[1] ;
         CLPEDIDOSU3_A216PedDItem = new short[1] ;
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidosupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               CLPEDIDOSU2_A210PedCod, CLPEDIDOSU2_A180MonCod
               }
               , new Object[] {
               CLPEDIDOSU3_A28ProdCod, CLPEDIDOSU3_A210PedCod, CLPEDIDOSU3_A1598PedICBPER, CLPEDIDOSU3_A1566PedDICBPER, CLPEDIDOSU3_A908ProdValICBPERD, CLPEDIDOSU3_A1554PedDCan, CLPEDIDOSU3_A907ProdValICBPER, CLPEDIDOSU3_A906ProdAfecICBPER, CLPEDIDOSU3_A216PedDItem
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
      private decimal A1598PedICBPER ;
      private decimal A1566PedDICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A1554PedDCan ;
      private decimal A907ProdValICBPER ;
      private decimal O1566PedDICBPER ;
      private decimal O1598PedICBPER ;
      private string A210PedCod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PedCod ;
      private IDataStoreProvider pr_default ;
      private string[] CLPEDIDOSU2_A210PedCod ;
      private int[] CLPEDIDOSU2_A180MonCod ;
      private string[] CLPEDIDOSU3_A28ProdCod ;
      private string[] CLPEDIDOSU3_A210PedCod ;
      private decimal[] CLPEDIDOSU3_A1598PedICBPER ;
      private decimal[] CLPEDIDOSU3_A1566PedDICBPER ;
      private decimal[] CLPEDIDOSU3_A908ProdValICBPERD ;
      private decimal[] CLPEDIDOSU3_A1554PedDCan ;
      private decimal[] CLPEDIDOSU3_A907ProdValICBPER ;
      private short[] CLPEDIDOSU3_A906ProdAfecICBPER ;
      private short[] CLPEDIDOSU3_A216PedDItem ;
   }

   public class clpedidosupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmCLPEDIDOSU2;
          prmCLPEDIDOSU2 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0)
          };
          Object[] prmCLPEDIDOSU3;
          prmCLPEDIDOSU3 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0)
          };
          Object[] prmCLPEDIDOSU4;
          prmCLPEDIDOSU4 = new Object[] {
          new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@PedDItem",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLPEDIDOSU2", "SELECT [PedCod], [MonCod] FROM [CLPEDIDOS] WHERE [PedCod] = @PedCod ORDER BY [PedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLPEDIDOSU2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("CLPEDIDOSU3", "SELECT T1.[ProdCod], T1.[PedCod], T3.[PedICBPER], T1.[PedDICBPER], T2.[ProdValICBPERD], T1.[PedDCan], T2.[ProdValICBPER], T2.[ProdAfecICBPER], T1.[PedDItem] FROM (([CLPEDIDOSDET] T1 WITH (UPDLOCK) INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLPEDIDOS] T3 ON T3.[PedCod] = T1.[PedCod]) WHERE T1.[PedCod] = @PedCod ORDER BY T1.[PedCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLPEDIDOSU3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLPEDIDOSU4", "UPDATE [CLPEDIDOSDET] SET [PedDICBPER]=@PedDICBPER  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLPEDIDOSU4)
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
