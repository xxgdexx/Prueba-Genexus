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
namespace GeneXus.Programs.wwpbaseobjects {
   public class loadmenutreeview : GXProcedure
   {
      public loadmenutreeview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public loadmenutreeview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MenuItemId ,
                           out GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> aP1_Gxm2rootcol )
      {
         this.AV5MenuItemId = aP0_MenuItemId;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>( context, "TreeNode", "SIGERP_ADVANCED") ;
         initialize();
         executePrivate();
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> executeUdp( short aP0_MenuItemId )
      {
         execute(aP0_MenuItemId, out aP1_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( short aP0_MenuItemId ,
                                 out GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> aP1_Gxm2rootcol )
      {
         loadmenutreeview objloadmenutreeview;
         objloadmenutreeview = new loadmenutreeview();
         objloadmenutreeview.AV5MenuItemId = aP0_MenuItemId;
         objloadmenutreeview.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>( context, "TreeNode", "SIGERP_ADVANCED") ;
         objloadmenutreeview.context.SetSubmitInitialConfig(context);
         objloadmenutreeview.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objloadmenutreeview);
         aP1_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadmenutreeview)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV5MenuItemId ,
                                              A353MenuItemFatherId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00062 */
         pr_default.execute(0, new Object[] {AV5MenuItemId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A353MenuItemFatherId = P00062_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P00062_n353MenuItemFatherId[0];
            A352MenuItemId = P00062_A352MenuItemId[0];
            A1222MenuItemCaption = P00062_A1222MenuItemCaption[0];
            Gxm1treenodecollection = new GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode(context);
            Gxm2rootcol.Add(Gxm1treenodecollection, 0);
            Gxm1treenodecollection.gxTpr_Id = StringUtil.Str( (decimal)(A352MenuItemId), 4, 0);
            Gxm1treenodecollection.gxTpr_Name = A1222MenuItemCaption;
            Gxm1treenodecollection.gxTpr_Expanded = true;
            GXt_objcol_SdtTreeNodeCollection_TreeNode1 = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>();
            new GeneXus.Programs.wwpbaseobjects.loadmenutreeview(context ).execute(  A352MenuItemId, out  GXt_objcol_SdtTreeNodeCollection_TreeNode1) ;
            Gxm1treenodecollection.gxTpr_Nodes = GXt_objcol_SdtTreeNodeCollection_TreeNode1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
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
         scmdbuf = "";
         P00062_A353MenuItemFatherId = new short[1] ;
         P00062_n353MenuItemFatherId = new bool[] {false} ;
         P00062_A352MenuItemId = new short[1] ;
         P00062_A1222MenuItemCaption = new string[] {""} ;
         A1222MenuItemCaption = "";
         Gxm1treenodecollection = new GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode(context);
         GXt_objcol_SdtTreeNodeCollection_TreeNode1 = new GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode>( context, "TreeNode", "SIGERP_ADVANCED");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.loadmenutreeview__default(),
            new Object[][] {
                new Object[] {
               P00062_A353MenuItemFatherId, P00062_n353MenuItemFatherId, P00062_A352MenuItemId, P00062_A1222MenuItemCaption
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV5MenuItemId ;
      private short A353MenuItemFatherId ;
      private short A352MenuItemId ;
      private string scmdbuf ;
      private bool n353MenuItemFatherId ;
      private string A1222MenuItemCaption ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00062_A353MenuItemFatherId ;
      private bool[] P00062_n353MenuItemFatherId ;
      private short[] P00062_A352MenuItemId ;
      private string[] P00062_A1222MenuItemCaption ;
      private GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> aP1_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode> GXt_objcol_SdtTreeNodeCollection_TreeNode1 ;
      private GeneXus.Programs.seguridad.SdtTreeNodeCollection_TreeNode Gxm1treenodecollection ;
   }

   public class loadmenutreeview__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00062( IGxContext context ,
                                             short AV5MenuItemId ,
                                             short A353MenuItemFatherId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MenuItemFatherId], [MenuItemId], [MenuItemCaption] FROM [SIGERPMenu]";
         if ( AV5MenuItemId > 0 )
         {
            AddWhere(sWhereString, "([MenuItemFatherId] = @AV5MenuItemId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV5MenuItemId == 0 )
         {
            AddWhere(sWhereString, "([MenuItemFatherId] IS NULL or ([MenuItemFatherId] = convert(int, 0)))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MenuItemId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00062(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
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
          Object[] prmP00062;
          prmP00062 = new Object[] {
          new ParDef("@AV5MenuItemId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00062", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00062,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
       }
    }

 }

}
