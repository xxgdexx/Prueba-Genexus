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
namespace GeneXus.Programs.contabilidad {
   public class p_reportecostocentrocostoexcel : GXProcedure
   {
      public p_reportecostocentrocostoexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public p_reportecostocentrocostoexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_CosCod ,
                           ref int aP3_MonCod ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV9Mes = aP1_Mes;
         this.AV61CosCod = aP2_CosCod;
         this.AV42MonCod = aP3_MonCod;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_CosCod=this.AV61CosCod;
         aP3_MonCod=this.AV42MonCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_CosCod ,
                                ref int aP3_MonCod ,
                                out string aP4_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_CosCod, ref aP3_MonCod, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_CosCod ,
                                 ref int aP3_MonCod ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         p_reportecostocentrocostoexcel objp_reportecostocentrocostoexcel;
         objp_reportecostocentrocostoexcel = new p_reportecostocentrocostoexcel();
         objp_reportecostocentrocostoexcel.AV8Ano = aP0_Ano;
         objp_reportecostocentrocostoexcel.AV9Mes = aP1_Mes;
         objp_reportecostocentrocostoexcel.AV61CosCod = aP2_CosCod;
         objp_reportecostocentrocostoexcel.AV42MonCod = aP3_MonCod;
         objp_reportecostocentrocostoexcel.AV10Filename = "" ;
         objp_reportecostocentrocostoexcel.AV11ErrorMessage = "" ;
         objp_reportecostocentrocostoexcel.context.SetSubmitInitialConfig(context);
         objp_reportecostocentrocostoexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objp_reportecostocentrocostoexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV9Mes;
         aP2_CosCod=this.AV61CosCod;
         aP3_MonCod=this.AV42MonCod;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((p_reportecostocentrocostoexcel)stateInfo).executePrivate();
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
         AV37Archivo.Source = "Excel/PlantillasResumenCostoCC.xlsx";
         AV38Path = AV37Archivo.GetPath();
         AV41FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasResumenCostoCC.xlsx";
         AV10Filename = "Excel/ResumenCostoCC" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV41FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 3;
         AV15FirstColumn = 1;
         AV44Titulo = "";
         AV68TotTipo = "RCC";
         /* Using cursor P00BS2 */
         pr_default.execute(0, new Object[] {AV61CosCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A79COSCod = P00BS2_A79COSCod[0];
            A761COSDsc = P00BS2_A761COSDsc[0];
            AV44Titulo = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV44Titulo);
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         AV73ImpTot = 0;
         AV65ImpRub = 0;
         AV62TotIng = 0;
         AV63TotEgr = 0;
         /* Using cursor P00BS3 */
         pr_default.execute(1, new Object[] {AV68TotTipo});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A114TotTipo = P00BS3_A114TotTipo[0];
            A115TotRub = P00BS3_A115TotRub[0];
            A1928TotDsc = P00BS3_A1928TotDsc[0];
            A120TotOrd = P00BS3_A120TotOrd[0];
            AV67TotRub = A115TotRub;
            AV70TotDsc = A1928TotDsc;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1928TotDsc)) )
            {
               /* Execute user subroutine: 'RUBROSTOTAL' */
               S121 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Using cursor P00BS4 */
            pr_default.execute(2, new Object[] {AV68TotTipo, AV67TotRub});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A115TotRub = P00BS4_A115TotRub[0];
               A114TotTipo = P00BS4_A114TotTipo[0];
               A1829RubSts = P00BS4_A1829RubSts[0];
               A116RubCod = P00BS4_A116RubCod[0];
               A1822RubDsc = P00BS4_A1822RubDsc[0];
               A1823RubDscTot = P00BS4_A1823RubDscTot[0];
               A117RubOrd = P00BS4_A117RubOrd[0];
               AV69RubCod = A116RubCod;
               AV65ImpRub = 0;
               AV71RubDsc = A1822RubDsc;
               AV75RubDscTot = A1823RubDscTot;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1822RubDsc)) )
               {
                  /* Execute user subroutine: 'RUBROS' */
                  S131 ();
                  if ( returnInSub )
                  {
                     pr_default.close(2);
                     this.cleanup();
                     if (true) return;
                  }
               }
               /* Using cursor P00BS5 */
               pr_default.execute(3, new Object[] {AV68TotTipo, AV67TotRub, AV69RubCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A116RubCod = P00BS5_A116RubCod[0];
                  A115TotRub = P00BS5_A115TotRub[0];
                  A114TotTipo = P00BS5_A114TotTipo[0];
                  A118RubLinCod = P00BS5_A118RubLinCod[0];
                  A1826RubLinDsc = P00BS5_A1826RubLinDsc[0];
                  A119RubLinOrd = P00BS5_A119RubLinOrd[0];
                  AV68TotTipo = A114TotTipo;
                  AV67TotRub = A115TotRub;
                  AV69RubCod = A116RubCod;
                  AV72RubLinCod = A118RubLinCod;
                  AV74RubLinDsc = A1826RubLinDsc;
                  GXt_decimal1 = AV66ImpBal;
                  new GeneXus.Programs.contabilidad.psaldolineabalance(context ).execute(  A114TotTipo,  A115TotRub,  A116RubCod,  A118RubLinCod,  AV8Ano,  AV9Mes,  "ACT",  AV61CosCod, out  GXt_decimal1) ;
                  AV66ImpBal = GXt_decimal1;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1826RubLinDsc)) )
                  {
                     /* Execute user subroutine: 'LINEAS' */
                     S141 ();
                     if ( returnInSub )
                     {
                        pr_default.close(3);
                        this.cleanup();
                        if (true) return;
                     }
                  }
                  AV65ImpRub = (decimal)(AV65ImpRub+AV66ImpBal);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
               AV62TotIng = (decimal)(AV62TotIng+(((AV67TotRub==1) ? AV65ImpRub : (decimal)(0))));
               AV63TotEgr = (decimal)(AV63TotEgr+(((AV67TotRub==2) ? AV65ImpRub : (decimal)(0))));
               /* Execute user subroutine: 'TOTALRUBROS' */
               S151 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  this.cleanup();
                  if (true) return;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV62TotIng = ((AV62TotIng<Convert.ToDecimal(0)) ? AV62TotIng*-1 : AV62TotIng);
         AV63TotEgr = ((AV63TotEgr<Convert.ToDecimal(0)) ? AV63TotEgr*-1 : AV63TotEgr);
         AV64Final = (decimal)(AV62TotIng-AV63TotEgr);
         /* Execute user subroutine: 'TOTALGENERAL' */
         S161 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
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
         /* 'RUBROSTOTAL' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV70TotDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Size = 12;
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S131( )
      {
         /* 'RUBROS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = StringUtil.Trim( AV71RubDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Size = 10;
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S141( )
      {
         /* 'LINEAS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Text = StringUtil.Trim( AV74RubLinDsc);
         AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Size = 8;
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Number = (double)(AV66ImpBal);
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Size = 8;
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S151( )
      {
         /* 'TOTALRUBROS' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Text = StringUtil.Trim( AV75RubDscTot);
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, 2, 1, 1).Size = 10;
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Number = (double)(AV65ImpRub);
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Size = 10;
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Bold = 1;
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S161( )
      {
         /* 'TOTALGENERAL' Routine */
         returnInSub = false;
         AV14CellRow = (int)(AV14CellRow+1);
         AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Text = "Total General";
         AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV14CellRow, 3, 1, 1).Size = 12;
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Number = (double)(AV64Final);
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Size = 12;
         AV13ExcelDocument.get_Cells(AV14CellRow, 4, 1, 1).Bold = 1;
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
         AV37Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV41FilenameOrigen = "";
         AV13ExcelDocument = new ExcelDocumentI();
         AV44Titulo = "";
         AV68TotTipo = "";
         scmdbuf = "";
         P00BS2_A79COSCod = new string[] {""} ;
         P00BS2_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         P00BS3_A114TotTipo = new string[] {""} ;
         P00BS3_A115TotRub = new int[1] ;
         P00BS3_A1928TotDsc = new string[] {""} ;
         P00BS3_A120TotOrd = new short[1] ;
         A114TotTipo = "";
         A1928TotDsc = "";
         AV70TotDsc = "";
         P00BS4_A115TotRub = new int[1] ;
         P00BS4_A114TotTipo = new string[] {""} ;
         P00BS4_A1829RubSts = new short[1] ;
         P00BS4_A116RubCod = new int[1] ;
         P00BS4_A1822RubDsc = new string[] {""} ;
         P00BS4_A1823RubDscTot = new string[] {""} ;
         P00BS4_A117RubOrd = new short[1] ;
         A1822RubDsc = "";
         A1823RubDscTot = "";
         AV71RubDsc = "";
         AV75RubDscTot = "";
         P00BS5_A116RubCod = new int[1] ;
         P00BS5_A115TotRub = new int[1] ;
         P00BS5_A114TotTipo = new string[] {""} ;
         P00BS5_A118RubLinCod = new int[1] ;
         P00BS5_A1826RubLinDsc = new string[] {""} ;
         P00BS5_A119RubLinOrd = new short[1] ;
         A1826RubLinDsc = "";
         AV74RubLinDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.p_reportecostocentrocostoexcel__default(),
            new Object[][] {
                new Object[] {
               P00BS2_A79COSCod, P00BS2_A761COSDsc
               }
               , new Object[] {
               P00BS3_A114TotTipo, P00BS3_A115TotRub, P00BS3_A1928TotDsc, P00BS3_A120TotOrd
               }
               , new Object[] {
               P00BS4_A115TotRub, P00BS4_A114TotTipo, P00BS4_A1829RubSts, P00BS4_A116RubCod, P00BS4_A1822RubDsc, P00BS4_A1823RubDscTot, P00BS4_A117RubOrd
               }
               , new Object[] {
               P00BS5_A116RubCod, P00BS5_A115TotRub, P00BS5_A114TotTipo, P00BS5_A118RubLinCod, P00BS5_A1826RubLinDsc, P00BS5_A119RubLinOrd
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV9Mes ;
      private short A120TotOrd ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private short A119RubLinOrd ;
      private int AV42MonCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A115TotRub ;
      private int AV67TotRub ;
      private int A116RubCod ;
      private int AV69RubCod ;
      private int A118RubLinCod ;
      private int AV72RubLinCod ;
      private decimal AV73ImpTot ;
      private decimal AV65ImpRub ;
      private decimal AV62TotIng ;
      private decimal AV63TotEgr ;
      private decimal AV66ImpBal ;
      private decimal GXt_decimal1 ;
      private decimal AV64Final ;
      private string AV61CosCod ;
      private string AV38Path ;
      private string AV44Titulo ;
      private string AV68TotTipo ;
      private string scmdbuf ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string AV70TotDsc ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private string AV71RubDsc ;
      private string AV75RubDscTot ;
      private string A1826RubLinDsc ;
      private string AV74RubLinDsc ;
      private bool returnInSub ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV41FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_CosCod ;
      private int aP3_MonCod ;
      private IDataStoreProvider pr_default ;
      private string[] P00BS2_A79COSCod ;
      private string[] P00BS2_A761COSDsc ;
      private string[] P00BS3_A114TotTipo ;
      private int[] P00BS3_A115TotRub ;
      private string[] P00BS3_A1928TotDsc ;
      private short[] P00BS3_A120TotOrd ;
      private int[] P00BS4_A115TotRub ;
      private string[] P00BS4_A114TotTipo ;
      private short[] P00BS4_A1829RubSts ;
      private int[] P00BS4_A116RubCod ;
      private string[] P00BS4_A1822RubDsc ;
      private string[] P00BS4_A1823RubDscTot ;
      private short[] P00BS4_A117RubOrd ;
      private int[] P00BS5_A116RubCod ;
      private int[] P00BS5_A115TotRub ;
      private string[] P00BS5_A114TotTipo ;
      private int[] P00BS5_A118RubLinCod ;
      private string[] P00BS5_A1826RubLinDsc ;
      private short[] P00BS5_A119RubLinOrd ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV37Archivo ;
   }

   public class p_reportecostocentrocostoexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00BS2;
          prmP00BS2 = new Object[] {
          new ParDef("@AV61CosCod",GXType.NChar,10,0)
          };
          Object[] prmP00BS3;
          prmP00BS3 = new Object[] {
          new ParDef("@AV68TotTipo",GXType.NChar,3,0)
          };
          Object[] prmP00BS4;
          prmP00BS4 = new Object[] {
          new ParDef("@AV68TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV67TotRub",GXType.Int32,6,0)
          };
          Object[] prmP00BS5;
          prmP00BS5 = new Object[] {
          new ParDef("@AV68TotTipo",GXType.NChar,3,0) ,
          new ParDef("@AV67TotRub",GXType.Int32,6,0) ,
          new ParDef("@AV69RubCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BS2", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV61CosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00BS3", "SELECT [TotTipo], [TotRub], [TotDsc], [TotOrd] FROM [CBRUBROST] WHERE [TotTipo] = @AV68TotTipo ORDER BY [TotOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS4", "SELECT [TotRub], [TotTipo], [RubSts], [RubCod], [RubDsc], [RubDscTot], [RubOrd] FROM [CBRUBROS] WHERE ([TotTipo] = @AV68TotTipo) AND ([TotRub] = @AV67TotRub) ORDER BY [RubOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BS5", "SELECT [RubCod], [TotRub], [TotTipo], [RubLinCod], [RubLinDsc], [RubLinOrd] FROM [CBRUBROSL] WHERE ([TotTipo] = @AV68TotTipo) AND ([TotRub] = @AV67TotRub) AND ([RubCod] = @AV69RubCod) ORDER BY [RubLinOrd] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BS5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
