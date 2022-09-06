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
   public class clventasupdateredundancy : GXProcedure
   {
      public clventasupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventasupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_TipCod ,
                           ref string aP1_DocNum )
      {
         this.A149TipCod = aP0_TipCod;
         this.A24DocNum = aP1_DocNum;
         initialize();
         executePrivate();
         aP0_TipCod=this.A149TipCod;
         aP1_DocNum=this.A24DocNum;
      }

      public string executeUdp( ref string aP0_TipCod )
      {
         execute(ref aP0_TipCod, ref aP1_DocNum);
         return A24DocNum ;
      }

      public void executeSubmit( ref string aP0_TipCod ,
                                 ref string aP1_DocNum )
      {
         clventasupdateredundancy objclventasupdateredundancy;
         objclventasupdateredundancy = new clventasupdateredundancy();
         objclventasupdateredundancy.A149TipCod = aP0_TipCod;
         objclventasupdateredundancy.A24DocNum = aP1_DocNum;
         objclventasupdateredundancy.context.SetSubmitInitialConfig(context);
         objclventasupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclventasupdateredundancy);
         aP0_TipCod=this.A149TipCod;
         aP1_DocNum=this.A24DocNum;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clventasupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLVENTASUP2 */
         pr_default.execute(0, new Object[] {A149TipCod, A24DocNum});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A230DocMonCod = CLVENTASUP2_A230DocMonCod[0];
            /* Using cursor CLVENTASUP3 */
            pr_default.execute(1, new Object[] {A149TipCod, A24DocNum});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = CLVENTASUP3_A28ProdCod[0];
               A932DocICBPER = CLVENTASUP3_A932DocICBPER[0];
               A905DocDICBPER = CLVENTASUP3_A905DocDICBPER[0];
               A908ProdValICBPERD = CLVENTASUP3_A908ProdValICBPERD[0];
               A895DocDCan = CLVENTASUP3_A895DocDCan[0];
               A907ProdValICBPER = CLVENTASUP3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLVENTASUP3_A906ProdAfecICBPER[0];
               A233DocItem = CLVENTASUP3_A233DocItem[0];
               O905DocDICBPER = A905DocDICBPER;
               A908ProdValICBPERD = CLVENTASUP3_A908ProdValICBPERD[0];
               A907ProdValICBPER = CLVENTASUP3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLVENTASUP3_A906ProdAfecICBPER[0];
               A932DocICBPER = CLVENTASUP3_A932DocICBPER[0];
               O932DocICBPER = A932DocICBPER;
               A932DocICBPER = (decimal)(O932DocICBPER+A905DocDICBPER-O905DocDICBPER);
               O905DocDICBPER = A905DocDICBPER;
               O932DocICBPER = A932DocICBPER;
               A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
               /* Using cursor CLVENTASUP4 */
               pr_default.execute(2, new Object[] {A905DocDICBPER, A149TipCod, A24DocNum, A233DocItem});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
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
         CLVENTASUP2_A149TipCod = new string[] {""} ;
         CLVENTASUP2_A24DocNum = new string[] {""} ;
         CLVENTASUP2_A230DocMonCod = new int[1] ;
         CLVENTASUP3_A28ProdCod = new string[] {""} ;
         CLVENTASUP3_A149TipCod = new string[] {""} ;
         CLVENTASUP3_A24DocNum = new string[] {""} ;
         CLVENTASUP3_A932DocICBPER = new decimal[1] ;
         CLVENTASUP3_A905DocDICBPER = new decimal[1] ;
         CLVENTASUP3_A908ProdValICBPERD = new decimal[1] ;
         CLVENTASUP3_A895DocDCan = new decimal[1] ;
         CLVENTASUP3_A907ProdValICBPER = new decimal[1] ;
         CLVENTASUP3_A906ProdAfecICBPER = new short[1] ;
         CLVENTASUP3_A233DocItem = new long[1] ;
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventasupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               CLVENTASUP2_A149TipCod, CLVENTASUP2_A24DocNum, CLVENTASUP2_A230DocMonCod
               }
               , new Object[] {
               CLVENTASUP3_A28ProdCod, CLVENTASUP3_A149TipCod, CLVENTASUP3_A24DocNum, CLVENTASUP3_A932DocICBPER, CLVENTASUP3_A905DocDICBPER, CLVENTASUP3_A908ProdValICBPERD, CLVENTASUP3_A895DocDCan, CLVENTASUP3_A907ProdValICBPER, CLVENTASUP3_A906ProdAfecICBPER, CLVENTASUP3_A233DocItem
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A906ProdAfecICBPER ;
      private int A230DocMonCod ;
      private long A233DocItem ;
      private decimal A932DocICBPER ;
      private decimal A905DocDICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A895DocDCan ;
      private decimal A907ProdValICBPER ;
      private decimal O905DocDICBPER ;
      private decimal O932DocICBPER ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_TipCod ;
      private string aP1_DocNum ;
      private IDataStoreProvider pr_default ;
      private string[] CLVENTASUP2_A149TipCod ;
      private string[] CLVENTASUP2_A24DocNum ;
      private int[] CLVENTASUP2_A230DocMonCod ;
      private string[] CLVENTASUP3_A28ProdCod ;
      private string[] CLVENTASUP3_A149TipCod ;
      private string[] CLVENTASUP3_A24DocNum ;
      private decimal[] CLVENTASUP3_A932DocICBPER ;
      private decimal[] CLVENTASUP3_A905DocDICBPER ;
      private decimal[] CLVENTASUP3_A908ProdValICBPERD ;
      private decimal[] CLVENTASUP3_A895DocDCan ;
      private decimal[] CLVENTASUP3_A907ProdValICBPER ;
      private short[] CLVENTASUP3_A906ProdAfecICBPER ;
      private long[] CLVENTASUP3_A233DocItem ;
   }

   public class clventasupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLVENTASUP2;
          prmCLVENTASUP2 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmCLVENTASUP3;
          prmCLVENTASUP3 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmCLVENTASUP4;
          prmCLVENTASUP4 = new Object[] {
          new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0) ,
          new ParDef("@DocItem",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLVENTASUP2", "SELECT [TipCod], [DocNum], [DocMonCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod and [DocNum] = @DocNum ORDER BY [TipCod], [DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLVENTASUP2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("CLVENTASUP3", "SELECT T1.[ProdCod], T1.[TipCod], T1.[DocNum], T3.[DocICBPER], T1.[DocDICBPER], T2.[ProdValICBPERD], T1.[DocDCan], T2.[ProdValICBPER], T2.[ProdAfecICBPER], T1.[DocItem] FROM (([CLVENTASDET] T1 WITH (UPDLOCK) INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) INNER JOIN [CLVENTAS] T3 ON T3.[TipCod] = T1.[TipCod] AND T3.[DocNum] = T1.[DocNum]) WHERE T1.[TipCod] = @TipCod and T1.[DocNum] = @DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLVENTASUP3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLVENTASUP4", "UPDATE [CLVENTASDET] SET [DocDICBPER]=@DocDICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLVENTASUP4)
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((long[]) buf[9])[0] = rslt.getLong(10);
                return;
       }
    }

 }

}
