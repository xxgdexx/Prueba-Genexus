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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.configuracion {
   public class tipopedidowwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public tipopedidowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipopedidowwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         tipopedidowwexportreport objtipopedidowwexportreport;
         objtipopedidowwexportreport = new tipopedidowwexportreport();
         objtipopedidowwexportreport.context.SetSubmitInitialConfig(context);
         objtipopedidowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipopedidowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipopedidowwexportreport)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            AV54Title = "Lista de Tipos de Pedidos";
            /* Execute user subroutine: 'PRINTFILTERS' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTDATA' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'PRINTFOOTER' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H4T0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TPEDDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TPedDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TPedDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17TPedDsc = AV15TPedDsc1;
                  H4T0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTPedDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TPedDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TPEDDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TPedDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TPedDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17TPedDsc = AV21TPedDsc2;
                     H4T0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTPedDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TPedDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TPEDDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TPedDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TPedDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTPedDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Pedido", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17TPedDsc = AV25TPedDsc3;
                        H4T0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTPedDscDescription, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TPedDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFTPedCod) && (0==AV32TFTPedCod_To) ) )
         {
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTPedCod), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFTPedCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTPedCod_To_Description, "")), 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFTPedCod_To), "ZZZZZ9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTPedDsc_Sel)) )
         {
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Pedido", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTPedDsc_Sel, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTPedDsc)) )
            {
               H4T0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Pedido", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTPedDsc, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! (0==AV36TFTPedGuia_Sel) )
         {
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Guia", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFTPedGuia_Sel), "9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV35TFTPedFac_Sel) )
         {
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Afecta Factura", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFTPedFac_Sel), "9")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV39TFTPedSts_Sels.FromJSonString(AV37TFTPedSts_SelsJson, null);
         if ( ! ( AV39TFTPedSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV39TFTPedSts_Sels.Count )
            {
               AV40TFTPedSts_Sel = (short)(AV39TFTPedSts_Sels.GetNumeric(AV64GXV1));
               if ( AV43i == 1 )
               {
                  AV38TFTPedSts_SelDscs = "";
               }
               else
               {
                  AV38TFTPedSts_SelDscs += ", ";
               }
               if ( AV40TFTPedSts_Sel == 1 )
               {
                  AV42FilterTFTPedSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFTPedSts_Sel == 0 )
               {
                  AV42FilterTFTPedSts_SelValueDescription = "INACTIVO";
               }
               AV38TFTPedSts_SelDscs += AV42FilterTFTPedSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H4T0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 218, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTPedSts_SelDscs, "")), 218, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4T0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4T0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Pedido", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Guia", 355, Gx_line+10, 461, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Afecta Factura", 465, Gx_line+10, 571, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 575, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV68Configuracion_tipopedidowwds_3_tpeddsc1 = AV15TPedDsc1;
         AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV72Configuracion_tipopedidowwds_7_tpeddsc2 = AV21TPedDsc2;
         AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV76Configuracion_tipopedidowwds_11_tpeddsc3 = AV25TPedDsc3;
         AV77Configuracion_tipopedidowwds_12_tftpedcod = AV31TFTPedCod;
         AV78Configuracion_tipopedidowwds_13_tftpedcod_to = AV32TFTPedCod_To;
         AV79Configuracion_tipopedidowwds_14_tftpeddsc = AV33TFTPedDsc;
         AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel = AV34TFTPedDsc_Sel;
         AV81Configuracion_tipopedidowwds_16_tftpedguia_sel = AV36TFTPedGuia_Sel;
         AV82Configuracion_tipopedidowwds_17_tftpedfac_sel = AV35TFTPedFac_Sel;
         AV83Configuracion_tipopedidowwds_18_tftpedsts_sels = AV39TFTPedSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1936TPedSts ,
                                              AV83Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                              AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                              AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                              AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                              AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                              AV72Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                              AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                              AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                              AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                              AV76Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                              AV77Configuracion_tipopedidowwds_12_tftpedcod ,
                                              AV78Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                              AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                              AV79Configuracion_tipopedidowwds_14_tftpeddsc ,
                                              AV81Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                              AV82Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                              AV83Configuracion_tipopedidowwds_18_tftpedsts_sels.Count ,
                                              A1931TPedDsc ,
                                              A212TPedCod ,
                                              A1933TPedGuia ,
                                              A1932TPedFac ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV68Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV72Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV72Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV76Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV76Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV79Configuracion_tipopedidowwds_14_tftpeddsc = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_tipopedidowwds_14_tftpeddsc), 100, "%");
         /* Using cursor P004T2 */
         pr_default.execute(0, new Object[] {lV68Configuracion_tipopedidowwds_3_tpeddsc1, lV68Configuracion_tipopedidowwds_3_tpeddsc1, lV72Configuracion_tipopedidowwds_7_tpeddsc2, lV72Configuracion_tipopedidowwds_7_tpeddsc2, lV76Configuracion_tipopedidowwds_11_tpeddsc3, lV76Configuracion_tipopedidowwds_11_tpeddsc3, AV77Configuracion_tipopedidowwds_12_tftpedcod, AV78Configuracion_tipopedidowwds_13_tftpedcod_to, lV79Configuracion_tipopedidowwds_14_tftpeddsc, AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1936TPedSts = P004T2_A1936TPedSts[0];
            A1932TPedFac = P004T2_A1932TPedFac[0];
            A1933TPedGuia = P004T2_A1933TPedGuia[0];
            A212TPedCod = P004T2_A212TPedCod[0];
            A1931TPedDsc = P004T2_A1931TPedDsc[0];
            if ( A1936TPedSts == 1 )
            {
               AV12TPedStsDescription = "ACTIVO";
            }
            else if ( A1936TPedSts == 0 )
            {
               AV12TPedStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4T0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1931TPedDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1933TPedGuia), "9")), 355, Gx_line+10, 461, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1932TPedFac), "9")), 465, Gx_line+10, 571, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TPedStsDescription, "")), 575, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
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

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.TipoPedidoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDCOD") == 0 )
            {
               AV31TFTPedCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFTPedCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDDSC") == 0 )
            {
               AV33TFTPedDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDDSC_SEL") == 0 )
            {
               AV34TFTPedDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDGUIA_SEL") == 0 )
            {
               AV36TFTPedGuia_Sel = (short)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDFAC_SEL") == 0 )
            {
               AV35TFTPedFac_Sel = (short)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPEDSTS_SEL") == 0 )
            {
               AV37TFTPedSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFTPedSts_Sels.FromJSonString(AV37TFTPedSts_SelsJson, null);
            }
            AV84GXV2 = (int)(AV84GXV2+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H4T0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV52PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV49DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV47AppName = "DVelop Software Solutions";
               AV53Phone = "+1 550 8923";
               AV51Mail = "info@mail.com";
               AV55Website = "http://www.web.com";
               AV44AddressLine1 = "French Boulevard 2859";
               AV45AddressLine2 = "Downtown";
               AV46AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
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
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV54Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15TPedDsc1 = "";
         AV16FilterTPedDscDescription = "";
         AV17TPedDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TPedDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TPedDsc3 = "";
         AV41TFTPedCod_To_Description = "";
         AV34TFTPedDsc_Sel = "";
         AV33TFTPedDsc = "";
         AV39TFTPedSts_Sels = new GxSimpleCollection<short>();
         AV37TFTPedSts_SelsJson = "";
         AV38TFTPedSts_SelDscs = "";
         AV42FilterTFTPedSts_SelValueDescription = "";
         AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = "";
         AV68Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = "";
         AV72Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = "";
         AV76Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         AV79Configuracion_tipopedidowwds_14_tftpeddsc = "";
         AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel = "";
         AV83Configuracion_tipopedidowwds_18_tftpedsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV68Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         lV72Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         lV76Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         lV79Configuracion_tipopedidowwds_14_tftpeddsc = "";
         A1931TPedDsc = "";
         P004T2_A1936TPedSts = new short[1] ;
         P004T2_A1932TPedFac = new short[1] ;
         P004T2_A1933TPedGuia = new short[1] ;
         P004T2_A212TPedCod = new int[1] ;
         P004T2_A1931TPedDsc = new string[] {""} ;
         AV12TPedStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52PageInfo = "";
         AV49DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV47AppName = "";
         AV53Phone = "";
         AV51Mail = "";
         AV55Website = "";
         AV44AddressLine1 = "";
         AV45AddressLine2 = "";
         AV46AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedidowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004T2_A1936TPedSts, P004T2_A1932TPedFac, P004T2_A1933TPedGuia, P004T2_A212TPedCod, P004T2_A1931TPedDsc
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV36TFTPedGuia_Sel ;
      private short AV35TFTPedFac_Sel ;
      private short AV40TFTPedSts_Sel ;
      private short AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ;
      private short AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ;
      private short AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ;
      private short AV81Configuracion_tipopedidowwds_16_tftpedguia_sel ;
      private short AV82Configuracion_tipopedidowwds_17_tftpedfac_sel ;
      private short A1936TPedSts ;
      private short A1933TPedGuia ;
      private short A1932TPedFac ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFTPedCod ;
      private int AV32TFTPedCod_To ;
      private int AV64GXV1 ;
      private int AV77Configuracion_tipopedidowwds_12_tftpedcod ;
      private int AV78Configuracion_tipopedidowwds_13_tftpedcod_to ;
      private int AV83Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ;
      private int A212TPedCod ;
      private int AV84GXV2 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15TPedDsc1 ;
      private string AV17TPedDsc ;
      private string AV21TPedDsc2 ;
      private string AV25TPedDsc3 ;
      private string AV34TFTPedDsc_Sel ;
      private string AV33TFTPedDsc ;
      private string AV68Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string AV72Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string AV76Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string AV79Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel ;
      private string scmdbuf ;
      private string lV68Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string lV72Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string lV76Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string lV79Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string A1931TPedDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ;
      private bool AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFTPedSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterTPedDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV41TFTPedCod_To_Description ;
      private string AV38TFTPedSts_SelDscs ;
      private string AV42FilterTFTPedSts_SelValueDescription ;
      private string AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ;
      private string AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ;
      private string AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ;
      private string AV12TPedStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV39TFTPedSts_Sels ;
      private GxSimpleCollection<short> AV83Configuracion_tipopedidowwds_18_tftpedsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P004T2_A1936TPedSts ;
      private short[] P004T2_A1932TPedFac ;
      private short[] P004T2_A1933TPedGuia ;
      private int[] P004T2_A212TPedCod ;
      private string[] P004T2_A1931TPedDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class tipopedidowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004T2( IGxContext context ,
                                             short A1936TPedSts ,
                                             GxSimpleCollection<short> AV83Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                             string AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                             bool AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                             string AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                             short AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                             string AV72Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                             bool AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                             string AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                             short AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                             string AV76Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                             int AV77Configuracion_tipopedidowwds_12_tftpedcod ,
                                             int AV78Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                             string AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                             string AV79Configuracion_tipopedidowwds_14_tftpeddsc ,
                                             short AV81Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                             short AV82Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                             int AV83Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ,
                                             string A1931TPedDsc ,
                                             int A212TPedCod ,
                                             short A1933TPedGuia ,
                                             short A1932TPedFac ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TPedSts], [TPedFac], [TPedGuia], [TPedCod], [TPedDsc] FROM [CTIPPEDIDO]";
         if ( ( StringUtil.StrCmp(AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV68Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV67Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV68Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV72Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV69Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV71Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV72Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV76Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV73Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV74Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV75Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV76Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV77Configuracion_tipopedidowwds_12_tftpedcod) )
         {
            AddWhere(sWhereString, "([TPedCod] >= @AV77Configuracion_tipopedidowwds_12_tftpedcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV78Configuracion_tipopedidowwds_13_tftpedcod_to) )
         {
            AddWhere(sWhereString, "([TPedCod] <= @AV78Configuracion_tipopedidowwds_13_tftpedcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_tipopedidowwds_14_tftpeddsc)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV79Configuracion_tipopedidowwds_14_tftpeddsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel)) )
         {
            AddWhere(sWhereString, "([TPedDsc] = @AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV81Configuracion_tipopedidowwds_16_tftpedguia_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 1)");
         }
         if ( AV81Configuracion_tipopedidowwds_16_tftpedguia_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 0)");
         }
         if ( AV82Configuracion_tipopedidowwds_17_tftpedfac_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedFac] = 1)");
         }
         if ( AV82Configuracion_tipopedidowwds_17_tftpedfac_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedFac] = 0)");
         }
         if ( AV83Configuracion_tipopedidowwds_18_tftpedsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Configuracion_tipopedidowwds_18_tftpedsts_sels, "[TPedSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedGuia]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedGuia] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedFac]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedFac] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TPedSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TPedSts] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004T2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP004T2;
          prmP004T2 = new Object[] {
          new ParDef("@lV68Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@AV77Configuracion_tipopedidowwds_12_tftpedcod",GXType.Int32,6,0) ,
          new ParDef("@AV78Configuracion_tipopedidowwds_13_tftpedcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV79Configuracion_tipopedidowwds_14_tftpeddsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Configuracion_tipopedidowwds_15_tftpeddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004T2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004T2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
