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
   public class cuentabancosloaddvcombo : GXProcedure
   {
      public cuentabancosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_BanCod ,
                           string aP4_CBCod ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV25BanCod = aP3_BanCod;
         this.AV26CBCod = aP4_CBCod;
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
                                int aP3_BanCod ,
                                string aP4_CBCod ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_BanCod, aP4_CBCod, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_BanCod ,
                                 string aP4_CBCod ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         cuentabancosloaddvcombo objcuentabancosloaddvcombo;
         objcuentabancosloaddvcombo = new cuentabancosloaddvcombo();
         objcuentabancosloaddvcombo.AV16ComboName = aP0_ComboName;
         objcuentabancosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objcuentabancosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objcuentabancosloaddvcombo.AV25BanCod = aP3_BanCod;
         objcuentabancosloaddvcombo.AV26CBCod = aP4_CBCod;
         objcuentabancosloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objcuentabancosloaddvcombo.AV15SelectedValue = "" ;
         objcuentabancosloaddvcombo.AV20SelectedText = "" ;
         objcuentabancosloaddvcombo.AV12Combo_DataJson = "" ;
         objcuentabancosloaddvcombo.context.SetSubmitInitialConfig(context);
         objcuentabancosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcuentabancosloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cuentabancosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "BanCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_BANCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "MonCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MONCOD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CBCueCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CBCUECOD' */
            S131 ();
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
         /* 'LOADCOMBOITEMS_BANCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A482BanDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P005F2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A482BanDsc = P005F2_A482BanDsc[0];
               A372BanCod = P005F2_A372BanCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A482BanDsc;
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
               /* Using cursor P005F3 */
               pr_default.execute(1, new Object[] {AV25BanCod, AV26CBCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A377CBCod = P005F3_A377CBCod[0];
                  A372BanCod = P005F3_A372BanCod[0];
                  A482BanDsc = P005F3_A482BanDsc[0];
                  A482BanDsc = P005F3_A482BanDsc[0];
                  AV15SelectedValue = ((0==A372BanCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 6, 0)));
                  AV20SelectedText = A482BanDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! (0==AV25BanCod) )
               {
                  AV15SelectedValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25BanCod), 6, 0));
                  /* Using cursor P005F4 */
                  pr_default.execute(2, new Object[] {AV25BanCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A372BanCod = P005F4_A372BanCod[0];
                     A482BanDsc = P005F4_A482BanDsc[0];
                     AV20SelectedText = A482BanDsc;
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
         /* 'LOADCOMBOITEMS_MONCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1234MonDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P005F5 */
            pr_default.execute(3, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A1234MonDsc = P005F5_A1234MonDsc[0];
               A180MonCod = P005F5_A180MonCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1234MonDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P005F6 */
                  pr_default.execute(4, new Object[] {AV25BanCod, AV26CBCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A377CBCod = P005F6_A377CBCod[0];
                     A372BanCod = P005F6_A372BanCod[0];
                     A180MonCod = P005F6_A180MonCod[0];
                     A1234MonDsc = P005F6_A1234MonDsc[0];
                     A1234MonDsc = P005F6_A1234MonDsc[0];
                     AV15SelectedValue = ((0==A180MonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0)));
                     AV20SelectedText = A1234MonDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV23MonCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P005F7 */
                  pr_default.execute(5, new Object[] {AV23MonCod});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A180MonCod = P005F7_A180MonCod[0];
                     A1234MonDsc = P005F7_A1234MonDsc[0];
                     AV20SelectedText = A1234MonDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_CBCUECOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A860CueDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P005F8 */
            pr_default.execute(6, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A860CueDsc = P005F8_A860CueDsc[0];
               A91CueCod = P005F8_A91CueCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A91CueCod;
               AV14Combo_DataItem.gxTpr_Title = A860CueDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P005F9 */
                  pr_default.execute(7, new Object[] {AV25BanCod, AV26CBCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A377CBCod = P005F9_A377CBCod[0];
                     A372BanCod = P005F9_A372BanCod[0];
                     A378CBCueCod = P005F9_A378CBCueCod[0];
                     AV15SelectedValue = A378CBCueCod;
                     AV24CueCod = A378CBCueCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV24CueCod = AV11SearchTxt;
               }
               /* Using cursor P005F10 */
               pr_default.execute(8, new Object[] {AV24CueCod});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A91CueCod = P005F10_A91CueCod[0];
                  A860CueDsc = P005F10_A860CueDsc[0];
                  AV20SelectedText = A860CueDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(8);
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
         A482BanDsc = "";
         P005F2_A482BanDsc = new string[] {""} ;
         P005F2_A372BanCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P005F3_A377CBCod = new string[] {""} ;
         P005F3_A372BanCod = new int[1] ;
         P005F3_A482BanDsc = new string[] {""} ;
         A377CBCod = "";
         P005F4_A372BanCod = new int[1] ;
         P005F4_A482BanDsc = new string[] {""} ;
         A1234MonDsc = "";
         P005F5_A1234MonDsc = new string[] {""} ;
         P005F5_A180MonCod = new int[1] ;
         P005F6_A377CBCod = new string[] {""} ;
         P005F6_A372BanCod = new int[1] ;
         P005F6_A180MonCod = new int[1] ;
         P005F6_A1234MonDsc = new string[] {""} ;
         P005F7_A180MonCod = new int[1] ;
         P005F7_A1234MonDsc = new string[] {""} ;
         A860CueDsc = "";
         P005F8_A860CueDsc = new string[] {""} ;
         P005F8_A91CueCod = new string[] {""} ;
         A91CueCod = "";
         P005F9_A377CBCod = new string[] {""} ;
         P005F9_A372BanCod = new int[1] ;
         P005F9_A378CBCueCod = new string[] {""} ;
         A378CBCueCod = "";
         AV24CueCod = "";
         P005F10_A91CueCod = new string[] {""} ;
         P005F10_A860CueDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P005F2_A482BanDsc, P005F2_A372BanCod
               }
               , new Object[] {
               P005F3_A377CBCod, P005F3_A372BanCod, P005F3_A482BanDsc
               }
               , new Object[] {
               P005F4_A372BanCod, P005F4_A482BanDsc
               }
               , new Object[] {
               P005F5_A1234MonDsc, P005F5_A180MonCod
               }
               , new Object[] {
               P005F6_A377CBCod, P005F6_A372BanCod, P005F6_A180MonCod, P005F6_A1234MonDsc
               }
               , new Object[] {
               P005F7_A180MonCod, P005F7_A1234MonDsc
               }
               , new Object[] {
               P005F8_A860CueDsc, P005F8_A91CueCod
               }
               , new Object[] {
               P005F9_A377CBCod, P005F9_A372BanCod, P005F9_A378CBCueCod
               }
               , new Object[] {
               P005F10_A91CueCod, P005F10_A860CueDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV25BanCod ;
      private int AV10MaxItems ;
      private int A372BanCod ;
      private int A180MonCod ;
      private int AV23MonCod ;
      private string AV18TrnMode ;
      private string AV26CBCod ;
      private string scmdbuf ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private string A378CBCueCod ;
      private string AV24CueCod ;
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
      private string[] P005F2_A482BanDsc ;
      private int[] P005F2_A372BanCod ;
      private string[] P005F3_A377CBCod ;
      private int[] P005F3_A372BanCod ;
      private string[] P005F3_A482BanDsc ;
      private int[] P005F4_A372BanCod ;
      private string[] P005F4_A482BanDsc ;
      private string[] P005F5_A1234MonDsc ;
      private int[] P005F5_A180MonCod ;
      private string[] P005F6_A377CBCod ;
      private int[] P005F6_A372BanCod ;
      private int[] P005F6_A180MonCod ;
      private string[] P005F6_A1234MonDsc ;
      private int[] P005F7_A180MonCod ;
      private string[] P005F7_A1234MonDsc ;
      private string[] P005F8_A860CueDsc ;
      private string[] P005F8_A91CueCod ;
      private string[] P005F9_A377CBCod ;
      private int[] P005F9_A372BanCod ;
      private string[] P005F9_A378CBCueCod ;
      private string[] P005F10_A91CueCod ;
      private string[] P005F10_A860CueDsc ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class cuentabancosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005F2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A482BanDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [BanDsc], [BanCod] FROM [TSBANCOS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005F5( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1234MonDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MonDsc], [MonCod] FROM [CMONEDAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MonDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005F8( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P005F5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P005F8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005F3;
          prmP005F3 = new Object[] {
          new ParDef("@AV25BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV26CBCod",GXType.NChar,20,0)
          };
          Object[] prmP005F4;
          prmP005F4 = new Object[] {
          new ParDef("@AV25BanCod",GXType.Int32,6,0)
          };
          Object[] prmP005F6;
          prmP005F6 = new Object[] {
          new ParDef("@AV25BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV26CBCod",GXType.NChar,20,0)
          };
          Object[] prmP005F7;
          prmP005F7 = new Object[] {
          new ParDef("@AV23MonCod",GXType.Int32,6,0)
          };
          Object[] prmP005F9;
          prmP005F9 = new Object[] {
          new ParDef("@AV25BanCod",GXType.Int32,6,0) ,
          new ParDef("@AV26CBCod",GXType.NChar,20,0)
          };
          Object[] prmP005F10;
          prmP005F10 = new Object[] {
          new ParDef("@AV24CueCod",GXType.NChar,15,0)
          };
          Object[] prmP005F2;
          prmP005F2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP005F5;
          prmP005F5 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP005F8;
          prmP005F8 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005F3", "SELECT T1.[CBCod], T1.[BanCod], T2.[BanDsc] FROM ([TSCUENTABANCO] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod]) WHERE T1.[BanCod] = @AV25BanCod and T1.[CBCod] = @AV26CBCod ORDER BY T1.[BanCod], T1.[CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005F4", "SELECT TOP 1 [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV25BanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005F6", "SELECT T1.[CBCod], T1.[BanCod], T1.[MonCod], T2.[MonDsc] FROM ([TSCUENTABANCO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) WHERE T1.[BanCod] = @AV25BanCod and T1.[CBCod] = @AV26CBCod ORDER BY T1.[BanCod], T1.[CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005F7", "SELECT TOP 1 [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = @AV23MonCod ORDER BY [MonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005F8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P005F9", "SELECT [CBCod], [BanCod], [CBCueCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @AV25BanCod and [CBCod] = @AV26CBCod ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P005F10", "SELECT TOP 1 [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV24CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005F10,1, GxCacheFrequency.OFF ,false,true )
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
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
