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
   public class clcotizadetloadredundancy : GXProcedure
   {
      public clcotizadetloadredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clcotizadetloadredundancy( IGxContext context )
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
         clcotizadetloadredundancy objclcotizadetloadredundancy;
         objclcotizadetloadredundancy = new clcotizadetloadredundancy();
         objclcotizadetloadredundancy.context.SetSubmitInitialConfig(context);
         objclcotizadetloadredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclcotizadetloadredundancy);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clcotizadetloadredundancy)stateInfo).executePrivate();
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
         /* Using cursor CLCOTIZADE2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A773CotDDsct2 = CLCOTIZADE2_A773CotDDsct2[0];
            A772CotDDsct1 = CLCOTIZADE2_A772CotDDsct1[0];
            A768CotDTot = CLCOTIZADE2_A768CotDTot[0];
            A780CotDPreInc = CLCOTIZADE2_A780CotDPreInc[0];
            A795CotDTotInc = CLCOTIZADE2_A795CotDTotInc[0];
            A771CotDPre = CLCOTIZADE2_A771CotDPre[0];
            A770CotDCan = CLCOTIZADE2_A770CotDCan[0];
            A177CotCod = CLCOTIZADE2_A177CotCod[0];
            A183CotDItem = CLCOTIZADE2_A183CotDItem[0];
            A769CotDSub = NumberUtil.Round( A770CotDCan*A771CotDPre, 4);
            A768CotDTot = NumberUtil.Round( (A769CotDSub)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
            A795CotDTotInc = NumberUtil.Round( (A780CotDPreInc*A770CotDCan)*(1-(A772CotDDsct1/ (decimal)(100)))*(1-(A773CotDDsct2/ (decimal)(100))), 2);
            /* Using cursor CLCOTIZADE3 */
            pr_default.execute(1, new Object[] {A768CotDTot, A795CotDTotInc, A177CotCod, A183CotDItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CLCOTIZADET");
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
         CLCOTIZADE2_A773CotDDsct2 = new decimal[1] ;
         CLCOTIZADE2_A772CotDDsct1 = new decimal[1] ;
         CLCOTIZADE2_A768CotDTot = new decimal[1] ;
         CLCOTIZADE2_A780CotDPreInc = new decimal[1] ;
         CLCOTIZADE2_A795CotDTotInc = new decimal[1] ;
         CLCOTIZADE2_A771CotDPre = new decimal[1] ;
         CLCOTIZADE2_A770CotDCan = new decimal[1] ;
         CLCOTIZADE2_A177CotCod = new string[] {""} ;
         CLCOTIZADE2_A183CotDItem = new short[1] ;
         A177CotCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clcotizadetloadredundancy__default(),
            new Object[][] {
                new Object[] {
               CLCOTIZADE2_A773CotDDsct2, CLCOTIZADE2_A772CotDDsct1, CLCOTIZADE2_A768CotDTot, CLCOTIZADE2_A780CotDPreInc, CLCOTIZADE2_A795CotDTotInc, CLCOTIZADE2_A771CotDPre, CLCOTIZADE2_A770CotDCan, CLCOTIZADE2_A177CotCod, CLCOTIZADE2_A183CotDItem
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A183CotDItem ;
      private decimal A773CotDDsct2 ;
      private decimal A772CotDDsct1 ;
      private decimal A768CotDTot ;
      private decimal A780CotDPreInc ;
      private decimal A795CotDTotInc ;
      private decimal A771CotDPre ;
      private decimal A770CotDCan ;
      private decimal A769CotDSub ;
      private string scmdbuf ;
      private string A177CotCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] CLCOTIZADE2_A773CotDDsct2 ;
      private decimal[] CLCOTIZADE2_A772CotDDsct1 ;
      private decimal[] CLCOTIZADE2_A768CotDTot ;
      private decimal[] CLCOTIZADE2_A780CotDPreInc ;
      private decimal[] CLCOTIZADE2_A795CotDTotInc ;
      private decimal[] CLCOTIZADE2_A771CotDPre ;
      private decimal[] CLCOTIZADE2_A770CotDCan ;
      private string[] CLCOTIZADE2_A177CotCod ;
      private short[] CLCOTIZADE2_A183CotDItem ;
   }

   public class clcotizadetloadredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmCLCOTIZADE2;
          prmCLCOTIZADE2 = new Object[] {
          };
          Object[] prmCLCOTIZADE3;
          prmCLCOTIZADE3 = new Object[] {
          new ParDef("@CotDTot",GXType.Decimal,18,8) ,
          new ParDef("@CotDTotInc",GXType.Decimal,15,4) ,
          new ParDef("@CotCod",GXType.NChar,10,0) ,
          new ParDef("@CotDItem",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("CLCOTIZADE2", "SELECT [CotDDsct2], [CotDDsct1], [CotDTot], [CotDPreInc], [CotDTotInc], [CotDPre], [CotDCan], [CotCod], [CotDItem] FROM [CLCOTIZADET] WITH (UPDLOCK) ORDER BY [CotCod], [CotDItem] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmCLCOTIZADE2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("CLCOTIZADE3", "UPDATE [CLCOTIZADET] SET [CotDTot]=@CotDTot, [CotDTotInc]=@CotDTotInc  WHERE [CotCod] = @CotCod AND [CotDItem] = @CotDItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmCLCOTIZADE3)
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
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                return;
       }
    }

 }

}
