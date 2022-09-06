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
   public class clpedidosloadredundancy : GXProcedure
   {
      public clpedidosloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clpedidosloadredundancy( IGxContext context )
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
         clpedidosloadredundancy objclpedidosloadredundancy;
         objclpedidosloadredundancy = new clpedidosloadredundancy();
         objclpedidosloadredundancy.context.SetSubmitInitialConfig(context);
         objclpedidosloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclpedidosloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clpedidosloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLPEDIDOSL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210PedCod = CLPEDIDOSL2_A210PedCod[0];
            A180MonCod = CLPEDIDOSL2_A180MonCod[0];
            A1598PedICBPER = CLPEDIDOSL2_A1598PedICBPER[0];
            O1598PedICBPER = A1598PedICBPER;
            O1598PedICBPER = A1598PedICBPER;
            A1598PedICBPER = 0;
            /* Using cursor CLPEDIDOSL3 */
            pr_default.execute(1, new Object[] {A210PedCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = CLPEDIDOSL3_A28ProdCod[0];
               A1566PedDICBPER = CLPEDIDOSL3_A1566PedDICBPER[0];
               A908ProdValICBPERD = CLPEDIDOSL3_A908ProdValICBPERD[0];
               A1554PedDCan = CLPEDIDOSL3_A1554PedDCan[0];
               A907ProdValICBPER = CLPEDIDOSL3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLPEDIDOSL3_A906ProdAfecICBPER[0];
               A216PedDItem = CLPEDIDOSL3_A216PedDItem[0];
               A908ProdValICBPERD = CLPEDIDOSL3_A908ProdValICBPERD[0];
               A907ProdValICBPER = CLPEDIDOSL3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLPEDIDOSL3_A906ProdAfecICBPER[0];
               A1598PedICBPER = (decimal)(O1598PedICBPER+A1566PedDICBPER);
               O1598PedICBPER = A1598PedICBPER;
               A1566PedDICBPER = ((A906ProdAfecICBPER==1) ? ((A180MonCod==1) ? A907ProdValICBPER*A1554PedDCan : A908ProdValICBPERD*A1554PedDCan) : (decimal)(0));
               /* Using cursor CLPEDIDOSL4 */
               pr_default.execute(2, new Object[] {A1566PedDICBPER, A210PedCod, A216PedDItem});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOSDET");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor CLPEDIDOSL5 */
            pr_default.execute(3, new Object[] {A1598PedICBPER, A210PedCod});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("CLPEDIDOS");
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
         CLPEDIDOSL2_A210PedCod = new string[] {""} ;
         CLPEDIDOSL2_A180MonCod = new int[1] ;
         CLPEDIDOSL2_A1598PedICBPER = new decimal[1] ;
         A210PedCod = "";
         CLPEDIDOSL3_A28ProdCod = new string[] {""} ;
         CLPEDIDOSL3_A210PedCod = new string[] {""} ;
         CLPEDIDOSL3_A1566PedDICBPER = new decimal[1] ;
         CLPEDIDOSL3_A908ProdValICBPERD = new decimal[1] ;
         CLPEDIDOSL3_A1554PedDCan = new decimal[1] ;
         CLPEDIDOSL3_A907ProdValICBPER = new decimal[1] ;
         CLPEDIDOSL3_A906ProdAfecICBPER = new short[1] ;
         CLPEDIDOSL3_A216PedDItem = new short[1] ;
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clpedidosloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLPEDIDOSL2_A210PedCod, CLPEDIDOSL2_A180MonCod, CLPEDIDOSL2_A1598PedICBPER
               }
               , new Object[] {
               CLPEDIDOSL3_A28ProdCod, CLPEDIDOSL3_A210PedCod, CLPEDIDOSL3_A1566PedDICBPER, CLPEDIDOSL3_A908ProdValICBPERD, CLPEDIDOSL3_A1554PedDCan, CLPEDIDOSL3_A907ProdValICBPER, CLPEDIDOSL3_A906ProdAfecICBPER, CLPEDIDOSL3_A216PedDItem
               }
               , new Object[] {
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
      private decimal O1598PedICBPER ;
      private decimal A1566PedDICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A1554PedDCan ;
      private decimal A907ProdValICBPER ;
      private string scmdbuf ;
      private string A210PedCod ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLPEDIDOSL2_A210PedCod ;
      private int[] CLPEDIDOSL2_A180MonCod ;
      private decimal[] CLPEDIDOSL2_A1598PedICBPER ;
      private string[] CLPEDIDOSL3_A28ProdCod ;
      private string[] CLPEDIDOSL3_A210PedCod ;
      private decimal[] CLPEDIDOSL3_A1566PedDICBPER ;
      private decimal[] CLPEDIDOSL3_A908ProdValICBPERD ;
      private decimal[] CLPEDIDOSL3_A1554PedDCan ;
      private decimal[] CLPEDIDOSL3_A907ProdValICBPER ;
      private short[] CLPEDIDOSL3_A906ProdAfecICBPER ;
      private short[] CLPEDIDOSL3_A216PedDItem ;
   }

   public class clpedidosloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmCLPEDIDOSL2;
          prmCLPEDIDOSL2 = new Object[] {
          };
          Object[] prmCLPEDIDOSL3;
          prmCLPEDIDOSL3 = new Object[] {
          new ParDef("@PedCod",GXType.NChar,10,0)
          };
          Object[] prmCLPEDIDOSL4;
          prmCLPEDIDOSL4 = new Object[] {
          new ParDef("@PedDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@PedCod",GXType.NChar,10,0) ,
          new ParDef("@PedDItem",GXType.Int16,4,0)
          };
          Object[] prmCLPEDIDOSL5;
          prmCLPEDIDOSL5 = new Object[] {
          new ParDef("@PedICBPER",GXType.Decimal,15,2) ,
          new ParDef("@PedCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLPEDIDOSL2", "SELECT [PedCod], [MonCod], [PedICBPER] FROM [CLPEDIDOS] WITH (UPDLOCK) ORDER BY [PedCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLPEDIDOSL2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLPEDIDOSL3", "SELECT T1.[ProdCod], T1.[PedCod], T1.[PedDICBPER], T2.[ProdValICBPERD], T1.[PedDCan], T2.[ProdValICBPER], T2.[ProdAfecICBPER], T1.[PedDItem] FROM ([CLPEDIDOSDET] T1 WITH (UPDLOCK) INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) WHERE T1.[PedCod] = @PedCod ORDER BY T1.[PedCod] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLPEDIDOSL3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLPEDIDOSL4", "UPDATE [CLPEDIDOSDET] SET [PedDICBPER]=@PedDICBPER  WHERE [PedCod] = @PedCod AND [PedDItem] = @PedDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLPEDIDOSL4)
             ,new CursorDef("CLPEDIDOSL5", "UPDATE [CLPEDIDOS] SET [PedICBPER]=@PedICBPER  WHERE [PedCod] = @PedCod", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLPEDIDOSL5)
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
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
