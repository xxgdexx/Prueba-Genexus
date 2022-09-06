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
namespace GeneXus.Programs.seguridad {
   public class usuariosloaddvcombo : GXProcedure
   {
      public usuariosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuariosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_UsuCod ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24UsuCod = aP3_UsuCod;
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
                                string aP3_UsuCod ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_UsuCod, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_UsuCod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         usuariosloaddvcombo objusuariosloaddvcombo;
         objusuariosloaddvcombo = new usuariosloaddvcombo();
         objusuariosloaddvcombo.AV16ComboName = aP0_ComboName;
         objusuariosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objusuariosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objusuariosloaddvcombo.AV24UsuCod = aP3_UsuCod;
         objusuariosloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objusuariosloaddvcombo.AV15SelectedValue = "" ;
         objusuariosloaddvcombo.AV20SelectedText = "" ;
         objusuariosloaddvcombo.AV12Combo_DataJson = "" ;
         objusuariosloaddvcombo.context.SetSubmitInitialConfig(context);
         objusuariosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuariosloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuariosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "UsuTieCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUTIECOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "AreCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ARECOD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "UsuVend") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUVEND' */
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
         /* 'LOADCOMBOITEMS_USUTIECOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1898TieDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00602 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1898TieDsc = P00602_A1898TieDsc[0];
               A178TieCod = P00602_A178TieCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A178TieCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1898TieDsc;
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
                  /* Using cursor P00603 */
                  pr_default.execute(1, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A348UsuCod = P00603_A348UsuCod[0];
                     A2040UsuTieCod = P00603_A2040UsuTieCod[0];
                     AV15SelectedValue = ((0==A2040UsuTieCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2040UsuTieCod), 6, 0)));
                     AV25TieCod = A2040UsuTieCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV25TieCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P00604 */
               pr_default.execute(2, new Object[] {AV25TieCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A178TieCod = P00604_A178TieCod[0];
                  A1898TieDsc = P00604_A1898TieDsc[0];
                  AV20SelectedText = A1898TieDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_ARECOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A474AreDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00605 */
            pr_default.execute(3, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A474AreDsc = P00605_A474AreDsc[0];
               A69AreCod = P00605_A69AreCod[0];
               n69AreCod = P00605_n69AreCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A69AreCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A474AreDsc;
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
                  /* Using cursor P00606 */
                  pr_default.execute(4, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A348UsuCod = P00606_A348UsuCod[0];
                     A69AreCod = P00606_A69AreCod[0];
                     n69AreCod = P00606_n69AreCod[0];
                     A474AreDsc = P00606_A474AreDsc[0];
                     A474AreDsc = P00606_A474AreDsc[0];
                     AV15SelectedValue = ((0==A69AreCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A69AreCod), 6, 0)));
                     AV20SelectedText = A474AreDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV23AreCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00607 */
                  pr_default.execute(5, new Object[] {AV23AreCod});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A69AreCod = P00607_A69AreCod[0];
                     n69AreCod = P00607_n69AreCod[0];
                     A474AreDsc = P00607_A474AreDsc[0];
                     AV20SelectedText = A474AreDsc;
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
         /* 'LOADCOMBOITEMS_USUVEND' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A2045VenDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00608 */
            pr_default.execute(6, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A2045VenDsc = P00608_A2045VenDsc[0];
               A309VenCod = P00608_A309VenCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A2045VenDsc;
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
                  /* Using cursor P00609 */
                  pr_default.execute(7, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A348UsuCod = P00609_A348UsuCod[0];
                     A2041UsuVend = P00609_A2041UsuVend[0];
                     AV15SelectedValue = ((0==A2041UsuVend) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2041UsuVend), 6, 0)));
                     AV26VenCod = A2041UsuVend;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV26VenCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P006010 */
               pr_default.execute(8, new Object[] {AV26VenCod});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A309VenCod = P006010_A309VenCod[0];
                  A2045VenDsc = P006010_A2045VenDsc[0];
                  AV20SelectedText = A2045VenDsc;
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
         A1898TieDsc = "";
         P00602_A1898TieDsc = new string[] {""} ;
         P00602_A178TieCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00603_A348UsuCod = new string[] {""} ;
         P00603_A2040UsuTieCod = new int[1] ;
         A348UsuCod = "";
         P00604_A178TieCod = new int[1] ;
         P00604_A1898TieDsc = new string[] {""} ;
         A474AreDsc = "";
         P00605_A474AreDsc = new string[] {""} ;
         P00605_A69AreCod = new int[1] ;
         P00605_n69AreCod = new bool[] {false} ;
         P00606_A348UsuCod = new string[] {""} ;
         P00606_A69AreCod = new int[1] ;
         P00606_n69AreCod = new bool[] {false} ;
         P00606_A474AreDsc = new string[] {""} ;
         P00607_A69AreCod = new int[1] ;
         P00607_n69AreCod = new bool[] {false} ;
         P00607_A474AreDsc = new string[] {""} ;
         A2045VenDsc = "";
         P00608_A2045VenDsc = new string[] {""} ;
         P00608_A309VenCod = new int[1] ;
         P00609_A348UsuCod = new string[] {""} ;
         P00609_A2041UsuVend = new int[1] ;
         P006010_A309VenCod = new int[1] ;
         P006010_A2045VenDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00602_A1898TieDsc, P00602_A178TieCod
               }
               , new Object[] {
               P00603_A348UsuCod, P00603_A2040UsuTieCod
               }
               , new Object[] {
               P00604_A178TieCod, P00604_A1898TieDsc
               }
               , new Object[] {
               P00605_A474AreDsc, P00605_A69AreCod
               }
               , new Object[] {
               P00606_A348UsuCod, P00606_A69AreCod, P00606_n69AreCod, P00606_A474AreDsc
               }
               , new Object[] {
               P00607_A69AreCod, P00607_A474AreDsc
               }
               , new Object[] {
               P00608_A2045VenDsc, P00608_A309VenCod
               }
               , new Object[] {
               P00609_A348UsuCod, P00609_A2041UsuVend
               }
               , new Object[] {
               P006010_A309VenCod, P006010_A2045VenDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10MaxItems ;
      private int A178TieCod ;
      private int A2040UsuTieCod ;
      private int AV25TieCod ;
      private int A69AreCod ;
      private int AV23AreCod ;
      private int A309VenCod ;
      private int A2041UsuVend ;
      private int AV26VenCod ;
      private string AV18TrnMode ;
      private string AV24UsuCod ;
      private string scmdbuf ;
      private string A1898TieDsc ;
      private string A348UsuCod ;
      private string A2045VenDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n69AreCod ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private string A474AreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00602_A1898TieDsc ;
      private int[] P00602_A178TieCod ;
      private string[] P00603_A348UsuCod ;
      private int[] P00603_A2040UsuTieCod ;
      private int[] P00604_A178TieCod ;
      private string[] P00604_A1898TieDsc ;
      private string[] P00605_A474AreDsc ;
      private int[] P00605_A69AreCod ;
      private bool[] P00605_n69AreCod ;
      private string[] P00606_A348UsuCod ;
      private int[] P00606_A69AreCod ;
      private bool[] P00606_n69AreCod ;
      private string[] P00606_A474AreDsc ;
      private int[] P00607_A69AreCod ;
      private bool[] P00607_n69AreCod ;
      private string[] P00607_A474AreDsc ;
      private string[] P00608_A2045VenDsc ;
      private int[] P00608_A309VenCod ;
      private string[] P00609_A348UsuCod ;
      private int[] P00609_A2041UsuVend ;
      private int[] P006010_A309VenCod ;
      private string[] P006010_A2045VenDsc ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class usuariosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00602( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1898TieDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TieDsc], [TieCod] FROM [SGTIENDAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TieDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00605( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A474AreDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [AreDsc], [AreCod] FROM [CAREAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AreDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00608( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A2045VenDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [VenDsc], [VenCod] FROM [CVENDEDORES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VenDsc]";
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
                     return conditional_P00602(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00605(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P00608(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00603;
          prmP00603 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP00604;
          prmP00604 = new Object[] {
          new ParDef("@AV25TieCod",GXType.Int32,6,0)
          };
          Object[] prmP00606;
          prmP00606 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP00607;
          prmP00607 = new Object[] {
          new ParDef("@AV23AreCod",GXType.Int32,6,0)
          };
          Object[] prmP00609;
          prmP00609 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP006010;
          prmP006010 = new Object[] {
          new ParDef("@AV26VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00602;
          prmP00602 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00605;
          prmP00605 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00608;
          prmP00608 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00602", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00602,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00603", "SELECT [UsuCod], [UsuTieCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00603,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00604", "SELECT TOP 1 [TieCod], [TieDsc] FROM [SGTIENDAS] WHERE [TieCod] = @AV25TieCod ORDER BY [TieCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00604,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00605", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00605,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00606", "SELECT T1.[UsuCod], T1.[AreCod], T2.[AreDsc] FROM ([SGUSUARIOS] T1 LEFT JOIN [CAREAS] T2 ON T2.[AreCod] = T1.[AreCod]) WHERE T1.[UsuCod] = @AV24UsuCod ORDER BY T1.[UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00606,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00607", "SELECT TOP 1 [AreCod], [AreDsc] FROM [CAREAS] WHERE [AreCod] = @AV23AreCod ORDER BY [AreCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00607,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00608", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00608,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00609", "SELECT [UsuCod], [UsuVend] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00609,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006010", "SELECT TOP 1 [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV26VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006010,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
