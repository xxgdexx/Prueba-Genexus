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
namespace GeneXus.Programs {
   public class pobtenerzonacliente : GXProcedure
   {
      public pobtenerzonacliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtenerzonacliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_CliCod ,
                           ref int aP1_DocCliDirItem ,
                           out int aP2_ZonCod ,
                           out string aP3_ZonDsc )
      {
         this.AV11CliCod = aP0_CliCod;
         this.AV10DocCliDirItem = aP1_DocCliDirItem;
         this.AV8ZonCod = 0 ;
         this.AV9ZonDsc = "" ;
         initialize();
         executePrivate();
         aP0_CliCod=this.AV11CliCod;
         aP1_DocCliDirItem=this.AV10DocCliDirItem;
         aP2_ZonCod=this.AV8ZonCod;
         aP3_ZonDsc=this.AV9ZonDsc;
      }

      public string executeUdp( ref string aP0_CliCod ,
                                ref int aP1_DocCliDirItem ,
                                out int aP2_ZonCod )
      {
         execute(ref aP0_CliCod, ref aP1_DocCliDirItem, out aP2_ZonCod, out aP3_ZonDsc);
         return AV9ZonDsc ;
      }

      public void executeSubmit( ref string aP0_CliCod ,
                                 ref int aP1_DocCliDirItem ,
                                 out int aP2_ZonCod ,
                                 out string aP3_ZonDsc )
      {
         pobtenerzonacliente objpobtenerzonacliente;
         objpobtenerzonacliente = new pobtenerzonacliente();
         objpobtenerzonacliente.AV11CliCod = aP0_CliCod;
         objpobtenerzonacliente.AV10DocCliDirItem = aP1_DocCliDirItem;
         objpobtenerzonacliente.AV8ZonCod = 0 ;
         objpobtenerzonacliente.AV9ZonDsc = "" ;
         objpobtenerzonacliente.context.SetSubmitInitialConfig(context);
         objpobtenerzonacliente.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtenerzonacliente);
         aP0_CliCod=this.AV11CliCod;
         aP1_DocCliDirItem=this.AV10DocCliDirItem;
         aP2_ZonCod=this.AV8ZonCod;
         aP3_ZonDsc=this.AV9ZonDsc;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtenerzonacliente)stateInfo).executePrivate();
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
         AV8ZonCod = 0;
         AV9ZonDsc = "";
         /* Using cursor P00EK2 */
         pr_default.execute(0, new Object[] {AV11CliCod, AV10DocCliDirItem});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A164CliDirItem = P00EK2_A164CliDirItem[0];
            A45CliCod = P00EK2_A45CliCod[0];
            A165CliDirZonCod = P00EK2_A165CliDirZonCod[0];
            A607CliDirZonDsc = P00EK2_A607CliDirZonDsc[0];
            A607CliDirZonDsc = P00EK2_A607CliDirZonDsc[0];
            AV8ZonCod = A165CliDirZonCod;
            AV9ZonDsc = A607CliDirZonDsc;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( (0==AV8ZonCod) )
         {
            /* Using cursor P00EK3 */
            pr_default.execute(1, new Object[] {AV11CliCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A45CliCod = P00EK3_A45CliCod[0];
               A158ZonCod = P00EK3_A158ZonCod[0];
               n158ZonCod = P00EK3_n158ZonCod[0];
               A2094ZonDsc = P00EK3_A2094ZonDsc[0];
               A2094ZonDsc = P00EK3_A2094ZonDsc[0];
               AV8ZonCod = A158ZonCod;
               AV9ZonDsc = A2094ZonDsc;
               /* Exiting from a For First loop. */
               if (true) break;
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
         AV9ZonDsc = "";
         scmdbuf = "";
         P00EK2_A164CliDirItem = new int[1] ;
         P00EK2_A45CliCod = new string[] {""} ;
         P00EK2_A165CliDirZonCod = new int[1] ;
         P00EK2_A607CliDirZonDsc = new string[] {""} ;
         A45CliCod = "";
         A607CliDirZonDsc = "";
         P00EK3_A45CliCod = new string[] {""} ;
         P00EK3_A158ZonCod = new int[1] ;
         P00EK3_n158ZonCod = new bool[] {false} ;
         P00EK3_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pobtenerzonacliente__default(),
            new Object[][] {
                new Object[] {
               P00EK2_A164CliDirItem, P00EK2_A45CliCod, P00EK2_A165CliDirZonCod, P00EK2_A607CliDirZonDsc
               }
               , new Object[] {
               P00EK3_A45CliCod, P00EK3_A158ZonCod, P00EK3_n158ZonCod, P00EK3_A2094ZonDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10DocCliDirItem ;
      private int AV8ZonCod ;
      private int A164CliDirItem ;
      private int A165CliDirZonCod ;
      private int A158ZonCod ;
      private string AV11CliCod ;
      private string AV9ZonDsc ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A607CliDirZonDsc ;
      private string A2094ZonDsc ;
      private bool n158ZonCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_CliCod ;
      private int aP1_DocCliDirItem ;
      private IDataStoreProvider pr_default ;
      private int[] P00EK2_A164CliDirItem ;
      private string[] P00EK2_A45CliCod ;
      private int[] P00EK2_A165CliDirZonCod ;
      private string[] P00EK2_A607CliDirZonDsc ;
      private string[] P00EK3_A45CliCod ;
      private int[] P00EK3_A158ZonCod ;
      private bool[] P00EK3_n158ZonCod ;
      private string[] P00EK3_A2094ZonDsc ;
      private int aP2_ZonCod ;
      private string aP3_ZonDsc ;
   }

   public class pobtenerzonacliente__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00EK2;
          prmP00EK2 = new Object[] {
          new ParDef("@AV11CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV10DocCliDirItem",GXType.Int32,6,0)
          };
          Object[] prmP00EK3;
          prmP00EK3 = new Object[] {
          new ParDef("@AV11CliCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EK2", "SELECT T1.[CliDirItem], T1.[CliCod], T1.[CliDirZonCod] AS CliDirZonCod, T2.[ZonDsc] AS CliDirZonDsc FROM ([CLCLIENTESDIRECCION] T1 INNER JOIN [CZONAS] T2 ON T2.[ZonCod] = T1.[CliDirZonCod]) WHERE T1.[CliCod] = @AV11CliCod and T1.[CliDirItem] = @AV10DocCliDirItem ORDER BY T1.[CliCod], T1.[CliDirItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EK2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00EK3", "SELECT T1.[CliCod], T1.[ZonCod], T2.[ZonDsc] FROM ([CLCLIENTES] T1 LEFT JOIN [CZONAS] T2 ON T2.[ZonCod] = T1.[ZonCod]) WHERE T1.[CliCod] = @AV11CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EK3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
