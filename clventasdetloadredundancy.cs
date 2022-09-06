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
   public class clventasdetloadredundancy : GXProcedure
   {
      public clventasdetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clventasdetloadredundancy( IGxContext context )
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
         clventasdetloadredundancy objclventasdetloadredundancy;
         objclventasdetloadredundancy = new clventasdetloadredundancy();
         objclventasdetloadredundancy.context.SetSubmitInitialConfig(context);
         objclventasdetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclventasdetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clventasdetloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLVENTASDE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A149TipCod = CLVENTASDE2_A149TipCod[0];
            A24DocNum = CLVENTASDE2_A24DocNum[0];
            A28ProdCod = CLVENTASDE2_A28ProdCod[0];
            A897DocDDct2 = CLVENTASDE2_A897DocDDct2[0];
            A896DocDDct = CLVENTASDE2_A896DocDDct[0];
            A892DocDTot = CLVENTASDE2_A892DocDTot[0];
            A908ProdValICBPERD = CLVENTASDE2_A908ProdValICBPERD[0];
            A907ProdValICBPER = CLVENTASDE2_A907ProdValICBPER[0];
            A230DocMonCod = CLVENTASDE2_A230DocMonCod[0];
            A906ProdAfecICBPER = CLVENTASDE2_A906ProdAfecICBPER[0];
            A905DocDICBPER = CLVENTASDE2_A905DocDICBPER[0];
            A895DocDCan = CLVENTASDE2_A895DocDCan[0];
            A894DocDpre = CLVENTASDE2_A894DocDpre[0];
            A233DocItem = CLVENTASDE2_A233DocItem[0];
            A230DocMonCod = CLVENTASDE2_A230DocMonCod[0];
            A908ProdValICBPERD = CLVENTASDE2_A908ProdValICBPERD[0];
            A907ProdValICBPER = CLVENTASDE2_A907ProdValICBPER[0];
            A906ProdAfecICBPER = CLVENTASDE2_A906ProdAfecICBPER[0];
            A893DocDSub = NumberUtil.Round( A894DocDpre*A895DocDCan, 4);
            A892DocDTot = NumberUtil.Round( (A893DocDSub)*(1-A896DocDDct/ (decimal)(100))*(1-A897DocDDct2/ (decimal)(100)), 2);
            A905DocDICBPER = ((A906ProdAfecICBPER==1) ? ((A230DocMonCod==1) ? A907ProdValICBPER*A895DocDCan : A908ProdValICBPERD*A895DocDCan) : (decimal)(0));
            /* Using cursor CLVENTASDE3 */
            pr_default.execute(1, new Object[] {A892DocDTot, A905DocDICBPER, A149TipCod, A24DocNum, A233DocItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CLVENTASDET");
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
         CLVENTASDE2_A149TipCod = new string[] {""} ;
         CLVENTASDE2_A24DocNum = new string[] {""} ;
         CLVENTASDE2_A28ProdCod = new string[] {""} ;
         CLVENTASDE2_A897DocDDct2 = new decimal[1] ;
         CLVENTASDE2_A896DocDDct = new decimal[1] ;
         CLVENTASDE2_A892DocDTot = new decimal[1] ;
         CLVENTASDE2_A908ProdValICBPERD = new decimal[1] ;
         CLVENTASDE2_A907ProdValICBPER = new decimal[1] ;
         CLVENTASDE2_A230DocMonCod = new int[1] ;
         CLVENTASDE2_A906ProdAfecICBPER = new short[1] ;
         CLVENTASDE2_A905DocDICBPER = new decimal[1] ;
         CLVENTASDE2_A895DocDCan = new decimal[1] ;
         CLVENTASDE2_A894DocDpre = new decimal[1] ;
         CLVENTASDE2_A233DocItem = new long[1] ;
         A149TipCod = "";
         A24DocNum = "";
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clventasdetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLVENTASDE2_A149TipCod, CLVENTASDE2_A24DocNum, CLVENTASDE2_A28ProdCod, CLVENTASDE2_A897DocDDct2, CLVENTASDE2_A896DocDDct, CLVENTASDE2_A892DocDTot, CLVENTASDE2_A908ProdValICBPERD, CLVENTASDE2_A907ProdValICBPER, CLVENTASDE2_A230DocMonCod, CLVENTASDE2_A906ProdAfecICBPER,
               CLVENTASDE2_A905DocDICBPER, CLVENTASDE2_A895DocDCan, CLVENTASDE2_A894DocDpre, CLVENTASDE2_A233DocItem
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
      private decimal A897DocDDct2 ;
      private decimal A896DocDDct ;
      private decimal A892DocDTot ;
      private decimal A908ProdValICBPERD ;
      private decimal A907ProdValICBPER ;
      private decimal A905DocDICBPER ;
      private decimal A895DocDCan ;
      private decimal A894DocDpre ;
      private decimal A893DocDSub ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string A28ProdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] CLVENTASDE2_A149TipCod ;
      private string[] CLVENTASDE2_A24DocNum ;
      private string[] CLVENTASDE2_A28ProdCod ;
      private decimal[] CLVENTASDE2_A897DocDDct2 ;
      private decimal[] CLVENTASDE2_A896DocDDct ;
      private decimal[] CLVENTASDE2_A892DocDTot ;
      private decimal[] CLVENTASDE2_A908ProdValICBPERD ;
      private decimal[] CLVENTASDE2_A907ProdValICBPER ;
      private int[] CLVENTASDE2_A230DocMonCod ;
      private short[] CLVENTASDE2_A906ProdAfecICBPER ;
      private decimal[] CLVENTASDE2_A905DocDICBPER ;
      private decimal[] CLVENTASDE2_A895DocDCan ;
      private decimal[] CLVENTASDE2_A894DocDpre ;
      private long[] CLVENTASDE2_A233DocItem ;
   }

   public class clventasdetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLVENTASDE2;
          prmCLVENTASDE2 = new Object[] {
          };
          Object[] prmCLVENTASDE3;
          prmCLVENTASDE3 = new Object[] {
          new ParDef("@DocDTot",GXType.Decimal,18,8) ,
          new ParDef("@DocDICBPER",GXType.Decimal,15,2) ,
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0) ,
          new ParDef("@DocItem",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLVENTASDE2", "SELECT T1.[TipCod], T1.[DocNum], T1.[ProdCod], T1.[DocDDct2], T1.[DocDDct], T1.[DocDTot], T3.[ProdValICBPERD], T3.[ProdValICBPER], T2.[DocMonCod], T3.[ProdAfecICBPER], T1.[DocDICBPER], T1.[DocDCan], T1.[DocDpre], T1.[DocItem] FROM (([CLVENTASDET] T1 WITH (UPDLOCK) INNER JOIN [CLVENTAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[DocNum] = T1.[DocNum]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) ORDER BY T1.[TipCod], T1.[DocNum], T1.[DocItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLVENTASDE2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLVENTASDE3", "UPDATE [CLVENTASDET] SET [DocDTot]=@DocDTot, [DocDICBPER]=@DocDICBPER  WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum AND [DocItem] = @DocItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLVENTASDE3)
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
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
                ((long[]) buf[13])[0] = rslt.getLong(14);
                return;
       }
    }

 }

}
