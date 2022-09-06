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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_codigoidwwexport : GXProcedure
   {
      public reloj_codigoidwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoidwwexport( IGxContext context )
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
         reloj_codigoidwwexport objreloj_codigoidwwexport;
         objreloj_codigoidwwexport = new reloj_codigoidwwexport();
         objreloj_codigoidwwexport.AV11Filename = "" ;
         objreloj_codigoidwwexport.AV12ErrorMessage = "" ;
         objreloj_codigoidwwexport.context.SetSubmitInitialConfig(context);
         objreloj_codigoidwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_codigoidwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_codigoidwwexport)stateInfo).executePrivate();
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
         AV11Filename = "Reloj_CodigoIDWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV20RHTrabajadorNombres1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20RHTrabajadorNombres1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20RHTrabajadorNombres1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV21Reloj_Nombre1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21Reloj_Nombre1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21Reloj_Nombre1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV22HorarioDescripcion1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22HorarioDescripcion1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV22HorarioDescripcion1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV26RHTrabajadorNombres2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RHTrabajadorNombres2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26RHTrabajadorNombres2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV27Reloj_Nombre2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Reloj_Nombre2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV27Reloj_Nombre2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28HorarioDescripcion2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28HorarioDescripcion2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28HorarioDescripcion2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV32RHTrabajadorNombres3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32RHTrabajadorNombres3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV32RHTrabajadorNombres3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33Reloj_Nombre3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Reloj_Nombre3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV33Reloj_Nombre3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV34HorarioDescripcion3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34HorarioDescripcion3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34HorarioDescripcion3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCodigoId_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Trabajador ID") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCodigoId_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCodigoId)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Trabajador ID") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCodigoId, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFReloj_Nombre_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Reloj") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFReloj_Nombre_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFReloj_Nombre)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Reloj") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFReloj_Nombre, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV46TFLectura_Ini) && (DateTime.MinValue==AV47TFLectura_Ini_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Fecha Registro") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV46TFLectura_Ini;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV47TFLectura_Ini_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV53TFRHTrabajadorNombres_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Trabajador") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV53TFRHTrabajadorNombres_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRHTrabajadorNombres)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Trabajador") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV52TFRHTrabajadorNombres, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV57TFHorarioDescripcion_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Horario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV57TFHorarioDescripcion_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHorarioDescripcion)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Horario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV56TFHorarioDescripcion, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Trabajador ID";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Reloj";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Fecha Registro";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Trabajador";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Horario";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV20RHTrabajadorNombres1;
         AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV21Reloj_Nombre1;
         AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV22HorarioDescripcion1;
         AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV26RHTrabajadorNombres2;
         AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV27Reloj_Nombre2;
         AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV28HorarioDescripcion2;
         AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV32RHTrabajadorNombres3;
         AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV33Reloj_Nombre3;
         AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV34HorarioDescripcion3;
         AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV40TFCodigoId;
         AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV41TFCodigoId_Sel;
         AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV44TFReloj_Nombre;
         AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV45TFReloj_Nombre_Sel;
         AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV46TFLectura_Ini;
         AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV47TFLectura_Ini_To;
         AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV52TFRHTrabajadorNombres;
         AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV53TFRHTrabajadorNombres_Sel;
         AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV56TFHorarioDescripcion;
         AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV57TFHorarioDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H32 */
         pr_default.execute(0, new Object[] {lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2589RHTrabajadorCodigo = P00H32_A2589RHTrabajadorCodigo[0];
            A2498Reloj_ID = P00H32_A2498Reloj_ID[0];
            A2591HorarioID = P00H32_A2591HorarioID[0];
            A2415Lectura_Ini = P00H32_A2415Lectura_Ini[0];
            A2431CodigoId = P00H32_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H32_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H32_A2592Reloj_Nombre[0];
            A2590RHTrabajadorNombres = P00H32_A2590RHTrabajadorNombres[0];
            A2525TrabApePat = P00H32_A2525TrabApePat[0];
            n2525TrabApePat = P00H32_n2525TrabApePat[0];
            A2526TrabApeMat = P00H32_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H32_n2526TrabApeMat[0];
            A2527TrabNombres = P00H32_A2527TrabNombres[0];
            n2527TrabNombres = P00H32_n2527TrabNombres[0];
            A2525TrabApePat = P00H32_A2525TrabApePat[0];
            n2525TrabApePat = P00H32_n2525TrabApePat[0];
            A2526TrabApeMat = P00H32_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H32_n2526TrabApeMat[0];
            A2527TrabNombres = P00H32_A2527TrabNombres[0];
            n2527TrabNombres = P00H32_n2527TrabNombres[0];
            A2592Reloj_Nombre = P00H32_A2592Reloj_Nombre[0];
            A2593HorarioDescripcion = P00H32_A2593HorarioDescripcion[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2431CodigoId, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2592Reloj_Nombre, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Date = A2415Lectura_Ini;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2590RHTrabajadorNombres, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2593HorarioDescripcion, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
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
         if ( StringUtil.StrCmp(AV36Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV88GXV1 = 1;
         while ( AV88GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV88GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCODIGOID") == 0 )
            {
               AV40TFCodigoId = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCODIGOID_SEL") == 0 )
            {
               AV41TFCodigoId_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE") == 0 )
            {
               AV44TFReloj_Nombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE_SEL") == 0 )
            {
               AV45TFReloj_Nombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLECTURA_INI") == 0 )
            {
               AV46TFLectura_Ini = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV47TFLectura_Ini_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES") == 0 )
            {
               AV52TFRHTrabajadorNombres = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES_SEL") == 0 )
            {
               AV53TFRHTrabajadorNombres_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION") == 0 )
            {
               AV56TFHorarioDescripcion = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION_SEL") == 0 )
            {
               AV57TFHorarioDescripcion_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV88GXV1 = (int)(AV88GXV1+1);
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
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20RHTrabajadorNombres1 = "";
         AV21Reloj_Nombre1 = "";
         AV22HorarioDescripcion1 = "";
         AV24DynamicFiltersSelector2 = "";
         AV26RHTrabajadorNombres2 = "";
         AV27Reloj_Nombre2 = "";
         AV28HorarioDescripcion2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32RHTrabajadorNombres3 = "";
         AV33Reloj_Nombre3 = "";
         AV34HorarioDescripcion3 = "";
         AV41TFCodigoId_Sel = "";
         AV40TFCodigoId = "";
         AV45TFReloj_Nombre_Sel = "";
         AV44TFReloj_Nombre = "";
         AV46TFLectura_Ini = (DateTime)(DateTime.MinValue);
         AV47TFLectura_Ini_To = (DateTime)(DateTime.MinValue);
         AV53TFRHTrabajadorNombres_Sel = "";
         AV52TFRHTrabajadorNombres = "";
         AV57TFHorarioDescripcion_Sel = "";
         AV56TFHorarioDescripcion = "";
         AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = "";
         AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = "";
         AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = "";
         AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = "";
         AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = "";
         AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = (DateTime)(DateTime.MinValue);
         AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = (DateTime)(DateTime.MinValue);
         AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = "";
         AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = "";
         scmdbuf = "";
         lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         A2592Reloj_Nombre = "";
         A2593HorarioDescripcion = "";
         A2431CodigoId = "";
         A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         P00H32_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H32_A2498Reloj_ID = new short[1] ;
         P00H32_A2591HorarioID = new short[1] ;
         P00H32_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H32_A2431CodigoId = new string[] {""} ;
         P00H32_A2593HorarioDescripcion = new string[] {""} ;
         P00H32_A2592Reloj_Nombre = new string[] {""} ;
         P00H32_A2590RHTrabajadorNombres = new string[] {""} ;
         P00H32_A2525TrabApePat = new string[] {""} ;
         P00H32_n2525TrabApePat = new bool[] {false} ;
         P00H32_A2526TrabApeMat = new string[] {""} ;
         P00H32_n2526TrabApeMat = new bool[] {false} ;
         P00H32_A2527TrabNombres = new string[] {""} ;
         P00H32_n2527TrabNombres = new bool[] {false} ;
         A2589RHTrabajadorCodigo = "";
         A2590RHTrabajadorNombres = "";
         GXt_char1 = "";
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoidwwexport__default(),
            new Object[][] {
                new Object[] {
               P00H32_A2589RHTrabajadorCodigo, P00H32_A2498Reloj_ID, P00H32_A2591HorarioID, P00H32_A2415Lectura_Ini, P00H32_A2431CodigoId, P00H32_A2593HorarioDescripcion, P00H32_A2592Reloj_Nombre, P00H32_A2590RHTrabajadorNombres, P00H32_A2525TrabApePat, P00H32_n2525TrabApePat,
               P00H32_A2526TrabApeMat, P00H32_n2526TrabApeMat, P00H32_A2527TrabNombres, P00H32_n2527TrabNombres
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ;
      private short AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ;
      private short AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private short A2498Reloj_ID ;
      private short A2591HorarioID ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV88GXV1 ;
      private string scmdbuf ;
      private string GXt_char1 ;
      private DateTime AV46TFLectura_Ini ;
      private DateTime AV47TFLectura_Ini_To ;
      private DateTime AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ;
      private DateTime AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ;
      private DateTime A2415Lectura_Ini ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ;
      private bool AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n2525TrabApePat ;
      private bool n2526TrabApeMat ;
      private bool n2527TrabNombres ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20RHTrabajadorNombres1 ;
      private string AV21Reloj_Nombre1 ;
      private string AV22HorarioDescripcion1 ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26RHTrabajadorNombres2 ;
      private string AV27Reloj_Nombre2 ;
      private string AV28HorarioDescripcion2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32RHTrabajadorNombres3 ;
      private string AV33Reloj_Nombre3 ;
      private string AV34HorarioDescripcion3 ;
      private string AV41TFCodigoId_Sel ;
      private string AV40TFCodigoId ;
      private string AV45TFReloj_Nombre_Sel ;
      private string AV44TFReloj_Nombre ;
      private string AV53TFRHTrabajadorNombres_Sel ;
      private string AV52TFRHTrabajadorNombres ;
      private string AV57TFHorarioDescripcion_Sel ;
      private string AV56TFHorarioDescripcion ;
      private string AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ;
      private string AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ;
      private string AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ;
      private string AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ;
      private string AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ;
      private string AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ;
      private string AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ;
      private string lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string A2592Reloj_Nombre ;
      private string A2593HorarioDescripcion ;
      private string A2431CodigoId ;
      private string A2589RHTrabajadorCodigo ;
      private string A2590RHTrabajadorNombres ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00H32_A2589RHTrabajadorCodigo ;
      private short[] P00H32_A2498Reloj_ID ;
      private short[] P00H32_A2591HorarioID ;
      private DateTime[] P00H32_A2415Lectura_Ini ;
      private string[] P00H32_A2431CodigoId ;
      private string[] P00H32_A2593HorarioDescripcion ;
      private string[] P00H32_A2592Reloj_Nombre ;
      private string[] P00H32_A2590RHTrabajadorNombres ;
      private string[] P00H32_A2525TrabApePat ;
      private bool[] P00H32_n2525TrabApePat ;
      private string[] P00H32_A2526TrabApeMat ;
      private bool[] P00H32_n2526TrabApeMat ;
      private string[] P00H32_A2527TrabNombres ;
      private bool[] P00H32_n2527TrabNombres ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class reloj_codigoidwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00H32( IGxContext context ,
                                             string AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, T1.[Lectura_Ini], T1.[CodigoId], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[Reloj_Nom] AS Reloj_Nombre, RTRIM(LTRIM(COALESCE( T2.[TrabApePat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabApeMat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabNombres], ''))) AS RHTrabajadorNombres, T2.[TrabApePat], T2.[TrabApeMat], T2.[TrabNombres] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV62Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV66Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RHTrabajadorNombres]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RHTrabajadorNombres] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CodigoId]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CodigoId] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[Reloj_Nom]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[Reloj_Nom] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Lectura_Ini]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Lectura_Ini] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[Horario_Dsc]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[Horario_Dsc] DESC";
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
                     return conditional_P00H32(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] );
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
          Object[] prmP00H32;
          prmP00H32 = new Object[] {
          new ParDef("@lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV63Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV64Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV65Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV78Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV79Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV80Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV81Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV82Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV83Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV84Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV85Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV87Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00H32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H32,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
