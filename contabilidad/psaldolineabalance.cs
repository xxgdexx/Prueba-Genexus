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
   public class psaldolineabalance : GXProcedure
   {
      public psaldolineabalance( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public psaldolineabalance( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_TotTipo ,
                           int aP1_TotRub ,
                           int aP2_RubCod ,
                           int aP3_RubLinCod ,
                           short aP4_Ano ,
                           short aP5_Mes ,
                           string aP6_Tipo ,
                           string aP7_CosCod ,
                           out decimal aP8_Saldo )
      {
         this.AV8TotTipo = aP0_TotTipo;
         this.AV9TotRub = aP1_TotRub;
         this.AV10RubCod = aP2_RubCod;
         this.AV11RubLinCod = aP3_RubLinCod;
         this.AV12Ano = aP4_Ano;
         this.AV13Mes = aP5_Mes;
         this.AV20Tipo = aP6_Tipo;
         this.AV26CosCod = aP7_CosCod;
         this.AV14Saldo = 0 ;
         initialize();
         executePrivate();
         aP8_Saldo=this.AV14Saldo;
      }

      public decimal executeUdp( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes ,
                                 string aP6_Tipo ,
                                 string aP7_CosCod )
      {
         execute(aP0_TotTipo, aP1_TotRub, aP2_RubCod, aP3_RubLinCod, aP4_Ano, aP5_Mes, aP6_Tipo, aP7_CosCod, out aP8_Saldo);
         return AV14Saldo ;
      }

      public void executeSubmit( string aP0_TotTipo ,
                                 int aP1_TotRub ,
                                 int aP2_RubCod ,
                                 int aP3_RubLinCod ,
                                 short aP4_Ano ,
                                 short aP5_Mes ,
                                 string aP6_Tipo ,
                                 string aP7_CosCod ,
                                 out decimal aP8_Saldo )
      {
         psaldolineabalance objpsaldolineabalance;
         objpsaldolineabalance = new psaldolineabalance();
         objpsaldolineabalance.AV8TotTipo = aP0_TotTipo;
         objpsaldolineabalance.AV9TotRub = aP1_TotRub;
         objpsaldolineabalance.AV10RubCod = aP2_RubCod;
         objpsaldolineabalance.AV11RubLinCod = aP3_RubLinCod;
         objpsaldolineabalance.AV12Ano = aP4_Ano;
         objpsaldolineabalance.AV13Mes = aP5_Mes;
         objpsaldolineabalance.AV20Tipo = aP6_Tipo;
         objpsaldolineabalance.AV26CosCod = aP7_CosCod;
         objpsaldolineabalance.AV14Saldo = 0 ;
         objpsaldolineabalance.context.SetSubmitInitialConfig(context);
         objpsaldolineabalance.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpsaldolineabalance);
         aP8_Saldo=this.AV14Saldo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((psaldolineabalance)stateInfo).executePrivate();
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
         AV14Saldo = 0.00m;
         /* Using cursor P00BO2 */
         pr_default.execute(0, new Object[] {AV8TotTipo, AV9TotRub, AV10RubCod, AV11RubLinCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A118RubLinCod = P00BO2_A118RubLinCod[0];
            A116RubCod = P00BO2_A116RubCod[0];
            A115TotRub = P00BO2_A115TotRub[0];
            A114TotTipo = P00BO2_A114TotTipo[0];
            A1825RubLDPos = P00BO2_A1825RubLDPos[0];
            A1824RubLDNeg = P00BO2_A1824RubLDNeg[0];
            A91CueCod = P00BO2_A91CueCod[0];
            AV23RubLDPos = A1825RubLDPos;
            AV24RubLDNeg = A1824RubLDNeg;
            AV17Len = (short)(StringUtil.Len( A91CueCod));
            AV18Cuenta = A91CueCod;
            AV25Signo = ((AV23RubLDPos==0)&&(AV24RubLDNeg==0) ? "" : ((AV23RubLDPos==1) ? "+" : "-"));
            /* Execute user subroutine: 'OBTIENESALDO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OBTIENESALDO' Routine */
         returnInSub = false;
         AV19ImpMov = 0.00m;
         /* Using cursor P00BO3 */
         pr_default.execute(1, new Object[] {AV17Len, AV18Cuenta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A91CueCod = P00BO3_A91CueCod[0];
            AV15CueCod = A91CueCod;
            if ( StringUtil.StrCmp(AV20Tipo, "ANT") == 0 )
            {
               GXt_decimal1 = AV19ImpMov;
               new GeneXus.Programs.contabilidad.psaldocuentabalances(context ).execute(  AV15CueCod,  AV12Ano,  AV13Mes, out  GXt_decimal1) ;
               AV19ImpMov = GXt_decimal1;
            }
            else
            {
               GXt_char2 = "";
               new GeneXus.Programs.contabilidad.poptienesaldocuentamesactual(context ).execute( ref  AV12Ano, ref  AV13Mes, ref  AV15CueCod, ref  GXt_char2, ref  AV26CosCod, out  AV21Debe, out  AV22Haber) ;
               AV19ImpMov = (decimal)(AV21Debe-AV22Haber);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Signo)) )
            {
               if ( StringUtil.StrCmp(AV25Signo, "+") == 0 )
               {
                  if ( ( AV19ImpMov < Convert.ToDecimal( 0 )) )
                  {
                     AV19ImpMov = 0;
                  }
               }
               else
               {
                  if ( ( AV19ImpMov > Convert.ToDecimal( 0 )) )
                  {
                     AV19ImpMov = 0;
                  }
               }
            }
            if ( ( StringUtil.StrCmp(AV8TotTipo, "BAL") == 0 ) && ( AV9TotRub == 2 ) )
            {
               AV19ImpMov = (decimal)(AV19ImpMov*-1);
            }
            AV14Saldo = (decimal)(AV14Saldo+AV19ImpMov);
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         P00BO2_A118RubLinCod = new int[1] ;
         P00BO2_A116RubCod = new int[1] ;
         P00BO2_A115TotRub = new int[1] ;
         P00BO2_A114TotTipo = new string[] {""} ;
         P00BO2_A1825RubLDPos = new short[1] ;
         P00BO2_A1824RubLDNeg = new short[1] ;
         P00BO2_A91CueCod = new string[] {""} ;
         A114TotTipo = "";
         A91CueCod = "";
         AV18Cuenta = "";
         AV25Signo = "";
         P00BO3_A91CueCod = new string[] {""} ;
         AV15CueCod = "";
         GXt_char2 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.psaldolineabalance__default(),
            new Object[][] {
                new Object[] {
               P00BO2_A118RubLinCod, P00BO2_A116RubCod, P00BO2_A115TotRub, P00BO2_A114TotTipo, P00BO2_A1825RubLDPos, P00BO2_A1824RubLDNeg, P00BO2_A91CueCod
               }
               , new Object[] {
               P00BO3_A91CueCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12Ano ;
      private short AV13Mes ;
      private short A1825RubLDPos ;
      private short A1824RubLDNeg ;
      private short AV23RubLDPos ;
      private short AV24RubLDNeg ;
      private short AV17Len ;
      private int AV9TotRub ;
      private int AV10RubCod ;
      private int AV11RubLinCod ;
      private int A118RubLinCod ;
      private int A116RubCod ;
      private int A115TotRub ;
      private decimal AV14Saldo ;
      private decimal AV19ImpMov ;
      private decimal GXt_decimal1 ;
      private decimal AV21Debe ;
      private decimal AV22Haber ;
      private string AV8TotTipo ;
      private string AV20Tipo ;
      private string AV26CosCod ;
      private string scmdbuf ;
      private string A114TotTipo ;
      private string A91CueCod ;
      private string AV18Cuenta ;
      private string AV25Signo ;
      private string AV15CueCod ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00BO2_A118RubLinCod ;
      private int[] P00BO2_A116RubCod ;
      private int[] P00BO2_A115TotRub ;
      private string[] P00BO2_A114TotTipo ;
      private short[] P00BO2_A1825RubLDPos ;
      private short[] P00BO2_A1824RubLDNeg ;
      private string[] P00BO2_A91CueCod ;
      private string[] P00BO3_A91CueCod ;
      private decimal aP8_Saldo ;
   }

   public class psaldolineabalance__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00BO2;
          prmP00BO2 = new Object[] {
          new ParDef("@AV8TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV9TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV10RubCod",GXType.Int32,6,0) ,
          new ParDef("@AV11RubLinCod",GXType.Int32,6,0)
          };
          Object[] prmP00BO3;
          prmP00BO3 = new Object[] {
          new ParDef("@AV17Len",GXType.Int16,2,0) ,
          new ParDef("@AV18Cuenta",GXType.Char,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BO2", "SELECT [RubLinCod], [RubCod], [TotRub], [TotTipo], [RubLDPos], [RubLDNeg], [CueCod] FROM [CBRUBROSLD] WHERE [TotTipo] = @AV8TotTipo and [TotRub] = @AV9TotRub and [RubCod] = @AV10RubCod and [RubLinCod] = @AV11RubLinCod ORDER BY [TotTipo], [TotRub], [RubCod], [RubLinCod], [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BO2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BO3", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE SUBSTRING([CueCod], 1, @AV17Len) = @AV18Cuenta ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BO3,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                return;
       }
    }

 }

}
