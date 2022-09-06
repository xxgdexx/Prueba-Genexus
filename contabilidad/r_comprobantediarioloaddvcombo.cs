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
namespace GeneXus.Programs.contabilidad {
   public class r_comprobantediarioloaddvcombo : GXProcedure
   {
      public r_comprobantediarioloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_comprobantediarioloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           short aP1_Cond_Ano ,
                           short aP2_Cond_Mes ,
                           int aP3_Cond_TASICod ,
                           string aP4_SearchTxt ,
                           out string aP5_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17Cond_Ano = aP1_Cond_Ano;
         this.AV18Cond_Mes = aP2_Cond_Mes;
         this.AV19Cond_TASICod = aP3_Cond_TASICod;
         this.AV11SearchTxt = aP4_SearchTxt;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                short aP1_Cond_Ano ,
                                short aP2_Cond_Mes ,
                                int aP3_Cond_TASICod ,
                                string aP4_SearchTxt )
      {
         execute(aP0_ComboName, aP1_Cond_Ano, aP2_Cond_Mes, aP3_Cond_TASICod, aP4_SearchTxt, out aP5_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 short aP1_Cond_Ano ,
                                 short aP2_Cond_Mes ,
                                 int aP3_Cond_TASICod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_Combo_DataJson )
      {
         r_comprobantediarioloaddvcombo objr_comprobantediarioloaddvcombo;
         objr_comprobantediarioloaddvcombo = new r_comprobantediarioloaddvcombo();
         objr_comprobantediarioloaddvcombo.AV16ComboName = aP0_ComboName;
         objr_comprobantediarioloaddvcombo.AV17Cond_Ano = aP1_Cond_Ano;
         objr_comprobantediarioloaddvcombo.AV18Cond_Mes = aP2_Cond_Mes;
         objr_comprobantediarioloaddvcombo.AV19Cond_TASICod = aP3_Cond_TASICod;
         objr_comprobantediarioloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objr_comprobantediarioloaddvcombo.AV12Combo_DataJson = "" ;
         objr_comprobantediarioloaddvcombo.context.SetSubmitInitialConfig(context);
         objr_comprobantediarioloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_comprobantediarioloaddvcombo);
         aP5_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_comprobantediarioloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 100;
         if ( StringUtil.StrCmp(AV16ComboName, "VouNum") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_VOUNUM' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_VOUNUM' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11SearchTxt ,
                                              A129VouNum } ,
                                              new int[]{
                                              }
         });
         lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
         /* Using cursor P00EY2 */
         pr_default.execute(0, new Object[] {lV11SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A129VouNum = P00EY2_A129VouNum[0];
            A127VouAno = P00EY2_A127VouAno[0];
            A128VouMes = P00EY2_A128VouMes[0];
            A126TASICod = P00EY2_A126TASICod[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A129VouNum;
            AV14Combo_DataItem.gxTpr_Title = A129VouNum;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            if ( AV13Combo_Data.Count > AV10MaxItems )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
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
         AV12Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         lV11SearchTxt = "";
         A129VouNum = "";
         P00EY2_A129VouNum = new string[] {""} ;
         P00EY2_A127VouAno = new short[1] ;
         P00EY2_A128VouMes = new short[1] ;
         P00EY2_A126TASICod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_comprobantediarioloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00EY2_A129VouNum, P00EY2_A127VouAno, P00EY2_A128VouMes, P00EY2_A126TASICod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV17Cond_Ano ;
      private short AV18Cond_Mes ;
      private short A127VouAno ;
      private short A128VouMes ;
      private int AV19Cond_TASICod ;
      private int AV10MaxItems ;
      private int A126TASICod ;
      private string scmdbuf ;
      private string A129VouNum ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00EY2_A129VouNum ;
      private short[] P00EY2_A127VouAno ;
      private short[] P00EY2_A128VouMes ;
      private int[] P00EY2_A126TASICod ;
      private string aP5_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class r_comprobantediarioloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EY2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A129VouNum )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [VouNum], [VouAno], [VouMes], [TASICod] FROM [CBVOUCHER]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([VouNum] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VouNum]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EY2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00EY2;
          prmP00EY2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EY2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EY2,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
