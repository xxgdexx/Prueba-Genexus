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
namespace GeneXus.Programs.almacen {
   public class r_guiasremisionloaddvcombo : GXProcedure
   {
      public r_guiasremisionloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_guiasremisionloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_Cond_CliCod ,
                           string aP2_SearchTxt ,
                           out string aP3_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV17Cond_CliCod = aP1_Cond_CliCod;
         this.AV11SearchTxt = aP2_SearchTxt;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_Cond_CliCod ,
                                string aP2_SearchTxt )
      {
         execute(aP0_ComboName, aP1_Cond_CliCod, aP2_SearchTxt, out aP3_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_Cond_CliCod ,
                                 string aP2_SearchTxt ,
                                 out string aP3_Combo_DataJson )
      {
         r_guiasremisionloaddvcombo objr_guiasremisionloaddvcombo;
         objr_guiasremisionloaddvcombo = new r_guiasremisionloaddvcombo();
         objr_guiasremisionloaddvcombo.AV16ComboName = aP0_ComboName;
         objr_guiasremisionloaddvcombo.AV17Cond_CliCod = aP1_Cond_CliCod;
         objr_guiasremisionloaddvcombo.AV11SearchTxt = aP2_SearchTxt;
         objr_guiasremisionloaddvcombo.AV12Combo_DataJson = "" ;
         objr_guiasremisionloaddvcombo.context.SetSubmitInitialConfig(context);
         objr_guiasremisionloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_guiasremisionloaddvcombo);
         aP3_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_guiasremisionloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "MVCliOrigen") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MVCLIORIGEN' */
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
         /* 'LOADCOMBOITEMS_MVCLIORIGEN' Routine */
         returnInSub = false;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV11SearchTxt ,
                                              A600CliDirDsc } ,
                                              new int[]{
                                              }
         });
         lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
         /* Using cursor P00F12 */
         pr_default.execute(0, new Object[] {lV11SearchTxt});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A600CliDirDsc = P00F12_A600CliDirDsc[0];
            A164CliDirItem = P00F12_A164CliDirItem[0];
            A45CliCod = P00F12_A45CliCod[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A164CliDirItem), 6, 0));
            AV14Combo_DataItem.gxTpr_Title = A600CliDirDsc;
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
         A600CliDirDsc = "";
         P00F12_A600CliDirDsc = new string[] {""} ;
         P00F12_A164CliDirItem = new int[1] ;
         P00F12_A45CliCod = new string[] {""} ;
         A45CliCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.r_guiasremisionloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00F12_A600CliDirDsc, P00F12_A164CliDirItem, P00F12_A45CliCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10MaxItems ;
      private int A164CliDirItem ;
      private string AV17Cond_CliCod ;
      private string scmdbuf ;
      private string A600CliDirDsc ;
      private string A45CliCod ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00F12_A600CliDirDsc ;
      private int[] P00F12_A164CliDirItem ;
      private string[] P00F12_A45CliCod ;
      private string aP3_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class r_guiasremisionloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00F12( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A600CliDirDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CliDirDsc], [CliDirItem], [CliCod] FROM [CLCLIENTESDIRECCION]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CliDirDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CliDirDsc]";
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
                     return conditional_P00F12(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00F12;
          prmP00F12 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00F12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00F12,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
       }
    }

 }

}
