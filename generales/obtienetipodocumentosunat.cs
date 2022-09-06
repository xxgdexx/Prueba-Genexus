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
namespace GeneXus.Programs.generales {
   public class obtienetipodocumentosunat : GXProcedure
   {
      public obtienetipodocumentosunat( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public obtienetipodocumentosunat( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_ComRefTDoc ,
                           out string aP1_TRef )
      {
         this.AV8ComRefTDoc = aP0_ComRefTDoc;
         this.AV9TRef = "" ;
         initialize();
         executePrivate();
         aP0_ComRefTDoc=this.AV8ComRefTDoc;
         aP1_TRef=this.AV9TRef;
      }

      public string executeUdp( ref string aP0_ComRefTDoc )
      {
         execute(ref aP0_ComRefTDoc, out aP1_TRef);
         return AV9TRef ;
      }

      public void executeSubmit( ref string aP0_ComRefTDoc ,
                                 out string aP1_TRef )
      {
         obtienetipodocumentosunat objobtienetipodocumentosunat;
         objobtienetipodocumentosunat = new obtienetipodocumentosunat();
         objobtienetipodocumentosunat.AV8ComRefTDoc = aP0_ComRefTDoc;
         objobtienetipodocumentosunat.AV9TRef = "" ;
         objobtienetipodocumentosunat.context.SetSubmitInitialConfig(context);
         objobtienetipodocumentosunat.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objobtienetipodocumentosunat);
         aP0_ComRefTDoc=this.AV8ComRefTDoc;
         aP1_TRef=this.AV9TRef;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((obtienetipodocumentosunat)stateInfo).executePrivate();
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
         AV9TRef = "";
         /* Using cursor P008X2 */
         pr_default.execute(0, new Object[] {AV8ComRefTDoc});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A149TipCod = P008X2_A149TipCod[0];
            A306TipAbr = P008X2_A306TipAbr[0];
            AV9TRef = StringUtil.Trim( A306TipAbr);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV9TRef = "";
         scmdbuf = "";
         P008X2_A149TipCod = new string[] {""} ;
         P008X2_A306TipAbr = new string[] {""} ;
         A149TipCod = "";
         A306TipAbr = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.obtienetipodocumentosunat__default(),
            new Object[][] {
                new Object[] {
               P008X2_A149TipCod, P008X2_A306TipAbr
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV8ComRefTDoc ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A306TipAbr ;
      private string AV9TRef ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_ComRefTDoc ;
      private IDataStoreProvider pr_default ;
      private string[] P008X2_A149TipCod ;
      private string[] P008X2_A306TipAbr ;
      private string aP1_TRef ;
   }

   public class obtienetipodocumentosunat__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008X2;
          prmP008X2 = new Object[] {
          new ParDef("@AV8ComRefTDoc",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008X2", "SELECT [TipCod], [TipAbr] FROM [CTIPDOC] WHERE [TipCod] = @AV8ComRefTDoc ORDER BY [TipCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008X2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                return;
       }
    }

 }

}
