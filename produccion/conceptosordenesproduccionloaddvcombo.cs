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
namespace GeneXus.Programs.produccion {
   public class conceptosordenesproduccionloaddvcombo : GXProcedure
   {
      public conceptosordenesproduccionloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccionloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_PoConcCod ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24PoConcCod = aP3_PoConcCod;
         this.AV11SearchTxt = aP4_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                int aP3_PoConcCod ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_PoConcCod, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_PoConcCod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         conceptosordenesproduccionloaddvcombo objconceptosordenesproduccionloaddvcombo;
         objconceptosordenesproduccionloaddvcombo = new conceptosordenesproduccionloaddvcombo();
         objconceptosordenesproduccionloaddvcombo.AV16ComboName = aP0_ComboName;
         objconceptosordenesproduccionloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objconceptosordenesproduccionloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objconceptosordenesproduccionloaddvcombo.AV24PoConcCod = aP3_PoConcCod;
         objconceptosordenesproduccionloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objconceptosordenesproduccionloaddvcombo.AV15SelectedValue = "" ;
         objconceptosordenesproduccionloaddvcombo.AV20SelectedText = "" ;
         objconceptosordenesproduccionloaddvcombo.AV12Combo_DataJson = "" ;
         objconceptosordenesproduccionloaddvcombo.context.SetSubmitInitialConfig(context);
         objconceptosordenesproduccionloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesproduccionloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesproduccionloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "PoConcDCueCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_POCONCDCUECOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "PoConcLinCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_POCONCLINCOD' */
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
         /* 'LOADCOMBOITEMS_POCONCDCUECOD' Routine */
         returnInSub = false;
         /* Using cursor P006B2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A873CueSts = P006B2_A873CueSts[0];
            A867CueMov = P006B2_A867CueMov[0];
            A2098CueDscCompleto = P006B2_A2098CueDscCompleto[0];
            A91CueCod = P006B2_A91CueCod[0];
            A860CueDsc = P006B2_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_POCONCLINCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1153LinDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P006B3 */
            pr_default.execute(1, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A1153LinDsc = P006B3_A1153LinDsc[0];
               A52LinCod = P006B3_A52LinCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1153LinDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P006B4 */
                  pr_default.execute(2, new Object[] {AV24PoConcCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A313PoConcCod = P006B4_A313PoConcCod[0];
                     A314PoConcLinCod = P006B4_A314PoConcLinCod[0];
                     n314PoConcLinCod = P006B4_n314PoConcLinCod[0];
                     AV15SelectedValue = ((0==A314PoConcLinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A314PoConcLinCod), 6, 0)));
                     AV23LinCod = A314PoConcLinCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
               else
               {
                  AV23LinCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P006B5 */
               pr_default.execute(3, new Object[] {AV23LinCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A52LinCod = P006B5_A52LinCod[0];
                  A1153LinDsc = P006B5_A1153LinDsc[0];
                  AV20SelectedText = A1153LinDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
            }
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
         P006B2_A873CueSts = new short[1] ;
         P006B2_A867CueMov = new short[1] ;
         P006B2_A2098CueDscCompleto = new string[] {""} ;
         P006B2_A91CueCod = new string[] {""} ;
         P006B2_A860CueDsc = new string[] {""} ;
         A2098CueDscCompleto = "";
         A91CueCod = "";
         A860CueDsc = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lV11SearchTxt = "";
         A1153LinDsc = "";
         P006B3_A1153LinDsc = new string[] {""} ;
         P006B3_A52LinCod = new int[1] ;
         P006B4_A313PoConcCod = new int[1] ;
         P006B4_A314PoConcLinCod = new int[1] ;
         P006B4_n314PoConcLinCod = new bool[] {false} ;
         P006B5_A52LinCod = new int[1] ;
         P006B5_A1153LinDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccionloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006B2_A873CueSts, P006B2_A867CueMov, P006B2_A2098CueDscCompleto, P006B2_A91CueCod, P006B2_A860CueDsc
               }
               , new Object[] {
               P006B3_A1153LinDsc, P006B3_A52LinCod
               }
               , new Object[] {
               P006B4_A313PoConcCod, P006B4_A314PoConcLinCod, P006B4_n314PoConcLinCod
               }
               , new Object[] {
               P006B5_A52LinCod, P006B5_A1153LinDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A873CueSts ;
      private short A867CueMov ;
      private int AV24PoConcCod ;
      private int AV10MaxItems ;
      private int A52LinCod ;
      private int A313PoConcCod ;
      private int A314PoConcLinCod ;
      private int AV23LinCod ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A2098CueDscCompleto ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A1153LinDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n314PoConcLinCod ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006B2_A873CueSts ;
      private short[] P006B2_A867CueMov ;
      private string[] P006B2_A2098CueDscCompleto ;
      private string[] P006B2_A91CueCod ;
      private string[] P006B2_A860CueDsc ;
      private string[] P006B3_A1153LinDsc ;
      private int[] P006B3_A52LinCod ;
      private int[] P006B4_A313PoConcCod ;
      private int[] P006B4_A314PoConcLinCod ;
      private bool[] P006B4_n314PoConcLinCod ;
      private int[] P006B5_A52LinCod ;
      private string[] P006B5_A1153LinDsc ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class conceptosordenesproduccionloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006B3( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1153LinDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [LinDsc], [LinCod] FROM [CLINEAPROD]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [LinDsc]";
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
               case 1 :
                     return conditional_P006B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006B2;
          prmP006B2 = new Object[] {
          };
          Object[] prmP006B4;
          prmP006B4 = new Object[] {
          new ParDef("@AV24PoConcCod",GXType.Int32,6,0)
          };
          Object[] prmP006B5;
          prmP006B5 = new Object[] {
          new ParDef("@AV23LinCod",GXType.Int32,6,0)
          };
          Object[] prmP006B3;
          prmP006B3 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006B2", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006B4", "SELECT [PoConcCod], [PoConcLinCod] FROM [POCONCEPTOS] WHERE [PoConcCod] = @AV24PoConcCod ORDER BY [PoConcCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006B5", "SELECT TOP 1 [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV23LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B5,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
