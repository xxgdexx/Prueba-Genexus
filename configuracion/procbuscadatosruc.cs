using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
   public class procbuscadatosruc : GXProcedure
   {
      public procbuscadatosruc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public procbuscadatosruc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_RUC ,
                           out string aP1_CliDsc ,
                           out string aP2_CliDir ,
                           out string aP3_Estado ,
                           out string aP4_EstCod ,
                           out string aP5_ProvCod ,
                           out string aP6_DisCod ,
                           out string aP7_Condicion )
      {
         this.AV19RUC = aP0_RUC;
         this.AV10CliDsc = "" ;
         this.AV9CliDir = "" ;
         this.AV16Estado = "" ;
         this.AV17EstCod = "" ;
         this.AV18ProvCod = "" ;
         this.AV12DisCod = "" ;
         this.AV11Condicion = "" ;
         initialize();
         executePrivate();
         aP1_CliDsc=this.AV10CliDsc;
         aP2_CliDir=this.AV9CliDir;
         aP3_Estado=this.AV16Estado;
         aP4_EstCod=this.AV17EstCod;
         aP5_ProvCod=this.AV18ProvCod;
         aP6_DisCod=this.AV12DisCod;
         aP7_Condicion=this.AV11Condicion;
      }

      public string executeUdp( string aP0_RUC ,
                                out string aP1_CliDsc ,
                                out string aP2_CliDir ,
                                out string aP3_Estado ,
                                out string aP4_EstCod ,
                                out string aP5_ProvCod ,
                                out string aP6_DisCod )
      {
         execute(aP0_RUC, out aP1_CliDsc, out aP2_CliDir, out aP3_Estado, out aP4_EstCod, out aP5_ProvCod, out aP6_DisCod, out aP7_Condicion);
         return AV11Condicion ;
      }

      public void executeSubmit( string aP0_RUC ,
                                 out string aP1_CliDsc ,
                                 out string aP2_CliDir ,
                                 out string aP3_Estado ,
                                 out string aP4_EstCod ,
                                 out string aP5_ProvCod ,
                                 out string aP6_DisCod ,
                                 out string aP7_Condicion )
      {
         procbuscadatosruc objprocbuscadatosruc;
         objprocbuscadatosruc = new procbuscadatosruc();
         objprocbuscadatosruc.AV19RUC = aP0_RUC;
         objprocbuscadatosruc.AV10CliDsc = "" ;
         objprocbuscadatosruc.AV9CliDir = "" ;
         objprocbuscadatosruc.AV16Estado = "" ;
         objprocbuscadatosruc.AV17EstCod = "" ;
         objprocbuscadatosruc.AV18ProvCod = "" ;
         objprocbuscadatosruc.AV12DisCod = "" ;
         objprocbuscadatosruc.AV11Condicion = "" ;
         objprocbuscadatosruc.context.SetSubmitInitialConfig(context);
         objprocbuscadatosruc.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprocbuscadatosruc);
         aP1_CliDsc=this.AV10CliDsc;
         aP2_CliDir=this.AV9CliDir;
         aP3_Estado=this.AV16Estado;
         aP4_EstCod=this.AV17EstCod;
         aP5_ProvCod=this.AV18ProvCod;
         aP6_DisCod=this.AV12DisCod;
         aP7_Condicion=this.AV11Condicion;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((procbuscadatosruc)stateInfo).executePrivate();
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
         AV8Cadena = AV22wsConsultaSunat.consultaruc(AV19RUC);
         AV20SoapErr = context.GetSoapErr( );
         if ( AV20SoapErr != 0 )
         {
            AV21SoapMsg = "Error al invocar el servicio:" + StringUtil.NewLine( ) + context.GetSoapErrMsg( );
            GX_msglist.addItem(AV21SoapMsg);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8Cadena)) )
         {
            AV14ejecadena = StringUtil.Trim( AV8Cadena);
            AV13ejeaux = GxRegex.Split(AV14ejecadena,";");
            AV10CliDsc = StringUtil.Trim( AV13ejeaux.GetString(2));
            AV9CliDir = StringUtil.Trim( AV13ejeaux.GetString(6));
            AV16Estado = StringUtil.Trim( AV13ejeaux.GetString(3));
            AV11Condicion = StringUtil.Trim( AV13ejeaux.GetString(4));
            AV17EstCod = StringUtil.Substring( StringUtil.Trim( AV13ejeaux.GetString(5)), 1, 2);
            AV18ProvCod = StringUtil.Substring( StringUtil.Trim( AV13ejeaux.GetString(5)), 3, 2);
            AV12DisCod = StringUtil.Substring( StringUtil.Trim( AV13ejeaux.GetString(5)), 5, 2);
         }
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
         AV10CliDsc = "";
         AV9CliDir = "";
         AV16Estado = "";
         AV17EstCod = "";
         AV18ProvCod = "";
         AV12DisCod = "";
         AV11Condicion = "";
         AV8Cadena = "";
         AV22wsConsultaSunat = new SdtwsConsultaSunat(context);
         AV21SoapMsg = "";
         AV14ejecadena = "";
         AV13ejeaux = new GxSimpleCollection<string>();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private long AV20SoapErr ;
      private string AV10CliDsc ;
      private string AV9CliDir ;
      private string AV17EstCod ;
      private string AV18ProvCod ;
      private string AV12DisCod ;
      private string AV19RUC ;
      private string AV16Estado ;
      private string AV11Condicion ;
      private string AV8Cadena ;
      private string AV21SoapMsg ;
      private string AV14ejecadena ;
      private SdtwsConsultaSunat AV22wsConsultaSunat ;
      private string aP1_CliDsc ;
      private string aP2_CliDir ;
      private string aP3_Estado ;
      private string aP4_EstCod ;
      private string aP5_ProvCod ;
      private string aP6_DisCod ;
      private string aP7_Condicion ;
      private GxSimpleCollection<string> AV13ejeaux ;
   }

}
