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
namespace GeneXus.Programs.almacen {
   public class r_buscarprecios : GXProcedure
   {
      public r_buscarprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_buscarprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_pProdCod ,
                           ref int aP1_pTipLCod ,
                           ref string aP2_pCliCod ,
                           out decimal aP3_pPrecio )
      {
         this.AV10pProdCod = aP0_pProdCod;
         this.AV9pTipLCod = aP1_pTipLCod;
         this.AV13pCliCod = aP2_pCliCod;
         this.AV8pPrecio = 0 ;
         initialize();
         executePrivate();
         aP0_pProdCod=this.AV10pProdCod;
         aP1_pTipLCod=this.AV9pTipLCod;
         aP2_pCliCod=this.AV13pCliCod;
         aP3_pPrecio=this.AV8pPrecio;
      }

      public decimal executeUdp( ref string aP0_pProdCod ,
                                 ref int aP1_pTipLCod ,
                                 ref string aP2_pCliCod )
      {
         execute(ref aP0_pProdCod, ref aP1_pTipLCod, ref aP2_pCliCod, out aP3_pPrecio);
         return AV8pPrecio ;
      }

      public void executeSubmit( ref string aP0_pProdCod ,
                                 ref int aP1_pTipLCod ,
                                 ref string aP2_pCliCod ,
                                 out decimal aP3_pPrecio )
      {
         r_buscarprecios objr_buscarprecios;
         objr_buscarprecios = new r_buscarprecios();
         objr_buscarprecios.AV10pProdCod = aP0_pProdCod;
         objr_buscarprecios.AV9pTipLCod = aP1_pTipLCod;
         objr_buscarprecios.AV13pCliCod = aP2_pCliCod;
         objr_buscarprecios.AV8pPrecio = 0 ;
         objr_buscarprecios.context.SetSubmitInitialConfig(context);
         objr_buscarprecios.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_buscarprecios);
         aP0_pProdCod=this.AV10pProdCod;
         aP1_pTipLCod=this.AV9pTipLCod;
         aP2_pCliCod=this.AV13pCliCod;
         aP3_pPrecio=this.AV8pPrecio;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_buscarprecios)stateInfo).executePrivate();
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
         AV8pPrecio = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV9pTipLCod ,
                                              A202TipLCod ,
                                              A45CliCod ,
                                              A28ProdCod ,
                                              AV10pProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DK2 */
         pr_default.execute(0, new Object[] {AV10pProdCod, AV9pTipLCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ProdCod = P00DK2_A28ProdCod[0];
            A45CliCod = P00DK2_A45CliCod[0];
            n45CliCod = P00DK2_n45CliCod[0];
            A202TipLCod = P00DK2_A202TipLCod[0];
            A1681ProdCosto = P00DK2_A1681ProdCosto[0];
            A1652PreLisCred = P00DK2_A1652PreLisCred[0];
            A1651PreLis = P00DK2_A1651PreLis[0];
            A1205LisFech = P00DK2_A1205LisFech[0];
            A203TipLItem = P00DK2_A203TipLItem[0];
            A1681ProdCosto = P00DK2_A1681ProdCosto[0];
            AV11ProdCosto = A1681ProdCosto;
            AV12Porcentaje = A1652PreLisCred;
            AV8pPrecio = A1651PreLis;
            if ( ! (Convert.ToDecimal(0)==AV12Porcentaje) && (Convert.ToDecimal(0)==AV8pPrecio) )
            {
               AV8pPrecio = (!(Convert.ToDecimal(0)==AV11ProdCosto) ? AV11ProdCosto+NumberUtil.Round( (AV11ProdCosto*AV12Porcentaje)/ (decimal)(100), 2) : (decimal)(0));
               AV8pPrecio = NumberUtil.Round( AV8pPrecio, 1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV9pTipLCod ,
                                              A202TipLCod ,
                                              A45CliCod ,
                                              AV13pCliCod ,
                                              A28ProdCod ,
                                              AV10pProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DK3 */
         pr_default.execute(1, new Object[] {AV13pCliCod, AV10pProdCod, AV9pTipLCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A45CliCod = P00DK3_A45CliCod[0];
            n45CliCod = P00DK3_n45CliCod[0];
            A28ProdCod = P00DK3_A28ProdCod[0];
            A202TipLCod = P00DK3_A202TipLCod[0];
            A1681ProdCosto = P00DK3_A1681ProdCosto[0];
            A1652PreLisCred = P00DK3_A1652PreLisCred[0];
            A1651PreLis = P00DK3_A1651PreLis[0];
            A1205LisFech = P00DK3_A1205LisFech[0];
            A203TipLItem = P00DK3_A203TipLItem[0];
            A1681ProdCosto = P00DK3_A1681ProdCosto[0];
            AV11ProdCosto = A1681ProdCosto;
            AV12Porcentaje = A1652PreLisCred;
            AV8pPrecio = A1651PreLis;
            if ( ! (Convert.ToDecimal(0)==AV12Porcentaje) && (Convert.ToDecimal(0)==AV8pPrecio) )
            {
               AV8pPrecio = (!(Convert.ToDecimal(0)==AV11ProdCosto) ? AV11ProdCosto+NumberUtil.Round( (AV11ProdCosto*AV12Porcentaje)/ (decimal)(100), 2) : (decimal)(0));
               AV8pPrecio = NumberUtil.Round( AV8pPrecio, 1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.CommitDataStores("almacen.r_buscarprecios",pr_default);
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
         A45CliCod = "";
         A28ProdCod = "";
         P00DK2_A28ProdCod = new string[] {""} ;
         P00DK2_A45CliCod = new string[] {""} ;
         P00DK2_n45CliCod = new bool[] {false} ;
         P00DK2_A202TipLCod = new int[1] ;
         P00DK2_A1681ProdCosto = new decimal[1] ;
         P00DK2_A1652PreLisCred = new decimal[1] ;
         P00DK2_A1651PreLis = new decimal[1] ;
         P00DK2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P00DK2_A203TipLItem = new int[1] ;
         A1205LisFech = DateTime.MinValue;
         P00DK3_A45CliCod = new string[] {""} ;
         P00DK3_n45CliCod = new bool[] {false} ;
         P00DK3_A28ProdCod = new string[] {""} ;
         P00DK3_A202TipLCod = new int[1] ;
         P00DK3_A1681ProdCosto = new decimal[1] ;
         P00DK3_A1652PreLisCred = new decimal[1] ;
         P00DK3_A1651PreLis = new decimal[1] ;
         P00DK3_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P00DK3_A203TipLItem = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_buscarprecios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_buscarprecios__default(),
            new Object[][] {
                new Object[] {
               P00DK2_A28ProdCod, P00DK2_A45CliCod, P00DK2_n45CliCod, P00DK2_A202TipLCod, P00DK2_A1681ProdCosto, P00DK2_A1652PreLisCred, P00DK2_A1651PreLis, P00DK2_A1205LisFech, P00DK2_A203TipLItem
               }
               , new Object[] {
               P00DK3_A45CliCod, P00DK3_n45CliCod, P00DK3_A28ProdCod, P00DK3_A202TipLCod, P00DK3_A1681ProdCosto, P00DK3_A1652PreLisCred, P00DK3_A1651PreLis, P00DK3_A1205LisFech, P00DK3_A203TipLItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV9pTipLCod ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private decimal AV8pPrecio ;
      private decimal A1681ProdCosto ;
      private decimal A1652PreLisCred ;
      private decimal A1651PreLis ;
      private decimal AV11ProdCosto ;
      private decimal AV12Porcentaje ;
      private string AV10pProdCod ;
      private string AV13pCliCod ;
      private string scmdbuf ;
      private string A45CliCod ;
      private string A28ProdCod ;
      private DateTime A1205LisFech ;
      private bool n45CliCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_pProdCod ;
      private int aP1_pTipLCod ;
      private string aP2_pCliCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00DK2_A28ProdCod ;
      private string[] P00DK2_A45CliCod ;
      private bool[] P00DK2_n45CliCod ;
      private int[] P00DK2_A202TipLCod ;
      private decimal[] P00DK2_A1681ProdCosto ;
      private decimal[] P00DK2_A1652PreLisCred ;
      private decimal[] P00DK2_A1651PreLis ;
      private DateTime[] P00DK2_A1205LisFech ;
      private int[] P00DK2_A203TipLItem ;
      private string[] P00DK3_A45CliCod ;
      private bool[] P00DK3_n45CliCod ;
      private string[] P00DK3_A28ProdCod ;
      private int[] P00DK3_A202TipLCod ;
      private decimal[] P00DK3_A1681ProdCosto ;
      private decimal[] P00DK3_A1652PreLisCred ;
      private decimal[] P00DK3_A1651PreLis ;
      private DateTime[] P00DK3_A1205LisFech ;
      private int[] P00DK3_A203TipLItem ;
      private decimal aP3_pPrecio ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class r_buscarprecios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class r_buscarprecios__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00DK2( IGxContext context ,
                                           int AV9pTipLCod ,
                                           int A202TipLCod ,
                                           string A45CliCod ,
                                           string A28ProdCod ,
                                           string AV10pProdCod )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[2];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT T1.[ProdCod], T1.[CliCod], T1.[TipLCod], T2.[ProdCosto], T1.[PreLisCred], T1.[PreLis], T1.[LisFech], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod])";
       AddWhere(sWhereString, "((T1.[CliCod] = '') or T1.[CliCod] IS NULL)");
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV10pProdCod)");
       if ( ! ( AV9pTipLCod == 99 ) )
       {
          AddWhere(sWhereString, "(T1.[TipLCod] = @AV9pTipLCod)");
       }
       else
       {
          GXv_int1[1] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[LisFech]";
       GXv_Object2[0] = scmdbuf;
       GXv_Object2[1] = GXv_int1;
       return GXv_Object2 ;
    }

    protected Object[] conditional_P00DK3( IGxContext context ,
                                           int AV9pTipLCod ,
                                           int A202TipLCod ,
                                           string A45CliCod ,
                                           string AV13pCliCod ,
                                           string A28ProdCod ,
                                           string AV10pProdCod )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[3];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT T1.[CliCod], T1.[ProdCod], T1.[TipLCod], T2.[ProdCosto], T1.[PreLisCred], T1.[PreLis], T1.[LisFech], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod])";
       AddWhere(sWhereString, "(T1.[CliCod] = @AV13pCliCod)");
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV10pProdCod)");
       if ( ! ( AV9pTipLCod == 99 ) )
       {
          AddWhere(sWhereString, "(T1.[TipLCod] = @AV9pTipLCod)");
       }
       else
       {
          GXv_int3[2] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY T1.[LisFech]";
       GXv_Object4[0] = scmdbuf;
       GXv_Object4[1] = GXv_int3;
       return GXv_Object4 ;
    }

    public override Object [] getDynamicStatement( int cursor ,
                                                   IGxContext context ,
                                                   Object [] dynConstraints )
    {
       switch ( cursor )
       {
             case 0 :
                   return conditional_P00DK2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] );
             case 1 :
                   return conditional_P00DK3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
       }
       return base.getDynamicStatement(cursor, context, dynConstraints);
    }

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
        Object[] prmP00DK2;
        prmP00DK2 = new Object[] {
        new ParDef("@AV10pProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV9pTipLCod",GXType.Int32,6,0)
        };
        Object[] prmP00DK3;
        prmP00DK3 = new Object[] {
        new ParDef("@AV13pCliCod",GXType.NChar,20,0) ,
        new ParDef("@AV10pProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV9pTipLCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00DK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00DK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DK3,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getString(2, 15);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              return;
     }
  }

}

}
