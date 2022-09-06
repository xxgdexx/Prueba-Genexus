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
   public class pgrabaalmacenvscontabilidad : GXProcedure
   {
      public pgrabaalmacenvscontabilidad( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pgrabaalmacenvscontabilidad( IGxContext context )
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
         pgrabaalmacenvscontabilidad objpgrabaalmacenvscontabilidad;
         objpgrabaalmacenvscontabilidad = new pgrabaalmacenvscontabilidad();
         objpgrabaalmacenvscontabilidad.AV20Item = aP0_Item;
         objpgrabaalmacenvscontabilidad.AV8VSFecha = aP1_VSFecha;
         objpgrabaalmacenvscontabilidad.AV9VSOrdCod = aP2_VSOrdCod;
         objpgrabaalmacenvscontabilidad.AV10VSMVACod = aP3_VSMVACod;
         objpgrabaalmacenvscontabilidad.AV11VSProdCod = aP4_VSProdCod;
         objpgrabaalmacenvscontabilidad.AV12VSProdDsc = aP5_VSProdDsc;
         objpgrabaalmacenvscontabilidad.AV13VSTipCod = aP6_VSTipCod;
         objpgrabaalmacenvscontabilidad.AV14VSDocNum = aP7_VSDocNum;
         objpgrabaalmacenvscontabilidad.AV15VSCantIng = aP8_VSCantIng;
         objpgrabaalmacenvscontabilidad.AV16VSCostoIng = aP9_VSCostoIng;
         objpgrabaalmacenvscontabilidad.AV17VSCantFac = aP10_VSCantFac;
         objpgrabaalmacenvscontabilidad.AV18VSCostoFac = aP11_VSCostoFac;
         objpgrabaalmacenvscontabilidad.AV19VSTipMov = aP12_VSTipMov;
         objpgrabaalmacenvscontabilidad.AV21Flag = aP13_Flag;
         objpgrabaalmacenvscontabilidad.context.SetSubmitInitialConfig(context);
         objpgrabaalmacenvscontabilidad.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpgrabaalmacenvscontabilidad);
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
            ((pgrabaalmacenvscontabilidad)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV9VSOrdCod)) && String.IsNullOrEmpty(StringUtil.RTrim( AV11VSProdCod)) )
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
            /* Using cursor P00DB2 */
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
            /* Using cursor P00DB3 */
            pr_default.execute(1, new Object[] {A237VSItem, A2087VSFecha, A2089VSOrdCod, A2088VSMVACod, A2090VSProdCod, A2091VSProdDsc, A2092VSTipCod, A2086VSDocNum, A2083VSCantIng, A2085VSCostoIng, A2082VSCantFac, A2084VSCostoFac, A2093VSTipMov});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("CPALMACENVSCONTA");
            if ( (pr_default.getStatus(1) == 1) )
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
         context.CommitDataStores("pgrabaalmacenvscontabilidad",pr_default);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'ITEM' Routine */
         returnInSub = false;
         /* Using cursor P00DB4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A237VSItem = P00DB4_A237VSItem[0];
            AV20Item = A237VSItem;
            pr_default.readNext(2);
         }
         pr_default.close(2);
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
         P00DB4_A237VSItem = new long[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.pgrabaalmacenvscontabilidad__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pgrabaalmacenvscontabilidad__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00DB4_A237VSItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV21Flag ;
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
      private long[] P00DB4_A237VSItem ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pgrabaalmacenvscontabilidad__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pgrabaalmacenvscontabilidad__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00DB2;
        prmP00DB2 = new Object[] {
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
        Object[] prmP00DB3;
        prmP00DB3 = new Object[] {
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
        Object[] prmP00DB4;
        prmP00DB4 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("P00DB2", "INSERT INTO [CPALMACENVSCONTA]([VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov]) VALUES(@VSItem, @VSFecha, @VSOrdCod, @VSMVACod, @VSProdCod, @VSProdDsc, @VSTipCod, @VSDocNum, @VSCantIng, @VSCostoIng, @VSCantFac, @VSCostoFac, @VSTipMov)", GxErrorMask.GX_NOMASK,prmP00DB2)
           ,new CursorDef("P00DB3", "INSERT INTO [CPALMACENVSCONTA]([VSItem], [VSFecha], [VSOrdCod], [VSMVACod], [VSProdCod], [VSProdDsc], [VSTipCod], [VSDocNum], [VSCantIng], [VSCostoIng], [VSCantFac], [VSCostoFac], [VSTipMov]) VALUES(@VSItem, @VSFecha, @VSOrdCod, @VSMVACod, @VSProdCod, @VSProdDsc, @VSTipCod, @VSDocNum, @VSCantIng, @VSCostoIng, @VSCantFac, @VSCostoFac, @VSTipMov)", GxErrorMask.GX_NOMASK,prmP00DB3)
           ,new CursorDef("P00DB4", "SELECT [VSItem] FROM [CPALMACENVSCONTA] ORDER BY [VSItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DB4,100, GxCacheFrequency.OFF ,false,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
