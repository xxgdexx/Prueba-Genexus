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
   public class unidadmedidawwexportreport : GXWebProcedure
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

      public unidadmedidawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public unidadmedidawwexportreport( IGxContext context )
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
         unidadmedidawwexportreport objunidadmedidawwexportreport;
         objunidadmedidawwexportreport = new unidadmedidawwexportreport();
         objunidadmedidawwexportreport.context.SetSubmitInitialConfig(context);
         objunidadmedidawwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objunidadmedidawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((unidadmedidawwexportreport)stateInfo).executePrivate();
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
            AV56Title = "Lista de Unidad Medida";
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
            H2R0( true, 0) ;
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
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "UNIDSC") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15UniDsc1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15UniDsc1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV17UniDsc = AV15UniDsc1;
                  H2R0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterUniDscDescription, "")), 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17UniDsc, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "UNIDSC") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21UniDsc2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21UniDsc2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV17UniDsc = AV21UniDsc2;
                     H2R0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterUniDscDescription, "")), 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17UniDsc, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "UNIDSC") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25UniDsc3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25UniDsc3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterUniDscDescription = StringUtil.Format( "%1 (%2)", "Unidad de Medida", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV17UniDsc = AV25UniDsc3;
                        H2R0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterUniDscDescription, "")), 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17UniDsc, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFUniCod) && (0==AV32TFUniCod_To) ) )
         {
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFUniCod), "ZZZZZ9")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFUniCod_To_Description = StringUtil.Format( "%1 (%2)", "Codigo", "Hasta", "", "", "", "", "", "", "");
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFUniCod_To_Description, "")), 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFUniCod_To), "ZZZZZ9")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFUniDsc_Sel)) )
         {
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Unidad Medida", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFUniDsc_Sel, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFUniDsc)) )
            {
               H2R0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Unidad Medida", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFUniDsc, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFUniAbr_Sel)) )
         {
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFUniAbr_Sel, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFUniAbr)) )
            {
               H2R0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Abreviatura", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFUniAbr, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFUniSunat_Sel)) )
         {
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFUniSunat_Sel, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFUniSunat)) )
            {
               H2R0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Codigo Sunat", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFUniSunat, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV41TFUniSts_Sels.FromJSonString(AV39TFUniSts_SelsJson, null);
         if ( ! ( AV41TFUniSts_Sels.Count == 0 ) )
         {
            AV45i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV41TFUniSts_Sels.Count )
            {
               AV42TFUniSts_Sel = (short)(AV41TFUniSts_Sels.GetNumeric(AV62GXV1));
               if ( AV45i == 1 )
               {
                  AV40TFUniSts_SelDscs = "";
               }
               else
               {
                  AV40TFUniSts_SelDscs += ", ";
               }
               if ( AV42TFUniSts_Sel == 1 )
               {
                  AV44FilterTFUniSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV42TFUniSts_Sel == 0 )
               {
                  AV44FilterTFUniSts_SelValueDescription = "INACTIVO";
               }
               AV40TFUniSts_SelDscs += AV44FilterTFUniSts_SelValueDescription;
               AV45i = (long)(AV45i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
            H2R0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 234, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFUniSts_SelDscs, "")), 234, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H2R0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H2R0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Codigo", 30, Gx_line+10, 135, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Unidad Medida", 139, Gx_line+10, 351, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Abreviatura", 355, Gx_line+10, 461, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Codigo Sunat", 465, Gx_line+10, 571, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 575, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV66Configuracion_unidadmedidawwds_3_unidsc1 = AV15UniDsc1;
         AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV70Configuracion_unidadmedidawwds_7_unidsc2 = AV21UniDsc2;
         AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV74Configuracion_unidadmedidawwds_11_unidsc3 = AV25UniDsc3;
         AV75Configuracion_unidadmedidawwds_12_tfunicod = AV31TFUniCod;
         AV76Configuracion_unidadmedidawwds_13_tfunicod_to = AV32TFUniCod_To;
         AV77Configuracion_unidadmedidawwds_14_tfunidsc = AV33TFUniDsc;
         AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel = AV34TFUniDsc_Sel;
         AV79Configuracion_unidadmedidawwds_16_tfuniabr = AV35TFUniAbr;
         AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel = AV36TFUniAbr_Sel;
         AV81Configuracion_unidadmedidawwds_18_tfunisunat = AV37TFUniSunat;
         AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel = AV38TFUniSunat_Sel;
         AV83Configuracion_unidadmedidawwds_20_tfunists_sels = AV41TFUniSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1999UniSts ,
                                              AV83Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                              AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                              AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                              AV66Configuracion_unidadmedidawwds_3_unidsc1 ,
                                              AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                              AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                              AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                              AV70Configuracion_unidadmedidawwds_7_unidsc2 ,
                                              AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                              AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                              AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                              AV74Configuracion_unidadmedidawwds_11_unidsc3 ,
                                              AV75Configuracion_unidadmedidawwds_12_tfunicod ,
                                              AV76Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                              AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                              AV77Configuracion_unidadmedidawwds_14_tfunidsc ,
                                              AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                              AV79Configuracion_unidadmedidawwds_16_tfuniabr ,
                                              AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                              AV81Configuracion_unidadmedidawwds_18_tfunisunat ,
                                              AV83Configuracion_unidadmedidawwds_20_tfunists_sels.Count ,
                                              A1998UniDsc ,
                                              A49UniCod ,
                                              A1997UniAbr ,
                                              A2000UniSunat ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV66Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV66Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV70Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV70Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV74Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV74Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV77Configuracion_unidadmedidawwds_14_tfunidsc = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_unidadmedidawwds_14_tfunidsc), 100, "%");
         lV79Configuracion_unidadmedidawwds_16_tfuniabr = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_unidadmedidawwds_16_tfuniabr), 5, "%");
         lV81Configuracion_unidadmedidawwds_18_tfunisunat = StringUtil.Concat( StringUtil.RTrim( AV81Configuracion_unidadmedidawwds_18_tfunisunat), "%", "");
         /* Using cursor P002R2 */
         pr_default.execute(0, new Object[] {lV66Configuracion_unidadmedidawwds_3_unidsc1, lV66Configuracion_unidadmedidawwds_3_unidsc1, lV70Configuracion_unidadmedidawwds_7_unidsc2, lV70Configuracion_unidadmedidawwds_7_unidsc2, lV74Configuracion_unidadmedidawwds_11_unidsc3, lV74Configuracion_unidadmedidawwds_11_unidsc3, AV75Configuracion_unidadmedidawwds_12_tfunicod, AV76Configuracion_unidadmedidawwds_13_tfunicod_to, lV77Configuracion_unidadmedidawwds_14_tfunidsc, AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel, lV79Configuracion_unidadmedidawwds_16_tfuniabr, AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel, lV81Configuracion_unidadmedidawwds_18_tfunisunat, AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1999UniSts = P002R2_A1999UniSts[0];
            A2000UniSunat = P002R2_A2000UniSunat[0];
            A1997UniAbr = P002R2_A1997UniAbr[0];
            A49UniCod = P002R2_A49UniCod[0];
            A1998UniDsc = P002R2_A1998UniDsc[0];
            if ( A1999UniSts == 1 )
            {
               AV12UniStsDescription = "ACTIVO";
            }
            else if ( A1999UniSts == 0 )
            {
               AV12UniStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H2R0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9")), 30, Gx_line+10, 135, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1998UniDsc, "")), 139, Gx_line+10, 351, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), 355, Gx_line+10, 461, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2000UniSunat, "")), 465, Gx_line+10, 571, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12UniStsDescription, "")), 575, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.UnidadMedidaWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV84GXV2 = 1;
         while ( AV84GXV2 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV84GXV2));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV31TFUniCod = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV32TFUniCod_To = (int)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNIDSC") == 0 )
            {
               AV33TFUniDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNIDSC_SEL") == 0 )
            {
               AV34TFUniDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNIABR") == 0 )
            {
               AV35TFUniAbr = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNIABR_SEL") == 0 )
            {
               AV36TFUniAbr_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNISUNAT") == 0 )
            {
               AV37TFUniSunat = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNISUNAT_SEL") == 0 )
            {
               AV38TFUniSunat_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUNISTS_SEL") == 0 )
            {
               AV39TFUniSts_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV41TFUniSts_Sels.FromJSonString(AV39TFUniSts_SelsJson, null);
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

      protected void H2R0( bool bFoot ,
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
                  AV54PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV51DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV49AppName = "DVelop Software Solutions";
               AV55Phone = "+1 550 8923";
               AV53Mail = "info@mail.com";
               AV57Website = "http://www.web.com";
               AV46AddressLine1 = "French Boulevard 2859";
               AV47AddressLine2 = "Downtown";
               AV48AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV56Title = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15UniDsc1 = "";
         AV16FilterUniDscDescription = "";
         AV17UniDsc = "";
         AV19DynamicFiltersSelector2 = "";
         AV21UniDsc2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25UniDsc3 = "";
         AV43TFUniCod_To_Description = "";
         AV34TFUniDsc_Sel = "";
         AV33TFUniDsc = "";
         AV36TFUniAbr_Sel = "";
         AV35TFUniAbr = "";
         AV38TFUniSunat_Sel = "";
         AV37TFUniSunat = "";
         AV41TFUniSts_Sels = new GxSimpleCollection<short>();
         AV39TFUniSts_SelsJson = "";
         AV40TFUniSts_SelDscs = "";
         AV44FilterTFUniSts_SelValueDescription = "";
         AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = "";
         AV66Configuracion_unidadmedidawwds_3_unidsc1 = "";
         AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = "";
         AV70Configuracion_unidadmedidawwds_7_unidsc2 = "";
         AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = "";
         AV74Configuracion_unidadmedidawwds_11_unidsc3 = "";
         AV77Configuracion_unidadmedidawwds_14_tfunidsc = "";
         AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel = "";
         AV79Configuracion_unidadmedidawwds_16_tfuniabr = "";
         AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel = "";
         AV81Configuracion_unidadmedidawwds_18_tfunisunat = "";
         AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel = "";
         AV83Configuracion_unidadmedidawwds_20_tfunists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV66Configuracion_unidadmedidawwds_3_unidsc1 = "";
         lV70Configuracion_unidadmedidawwds_7_unidsc2 = "";
         lV74Configuracion_unidadmedidawwds_11_unidsc3 = "";
         lV77Configuracion_unidadmedidawwds_14_tfunidsc = "";
         lV79Configuracion_unidadmedidawwds_16_tfuniabr = "";
         lV81Configuracion_unidadmedidawwds_18_tfunisunat = "";
         A1998UniDsc = "";
         A1997UniAbr = "";
         A2000UniSunat = "";
         P002R2_A1999UniSts = new short[1] ;
         P002R2_A2000UniSunat = new string[] {""} ;
         P002R2_A1997UniAbr = new string[] {""} ;
         P002R2_A49UniCod = new int[1] ;
         P002R2_A1998UniDsc = new string[] {""} ;
         AV12UniStsDescription = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV54PageInfo = "";
         AV51DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV49AppName = "";
         AV55Phone = "";
         AV53Mail = "";
         AV57Website = "";
         AV46AddressLine1 = "";
         AV47AddressLine2 = "";
         AV48AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.unidadmedidawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P002R2_A1999UniSts, P002R2_A2000UniSunat, P002R2_A1997UniAbr, P002R2_A49UniCod, P002R2_A1998UniDsc
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
      private short AV42TFUniSts_Sel ;
      private short AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ;
      private short AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ;
      private short AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ;
      private short A1999UniSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV31TFUniCod ;
      private int AV32TFUniCod_To ;
      private int AV62GXV1 ;
      private int AV75Configuracion_unidadmedidawwds_12_tfunicod ;
      private int AV76Configuracion_unidadmedidawwds_13_tfunicod_to ;
      private int AV83Configuracion_unidadmedidawwds_20_tfunists_sels_Count ;
      private int A49UniCod ;
      private int AV84GXV2 ;
      private long AV45i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV15UniDsc1 ;
      private string AV17UniDsc ;
      private string AV21UniDsc2 ;
      private string AV25UniDsc3 ;
      private string AV34TFUniDsc_Sel ;
      private string AV33TFUniDsc ;
      private string AV36TFUniAbr_Sel ;
      private string AV35TFUniAbr ;
      private string AV66Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string AV70Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string AV74Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string AV77Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel ;
      private string AV79Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel ;
      private string scmdbuf ;
      private string lV66Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string lV70Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string lV74Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string lV77Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string lV79Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string A1998UniDsc ;
      private string A1997UniAbr ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ;
      private bool AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV39TFUniSts_SelsJson ;
      private string AV56Title ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterUniDscDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV43TFUniCod_To_Description ;
      private string AV38TFUniSunat_Sel ;
      private string AV37TFUniSunat ;
      private string AV40TFUniSts_SelDscs ;
      private string AV44FilterTFUniSts_SelValueDescription ;
      private string AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ;
      private string AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ;
      private string AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ;
      private string AV81Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel ;
      private string lV81Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string A2000UniSunat ;
      private string AV12UniStsDescription ;
      private string AV54PageInfo ;
      private string AV51DateInfo ;
      private string AV49AppName ;
      private string AV55Phone ;
      private string AV53Mail ;
      private string AV57Website ;
      private string AV46AddressLine1 ;
      private string AV47AddressLine2 ;
      private string AV48AddressLine3 ;
      private GxSimpleCollection<short> AV41TFUniSts_Sels ;
      private GxSimpleCollection<short> AV83Configuracion_unidadmedidawwds_20_tfunists_sels ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P002R2_A1999UniSts ;
      private string[] P002R2_A2000UniSunat ;
      private string[] P002R2_A1997UniAbr ;
      private int[] P002R2_A49UniCod ;
      private string[] P002R2_A1998UniDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
   }

   public class unidadmedidawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002R2( IGxContext context ,
                                             short A1999UniSts ,
                                             GxSimpleCollection<short> AV83Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                             string AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                             short AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                             string AV66Configuracion_unidadmedidawwds_3_unidsc1 ,
                                             bool AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                             string AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                             short AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                             string AV70Configuracion_unidadmedidawwds_7_unidsc2 ,
                                             bool AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                             string AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                             short AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                             string AV74Configuracion_unidadmedidawwds_11_unidsc3 ,
                                             int AV75Configuracion_unidadmedidawwds_12_tfunicod ,
                                             int AV76Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                             string AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                             string AV77Configuracion_unidadmedidawwds_14_tfunidsc ,
                                             string AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                             string AV79Configuracion_unidadmedidawwds_16_tfuniabr ,
                                             string AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                             string AV81Configuracion_unidadmedidawwds_18_tfunisunat ,
                                             int AV83Configuracion_unidadmedidawwds_20_tfunists_sels_Count ,
                                             string A1998UniDsc ,
                                             int A49UniCod ,
                                             string A1997UniAbr ,
                                             string A2000UniSunat ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UniSts], [UniSunat], [UniAbr], [UniCod], [UniDsc] FROM [CUNIDADMEDIDA]";
         if ( ( StringUtil.StrCmp(AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV66Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV65Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV66Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV70Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV67Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV69Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV70Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV74Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV71Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV73Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV74Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV75Configuracion_unidadmedidawwds_12_tfunicod) )
         {
            AddWhere(sWhereString, "([UniCod] >= @AV75Configuracion_unidadmedidawwds_12_tfunicod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV76Configuracion_unidadmedidawwds_13_tfunicod_to) )
         {
            AddWhere(sWhereString, "([UniCod] <= @AV76Configuracion_unidadmedidawwds_13_tfunicod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_unidadmedidawwds_14_tfunidsc)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV77Configuracion_unidadmedidawwds_14_tfunidsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel)) )
         {
            AddWhere(sWhereString, "([UniDsc] = @AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_unidadmedidawwds_16_tfuniabr)) ) )
         {
            AddWhere(sWhereString, "([UniAbr] like @lV79Configuracion_unidadmedidawwds_16_tfuniabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel)) )
         {
            AddWhere(sWhereString, "([UniAbr] = @AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_unidadmedidawwds_18_tfunisunat)) ) )
         {
            AddWhere(sWhereString, "([UniSunat] like @lV81Configuracion_unidadmedidawwds_18_tfunisunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel)) )
         {
            AddWhere(sWhereString, "([UniSunat] = @AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV83Configuracion_unidadmedidawwds_20_tfunists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Configuracion_unidadmedidawwds_20_tfunists_sels, "[UniSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniAbr]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniAbr] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniSunat]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniSunat] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [UniSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [UniSts] DESC";
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
                     return conditional_P002R2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP002R2;
          prmP002R2 = new Object[] {
          new ParDef("@lV66Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_unidadmedidawwds_12_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV76Configuracion_unidadmedidawwds_13_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Configuracion_unidadmedidawwds_14_tfunidsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Configuracion_unidadmedidawwds_15_tfunidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_unidadmedidawwds_16_tfuniabr",GXType.NChar,5,0) ,
          new ParDef("@AV80Configuracion_unidadmedidawwds_17_tfuniabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV81Configuracion_unidadmedidawwds_18_tfunisunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV82Configuracion_unidadmedidawwds_19_tfunisunat_sel",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002R2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
