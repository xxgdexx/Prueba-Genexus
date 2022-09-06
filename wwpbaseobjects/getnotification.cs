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
   public class getnotification : GXProcedure
   {
      public getnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public getnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "SIGERP_ADVANCED") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol )
      {
         getnotification objgetnotification;
         objgetnotification = new getnotification();
         objgetnotification.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "SIGERP_ADVANCED") ;
         objgetnotification.context.SetSubmitInitialConfig(context);
         objgetnotification.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetnotification);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getnotification)stateInfo).executePrivate();
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
         AV11Udparg3 = new GeneXus.Programs.wwpbaseobjects.getusuario(context).executeUdp( );
         /* Using cursor P00052 */
         pr_default.execute(0, new Object[] {AV11Udparg3});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2241SGNotificacionUsuario = P00052_A2241SGNotificacionUsuario[0];
            A2237SGNotificacionID = P00052_A2237SGNotificacionID[0];
            A2243SGNotificacionIconClass = P00052_A2243SGNotificacionIconClass[0];
            A2238SGNotificacionTitulo = P00052_A2238SGNotificacionTitulo[0];
            A2239SGNotificacionDescripcion = P00052_A2239SGNotificacionDescripcion[0];
            A2240SGNotificacionFecha = P00052_A2240SGNotificacionFecha[0];
            Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
            Gxm2rootcol.Add(Gxm1wwp_sdtnotificationsdata, 0);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationid = (int)(A2237SGNotificacionID);
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationiconclass = A2243SGNotificacionIconClass;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationtitle = A2238SGNotificacionTitulo;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdescription = A2239SGNotificacionDescripcion;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationdatetime = A2240SGNotificacionFecha;
            Gxm1wwp_sdtnotificationsdata.gxTpr_Notificationlink = "";
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
         AV11Udparg3 = "";
         scmdbuf = "";
         P00052_A2241SGNotificacionUsuario = new string[] {""} ;
         P00052_A2237SGNotificacionID = new long[1] ;
         P00052_A2243SGNotificacionIconClass = new string[] {""} ;
         P00052_A2238SGNotificacionTitulo = new string[] {""} ;
         P00052_A2239SGNotificacionDescripcion = new string[] {""} ;
         P00052_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         A2241SGNotificacionUsuario = "";
         A2243SGNotificacionIconClass = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Gxm1wwp_sdtnotificationsdata = new GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.getnotification__default(),
            new Object[][] {
                new Object[] {
               P00052_A2241SGNotificacionUsuario, P00052_A2237SGNotificacionID, P00052_A2243SGNotificacionIconClass, P00052_A2238SGNotificacionTitulo, P00052_A2239SGNotificacionDescripcion, P00052_A2240SGNotificacionFecha
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long A2237SGNotificacionID ;
      private string AV11Udparg3 ;
      private string scmdbuf ;
      private string A2241SGNotificacionUsuario ;
      private DateTime A2240SGNotificacionFecha ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00052_A2241SGNotificacionUsuario ;
      private long[] P00052_A2237SGNotificacionID ;
      private string[] P00052_A2243SGNotificacionIconClass ;
      private string[] P00052_A2238SGNotificacionTitulo ;
      private string[] P00052_A2239SGNotificacionDescripcion ;
      private DateTime[] P00052_A2240SGNotificacionFecha ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> aP0_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> Gxm2rootcol ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem Gxm1wwp_sdtnotificationsdata ;
   }

   public class getnotification__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP00052;
          prmP00052 = new Object[] {
          new ParDef("@AV11Udparg3",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00052", "SELECT [SGNotificacionUsuario], [SGNotificacionID], [SGNotificacionIconClass], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @AV11Udparg3 ORDER BY [SGNotificacionUsuario] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00052,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                return;
       }
    }

 }

}
