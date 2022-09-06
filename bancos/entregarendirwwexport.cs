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
namespace GeneXus.Programs.bancos {
   public class entregarendirwwexport : GXProcedure
   {
      public entregarendirwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public entregarendirwwexport( IGxContext context )
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
         entregarendirwwexport objentregarendirwwexport;
         objentregarendirwwexport = new entregarendirwwexport();
         objentregarendirwwexport.AV11Filename = "" ;
         objentregarendirwwexport.AV12ErrorMessage = "" ;
         objentregarendirwwexport.context.SetSubmitInitialConfig(context);
         objentregarendirwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objentregarendirwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((entregarendirwwexport)stateInfo).executePrivate();
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
         AV11Filename = "EntregaRendirWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "ENTDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV20EntDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20EntDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20EntDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV21CueDsc1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CueDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV21CueDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "ENTDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25EntDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25EntDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV25EntDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26CueDsc2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CueDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV26CueDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "ENTDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30EntDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30EntDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Entrega a Rendir", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV30EntDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31CueDsc3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31CueDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Descripción de Cuenta", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV31CueDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV37TFEntCod) && (0==AV38TFEntCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV37TFEntCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV38TFEntCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFEntDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Entrega a Rendir") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFEntDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFEntDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Entrega a Rendir") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFEntDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV44TFCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44TFCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV46TFCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46TFCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV45TFCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45TFCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV48TFEntSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV48TFEntSts_Sels.Count )
            {
               AV49TFEntSts_Sel = (short)(AV48TFEntSts_Sels.GetNumeric(AV53GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV49TFEntSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV49TFEntSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV50i = (long)(AV50i+1);
               AV53GXV1 = (int)(AV53GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Entrega a Rendir";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Cuenta Contable";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Descripción de Cuenta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV57Bancos_entregarendirwwds_3_entdsc1 = AV20EntDsc1;
         AV58Bancos_entregarendirwwds_4_cuedsc1 = AV21CueDsc1;
         AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV62Bancos_entregarendirwwds_8_entdsc2 = AV25EntDsc2;
         AV63Bancos_entregarendirwwds_9_cuedsc2 = AV26CueDsc2;
         AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV67Bancos_entregarendirwwds_13_entdsc3 = AV30EntDsc3;
         AV68Bancos_entregarendirwwds_14_cuedsc3 = AV31CueDsc3;
         AV69Bancos_entregarendirwwds_15_tfentcod = AV37TFEntCod;
         AV70Bancos_entregarendirwwds_16_tfentcod_to = AV38TFEntCod_To;
         AV71Bancos_entregarendirwwds_17_tfentdsc = AV39TFEntDsc;
         AV72Bancos_entregarendirwwds_18_tfentdsc_sel = AV40TFEntDsc_Sel;
         AV73Bancos_entregarendirwwds_19_tfcuecod = AV43TFCueCod;
         AV74Bancos_entregarendirwwds_20_tfcuecod_sel = AV44TFCueCod_Sel;
         AV75Bancos_entregarendirwwds_21_tfcuedsc = AV45TFCueDsc;
         AV76Bancos_entregarendirwwds_22_tfcuedsc_sel = AV46TFCueDsc_Sel;
         AV77Bancos_entregarendirwwds_23_tfentsts_sels = AV48TFEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A973EntSts ,
                                              AV77Bancos_entregarendirwwds_23_tfentsts_sels ,
                                              AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV57Bancos_entregarendirwwds_3_entdsc1 ,
                                              AV58Bancos_entregarendirwwds_4_cuedsc1 ,
                                              AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV62Bancos_entregarendirwwds_8_entdsc2 ,
                                              AV63Bancos_entregarendirwwds_9_cuedsc2 ,
                                              AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV67Bancos_entregarendirwwds_13_entdsc3 ,
                                              AV68Bancos_entregarendirwwds_14_cuedsc3 ,
                                              AV69Bancos_entregarendirwwds_15_tfentcod ,
                                              AV70Bancos_entregarendirwwds_16_tfentcod_to ,
                                              AV72Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                              AV71Bancos_entregarendirwwds_17_tfentdsc ,
                                              AV74Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                              AV73Bancos_entregarendirwwds_19_tfcuecod ,
                                              AV76Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                              AV75Bancos_entregarendirwwds_21_tfcuedsc ,
                                              AV77Bancos_entregarendirwwds_23_tfentsts_sels.Count ,
                                              A972EntDsc ,
                                              A860CueDsc ,
                                              A365EntCod ,
                                              A91CueCod ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV57Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV58Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV58Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV62Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV62Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV63Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV63Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV67Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV67Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV68Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV68Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV71Bancos_entregarendirwwds_17_tfentdsc = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_17_tfentdsc), 100, "%");
         lV73Bancos_entregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_entregarendirwwds_19_tfcuecod), 15, "%");
         lV75Bancos_entregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_entregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005T2 */
         pr_default.execute(0, new Object[] {lV57Bancos_entregarendirwwds_3_entdsc1, lV57Bancos_entregarendirwwds_3_entdsc1, lV58Bancos_entregarendirwwds_4_cuedsc1, lV58Bancos_entregarendirwwds_4_cuedsc1, lV62Bancos_entregarendirwwds_8_entdsc2, lV62Bancos_entregarendirwwds_8_entdsc2, lV63Bancos_entregarendirwwds_9_cuedsc2, lV63Bancos_entregarendirwwds_9_cuedsc2, lV67Bancos_entregarendirwwds_13_entdsc3, lV67Bancos_entregarendirwwds_13_entdsc3, lV68Bancos_entregarendirwwds_14_cuedsc3, lV68Bancos_entregarendirwwds_14_cuedsc3, AV69Bancos_entregarendirwwds_15_tfentcod, AV70Bancos_entregarendirwwds_16_tfentcod_to, lV71Bancos_entregarendirwwds_17_tfentdsc, AV72Bancos_entregarendirwwds_18_tfentdsc_sel, lV73Bancos_entregarendirwwds_19_tfcuecod, AV74Bancos_entregarendirwwds_20_tfcuecod_sel, lV75Bancos_entregarendirwwds_21_tfcuedsc, AV76Bancos_entregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A973EntSts = P005T2_A973EntSts[0];
            A91CueCod = P005T2_A91CueCod[0];
            A365EntCod = P005T2_A365EntCod[0];
            A860CueDsc = P005T2_A860CueDsc[0];
            A972EntDsc = P005T2_A972EntDsc[0];
            A860CueDsc = P005T2_A860CueDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A365EntCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A972EntDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A91CueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A860CueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A973EntSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A973EntSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "INACTIVO";
            }
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.EntregaRendirWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV78GXV2 = 1;
         while ( AV78GXV2 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV78GXV2));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENTCOD") == 0 )
            {
               AV37TFEntCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV38TFEntCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENTDSC") == 0 )
            {
               AV39TFEntDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENTDSC_SEL") == 0 )
            {
               AV40TFEntDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV43TFCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV44TFCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV45TFCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV46TFCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFENTSTS_SEL") == 0 )
            {
               AV47TFEntSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV48TFEntSts_Sels.FromJSonString(AV47TFEntSts_SelsJson, null);
            }
            AV78GXV2 = (int)(AV78GXV2+1);
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
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20EntDsc1 = "";
         AV21CueDsc1 = "";
         AV23DynamicFiltersSelector2 = "";
         AV25EntDsc2 = "";
         AV26CueDsc2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30EntDsc3 = "";
         AV31CueDsc3 = "";
         AV40TFEntDsc_Sel = "";
         AV39TFEntDsc = "";
         AV44TFCueCod_Sel = "";
         AV43TFCueCod = "";
         AV46TFCueDsc_Sel = "";
         AV45TFCueDsc = "";
         AV48TFEntSts_Sels = new GxSimpleCollection<short>();
         AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1 = "";
         AV57Bancos_entregarendirwwds_3_entdsc1 = "";
         AV58Bancos_entregarendirwwds_4_cuedsc1 = "";
         AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2 = "";
         AV62Bancos_entregarendirwwds_8_entdsc2 = "";
         AV63Bancos_entregarendirwwds_9_cuedsc2 = "";
         AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3 = "";
         AV67Bancos_entregarendirwwds_13_entdsc3 = "";
         AV68Bancos_entregarendirwwds_14_cuedsc3 = "";
         AV71Bancos_entregarendirwwds_17_tfentdsc = "";
         AV72Bancos_entregarendirwwds_18_tfentdsc_sel = "";
         AV73Bancos_entregarendirwwds_19_tfcuecod = "";
         AV74Bancos_entregarendirwwds_20_tfcuecod_sel = "";
         AV75Bancos_entregarendirwwds_21_tfcuedsc = "";
         AV76Bancos_entregarendirwwds_22_tfcuedsc_sel = "";
         AV77Bancos_entregarendirwwds_23_tfentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Bancos_entregarendirwwds_3_entdsc1 = "";
         lV58Bancos_entregarendirwwds_4_cuedsc1 = "";
         lV62Bancos_entregarendirwwds_8_entdsc2 = "";
         lV63Bancos_entregarendirwwds_9_cuedsc2 = "";
         lV67Bancos_entregarendirwwds_13_entdsc3 = "";
         lV68Bancos_entregarendirwwds_14_cuedsc3 = "";
         lV71Bancos_entregarendirwwds_17_tfentdsc = "";
         lV73Bancos_entregarendirwwds_19_tfcuecod = "";
         lV75Bancos_entregarendirwwds_21_tfcuedsc = "";
         A972EntDsc = "";
         A860CueDsc = "";
         A91CueCod = "";
         P005T2_A973EntSts = new short[1] ;
         P005T2_A91CueCod = new string[] {""} ;
         P005T2_A365EntCod = new int[1] ;
         P005T2_A860CueDsc = new string[] {""} ;
         P005T2_A972EntDsc = new string[] {""} ;
         GXt_char1 = "";
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFEntSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendirwwexport__default(),
            new Object[][] {
                new Object[] {
               P005T2_A973EntSts, P005T2_A91CueCod, P005T2_A365EntCod, P005T2_A860CueDsc, P005T2_A972EntDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV49TFEntSts_Sel ;
      private short AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A973EntSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV37TFEntCod ;
      private int AV38TFEntCod_To ;
      private int AV53GXV1 ;
      private int AV69Bancos_entregarendirwwds_15_tfentcod ;
      private int AV70Bancos_entregarendirwwds_16_tfentcod_to ;
      private int AV77Bancos_entregarendirwwds_23_tfentsts_sels_Count ;
      private int A365EntCod ;
      private int AV78GXV2 ;
      private long AV50i ;
      private string AV20EntDsc1 ;
      private string AV21CueDsc1 ;
      private string AV25EntDsc2 ;
      private string AV26CueDsc2 ;
      private string AV30EntDsc3 ;
      private string AV31CueDsc3 ;
      private string AV40TFEntDsc_Sel ;
      private string AV39TFEntDsc ;
      private string AV44TFCueCod_Sel ;
      private string AV43TFCueCod ;
      private string AV46TFCueDsc_Sel ;
      private string AV45TFCueDsc ;
      private string AV57Bancos_entregarendirwwds_3_entdsc1 ;
      private string AV58Bancos_entregarendirwwds_4_cuedsc1 ;
      private string AV62Bancos_entregarendirwwds_8_entdsc2 ;
      private string AV63Bancos_entregarendirwwds_9_cuedsc2 ;
      private string AV67Bancos_entregarendirwwds_13_entdsc3 ;
      private string AV68Bancos_entregarendirwwds_14_cuedsc3 ;
      private string AV71Bancos_entregarendirwwds_17_tfentdsc ;
      private string AV72Bancos_entregarendirwwds_18_tfentdsc_sel ;
      private string AV73Bancos_entregarendirwwds_19_tfcuecod ;
      private string AV74Bancos_entregarendirwwds_20_tfcuecod_sel ;
      private string AV75Bancos_entregarendirwwds_21_tfcuedsc ;
      private string AV76Bancos_entregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV57Bancos_entregarendirwwds_3_entdsc1 ;
      private string lV58Bancos_entregarendirwwds_4_cuedsc1 ;
      private string lV62Bancos_entregarendirwwds_8_entdsc2 ;
      private string lV63Bancos_entregarendirwwds_9_cuedsc2 ;
      private string lV67Bancos_entregarendirwwds_13_entdsc3 ;
      private string lV68Bancos_entregarendirwwds_14_cuedsc3 ;
      private string lV71Bancos_entregarendirwwds_17_tfentdsc ;
      private string lV73Bancos_entregarendirwwds_19_tfcuecod ;
      private string lV75Bancos_entregarendirwwds_21_tfcuedsc ;
      private string A972EntDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV47TFEntSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV48TFEntSts_Sels ;
      private GxSimpleCollection<short> AV77Bancos_entregarendirwwds_23_tfentsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005T2_A973EntSts ;
      private string[] P005T2_A91CueCod ;
      private int[] P005T2_A365EntCod ;
      private string[] P005T2_A860CueDsc ;
      private string[] P005T2_A972EntDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class entregarendirwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005T2( IGxContext context ,
                                             short A973EntSts ,
                                             GxSimpleCollection<short> AV77Bancos_entregarendirwwds_23_tfentsts_sels ,
                                             string AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV57Bancos_entregarendirwwds_3_entdsc1 ,
                                             string AV58Bancos_entregarendirwwds_4_cuedsc1 ,
                                             bool AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV62Bancos_entregarendirwwds_8_entdsc2 ,
                                             string AV63Bancos_entregarendirwwds_9_cuedsc2 ,
                                             bool AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV67Bancos_entregarendirwwds_13_entdsc3 ,
                                             string AV68Bancos_entregarendirwwds_14_cuedsc3 ,
                                             int AV69Bancos_entregarendirwwds_15_tfentcod ,
                                             int AV70Bancos_entregarendirwwds_16_tfentcod_to ,
                                             string AV72Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                             string AV71Bancos_entregarendirwwds_17_tfentdsc ,
                                             string AV74Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                             string AV73Bancos_entregarendirwwds_19_tfcuecod ,
                                             string AV76Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                             string AV75Bancos_entregarendirwwds_21_tfcuedsc ,
                                             int AV77Bancos_entregarendirwwds_23_tfentsts_sels_Count ,
                                             string A972EntDsc ,
                                             string A860CueDsc ,
                                             int A365EntCod ,
                                             string A91CueCod ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[EntSts], T1.[CueCod], T1.[EntCod], T2.[CueDsc], T1.[EntDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV57Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV57Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV58Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV56Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV58Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV62Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV62Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV63Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV59Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV61Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV63Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV67Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV67Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV68Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV64Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV66Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV68Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV69Bancos_entregarendirwwds_15_tfentcod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] >= @AV69Bancos_entregarendirwwds_15_tfentcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV70Bancos_entregarendirwwds_16_tfentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] <= @AV70Bancos_entregarendirwwds_16_tfentcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_entregarendirwwds_18_tfentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_17_tfentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV71Bancos_entregarendirwwds_17_tfentdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_entregarendirwwds_18_tfentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] = @AV72Bancos_entregarendirwwds_18_tfentdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_entregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV73Bancos_entregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV74Bancos_entregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_entregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV75Bancos_entregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_entregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV76Bancos_entregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV77Bancos_entregarendirwwds_23_tfentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Bancos_entregarendirwwds_23_tfentsts_sels, "T1.[EntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CueCod]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CueCod] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[CueDsc]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[CueDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[EntSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[EntSts] DESC";
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
                     return conditional_P005T2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005T2;
          prmP005T2 = new Object[] {
          new ParDef("@lV57Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV69Bancos_entregarendirwwds_15_tfentcod",GXType.Int32,6,0) ,
          new ParDef("@AV70Bancos_entregarendirwwds_16_tfentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_17_tfentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Bancos_entregarendirwwds_18_tfentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_entregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV74Bancos_entregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV75Bancos_entregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV76Bancos_entregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
