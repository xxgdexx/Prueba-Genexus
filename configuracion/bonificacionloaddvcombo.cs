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
   public class bonificacionloaddvcombo : GXProcedure
   {
      public bonificacionloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bonificacionloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           string aP2_CBonProdCod ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV24CBonProdCod = aP2_CBonProdCod;
         this.AV15SelectedValue = "" ;
         this.AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV13Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    string aP2_CBonProdCod ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_CBonProdCod, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV13Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 string aP2_CBonProdCod ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         bonificacionloaddvcombo objbonificacionloaddvcombo;
         objbonificacionloaddvcombo = new bonificacionloaddvcombo();
         objbonificacionloaddvcombo.AV16ComboName = aP0_ComboName;
         objbonificacionloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objbonificacionloaddvcombo.AV24CBonProdCod = aP2_CBonProdCod;
         objbonificacionloaddvcombo.AV15SelectedValue = "" ;
         objbonificacionloaddvcombo.AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objbonificacionloaddvcombo.context.SetSubmitInitialConfig(context);
         objbonificacionloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbonificacionloaddvcombo);
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV13Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bonificacionloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "CBonDProdCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CBONDPRODCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CBonProdCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CBONPRODCOD' */
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
         /* 'LOADCOMBOITEMS_CBONDPRODCOD' Routine */
         returnInSub = false;
         /* Using cursor P00582 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A28ProdCod = P00582_A28ProdCod[0];
            A55ProdDsc = P00582_A55ProdDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A28ProdCod;
            AV14Combo_DataItem.gxTpr_Title = A55ProdDsc;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00583 */
            pr_default.execute(1, new Object[] {AV24CBonProdCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A81CBonProdCod = P00583_A81CBonProdCod[0];
               A82CBonDProdCod = P00583_A82CBonDProdCod[0];
               AV15SelectedValue = A82CBonDProdCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_CBONPRODCOD' Routine */
         returnInSub = false;
         /* Using cursor P00584 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A28ProdCod = P00584_A28ProdCod[0];
            A55ProdDsc = P00584_A55ProdDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A28ProdCod;
            AV14Combo_DataItem.gxTpr_Title = A55ProdDsc;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P00585 */
            pr_default.execute(3, new Object[] {AV24CBonProdCod});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A81CBonProdCod = P00585_A81CBonProdCod[0];
               AV15SelectedValue = A81CBonProdCod;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(3);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24CBonProdCod)) )
            {
               AV15SelectedValue = AV24CBonProdCod;
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
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P00582_A28ProdCod = new string[] {""} ;
         P00582_A55ProdDsc = new string[] {""} ;
         A28ProdCod = "";
         A55ProdDsc = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P00583_A81CBonProdCod = new string[] {""} ;
         P00583_A82CBonDProdCod = new string[] {""} ;
         A81CBonProdCod = "";
         A82CBonDProdCod = "";
         P00584_A28ProdCod = new string[] {""} ;
         P00584_A55ProdDsc = new string[] {""} ;
         P00585_A81CBonProdCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacionloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00582_A28ProdCod, P00582_A55ProdDsc
               }
               , new Object[] {
               P00583_A81CBonProdCod, P00583_A82CBonDProdCod
               }
               , new Object[] {
               P00584_A28ProdCod, P00584_A55ProdDsc
               }
               , new Object[] {
               P00585_A81CBonProdCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV18TrnMode ;
      private string AV24CBonProdCod ;
      private string scmdbuf ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A81CBonProdCod ;
      private string A82CBonDProdCod ;
      private bool returnInSub ;
      private string AV16ComboName ;
      private string AV15SelectedValue ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00582_A28ProdCod ;
      private string[] P00582_A55ProdDsc ;
      private string[] P00583_A81CBonProdCod ;
      private string[] P00583_A82CBonDProdCod ;
      private string[] P00584_A28ProdCod ;
      private string[] P00584_A55ProdDsc ;
      private string[] P00585_A81CBonProdCod ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class bonificacionloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00582;
          prmP00582 = new Object[] {
          };
          Object[] prmP00583;
          prmP00583 = new Object[] {
          new ParDef("@AV24CBonProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00584;
          prmP00584 = new Object[] {
          };
          Object[] prmP00585;
          prmP00585 = new Object[] {
          new ParDef("@AV24CBonProdCod",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00582", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] ORDER BY [ProdDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00582,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00583", "SELECT [CBonProdCod], [CBonDProdCod] FROM [CBONIFICACION] WHERE [CBonProdCod] = @AV24CBonProdCod ORDER BY [CBonProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00583,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00584", "SELECT [ProdCod], [ProdDsc] FROM [APRODUCTOS] ORDER BY [ProdDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00584,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00585", "SELECT [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonProdCod] = @AV24CBonProdCod ORDER BY [CBonProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00585,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                return;
       }
    }

 }

}
