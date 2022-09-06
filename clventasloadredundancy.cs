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
   public class clventasloadredundancy : GXProcedure
   {
      public clventasloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventasloadredundancy( IGxContext context )
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
         clventasloadredundancy objclventasloadredundancy;
         objclventasloadredundancy = new clventasloadredundancy();
         objclventasloadredundancy.context.SetSubmitInitialConfig(context);
         objclventasloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclventasloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clventasloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLVENTASLO2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A24DocNum = CLVENTASLO2_A24DocNum[0];
            A149TipCod = CLVENTASLO2_A149TipCod[0];
            A230DocMonCod = CLVENTASLO2_A230DocMonCod[0];
            A932DocICBPER = CLVENTASLO2_A932DocICBPER[0];
            O932DocICBPER = A932DocICBPER;
            O932DocICBPER = A932DocICBPER;
            A932DocICBPER = 0;
            /* Using cursor CLVENTASLO3 */
            pr_default.execute(1, new Object[] {A149TipCod, A24DocNum});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A28ProdCod = CLVENTASLO3_A28ProdCod[0];
               A905DocDICBPER = CLVENTASLO3_A905DocDICBPER[0];
               A908ProdValICBPERD = CLVENTASLO3_A908ProdValICBPERD[0];
               A895DocDCan = CLVENTASLO3_A895DocDCan[0];
               A907ProdValICBPER = CLVENTASLO3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLVENTASLO3_A906ProdAfecICBPER[0];
               A233DocItem = CLVENTASLO3_A233DocItem[0];
               A908ProdValICBPERD = CLVENTASLO3_A908ProdValICBPERD[0];
               A907ProdValICBPER = CLVENTASLO3_A907ProdValICBPER[0];
               A906ProdAfecICBPER = CLVENTASLO3_A906ProdAfecICBPER[0];
               A932DocICBPER = (decimal)(O932DocICBPER+A905DocDICBPER);
               O932DocICBPER = A932DocICBPER;
               A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
               /* Using cursor CLVENTASLO4 */
               pr_default.execute(2, new Object[] {A905DocDICBPER, A149TipCod, A24DocNum, A233DocItem});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor CLVENTASLO5 */
            pr_default.execute(3, new Object[] {A932DocICBPER, A149TipCod, A24DocNum});
            pr_default.close(3);
            dsDefault.SmartCacheProvider.SetUpdated("CLVENTAS");
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
         CLVENTASLO2_A24DocNum = new string[] {""} ;
         CLVENTASLO2_A149TipCod = new string[] {""} ;
         CLVENTASLO2_A230DocMonCod = new int[1] ;
         CLVENTASLO2_A932DocICBPER = new decimal[1] ;
         A24DocNum = "";
         A149TipCod = "";
         CLVENTASLO3_A28ProdCod = new string[] {""} ;
         CLVENTASLO3_A149TipCod = new string[] {""} ;
         CLVENTASLO3_A24DocNum = new string[] {""} ;
         CLVENTASLO3_A905DocDICBPER = new decimal[1] ;
         CLVENTASLO3_A908ProdValICBPERD = new decimal[1] ;
         CLVENTASLO3_A895DocDCan = new decimal[1] ;
         CLVENTASLO3_A907ProdValICBPER = new decimal[1] ;
         CLVENTASLO3_A906ProdAfecICBPER = new short[1] ;
         CLVENTASLO3_A233DocItem = new long[1] ;
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventasloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLVENTASLO2_A24DocNum, CLVENTASLO2_A149TipCod, CLVENTASLO2_A230DocMonCod, CLVENTASLO2_A932DocICBPER
               }
               , new Object[] {
               CLVENTASLO3_A28ProdCod, CLVENTASLO3_A149TipCod, CLVENTASLO3_A24DocNum, CLVENTASLO3_A905DocDICBPER, CLVENTASLO3_A908ProdValICBPERD, CLVENTASLO3_A895DocDCan, CLVENTASLO3_A907ProdValICBPER, CLVENTASLO3_A906ProdAfecICBPER, CLVENTASLO3_A233DocItem
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
      private int A230DocMonCod ;
      private long A233DocItem ;
      private decimal A932DocICBPER ;
      private decimal O932DocICBPER ;
      private decimal A905DocDICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal A895DocDCan ;
      private decimal A907ProdValICBPER ;
      private string scmdbuf ;
      private string A24DocNum ;
      private string A149TipCod ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLVENTASLO2_A24DocNum ;
      private string[] CLVENTASLO2_A149TipCod ;
      private int[] CLVENTASLO2_A230DocMonCod ;
      private decimal[] CLVENTASLO2_A932DocICBPER ;
      private string[] CLVENTASLO3_A28ProdCod ;
      private string[] CLVENTASLO3_A149TipCod ;
      private string[] CLVENTASLO3_A24DocNum ;
      private decimal[] CLVENTASLO3_A905DocDICBPER ;
      private decimal[] CLVENTASLO3_A908ProdValICBPERD ;
      private decimal[] CLVENTASLO3_A895DocDCan ;
      private decimal[] CLVENTASLO3_A907ProdValICBPER ;
      private short[] CLVENTASLO3_A906ProdAfecICBPER ;
      private long[] CLVENTASLO3_A233DocItem ;
   }

   public class clventasloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLVENTASLO2;
          prmCLVENTASLO2 = new Object[] {
          };
          Object[] prmCLVENTASLO3;
          prmCLVENTASLO3 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmCLVENTASLO4;
          prmCLVENTASLO4 = new Object[] {
          new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0) ,
          new ParDef("@DocItem",GXType.Decimal,10,0)
          };
          Object[] prmCLVENTASLO5;
          prmCLVENTASLO5 = new Object[] {
          new ParDef("@DocICBPER",GXType.Decimal,15,2) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLVENTASLO2", "SELECT [DocNum], [TipCod], [DocMonCod], [DocICBPER] FROM [CLVENTAS] WITH (UPDLOCK) ORDER BY [TipCod], [DocNum] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLVENTASLO2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLVENTASLO3", "SELECT T1.[ProdCod], T1.[TipCod], T1.[DocNum], T1.[DocDICBPER], T2.[ProdValICBPERD], T1.[DocDCan], T2.[ProdValICBPER], T2.[ProdAfecICBPER], T1.[DocItem] FROM ([CLVENTASDET] T1 WITH (UPDLOCK) INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod]) WHERE T1.[TipCod] = @TipCod and T1.[DocNum] = @DocNum ORDER BY T1.[TipCod], T1.[DocNum] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLVENTASLO3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLVENTASLO4", "UPDATE [CLVENTASDET] SET [DocDICBPER]=@DocDICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLVENTASLO4)
             ,new CursorDef("CLVENTASLO5", "UPDATE [CLVENTAS] SET [DocICBPER]=@DocICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLVENTASLO5)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 12);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 12);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((long[]) buf[8])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}
