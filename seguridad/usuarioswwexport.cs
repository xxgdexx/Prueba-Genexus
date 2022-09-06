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
   public class usuarioswwexport : GXProcedure
   {
      public usuarioswwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuarioswwexport( IGxContext context )
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
         usuarioswwexport objusuarioswwexport;
         objusuarioswwexport = new usuarioswwexport();
         objusuarioswwexport.AV11Filename = "" ;
         objusuarioswwexport.AV12ErrorMessage = "" ;
         objusuarioswwexport.context.SetSubmitInitialConfig(context);
         objusuarioswwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuarioswwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuarioswwexport)stateInfo).executePrivate();
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
         AV11Filename = "UsuariosWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "USUVENDDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV91UsuVendDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91UsuVendDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV91UsuVendDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "USUTIEDSC") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV92UsuTieDsc1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92UsuTieDsc1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV92UsuTieDsc1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "USUNOM") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV29GridStateDynamicFilter.gxTpr_Operator;
               AV84UsuNom1 = AV29GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84UsuNom1)) )
               {
                  AV13CellRow = (int)(AV13CellRow+1);
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                  if ( AV19DynamicFiltersOperator1 == 0 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV19DynamicFiltersOperator1 == 1 )
                  {
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                  GXt_char1 = "";
                  new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV84UsuNom1, out  GXt_char1) ;
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
               }
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV21DynamicFiltersEnabled2 = true;
               AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV29GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "USUVENDDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV93UsuVendDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93UsuVendDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV93UsuVendDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "USUTIEDSC") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV94UsuTieDsc2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94UsuTieDsc2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV94UsuTieDsc2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "USUNOM") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV29GridStateDynamicFilter.gxTpr_Operator;
                  AV85UsuNom2 = AV29GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85UsuNom2)) )
                  {
                     AV13CellRow = (int)(AV13CellRow+1);
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                     if ( AV23DynamicFiltersOperator2 == 0 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV23DynamicFiltersOperator2 == 1 )
                     {
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                     GXt_char1 = "";
                     new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV85UsuNom2, out  GXt_char1) ;
                     AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                  }
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV29GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV29GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "USUVENDDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV95UsuVendDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95UsuVendDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV95UsuVendDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "USUTIEDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV96UsuTieDsc3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96UsuTieDsc3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV96UsuTieDsc3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "USUNOM") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV29GridStateDynamicFilter.gxTpr_Operator;
                     AV86UsuNom3 = AV29GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86UsuNom3)) )
                     {
                        AV13CellRow = (int)(AV13CellRow+1);
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Bold = 1;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Color = 3;
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn, 1, 1).Text = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Italic = 1;
                        GXt_char1 = "";
                        new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV86UsuNom3, out  GXt_char1) ;
                        AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
                     }
                  }
               }
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV35TFUsuCod_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV35TFUsuCod_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34TFUsuCod)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Usuario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV34TFUsuCod, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFUsuNom_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nombre Usuario") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFUsuNom_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFUsuNom)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Nombre Usuario") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFUsuNom, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV71TFUsuEMAIL_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-Mail") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV71TFUsuEMAIL_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFUsuEMAIL)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "E-Mail") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV70TFUsuEMAIL, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( ( AV88TFUsuSts_Sels.Count == 0 ) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Estado") ;
            AV13CellRow = GXt_int2;
            AV90i = 1;
            AV103GXV1 = 1;
            while ( AV103GXV1 <= AV88TFUsuSts_Sels.Count )
            {
               AV89TFUsuSts_Sel = (short)(AV88TFUsuSts_Sels.GetNumeric(AV103GXV1));
               if ( AV90i == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "";
               }
               else
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+", ";
               }
               if ( AV89TFUsuSts_Sel == 1 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"ACTIVO";
               }
               else if ( AV89TFUsuSts_Sel == 0 )
               {
                  AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text+"INACTIVO";
               }
               AV90i = (long)(AV90i+1);
               AV103GXV1 = (int)(AV103GXV1+1);
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV98TFUsuVendDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV98TFUsuVendDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV97TFUsuVendDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Vendedor") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV97TFUsuVendDsc, out  GXt_char1) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV100TFUsuTieDsc_Sel)) ) )
         {
            GXt_int2 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Local") ;
            AV13CellRow = GXt_int2;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV100TFUsuTieDsc_Sel, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV99TFUsuTieDsc)) ) )
            {
               GXt_int2 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int2,  (short)(AV14FirstColumn),  "Local") ;
               AV13CellRow = GXt_int2;
               GXt_char1 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV99TFUsuTieDsc, out  GXt_char1) ;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Usuario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Nombre Usuario";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "E-Mail";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Estado";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Vendedor";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Local";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV107Seguridad_usuarioswwds_3_usuvenddsc1 = AV91UsuVendDsc1;
         AV108Seguridad_usuarioswwds_4_usutiedsc1 = AV92UsuTieDsc1;
         AV109Seguridad_usuarioswwds_5_usunom1 = AV84UsuNom1;
         AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV113Seguridad_usuarioswwds_9_usuvenddsc2 = AV93UsuVendDsc2;
         AV114Seguridad_usuarioswwds_10_usutiedsc2 = AV94UsuTieDsc2;
         AV115Seguridad_usuarioswwds_11_usunom2 = AV85UsuNom2;
         AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV119Seguridad_usuarioswwds_15_usuvenddsc3 = AV95UsuVendDsc3;
         AV120Seguridad_usuarioswwds_16_usutiedsc3 = AV96UsuTieDsc3;
         AV121Seguridad_usuarioswwds_17_usunom3 = AV86UsuNom3;
         AV122Seguridad_usuarioswwds_18_tfusucod = AV34TFUsuCod;
         AV123Seguridad_usuarioswwds_19_tfusucod_sel = AV35TFUsuCod_Sel;
         AV124Seguridad_usuarioswwds_20_tfusunom = AV38TFUsuNom;
         AV125Seguridad_usuarioswwds_21_tfusunom_sel = AV39TFUsuNom_Sel;
         AV126Seguridad_usuarioswwds_22_tfusuemail = AV70TFUsuEMAIL;
         AV127Seguridad_usuarioswwds_23_tfusuemail_sel = AV71TFUsuEMAIL_Sel;
         AV128Seguridad_usuarioswwds_24_tfususts_sels = AV88TFUsuSts_Sels;
         AV129Seguridad_usuarioswwds_25_tfusuvenddsc = AV97TFUsuVendDsc;
         AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV98TFUsuVendDsc_Sel;
         AV131Seguridad_usuarioswwds_27_tfusutiedsc = AV99TFUsuTieDsc;
         AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV100TFUsuTieDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV128Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV107Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV108Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV109Seguridad_usuarioswwds_5_usunom1 ,
                                              AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV113Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV114Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV115Seguridad_usuarioswwds_11_usunom2 ,
                                              AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV119Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV120Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV121Seguridad_usuarioswwds_17_usunom3 ,
                                              AV123Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV122Seguridad_usuarioswwds_18_tfusucod ,
                                              AV125Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV124Seguridad_usuarioswwds_20_tfusunom ,
                                              AV127Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV126Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV128Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV129Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV131Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV107Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV107Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV107Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV107Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV108Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV108Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV108Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV108Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV109Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV109Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV109Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV113Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV113Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV113Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV113Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV114Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV114Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV114Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV114Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV115Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV115Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV115Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV119Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV119Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV119Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV119Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV120Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV120Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV120Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV120Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV121Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV121Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV121Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV122Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV124Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV126Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV126Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV129Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV129Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV131Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV131Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P00272 */
         pr_default.execute(0, new Object[] {lV107Seguridad_usuarioswwds_3_usuvenddsc1, lV107Seguridad_usuarioswwds_3_usuvenddsc1, lV108Seguridad_usuarioswwds_4_usutiedsc1, lV108Seguridad_usuarioswwds_4_usutiedsc1, lV109Seguridad_usuarioswwds_5_usunom1, lV109Seguridad_usuarioswwds_5_usunom1, lV113Seguridad_usuarioswwds_9_usuvenddsc2, lV113Seguridad_usuarioswwds_9_usuvenddsc2, lV114Seguridad_usuarioswwds_10_usutiedsc2, lV114Seguridad_usuarioswwds_10_usutiedsc2, lV115Seguridad_usuarioswwds_11_usunom2, lV115Seguridad_usuarioswwds_11_usunom2, lV119Seguridad_usuarioswwds_15_usuvenddsc3, lV119Seguridad_usuarioswwds_15_usuvenddsc3, lV120Seguridad_usuarioswwds_16_usutiedsc3, lV120Seguridad_usuarioswwds_16_usutiedsc3, lV121Seguridad_usuarioswwds_17_usunom3, lV121Seguridad_usuarioswwds_17_usunom3, lV122Seguridad_usuarioswwds_18_tfusucod, AV123Seguridad_usuarioswwds_19_tfusucod_sel, lV124Seguridad_usuarioswwds_20_tfusunom, AV125Seguridad_usuarioswwds_21_tfusunom_sel, lV126Seguridad_usuarioswwds_22_tfusuemail, AV127Seguridad_usuarioswwds_23_tfusuemail_sel, lV129Seguridad_usuarioswwds_25_tfusuvenddsc, AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV131Seguridad_usuarioswwds_27_tfusutiedsc, AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2041UsuVend = P00272_A2041UsuVend[0];
            A2040UsuTieCod = P00272_A2040UsuTieCod[0];
            A2039UsuSts = P00272_A2039UsuSts[0];
            A2014UsuEMAIL = P00272_A2014UsuEMAIL[0];
            A348UsuCod = P00272_A348UsuCod[0];
            A2019UsuNom = P00272_A2019UsuNom[0];
            A2096UsuTieDsc = P00272_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P00272_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P00272_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P00272_A2096UsuTieDsc[0];
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
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A348UsuCod, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2019UsuNom, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2014UsuEMAIL, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "";
            if ( A2039UsuSts == 1 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "ACTIVO";
            }
            else if ( A2039UsuSts == 0 )
            {
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "INACTIVO";
            }
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2097UsuVendDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char1;
            GXt_char1 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2096UsuTieDsc, out  GXt_char1) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = GXt_char1;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Seguridad.UsuariosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.UsuariosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Seguridad.UsuariosWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV133GXV2 = 1;
         while ( AV133GXV2 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV133GXV2));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUCOD") == 0 )
            {
               AV34TFUsuCod = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUCOD_SEL") == 0 )
            {
               AV35TFUsuCod_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUNOM") == 0 )
            {
               AV38TFUsuNom = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUNOM_SEL") == 0 )
            {
               AV39TFUsuNom_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL") == 0 )
            {
               AV70TFUsuEMAIL = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL_SEL") == 0 )
            {
               AV71TFUsuEMAIL_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUSTS_SEL") == 0 )
            {
               AV87TFUsuSts_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV88TFUsuSts_Sels.FromJSonString(AV87TFUsuSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC") == 0 )
            {
               AV97TFUsuVendDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC_SEL") == 0 )
            {
               AV98TFUsuVendDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC") == 0 )
            {
               AV99TFUsuTieDsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC_SEL") == 0 )
            {
               AV100TFUsuTieDsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV133GXV2 = (int)(AV133GXV2+1);
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
         AV91UsuVendDsc1 = "";
         AV92UsuTieDsc1 = "";
         AV84UsuNom1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV93UsuVendDsc2 = "";
         AV94UsuTieDsc2 = "";
         AV85UsuNom2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV95UsuVendDsc3 = "";
         AV96UsuTieDsc3 = "";
         AV86UsuNom3 = "";
         AV35TFUsuCod_Sel = "";
         AV34TFUsuCod = "";
         AV39TFUsuNom_Sel = "";
         AV38TFUsuNom = "";
         AV71TFUsuEMAIL_Sel = "";
         AV70TFUsuEMAIL = "";
         AV88TFUsuSts_Sels = new GxSimpleCollection<short>();
         AV98TFUsuVendDsc_Sel = "";
         AV97TFUsuVendDsc = "";
         AV100TFUsuTieDsc_Sel = "";
         AV99TFUsuTieDsc = "";
         AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1 = "";
         AV107Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         AV108Seguridad_usuarioswwds_4_usutiedsc1 = "";
         AV109Seguridad_usuarioswwds_5_usunom1 = "";
         AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2 = "";
         AV113Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         AV114Seguridad_usuarioswwds_10_usutiedsc2 = "";
         AV115Seguridad_usuarioswwds_11_usunom2 = "";
         AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3 = "";
         AV119Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         AV120Seguridad_usuarioswwds_16_usutiedsc3 = "";
         AV121Seguridad_usuarioswwds_17_usunom3 = "";
         AV122Seguridad_usuarioswwds_18_tfusucod = "";
         AV123Seguridad_usuarioswwds_19_tfusucod_sel = "";
         AV124Seguridad_usuarioswwds_20_tfusunom = "";
         AV125Seguridad_usuarioswwds_21_tfusunom_sel = "";
         AV126Seguridad_usuarioswwds_22_tfusuemail = "";
         AV127Seguridad_usuarioswwds_23_tfusuemail_sel = "";
         AV128Seguridad_usuarioswwds_24_tfususts_sels = new GxSimpleCollection<short>();
         AV129Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel = "";
         AV131Seguridad_usuarioswwds_27_tfusutiedsc = "";
         AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel = "";
         scmdbuf = "";
         lV107Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         lV108Seguridad_usuarioswwds_4_usutiedsc1 = "";
         lV109Seguridad_usuarioswwds_5_usunom1 = "";
         lV113Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         lV114Seguridad_usuarioswwds_10_usutiedsc2 = "";
         lV115Seguridad_usuarioswwds_11_usunom2 = "";
         lV119Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         lV120Seguridad_usuarioswwds_16_usutiedsc3 = "";
         lV121Seguridad_usuarioswwds_17_usunom3 = "";
         lV122Seguridad_usuarioswwds_18_tfusucod = "";
         lV124Seguridad_usuarioswwds_20_tfusunom = "";
         lV126Seguridad_usuarioswwds_22_tfusuemail = "";
         lV129Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         lV131Seguridad_usuarioswwds_27_tfusutiedsc = "";
         A2097UsuVendDsc = "";
         A2096UsuTieDsc = "";
         A2019UsuNom = "";
         A348UsuCod = "";
         A2014UsuEMAIL = "";
         P00272_A2041UsuVend = new int[1] ;
         P00272_A2040UsuTieCod = new int[1] ;
         P00272_A2039UsuSts = new short[1] ;
         P00272_A2014UsuEMAIL = new string[] {""} ;
         P00272_A348UsuCod = new string[] {""} ;
         P00272_A2019UsuNom = new string[] {""} ;
         P00272_A2096UsuTieDsc = new string[] {""} ;
         P00272_A2097UsuVendDsc = new string[] {""} ;
         GXt_char1 = "";
         AV30Session = context.GetSession();
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV87TFUsuSts_SelsJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuarioswwexport__default(),
            new Object[][] {
                new Object[] {
               P00272_A2041UsuVend, P00272_A2040UsuTieCod, P00272_A2039UsuSts, P00272_A2014UsuEMAIL, P00272_A348UsuCod, P00272_A2019UsuNom, P00272_A2096UsuTieDsc, P00272_A2097UsuVendDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV89TFUsuSts_Sel ;
      private short GXt_int2 ;
      private short AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ;
      private short AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ;
      private short AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ;
      private short A2039UsuSts ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV103GXV1 ;
      private int AV128Seguridad_usuarioswwds_24_tfususts_sels_Count ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int AV133GXV2 ;
      private long AV90i ;
      private string AV91UsuVendDsc1 ;
      private string AV92UsuTieDsc1 ;
      private string AV84UsuNom1 ;
      private string AV93UsuVendDsc2 ;
      private string AV94UsuTieDsc2 ;
      private string AV85UsuNom2 ;
      private string AV95UsuVendDsc3 ;
      private string AV96UsuTieDsc3 ;
      private string AV86UsuNom3 ;
      private string AV35TFUsuCod_Sel ;
      private string AV34TFUsuCod ;
      private string AV39TFUsuNom_Sel ;
      private string AV38TFUsuNom ;
      private string AV98TFUsuVendDsc_Sel ;
      private string AV97TFUsuVendDsc ;
      private string AV100TFUsuTieDsc_Sel ;
      private string AV99TFUsuTieDsc ;
      private string AV107Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string AV108Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string AV109Seguridad_usuarioswwds_5_usunom1 ;
      private string AV113Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string AV114Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string AV115Seguridad_usuarioswwds_11_usunom2 ;
      private string AV119Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string AV120Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string AV121Seguridad_usuarioswwds_17_usunom3 ;
      private string AV122Seguridad_usuarioswwds_18_tfusucod ;
      private string AV123Seguridad_usuarioswwds_19_tfusucod_sel ;
      private string AV124Seguridad_usuarioswwds_20_tfusunom ;
      private string AV125Seguridad_usuarioswwds_21_tfusunom_sel ;
      private string AV129Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel ;
      private string AV131Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel ;
      private string scmdbuf ;
      private string lV107Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string lV108Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string lV109Seguridad_usuarioswwds_5_usunom1 ;
      private string lV113Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string lV114Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string lV115Seguridad_usuarioswwds_11_usunom2 ;
      private string lV119Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string lV120Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string lV121Seguridad_usuarioswwds_17_usunom3 ;
      private string lV122Seguridad_usuarioswwds_18_tfusucod ;
      private string lV124Seguridad_usuarioswwds_20_tfusunom ;
      private string lV129Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string lV131Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string A2097UsuVendDsc ;
      private string A2096UsuTieDsc ;
      private string A2019UsuNom ;
      private string A348UsuCod ;
      private string GXt_char1 ;
      private bool returnInSub ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ;
      private bool AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ;
      private bool AV17OrderedDsc ;
      private string AV87TFUsuSts_SelsJson ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV71TFUsuEMAIL_Sel ;
      private string AV70TFUsuEMAIL ;
      private string AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1 ;
      private string AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2 ;
      private string AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3 ;
      private string AV126Seguridad_usuarioswwds_22_tfusuemail ;
      private string AV127Seguridad_usuarioswwds_23_tfusuemail_sel ;
      private string lV126Seguridad_usuarioswwds_22_tfusuemail ;
      private string A2014UsuEMAIL ;
      private GxSimpleCollection<short> AV88TFUsuSts_Sels ;
      private GxSimpleCollection<short> AV128Seguridad_usuarioswwds_24_tfususts_sels ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00272_A2041UsuVend ;
      private int[] P00272_A2040UsuTieCod ;
      private short[] P00272_A2039UsuSts ;
      private string[] P00272_A2014UsuEMAIL ;
      private string[] P00272_A348UsuCod ;
      private string[] P00272_A2019UsuNom ;
      private string[] P00272_A2096UsuTieDsc ;
      private string[] P00272_A2097UsuVendDsc ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV29GridStateDynamicFilter ;
   }

   public class usuarioswwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00272( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV128Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV107Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV108Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV109Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV113Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV114Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV115Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV119Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV120Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV121Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV123Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV122Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV125Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV124Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV127Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV126Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV128Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV129Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV131Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T1.[UsuNom], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV107Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV107Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV108Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV108Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV109Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV105Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV106Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV109Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV113Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV113Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV114Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV114Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV115Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV110Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV111Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV112Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV115Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV119Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV119Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV120Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV120Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV121Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV116Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV117Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV118Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV121Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV122Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV123Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV125Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV126Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV127Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV128Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV128Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV129Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV131Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuCod]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuCod] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuNom]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuNom] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuEMAIL]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuEMAIL] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuSts]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuSts] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[TieDsc]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[TieDsc] DESC";
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
                     return conditional_P00272(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmP00272;
          prmP00272 = new Object[] {
          new ParDef("@lV107Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV107Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV108Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV108Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV109Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV109Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV113Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV113Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV114Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV114Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV115Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV119Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV119Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV120Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV120Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV121Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV123Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV125Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV126Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV127Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV131Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV132Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00272", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00272,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
       }
    }

 }

}
