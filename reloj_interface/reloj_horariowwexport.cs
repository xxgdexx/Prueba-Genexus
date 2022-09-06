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
   public class reloj_horariowwexport : GXProcedure
   {
      public reloj_horariowwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horariowwexport( IGxContext context )
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
         reloj_horariowwexport objreloj_horariowwexport;
         objreloj_horariowwexport = new reloj_horariowwexport();
         objreloj_horariowwexport.AV11Filename = "" ;
         objreloj_horariowwexport.AV12ErrorMessage = "" ;
         objreloj_horariowwexport.context.SetSubmitInitialConfig(context);
         objreloj_horariowwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_horariowwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_horariowwexport)stateInfo).executePrivate();
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
         AV11Filename = "Reloj_HorarioWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV34TFHorario_ID) && (0==AV35TFHorario_ID_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "ID") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFHorario_ID;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFHorario_ID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFHorario_Dsc_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Horario_Dsc") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFHorario_Dsc_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFHorario_Dsc)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Horario_Dsc") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFHorario_Dsc, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (DateTime.MinValue==AV38TFHorario_Dia_Ini_01) && (DateTime.MinValue==AV39TFHorario_Dia_Ini_01_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Horario Ingreso") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.localUtil.Format( AV38TFHorario_Dia_Ini_01, "99:99");
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = context.localUtil.Format( AV39TFHorario_Dia_Ini_01_To, "99:99");
         }
         if ( ! ( (DateTime.MinValue==AV40TFHorario_Dia_Fin_01) && (DateTime.MinValue==AV41TFHorario_Dia_Fin_01_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Horario Salida") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = context.localUtil.Format( AV40TFHorario_Dia_Fin_01, "99:99");
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = context.localUtil.Format( AV41TFHorario_Dia_Fin_01_To, "99:99");
         }
         if ( ! ( (DateTime.MinValue==AV42TFHorario_Vigencia) && (DateTime.MinValue==AV43TFHorario_Vigencia_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Fecha Registro") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Date = AV42TFHorario_Vigencia;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Date = AV43TFHorario_Vigencia_To;
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
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Horario_Dsc";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Horario Ingreso";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Horario Salida";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Fecha Registro";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV34TFHorario_ID;
         AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV35TFHorario_ID_To;
         AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV36TFHorario_Dsc;
         AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV37TFHorario_Dsc_Sel;
         AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV38TFHorario_Dia_Ini_01;
         AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV39TFHorario_Dia_Ini_01_To;
         AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV40TFHorario_Dia_Fin_01;
         AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV41TFHorario_Dia_Fin_01_To;
         AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV42TFHorario_Vigencia;
         AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV43TFHorario_Vigencia_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                              AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                              AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                              AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                              AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                              AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                              AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                              AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                              AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                              AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                              A2432Horario_ID ,
                                              A2433Horario_Dsc ,
                                              A2434Horario_Dia_Ini_01 ,
                                              A2441Horario_Dia_Fin_01 ,
                                              A2462Horario_Vigencia ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = StringUtil.Concat( StringUtil.RTrim( AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc), "%", "");
         /* Using cursor P00GH2 */
         pr_default.execute(0, new Object[] {AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id, AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to, lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc, AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel, AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01, AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to, AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01, AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to, AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia, AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2462Horario_Vigencia = P00GH2_A2462Horario_Vigencia[0];
            A2441Horario_Dia_Fin_01 = P00GH2_A2441Horario_Dia_Fin_01[0];
            A2434Horario_Dia_Ini_01 = P00GH2_A2434Horario_Dia_Ini_01[0];
            A2433Horario_Dsc = P00GH2_A2433Horario_Dsc[0];
            A2432Horario_ID = P00GH2_A2432Horario_ID[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A2432Horario_ID;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2433Horario_Dsc, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = context.localUtil.Format( A2434Horario_Dia_Ini_01, "99:99");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = context.localUtil.Format( A2441Horario_Dia_Fin_01, "99:99");
            AV10ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Date = A2462Horario_Vigencia;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_ID") == 0 )
            {
               AV34TFHorario_ID = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFHorario_ID_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC") == 0 )
            {
               AV36TFHorario_Dsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC_SEL") == 0 )
            {
               AV37TFHorario_Dsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_INI_01") == 0 )
            {
               AV38TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, 2));
               AV39TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_FIN_01") == 0 )
            {
               AV40TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, 2));
               AV41TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFHORARIO_VIGENCIA") == 0 )
            {
               AV42TFHorario_Vigencia = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Value, 2);
               AV43TFHorario_Vigencia_To = context.localUtil.CToT( AV33GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
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
         AV37TFHorario_Dsc_Sel = "";
         AV36TFHorario_Dsc = "";
         AV38TFHorario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         AV39TFHorario_Dia_Ini_01_To = (DateTime)(DateTime.MinValue);
         AV40TFHorario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         AV41TFHorario_Dia_Fin_01_To = (DateTime)(DateTime.MinValue);
         AV42TFHorario_Vigencia = (DateTime)(DateTime.MinValue);
         AV43TFHorario_Vigencia_To = (DateTime)(DateTime.MinValue);
         AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = "";
         AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = (DateTime)(DateTime.MinValue);
         AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = (DateTime)(DateTime.MinValue);
         AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = (DateTime)(DateTime.MinValue);
         AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = (DateTime)(DateTime.MinValue);
         AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = (DateTime)(DateTime.MinValue);
         AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         A2433Horario_Dsc = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         P00GH2_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         P00GH2_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         P00GH2_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         P00GH2_A2433Horario_Dsc = new string[] {""} ;
         P00GH2_A2432Horario_ID = new short[1] ;
         GXt_char2 = "";
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horariowwexport__default(),
            new Object[][] {
                new Object[] {
               P00GH2_A2462Horario_Vigencia, P00GH2_A2441Horario_Dia_Fin_01, P00GH2_A2434Horario_Dia_Ini_01, P00GH2_A2433Horario_Dsc, P00GH2_A2432Horario_ID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV34TFHorario_ID ;
      private short AV35TFHorario_ID_To ;
      private short GXt_int1 ;
      private short AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id ;
      private short AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ;
      private short A2432Horario_ID ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV61GXV1 ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private DateTime AV38TFHorario_Dia_Ini_01 ;
      private DateTime AV39TFHorario_Dia_Ini_01_To ;
      private DateTime AV40TFHorario_Dia_Fin_01 ;
      private DateTime AV41TFHorario_Dia_Fin_01_To ;
      private DateTime AV42TFHorario_Vigencia ;
      private DateTime AV43TFHorario_Vigencia_To ;
      private DateTime AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ;
      private DateTime AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ;
      private DateTime AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ;
      private DateTime AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ;
      private DateTime AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ;
      private DateTime AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2462Horario_Vigencia ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV37TFHorario_Dsc_Sel ;
      private string AV36TFHorario_Dsc ;
      private string AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ;
      private string lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string A2433Horario_Dsc ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00GH2_A2462Horario_Vigencia ;
      private DateTime[] P00GH2_A2441Horario_Dia_Fin_01 ;
      private DateTime[] P00GH2_A2434Horario_Dia_Ini_01 ;
      private string[] P00GH2_A2433Horario_Dsc ;
      private short[] P00GH2_A2432Horario_ID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class reloj_horariowwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GH2( IGxContext context ,
                                             short AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                             short AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                             string AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                             string AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                             DateTime AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                             DateTime AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                             DateTime AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                             DateTime AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                             DateTime AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                             DateTime AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                             short A2432Horario_ID ,
                                             string A2433Horario_Dsc ,
                                             DateTime A2434Horario_Dia_Ini_01 ,
                                             DateTime A2441Horario_Dia_Fin_01 ,
                                             DateTime A2462Horario_Vigencia ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [Horario_Vigencia], [Horario_Dia_Fin_01], [Horario_Dia_Ini_01], [Horario_Dsc], [Horario_ID] FROM [Reloj_Horario]";
         if ( ! (0==AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id) )
         {
            AddWhere(sWhereString, "([Horario_ID] >= @AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to) )
         {
            AddWhere(sWhereString, "([Horario_ID] <= @AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)) ) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like @lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] = @AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] >= @AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] <= @AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] >= @AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] <= @AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] >= @AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] <= @AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_ID]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_ID] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dsc]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dsc] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Ini_01]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Ini_01] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Fin_01]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Fin_01] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Vigencia]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Vigencia] DESC";
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
                     return conditional_P00GH2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP00GH2;
          prmP00GH2 = new Object[] {
          new ParDef("@AV51Reloj_interface_reloj_horariowwds_1_tfhorario_id",GXType.Int16,4,0) ,
          new ParDef("@AV52Reloj_interface_reloj_horariowwds_2_tfhorario_id_to",GXType.Int16,4,0) ,
          new ParDef("@lV53Reloj_interface_reloj_horariowwds_3_tfhorario_dsc",GXType.NVarChar,100,5) ,
          new ParDef("@AV54Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel",GXType.NVarChar,100,5) ,
          new ParDef("@AV55Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01",GXType.DateTime,0,5) ,
          new ParDef("@AV56Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV57Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01",GXType.DateTime,0,5) ,
          new ParDef("@AV58Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV59Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia",GXType.DateTime,10,8) ,
          new ParDef("@AV60Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00GH2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GH2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
