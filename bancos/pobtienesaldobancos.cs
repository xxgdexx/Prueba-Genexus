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
namespace GeneXus.Programs.bancos {
   public class pobtienesaldobancos : GXProcedure
   {
      public pobtienesaldobancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pobtienesaldobancos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref string aP1_BanCuenta ,
                           ref DateTime aP2_Fecha ,
                           out decimal aP3_Saldo )
      {
         this.AV8BanCod = aP0_BanCod;
         this.AV12BanCuenta = aP1_BanCuenta;
         this.AV11Fecha = aP2_Fecha;
         this.AV10Saldo = 0 ;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV8BanCod;
         aP1_BanCuenta=this.AV12BanCuenta;
         aP2_Fecha=this.AV11Fecha;
         aP3_Saldo=this.AV10Saldo;
      }

      public decimal executeUdp( ref int aP0_BanCod ,
                                 ref string aP1_BanCuenta ,
                                 ref DateTime aP2_Fecha )
      {
         execute(ref aP0_BanCod, ref aP1_BanCuenta, ref aP2_Fecha, out aP3_Saldo);
         return AV10Saldo ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref string aP1_BanCuenta ,
                                 ref DateTime aP2_Fecha ,
                                 out decimal aP3_Saldo )
      {
         pobtienesaldobancos objpobtienesaldobancos;
         objpobtienesaldobancos = new pobtienesaldobancos();
         objpobtienesaldobancos.AV8BanCod = aP0_BanCod;
         objpobtienesaldobancos.AV12BanCuenta = aP1_BanCuenta;
         objpobtienesaldobancos.AV11Fecha = aP2_Fecha;
         objpobtienesaldobancos.AV10Saldo = 0 ;
         objpobtienesaldobancos.context.SetSubmitInitialConfig(context);
         objpobtienesaldobancos.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpobtienesaldobancos);
         aP0_BanCod=this.AV8BanCod;
         aP1_BanCuenta=this.AV12BanCuenta;
         aP2_Fecha=this.AV11Fecha;
         aP3_Saldo=this.AV10Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pobtienesaldobancos)stateInfo).executePrivate();
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
         /* Using cursor P009V2 */
         pr_default.execute(0, new Object[] {AV8BanCod, AV12BanCuenta, AV11Fecha});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1079LBFech = P009V2_A1079LBFech[0];
            A380LBCBCod = P009V2_A380LBCBCod[0];
            A379LBBanCod = P009V2_A379LBBanCod[0];
            A381LBRegistro = P009V2_A381LBRegistro[0];
            A1073LBTHaber = P009V2_A1073LBTHaber[0];
            A1072LBTDebe = P009V2_A1072LBTDebe[0];
            A1070LBTipo = P009V2_A1070LBTipo[0];
            A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
            A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
            A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
            AV10Saldo = (decimal)(AV10Saldo+(NumberUtil.Round( A1069LBDebeTot-A1082LBHaberTot, 2)));
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
         P009V2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P009V2_A380LBCBCod = new string[] {""} ;
         P009V2_A379LBBanCod = new int[1] ;
         P009V2_A381LBRegistro = new string[] {""} ;
         P009V2_A1073LBTHaber = new decimal[1] ;
         P009V2_A1072LBTDebe = new decimal[1] ;
         P009V2_A1070LBTipo = new short[1] ;
         A1079LBFech = DateTime.MinValue;
         A380LBCBCod = "";
         A381LBRegistro = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.pobtienesaldobancos__default(),
            new Object[][] {
                new Object[] {
               P009V2_A1079LBFech, P009V2_A380LBCBCod, P009V2_A379LBBanCod, P009V2_A381LBRegistro, P009V2_A1073LBTHaber, P009V2_A1072LBTDebe, P009V2_A1070LBTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1070LBTipo ;
      private int AV8BanCod ;
      private int A379LBBanCod ;
      private decimal AV10Saldo ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1069LBDebeTot ;
      private decimal A1082LBHaberTot ;
      private string AV12BanCuenta ;
      private string scmdbuf ;
      private string A380LBCBCod ;
      private string A381LBRegistro ;
      private DateTime AV11Fecha ;
      private DateTime A1079LBFech ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private string aP1_BanCuenta ;
      private DateTime aP2_Fecha ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P009V2_A1079LBFech ;
      private string[] P009V2_A380LBCBCod ;
      private int[] P009V2_A379LBBanCod ;
      private string[] P009V2_A381LBRegistro ;
      private decimal[] P009V2_A1073LBTHaber ;
      private decimal[] P009V2_A1072LBTDebe ;
      private short[] P009V2_A1070LBTipo ;
      private decimal aP3_Saldo ;
   }

   public class pobtienesaldobancos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009V2;
          prmP009V2 = new Object[] {
          new ParDef("@AV8BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV12BanCuenta",GXType.NChar,20,0) ,
          new ParDef("@AV11Fecha",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009V2", "SELECT [LBFech], [LBCBCod], [LBBanCod], [LBRegistro], [LBTHaber], [LBTDebe], [LBTipo] FROM [TSLIBROBANCOS] WHERE ([LBBanCod] = @AV8BanCod) AND ([LBCBCod] = RTRIM(LTRIM(@AV12BanCuenta))) AND ([LBFech] < @AV11Fecha) ORDER BY [LBBanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009V2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
       }
    }

 }

}
