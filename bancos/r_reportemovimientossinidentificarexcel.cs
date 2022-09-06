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
namespace GeneXus.Programs.bancos {
   public class r_reportemovimientossinidentificarexcel : GXProcedure
   {
      public r_reportemovimientossinidentificarexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_reportemovimientossinidentificarexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref string aP1_CBCod ,
                           ref DateTime aP2_FDesde ,
                           ref DateTime aP3_FHasta ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV14BanCod = aP0_BanCod;
         this.AV16CBCod = aP1_CBCod;
         this.AV21FDesde = aP2_FDesde;
         this.AV22FHasta = aP3_FHasta;
         this.AV23Filename = "" ;
         this.AV19ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV14BanCod;
         aP1_CBCod=this.AV16CBCod;
         aP2_FDesde=this.AV21FDesde;
         aP3_FHasta=this.AV22FHasta;
         aP4_Filename=this.AV23Filename;
         aP5_ErrorMessage=this.AV19ErrorMessage;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref string aP1_CBCod ,
                                ref DateTime aP2_FDesde ,
                                ref DateTime aP3_FHasta ,
                                out string aP4_Filename )
      {
         execute(ref aP0_BanCod, ref aP1_CBCod, ref aP2_FDesde, ref aP3_FHasta, out aP4_Filename, out aP5_ErrorMessage);
         return AV19ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref string aP1_CBCod ,
                                 ref DateTime aP2_FDesde ,
                                 ref DateTime aP3_FHasta ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_reportemovimientossinidentificarexcel objr_reportemovimientossinidentificarexcel;
         objr_reportemovimientossinidentificarexcel = new r_reportemovimientossinidentificarexcel();
         objr_reportemovimientossinidentificarexcel.AV14BanCod = aP0_BanCod;
         objr_reportemovimientossinidentificarexcel.AV16CBCod = aP1_CBCod;
         objr_reportemovimientossinidentificarexcel.AV21FDesde = aP2_FDesde;
         objr_reportemovimientossinidentificarexcel.AV22FHasta = aP3_FHasta;
         objr_reportemovimientossinidentificarexcel.AV23Filename = "" ;
         objr_reportemovimientossinidentificarexcel.AV19ErrorMessage = "" ;
         objr_reportemovimientossinidentificarexcel.context.SetSubmitInitialConfig(context);
         objr_reportemovimientossinidentificarexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_reportemovimientossinidentificarexcel);
         aP0_BanCod=this.AV14BanCod;
         aP1_CBCod=this.AV16CBCod;
         aP2_FDesde=this.AV21FDesde;
         aP3_FHasta=this.AV22FHasta;
         aP4_Filename=this.AV23Filename;
         aP5_ErrorMessage=this.AV19ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_reportemovimientossinidentificarexcel)stateInfo).executePrivate();
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
         AV13Archivo.Source = "Excel/PlantillasSINIdentificar.xlsx";
         AV38Path = AV13Archivo.GetPath();
         AV24FilenameOrigen = StringUtil.Trim( AV38Path) + "\\PlantillasSINIdentificar.xlsx";
         AV23Filename = "Excel/SINIdentificar" + ".xlsx";
         AV20ExcelDocument.Clear();
         AV20ExcelDocument.Template = AV24FilenameOrigen;
         AV20ExcelDocument.Open(AV23Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV17CellRow = 5;
         AV25FirstColumn = 1;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV14BanCod ,
                                              AV16CBCod ,
                                              A379LBBanCod ,
                                              A380LBCBCod ,
                                              A1079LBFech ,
                                              AV21FDesde ,
                                              AV22FHasta ,
                                              A1088LBSaldoAnticipo ,
                                              A1055LBCheck } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.SHORT
                                              }
         });
         /* Using cursor P008E2 */
         pr_default.execute(0, new Object[] {AV21FDesde, AV22FHasta, AV14BanCod, AV16CBCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8E2 = false;
            A1085LBMonCod = P008E2_A1085LBMonCod[0];
            A380LBCBCod = P008E2_A380LBCBCod[0];
            A379LBBanCod = P008E2_A379LBBanCod[0];
            A1055LBCheck = P008E2_A1055LBCheck[0];
            A1088LBSaldoAnticipo = P008E2_A1088LBSaldoAnticipo[0];
            A1079LBFech = P008E2_A1079LBFech[0];
            A482BanDsc = P008E2_A482BanDsc[0];
            n482BanDsc = P008E2_n482BanDsc[0];
            A1234MonDsc = P008E2_A1234MonDsc[0];
            n1234MonDsc = P008E2_n1234MonDsc[0];
            A1233MonAbr = P008E2_A1233MonAbr[0];
            n1233MonAbr = P008E2_n1233MonAbr[0];
            A1073LBTHaber = P008E2_A1073LBTHaber[0];
            A1052LBAnticipoAplic = P008E2_A1052LBAnticipoAplic[0];
            A381LBRegistro = P008E2_A381LBRegistro[0];
            A482BanDsc = P008E2_A482BanDsc[0];
            n482BanDsc = P008E2_n482BanDsc[0];
            A1085LBMonCod = P008E2_A1085LBMonCod[0];
            A1234MonDsc = P008E2_A1234MonDsc[0];
            n1234MonDsc = P008E2_n1234MonDsc[0];
            A1233MonAbr = P008E2_A1233MonAbr[0];
            n1233MonAbr = P008E2_n1233MonAbr[0];
            while ( (pr_default.getStatus(0) != 101) && ( P008E2_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(P008E2_A380LBCBCod[0], A380LBCBCod) == 0 ) )
            {
               BRK8E2 = false;
               A1085LBMonCod = P008E2_A1085LBMonCod[0];
               A381LBRegistro = P008E2_A381LBRegistro[0];
               A1085LBMonCod = P008E2_A1085LBMonCod[0];
               BRK8E2 = true;
               pr_default.readNext(0);
            }
            AV27LBBanCod = A379LBBanCod;
            AV28LBCBCod = A380LBCBCod;
            AV15BanDsc = A482BanDsc;
            AV12MonDsc = StringUtil.Trim( A1234MonDsc);
            AV11MonAbr = StringUtil.Trim( A1233MonAbr);
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            if ( ! BRK8E2 )
            {
               BRK8E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV20ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV20ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         /* Using cursor P008E3 */
         pr_default.execute(1, new Object[] {AV21FDesde, AV27LBBanCod, AV28LBCBCod, AV22FHasta});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A379LBBanCod = P008E3_A379LBBanCod[0];
            A380LBCBCod = P008E3_A380LBCBCod[0];
            A1055LBCheck = P008E3_A1055LBCheck[0];
            A1088LBSaldoAnticipo = P008E3_A1088LBSaldoAnticipo[0];
            A1079LBFech = P008E3_A1079LBFech[0];
            A1057LBConcepto = P008E3_A1057LBConcepto[0];
            A1054LBBeneficia = P008E3_A1054LBBeneficia[0];
            A381LBRegistro = P008E3_A381LBRegistro[0];
            A1075LBDocumento = P008E3_A1075LBDocumento[0];
            A1073LBTHaber = P008E3_A1073LBTHaber[0];
            A1052LBAnticipoAplic = P008E3_A1052LBAnticipoAplic[0];
            AV18Debe = A1088LBSaldoAnticipo;
            AV26Haber = 0;
            AV33LBFech = A1079LBFech;
            AV9LBConcepto = StringUtil.Trim( A1057LBConcepto);
            AV8LBBeneficia = StringUtil.Trim( A1054LBBeneficia);
            AV35LBRegistro = StringUtil.Trim( A381LBRegistro);
            AV10LBDocumento = A1075LBDocumento;
            /* Execute user subroutine: 'DETALLES' */
            S124 ();
            if ( returnInSub )
            {
               pr_default.close(1);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void S124( )
      {
         /* 'DETALLES' Routine */
         returnInSub = false;
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+0), 1, 1).Text = StringUtil.Trim( AV15BanDsc);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV28LBCBCod);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV12MonDsc);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV35LBRegistro);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV10LBDocumento);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV33LBFech ) ;
         AV20ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+5), 1, 1).Date = GXt_dtime1;
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+6), 1, 1).Text = StringUtil.Trim( AV8LBBeneficia);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+7), 1, 1).Text = StringUtil.Trim( AV9LBConcepto);
         AV20ExcelDocument.get_Cells((int)(AV17CellRow), (int)(AV25FirstColumn+8), 1, 1).Number = (double)(AV18Debe);
         AV17CellRow = (long)(AV17CellRow+1);
      }

      protected void S131( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV20ExcelDocument.ErrCode != 0 )
         {
            AV23Filename = "";
            AV19ErrorMessage = AV20ExcelDocument.ErrDescription;
            AV20ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
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
         AV23Filename = "";
         AV19ErrorMessage = "";
         AV13Archivo = new GxFile(context.GetPhysicalPath());
         AV38Path = "";
         AV24FilenameOrigen = "";
         AV20ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         A380LBCBCod = "";
         A1079LBFech = DateTime.MinValue;
         P008E2_A1085LBMonCod = new int[1] ;
         P008E2_A380LBCBCod = new string[] {""} ;
         P008E2_A379LBBanCod = new int[1] ;
         P008E2_A1055LBCheck = new short[1] ;
         P008E2_A1088LBSaldoAnticipo = new decimal[1] ;
         P008E2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P008E2_A482BanDsc = new string[] {""} ;
         P008E2_n482BanDsc = new bool[] {false} ;
         P008E2_A1234MonDsc = new string[] {""} ;
         P008E2_n1234MonDsc = new bool[] {false} ;
         P008E2_A1233MonAbr = new string[] {""} ;
         P008E2_n1233MonAbr = new bool[] {false} ;
         P008E2_A1073LBTHaber = new decimal[1] ;
         P008E2_A1052LBAnticipoAplic = new decimal[1] ;
         P008E2_A381LBRegistro = new string[] {""} ;
         A482BanDsc = "";
         A1234MonDsc = "";
         A1233MonAbr = "";
         A381LBRegistro = "";
         AV28LBCBCod = "";
         AV15BanDsc = "";
         AV12MonDsc = "";
         AV11MonAbr = "";
         P008E3_A379LBBanCod = new int[1] ;
         P008E3_A380LBCBCod = new string[] {""} ;
         P008E3_A1055LBCheck = new short[1] ;
         P008E3_A1088LBSaldoAnticipo = new decimal[1] ;
         P008E3_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P008E3_A1057LBConcepto = new string[] {""} ;
         P008E3_A1054LBBeneficia = new string[] {""} ;
         P008E3_A381LBRegistro = new string[] {""} ;
         P008E3_A1075LBDocumento = new string[] {""} ;
         P008E3_A1073LBTHaber = new decimal[1] ;
         P008E3_A1052LBAnticipoAplic = new decimal[1] ;
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A1075LBDocumento = "";
         AV33LBFech = DateTime.MinValue;
         AV9LBConcepto = "";
         AV8LBBeneficia = "";
         AV35LBRegistro = "";
         AV10LBDocumento = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_reportemovimientossinidentificarexcel__default(),
            new Object[][] {
                new Object[] {
               P008E2_A1085LBMonCod, P008E2_A380LBCBCod, P008E2_A379LBBanCod, P008E2_A1055LBCheck, P008E2_A1088LBSaldoAnticipo, P008E2_A1079LBFech, P008E2_A482BanDsc, P008E2_n482BanDsc, P008E2_A1234MonDsc, P008E2_n1234MonDsc,
               P008E2_A1233MonAbr, P008E2_n1233MonAbr, P008E2_A1073LBTHaber, P008E2_A1052LBAnticipoAplic, P008E2_A381LBRegistro
               }
               , new Object[] {
               P008E3_A379LBBanCod, P008E3_A380LBCBCod, P008E3_A1055LBCheck, P008E3_A1088LBSaldoAnticipo, P008E3_A1079LBFech, P008E3_A1057LBConcepto, P008E3_A1054LBBeneficia, P008E3_A381LBRegistro, P008E3_A1075LBDocumento, P008E3_A1073LBTHaber,
               P008E3_A1052LBAnticipoAplic
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1055LBCheck ;
      private int AV14BanCod ;
      private int A379LBBanCod ;
      private int A1085LBMonCod ;
      private int AV27LBBanCod ;
      private long AV17CellRow ;
      private long AV25FirstColumn ;
      private decimal A1088LBSaldoAnticipo ;
      private decimal A1073LBTHaber ;
      private decimal A1052LBAnticipoAplic ;
      private decimal AV18Debe ;
      private decimal AV26Haber ;
      private string AV16CBCod ;
      private string AV19ErrorMessage ;
      private string AV38Path ;
      private string scmdbuf ;
      private string A380LBCBCod ;
      private string A482BanDsc ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private string A381LBRegistro ;
      private string AV28LBCBCod ;
      private string AV15BanDsc ;
      private string AV12MonDsc ;
      private string AV11MonAbr ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A1075LBDocumento ;
      private string AV9LBConcepto ;
      private string AV8LBBeneficia ;
      private string AV35LBRegistro ;
      private string AV10LBDocumento ;
      private DateTime GXt_dtime1 ;
      private DateTime AV21FDesde ;
      private DateTime AV22FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV33LBFech ;
      private bool returnInSub ;
      private bool BRK8E2 ;
      private bool n482BanDsc ;
      private bool n1234MonDsc ;
      private bool n1233MonAbr ;
      private string AV23Filename ;
      private string AV24FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private string aP1_CBCod ;
      private DateTime aP2_FDesde ;
      private DateTime aP3_FHasta ;
      private IDataStoreProvider pr_default ;
      private int[] P008E2_A1085LBMonCod ;
      private string[] P008E2_A380LBCBCod ;
      private int[] P008E2_A379LBBanCod ;
      private short[] P008E2_A1055LBCheck ;
      private decimal[] P008E2_A1088LBSaldoAnticipo ;
      private DateTime[] P008E2_A1079LBFech ;
      private string[] P008E2_A482BanDsc ;
      private bool[] P008E2_n482BanDsc ;
      private string[] P008E2_A1234MonDsc ;
      private bool[] P008E2_n1234MonDsc ;
      private string[] P008E2_A1233MonAbr ;
      private bool[] P008E2_n1233MonAbr ;
      private decimal[] P008E2_A1073LBTHaber ;
      private decimal[] P008E2_A1052LBAnticipoAplic ;
      private string[] P008E2_A381LBRegistro ;
      private int[] P008E3_A379LBBanCod ;
      private string[] P008E3_A380LBCBCod ;
      private short[] P008E3_A1055LBCheck ;
      private decimal[] P008E3_A1088LBSaldoAnticipo ;
      private DateTime[] P008E3_A1079LBFech ;
      private string[] P008E3_A1057LBConcepto ;
      private string[] P008E3_A1054LBBeneficia ;
      private string[] P008E3_A381LBRegistro ;
      private string[] P008E3_A1075LBDocumento ;
      private decimal[] P008E3_A1073LBTHaber ;
      private decimal[] P008E3_A1052LBAnticipoAplic ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV20ExcelDocument ;
      private GxFile AV13Archivo ;
   }

   public class r_reportemovimientossinidentificarexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008E2( IGxContext context ,
                                             int AV14BanCod ,
                                             string AV16CBCod ,
                                             int A379LBBanCod ,
                                             string A380LBCBCod ,
                                             DateTime A1079LBFech ,
                                             DateTime AV21FDesde ,
                                             DateTime AV22FHasta ,
                                             decimal A1088LBSaldoAnticipo ,
                                             short A1055LBCheck )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T3.[MonCod] AS LBMonCod, T1.[LBCBCod] AS LBCBCod, T1.[LBBanCod] AS LBBanCod, T1.[LBCheck], T1.[LBTHaber] - T1.[LBAnticipoAplic] AS LBSaldoAnticipo, T1.[LBFech], T2.[BanDsc], T4.[MonDsc], T4.[MonAbr], T1.[LBTHaber], T1.[LBAnticipoAplic], T1.[LBRegistro] FROM ((([TSLIBROBANCOS] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = T1.[LBBanCod] AND T3.[CBCod] = T1.[LBCBCod]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = T3.[MonCod])";
         AddWhere(sWhereString, "(T1.[LBFech] >= @AV21FDesde)");
         AddWhere(sWhereString, "(T1.[LBFech] <= @AV22FHasta)");
         AddWhere(sWhereString, "(Not (T1.[LBTHaber] - T1.[LBAnticipoAplic] = convert(int, 0)))");
         AddWhere(sWhereString, "(T1.[LBCheck] = 1)");
         if ( ! (0==AV14BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV14BanCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16CBCod)) )
         {
            AddWhere(sWhereString, "(T1.[LBCBCod] = @AV16CBCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBBanCod], T1.[LBCBCod], T3.[MonCod]";
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
                     return conditional_P008E2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (decimal)dynConstraints[7] , (short)dynConstraints[8] );
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
          Object[] prmP008E3;
          prmP008E3 = new Object[] {
          new ParDef("@AV21FDesde",GXType.Date,8,0) ,
          new ParDef("@AV27LBBanCod",GXType.Int32,6,0) ,
          new ParDef("@AV28LBCBCod",GXType.NChar,20,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0)
          };
          Object[] prmP008E2;
          prmP008E2 = new Object[] {
          new ParDef("@AV21FDesde",GXType.Date,8,0) ,
          new ParDef("@AV22FHasta",GXType.Date,8,0) ,
          new ParDef("@AV14BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV16CBCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E3", "SELECT [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBCheck], [LBTHaber] - [LBAnticipoAplic] AS LBSaldoAnticipo, [LBFech], [LBConcepto], [LBBeneficia], [LBRegistro], [LBDocumento], [LBTHaber], [LBAnticipoAplic] FROM [TSLIBROBANCOS] WHERE ([LBFech] >= @AV21FDesde) AND (Not ([LBTHaber] - [LBAnticipoAplic] = convert(int, 0))) AND ([LBBanCod] = @AV27LBBanCod) AND ([LBCBCod] = @AV28LBCBCod) AND ([LBCheck] = 1) AND ([LBFech] <= @AV22FHasta) ORDER BY [LBFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 5);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(11);
                ((string[]) buf[14])[0] = rslt.getString(12, 10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 60);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 10);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                return;
       }
    }

 }

}
