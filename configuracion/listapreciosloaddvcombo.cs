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
namespace GeneXus.Programs.configuracion {
   public class listapreciosloaddvcombo : GXProcedure
   {
      public listapreciosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listapreciosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_TipLCod ,
                           int aP4_TipLItem ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV25TipLCod = aP3_TipLCod;
         this.AV26TipLItem = aP4_TipLItem;
         this.AV11SearchTxt = aP5_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_TipLCod ,
                                int aP4_TipLItem ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_TipLCod, aP4_TipLItem, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_TipLCod ,
                                 int aP4_TipLItem ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         listapreciosloaddvcombo objlistapreciosloaddvcombo;
         objlistapreciosloaddvcombo = new listapreciosloaddvcombo();
         objlistapreciosloaddvcombo.AV16ComboName = aP0_ComboName;
         objlistapreciosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objlistapreciosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objlistapreciosloaddvcombo.AV25TipLCod = aP3_TipLCod;
         objlistapreciosloaddvcombo.AV26TipLItem = aP4_TipLItem;
         objlistapreciosloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objlistapreciosloaddvcombo.AV15SelectedValue = "" ;
         objlistapreciosloaddvcombo.AV20SelectedText = "" ;
         objlistapreciosloaddvcombo.AV12Combo_DataJson = "" ;
         objlistapreciosloaddvcombo.context.SetSubmitInitialConfig(context);
         objlistapreciosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistapreciosloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listapreciosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipLCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPLCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CliCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLICOD' */
            S121 ();
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
         /* 'LOADCOMBOITEMS_TIPLCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1912TipLDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P004L2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1912TipLDsc = P004L2_A1912TipLDsc[0];
               A202TipLCod = P004L2_A202TipLCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A202TipLCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1912TipLDsc;
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
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               /* Using cursor P004L3 */
               pr_default.execute(1, new Object[] {AV25TipLCod, AV26TipLItem});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A203TipLItem = P004L3_A203TipLItem[0];
                  A202TipLCod = P004L3_A202TipLCod[0];
                  A1912TipLDsc = P004L3_A1912TipLDsc[0];
                  A1912TipLDsc = P004L3_A1912TipLDsc[0];
                  AV15SelectedValue = ((0==A202TipLCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A202TipLCod), 6, 0)));
                  AV20SelectedText = A1912TipLDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV25TipLCod) )
               {
                  AV15SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25TipLCod), 6, 0));
                  /* Using cursor P004L4 */
                  pr_default.execute(2, new Object[] {AV25TipLCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A202TipLCod = P004L4_A202TipLCod[0];
                     A1912TipLDsc = P004L4_A1912TipLDsc[0];
                     AV20SelectedText = A1912TipLDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_CLICOD' Routine */
         returnInSub = false;
         /* Using cursor P004L5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A627CliSts = P004L5_A627CliSts[0];
            A45CliCod = P004L5_A45CliCod[0];
            n45CliCod = P004L5_n45CliCod[0];
            A161CliDsc = P004L5_A161CliDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A45CliCod;
            AV14Combo_DataItem.gxTpr_Title = A161CliDsc;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P004L6 */
            pr_default.execute(4, new Object[] {AV25TipLCod, AV26TipLItem});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A203TipLItem = P004L6_A203TipLItem[0];
               A202TipLCod = P004L6_A202TipLCod[0];
               A45CliCod = P004L6_A45CliCod[0];
               n45CliCod = P004L6_n45CliCod[0];
               AV15SelectedValue = A45CliCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
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
         AV15SelectedValue = "";
         AV20SelectedText = "";
         AV12Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         lV11SearchTxt = "";
         A1912TipLDsc = "";
         P004L2_A1912TipLDsc = new string[] {""} ;
         P004L2_A202TipLCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P004L3_A203TipLItem = new int[1] ;
         P004L3_A202TipLCod = new int[1] ;
         P004L3_A1912TipLDsc = new string[] {""} ;
         P004L4_A202TipLCod = new int[1] ;
         P004L4_A1912TipLDsc = new string[] {""} ;
         P004L5_A627CliSts = new short[1] ;
         P004L5_A45CliCod = new string[] {""} ;
         P004L5_n45CliCod = new bool[] {false} ;
         P004L5_A161CliDsc = new string[] {""} ;
         A45CliCod = "";
         A161CliDsc = "";
         P004L6_A203TipLItem = new int[1] ;
         P004L6_A202TipLCod = new int[1] ;
         P004L6_A45CliCod = new string[] {""} ;
         P004L6_n45CliCod = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listapreciosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004L2_A1912TipLDsc, P004L2_A202TipLCod
               }
               , new Object[] {
               P004L3_A203TipLItem, P004L3_A202TipLCod, P004L3_A1912TipLDsc
               }
               , new Object[] {
               P004L4_A202TipLCod, P004L4_A1912TipLDsc
               }
               , new Object[] {
               P004L5_A627CliSts, P004L5_A45CliCod, P004L5_A161CliDsc
               }
               , new Object[] {
               P004L6_A203TipLItem, P004L6_A202TipLCod, P004L6_A45CliCod, P004L6_n45CliCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A627CliSts ;
      private int AV25TipLCod ;
      private int AV26TipLItem ;
      private int AV10MaxItems ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A1912TipLDsc ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n45CliCod ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004L2_A1912TipLDsc ;
      private int[] P004L2_A202TipLCod ;
      private int[] P004L3_A203TipLItem ;
      private int[] P004L3_A202TipLCod ;
      private string[] P004L3_A1912TipLDsc ;
      private int[] P004L4_A202TipLCod ;
      private string[] P004L4_A1912TipLDsc ;
      private short[] P004L5_A627CliSts ;
      private string[] P004L5_A45CliCod ;
      private bool[] P004L5_n45CliCod ;
      private string[] P004L5_A161CliDsc ;
      private int[] P004L6_A203TipLItem ;
      private int[] P004L6_A202TipLCod ;
      private string[] P004L6_A45CliCod ;
      private bool[] P004L6_n45CliCod ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class listapreciosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004L2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1912TipLDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipLDsc], [TipLCod] FROM [CTIPOSLISTAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipLDsc]";
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
                     return conditional_P004L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004L3;
          prmP004L3 = new Object[] {
          new ParDef("@AV25TipLCod",GXType.Int32,6,0) ,
          new ParDef("@AV26TipLItem",GXType.Int32,6,0)
          };
          Object[] prmP004L4;
          prmP004L4 = new Object[] {
          new ParDef("@AV25TipLCod",GXType.Int32,6,0)
          };
          Object[] prmP004L5;
          prmP004L5 = new Object[] {
          };
          Object[] prmP004L6;
          prmP004L6 = new Object[] {
          new ParDef("@AV25TipLCod",GXType.Int32,6,0) ,
          new ParDef("@AV26TipLItem",GXType.Int32,6,0)
          };
          Object[] prmP004L2;
          prmP004L2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004L3", "SELECT T1.[TipLItem], T1.[TipLCod], T2.[TipLDsc] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod]) WHERE T1.[TipLCod] = @AV25TipLCod and T1.[TipLItem] = @AV26TipLItem ORDER BY T1.[TipLCod], T1.[TipLItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004L4", "SELECT TOP 1 [TipLCod], [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @AV25TipLCod ORDER BY [TipLCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P004L5", "SELECT [CliSts], [CliCod], [CliDsc] FROM [CLCLIENTES] WHERE [CliSts] = 1 ORDER BY [CliDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004L6", "SELECT [TipLItem], [TipLCod], [CliCod] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @AV25TipLCod and [TipLItem] = @AV26TipLItem ORDER BY [TipLCod], [TipLItem] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004L6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
