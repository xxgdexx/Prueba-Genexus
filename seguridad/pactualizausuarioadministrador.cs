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
   public class pactualizausuarioadministrador : GXProcedure
   {
      public pactualizausuarioadministrador( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pactualizausuarioadministrador( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_UsuCod )
      {
         this.AV10UsuCod = aP0_UsuCod;
         initialize();
         executePrivate();
         aP0_UsuCod=this.AV10UsuCod;
      }

      public string executeUdp( )
      {
         execute(ref aP0_UsuCod);
         return AV10UsuCod ;
      }

      public void executeSubmit( ref string aP0_UsuCod )
      {
         pactualizausuarioadministrador objpactualizausuarioadministrador;
         objpactualizausuarioadministrador = new pactualizausuarioadministrador();
         objpactualizausuarioadministrador.AV10UsuCod = aP0_UsuCod;
         objpactualizausuarioadministrador.context.SetSubmitInitialConfig(context);
         objpactualizausuarioadministrador.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpactualizausuarioadministrador);
         aP0_UsuCod=this.AV10UsuCod;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pactualizausuarioadministrador)stateInfo).executePrivate();
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
         AV9SGMenuPrograma = AV11Session.Get("SGPrograma");
         /* Optimized DELETE. */
         /* Using cursor P001L2 */
         pr_default.execute(0, new Object[] {AV10UsuCod, AV9SGMenuPrograma});
         pr_default.close(0);
         dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV3");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P001L3 */
         pr_default.execute(1, new Object[] {AV10UsuCod, AV9SGMenuPrograma});
         pr_default.close(1);
         dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV2");
         /* End optimized DELETE. */
         /* Optimized DELETE. */
         /* Using cursor P001L4 */
         pr_default.execute(2, new Object[] {AV10UsuCod, AV9SGMenuPrograma});
         pr_default.close(2);
         dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV1");
         /* End optimized DELETE. */
         /* Using cursor P001L5 */
         pr_default.execute(3, new Object[] {AV9SGMenuPrograma});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A343SGMenuNiv1ID = P001L5_A343SGMenuNiv1ID[0];
            A342SGMenuPrograma = P001L5_A342SGMenuPrograma[0];
            A1850SGMenuNiv1Dsc = P001L5_A1850SGMenuNiv1Dsc[0];
            W342SGMenuPrograma = A342SGMenuPrograma;
            /*
               INSERT RECORD ON TABLE SGUSUARIONIV1

            */
            W342SGMenuPrograma = A342SGMenuPrograma;
            W343SGMenuNiv1ID = A343SGMenuNiv1ID;
            A348UsuCod = AV10UsuCod;
            A342SGMenuPrograma = AV9SGMenuPrograma;
            A2015UsuModuloSts = 1;
            /* Using cursor P001L6 */
            pr_default.execute(4, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A2015UsuModuloSts});
            pr_default.close(4);
            dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV1");
            if ( (pr_default.getStatus(4) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            A342SGMenuPrograma = W342SGMenuPrograma;
            A343SGMenuNiv1ID = W343SGMenuNiv1ID;
            /* End Insert */
            A342SGMenuPrograma = W342SGMenuPrograma;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         /* Using cursor P001L7 */
         pr_default.execute(5, new Object[] {AV9SGMenuPrograma});
         while ( (pr_default.getStatus(5) != 101) )
         {
            A344SGMenuNiv2ID = P001L7_A344SGMenuNiv2ID[0];
            A343SGMenuNiv1ID = P001L7_A343SGMenuNiv1ID[0];
            A342SGMenuPrograma = P001L7_A342SGMenuPrograma[0];
            A1851SGMenuNiv2Dsc = P001L7_A1851SGMenuNiv2Dsc[0];
            W342SGMenuPrograma = A342SGMenuPrograma;
            /*
               INSERT RECORD ON TABLE SGUSUARIONIV2

            */
            W342SGMenuPrograma = A342SGMenuPrograma;
            W343SGMenuNiv1ID = A343SGMenuNiv1ID;
            W344SGMenuNiv2ID = A344SGMenuNiv2ID;
            A348UsuCod = AV10UsuCod;
            A342SGMenuPrograma = AV9SGMenuPrograma;
            A1857SGUsuN1New = 0;
            A1859SGUsuN1Upd = 0;
            A1855SGUsuN1Del = 0;
            A1856SGUsuN1DSP = 0;
            A1858SGUsuN1Tot = 1;
            /* Using cursor P001L8 */
            pr_default.execute(6, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A1857SGUsuN1New, A1859SGUsuN1Upd, A1855SGUsuN1Del, A1856SGUsuN1DSP, A1858SGUsuN1Tot});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV2");
            if ( (pr_default.getStatus(6) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            A342SGMenuPrograma = W342SGMenuPrograma;
            A343SGMenuNiv1ID = W343SGMenuNiv1ID;
            A344SGMenuNiv2ID = W344SGMenuNiv2ID;
            /* End Insert */
            A342SGMenuPrograma = W342SGMenuPrograma;
            pr_default.readNext(5);
         }
         pr_default.close(5);
         /* Using cursor P001L9 */
         pr_default.execute(7, new Object[] {AV9SGMenuPrograma});
         while ( (pr_default.getStatus(7) != 101) )
         {
            A345SGMenuNiv3ID = P001L9_A345SGMenuNiv3ID[0];
            A344SGMenuNiv2ID = P001L9_A344SGMenuNiv2ID[0];
            A343SGMenuNiv1ID = P001L9_A343SGMenuNiv1ID[0];
            A342SGMenuPrograma = P001L9_A342SGMenuPrograma[0];
            A1853SGMenuNiv3Dsc = P001L9_A1853SGMenuNiv3Dsc[0];
            W342SGMenuPrograma = A342SGMenuPrograma;
            /*
               INSERT RECORD ON TABLE SGUSUARIONIV3

            */
            W342SGMenuPrograma = A342SGMenuPrograma;
            W343SGMenuNiv1ID = A343SGMenuNiv1ID;
            W344SGMenuNiv2ID = A344SGMenuNiv2ID;
            W345SGMenuNiv3ID = A345SGMenuNiv3ID;
            A348UsuCod = AV10UsuCod;
            A342SGMenuPrograma = AV9SGMenuPrograma;
            A1862SGUsuN2New = 0;
            A1864SGUsuN2Upd = 0;
            A1860SGUsuN2Del = 0;
            A1861SGUsuN2DSP = 0;
            A1863SGUsuN2Tot = 1;
            /* Using cursor P001L10 */
            pr_default.execute(8, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID, A345SGMenuNiv3ID, A1862SGUsuN2New, A1864SGUsuN2Upd, A1860SGUsuN2Del, A1861SGUsuN2DSP, A1863SGUsuN2Tot});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV3");
            if ( (pr_default.getStatus(8) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            A342SGMenuPrograma = W342SGMenuPrograma;
            A343SGMenuNiv1ID = W343SGMenuNiv1ID;
            A344SGMenuNiv2ID = W344SGMenuNiv2ID;
            A345SGMenuNiv3ID = W345SGMenuNiv3ID;
            /* End Insert */
            A342SGMenuPrograma = W342SGMenuPrograma;
            pr_default.readNext(7);
         }
         pr_default.close(7);
         context.CommitDataStores("seguridad.pactualizausuarioadministrador",pr_default);
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
         AV9SGMenuPrograma = "";
         AV11Session = context.GetSession();
         scmdbuf = "";
         P001L5_A343SGMenuNiv1ID = new string[] {""} ;
         P001L5_A342SGMenuPrograma = new string[] {""} ;
         P001L5_A1850SGMenuNiv1Dsc = new string[] {""} ;
         A343SGMenuNiv1ID = "";
         A342SGMenuPrograma = "";
         A1850SGMenuNiv1Dsc = "";
         W342SGMenuPrograma = "";
         W343SGMenuNiv1ID = "";
         A348UsuCod = "";
         Gx_emsg = "";
         P001L7_A344SGMenuNiv2ID = new string[] {""} ;
         P001L7_A343SGMenuNiv1ID = new string[] {""} ;
         P001L7_A342SGMenuPrograma = new string[] {""} ;
         P001L7_A1851SGMenuNiv2Dsc = new string[] {""} ;
         A344SGMenuNiv2ID = "";
         A1851SGMenuNiv2Dsc = "";
         W344SGMenuNiv2ID = "";
         P001L9_A345SGMenuNiv3ID = new string[] {""} ;
         P001L9_A344SGMenuNiv2ID = new string[] {""} ;
         P001L9_A343SGMenuNiv1ID = new string[] {""} ;
         P001L9_A342SGMenuPrograma = new string[] {""} ;
         P001L9_A1853SGMenuNiv3Dsc = new string[] {""} ;
         A345SGMenuNiv3ID = "";
         A1853SGMenuNiv3Dsc = "";
         W345SGMenuNiv3ID = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.pactualizausuarioadministrador__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.pactualizausuarioadministrador__default(),
            new Object[][] {
                new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P001L5_A343SGMenuNiv1ID, P001L5_A342SGMenuPrograma, P001L5_A1850SGMenuNiv1Dsc
               }
               , new Object[] {
               }
               , new Object[] {
               P001L7_A344SGMenuNiv2ID, P001L7_A343SGMenuNiv1ID, P001L7_A342SGMenuPrograma, P001L7_A1851SGMenuNiv2Dsc
               }
               , new Object[] {
               }
               , new Object[] {
               P001L9_A345SGMenuNiv3ID, P001L9_A344SGMenuNiv2ID, P001L9_A343SGMenuNiv1ID, P001L9_A342SGMenuPrograma, P001L9_A1853SGMenuNiv3Dsc
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2015UsuModuloSts ;
      private short A1857SGUsuN1New ;
      private short A1859SGUsuN1Upd ;
      private short A1855SGUsuN1Del ;
      private short A1856SGUsuN1DSP ;
      private short A1858SGUsuN1Tot ;
      private short A1862SGUsuN2New ;
      private short A1864SGUsuN2Upd ;
      private short A1860SGUsuN2Del ;
      private short A1861SGUsuN2DSP ;
      private short A1863SGUsuN2Tot ;
      private int GX_INS29 ;
      private int GX_INS30 ;
      private int GX_INS31 ;
      private string AV10UsuCod ;
      private string scmdbuf ;
      private string A348UsuCod ;
      private string Gx_emsg ;
      private string AV9SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string A342SGMenuPrograma ;
      private string A1850SGMenuNiv1Dsc ;
      private string W342SGMenuPrograma ;
      private string W343SGMenuNiv1ID ;
      private string A344SGMenuNiv2ID ;
      private string A1851SGMenuNiv2Dsc ;
      private string W344SGMenuNiv2ID ;
      private string A345SGMenuNiv3ID ;
      private string A1853SGMenuNiv3Dsc ;
      private string W345SGMenuNiv3ID ;
      private IGxSession AV11Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_UsuCod ;
      private IDataStoreProvider pr_default ;
      private string[] P001L5_A343SGMenuNiv1ID ;
      private string[] P001L5_A342SGMenuPrograma ;
      private string[] P001L5_A1850SGMenuNiv1Dsc ;
      private string[] P001L7_A344SGMenuNiv2ID ;
      private string[] P001L7_A343SGMenuNiv1ID ;
      private string[] P001L7_A342SGMenuPrograma ;
      private string[] P001L7_A1851SGMenuNiv2Dsc ;
      private string[] P001L9_A345SGMenuNiv3ID ;
      private string[] P001L9_A344SGMenuNiv2ID ;
      private string[] P001L9_A343SGMenuNiv1ID ;
      private string[] P001L9_A342SGMenuPrograma ;
      private string[] P001L9_A1853SGMenuNiv3Dsc ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pactualizausuarioadministrador__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pactualizausuarioadministrador__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new UpdateCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP001L2;
        prmP001L2 = new Object[] {
        new ParDef("@AV10UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L3;
        prmP001L3 = new Object[] {
        new ParDef("@AV10UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L4;
        prmP001L4 = new Object[] {
        new ParDef("@AV10UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L5;
        prmP001L5 = new Object[] {
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L6;
        prmP001L6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@UsuModuloSts",GXType.Int16,1,0)
        };
        Object[] prmP001L7;
        prmP001L7 = new Object[] {
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L8;
        prmP001L8 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGUsuN1New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Tot",GXType.Int16,1,0)
        };
        Object[] prmP001L9;
        prmP001L9 = new Object[] {
        new ParDef("@AV9SGMenuPrograma",GXType.NVarChar,20,0)
        };
        Object[] prmP001L10;
        prmP001L10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGMenuNiv3ID",GXType.NVarChar,5,0) ,
        new ParDef("@SGUsuN2New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN2Tot",GXType.Int16,1,0)
        };
        def= new CursorDef[] {
            new CursorDef("P001L2", "DELETE FROM [SGUSUARIONIV3]  WHERE [UsuCod] = @AV10UsuCod and [SGMenuPrograma] = @AV9SGMenuPrograma", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001L2)
           ,new CursorDef("P001L3", "DELETE FROM [SGUSUARIONIV2]  WHERE [UsuCod] = @AV10UsuCod and [SGMenuPrograma] = @AV9SGMenuPrograma", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001L3)
           ,new CursorDef("P001L4", "DELETE FROM [SGUSUARIONIV1]  WHERE [UsuCod] = @AV10UsuCod and [SGMenuPrograma] = @AV9SGMenuPrograma", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP001L4)
           ,new CursorDef("P001L5", "SELECT [SGMenuNiv1ID], [SGMenuPrograma], [SGMenuNiv1Dsc] FROM [SGMENUNIV1] WHERE [SGMenuPrograma] = @AV9SGMenuPrograma ORDER BY [SGMenuPrograma] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P001L6", "INSERT INTO [SGUSUARIONIV1]([UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [UsuModuloSts]) VALUES(@UsuCod, @SGMenuPrograma, @SGMenuNiv1ID, @UsuModuloSts)", GxErrorMask.GX_NOMASK,prmP001L6)
           ,new CursorDef("P001L7", "SELECT [SGMenuNiv2ID], [SGMenuNiv1ID], [SGMenuPrograma], [SGMenuNiv2Dsc] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @AV9SGMenuPrograma ORDER BY [SGMenuPrograma] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P001L8", "INSERT INTO [SGUSUARIONIV2]([UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGUsuN1New], [SGUsuN1Upd], [SGUsuN1Del], [SGUsuN1DSP], [SGUsuN1Tot]) VALUES(@UsuCod, @SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv2ID, @SGUsuN1New, @SGUsuN1Upd, @SGUsuN1Del, @SGUsuN1DSP, @SGUsuN1Tot)", GxErrorMask.GX_NOMASK,prmP001L8)
           ,new CursorDef("P001L9", "SELECT [SGMenuNiv3ID], [SGMenuNiv2ID], [SGMenuNiv1ID], [SGMenuPrograma], [SGMenuNiv3Dsc] FROM [SGMENUNIV3] WHERE [SGMenuPrograma] = @AV9SGMenuPrograma ORDER BY [SGMenuPrograma] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001L9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P001L10", "INSERT INTO [SGUSUARIONIV3]([UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID], [SGUsuN2New], [SGUsuN2Upd], [SGUsuN2Del], [SGUsuN2DSP], [SGUsuN2Tot]) VALUES(@UsuCod, @SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv2ID, @SGMenuNiv3ID, @SGUsuN2New, @SGUsuN2Upd, @SGUsuN2Del, @SGUsuN2DSP, @SGUsuN2Tot)", GxErrorMask.GX_NOMASK,prmP001L10)
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
     }
  }

}

}
