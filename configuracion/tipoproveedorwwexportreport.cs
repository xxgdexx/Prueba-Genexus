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
   public class tipoproveedorwwexportreport : GXWebProcedure
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

      public tipoproveedorwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoproveedorwwexportreport( IGxContext context )
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
         tipoproveedorwwexportreport objtipoproveedorwwexportreport;
         objtipoproveedorwwexportreport = new tipoproveedorwwexportreport();
         objtipoproveedorwwexportreport.context.SetSubmitInitialConfig(context);
         objtipoproveedorwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoproveedorwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoproveedorwwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Tipo Proveedor";
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
            H480( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "TPRVDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15TprvDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15TprvDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17TprvDsc = AV15TprvDsc1;
                  H480( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTprvDscDescription, "")), 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TprvDsc, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "TPRVDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21TprvDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21TprvDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17TprvDsc = AV21TprvDsc2;
                     H480( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTprvDscDescription, "")), 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TprvDsc, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "TPRVDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25TprvDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25TprvDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterTprvDscDescription = StringUtil.Format( "%1 (%2)", "Tipo de Proveedor", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17TprvDsc = AV25TprvDsc3;
                        H480( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterTprvDscDescription, "")), 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17TprvDsc, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFTprvCod) && (0==AV32TFTprvCod_To) ) )
         {
            H480( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFTprvCod), "ZZZZZ9")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFTprvCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H480( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFTprvCod_To_Description, "")), 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFTprvCod_To), "ZZZZZ9")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTprvDsc_Sel)) )
         {
            H480( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo de Proveedor", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTprvDsc_Sel, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTprvDsc)) )
            {
               H480( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo de Proveedor", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTprvDsc, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFTprvAbr_Sel)) )
         {
            H480( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFTprvAbr_Sel, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTprvAbr)) )
            {
               H480( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTprvAbr, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFTprvSts_Sels.FromJSonString(AV37TFTprvSts_SelsJson, null);
         if ( ! ( AV39TFTprvSts_Sels.Count == 0 ) )
         {
            AV43i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV39TFTprvSts_Sels.Count )
            {
               AV40TFTprvSts_Sel = (short)(AV39TFTprvSts_Sels.GetNumeric(AV60GXV1));
               if ( AV43i == 1 )
               {
                  AV38TFTprvSts_SelDscs = "";
               }
               else
               {
                  AV38TFTprvSts_SelDscs += ", ";
               }
               if ( AV40TFTprvSts_Sel == 1 )
               {
                  AV42FilterTFTprvSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV40TFTprvSts_Sel == 0 )
               {
                  AV42FilterTFTprvSts_SelValueDescription = "INACTIVO";
               }
               AV38TFTprvSts_SelDscs += AV42FilterTFTprvSts_SelValueDescription;
               AV43i = (long)(AV43i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
            H480( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 235, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFTprvSts_SelDscs, "")), 235, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H480( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H480( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo de Proveedor", 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV64Configuracion_tipoproveedorwwds_3_tprvdsc1 = AV15TprvDsc1;
         AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV68Configuracion_tipoproveedorwwds_7_tprvdsc2 = AV21TprvDsc2;
         AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV72Configuracion_tipoproveedorwwds_11_tprvdsc3 = AV25TprvDsc3;
         AV73Configuracion_tipoproveedorwwds_12_tftprvcod = AV31TFTprvCod;
         AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to = AV32TFTprvCod_To;
         AV75Configuracion_tipoproveedorwwds_14_tftprvdsc = AV33TFTprvDsc;
         AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel = AV34TFTprvDsc_Sel;
         AV77Configuracion_tipoproveedorwwds_16_tftprvabr = AV35TFTprvAbr;
         AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel = AV36TFTprvAbr_Sel;
         AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels = AV39TFTprvSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1942TprvSts ,
                                              AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                              AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                              AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                              AV64Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                              AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                              AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                              AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                              AV68Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                              AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                              AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                              AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                              AV72Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                              AV73Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                              AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                              AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                              AV75Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                              AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                              AV77Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                              AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels.Count ,
                                              A1941TprvDsc ,
                                              A298TprvCod ,
                                              A1940TprvAbr ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV64Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV68Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV68Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV72Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV72Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV75Configuracion_tipoproveedorwwds_14_tftprvdsc = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipoproveedorwwds_14_tftprvdsc), 100, "%");
         lV77Configuracion_tipoproveedorwwds_16_tftprvabr = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_tipoproveedorwwds_16_tftprvabr), 5, "%");
         /* Using cursor P00482 */
         pr_default.execute(0, new Object[] {lV64Configuracion_tipoproveedorwwds_3_tprvdsc1, lV64Configuracion_tipoproveedorwwds_3_tprvdsc1, lV68Configuracion_tipoproveedorwwds_7_tprvdsc2, lV68Configuracion_tipoproveedorwwds_7_tprvdsc2, lV72Configuracion_tipoproveedorwwds_11_tprvdsc3, lV72Configuracion_tipoproveedorwwds_11_tprvdsc3, AV73Configuracion_tipoproveedorwwds_12_tftprvcod, AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to, lV75Configuracion_tipoproveedorwwds_14_tftprvdsc, AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel, lV77Configuracion_tipoproveedorwwds_16_tftprvabr, AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1942TprvSts = P00482_A1942TprvSts[0];
            A1940TprvAbr = P00482_A1940TprvAbr[0];
            A298TprvCod = P00482_A298TprvCod[0];
            A1941TprvDsc = P00482_A1941TprvDsc[0];
            if ( A1942TprvSts == 1 )
            {
               AV12TprvStsDescription = "ACTIVO";
            }
            else if ( A1942TprvSts == 0 )
            {
               AV12TprvStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H480( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1941TprvDsc, "")), 158, Gx_line+10, 406, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1940TprvAbr, "")), 410, Gx_line+10, 534, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12TprvStsDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.TipoProveedorWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoProveedorWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.TipoProveedorWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV80GXV2 = 1;
         while ( AV80GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV80GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVCOD") == 0 )
            {
               AV31TFTprvCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFTprvCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVDSC") == 0 )
            {
               AV33TFTprvDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVDSC_SEL") == 0 )
            {
               AV34TFTprvDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVABR") == 0 )
            {
               AV35TFTprvAbr = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVABR_SEL") == 0 )
            {
               AV36TFTprvAbr_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFTPRVSTS_SEL") == 0 )
            {
               AV37TFTprvSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV39TFTprvSts_Sels.FromJSonString(AV37TFTprvSts_SelsJson, null);
            }
            AV80GXV2 = (int)(AV80GXV2+1);
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

      protected void H480( bool bFoot ,
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
         AV15TprvDsc1 = "";
         AV16FilterTprvDscDescription = "";
         AV17TprvDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21TprvDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25TprvDsc3 = "";
         AV41TFTprvCod_To_Description = "";
         AV34TFTprvDsc_Sel = "";
         AV33TFTprvDsc = "";
         AV36TFTprvAbr_Sel = "";
         AV35TFTprvAbr = "";
         AV39TFTprvSts_Sels = new GxSimpleCollection<short>();
         AV37TFTprvSts_SelsJson = "";
         AV38TFTprvSts_SelDscs = "";
         AV42FilterTFTprvSts_SelValueDescription = "";
         AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 = "";
         AV64Configuracion_tipoproveedorwwds_3_tprvdsc1 = "";
         AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 = "";
         AV68Configuracion_tipoproveedorwwds_7_tprvdsc2 = "";
         AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 = "";
         AV72Configuracion_tipoproveedorwwds_11_tprvdsc3 = "";
         AV75Configuracion_tipoproveedorwwds_14_tftprvdsc = "";
         AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel = "";
         AV77Configuracion_tipoproveedorwwds_16_tftprvabr = "";
         AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel = "";
         AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV64Configuracion_tipoproveedorwwds_3_tprvdsc1 = "";
         lV68Configuracion_tipoproveedorwwds_7_tprvdsc2 = "";
         lV72Configuracion_tipoproveedorwwds_11_tprvdsc3 = "";
         lV75Configuracion_tipoproveedorwwds_14_tftprvdsc = "";
         lV77Configuracion_tipoproveedorwwds_16_tftprvabr = "";
         A1941TprvDsc = "";
         A1940TprvAbr = "";
         P00482_A1942TprvSts = new short[1] ;
         P00482_A1940TprvAbr = new string[] {""} ;
         P00482_A298TprvCod = new int[1] ;
         P00482_A1941TprvDsc = new string[] {""} ;
         AV12TprvStsDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoproveedorwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00482_A1942TprvSts, P00482_A1940TprvAbr, P00482_A298TprvCod, P00482_A1941TprvDsc
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
      private short AV40TFTprvSts_Sel ;
      private short AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ;
      private short AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ;
      private short AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ;
      private short A1942TprvSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFTprvCod ;
      private int AV32TFTprvCod_To ;
      private int AV60GXV1 ;
      private int AV73Configuracion_tipoproveedorwwds_12_tftprvcod ;
      private int AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to ;
      private int AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count ;
      private int A298TprvCod ;
      private int AV80GXV2 ;
      private long AV43i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15TprvDsc1 ;
      private string AV17TprvDsc ;
      private string AV21TprvDsc2 ;
      private string AV25TprvDsc3 ;
      private string AV34TFTprvDsc_Sel ;
      private string AV33TFTprvDsc ;
      private string AV36TFTprvAbr_Sel ;
      private string AV35TFTprvAbr ;
      private string AV64Configuracion_tipoproveedorwwds_3_tprvdsc1 ;
      private string AV68Configuracion_tipoproveedorwwds_7_tprvdsc2 ;
      private string AV72Configuracion_tipoproveedorwwds_11_tprvdsc3 ;
      private string AV75Configuracion_tipoproveedorwwds_14_tftprvdsc ;
      private string AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ;
      private string AV77Configuracion_tipoproveedorwwds_16_tftprvabr ;
      private string AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel ;
      private string scmdbuf ;
      private string lV64Configuracion_tipoproveedorwwds_3_tprvdsc1 ;
      private string lV68Configuracion_tipoproveedorwwds_7_tprvdsc2 ;
      private string lV72Configuracion_tipoproveedorwwds_11_tprvdsc3 ;
      private string lV75Configuracion_tipoproveedorwwds_14_tftprvdsc ;
      private string lV77Configuracion_tipoproveedorwwds_16_tftprvabr ;
      private string A1941TprvDsc ;
      private string A1940TprvAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ;
      private bool AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV37TFTprvSts_SelsJson ;
      private string AV54Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterTprvDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV41TFTprvCod_To_Description ;
      private string AV38TFTprvSts_SelDscs ;
      private string AV42FilterTFTprvSts_SelValueDescription ;
      private string AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ;
      private string AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ;
      private string AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ;
      private string AV12TprvStsDescription ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private GxSimpleCollection<short> AV39TFTprvSts_Sels ;
      private GxSimpleCollection<short> AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00482_A1942TprvSts ;
      private string[] P00482_A1940TprvAbr ;
      private int[] P00482_A298TprvCod ;
      private string[] P00482_A1941TprvDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class tipoproveedorwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00482( IGxContext context ,
                                             short A1942TprvSts ,
                                             GxSimpleCollection<short> AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                             string AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                             short AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                             string AV64Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                             bool AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                             string AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                             short AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                             string AV68Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                             bool AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                             string AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                             short AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                             string AV72Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                             int AV73Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                             int AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                             string AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                             string AV75Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                             string AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                             string AV77Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                             int AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count ,
                                             string A1941TprvDsc ,
                                             int A298TprvCod ,
                                             string A1940TprvAbr ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TprvSts], [TprvAbr], [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR]";
         if ( ( StringUtil.StrCmp(AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV64Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV63Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV64Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV68Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV65Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV67Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV68Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV72Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV69Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV71Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV72Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV73Configuracion_tipoproveedorwwds_12_tftprvcod) )
         {
            AddWhere(sWhereString, "([TprvCod] >= @AV73Configuracion_tipoproveedorwwds_12_tftprvcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to) )
         {
            AddWhere(sWhereString, "([TprvCod] <= @AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipoproveedorwwds_14_tftprvdsc)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV75Configuracion_tipoproveedorwwds_14_tftprvdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) )
         {
            AddWhere(sWhereString, "([TprvDsc] = @AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_tipoproveedorwwds_16_tftprvabr)) ) )
         {
            AddWhere(sWhereString, "([TprvAbr] like @lV77Configuracion_tipoproveedorwwds_16_tftprvabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) )
         {
            AddWhere(sWhereString, "([TprvAbr] = @AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_tipoproveedorwwds_18_tftprvsts_sels, "[TprvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TprvCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TprvCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TprvDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TprvDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TprvAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TprvAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [TprvSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [TprvSts] DESC";
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
                     return conditional_P00482(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (bool)dynConstraints[24] );
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
          Object[] prmP00482;
          prmP00482 = new Object[] {
          new ParDef("@lV64Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_tipoproveedorwwds_12_tftprvcod",GXType.Int32,6,0) ,
          new ParDef("@AV74Configuracion_tipoproveedorwwds_13_tftprvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV75Configuracion_tipoproveedorwwds_14_tftprvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV76Configuracion_tipoproveedorwwds_15_tftprvdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV77Configuracion_tipoproveedorwwds_16_tftprvabr",GXType.NChar,5,0) ,
          new ParDef("@AV78Configuracion_tipoproveedorwwds_17_tftprvabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00482", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00482,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 5);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
