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
namespace GeneXus.Programs.contabilidad {
   public class pobtienemonedapago : GXProcedure
   {
      public pobtienemonedapago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienemonedapago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CPPrvCod ,
                           ref string aP1_CPTipCod ,
                           ref string aP2_CPComCod ,
                           out int aP3_MonCod )
      {
         this.AV8CPPrvCod = aP0_CPPrvCod;
         this.AV9CPTipCod = aP1_CPTipCod;
         this.AV10CPComCod = aP2_CPComCod;
         this.AV11MonCod = 0 ;
         initialize();
         executePrivate();
         aP0_CPPrvCod=this.AV8CPPrvCod;
         aP1_CPTipCod=this.AV9CPTipCod;
         aP2_CPComCod=this.AV10CPComCod;
         aP3_MonCod=this.AV11MonCod;
      }

      public int executeUdp( ref string aP0_CPPrvCod ,
                             ref string aP1_CPTipCod ,
                             ref string aP2_CPComCod )
      {
         execute(ref aP0_CPPrvCod, ref aP1_CPTipCod, ref aP2_CPComCod, out aP3_MonCod);
         return AV11MonCod ;
      }

      public void executeSubmit( ref string aP0_CPPrvCod ,
                                 ref string aP1_CPTipCod ,
                                 ref string aP2_CPComCod ,
                                 out int aP3_MonCod )
      {
         pobtienemonedapago objpobtienemonedapago;
         objpobtienemonedapago = new pobtienemonedapago();
         objpobtienemonedapago.AV8CPPrvCod = aP0_CPPrvCod;
         objpobtienemonedapago.AV9CPTipCod = aP1_CPTipCod;
         objpobtienemonedapago.AV10CPComCod = aP2_CPComCod;
         objpobtienemonedapago.AV11MonCod = 0 ;
         objpobtienemonedapago.context.SetSubmitInitialConfig(context);
         objpobtienemonedapago.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienemonedapago);
         aP0_CPPrvCod=this.AV8CPPrvCod;
         aP1_CPTipCod=this.AV9CPTipCod;
         aP2_CPComCod=this.AV10CPComCod;
         aP3_MonCod=this.AV11MonCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienemonedapago)stateInfo).executePrivate();
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
         /* Using cursor P00AN2 */
         pr_default.execute(0, new Object[] {AV9CPTipCod, AV10CPComCod, AV8CPPrvCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A261CPComCod = P00AN2_A261CPComCod[0];
            A260CPTipCod = P00AN2_A260CPTipCod[0];
            A262CPPrvCod = P00AN2_A262CPPrvCod[0];
            A263CPMonCod = P00AN2_A263CPMonCod[0];
            AV11MonCod = A263CPMonCod;
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
         P00AN2_A261CPComCod = new string[] {""} ;
         P00AN2_A260CPTipCod = new string[] {""} ;
         P00AN2_A262CPPrvCod = new string[] {""} ;
         P00AN2_A263CPMonCod = new int[1] ;
         A261CPComCod = "";
         A260CPTipCod = "";
         A262CPPrvCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.pobtienemonedapago__default(),
            new Object[][] {
                new Object[] {
               P00AN2_A261CPComCod, P00AN2_A260CPTipCod, P00AN2_A262CPPrvCod, P00AN2_A263CPMonCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MonCod ;
      private int A263CPMonCod ;
      private string AV8CPPrvCod ;
      private string AV9CPTipCod ;
      private string AV10CPComCod ;
      private string scmdbuf ;
      private string A261CPComCod ;
      private string A260CPTipCod ;
      private string A262CPPrvCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CPPrvCod ;
      private string aP1_CPTipCod ;
      private string aP2_CPComCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00AN2_A261CPComCod ;
      private string[] P00AN2_A260CPTipCod ;
      private string[] P00AN2_A262CPPrvCod ;
      private int[] P00AN2_A263CPMonCod ;
      private int aP3_MonCod ;
   }

   public class pobtienemonedapago__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AN2;
          prmP00AN2 = new Object[] {
          new ParDef("@AV9CPTipCod",GXType.NChar,3,0) ,
          new ParDef("@AV10CPComCod",GXType.NChar,15,0) ,
          new ParDef("@AV8CPPrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AN2", "SELECT [CPComCod], [CPTipCod], [CPPrvCod], [CPMonCod] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @AV9CPTipCod and [CPComCod] = @AV10CPComCod and [CPPrvCod] = @AV8CPPrvCod ORDER BY [CPTipCod], [CPComCod], [CPPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AN2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
