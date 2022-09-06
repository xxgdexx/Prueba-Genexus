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
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.reloj_interface {
   public class relojwwgetfilterdata : GXProcedure
   {
      public relojwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public relojwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxt ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV24DDOName = aP0_DDOName;
         this.AV22SearchTxt = aP1_SearchTxt;
         this.AV23SearchTxtTo = aP2_SearchTxtTo;
         this.AV28OptionsJson = "" ;
         this.AV31OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         relojwwgetfilterdata objrelojwwgetfilterdata;
         objrelojwwgetfilterdata = new relojwwgetfilterdata();
         objrelojwwgetfilterdata.AV24DDOName = aP0_DDOName;
         objrelojwwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objrelojwwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objrelojwwgetfilterdata.AV28OptionsJson = "" ;
         objrelojwwgetfilterdata.AV31OptionsDescJson = "" ;
         objrelojwwgetfilterdata.AV33OptionIndexesJson = "" ;
         objrelojwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objrelojwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrelojwwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((relojwwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_RELOJ_NOM") == 0 )
         {
            /* Execute user subroutine: 'LOADRELOJ_NOMOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_RELOJ_DSC") == 0 )
         {
            /* Execute user subroutine: 'LOADRELOJ_DSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_RELOJ_IP") == 0 )
         {
            /* Execute user subroutine: 'LOADRELOJ_IPOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_RELOJ_PUERTO") == 0 )
         {
            /* Execute user subroutine: 'LOADRELOJ_PUERTOOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV28OptionsJson = AV27Options.ToJSonString(false);
         AV31OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("Reloj_Interface.RelojWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Reloj_Interface.RelojWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJID") == 0 )
            {
               AV10TFRelojID = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFRelojID_To = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM") == 0 )
            {
               AV12TFReloj_Nom = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOM_SEL") == 0 )
            {
               AV13TFReloj_Nom_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC") == 0 )
            {
               AV14TFReloj_Dsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_DSC_SEL") == 0 )
            {
               AV15TFReloj_Dsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP") == 0 )
            {
               AV16TFReloj_IP = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_IP_SEL") == 0 )
            {
               AV17TFReloj_IP_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO") == 0 )
            {
               AV18TFReloj_Puerto = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_PUERTO_SEL") == 0 )
            {
               AV19TFReloj_Puerto_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFRELOJ_ESTADO") == 0 )
            {
               AV20TFReloj_Estado = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV21TFReloj_Estado_To = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADRELOJ_NOMOPTIONS' Routine */
         returnInSub = false;
         AV12TFReloj_Nom = AV22SearchTxt;
         AV13TFReloj_Nom_Sel = "";
         AV55Reloj_interface_relojwwds_1_tfrelojid = AV10TFRelojID;
         AV56Reloj_interface_relojwwds_2_tfrelojid_to = AV11TFRelojID_To;
         AV57Reloj_interface_relojwwds_3_tfreloj_nom = AV12TFReloj_Nom;
         AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV13TFReloj_Nom_Sel;
         AV59Reloj_interface_relojwwds_5_tfreloj_dsc = AV14TFReloj_Dsc;
         AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV15TFReloj_Dsc_Sel;
         AV61Reloj_interface_relojwwds_7_tfreloj_ip = AV16TFReloj_IP;
         AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV17TFReloj_IP_Sel;
         AV63Reloj_interface_relojwwds_9_tfreloj_puerto = AV18TFReloj_Puerto;
         AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV19TFReloj_Puerto_Sel;
         AV65Reloj_interface_relojwwds_11_tfreloj_estado = AV20TFReloj_Estado;
         AV66Reloj_interface_relojwwds_12_tfreloj_estado_to = AV21TFReloj_Estado_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV57Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV59Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV61Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV63Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GD2 */
         pr_default.execute(0, new Object[] {AV55Reloj_interface_relojwwds_1_tfrelojid, AV56Reloj_interface_relojwwds_2_tfrelojid_to, lV57Reloj_interface_relojwwds_3_tfreloj_nom, AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV59Reloj_interface_relojwwds_5_tfreloj_dsc, AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV61Reloj_interface_relojwwds_7_tfreloj_ip, AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV63Reloj_interface_relojwwds_9_tfreloj_puerto, AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV65Reloj_interface_relojwwds_11_tfreloj_estado, AV66Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKGD2 = false;
            A2425Reloj_Nom = P00GD2_A2425Reloj_Nom[0];
            A2429Reloj_Estado = P00GD2_A2429Reloj_Estado[0];
            A2428Reloj_Puerto = P00GD2_A2428Reloj_Puerto[0];
            A2427Reloj_IP = P00GD2_A2427Reloj_IP[0];
            A2426Reloj_Dsc = P00GD2_A2426Reloj_Dsc[0];
            A2430RelojID = P00GD2_A2430RelojID[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00GD2_A2425Reloj_Nom[0], A2425Reloj_Nom) == 0 ) )
            {
               BRKGD2 = false;
               A2430RelojID = P00GD2_A2430RelojID[0];
               AV34count = (long)(AV34count+1);
               BRKGD2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2425Reloj_Nom)) )
            {
               AV26Option = A2425Reloj_Nom;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGD2 )
            {
               BRKGD2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRELOJ_DSCOPTIONS' Routine */
         returnInSub = false;
         AV14TFReloj_Dsc = AV22SearchTxt;
         AV15TFReloj_Dsc_Sel = "";
         AV55Reloj_interface_relojwwds_1_tfrelojid = AV10TFRelojID;
         AV56Reloj_interface_relojwwds_2_tfrelojid_to = AV11TFRelojID_To;
         AV57Reloj_interface_relojwwds_3_tfreloj_nom = AV12TFReloj_Nom;
         AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV13TFReloj_Nom_Sel;
         AV59Reloj_interface_relojwwds_5_tfreloj_dsc = AV14TFReloj_Dsc;
         AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV15TFReloj_Dsc_Sel;
         AV61Reloj_interface_relojwwds_7_tfreloj_ip = AV16TFReloj_IP;
         AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV17TFReloj_IP_Sel;
         AV63Reloj_interface_relojwwds_9_tfreloj_puerto = AV18TFReloj_Puerto;
         AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV19TFReloj_Puerto_Sel;
         AV65Reloj_interface_relojwwds_11_tfreloj_estado = AV20TFReloj_Estado;
         AV66Reloj_interface_relojwwds_12_tfreloj_estado_to = AV21TFReloj_Estado_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV57Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV59Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV61Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV63Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GD3 */
         pr_default.execute(1, new Object[] {AV55Reloj_interface_relojwwds_1_tfrelojid, AV56Reloj_interface_relojwwds_2_tfrelojid_to, lV57Reloj_interface_relojwwds_3_tfreloj_nom, AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV59Reloj_interface_relojwwds_5_tfreloj_dsc, AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV61Reloj_interface_relojwwds_7_tfreloj_ip, AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV63Reloj_interface_relojwwds_9_tfreloj_puerto, AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV65Reloj_interface_relojwwds_11_tfreloj_estado, AV66Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKGD4 = false;
            A2426Reloj_Dsc = P00GD3_A2426Reloj_Dsc[0];
            A2429Reloj_Estado = P00GD3_A2429Reloj_Estado[0];
            A2428Reloj_Puerto = P00GD3_A2428Reloj_Puerto[0];
            A2427Reloj_IP = P00GD3_A2427Reloj_IP[0];
            A2425Reloj_Nom = P00GD3_A2425Reloj_Nom[0];
            A2430RelojID = P00GD3_A2430RelojID[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00GD3_A2426Reloj_Dsc[0], A2426Reloj_Dsc) == 0 ) )
            {
               BRKGD4 = false;
               A2430RelojID = P00GD3_A2430RelojID[0];
               AV34count = (long)(AV34count+1);
               BRKGD4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2426Reloj_Dsc)) )
            {
               AV26Option = A2426Reloj_Dsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGD4 )
            {
               BRKGD4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRELOJ_IPOPTIONS' Routine */
         returnInSub = false;
         AV16TFReloj_IP = AV22SearchTxt;
         AV17TFReloj_IP_Sel = "";
         AV55Reloj_interface_relojwwds_1_tfrelojid = AV10TFRelojID;
         AV56Reloj_interface_relojwwds_2_tfrelojid_to = AV11TFRelojID_To;
         AV57Reloj_interface_relojwwds_3_tfreloj_nom = AV12TFReloj_Nom;
         AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV13TFReloj_Nom_Sel;
         AV59Reloj_interface_relojwwds_5_tfreloj_dsc = AV14TFReloj_Dsc;
         AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV15TFReloj_Dsc_Sel;
         AV61Reloj_interface_relojwwds_7_tfreloj_ip = AV16TFReloj_IP;
         AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV17TFReloj_IP_Sel;
         AV63Reloj_interface_relojwwds_9_tfreloj_puerto = AV18TFReloj_Puerto;
         AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV19TFReloj_Puerto_Sel;
         AV65Reloj_interface_relojwwds_11_tfreloj_estado = AV20TFReloj_Estado;
         AV66Reloj_interface_relojwwds_12_tfreloj_estado_to = AV21TFReloj_Estado_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV57Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV59Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV61Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV63Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GD4 */
         pr_default.execute(2, new Object[] {AV55Reloj_interface_relojwwds_1_tfrelojid, AV56Reloj_interface_relojwwds_2_tfrelojid_to, lV57Reloj_interface_relojwwds_3_tfreloj_nom, AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV59Reloj_interface_relojwwds_5_tfreloj_dsc, AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV61Reloj_interface_relojwwds_7_tfreloj_ip, AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV63Reloj_interface_relojwwds_9_tfreloj_puerto, AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV65Reloj_interface_relojwwds_11_tfreloj_estado, AV66Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKGD6 = false;
            A2427Reloj_IP = P00GD4_A2427Reloj_IP[0];
            A2429Reloj_Estado = P00GD4_A2429Reloj_Estado[0];
            A2428Reloj_Puerto = P00GD4_A2428Reloj_Puerto[0];
            A2426Reloj_Dsc = P00GD4_A2426Reloj_Dsc[0];
            A2425Reloj_Nom = P00GD4_A2425Reloj_Nom[0];
            A2430RelojID = P00GD4_A2430RelojID[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00GD4_A2427Reloj_IP[0], A2427Reloj_IP) == 0 ) )
            {
               BRKGD6 = false;
               A2430RelojID = P00GD4_A2430RelojID[0];
               AV34count = (long)(AV34count+1);
               BRKGD6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2427Reloj_IP)) )
            {
               AV26Option = A2427Reloj_IP;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGD6 )
            {
               BRKGD6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADRELOJ_PUERTOOPTIONS' Routine */
         returnInSub = false;
         AV18TFReloj_Puerto = AV22SearchTxt;
         AV19TFReloj_Puerto_Sel = "";
         AV55Reloj_interface_relojwwds_1_tfrelojid = AV10TFRelojID;
         AV56Reloj_interface_relojwwds_2_tfrelojid_to = AV11TFRelojID_To;
         AV57Reloj_interface_relojwwds_3_tfreloj_nom = AV12TFReloj_Nom;
         AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel = AV13TFReloj_Nom_Sel;
         AV59Reloj_interface_relojwwds_5_tfreloj_dsc = AV14TFReloj_Dsc;
         AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel = AV15TFReloj_Dsc_Sel;
         AV61Reloj_interface_relojwwds_7_tfreloj_ip = AV16TFReloj_IP;
         AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel = AV17TFReloj_IP_Sel;
         AV63Reloj_interface_relojwwds_9_tfreloj_puerto = AV18TFReloj_Puerto;
         AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel = AV19TFReloj_Puerto_Sel;
         AV65Reloj_interface_relojwwds_11_tfreloj_estado = AV20TFReloj_Estado;
         AV66Reloj_interface_relojwwds_12_tfreloj_estado_to = AV21TFReloj_Estado_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                              AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                              AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                              AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                              AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                              AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                              AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                              AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                              AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                              AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                              AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                              AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                              A2430RelojID ,
                                              A2425Reloj_Nom ,
                                              A2426Reloj_Dsc ,
                                              A2427Reloj_IP ,
                                              A2428Reloj_Puerto ,
                                              A2429Reloj_Estado } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV57Reloj_interface_relojwwds_3_tfreloj_nom = StringUtil.Concat( StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom), "%", "");
         lV59Reloj_interface_relojwwds_5_tfreloj_dsc = StringUtil.Concat( StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc), "%", "");
         lV61Reloj_interface_relojwwds_7_tfreloj_ip = StringUtil.Concat( StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip), "%", "");
         lV63Reloj_interface_relojwwds_9_tfreloj_puerto = StringUtil.Concat( StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto), "%", "");
         /* Using cursor P00GD5 */
         pr_default.execute(3, new Object[] {AV55Reloj_interface_relojwwds_1_tfrelojid, AV56Reloj_interface_relojwwds_2_tfrelojid_to, lV57Reloj_interface_relojwwds_3_tfreloj_nom, AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel, lV59Reloj_interface_relojwwds_5_tfreloj_dsc, AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel, lV61Reloj_interface_relojwwds_7_tfreloj_ip, AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel, lV63Reloj_interface_relojwwds_9_tfreloj_puerto, AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel, AV65Reloj_interface_relojwwds_11_tfreloj_estado, AV66Reloj_interface_relojwwds_12_tfreloj_estado_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKGD8 = false;
            A2428Reloj_Puerto = P00GD5_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = P00GD5_A2429Reloj_Estado[0];
            A2427Reloj_IP = P00GD5_A2427Reloj_IP[0];
            A2426Reloj_Dsc = P00GD5_A2426Reloj_Dsc[0];
            A2425Reloj_Nom = P00GD5_A2425Reloj_Nom[0];
            A2430RelojID = P00GD5_A2430RelojID[0];
            AV34count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00GD5_A2428Reloj_Puerto[0], A2428Reloj_Puerto) == 0 ) )
            {
               BRKGD8 = false;
               A2430RelojID = P00GD5_A2430RelojID[0];
               AV34count = (long)(AV34count+1);
               BRKGD8 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2428Reloj_Puerto)) )
            {
               AV26Option = A2428Reloj_Puerto;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGD8 )
            {
               BRKGD8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV28OptionsJson = "";
         AV31OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFReloj_Nom = "";
         AV13TFReloj_Nom_Sel = "";
         AV14TFReloj_Dsc = "";
         AV15TFReloj_Dsc_Sel = "";
         AV16TFReloj_IP = "";
         AV17TFReloj_IP_Sel = "";
         AV18TFReloj_Puerto = "";
         AV19TFReloj_Puerto_Sel = "";
         AV57Reloj_interface_relojwwds_3_tfreloj_nom = "";
         AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel = "";
         AV59Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel = "";
         AV61Reloj_interface_relojwwds_7_tfreloj_ip = "";
         AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel = "";
         AV63Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel = "";
         scmdbuf = "";
         lV57Reloj_interface_relojwwds_3_tfreloj_nom = "";
         lV59Reloj_interface_relojwwds_5_tfreloj_dsc = "";
         lV61Reloj_interface_relojwwds_7_tfreloj_ip = "";
         lV63Reloj_interface_relojwwds_9_tfreloj_puerto = "";
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         P00GD2_A2425Reloj_Nom = new string[] {""} ;
         P00GD2_A2429Reloj_Estado = new short[1] ;
         P00GD2_A2428Reloj_Puerto = new string[] {""} ;
         P00GD2_A2427Reloj_IP = new string[] {""} ;
         P00GD2_A2426Reloj_Dsc = new string[] {""} ;
         P00GD2_A2430RelojID = new short[1] ;
         AV26Option = "";
         P00GD3_A2426Reloj_Dsc = new string[] {""} ;
         P00GD3_A2429Reloj_Estado = new short[1] ;
         P00GD3_A2428Reloj_Puerto = new string[] {""} ;
         P00GD3_A2427Reloj_IP = new string[] {""} ;
         P00GD3_A2425Reloj_Nom = new string[] {""} ;
         P00GD3_A2430RelojID = new short[1] ;
         P00GD4_A2427Reloj_IP = new string[] {""} ;
         P00GD4_A2429Reloj_Estado = new short[1] ;
         P00GD4_A2428Reloj_Puerto = new string[] {""} ;
         P00GD4_A2426Reloj_Dsc = new string[] {""} ;
         P00GD4_A2425Reloj_Nom = new string[] {""} ;
         P00GD4_A2430RelojID = new short[1] ;
         P00GD5_A2428Reloj_Puerto = new string[] {""} ;
         P00GD5_A2429Reloj_Estado = new short[1] ;
         P00GD5_A2427Reloj_IP = new string[] {""} ;
         P00GD5_A2426Reloj_Dsc = new string[] {""} ;
         P00GD5_A2425Reloj_Nom = new string[] {""} ;
         P00GD5_A2430RelojID = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.relojwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00GD2_A2425Reloj_Nom, P00GD2_A2429Reloj_Estado, P00GD2_A2428Reloj_Puerto, P00GD2_A2427Reloj_IP, P00GD2_A2426Reloj_Dsc, P00GD2_A2430RelojID
               }
               , new Object[] {
               P00GD3_A2426Reloj_Dsc, P00GD3_A2429Reloj_Estado, P00GD3_A2428Reloj_Puerto, P00GD3_A2427Reloj_IP, P00GD3_A2425Reloj_Nom, P00GD3_A2430RelojID
               }
               , new Object[] {
               P00GD4_A2427Reloj_IP, P00GD4_A2429Reloj_Estado, P00GD4_A2428Reloj_Puerto, P00GD4_A2426Reloj_Dsc, P00GD4_A2425Reloj_Nom, P00GD4_A2430RelojID
               }
               , new Object[] {
               P00GD5_A2428Reloj_Puerto, P00GD5_A2429Reloj_Estado, P00GD5_A2427Reloj_IP, P00GD5_A2426Reloj_Dsc, P00GD5_A2425Reloj_Nom, P00GD5_A2430RelojID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10TFRelojID ;
      private short AV11TFRelojID_To ;
      private short AV20TFReloj_Estado ;
      private short AV21TFReloj_Estado_To ;
      private short AV55Reloj_interface_relojwwds_1_tfrelojid ;
      private short AV56Reloj_interface_relojwwds_2_tfrelojid_to ;
      private short AV65Reloj_interface_relojwwds_11_tfreloj_estado ;
      private short AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ;
      private short A2430RelojID ;
      private short A2429Reloj_Estado ;
      private int AV53GXV1 ;
      private long AV34count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRKGD2 ;
      private bool BRKGD4 ;
      private bool BRKGD6 ;
      private bool BRKGD8 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV12TFReloj_Nom ;
      private string AV13TFReloj_Nom_Sel ;
      private string AV14TFReloj_Dsc ;
      private string AV15TFReloj_Dsc_Sel ;
      private string AV16TFReloj_IP ;
      private string AV17TFReloj_IP_Sel ;
      private string AV18TFReloj_Puerto ;
      private string AV19TFReloj_Puerto_Sel ;
      private string AV57Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ;
      private string AV59Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ;
      private string AV61Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ;
      private string AV63Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ;
      private string lV57Reloj_interface_relojwwds_3_tfreloj_nom ;
      private string lV59Reloj_interface_relojwwds_5_tfreloj_dsc ;
      private string lV61Reloj_interface_relojwwds_7_tfreloj_ip ;
      private string lV63Reloj_interface_relojwwds_9_tfreloj_puerto ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private string AV26Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GD2_A2425Reloj_Nom ;
      private short[] P00GD2_A2429Reloj_Estado ;
      private string[] P00GD2_A2428Reloj_Puerto ;
      private string[] P00GD2_A2427Reloj_IP ;
      private string[] P00GD2_A2426Reloj_Dsc ;
      private short[] P00GD2_A2430RelojID ;
      private string[] P00GD3_A2426Reloj_Dsc ;
      private short[] P00GD3_A2429Reloj_Estado ;
      private string[] P00GD3_A2428Reloj_Puerto ;
      private string[] P00GD3_A2427Reloj_IP ;
      private string[] P00GD3_A2425Reloj_Nom ;
      private short[] P00GD3_A2430RelojID ;
      private string[] P00GD4_A2427Reloj_IP ;
      private short[] P00GD4_A2429Reloj_Estado ;
      private string[] P00GD4_A2428Reloj_Puerto ;
      private string[] P00GD4_A2426Reloj_Dsc ;
      private string[] P00GD4_A2425Reloj_Nom ;
      private short[] P00GD4_A2430RelojID ;
      private string[] P00GD5_A2428Reloj_Puerto ;
      private short[] P00GD5_A2429Reloj_Estado ;
      private string[] P00GD5_A2427Reloj_IP ;
      private string[] P00GD5_A2426Reloj_Dsc ;
      private string[] P00GD5_A2425Reloj_Nom ;
      private short[] P00GD5_A2430RelojID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
   }

   public class relojwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GD2( IGxContext context ,
                                             short AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [Reloj_Nom], [Reloj_Estado], [Reloj_Puerto], [Reloj_IP], [Reloj_Dsc], [RelojID] FROM [Reloj]";
         if ( ! (0==AV55Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV55Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV56Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV56Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV57Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV59Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV61Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV63Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV65Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV65Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV66Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV66Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Reloj_Nom]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00GD3( IGxContext context ,
                                             short AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [Reloj_Dsc], [Reloj_Estado], [Reloj_Puerto], [Reloj_IP], [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! (0==AV55Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV55Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV56Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV56Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV57Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV59Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV61Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV63Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV65Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV65Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV66Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV66Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Reloj_Dsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00GD4( IGxContext context ,
                                             short AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [Reloj_IP], [Reloj_Estado], [Reloj_Puerto], [Reloj_Dsc], [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! (0==AV55Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV55Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ! (0==AV56Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV56Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV57Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV59Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV61Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV63Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (0==AV65Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV65Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV66Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV66Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Reloj_IP]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00GD5( IGxContext context ,
                                             short AV55Reloj_interface_relojwwds_1_tfrelojid ,
                                             short AV56Reloj_interface_relojwwds_2_tfrelojid_to ,
                                             string AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel ,
                                             string AV57Reloj_interface_relojwwds_3_tfreloj_nom ,
                                             string AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel ,
                                             string AV59Reloj_interface_relojwwds_5_tfreloj_dsc ,
                                             string AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel ,
                                             string AV61Reloj_interface_relojwwds_7_tfreloj_ip ,
                                             string AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel ,
                                             string AV63Reloj_interface_relojwwds_9_tfreloj_puerto ,
                                             short AV65Reloj_interface_relojwwds_11_tfreloj_estado ,
                                             short AV66Reloj_interface_relojwwds_12_tfreloj_estado_to ,
                                             short A2430RelojID ,
                                             string A2425Reloj_Nom ,
                                             string A2426Reloj_Dsc ,
                                             string A2427Reloj_IP ,
                                             string A2428Reloj_Puerto ,
                                             short A2429Reloj_Estado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [Reloj_Puerto], [Reloj_Estado], [Reloj_IP], [Reloj_Dsc], [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! (0==AV55Reloj_interface_relojwwds_1_tfrelojid) )
         {
            AddWhere(sWhereString, "([RelojID] >= @AV55Reloj_interface_relojwwds_1_tfrelojid)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ! (0==AV56Reloj_interface_relojwwds_2_tfrelojid_to) )
         {
            AddWhere(sWhereString, "([RelojID] <= @AV56Reloj_interface_relojwwds_2_tfrelojid_to)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Reloj_interface_relojwwds_3_tfreloj_nom)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like @lV57Reloj_interface_relojwwds_3_tfreloj_nom)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] = @AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reloj_interface_relojwwds_5_tfreloj_dsc)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] like @lV59Reloj_interface_relojwwds_5_tfreloj_dsc)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Dsc] = @AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Reloj_interface_relojwwds_7_tfreloj_ip)) ) )
         {
            AddWhere(sWhereString, "([Reloj_IP] like @lV61Reloj_interface_relojwwds_7_tfreloj_ip)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_IP] = @AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Reloj_interface_relojwwds_9_tfreloj_puerto)) ) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] like @lV63Reloj_interface_relojwwds_9_tfreloj_puerto)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)) )
         {
            AddWhere(sWhereString, "([Reloj_Puerto] = @AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! (0==AV65Reloj_interface_relojwwds_11_tfreloj_estado) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] >= @AV65Reloj_interface_relojwwds_11_tfreloj_estado)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! (0==AV66Reloj_interface_relojwwds_12_tfreloj_estado_to) )
         {
            AddWhere(sWhereString, "([Reloj_Estado] <= @AV66Reloj_interface_relojwwds_12_tfreloj_estado_to)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Reloj_Puerto]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00GD2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] );
               case 1 :
                     return conditional_P00GD3(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] );
               case 2 :
                     return conditional_P00GD4(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] );
               case 3 :
                     return conditional_P00GD5(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GD2;
          prmP00GD2 = new Object[] {
          new ParDef("@AV55Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV56Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV57Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV59Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV63Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV65Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV66Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          Object[] prmP00GD3;
          prmP00GD3 = new Object[] {
          new ParDef("@AV55Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV56Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV57Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV59Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV63Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV65Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV66Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          Object[] prmP00GD4;
          prmP00GD4 = new Object[] {
          new ParDef("@AV55Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV56Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV57Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV59Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV63Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV65Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV66Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          Object[] prmP00GD5;
          prmP00GD5 = new Object[] {
          new ParDef("@AV55Reloj_interface_relojwwds_1_tfrelojid",GXType.Int16,4,0) ,
          new ParDef("@AV56Reloj_interface_relojwwds_2_tfrelojid_to",GXType.Int16,4,0) ,
          new ParDef("@lV57Reloj_interface_relojwwds_3_tfreloj_nom",GXType.NVarChar,50,0) ,
          new ParDef("@AV58Reloj_interface_relojwwds_4_tfreloj_nom_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV59Reloj_interface_relojwwds_5_tfreloj_dsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV60Reloj_interface_relojwwds_6_tfreloj_dsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Reloj_interface_relojwwds_7_tfreloj_ip",GXType.NVarChar,50,0) ,
          new ParDef("@AV62Reloj_interface_relojwwds_8_tfreloj_ip_sel",GXType.NVarChar,50,0) ,
          new ParDef("@lV63Reloj_interface_relojwwds_9_tfreloj_puerto",GXType.NVarChar,50,0) ,
          new ParDef("@AV64Reloj_interface_relojwwds_10_tfreloj_puerto_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV65Reloj_interface_relojwwds_11_tfreloj_estado",GXType.Int16,1,0) ,
          new ParDef("@AV66Reloj_interface_relojwwds_12_tfreloj_estado_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GD2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GD3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GD4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GD5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GD5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
