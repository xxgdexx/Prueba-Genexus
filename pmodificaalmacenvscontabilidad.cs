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
   public class pmodificaalmacenvscontabilidad : GXProcedure
   {
      public pmodificaalmacenvscontabilidad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pmodificaalmacenvscontabilidad( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_Item ,
                           ref DateTime aP1_VSFecha ,
                           ref string aP2_VSOrdCod ,
                           ref string aP3_VSMVACod ,
                           ref string aP4_VSProdCod ,
                           ref string aP5_VSProdDsc ,
                           ref string aP6_VSTipCod ,
                           ref string aP7_VSDocNum ,
                           ref decimal aP8_VSCantIng ,
                           ref decimal aP9_VSCostoIng ,
                           ref decimal aP10_VSCantFac ,
                           ref decimal aP11_VSCostoFac ,
                           ref string aP12_VSTipMov ,
                           ref short aP13_Flag )
      {
         this.AV20Item = aP0_Item;
         this.AV8VSFecha = aP1_VSFecha;
         this.AV9VSOrdCod = aP2_VSOrdCod;
         this.AV10VSMVACod = aP3_VSMVACod;
         this.AV11VSProdCod = aP4_VSProdCod;
         this.AV12VSProdDsc = aP5_VSProdDsc;
         this.AV13VSTipCod = aP6_VSTipCod;
         this.AV14VSDocNum = aP7_VSDocNum;
         this.AV15VSCantIng = aP8_VSCantIng;
         this.AV16VSCostoIng = aP9_VSCostoIng;
         this.AV17VSCantFac = aP10_VSCantFac;
         this.AV18VSCostoFac = aP11_VSCostoFac;
         this.AV19VSTipMov = aP12_VSTipMov;
         this.AV21Flag = aP13_Flag;
         initialize();
         executePrivate();
         aP0_Item=this.AV20Item;
         aP1_VSFecha=this.AV8VSFecha;
         aP2_VSOrdCod=this.AV9VSOrdCod;
         aP3_VSMVACod=this.AV10VSMVACod;
         aP4_VSProdCod=this.AV11VSProdCod;
         aP5_VSProdDsc=this.AV12VSProdDsc;
         aP6_VSTipCod=this.AV13VSTipCod;
         aP7_VSDocNum=this.AV14VSDocNum;
         aP8_VSCantIng=this.AV15VSCantIng;
         aP9_VSCostoIng=this.AV16VSCostoIng;
         aP10_VSCantFac=this.AV17VSCantFac;
         aP11_VSCostoFac=this.AV18VSCostoFac;
         aP12_VSTipMov=this.AV19VSTipMov;
         aP13_Flag=this.AV21Flag;
      }

      public short executeUdp( ref long aP0_Item ,
                               ref DateTime aP1_VSFecha ,
                               ref string aP2_VSOrdCod ,
                               ref string aP3_VSMVACod ,
                               ref string aP4_VSProdCod ,
                               ref string aP5_VSProdDsc ,
                               ref string aP6_VSTipCod ,
                               ref string aP7_VSDocNum ,
                               ref decimal aP8_VSCantIng ,
                               ref decimal aP9_VSCostoIng ,
                               ref decimal aP10_VSCantFac ,
                               ref decimal aP11_VSCostoFac ,
                               ref string aP12_VSTipMov )
      {
         execute(ref aP0_Item, ref aP1_VSFecha, ref aP2_VSOrdCod, ref aP3_VSMVACod, ref aP4_VSProdCod, ref aP5_VSProdDsc, ref aP6_VSTipCod, ref aP7_VSDocNum, ref aP8_VSCantIng, ref aP9_VSCostoIng, ref aP10_VSCantFac, ref aP11_VSCostoFac, ref aP12_VSTipMov, ref aP13_Flag);
         return AV21Flag ;
      }

      public void executeSubmit( ref long aP0_Item ,
                                 ref DateTime aP1_VSFecha ,
                                 ref string aP2_VSOrdCod ,
                                 ref string aP3_VSMVACod ,
                                 ref string aP4_VSProdCod ,
                                 ref string aP5_VSProdDsc ,
                                 ref string aP6_VSTipCod ,
                                 ref string aP7_VSDocNum ,
                                 ref decimal aP8_VSCantIng ,
                                 ref decimal aP9_VSCostoIng ,
                                 ref decimal aP10_VSCantFac ,
                                 ref decimal aP11_VSCostoFac ,
                                 ref string aP12_VSTipMov ,
                                 ref short aP13_Flag )
      {
         pmodificaalmacenvscontabilidad objpmodificaalmacenvscontabilidad;
         objpmodificaalmacenvscontabilidad = new pmodificaalmacenvscontabilidad();
         objpmodificaalmacenvscontabilidad.AV20Item = aP0_Item;
         objpmodificaalmacenvscontabilidad.AV8VSFecha = aP1_VSFecha;
         objpmodificaalmacenvscontabilidad.AV9VSOrdCod = aP2_VSOrdCod;
         objpmodificaalmacenvscontabilidad.AV10VSMVACod = aP3_VSMVACod;
         objpmodificaalmacenvscontabilidad.AV11VSProdCod = aP4_VSProdCod;
         objpmodificaalmacenvscontabilidad.AV12VSProdDsc = aP5_VSProdDsc;
         objpmodificaalmacenvscontabilidad.AV13VSTipCod = aP6_VSTipCod;
         objpmodificaalmacenvscontabilidad.AV14VSDocNum = aP7_VSDocNum;
         objpmodificaalmacenvscontabilidad.AV15VSCantIng = aP8_VSCantIng;
         objpmodificaalmacenvscontabilidad.AV16VSCostoIng = aP9_VSCostoIng;
         objpmodificaalmacenvscontabilidad.AV17VSCantFac = aP10_VSCantFac;
         objpmodificaalmacenvscontabilidad.AV18VSCostoFac = aP11_VSCostoFac;
         objpmodificaalmacenvscontabilidad.AV19VSTipMov = aP12_VSTipMov;
         objpmodificaalmacenvscontabilidad.AV21Flag = aP13_Flag;
         objpmodificaalmacenvscontabilidad.context.SetSubmitInitialConfig(context);
         objpmodificaalmacenvscontabilidad.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpmodificaalmacenvscontabilidad);
         aP0_Item=this.AV20Item;
         aP1_VSFecha=this.AV8VSFecha;
         aP2_VSOrdCod=this.AV9VSOrdCod;
         aP3_VSMVACod=this.AV10VSMVACod;
         aP4_VSProdCod=this.AV11VSProdCod;
         aP5_VSProdDsc=this.AV12VSProdDsc;
         aP6_VSTipCod=this.AV13VSTipCod;
         aP7_VSDocNum=this.AV14VSDocNum;
         aP8_VSCantIng=this.AV15VSCantIng;
         aP9_VSCostoIng=this.AV16VSCostoIng;
         aP10_VSCantFac=this.AV17VSCantFac;
         aP11_VSCostoFac=this.AV18VSCostoFac;
         aP12_VSTipMov=this.AV19VSTipMov;
         aP13_Flag=this.AV21Flag;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pmodificaalmacenvscontabilidad)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11VSProdCod)) && String.IsNullOrEmpty(StringUtil.RTrim( AV9VSOrdCod)) )
         {
            /* Execute user subroutine: 'ITEM' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /*
               INSERT RECORD ON TABLE CPALMACENVSCONTA

            */
            A237VSItem = AV20Item;
            A2087VSFecha = AV8VSFecha;
            A2089VSOrdCod = AV9VSOrdCod;
            A2088VSMVACod = AV10VSMVACod;
            A2090VSProdCod = AV11VSProdCod;
            A2091VSProdDsc = AV12VSProdDsc;
            A2092VSTipCod = AV13VSTipCod;
            A2086VSDocNum = AV14VSDocNum;
            A2083VSCantIng = AV15VSCantIng;
            A2085VSCostoIng = AV16VSCostoIng;
            A2082VSCantFac = AV17VSCantFac;
            A2084VSCostoFac = AV18VSCostoFac;
            A2093VSTipMov = AV19VSTipMov;
            /* Using cursor P00DC2 */
            pr_default.execute(0, new Object[] {A237VSItem, A2087VSFecha, A2089VSOrdCod, A2088VSMVACod, A2090VSProdCod, A2091VSProdDsc, A2092VSTipCod, A2086VSDocNum, A2083VSCantIng, A2085VSCostoIng, A2082VSCantFac, A2084VSCostoFac, A2093VSTipMov});
            pr_default.close(0);
            dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
            if ( (pr_default.getStatus(0) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
         }
         else
         {
            AV24GXLvl21 = 0;
            /* Optimized UPDATE. */
            /* Using cursor P00DC3 */
            pr_default.execute(1, new Object[] {AV19VSTipMov, AV16VSCostoIng, AV15VSCantIng, AV10VSMVACod, AV18VSCostoFac, AV17VSCantFac, AV14VSDocNum, AV13VSTipCod, AV11VSProdCod, AV9VSOrdCod});
            if ( (pr_default.getStatus(1) != 101) )
            {
               AV24GXLvl21 = 1;
            }
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
            /* End optimized UPDATE. */
            if ( AV24GXLvl21 == 0 )
            {
               /* Execute user subroutine: 'ITEM' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /*
                  INSERT RECORD ON TABLE CPALMACENVSCONTA

               */
               A237VSItem = AV20Item;
               A2087VSFecha = AV8VSFecha;
               A2089VSOrdCod = AV9VSOrdCod;
               A2088VSMVACod = AV10VSMVACod;
               A2090VSProdCod = AV11VSProdCod;
               A2091VSProdDsc = AV12VSProdDsc;
               A2092VSTipCod = AV13VSTipCod;
               A2086VSDocNum = AV14VSDocNum;
               A2083VSCantIng = AV15VSCantIng;
               A2085VSCostoIng = AV16VSCostoIng;
               A2082VSCantFac = AV17VSCantFac;
               A2084VSCostoFac = AV18VSCostoFac;
               A2093VSTipMov = AV19VSTipMov;
               /* Using cursor P00DC4 */
               pr_default.execute(2, new Object[] {A237VSItem, A2087VSFecha, A2089VSOrdCod, A2088VSMVACod, A2090VSProdCod, A2091VSProdDsc, A2092VSTipCod, A2086VSDocNum, A2083VSCantIng, A2085VSCostoIng, A2082VSCantFac, A2084VSCostoFac, A2093VSTipMov});
               pr_default.close(2);
               dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
               if ( (pr_default.getStatus(2) == 1) )
               {
                  context.Gx_err = 1;
                  Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
               }
               else
               {
                  context.Gx_err = 0;
                  Gx_emsg = "";
               }
               /* End Insert */
            }
         }
         context.CommitDataStores("pmodificaalmacenvscontabilidad",pr_default);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ITEM' Routine */
         returnInSub = false;
         /* Using cursor P00DC5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A237VSItem = P00DC5_A237VSItem[0];
            AV20Item = A237VSItem;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV20Item = (long)(AV20Item+1);
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
         A2087VSFecha = DateTime.MinValue;
         A2089VSOrdCod = "";
         A2088VSMVACod = "";
         A2090VSProdCod = "";
         A2091VSProdDsc = "";
         A2092VSTipCod = "";
         A2086VSDocNum = "";
         A2093VSTipMov = "";
         Gx_emsg = "";
         scmdbuf = "";
         P00DC5_A237VSItem = new long[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.pmodificaalmacenvscontabilidad__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pmodificaalmacenvscontabilidad__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00DC5_A237VSItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV21Flag ;
      private short AV24GXLvl21 ;
      private int GX_INS108 ;
      private long AV20Item ;
      private long A237VSItem ;
      private decimal AV15VSCantIng ;
      private decimal AV16VSCostoIng ;
      private decimal AV17VSCantFac ;
      private decimal AV18VSCostoFac ;
      private decimal A2083VSCantIng ;
      private decimal A2085VSCostoIng ;
      private decimal A2082VSCantFac ;
      private decimal A2084VSCostoFac ;
      private string AV9VSOrdCod ;
      private string AV10VSMVACod ;
      private string AV11VSProdCod ;
      private string AV13VSTipCod ;
      private string AV14VSDocNum ;
      private string A2089VSOrdCod ;
      private string A2088VSMVACod ;
      private string A2090VSProdCod ;
      private string A2092VSTipCod ;
      private string A2086VSDocNum ;
      private string Gx_emsg ;
      private string scmdbuf ;
      private DateTime AV8VSFecha ;
      private DateTime A2087VSFecha ;
      private bool returnInSub ;
      private string AV12VSProdDsc ;
      private string AV19VSTipMov ;
      private string A2091VSProdDsc ;
      private string A2093VSTipMov ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private long aP0_Item ;
      private DateTime aP1_VSFecha ;
      private string aP2_VSOrdCod ;
      private string aP3_VSMVACod ;
      private string aP4_VSProdCod ;
      private string aP5_VSProdDsc ;
      private string aP6_VSTipCod ;
      private string aP7_VSDocNum ;
      private decimal aP8_VSCantIng ;
      private decimal aP9_VSCostoIng ;
      private decimal aP10_VSCantFac ;
      private decimal aP11_VSCostoFac ;
      private string aP12_VSTipMov ;
      private short aP13_Flag ;
      private IDataStoreProvider pr_default ;
      private long[] P00DC5_A237VSItem ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pmodificaalmacenvscontabilidad__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pmodificaalmacenvscontabilidad__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00DC2;
        prmP00DC2 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0) ,
        new ParDef("@VSFecha",GXType.Date,8,0) ,
        new ParDef("@VSOrdCod",GXType.NChar,10,0) ,
        new ParDef("@VSMVACod",GXType.NChar,10,0) ,
        new ParDef("@VSProdCod",GXType.NChar,15,0) ,
        new ParDef("@VSProdDsc",GXType.NVarChar,100,0) ,
        new ParDef("@VSTipCod",GXType.NChar,5,0) ,
        new ParDef("@VSDocNum",GXType.NChar,15,0) ,
        new ParDef("@VSCantIng",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoIng",GXType.Decimal,15,2) ,
        new ParDef("@VSCantFac",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoFac",GXType.Decimal,15,2) ,
        new ParDef("@VSTipMov",GXType.NVarChar,100,0)
        };
        Object[] prmP00DC3;
        prmP00DC3 = new Object[] {
        new ParDef("@AV19VSTipMov",GXType.VarChar,100,0) ,
        new ParDef("@AV16VSCostoIng",GXType.Decimal,15,2) ,
        new ParDef("@AV15VSCantIng",GXType.Decimal,15,4) ,
        new ParDef("@AV10VSMVACod",GXType.Char,10,0) ,
        new ParDef("@AV18VSCostoFac",GXType.Decimal,15,2) ,
        new ParDef("@AV17VSCantFac",GXType.Decimal,15,4) ,
        new ParDef("@AV14VSDocNum",GXType.Char,15,0) ,
        new ParDef("@AV13VSTipCod",GXType.Char,5,0) ,
        new ParDef("@AV11VSProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV9VSOrdCod",GXType.NChar,10,0)
        };
        Object[] prmP00DC4;
        prmP00DC4 = new Object[] {
        new ParDef("@VSItem",GXType.Decimal,10,0) ,
        new ParDef("@VSFecha",GXType.Date,8,0) ,
        new ParDef("@VSOrdCod",GXType.NChar,10,0) ,
        new ParDef("@VSMVACod",GXType.NChar,10,0) ,
        new ParDef("@VSProdCod",GXType.NChar,15,0) ,
        new ParDef("@VSProdDsc",GXType.NVarChar,100,0) ,
        new ParDef("@VSTipCod",GXType.NChar,5,0) ,
        new ParDef("@VSDocNum",GXType.NChar,15,0) ,
        new ParDef("@VSCantIng",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoIng",GXType.Decimal,15,2) ,
        new ParDef("@VSCantFac",GXType.Decimal,15,4) ,
        new ParDef("@VSCostoFac",GXType.Decimal,15,2) ,
        new ParDef("@VSTipMov",GXType.NVarChar,100,0)
        };
        Object[] prmP00DC5;
        prmP00DC5 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00DC2", "INSERT INTO [CPALMACENVSCONTA]([VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov]) VALUES(@VSItem, @VSFecha, @VSOrdCod, @VSMVACod, @VSProdCod, @VSProdDsc, @VSTipCod, @VSDocNum, @VSCantIng, @VSCostoIng, @VSCantFac, @VSCostoFac, @VSTipMov)", GxErrorMask.GX_NOMASK,prmP00DC2)
           ,new CursorDef("P00DC3", "UPDATE [CPALMACENVSCONTA] SET [VSTipMov]=CASE  WHEN ([VSTipMov] = '') THEN @AV19VSTipMov ELSE [VSTipMov] END, [VSCostoIng]=CASE  WHEN ([VSCostoIng] = convert(int, 0)) THEN @AV16VSCostoIng ELSE [VSCostoIng] END, [VSCantIng]=CASE  WHEN ([VSCantIng] = convert(int, 0)) THEN @AV15VSCantIng ELSE [VSCantIng] END, [VSMVACod]=CASE  WHEN ([VSMVACod] = '') THEN @AV10VSMVACod ELSE [VSMVACod] END, [VSCostoFac]=CASE  WHEN ([VSCostoFac] = convert(int, 0)) THEN @AV18VSCostoFac ELSE [VSCostoFac] END, [VSCantFac]=CASE  WHEN ([VSCantFac] = convert(int, 0)) THEN @AV17VSCantFac ELSE [VSCantFac] END, [VSDocNum]=CASE  WHEN ([VSDocNum] = '') THEN @AV14VSDocNum ELSE [VSDocNum] END, [VSTipCod]=CASE  WHEN ([VSTipCod] = '') THEN @AV13VSTipCod ELSE [VSTipCod] END  WHERE ([VSProdCod] = @AV11VSProdCod) AND ([VSOrdCod] = @AV9VSOrdCod)", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00DC3)
           ,new CursorDef("P00DC4", "INSERT INTO [CPALMACENVSCONTA]([VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov]) VALUES(@VSItem, @VSFecha, @VSOrdCod, @VSMVACod, @VSProdCod, @VSProdDsc, @VSTipCod, @VSDocNum, @VSCantIng, @VSCostoIng, @VSCantFac, @VSCostoFac, @VSTipMov)", GxErrorMask.GX_NOMASK,prmP00DC4)
           ,new CursorDef("P00DC5", "SELECT [VSItem] FROM [CPALMACENVSCONTA] ORDER BY [VSItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DC5,100, GxCacheFrequency.OFF ,false,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
