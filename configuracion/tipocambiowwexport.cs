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
   public class tipocambiowwexport : GXProcedure
   {
      public tipocambiowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambiowwexport( IGxContext context )
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
         tipocambiowwexport objtipocambiowwexport;
         objtipocambiowwexport = new tipocambiowwexport();
         objtipocambiowwexport.AV11Filename = "" ;
         objtipocambiowwexport.AV12ErrorMessage = "" ;
         objtipocambiowwexport.context.SetSubmitInitialConfig(context);
         objtipocambiowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipocambiowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipocambiowwexport)stateInfo).executePrivate();
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
         AV11Filename = "TipoCambioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV42MonDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42MonDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42MonDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TIPFECH") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV44TipFech1 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Value, 2);
               AV45TipFech_To1 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Valueto, 2);
               AV43PrintFilterValue = false;
               if ( ! (DateTime.MinValue==AV44TipFech1) || ! (DateTime.MinValue==AV45TipFech_To1) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Pasado";
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoy";
                  }
                  else if ( AV19DynamicFiltersOperator1 == 2 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "En el futuro";
                  }
                  else if ( AV19DynamicFiltersOperator1 == 3 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                     AV43PrintFilterValue = true;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = " - ";
                  }
                  if ( AV43PrintFilterValue )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_dtime2 = DateTimeUtil.ResetTime( AV44TipFech1 ) ;
                     AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime2;
                     if ( AV43PrintFilterValue )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                        GXt_dtime2 = DateTimeUtil.ResetTime( AV45TipFech_To1 ) ;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime2;
                     }
                  }
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV46MonDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46MonDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV46MonDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TIPFECH") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV47TipFech2 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Value, 2);
                  AV48TipFech_To2 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Valueto, 2);
                  AV43PrintFilterValue = false;
                  if ( ! (DateTime.MinValue==AV47TipFech2) || ! (DateTime.MinValue==AV48TipFech_To2) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Pasado";
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoy";
                     }
                     else if ( AV23DynamicFiltersOperator2 == 2 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "En el futuro";
                     }
                     else if ( AV23DynamicFiltersOperator2 == 3 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                        AV43PrintFilterValue = true;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = " - ";
                     }
                     if ( AV43PrintFilterValue )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_dtime2 = DateTimeUtil.ResetTime( AV47TipFech2 ) ;
                        AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime2;
                        if ( AV43PrintFilterValue )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                           GXt_dtime2 = DateTimeUtil.ResetTime( AV48TipFech_To2 ) ;
                           AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime2;
                        }
                     }
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV49MonDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49MonDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Moneda", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV49MonDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TIPFECH") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV50TipFech3 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Value, 2);
                     AV51TipFech_To3 = context.localUtil.CToD( AV29GridStateDynamicFilter.gxTpr_Valueto, 2);
                     AV43PrintFilterValue = false;
                     if ( ! (DateTime.MinValue==AV50TipFech3) || ! (DateTime.MinValue==AV51TipFech_To3) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Pasado";
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Hoy";
                        }
                        else if ( AV27DynamicFiltersOperator3 == 2 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = "Fecha";
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "En el futuro";
                        }
                        else if ( AV27DynamicFiltersOperator3 == 3 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Fecha", "Período", "", "", "", "", "", "", "");
                           AV43PrintFilterValue = true;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 3;
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = " - ";
                        }
                        if ( AV43PrintFilterValue )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                           GXt_dtime2 = DateTimeUtil.ResetTime( AV50TipFech3 ) ;
                           AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime2;
                           if ( AV43PrintFilterValue )
                           {
                              AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Italic = 1;
                              GXt_dtime2 = DateTimeUtil.ResetTime( AV51TipFech_To3 ) ;
                              AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
                              AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime2;
                           }
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFMonDsc_Sel)) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "Moneda") ;
            AV13CellRow = GXt_int3;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFMonDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFMonDsc)) ) )
            {
               GXt_int3 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "Moneda") ;
               AV13CellRow = GXt_int3;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFMonDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( (DateTime.MinValue==AV34TFTipFech) && (DateTime.MinValue==AV35TFTipFech_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "Fecha") ;
            AV13CellRow = GXt_int3;
            GXt_dtime2 = DateTimeUtil.ResetTime( AV34TFTipFech ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime2;
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int3;
            GXt_dtime2 = DateTimeUtil.ResetTime( AV35TFTipFech_To ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = GXt_dtime2;
         }
         if ( ! ( (Convert.ToDecimal(0)==AV36TFTipCompra) && (Convert.ToDecimal(0)==AV37TFTipCompra_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "Compra") ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV36TFTipCompra);
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV37TFTipCompra_To);
         }
         if ( ! ( (Convert.ToDecimal(0)==AV38TFTipVenta) && (Convert.ToDecimal(0)==AV39TFTipVenta_To) ) )
         {
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn),  "Venta") ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = (double)(AV38TFTipVenta);
            GXt_int3 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int3,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int3;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(AV39TFTipVenta_To);
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Moneda";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Fecha";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Compra";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Venta";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV57Configuracion_tipocambiowwds_3_mondsc1 = AV42MonDsc1;
         AV58Configuracion_tipocambiowwds_4_tipfech1 = AV44TipFech1;
         AV59Configuracion_tipocambiowwds_5_tipfech_to1 = AV45TipFech_To1;
         AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV63Configuracion_tipocambiowwds_9_mondsc2 = AV46MonDsc2;
         AV64Configuracion_tipocambiowwds_10_tipfech2 = AV47TipFech2;
         AV65Configuracion_tipocambiowwds_11_tipfech_to2 = AV48TipFech_To2;
         AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV69Configuracion_tipocambiowwds_15_mondsc3 = AV49MonDsc3;
         AV70Configuracion_tipocambiowwds_16_tipfech3 = AV50TipFech3;
         AV71Configuracion_tipocambiowwds_17_tipfech_to3 = AV51TipFech_To3;
         AV72Configuracion_tipocambiowwds_18_tfmondsc = AV40TFMonDsc;
         AV73Configuracion_tipocambiowwds_19_tfmondsc_sel = AV41TFMonDsc_Sel;
         AV74Configuracion_tipocambiowwds_20_tftipfech = AV34TFTipFech;
         AV75Configuracion_tipocambiowwds_21_tftipfech_to = AV35TFTipFech_To;
         AV76Configuracion_tipocambiowwds_22_tftipcompra = AV36TFTipCompra;
         AV77Configuracion_tipocambiowwds_23_tftipcompra_to = AV37TFTipCompra_To;
         AV78Configuracion_tipocambiowwds_24_tftipventa = AV38TFTipVenta;
         AV79Configuracion_tipocambiowwds_25_tftipventa_to = AV39TFTipVenta_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_tipocambiowwds_3_mondsc1 ,
                                              AV58Configuracion_tipocambiowwds_4_tipfech1 ,
                                              AV59Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                              AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                              AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                              AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                              AV63Configuracion_tipocambiowwds_9_mondsc2 ,
                                              AV64Configuracion_tipocambiowwds_10_tipfech2 ,
                                              AV65Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                              AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                              AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                              AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                              AV69Configuracion_tipocambiowwds_15_mondsc3 ,
                                              AV70Configuracion_tipocambiowwds_16_tipfech3 ,
                                              AV71Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                              AV73Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                              AV72Configuracion_tipocambiowwds_18_tfmondsc ,
                                              AV74Configuracion_tipocambiowwds_20_tftipfech ,
                                              AV75Configuracion_tipocambiowwds_21_tftipfech_to ,
                                              AV76Configuracion_tipocambiowwds_22_tftipcompra ,
                                              AV77Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                              AV78Configuracion_tipocambiowwds_24_tftipventa ,
                                              AV79Configuracion_tipocambiowwds_25_tftipventa_to ,
                                              A1234MonDsc ,
                                              A308TipFech ,
                                              A1907TipCompra ,
                                              A1920TipVenta ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV57Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV57Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV63Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV63Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV69Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV69Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV72Configuracion_tipocambiowwds_18_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipocambiowwds_18_tfmondsc), 100, "%");
         /* Using cursor P00512 */
         pr_default.execute(0, new Object[] {lV57Configuracion_tipocambiowwds_3_mondsc1, lV57Configuracion_tipocambiowwds_3_mondsc1, AV58Configuracion_tipocambiowwds_4_tipfech1, AV58Configuracion_tipocambiowwds_4_tipfech1, AV58Configuracion_tipocambiowwds_4_tipfech1, AV58Configuracion_tipocambiowwds_4_tipfech1, AV59Configuracion_tipocambiowwds_5_tipfech_to1, lV63Configuracion_tipocambiowwds_9_mondsc2, lV63Configuracion_tipocambiowwds_9_mondsc2, AV64Configuracion_tipocambiowwds_10_tipfech2, AV64Configuracion_tipocambiowwds_10_tipfech2, AV64Configuracion_tipocambiowwds_10_tipfech2, AV64Configuracion_tipocambiowwds_10_tipfech2, AV65Configuracion_tipocambiowwds_11_tipfech_to2, lV69Configuracion_tipocambiowwds_15_mondsc3, lV69Configuracion_tipocambiowwds_15_mondsc3, AV70Configuracion_tipocambiowwds_16_tipfech3, AV70Configuracion_tipocambiowwds_16_tipfech3, AV70Configuracion_tipocambiowwds_16_tipfech3, AV70Configuracion_tipocambiowwds_16_tipfech3, AV71Configuracion_tipocambiowwds_17_tipfech_to3, lV72Configuracion_tipocambiowwds_18_tfmondsc, AV73Configuracion_tipocambiowwds_19_tfmondsc_sel, AV74Configuracion_tipocambiowwds_20_tftipfech, AV75Configuracion_tipocambiowwds_21_tftipfech_to, AV76Configuracion_tipocambiowwds_22_tftipcompra, AV77Configuracion_tipocambiowwds_23_tftipcompra_to, AV78Configuracion_tipocambiowwds_24_tftipventa, AV79Configuracion_tipocambiowwds_25_tftipventa_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A307TipMonCod = P00512_A307TipMonCod[0];
            A1920TipVenta = P00512_A1920TipVenta[0];
            A1907TipCompra = P00512_A1907TipCompra[0];
            A308TipFech = P00512_A308TipFech[0];
            A1234MonDsc = P00512_A1234MonDsc[0];
            n1234MonDsc = P00512_n1234MonDsc[0];
            A1234MonDsc = P00512_A1234MonDsc[0];
            n1234MonDsc = P00512_n1234MonDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A1234MonDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_dtime2 = DateTimeUtil.ResetTime( A308TipFech ) ;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = GXt_dtime2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Number = (double)(A1907TipCompra);
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = (double)(A1920TipVenta);
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
         if ( StringUtil.StrCmp(AV30Session.Get("Configuracion.TipoCambioWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV80GXV1 = 1;
         while ( AV80GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV80GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV40TFMonDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV41TFMonDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPFECH") == 0 )
            {
               AV34TFTipFech = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV35TFTipFech_To = context.localUtil.CToD( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPCOMPRA") == 0 )
            {
               AV36TFTipCompra = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV37TFTipCompra_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTIPVENTA") == 0 )
            {
               AV38TFTipVenta = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV39TFTipVenta_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV80GXV1 = (int)(AV80GXV1+1);
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
         AV42MonDsc1 = "";
         AV44TipFech1 = DateTime.MinValue;
         AV45TipFech_To1 = DateTime.MinValue;
         AV22DynamicFiltersSelector2 = "";
         AV46MonDsc2 = "";
         AV47TipFech2 = DateTime.MinValue;
         AV48TipFech_To2 = DateTime.MinValue;
         AV26DynamicFiltersSelector3 = "";
         AV49MonDsc3 = "";
         AV50TipFech3 = DateTime.MinValue;
         AV51TipFech_To3 = DateTime.MinValue;
         AV41TFMonDsc_Sel = "";
         AV40TFMonDsc = "";
         AV34TFTipFech = DateTime.MinValue;
         AV35TFTipFech_To = DateTime.MinValue;
         AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = "";
         AV57Configuracion_tipocambiowwds_3_mondsc1 = "";
         AV58Configuracion_tipocambiowwds_4_tipfech1 = DateTime.MinValue;
         AV59Configuracion_tipocambiowwds_5_tipfech_to1 = DateTime.MinValue;
         AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = "";
         AV63Configuracion_tipocambiowwds_9_mondsc2 = "";
         AV64Configuracion_tipocambiowwds_10_tipfech2 = DateTime.MinValue;
         AV65Configuracion_tipocambiowwds_11_tipfech_to2 = DateTime.MinValue;
         AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = "";
         AV69Configuracion_tipocambiowwds_15_mondsc3 = "";
         AV70Configuracion_tipocambiowwds_16_tipfech3 = DateTime.MinValue;
         AV71Configuracion_tipocambiowwds_17_tipfech_to3 = DateTime.MinValue;
         AV72Configuracion_tipocambiowwds_18_tfmondsc = "";
         AV73Configuracion_tipocambiowwds_19_tfmondsc_sel = "";
         AV74Configuracion_tipocambiowwds_20_tftipfech = DateTime.MinValue;
         AV75Configuracion_tipocambiowwds_21_tftipfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV57Configuracion_tipocambiowwds_3_mondsc1 = "";
         lV63Configuracion_tipocambiowwds_9_mondsc2 = "";
         lV69Configuracion_tipocambiowwds_15_mondsc3 = "";
         lV72Configuracion_tipocambiowwds_18_tfmondsc = "";
         A1234MonDsc = "";
         A308TipFech = DateTime.MinValue;
         P00512_A307TipMonCod = new int[1] ;
         P00512_A1920TipVenta = new decimal[1] ;
         P00512_A1907TipCompra = new decimal[1] ;
         P00512_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         P00512_A1234MonDsc = new string[] {""} ;
         P00512_n1234MonDsc = new bool[] {false} ;
         GXt_char1 = "";
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambiowwexport__default(),
            new Object[][] {
                new Object[] {
               P00512_A307TipMonCod, P00512_A1920TipVenta, P00512_A1907TipCompra, P00512_A308TipFech, P00512_A1234MonDsc, P00512_n1234MonDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short GXt_int3 ;
      private short AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ;
      private short AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ;
      private short AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int A307TipMonCod ;
      private int AV80GXV1 ;
      private decimal AV36TFTipCompra ;
      private decimal AV37TFTipCompra_To ;
      private decimal AV38TFTipVenta ;
      private decimal AV39TFTipVenta_To ;
      private decimal AV76Configuracion_tipocambiowwds_22_tftipcompra ;
      private decimal AV77Configuracion_tipocambiowwds_23_tftipcompra_to ;
      private decimal AV78Configuracion_tipocambiowwds_24_tftipventa ;
      private decimal AV79Configuracion_tipocambiowwds_25_tftipventa_to ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private string AV42MonDsc1 ;
      private string AV46MonDsc2 ;
      private string AV49MonDsc3 ;
      private string AV41TFMonDsc_Sel ;
      private string AV40TFMonDsc ;
      private string AV57Configuracion_tipocambiowwds_3_mondsc1 ;
      private string AV63Configuracion_tipocambiowwds_9_mondsc2 ;
      private string AV69Configuracion_tipocambiowwds_15_mondsc3 ;
      private string AV72Configuracion_tipocambiowwds_18_tfmondsc ;
      private string AV73Configuracion_tipocambiowwds_19_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV57Configuracion_tipocambiowwds_3_mondsc1 ;
      private string lV63Configuracion_tipocambiowwds_9_mondsc2 ;
      private string lV69Configuracion_tipocambiowwds_15_mondsc3 ;
      private string lV72Configuracion_tipocambiowwds_18_tfmondsc ;
      private string A1234MonDsc ;
      private string GXt_char1 ;
      private DateTime GXt_dtime2 ;
      private DateTime AV44TipFech1 ;
      private DateTime AV45TipFech_To1 ;
      private DateTime AV47TipFech2 ;
      private DateTime AV48TipFech_To2 ;
      private DateTime AV50TipFech3 ;
      private DateTime AV51TipFech_To3 ;
      private DateTime AV34TFTipFech ;
      private DateTime AV35TFTipFech_To ;
      private DateTime AV58Configuracion_tipocambiowwds_4_tipfech1 ;
      private DateTime AV59Configuracion_tipocambiowwds_5_tipfech_to1 ;
      private DateTime AV64Configuracion_tipocambiowwds_10_tipfech2 ;
      private DateTime AV65Configuracion_tipocambiowwds_11_tipfech_to2 ;
      private DateTime AV70Configuracion_tipocambiowwds_16_tipfech3 ;
      private DateTime AV71Configuracion_tipocambiowwds_17_tipfech_to3 ;
      private DateTime AV74Configuracion_tipocambiowwds_20_tftipfech ;
      private DateTime AV75Configuracion_tipocambiowwds_21_tftipfech_to ;
      private DateTime A308TipFech ;
      private bool returnInSub ;
      private bool AV43PrintFilterValue ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ;
      private bool AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private bool n1234MonDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ;
      private string AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ;
      private string AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00512_A307TipMonCod ;
      private decimal[] P00512_A1920TipVenta ;
      private decimal[] P00512_A1907TipCompra ;
      private DateTime[] P00512_A308TipFech ;
      private string[] P00512_A1234MonDsc ;
      private bool[] P00512_n1234MonDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class tipocambiowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00512( IGxContext context ,
                                             string AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_tipocambiowwds_3_mondsc1 ,
                                             DateTime AV58Configuracion_tipocambiowwds_4_tipfech1 ,
                                             DateTime AV59Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                             bool AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                             short AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_tipocambiowwds_9_mondsc2 ,
                                             DateTime AV64Configuracion_tipocambiowwds_10_tipfech2 ,
                                             DateTime AV65Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                             bool AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                             short AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_tipocambiowwds_15_mondsc3 ,
                                             DateTime AV70Configuracion_tipocambiowwds_16_tipfech3 ,
                                             DateTime AV71Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                             string AV73Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                             string AV72Configuracion_tipocambiowwds_18_tfmondsc ,
                                             DateTime AV74Configuracion_tipocambiowwds_20_tftipfech ,
                                             DateTime AV75Configuracion_tipocambiowwds_21_tftipfech_to ,
                                             decimal AV76Configuracion_tipocambiowwds_22_tftipcompra ,
                                             decimal AV77Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                             decimal AV78Configuracion_tipocambiowwds_24_tftipventa ,
                                             decimal AV79Configuracion_tipocambiowwds_25_tftipventa_to ,
                                             string A1234MonDsc ,
                                             DateTime A308TipFech ,
                                             decimal A1907TipCompra ,
                                             decimal A1920TipVenta ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[29];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[TipMonCod] AS TipMonCod, T1.[TipVenta], T1.[TipCompra], T1.[TipFech], T2.[MonDsc] FROM ([CTIPOCAMBIO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[TipMonCod])";
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV57Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV57Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV58Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV58Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV58Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV58Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV58Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV58Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV58Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV58Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV56Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV59Configuracion_tipocambiowwds_5_tipfech_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV59Configuracion_tipocambiowwds_5_tipfech_to1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV63Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV63Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV64Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV64Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV64Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV64Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV64Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV64Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV64Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV64Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV60Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV62Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV65Configuracion_tipocambiowwds_11_tipfech_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV65Configuracion_tipocambiowwds_11_tipfech_to2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV69Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV69Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV70Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV70Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV70Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV70Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV70Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV70Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV70Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV70Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV66Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV68Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV71Configuracion_tipocambiowwds_17_tipfech_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV71Configuracion_tipocambiowwds_17_tipfech_to3)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_19_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipocambiowwds_18_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV72Configuracion_tipocambiowwds_18_tfmondsc)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_tipocambiowwds_19_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV73Configuracion_tipocambiowwds_19_tfmondsc_sel)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Configuracion_tipocambiowwds_20_tftipfech) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV74Configuracion_tipocambiowwds_20_tftipfech)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_21_tftipfech_to) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV75Configuracion_tipocambiowwds_21_tftipfech_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Configuracion_tipocambiowwds_22_tftipcompra) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] >= @AV76Configuracion_tipocambiowwds_22_tftipcompra)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV77Configuracion_tipocambiowwds_23_tftipcompra_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] <= @AV77Configuracion_tipocambiowwds_23_tftipcompra_to)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV78Configuracion_tipocambiowwds_24_tftipventa) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] >= @AV78Configuracion_tipocambiowwds_24_tftipventa)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV79Configuracion_tipocambiowwds_25_tftipventa_to) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] <= @AV79Configuracion_tipocambiowwds_25_tftipventa_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipFech]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipFech] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipCompra]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipCompra] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[TipVenta]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[TipVenta] DESC";
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
                     return conditional_P00512(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] );
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
          Object[] prmP00512;
          prmP00512 = new Object[] {
          new ParDef("@lV57Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@AV58Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV58Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV58Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV58Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV59Configuracion_tipocambiowwds_5_tipfech_to1",GXType.Date,8,0) ,
          new ParDef("@lV63Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV64Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV64Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV64Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV65Configuracion_tipocambiowwds_11_tipfech_to2",GXType.Date,8,0) ,
          new ParDef("@lV69Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV70Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV70Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV70Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV71Configuracion_tipocambiowwds_17_tipfech_to3",GXType.Date,8,0) ,
          new ParDef("@lV72Configuracion_tipocambiowwds_18_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_tipocambiowwds_19_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV74Configuracion_tipocambiowwds_20_tftipfech",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_21_tftipfech_to",GXType.Date,8,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_22_tftipcompra",GXType.Decimal,15,5) ,
          new ParDef("@AV77Configuracion_tipocambiowwds_23_tftipcompra_to",GXType.Decimal,15,5) ,
          new ParDef("@AV78Configuracion_tipocambiowwds_24_tftipventa",GXType.Decimal,15,5) ,
          new ParDef("@AV79Configuracion_tipocambiowwds_25_tftipventa_to",GXType.Decimal,15,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00512", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00512,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
