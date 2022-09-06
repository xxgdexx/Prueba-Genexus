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
namespace GeneXus.Programs.configuracion {
   public class tipodocumentowwexport : GXProcedure
   {
      public tipodocumentowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipodocumentowwexport( IGxContext context )
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
         tipodocumentowwexport objtipodocumentowwexport;
         objtipodocumentowwexport = new tipodocumentowwexport();
         objtipodocumentowwexport.AV11Filename = "" ;
         objtipodocumentowwexport.AV12ErrorMessage = "" ;
         objtipodocumentowwexport.context.SetSubmitInitialConfig(context);
         objtipodocumentowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipodocumentowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipodocumentowwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoDocumentoWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV20TipDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TipDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV20TipDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPABR") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV63TipAbr1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TipAbr1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV63TipAbr1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV24TipDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TipDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV24TipDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPABR") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV64TipAbr2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TipAbr2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV64TipAbr2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV28TipDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TipDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Tipo de Documento", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV28TipDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPABR") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV65TipAbr3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TipAbr3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Codigo Sunat", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV65TipAbr3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFTipAbr_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFTipAbr_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFTipAbr)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Codigo Sunat") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFTipAbr, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFTipDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Documento") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFTipDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTipDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Tipo de Documento") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFTipDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (0==AV54TFTipVta_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Registro Venta") ;
            AV13CellRow = GXt_int2;
            if ( AV54TFTipVta_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV54TFTipVta_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV55TFTipCmp_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Registro Compra") ;
            AV13CellRow = GXt_int2;
            if ( AV55TFTipCmp_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV55TFTipCmp_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV56TFTipRHo_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Honorarios") ;
            AV13CellRow = GXt_int2;
            if ( AV56TFTipRHo_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV56TFTipRHo_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV57TFTipCxP_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Cuenta x Pagar") ;
            AV13CellRow = GXt_int2;
            if ( AV57TFTipCxP_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV57TFTipCxP_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( (0==AV58TFTipBan_Sel) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Afecta Bancos") ;
            AV13CellRow = GXt_int2;
            if ( AV58TFTipBan_Sel == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Marcado";
            }
            else if ( AV58TFTipBan_Sel == 2 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Desmarcado";
            }
         }
         if ( ! ( ( AV60TFTipSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV62i = 1;
            AV68GXV1 = 1;
            while ( AV68GXV1 <= AV60TFTipSts_Sels.Count )
            {
               AV61TFTipSts_Sel = (short)(AV60TFTipSts_Sels.GetNumeric(AV68GXV1));
               if ( AV62i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV61TFTipSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV61TFTipSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV62i = (long)(AV62i+1);
               AV68GXV1 = (int)(AV68GXV1+1);
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Codigo Sunat";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Tipo de Documento";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Afecta Registro Venta";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Afecta Registro Compra";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Afecta Honorarios";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Afecta Cuenta x Pagar";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Text = "Afecta Bancos";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV72Configuracion_tipodocumentowwds_3_tipdsc1 = AV20TipDsc1;
         AV73Configuracion_tipodocumentowwds_4_tipabr1 = AV63TipAbr1;
         AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV77Configuracion_tipodocumentowwds_8_tipdsc2 = AV24TipDsc2;
         AV78Configuracion_tipodocumentowwds_9_tipabr2 = AV64TipAbr2;
         AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV82Configuracion_tipodocumentowwds_13_tipdsc3 = AV28TipDsc3;
         AV83Configuracion_tipodocumentowwds_14_tipabr3 = AV65TipAbr3;
         AV84Configuracion_tipodocumentowwds_15_tftipabr = AV38TFTipAbr;
         AV85Configuracion_tipodocumentowwds_16_tftipabr_sel = AV39TFTipAbr_Sel;
         AV86Configuracion_tipodocumentowwds_17_tftipdsc = AV36TFTipDsc;
         AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV37TFTipDsc_Sel;
         AV88Configuracion_tipodocumentowwds_19_tftipvta_sel = AV54TFTipVta_Sel;
         AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV55TFTipCmp_Sel;
         AV90Configuracion_tipodocumentowwds_21_tftiprho_sel = AV56TFTipRHo_Sel;
         AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV57TFTipCxP_Sel;
         AV92Configuracion_tipodocumentowwds_23_tftipban_sel = AV58TFTipBan_Sel;
         AV93Configuracion_tipodocumentowwds_24_tftipsts_sels = AV60TFTipSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1919TipSts ,
                                              AV93Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                              AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                              AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                              AV72Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                              AV73Configuracion_tipodocumentowwds_4_tipabr1 ,
                                              AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                              AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                              AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                              AV77Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                              AV78Configuracion_tipodocumentowwds_9_tipabr2 ,
                                              AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                              AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                              AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                              AV82Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                              AV83Configuracion_tipodocumentowwds_14_tipabr3 ,
                                              AV85Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                              AV84Configuracion_tipodocumentowwds_15_tftipabr ,
                                              AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                              AV86Configuracion_tipodocumentowwds_17_tftipdsc ,
                                              AV88Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                              AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                              AV90Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                              AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                              AV92Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                              AV93Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                              A1910TipDsc ,
                                              A306TipAbr ,
                                              A1921TipVta ,
                                              A1906TipCmp ,
                                              A1915TipRHo ,
                                              A1909TipCxP ,
                                              A1903TipBan ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV72Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV73Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV73Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV77Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV77Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV78Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV78Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV82Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV82Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV83Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV83Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV84Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
         lV86Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
         /* Using cursor P004A2 */
         pr_default.execute(0, new Object[] {lV72Configuracion_tipodocumentowwds_3_tipdsc1, lV72Configuracion_tipodocumentowwds_3_tipdsc1, lV73Configuracion_tipodocumentowwds_4_tipabr1, lV73Configuracion_tipodocumentowwds_4_tipabr1, lV77Configuracion_tipodocumentowwds_8_tipdsc2, lV77Configuracion_tipodocumentowwds_8_tipdsc2, lV78Configuracion_tipodocumentowwds_9_tipabr2, lV78Configuracion_tipodocumentowwds_9_tipabr2, lV82Configuracion_tipodocumentowwds_13_tipdsc3, lV82Configuracion_tipodocumentowwds_13_tipdsc3, lV83Configuracion_tipodocumentowwds_14_tipabr3, lV83Configuracion_tipodocumentowwds_14_tipabr3, lV84Configuracion_tipodocumentowwds_15_tftipabr, AV85Configuracion_tipodocumentowwds_16_tftipabr_sel, lV86Configuracion_tipodocumentowwds_17_tftipdsc, AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1919TipSts = P004A2_A1919TipSts[0];
            A1903TipBan = P004A2_A1903TipBan[0];
            A1909TipCxP = P004A2_A1909TipCxP[0];
            A1915TipRHo = P004A2_A1915TipRHo[0];
            A1906TipCmp = P004A2_A1906TipCmp[0];
            A1921TipVta = P004A2_A1921TipVta[0];
            A306TipAbr = P004A2_A306TipAbr[0];
            A1910TipDsc = P004A2_A1910TipDsc[0];
            A149TipCod = P004A2_A149TipCod[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A306TipAbr, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1910TipDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = A1921TipVta;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = A1906TipCmp;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Number = A1915TipRHo;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A1909TipCxP;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+6, 1, 1).Number = A1903TipBan;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "";
            if ( A1919TipSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "ACTIVO";
            }
            else if ( A1919TipSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+7, 1, 1).Text = "INACTIVO";
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.TipoDocumentoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV94GXV2 = 1;
         while ( AV94GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV94GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPABR") == 0 )
            {
               AV38TFTipAbr = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPABR_SEL") == 0 )
            {
               AV39TFTipAbr_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPDSC") == 0 )
            {
               AV36TFTipDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPDSC_SEL") == 0 )
            {
               AV37TFTipDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPVTA_SEL") == 0 )
            {
               AV54TFTipVta_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCMP_SEL") == 0 )
            {
               AV55TFTipCmp_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPRHO_SEL") == 0 )
            {
               AV56TFTipRHo_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCXP_SEL") == 0 )
            {
               AV57TFTipCxP_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPBAN_SEL") == 0 )
            {
               AV58TFTipBan_Sel = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPSTS_SEL") == 0 )
            {
               AV59TFTipSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV60TFTipSts_Sels.FromJSonString(AV59TFTipSts_SelsJson, null);
            }
            AV94GXV2 = (int)(AV94GXV2+1);
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
         AV20TipDsc1 = "";
         AV63TipAbr1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TipDsc2 = "";
         AV64TipAbr2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TipDsc3 = "";
         AV65TipAbr3 = "";
         AV39TFTipAbr_Sel = "";
         AV38TFTipAbr = "";
         AV37TFTipDsc_Sel = "";
         AV36TFTipDsc = "";
         AV60TFTipSts_Sels = new GxSimpleCollection<short>();
         AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = "";
         AV72Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         AV73Configuracion_tipodocumentowwds_4_tipabr1 = "";
         AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = "";
         AV77Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         AV78Configuracion_tipodocumentowwds_9_tipabr2 = "";
         AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = "";
         AV82Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         AV83Configuracion_tipodocumentowwds_14_tipabr3 = "";
         AV84Configuracion_tipodocumentowwds_15_tftipabr = "";
         AV85Configuracion_tipodocumentowwds_16_tftipabr_sel = "";
         AV86Configuracion_tipodocumentowwds_17_tftipdsc = "";
         AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel = "";
         AV93Configuracion_tipodocumentowwds_24_tftipsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV72Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         lV73Configuracion_tipodocumentowwds_4_tipabr1 = "";
         lV77Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         lV78Configuracion_tipodocumentowwds_9_tipabr2 = "";
         lV82Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         lV83Configuracion_tipodocumentowwds_14_tipabr3 = "";
         lV84Configuracion_tipodocumentowwds_15_tftipabr = "";
         lV86Configuracion_tipodocumentowwds_17_tftipdsc = "";
         A1910TipDsc = "";
         A306TipAbr = "";
         P004A2_A1919TipSts = new short[1] ;
         P004A2_A1903TipBan = new short[1] ;
         P004A2_A1909TipCxP = new short[1] ;
         P004A2_A1915TipRHo = new short[1] ;
         P004A2_A1906TipCmp = new short[1] ;
         P004A2_A1921TipVta = new short[1] ;
         P004A2_A306TipAbr = new string[] {""} ;
         P004A2_A1910TipDsc = new string[] {""} ;
         P004A2_A149TipCod = new string[] {""} ;
         A149TipCod = "";
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59TFTipSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumentowwexport__default(),
            new Object[][] {
                new Object[] {
               P004A2_A1919TipSts, P004A2_A1903TipBan, P004A2_A1909TipCxP, P004A2_A1915TipRHo, P004A2_A1906TipCmp, P004A2_A1921TipVta, P004A2_A306TipAbr, P004A2_A1910TipDsc, P004A2_A149TipCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV54TFTipVta_Sel ;
      private short AV55TFTipCmp_Sel ;
      private short AV56TFTipRHo_Sel ;
      private short AV57TFTipCxP_Sel ;
      private short AV58TFTipBan_Sel ;
      private short GXt_int2 ;
      private short AV61TFTipSts_Sel ;
      private short AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ;
      private short AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ;
      private short AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ;
      private short AV88Configuracion_tipodocumentowwds_19_tftipvta_sel ;
      private short AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel ;
      private short AV90Configuracion_tipodocumentowwds_21_tftiprho_sel ;
      private short AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel ;
      private short AV92Configuracion_tipodocumentowwds_23_tftipban_sel ;
      private short A1919TipSts ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV68GXV1 ;
      private int AV93Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ;
      private int AV94GXV2 ;
      private long AV62i ;
      private string AV20TipDsc1 ;
      private string AV63TipAbr1 ;
      private string AV24TipDsc2 ;
      private string AV64TipAbr2 ;
      private string AV28TipDsc3 ;
      private string AV65TipAbr3 ;
      private string AV39TFTipAbr_Sel ;
      private string AV38TFTipAbr ;
      private string AV37TFTipDsc_Sel ;
      private string AV36TFTipDsc ;
      private string AV72Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string AV73Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string AV77Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string AV78Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string AV82Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string AV83Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string AV84Configuracion_tipodocumentowwds_15_tftipabr ;
      private string AV85Configuracion_tipodocumentowwds_16_tftipabr_sel ;
      private string AV86Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel ;
      private string scmdbuf ;
      private string lV72Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string lV73Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string lV77Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string lV78Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string lV82Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string lV83Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string lV84Configuracion_tipodocumentowwds_15_tftipabr ;
      private string lV86Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string A1910TipDsc ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ;
      private bool AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV59TFTipSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ;
      private string AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ;
      private string AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ;
      private GxSimpleCollection<short> AV60TFTipSts_Sels ;
      private GxSimpleCollection<short> AV93Configuracion_tipodocumentowwds_24_tftipsts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004A2_A1919TipSts ;
      private short[] P004A2_A1903TipBan ;
      private short[] P004A2_A1909TipCxP ;
      private short[] P004A2_A1915TipRHo ;
      private short[] P004A2_A1906TipCmp ;
      private short[] P004A2_A1921TipVta ;
      private string[] P004A2_A306TipAbr ;
      private string[] P004A2_A1910TipDsc ;
      private string[] P004A2_A149TipCod ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipodocumentowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004A2( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV93Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV72Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV73Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV77Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV78Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV82Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV83Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV85Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV84Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV86Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV88Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV90Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV92Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV93Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipSts], [TipBan], [TipCxP], [TipRHo], [TipCmp], [TipVta], [TipAbr], [TipDsc], [TipCod] FROM [CTIPDOC]";
         if ( ( StringUtil.StrCmp(AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV72Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV72Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV73Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV70Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV71Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV73Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV77Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV77Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV78Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV74Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV75Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV76Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV78Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV82Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV82Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV83Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV79Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV81Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV83Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV84Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV85Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV86Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV88Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV88Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV89Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV90Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV90Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV91Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV92Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV92Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV93Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV93Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipAbr]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipAbr] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipVta]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipVta] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCmp]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCmp] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipRHo]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipRHo] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipCxP]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipCxP] DESC";
         }
         else if ( ( AV16OrderedBy == 7 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipBan]";
         }
         else if ( ( AV16OrderedBy == 7 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipBan] DESC";
         }
         else if ( ( AV16OrderedBy == 8 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [TipSts]";
         }
         else if ( ( AV16OrderedBy == 8 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TipSts] DESC";
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
                     return conditional_P004A2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] , (short)dynConstraints[33] , (bool)dynConstraints[34] );
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
          Object[] prmP004A2;
          prmP004A2 = new Object[] {
          new ParDef("@lV72Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV73Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV77Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV78Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV82Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV83Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV83Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV84Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV85Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV87Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 5);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                return;
       }
    }

 }

}
