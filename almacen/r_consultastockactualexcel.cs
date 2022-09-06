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
   public class r_consultastockactualexcel : GXProcedure
   {
      public r_consultastockactualexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_consultastockactualexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_cProdCod ,
                           ref string aP1_cProdDsc ,
                           ref int aP2_cLinCod ,
                           ref int aP3_cSubLCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV98cProdCod = aP0_cProdCod;
         this.AV99cProdDsc = aP1_cProdDsc;
         this.AV100cLinCod = aP2_cLinCod;
         this.AV101cSubLCod = aP3_cSubLCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_cProdCod=this.AV98cProdCod;
         aP1_cProdDsc=this.AV99cProdDsc;
         aP2_cLinCod=this.AV100cLinCod;
         aP3_cSubLCod=this.AV101cSubLCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_cProdCod ,
                                ref string aP1_cProdDsc ,
                                ref int aP2_cLinCod ,
                                ref int aP3_cSubLCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_cProdCod, ref aP1_cProdDsc, ref aP2_cLinCod, ref aP3_cSubLCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_cProdCod ,
                                 ref string aP1_cProdDsc ,
                                 ref int aP2_cLinCod ,
                                 ref int aP3_cSubLCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_consultastockactualexcel objr_consultastockactualexcel;
         objr_consultastockactualexcel = new r_consultastockactualexcel();
         objr_consultastockactualexcel.AV98cProdCod = aP0_cProdCod;
         objr_consultastockactualexcel.AV99cProdDsc = aP1_cProdDsc;
         objr_consultastockactualexcel.AV100cLinCod = aP2_cLinCod;
         objr_consultastockactualexcel.AV101cSubLCod = aP3_cSubLCod;
         objr_consultastockactualexcel.AV10Filename = "" ;
         objr_consultastockactualexcel.AV11ErrorMessage = "" ;
         objr_consultastockactualexcel.context.SetSubmitInitialConfig(context);
         objr_consultastockactualexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_consultastockactualexcel);
         aP0_cProdCod=this.AV98cProdCod;
         aP1_cProdDsc=this.AV99cProdDsc;
         aP2_cLinCod=this.AV100cLinCod;
         aP3_cSubLCod=this.AV101cSubLCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_consultastockactualexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasConsultaStockActual.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasConsultaStockActual.xlsx";
         AV10Filename = "Excel/ConsultaStockActual" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 5;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A28ProdCod ,
                                              AV81Prodcod ,
                                              A55ProdDsc ,
                                              AV102ProdDsc ,
                                              A1880StkAct } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL
                                              }
         });
         lV81Prodcod = StringUtil.PadR( StringUtil.RTrim( AV81Prodcod), 15, "%");
         lV102ProdDsc = StringUtil.PadR( StringUtil.RTrim( AV102ProdDsc), 100, "%");
         /* Using cursor P00822 */
         pr_default.execute(0, new Object[] {lV81Prodcod, lV102ProdDsc, AV77LinCod, AV78SubLCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A63AlmCod = P00822_A63AlmCod[0];
            A49UniCod = P00822_A49UniCod[0];
            A51SublCod = P00822_A51SublCod[0];
            n51SublCod = P00822_n51SublCod[0];
            A52LinCod = P00822_A52LinCod[0];
            A1880StkAct = P00822_A1880StkAct[0];
            A55ProdDsc = P00822_A55ProdDsc[0];
            A28ProdCod = P00822_A28ProdCod[0];
            A1153LinDsc = P00822_A1153LinDsc[0];
            A1997UniAbr = P00822_A1997UniAbr[0];
            A436AlmDsc = P00822_A436AlmDsc[0];
            A1881StkIng = P00822_A1881StkIng[0];
            A1882StkSal = P00822_A1882StkSal[0];
            A436AlmDsc = P00822_A436AlmDsc[0];
            A49UniCod = P00822_A49UniCod[0];
            A51SublCod = P00822_A51SublCod[0];
            n51SublCod = P00822_n51SublCod[0];
            A52LinCod = P00822_A52LinCod[0];
            A55ProdDsc = P00822_A55ProdDsc[0];
            A1997UniAbr = P00822_A1997UniAbr[0];
            A1153LinDsc = P00822_A1153LinDsc[0];
            AV88AlmDsc = A436AlmDsc;
            AV89Codigo = A28ProdCod;
            AV90Producto = A55ProdDsc;
            AV96LinDsc = A1153LinDsc;
            AV78SubLCod = A51SublCod;
            AV97SubLDsc = "";
            AV91UniAbr = StringUtil.Trim( A1997UniAbr);
            AV87StkAct = A1880StkAct;
            GXt_decimal1 = AV94Precio;
            GXt_int2 = 99;
            GXt_char3 = "";
            new GeneXus.Programs.almacen.r_buscarprecios(context ).execute( ref  AV89Codigo, ref  GXt_int2, ref  GXt_char3, out  GXt_decimal1) ;
            AV94Precio = GXt_decimal1;
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV10Filename = "";
            AV11ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV13ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         if ( ! (0==AV78SubLCod) )
         {
            /* Using cursor P00823 */
            pr_default.execute(1, new Object[] {AV78SubLCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51SublCod = P00823_A51SublCod[0];
               n51SublCod = P00823_n51SublCod[0];
               A1892SublDsc = P00823_A1892SublDsc[0];
               AV97SubLDsc = StringUtil.Trim( A1892SublDsc);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV88AlmDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV89Codigo);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV90Producto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV96LinDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV97SubLDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV91UniAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV87StkAct);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV94Precio);
         AV14CellRow = (int)(AV14CellRow+1);
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
         AV10Filename = "";
         AV11ErrorMessage = "";
         AV72Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         lV81Prodcod = "";
         lV102ProdDsc = "";
         scmdbuf = "";
         A28ProdCod = "";
         AV81Prodcod = "";
         A55ProdDsc = "";
         AV102ProdDsc = "";
         P00822_A63AlmCod = new int[1] ;
         P00822_A49UniCod = new int[1] ;
         P00822_A51SublCod = new int[1] ;
         P00822_n51SublCod = new bool[] {false} ;
         P00822_A52LinCod = new int[1] ;
         P00822_A1880StkAct = new decimal[1] ;
         P00822_A55ProdDsc = new string[] {""} ;
         P00822_A28ProdCod = new string[] {""} ;
         P00822_A1153LinDsc = new string[] {""} ;
         P00822_A1997UniAbr = new string[] {""} ;
         P00822_A436AlmDsc = new string[] {""} ;
         P00822_A1881StkIng = new decimal[1] ;
         P00822_A1882StkSal = new decimal[1] ;
         A1153LinDsc = "";
         A1997UniAbr = "";
         A436AlmDsc = "";
         AV88AlmDsc = "";
         AV89Codigo = "";
         AV90Producto = "";
         AV96LinDsc = "";
         AV97SubLDsc = "";
         AV91UniAbr = "";
         GXt_char3 = "";
         P00823_A51SublCod = new int[1] ;
         P00823_n51SublCod = new bool[] {false} ;
         P00823_A1892SublDsc = new string[] {""} ;
         A1892SublDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_consultastockactualexcel__default(),
            new Object[][] {
                new Object[] {
               P00822_A63AlmCod, P00822_A49UniCod, P00822_A51SublCod, P00822_n51SublCod, P00822_A52LinCod, P00822_A1880StkAct, P00822_A55ProdDsc, P00822_A28ProdCod, P00822_A1153LinDsc, P00822_A1997UniAbr,
               P00822_A436AlmDsc, P00822_A1881StkIng, P00822_A1882StkSal
               }
               , new Object[] {
               P00823_A51SublCod, P00823_A1892SublDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV100cLinCod ;
      private int AV101cSubLCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int AV77LinCod ;
      private int AV78SubLCod ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A63AlmCod ;
      private int A49UniCod ;
      private int GXt_int2 ;
      private decimal A1880StkAct ;
      private decimal A1881StkIng ;
      private decimal A1882StkSal ;
      private decimal AV87StkAct ;
      private decimal AV94Precio ;
      private decimal GXt_decimal1 ;
      private string AV98cProdCod ;
      private string AV99cProdDsc ;
      private string AV71Path ;
      private string lV81Prodcod ;
      private string lV102ProdDsc ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string AV81Prodcod ;
      private string A55ProdDsc ;
      private string AV102ProdDsc ;
      private string A1153LinDsc ;
      private string A1997UniAbr ;
      private string A436AlmDsc ;
      private string AV88AlmDsc ;
      private string AV89Codigo ;
      private string AV90Producto ;
      private string AV96LinDsc ;
      private string AV97SubLDsc ;
      private string AV91UniAbr ;
      private string GXt_char3 ;
      private string A1892SublDsc ;
      private bool returnInSub ;
      private bool n51SublCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_cProdCod ;
      private string aP1_cProdDsc ;
      private int aP2_cLinCod ;
      private int aP3_cSubLCod ;
      private IDataStoreProvider pr_default ;
      private int[] P00822_A63AlmCod ;
      private int[] P00822_A49UniCod ;
      private int[] P00822_A51SublCod ;
      private bool[] P00822_n51SublCod ;
      private int[] P00822_A52LinCod ;
      private decimal[] P00822_A1880StkAct ;
      private string[] P00822_A55ProdDsc ;
      private string[] P00822_A28ProdCod ;
      private string[] P00822_A1153LinDsc ;
      private string[] P00822_A1997UniAbr ;
      private string[] P00822_A436AlmDsc ;
      private decimal[] P00822_A1881StkIng ;
      private decimal[] P00822_A1882StkSal ;
      private int[] P00823_A51SublCod ;
      private bool[] P00823_n51SublCod ;
      private string[] P00823_A1892SublDsc ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_consultastockactualexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00822( IGxContext context ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             string A28ProdCod ,
                                             string AV81Prodcod ,
                                             string A55ProdDsc ,
                                             string AV102ProdDsc ,
                                             decimal A1880StkAct )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[AlmCod], T3.[UniCod], T3.[SublCod], T3.[LinCod], T1.[StkIng] - T1.[StkSal] AS StkAct, T3.[ProdDsc], T1.[ProdCod], T5.[LinDsc], T4.[UniAbr], T2.[AlmDsc], T1.[StkIng], T1.[StkSal] FROM (((([ASTOCKACTUAL] T1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = T1.[AlmCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T1.[ProdCod] like '%' + RTRIM(LTRIM(@lV81Prodcod)) + '%')");
         AddWhere(sWhereString, "(T3.[ProdDsc] like '%' + RTRIM(LTRIM(@lV102ProdDsc)) + '%')");
         AddWhere(sWhereString, "(Not (T1.[StkIng] - T1.[StkSal] = convert(int, 0)))");
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[AlmDsc], T1.[ProdCod]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00822(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] );
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
          Object[] prmP00823;
          prmP00823 = new Object[] {
          new ParDef("@AV78SubLCod",GXType.Int32,6,0)
          };
          Object[] prmP00822;
          prmP00822 = new Object[] {
          new ParDef("@lV81Prodcod",GXType.NChar,15,0) ,
          new ParDef("@lV102ProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00822", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00822,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00823", "SELECT [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV78SubLCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00823,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 15);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((string[]) buf[10])[0] = rslt.getString(10, 100);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
