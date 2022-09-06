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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.almacen {
   public class r_stockminimoexcel : GXProcedure
   {
      public r_stockminimoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_stockminimoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref string aP2_Prodcod ,
                           ref int aP3_AlmCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV21LinCod = aP0_LinCod;
         this.AV29SubLCod = aP1_SubLCod;
         this.AV23Prodcod = aP2_Prodcod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV17Filename = "" ;
         this.AV15ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV21LinCod;
         aP1_SubLCod=this.AV29SubLCod;
         aP2_Prodcod=this.AV23Prodcod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Filename=this.AV17Filename;
         aP5_ErrorMessage=this.AV15ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref string aP2_Prodcod ,
                                ref int aP3_AlmCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_Prodcod, ref aP3_AlmCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV15ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref string aP2_Prodcod ,
                                 ref int aP3_AlmCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_stockminimoexcel objr_stockminimoexcel;
         objr_stockminimoexcel = new r_stockminimoexcel();
         objr_stockminimoexcel.AV21LinCod = aP0_LinCod;
         objr_stockminimoexcel.AV29SubLCod = aP1_SubLCod;
         objr_stockminimoexcel.AV23Prodcod = aP2_Prodcod;
         objr_stockminimoexcel.AV9AlmCod = aP3_AlmCod;
         objr_stockminimoexcel.AV17Filename = "" ;
         objr_stockminimoexcel.AV15ErrorMessage = "" ;
         objr_stockminimoexcel.context.SetSubmitInitialConfig(context);
         objr_stockminimoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_stockminimoexcel);
         aP0_LinCod=this.AV21LinCod;
         aP1_SubLCod=this.AV29SubLCod;
         aP2_Prodcod=this.AV23Prodcod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Filename=this.AV17Filename;
         aP5_ErrorMessage=this.AV15ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_stockminimoexcel)stateInfo).executePrivate();
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
         AV11Archivo.Source = "Excel/PlantillasStockMinimo.xlsx";
         AV22Path = AV11Archivo.GetPath();
         AV18FilenameOrigen = StringUtil.Trim( AV22Path) + "\\PlantillasStockMinimo.xlsx";
         AV17Filename = "Excel/StockMinimo" + ".xlsx";
         AV16ExcelDocument.Clear();
         AV16ExcelDocument.Template = AV18FilenameOrigen;
         AV16ExcelDocument.Open(AV17Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV20ITemProd = 1;
         AV12CellRow = 5;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV21LinCod ,
                                              AV29SubLCod ,
                                              AV23Prodcod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A28ProdCod ,
                                              A1717ProdStkMin ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008R2 */
         pr_default.execute(0, new Object[] {AV21LinCod, AV29SubLCod, AV23Prodcod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1718ProdSts = P008R2_A1718ProdSts[0];
            A1717ProdStkMin = P008R2_A1717ProdStkMin[0];
            A28ProdCod = P008R2_A28ProdCod[0];
            A51SublCod = P008R2_A51SublCod[0];
            n51SublCod = P008R2_n51SublCod[0];
            A52LinCod = P008R2_A52LinCod[0];
            A55ProdDsc = P008R2_A55ProdDsc[0];
            A1716ProdStkMax = P008R2_A1716ProdStkMax[0];
            AV13Codigo = A28ProdCod;
            AV24Producto = A55ProdDsc;
            AV28StkMin = A1717ProdStkMin;
            AV27StkMax = A1716ProdStkMax;
            AV25StkAct = 0.00m;
            AV19Flag = 0;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV9AlmCod ,
                                                 A63AlmCod ,
                                                 A1880StkAct ,
                                                 A28ProdCod ,
                                                 AV13Codigo } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL
                                                 }
            });
            /* Using cursor P008R3 */
            pr_default.execute(1, new Object[] {AV13Codigo, AV9AlmCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1880StkAct = P008R3_A1880StkAct[0];
               A28ProdCod = P008R3_A28ProdCod[0];
               A63AlmCod = P008R3_A63AlmCod[0];
               A436AlmDsc = P008R3_A436AlmDsc[0];
               A1881StkIng = P008R3_A1881StkIng[0];
               A1882StkSal = P008R3_A1882StkSal[0];
               A436AlmDsc = P008R3_A436AlmDsc[0];
               AV8Almacen = A436AlmDsc;
               AV25StkAct = A1880StkAct;
               if ( AV25StkAct < AV28StkMin )
               {
                  if ( ( AV27StkMax > Convert.ToDecimal( 0 )) )
                  {
                     AV14Diferencia = (decimal)(AV27StkMax-AV25StkAct);
                  }
                  else
                  {
                     AV14Diferencia = (decimal)(AV28StkMin-AV25StkAct);
                  }
                  /* Execute user subroutine: 'DETALLE' */
                  S121 ();
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     this.cleanup();
                     if (true) return;
                  }
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV20ITemProd = (long)(+1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV16ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV16ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV16ExcelDocument.ErrCode != 0 )
         {
            AV17Filename = "";
            AV15ErrorMessage = AV16ExcelDocument.ErrDescription;
            AV16ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV16ExcelDocument.get_Cells(AV12CellRow, 1, 1, 1).Number = AV20ITemProd;
         AV16ExcelDocument.get_Cells(AV12CellRow, 2, 1, 1).Text = StringUtil.Trim( AV13Codigo);
         AV16ExcelDocument.get_Cells(AV12CellRow, 3, 1, 1).Text = StringUtil.Trim( AV24Producto);
         AV16ExcelDocument.get_Cells(AV12CellRow, 4, 1, 1).Text = StringUtil.Trim( AV30UniAbr);
         AV16ExcelDocument.get_Cells(AV12CellRow, 5, 1, 1).Number = (double)(AV28StkMin);
         AV16ExcelDocument.get_Cells(AV12CellRow, 6, 1, 1).Number = (double)(AV25StkAct);
         AV16ExcelDocument.get_Cells(AV12CellRow, 7, 1, 1).Number = (double)(AV27StkMax);
         AV16ExcelDocument.get_Cells(AV12CellRow, 8, 1, 1).Number = (double)(AV14Diferencia);
         AV16ExcelDocument.get_Cells(AV12CellRow, 9, 1, 1).Text = StringUtil.Trim( AV10AlmDsc);
         AV12CellRow = (int)(AV12CellRow+1);
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
         AV17Filename = "";
         AV15ErrorMessage = "";
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV22Path = "";
         AV18FilenameOrigen = "";
         AV16ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A28ProdCod = "";
         P008R2_A1718ProdSts = new short[1] ;
         P008R2_A1717ProdStkMin = new decimal[1] ;
         P008R2_A28ProdCod = new string[] {""} ;
         P008R2_A51SublCod = new int[1] ;
         P008R2_n51SublCod = new bool[] {false} ;
         P008R2_A52LinCod = new int[1] ;
         P008R2_A55ProdDsc = new string[] {""} ;
         P008R2_A1716ProdStkMax = new decimal[1] ;
         A55ProdDsc = "";
         AV13Codigo = "";
         AV24Producto = "";
         P008R3_A1880StkAct = new decimal[1] ;
         P008R3_A28ProdCod = new string[] {""} ;
         P008R3_A63AlmCod = new int[1] ;
         P008R3_A436AlmDsc = new string[] {""} ;
         P008R3_A1881StkIng = new decimal[1] ;
         P008R3_A1882StkSal = new decimal[1] ;
         A436AlmDsc = "";
         AV8Almacen = "";
         AV30UniAbr = "";
         AV10AlmDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_stockminimoexcel__default(),
            new Object[][] {
                new Object[] {
               P008R2_A1718ProdSts, P008R2_A1717ProdStkMin, P008R2_A28ProdCod, P008R2_A51SublCod, P008R2_n51SublCod, P008R2_A52LinCod, P008R2_A55ProdDsc, P008R2_A1716ProdStkMax
               }
               , new Object[] {
               P008R3_A1880StkAct, P008R3_A28ProdCod, P008R3_A63AlmCod, P008R3_A436AlmDsc, P008R3_A1881StkIng, P008R3_A1882StkSal
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1718ProdSts ;
      private short AV19Flag ;
      private int AV21LinCod ;
      private int AV29SubLCod ;
      private int AV9AlmCod ;
      private int AV12CellRow ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A63AlmCod ;
      private long AV20ITemProd ;
      private decimal A1717ProdStkMin ;
      private decimal A1716ProdStkMax ;
      private decimal AV28StkMin ;
      private decimal AV27StkMax ;
      private decimal AV25StkAct ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV14Diferencia ;
      private string AV23Prodcod ;
      private string AV22Path ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string AV13Codigo ;
      private string AV24Producto ;
      private string A436AlmDsc ;
      private string AV30UniAbr ;
      private string AV10AlmDsc ;
      private bool returnInSub ;
      private bool n51SublCod ;
      private string AV17Filename ;
      private string AV15ErrorMessage ;
      private string AV18FilenameOrigen ;
      private string AV8Almacen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private string aP2_Prodcod ;
      private int aP3_AlmCod ;
      private IDataStoreProvider pr_default ;
      private short[] P008R2_A1718ProdSts ;
      private decimal[] P008R2_A1717ProdStkMin ;
      private string[] P008R2_A28ProdCod ;
      private int[] P008R2_A51SublCod ;
      private bool[] P008R2_n51SublCod ;
      private int[] P008R2_A52LinCod ;
      private string[] P008R2_A55ProdDsc ;
      private decimal[] P008R2_A1716ProdStkMax ;
      private decimal[] P008R3_A1880StkAct ;
      private string[] P008R3_A28ProdCod ;
      private int[] P008R3_A63AlmCod ;
      private string[] P008R3_A436AlmDsc ;
      private decimal[] P008R3_A1881StkIng ;
      private decimal[] P008R3_A1882StkSal ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV16ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class r_stockminimoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008R2( IGxContext context ,
                                             int AV21LinCod ,
                                             int AV29SubLCod ,
                                             string AV23Prodcod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A28ProdCod ,
                                             decimal A1717ProdStkMin ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ProdSts], [ProdStkMin], [ProdCod], [SublCod], [LinCod], [ProdDsc], [ProdStkMax] FROM [APRODUCTOS]";
         AddWhere(sWhereString, "([ProdStkMin] > 0)");
         AddWhere(sWhereString, "([ProdSts] = 1)");
         if ( ! (0==AV21LinCod) )
         {
            AddWhere(sWhereString, "([LinCod] = @AV21LinCod)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV29SubLCod) )
         {
            AddWhere(sWhereString, "([SublCod] = @AV29SubLCod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23Prodcod)) )
         {
            AddWhere(sWhereString, "([ProdCod] = @AV23Prodcod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008R3( IGxContext context ,
                                             int AV9AlmCod ,
                                             int A63AlmCod ,
                                             decimal A1880StkAct ,
                                             string A28ProdCod ,
                                             string AV13Codigo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[StkIng] - T1.[StkSal] AS StkAct, T1.[ProdCod], T1.[AlmCod], T2.[AlmDsc], T1.[StkIng], T1.[StkSal] FROM ([ASTOCKACTUAL] T1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = T1.[AlmCod])";
         AddWhere(sWhereString, "(Not (T1.[StkIng] - T1.[StkSal] = convert(int, 0)))");
         AddWhere(sWhereString, "(T1.[ProdCod] = @AV13Codigo)");
         if ( ! (0==AV9AlmCod) )
         {
            AddWhere(sWhereString, "(T1.[AlmCod] = @AV9AlmCod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AlmCod], T1.[ProdCod]";
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
                     return conditional_P008R2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (short)dynConstraints[7] );
               case 1 :
                     return conditional_P008R3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (decimal)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] );
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
          Object[] prmP008R2;
          prmP008R2 = new Object[] {
          new ParDef("@AV21LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV29SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV23Prodcod",GXType.NChar,15,0)
          };
          Object[] prmP008R3;
          prmP008R3 = new Object[] {
          new ParDef("@AV13Codigo",GXType.NChar,15,0) ,
          new ParDef("@AV9AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008R3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
       }
    }

 }

}
