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
   public class relojwwexport : GXProcedure
   {
      public relojwwexport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relojwwexport( IGxContext context )
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
         relojwwexport objrelojwwexport;
         objrelojwwexport = new relojwwexport();
         objrelojwwexport.AV11Filename = "" ;
         objrelojwwexport.AV12ErrorMessage = "" ;
         objrelojwwexport.context.SetSubmitInitialConfig(context);
         objrelojwwexport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrelojwwexport);
         aP0_Filename=this.AV11Filename;
         aP1_ErrorMessage=this.AV12ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((relojwwexport)stateInfo).executePrivate();
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
         AV11Filename = "RelojWWExport-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV15Random), 8, 0)) + ".xlsx";
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
         if ( ! ( (0==AV34TFRelojID) && (0==AV35TFRelojID_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Código") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV34TFRelojID;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV35TFRelojID_To;
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TFReloj_Nom_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Nom") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV37TFReloj_Nom_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReloj_Nom)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Nom") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV36TFReloj_Nom, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV39TFReloj_Dsc_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Dsc") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV39TFReloj_Dsc_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReloj_Dsc)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Dsc") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV38TFReloj_Dsc, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV41TFReloj_IP_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_IP") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV41TFReloj_IP_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFReloj_IP)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_IP") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV40TFReloj_IP, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43TFReloj_Puerto_Sel)) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Puerto") ;
            AV13CellRow = GXt_int1;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV43TFReloj_Puerto_Sel, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV42TFReloj_Puerto)) ) )
            {
               GXt_int1 = (short)(AV13CellRow);
               new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Puerto") ;
               AV13CellRow = GXt_int1;
               GXt_char2 = "";
               new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  AV42TFReloj_Puerto, out  GXt_char2) ;
               AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            }
         }
         if ( ! ( (0==AV44TFReloj_Estado) && (0==AV45TFReloj_Estado_To) ) )
         {
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn),  "Reloj_Estado") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Number = AV44TFReloj_Estado;
            GXt_int1 = (short)(AV13CellRow);
            new GeneXus.Programs.wwpbaseobjects.wwp_exportwritefilter(context ).execute( ref  AV10ExcelDocument,  true, ref  GXt_int1,  (short)(AV14FirstColumn+2),  "Hasta") ;
            AV13CellRow = GXt_int1;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Number = AV45TFReloj_Estado_To;
         }
         AV13CellRow = (int)(AV13CellRow+2);
      }

      protected void S141( )
      {
         /* 'WRITECOLUMNTITLES' Routine */
         returnInSub = false;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Text = "Código";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = "Reloj_Nom";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = "Reloj_Dsc";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = "Reloj_IP";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = "Reloj_Puerto";
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Bold = 1;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Color = 11;
         AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Text = "Reloj_Estado";
      }

      protected void S151( )
      {
         /* 'WRITEDATA' Routine */
         returnInSub = false;
         AV49Reloj_interface_relojwwds_1_tfrelojid = AV34TFRelojID;
         AV50Reloj_interface_relojwwds_2_tfrelojid_to = AV35TFRelojID_To;
         AV51Reloj_interface_relojwwds_3_tfreloj_nom = AV36TFReloj_Nom;
         AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV37TFReloj_Nom_Sel;
         AV53Reloj_interface_relojwwds_5_tfreloj_dsc = AV38TFReloj_Dsc;
         AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV39TFReloj_Dsc_Sel;
         AV55Reloj_interface_relojwwds_7_tfreloj_ip = AV40TFReloj_IP;
         AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV41TFReloj_IP_Sel;
         AV57Reloj_interface_relojwwds_9_tfreloj_puerto = AV42TFReloj_Puerto;
         AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV43TFReloj_Puerto_Sel;
         AV59Reloj_interface_relojwwds_11_tfreloj_estado = AV44TFReloj_Estado;
         AV60Reloj_interface_relojwwds_12_tfreloj_estado_to = AV45TFReloj_Estado_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV50Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV51Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV53Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV55Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV57Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV59Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV60Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado ,
                                              AV16OrderedBy ,
                                              AV17OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV51Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV51Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV53Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV53Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV55Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV55Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV57Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV57Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GE2 */
         pr_default.execute(0, new Object[] {AV49Reloj_interface_relojwwds_1_tfrelojid, AV50Reloj_interface_relojwwds_2_tfrelojid_to, lV51Reloj_interface_relojwwds_3_tfreloj_nom, AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV53Reloj_interface_relojwwds_5_tfreloj_dsc, AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV55Reloj_interface_relojwwds_7_tfreloj_ip, AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV57Reloj_interface_relojwwds_9_tfreloj_puerto, AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV59Reloj_interface_relojwwds_11_tfreloj_estado, AV60Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2429Reloj_Estado = P00GE2_A2429Reloj_Estado[0];
            A2428Reloj_Puerto = P00GE2_A2428Reloj_Puerto[0];
            A2427Reloj_IP = P00GE2_A2427Reloj_IP[0];
            A2426Reloj_Dsc = P00GE2_A2426Reloj_Dsc[0];
            A2425Reloj_Nom = P00GE2_A2425Reloj_Nom[0];
            A2430RelojID = P00GE2_A2430RelojID[0];
            AV13CellRow = (int)(AV13CellRow+1);
            /* Execute user subroutine: 'BEFOREWRITELINE' */
            S162 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+0, 1, 1).Number = A2430RelojID;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2425Reloj_Nom, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+1, 1, 1).Text = GXt_char2;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2426Reloj_Dsc, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+2, 1, 1).Text = GXt_char2;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2427Reloj_IP, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+3, 1, 1).Text = GXt_char2;
            GXt_char2 = "";
            new GeneXus.Programs.wwpbaseobjects.wwp_export_securetext(context ).execute(  A2428Reloj_Puerto, out  GXt_char2) ;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+4, 1, 1).Text = GXt_char2;
            AV10ExcelDocument.get_Cells(AV13CellRow, AV14FirstColumn+5, 1, 1).Number = A2429Reloj_Estado;
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
         if ( StringUtil.StrCmp(AV30Session.Get("Reloj_Interface.RelojWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         AV16OrderedBy = AV32GridState.gxTpr_Orderedby;
         AV17OrderedDsc = AV32GridState.gxTpr_Ordereddsc;
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJID") == 0 )
            {
               AV34TFRelojID = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV35TFRelojID_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM") == 0 )
            {
               AV36TFReloj_Nom = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM_SEL") == 0 )
            {
               AV37TFReloj_Nom_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC") == 0 )
            {
               AV38TFReloj_Dsc = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC_SEL") == 0 )
            {
               AV39TFReloj_Dsc_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP") == 0 )
            {
               AV40TFReloj_IP = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP_SEL") == 0 )
            {
               AV41TFReloj_IP_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO") == 0 )
            {
               AV42TFReloj_Puerto = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO_SEL") == 0 )
            {
               AV43TFReloj_Puerto_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFRELOJ_ESTADO") == 0 )
            {
               AV44TFReloj_Estado = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."));
               AV45TFReloj_Estado_To = (short)(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."));
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
         AV37TFReloj_Nom_Sel = "";
         AV36TFReloj_Nom = "";
         AV39TFReloj_Dsc_Sel = "";
         AV38TFReloj_Dsc = "";
         AV41TFReloj_IP_Sel = "";
         AV40TFReloj_IP = "";
         AV43TFReloj_Puerto_Sel = "";
         AV42TFReloj_Puerto = "";
         AV51Reloj_interface_relojwwds_3_tfreloj_nom = "";
         AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel = "";
         AV53Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel = "";
         AV55Reloj_interface_relojwwds_7_tfreloj_ip = "";
         AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel = "";
         AV57Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel = "";
         scmdbuf = "";
         lV51Reloj_interface_relojwwds_3_tfreloj_nom = "";
         lV53Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         lV55Reloj_interface_relojwwds_7_tfreloj_ip = "";
         lV57Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         P00GE2_A2429Reloj_Estado = new short[1] ;
         P00GE2_A2428Reloj_Puerto = new string[] {""} ;
         P00GE2_A2427Reloj_IP = new string[] {""} ;
         P00GE2_A2426Reloj_Dsc = new string[] {""} ;
         P00GE2_A2425Reloj_Nom = new string[] {""} ;
         P00GE2_A2430RelojID = new short[1] ;
         GXt_char2 = "";
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.relojwwexport__default(),
            new Object[][] {
                new Object[] {
               P00GE2_A2429Reloj_Estado, P00GE2_A2428Reloj_Puerto, P00GE2_A2427Reloj_IP, P00GE2_A2426Reloj_Dsc, P00GE2_A2425Reloj_Nom, P00GE2_A2430RelojID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV34TFRelojID ;
      private short AV35TFRelojID_To ;
      private short AV44TFReloj_Estado ;
      private short AV45TFReloj_Estado_To ;
      private short GXt_int1 ;
      private short AV49Reloj_interface_relojwwds_1_tfrelojid ;
      private short AV50Reloj_interface_relojwwds_2_tfrelojid_to ;
      private short AV59Reloj_interface_relojwwds_11_tfreloj_estado ;
      private short AV60Reloj_interface_relojwwds_12_tfreloj_estado_to ;
      private short A2430RelojID ;
      private short A2429Reloj_Estado ;
      private short AV16OrderedBy ;
      private int AV13CellRow ;
      private int AV14FirstColumn ;
      private int AV15Random ;
      private int AV61GXV1 ;
      private string scmdbuf ;
      private string GXt_char2 ;
      private bool returnInSub ;
      private bool AV17OrderedDsc ;
      private string AV11Filename ;
      private string AV12ErrorMessage ;
      private string AV37TFReloj_Nom_Sel ;
      private string AV36TFReloj_Nom ;
      private string AV39TFReloj_Dsc_Sel ;
      private string AV38TFReloj_Dsc ;
      private string AV41TFReloj_IP_Sel ;
      private string AV40TFReloj_IP ;
      private string AV43TFReloj_Puerto_Sel ;
      private string AV42TFReloj_Puerto ;
      private string AV51Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel ;
      private string AV53Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel ;
      private string AV55Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel ;
      private string AV57Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel ;
      private string lV51Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string lV53Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string lV55Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string lV57Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00GE2_A2429Reloj_Estado ;
      private string[] P00GE2_A2428Reloj_Puerto ;
      private string[] P00GE2_A2427Reloj_IP ;
      private string[] P00GE2_A2426Reloj_Dsc ;
      private string[] P00GE2_A2425Reloj_Nom ;
      private short[] P00GE2_A2430RelojID ;
      private string aP0_Filename ;
      private string aP1_ErrorMessage ;
      private ExcelDocumentI AV10ExcelDocument ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
   }

   public class relojwwexport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GE2( IGxContext context ,
                                             short AV49Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV50Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV51Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV53Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV55Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV57Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV59Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV60Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado ,
                                             short AV16OrderedBy ,
                                             bool AV17OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [Reloj_Estado], [Reloj_Puerto], [Reloj_IP], [Reloj_Dsc], [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! (0==AV49Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV49Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV50Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV50Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV51Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV53Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV55Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV57Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV59Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV59Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV60Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV60Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV16OrderedBy == 1 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [RelojID]";
         }
         else if ( ( AV16OrderedBy == 1 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RelojID] DESC";
         }
         else if ( ( AV16OrderedBy == 2 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Nom]";
         }
         else if ( ( AV16OrderedBy == 2 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Nom] DESC";
         }
         else if ( ( AV16OrderedBy == 3 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Dsc]";
         }
         else if ( ( AV16OrderedBy == 3 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Dsc] DESC";
         }
         else if ( ( AV16OrderedBy == 4 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_IP]";
         }
         else if ( ( AV16OrderedBy == 4 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_IP] DESC";
         }
         else if ( ( AV16OrderedBy == 5 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Puerto]";
         }
         else if ( ( AV16OrderedBy == 5 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Puerto] DESC";
         }
         else if ( ( AV16OrderedBy == 6 ) && ! AV17OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Estado]";
         }
         else if ( ( AV16OrderedBy == 6 ) && ( AV17OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Estado] DESC";
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
                     return conditional_P00GE2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00GE2;
          prmP00GE2 = new Object[] {
          new ParDef("@AV49Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV50Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV51Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV52Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV53Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV54Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV56Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV57Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV58Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV59Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV60Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GE2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
