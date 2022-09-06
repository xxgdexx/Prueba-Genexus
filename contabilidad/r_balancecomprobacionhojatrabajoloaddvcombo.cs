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
   public class r_balancecomprobacionhojatrabajoloaddvcombo : GXProcedure
   {
      public r_balancecomprobacionhojatrabajoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_balancecomprobacionhojatrabajoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           int aP1_Cond_BanCod ,
                           string aP2_SearchTxt ,
                           out string aP3_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17Cond_BanCod = aP1_Cond_BanCod;
         this.AV11SearchTxt = aP2_SearchTxt;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                int aP1_Cond_BanCod ,
                                string aP2_SearchTxt )
      {
         execute(aP0_ComboName, aP1_Cond_BanCod, aP2_SearchTxt, out aP3_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 int aP1_Cond_BanCod ,
                                 string aP2_SearchTxt ,
                                 out string aP3_Combo_DataJson )
      {
         r_balancecomprobacionhojatrabajoloaddvcombo objr_balancecomprobacionhojatrabajoloaddvcombo;
         objr_balancecomprobacionhojatrabajoloaddvcombo = new r_balancecomprobacionhojatrabajoloaddvcombo();
         objr_balancecomprobacionhojatrabajoloaddvcombo.AV16ComboName = aP0_ComboName;
         objr_balancecomprobacionhojatrabajoloaddvcombo.AV17Cond_BanCod = aP1_Cond_BanCod;
         objr_balancecomprobacionhojatrabajoloaddvcombo.AV11SearchTxt = aP2_SearchTxt;
         objr_balancecomprobacionhojatrabajoloaddvcombo.AV12Combo_DataJson = "" ;
         objr_balancecomprobacionhojatrabajoloaddvcombo.context.SetSubmitInitialConfig(context);
         objr_balancecomprobacionhojatrabajoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_balancecomprobacionhojatrabajoloaddvcombo);
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_balancecomprobacionhojatrabajoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "CBCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CBCOD' */
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
         /* 'LOADCOMBOITEMS_CBCOD' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11SearchTxt ,
                                              A377CBCod ,
                                              A504CBSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
         /* Using cursor P00D32 */
         pr_default.execute(0, new Object[] {lV11SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504CBSts = P00D32_A504CBSts[0];
            A377CBCod = P00D32_A377CBCod[0];
            A372BanCod = P00D32_A372BanCod[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A377CBCod;
            AV14Combo_DataItem.gxTpr_Title = A377CBCod;
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
         A377CBCod = "";
         P00D32_A504CBSts = new short[1] ;
         P00D32_A377CBCod = new string[] {""} ;
         P00D32_A372BanCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_balancecomprobacionhojatrabajoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00D32_A504CBSts, P00D32_A377CBCod, P00D32_A372BanCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A504CBSts ;
      private int AV17Cond_BanCod ;
      private int AV10MaxItems ;
      private int A372BanCod ;
      private string scmdbuf ;
      private string A377CBCod ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00D32_A504CBSts ;
      private string[] P00D32_A377CBCod ;
      private int[] P00D32_A372BanCod ;
      private string aP3_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class r_balancecomprobacionhojatrabajoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D32( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A377CBCod ,
                                             short A504CBSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CBSts], [CBCod], [BanCod] FROM [TSCUENTABANCO]";
         AddWhere(sWhereString, "([CBSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CBCod] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CBCod]";
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
                     return conditional_P00D32(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
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
          Object[] prmP00D32;
          prmP00D32 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D32,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
