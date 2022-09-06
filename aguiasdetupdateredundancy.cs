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
   public class aguiasdetupdateredundancy : GXProcedure
   {
      public aguiasdetupdateredundancy( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiasdetupdateredundancy( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_MvATip ,
                           ref string aP1_MvACod ,
                           ref int aP2_MvADItem )
      {
         this.A13MvATip = aP0_MvATip;
         this.A14MvACod = aP1_MvACod;
         this.A30MvADItem = aP2_MvADItem;
         initialize();
         executePrivate();
         aP0_MvATip=this.A13MvATip;
         aP1_MvACod=this.A14MvACod;
         aP2_MvADItem=this.A30MvADItem;
      }

      public int executeUdp( ref string aP0_MvATip ,
                             ref string aP1_MvACod )
      {
         execute(ref aP0_MvATip, ref aP1_MvACod, ref aP2_MvADItem);
         return A30MvADItem ;
      }

      public void executeSubmit( ref string aP0_MvATip ,
                                 ref string aP1_MvACod ,
                                 ref int aP2_MvADItem )
      {
         aguiasdetupdateredundancy objaguiasdetupdateredundancy;
         objaguiasdetupdateredundancy = new aguiasdetupdateredundancy();
         objaguiasdetupdateredundancy.A13MvATip = aP0_MvATip;
         objaguiasdetupdateredundancy.A14MvACod = aP1_MvACod;
         objaguiasdetupdateredundancy.A30MvADItem = aP2_MvADItem;
         objaguiasdetupdateredundancy.context.SetSubmitInitialConfig(context);
         objaguiasdetupdateredundancy.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objaguiasdetupdateredundancy);
         aP0_MvATip=this.A13MvATip;
         aP1_MvACod=this.A14MvACod;
         aP2_MvADItem=this.A30MvADItem;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aguiasdetupdateredundancy)stateInfo).executePrivate();
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
         /* Using cursor AGUIASDETU2 */
         pr_default.execute(0, new Object[] {A13MvATip, A14MvACod, A30MvADItem});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1250MVADPrecio = AGUIASDETU2_A1250MVADPrecio[0];
            A1248MvADCant = AGUIASDETU2_A1248MvADCant[0];
            A28ProdCod = AGUIASDETU2_A28ProdCod[0];
            AV2GXV28 = A28ProdCod;
            /* Optimized UPDATE. */
            /* Using cursor AGUIASDETU3 */
            pr_default.execute(1, new Object[] {AV2GXV28, A13MvATip, A14MvACod, A30MvADItem});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("AGUIASDETLOTE");
            /* End optimized UPDATE. */
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
         AGUIASDETU2_A13MvATip = new string[] {""} ;
         AGUIASDETU2_A14MvACod = new string[] {""} ;
         AGUIASDETU2_A30MvADItem = new int[1] ;
         AGUIASDETU2_A1250MVADPrecio = new decimal[1] ;
         AGUIASDETU2_A1248MvADCant = new decimal[1] ;
         AGUIASDETU2_A28ProdCod = new string[] {""} ;
         A28ProdCod = "";
         AV2GXV28 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiasdetupdateredundancy__default(),
            new Object[][] {
                new Object[] {
               AGUIASDETU2_A13MvATip, AGUIASDETU2_A14MvACod, AGUIASDETU2_A30MvADItem, AGUIASDETU2_A1250MVADPrecio, AGUIASDETU2_A1248MvADCant, AGUIASDETU2_A28ProdCod
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int A30MvADItem ;
      private decimal A1250MVADPrecio ;
      private decimal A1248MvADCant ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string AV2GXV28 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_MvATip ;
      private string aP1_MvACod ;
      private int aP2_MvADItem ;
      private IDataStoreProvider pr_default ;
      private string[] AGUIASDETU2_A13MvATip ;
      private string[] AGUIASDETU2_A14MvACod ;
      private int[] AGUIASDETU2_A30MvADItem ;
      private decimal[] AGUIASDETU2_A1250MVADPrecio ;
      private decimal[] AGUIASDETU2_A1248MvADCant ;
      private string[] AGUIASDETU2_A28ProdCod ;
   }

   public class aguiasdetupdateredundancy__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmAGUIASDETU2;
          prmAGUIASDETU2 = new Object[] {
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0) ,
          new ParDef("@MvADItem",GXType.Int32,6,0)
          };
          Object[] prmAGUIASDETU3;
          prmAGUIASDETU3 = new Object[] {
          new ParDef("@ProdCod",GXType.NChar,15,0) ,
          new ParDef("@MvATip",GXType.NChar,3,0) ,
          new ParDef("@MvACod",GXType.NChar,12,0) ,
          new ParDef("@MvADItem",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("AGUIASDETU2", "SELECT [MvATip], [MvACod], [MvADItem], [MVADPrecio], [MvADCant], [ProdCod] FROM [AGUIASDET] WHERE [MvATip] = @MvATip and [MvACod] = @MvACod and [MvADItem] = @MvADItem ORDER BY [MvATip], [MvACod], [MvADItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmAGUIASDETU2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("AGUIASDETU3", "UPDATE [AGUIASDETLOTE] SET [ProdCod]=@ProdCod  WHERE [MvATip] = @MvATip and [MvACod] = @MvACod and [MvADItem] = @MvADItem", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmAGUIASDETU3)
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 15);
                return;
       }
    }

 }

}
