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
   public class centrocostoloaddvcombo : GXProcedure
   {
      public centrocostoloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public centrocostoloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           string aP2_COSCod ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV24COSCod = aP2_COSCod;
         this.AV15SelectedValue = "" ;
         this.AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         executePrivate();
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV13Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    string aP2_COSCod ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_COSCod, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV13Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 string aP2_COSCod ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         centrocostoloaddvcombo objcentrocostoloaddvcombo;
         objcentrocostoloaddvcombo = new centrocostoloaddvcombo();
         objcentrocostoloaddvcombo.AV16ComboName = aP0_ComboName;
         objcentrocostoloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objcentrocostoloaddvcombo.AV24COSCod = aP2_COSCod;
         objcentrocostoloaddvcombo.AV15SelectedValue = "" ;
         objcentrocostoloaddvcombo.AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         objcentrocostoloaddvcombo.context.SetSubmitInitialConfig(context);
         objcentrocostoloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcentrocostoloaddvcombo);
         aP3_SelectedValue=this.AV15SelectedValue;
         aP4_Combo_Data=this.AV13Combo_Data;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrocostoloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "COSCueDestino") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_COSCUEDESTINO' */
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
         /* 'LOADCOMBOITEMS_COSCUEDESTINO' Routine */
         returnInSub = false;
         /* Using cursor P006U2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A867CueMov = P006U2_A867CueMov[0];
            A873CueSts = P006U2_A873CueSts[0];
            A2098CueDscCompleto = P006U2_A2098CueDscCompleto[0];
            A91CueCod = P006U2_A91CueCod[0];
            A860CueDsc = P006U2_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006U3 */
            pr_default.execute(1, new Object[] {AV24COSCod});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A79COSCod = P006U3_A79COSCod[0];
               A80COSCueDestino = P006U3_A80COSCueDestino[0];
               n80COSCueDestino = P006U3_n80COSCueDestino[0];
               AV15SelectedValue = A80COSCueDestino;
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
         AV15SelectedValue = "";
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P006U2_A867CueMov = new short[1] ;
         P006U2_A873CueSts = new short[1] ;
         P006U2_A2098CueDscCompleto = new string[] {""} ;
         P006U2_A91CueCod = new string[] {""} ;
         P006U2_A860CueDsc = new string[] {""} ;
         A2098CueDscCompleto = "";
         A91CueCod = "";
         A860CueDsc = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         P006U3_A79COSCod = new string[] {""} ;
         P006U3_A80COSCueDestino = new string[] {""} ;
         P006U3_n80COSCueDestino = new bool[] {false} ;
         A79COSCod = "";
         A80COSCueDestino = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocostoloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006U2_A867CueMov, P006U2_A873CueSts, P006U2_A2098CueDscCompleto, P006U2_A91CueCod, P006U2_A860CueDsc
               }
               , new Object[] {
               P006U3_A79COSCod, P006U3_A80COSCueDestino, P006U3_n80COSCueDestino
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A867CueMov ;
      private short A873CueSts ;
      private string AV18TrnMode ;
      private string AV24COSCod ;
      private string scmdbuf ;
      private string A2098CueDscCompleto ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string A79COSCod ;
      private string A80COSCueDestino ;
      private bool returnInSub ;
      private bool n80COSCueDestino ;
      private string AV16ComboName ;
      private string AV15SelectedValue ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006U2_A867CueMov ;
      private short[] P006U2_A873CueSts ;
      private string[] P006U2_A2098CueDscCompleto ;
      private string[] P006U2_A91CueCod ;
      private string[] P006U2_A860CueDsc ;
      private string[] P006U3_A79COSCod ;
      private string[] P006U3_A80COSCueDestino ;
      private bool[] P006U3_n80COSCueDestino ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class centrocostoloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006U2;
          prmP006U2 = new Object[] {
          };
          Object[] prmP006U3;
          prmP006U3 = new Object[] {
          new ParDef("@AV24COSCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006U2", "SELECT [CueMov], [CueSts], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueMov] = 1) AND ([CueSts] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006U3", "SELECT [COSCod], [COSCueDestino] FROM [CBCOSTOS] WHERE [COSCod] = @AV24COSCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006U3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
