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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_codigoidwwexportreport : GXWebProcedure
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

      public reloj_codigoidwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoidwwexportreport( IGxContext context )
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
         reloj_codigoidwwexportreport objreloj_codigoidwwexportreport;
         objreloj_codigoidwwexportreport = new reloj_codigoidwwexportreport();
         objreloj_codigoidwwexportreport.context.SetSubmitInitialConfig(context);
         objreloj_codigoidwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_codigoidwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_codigoidwwexportreport)stateInfo).executePrivate();
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
            AV72Title = "Lista de Enrolar Codigos del Reloj Con Trabajador";
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
            HH40( true, 0) ;
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
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV12DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV14RHTrabajadorNombres1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV14RHTrabajadorNombres1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV16RHTrabajadorNombres = AV14RHTrabajadorNombres1;
                  HH40( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterRHTrabajadorNombresDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16RHTrabajadorNombres, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV17Reloj_Nombre1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Reloj_Nombre1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV19Reloj_Nombre = AV17Reloj_Nombre1;
                  HH40( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterReloj_NombreDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Reloj_Nombre, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV12DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
            {
               AV13DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV20HorarioDescripcion1 = AV35GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV20HorarioDescripcion1)) )
               {
                  if ( AV13DynamicFiltersOperator1 == 0 )
                  {
                     AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                  }
                  else if ( AV13DynamicFiltersOperator1 == 1 )
                  {
                     AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                  }
                  AV22HorarioDescripcion = AV20HorarioDescripcion1;
                  HH40( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterHorarioDescripcionDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22HorarioDescripcion, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV23DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV24DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV26RHTrabajadorNombres2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RHTrabajadorNombres2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV16RHTrabajadorNombres = AV26RHTrabajadorNombres2;
                     HH40( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterRHTrabajadorNombresDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16RHTrabajadorNombres, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV27Reloj_Nombre2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Reloj_Nombre2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV19Reloj_Nombre = AV27Reloj_Nombre2;
                     HH40( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterReloj_NombreDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Reloj_Nombre, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV24DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
               {
                  AV25DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV28HorarioDescripcion2 = AV35GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV28HorarioDescripcion2)) )
                  {
                     if ( AV25DynamicFiltersOperator2 == 0 )
                     {
                        AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                     }
                     else if ( AV25DynamicFiltersOperator2 == 1 )
                     {
                        AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                     }
                     AV22HorarioDescripcion = AV28HorarioDescripcion2;
                     HH40( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterHorarioDescripcionDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22HorarioDescripcion, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV29DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV30DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV32RHTrabajadorNombres3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32RHTrabajadorNombres3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV15FilterRHTrabajadorNombresDescription = StringUtil.Format( "%1 (%2)", "Nombres", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV16RHTrabajadorNombres = AV32RHTrabajadorNombres3;
                        HH40( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV15FilterRHTrabajadorNombresDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16RHTrabajadorNombres, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV33Reloj_Nombre3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33Reloj_Nombre3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV18FilterReloj_NombreDescription = StringUtil.Format( "%1 (%2)", "Reloj_Nombre", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV19Reloj_Nombre = AV33Reloj_Nombre3;
                        HH40( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18FilterReloj_NombreDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV19Reloj_Nombre, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV30DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
                  {
                     AV31DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV34HorarioDescripcion3 = AV35GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34HorarioDescripcion3)) )
                     {
                        if ( AV31DynamicFiltersOperator3 == 0 )
                        {
                           AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Comienza con", "", "", "", "", "", "", "");
                        }
                        else if ( AV31DynamicFiltersOperator3 == 1 )
                        {
                           AV21FilterHorarioDescripcionDescription = StringUtil.Format( "%1 (%2)", "Horario", "Contiene", "", "", "", "", "", "", "");
                        }
                        AV22HorarioDescripcion = AV34HorarioDescripcion3;
                        HH40( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21FilterHorarioDescripcionDescription, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV22HorarioDescripcion, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFCodigoId_Sel)) )
         {
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajador ID", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFCodigoId_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFCodigoId)) )
            {
               HH40( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Trabajador ID", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFCodigoId, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFReloj_Nombre_Sel)) )
         {
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFReloj_Nombre_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFReloj_Nombre)) )
            {
               HH40( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reloj", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFReloj_Nombre, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV46TFLectura_Ini) && (DateTime.MinValue==AV47TFLectura_Ini_To) ) )
         {
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha Registro", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV46TFLectura_Ini, "99/99/9999 99:99:99"), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV59TFLectura_Ini_To_Description = StringUtil.Format( "%1 (%2)", "Fecha Registro", "Hasta", "", "", "", "", "", "", "");
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFLectura_Ini_To_Description, "")), 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV47TFLectura_Ini_To, "99/99/9999 99:99:99"), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFRHTrabajadorNombres_Sel)) )
         {
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Trabajador", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFRHTrabajadorNombres_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFRHTrabajadorNombres)) )
            {
               HH40( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Trabajador", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFRHTrabajadorNombres, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFHorarioDescripcion_Sel)) )
         {
            HH40( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Horario", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFHorarioDescripcion_Sel, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFHorarioDescripcion)) )
            {
               HH40( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Horario", 25, Gx_line+0, 213, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFHorarioDescripcion, "")), 213, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HH40( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HH40( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Trabajador ID", 30, Gx_line+10, 194, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj", 198, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha Registro", 366, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Trabajador", 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Horario", 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV12DynamicFiltersSelector1;
         AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV13DynamicFiltersOperator1;
         AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV14RHTrabajadorNombres1;
         AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV17Reloj_Nombre1;
         AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV20HorarioDescripcion1;
         AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV23DynamicFiltersEnabled2;
         AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV24DynamicFiltersSelector2;
         AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV25DynamicFiltersOperator2;
         AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV26RHTrabajadorNombres2;
         AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV27Reloj_Nombre2;
         AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV28HorarioDescripcion2;
         AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV29DynamicFiltersEnabled3;
         AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV30DynamicFiltersSelector3;
         AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV31DynamicFiltersOperator3;
         AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV32RHTrabajadorNombres3;
         AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV33Reloj_Nombre3;
         AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV34HorarioDescripcion3;
         AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV40TFCodigoId;
         AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV41TFCodigoId_Sel;
         AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV44TFReloj_Nombre;
         AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV45TFReloj_Nombre_Sel;
         AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV46TFLectura_Ini;
         AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV47TFLectura_Ini_To;
         AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV52TFRHTrabajadorNombres;
         AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV53TFRHTrabajadorNombres_Sel;
         AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV56TFHorarioDescripcion;
         AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV57TFHorarioDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H42 */
         pr_default.execute(0, new Object[] {lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2589RHTrabajadorCodigo = P00H42_A2589RHTrabajadorCodigo[0];
            A2498Reloj_ID = P00H42_A2498Reloj_ID[0];
            A2591HorarioID = P00H42_A2591HorarioID[0];
            A2415Lectura_Ini = P00H42_A2415Lectura_Ini[0];
            A2431CodigoId = P00H42_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H42_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H42_A2592Reloj_Nombre[0];
            A2590RHTrabajadorNombres = P00H42_A2590RHTrabajadorNombres[0];
            A2525TrabApePat = P00H42_A2525TrabApePat[0];
            n2525TrabApePat = P00H42_n2525TrabApePat[0];
            A2526TrabApeMat = P00H42_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H42_n2526TrabApeMat[0];
            A2527TrabNombres = P00H42_A2527TrabNombres[0];
            n2527TrabNombres = P00H42_n2527TrabNombres[0];
            A2525TrabApePat = P00H42_A2525TrabApePat[0];
            n2525TrabApePat = P00H42_n2525TrabApePat[0];
            A2526TrabApeMat = P00H42_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H42_n2526TrabApeMat[0];
            A2527TrabNombres = P00H42_A2527TrabNombres[0];
            n2527TrabNombres = P00H42_n2527TrabNombres[0];
            A2592Reloj_Nombre = P00H42_A2592Reloj_Nombre[0];
            A2593HorarioDescripcion = P00H42_A2593HorarioDescripcion[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HH40( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2431CodigoId, "")), 30, Gx_line+10, 194, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2592Reloj_Nombre, "")), 198, Gx_line+10, 362, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A2415Lectura_Ini, "99/99/9999 99:99:99"), 366, Gx_line+10, 448, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2590RHTrabajadorNombres, "")), 452, Gx_line+10, 617, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2593HorarioDescripcion, "")), 621, Gx_line+10, 787, Gx_line+55, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV36Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV38GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV38GridState.gxTpr_Ordereddsc;
         AV106GXV1 = 1;
         while ( AV106GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV106GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCODIGOID") == 0 )
            {
               AV40TFCodigoId = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFCODIGOID_SEL") == 0 )
            {
               AV41TFCodigoId_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE") == 0 )
            {
               AV44TFReloj_Nombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE_SEL") == 0 )
            {
               AV45TFReloj_Nombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLECTURA_INI") == 0 )
            {
               AV46TFLectura_Ini = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, 2);
               AV47TFLectura_Ini_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES") == 0 )
            {
               AV52TFRHTrabajadorNombres = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES_SEL") == 0 )
            {
               AV53TFRHTrabajadorNombres_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION") == 0 )
            {
               AV56TFHorarioDescripcion = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION_SEL") == 0 )
            {
               AV57TFHorarioDescripcion_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV106GXV1 = (int)(AV106GXV1+1);
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

      protected void HH40( bool bFoot ,
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
                  AV70PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV67DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV65AppName = "DVelop Software Solutions";
               AV71Phone = "+1 550 8923";
               AV69Mail = "info@mail.com";
               AV73Website = "http://www.web.com";
               AV62AddressLine1 = "French Boulevard 2859";
               AV63AddressLine2 = "Downtown";
               AV64AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV72Title = "";
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV12DynamicFiltersSelector1 = "";
         AV14RHTrabajadorNombres1 = "";
         AV15FilterRHTrabajadorNombresDescription = "";
         AV16RHTrabajadorNombres = "";
         AV17Reloj_Nombre1 = "";
         AV18FilterReloj_NombreDescription = "";
         AV19Reloj_Nombre = "";
         AV20HorarioDescripcion1 = "";
         AV21FilterHorarioDescripcionDescription = "";
         AV22HorarioDescripcion = "";
         AV24DynamicFiltersSelector2 = "";
         AV26RHTrabajadorNombres2 = "";
         AV27Reloj_Nombre2 = "";
         AV28HorarioDescripcion2 = "";
         AV30DynamicFiltersSelector3 = "";
         AV32RHTrabajadorNombres3 = "";
         AV33Reloj_Nombre3 = "";
         AV34HorarioDescripcion3 = "";
         AV41TFCodigoId_Sel = "";
         AV40TFCodigoId = "";
         AV45TFReloj_Nombre_Sel = "";
         AV44TFReloj_Nombre = "";
         AV46TFLectura_Ini = (DateTime)(DateTime.MinValue);
         AV47TFLectura_Ini_To = (DateTime)(DateTime.MinValue);
         AV59TFLectura_Ini_To_Description = "";
         AV53TFRHTrabajadorNombres_Sel = "";
         AV52TFRHTrabajadorNombres = "";
         AV57TFHorarioDescripcion_Sel = "";
         AV56TFHorarioDescripcion = "";
         AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = "";
         AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = "";
         AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = "";
         AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = "";
         AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = "";
         AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = (DateTime)(DateTime.MinValue);
         AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = (DateTime)(DateTime.MinValue);
         AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = "";
         AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = "";
         scmdbuf = "";
         lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         A2592Reloj_Nombre = "";
         A2593HorarioDescripcion = "";
         A2431CodigoId = "";
         A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         P00H42_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H42_A2498Reloj_ID = new short[1] ;
         P00H42_A2591HorarioID = new short[1] ;
         P00H42_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H42_A2431CodigoId = new string[] {""} ;
         P00H42_A2593HorarioDescripcion = new string[] {""} ;
         P00H42_A2592Reloj_Nombre = new string[] {""} ;
         P00H42_A2590RHTrabajadorNombres = new string[] {""} ;
         P00H42_A2525TrabApePat = new string[] {""} ;
         P00H42_n2525TrabApePat = new bool[] {false} ;
         P00H42_A2526TrabApeMat = new string[] {""} ;
         P00H42_n2526TrabApeMat = new bool[] {false} ;
         P00H42_A2527TrabNombres = new string[] {""} ;
         P00H42_n2527TrabNombres = new bool[] {false} ;
         A2589RHTrabajadorCodigo = "";
         A2590RHTrabajadorNombres = "";
         AV36Session = context.GetSession();
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV70PageInfo = "";
         AV67DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV65AppName = "";
         AV71Phone = "";
         AV69Mail = "";
         AV73Website = "";
         AV62AddressLine1 = "";
         AV63AddressLine2 = "";
         AV64AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoidwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00H42_A2589RHTrabajadorCodigo, P00H42_A2498Reloj_ID, P00H42_A2591HorarioID, P00H42_A2415Lectura_Ini, P00H42_A2431CodigoId, P00H42_A2593HorarioDescripcion, P00H42_A2592Reloj_Nombre, P00H42_A2590RHTrabajadorNombres, P00H42_A2525TrabApePat, P00H42_n2525TrabApePat,
               P00H42_A2526TrabApeMat, P00H42_n2526TrabApeMat, P00H42_A2527TrabNombres, P00H42_n2527TrabNombres
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
      private short AV25DynamicFiltersOperator2 ;
      private short AV31DynamicFiltersOperator3 ;
      private short AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ;
      private short AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ;
      private short AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ;
      private short AV10OrderedBy ;
      private short A2498Reloj_ID ;
      private short A2591HorarioID ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV106GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV46TFLectura_Ini ;
      private DateTime AV47TFLectura_Ini_To ;
      private DateTime AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ;
      private DateTime AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ;
      private DateTime A2415Lectura_Ini ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV23DynamicFiltersEnabled2 ;
      private bool AV29DynamicFiltersEnabled3 ;
      private bool AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ;
      private bool AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private bool n2525TrabApePat ;
      private bool n2526TrabApeMat ;
      private bool n2527TrabNombres ;
      private string AV72Title ;
      private string AV12DynamicFiltersSelector1 ;
      private string AV14RHTrabajadorNombres1 ;
      private string AV15FilterRHTrabajadorNombresDescription ;
      private string AV16RHTrabajadorNombres ;
      private string AV17Reloj_Nombre1 ;
      private string AV18FilterReloj_NombreDescription ;
      private string AV19Reloj_Nombre ;
      private string AV20HorarioDescripcion1 ;
      private string AV21FilterHorarioDescripcionDescription ;
      private string AV22HorarioDescripcion ;
      private string AV24DynamicFiltersSelector2 ;
      private string AV26RHTrabajadorNombres2 ;
      private string AV27Reloj_Nombre2 ;
      private string AV28HorarioDescripcion2 ;
      private string AV30DynamicFiltersSelector3 ;
      private string AV32RHTrabajadorNombres3 ;
      private string AV33Reloj_Nombre3 ;
      private string AV34HorarioDescripcion3 ;
      private string AV41TFCodigoId_Sel ;
      private string AV40TFCodigoId ;
      private string AV45TFReloj_Nombre_Sel ;
      private string AV44TFReloj_Nombre ;
      private string AV59TFLectura_Ini_To_Description ;
      private string AV53TFRHTrabajadorNombres_Sel ;
      private string AV52TFRHTrabajadorNombres ;
      private string AV57TFHorarioDescripcion_Sel ;
      private string AV56TFHorarioDescripcion ;
      private string AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ;
      private string AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ;
      private string AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ;
      private string AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ;
      private string AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ;
      private string AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ;
      private string AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ;
      private string lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string A2592Reloj_Nombre ;
      private string A2593HorarioDescripcion ;
      private string A2431CodigoId ;
      private string A2589RHTrabajadorCodigo ;
      private string A2590RHTrabajadorNombres ;
      private string AV70PageInfo ;
      private string AV67DateInfo ;
      private string AV65AppName ;
      private string AV71Phone ;
      private string AV69Mail ;
      private string AV73Website ;
      private string AV62AddressLine1 ;
      private string AV63AddressLine2 ;
      private string AV64AddressLine3 ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00H42_A2589RHTrabajadorCodigo ;
      private short[] P00H42_A2498Reloj_ID ;
      private short[] P00H42_A2591HorarioID ;
      private DateTime[] P00H42_A2415Lectura_Ini ;
      private string[] P00H42_A2431CodigoId ;
      private string[] P00H42_A2593HorarioDescripcion ;
      private string[] P00H42_A2592Reloj_Nombre ;
      private string[] P00H42_A2590RHTrabajadorNombres ;
      private string[] P00H42_A2525TrabApePat ;
      private bool[] P00H42_n2525TrabApePat ;
      private string[] P00H42_A2526TrabApeMat ;
      private bool[] P00H42_n2526TrabApeMat ;
      private string[] P00H42_A2527TrabNombres ;
      private bool[] P00H42_n2527TrabNombres ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class reloj_codigoidwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00H42( IGxContext context ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, T1.[Lectura_Ini], T1.[CodigoId], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[Reloj_Nom] AS Reloj_Nombre, RTRIM(LTRIM(COALESCE( T2.[TrabApePat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabApeMat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabNombres], ''))) AS RHTrabajadorNombres, T2.[TrabApePat], T2.[TrabApeMat], T2.[TrabNombres] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV84Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV85Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV86Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV90Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV91Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV92Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RHTrabajadorNombres]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RHTrabajadorNombres] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[CodigoId]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[CodigoId] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.[Reloj_Nom]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.[Reloj_Nom] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.[Lectura_Ini]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.[Lectura_Ini] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.[Horario_Dsc]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.[Horario_Dsc] DESC";
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
                     return conditional_P00H42(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] , (short)dynConstraints[34] , (bool)dynConstraints[35] );
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
          Object[] prmP00H42;
          prmP00H42 = new Object[] {
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV87Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV88Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV89Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV93Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV94Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV95Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV96Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV97Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV98Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV99Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV100Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV101Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV102Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV103Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV104Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV105Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00H42", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H42,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
