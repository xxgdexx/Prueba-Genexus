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
namespace GeneXus.Programs.reloj_interface {
   public class pa_grabalecturareloj : GXProcedure
   {
      public pa_grabalecturareloj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pa_grabalecturareloj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_message )
      {
         this.AV18message = aP0_message;
         initialize();
         executePrivate();
         aP0_message=this.AV18message;
      }

      public string executeUdp( )
      {
         execute(ref aP0_message);
         return AV18message ;
      }

      public void executeSubmit( ref string aP0_message )
      {
         pa_grabalecturareloj objpa_grabalecturareloj;
         objpa_grabalecturareloj = new pa_grabalecturareloj();
         objpa_grabalecturareloj.AV18message = aP0_message;
         objpa_grabalecturareloj.context.SetSubmitInitialConfig(context);
         objpa_grabalecturareloj.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpa_grabalecturareloj);
         aP0_message=this.AV18message;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pa_grabalecturareloj)stateInfo).executePrivate();
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
         /* Using cursor P00GL2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2467id = P00GL2_A2467id[0];
            A2468Cod_EmpReloj = P00GL2_A2468Cod_EmpReloj[0];
            A2380Nombre = P00GL2_A2380Nombre[0];
            A2469Apellido = P00GL2_A2469Apellido[0];
            A2470Marcacion = P00GL2_A2470Marcacion[0];
            A2471Fec_Marcacion = P00GL2_A2471Fec_Marcacion[0];
            A2472Hor_Marcacion = P00GL2_A2472Hor_Marcacion[0];
            A2473Anio = P00GL2_A2473Anio[0];
            A2474mes = P00GL2_A2474mes[0];
            A2475dia = P00GL2_A2475dia[0];
            AV8id = A2467id;
            AV9Cod_EmpReloj = A2468Cod_EmpReloj;
            AV10Nombre = A2380Nombre;
            AV11Apellido = A2469Apellido;
            AV12Marcacion = A2470Marcacion;
            AV13Fec_Marcacion = A2471Fec_Marcacion;
            AV14Hor_Marcacion = A2472Hor_Marcacion;
            AV15Anio = A2473Anio;
            AV16mes = A2474mes;
            AV17dia = A2475dia;
            /*
               INSERT RECORD ON TABLE Reloj_Lecturas

            */
            A2577Id_Lee = AV8id;
            A2578CodEmp_Lee = AV9Cod_EmpReloj;
            A2579NomEmp_Lee = AV10Nombre;
            A2580ApeEmp_Lee = AV11Apellido;
            A2581Marca_Lee = AV12Marcacion;
            A2582Fec_Lee = AV13Fec_Marcacion;
            A2583Hora_Lee = AV14Hor_Marcacion;
            A2584anio_Lee = (short)(AV15Anio);
            A2585Mes_Lee = (short)(AV16mes);
            A2586Dia_Lee = (short)(AV17dia);
            /* Using cursor P00GL3 */
            pr_default.execute(1, new Object[] {A2577Id_Lee, A2578CodEmp_Lee, A2579NomEmp_Lee, A2580ApeEmp_Lee, A2581Marca_Lee, A2582Fec_Lee, A2583Hora_Lee, A2584anio_Lee, A2585Mes_Lee, A2586Dia_Lee});
            pr_default.close(1);
            dsDefault.SmartCacheProvider.SetUpdated("Reloj_Lecturas");
            if ( (pr_default.getStatus(1) == 1) )
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.CommitDataStores("reloj_interface.pa_grabalecturareloj",pr_default);
         AV18message = "Se registró Exitosamente en SIG";
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("reloj_interface.pa_grabalecturareloj",pr_default);
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
         P00GL2_A2467id = new int[1] ;
         P00GL2_A2468Cod_EmpReloj = new string[] {""} ;
         P00GL2_A2380Nombre = new string[] {""} ;
         P00GL2_A2469Apellido = new string[] {""} ;
         P00GL2_A2470Marcacion = new string[] {""} ;
         P00GL2_A2471Fec_Marcacion = new string[] {""} ;
         P00GL2_A2472Hor_Marcacion = new string[] {""} ;
         P00GL2_A2473Anio = new int[1] ;
         P00GL2_A2474mes = new int[1] ;
         P00GL2_A2475dia = new int[1] ;
         A2468Cod_EmpReloj = "";
         A2380Nombre = "";
         A2469Apellido = "";
         A2470Marcacion = "";
         A2471Fec_Marcacion = "";
         A2472Hor_Marcacion = "";
         AV9Cod_EmpReloj = "";
         AV10Nombre = "";
         AV11Apellido = "";
         AV12Marcacion = "";
         AV13Fec_Marcacion = "";
         AV14Hor_Marcacion = "";
         A2578CodEmp_Lee = "";
         A2579NomEmp_Lee = "";
         A2580ApeEmp_Lee = "";
         A2581Marca_Lee = "";
         A2582Fec_Lee = "";
         A2583Hora_Lee = "";
         Gx_emsg = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.pa_grabalecturareloj__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.pa_grabalecturareloj__default(),
            new Object[][] {
                new Object[] {
               P00GL2_A2467id, P00GL2_A2468Cod_EmpReloj, P00GL2_A2380Nombre, P00GL2_A2469Apellido, P00GL2_A2470Marcacion, P00GL2_A2471Fec_Marcacion, P00GL2_A2472Hor_Marcacion, P00GL2_A2473Anio, P00GL2_A2474mes, P00GL2_A2475dia
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2584anio_Lee ;
      private short A2585Mes_Lee ;
      private short A2586Dia_Lee ;
      private int A2467id ;
      private int A2473Anio ;
      private int A2474mes ;
      private int A2475dia ;
      private int AV8id ;
      private int AV15Anio ;
      private int AV16mes ;
      private int AV17dia ;
      private int GX_INS221 ;
      private long A2577Id_Lee ;
      private string scmdbuf ;
      private string Gx_emsg ;
      private string AV18message ;
      private string A2468Cod_EmpReloj ;
      private string A2380Nombre ;
      private string A2469Apellido ;
      private string A2470Marcacion ;
      private string A2471Fec_Marcacion ;
      private string A2472Hor_Marcacion ;
      private string AV9Cod_EmpReloj ;
      private string AV10Nombre ;
      private string AV11Apellido ;
      private string AV12Marcacion ;
      private string AV13Fec_Marcacion ;
      private string AV14Hor_Marcacion ;
      private string A2578CodEmp_Lee ;
      private string A2579NomEmp_Lee ;
      private string A2580ApeEmp_Lee ;
      private string A2581Marca_Lee ;
      private string A2582Fec_Lee ;
      private string A2583Hora_Lee ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private string aP0_message ;
      private IDataStoreProvider pr_default ;
      private int[] P00GL2_A2467id ;
      private string[] P00GL2_A2468Cod_EmpReloj ;
      private string[] P00GL2_A2380Nombre ;
      private string[] P00GL2_A2469Apellido ;
      private string[] P00GL2_A2470Marcacion ;
      private string[] P00GL2_A2471Fec_Marcacion ;
      private string[] P00GL2_A2472Hor_Marcacion ;
      private int[] P00GL2_A2473Anio ;
      private int[] P00GL2_A2474mes ;
      private int[] P00GL2_A2475dia ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class pa_grabalecturareloj__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class pa_grabalecturareloj__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00GL2;
        prmP00GL2 = new Object[] {
        };
        Object[] prmP00GL3;
        prmP00GL3 = new Object[] {
        new ParDef("@Id_Lee",GXType.Decimal,12,0) ,
        new ParDef("@CodEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@NomEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@ApeEmp_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Marca_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Fec_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@Hora_Lee",GXType.NVarChar,25,0) ,
        new ParDef("@anio_Lee",GXType.Int16,4,0) ,
        new ParDef("@Mes_Lee",GXType.Int16,2,0) ,
        new ParDef("@Dia_Lee",GXType.Int16,2,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00GL2", "SELECT [id], [Cod_EmpReloj], [Nombre], [Apellido], [Marcacion], [Fec_Marcacion], [Hor_Marcacion], [Anio], [mes], [dia] FROM [V_Reloj_Asistencia] ORDER BY [id] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GL2,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00GL3", "INSERT INTO [Reloj_Lecturas]([Id_Lee], [CodEmp_Lee], [NomEmp_Lee], [ApeEmp_Lee], [Marca_Lee], [Fec_Lee], [Hora_Lee], [anio_Lee], [Mes_Lee], [Dia_Lee]) VALUES(@Id_Lee, @CodEmp_Lee, @NomEmp_Lee, @ApeEmp_Lee, @Marca_Lee, @Fec_Lee, @Hora_Lee, @anio_Lee, @Mes_Lee, @Dia_Lee)", GxErrorMask.GX_NOMASK,prmP00GL3)
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
     }
  }

}

}
