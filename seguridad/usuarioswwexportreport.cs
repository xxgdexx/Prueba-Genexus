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
namespace GeneXus.Programs.seguridad {
   public class usuarioswwexportreport : GXWebProcedure
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

      public usuarioswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuarioswwexportreport( IGxContext context )
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
         usuarioswwexportreport objusuarioswwexportreport;
         objusuarioswwexportreport = new usuarioswwexportreport();
         objusuarioswwexportreport.context.SetSubmitInitialConfig(context);
         objusuarioswwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuarioswwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuarioswwexportreport)stateInfo).executePrivate();
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
            AV102Title = "Lista de Usuarios";
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
            H280( true, 0) ;
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
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV25GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "USUVENDDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV116UsuVendDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116UsuVendDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV118UsuVendDsc = AV116UsuVendDsc1;
                  H280( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterUsuVendDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118UsuVendDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "USUTIEDSC") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV119UsuTieDsc1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV119UsuTieDsc1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV121UsuTieDsc = AV119UsuTieDsc1;
                  H280( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV120FilterUsuTieDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV121UsuTieDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "USUNOM") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV25GridStateDynamicFilter.gxTpr_Operator;
               AV105UsuNom1 = AV25GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105UsuNom1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV107UsuNom = AV105UsuNom1;
                  H280( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106FilterUsuNomDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107UsuNom, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV17DynamicFiltersEnabled2 = true;
               AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV18DynamicFiltersSelector2 = AV25GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "USUVENDDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV122UsuVendDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122UsuVendDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV118UsuVendDsc = AV122UsuVendDsc2;
                     H280( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterUsuVendDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118UsuVendDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "USUTIEDSC") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV123UsuTieDsc2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123UsuTieDsc2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV121UsuTieDsc = AV123UsuTieDsc2;
                     H280( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV120FilterUsuTieDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV121UsuTieDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector2, "USUNOM") == 0 )
               {
                  AV19DynamicFiltersOperator2 = AV25GridStateDynamicFilter.gxTpr_Operator;
                  AV108UsuNom2 = AV25GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108UsuNom2)) )
                  {
                     if ( AV19DynamicFiltersOperator2 == 0 )
                     {
                        AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV19DynamicFiltersOperator2 == 1 )
                     {
                        AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV107UsuNom = AV108UsuNom2;
                     H280( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106FilterUsuNomDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107UsuNom, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV21DynamicFiltersEnabled3 = true;
                  AV25GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV22DynamicFiltersSelector3 = AV25GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "USUVENDDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV124UsuVendDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124UsuVendDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV117FilterUsuVendDscDescription = StringUtil.Format( "%1 (%2)", "Vendedor", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV118UsuVendDsc = AV124UsuVendDsc3;
                        H280( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117FilterUsuVendDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118UsuVendDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "USUTIEDSC") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV125UsuTieDsc3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125UsuTieDsc3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV120FilterUsuTieDscDescription = StringUtil.Format( "%1 (%2)", "Local", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV121UsuTieDsc = AV125UsuTieDsc3;
                        H280( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV120FilterUsuTieDscDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV121UsuTieDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV22DynamicFiltersSelector3, "USUNOM") == 0 )
                  {
                     AV23DynamicFiltersOperator3 = AV25GridStateDynamicFilter.gxTpr_Operator;
                     AV109UsuNom3 = AV25GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109UsuNom3)) )
                     {
                        if ( AV23DynamicFiltersOperator3 == 0 )
                        {
                           AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV23DynamicFiltersOperator3 == 1 )
                        {
                           AV106FilterUsuNomDescription = StringUtil.Format( "%1 (%2)", "Nombre de Usuario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV107UsuNom = AV109UsuNom3;
                        H280( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106FilterUsuNomDescription, "")), 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107UsuNom, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFUsuCod_Sel)) )
         {
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFUsuCod_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30TFUsuCod)) )
            {
               H280( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuario", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV30TFUsuCod, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFUsuNom_Sel)) )
         {
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nombre Usuario", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFUsuNom_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFUsuNom)) )
            {
               H280( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre Usuario", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFUsuNom, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFUsuEMAIL_Sel)) )
         {
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-Mail", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFUsuEMAIL_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFUsuEMAIL)) )
            {
               H280( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-Mail", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFUsuEMAIL, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV112TFUsuSts_Sels.FromJSonString(AV110TFUsuSts_SelsJson, null);
         if ( ! ( AV112TFUsuSts_Sels.Count == 0 ) )
         {
            AV115i = 1;
            AV134GXV1 = 1;
            while ( AV134GXV1 <= AV112TFUsuSts_Sels.Count )
            {
               AV113TFUsuSts_Sel = (short)(AV112TFUsuSts_Sels.GetNumeric(AV134GXV1));
               if ( AV115i == 1 )
               {
                  AV111TFUsuSts_SelDscs = "";
               }
               else
               {
                  AV111TFUsuSts_SelDscs += ", ";
               }
               if ( AV113TFUsuSts_Sel == 1 )
               {
                  AV114FilterTFUsuSts_SelValueDescription = "ACTIVO";
               }
               else if ( AV113TFUsuSts_Sel == 0 )
               {
                  AV114FilterTFUsuSts_SelValueDescription = "INACTIVO";
               }
               AV111TFUsuSts_SelDscs += AV114FilterTFUsuSts_SelValueDescription;
               AV115i = (long)(AV115i+1);
               AV134GXV1 = (int)(AV134GXV1+1);
            }
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Estado", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV111TFUsuSts_SelDscs, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127TFUsuVendDsc_Sel)) )
         {
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Vendedor", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV127TFUsuVendDsc_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126TFUsuVendDsc)) )
            {
               H280( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Vendedor", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV126TFUsuVendDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129TFUsuTieDsc_Sel)) )
         {
            H280( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Local", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129TFUsuTieDsc_Sel, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128TFUsuTieDsc)) )
            {
               H280( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Local", 25, Gx_line+0, 238, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV128TFUsuTieDsc, "")), 238, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H280( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H280( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Usuario", 30, Gx_line+10, 97, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nombre Usuario", 101, Gx_line+10, 235, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-Mail", 239, Gx_line+10, 373, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Estado", 377, Gx_line+10, 511, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Vendedor", 515, Gx_line+10, 649, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Local", 653, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV138Seguridad_usuarioswwds_3_usuvenddsc1 = AV116UsuVendDsc1;
         AV139Seguridad_usuarioswwds_4_usutiedsc1 = AV119UsuTieDsc1;
         AV140Seguridad_usuarioswwds_5_usunom1 = AV105UsuNom1;
         AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV17DynamicFiltersEnabled2;
         AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV18DynamicFiltersSelector2;
         AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV19DynamicFiltersOperator2;
         AV144Seguridad_usuarioswwds_9_usuvenddsc2 = AV122UsuVendDsc2;
         AV145Seguridad_usuarioswwds_10_usutiedsc2 = AV123UsuTieDsc2;
         AV146Seguridad_usuarioswwds_11_usunom2 = AV108UsuNom2;
         AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV21DynamicFiltersEnabled3;
         AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV22DynamicFiltersSelector3;
         AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV23DynamicFiltersOperator3;
         AV150Seguridad_usuarioswwds_15_usuvenddsc3 = AV124UsuVendDsc3;
         AV151Seguridad_usuarioswwds_16_usutiedsc3 = AV125UsuTieDsc3;
         AV152Seguridad_usuarioswwds_17_usunom3 = AV109UsuNom3;
         AV153Seguridad_usuarioswwds_18_tfusucod = AV30TFUsuCod;
         AV154Seguridad_usuarioswwds_19_tfusucod_sel = AV31TFUsuCod_Sel;
         AV155Seguridad_usuarioswwds_20_tfusunom = AV34TFUsuNom;
         AV156Seguridad_usuarioswwds_21_tfusunom_sel = AV35TFUsuNom_Sel;
         AV157Seguridad_usuarioswwds_22_tfusuemail = AV66TFUsuEMAIL;
         AV158Seguridad_usuarioswwds_23_tfusuemail_sel = AV67TFUsuEMAIL_Sel;
         AV159Seguridad_usuarioswwds_24_tfususts_sels = AV112TFUsuSts_Sels;
         AV160Seguridad_usuarioswwds_25_tfusuvenddsc = AV126TFUsuVendDsc;
         AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV127TFUsuVendDsc_Sel;
         AV162Seguridad_usuarioswwds_27_tfusutiedsc = AV128TFUsuTieDsc;
         AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV129TFUsuTieDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV159Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV138Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV139Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV140Seguridad_usuarioswwds_5_usunom1 ,
                                              AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV144Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV145Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV146Seguridad_usuarioswwds_11_usunom2 ,
                                              AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV150Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV151Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV152Seguridad_usuarioswwds_17_usunom3 ,
                                              AV154Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV153Seguridad_usuarioswwds_18_tfusucod ,
                                              AV156Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV155Seguridad_usuarioswwds_20_tfusunom ,
                                              AV158Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV157Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV159Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV160Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV162Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV138Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV138Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV138Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV138Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV139Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV139Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV139Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV139Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV140Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV140Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV140Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV140Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV144Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV144Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV144Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV144Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV145Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV145Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV145Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV145Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV146Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV146Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV146Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV146Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV150Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV150Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV150Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV150Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV151Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV151Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV151Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV151Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV152Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV152Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV152Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV152Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV153Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV153Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV155Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV155Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV157Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV157Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV160Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV160Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV162Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV162Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P00282 */
         pr_default.execute(0, new Object[] {lV138Seguridad_usuarioswwds_3_usuvenddsc1, lV138Seguridad_usuarioswwds_3_usuvenddsc1, lV139Seguridad_usuarioswwds_4_usutiedsc1, lV139Seguridad_usuarioswwds_4_usutiedsc1, lV140Seguridad_usuarioswwds_5_usunom1, lV140Seguridad_usuarioswwds_5_usunom1, lV144Seguridad_usuarioswwds_9_usuvenddsc2, lV144Seguridad_usuarioswwds_9_usuvenddsc2, lV145Seguridad_usuarioswwds_10_usutiedsc2, lV145Seguridad_usuarioswwds_10_usutiedsc2, lV146Seguridad_usuarioswwds_11_usunom2, lV146Seguridad_usuarioswwds_11_usunom2, lV150Seguridad_usuarioswwds_15_usuvenddsc3, lV150Seguridad_usuarioswwds_15_usuvenddsc3, lV151Seguridad_usuarioswwds_16_usutiedsc3, lV151Seguridad_usuarioswwds_16_usutiedsc3, lV152Seguridad_usuarioswwds_17_usunom3, lV152Seguridad_usuarioswwds_17_usunom3, lV153Seguridad_usuarioswwds_18_tfusucod, AV154Seguridad_usuarioswwds_19_tfusucod_sel, lV155Seguridad_usuarioswwds_20_tfusunom, AV156Seguridad_usuarioswwds_21_tfusunom_sel, lV157Seguridad_usuarioswwds_22_tfusuemail, AV158Seguridad_usuarioswwds_23_tfusuemail_sel, lV160Seguridad_usuarioswwds_25_tfusuvenddsc, AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV162Seguridad_usuarioswwds_27_tfusutiedsc, AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2041UsuVend = P00282_A2041UsuVend[0];
            A2040UsuTieCod = P00282_A2040UsuTieCod[0];
            A2039UsuSts = P00282_A2039UsuSts[0];
            A2014UsuEMAIL = P00282_A2014UsuEMAIL[0];
            A348UsuCod = P00282_A348UsuCod[0];
            A2019UsuNom = P00282_A2019UsuNom[0];
            A2096UsuTieDsc = P00282_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P00282_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P00282_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P00282_A2096UsuTieDsc[0];
            if ( A2039UsuSts == 1 )
            {
               AV104UsuStsDescription = "ACTIVO";
            }
            else if ( A2039UsuSts == 0 )
            {
               AV104UsuStsDescription = "INACTIVO";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H280( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), 30, Gx_line+10, 97, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")), 101, Gx_line+10, 235, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2014UsuEMAIL, "")), 239, Gx_line+10, 373, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104UsuStsDescription, "")), 377, Gx_line+10, 511, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2097UsuVendDsc, "")), 515, Gx_line+10, 649, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2096UsuTieDsc, "")), 653, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Seguridad.UsuariosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.UsuariosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Seguridad.UsuariosWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV164GXV2 = 1;
         while ( AV164GXV2 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV164GXV2));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUCOD") == 0 )
            {
               AV30TFUsuCod = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUCOD_SEL") == 0 )
            {
               AV31TFUsuCod_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUNOM") == 0 )
            {
               AV34TFUsuNom = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUNOM_SEL") == 0 )
            {
               AV35TFUsuNom_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL") == 0 )
            {
               AV66TFUsuEMAIL = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL_SEL") == 0 )
            {
               AV67TFUsuEMAIL_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUSTS_SEL") == 0 )
            {
               AV110TFUsuSts_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV112TFUsuSts_Sels.FromJSonString(AV110TFUsuSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC") == 0 )
            {
               AV126TFUsuVendDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC_SEL") == 0 )
            {
               AV127TFUsuVendDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC") == 0 )
            {
               AV128TFUsuTieDsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC_SEL") == 0 )
            {
               AV129TFUsuTieDsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV164GXV2 = (int)(AV164GXV2+1);
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

      protected void H280( bool bFoot ,
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
                  AV100PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV97DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV95AppName = "DVelop Software Solutions";
               AV101Phone = "+1 550 8923";
               AV99Mail = "info@mail.com";
               AV103Website = "http://www.web.com";
               AV92AddressLine1 = "French Boulevard 2859";
               AV93AddressLine2 = "Downtown";
               AV94AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV102Title = "";
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV25GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV116UsuVendDsc1 = "";
         AV117FilterUsuVendDscDescription = "";
         AV118UsuVendDsc = "";
         AV119UsuTieDsc1 = "";
         AV120FilterUsuTieDscDescription = "";
         AV121UsuTieDsc = "";
         AV105UsuNom1 = "";
         AV106FilterUsuNomDescription = "";
         AV107UsuNom = "";
         AV18DynamicFiltersSelector2 = "";
         AV122UsuVendDsc2 = "";
         AV123UsuTieDsc2 = "";
         AV108UsuNom2 = "";
         AV22DynamicFiltersSelector3 = "";
         AV124UsuVendDsc3 = "";
         AV125UsuTieDsc3 = "";
         AV109UsuNom3 = "";
         AV31TFUsuCod_Sel = "";
         AV30TFUsuCod = "";
         AV35TFUsuNom_Sel = "";
         AV34TFUsuNom = "";
         AV67TFUsuEMAIL_Sel = "";
         AV66TFUsuEMAIL = "";
         AV112TFUsuSts_Sels = new GxSimpleCollection<short>();
         AV110TFUsuSts_SelsJson = "";
         AV111TFUsuSts_SelDscs = "";
         AV114FilterTFUsuSts_SelValueDescription = "";
         AV127TFUsuVendDsc_Sel = "";
         AV126TFUsuVendDsc = "";
         AV129TFUsuTieDsc_Sel = "";
         AV128TFUsuTieDsc = "";
         AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1 = "";
         AV138Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         AV139Seguridad_usuarioswwds_4_usutiedsc1 = "";
         AV140Seguridad_usuarioswwds_5_usunom1 = "";
         AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2 = "";
         AV144Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         AV145Seguridad_usuarioswwds_10_usutiedsc2 = "";
         AV146Seguridad_usuarioswwds_11_usunom2 = "";
         AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3 = "";
         AV150Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         AV151Seguridad_usuarioswwds_16_usutiedsc3 = "";
         AV152Seguridad_usuarioswwds_17_usunom3 = "";
         AV153Seguridad_usuarioswwds_18_tfusucod = "";
         AV154Seguridad_usuarioswwds_19_tfusucod_sel = "";
         AV155Seguridad_usuarioswwds_20_tfusunom = "";
         AV156Seguridad_usuarioswwds_21_tfusunom_sel = "";
         AV157Seguridad_usuarioswwds_22_tfusuemail = "";
         AV158Seguridad_usuarioswwds_23_tfusuemail_sel = "";
         AV159Seguridad_usuarioswwds_24_tfususts_sels = new GxSimpleCollection<short>();
         AV160Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel = "";
         AV162Seguridad_usuarioswwds_27_tfusutiedsc = "";
         AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel = "";
         scmdbuf = "";
         lV138Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         lV139Seguridad_usuarioswwds_4_usutiedsc1 = "";
         lV140Seguridad_usuarioswwds_5_usunom1 = "";
         lV144Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         lV145Seguridad_usuarioswwds_10_usutiedsc2 = "";
         lV146Seguridad_usuarioswwds_11_usunom2 = "";
         lV150Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         lV151Seguridad_usuarioswwds_16_usutiedsc3 = "";
         lV152Seguridad_usuarioswwds_17_usunom3 = "";
         lV153Seguridad_usuarioswwds_18_tfusucod = "";
         lV155Seguridad_usuarioswwds_20_tfusunom = "";
         lV157Seguridad_usuarioswwds_22_tfusuemail = "";
         lV160Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         lV162Seguridad_usuarioswwds_27_tfusutiedsc = "";
         A2097UsuVendDsc = "";
         A2096UsuTieDsc = "";
         A2019UsuNom = "";
         A348UsuCod = "";
         A2014UsuEMAIL = "";
         P00282_A2041UsuVend = new int[1] ;
         P00282_A2040UsuTieCod = new int[1] ;
         P00282_A2039UsuSts = new short[1] ;
         P00282_A2014UsuEMAIL = new string[] {""} ;
         P00282_A348UsuCod = new string[] {""} ;
         P00282_A2019UsuNom = new string[] {""} ;
         P00282_A2096UsuTieDsc = new string[] {""} ;
         P00282_A2097UsuVendDsc = new string[] {""} ;
         AV104UsuStsDescription = "";
         AV26Session = context.GetSession();
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV100PageInfo = "";
         AV97DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV95AppName = "";
         AV101Phone = "";
         AV99Mail = "";
         AV103Website = "";
         AV92AddressLine1 = "";
         AV93AddressLine2 = "";
         AV94AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuarioswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00282_A2041UsuVend, P00282_A2040UsuTieCod, P00282_A2039UsuSts, P00282_A2014UsuEMAIL, P00282_A348UsuCod, P00282_A2019UsuNom, P00282_A2096UsuTieDsc, P00282_A2097UsuVendDsc
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
      private short AV19DynamicFiltersOperator2 ;
      private short AV23DynamicFiltersOperator3 ;
      private short AV113TFUsuSts_Sel ;
      private short AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ;
      private short AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ;
      private short AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ;
      private short A2039UsuSts ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV134GXV1 ;
      private int AV159Seguridad_usuarioswwds_24_tfususts_sels_Count ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int AV164GXV2 ;
      private long AV115i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV116UsuVendDsc1 ;
      private string AV118UsuVendDsc ;
      private string AV119UsuTieDsc1 ;
      private string AV121UsuTieDsc ;
      private string AV105UsuNom1 ;
      private string AV107UsuNom ;
      private string AV122UsuVendDsc2 ;
      private string AV123UsuTieDsc2 ;
      private string AV108UsuNom2 ;
      private string AV124UsuVendDsc3 ;
      private string AV125UsuTieDsc3 ;
      private string AV109UsuNom3 ;
      private string AV31TFUsuCod_Sel ;
      private string AV30TFUsuCod ;
      private string AV35TFUsuNom_Sel ;
      private string AV34TFUsuNom ;
      private string AV127TFUsuVendDsc_Sel ;
      private string AV126TFUsuVendDsc ;
      private string AV129TFUsuTieDsc_Sel ;
      private string AV128TFUsuTieDsc ;
      private string AV138Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string AV139Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string AV140Seguridad_usuarioswwds_5_usunom1 ;
      private string AV144Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string AV145Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string AV146Seguridad_usuarioswwds_11_usunom2 ;
      private string AV150Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string AV151Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string AV152Seguridad_usuarioswwds_17_usunom3 ;
      private string AV153Seguridad_usuarioswwds_18_tfusucod ;
      private string AV154Seguridad_usuarioswwds_19_tfusucod_sel ;
      private string AV155Seguridad_usuarioswwds_20_tfusunom ;
      private string AV156Seguridad_usuarioswwds_21_tfusunom_sel ;
      private string AV160Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel ;
      private string AV162Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel ;
      private string scmdbuf ;
      private string lV138Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string lV139Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string lV140Seguridad_usuarioswwds_5_usunom1 ;
      private string lV144Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string lV145Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string lV146Seguridad_usuarioswwds_11_usunom2 ;
      private string lV150Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string lV151Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string lV152Seguridad_usuarioswwds_17_usunom3 ;
      private string lV153Seguridad_usuarioswwds_18_tfusucod ;
      private string lV155Seguridad_usuarioswwds_20_tfusunom ;
      private string lV160Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string lV162Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string A2097UsuVendDsc ;
      private string A2096UsuTieDsc ;
      private string A2019UsuNom ;
      private string A348UsuCod ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV17DynamicFiltersEnabled2 ;
      private bool AV21DynamicFiltersEnabled3 ;
      private bool AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ;
      private bool AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV110TFUsuSts_SelsJson ;
      private string AV102Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV117FilterUsuVendDscDescription ;
      private string AV120FilterUsuTieDscDescription ;
      private string AV106FilterUsuNomDescription ;
      private string AV18DynamicFiltersSelector2 ;
      private string AV22DynamicFiltersSelector3 ;
      private string AV67TFUsuEMAIL_Sel ;
      private string AV66TFUsuEMAIL ;
      private string AV111TFUsuSts_SelDscs ;
      private string AV114FilterTFUsuSts_SelValueDescription ;
      private string AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1 ;
      private string AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2 ;
      private string AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3 ;
      private string AV157Seguridad_usuarioswwds_22_tfusuemail ;
      private string AV158Seguridad_usuarioswwds_23_tfusuemail_sel ;
      private string lV157Seguridad_usuarioswwds_22_tfusuemail ;
      private string A2014UsuEMAIL ;
      private string AV104UsuStsDescription ;
      private string AV100PageInfo ;
      private string AV97DateInfo ;
      private string AV95AppName ;
      private string AV101Phone ;
      private string AV99Mail ;
      private string AV103Website ;
      private string AV92AddressLine1 ;
      private string AV93AddressLine2 ;
      private string AV94AddressLine3 ;
      private GxSimpleCollection<short> AV112TFUsuSts_Sels ;
      private GxSimpleCollection<short> AV159Seguridad_usuarioswwds_24_tfususts_sels ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00282_A2041UsuVend ;
      private int[] P00282_A2040UsuTieCod ;
      private short[] P00282_A2039UsuSts ;
      private string[] P00282_A2014UsuEMAIL ;
      private string[] P00282_A348UsuCod ;
      private string[] P00282_A2019UsuNom ;
      private string[] P00282_A2096UsuTieDsc ;
      private string[] P00282_A2097UsuVendDsc ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV25GridStateDynamicFilter ;
   }

   public class usuarioswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00282( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV159Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV138Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV139Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV140Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV144Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV145Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV146Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV150Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV151Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV152Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV154Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV153Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV156Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV155Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV158Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV157Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV159Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV160Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV162Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T1.[UsuNom], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV138Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV138Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV139Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV139Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV140Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV136Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV137Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV140Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV144Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV144Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV145Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV145Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV146Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV141Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV142Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV143Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV146Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV150Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV150Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV151Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV151Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV152Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV147Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV148Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV149Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV152Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV153Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV154Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV155Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV156Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV157Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV158Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV159Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV159Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV160Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV162Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuCod]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuCod] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuNom]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuNom] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuEMAIL]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuEMAIL] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[UsuSts]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[UsuSts] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.[VenDsc]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.[VenDsc] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[TieDsc]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[TieDsc] DESC";
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
                     return conditional_P00282(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (short)dynConstraints[35] , (bool)dynConstraints[36] );
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
          Object[] prmP00282;
          prmP00282 = new Object[] {
          new ParDef("@lV138Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV138Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV139Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV139Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV140Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV140Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV144Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV144Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV145Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV145Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV146Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV146Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV150Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV150Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV151Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV151Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV152Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV152Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV153Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV154Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV155Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV156Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV157Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV158Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV160Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV161Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV162Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV163Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00282", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00282,100, GxCacheFrequency.OFF ,true,false )
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
