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
   public class cpordendetloadredundancy : GXProcedure
   {
      public cpordendetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpordendetloadredundancy( IGxContext context )
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
         cpordendetloadredundancy objcpordendetloadredundancy;
         objcpordendetloadredundancy = new cpordendetloadredundancy();
         objcpordendetloadredundancy.context.SetSubmitInitialConfig(context);
         objcpordendetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcpordendetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cpordendetloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CPORDENDET2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1444OrdDTot = CPORDENDET2_A1444OrdDTot[0];
            A1439OrdDDscto = CPORDENDET2_A1439OrdDDscto[0];
            A1438OrdDPre = CPORDENDET2_A1438OrdDPre[0];
            A1431OrdDCan = CPORDENDET2_A1431OrdDCan[0];
            A289OrdCod = CPORDENDET2_A289OrdCod[0];
            A295OrdDItem = CPORDENDET2_A295OrdDItem[0];
            A1437OrdDSub = NumberUtil.Round( A1431OrdDCan*A1438OrdDPre, 2);
            A1436OrdDDescuento = NumberUtil.Round( A1437OrdDSub*A1439OrdDDscto/ (decimal)(100), 2);
            A1444OrdDTot = NumberUtil.Round( (A1431OrdDCan*A1438OrdDPre)-A1436OrdDDescuento, 8);
            /* Using cursor CPORDENDET3 */
            pr_default.execute(1, new Object[] {A1444OrdDTot, A289OrdCod, A295OrdDItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CPORDENDET");
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
         CPORDENDET2_A1444OrdDTot = new decimal[1] ;
         CPORDENDET2_A1439OrdDDscto = new decimal[1] ;
         CPORDENDET2_A1438OrdDPre = new decimal[1] ;
         CPORDENDET2_A1431OrdDCan = new decimal[1] ;
         CPORDENDET2_A289OrdCod = new string[] {""} ;
         CPORDENDET2_A295OrdDItem = new int[1] ;
         A289OrdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpordendetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CPORDENDET2_A1444OrdDTot, CPORDENDET2_A1439OrdDDscto, CPORDENDET2_A1438OrdDPre, CPORDENDET2_A1431OrdDCan, CPORDENDET2_A289OrdCod, CPORDENDET2_A295OrdDItem
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A295OrdDItem ;
      private decimal A1444OrdDTot ;
      private decimal A1439OrdDDscto ;
      private decimal A1438OrdDPre ;
      private decimal A1431OrdDCan ;
      private decimal A1437OrdDSub ;
      private decimal A1436OrdDDescuento ;
      private string scmdbuf ;
      private string A289OrdCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] CPORDENDET2_A1444OrdDTot ;
      private decimal[] CPORDENDET2_A1439OrdDDscto ;
      private decimal[] CPORDENDET2_A1438OrdDPre ;
      private decimal[] CPORDENDET2_A1431OrdDCan ;
      private string[] CPORDENDET2_A289OrdCod ;
      private int[] CPORDENDET2_A295OrdDItem ;
   }

   public class cpordendetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCPORDENDET2;
          prmCPORDENDET2 = new Object[] {
          };
          Object[] prmCPORDENDET3;
          prmCPORDENDET3 = new Object[] {
          new ParDef("@OrdDTot",GXType.Decimal,18,8) ,
          new ParDef("@OrdCod",GXType.NChar,10,0) ,
          new ParDef("@OrdDItem",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("CPORDENDET2", "SELECT [OrdDTot], [OrdDDscto], [OrdDPre], [OrdDCan], [OrdCod], [OrdDItem] FROM [CPORDENDET] WITH (UPDLOCK) ORDER BY [OrdCod], [OrdDItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCPORDENDET2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CPORDENDET3", "UPDATE [CPORDENDET] SET [OrdDTot]=@OrdDTot  WHERE [OrdCod] = @OrdCod AND [OrdDItem] = @OrdDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCPORDENDET3)
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
