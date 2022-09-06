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
   public class pgrabaauditoria : GXProcedure
   {
      public pgrabaauditoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pgrabaauditoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_SGAuMod ,
                           ref string aP1_SGAuDocGls ,
                           ref string aP2_SGAuDocNum ,
                           ref string aP3_SGAuDocRef ,
                           ref string aP4_SGAuTipCod ,
                           ref string aP5_SGAuTipo )
      {
         this.AV8SGAuMod = aP0_SGAuMod;
         this.AV10SGAuDocGls = aP1_SGAuDocGls;
         this.AV11SGAuDocNum = aP2_SGAuDocNum;
         this.AV12SGAuDocRef = aP3_SGAuDocRef;
         this.AV13SGAuTipCod = aP4_SGAuTipCod;
         this.AV16SGAuTipo = aP5_SGAuTipo;
         initialize();
         executePrivate();
         aP0_SGAuMod=this.AV8SGAuMod;
         aP1_SGAuDocGls=this.AV10SGAuDocGls;
         aP2_SGAuDocNum=this.AV11SGAuDocNum;
         aP3_SGAuDocRef=this.AV12SGAuDocRef;
         aP4_SGAuTipCod=this.AV13SGAuTipCod;
         aP5_SGAuTipo=this.AV16SGAuTipo;
      }

      public string executeUdp( ref string aP0_SGAuMod ,
                                ref string aP1_SGAuDocGls ,
                                ref string aP2_SGAuDocNum ,
                                ref string aP3_SGAuDocRef ,
                                ref string aP4_SGAuTipCod )
      {
         execute(ref aP0_SGAuMod, ref aP1_SGAuDocGls, ref aP2_SGAuDocNum, ref aP3_SGAuDocRef, ref aP4_SGAuTipCod, ref aP5_SGAuTipo);
         return AV16SGAuTipo ;
      }

      public void executeSubmit( ref string aP0_SGAuMod ,
                                 ref string aP1_SGAuDocGls ,
                                 ref string aP2_SGAuDocNum ,
                                 ref string aP3_SGAuDocRef ,
                                 ref string aP4_SGAuTipCod ,
                                 ref string aP5_SGAuTipo )
      {
         pgrabaauditoria objpgrabaauditoria;
         objpgrabaauditoria = new pgrabaauditoria();
         objpgrabaauditoria.AV8SGAuMod = aP0_SGAuMod;
         objpgrabaauditoria.AV10SGAuDocGls = aP1_SGAuDocGls;
         objpgrabaauditoria.AV11SGAuDocNum = aP2_SGAuDocNum;
         objpgrabaauditoria.AV12SGAuDocRef = aP3_SGAuDocRef;
         objpgrabaauditoria.AV13SGAuTipCod = aP4_SGAuTipCod;
         objpgrabaauditoria.AV16SGAuTipo = aP5_SGAuTipo;
         objpgrabaauditoria.context.SetSubmitInitialConfig(context);
         objpgrabaauditoria.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpgrabaauditoria);
         aP0_SGAuMod=this.AV8SGAuMod;
         aP1_SGAuDocGls=this.AV10SGAuDocGls;
         aP2_SGAuDocNum=this.AV11SGAuDocNum;
         aP3_SGAuDocRef=this.AV12SGAuDocRef;
         aP4_SGAuTipCod=this.AV13SGAuTipCod;
         aP5_SGAuTipo=this.AV16SGAuTipo;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pgrabaauditoria)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV18WWPContext) ;
         AV14SGAuUsuCod = AV18WWPContext.gxTpr_Username;
         AV9SGAuFecha = DateTimeUtil.Now( context);
         AV17SGAuFech = DateTimeUtil.Today( context);
         /*
            INSERT RECORD ON TABLE SGAUDITORIA

         */
         A337SGAuMod = AV8SGAuMod;
         A1846SGAuFech = AV17SGAuFech;
         A338SGAuFecha = AV9SGAuFecha;
         A1843SGAuDocGls = AV10SGAuDocGls;
         A1844SGAuDocNum = AV11SGAuDocNum;
         A1845SGAuDocRef = AV12SGAuDocRef;
         A1847SGAuTipCod = AV13SGAuTipCod;
         A1849SGAuUsuCod = AV14SGAuUsuCod;
         A1848SGAuTipo = AV16SGAuTipo;
         /* Using cursor P002L2 */
         pr_default.execute(0, new Object[] {A337SGAuMod, A338SGAuFecha, A1847SGAuTipCod, A1844SGAuDocNum, A1845SGAuDocRef, A1843SGAuDocGls, A1849SGAuUsuCod, A1848SGAuTipo, A1846SGAuFech});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("SGAUDITORIA");
         if ( (pr_default.getStatus(0) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         context.CommitDataStores("configuracion.pgrabaauditoria",pr_default);
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
         AV18WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV14SGAuUsuCod = "";
         AV9SGAuFecha = (DateTime)(DateTime.MinValue);
         AV17SGAuFech = DateTime.MinValue;
         A337SGAuMod = "";
         A1846SGAuFech = DateTime.MinValue;
         A338SGAuFecha = (DateTime)(DateTime.MinValue);
         A1843SGAuDocGls = "";
         A1844SGAuDocNum = "";
         A1845SGAuDocRef = "";
         A1847SGAuTipCod = "";
         A1849SGAuUsuCod = "";
         A1848SGAuTipo = "";
         Gx_emsg = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.pgrabaauditoria__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.pgrabaauditoria__default(),
            new Object[][] {
                new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int GX_INS21 ;
      private string Gx_emsg ;
      private DateTime AV9SGAuFecha ;
      private DateTime A338SGAuFecha ;
      private DateTime AV17SGAuFech ;
      private DateTime A1846SGAuFech ;
      private string AV8SGAuMod ;
      private string AV10SGAuDocGls ;
      private string AV11SGAuDocNum ;
      private string AV12SGAuDocRef ;
      private string AV13SGAuTipCod ;
      private string AV16SGAuTipo ;
      private string AV14SGAuUsuCod ;
      private string A337SGAuMod ;
      private string A1843SGAuDocGls ;
      private string A1844SGAuDocNum ;
      private string A1845SGAuDocRef ;
      private string A1847SGAuTipCod ;
      private string A1849SGAuUsuCod ;
      private string A1848SGAuTipo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_SGAuMod ;
      private string aP1_SGAuDocGls ;
      private string aP2_SGAuDocNum ;
      private string aP3_SGAuDocRef ;
      private string aP4_SGAuTipCod ;
      private string aP5_SGAuTipo ;
      private IDataStoreProvider pr_default ;
      private IDataStoreProvider pr_datastore2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV18WWPContext ;
   }

   public class pgrabaauditoria__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class pgrabaauditoria__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP002L2;
        prmP002L2 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGAuTipCod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuDocNum",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocRef",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocGls",GXType.NVarChar,100,0) ,
        new ParDef("@SGAuUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@SGAuTipo",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuFech",GXType.Date,8,0)
        };
        def= new CursorDef[] {
            new CursorDef("P002L2", "INSERT INTO [SGAUDITORIA]([SGAuMod], [SGAuFecha], [SGAuTipCod], [SGAuDocNum], [SGAuDocRef], [SGAuDocGls], [SGAuUsuCod], [SGAuTipo], [SGAuFech]) VALUES(@SGAuMod, @SGAuFecha, @SGAuTipCod, @SGAuDocNum, @SGAuDocRef, @SGAuDocGls, @SGAuUsuCod, @SGAuTipo, @SGAuFech)", GxErrorMask.GX_NOMASK,prmP002L2)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
