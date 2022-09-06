using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
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
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reloj_horarioupdatereferentialintegrity : GXProcedure
   {
      public reloj_horarioupdatereferentialintegrity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horarioupdatereferentialintegrity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         reloj_horarioupdatereferentialintegrity objreloj_horarioupdatereferentialintegrity;
         objreloj_horarioupdatereferentialintegrity = new reloj_horarioupdatereferentialintegrity();
         objreloj_horarioupdatereferentialintegrity.context.SetSubmitInitialConfig(context);
         objreloj_horarioupdatereferentialintegrity.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_horarioupdatereferentialintegrity);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_horarioupdatereferentialintegrity)stateInfo).executePrivate();
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
         /* Using cursor RELOJ_HORA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2591HorarioID = RELOJ_HORA2_A2591HorarioID[0];
            A2431CodigoId = RELOJ_HORA2_A2431CodigoId[0];
            /*
               INSERT RECORD ON TABLE Reloj_Horario

            */
            A2432Horario_ID = A2591HorarioID;
            A2433Horario_Dsc = " ";
            A2434Horario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2435Horario_Dia_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2436Horario_Dia_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2437Horario_Dia_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2438Horario_Dia_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2439Horario_Dia_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2440Horario_Dia_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2441Horario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2442Horario_Dia_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2443Horario_Dia_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2444Horario_Dia_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2445Horario_Dia_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2446Horario_Dia_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2447Horario_Dia_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2448Horario_Ref_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2449Horario_Ref_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2450Horario_Ref_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2451Horario_Ref_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2452Horario_Ref_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2453Horario_Ref_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2454Horario_Ref_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2455Horario_Ref_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2456Horario_Ref_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2457Horario_Ref_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2458Horario_Ref_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2459Horario_Ref_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2460Horario_Ref_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2461Horario_Ref_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0));
            A2462Horario_Vigencia = context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0);
            A2463Horario_Sts = 0;
            A2464Horario_Dia_Toling = 0;
            A2465Horario_Dia_TolRef = 0;
            A2466Horario_Dia_TolSal = 0;
            /* Using cursor RELOJ_HORA3 */
            pr_default.execute(1, new Object[] {A2432Horario_ID, A2433Horario_Dsc, A2434Horario_Dia_Ini_01, A2435Horario_Dia_Ini_02, A2436Horario_Dia_Ini_03, A2437Horario_Dia_Ini_04, A2438Horario_Dia_Ini_05, A2439Horario_Dia_Ini_06, A2440Horario_Dia_Ini_07, A2441Horario_Dia_Fin_01, A2442Horario_Dia_Fin_02, A2443Horario_Dia_Fin_03, A2444Horario_Dia_Fin_04, A2445Horario_Dia_Fin_05, A2446Horario_Dia_Fin_06, A2447Horario_Dia_Fin_07, A2448Horario_Ref_Ini_01, A2449Horario_Ref_Ini_02, A2450Horario_Ref_Ini_03, A2451Horario_Ref_Ini_04, A2452Horario_Ref_Ini_05, A2453Horario_Ref_Ini_06, A2454Horario_Ref_Ini_07, A2455Horario_Ref_Fin_01, A2456Horario_Ref_Fin_02, A2457Horario_Ref_Fin_03, A2458Horario_Ref_Fin_04, A2459Horario_Ref_Fin_05, A2460Horario_Ref_Fin_06, A2461Horario_Ref_Fin_07, A2462Horario_Vigencia, A2463Horario_Sts, A2464Horario_Dia_Toling, A2465Horario_Dia_TolRef, A2466Horario_Dia_TolSal});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Reloj_Horario");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(GXResourceManager.GetMessage("GXM_noupdate"));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         RELOJ_HORA2_A2591HorarioID = new short[1] ;
         RELOJ_HORA2_A2431CodigoId = new string[] {""} ;
         A2431CodigoId = "";
         A2433Horario_Dsc = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         A2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
         A2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
         A2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
         A2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
         A2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
         A2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         A2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
         A2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
         A2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
         A2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
         A2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
         A2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
         A2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
         A2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
         A2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
         A2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
         A2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
         A2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
         A2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
         A2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
         A2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
         A2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
         A2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
         A2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
         A2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
         A2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_horarioupdatereferentialintegrity__default(),
            new Object[][] {
                new Object[] {
               RELOJ_HORA2_A2591HorarioID, RELOJ_HORA2_A2431CodigoId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2591HorarioID ;
      private short A2432Horario_ID ;
      private short A2463Horario_Sts ;
      private int GX_INS213 ;
      private int A2464Horario_Dia_Toling ;
      private int A2465Horario_Dia_TolRef ;
      private int A2466Horario_Dia_TolSal ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2435Horario_Dia_Ini_02 ;
      private DateTime A2436Horario_Dia_Ini_03 ;
      private DateTime A2437Horario_Dia_Ini_04 ;
      private DateTime A2438Horario_Dia_Ini_05 ;
      private DateTime A2439Horario_Dia_Ini_06 ;
      private DateTime A2440Horario_Dia_Ini_07 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2442Horario_Dia_Fin_02 ;
      private DateTime A2443Horario_Dia_Fin_03 ;
      private DateTime A2444Horario_Dia_Fin_04 ;
      private DateTime A2445Horario_Dia_Fin_05 ;
      private DateTime A2446Horario_Dia_Fin_06 ;
      private DateTime A2447Horario_Dia_Fin_07 ;
      private DateTime A2448Horario_Ref_Ini_01 ;
      private DateTime A2449Horario_Ref_Ini_02 ;
      private DateTime A2450Horario_Ref_Ini_03 ;
      private DateTime A2451Horario_Ref_Ini_04 ;
      private DateTime A2452Horario_Ref_Ini_05 ;
      private DateTime A2453Horario_Ref_Ini_06 ;
      private DateTime A2454Horario_Ref_Ini_07 ;
      private DateTime A2455Horario_Ref_Fin_01 ;
      private DateTime A2456Horario_Ref_Fin_02 ;
      private DateTime A2457Horario_Ref_Fin_03 ;
      private DateTime A2458Horario_Ref_Fin_04 ;
      private DateTime A2459Horario_Ref_Fin_05 ;
      private DateTime A2460Horario_Ref_Fin_06 ;
      private DateTime A2461Horario_Ref_Fin_07 ;
      private DateTime A2462Horario_Vigencia ;
      private string A2431CodigoId ;
      private string A2433Horario_Dsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] RELOJ_HORA2_A2591HorarioID ;
      private string[] RELOJ_HORA2_A2431CodigoId ;
   }

   public class reloj_horarioupdatereferentialintegrity__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmRELOJ_HORA2;
          prmRELOJ_HORA2 = new Object[] {
          };
          Object[] prmRELOJ_HORA3;
          prmRELOJ_HORA3 = new Object[] {
          new ParDef("@Horario_ID",GXType.Int16,4,0) ,
          new ParDef("@Horario_Dsc",GXType.NVarChar,100,5) ,
          new ParDef("@Horario_Dia_Ini_01",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_02",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_03",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_04",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_05",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_06",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Ini_07",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_01",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_02",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_03",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_04",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_05",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_06",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Dia_Fin_07",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_01",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_02",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_03",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_04",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_05",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_06",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Ini_07",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_01",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_02",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_03",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_04",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_05",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_06",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Ref_Fin_07",GXType.DateTime,0,5) ,
          new ParDef("@Horario_Vigencia",GXType.DateTime,10,8) ,
          new ParDef("@Horario_Sts",GXType.Int16,1,0) ,
          new ParDef("@Horario_Dia_Toling",GXType.Int32,9,0) ,
          new ParDef("@Horario_Dia_TolRef",GXType.Int32,9,0) ,
          new ParDef("@Horario_Dia_TolSal",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("RELOJ_HORA2", "SELECT [HorarioID], [CodigoId] FROM [Reloj_CodigoID] ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmRELOJ_HORA2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("RELOJ_HORA3", "INSERT INTO [Reloj_Horario]([Horario_ID], [Horario_Dsc], [Horario_Dia_Ini_01], [Horario_Dia_Ini_02], [Horario_Dia_Ini_03], [Horario_Dia_Ini_04], [Horario_Dia_Ini_05], [Horario_Dia_Ini_06], [Horario_Dia_Ini_07], [Horario_Dia_Fin_01], [Horario_Dia_Fin_02], [Horario_Dia_Fin_03], [Horario_Dia_Fin_04], [Horario_Dia_Fin_05], [Horario_Dia_Fin_06], [Horario_Dia_Fin_07], [Horario_Ref_Ini_01], [Horario_Ref_Ini_02], [Horario_Ref_Ini_03], [Horario_Ref_Ini_04], [Horario_Ref_Ini_05], [Horario_Ref_Ini_06], [Horario_Ref_Ini_07], [Horario_Ref_Fin_01], [Horario_Ref_Fin_02], [Horario_Ref_Fin_03], [Horario_Ref_Fin_04], [Horario_Ref_Fin_05], [Horario_Ref_Fin_06], [Horario_Ref_Fin_07], [Horario_Vigencia], [Horario_Sts], [Horario_Dia_Toling], [Horario_Dia_TolRef], [Horario_Dia_TolSal]) VALUES(@Horario_ID, @Horario_Dsc, @Horario_Dia_Ini_01, @Horario_Dia_Ini_02, @Horario_Dia_Ini_03, @Horario_Dia_Ini_04, @Horario_Dia_Ini_05, @Horario_Dia_Ini_06, @Horario_Dia_Ini_07, @Horario_Dia_Fin_01, @Horario_Dia_Fin_02, @Horario_Dia_Fin_03, @Horario_Dia_Fin_04, @Horario_Dia_Fin_05, @Horario_Dia_Fin_06, @Horario_Dia_Fin_07, @Horario_Ref_Ini_01, @Horario_Ref_Ini_02, @Horario_Ref_Ini_03, @Horario_Ref_Ini_04, @Horario_Ref_Ini_05, @Horario_Ref_Ini_06, @Horario_Ref_Ini_07, @Horario_Ref_Fin_01, @Horario_Ref_Fin_02, @Horario_Ref_Fin_03, @Horario_Ref_Fin_04, @Horario_Ref_Fin_05, @Horario_Ref_Fin_06, @Horario_Ref_Fin_07, @Horario_Vigencia, @Horario_Sts, @Horario_Dia_Toling, @Horario_Dia_TolRef, @Horario_Dia_TolSal)", GxErrorMask.GX_NOMASK,prmRELOJ_HORA3)
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
