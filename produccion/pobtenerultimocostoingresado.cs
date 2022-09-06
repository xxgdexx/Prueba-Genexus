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
namespace GeneXus.Programs.produccion {
   public class pobtenerultimocostoingresado : GXProcedure
   {
      public pobtenerultimocostoingresado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtenerultimocostoingresado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_MVAlm ,
                           ref string aP1_ProdCod ,
                           ref DateTime aP2_MvAFec ,
                           out decimal aP3_MVADPrecio )
      {
         this.AV11MVAlm = aP0_MVAlm;
         this.AV10ProdCod = aP1_ProdCod;
         this.AV8MvAFec = aP2_MvAFec;
         this.AV9MVADPrecio = 0 ;
         initialize();
         executePrivate();
         aP0_MVAlm=this.AV11MVAlm;
         aP1_ProdCod=this.AV10ProdCod;
         aP2_MvAFec=this.AV8MvAFec;
         aP3_MVADPrecio=this.AV9MVADPrecio;
      }

      public decimal executeUdp( ref int aP0_MVAlm ,
                                 ref string aP1_ProdCod ,
                                 ref DateTime aP2_MvAFec )
      {
         execute(ref aP0_MVAlm, ref aP1_ProdCod, ref aP2_MvAFec, out aP3_MVADPrecio);
         return AV9MVADPrecio ;
      }

      public void executeSubmit( ref int aP0_MVAlm ,
                                 ref string aP1_ProdCod ,
                                 ref DateTime aP2_MvAFec ,
                                 out decimal aP3_MVADPrecio )
      {
         pobtenerultimocostoingresado objpobtenerultimocostoingresado;
         objpobtenerultimocostoingresado = new pobtenerultimocostoingresado();
         objpobtenerultimocostoingresado.AV11MVAlm = aP0_MVAlm;
         objpobtenerultimocostoingresado.AV10ProdCod = aP1_ProdCod;
         objpobtenerultimocostoingresado.AV8MvAFec = aP2_MvAFec;
         objpobtenerultimocostoingresado.AV9MVADPrecio = 0 ;
         objpobtenerultimocostoingresado.context.SetSubmitInitialConfig(context);
         objpobtenerultimocostoingresado.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtenerultimocostoingresado);
         aP0_MVAlm=this.AV11MVAlm;
         aP1_ProdCod=this.AV10ProdCod;
         aP2_MvAFec=this.AV8MvAFec;
         aP3_MVADPrecio=this.AV9MVADPrecio;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtenerultimocostoingresado)stateInfo).executePrivate();
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
         AV9MVADPrecio = 0.000000m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11MVAlm ,
                                              A21MvAlm ,
                                              A1250MVADPrecio ,
                                              A28ProdCod ,
                                              AV10ProdCod ,
                                              A13MvATip ,
                                              AV8MvAFec } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DATE
                                              }
         });
         /* Using cursor P008M2 */
         pr_default.execute(0, new Object[] {AV8MvAFec, AV10ProdCod, AV11MVAlm});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14MvACod = P008M2_A14MvACod[0];
            A28ProdCod = P008M2_A28ProdCod[0];
            A13MvATip = P008M2_A13MvATip[0];
            A1250MVADPrecio = P008M2_A1250MVADPrecio[0];
            A21MvAlm = P008M2_A21MvAlm[0];
            A25MvAFec = P008M2_A25MvAFec[0];
            A30MvADItem = P008M2_A30MvADItem[0];
            A21MvAlm = P008M2_A21MvAlm[0];
            A25MvAFec = P008M2_A25MvAFec[0];
            AV9MVADPrecio = A1250MVADPrecio;
            if ( ! (Convert.ToDecimal(0)==AV9MVADPrecio) )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
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
         A28ProdCod = "";
         A13MvATip = "";
         P008M2_A14MvACod = new string[] {""} ;
         P008M2_A28ProdCod = new string[] {""} ;
         P008M2_A13MvATip = new string[] {""} ;
         P008M2_A1250MVADPrecio = new decimal[1] ;
         P008M2_A21MvAlm = new int[1] ;
         P008M2_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         P008M2_A30MvADItem = new int[1] ;
         A14MvACod = "";
         A25MvAFec = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.pobtenerultimocostoingresado__default(),
            new Object[][] {
                new Object[] {
               P008M2_A14MvACod, P008M2_A28ProdCod, P008M2_A13MvATip, P008M2_A1250MVADPrecio, P008M2_A21MvAlm, P008M2_A25MvAFec, P008M2_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV11MVAlm ;
      private int A21MvAlm ;
      private int A30MvADItem ;
      private decimal AV9MVADPrecio ;
      private decimal A1250MVADPrecio ;
      private string AV10ProdCod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A13MvATip ;
      private string A14MvACod ;
      private DateTime AV8MvAFec ;
      private DateTime A25MvAFec ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_MVAlm ;
      private string aP1_ProdCod ;
      private DateTime aP2_MvAFec ;
      private IDataStoreProvider pr_default ;
      private string[] P008M2_A14MvACod ;
      private string[] P008M2_A28ProdCod ;
      private string[] P008M2_A13MvATip ;
      private decimal[] P008M2_A1250MVADPrecio ;
      private int[] P008M2_A21MvAlm ;
      private DateTime[] P008M2_A25MvAFec ;
      private int[] P008M2_A30MvADItem ;
      private decimal aP3_MVADPrecio ;
   }

   public class pobtenerultimocostoingresado__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008M2( IGxContext context ,
                                             int AV11MVAlm ,
                                             int A21MvAlm ,
                                             decimal A1250MVADPrecio ,
                                             string A28ProdCod ,
                                             string AV10ProdCod ,
                                             string A13MvATip ,
                                             DateTime AV8MvAFec )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MvACod], T1.[ProdCod], T1.[MvATip], T1.[MVADPrecio], T2.[MvAlm], T2.[MvAFec], T1.[MvADItem] FROM ([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod])";
         AddWhere(sWhereString, "(T2.[MvAFec] < @AV8MvAFec)");
         AddWhere(sWhereString, "(T1.[MVADPrecio] > 0)");
         AddWhere(sWhereString, "(Not (T1.[MVADPrecio] = convert(int, 0)))");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV10ProdCod)");
         AddWhere(sWhereString, "(T1.[MvATip] = 'ING')");
         if ( ! (0==AV11MVAlm) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV11MVAlm)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MvAFec] DESC";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008M2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP008M2;
          prmP008M2 = new Object[] {
          new ParDef("@AV8MvAFec",GXType.Date,8,0) ,
          new ParDef("@AV10ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11MVAlm",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008M2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
