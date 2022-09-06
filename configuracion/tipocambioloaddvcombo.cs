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
   public class tipocambioloaddvcombo : GXProcedure
   {
      public tipocambioloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambioloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_TipMonCod ,
                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP4_TipFech ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24TipMonCod = aP3_TipMonCod;
         this.AV25TipFech = aP4_TipFech;
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
                                int aP3_TipMonCod ,
                                DateTime aP4_TipFech ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_TipMonCod, aP4_TipFech, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_TipMonCod ,
                                 DateTime aP4_TipFech ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         tipocambioloaddvcombo objtipocambioloaddvcombo;
         objtipocambioloaddvcombo = new tipocambioloaddvcombo();
         objtipocambioloaddvcombo.AV16ComboName = aP0_ComboName;
         objtipocambioloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objtipocambioloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objtipocambioloaddvcombo.AV24TipMonCod = aP3_TipMonCod;
         objtipocambioloaddvcombo.AV25TipFech = aP4_TipFech;
         objtipocambioloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objtipocambioloaddvcombo.AV15SelectedValue = "" ;
         objtipocambioloaddvcombo.AV20SelectedText = "" ;
         objtipocambioloaddvcombo.AV12Combo_DataJson = "" ;
         objtipocambioloaddvcombo.context.SetSubmitInitialConfig(context);
         objtipocambioloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipocambioloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipocambioloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipMonCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPMONCOD' */
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
         /* 'LOADCOMBOITEMS_TIPMONCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1234MonDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00532 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1234MonDsc = P00532_A1234MonDsc[0];
               A180MonCod = P00532_A180MonCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1234MonDsc;
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
               /* Using cursor P00533 */
               pr_default.execute(1, new Object[] {AV24TipMonCod, AV25TipFech});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A308TipFech = P00533_A308TipFech[0];
                  A307TipMonCod = P00533_A307TipMonCod[0];
                  AV15SelectedValue = ((0==A307TipMonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A307TipMonCod), 6, 0)));
                  AV23MonCod = A307TipMonCod;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
               /* Using cursor P00534 */
               pr_default.execute(2, new Object[] {AV23MonCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A180MonCod = P00534_A180MonCod[0];
                  A1234MonDsc = P00534_A1234MonDsc[0];
                  AV20SelectedText = A1234MonDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
            else
            {
               if ( ! (0==AV24TipMonCod) )
               {
                  AV15SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24TipMonCod), 6, 0));
                  /* Using cursor P00535 */
                  pr_default.execute(3, new Object[] {AV24TipMonCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A180MonCod = P00535_A180MonCod[0];
                     A1234MonDsc = P00535_A1234MonDsc[0];
                     AV20SelectedText = A1234MonDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
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
         lV11SearchTxt = "";
         A1234MonDsc = "";
         P00532_A1234MonDsc = new string[] {""} ;
         P00532_A180MonCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00533_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         P00533_A307TipMonCod = new int[1] ;
         A308TipFech = DateTime.MinValue;
         P00534_A180MonCod = new int[1] ;
         P00534_A1234MonDsc = new string[] {""} ;
         P00535_A180MonCod = new int[1] ;
         P00535_A1234MonDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambioloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00532_A1234MonDsc, P00532_A180MonCod
               }
               , new Object[] {
               P00533_A308TipFech, P00533_A307TipMonCod
               }
               , new Object[] {
               P00534_A180MonCod, P00534_A1234MonDsc
               }
               , new Object[] {
               P00535_A180MonCod, P00535_A1234MonDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV24TipMonCod ;
      private int AV10MaxItems ;
      private int A180MonCod ;
      private int A307TipMonCod ;
      private int AV23MonCod ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A1234MonDsc ;
      private DateTime AV25TipFech ;
      private DateTime A308TipFech ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00532_A1234MonDsc ;
      private int[] P00532_A180MonCod ;
      private DateTime[] P00533_A308TipFech ;
      private int[] P00533_A307TipMonCod ;
      private int[] P00534_A180MonCod ;
      private string[] P00534_A1234MonDsc ;
      private int[] P00535_A180MonCod ;
      private string[] P00535_A1234MonDsc ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class tipocambioloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00532( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1234MonDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MonDsc], [MonCod] FROM [CMONEDAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MonDsc]";
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
                     return conditional_P00532(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00533;
          prmP00533 = new Object[] {
          new ParDef("@AV24TipMonCod",GXType.Int32,6,0) ,
          new ParDef("@AV25TipFech",GXType.Date,8,0)
          };
          Object[] prmP00534;
          prmP00534 = new Object[] {
          new ParDef("@AV23MonCod",GXType.Int32,6,0)
          };
          Object[] prmP00535;
          prmP00535 = new Object[] {
          new ParDef("@AV24TipMonCod",GXType.Int32,6,0)
          };
          Object[] prmP00532;
          prmP00532 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00532", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00532,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00533", "SELECT [TipFech], [TipMonCod] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @AV24TipMonCod and [TipFech] = @AV25TipFech ORDER BY [TipMonCod], [TipFech] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00533,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00534", "SELECT TOP 1 [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV23MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00534,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00535", "SELECT TOP 1 [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV24TipMonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00535,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
