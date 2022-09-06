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
   public class tipopedidoloaddvcombo : GXProcedure
   {
      public tipopedidoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipopedidoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           int aP2_TPedCod ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV15TrnMode = aP1_TrnMode;
         this.AV17TPedCod = aP2_TPedCod;
         this.AV12SelectedValue = "" ;
         this.AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV12SelectedValue;
         aP4_Combo_Data=this.AV10Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    int aP2_TPedCod ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_TPedCod, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV10Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 int aP2_TPedCod ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         tipopedidoloaddvcombo objtipopedidoloaddvcombo;
         objtipopedidoloaddvcombo = new tipopedidoloaddvcombo();
         objtipopedidoloaddvcombo.AV13ComboName = aP0_ComboName;
         objtipopedidoloaddvcombo.AV15TrnMode = aP1_TrnMode;
         objtipopedidoloaddvcombo.AV17TPedCod = aP2_TPedCod;
         objtipopedidoloaddvcombo.AV12SelectedValue = "" ;
         objtipopedidoloaddvcombo.AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objtipopedidoloaddvcombo.context.SetSubmitInitialConfig(context);
         objtipopedidoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipopedidoloaddvcombo);
         aP3_SelectedValue=this.AV12SelectedValue;
         aP4_Combo_Data=this.AV10Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipopedidoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV13ComboName, "TPedMovCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TPEDMOVCOD' */
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
         /* 'LOADCOMBOITEMS_TPEDMOVCOD' Routine */
         returnInSub = false;
         /* Using cursor P004X2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1240MovSts = P004X2_A1240MovSts[0];
            A1241MovTip = P004X2_A1241MovTip[0];
            A234MovCod = P004X2_A234MovCod[0];
            A1239MovDsc = P004X2_A1239MovDsc[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A234MovCod), 6, 0));
            AV11Combo_DataItem.gxTpr_Title = A1239MovDsc;
            AV10Combo_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
         {
            /* Using cursor P004X3 */
            pr_default.execute(1, new Object[] {AV17TPedCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A212TPedCod = P004X3_A212TPedCod[0];
               A1934TPedMovCod = P004X3_A1934TPedMovCod[0];
               AV12SelectedValue = ((0==A1934TPedMovCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A1934TPedMovCod), 6, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
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
         AV12SelectedValue = "";
         AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P004X2_A1240MovSts = new short[1] ;
         P004X2_A1241MovTip = new short[1] ;
         P004X2_A234MovCod = new int[1] ;
         P004X2_A1239MovDsc = new string[] {""} ;
         A1239MovDsc = "";
         AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P004X3_A212TPedCod = new int[1] ;
         P004X3_A1934TPedMovCod = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedidoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P004X2_A1240MovSts, P004X2_A1241MovTip, P004X2_A234MovCod, P004X2_A1239MovDsc
               }
               , new Object[] {
               P004X3_A212TPedCod, P004X3_A1934TPedMovCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1240MovSts ;
      private short A1241MovTip ;
      private int AV17TPedCod ;
      private int A234MovCod ;
      private int A212TPedCod ;
      private int A1934TPedMovCod ;
      private string AV15TrnMode ;
      private string scmdbuf ;
      private string A1239MovDsc ;
      private bool returnInSub ;
      private string AV13ComboName ;
      private string AV12SelectedValue ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004X2_A1240MovSts ;
      private short[] P004X2_A1241MovTip ;
      private int[] P004X2_A234MovCod ;
      private string[] P004X2_A1239MovDsc ;
      private int[] P004X3_A212TPedCod ;
      private int[] P004X3_A1934TPedMovCod ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
   }

   public class tipopedidoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP004X2;
          prmP004X2 = new Object[] {
          };
          Object[] prmP004X3;
          prmP004X3 = new Object[] {
          new ParDef("@AV17TPedCod",GXType.Int32,6,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004X2", "SELECT [MovSts], [MovTip], [MovCod], [MovDsc] FROM [CMOVALMACEN] WHERE ([MovSts] = 1) AND ([MovTip] = 2) ORDER BY [MovDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004X2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P004X3", "SELECT [TPedCod], [TPedMovCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @AV17TPedCod ORDER BY [TPedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004X3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
    }

 }

}
