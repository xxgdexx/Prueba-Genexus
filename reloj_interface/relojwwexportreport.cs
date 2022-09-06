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
   public class relojwwexportreport : GXWebProcedure
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

      public relojwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relojwwexportreport( IGxContext context )
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
         relojwwexportreport objrelojwwexportreport;
         objrelojwwexportreport = new relojwwexportreport();
         objrelojwwexportreport.context.SetSubmitInitialConfig(context);
         objrelojwwexportreport.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrelojwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((relojwwexportreport)stateInfo).executePrivate();
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
            AV54Title = "Lista de Reloj";
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
            HGF0( true, 0) ;
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
         if ( ! ( (0==AV30TFRelojID) && (0==AV31TFRelojID_To) ) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Código", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV30TFRelojID), "ZZZ9")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFRelojID_To_Description = StringUtil.Format( "%1 (%2)", "Código", "Hasta", "", "", "", "", "", "", "");
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFRelojID_To_Description, "")), 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFRelojID_To), "ZZZ9")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFReloj_Nom_Sel)) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj_Nom", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFReloj_Nom_Sel, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFReloj_Nom)) )
            {
               HGF0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reloj_Nom", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFReloj_Nom, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFReloj_Dsc_Sel)) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj_Dsc", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFReloj_Dsc_Sel, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFReloj_Dsc)) )
            {
               HGF0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reloj_Dsc", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFReloj_Dsc, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFReloj_IP_Sel)) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj_IP", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFReloj_IP_Sel, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFReloj_IP)) )
            {
               HGF0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reloj_IP", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFReloj_IP, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFReloj_Puerto_Sel)) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj_Puerto", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFReloj_Puerto_Sel, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFReloj_Puerto)) )
            {
               HGF0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Reloj_Puerto", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFReloj_Puerto, "")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV40TFReloj_Estado) && (0==AV41TFReloj_Estado_To) ) )
         {
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Reloj_Estado", 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV40TFReloj_Estado), "9")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFReloj_Estado_To_Description = StringUtil.Format( "%1 (%2)", "Reloj_Estado", "Hasta", "", "", "", "", "", "", "");
            HGF0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFReloj_Estado_To_Description, "")), 25, Gx_line+0, 172, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV41TFReloj_Estado_To), "9")), 172, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HGF0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 10, 77, 152, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HGF0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 10, 77, 152, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Código", 30, Gx_line+10, 103, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj_Nom", 107, Gx_line+10, 253, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj_Dsc", 257, Gx_line+10, 405, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj_IP", 409, Gx_line+10, 557, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj_Puerto", 561, Gx_line+10, 709, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Reloj_Estado", 713, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV61Reloj_interface_relojwwds_1_tfrelojid = AV30TFRelojID;
         AV62Reloj_interface_relojwwds_2_tfrelojid_to = AV31TFRelojID_To;
         AV63Reloj_interface_relojwwds_3_tfreloj_nom = AV32TFReloj_Nom;
         AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV33TFReloj_Nom_Sel;
         AV65Reloj_interface_relojwwds_5_tfreloj_dsc = AV34TFReloj_Dsc;
         AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV35TFReloj_Dsc_Sel;
         AV67Reloj_interface_relojwwds_7_tfreloj_ip = AV36TFReloj_IP;
         AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV37TFReloj_IP_Sel;
         AV69Reloj_interface_relojwwds_9_tfreloj_puerto = AV38TFReloj_Puerto;
         AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV39TFReloj_Puerto_Sel;
         AV71Reloj_interface_relojwwds_11_tfreloj_estado = AV40TFReloj_Estado;
         AV72Reloj_interface_relojwwds_12_tfreloj_estado_to = AV41TFReloj_Estado_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV62Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV63Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV65Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV67Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV69Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV71Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV72Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV63Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV65Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV65Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV67Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV67Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV69Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GF2 */
         pr_default.execute(0, new Object[] {AV61Reloj_interface_relojwwds_1_tfrelojid, AV62Reloj_interface_relojwwds_2_tfrelojid_to, lV63Reloj_interface_relojwwds_3_tfreloj_nom, AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV65Reloj_interface_relojwwds_5_tfreloj_dsc, AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV67Reloj_interface_relojwwds_7_tfreloj_ip, AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV69Reloj_interface_relojwwds_9_tfreloj_puerto, AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV71Reloj_interface_relojwwds_11_tfreloj_estado, AV72Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2429Reloj_Estado = P00GF2_A2429Reloj_Estado[0];
            A2428Reloj_Puerto = P00GF2_A2428Reloj_Puerto[0];
            A2427Reloj_IP = P00GF2_A2427Reloj_IP[0];
            A2426Reloj_Dsc = P00GF2_A2426Reloj_Dsc[0];
            A2425Reloj_Nom = P00GF2_A2425Reloj_Nom[0];
            A2430RelojID = P00GF2_A2430RelojID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HGF0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A2430RelojID), "ZZZ9")), 30, Gx_line+10, 103, Gx_line+25, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2425Reloj_Nom, "")), 107, Gx_line+10, 253, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2426Reloj_Dsc, "")), 257, Gx_line+10, 405, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2427Reloj_IP, "")), 409, Gx_line+10, 557, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A2428Reloj_Puerto, "")), 561, Gx_line+10, 709, Gx_line+25, 0, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A2429Reloj_Estado), "9")), 713, Gx_line+10, 787, Gx_line+25, 2, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV26Session.Get("Reloj_Interface.RelojWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV28GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV28GridState.gxTpr_Ordereddsc;
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJID") == 0 )
            {
               AV30TFRelojID = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV31TFRelojID_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM") == 0 )
            {
               AV32TFReloj_Nom = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM_SEL") == 0 )
            {
               AV33TFReloj_Nom_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC") == 0 )
            {
               AV34TFReloj_Dsc = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC_SEL") == 0 )
            {
               AV35TFReloj_Dsc_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP") == 0 )
            {
               AV36TFReloj_IP = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP_SEL") == 0 )
            {
               AV37TFReloj_IP_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO") == 0 )
            {
               AV38TFReloj_Puerto = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO_SEL") == 0 )
            {
               AV39TFReloj_Puerto_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFRELOJ_ESTADO") == 0 )
            {
               AV40TFReloj_Estado = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."));
               AV41TFReloj_Estado_To = (short)(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV73GXV1 = (int)(AV73GXV1+1);
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

      protected void HGF0( bool bFoot ,
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
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 10, 77, 152, 1, 1, 1, 1, 0, 0, 0, 0) ;
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
         AV42TFRelojID_To_Description = "";
         AV33TFReloj_Nom_Sel = "";
         AV32TFReloj_Nom = "";
         AV35TFReloj_Dsc_Sel = "";
         AV34TFReloj_Dsc = "";
         AV37TFReloj_IP_Sel = "";
         AV36TFReloj_IP = "";
         AV39TFReloj_Puerto_Sel = "";
         AV38TFReloj_Puerto = "";
         AV43TFReloj_Estado_To_Description = "";
         AV63Reloj_interface_relojwwds_3_tfreloj_nom = "";
         AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel = "";
         AV65Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel = "";
         AV67Reloj_interface_relojwwds_7_tfreloj_ip = "";
         AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel = "";
         AV69Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel = "";
         scmdbuf = "";
         lV63Reloj_interface_relojwwds_3_tfreloj_nom = "";
         lV65Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         lV67Reloj_interface_relojwwds_7_tfreloj_ip = "";
         lV69Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         P00GF2_A2429Reloj_Estado = new short[1] ;
         P00GF2_A2428Reloj_Puerto = new string[] {""} ;
         P00GF2_A2427Reloj_IP = new string[] {""} ;
         P00GF2_A2426Reloj_Dsc = new string[] {""} ;
         P00GF2_A2425Reloj_Nom = new string[] {""} ;
         P00GF2_A2430RelojID = new short[1] ;
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.relojwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00GF2_A2429Reloj_Estado, P00GF2_A2428Reloj_Puerto, P00GF2_A2427Reloj_IP, P00GF2_A2426Reloj_Dsc, P00GF2_A2425Reloj_Nom, P00GF2_A2430RelojID
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
      private short AV30TFRelojID ;
      private short AV31TFRelojID_To ;
      private short AV40TFReloj_Estado ;
      private short AV41TFReloj_Estado_To ;
      private short AV61Reloj_interface_relojwwds_1_tfrelojid ;
      private short AV62Reloj_interface_relojwwds_2_tfrelojid_to ;
      private short AV71Reloj_interface_relojwwds_11_tfreloj_estado ;
      private short AV72Reloj_interface_relojwwds_12_tfreloj_estado_to ;
      private short A2430RelojID ;
      private short A2429Reloj_Estado ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV73GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool returnInSub ;
      private bool AV11OrderedDsc ;
      private string AV54Title ;
      private string AV42TFRelojID_To_Description ;
      private string AV33TFReloj_Nom_Sel ;
      private string AV32TFReloj_Nom ;
      private string AV35TFReloj_Dsc_Sel ;
      private string AV34TFReloj_Dsc ;
      private string AV37TFReloj_IP_Sel ;
      private string AV36TFReloj_IP ;
      private string AV39TFReloj_Puerto_Sel ;
      private string AV38TFReloj_Puerto ;
      private string AV43TFReloj_Estado_To_Description ;
      private string AV63Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel ;
      private string AV65Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel ;
      private string AV67Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel ;
      private string AV69Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel ;
      private string lV63Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string lV65Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string lV67Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string lV69Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00GF2_A2429Reloj_Estado ;
      private string[] P00GF2_A2428Reloj_Puerto ;
      private string[] P00GF2_A2427Reloj_IP ;
      private string[] P00GF2_A2426Reloj_Dsc ;
      private string[] P00GF2_A2425Reloj_Nom ;
      private short[] P00GF2_A2430RelojID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
   }

   public class relojwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GF2( IGxContext context ,
                                             short AV61Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV62Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV63Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV65Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV67Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV69Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV71Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV72Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [Reloj_Estado], [Reloj_Puerto], [Reloj_IP], [Reloj_Dsc], [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! (0==AV61Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV61Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV62Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV62Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV63Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV65Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV67Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV69Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV71Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV71Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV72Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV72Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [RelojID]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RelojID] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Nom]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Nom] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Dsc]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Dsc] DESC";
         }
         else if ( ( AV10OrderedBy == 4 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_IP]";
         }
         else if ( ( AV10OrderedBy == 4 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_IP] DESC";
         }
         else if ( ( AV10OrderedBy == 5 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Puerto]";
         }
         else if ( ( AV10OrderedBy == 5 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Puerto] DESC";
         }
         else if ( ( AV10OrderedBy == 6 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [Reloj_Estado]";
         }
         else if ( ( AV10OrderedBy == 6 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [Reloj_Estado] DESC";
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
                     return conditional_P00GF2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP00GF2;
          prmP00GF2 = new Object[] {
          new ParDef("@AV61Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV62Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV63Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV64Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV65Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV66Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV67Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV68Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV69Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV70Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV71Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV72Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GF2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GF2,100, GxCacheFrequency.OFF ,true,false )
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
