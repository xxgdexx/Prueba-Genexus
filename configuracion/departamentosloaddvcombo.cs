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
   public class departamentosloaddvcombo : GXProcedure
   {
      public departamentosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public departamentosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_PaiCod ,
                           string aP4_EstCod ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV23PaiCod = aP3_PaiCod;
         this.AV24EstCod = aP4_EstCod;
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
                                string aP3_PaiCod ,
                                string aP4_EstCod ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_PaiCod, aP4_EstCod, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_PaiCod ,
                                 string aP4_EstCod ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         departamentosloaddvcombo objdepartamentosloaddvcombo;
         objdepartamentosloaddvcombo = new departamentosloaddvcombo();
         objdepartamentosloaddvcombo.AV16ComboName = aP0_ComboName;
         objdepartamentosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objdepartamentosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objdepartamentosloaddvcombo.AV23PaiCod = aP3_PaiCod;
         objdepartamentosloaddvcombo.AV24EstCod = aP4_EstCod;
         objdepartamentosloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objdepartamentosloaddvcombo.AV15SelectedValue = "" ;
         objdepartamentosloaddvcombo.AV20SelectedText = "" ;
         objdepartamentosloaddvcombo.AV12Combo_DataJson = "" ;
         objdepartamentosloaddvcombo.context.SetSubmitInitialConfig(context);
         objdepartamentosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdepartamentosloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((departamentosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "PaiCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PAICOD' */
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
         /* 'LOADCOMBOITEMS_PAICOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1500PaiDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P003N2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1500PaiDsc = P003N2_A1500PaiDsc[0];
               A139PaiCod = P003N2_A139PaiCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A139PaiCod;
               AV14Combo_DataItem.gxTpr_Title = A1500PaiDsc;
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
               /* Using cursor P003N3 */
               pr_default.execute(1, new Object[] {AV23PaiCod, AV24EstCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A140EstCod = P003N3_A140EstCod[0];
                  A139PaiCod = P003N3_A139PaiCod[0];
                  A1500PaiDsc = P003N3_A1500PaiDsc[0];
                  A1500PaiDsc = P003N3_A1500PaiDsc[0];
                  AV15SelectedValue = A139PaiCod;
                  AV20SelectedText = A1500PaiDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23PaiCod)) )
               {
                  AV15SelectedValue = AV23PaiCod;
                  /* Using cursor P003N4 */
                  pr_default.execute(2, new Object[] {AV23PaiCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A139PaiCod = P003N4_A139PaiCod[0];
                     A1500PaiDsc = P003N4_A1500PaiDsc[0];
                     AV20SelectedText = A1500PaiDsc;
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
         A1500PaiDsc = "";
         P003N2_A1500PaiDsc = new string[] {""} ;
         P003N2_A139PaiCod = new string[] {""} ;
         A139PaiCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P003N3_A140EstCod = new string[] {""} ;
         P003N3_A139PaiCod = new string[] {""} ;
         P003N3_A1500PaiDsc = new string[] {""} ;
         A140EstCod = "";
         P003N4_A139PaiCod = new string[] {""} ;
         P003N4_A1500PaiDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P003N2_A1500PaiDsc, P003N2_A139PaiCod
               }
               , new Object[] {
               P003N3_A140EstCod, P003N3_A139PaiCod, P003N3_A1500PaiDsc
               }
               , new Object[] {
               P003N4_A139PaiCod, P003N4_A1500PaiDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10MaxItems ;
      private string AV18TrnMode ;
      private string AV23PaiCod ;
      private string AV24EstCod ;
      private string scmdbuf ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
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
      private string[] P003N2_A1500PaiDsc ;
      private string[] P003N2_A139PaiCod ;
      private string[] P003N3_A140EstCod ;
      private string[] P003N3_A139PaiCod ;
      private string[] P003N3_A1500PaiDsc ;
      private string[] P003N4_A139PaiCod ;
      private string[] P003N4_A1500PaiDsc ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class departamentosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003N2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PaiDsc], [PaiCod] FROM [CPAISES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaiDsc]";
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
                     return conditional_P003N2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP003N3;
          prmP003N3 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0)
          };
          Object[] prmP003N4;
          prmP003N4 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP003N2;
          prmP003N2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003N3", "SELECT T1.[EstCod], T1.[PaiCod], T2.[PaiDsc] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod]) WHERE T1.[PaiCod] = @AV23PaiCod and T1.[EstCod] = @AV24EstCod ORDER BY T1.[PaiCod], T1.[EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003N4", "SELECT TOP 1 [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV23PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003N4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
