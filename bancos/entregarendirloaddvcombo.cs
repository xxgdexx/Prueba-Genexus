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
namespace GeneXus.Programs.bancos {
   public class entregarendirloaddvcombo : GXProcedure
   {
      public entregarendirloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public entregarendirloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_EntCod ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24EntCod = aP3_EntCod;
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
                                int aP3_EntCod ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_EntCod, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_EntCod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         entregarendirloaddvcombo objentregarendirloaddvcombo;
         objentregarendirloaddvcombo = new entregarendirloaddvcombo();
         objentregarendirloaddvcombo.AV16ComboName = aP0_ComboName;
         objentregarendirloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objentregarendirloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objentregarendirloaddvcombo.AV24EntCod = aP3_EntCod;
         objentregarendirloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objentregarendirloaddvcombo.AV15SelectedValue = "" ;
         objentregarendirloaddvcombo.AV20SelectedText = "" ;
         objentregarendirloaddvcombo.AV12Combo_DataJson = "" ;
         objentregarendirloaddvcombo.context.SetSubmitInitialConfig(context);
         objentregarendirloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objentregarendirloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((entregarendirloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "CueCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUECOD' */
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
         /* 'LOADCOMBOITEMS_CUECOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A860CueDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P005V2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A860CueDsc = P005V2_A860CueDsc[0];
               A91CueCod = P005V2_A91CueCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A91CueCod;
               AV14Combo_DataItem.gxTpr_Title = A860CueDsc;
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
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P005V3 */
                  pr_default.execute(1, new Object[] {AV24EntCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A365EntCod = P005V3_A365EntCod[0];
                     A91CueCod = P005V3_A91CueCod[0];
                     A860CueDsc = P005V3_A860CueDsc[0];
                     A860CueDsc = P005V3_A860CueDsc[0];
                     AV15SelectedValue = A91CueCod;
                     AV20SelectedText = A860CueDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV23CueCod = AV11SearchTxt;
                  /* Using cursor P005V4 */
                  pr_default.execute(2, new Object[] {AV23CueCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A91CueCod = P005V4_A91CueCod[0];
                     A860CueDsc = P005V4_A860CueDsc[0];
                     AV20SelectedText = A860CueDsc;
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
         A860CueDsc = "";
         P005V2_A860CueDsc = new string[] {""} ;
         P005V2_A91CueCod = new string[] {""} ;
         A91CueCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005V3_A365EntCod = new int[1] ;
         P005V3_A91CueCod = new string[] {""} ;
         P005V3_A860CueDsc = new string[] {""} ;
         AV23CueCod = "";
         P005V4_A91CueCod = new string[] {""} ;
         P005V4_A860CueDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendirloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005V2_A860CueDsc, P005V2_A91CueCod
               }
               , new Object[] {
               P005V3_A365EntCod, P005V3_A91CueCod, P005V3_A860CueDsc
               }
               , new Object[] {
               P005V4_A91CueCod, P005V4_A860CueDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV24EntCod ;
      private int AV10MaxItems ;
      private int A365EntCod ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private string AV23CueCod ;
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
      private string[] P005V2_A860CueDsc ;
      private string[] P005V2_A91CueCod ;
      private int[] P005V3_A365EntCod ;
      private string[] P005V3_A91CueCod ;
      private string[] P005V3_A860CueDsc ;
      private string[] P005V4_A91CueCod ;
      private string[] P005V4_A860CueDsc ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class entregarendirloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005V2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
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
                     return conditional_P005V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005V3;
          prmP005V3 = new Object[] {
          new ParDef("@AV24EntCod",GXType.Int32,6,0)
          };
          Object[] prmP005V4;
          prmP005V4 = new Object[] {
          new ParDef("@AV23CueCod",GXType.NChar,15,0)
          };
          Object[] prmP005V2;
          prmP005V2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005V3", "SELECT T1.[EntCod], T1.[CueCod], T2.[CueDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod]) WHERE T1.[EntCod] = @AV24EntCod ORDER BY T1.[EntCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005V4", "SELECT TOP 1 [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV23CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005V4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
