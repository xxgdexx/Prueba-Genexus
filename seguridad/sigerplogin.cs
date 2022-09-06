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
   public class sigerplogin : GXProcedure
   {
      public sigerplogin( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sigerplogin( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_SecUserName ,
                           ref string aP1_SecUserPassword ,
                           ref short aP2_Estado )
      {
         this.AV10SecUserName = aP0_SecUserName;
         this.AV11SecUserPassword = aP1_SecUserPassword;
         this.AV9Estado = aP2_Estado;
         initialize();
         executePrivate();
         aP0_SecUserName=this.AV10SecUserName;
         aP1_SecUserPassword=this.AV11SecUserPassword;
         aP2_Estado=this.AV9Estado;
      }

      public short executeUdp( ref string aP0_SecUserName ,
                               ref string aP1_SecUserPassword )
      {
         execute(ref aP0_SecUserName, ref aP1_SecUserPassword, ref aP2_Estado);
         return AV9Estado ;
      }

      public void executeSubmit( ref string aP0_SecUserName ,
                                 ref string aP1_SecUserPassword ,
                                 ref short aP2_Estado )
      {
         sigerplogin objsigerplogin;
         objsigerplogin = new sigerplogin();
         objsigerplogin.AV10SecUserName = aP0_SecUserName;
         objsigerplogin.AV11SecUserPassword = aP1_SecUserPassword;
         objsigerplogin.AV9Estado = aP2_Estado;
         objsigerplogin.context.SetSubmitInitialConfig(context);
         objsigerplogin.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsigerplogin);
         aP0_SecUserName=this.AV10SecUserName;
         aP1_SecUserPassword=this.AV11SecUserPassword;
         aP2_Estado=this.AV9Estado;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sigerplogin)stateInfo).executePrivate();
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
         AV9Estado = 0;
         AV15GXLvl2 = 0;
         /* Using cursor P00262 */
         pr_default.execute(0, new Object[] {AV10SecUserName});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A348UsuCod = P00262_A348UsuCod[0];
            A2039UsuSts = P00262_A2039UsuSts[0];
            A2021UsuPas = P00262_A2021UsuPas[0];
            AV15GXLvl2 = 1;
            if ( A2039UsuSts == 0 )
            {
               AV9Estado = 1;
            }
            else
            {
               if ( StringUtil.StrCmp(A2021UsuPas, AV11SecUserPassword) == 0 )
               {
                  AV9Estado = 3;
                  AV8WWPContext.gxTpr_Username = AV10SecUserName;
                  new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV8WWPContext) ;
               }
               else
               {
                  AV9Estado = 2;
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV15GXLvl2 == 0 )
         {
            AV9Estado = 0;
         }
         AV8WWPContext.gxTpr_Userid = AV12SecUserId;
         AV8WWPContext.gxTpr_Username = AV10SecUserName;
         new GeneXus.Programs.wwpbaseobjects.setwwpcontext(context ).execute(  AV8WWPContext) ;
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
         P00262_A348UsuCod = new string[] {""} ;
         P00262_A2039UsuSts = new short[1] ;
         P00262_A2021UsuPas = new string[] {""} ;
         A348UsuCod = "";
         A2021UsuPas = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.sigerplogin__default(),
            new Object[][] {
                new Object[] {
               P00262_A348UsuCod, P00262_A2039UsuSts, P00262_A2021UsuPas
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9Estado ;
      private short AV15GXLvl2 ;
      private short A2039UsuSts ;
      private short AV12SecUserId ;
      private string scmdbuf ;
      private string A348UsuCod ;
      private string A2021UsuPas ;
      private string AV10SecUserName ;
      private string AV11SecUserPassword ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_SecUserName ;
      private string aP1_SecUserPassword ;
      private short aP2_Estado ;
      private IDataStoreProvider pr_default ;
      private string[] P00262_A348UsuCod ;
      private short[] P00262_A2039UsuSts ;
      private string[] P00262_A2021UsuPas ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class sigerplogin__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00262;
          prmP00262 = new Object[] {
          new ParDef("@AV10SecUserName",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00262", "SELECT [UsuCod], [UsuSts], [UsuPas] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV10SecUserName ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00262,1, GxCacheFrequency.OFF ,true,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                return;
       }
    }

 }

}
