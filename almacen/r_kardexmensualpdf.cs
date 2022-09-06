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
namespace GeneXus.Programs.almacen {
   public class r_kardexmensualpdf : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "almacen.r_kardexmensualpdf.aspx")), "almacen.r_kardexmensualpdf.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "almacen.r_kardexmensualpdf.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "LinCod");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV17LinCod = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV27SubLCod = (int)(NumberUtil.Val( GetPar( "SubLCod"), "."));
                  AV14FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AV9AlmCod = (int)(NumberUtil.Val( GetPar( "AlmCod"), "."));
                  AV20Prodcod = GetPar( "Prodcod");
                  AV19nOrden = (short)(NumberUtil.Val( GetPar( "nOrden"), "."));
                  AV15FDesde = context.localUtil.ParseDateParm( GetPar( "FDesde"));
               }
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public r_kardexmensualpdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_kardexmensualpdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref int aP0_LinCod ,
                           ref int aP1_SubLCod ,
                           ref int aP2_FamCod ,
                           ref int aP3_AlmCod ,
                           ref string aP4_Prodcod ,
                           ref short aP5_nOrden ,
                           ref DateTime aP6_FDesde )
      {
         this.AV17LinCod = aP0_LinCod;
         this.AV27SubLCod = aP1_SubLCod;
         this.AV14FamCod = aP2_FamCod;
         this.AV9AlmCod = aP3_AlmCod;
         this.AV20Prodcod = aP4_Prodcod;
         this.AV19nOrden = aP5_nOrden;
         this.AV15FDesde = aP6_FDesde;
         initialize();
         executePrivate();
         aP0_LinCod=this.AV17LinCod;
         aP1_SubLCod=this.AV27SubLCod;
         aP2_FamCod=this.AV14FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV20Prodcod;
         aP5_nOrden=this.AV19nOrden;
         aP6_FDesde=this.AV15FDesde;
      }

      public DateTime executeUdp( ref int aP0_LinCod ,
                                  ref int aP1_SubLCod ,
                                  ref int aP2_FamCod ,
                                  ref int aP3_AlmCod ,
                                  ref string aP4_Prodcod ,
                                  ref short aP5_nOrden )
      {
         execute(ref aP0_LinCod, ref aP1_SubLCod, ref aP2_FamCod, ref aP3_AlmCod, ref aP4_Prodcod, ref aP5_nOrden, ref aP6_FDesde);
         return AV15FDesde ;
      }

      public void executeSubmit( ref int aP0_LinCod ,
                                 ref int aP1_SubLCod ,
                                 ref int aP2_FamCod ,
                                 ref int aP3_AlmCod ,
                                 ref string aP4_Prodcod ,
                                 ref short aP5_nOrden ,
                                 ref DateTime aP6_FDesde )
      {
         r_kardexmensualpdf objr_kardexmensualpdf;
         objr_kardexmensualpdf = new r_kardexmensualpdf();
         objr_kardexmensualpdf.AV17LinCod = aP0_LinCod;
         objr_kardexmensualpdf.AV27SubLCod = aP1_SubLCod;
         objr_kardexmensualpdf.AV14FamCod = aP2_FamCod;
         objr_kardexmensualpdf.AV9AlmCod = aP3_AlmCod;
         objr_kardexmensualpdf.AV20Prodcod = aP4_Prodcod;
         objr_kardexmensualpdf.AV19nOrden = aP5_nOrden;
         objr_kardexmensualpdf.AV15FDesde = aP6_FDesde;
         objr_kardexmensualpdf.context.SetSubmitInitialConfig(context);
         objr_kardexmensualpdf.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_kardexmensualpdf);
         aP0_LinCod=this.AV17LinCod;
         aP1_SubLCod=this.AV27SubLCod;
         aP2_FamCod=this.AV14FamCod;
         aP3_AlmCod=this.AV9AlmCod;
         aP4_Prodcod=this.AV20Prodcod;
         aP5_nOrden=this.AV19nOrden;
         aP6_FDesde=this.AV15FDesde;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_kardexmensualpdf)stateInfo).executePrivate();
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
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         GXDecQS = "";
         gxfirstwebparm = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GxWebError ;
      private short nGotPars ;
      private short AV19nOrden ;
      private int AV17LinCod ;
      private int AV27SubLCod ;
      private int AV14FamCod ;
      private int AV9AlmCod ;
      private string GXKey ;
      private string GXDecQS ;
      private string gxfirstwebparm ;
      private string AV20Prodcod ;
      private DateTime AV15FDesde ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private int aP0_LinCod ;
      private int aP1_SubLCod ;
      private int aP2_FamCod ;
      private int aP3_AlmCod ;
      private string aP4_Prodcod ;
      private short aP5_nOrden ;
      private DateTime aP6_FDesde ;
   }

}
