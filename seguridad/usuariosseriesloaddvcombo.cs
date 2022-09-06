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
   public class usuariosseriesloaddvcombo : GXProcedure
   {
      public usuariosseriesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuariosseriesloaddvcombo( IGxContext context )
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
         this.AV23UsuCod = aP3_UsuCod;
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
         usuariosseriesloaddvcombo objusuariosseriesloaddvcombo;
         objusuariosseriesloaddvcombo = new usuariosseriesloaddvcombo();
         objusuariosseriesloaddvcombo.AV16ComboName = aP0_ComboName;
         objusuariosseriesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objusuariosseriesloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objusuariosseriesloaddvcombo.AV23UsuCod = aP3_UsuCod;
         objusuariosseriesloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objusuariosseriesloaddvcombo.AV15SelectedValue = "" ;
         objusuariosseriesloaddvcombo.AV20SelectedText = "" ;
         objusuariosseriesloaddvcombo.AV12Combo_DataJson = "" ;
         objusuariosseriesloaddvcombo.context.SetSubmitInitialConfig(context);
         objusuariosseriesloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuariosseriesloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuariosseriesloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPCOD' */
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
         /* 'LOADCOMBOITEMS_TIPCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV25ValuesCollection.FromJSonString(AV11SearchTxt, null);
               AV24DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV30GXV1 = 1;
               while ( AV30GXV1 <= AV25ValuesCollection.Count )
               {
                  AV26ValueItem = ((string)AV25ValuesCollection.Item(AV30GXV1));
                  AV27TipCod_Filter = AV26ValueItem;
                  AV31GXLvl26 = 0;
                  /* Using cursor P00612 */
                  pr_default.execute(0, new Object[] {AV27TipCod_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A149TipCod = P00612_A149TipCod[0];
                     A1910TipDsc = P00612_A1910TipDsc[0];
                     AV31GXLvl26 = 1;
                     AV24DscsCollection.Add(A1910TipDsc, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV31GXLvl26 == 0 )
                  {
                     AV24DscsCollection.Add("", 0);
                  }
                  AV30GXV1 = (int)(AV30GXV1+1);
               }
               AV12Combo_DataJson = AV24DscsCollection.ToJSonString(false);
            }
            else
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV11SearchTxt ,
                                                    A1910TipDsc } ,
                                                    new int[]{
                                                    }
               });
               lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
               /* Using cursor P00613 */
               pr_default.execute(1, new Object[] {lV11SearchTxt});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A1910TipDsc = P00613_A1910TipDsc[0];
                  A149TipCod = P00613_A149TipCod[0];
                  AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV14Combo_DataItem.gxTpr_Id = A149TipCod;
                  AV14Combo_DataItem.gxTpr_Title = A1910TipDsc;
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
         AV25ValuesCollection = new GxSimpleCollection<string>();
         AV24DscsCollection = new GxSimpleCollection<string>();
         AV26ValueItem = "";
         AV27TipCod_Filter = "";
         scmdbuf = "";
         P00612_A149TipCod = new string[] {""} ;
         P00612_A1910TipDsc = new string[] {""} ;
         A149TipCod = "";
         A1910TipDsc = "";
         lV11SearchTxt = "";
         P00613_A1910TipDsc = new string[] {""} ;
         P00613_A149TipCod = new string[] {""} ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosseriesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00612_A149TipCod, P00612_A1910TipDsc
               }
               , new Object[] {
               P00613_A1910TipDsc, P00613_A149TipCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV31GXLvl26 ;
      private int AV10MaxItems ;
      private int AV30GXV1 ;
      private string AV18TrnMode ;
      private string AV23UsuCod ;
      private string AV27TipCod_Filter ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1910TipDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string AV26ValueItem ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00612_A149TipCod ;
      private string[] P00612_A1910TipDsc ;
      private string[] P00613_A1910TipDsc ;
      private string[] P00613_A149TipCod ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GxSimpleCollection<string> AV25ValuesCollection ;
      private GxSimpleCollection<string> AV24DscsCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class usuariosseriesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00613( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1910TipDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipDsc], [TipCod] FROM [CTIPDOC]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipDsc]";
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
                     return conditional_P00613(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00612;
          prmP00612 = new Object[] {
          new ParDef("@AV27TipCod_Filter",GXType.NChar,3,0)
          };
          Object[] prmP00613;
          prmP00613 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00612", "SELECT TOP 1 [TipCod], [TipDsc] FROM [CTIPDOC] WHERE [TipCod] = @AV27TipCod_Filter ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00612,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00613", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00613,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                return;
       }
    }

 }

}
