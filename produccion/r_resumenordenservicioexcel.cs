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
namespace GeneXus.Programs.produccion {
   public class r_resumenordenservicioexcel : GXProcedure
   {
      public r_resumenordenservicioexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumenordenservicioexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ProdCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_ProSts ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV74ProdCod = aP0_ProdCod;
         this.AV76FDesde = aP1_FDesde;
         this.AV77FHasta = aP2_FHasta;
         this.AV75ProSts = aP3_ProSts;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_ProdCod=this.AV74ProdCod;
         aP1_FDesde=this.AV76FDesde;
         aP2_FHasta=this.AV77FHasta;
         aP3_ProSts=this.AV75ProSts;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref string aP0_ProdCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref string aP3_ProSts ,
                                out string aP4_Filename )
      {
         execute(ref aP0_ProdCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_ProSts, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref string aP0_ProdCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_ProSts ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumenordenservicioexcel objr_resumenordenservicioexcel;
         objr_resumenordenservicioexcel = new r_resumenordenservicioexcel();
         objr_resumenordenservicioexcel.AV74ProdCod = aP0_ProdCod;
         objr_resumenordenservicioexcel.AV76FDesde = aP1_FDesde;
         objr_resumenordenservicioexcel.AV77FHasta = aP2_FHasta;
         objr_resumenordenservicioexcel.AV75ProSts = aP3_ProSts;
         objr_resumenordenservicioexcel.AV10Filename = "" ;
         objr_resumenordenservicioexcel.AV11ErrorMessage = "" ;
         objr_resumenordenservicioexcel.context.SetSubmitInitialConfig(context);
         objr_resumenordenservicioexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumenordenservicioexcel);
         aP0_ProdCod=this.AV74ProdCod;
         aP1_FDesde=this.AV76FDesde;
         aP2_FHasta=this.AV77FHasta;
         aP3_ProSts=this.AV75ProSts;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumenordenservicioexcel)stateInfo).executePrivate();
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
         AV73Archivo.Source = "Excel/PlantillasResumenOServicios.xlsx";
         AV72Path = AV73Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV72Path) + "\\PlantillasResumenOServicios.xlsx";
         AV10Filename = "Excel/ResumenOServicios" + ".xlsx";
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
         AV14CellRow = 7;
         AV15FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV74ProdCod ,
                                              AV75ProSts ,
                                              A334PSerProdCod ,
                                              A1817PSerSts ,
                                              A1805PSerFec ,
                                              AV76FDesde ,
                                              AV77FHasta } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P00FE2 */
         pr_default.execute(0, new Object[] {AV76FDesde, AV77FHasta, AV74ProdCod, AV75ProSts});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1805PSerFec = P00FE2_A1805PSerFec[0];
            A1817PSerSts = P00FE2_A1817PSerSts[0];
            A334PSerProdCod = P00FE2_A334PSerProdCod[0];
            A336PSerDProdCod = P00FE2_A336PSerDProdCod[0];
            A1804PSerDProdDsc = P00FE2_A1804PSerDProdDsc[0];
            A1793PSerCantSer = P00FE2_A1793PSerCantSer[0];
            A1792PSerCantIng = P00FE2_A1792PSerCantIng[0];
            A1798PSerCostos = P00FE2_A1798PSerCostos[0];
            A1816PSerRef = P00FE2_A1816PSerRef[0];
            A329PSerCod = P00FE2_A329PSerCod[0];
            A335PSerDItem = P00FE2_A335PSerDItem[0];
            A1804PSerDProdDsc = P00FE2_A1804PSerDProdDsc[0];
            A1805PSerFec = P00FE2_A1805PSerFec[0];
            A1817PSerSts = P00FE2_A1817PSerSts[0];
            A334PSerProdCod = P00FE2_A334PSerProdCod[0];
            A1793PSerCantSer = P00FE2_A1793PSerCantSer[0];
            A1792PSerCantIng = P00FE2_A1792PSerCantIng[0];
            A1798PSerCostos = P00FE2_A1798PSerCostos[0];
            A1816PSerRef = P00FE2_A1816PSerRef[0];
            AV85PSerCod = A329PSerCod;
            AV89PSerFec = A1805PSerFec;
            AV86PSerDProdCod = A336PSerDProdCod;
            AV87PSerDProdDsc = A1804PSerDProdDsc;
            AV81ProCantProd = A1793PSerCantSer;
            AV82ProCantProdIng = A1792PSerCantIng;
            AV83Estado = ((StringUtil.StrCmp(A1817PSerSts, "T")==0) ? "TERMINADO" : "PENDIENTE");
            AV79CostoT = 0.00m;
            AV78TCosto = A1798PSerCostos;
            AV79CostoT = AV78TCosto;
            AV80CostoUnit = ((AV82ProCantProdIng==Convert.ToDecimal(0)) ? (decimal)(0) : NumberUtil.Round( AV78TCosto/ (decimal)(AV82ProCantProdIng), 4));
            AV84PSerRef = A1816PSerRef;
            AV88CliDsc = "";
            /* Execute user subroutine: 'CLIENTE' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'DETALLE' */
            S131 ();
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
         /* 'CLIENTE' Routine */
         returnInSub = false;
         /* Using cursor P00FE3 */
         pr_default.execute(1, new Object[] {AV84PSerRef});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A45CliCod = P00FE3_A45CliCod[0];
            A210PedCod = P00FE3_A210PedCod[0];
            A161CliDsc = P00FE3_A161CliDsc[0];
            A161CliDsc = P00FE3_A161CliDsc[0];
            AV88CliDsc = StringUtil.Trim( A161CliDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void S131( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV85PSerCod);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV89PSerFec ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV84PSerRef);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV88CliDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV86PSerDProdCod);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV87PSerDProdDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Number = (double)(AV81ProCantProd);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV82ProCantProdIng);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV80CostoUnit);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+9, 1, 1).Number = (double)(AV79CostoT);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+10, 1, 1).Text = AV83Estado;
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
         AV73Archivo = new GxFile(context.GetPhysicalPath());
         AV72Path = "";
         AV70FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A334PSerProdCod = "";
         A1817PSerSts = "";
         A1805PSerFec = DateTime.MinValue;
         P00FE2_A1805PSerFec = new DateTime[] {DateTime.MinValue} ;
         P00FE2_A1817PSerSts = new string[] {""} ;
         P00FE2_A334PSerProdCod = new string[] {""} ;
         P00FE2_A336PSerDProdCod = new string[] {""} ;
         P00FE2_A1804PSerDProdDsc = new string[] {""} ;
         P00FE2_A1793PSerCantSer = new decimal[1] ;
         P00FE2_A1792PSerCantIng = new decimal[1] ;
         P00FE2_A1798PSerCostos = new decimal[1] ;
         P00FE2_A1816PSerRef = new string[] {""} ;
         P00FE2_A329PSerCod = new string[] {""} ;
         P00FE2_A335PSerDItem = new int[1] ;
         A336PSerDProdCod = "";
         A1804PSerDProdDsc = "";
         A1816PSerRef = "";
         A329PSerCod = "";
         AV85PSerCod = "";
         AV89PSerFec = DateTime.MinValue;
         AV86PSerDProdCod = "";
         AV87PSerDProdDsc = "";
         AV83Estado = "";
         AV84PSerRef = "";
         AV88CliDsc = "";
         P00FE3_A45CliCod = new string[] {""} ;
         P00FE3_A210PedCod = new string[] {""} ;
         P00FE3_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A210PedCod = "";
         A161CliDsc = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.r_resumenordenservicioexcel__default(),
            new Object[][] {
                new Object[] {
               P00FE2_A1805PSerFec, P00FE2_A1817PSerSts, P00FE2_A334PSerProdCod, P00FE2_A336PSerDProdCod, P00FE2_A1804PSerDProdDsc, P00FE2_A1793PSerCantSer, P00FE2_A1792PSerCantIng, P00FE2_A1798PSerCostos, P00FE2_A1816PSerRef, P00FE2_A329PSerCod,
               P00FE2_A335PSerDItem
               }
               , new Object[] {
               P00FE3_A45CliCod, P00FE3_A210PedCod, P00FE3_A161CliDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A335PSerDItem ;
      private decimal A1793PSerCantSer ;
      private decimal A1792PSerCantIng ;
      private decimal A1798PSerCostos ;
      private decimal AV81ProCantProd ;
      private decimal AV82ProCantProdIng ;
      private decimal AV79CostoT ;
      private decimal AV78TCosto ;
      private decimal AV80CostoUnit ;
      private string AV74ProdCod ;
      private string AV75ProSts ;
      private string AV72Path ;
      private string scmdbuf ;
      private string A334PSerProdCod ;
      private string A1817PSerSts ;
      private string A336PSerDProdCod ;
      private string A1804PSerDProdDsc ;
      private string A1816PSerRef ;
      private string A329PSerCod ;
      private string AV85PSerCod ;
      private string AV86PSerDProdCod ;
      private string AV87PSerDProdDsc ;
      private string AV83Estado ;
      private string AV84PSerRef ;
      private string AV88CliDsc ;
      private string A45CliCod ;
      private string A210PedCod ;
      private string A161CliDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV76FDesde ;
      private DateTime AV77FHasta ;
      private DateTime A1805PSerFec ;
      private DateTime AV89PSerFec ;
      private bool returnInSub ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ProdCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_ProSts ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00FE2_A1805PSerFec ;
      private string[] P00FE2_A1817PSerSts ;
      private string[] P00FE2_A334PSerProdCod ;
      private string[] P00FE2_A336PSerDProdCod ;
      private string[] P00FE2_A1804PSerDProdDsc ;
      private decimal[] P00FE2_A1793PSerCantSer ;
      private decimal[] P00FE2_A1792PSerCantIng ;
      private decimal[] P00FE2_A1798PSerCostos ;
      private string[] P00FE2_A1816PSerRef ;
      private string[] P00FE2_A329PSerCod ;
      private int[] P00FE2_A335PSerDItem ;
      private string[] P00FE3_A45CliCod ;
      private string[] P00FE3_A210PedCod ;
      private string[] P00FE3_A161CliDsc ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV73Archivo ;
   }

   public class r_resumenordenservicioexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00FE2( IGxContext context ,
                                             string AV74ProdCod ,
                                             string AV75ProSts ,
                                             string A334PSerProdCod ,
                                             string A1817PSerSts ,
                                             DateTime A1805PSerFec ,
                                             DateTime AV76FDesde ,
                                             DateTime AV77FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[PSerFec], T3.[PSerSts], T3.[PSerProdCod], T1.[PSerDProdCod] AS PSerDProdCod, T2.[ProdDsc] AS PSerDProdDsc, T3.[PSerCantSer], T3.[PSerCantIng], T3.[PSerCostos], T3.[PSerRef], T1.[PSerCod], T1.[PSerDItem] FROM (([POSERVICIODET] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[PSerDProdCod]) INNER JOIN [POSERVICIO] T3 ON T3.[PSerCod] = T1.[PSerCod])";
         AddWhere(sWhereString, "(T3.[PSerFec] >= @AV76FDesde and T3.[PSerFec] <= @AV77FHasta)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74ProdCod)) )
         {
            AddWhere(sWhereString, "(T3.[PSerProdCod] = @AV74ProdCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75ProSts)) )
         {
            AddWhere(sWhereString, "(T3.[PSerSts] = @AV75ProSts)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PSerCod]";
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
                     return conditional_P00FE2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP00FE3;
          prmP00FE3 = new Object[] {
          new ParDef("@AV84PSerRef",GXType.NChar,10,0)
          };
          Object[] prmP00FE2;
          prmP00FE2 = new Object[] {
          new ParDef("@AV76FDesde",GXType.Date,8,0) ,
          new ParDef("@AV77FHasta",GXType.Date,8,0) ,
          new ParDef("@AV74ProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV75ProSts",GXType.NChar,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00FE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00FE3", "SELECT T1.[CliCod], T1.[PedCod], T2.[CliDsc] FROM ([CLPEDIDOS] T1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = T1.[CliCod]) WHERE T1.[PedCod] = @AV84PSerRef ORDER BY T1.[PedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FE3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 10);
                ((string[]) buf[9])[0] = rslt.getString(10, 10);
                ((int[]) buf[10])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
       }
    }

 }

}
