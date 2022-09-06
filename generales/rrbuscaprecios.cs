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
   public class rrbuscaprecios : GXProcedure
   {
      public rrbuscaprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rrbuscaprecios( IGxContext context )
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
         this.AV20pProdCod = aP0_pProdCod;
         this.AV19pTipLCod = aP1_pTipLCod;
         this.AV18pCliCod = aP2_pCliCod;
         this.AV17pPrecio = 0 ;
         initialize();
         executePrivate();
         aP0_pProdCod=this.AV20pProdCod;
         aP1_pTipLCod=this.AV19pTipLCod;
         aP2_pCliCod=this.AV18pCliCod;
         aP3_pPrecio=this.AV17pPrecio;
      }

      public decimal executeUdp( ref string aP0_pProdCod ,
                                 ref int aP1_pTipLCod ,
                                 ref string aP2_pCliCod )
      {
         execute(ref aP0_pProdCod, ref aP1_pTipLCod, ref aP2_pCliCod, out aP3_pPrecio);
         return AV17pPrecio ;
      }

      public void executeSubmit( ref string aP0_pProdCod ,
                                 ref int aP1_pTipLCod ,
                                 ref string aP2_pCliCod ,
                                 out decimal aP3_pPrecio )
      {
         rrbuscaprecios objrrbuscaprecios;
         objrrbuscaprecios = new rrbuscaprecios();
         objrrbuscaprecios.AV20pProdCod = aP0_pProdCod;
         objrrbuscaprecios.AV19pTipLCod = aP1_pTipLCod;
         objrrbuscaprecios.AV18pCliCod = aP2_pCliCod;
         objrrbuscaprecios.AV17pPrecio = 0 ;
         objrrbuscaprecios.context.SetSubmitInitialConfig(context);
         objrrbuscaprecios.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrrbuscaprecios);
         aP0_pProdCod=this.AV20pProdCod;
         aP1_pTipLCod=this.AV19pTipLCod;
         aP2_pCliCod=this.AV18pCliCod;
         aP3_pPrecio=this.AV17pPrecio;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rrbuscaprecios)stateInfo).executePrivate();
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
         AV17pPrecio = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV19pTipLCod ,
                                              A202TipLCod ,
                                              A45CliCod ,
                                              A28ProdCod ,
                                              AV20pProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DZ2 */
         pr_default.execute(0, new Object[] {AV20pProdCod, AV19pTipLCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ProdCod = P00DZ2_A28ProdCod[0];
            A45CliCod = P00DZ2_A45CliCod[0];
            n45CliCod = P00DZ2_n45CliCod[0];
            A202TipLCod = P00DZ2_A202TipLCod[0];
            A1681ProdCosto = P00DZ2_A1681ProdCosto[0];
            A1652PreLisCred = P00DZ2_A1652PreLisCred[0];
            A1651PreLis = P00DZ2_A1651PreLis[0];
            A1205LisFech = P00DZ2_A1205LisFech[0];
            A203TipLItem = P00DZ2_A203TipLItem[0];
            A1681ProdCosto = P00DZ2_A1681ProdCosto[0];
            AV15ProdCosto = A1681ProdCosto;
            AV16Porcentaje = A1652PreLisCred;
            AV17pPrecio = A1651PreLis;
            if ( ! (Convert.ToDecimal(0)==AV16Porcentaje) && (Convert.ToDecimal(0)==AV17pPrecio) )
            {
               AV17pPrecio = (!(Convert.ToDecimal(0)==AV15ProdCosto) ? AV15ProdCosto+NumberUtil.Round( (AV15ProdCosto*AV16Porcentaje)/ (decimal)(100), 2) : (decimal)(0));
               AV17pPrecio = NumberUtil.Round( AV17pPrecio, 1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV19pTipLCod ,
                                              A202TipLCod ,
                                              A45CliCod ,
                                              AV18pCliCod ,
                                              A28ProdCod ,
                                              AV20pProdCod } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00DZ3 */
         pr_default.execute(1, new Object[] {AV18pCliCod, AV20pProdCod, AV19pTipLCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A45CliCod = P00DZ3_A45CliCod[0];
            n45CliCod = P00DZ3_n45CliCod[0];
            A28ProdCod = P00DZ3_A28ProdCod[0];
            A202TipLCod = P00DZ3_A202TipLCod[0];
            A1681ProdCosto = P00DZ3_A1681ProdCosto[0];
            A1652PreLisCred = P00DZ3_A1652PreLisCred[0];
            A1651PreLis = P00DZ3_A1651PreLis[0];
            A1205LisFech = P00DZ3_A1205LisFech[0];
            A203TipLItem = P00DZ3_A203TipLItem[0];
            A1681ProdCosto = P00DZ3_A1681ProdCosto[0];
            AV15ProdCosto = A1681ProdCosto;
            AV16Porcentaje = A1652PreLisCred;
            AV17pPrecio = A1651PreLis;
            if ( ! (Convert.ToDecimal(0)==AV16Porcentaje) && (Convert.ToDecimal(0)==AV17pPrecio) )
            {
               AV17pPrecio = (!(Convert.ToDecimal(0)==AV15ProdCosto) ? AV15ProdCosto+NumberUtil.Round( (AV15ProdCosto*AV16Porcentaje)/ (decimal)(100), 2) : (decimal)(0));
               AV17pPrecio = NumberUtil.Round( AV17pPrecio, 1);
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
         context.CommitDataStores("generales.rrbuscaprecios",pr_default);
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
         P00DZ2_A28ProdCod = new string[] {""} ;
         P00DZ2_A45CliCod = new string[] {""} ;
         P00DZ2_n45CliCod = new bool[] {false} ;
         P00DZ2_A202TipLCod = new int[1] ;
         P00DZ2_A1681ProdCosto = new decimal[1] ;
         P00DZ2_A1652PreLisCred = new decimal[1] ;
         P00DZ2_A1651PreLis = new decimal[1] ;
         P00DZ2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P00DZ2_A203TipLItem = new int[1] ;
         A1205LisFech = DateTime.MinValue;
         P00DZ3_A45CliCod = new string[] {""} ;
         P00DZ3_n45CliCod = new bool[] {false} ;
         P00DZ3_A28ProdCod = new string[] {""} ;
         P00DZ3_A202TipLCod = new int[1] ;
         P00DZ3_A1681ProdCosto = new decimal[1] ;
         P00DZ3_A1652PreLisCred = new decimal[1] ;
         P00DZ3_A1651PreLis = new decimal[1] ;
         P00DZ3_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P00DZ3_A203TipLItem = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.generales.rrbuscaprecios__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.rrbuscaprecios__default(),
            new Object[][] {
                new Object[] {
               P00DZ2_A28ProdCod, P00DZ2_A45CliCod, P00DZ2_n45CliCod, P00DZ2_A202TipLCod, P00DZ2_A1681ProdCosto, P00DZ2_A1652PreLisCred, P00DZ2_A1651PreLis, P00DZ2_A1205LisFech, P00DZ2_A203TipLItem
               }
               , new Object[] {
               P00DZ3_A45CliCod, P00DZ3_n45CliCod, P00DZ3_A28ProdCod, P00DZ3_A202TipLCod, P00DZ3_A1681ProdCosto, P00DZ3_A1652PreLisCred, P00DZ3_A1651PreLis, P00DZ3_A1205LisFech, P00DZ3_A203TipLItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV19pTipLCod ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private decimal AV17pPrecio ;
      private decimal A1681ProdCosto ;
      private decimal A1652PreLisCred ;
      private decimal A1651PreLis ;
      private decimal AV15ProdCosto ;
      private decimal AV16Porcentaje ;
      private string AV20pProdCod ;
      private string AV18pCliCod ;
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
      private string[] P00DZ2_A28ProdCod ;
      private string[] P00DZ2_A45CliCod ;
      private bool[] P00DZ2_n45CliCod ;
      private int[] P00DZ2_A202TipLCod ;
      private decimal[] P00DZ2_A1681ProdCosto ;
      private decimal[] P00DZ2_A1652PreLisCred ;
      private decimal[] P00DZ2_A1651PreLis ;
      private DateTime[] P00DZ2_A1205LisFech ;
      private int[] P00DZ2_A203TipLItem ;
      private string[] P00DZ3_A45CliCod ;
      private bool[] P00DZ3_n45CliCod ;
      private string[] P00DZ3_A28ProdCod ;
      private int[] P00DZ3_A202TipLCod ;
      private decimal[] P00DZ3_A1681ProdCosto ;
      private decimal[] P00DZ3_A1652PreLisCred ;
      private decimal[] P00DZ3_A1651PreLis ;
      private DateTime[] P00DZ3_A1205LisFech ;
      private int[] P00DZ3_A203TipLItem ;
      private decimal aP3_pPrecio ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class rrbuscaprecios__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class rrbuscaprecios__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P00DZ2( IGxContext context ,
                                           int AV19pTipLCod ,
                                           int A202TipLCod ,
                                           string A45CliCod ,
                                           string A28ProdCod ,
                                           string AV20pProdCod )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int1 = new short[2];
       Object[] GXv_Object2 = new Object[2];
       scmdbuf = "SELECT T1.[ProdCod], T1.[CliCod], T1.[TipLCod], T2.[ProdCosto], T1.[PreLisCred], T1.[PreLis], T1.[LisFech], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod])";
       AddWhere(sWhereString, "((T1.[CliCod] = '') or T1.[CliCod] IS NULL)");
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV20pProdCod)");
       if ( ! ( AV19pTipLCod == 99 ) )
       {
          AddWhere(sWhereString, "(T1.[TipLCod] = @AV19pTipLCod)");
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

    protected Object[] conditional_P00DZ3( IGxContext context ,
                                           int AV19pTipLCod ,
                                           int A202TipLCod ,
                                           string A45CliCod ,
                                           string AV18pCliCod ,
                                           string A28ProdCod ,
                                           string AV20pProdCod )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[3];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT T1.[CliCod], T1.[ProdCod], T1.[TipLCod], T2.[ProdCosto], T1.[PreLisCred], T1.[PreLis], T1.[LisFech], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdCod])";
       AddWhere(sWhereString, "(T1.[CliCod] = @AV18pCliCod)");
       AddWhere(sWhereString, "(T1.[ProdCod] = @AV20pProdCod)");
       if ( ! ( AV19pTipLCod == 99 ) )
       {
          AddWhere(sWhereString, "(T1.[TipLCod] = @AV19pTipLCod)");
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
                   return conditional_P00DZ2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] );
             case 1 :
                   return conditional_P00DZ3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
        Object[] prmP00DZ2;
        prmP00DZ2 = new Object[] {
        new ParDef("@AV20pProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV19pTipLCod",GXType.Int32,6,0)
        };
        Object[] prmP00DZ3;
        prmP00DZ3 = new Object[] {
        new ParDef("@AV18pCliCod",GXType.NChar,20,0) ,
        new ParDef("@AV20pProdCod",GXType.NChar,15,0) ,
        new ParDef("@AV19pTipLCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00DZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DZ2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00DZ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DZ3,100, GxCacheFrequency.OFF ,false,false )
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
