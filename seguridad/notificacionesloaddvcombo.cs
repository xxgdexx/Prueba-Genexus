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
   public class notificacionesloaddvcombo : GXProcedure
   {
      public notificacionesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacionesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           long aP3_SGNotificacionID ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24SGNotificacionID = aP3_SGNotificacionID;
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
                                long aP3_SGNotificacionID ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_SGNotificacionID, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 long aP3_SGNotificacionID ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         notificacionesloaddvcombo objnotificacionesloaddvcombo;
         objnotificacionesloaddvcombo = new notificacionesloaddvcombo();
         objnotificacionesloaddvcombo.AV16ComboName = aP0_ComboName;
         objnotificacionesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objnotificacionesloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objnotificacionesloaddvcombo.AV24SGNotificacionID = aP3_SGNotificacionID;
         objnotificacionesloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objnotificacionesloaddvcombo.AV15SelectedValue = "" ;
         objnotificacionesloaddvcombo.AV20SelectedText = "" ;
         objnotificacionesloaddvcombo.AV12Combo_DataJson = "" ;
         objnotificacionesloaddvcombo.context.SetSubmitInitialConfig(context);
         objnotificacionesloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotificacionesloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificacionesloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "SGNotificacionDetUsuario") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SGNOTIFICACIONDETUSUARIO' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "SGNotificacionUsuario") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SGNOTIFICACIONUSUARIO' */
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
         /* 'LOADCOMBOITEMS_SGNOTIFICACIONDETUSUARIO' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV26ValuesCollection.FromJSonString(AV11SearchTxt, null);
               AV25DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV31GXV1 = 1;
               while ( AV31GXV1 <= AV26ValuesCollection.Count )
               {
                  AV27ValueItem = ((string)AV26ValuesCollection.Item(AV31GXV1));
                  AV28UsuCod_Filter = AV27ValueItem;
                  AV32GXLvl28 = 0;
                  /* Using cursor P007Z2 */
                  pr_default.execute(0, new Object[] {AV28UsuCod_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A348UsuCod = P007Z2_A348UsuCod[0];
                     A2019UsuNom = P007Z2_A2019UsuNom[0];
                     AV32GXLvl28 = 1;
                     AV25DscsCollection.Add(A2019UsuNom, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV32GXLvl28 == 0 )
                  {
                     AV25DscsCollection.Add("", 0);
                  }
                  AV31GXV1 = (int)(AV31GXV1+1);
               }
               AV12Combo_DataJson = AV25DscsCollection.ToJSonString(false);
            }
            else
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV11SearchTxt ,
                                                    A2019UsuNom } ,
                                                    new int[]{
                                                    }
               });
               lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
               /* Using cursor P007Z3 */
               pr_default.execute(1, new Object[] {lV11SearchTxt});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A2019UsuNom = P007Z3_A2019UsuNom[0];
                  A348UsuCod = P007Z3_A348UsuCod[0];
                  AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV14Combo_DataItem.gxTpr_Id = A348UsuCod;
                  AV14Combo_DataItem.gxTpr_Title = A2019UsuNom;
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
         }
         else
         {
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SGNOTIFICACIONUSUARIO' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A2019UsuNom } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P007Z4 */
            pr_default.execute(2, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A2019UsuNom = P007Z4_A2019UsuNom[0];
               A348UsuCod = P007Z4_A348UsuCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A348UsuCod;
               AV14Combo_DataItem.gxTpr_Title = A2019UsuNom;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P007Z5 */
                  pr_default.execute(3, new Object[] {AV24SGNotificacionID});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A2237SGNotificacionID = P007Z5_A2237SGNotificacionID[0];
                     A2241SGNotificacionUsuario = P007Z5_A2241SGNotificacionUsuario[0];
                     AV15SelectedValue = A2241SGNotificacionUsuario;
                     AV23UsuCod = A2241SGNotificacionUsuario;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV23UsuCod = AV11SearchTxt;
               }
               /* Using cursor P007Z6 */
               pr_default.execute(4, new Object[] {AV23UsuCod});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A348UsuCod = P007Z6_A348UsuCod[0];
                  A2019UsuNom = P007Z6_A2019UsuNom[0];
                  AV20SelectedText = A2019UsuNom;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
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
         AV26ValuesCollection = new GxSimpleCollection<string>();
         AV25DscsCollection = new GxSimpleCollection<string>();
         AV27ValueItem = "";
         AV28UsuCod_Filter = "";
         scmdbuf = "";
         P007Z2_A348UsuCod = new string[] {""} ;
         P007Z2_A2019UsuNom = new string[] {""} ;
         A348UsuCod = "";
         A2019UsuNom = "";
         lV11SearchTxt = "";
         P007Z3_A2019UsuNom = new string[] {""} ;
         P007Z3_A348UsuCod = new string[] {""} ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P007Z4_A2019UsuNom = new string[] {""} ;
         P007Z4_A348UsuCod = new string[] {""} ;
         P007Z5_A2237SGNotificacionID = new long[1] ;
         P007Z5_A2241SGNotificacionUsuario = new string[] {""} ;
         A2241SGNotificacionUsuario = "";
         AV23UsuCod = "";
         P007Z6_A348UsuCod = new string[] {""} ;
         P007Z6_A2019UsuNom = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacionesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P007Z2_A348UsuCod, P007Z2_A2019UsuNom
               }
               , new Object[] {
               P007Z3_A2019UsuNom, P007Z3_A348UsuCod
               }
               , new Object[] {
               P007Z4_A2019UsuNom, P007Z4_A348UsuCod
               }
               , new Object[] {
               P007Z5_A2237SGNotificacionID, P007Z5_A2241SGNotificacionUsuario
               }
               , new Object[] {
               P007Z6_A348UsuCod, P007Z6_A2019UsuNom
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV32GXLvl28 ;
      private int AV10MaxItems ;
      private int AV31GXV1 ;
      private long AV24SGNotificacionID ;
      private long A2237SGNotificacionID ;
      private string AV18TrnMode ;
      private string AV28UsuCod_Filter ;
      private string scmdbuf ;
      private string A348UsuCod ;
      private string A2019UsuNom ;
      private string A2241SGNotificacionUsuario ;
      private string AV23UsuCod ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string AV27ValueItem ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007Z2_A348UsuCod ;
      private string[] P007Z2_A2019UsuNom ;
      private string[] P007Z3_A2019UsuNom ;
      private string[] P007Z3_A348UsuCod ;
      private string[] P007Z4_A2019UsuNom ;
      private string[] P007Z4_A348UsuCod ;
      private long[] P007Z5_A2237SGNotificacionID ;
      private string[] P007Z5_A2241SGNotificacionUsuario ;
      private string[] P007Z6_A348UsuCod ;
      private string[] P007Z6_A2019UsuNom ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GxSimpleCollection<string> AV26ValuesCollection ;
      private GxSimpleCollection<string> AV25DscsCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class notificacionesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007Z3( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A2019UsuNom )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UsuNom], [UsuCod] FROM [SGUSUARIOS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([UsuNom] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UsuNom]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007Z4( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A2019UsuNom )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [UsuNom], [UsuCod] FROM [SGUSUARIOS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([UsuNom] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UsuNom]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P007Z3(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P007Z4(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP007Z2;
          prmP007Z2 = new Object[] {
          new ParDef("@AV28UsuCod_Filter",GXType.NChar,10,0)
          };
          Object[] prmP007Z5;
          prmP007Z5 = new Object[] {
          new ParDef("@AV24SGNotificacionID",GXType.Decimal,10,0)
          };
          Object[] prmP007Z6;
          prmP007Z6 = new Object[] {
          new ParDef("@AV23UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP007Z3;
          prmP007Z3 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP007Z4;
          prmP007Z4 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007Z2", "SELECT TOP 1 [UsuCod], [UsuNom] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV28UsuCod_Filter ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Z4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007Z5", "SELECT [SGNotificacionID], [SGNotificacionUsuario] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @AV24SGNotificacionID ORDER BY [SGNotificacionID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z5,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007Z6", "SELECT TOP 1 [UsuCod], [UsuNom] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV23UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007Z6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
