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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.seguridad {
   public class cierremoduloswwexport : GXProcedure
   {
      public cierremoduloswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cierremoduloswwexport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_Filename ,
                           out string aP1_ErrorMessage )
      {
         this.AV11Filename = "" ;
         this.AV12ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      public string executeUdp( out string aP0_Filename )
      {
         execute(out aP0_Filename, out aP1_ErrorMessage);
         return AV12ErrorMessage ;
      }

      public void executeSubmit( out string aP0_Filename ,
                                 out string aP1_ErrorMessage )
      {
         cierremoduloswwexport objcierremoduloswwexport;
         objcierremoduloswwexport = new cierremoduloswwexport();
         objcierremoduloswwexport.AV11Filename = "" ;
         objcierremoduloswwexport.AV12ErrorMessage = "" ;
         objcierremoduloswwexport.context.SetSubmitInitialConfig(context);
         objcierremoduloswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcierremoduloswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cierremoduloswwexport)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'OPENDOCUMENT' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13CellRow = 1;
         AV14FirstColumn = 1;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S191 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEFILTERS' */
         S131 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITECOLUMNTITLES' */
         S141 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'WRITEDATA' */
         S151 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         /* Execute user subroutine: 'CLOSEDOCUMENT' */
         S181 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'OPENDOCUMENT' Routine */
         returnInSub = false;
         AV15Random = (int)(NumberUtil.Random( )*10000);
         AV11Filename = "CierreModulosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
         AV10ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Clear();
      }

      protected void S131( )
      {
         /* 'WRITEFILTERS' Routine */
         returnInSub = false;
         if ( ! ( (0==AV50CMModAno) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Año") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV50CMModAno;
         }
         if ( ! ( (0==AV51CMModMes) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Mes") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( AV51CMModMes == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Enero";
            }
            else if ( AV51CMModMes == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Febrero";
            }
            else if ( AV51CMModMes == 3 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marzo";
            }
            else if ( AV51CMModMes == 4 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Abril";
            }
            else if ( AV51CMModMes == 5 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Mayo";
            }
            else if ( AV51CMModMes == 6 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Junio";
            }
            else if ( AV51CMModMes == 7 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Julio";
            }
            else if ( AV51CMModMes == 8 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Agosto";
            }
            else if ( AV51CMModMes == 9 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Setiembre";
            }
            else if ( AV51CMModMes == 10 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Octubre";
            }
            else if ( AV51CMModMes == 11 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Noviembre";
            }
            else if ( AV51CMModMes == 12 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Diciembre";
            }
         }
         if ( ! ( (0==AV36TFCMModAno) && (0==AV37TFCMModAno_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Año") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV36TFCMModAno;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV37TFCMModAno_To;
         }
         if ( ! ( ( AV53TFCMModMes_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Mes") ;
            AV13CellRow = GXt_int1;
            AV60i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV53TFCMModMes_Sels.Count )
            {
               AV54TFCMModMes_Sel = (short)(AV53TFCMModMes_Sels.GetNumeric(AV63GXV1));
               if ( AV60i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV54TFCMModMes_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Enero";
               }
               else if ( AV54TFCMModMes_Sel == 2 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Febrero";
               }
               else if ( AV54TFCMModMes_Sel == 3 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Marzo";
               }
               else if ( AV54TFCMModMes_Sel == 4 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Abril";
               }
               else if ( AV54TFCMModMes_Sel == 5 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Mayo";
               }
               else if ( AV54TFCMModMes_Sel == 6 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Junio";
               }
               else if ( AV54TFCMModMes_Sel == 7 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Julio";
               }
               else if ( AV54TFCMModMes_Sel == 8 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Agosto";
               }
               else if ( AV54TFCMModMes_Sel == 9 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Setiembre";
               }
               else if ( AV54TFCMModMes_Sel == 10 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Octubre";
               }
               else if ( AV54TFCMModMes_Sel == 11 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Noviembre";
               }
               else if ( AV54TFCMModMes_Sel == 12 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Diciembre";
               }
               AV60i = (long)(AV60i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
         }
         if ( ! ( ( AV56TFCMModCod_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Modulo") ;
            AV13CellRow = GXt_int1;
            AV60i = 1;
            AV64GXV2 = 1;
            while ( AV64GXV2 <= AV56TFCMModCod_Sels.Count )
            {
               AV35TFCMModCod_Sel = AV56TFCMModCod_Sels.GetString(AV64GXV2);
               if ( AV60i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "ALM") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Almacenes";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "CLI") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Ventas";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "PRV") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Compras";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "TES") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Bancos";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "CON") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Contabilidad";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "PRO") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Produccion";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "PLA") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Planilla";
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV35TFCMModCod_Sel), "ACT") == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Activos Fijos";
               }
               AV60i = (long)(AV60i+1);
               AV64GXV2 = (int)(AV64GXV2+1);
            }
         }
         if ( ! ( ( AV58TFCMModSts_Sels.Count == 0 ) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int1;
            AV60i = 1;
            AV65GXV3 = 1;
            while ( AV65GXV3 <= AV58TFCMModSts_Sels.Count )
            {
               AV59TFCMModSts_Sel = (short)(AV58TFCMModSts_Sels.GetNumeric(AV65GXV3));
               if ( AV60i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV59TFCMModSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Abierto";
               }
               else if ( AV59TFCMModSts_Sel == 2 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"Cerrado";
               }
               AV60i = (long)(AV60i+1);
               AV65GXV3 = (int)(AV65GXV3+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCMModUsuC_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Usuario Creación") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFCMModUsuC_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFCMModUsuC)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Usuario Creación") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFCMModUsuC, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV44TFCMModFecC) && (DateTime.MinValue==AV45TFCMModFecC_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Fecha Creación") ;
            AV13CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV44TFCMModFecC ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV45TFCMModFecC_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCMModUsuM_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Usuario Modificación") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV47TFCMModUsuM_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCMModUsuM)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Usuario Modificación") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFCMModUsuM, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV48TFCMModFecM) && (DateTime.MinValue==AV49TFCMModFecM_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Fecha Modificación") ;
            AV13CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV48TFCMModFecM ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime3;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            GXt_dtime3 = DateTimeUtil.ResetTime( AV49TFCMModFecM_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime3;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Año";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Mes";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Modulo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Usuario Creación";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Fecha Creación";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Usuario Modificación";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Fecha Modificación";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV67Seguridad_cierremoduloswwds_1_cmmodano = AV50CMModAno;
         AV68Seguridad_cierremoduloswwds_2_cmmodmes = AV51CMModMes;
         AV69Seguridad_cierremoduloswwds_3_tfcmmodano = AV36TFCMModAno;
         AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV37TFCMModAno_To;
         AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV53TFCMModMes_Sels;
         AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV56TFCMModCod_Sels;
         AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV58TFCMModSts_Sels;
         AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV42TFCMModUsuC;
         AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV43TFCMModUsuC_Sel;
         AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV44TFCMModFecC;
         AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV45TFCMModFecC_To;
         AV78Seguridad_cierremoduloswwds_12_tfcmmodusum = AV46TFCMModUsuM;
         AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV47TFCMModUsuM_Sel;
         AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV48TFCMModFecM;
         AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV49TFCMModFecM_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A75CMModMes ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                              A73CMModCod ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                              A640CMModSts ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                              AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                              AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                              AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                              AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                              AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                              AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                              AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                              AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                              AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                              AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                              AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                              AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                              A74CMModAno ,
                                              A641CMModUsuC ,
                                              A638CMModFecC ,
                                              A642CMModUsuM ,
                                              A639CMModFecM ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
         lV78Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
         /* Using cursor P001O2 */
         pr_default.execute(0, new Object[] {AV67Seguridad_cierremoduloswwds_1_cmmodano, AV68Seguridad_cierremoduloswwds_2_cmmodmes, AV69Seguridad_cierremoduloswwds_3_tfcmmodano, AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV78Seguridad_cierremoduloswwds_12_tfcmmodusum, AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A639CMModFecM = P001O2_A639CMModFecM[0];
            A642CMModUsuM = P001O2_A642CMModUsuM[0];
            A638CMModFecC = P001O2_A638CMModFecC[0];
            A641CMModUsuC = P001O2_A641CMModUsuC[0];
            A640CMModSts = P001O2_A640CMModSts[0];
            A73CMModCod = P001O2_A73CMModCod[0];
            A75CMModMes = P001O2_A75CMModMes[0];
            A74CMModAno = P001O2_A74CMModAno[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A74CMModAno;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
            if ( A75CMModMes == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Enero";
            }
            else if ( A75CMModMes == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Febrero";
            }
            else if ( A75CMModMes == 3 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marzo";
            }
            else if ( A75CMModMes == 4 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Abril";
            }
            else if ( A75CMModMes == 5 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Mayo";
            }
            else if ( A75CMModMes == 6 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Junio";
            }
            else if ( A75CMModMes == 7 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Julio";
            }
            else if ( A75CMModMes == 8 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Agosto";
            }
            else if ( A75CMModMes == 9 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Setiembre";
            }
            else if ( A75CMModMes == 10 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Octubre";
            }
            else if ( A75CMModMes == 11 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Noviembre";
            }
            else if ( A75CMModMes == 12 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Diciembre";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "";
            if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "ALM") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Almacenes";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "CLI") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Ventas";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PRV") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Compras";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "TES") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Bancos";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "CON") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Contabilidad";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PRO") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Produccion";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "PLA") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Planilla";
            }
            else if ( StringUtil.StrCmp(StringUtil.Trim( A73CMModCod), "ACT") == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Activos Fijos";
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A640CMModSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Abierto";
            }
            else if ( A640CMModSts == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Cerrado";
            }
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A641CMModUsuC, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char2;
            GXt_dtime3 = DateTimeUtil.ResetTime( A638CMModFecC ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Date = GXt_dtime3;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A642CMModUsuM, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = GXt_char2;
            GXt_dtime3 = DateTimeUtil.ResetTime( A639CMModFecM ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Date = GXt_dtime3;
            /* Execute user subroutine: 'AFTERWRITELINE' */
            S172 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S181( )
      {
         /* 'CLOSEDOCUMENT' Routine */
         returnInSub = false;
         AV10ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if (returnInSub) return;
         AV10ExcelDocument.Close();
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV10ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV10ExcelDocument.ErrDescription;
            AV10ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S191( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("Seguridad.CierreModulosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV82GXV4 = 1;
         while ( AV82GXV4 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV82GXV4));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "CMMODANO") == 0 )
            {
               AV50CMModAno = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "CMMODMES") == 0 )
            {
               AV51CMModMes = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODANO") == 0 )
            {
               AV36TFCMModAno = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV37TFCMModAno_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODMES_SEL") == 0 )
            {
               AV52TFCMModMes_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV53TFCMModMes_Sels.FromJSonString(AV52TFCMModMes_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODCOD_SEL") == 0 )
            {
               AV55TFCMModCod_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV56TFCMModCod_Sels.FromJSonString(AV55TFCMModCod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODSTS_SEL") == 0 )
            {
               AV57TFCMModSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV58TFCMModSts_Sels.FromJSonString(AV57TFCMModSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC") == 0 )
            {
               AV42TFCMModUsuC = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC_SEL") == 0 )
            {
               AV43TFCMModUsuC_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODFECC") == 0 )
            {
               AV44TFCMModFecC = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV45TFCMModFecC_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM") == 0 )
            {
               AV46TFCMModUsuM = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM_SEL") == 0 )
            {
               AV47TFCMModUsuM_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCMMODFECM") == 0 )
            {
               AV48TFCMModFecM = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV49TFCMModFecM_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV82GXV4 = (int)(AV82GXV4+1);
         }
      }

      protected void S162( )
      {
         /* 'BEFOREWRITELINE' Routine */
         returnInSub = false;
      }

      protected void S172( )
      {
         /* 'AFTERWRITELINE' Routine */
         returnInSub = false;
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
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10ExcelDocument = new ExcelDocumentI();
         AV53TFCMModMes_Sels = new GxSimpleCollection<short>();
         AV56TFCMModCod_Sels = new GxSimpleCollection<string>();
         AV35TFCMModCod_Sel = "";
         AV58TFCMModSts_Sels = new GxSimpleCollection<short>();
         AV43TFCMModUsuC_Sel = "";
         AV42TFCMModUsuC = "";
         AV44TFCMModFecC = DateTime.MinValue;
         AV45TFCMModFecC_To = DateTime.MinValue;
         AV47TFCMModUsuM_Sel = "";
         AV46TFCMModUsuM = "";
         AV48TFCMModFecM = DateTime.MinValue;
         AV49TFCMModFecM_To = DateTime.MinValue;
         AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = new GxSimpleCollection<short>();
         AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = new GxSimpleCollection<string>();
         AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = new GxSimpleCollection<short>();
         AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = "";
         AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc = DateTime.MinValue;
         AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = DateTime.MinValue;
         AV78Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = "";
         AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm = DateTime.MinValue;
         AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = DateTime.MinValue;
         scmdbuf = "";
         lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         lV78Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         A73CMModCod = "";
         A641CMModUsuC = "";
         A638CMModFecC = DateTime.MinValue;
         A642CMModUsuM = "";
         A639CMModFecM = DateTime.MinValue;
         P001O2_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         P001O2_A642CMModUsuM = new string[] {""} ;
         P001O2_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         P001O2_A641CMModUsuC = new string[] {""} ;
         P001O2_A640CMModSts = new short[1] ;
         P001O2_A73CMModCod = new string[] {""} ;
         P001O2_A75CMModMes = new short[1] ;
         P001O2_A74CMModAno = new short[1] ;
         GXt_char2 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52TFCMModMes_SelsJson = "";
         AV55TFCMModCod_SelsJson = "";
         AV57TFCMModSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremoduloswwexport__default(),
            new Object[][] {
                new Object[] {
               P001O2_A639CMModFecM, P001O2_A642CMModUsuM, P001O2_A638CMModFecC, P001O2_A641CMModUsuC, P001O2_A640CMModSts, P001O2_A73CMModCod, P001O2_A75CMModMes, P001O2_A74CMModAno
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV50CMModAno ;
      private short AV51CMModMes ;
      private short AV36TFCMModAno ;
      private short AV37TFCMModAno_To ;
      private short AV54TFCMModMes_Sel ;
      private short AV59TFCMModSts_Sel ;
      private short GXt_int1 ;
      private short AV67Seguridad_cierremoduloswwds_1_cmmodano ;
      private short AV68Seguridad_cierremoduloswwds_2_cmmodmes ;
      private short AV69Seguridad_cierremoduloswwds_3_tfcmmodano ;
      private short AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short A74CMModAno ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV63GXV1 ;
      private int AV64GXV2 ;
      private int AV65GXV3 ;
      private int AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ;
      private int AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ;
      private int AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ;
      private int AV82GXV4 ;
      private long AV60i ;
      private string AV35TFCMModCod_Sel ;
      private string AV43TFCMModUsuC_Sel ;
      private string AV42TFCMModUsuC ;
      private string AV47TFCMModUsuM_Sel ;
      private string AV46TFCMModUsuM ;
      private string AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ;
      private string AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ;
      private string scmdbuf ;
      private string lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string lV78Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string A73CMModCod ;
      private string A641CMModUsuC ;
      private string A642CMModUsuM ;
      private string GXt_char2 ;
      private DateTime GXt_dtime3 ;
      private DateTime AV44TFCMModFecC ;
      private DateTime AV45TFCMModFecC_To ;
      private DateTime AV48TFCMModFecM ;
      private DateTime AV49TFCMModFecM_To ;
      private DateTime AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ;
      private DateTime AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ;
      private DateTime AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ;
      private DateTime AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private string AV52TFCMModMes_SelsJson ;
      private string AV55TFCMModCod_SelsJson ;
      private string AV57TFCMModSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private GxSimpleCollection<short> AV53TFCMModMes_Sels ;
      private GxSimpleCollection<short> AV58TFCMModSts_Sels ;
      private GxSimpleCollection<short> AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ;
      private GxSimpleCollection<short> AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P001O2_A639CMModFecM ;
      private string[] P001O2_A642CMModUsuM ;
      private DateTime[] P001O2_A638CMModFecC ;
      private string[] P001O2_A641CMModUsuC ;
      private short[] P001O2_A640CMModSts ;
      private string[] P001O2_A73CMModCod ;
      private short[] P001O2_A75CMModMes ;
      private short[] P001O2_A74CMModAno ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV56TFCMModCod_Sels ;
      private GxSimpleCollection<string> AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class cierremoduloswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001O2( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [CMModFecM], [CMModUsuM], [CMModFecC], [CMModUsuC], [CMModSts], [CMModCod], [CMModMes], [CMModAno] FROM [CBCIERREMODULO]";
         if ( ! (0==AV67Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV67Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! (0==AV68Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV68Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV69Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV69Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV78Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModAno]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModAno] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModMes]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModMes] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModSts] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModUsuC]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModUsuC] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModFecC]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModFecC] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModUsuM]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModUsuM] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [CMModFecM]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CMModFecM] DESC";
         }
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P001O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP001O2;
          prmP001O2 = new Object[] {
          new ParDef("@AV67Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV68Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV69Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV78Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
