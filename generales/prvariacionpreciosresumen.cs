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
namespace GeneXus.Programs.generales {
   public class prvariacionpreciosresumen : GXProcedure
   {
      public prvariacionpreciosresumen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public prvariacionpreciosresumen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_PrvCod ,
                           ref string aP1_ProdCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta ,
                           out decimal aP4_Porcentaje )
      {
         this.AV20PrvCod = aP0_PrvCod;
         this.AV19ProdCod = aP1_ProdCod;
         this.AV17FDesde = aP2_FDesde;
         this.AV18FHasta = aP3_FHasta;
         this.AV8Porcentaje = 0 ;
         initialize();
         executePrivate();
         aP0_PrvCod=this.AV20PrvCod;
         aP1_ProdCod=this.AV19ProdCod;
         aP2_FDesde=this.AV17FDesde;
         aP3_FHasta=this.AV18FHasta;
         aP4_Porcentaje=this.AV8Porcentaje;
      }

      public decimal executeUdp( ref string aP0_PrvCod ,
                                 ref string aP1_ProdCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta )
      {
         execute(ref aP0_PrvCod, ref aP1_ProdCod, ref aP2_FDesde, ref aP3_FHasta, out aP4_Porcentaje);
         return AV8Porcentaje ;
      }

      public void executeSubmit( ref string aP0_PrvCod ,
                                 ref string aP1_ProdCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta ,
                                 out decimal aP4_Porcentaje )
      {
         prvariacionpreciosresumen objprvariacionpreciosresumen;
         objprvariacionpreciosresumen = new prvariacionpreciosresumen();
         objprvariacionpreciosresumen.AV20PrvCod = aP0_PrvCod;
         objprvariacionpreciosresumen.AV19ProdCod = aP1_ProdCod;
         objprvariacionpreciosresumen.AV17FDesde = aP2_FDesde;
         objprvariacionpreciosresumen.AV18FHasta = aP3_FHasta;
         objprvariacionpreciosresumen.AV8Porcentaje = 0 ;
         objprvariacionpreciosresumen.context.SetSubmitInitialConfig(context);
         objprvariacionpreciosresumen.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprvariacionpreciosresumen);
         aP0_PrvCod=this.AV20PrvCod;
         aP1_ProdCod=this.AV19ProdCod;
         aP2_FDesde=this.AV17FDesde;
         aP3_FHasta=this.AV18FHasta;
         aP4_Porcentaje=this.AV8Porcentaje;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prvariacionpreciosresumen)stateInfo).executePrivate();
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
         AV9Por = 0.00m;
         AV16I = 1;
         /* Using cursor P00DJ2 */
         pr_default.execute(0, new Object[] {AV17FDesde, AV20PrvCod, AV19ProdCod, AV18FHasta});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A149TipCod = P00DJ2_A149TipCod[0];
            A243ComCod = P00DJ2_A243ComCod[0];
            A244PrvCod = P00DJ2_A244PrvCod[0];
            A254ComDProCod = P00DJ2_A254ComDProCod[0];
            n254ComDProCod = P00DJ2_n254ComDProCod[0];
            A248ComFec = P00DJ2_A248ComFec[0];
            A246ComMon = P00DJ2_A246ComMon[0];
            A1233MonAbr = P00DJ2_A1233MonAbr[0];
            n1233MonAbr = P00DJ2_n1233MonAbr[0];
            A686ComDPre = P00DJ2_A686ComDPre[0];
            A250ComDItem = P00DJ2_A250ComDItem[0];
            A251ComDOrdCod = P00DJ2_A251ComDOrdCod[0];
            A248ComFec = P00DJ2_A248ComFec[0];
            A246ComMon = P00DJ2_A246ComMon[0];
            A1233MonAbr = P00DJ2_A1233MonAbr[0];
            n1233MonAbr = P00DJ2_n1233MonAbr[0];
            AV10ComMon = A246ComMon;
            AV11MonAbr = A1233MonAbr;
            AV12ComDPre = A686ComDPre;
            AV13Precio = A686ComDPre;
            AV14ComFec = A248ComFec;
            if ( AV16I == 1 )
            {
               AV9Por = 0;
               AV15PrimerPrecio = AV13Precio;
            }
            else
            {
               AV9Por = (decimal)(NumberUtil.Round( (AV13Precio/ (decimal)(AV15PrimerPrecio))*100, 2)-100);
            }
            AV21UltimoPrecio = AV13Precio;
            AV16I = (long)(AV16I+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV8Porcentaje = AV9Por;
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
         P00DJ2_A149TipCod = new string[] {""} ;
         P00DJ2_A243ComCod = new string[] {""} ;
         P00DJ2_A244PrvCod = new string[] {""} ;
         P00DJ2_A254ComDProCod = new string[] {""} ;
         P00DJ2_n254ComDProCod = new bool[] {false} ;
         P00DJ2_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P00DJ2_A246ComMon = new int[1] ;
         P00DJ2_A1233MonAbr = new string[] {""} ;
         P00DJ2_n1233MonAbr = new bool[] {false} ;
         P00DJ2_A686ComDPre = new decimal[1] ;
         P00DJ2_A250ComDItem = new short[1] ;
         P00DJ2_A251ComDOrdCod = new string[] {""} ;
         A149TipCod = "";
         A243ComCod = "";
         A244PrvCod = "";
         A254ComDProCod = "";
         A248ComFec = DateTime.MinValue;
         A1233MonAbr = "";
         A251ComDOrdCod = "";
         AV11MonAbr = "";
         AV14ComFec = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.prvariacionpreciosresumen__default(),
            new Object[][] {
                new Object[] {
               P00DJ2_A149TipCod, P00DJ2_A243ComCod, P00DJ2_A244PrvCod, P00DJ2_A254ComDProCod, P00DJ2_n254ComDProCod, P00DJ2_A248ComFec, P00DJ2_A246ComMon, P00DJ2_A1233MonAbr, P00DJ2_n1233MonAbr, P00DJ2_A686ComDPre,
               P00DJ2_A250ComDItem, P00DJ2_A251ComDOrdCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A250ComDItem ;
      private int A246ComMon ;
      private int AV10ComMon ;
      private long AV16I ;
      private decimal AV8Porcentaje ;
      private decimal AV9Por ;
      private decimal A686ComDPre ;
      private decimal AV12ComDPre ;
      private decimal AV13Precio ;
      private decimal AV15PrimerPrecio ;
      private decimal AV21UltimoPrecio ;
      private string AV20PrvCod ;
      private string AV19ProdCod ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A244PrvCod ;
      private string A254ComDProCod ;
      private string A1233MonAbr ;
      private string A251ComDOrdCod ;
      private string AV11MonAbr ;
      private DateTime AV17FDesde ;
      private DateTime AV18FHasta ;
      private DateTime A248ComFec ;
      private DateTime AV14ComFec ;
      private bool n254ComDProCod ;
      private bool n1233MonAbr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_PrvCod ;
      private string aP1_ProdCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private string[] P00DJ2_A149TipCod ;
      private string[] P00DJ2_A243ComCod ;
      private string[] P00DJ2_A244PrvCod ;
      private string[] P00DJ2_A254ComDProCod ;
      private bool[] P00DJ2_n254ComDProCod ;
      private DateTime[] P00DJ2_A248ComFec ;
      private int[] P00DJ2_A246ComMon ;
      private string[] P00DJ2_A1233MonAbr ;
      private bool[] P00DJ2_n1233MonAbr ;
      private decimal[] P00DJ2_A686ComDPre ;
      private short[] P00DJ2_A250ComDItem ;
      private string[] P00DJ2_A251ComDOrdCod ;
      private decimal aP4_Porcentaje ;
   }

   public class prvariacionpreciosresumen__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DJ2;
          prmP00DJ2 = new Object[] {
          new ParDef("@AV17FDesde",GXType.Date,8,0) ,
          new ParDef("@AV20PrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV19ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV18FHasta",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DJ2", "SELECT T1.[TipCod], T1.[ComCod], T1.[PrvCod], T1.[ComDProCod], T2.[ComFec], T2.[ComMon] AS ComMon, T3.[MonAbr], T1.[ComDPre], T1.[ComDItem], T1.[ComDOrdCod] FROM (([CPCOMPRASDET] T1 INNER JOIN [CPCOMPRAS] T2 ON T2.[TipCod] = T1.[TipCod] AND T2.[ComCod] = T1.[ComCod] AND T2.[PrvCod] = T1.[PrvCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T2.[ComMon]) WHERE (T2.[ComFec] >= @AV17FDesde) AND (T1.[PrvCod] = @AV20PrvCod) AND (T1.[ComDProCod] = @AV19ProdCod) AND (T2.[ComFec] <= @AV18FHasta) ORDER BY T2.[ComFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DJ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 5);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((short[]) buf[10])[0] = rslt.getShort(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 10);
                return;
       }
    }

 }

}
