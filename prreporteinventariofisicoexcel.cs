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
namespace GeneXus.Programs {
   public class prreporteinventariofisicoexcel : GXProcedure
   {
      public prreporteinventariofisicoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public prreporteinventariofisicoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV77LinCod = aP0_LinCod;
         this.AV78SubLCod = aP1_SubLCod;
         this.AV79FamCod = aP2_FamCod;
         this.AV80AlmCod = aP3_AlmCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_LinCod ,
                                ref int aP1_SubLCod ,
                                ref int aP2_FamCod ,
                                ref int aP3_AlmCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         prreporteinventariofisicoexcel objprreporteinventariofisicoexcel;
         objprreporteinventariofisicoexcel = new prreporteinventariofisicoexcel();
         objprreporteinventariofisicoexcel.AV77LinCod = aP0_LinCod;
         objprreporteinventariofisicoexcel.AV78SubLCod = aP1_SubLCod;
         objprreporteinventariofisicoexcel.AV79FamCod = aP2_FamCod;
         objprreporteinventariofisicoexcel.AV80AlmCod = aP3_AlmCod;
         objprreporteinventariofisicoexcel.AV10Filename = "" ;
         objprreporteinventariofisicoexcel.AV11ErrorMessage = "" ;
         objprreporteinventariofisicoexcel.context.SetSubmitInitialConfig(context);
         objprreporteinventariofisicoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprreporteinventariofisicoexcel);
         aP0_LinCod=this.AV77LinCod;
         aP1_SubLCod=this.AV78SubLCod;
         aP2_FamCod=this.AV79FamCod;
         aP3_AlmCod=this.AV80AlmCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((prreporteinventariofisicoexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasInventarioFisico.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasInventarioFisico.xlsx";
         AV10Filename = "Excel/InventarioFisico" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         AV115Fecha = DateTimeUtil.Today( context);
         AV114MVAlm = AV80AlmCod;
         if ( (0==AV80AlmCod) )
         {
            AV80AlmCod = 99;
         }
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV77LinCod ,
                                              AV78SubLCod ,
                                              AV79FamCod ,
                                              AV80AlmCod ,
                                              A52LinCod ,
                                              A51SublCod ,
                                              A50FamCod ,
                                              A21MvAlm ,
                                              A1158LinStk ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008L2 */
         pr_default.execute(0, new Object[] {AV77LinCod, AV78SubLCod, AV79FamCod, AV80AlmCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8L2 = false;
            A13MvATip = P008L2_A13MvATip[0];
            A14MvACod = P008L2_A14MvACod[0];
            A49UniCod = P008L2_A49UniCod[0];
            A55ProdDsc = P008L2_A55ProdDsc[0];
            A28ProdCod = P008L2_A28ProdCod[0];
            A1718ProdSts = P008L2_A1718ProdSts[0];
            A1158LinStk = P008L2_A1158LinStk[0];
            A21MvAlm = P008L2_A21MvAlm[0];
            A50FamCod = P008L2_A50FamCod[0];
            n50FamCod = P008L2_n50FamCod[0];
            A51SublCod = P008L2_A51SublCod[0];
            n51SublCod = P008L2_n51SublCod[0];
            A52LinCod = P008L2_A52LinCod[0];
            A1674ProdBarra = P008L2_A1674ProdBarra[0];
            A1717ProdStkMin = P008L2_A1717ProdStkMin[0];
            A1716ProdStkMax = P008L2_A1716ProdStkMax[0];
            A1997UniAbr = P008L2_A1997UniAbr[0];
            A30MvADItem = P008L2_A30MvADItem[0];
            A21MvAlm = P008L2_A21MvAlm[0];
            A49UniCod = P008L2_A49UniCod[0];
            A55ProdDsc = P008L2_A55ProdDsc[0];
            A1718ProdSts = P008L2_A1718ProdSts[0];
            A50FamCod = P008L2_A50FamCod[0];
            n50FamCod = P008L2_n50FamCod[0];
            A51SublCod = P008L2_A51SublCod[0];
            n51SublCod = P008L2_n51SublCod[0];
            A52LinCod = P008L2_A52LinCod[0];
            A1674ProdBarra = P008L2_A1674ProdBarra[0];
            A1717ProdStkMin = P008L2_A1717ProdStkMin[0];
            A1716ProdStkMax = P008L2_A1716ProdStkMax[0];
            A1997UniAbr = P008L2_A1997UniAbr[0];
            A1158LinStk = P008L2_A1158LinStk[0];
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008L2_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK8L2 = false;
               A13MvATip = P008L2_A13MvATip[0];
               A14MvACod = P008L2_A14MvACod[0];
               A55ProdDsc = P008L2_A55ProdDsc[0];
               A30MvADItem = P008L2_A30MvADItem[0];
               A55ProdDsc = P008L2_A55ProdDsc[0];
               BRK8L2 = true;
               pr_default.readNext(0);
            }
            AV81Prodcod = A28ProdCod;
            AV95ProdDsc = StringUtil.Trim( A55ProdDsc);
            AV119ProdBarra = A1674ProdBarra;
            AV120ProdStkMin = A1717ProdStkMin;
            AV121ProdStkMax = A1716ProdStkMax;
            AV113UniAbr = StringUtil.Trim( A1997UniAbr);
            GXt_decimal1 = AV87StkAct;
            new GeneXus.Programs.generales.pbuscastock(context ).execute(  AV80AlmCod,  AV81Prodcod, out  GXt_decimal1) ;
            AV87StkAct = GXt_decimal1;
            GXt_decimal1 = AV112CostoU;
            new GeneXus.Programs.produccion.pobtenerultimocostoingresado(context ).execute( ref  AV114MVAlm, ref  AV81Prodcod, ref  AV115Fecha, out  GXt_decimal1) ;
            AV112CostoU = GXt_decimal1;
            AV118CostoT = NumberUtil.Round( AV112CostoU*AV87StkAct, 2);
            AV117StkFisico = 0.0000m;
            /* Execute user subroutine: 'DETALLE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV84ITemProd = (long)(AV84ITemProd+1);
            if ( ! BRK8L2 )
            {
               BRK8L2 = true;
               pr_default.readNext(0);
            }
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
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Number = AV84ITemProd;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV81Prodcod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV119ProdBarra);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV95ProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV113UniAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Number = (double)(AV87StkAct);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV120ProdStkMin);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV121ProdStkMax);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Number = (double)(AV112CostoU);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+11, 1, 1).Number = (double)(AV118CostoT);
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
         AV115Fecha = DateTime.MinValue;
         scmdbuf = "";
         P008L2_A13MvATip = new string[] {""} ;
         P008L2_A14MvACod = new string[] {""} ;
         P008L2_A49UniCod = new int[1] ;
         P008L2_A55ProdDsc = new string[] {""} ;
         P008L2_A28ProdCod = new string[] {""} ;
         P008L2_A1718ProdSts = new short[1] ;
         P008L2_A1158LinStk = new short[1] ;
         P008L2_A21MvAlm = new int[1] ;
         P008L2_A50FamCod = new int[1] ;
         P008L2_n50FamCod = new bool[] {false} ;
         P008L2_A51SublCod = new int[1] ;
         P008L2_n51SublCod = new bool[] {false} ;
         P008L2_A52LinCod = new int[1] ;
         P008L2_A1674ProdBarra = new string[] {""} ;
         P008L2_A1717ProdStkMin = new decimal[1] ;
         P008L2_A1716ProdStkMax = new decimal[1] ;
         P008L2_A1997UniAbr = new string[] {""} ;
         P008L2_A30MvADItem = new int[1] ;
         A13MvATip = "";
         A14MvACod = "";
         A55ProdDsc = "";
         A28ProdCod = "";
         A1674ProdBarra = "";
         A1997UniAbr = "";
         AV81Prodcod = "";
         AV95ProdDsc = "";
         AV119ProdBarra = "";
         AV113UniAbr = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.prreporteinventariofisicoexcel__default(),
            new Object[][] {
                new Object[] {
               P008L2_A13MvATip, P008L2_A14MvACod, P008L2_A49UniCod, P008L2_A55ProdDsc, P008L2_A28ProdCod, P008L2_A1718ProdSts, P008L2_A1158LinStk, P008L2_A21MvAlm, P008L2_A50FamCod, P008L2_n50FamCod,
               P008L2_A51SublCod, P008L2_n51SublCod, P008L2_A52LinCod, P008L2_A1674ProdBarra, P008L2_A1717ProdStkMin, P008L2_A1716ProdStkMax, P008L2_A1997UniAbr, P008L2_A30MvADItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1158LinStk ;
      private short A1718ProdSts ;
      private int AV77LinCod ;
      private int AV78SubLCod ;
      private int AV79FamCod ;
      private int AV80AlmCod ;
      private int AV114MVAlm ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A52LinCod ;
      private int A51SublCod ;
      private int A50FamCod ;
      private int A21MvAlm ;
      private int A49UniCod ;
      private int A30MvADItem ;
      private long AV84ITemProd ;
      private decimal A1717ProdStkMin ;
      private decimal A1716ProdStkMax ;
      private decimal AV120ProdStkMin ;
      private decimal AV121ProdStkMax ;
      private decimal AV87StkAct ;
      private decimal AV112CostoU ;
      private decimal GXt_decimal1 ;
      private decimal AV118CostoT ;
      private decimal AV117StkFisico ;
      private string AV71Path ;
      private string scmdbuf ;
      private string A13MvATip ;
      private string A14MvACod ;
      private string A55ProdDsc ;
      private string A28ProdCod ;
      private string A1997UniAbr ;
      private string AV81Prodcod ;
      private string AV95ProdDsc ;
      private string AV113UniAbr ;
      private DateTime AV115Fecha ;
      private bool returnInSub ;
      private bool BRK8L2 ;
      private bool n50FamCod ;
      private bool n51SublCod ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private string A1674ProdBarra ;
      private string AV119ProdBarra ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private IDataStoreProvider pr_default ;
      private string[] P008L2_A13MvATip ;
      private string[] P008L2_A14MvACod ;
      private int[] P008L2_A49UniCod ;
      private string[] P008L2_A55ProdDsc ;
      private string[] P008L2_A28ProdCod ;
      private short[] P008L2_A1718ProdSts ;
      private short[] P008L2_A1158LinStk ;
      private int[] P008L2_A21MvAlm ;
      private int[] P008L2_A50FamCod ;
      private bool[] P008L2_n50FamCod ;
      private int[] P008L2_A51SublCod ;
      private bool[] P008L2_n51SublCod ;
      private int[] P008L2_A52LinCod ;
      private string[] P008L2_A1674ProdBarra ;
      private decimal[] P008L2_A1717ProdStkMin ;
      private decimal[] P008L2_A1716ProdStkMax ;
      private string[] P008L2_A1997UniAbr ;
      private int[] P008L2_A30MvADItem ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class prreporteinventariofisicoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008L2( IGxContext context ,
                                             int AV77LinCod ,
                                             int AV78SubLCod ,
                                             int AV79FamCod ,
                                             int AV80AlmCod ,
                                             int A52LinCod ,
                                             int A51SublCod ,
                                             int A50FamCod ,
                                             int A21MvAlm ,
                                             short A1158LinStk ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MvATip], T1.[MvACod], T3.[UniCod], T3.[ProdDsc], T1.[ProdCod], T3.[ProdSts], T5.[LinStk], T2.[MvAlm], T3.[FamCod], T3.[SublCod], T3.[LinCod], T3.[ProdBarra], T3.[ProdStkMin], T3.[ProdStkMax], T4.[UniAbr], T1.[MvADItem] FROM (((([AGUIASDET] T1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = T1.[MvATip] AND T2.[MvACod] = T1.[MvACod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = T1.[ProdCod]) INNER JOIN [CUNIDADMEDIDA] T4 ON T4.[UniCod] = T3.[UniCod]) INNER JOIN [CLINEAPROD] T5 ON T5.[LinCod] = T3.[LinCod])";
         AddWhere(sWhereString, "(T5.[LinStk] = 1)");
         AddWhere(sWhereString, "(T3.[ProdSts] = 1)");
         if ( ! (0==AV77LinCod) )
         {
            AddWhere(sWhereString, "(T3.[LinCod] = @AV77LinCod)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV78SubLCod) )
         {
            AddWhere(sWhereString, "(T3.[SublCod] = @AV78SubLCod)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV79FamCod) )
         {
            AddWhere(sWhereString, "(T3.[FamCod] = @AV79FamCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! ( AV80AlmCod == 99 ) )
         {
            AddWhere(sWhereString, "(T2.[MvAlm] = @AV80AlmCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod], T3.[ProdDsc]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008L2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] );
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
          Object[] prmP008L2;
          prmP008L2 = new Object[] {
          new ParDef("@AV77LinCod",GXType.Int32,6,0) ,
          new ParDef("@AV78SubLCod",GXType.Int32,6,0) ,
          new ParDef("@AV79FamCod",GXType.Int32,6,0) ,
          new ParDef("@AV80AlmCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008L2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((int[]) buf[7])[0] = rslt.getInt(8);
                ((int[]) buf[8])[0] = rslt.getInt(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((int[]) buf[10])[0] = rslt.getInt(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(13);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 5);
                ((int[]) buf[17])[0] = rslt.getInt(16);
                return;
       }
    }

 }

}
