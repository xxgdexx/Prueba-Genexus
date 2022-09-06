using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.configuracion {
   public class pvalidalistaprecios : GXProcedure
   {
      public pvalidalistaprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pvalidalistaprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipLCod ,
                           ref string aP1_ProdCod ,
                           ref string aP2_CliCod ,
                           ref short aP3_Estado )
      {
         this.AV9TipLCod = aP0_TipLCod;
         this.AV10ProdCod = aP1_ProdCod;
         this.AV11CliCod = aP2_CliCod;
         this.AV8Estado = aP3_Estado;
         initialize();
         executePrivate();
         aP0_TipLCod=this.AV9TipLCod;
         aP1_ProdCod=this.AV10ProdCod;
         aP2_CliCod=this.AV11CliCod;
         aP3_Estado=this.AV8Estado;
      }

      public short executeUdp( ref int aP0_TipLCod ,
                               ref string aP1_ProdCod ,
                               ref string aP2_CliCod )
      {
         execute(ref aP0_TipLCod, ref aP1_ProdCod, ref aP2_CliCod, ref aP3_Estado);
         return AV8Estado ;
      }

      public void executeSubmit( ref int aP0_TipLCod ,
                                 ref string aP1_ProdCod ,
                                 ref string aP2_CliCod ,
                                 ref short aP3_Estado )
      {
         pvalidalistaprecios objpvalidalistaprecios;
         objpvalidalistaprecios = new pvalidalistaprecios();
         objpvalidalistaprecios.AV9TipLCod = aP0_TipLCod;
         objpvalidalistaprecios.AV10ProdCod = aP1_ProdCod;
         objpvalidalistaprecios.AV11CliCod = aP2_CliCod;
         objpvalidalistaprecios.AV8Estado = aP3_Estado;
         objpvalidalistaprecios.context.SetSubmitInitialConfig(context);
         objpvalidalistaprecios.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpvalidalistaprecios);
         aP0_TipLCod=this.AV9TipLCod;
         aP1_ProdCod=this.AV10ProdCod;
         aP2_CliCod=this.AV11CliCod;
         aP3_Estado=this.AV8Estado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pvalidalistaprecios)stateInfo).executePrivate();
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
         AV8Estado = 0;
         AV12OpcListaPrecios = 0;
         /* Using cursor P004M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A347OpcId = P004M2_A347OpcId[0];
            A1405OpcListaPrecios = P004M2_A1405OpcListaPrecios[0];
            AV12OpcListaPrecios = A1405OpcListaPrecios;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV12OpcListaPrecios == 0 )
         {
            /* Using cursor P004M3 */
            pr_default.execute(1, new Object[] {AV9TipLCod, AV10ProdCod, AV11CliCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A45CliCod = P004M3_A45CliCod[0];
               n45CliCod = P004M3_n45CliCod[0];
               A28ProdCod = P004M3_A28ProdCod[0];
               A202TipLCod = P004M3_A202TipLCod[0];
               A203TipLItem = P004M3_A203TipLItem[0];
               AV8Estado = 1;
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
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
         P004M2_A347OpcId = new short[1] ;
         P004M2_A1405OpcListaPrecios = new short[1] ;
         P004M3_A45CliCod = new string[] {""} ;
         P004M3_n45CliCod = new bool[] {false} ;
         P004M3_A28ProdCod = new string[] {""} ;
         P004M3_A202TipLCod = new int[1] ;
         P004M3_A203TipLItem = new int[1] ;
         A45CliCod = "";
         A28ProdCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.pvalidalistaprecios__default(),
            new Object[][] {
                new Object[] {
               P004M2_A347OpcId, P004M2_A1405OpcListaPrecios
               }
               , new Object[] {
               P004M3_A45CliCod, P004M3_n45CliCod, P004M3_A28ProdCod, P004M3_A202TipLCod, P004M3_A203TipLItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Estado ;
      private short AV12OpcListaPrecios ;
      private short A347OpcId ;
      private short A1405OpcListaPrecios ;
      private int AV9TipLCod ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private string AV10ProdCod ;
      private string AV11CliCod ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A28ProdCod ;
      private bool n45CliCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipLCod ;
      private string aP1_ProdCod ;
      private string aP2_CliCod ;
      private short aP3_Estado ;
      private IDataStoreProvider pr_default ;
      private short[] P004M2_A347OpcId ;
      private short[] P004M2_A1405OpcListaPrecios ;
      private string[] P004M3_A45CliCod ;
      private bool[] P004M3_n45CliCod ;
      private string[] P004M3_A28ProdCod ;
      private int[] P004M3_A202TipLCod ;
      private int[] P004M3_A203TipLItem ;
   }

   public class pvalidalistaprecios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          };
          Object[] prmP004M3;
          prmP004M3 = new Object[] {
          new ParDef("@AV9TipLCod",GXType.Int32,6,0) ,
          new ParDef("@AV10ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11CliCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "SELECT [OpcId], [OpcListaPrecios] FROM [SGOPCIONES] WHERE [OpcId] = 1 ORDER BY [OpcId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004M3", "SELECT [CliCod], [ProdCod], [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE ([TipLCod] = @AV9TipLCod) AND ([ProdCod] = @AV10ProdCod) AND ([CliCod] = @AV11CliCod) ORDER BY [TipLCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M3,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 15);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
