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
namespace GeneXus.Programs.ventas {
   public class r_antiguedadsaldosloaddvcombo : GXProcedure
   {
      public r_antiguedadsaldosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_antiguedadsaldosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_Cond_EstCod ,
                           string aP2_SearchTxt ,
                           out string aP3_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17Cond_EstCod = aP1_Cond_EstCod;
         this.AV11SearchTxt = aP2_SearchTxt;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_Cond_EstCod ,
                                string aP2_SearchTxt )
      {
         execute(aP0_ComboName, aP1_Cond_EstCod, aP2_SearchTxt, out aP3_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_Cond_EstCod ,
                                 string aP2_SearchTxt ,
                                 out string aP3_Combo_DataJson )
      {
         r_antiguedadsaldosloaddvcombo objr_antiguedadsaldosloaddvcombo;
         objr_antiguedadsaldosloaddvcombo = new r_antiguedadsaldosloaddvcombo();
         objr_antiguedadsaldosloaddvcombo.AV16ComboName = aP0_ComboName;
         objr_antiguedadsaldosloaddvcombo.AV17Cond_EstCod = aP1_Cond_EstCod;
         objr_antiguedadsaldosloaddvcombo.AV11SearchTxt = aP2_SearchTxt;
         objr_antiguedadsaldosloaddvcombo.AV12Combo_DataJson = "" ;
         objr_antiguedadsaldosloaddvcombo.context.SetSubmitInitialConfig(context);
         objr_antiguedadsaldosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_antiguedadsaldosloaddvcombo);
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_antiguedadsaldosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "ProvCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROVCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "DiscCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DISCCOD' */
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
         /* 'LOADCOMBOITEMS_PROVCOD' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11SearchTxt ,
                                              A603ProvDsc ,
                                              A1742ProvSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
         /* Using cursor P00EC2 */
         pr_default.execute(0, new Object[] {lV11SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1742ProvSts = P00EC2_A1742ProvSts[0];
            A603ProvDsc = P00EC2_A603ProvDsc[0];
            A141ProvCod = P00EC2_A141ProvCod[0];
            A139PaiCod = P00EC2_A139PaiCod[0];
            A140EstCod = P00EC2_A140EstCod[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A141ProvCod;
            AV14Combo_DataItem.gxTpr_Title = A603ProvDsc;
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

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_DISCCOD' Routine */
         returnInSub = false;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11SearchTxt ,
                                              A604DisDsc ,
                                              A878DisSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
         /* Using cursor P00EC3 */
         pr_default.execute(1, new Object[] {lV11SearchTxt});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A878DisSts = P00EC3_A878DisSts[0];
            A604DisDsc = P00EC3_A604DisDsc[0];
            A142DisCod = P00EC3_A142DisCod[0];
            A139PaiCod = P00EC3_A139PaiCod[0];
            A140EstCod = P00EC3_A140EstCod[0];
            A141ProvCod = P00EC3_A141ProvCod[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A142DisCod;
            AV14Combo_DataItem.gxTpr_Title = A604DisDsc;
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
         AV12Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         lV11SearchTxt = "";
         A603ProvDsc = "";
         P00EC2_A1742ProvSts = new short[1] ;
         P00EC2_A603ProvDsc = new string[] {""} ;
         P00EC2_A141ProvCod = new string[] {""} ;
         P00EC2_A139PaiCod = new string[] {""} ;
         P00EC2_A140EstCod = new string[] {""} ;
         A141ProvCod = "";
         A139PaiCod = "";
         A140EstCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A604DisDsc = "";
         P00EC3_A878DisSts = new short[1] ;
         P00EC3_A604DisDsc = new string[] {""} ;
         P00EC3_A142DisCod = new string[] {""} ;
         P00EC3_A139PaiCod = new string[] {""} ;
         P00EC3_A140EstCod = new string[] {""} ;
         P00EC3_A141ProvCod = new string[] {""} ;
         A142DisCod = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.r_antiguedadsaldosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00EC2_A1742ProvSts, P00EC2_A603ProvDsc, P00EC2_A141ProvCod, P00EC2_A139PaiCod, P00EC2_A140EstCod
               }
               , new Object[] {
               P00EC3_A878DisSts, P00EC3_A604DisDsc, P00EC3_A142DisCod, P00EC3_A139PaiCod, P00EC3_A140EstCod, P00EC3_A141ProvCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1742ProvSts ;
      private short A878DisSts ;
      private int AV10MaxItems ;
      private string AV17Cond_EstCod ;
      private string scmdbuf ;
      private string A603ProvDsc ;
      private string A141ProvCod ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A604DisDsc ;
      private string A142DisCod ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00EC2_A1742ProvSts ;
      private string[] P00EC2_A603ProvDsc ;
      private string[] P00EC2_A141ProvCod ;
      private string[] P00EC2_A139PaiCod ;
      private string[] P00EC2_A140EstCod ;
      private short[] P00EC3_A878DisSts ;
      private string[] P00EC3_A604DisDsc ;
      private string[] P00EC3_A142DisCod ;
      private string[] P00EC3_A139PaiCod ;
      private string[] P00EC3_A140EstCod ;
      private string[] P00EC3_A141ProvCod ;
      private string aP3_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class r_antiguedadsaldosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EC2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A603ProvDsc ,
                                             short A1742ProvSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ProvSts], [ProvDsc], [ProvCod], [PaiCod], [EstCod] FROM [CPROVINCIA]";
         AddWhere(sWhereString, "([ProvSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ProvDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProvDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EC3( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A604DisDsc ,
                                             short A878DisSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [DisSts], [DisDsc], [DisCod], [PaiCod], [EstCod], [ProvCod] FROM [CDISTRITOS]";
         AddWhere(sWhereString, "([DisSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([DisDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DisDsc]";
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
               case 0 :
                     return conditional_P00EC2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
               case 1 :
                     return conditional_P00EC3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
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
          Object[] prmP00EC2;
          prmP00EC2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00EC3;
          prmP00EC3 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EC2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00EC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EC3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                return;
       }
    }

 }

}
