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
namespace GeneXus.Programs.compras {
   public class pobtieneestadodocumento : GXProcedure
   {
      public pobtieneestadodocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtieneestadodocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CPPrvCod ,
                           ref string aP1_CPTipCod ,
                           ref string aP2_CPComCod ,
                           out string aP3_Estado )
      {
         this.A262CPPrvCod = aP0_CPPrvCod;
         this.A260CPTipCod = aP1_CPTipCod;
         this.A261CPComCod = aP2_CPComCod;
         this.AV12Estado = "" ;
         initialize();
         executePrivate();
         aP0_CPPrvCod=this.A262CPPrvCod;
         aP1_CPTipCod=this.A260CPTipCod;
         aP2_CPComCod=this.A261CPComCod;
         aP3_Estado=this.AV12Estado;
      }

      public string executeUdp( ref string aP0_CPPrvCod ,
                                ref string aP1_CPTipCod ,
                                ref string aP2_CPComCod )
      {
         execute(ref aP0_CPPrvCod, ref aP1_CPTipCod, ref aP2_CPComCod, out aP3_Estado);
         return AV12Estado ;
      }

      public void executeSubmit( ref string aP0_CPPrvCod ,
                                 ref string aP1_CPTipCod ,
                                 ref string aP2_CPComCod ,
                                 out string aP3_Estado )
      {
         pobtieneestadodocumento objpobtieneestadodocumento;
         objpobtieneestadodocumento = new pobtieneestadodocumento();
         objpobtieneestadodocumento.A262CPPrvCod = aP0_CPPrvCod;
         objpobtieneestadodocumento.A260CPTipCod = aP1_CPTipCod;
         objpobtieneestadodocumento.A261CPComCod = aP2_CPComCod;
         objpobtieneestadodocumento.AV12Estado = "" ;
         objpobtieneestadodocumento.context.SetSubmitInitialConfig(context);
         objpobtieneestadodocumento.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtieneestadodocumento);
         aP0_CPPrvCod=this.A262CPPrvCod;
         aP1_CPTipCod=this.A260CPTipCod;
         aP2_CPComCod=this.A261CPComCod;
         aP3_Estado=this.AV12Estado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtieneestadodocumento)stateInfo).executePrivate();
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
         /* Using cursor P008W2 */
         pr_default.execute(0, new Object[] {A260CPTipCod, A261CPComCod, A262CPPrvCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A815CPEstado = P008W2_A815CPEstado[0];
            AV12Estado = A815CPEstado;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         context.CommitDataStores("compras.pobtieneestadodocumento",pr_default);
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
         AV12Estado = "";
         scmdbuf = "";
         P008W2_A260CPTipCod = new string[] {""} ;
         P008W2_A261CPComCod = new string[] {""} ;
         P008W2_A262CPPrvCod = new string[] {""} ;
         P008W2_A815CPEstado = new string[] {""} ;
         A815CPEstado = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.compras.pobtieneestadodocumento__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.compras.pobtieneestadodocumento__default(),
            new Object[][] {
                new Object[] {
               P008W2_A260CPTipCod, P008W2_A261CPComCod, P008W2_A262CPPrvCod, P008W2_A815CPEstado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string A262CPPrvCod ;
      private string A260CPTipCod ;
      private string A261CPComCod ;
      private string AV12Estado ;
      private string scmdbuf ;
      private string A815CPEstado ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CPPrvCod ;
      private string aP1_CPTipCod ;
      private string aP2_CPComCod ;
      private IDataStoreProvider pr_default ;
      private string[] P008W2_A260CPTipCod ;
      private string[] P008W2_A261CPComCod ;
      private string[] P008W2_A262CPPrvCod ;
      private string[] P008W2_A815CPEstado ;
      private string aP3_Estado ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pobtieneestadodocumento__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class pobtieneestadodocumento__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP008W2;
        prmP008W2 = new Object[] {
        new ParDef("@CPTipCod",GXType.NChar,3,0) ,
        new ParDef("@CPComCod",GXType.NChar,15,0) ,
        new ParDef("@CPPrvCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P008W2", "SELECT [CPTipCod], [CPComCod], [CPPrvCod], [CPEstado] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @CPTipCod and [CPComCod] = @CPComCod and [CPPrvCod] = @CPPrvCod ORDER BY [CPTipCod], [CPComCod], [CPPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008W2,1, GxCacheFrequency.OFF ,false,true )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              return;
     }
  }

}

}
