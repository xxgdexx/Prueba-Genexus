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
   public class r_resumeningresosegresosexcel : GXProcedure
   {
      public r_resumeningresosegresosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_resumeningresosegresosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_BanCod ,
                           ref DateTime aP1_FDesde ,
                           ref DateTime aP2_FHasta ,
                           ref string aP3_Tipo ,
                           out string aP4_Filename ,
                           out string aP5_ErrorMessage )
      {
         this.AV140BanCod = aP0_BanCod;
         this.AV77FDesde = aP1_FDesde;
         this.AV76FHasta = aP2_FHasta;
         this.AV157Tipo = aP3_Tipo;
         this.AV10Filename = "" ;
         this.AV11ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_BanCod=this.AV140BanCod;
         aP1_FDesde=this.AV77FDesde;
         aP2_FHasta=this.AV76FHasta;
         aP3_Tipo=this.AV157Tipo;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      public string executeUdp( ref int aP0_BanCod ,
                                ref DateTime aP1_FDesde ,
                                ref DateTime aP2_FHasta ,
                                ref string aP3_Tipo ,
                                out string aP4_Filename )
      {
         execute(ref aP0_BanCod, ref aP1_FDesde, ref aP2_FHasta, ref aP3_Tipo, out aP4_Filename, out aP5_ErrorMessage);
         return AV11ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_BanCod ,
                                 ref DateTime aP1_FDesde ,
                                 ref DateTime aP2_FHasta ,
                                 ref string aP3_Tipo ,
                                 out string aP4_Filename ,
                                 out string aP5_ErrorMessage )
      {
         r_resumeningresosegresosexcel objr_resumeningresosegresosexcel;
         objr_resumeningresosegresosexcel = new r_resumeningresosegresosexcel();
         objr_resumeningresosegresosexcel.AV140BanCod = aP0_BanCod;
         objr_resumeningresosegresosexcel.AV77FDesde = aP1_FDesde;
         objr_resumeningresosegresosexcel.AV76FHasta = aP2_FHasta;
         objr_resumeningresosegresosexcel.AV157Tipo = aP3_Tipo;
         objr_resumeningresosegresosexcel.AV10Filename = "" ;
         objr_resumeningresosegresosexcel.AV11ErrorMessage = "" ;
         objr_resumeningresosegresosexcel.context.SetSubmitInitialConfig(context);
         objr_resumeningresosegresosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_resumeningresosegresosexcel);
         aP0_BanCod=this.AV140BanCod;
         aP1_FDesde=this.AV77FDesde;
         aP2_FHasta=this.AV76FHasta;
         aP3_Tipo=this.AV157Tipo;
         aP4_Filename=this.AV10Filename;
         aP5_ErrorMessage=this.AV11ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_resumeningresosegresosexcel)stateInfo).executePrivate();
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
         AV72Archivo.Source = "Excel/PlantillasIngresosEgresos.xlsx";
         AV71Path = AV72Archivo.GetPath();
         AV70FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasIngresosEgresos.xlsx";
         AV10Filename = "Excel/IngresosEgresos" + ".xlsx";
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.Template = AV70FilenameOrigen;
         AV13ExcelDocument.Open(AV10Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV14CellRow = 6;
         AV15FirstColumn = 1;
         AV13ExcelDocument.get_Cells(3, 1, 1, 1).Text = "Desde  : "+context.localUtil.DToC( AV77FDesde, 2, "/")+" Al : "+context.localUtil.DToC( AV76FHasta, 2, "/");
         AV150BanDsc = "";
         AV151CTBco = "";
         AV26Debe = 0.00m;
         AV27Haber = 0.00m;
         AV109Saldo = 0.00m;
         AV153TDebe = 0.00m;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV140BanCod ,
                                              AV157Tipo ,
                                              A379LBBanCod ,
                                              A1070LBTipo ,
                                              A1079LBFech ,
                                              AV77FDesde ,
                                              AV76FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009X2 */
         pr_default.execute(0, new Object[] {AV77FDesde, AV76FHasta, AV140BanCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1079LBFech = P009X2_A1079LBFech[0];
            A379LBBanCod = P009X2_A379LBBanCod[0];
            A1056LBCheq = P009X2_A1056LBCheq[0];
            A1053LBBanAbr = P009X2_A1053LBBanAbr[0];
            A380LBCBCod = P009X2_A380LBCBCod[0];
            A1075LBDocumento = P009X2_A1075LBDocumento[0];
            A1057LBConcepto = P009X2_A1057LBConcepto[0];
            A1054LBBeneficia = P009X2_A1054LBBeneficia[0];
            A381LBRegistro = P009X2_A381LBRegistro[0];
            A1073LBTHaber = P009X2_A1073LBTHaber[0];
            A1072LBTDebe = P009X2_A1072LBTDebe[0];
            A1070LBTipo = P009X2_A1070LBTipo[0];
            A1053LBBanAbr = P009X2_A1053LBBanAbr[0];
            A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
            A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
            A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
            AV158BanAbr = StringUtil.Trim( A1053LBBanAbr);
            AV151CTBco = A380LBCBCod;
            AV26Debe = A1069LBDebeTot;
            AV27Haber = A1082LBHaberTot;
            AV144LBRegistro = StringUtil.Trim( A381LBRegistro);
            AV145LBDocumento = StringUtil.Trim( A1075LBDocumento);
            AV146LBFech = A1079LBFech;
            AV156Mov = (decimal)(AV26Debe-AV27Haber);
            AV109Saldo = (decimal)(AV109Saldo+AV156Mov);
            AV159LBConcepto = StringUtil.Trim( A1057LBConcepto);
            AV147LBBeneficia = StringUtil.Trim( A1054LBBeneficia);
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV153TDebe = (decimal)(AV153TDebe+AV26Debe);
            AV154THaber = (decimal)(AV154THaber+AV27Haber);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
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
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV158BanAbr);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+1, 1, 1).Text = StringUtil.Trim( AV151CTBco);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV144LBRegistro);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV145LBDocumento);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV146LBFech ) ;
         AV13ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+4, 1, 1).Date = GXt_dtime1;
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV159LBConcepto);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV147LBBeneficia);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+7, 1, 1).Number = (double)(AV26Debe);
         AV13ExcelDocument.get_Cells(AV14CellRow, AV15FirstColumn+8, 1, 1).Number = (double)(AV27Haber);
         AV14CellRow = (int)(AV14CellRow+1);
      }

      protected void S121( )
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
         AV150BanDsc = "";
         AV151CTBco = "";
         scmdbuf = "";
         A1079LBFech = DateTime.MinValue;
         P009X2_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         P009X2_A379LBBanCod = new int[1] ;
         P009X2_A1056LBCheq = new short[1] ;
         P009X2_A1053LBBanAbr = new string[] {""} ;
         P009X2_A380LBCBCod = new string[] {""} ;
         P009X2_A1075LBDocumento = new string[] {""} ;
         P009X2_A1057LBConcepto = new string[] {""} ;
         P009X2_A1054LBBeneficia = new string[] {""} ;
         P009X2_A381LBRegistro = new string[] {""} ;
         P009X2_A1073LBTHaber = new decimal[1] ;
         P009X2_A1072LBTDebe = new decimal[1] ;
         P009X2_A1070LBTipo = new short[1] ;
         A1053LBBanAbr = "";
         A380LBCBCod = "";
         A1075LBDocumento = "";
         A1057LBConcepto = "";
         A1054LBBeneficia = "";
         A381LBRegistro = "";
         AV158BanAbr = "";
         AV144LBRegistro = "";
         AV145LBDocumento = "";
         AV146LBFech = DateTime.MinValue;
         AV159LBConcepto = "";
         AV147LBBeneficia = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.r_resumeningresosegresosexcel__default(),
            new Object[][] {
                new Object[] {
               P009X2_A1079LBFech, P009X2_A379LBBanCod, P009X2_A1056LBCheq, P009X2_A1053LBBanAbr, P009X2_A380LBCBCod, P009X2_A1075LBDocumento, P009X2_A1057LBConcepto, P009X2_A1054LBBeneficia, P009X2_A381LBRegistro, P009X2_A1073LBTHaber,
               P009X2_A1072LBTDebe, P009X2_A1070LBTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1070LBTipo ;
      private short A1056LBCheq ;
      private int AV140BanCod ;
      private int AV14CellRow ;
      private int AV15FirstColumn ;
      private int A379LBBanCod ;
      private decimal AV26Debe ;
      private decimal AV27Haber ;
      private decimal AV109Saldo ;
      private decimal AV153TDebe ;
      private decimal A1073LBTHaber ;
      private decimal A1072LBTDebe ;
      private decimal A1071LBTSaldo ;
      private decimal A1082LBHaberTot ;
      private decimal A1069LBDebeTot ;
      private decimal AV156Mov ;
      private decimal AV154THaber ;
      private string AV157Tipo ;
      private string AV71Path ;
      private string AV150BanDsc ;
      private string AV151CTBco ;
      private string scmdbuf ;
      private string A1053LBBanAbr ;
      private string A380LBCBCod ;
      private string A1075LBDocumento ;
      private string A1057LBConcepto ;
      private string A1054LBBeneficia ;
      private string A381LBRegistro ;
      private string AV158BanAbr ;
      private string AV144LBRegistro ;
      private string AV145LBDocumento ;
      private string AV159LBConcepto ;
      private string AV147LBBeneficia ;
      private DateTime GXt_dtime1 ;
      private DateTime AV77FDesde ;
      private DateTime AV76FHasta ;
      private DateTime A1079LBFech ;
      private DateTime AV146LBFech ;
      private bool returnInSub ;
      private string AV10Filename ;
      private string AV11ErrorMessage ;
      private string AV70FilenameOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_BanCod ;
      private DateTime aP1_FDesde ;
      private DateTime aP2_FHasta ;
      private string aP3_Tipo ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P009X2_A1079LBFech ;
      private int[] P009X2_A379LBBanCod ;
      private short[] P009X2_A1056LBCheq ;
      private string[] P009X2_A1053LBBanAbr ;
      private string[] P009X2_A380LBCBCod ;
      private string[] P009X2_A1075LBDocumento ;
      private string[] P009X2_A1057LBConcepto ;
      private string[] P009X2_A1054LBBeneficia ;
      private string[] P009X2_A381LBRegistro ;
      private decimal[] P009X2_A1073LBTHaber ;
      private decimal[] P009X2_A1072LBTDebe ;
      private short[] P009X2_A1070LBTipo ;
      private string aP4_Filename ;
      private string aP5_ErrorMessage ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GxFile AV72Archivo ;
   }

   public class r_resumeningresosegresosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009X2( IGxContext context ,
                                             int AV140BanCod ,
                                             string AV157Tipo ,
                                             int A379LBBanCod ,
                                             short A1070LBTipo ,
                                             DateTime A1079LBFech ,
                                             DateTime AV77FDesde ,
                                             DateTime AV76FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[3];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[LBFech], T1.[LBBanCod] AS LBBanCod, T1.[LBCheq], T2.[BanAbr] AS LBBanAbr, T1.[LBCBCod], T1.[LBDocumento], T1.[LBConcepto], T1.[LBBeneficia], T1.[LBRegistro], T1.[LBTHaber], T1.[LBTDebe], T1.[LBTipo] FROM ([TSLIBROBANCOS] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[LBBanCod])";
         AddWhere(sWhereString, "(T1.[LBFech] >= @AV77FDesde)");
         AddWhere(sWhereString, "(T1.[LBFech] <= @AV76FHasta)");
         if ( ! (0==AV140BanCod) )
         {
            AddWhere(sWhereString, "(T1.[LBBanCod] = @AV140BanCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( StringUtil.StrCmp(AV157Tipo, "I") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LBTipo] = 1)");
         }
         if ( StringUtil.StrCmp(AV157Tipo, "E") == 0 )
         {
            AddWhere(sWhereString, "(T1.[LBTipo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[LBRegistro]";
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
                     return conditional_P009X2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (short)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] );
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
          Object[] prmP009X2;
          prmP009X2 = new Object[] {
          new ParDef("@AV77FDesde",GXType.Date,8,0) ,
          new ParDef("@AV76FHasta",GXType.Date,8,0) ,
          new ParDef("@AV140BanCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 60);
                ((string[]) buf[7])[0] = rslt.getString(8, 60);
                ((string[]) buf[8])[0] = rslt.getString(9, 10);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                return;
       }
    }

 }

}
