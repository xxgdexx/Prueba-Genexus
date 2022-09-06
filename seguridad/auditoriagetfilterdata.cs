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
namespace GeneXus.Programs.seguridad {
   public class auditoriagetfilterdata : GXProcedure
   {
      public auditoriagetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auditoriagetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV28SearchTxt = aP1_SearchTxt;
         this.AV29SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         auditoriagetfilterdata objauditoriagetfilterdata;
         objauditoriagetfilterdata = new auditoriagetfilterdata();
         objauditoriagetfilterdata.AV30DDOName = aP0_DDOName;
         objauditoriagetfilterdata.AV28SearchTxt = aP1_SearchTxt;
         objauditoriagetfilterdata.AV29SearchTxtTo = aP2_SearchTxtTo;
         objauditoriagetfilterdata.AV34OptionsJson = "" ;
         objauditoriagetfilterdata.AV37OptionsDescJson = "" ;
         objauditoriagetfilterdata.AV39OptionIndexesJson = "" ;
         objauditoriagetfilterdata.context.SetSubmitInitialConfig(context);
         objauditoriagetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objauditoriagetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auditoriagetfilterdata)stateInfo).executePrivate();
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
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUDOCGLS") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUDOCGLSOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUDOCNUM") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUDOCNUMOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUDOCREF") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUDOCREFOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUTIPCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUTIPCODOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUTIPO") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUTIPOOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_SGAUUSUCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADSGAUUSUCODOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV33Options.ToJSonString(false);
         AV37OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("Seguridad.AuditoriaGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.AuditoriaGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("Seguridad.AuditoriaGridState"), null, "", "");
         }
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "USUCOD") == 0 )
            {
               AV66UsuCod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "SGAUMOD") == 0 )
            {
               AV60SGAuMod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "SGAUDOCGLS") == 0 )
            {
               AV62SGAuDocGls = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "SGAUFECH") == 0 )
            {
               AV65SGAuFech = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Value, 2);
               AV63SGAuFechOperator = AV44GridStateFilterValue.gxTpr_Operator;
               AV64SGAuFech_To = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUMOD_SEL") == 0 )
            {
               AV67TFSGAuMod_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV68TFSGAuMod_Sels.FromJSonString(AV67TFSGAuMod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUFECHA") == 0 )
            {
               AV12TFSGAuFecha = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Value, 2);
               AV13TFSGAuFecha_To = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCGLS") == 0 )
            {
               AV20TFSGAuDocGls = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCGLS_SEL") == 0 )
            {
               AV21TFSGAuDocGls_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCNUM") == 0 )
            {
               AV16TFSGAuDocNum = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCNUM_SEL") == 0 )
            {
               AV17TFSGAuDocNum_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCREF") == 0 )
            {
               AV18TFSGAuDocRef = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUDOCREF_SEL") == 0 )
            {
               AV19TFSGAuDocRef_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUTIPCOD") == 0 )
            {
               AV14TFSGAuTipCod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUTIPCOD_SEL") == 0 )
            {
               AV15TFSGAuTipCod_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUTIPO") == 0 )
            {
               AV24TFSGAuTipo = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUTIPO_SEL") == 0 )
            {
               AV25TFSGAuTipo_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUUSUCOD") == 0 )
            {
               AV22TFSGAuUsuCod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSGAUUSUCOD_SEL") == 0 )
            {
               AV23TFSGAuUsuCod_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSGAUDOCGLSOPTIONS' Routine */
         returnInSub = false;
         AV20TFSGAuDocGls = AV28SearchTxt;
         AV21TFSGAuDocGls_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N2 */
         pr_default.execute(0, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1N2 = false;
            A1843SGAuDocGls = P001N2_A1843SGAuDocGls[0];
            A1848SGAuTipo = P001N2_A1848SGAuTipo[0];
            A1847SGAuTipCod = P001N2_A1847SGAuTipCod[0];
            A1845SGAuDocRef = P001N2_A1845SGAuDocRef[0];
            A1844SGAuDocNum = P001N2_A1844SGAuDocNum[0];
            A338SGAuFecha = P001N2_A338SGAuFecha[0];
            A1846SGAuFech = P001N2_A1846SGAuFech[0];
            A337SGAuMod = P001N2_A337SGAuMod[0];
            A1849SGAuUsuCod = P001N2_A1849SGAuUsuCod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001N2_A1843SGAuDocGls[0], A1843SGAuDocGls) == 0 ) )
            {
               BRK1N2 = false;
               A338SGAuFecha = P001N2_A338SGAuFecha[0];
               A337SGAuMod = P001N2_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1843SGAuDocGls)) )
            {
               AV32Option = A1843SGAuDocGls;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N2 )
            {
               BRK1N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSGAUDOCNUMOPTIONS' Routine */
         returnInSub = false;
         AV16TFSGAuDocNum = AV28SearchTxt;
         AV17TFSGAuDocNum_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N3 */
         pr_default.execute(1, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1N4 = false;
            A1844SGAuDocNum = P001N3_A1844SGAuDocNum[0];
            A1848SGAuTipo = P001N3_A1848SGAuTipo[0];
            A1847SGAuTipCod = P001N3_A1847SGAuTipCod[0];
            A1845SGAuDocRef = P001N3_A1845SGAuDocRef[0];
            A338SGAuFecha = P001N3_A338SGAuFecha[0];
            A1846SGAuFech = P001N3_A1846SGAuFech[0];
            A1843SGAuDocGls = P001N3_A1843SGAuDocGls[0];
            A337SGAuMod = P001N3_A337SGAuMod[0];
            A1849SGAuUsuCod = P001N3_A1849SGAuUsuCod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001N3_A1844SGAuDocNum[0], A1844SGAuDocNum) == 0 ) )
            {
               BRK1N4 = false;
               A338SGAuFecha = P001N3_A338SGAuFecha[0];
               A337SGAuMod = P001N3_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1844SGAuDocNum)) )
            {
               AV32Option = A1844SGAuDocNum;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N4 )
            {
               BRK1N4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSGAUDOCREFOPTIONS' Routine */
         returnInSub = false;
         AV18TFSGAuDocRef = AV28SearchTxt;
         AV19TFSGAuDocRef_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N4 */
         pr_default.execute(2, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK1N6 = false;
            A1845SGAuDocRef = P001N4_A1845SGAuDocRef[0];
            A1848SGAuTipo = P001N4_A1848SGAuTipo[0];
            A1847SGAuTipCod = P001N4_A1847SGAuTipCod[0];
            A1844SGAuDocNum = P001N4_A1844SGAuDocNum[0];
            A338SGAuFecha = P001N4_A338SGAuFecha[0];
            A1846SGAuFech = P001N4_A1846SGAuFech[0];
            A1843SGAuDocGls = P001N4_A1843SGAuDocGls[0];
            A337SGAuMod = P001N4_A337SGAuMod[0];
            A1849SGAuUsuCod = P001N4_A1849SGAuUsuCod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P001N4_A1845SGAuDocRef[0], A1845SGAuDocRef) == 0 ) )
            {
               BRK1N6 = false;
               A338SGAuFecha = P001N4_A338SGAuFecha[0];
               A337SGAuMod = P001N4_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1845SGAuDocRef)) )
            {
               AV32Option = A1845SGAuDocRef;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N6 )
            {
               BRK1N6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSGAUTIPCODOPTIONS' Routine */
         returnInSub = false;
         AV14TFSGAuTipCod = AV28SearchTxt;
         AV15TFSGAuTipCod_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N5 */
         pr_default.execute(3, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK1N8 = false;
            A1847SGAuTipCod = P001N5_A1847SGAuTipCod[0];
            A1848SGAuTipo = P001N5_A1848SGAuTipo[0];
            A1845SGAuDocRef = P001N5_A1845SGAuDocRef[0];
            A1844SGAuDocNum = P001N5_A1844SGAuDocNum[0];
            A338SGAuFecha = P001N5_A338SGAuFecha[0];
            A1846SGAuFech = P001N5_A1846SGAuFech[0];
            A1843SGAuDocGls = P001N5_A1843SGAuDocGls[0];
            A337SGAuMod = P001N5_A337SGAuMod[0];
            A1849SGAuUsuCod = P001N5_A1849SGAuUsuCod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P001N5_A1847SGAuTipCod[0], A1847SGAuTipCod) == 0 ) )
            {
               BRK1N8 = false;
               A338SGAuFecha = P001N5_A338SGAuFecha[0];
               A337SGAuMod = P001N5_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N8 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1847SGAuTipCod)) )
            {
               AV32Option = A1847SGAuTipCod;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N8 )
            {
               BRK1N8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSGAUTIPOOPTIONS' Routine */
         returnInSub = false;
         AV24TFSGAuTipo = AV28SearchTxt;
         AV25TFSGAuTipo_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N6 */
         pr_default.execute(4, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK1N10 = false;
            A1848SGAuTipo = P001N6_A1848SGAuTipo[0];
            A1847SGAuTipCod = P001N6_A1847SGAuTipCod[0];
            A1845SGAuDocRef = P001N6_A1845SGAuDocRef[0];
            A1844SGAuDocNum = P001N6_A1844SGAuDocNum[0];
            A338SGAuFecha = P001N6_A338SGAuFecha[0];
            A1846SGAuFech = P001N6_A1846SGAuFech[0];
            A1843SGAuDocGls = P001N6_A1843SGAuDocGls[0];
            A337SGAuMod = P001N6_A337SGAuMod[0];
            A1849SGAuUsuCod = P001N6_A1849SGAuUsuCod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P001N6_A1848SGAuTipo[0], A1848SGAuTipo) == 0 ) )
            {
               BRK1N10 = false;
               A338SGAuFecha = P001N6_A338SGAuFecha[0];
               A337SGAuMod = P001N6_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N10 = true;
               pr_default.readNext(4);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1848SGAuTipo)) )
            {
               AV32Option = A1848SGAuTipo;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N10 )
            {
               BRK1N10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSGAUUSUCODOPTIONS' Routine */
         returnInSub = false;
         AV22TFSGAuUsuCod = AV28SearchTxt;
         AV23TFSGAuUsuCod_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = AV66UsuCod;
         AV74Seguridad_auditoriads_2_sgaumod = AV60SGAuMod;
         AV75Seguridad_auditoriads_3_sgaudocgls = AV62SGAuDocGls;
         AV76Seguridad_auditoriads_4_sgaufech = AV65SGAuFech;
         AV77Seguridad_auditoriads_5_sgaufech_to = AV64SGAuFech_To;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = AV68TFSGAuMod_Sels;
         AV79Seguridad_auditoriads_7_tfsgaufecha = AV12TFSGAuFecha;
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = AV13TFSGAuFecha_To;
         AV81Seguridad_auditoriads_9_tfsgaudocgls = AV20TFSGAuDocGls;
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = AV21TFSGAuDocGls_Sel;
         AV83Seguridad_auditoriads_11_tfsgaudocnum = AV16TFSGAuDocNum;
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = AV17TFSGAuDocNum_Sel;
         AV85Seguridad_auditoriads_13_tfsgaudocref = AV18TFSGAuDocRef;
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = AV19TFSGAuDocRef_Sel;
         AV87Seguridad_auditoriads_15_tfsgautipcod = AV14TFSGAuTipCod;
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = AV15TFSGAuTipCod_Sel;
         AV89Seguridad_auditoriads_17_tfsgautipo = AV24TFSGAuTipo;
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = AV25TFSGAuTipo_Sel;
         AV91Seguridad_auditoriads_19_tfsgauusucod = AV22TFSGAuUsuCod;
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = AV23TFSGAuUsuCod_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A337SGAuMod ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                              AV73Seguridad_auditoriads_1_usucod ,
                                              AV74Seguridad_auditoriads_2_sgaumod ,
                                              AV63SGAuFechOperator ,
                                              AV76Seguridad_auditoriads_4_sgaufech ,
                                              AV77Seguridad_auditoriads_5_sgaufech_to ,
                                              AV78Seguridad_auditoriads_6_tfsgaumod_sels.Count ,
                                              AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                              AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                              AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                              AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                              AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                              AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                              AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                              AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                              AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                              AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                              AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                              AV89Seguridad_auditoriads_17_tfsgautipo ,
                                              AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                              AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                              A1849SGAuUsuCod ,
                                              A1846SGAuFech ,
                                              A338SGAuFecha ,
                                              A1843SGAuDocGls ,
                                              A1844SGAuDocNum ,
                                              A1845SGAuDocRef ,
                                              A1847SGAuTipCod ,
                                              A1848SGAuTipo ,
                                              AV75Seguridad_auditoriads_3_sgaudocgls } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV75Seguridad_auditoriads_3_sgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV75Seguridad_auditoriads_3_sgaudocgls), "%", "");
         lV81Seguridad_auditoriads_9_tfsgaudocgls = StringUtil.Concat( StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls), "%", "");
         lV83Seguridad_auditoriads_11_tfsgaudocnum = StringUtil.Concat( StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum), "%", "");
         lV85Seguridad_auditoriads_13_tfsgaudocref = StringUtil.Concat( StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref), "%", "");
         lV87Seguridad_auditoriads_15_tfsgautipcod = StringUtil.Concat( StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod), "%", "");
         lV89Seguridad_auditoriads_17_tfsgautipo = StringUtil.Concat( StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo), "%", "");
         lV91Seguridad_auditoriads_19_tfsgauusucod = StringUtil.Concat( StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod), "%", "");
         /* Using cursor P001N7 */
         pr_default.execute(5, new Object[] {lV75Seguridad_auditoriads_3_sgaudocgls, AV73Seguridad_auditoriads_1_usucod, AV74Seguridad_auditoriads_2_sgaumod, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV76Seguridad_auditoriads_4_sgaufech, AV77Seguridad_auditoriads_5_sgaufech_to, AV79Seguridad_auditoriads_7_tfsgaufecha, AV80Seguridad_auditoriads_8_tfsgaufecha_to, lV81Seguridad_auditoriads_9_tfsgaudocgls, AV82Seguridad_auditoriads_10_tfsgaudocgls_sel, lV83Seguridad_auditoriads_11_tfsgaudocnum, AV84Seguridad_auditoriads_12_tfsgaudocnum_sel, lV85Seguridad_auditoriads_13_tfsgaudocref, AV86Seguridad_auditoriads_14_tfsgaudocref_sel, lV87Seguridad_auditoriads_15_tfsgautipcod, AV88Seguridad_auditoriads_16_tfsgautipcod_sel, lV89Seguridad_auditoriads_17_tfsgautipo, AV90Seguridad_auditoriads_18_tfsgautipo_sel, lV91Seguridad_auditoriads_19_tfsgauusucod, AV92Seguridad_auditoriads_20_tfsgauusucod_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK1N12 = false;
            A1849SGAuUsuCod = P001N7_A1849SGAuUsuCod[0];
            A1848SGAuTipo = P001N7_A1848SGAuTipo[0];
            A1847SGAuTipCod = P001N7_A1847SGAuTipCod[0];
            A1845SGAuDocRef = P001N7_A1845SGAuDocRef[0];
            A1844SGAuDocNum = P001N7_A1844SGAuDocNum[0];
            A338SGAuFecha = P001N7_A338SGAuFecha[0];
            A1846SGAuFech = P001N7_A1846SGAuFech[0];
            A1843SGAuDocGls = P001N7_A1843SGAuDocGls[0];
            A337SGAuMod = P001N7_A337SGAuMod[0];
            AV40count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P001N7_A1849SGAuUsuCod[0], A1849SGAuUsuCod) == 0 ) )
            {
               BRK1N12 = false;
               A338SGAuFecha = P001N7_A338SGAuFecha[0];
               A337SGAuMod = P001N7_A337SGAuMod[0];
               AV40count = (long)(AV40count+1);
               BRK1N12 = true;
               pr_default.readNext(5);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1849SGAuUsuCod)) )
            {
               AV32Option = A1849SGAuUsuCod;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1N12 )
            {
               BRK1N12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV34OptionsJson = "";
         AV37OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV66UsuCod = "";
         AV60SGAuMod = "";
         AV62SGAuDocGls = "";
         AV65SGAuFech = DateTime.MinValue;
         AV64SGAuFech_To = DateTime.MinValue;
         AV67TFSGAuMod_SelsJson = "";
         AV68TFSGAuMod_Sels = new GxSimpleCollection<string>();
         AV12TFSGAuFecha = (DateTime)(DateTime.MinValue);
         AV13TFSGAuFecha_To = (DateTime)(DateTime.MinValue);
         AV20TFSGAuDocGls = "";
         AV21TFSGAuDocGls_Sel = "";
         AV16TFSGAuDocNum = "";
         AV17TFSGAuDocNum_Sel = "";
         AV18TFSGAuDocRef = "";
         AV19TFSGAuDocRef_Sel = "";
         AV14TFSGAuTipCod = "";
         AV15TFSGAuTipCod_Sel = "";
         AV24TFSGAuTipo = "";
         AV25TFSGAuTipo_Sel = "";
         AV22TFSGAuUsuCod = "";
         AV23TFSGAuUsuCod_Sel = "";
         AV73Seguridad_auditoriads_1_usucod = "";
         AV74Seguridad_auditoriads_2_sgaumod = "";
         AV75Seguridad_auditoriads_3_sgaudocgls = "";
         AV76Seguridad_auditoriads_4_sgaufech = DateTime.MinValue;
         AV77Seguridad_auditoriads_5_sgaufech_to = DateTime.MinValue;
         AV78Seguridad_auditoriads_6_tfsgaumod_sels = new GxSimpleCollection<string>();
         AV79Seguridad_auditoriads_7_tfsgaufecha = (DateTime)(DateTime.MinValue);
         AV80Seguridad_auditoriads_8_tfsgaufecha_to = (DateTime)(DateTime.MinValue);
         AV81Seguridad_auditoriads_9_tfsgaudocgls = "";
         AV82Seguridad_auditoriads_10_tfsgaudocgls_sel = "";
         AV83Seguridad_auditoriads_11_tfsgaudocnum = "";
         AV84Seguridad_auditoriads_12_tfsgaudocnum_sel = "";
         AV85Seguridad_auditoriads_13_tfsgaudocref = "";
         AV86Seguridad_auditoriads_14_tfsgaudocref_sel = "";
         AV87Seguridad_auditoriads_15_tfsgautipcod = "";
         AV88Seguridad_auditoriads_16_tfsgautipcod_sel = "";
         AV89Seguridad_auditoriads_17_tfsgautipo = "";
         AV90Seguridad_auditoriads_18_tfsgautipo_sel = "";
         AV91Seguridad_auditoriads_19_tfsgauusucod = "";
         AV92Seguridad_auditoriads_20_tfsgauusucod_sel = "";
         lV75Seguridad_auditoriads_3_sgaudocgls = "";
         scmdbuf = "";
         lV81Seguridad_auditoriads_9_tfsgaudocgls = "";
         lV83Seguridad_auditoriads_11_tfsgaudocnum = "";
         lV85Seguridad_auditoriads_13_tfsgaudocref = "";
         lV87Seguridad_auditoriads_15_tfsgautipcod = "";
         lV89Seguridad_auditoriads_17_tfsgautipo = "";
         lV91Seguridad_auditoriads_19_tfsgauusucod = "";
         A337SGAuMod = "";
         A1849SGAuUsuCod = "";
         A1846SGAuFech = DateTime.MinValue;
         A338SGAuFecha = (DateTime)(DateTime.MinValue);
         A1843SGAuDocGls = "";
         A1844SGAuDocNum = "";
         A1845SGAuDocRef = "";
         A1847SGAuTipCod = "";
         A1848SGAuTipo = "";
         P001N2_A1843SGAuDocGls = new string[] {""} ;
         P001N2_A1848SGAuTipo = new string[] {""} ;
         P001N2_A1847SGAuTipCod = new string[] {""} ;
         P001N2_A1845SGAuDocRef = new string[] {""} ;
         P001N2_A1844SGAuDocNum = new string[] {""} ;
         P001N2_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N2_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N2_A337SGAuMod = new string[] {""} ;
         P001N2_A1849SGAuUsuCod = new string[] {""} ;
         AV32Option = "";
         P001N3_A1844SGAuDocNum = new string[] {""} ;
         P001N3_A1848SGAuTipo = new string[] {""} ;
         P001N3_A1847SGAuTipCod = new string[] {""} ;
         P001N3_A1845SGAuDocRef = new string[] {""} ;
         P001N3_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N3_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N3_A1843SGAuDocGls = new string[] {""} ;
         P001N3_A337SGAuMod = new string[] {""} ;
         P001N3_A1849SGAuUsuCod = new string[] {""} ;
         P001N4_A1845SGAuDocRef = new string[] {""} ;
         P001N4_A1848SGAuTipo = new string[] {""} ;
         P001N4_A1847SGAuTipCod = new string[] {""} ;
         P001N4_A1844SGAuDocNum = new string[] {""} ;
         P001N4_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N4_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N4_A1843SGAuDocGls = new string[] {""} ;
         P001N4_A337SGAuMod = new string[] {""} ;
         P001N4_A1849SGAuUsuCod = new string[] {""} ;
         P001N5_A1847SGAuTipCod = new string[] {""} ;
         P001N5_A1848SGAuTipo = new string[] {""} ;
         P001N5_A1845SGAuDocRef = new string[] {""} ;
         P001N5_A1844SGAuDocNum = new string[] {""} ;
         P001N5_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N5_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N5_A1843SGAuDocGls = new string[] {""} ;
         P001N5_A337SGAuMod = new string[] {""} ;
         P001N5_A1849SGAuUsuCod = new string[] {""} ;
         P001N6_A1848SGAuTipo = new string[] {""} ;
         P001N6_A1847SGAuTipCod = new string[] {""} ;
         P001N6_A1845SGAuDocRef = new string[] {""} ;
         P001N6_A1844SGAuDocNum = new string[] {""} ;
         P001N6_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N6_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N6_A1843SGAuDocGls = new string[] {""} ;
         P001N6_A337SGAuMod = new string[] {""} ;
         P001N6_A1849SGAuUsuCod = new string[] {""} ;
         P001N7_A1849SGAuUsuCod = new string[] {""} ;
         P001N7_A1848SGAuTipo = new string[] {""} ;
         P001N7_A1847SGAuTipCod = new string[] {""} ;
         P001N7_A1845SGAuDocRef = new string[] {""} ;
         P001N7_A1844SGAuDocNum = new string[] {""} ;
         P001N7_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         P001N7_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         P001N7_A1843SGAuDocGls = new string[] {""} ;
         P001N7_A337SGAuMod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.auditoriagetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001N2_A1843SGAuDocGls, P001N2_A1848SGAuTipo, P001N2_A1847SGAuTipCod, P001N2_A1845SGAuDocRef, P001N2_A1844SGAuDocNum, P001N2_A338SGAuFecha, P001N2_A1846SGAuFech, P001N2_A337SGAuMod, P001N2_A1849SGAuUsuCod
               }
               , new Object[] {
               P001N3_A1844SGAuDocNum, P001N3_A1848SGAuTipo, P001N3_A1847SGAuTipCod, P001N3_A1845SGAuDocRef, P001N3_A338SGAuFecha, P001N3_A1846SGAuFech, P001N3_A1843SGAuDocGls, P001N3_A337SGAuMod, P001N3_A1849SGAuUsuCod
               }
               , new Object[] {
               P001N4_A1845SGAuDocRef, P001N4_A1848SGAuTipo, P001N4_A1847SGAuTipCod, P001N4_A1844SGAuDocNum, P001N4_A338SGAuFecha, P001N4_A1846SGAuFech, P001N4_A1843SGAuDocGls, P001N4_A337SGAuMod, P001N4_A1849SGAuUsuCod
               }
               , new Object[] {
               P001N5_A1847SGAuTipCod, P001N5_A1848SGAuTipo, P001N5_A1845SGAuDocRef, P001N5_A1844SGAuDocNum, P001N5_A338SGAuFecha, P001N5_A1846SGAuFech, P001N5_A1843SGAuDocGls, P001N5_A337SGAuMod, P001N5_A1849SGAuUsuCod
               }
               , new Object[] {
               P001N6_A1848SGAuTipo, P001N6_A1847SGAuTipCod, P001N6_A1845SGAuDocRef, P001N6_A1844SGAuDocNum, P001N6_A338SGAuFecha, P001N6_A1846SGAuFech, P001N6_A1843SGAuDocGls, P001N6_A337SGAuMod, P001N6_A1849SGAuUsuCod
               }
               , new Object[] {
               P001N7_A1849SGAuUsuCod, P001N7_A1848SGAuTipo, P001N7_A1847SGAuTipCod, P001N7_A1845SGAuDocRef, P001N7_A1844SGAuDocNum, P001N7_A338SGAuFecha, P001N7_A1846SGAuFech, P001N7_A1843SGAuDocGls, P001N7_A337SGAuMod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV63SGAuFechOperator ;
      private int AV71GXV1 ;
      private int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ;
      private long AV40count ;
      private string AV66UsuCod ;
      private string AV73Seguridad_auditoriads_1_usucod ;
      private string scmdbuf ;
      private DateTime AV12TFSGAuFecha ;
      private DateTime AV13TFSGAuFecha_To ;
      private DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ;
      private DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ;
      private DateTime A338SGAuFecha ;
      private DateTime AV65SGAuFech ;
      private DateTime AV64SGAuFech_To ;
      private DateTime AV76Seguridad_auditoriads_4_sgaufech ;
      private DateTime AV77Seguridad_auditoriads_5_sgaufech_to ;
      private DateTime A1846SGAuFech ;
      private bool returnInSub ;
      private bool BRK1N2 ;
      private bool BRK1N4 ;
      private bool BRK1N6 ;
      private bool BRK1N8 ;
      private bool BRK1N10 ;
      private bool BRK1N12 ;
      private string AV34OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV67TFSGAuMod_SelsJson ;
      private string AV30DDOName ;
      private string AV28SearchTxt ;
      private string AV29SearchTxtTo ;
      private string AV60SGAuMod ;
      private string AV62SGAuDocGls ;
      private string AV20TFSGAuDocGls ;
      private string AV21TFSGAuDocGls_Sel ;
      private string AV16TFSGAuDocNum ;
      private string AV17TFSGAuDocNum_Sel ;
      private string AV18TFSGAuDocRef ;
      private string AV19TFSGAuDocRef_Sel ;
      private string AV14TFSGAuTipCod ;
      private string AV15TFSGAuTipCod_Sel ;
      private string AV24TFSGAuTipo ;
      private string AV25TFSGAuTipo_Sel ;
      private string AV22TFSGAuUsuCod ;
      private string AV23TFSGAuUsuCod_Sel ;
      private string AV74Seguridad_auditoriads_2_sgaumod ;
      private string AV75Seguridad_auditoriads_3_sgaudocgls ;
      private string AV81Seguridad_auditoriads_9_tfsgaudocgls ;
      private string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ;
      private string AV83Seguridad_auditoriads_11_tfsgaudocnum ;
      private string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ;
      private string AV85Seguridad_auditoriads_13_tfsgaudocref ;
      private string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ;
      private string AV87Seguridad_auditoriads_15_tfsgautipcod ;
      private string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ;
      private string AV89Seguridad_auditoriads_17_tfsgautipo ;
      private string AV90Seguridad_auditoriads_18_tfsgautipo_sel ;
      private string AV91Seguridad_auditoriads_19_tfsgauusucod ;
      private string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ;
      private string lV75Seguridad_auditoriads_3_sgaudocgls ;
      private string lV81Seguridad_auditoriads_9_tfsgaudocgls ;
      private string lV83Seguridad_auditoriads_11_tfsgaudocnum ;
      private string lV85Seguridad_auditoriads_13_tfsgaudocref ;
      private string lV87Seguridad_auditoriads_15_tfsgautipcod ;
      private string lV89Seguridad_auditoriads_17_tfsgautipo ;
      private string lV91Seguridad_auditoriads_19_tfsgauusucod ;
      private string A337SGAuMod ;
      private string A1849SGAuUsuCod ;
      private string A1843SGAuDocGls ;
      private string A1844SGAuDocNum ;
      private string A1845SGAuDocRef ;
      private string A1847SGAuTipCod ;
      private string A1848SGAuTipo ;
      private string AV32Option ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001N2_A1843SGAuDocGls ;
      private string[] P001N2_A1848SGAuTipo ;
      private string[] P001N2_A1847SGAuTipCod ;
      private string[] P001N2_A1845SGAuDocRef ;
      private string[] P001N2_A1844SGAuDocNum ;
      private DateTime[] P001N2_A338SGAuFecha ;
      private DateTime[] P001N2_A1846SGAuFech ;
      private string[] P001N2_A337SGAuMod ;
      private string[] P001N2_A1849SGAuUsuCod ;
      private string[] P001N3_A1844SGAuDocNum ;
      private string[] P001N3_A1848SGAuTipo ;
      private string[] P001N3_A1847SGAuTipCod ;
      private string[] P001N3_A1845SGAuDocRef ;
      private DateTime[] P001N3_A338SGAuFecha ;
      private DateTime[] P001N3_A1846SGAuFech ;
      private string[] P001N3_A1843SGAuDocGls ;
      private string[] P001N3_A337SGAuMod ;
      private string[] P001N3_A1849SGAuUsuCod ;
      private string[] P001N4_A1845SGAuDocRef ;
      private string[] P001N4_A1848SGAuTipo ;
      private string[] P001N4_A1847SGAuTipCod ;
      private string[] P001N4_A1844SGAuDocNum ;
      private DateTime[] P001N4_A338SGAuFecha ;
      private DateTime[] P001N4_A1846SGAuFech ;
      private string[] P001N4_A1843SGAuDocGls ;
      private string[] P001N4_A337SGAuMod ;
      private string[] P001N4_A1849SGAuUsuCod ;
      private string[] P001N5_A1847SGAuTipCod ;
      private string[] P001N5_A1848SGAuTipo ;
      private string[] P001N5_A1845SGAuDocRef ;
      private string[] P001N5_A1844SGAuDocNum ;
      private DateTime[] P001N5_A338SGAuFecha ;
      private DateTime[] P001N5_A1846SGAuFech ;
      private string[] P001N5_A1843SGAuDocGls ;
      private string[] P001N5_A337SGAuMod ;
      private string[] P001N5_A1849SGAuUsuCod ;
      private string[] P001N6_A1848SGAuTipo ;
      private string[] P001N6_A1847SGAuTipCod ;
      private string[] P001N6_A1845SGAuDocRef ;
      private string[] P001N6_A1844SGAuDocNum ;
      private DateTime[] P001N6_A338SGAuFecha ;
      private DateTime[] P001N6_A1846SGAuFech ;
      private string[] P001N6_A1843SGAuDocGls ;
      private string[] P001N6_A337SGAuMod ;
      private string[] P001N6_A1849SGAuUsuCod ;
      private string[] P001N7_A1849SGAuUsuCod ;
      private string[] P001N7_A1848SGAuTipo ;
      private string[] P001N7_A1847SGAuTipCod ;
      private string[] P001N7_A1845SGAuDocRef ;
      private string[] P001N7_A1844SGAuDocNum ;
      private DateTime[] P001N7_A338SGAuFecha ;
      private DateTime[] P001N7_A1846SGAuFech ;
      private string[] P001N7_A1843SGAuDocGls ;
      private string[] P001N7_A337SGAuMod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GxSimpleCollection<string> AV68TFSGAuMod_Sels ;
      private GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
   }

   public class auditoriagetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001N2( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[22];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SGAuDocGls], [SGAuTipo], [SGAuTipCod], [SGAuDocRef], [SGAuDocNum], [SGAuFecha], [SGAuFech], [SGAuMod], [SGAuUsuCod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuDocGls]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001N3( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[22];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [SGAuDocNum], [SGAuTipo], [SGAuTipCod], [SGAuDocRef], [SGAuFecha], [SGAuFech], [SGAuDocGls], [SGAuMod], [SGAuUsuCod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuDocNum]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P001N4( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[22];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [SGAuDocRef], [SGAuTipo], [SGAuTipCod], [SGAuDocNum], [SGAuFecha], [SGAuFech], [SGAuDocGls], [SGAuMod], [SGAuUsuCod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuDocRef]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P001N5( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[22];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [SGAuTipCod], [SGAuTipo], [SGAuDocRef], [SGAuDocNum], [SGAuFecha], [SGAuFech], [SGAuDocGls], [SGAuMod], [SGAuUsuCod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuTipCod]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P001N6( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[22];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [SGAuTipo], [SGAuTipCod], [SGAuDocRef], [SGAuDocNum], [SGAuFecha], [SGAuFech], [SGAuDocGls], [SGAuMod], [SGAuUsuCod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuTipo]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P001N7( IGxContext context ,
                                             string A337SGAuMod ,
                                             GxSimpleCollection<string> AV78Seguridad_auditoriads_6_tfsgaumod_sels ,
                                             string AV73Seguridad_auditoriads_1_usucod ,
                                             string AV74Seguridad_auditoriads_2_sgaumod ,
                                             short AV63SGAuFechOperator ,
                                             DateTime AV76Seguridad_auditoriads_4_sgaufech ,
                                             DateTime AV77Seguridad_auditoriads_5_sgaufech_to ,
                                             int AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count ,
                                             DateTime AV79Seguridad_auditoriads_7_tfsgaufecha ,
                                             DateTime AV80Seguridad_auditoriads_8_tfsgaufecha_to ,
                                             string AV82Seguridad_auditoriads_10_tfsgaudocgls_sel ,
                                             string AV81Seguridad_auditoriads_9_tfsgaudocgls ,
                                             string AV84Seguridad_auditoriads_12_tfsgaudocnum_sel ,
                                             string AV83Seguridad_auditoriads_11_tfsgaudocnum ,
                                             string AV86Seguridad_auditoriads_14_tfsgaudocref_sel ,
                                             string AV85Seguridad_auditoriads_13_tfsgaudocref ,
                                             string AV88Seguridad_auditoriads_16_tfsgautipcod_sel ,
                                             string AV87Seguridad_auditoriads_15_tfsgautipcod ,
                                             string AV90Seguridad_auditoriads_18_tfsgautipo_sel ,
                                             string AV89Seguridad_auditoriads_17_tfsgautipo ,
                                             string AV92Seguridad_auditoriads_20_tfsgauusucod_sel ,
                                             string AV91Seguridad_auditoriads_19_tfsgauusucod ,
                                             string A1849SGAuUsuCod ,
                                             DateTime A1846SGAuFech ,
                                             DateTime A338SGAuFecha ,
                                             string A1843SGAuDocGls ,
                                             string A1844SGAuDocNum ,
                                             string A1845SGAuDocRef ,
                                             string A1847SGAuTipCod ,
                                             string A1848SGAuTipo ,
                                             string AV75Seguridad_auditoriads_3_sgaudocgls )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[22];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [SGAuUsuCod], [SGAuTipo], [SGAuTipCod], [SGAuDocRef], [SGAuDocNum], [SGAuFecha], [SGAuFech], [SGAuDocGls], [SGAuMod] FROM [SGAUDITORIA]";
         AddWhere(sWhereString, "([SGAuDocGls] like '%' + @lV75Seguridad_auditoriads_3_sgaudocgls + '%')");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_auditoriads_1_usucod)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV73Seguridad_auditoriads_1_usucod)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_auditoriads_2_sgaumod)) )
         {
            AddWhere(sWhereString, "([SGAuMod] = @AV74Seguridad_auditoriads_2_sgaumod)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( ( AV63SGAuFechOperator == 0 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] = @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ( AV63SGAuFechOperator == 1 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] < @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( ( AV63SGAuFechOperator == 2 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] > @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV76Seguridad_auditoriads_4_sgaufech) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] >= @AV76Seguridad_auditoriads_4_sgaufech)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( ( AV63SGAuFechOperator == 3 ) && ( ! (DateTime.MinValue==AV77Seguridad_auditoriads_5_sgaufech_to) ) )
         {
            AddWhere(sWhereString, "([SGAuFech] <= @AV77Seguridad_auditoriads_5_sgaufech_to)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( AV78Seguridad_auditoriads_6_tfsgaumod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Seguridad_auditoriads_6_tfsgaumod_sels, "[SGAuMod] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV79Seguridad_auditoriads_7_tfsgaufecha) )
         {
            AddWhere(sWhereString, "([SGAuFecha] >= @AV79Seguridad_auditoriads_7_tfsgaufecha)");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_auditoriads_8_tfsgaufecha_to) )
         {
            AddWhere(sWhereString, "([SGAuFecha] <= @AV80Seguridad_auditoriads_8_tfsgaufecha_to)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_auditoriads_9_tfsgaudocgls)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] like @lV81Seguridad_auditoriads_9_tfsgaudocgls)");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocGls] = @AV82Seguridad_auditoriads_10_tfsgaudocgls_sel)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_auditoriads_11_tfsgaudocnum)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] like @lV83Seguridad_auditoriads_11_tfsgaudocnum)");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocNum] = @AV84Seguridad_auditoriads_12_tfsgaudocnum_sel)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Seguridad_auditoriads_13_tfsgaudocref)) ) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] like @lV85Seguridad_auditoriads_13_tfsgaudocref)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Seguridad_auditoriads_14_tfsgaudocref_sel)) )
         {
            AddWhere(sWhereString, "([SGAuDocRef] = @AV86Seguridad_auditoriads_14_tfsgaudocref_sel)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Seguridad_auditoriads_15_tfsgautipcod)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] like @lV87Seguridad_auditoriads_15_tfsgautipcod)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Seguridad_auditoriads_16_tfsgautipcod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipCod] = @AV88Seguridad_auditoriads_16_tfsgautipcod_sel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Seguridad_auditoriads_17_tfsgautipo)) ) )
         {
            AddWhere(sWhereString, "([SGAuTipo] like @lV89Seguridad_auditoriads_17_tfsgautipo)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Seguridad_auditoriads_18_tfsgautipo_sel)) )
         {
            AddWhere(sWhereString, "([SGAuTipo] = @AV90Seguridad_auditoriads_18_tfsgautipo_sel)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Seguridad_auditoriads_19_tfsgauusucod)) ) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] like @lV91Seguridad_auditoriads_19_tfsgauusucod)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Seguridad_auditoriads_20_tfsgauusucod_sel)) )
         {
            AddWhere(sWhereString, "([SGAuUsuCod] = @AV92Seguridad_auditoriads_20_tfsgauusucod_sel)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SGAuUsuCod]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P001N2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
               case 1 :
                     return conditional_P001N3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
               case 2 :
                     return conditional_P001N4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
               case 3 :
                     return conditional_P001N5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
               case 4 :
                     return conditional_P001N6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
               case 5 :
                     return conditional_P001N7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] );
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
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001N2;
          prmP001N2 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001N3;
          prmP001N3 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001N4;
          prmP001N4 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001N5;
          prmP001N5 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001N6;
          prmP001N6 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001N7;
          prmP001N7 = new Object[] {
          new ParDef("@lV75Seguridad_auditoriads_3_sgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_auditoriads_1_usucod",GXType.NChar,10,0) ,
          new ParDef("@AV74Seguridad_auditoriads_2_sgaumod",GXType.NVarChar,5,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV76Seguridad_auditoriads_4_sgaufech",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_auditoriads_5_sgaufech_to",GXType.Date,8,0) ,
          new ParDef("@AV79Seguridad_auditoriads_7_tfsgaufecha",GXType.DateTime,8,5) ,
          new ParDef("@AV80Seguridad_auditoriads_8_tfsgaufecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV81Seguridad_auditoriads_9_tfsgaudocgls",GXType.NVarChar,100,0) ,
          new ParDef("@AV82Seguridad_auditoriads_10_tfsgaudocgls_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV83Seguridad_auditoriads_11_tfsgaudocnum",GXType.NVarChar,20,0) ,
          new ParDef("@AV84Seguridad_auditoriads_12_tfsgaudocnum_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV85Seguridad_auditoriads_13_tfsgaudocref",GXType.NVarChar,20,0) ,
          new ParDef("@AV86Seguridad_auditoriads_14_tfsgaudocref_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV87Seguridad_auditoriads_15_tfsgautipcod",GXType.NVarChar,5,0) ,
          new ParDef("@AV88Seguridad_auditoriads_16_tfsgautipcod_sel",GXType.NVarChar,5,0) ,
          new ParDef("@lV89Seguridad_auditoriads_17_tfsgautipo",GXType.NVarChar,20,0) ,
          new ParDef("@AV90Seguridad_auditoriads_18_tfsgautipo_sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV91Seguridad_auditoriads_19_tfsgauusucod",GXType.NVarChar,10,0) ,
          new ParDef("@AV92Seguridad_auditoriads_20_tfsgauusucod_sel",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001N7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001N7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

}
