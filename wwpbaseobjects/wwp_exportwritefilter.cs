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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_exportwritefilter : GXProcedure
   {
      public wwp_exportwritefilter( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwp_exportwritefilter( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( ref ExcelDocumentI aP0_ExcelDocument ,
                           bool aP1_AddRow ,
                           ref short aP2_CellRow ,
                           short aP3_FirstColumn ,
                           string aP4_FilterDsc )
      {
         this.AV10ExcelDocument = aP0_ExcelDocument;
         this.AV8AddRow = aP1_AddRow;
         this.AV9CellRow = aP2_CellRow;
         this.AV12FirstColumn = aP3_FirstColumn;
         this.AV11FilterDsc = aP4_FilterDsc;
         initialize();
         executePrivate();
         aP0_ExcelDocument=this.AV10ExcelDocument;
         aP2_CellRow=this.AV9CellRow;
      }

      public void executeSubmit( ref ExcelDocumentI aP0_ExcelDocument ,
                                 bool aP1_AddRow ,
                                 ref short aP2_CellRow ,
                                 short aP3_FirstColumn ,
                                 string aP4_FilterDsc )
      {
         wwp_exportwritefilter objwwp_exportwritefilter;
         objwwp_exportwritefilter = new wwp_exportwritefilter();
         objwwp_exportwritefilter.AV10ExcelDocument = aP0_ExcelDocument;
         objwwp_exportwritefilter.AV8AddRow = aP1_AddRow;
         objwwp_exportwritefilter.AV9CellRow = aP2_CellRow;
         objwwp_exportwritefilter.AV12FirstColumn = aP3_FirstColumn;
         objwwp_exportwritefilter.AV11FilterDsc = aP4_FilterDsc;
         objwwp_exportwritefilter.context.SetSubmitInitialConfig(context);
         objwwp_exportwritefilter.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwp_exportwritefilter);
         aP0_ExcelDocument=this.AV10ExcelDocument;
         aP2_CellRow=this.AV9CellRow;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwp_exportwritefilter)stateInfo).executePrivate();
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
         if ( AV8AddRow )
         {
            AV9CellRow = (short)(AV9CellRow+1);
         }
         AV10ExcelDocument.get_Cells(AV9CellRow, AV12FirstColumn, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV9CellRow, AV12FirstColumn, 1, 1).Color = 3;
         AV10ExcelDocument.get_Cells(AV9CellRow, AV12FirstColumn, 1, 1).Text = AV11FilterDsc;
         AV10ExcelDocument.get_Cells(AV9CellRow, AV12FirstColumn+1, 1, 1).Italic = 1;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV9CellRow ;
      private short AV12FirstColumn ;
      private bool AV8AddRow ;
      private string AV11FilterDsc ;
      private ExcelDocumentI aP0_ExcelDocument ;
      private short aP2_CellRow ;
      private ExcelDocumentI AV10ExcelDocument ;
   }

}
