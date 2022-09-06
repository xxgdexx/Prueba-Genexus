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
   public class tslibrobancosloadredundancy : GXProcedure
   {
      public tslibrobancosloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tslibrobancosloadredundancy( IGxContext context )
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
         tslibrobancosloadredundancy objtslibrobancosloadredundancy;
         objtslibrobancosloadredundancy = new tslibrobancosloadredundancy();
         objtslibrobancosloadredundancy.context.SetSubmitInitialConfig(context);
         objtslibrobancosloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtslibrobancosloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tslibrobancosloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor TSLIBROBAN2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A381LBRegistro = TSLIBROBAN2_A381LBRegistro[0];
            A380LBCBCod = TSLIBROBAN2_A380LBCBCod[0];
            A379LBBanCod = TSLIBROBAN2_A379LBBanCod[0];
            A1072LBTDebe = TSLIBROBAN2_A1072LBTDebe[0];
            A1073LBTHaber = TSLIBROBAN2_A1073LBTHaber[0];
            O1073LBTHaber = A1073LBTHaber;
            O1072LBTDebe = A1072LBTDebe;
            O1073LBTHaber = A1073LBTHaber;
            O1072LBTDebe = A1072LBTDebe;
            A1072LBTDebe = 0;
            A1073LBTHaber = 0;
            /* Using cursor TSLIBROBAN3 */
            pr_default.execute(1, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1074LBDHaber = TSLIBROBAN3_A1074LBDHaber[0];
               A1067LBDDebe = TSLIBROBAN3_A1067LBDDebe[0];
               A383LBDITem = TSLIBROBAN3_A383LBDITem[0];
               A1072LBTDebe = (decimal)(O1072LBTDebe+A1067LBDDebe);
               A1073LBTHaber = (decimal)(O1073LBTHaber+A1074LBDHaber);
               O1073LBTHaber = A1073LBTHaber;
               O1072LBTDebe = A1072LBTDebe;
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor TSLIBROBAN4 */
            pr_default.execute(2, new Object[] {A1072LBTDebe, A1073LBTHaber, A379LBBanCod, A380LBCBCod, A381LBRegistro});
            pr_default.close(2);
            dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOS");
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
         TSLIBROBAN2_A381LBRegistro = new string[] {""} ;
         TSLIBROBAN2_A380LBCBCod = new string[] {""} ;
         TSLIBROBAN2_A379LBBanCod = new int[1] ;
         TSLIBROBAN2_A1072LBTDebe = new decimal[1] ;
         TSLIBROBAN2_A1073LBTHaber = new decimal[1] ;
         A381LBRegistro = "";
         A380LBCBCod = "";
         TSLIBROBAN3_A379LBBanCod = new int[1] ;
         TSLIBROBAN3_A380LBCBCod = new string[] {""} ;
         TSLIBROBAN3_A381LBRegistro = new string[] {""} ;
         TSLIBROBAN3_A1074LBDHaber = new decimal[1] ;
         TSLIBROBAN3_A1067LBDDebe = new decimal[1] ;
         TSLIBROBAN3_A383LBDITem = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tslibrobancosloadredundancy__default(),
            new Object[][] {
                new Object[] {
               TSLIBROBAN2_A381LBRegistro, TSLIBROBAN2_A380LBCBCod, TSLIBROBAN2_A379LBBanCod, TSLIBROBAN2_A1072LBTDebe, TSLIBROBAN2_A1073LBTHaber
               }
               , new Object[] {
               TSLIBROBAN3_A379LBBanCod, TSLIBROBAN3_A380LBCBCod, TSLIBROBAN3_A381LBRegistro, TSLIBROBAN3_A1074LBDHaber, TSLIBROBAN3_A1067LBDDebe, TSLIBROBAN3_A383LBDITem
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A379LBBanCod ;
      private int A383LBDITem ;
      private decimal A1072LBTDebe ;
      private decimal A1073LBTHaber ;
      private decimal O1073LBTHaber ;
      private decimal O1072LBTDebe ;
      private decimal A1074LBDHaber ;
      private decimal A1067LBDDebe ;
      private string scmdbuf ;
      private string A381LBRegistro ;
      private string A380LBCBCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] TSLIBROBAN2_A381LBRegistro ;
      private string[] TSLIBROBAN2_A380LBCBCod ;
      private int[] TSLIBROBAN2_A379LBBanCod ;
      private decimal[] TSLIBROBAN2_A1072LBTDebe ;
      private decimal[] TSLIBROBAN2_A1073LBTHaber ;
      private int[] TSLIBROBAN3_A379LBBanCod ;
      private string[] TSLIBROBAN3_A380LBCBCod ;
      private string[] TSLIBROBAN3_A381LBRegistro ;
      private decimal[] TSLIBROBAN3_A1074LBDHaber ;
      private decimal[] TSLIBROBAN3_A1067LBDDebe ;
      private int[] TSLIBROBAN3_A383LBDITem ;
   }

   public class tslibrobancosloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmTSLIBROBAN2;
          prmTSLIBROBAN2 = new Object[] {
          };
          Object[] prmTSLIBROBAN3;
          prmTSLIBROBAN3 = new Object[] {
          new ParDef("@LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@LBCBCod",GXType.NChar,20,0) ,
          new ParDef("@LBRegistro",GXType.NChar,10,0)
          };
          Object[] prmTSLIBROBAN4;
          prmTSLIBROBAN4 = new Object[] {
          new ParDef("@LBTDebe",GXType.Decimal,15,2) ,
          new ParDef("@LBTHaber",GXType.Decimal,15,2) ,
          new ParDef("@LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@LBCBCod",GXType.NChar,20,0) ,
          new ParDef("@LBRegistro",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("TSLIBROBAN2", "SELECT [LBRegistro], [LBCBCod], [LBBanCod], [LBTDebe], [LBTHaber] FROM [TSLIBROBANCOS] WITH (UPDLOCK) ORDER BY [LBBanCod], [LBCBCod], [LBRegistro] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTSLIBROBAN2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("TSLIBROBAN3", "SELECT [LBBanCod], [LBCBCod], [LBRegistro], [LBDHaber], [LBDDebe], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBBanCod] = @LBBanCod and [LBCBCod] = @LBCBCod and [LBRegistro] = @LBRegistro ORDER BY [LBBanCod], [LBCBCod], [LBRegistro] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmTSLIBROBAN3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("TSLIBROBAN4", "UPDATE [TSLIBROBANCOS] SET [LBTDebe]=@LBTDebe, [LBTHaber]=@LBTHaber  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmTSLIBROBAN4)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
