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
   public class notificacioneswwexport : GXProcedure
   {
      public notificacioneswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacioneswwexport( IGxContext context )
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
         notificacioneswwexport objnotificacioneswwexport;
         objnotificacioneswwexport = new notificacioneswwexport();
         objnotificacioneswwexport.AV11Filename = "" ;
         objnotificacioneswwexport.AV12ErrorMessage = "" ;
         objnotificacioneswwexport.context.SetSubmitInitialConfig(context);
         objnotificacioneswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotificacioneswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificacioneswwexport)stateInfo).executePrivate();
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
         AV11Filename = "NotificacionesWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV29GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20SGNotificacionTitulo1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20SGNotificacionTitulo1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20SGNotificacionTitulo1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24SGNotificacionTitulo2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24SGNotificacionTitulo2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24SGNotificacionTitulo2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28SGNotificacionTitulo3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28SGNotificacionTitulo3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Titulo", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28SGNotificacionTitulo3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFSGNotificacionID) && (0==AV35TFSGNotificacionID_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "ID") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFSGNotificacionID;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFSGNotificacionID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFSGNotificacionTitulo_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Titulo") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFSGNotificacionTitulo_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFSGNotificacionTitulo)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Titulo") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFSGNotificacionTitulo, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFSGNotificacionDescripcion_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFSGNotificacionDescripcion_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFSGNotificacionDescripcion)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFSGNotificacionDescripcion, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV40TFSGNotificacionFecha) && (DateTime.MinValue==AV41TFSGNotificacionFecha_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Hora") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV40TFSGNotificacionFecha;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV41TFSGNotificacionFecha_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFSGNotificacionUsuario_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFSGNotificacionUsuario_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFSGNotificacionUsuario)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFSGNotificacionUsuario, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFSGNotificacionUsuarioDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFSGNotificacionUsuarioDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFSGNotificacionUsuarioDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFSGNotificacionUsuarioDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV47TFSGNotificacionIconClass_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Icon Class") ;
            AV13CellRow = GXt_int2;
            AV51i = 1;
            AV54GXV1 = 1;
            while ( AV54GXV1 <= AV47TFSGNotificacionIconClass_Sels.Count )
            {
               AV48TFSGNotificacionIconClass_Sel = ((string)AV47TFSGNotificacionIconClass_Sels.Item(AV54GXV1));
               if ( AV51i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+gxdomainicononotificaciones.getDescription(context,AV48TFSGNotificacionIconClass_Sel);
               AV51i = (long)(AV51i+1);
               AV54GXV1 = (int)(AV54GXV1+1);
            }
         }
         if ( ! ( (0==AV49TFSGNotificacionTUsuario) && (0==AV50TFSGNotificacionTUsuario_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuarios") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV49TFSGNotificacionTUsuario;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV50TFSGNotificacionTUsuario_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "ID";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Titulo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Descripción";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Hora";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Usuario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Usuario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Icon Class";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Usuarios";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV20SGNotificacionTitulo1;
         AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV24SGNotificacionTitulo2;
         AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV28SGNotificacionTitulo3;
         AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV34TFSGNotificacionID;
         AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV35TFSGNotificacionID_To;
         AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV36TFSGNotificacionTitulo;
         AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV37TFSGNotificacionTitulo_Sel;
         AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV38TFSGNotificacionDescripcion;
         AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV39TFSGNotificacionDescripcion_Sel;
         AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV40TFSGNotificacionFecha;
         AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV41TFSGNotificacionFecha_To;
         AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV42TFSGNotificacionUsuario;
         AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV43TFSGNotificacionUsuario_Sel;
         AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV44TFSGNotificacionUsuarioDsc;
         AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV45TFSGNotificacionUsuarioDsc_Sel;
         AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV47TFSGNotificacionIconClass_Sels;
         AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV49TFSGNotificacionTUsuario;
         AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV50TFSGNotificacionTUsuario_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007X2 */
         pr_default.execute(0, new Object[] {lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2244SGNotificacionTUsuario = P007X2_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007X2_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007X2_A2242SGNotificacionUsuarioDsc[0];
            A2241SGNotificacionUsuario = P007X2_A2241SGNotificacionUsuario[0];
            A2240SGNotificacionFecha = P007X2_A2240SGNotificacionFecha[0];
            A2239SGNotificacionDescripcion = P007X2_A2239SGNotificacionDescripcion[0];
            A2237SGNotificacionID = P007X2_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = P007X2_A2238SGNotificacionTitulo[0];
            A2242SGNotificacionUsuarioDsc = P007X2_A2242SGNotificacionUsuarioDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A2237SGNotificacionID;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2238SGNotificacionTitulo, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2239SGNotificacionDescripcion, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = A2240SGNotificacionFecha;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2241SGNotificacionUsuario, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2242SGNotificacionUsuarioDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = gxdomainicononotificaciones.getDescription(context,A2243SGNotificacionIconClass);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Number = A2244SGNotificacionTUsuario;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Seguridad.NotificacionesWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV82GXV2 = 1;
         while ( AV82GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV82GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONID") == 0 )
            {
               AV34TFSGNotificacionID = (long)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFSGNotificacionID_To = (long)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO") == 0 )
            {
               AV36TFSGNotificacionTitulo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO_SEL") == 0 )
            {
               AV37TFSGNotificacionTitulo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION") == 0 )
            {
               AV38TFSGNotificacionDescripcion = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV39TFSGNotificacionDescripcion_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONFECHA") == 0 )
            {
               AV40TFSGNotificacionFecha = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV41TFSGNotificacionFecha_To = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO") == 0 )
            {
               AV42TFSGNotificacionUsuario = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO_SEL") == 0 )
            {
               AV43TFSGNotificacionUsuario_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC") == 0 )
            {
               AV44TFSGNotificacionUsuarioDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC_SEL") == 0 )
            {
               AV45TFSGNotificacionUsuarioDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONICONCLASS_SEL") == 0 )
            {
               AV46TFSGNotificacionIconClass_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV47TFSGNotificacionIconClass_Sels.FromJSonString(AV46TFSGNotificacionIconClass_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTUSUARIO") == 0 )
            {
               AV49TFSGNotificacionTUsuario = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV50TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV82GXV2 = (int)(AV82GXV2+1);
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
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20SGNotificacionTitulo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24SGNotificacionTitulo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28SGNotificacionTitulo3 = "";
         AV37TFSGNotificacionTitulo_Sel = "";
         AV36TFSGNotificacionTitulo = "";
         AV39TFSGNotificacionDescripcion_Sel = "";
         AV38TFSGNotificacionDescripcion = "";
         AV40TFSGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AV41TFSGNotificacionFecha_To = (DateTime)(DateTime.MinValue);
         AV43TFSGNotificacionUsuario_Sel = "";
         AV42TFSGNotificacionUsuario = "";
         AV45TFSGNotificacionUsuarioDsc_Sel = "";
         AV44TFSGNotificacionUsuarioDsc = "";
         AV47TFSGNotificacionIconClass_Sels = new GxSimpleCollection<string>();
         AV48TFSGNotificacionIconClass_Sel = "";
         AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = "";
         AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = "";
         AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = "";
         AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = "";
         AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = "";
         AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = (DateTime)(DateTime.MinValue);
         AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = (DateTime)(DateTime.MinValue);
         AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = "";
         AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = "";
         AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         A2243SGNotificacionIconClass = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2241SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         P007X2_A2244SGNotificacionTUsuario = new short[1] ;
         P007X2_A2243SGNotificacionIconClass = new string[] {""} ;
         P007X2_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007X2_A2241SGNotificacionUsuario = new string[] {""} ;
         P007X2_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007X2_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007X2_A2237SGNotificacionID = new long[1] ;
         P007X2_A2238SGNotificacionTitulo = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV46TFSGNotificacionIconClass_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacioneswwexport__default(),
            new Object[][] {
                new Object[] {
               P007X2_A2244SGNotificacionTUsuario, P007X2_A2243SGNotificacionIconClass, P007X2_A2242SGNotificacionUsuarioDsc, P007X2_A2241SGNotificacionUsuario, P007X2_A2240SGNotificacionFecha, P007X2_A2239SGNotificacionDescripcion, P007X2_A2237SGNotificacionID, P007X2_A2238SGNotificacionTitulo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV49TFSGNotificacionTUsuario ;
      private short AV50TFSGNotificacionTUsuario_To ;
      private short GXt_int2 ;
      private short AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ;
      private short AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ;
      private short AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ;
      private short AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ;
      private short AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ;
      private short A2244SGNotificacionTUsuario ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV54GXV1 ;
      private int AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ;
      private int AV82GXV2 ;
      private long AV34TFSGNotificacionID ;
      private long AV35TFSGNotificacionID_To ;
      private long AV51i ;
      private long AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid ;
      private long AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ;
      private long A2237SGNotificacionID ;
      private string AV43TFSGNotificacionUsuario_Sel ;
      private string AV42TFSGNotificacionUsuario ;
      private string AV45TFSGNotificacionUsuarioDsc_Sel ;
      private string AV44TFSGNotificacionUsuarioDsc ;
      private string AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ;
      private string AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ;
      private string scmdbuf ;
      private string lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string A2241SGNotificacionUsuario ;
      private string A2242SGNotificacionUsuarioDsc ;
      private string GXt_char1 ;
      private DateTime AV40TFSGNotificacionFecha ;
      private DateTime AV41TFSGNotificacionFecha_To ;
      private DateTime AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ;
      private DateTime AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ;
      private DateTime A2240SGNotificacionFecha ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ;
      private bool AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV46TFSGNotificacionIconClass_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20SGNotificacionTitulo1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24SGNotificacionTitulo2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28SGNotificacionTitulo3 ;
      private string AV37TFSGNotificacionTitulo_Sel ;
      private string AV36TFSGNotificacionTitulo ;
      private string AV39TFSGNotificacionDescripcion_Sel ;
      private string AV38TFSGNotificacionDescripcion ;
      private string AV48TFSGNotificacionIconClass_Sel ;
      private string AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ;
      private string AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ;
      private string AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ;
      private string AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ;
      private string AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ;
      private string lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P007X2_A2244SGNotificacionTUsuario ;
      private string[] P007X2_A2243SGNotificacionIconClass ;
      private string[] P007X2_A2242SGNotificacionUsuarioDsc ;
      private string[] P007X2_A2241SGNotificacionUsuario ;
      private DateTime[] P007X2_A2240SGNotificacionFecha ;
      private string[] P007X2_A2239SGNotificacionDescripcion ;
      private long[] P007X2_A2237SGNotificacionID ;
      private string[] P007X2_A2238SGNotificacionTitulo ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GxSimpleCollection<string> AV47TFSGNotificacionIconClass_Sels ;
      private GxSimpleCollection<string> AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class notificacioneswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007X2( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionID], T1.[SGNotificacionTitulo] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV57Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV59Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV61Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV63Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV65Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTitulo]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTitulo] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionID]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionID] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionDescripcion]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionDescripcion] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionFecha]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionFecha] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionUsuario]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionUsuario] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[UsuNom]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[UsuNom] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionIconClass]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionIconClass] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTUsuario]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[SGNotificacionTUsuario] DESC";
         }
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007X2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmP007X2;
          prmP007X2 = new Object[] {
          new ParDef("@lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV58Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV62Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV66Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV67Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV68Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV70Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV71Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV72Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV74Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV75Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV77Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV80Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
