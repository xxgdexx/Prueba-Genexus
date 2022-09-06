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
   public class conceptoentregarendirwwexport : GXProcedure
   {
      public conceptoentregarendirwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoentregarendirwwexport( IGxContext context )
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
         conceptoentregarendirwwexport objconceptoentregarendirwwexport;
         objconceptoentregarendirwwexport = new conceptoentregarendirwwexport();
         objconceptoentregarendirwwexport.AV11Filename = "" ;
         objconceptoentregarendirwwexport.AV12ErrorMessage = "" ;
         objconceptoentregarendirwwexport.context.SetSubmitInitialConfig(context);
         objconceptoentregarendirwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoentregarendirwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoentregarendirwwexport)stateInfo).executePrivate();
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
         AV11Filename = "ConceptoEntregaRendirWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CONENTDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20ConEntDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20ConEntDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20ConEntDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV44CueCod1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44CueCod1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV44CueCod1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CONENTDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24ConEntDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24ConEntDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24ConEntDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV45CueCod2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45CueCod2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV45CueCod2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CONENTDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28ConEntDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28ConEntDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Concepto de Entrega", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28ConEntDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV46CueCod3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46CueCod3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Cuenta Contable", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46CueCod3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV34TFConEntCod) && (0==AV35TFConEntCod_To) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFConEntCod;
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFConEntCod_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConEntDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto Entrega Rendir") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFConEntDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConEntDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Concepto Entrega Rendir") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFConEntDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFCueCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFCueCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCueCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Cuenta Contable") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFCueCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCueDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFCueDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCueDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Descripción de Cuenta") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFCueDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV48TFConEntSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV50i = 1;
            AV53GXV1 = 1;
            while ( AV53GXV1 <= AV48TFConEntSts_Sels.Count )
            {
               AV49TFConEntSts_Sel = (short)(AV48TFConEntSts_Sels.GetNumeric(AV53GXV1));
               if ( AV50i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV49TFConEntSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV49TFConEntSts_Sel == 0 )
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Concepto Entrega Rendir";
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
         AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV57Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV20ConEntDsc1;
         AV58Bancos_conceptoentregarendirwwds_4_cuecod1 = AV44CueCod1;
         AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV62Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV24ConEntDsc2;
         AV63Bancos_conceptoentregarendirwwds_9_cuecod2 = AV45CueCod2;
         AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV67Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV28ConEntDsc3;
         AV68Bancos_conceptoentregarendirwwds_14_cuecod3 = AV46CueCod3;
         AV69Bancos_conceptoentregarendirwwds_15_tfconentcod = AV34TFConEntCod;
         AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV35TFConEntCod_To;
         AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV36TFConEntDsc;
         AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV37TFConEntDsc_Sel;
         AV73Bancos_conceptoentregarendirwwds_19_tfcuecod = AV38TFCueCod;
         AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV39TFCueCod_Sel;
         AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV40TFCueDsc;
         AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV41TFCueDsc_Sel;
         AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV48TFConEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV57Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV58Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV62Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV63Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV67Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV68Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV69Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV73Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV57Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV58Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV58Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV62Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV62Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV63Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV63Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV67Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV67Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV68Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV68Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV73Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {lV57Bancos_conceptoentregarendirwwds_3_conentdsc1, lV57Bancos_conceptoentregarendirwwds_3_conentdsc1, lV58Bancos_conceptoentregarendirwwds_4_cuecod1, lV58Bancos_conceptoentregarendirwwds_4_cuecod1, lV62Bancos_conceptoentregarendirwwds_8_conentdsc2, lV62Bancos_conceptoentregarendirwwds_8_conentdsc2, lV63Bancos_conceptoentregarendirwwds_9_cuecod2, lV63Bancos_conceptoentregarendirwwds_9_cuecod2, lV67Bancos_conceptoentregarendirwwds_13_conentdsc3, lV67Bancos_conceptoentregarendirwwds_13_conentdsc3, lV68Bancos_conceptoentregarendirwwds_14_cuecod3, lV68Bancos_conceptoentregarendirwwds_14_cuecod3, AV69Bancos_conceptoentregarendirwwds_15_tfconentcod, AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV73Bancos_conceptoentregarendirwwds_19_tfcuecod, AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A750ConEntSts = P005X2_A750ConEntSts[0];
            A860CueDsc = P005X2_A860CueDsc[0];
            A376ConEntCod = P005X2_A376ConEntCod[0];
            A91CueCod = P005X2_A91CueCod[0];
            A749ConEntDsc = P005X2_A749ConEntDsc[0];
            A860CueDsc = P005X2_A860CueDsc[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A376ConEntCod;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A749ConEntDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A91CueCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A860CueDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "";
            if ( A750ConEntSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "ACTIVO";
            }
            else if ( A750ConEntSts == 0 )
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
         if ( StringUtil.StrCmp(AV30Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV78GXV2 = 1;
         while ( AV78GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV78GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONENTCOD") == 0 )
            {
               AV34TFConEntCod = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFConEntCod_To = (int)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONENTDSC") == 0 )
            {
               AV36TFConEntDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONENTDSC_SEL") == 0 )
            {
               AV37TFConEntDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV38TFCueCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV39TFCueCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV40TFCueDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV41TFCueDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCONENTSTS_SEL") == 0 )
            {
               AV47TFConEntSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV48TFConEntSts_Sels.FromJSonString(AV47TFConEntSts_SelsJson, null);
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
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV18DynamicFiltersSelector1 = "";
         AV20ConEntDsc1 = "";
         AV44CueCod1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24ConEntDsc2 = "";
         AV45CueCod2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28ConEntDsc3 = "";
         AV46CueCod3 = "";
         AV37TFConEntDsc_Sel = "";
         AV36TFConEntDsc = "";
         AV39TFCueCod_Sel = "";
         AV38TFCueCod = "";
         AV41TFCueDsc_Sel = "";
         AV40TFCueDsc = "";
         AV48TFConEntSts_Sels = new GxSimpleCollection<short>();
         AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = "";
         AV57Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         AV58Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = "";
         AV62Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         AV63Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = "";
         AV67Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         AV68Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = "";
         AV73Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = "";
         AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = "";
         AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         lV58Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         lV62Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         lV63Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         lV67Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         lV68Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         lV73Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         A749ConEntDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005X2_A750ConEntSts = new short[1] ;
         P005X2_A860CueDsc = new string[] {""} ;
         P005X2_A376ConEntCod = new int[1] ;
         P005X2_A91CueCod = new string[] {""} ;
         P005X2_A749ConEntDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47TFConEntSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoentregarendirwwexport__default(),
            new Object[][] {
                new Object[] {
               P005X2_A750ConEntSts, P005X2_A860CueDsc, P005X2_A376ConEntCod, P005X2_A91CueCod, P005X2_A749ConEntDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int2 ;
      private short AV49TFConEntSts_Sel ;
      private short AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A750ConEntSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV34TFConEntCod ;
      private int AV35TFConEntCod_To ;
      private int AV53GXV1 ;
      private int AV69Bancos_conceptoentregarendirwwds_15_tfconentcod ;
      private int AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to ;
      private int AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ;
      private int A376ConEntCod ;
      private int AV78GXV2 ;
      private long AV50i ;
      private string AV20ConEntDsc1 ;
      private string AV44CueCod1 ;
      private string AV24ConEntDsc2 ;
      private string AV45CueCod2 ;
      private string AV28ConEntDsc3 ;
      private string AV46CueCod3 ;
      private string AV37TFConEntDsc_Sel ;
      private string AV36TFConEntDsc ;
      private string AV39TFCueCod_Sel ;
      private string AV38TFCueCod ;
      private string AV41TFCueDsc_Sel ;
      private string AV40TFCueDsc ;
      private string AV57Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string AV58Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string AV62Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string AV63Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string AV67Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string AV68Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ;
      private string AV73Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ;
      private string AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV57Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string lV58Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string lV62Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string lV63Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string lV67Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string lV68Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string lV73Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string A749ConEntDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV47TFConEntSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV48TFConEntSts_Sels ;
      private GxSimpleCollection<short> AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005X2_A750ConEntSts ;
      private string[] P005X2_A860CueDsc ;
      private int[] P005X2_A376ConEntCod ;
      private string[] P005X2_A91CueCod ;
      private string[] P005X2_A749ConEntDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class conceptoentregarendirwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005X2( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV57Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV58Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV62Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV63Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV67Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV68Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV69Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV73Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ConEntSts], T2.[CueDsc], T1.[ConEntCod], T1.[CueCod], T1.[ConEntDsc] FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV57Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV57Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV58Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV56Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV58Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV62Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV62Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV63Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV59Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV61Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV63Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV67Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV67Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV68Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV64Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV66Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV68Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV69Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV69Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV73Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConEntCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[ConEntDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntDsc] DESC";
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
            scmdbuf += " ORDER BY T1.[ConEntSts]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[ConEntSts] DESC";
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
                     return conditional_P005X2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("@lV57Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV58Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV62Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV67Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV69Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV70Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV74Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV75Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV76Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
