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
   public class auxiliaresloaddvcombo : GXProcedure
   {
      public auxiliaresloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliaresloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_TipACod ,
                           string aP4_TipADCod ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV23TipACod = aP3_TipACod;
         this.AV24TipADCod = aP4_TipADCod;
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
                                int aP3_TipACod ,
                                string aP4_TipADCod ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_TipACod, aP4_TipADCod, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_TipACod ,
                                 string aP4_TipADCod ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         auxiliaresloaddvcombo objauxiliaresloaddvcombo;
         objauxiliaresloaddvcombo = new auxiliaresloaddvcombo();
         objauxiliaresloaddvcombo.AV16ComboName = aP0_ComboName;
         objauxiliaresloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objauxiliaresloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objauxiliaresloaddvcombo.AV23TipACod = aP3_TipACod;
         objauxiliaresloaddvcombo.AV24TipADCod = aP4_TipADCod;
         objauxiliaresloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objauxiliaresloaddvcombo.AV15SelectedValue = "" ;
         objauxiliaresloaddvcombo.AV20SelectedText = "" ;
         objauxiliaresloaddvcombo.AV12Combo_DataJson = "" ;
         objauxiliaresloaddvcombo.context.SetSubmitInitialConfig(context);
         objauxiliaresloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objauxiliaresloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auxiliaresloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipACod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPACOD' */
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
         /* 'LOADCOMBOITEMS_TIPACOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1900TipADsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P006Q2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1900TipADsc = P006Q2_A1900TipADsc[0];
               A70TipACod = P006Q2_A70TipACod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1900TipADsc;
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
               /* Using cursor P006Q3 */
               pr_default.execute(1, new Object[] {AV23TipACod, AV24TipADCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A71TipADCod = P006Q3_A71TipADCod[0];
                  A70TipACod = P006Q3_A70TipACod[0];
                  A1900TipADsc = P006Q3_A1900TipADsc[0];
                  A1900TipADsc = P006Q3_A1900TipADsc[0];
                  AV15SelectedValue = ((0==A70TipACod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0)));
                  AV20SelectedText = A1900TipADsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV23TipACod) )
               {
                  AV15SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23TipACod), 6, 0));
                  /* Using cursor P006Q4 */
                  pr_default.execute(2, new Object[] {AV23TipACod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A70TipACod = P006Q4_A70TipACod[0];
                     A1900TipADsc = P006Q4_A1900TipADsc[0];
                     AV20SelectedText = A1900TipADsc;
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
         A1900TipADsc = "";
         P006Q2_A1900TipADsc = new string[] {""} ;
         P006Q2_A70TipACod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006Q3_A71TipADCod = new string[] {""} ;
         P006Q3_A70TipACod = new int[1] ;
         P006Q3_A1900TipADsc = new string[] {""} ;
         A71TipADCod = "";
         P006Q4_A70TipACod = new int[1] ;
         P006Q4_A1900TipADsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliaresloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006Q2_A1900TipADsc, P006Q2_A70TipACod
               }
               , new Object[] {
               P006Q3_A71TipADCod, P006Q3_A70TipACod, P006Q3_A1900TipADsc
               }
               , new Object[] {
               P006Q4_A70TipACod, P006Q4_A1900TipADsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV23TipACod ;
      private int AV10MaxItems ;
      private int A70TipACod ;
      private string AV18TrnMode ;
      private string AV24TipADCod ;
      private string scmdbuf ;
      private string A1900TipADsc ;
      private string A71TipADCod ;
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
      private string[] P006Q2_A1900TipADsc ;
      private int[] P006Q2_A70TipACod ;
      private string[] P006Q3_A71TipADCod ;
      private int[] P006Q3_A70TipACod ;
      private string[] P006Q3_A1900TipADsc ;
      private int[] P006Q4_A70TipACod ;
      private string[] P006Q4_A1900TipADsc ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class auxiliaresloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Q2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1900TipADsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipADsc], [TipACod] FROM [CBTIPAUXILIAR]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipADsc]";
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
                     return conditional_P006Q2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP006Q3;
          prmP006Q3 = new Object[] {
          new ParDef("@AV23TipACod",GXType.Int32,6,0) ,
          new ParDef("@AV24TipADCod",GXType.NChar,20,0)
          };
          Object[] prmP006Q4;
          prmP006Q4 = new Object[] {
          new ParDef("@AV23TipACod",GXType.Int32,6,0)
          };
          Object[] prmP006Q2;
          prmP006Q2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006Q3", "SELECT T1.[TipADCod], T1.[TipACod], T2.[TipADsc] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod]) WHERE T1.[TipACod] = @AV23TipACod and T1.[TipADCod] = @AV24TipADCod ORDER BY T1.[TipACod], T1.[TipADCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Q4", "SELECT TOP 1 [TipACod], [TipADsc] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @AV23TipACod ORDER BY [TipACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Q4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
