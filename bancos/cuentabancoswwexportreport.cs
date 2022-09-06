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
namespace GeneXus.Programs.bancos {
   public class cuentabancoswwexportreport : GXWebProcedure
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

      public cuentabancoswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancoswwexportreport( IGxContext context )
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
         cuentabancoswwexportreport objcuentabancoswwexportreport;
         objcuentabancoswwexportreport = new cuentabancoswwexportreport();
         objcuentabancoswwexportreport.context.SetSubmitInitialConfig(context);
         objcuentabancoswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcuentabancoswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cuentabancoswwexportreport)stateInfo).executePrivate();
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
            AV69Title = "Lista de Cuenta Bancos";
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
            H5E0( true, 0) ;
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
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV72BanDsc1 = AV30GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72BanDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV74BanDsc = AV72BanDsc1;
                  H5E0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "MONCOD") == 0 )
            {
               AV75MonCod1 = (int)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
               if ( ! (0==AV75MonCod1) )
               {
                  AV76MonCod = AV75MonCod1;
                  H5E0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV76MonCod), "ZZZZZ9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV20DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV21DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV22DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV77BanDsc2 = AV30GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77BanDsc2)) )
                  {
                     if ( AV22DynamicFiltersOperator2 == 0 )
                     {
                        AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV22DynamicFiltersOperator2 == 1 )
                     {
                        AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV74BanDsc = AV77BanDsc2;
                     H5E0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV21DynamicFiltersSelector2, "MONCOD") == 0 )
               {
                  AV78MonCod2 = (int)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
                  if ( ! (0==AV78MonCod2) )
                  {
                     AV76MonCod = AV78MonCod2;
                     H5E0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV76MonCod), "ZZZZZ9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV25DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV79BanDsc3 = AV30GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79BanDsc3)) )
                     {
                        if ( AV27DynamicFiltersOperator3 == 0 )
                        {
                           AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV27DynamicFiltersOperator3 == 1 )
                        {
                           AV73FilterBanDscDescription = StringUtil.Format( "%1 (%2)", "Banco", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV74BanDsc = AV79BanDsc3;
                        H5E0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73FilterBanDscDescription, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74BanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "MONCOD") == 0 )
                  {
                     AV80MonCod3 = (int)(NumberUtil.Val( AV30GridStateDynamicFilter.gxTpr_Value, "."));
                     if ( ! (0==AV80MonCod3) )
                     {
                        AV76MonCod = AV80MonCod3;
                        H5E0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV76MonCod), "ZZZZZ9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82TFBanDsc_Sel)) )
         {
            H5E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Banco", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82TFBanDsc_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81TFBanDsc)) )
            {
               H5E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Banco", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81TFBanDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFCBCod_Sel)) )
         {
            H5E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("N° de Cuenta", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCBCod_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFCBCod)) )
            {
               H5E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("N° de Cuenta", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCBCod, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFMonDsc_Sel)) )
         {
            H5E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFMonDsc_Sel, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFMonDsc)) )
            {
               H5E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Moneda", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFMonDsc, "")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV43TFCBSts) && (0==AV44TFCBSts_To) ) )
         {
            H5E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV43TFCBSts), "9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV55TFCBSts_To_Description = StringUtil.Format( "%1 (%2)", "Estado", "Hasta", "", "", "", "", "", "", "");
            H5E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFCBSts_To_Description, "")), 25, Gx_line+0, 176, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV44TFCBSts_To), "9")), 176, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 0, 64, 128, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5E0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 64, 128, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Banco", 30, Gx_line+10, 242, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("N° de Cuenta", 246, Gx_line+10, 458, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Moneda", 462, Gx_line+10, 676, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 680, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV98Bancos_cuentabancoswwds_3_bandsc1 = AV72BanDsc1;
         AV99Bancos_cuentabancoswwds_4_moncod1 = AV75MonCod1;
         AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV20DynamicFiltersEnabled2;
         AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV21DynamicFiltersSelector2;
         AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV22DynamicFiltersOperator2;
         AV103Bancos_cuentabancoswwds_8_bandsc2 = AV77BanDsc2;
         AV104Bancos_cuentabancoswwds_9_moncod2 = AV78MonCod2;
         AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV108Bancos_cuentabancoswwds_13_bandsc3 = AV79BanDsc3;
         AV109Bancos_cuentabancoswwds_14_moncod3 = AV80MonCod3;
         AV110Bancos_cuentabancoswwds_15_tfbandsc = AV81TFBanDsc;
         AV111Bancos_cuentabancoswwds_16_tfbandsc_sel = AV82TFBanDsc_Sel;
         AV112Bancos_cuentabancoswwds_17_tfcbcod = AV37TFCBCod;
         AV113Bancos_cuentabancoswwds_18_tfcbcod_sel = AV38TFCBCod_Sel;
         AV114Bancos_cuentabancoswwds_19_tfmondsc = AV83TFMonDsc;
         AV115Bancos_cuentabancoswwds_20_tfmondsc_sel = AV84TFMonDsc_Sel;
         AV116Bancos_cuentabancoswwds_21_tfcbsts = AV43TFCBSts;
         AV117Bancos_cuentabancoswwds_22_tfcbsts_to = AV44TFCBSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV98Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV99Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV103Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV104Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV108Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV109Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV111Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV110Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV113Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV112Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV115Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV114Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV116Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV117Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV98Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV98Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV98Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV98Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV103Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV103Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV103Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV103Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV108Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV108Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV108Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV108Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV110Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV110Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV112Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV112Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV114Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV114Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor P005E2 */
         pr_default.execute(0, new Object[] {lV98Bancos_cuentabancoswwds_3_bandsc1, lV98Bancos_cuentabancoswwds_3_bandsc1, AV99Bancos_cuentabancoswwds_4_moncod1, lV103Bancos_cuentabancoswwds_8_bandsc2, lV103Bancos_cuentabancoswwds_8_bandsc2, AV104Bancos_cuentabancoswwds_9_moncod2, lV108Bancos_cuentabancoswwds_13_bandsc3, lV108Bancos_cuentabancoswwds_13_bandsc3, AV109Bancos_cuentabancoswwds_14_moncod3, lV110Bancos_cuentabancoswwds_15_tfbandsc, AV111Bancos_cuentabancoswwds_16_tfbandsc_sel, lV112Bancos_cuentabancoswwds_17_tfcbcod, AV113Bancos_cuentabancoswwds_18_tfcbcod_sel, lV114Bancos_cuentabancoswwds_19_tfmondsc, AV115Bancos_cuentabancoswwds_20_tfmondsc_sel, AV116Bancos_cuentabancoswwds_21_tfcbsts, AV117Bancos_cuentabancoswwds_22_tfcbsts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A504CBSts = P005E2_A504CBSts[0];
            A1234MonDsc = P005E2_A1234MonDsc[0];
            A377CBCod = P005E2_A377CBCod[0];
            A180MonCod = P005E2_A180MonCod[0];
            A482BanDsc = P005E2_A482BanDsc[0];
            A372BanCod = P005E2_A372BanCod[0];
            A1234MonDsc = P005E2_A1234MonDsc[0];
            A482BanDsc = P005E2_A482BanDsc[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5E0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A482BanDsc, "")), 30, Gx_line+10, 242, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A377CBCod, "")), 246, Gx_line+10, 458, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), 462, Gx_line+10, 676, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A504CBSts), "9")), 680, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV31Session.Get("Bancos.CuentaBancosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV33GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV33GridState.gxTpr_Ordereddsc;
         AV118GXV1 = 1;
         while ( AV118GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV118GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV81TFBanDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV82TFBanDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCBCOD") == 0 )
            {
               AV37TFCBCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCBCOD_SEL") == 0 )
            {
               AV38TFCBCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV83TFMonDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV84TFMonDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFCBSTS") == 0 )
            {
               AV43TFCBSts = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV44TFCBSts_To = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV118GXV1 = (int)(AV118GXV1+1);
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

      protected void H5E0( bool bFoot ,
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
                  AV67PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV64DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV62AppName = "DVelop Software Solutions";
               AV68Phone = "+1 550 8923";
               AV66Mail = "info@mail.com";
               AV70Website = "http://www.web.com";
               AV59AddressLine1 = "French Boulevard 2859";
               AV60AddressLine2 = "Downtown";
               AV61AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 0, 64, 128, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV69Title = "";
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV72BanDsc1 = "";
         AV73FilterBanDscDescription = "";
         AV74BanDsc = "";
         AV21DynamicFiltersSelector2 = "";
         AV77BanDsc2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV79BanDsc3 = "";
         AV82TFBanDsc_Sel = "";
         AV81TFBanDsc = "";
         AV38TFCBCod_Sel = "";
         AV37TFCBCod = "";
         AV84TFMonDsc_Sel = "";
         AV83TFMonDsc = "";
         AV55TFCBSts_To_Description = "";
         AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = "";
         AV98Bancos_cuentabancoswwds_3_bandsc1 = "";
         AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = "";
         AV103Bancos_cuentabancoswwds_8_bandsc2 = "";
         AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = "";
         AV108Bancos_cuentabancoswwds_13_bandsc3 = "";
         AV110Bancos_cuentabancoswwds_15_tfbandsc = "";
         AV111Bancos_cuentabancoswwds_16_tfbandsc_sel = "";
         AV112Bancos_cuentabancoswwds_17_tfcbcod = "";
         AV113Bancos_cuentabancoswwds_18_tfcbcod_sel = "";
         AV114Bancos_cuentabancoswwds_19_tfmondsc = "";
         AV115Bancos_cuentabancoswwds_20_tfmondsc_sel = "";
         scmdbuf = "";
         lV98Bancos_cuentabancoswwds_3_bandsc1 = "";
         lV103Bancos_cuentabancoswwds_8_bandsc2 = "";
         lV108Bancos_cuentabancoswwds_13_bandsc3 = "";
         lV110Bancos_cuentabancoswwds_15_tfbandsc = "";
         lV112Bancos_cuentabancoswwds_17_tfcbcod = "";
         lV114Bancos_cuentabancoswwds_19_tfmondsc = "";
         A482BanDsc = "";
         A377CBCod = "";
         A1234MonDsc = "";
         P005E2_A504CBSts = new short[1] ;
         P005E2_A1234MonDsc = new string[] {""} ;
         P005E2_A377CBCod = new string[] {""} ;
         P005E2_A180MonCod = new int[1] ;
         P005E2_A482BanDsc = new string[] {""} ;
         P005E2_A372BanCod = new int[1] ;
         AV31Session = context.GetSession();
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV67PageInfo = "";
         AV64DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV62AppName = "";
         AV68Phone = "";
         AV66Mail = "";
         AV70Website = "";
         AV59AddressLine1 = "";
         AV60AddressLine2 = "";
         AV61AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancoswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005E2_A504CBSts, P005E2_A1234MonDsc, P005E2_A377CBCod, P005E2_A180MonCod, P005E2_A482BanDsc, P005E2_A372BanCod
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
      private short AV13DynamicFiltersOperator1 ;
      private short AV22DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV43TFCBSts ;
      private short AV44TFCBSts_To ;
      private short AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ;
      private short AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ;
      private short AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ;
      private short AV116Bancos_cuentabancoswwds_21_tfcbsts ;
      private short AV117Bancos_cuentabancoswwds_22_tfcbsts_to ;
      private short A504CBSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV75MonCod1 ;
      private int AV76MonCod ;
      private int AV78MonCod2 ;
      private int AV80MonCod3 ;
      private int AV99Bancos_cuentabancoswwds_4_moncod1 ;
      private int AV104Bancos_cuentabancoswwds_9_moncod2 ;
      private int AV109Bancos_cuentabancoswwds_14_moncod3 ;
      private int A180MonCod ;
      private int A372BanCod ;
      private int AV118GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV72BanDsc1 ;
      private string AV74BanDsc ;
      private string AV77BanDsc2 ;
      private string AV79BanDsc3 ;
      private string AV82TFBanDsc_Sel ;
      private string AV81TFBanDsc ;
      private string AV38TFCBCod_Sel ;
      private string AV37TFCBCod ;
      private string AV84TFMonDsc_Sel ;
      private string AV83TFMonDsc ;
      private string AV98Bancos_cuentabancoswwds_3_bandsc1 ;
      private string AV103Bancos_cuentabancoswwds_8_bandsc2 ;
      private string AV108Bancos_cuentabancoswwds_13_bandsc3 ;
      private string AV110Bancos_cuentabancoswwds_15_tfbandsc ;
      private string AV111Bancos_cuentabancoswwds_16_tfbandsc_sel ;
      private string AV112Bancos_cuentabancoswwds_17_tfcbcod ;
      private string AV113Bancos_cuentabancoswwds_18_tfcbcod_sel ;
      private string AV114Bancos_cuentabancoswwds_19_tfmondsc ;
      private string AV115Bancos_cuentabancoswwds_20_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV98Bancos_cuentabancoswwds_3_bandsc1 ;
      private string lV103Bancos_cuentabancoswwds_8_bandsc2 ;
      private string lV108Bancos_cuentabancoswwds_13_bandsc3 ;
      private string lV110Bancos_cuentabancoswwds_15_tfbandsc ;
      private string lV112Bancos_cuentabancoswwds_17_tfcbcod ;
      private string lV114Bancos_cuentabancoswwds_19_tfmondsc ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV20DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV69Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV73FilterBanDscDescription ;
      private string AV21DynamicFiltersSelector2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV55TFCBSts_To_Description ;
      private string AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ;
      private string AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ;
      private string AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ;
      private string AV67PageInfo ;
      private string AV64DateInfo ;
      private string AV62AppName ;
      private string AV68Phone ;
      private string AV66Mail ;
      private string AV70Website ;
      private string AV59AddressLine1 ;
      private string AV60AddressLine2 ;
      private string AV61AddressLine3 ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P005E2_A504CBSts ;
      private string[] P005E2_A1234MonDsc ;
      private string[] P005E2_A377CBCod ;
      private int[] P005E2_A180MonCod ;
      private string[] P005E2_A482BanDsc ;
      private int[] P005E2_A372BanCod ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
   }

   public class cuentabancoswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005E2( IGxContext context ,
                                             string AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV98Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV99Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV103Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV104Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV108Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV109Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV111Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV110Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV113Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV112Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV115Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV114Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV116Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV117Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CBSts], T2.[MonDsc], T1.[CBCod], T1.[MonCod], T3.[BanDsc], T1.[BanCod] FROM (([TSCUENTABANCO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[MonCod]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = T1.[BanCod])";
         if ( ( StringUtil.StrCmp(AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV98Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV97Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV98Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV96Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV99Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV99Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV103Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV102Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV103Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV100Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV101Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV104Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV104Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV108Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV107Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like '%' + @lV108Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV105Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV106Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV109Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV109Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] like @lV110Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[BanDsc] = @AV111Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV113Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV112Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV113Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV115Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV114Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV115Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV116Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV116Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (0==AV117Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV117Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV10OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.[BanCod], T1.[CBCod]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[BanDsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[BanDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBCod]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBCod] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[MonDsc]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[MonDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CBSts]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CBSts] DESC";
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
                     return conditional_P005E2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] );
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
          Object[] prmP005E2;
          prmP005E2 = new Object[] {
          new ParDef("@lV98Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV98Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV99Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV103Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV103Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV104Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV108Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV108Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV109Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV110Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV111Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV112Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV113Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV114Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV115Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV116Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV117Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                return;
       }
    }

 }

}
