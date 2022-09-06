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
   public class reloj_horariowwexportreport : GXWebProcedure
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

      public reloj_horariowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horariowwexportreport( IGxContext context )
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
         reloj_horariowwexportreport objreloj_horariowwexportreport;
         objreloj_horariowwexportreport = new reloj_horariowwexportreport();
         objreloj_horariowwexportreport.context.SetSubmitInitialConfig(context);
         objreloj_horariowwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_horariowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_horariowwexportreport)stateInfo).executePrivate();
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
            AV57Title = "Lista de Maestro de Horario";
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
            HGI0( true, 0) ;
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
         if ( ! ( (0==AV30TFHorario_ID) && (0==AV31TFHorario_ID_To) ) )
         {
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("ID", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFHorario_ID), "ZZZ9")), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFHorario_ID_To_Description = StringUtil.Format( "%1 (%2)", "ID", "Hasta", "", "", "", "", "", "", "");
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFHorario_ID_To_Description, "")), 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFHorario_ID_To), "ZZZ9")), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFHorario_Dsc_Sel)) )
         {
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Horario_Dsc", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFHorario_Dsc_Sel, "")), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFHorario_Dsc)) )
            {
               HGI0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Horario_Dsc", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFHorario_Dsc, "")), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV34TFHorario_Dia_Ini_01) && (DateTime.MinValue==AV35TFHorario_Dia_Ini_01_To) ) )
         {
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Horario Ingreso", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV34TFHorario_Dia_Ini_01, "99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFHorario_Dia_Ini_01_To_Description = StringUtil.Format( "%1 (%2)", "Horario Ingreso", "Hasta", "", "", "", "", "", "", "");
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFHorario_Dia_Ini_01_To_Description, "")), 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV35TFHorario_Dia_Ini_01_To, "99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV36TFHorario_Dia_Fin_01) && (DateTime.MinValue==AV37TFHorario_Dia_Fin_01_To) ) )
         {
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Horario Salida", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV36TFHorario_Dia_Fin_01, "99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TFHorario_Dia_Fin_01_To_Description = StringUtil.Format( "%1 (%2)", "Horario Salida", "Hasta", "", "", "", "", "", "", "");
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFHorario_Dia_Fin_01_To_Description, "")), 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV37TFHorario_Dia_Fin_01_To, "99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV38TFHorario_Vigencia) && (DateTime.MinValue==AV39TFHorario_Vigencia_To) ) )
         {
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Fecha Registro", 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV38TFHorario_Vigencia, "99/99/9999 99:99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFHorario_Vigencia_To_Description = StringUtil.Format( "%1 (%2)", "Fecha Registro", "Hasta", "", "", "", "", "", "", "");
            HGI0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFHorario_Vigencia_To_Description, "")), 25, Gx_line+0, 181, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV39TFHorario_Vigencia_To, "99/99/9999 99:99:99"), 181, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HGI0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HGI0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("ID", 30, Gx_line+10, 153, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Horario_Dsc", 157, Gx_line+10, 403, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Horario Ingreso", 407, Gx_line+10, 531, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Horario Salida", 535, Gx_line+10, 659, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Fecha Registro", 663, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV30TFHorario_ID;
         AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV31TFHorario_ID_To;
         AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV32TFHorario_Dsc;
         AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV33TFHorario_Dsc_Sel;
         AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV34TFHorario_Dia_Ini_01;
         AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV35TFHorario_Dia_Ini_01_To;
         AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV36TFHorario_Dia_Fin_01;
         AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV37TFHorario_Dia_Fin_01_To;
         AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV38TFHorario_Vigencia;
         AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV39TFHorario_Vigencia_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                              AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                              AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                              AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                              AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                              AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                              AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                              AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                              AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                              AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                              A2432Horario_ID ,
                                              A2433Horario_Dsc ,
                                              A2434Horario_Dia_Ini_01 ,
                                              A2441Horario_Dia_Fin_01 ,
                                              A2462Horario_Vigencia ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = StringUtil.Concat( StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc), "%", "");
         /* Using cursor P00GI2 */
         pr_default.execute(0, new Object[] {AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id, AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to, lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc, AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel, AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01, AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to, AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01, AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to, AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia, AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2462Horario_Vigencia = P00GI2_A2462Horario_Vigencia[0];
            A2441Horario_Dia_Fin_01 = P00GI2_A2441Horario_Dia_Fin_01[0];
            A2434Horario_Dia_Ini_01 = P00GI2_A2434Horario_Dia_Ini_01[0];
            A2433Horario_Dsc = P00GI2_A2433Horario_Dsc[0];
            A2432Horario_ID = P00GI2_A2432Horario_ID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HGI0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A2432Horario_ID), "ZZZ9")), 30, Gx_line+10, 153, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2433Horario_Dsc, "")), 157, Gx_line+10, 403, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A2434Horario_Dia_Ini_01, "99:99"), 407, Gx_line+10, 531, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A2441Horario_Dia_Fin_01, "99:99"), 535, Gx_line+10, 659, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A2462Horario_Vigencia, "99/99/9999 99:99:99"), 663, Gx_line+10, 787, Gx_line+25, 0, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV76GXV1 = 1;
         while ( AV76GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV76GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_ID") == 0 )
            {
               AV30TFHorario_ID = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFHorario_ID_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC") == 0 )
            {
               AV32TFHorario_Dsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC_SEL") == 0 )
            {
               AV33TFHorario_Dsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_INI_01") == 0 )
            {
               AV34TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Value, 2));
               AV35TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_FIN_01") == 0 )
            {
               AV36TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Value, 2));
               AV37TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFHORARIO_VIGENCIA") == 0 )
            {
               AV38TFHorario_Vigencia = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Value, 2);
               AV39TFHorario_Vigencia_To = context.localUtil.CToT( AV29GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV76GXV1 = (int)(AV76GXV1+1);
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

      protected void HGI0( bool bFoot ,
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
                  AV55PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV52DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV50AppName = "DVelop Software Solutions";
               AV56Phone = "+1 550 8923";
               AV54Mail = "info@mail.com";
               AV58Website = "http://www.web.com";
               AV47AddressLine1 = "French Boulevard 2859";
               AV48AddressLine2 = "Downtown";
               AV49AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV57Title = "";
         AV42TFHorario_ID_To_Description = "";
         AV33TFHorario_Dsc_Sel = "";
         AV32TFHorario_Dsc = "";
         AV34TFHorario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         AV35TFHorario_Dia_Ini_01_To = (DateTime)(DateTime.MinValue);
         AV43TFHorario_Dia_Ini_01_To_Description = "";
         AV36TFHorario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         AV37TFHorario_Dia_Fin_01_To = (DateTime)(DateTime.MinValue);
         AV44TFHorario_Dia_Fin_01_To_Description = "";
         AV38TFHorario_Vigencia = (DateTime)(DateTime.MinValue);
         AV39TFHorario_Vigencia_To = (DateTime)(DateTime.MinValue);
         AV45TFHorario_Vigencia_To_Description = "";
         AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = "";
         AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = (DateTime)(DateTime.MinValue);
         AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = (DateTime)(DateTime.MinValue);
         AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = (DateTime)(DateTime.MinValue);
         AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = (DateTime)(DateTime.MinValue);
         AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = (DateTime)(DateTime.MinValue);
         AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         A2433Horario_Dsc = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         P00GI2_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         P00GI2_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         P00GI2_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         P00GI2_A2433Horario_Dsc = new string[] {""} ;
         P00GI2_A2432Horario_ID = new short[1] ;
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55PageInfo = "";
         AV52DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV50AppName = "";
         AV56Phone = "";
         AV54Mail = "";
         AV58Website = "";
         AV47AddressLine1 = "";
         AV48AddressLine2 = "";
         AV49AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horariowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00GI2_A2462Horario_Vigencia, P00GI2_A2441Horario_Dia_Fin_01, P00GI2_A2434Horario_Dia_Ini_01, P00GI2_A2433Horario_Dsc, P00GI2_A2432Horario_ID
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
      private short AV30TFHorario_ID ;
      private short AV31TFHorario_ID_To ;
      private short AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id ;
      private short AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ;
      private short A2432Horario_ID ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV76GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV34TFHorario_Dia_Ini_01 ;
      private DateTime AV35TFHorario_Dia_Ini_01_To ;
      private DateTime AV36TFHorario_Dia_Fin_01 ;
      private DateTime AV37TFHorario_Dia_Fin_01_To ;
      private DateTime AV38TFHorario_Vigencia ;
      private DateTime AV39TFHorario_Vigencia_To ;
      private DateTime AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ;
      private DateTime AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ;
      private DateTime AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ;
      private DateTime AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ;
      private DateTime AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ;
      private DateTime AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2462Horario_Vigencia ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV11OrderedDsc ;
      private string AV57Title ;
      private string AV42TFHorario_ID_To_Description ;
      private string AV33TFHorario_Dsc_Sel ;
      private string AV32TFHorario_Dsc ;
      private string AV43TFHorario_Dia_Ini_01_To_Description ;
      private string AV44TFHorario_Dia_Fin_01_To_Description ;
      private string AV45TFHorario_Vigencia_To_Description ;
      private string AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ;
      private string lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string A2433Horario_Dsc ;
      private string AV55PageInfo ;
      private string AV52DateInfo ;
      private string AV50AppName ;
      private string AV56Phone ;
      private string AV54Mail ;
      private string AV58Website ;
      private string AV47AddressLine1 ;
      private string AV48AddressLine2 ;
      private string AV49AddressLine3 ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00GI2_A2462Horario_Vigencia ;
      private DateTime[] P00GI2_A2441Horario_Dia_Fin_01 ;
      private DateTime[] P00GI2_A2434Horario_Dia_Ini_01 ;
      private string[] P00GI2_A2433Horario_Dsc ;
      private short[] P00GI2_A2432Horario_ID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class reloj_horariowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GI2( IGxContext context ,
                                             short AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                             short AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                             string AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                             string AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                             DateTime AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                             DateTime AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                             DateTime AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                             DateTime AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                             DateTime AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                             DateTime AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                             short A2432Horario_ID ,
                                             string A2433Horario_Dsc ,
                                             DateTime A2434Horario_Dia_Ini_01 ,
                                             DateTime A2441Horario_Dia_Fin_01 ,
                                             DateTime A2462Horario_Vigencia ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [Horario_Vigencia], [Horario_Dia_Fin_01], [Horario_Dia_Ini_01], [Horario_Dsc], [Horario_ID] FROM [Reloj_Horario]";
         if ( ! (0==AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id) )
         {
            AddWhere(sWhereString, "([Horario_ID] >= @AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to) )
         {
            AddWhere(sWhereString, "([Horario_ID] <= @AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)) ) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like @lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] = @AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] >= @AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] <= @AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] >= @AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] <= @AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] >= @AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] <= @AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_ID]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_ID] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dsc]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dsc] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Ini_01]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Ini_01] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Fin_01]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Dia_Fin_01] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Horario_Vigencia]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Horario_Vigencia] DESC";
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
                     return conditional_P00GI2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmP00GI2;
          prmP00GI2 = new Object[] {
          new ParDef("@AV66Reloj_interface_reloj_horariowwds_1_tfhorario_id",GXType.Int16,4,0) ,
          new ParDef("@AV67Reloj_interface_reloj_horariowwds_2_tfhorario_id_to",GXType.Int16,4,0) ,
          new ParDef("@lV68Reloj_interface_reloj_horariowwds_3_tfhorario_dsc",GXType.NVarChar,100,5) ,
          new ParDef("@AV69Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel",GXType.NVarChar,100,5) ,
          new ParDef("@AV70Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01",GXType.DateTime,0,5) ,
          new ParDef("@AV71Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV72Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01",GXType.DateTime,0,5) ,
          new ParDef("@AV73Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV74Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia",GXType.DateTime,10,8) ,
          new ParDef("@AV75Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00GI2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GI2,100, GxCacheFrequency.OFF ,true,false )
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
