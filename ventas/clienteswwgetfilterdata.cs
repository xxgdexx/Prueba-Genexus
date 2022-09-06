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
namespace GeneXus.Programs.ventas {
   public class clienteswwgetfilterdata : GXProcedure
   {
      public clienteswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clienteswwgetfilterdata( IGxContext context )
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
         this.AV60DDOName = aP0_DDOName;
         this.AV58SearchTxt = aP1_SearchTxt;
         this.AV59SearchTxtTo = aP2_SearchTxtTo;
         this.AV64OptionsJson = "" ;
         this.AV67OptionsDescJson = "" ;
         this.AV69OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV64OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV69OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         clienteswwgetfilterdata objclienteswwgetfilterdata;
         objclienteswwgetfilterdata = new clienteswwgetfilterdata();
         objclienteswwgetfilterdata.AV60DDOName = aP0_DDOName;
         objclienteswwgetfilterdata.AV58SearchTxt = aP1_SearchTxt;
         objclienteswwgetfilterdata.AV59SearchTxtTo = aP2_SearchTxtTo;
         objclienteswwgetfilterdata.AV64OptionsJson = "" ;
         objclienteswwgetfilterdata.AV67OptionsDescJson = "" ;
         objclienteswwgetfilterdata.AV69OptionIndexesJson = "" ;
         objclienteswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objclienteswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclienteswwgetfilterdata);
         aP3_OptionsJson=this.AV64OptionsJson;
         aP4_OptionsDescJson=this.AV67OptionsDescJson;
         aP5_OptionIndexesJson=this.AV69OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clienteswwgetfilterdata)stateInfo).executePrivate();
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
         AV63Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV66OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV68OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLICOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCLICODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIDIROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_ESTCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADESTCODOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_PAICOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPAICODOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLITEL1") == 0 )
         {
            /* Execute user subroutine: 'LOADCLITEL1OPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLITEL2") == 0 )
         {
            /* Execute user subroutine: 'LOADCLITEL2OPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIFAX") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIFAXOPTIONS' */
            S191 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLICEL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLICELOPTIONS' */
            S201 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIEMA") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIEMAOPTIONS' */
            S211 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIWEB") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIWEBOPTIONS' */
            S221 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIVENDDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIVENDDSCOPTIONS' */
            S231 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF1") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF1OPTIONS' */
            S241 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF2") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF2OPTIONS' */
            S251 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF3") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF3OPTIONS' */
            S261 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF4") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF4OPTIONS' */
            S271 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF5") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF5OPTIONS' */
            S281 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF6") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF6OPTIONS' */
            S291 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV60DDOName), "DDO_CLIREF7") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIREF7OPTIONS' */
            S301 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV64OptionsJson = AV63Options.ToJSonString(false);
         AV67OptionsDescJson = AV66OptionsDesc.ToJSonString(false);
         AV69OptionIndexesJson = AV68OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV71Session.Get("Ventas.ClientesWWGridState"), "") == 0 )
         {
            AV73GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Ventas.ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV73GridState.FromXml(AV71Session.Get("Ventas.ClientesWWGridState"), null, "", "");
         }
         AV92GXV1 = 1;
         while ( AV92GXV1 <= AV73GridState.gxTpr_Filtervalues.Count )
         {
            AV74GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV73GridState.gxTpr_Filtervalues.Item(AV92GXV1));
            if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV10TFCliCod = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV11TFCliCod_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIDSC") == 0 )
            {
               AV12TFCliDsc = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIDSC_SEL") == 0 )
            {
               AV13TFCliDsc_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIDIR") == 0 )
            {
               AV14TFCliDir = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIDIR_SEL") == 0 )
            {
               AV15TFCliDir_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV16TFEstCod = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV17TFEstCod_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV18TFPaiCod = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV19TFPaiCod_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLITEL1") == 0 )
            {
               AV20TFCliTel1 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLITEL1_SEL") == 0 )
            {
               AV21TFCliTel1_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLITEL2") == 0 )
            {
               AV22TFCliTel2 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLITEL2_SEL") == 0 )
            {
               AV23TFCliTel2_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIFAX") == 0 )
            {
               AV24TFCliFax = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIFAX_SEL") == 0 )
            {
               AV25TFCliFax_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLICEL") == 0 )
            {
               AV26TFCliCel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLICEL_SEL") == 0 )
            {
               AV27TFCliCel_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIEMA") == 0 )
            {
               AV28TFCliEma = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIEMA_SEL") == 0 )
            {
               AV29TFCliEma_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIWEB") == 0 )
            {
               AV30TFCliWeb = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIWEB_SEL") == 0 )
            {
               AV31TFCliWeb_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV32TFTipCCod = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, "."));
               AV33TFTipCCod_To = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLISTS") == 0 )
            {
               AV34TFCliSts = (short)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, "."));
               AV35TFCliSts_To = (short)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV36TFConpcod = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, "."));
               AV37TFConpcod_To = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLILIM") == 0 )
            {
               AV38TFCliLim = NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, ".");
               AV39TFCliLim_To = NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIVEND") == 0 )
            {
               AV40TFCliVend = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Value, "."));
               AV41TFCliVend_To = (int)(NumberUtil.Val( AV74GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC") == 0 )
            {
               AV42TFCliVendDsc = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIVENDDSC_SEL") == 0 )
            {
               AV43TFCliVendDsc_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF1") == 0 )
            {
               AV44TFCliRef1 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF1_SEL") == 0 )
            {
               AV45TFCliRef1_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF2") == 0 )
            {
               AV46TFCliRef2 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF2_SEL") == 0 )
            {
               AV47TFCliRef2_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF3") == 0 )
            {
               AV48TFCliRef3 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF3_SEL") == 0 )
            {
               AV49TFCliRef3_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF4") == 0 )
            {
               AV50TFCliRef4 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF4_SEL") == 0 )
            {
               AV51TFCliRef4_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF5") == 0 )
            {
               AV52TFCliRef5 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF5_SEL") == 0 )
            {
               AV53TFCliRef5_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF6") == 0 )
            {
               AV54TFCliRef6 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF6_SEL") == 0 )
            {
               AV55TFCliRef6_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF7") == 0 )
            {
               AV56TFCliRef7 = AV74GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV74GridStateFilterValue.gxTpr_Name, "TFCLIREF7_SEL") == 0 )
            {
               AV57TFCliRef7_Sel = AV74GridStateFilterValue.gxTpr_Value;
            }
            AV92GXV1 = (int)(AV92GXV1+1);
         }
         if ( AV73GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV75GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV73GridState.gxTpr_Dynamicfilters.Item(1));
            AV76DynamicFiltersSelector1 = AV75GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV76DynamicFiltersSelector1, "CLIDSC") == 0 )
            {
               AV77DynamicFiltersOperator1 = AV75GridStateDynamicFilter.gxTpr_Operator;
               AV78CliDsc1 = AV75GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76DynamicFiltersSelector1, "CLIVENDDSC") == 0 )
            {
               AV77DynamicFiltersOperator1 = AV75GridStateDynamicFilter.gxTpr_Operator;
               AV79CliVendDsc1 = AV75GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV73GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV80DynamicFiltersEnabled2 = true;
               AV75GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV73GridState.gxTpr_Dynamicfilters.Item(2));
               AV81DynamicFiltersSelector2 = AV75GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV81DynamicFiltersSelector2, "CLIDSC") == 0 )
               {
                  AV82DynamicFiltersOperator2 = AV75GridStateDynamicFilter.gxTpr_Operator;
                  AV83CliDsc2 = AV75GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV81DynamicFiltersSelector2, "CLIVENDDSC") == 0 )
               {
                  AV82DynamicFiltersOperator2 = AV75GridStateDynamicFilter.gxTpr_Operator;
                  AV84CliVendDsc2 = AV75GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV73GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV85DynamicFiltersEnabled3 = true;
                  AV75GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV73GridState.gxTpr_Dynamicfilters.Item(3));
                  AV86DynamicFiltersSelector3 = AV75GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV86DynamicFiltersSelector3, "CLIDSC") == 0 )
                  {
                     AV87DynamicFiltersOperator3 = AV75GridStateDynamicFilter.gxTpr_Operator;
                     AV88CliDsc3 = AV75GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV86DynamicFiltersSelector3, "CLIVENDDSC") == 0 )
                  {
                     AV87DynamicFiltersOperator3 = AV75GridStateDynamicFilter.gxTpr_Operator;
                     AV89CliVendDsc3 = AV75GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLICODOPTIONS' Routine */
         returnInSub = false;
         AV10TFCliCod = AV58SearchTxt;
         AV11TFCliCod_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA2 */
         pr_default.execute(0, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A624CliRef7 = P00GA2_A624CliRef7[0];
            A623CliRef6 = P00GA2_A623CliRef6[0];
            A622CliRef5 = P00GA2_A622CliRef5[0];
            A621CliRef4 = P00GA2_A621CliRef4[0];
            A620CliRef3 = P00GA2_A620CliRef3[0];
            A619CliRef2 = P00GA2_A619CliRef2[0];
            A618CliRef1 = P00GA2_A618CliRef1[0];
            A160CliVend = P00GA2_A160CliVend[0];
            A613CliLim = P00GA2_A613CliLim[0];
            A137Conpcod = P00GA2_A137Conpcod[0];
            A627CliSts = P00GA2_A627CliSts[0];
            A159TipCCod = P00GA2_A159TipCCod[0];
            A637CliWeb = P00GA2_A637CliWeb[0];
            A609CliEma = P00GA2_A609CliEma[0];
            A575CliCel = P00GA2_A575CliCel[0];
            A611CliFax = P00GA2_A611CliFax[0];
            A630CliTel2 = P00GA2_A630CliTel2[0];
            A629CliTel1 = P00GA2_A629CliTel1[0];
            A139PaiCod = P00GA2_A139PaiCod[0];
            A140EstCod = P00GA2_A140EstCod[0];
            A596CliDir = P00GA2_A596CliDir[0];
            A45CliCod = P00GA2_A45CliCod[0];
            A635CliVendDsc = P00GA2_A635CliVendDsc[0];
            A161CliDsc = P00GA2_A161CliDsc[0];
            A635CliVendDsc = P00GA2_A635CliVendDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) )
            {
               AV62Option = A45CliCod;
               AV63Options.Add(AV62Option, 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCliDsc = AV58SearchTxt;
         AV13TFCliDsc_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA3 */
         pr_default.execute(1, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKGA3 = false;
            A161CliDsc = P00GA3_A161CliDsc[0];
            A624CliRef7 = P00GA3_A624CliRef7[0];
            A623CliRef6 = P00GA3_A623CliRef6[0];
            A622CliRef5 = P00GA3_A622CliRef5[0];
            A621CliRef4 = P00GA3_A621CliRef4[0];
            A620CliRef3 = P00GA3_A620CliRef3[0];
            A619CliRef2 = P00GA3_A619CliRef2[0];
            A618CliRef1 = P00GA3_A618CliRef1[0];
            A160CliVend = P00GA3_A160CliVend[0];
            A613CliLim = P00GA3_A613CliLim[0];
            A137Conpcod = P00GA3_A137Conpcod[0];
            A627CliSts = P00GA3_A627CliSts[0];
            A159TipCCod = P00GA3_A159TipCCod[0];
            A637CliWeb = P00GA3_A637CliWeb[0];
            A609CliEma = P00GA3_A609CliEma[0];
            A575CliCel = P00GA3_A575CliCel[0];
            A611CliFax = P00GA3_A611CliFax[0];
            A630CliTel2 = P00GA3_A630CliTel2[0];
            A629CliTel1 = P00GA3_A629CliTel1[0];
            A139PaiCod = P00GA3_A139PaiCod[0];
            A140EstCod = P00GA3_A140EstCod[0];
            A596CliDir = P00GA3_A596CliDir[0];
            A45CliCod = P00GA3_A45CliCod[0];
            A635CliVendDsc = P00GA3_A635CliVendDsc[0];
            A635CliVendDsc = P00GA3_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00GA3_A161CliDsc[0], A161CliDsc) == 0 ) )
            {
               BRKGA3 = false;
               A45CliCod = P00GA3_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A161CliDsc)) )
            {
               AV62Option = A161CliDsc;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA3 )
            {
               BRKGA3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIDIROPTIONS' Routine */
         returnInSub = false;
         AV14TFCliDir = AV58SearchTxt;
         AV15TFCliDir_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA4 */
         pr_default.execute(2, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKGA5 = false;
            A596CliDir = P00GA4_A596CliDir[0];
            A624CliRef7 = P00GA4_A624CliRef7[0];
            A623CliRef6 = P00GA4_A623CliRef6[0];
            A622CliRef5 = P00GA4_A622CliRef5[0];
            A621CliRef4 = P00GA4_A621CliRef4[0];
            A620CliRef3 = P00GA4_A620CliRef3[0];
            A619CliRef2 = P00GA4_A619CliRef2[0];
            A618CliRef1 = P00GA4_A618CliRef1[0];
            A160CliVend = P00GA4_A160CliVend[0];
            A613CliLim = P00GA4_A613CliLim[0];
            A137Conpcod = P00GA4_A137Conpcod[0];
            A627CliSts = P00GA4_A627CliSts[0];
            A159TipCCod = P00GA4_A159TipCCod[0];
            A637CliWeb = P00GA4_A637CliWeb[0];
            A609CliEma = P00GA4_A609CliEma[0];
            A575CliCel = P00GA4_A575CliCel[0];
            A611CliFax = P00GA4_A611CliFax[0];
            A630CliTel2 = P00GA4_A630CliTel2[0];
            A629CliTel1 = P00GA4_A629CliTel1[0];
            A139PaiCod = P00GA4_A139PaiCod[0];
            A140EstCod = P00GA4_A140EstCod[0];
            A45CliCod = P00GA4_A45CliCod[0];
            A635CliVendDsc = P00GA4_A635CliVendDsc[0];
            A161CliDsc = P00GA4_A161CliDsc[0];
            A635CliVendDsc = P00GA4_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00GA4_A596CliDir[0], A596CliDir) == 0 ) )
            {
               BRKGA5 = false;
               A45CliCod = P00GA4_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA5 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A596CliDir)) )
            {
               AV62Option = A596CliDir;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA5 )
            {
               BRKGA5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADESTCODOPTIONS' Routine */
         returnInSub = false;
         AV16TFEstCod = AV58SearchTxt;
         AV17TFEstCod_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA5 */
         pr_default.execute(3, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKGA7 = false;
            A140EstCod = P00GA5_A140EstCod[0];
            A624CliRef7 = P00GA5_A624CliRef7[0];
            A623CliRef6 = P00GA5_A623CliRef6[0];
            A622CliRef5 = P00GA5_A622CliRef5[0];
            A621CliRef4 = P00GA5_A621CliRef4[0];
            A620CliRef3 = P00GA5_A620CliRef3[0];
            A619CliRef2 = P00GA5_A619CliRef2[0];
            A618CliRef1 = P00GA5_A618CliRef1[0];
            A160CliVend = P00GA5_A160CliVend[0];
            A613CliLim = P00GA5_A613CliLim[0];
            A137Conpcod = P00GA5_A137Conpcod[0];
            A627CliSts = P00GA5_A627CliSts[0];
            A159TipCCod = P00GA5_A159TipCCod[0];
            A637CliWeb = P00GA5_A637CliWeb[0];
            A609CliEma = P00GA5_A609CliEma[0];
            A575CliCel = P00GA5_A575CliCel[0];
            A611CliFax = P00GA5_A611CliFax[0];
            A630CliTel2 = P00GA5_A630CliTel2[0];
            A629CliTel1 = P00GA5_A629CliTel1[0];
            A139PaiCod = P00GA5_A139PaiCod[0];
            A596CliDir = P00GA5_A596CliDir[0];
            A45CliCod = P00GA5_A45CliCod[0];
            A635CliVendDsc = P00GA5_A635CliVendDsc[0];
            A161CliDsc = P00GA5_A161CliDsc[0];
            A635CliVendDsc = P00GA5_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00GA5_A140EstCod[0], A140EstCod) == 0 ) )
            {
               BRKGA7 = false;
               A45CliCod = P00GA5_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA7 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
            {
               AV62Option = A140EstCod;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA7 )
            {
               BRKGA7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPAICODOPTIONS' Routine */
         returnInSub = false;
         AV18TFPaiCod = AV58SearchTxt;
         AV19TFPaiCod_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA6 */
         pr_default.execute(4, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKGA9 = false;
            A139PaiCod = P00GA6_A139PaiCod[0];
            A624CliRef7 = P00GA6_A624CliRef7[0];
            A623CliRef6 = P00GA6_A623CliRef6[0];
            A622CliRef5 = P00GA6_A622CliRef5[0];
            A621CliRef4 = P00GA6_A621CliRef4[0];
            A620CliRef3 = P00GA6_A620CliRef3[0];
            A619CliRef2 = P00GA6_A619CliRef2[0];
            A618CliRef1 = P00GA6_A618CliRef1[0];
            A160CliVend = P00GA6_A160CliVend[0];
            A613CliLim = P00GA6_A613CliLim[0];
            A137Conpcod = P00GA6_A137Conpcod[0];
            A627CliSts = P00GA6_A627CliSts[0];
            A159TipCCod = P00GA6_A159TipCCod[0];
            A637CliWeb = P00GA6_A637CliWeb[0];
            A609CliEma = P00GA6_A609CliEma[0];
            A575CliCel = P00GA6_A575CliCel[0];
            A611CliFax = P00GA6_A611CliFax[0];
            A630CliTel2 = P00GA6_A630CliTel2[0];
            A629CliTel1 = P00GA6_A629CliTel1[0];
            A140EstCod = P00GA6_A140EstCod[0];
            A596CliDir = P00GA6_A596CliDir[0];
            A45CliCod = P00GA6_A45CliCod[0];
            A635CliVendDsc = P00GA6_A635CliVendDsc[0];
            A161CliDsc = P00GA6_A161CliDsc[0];
            A635CliVendDsc = P00GA6_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00GA6_A139PaiCod[0], A139PaiCod) == 0 ) )
            {
               BRKGA9 = false;
               A45CliCod = P00GA6_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA9 = true;
               pr_default.readNext(4);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
            {
               AV62Option = A139PaiCod;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA9 )
            {
               BRKGA9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADCLITEL1OPTIONS' Routine */
         returnInSub = false;
         AV20TFCliTel1 = AV58SearchTxt;
         AV21TFCliTel1_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA7 */
         pr_default.execute(5, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKGA11 = false;
            A629CliTel1 = P00GA7_A629CliTel1[0];
            A624CliRef7 = P00GA7_A624CliRef7[0];
            A623CliRef6 = P00GA7_A623CliRef6[0];
            A622CliRef5 = P00GA7_A622CliRef5[0];
            A621CliRef4 = P00GA7_A621CliRef4[0];
            A620CliRef3 = P00GA7_A620CliRef3[0];
            A619CliRef2 = P00GA7_A619CliRef2[0];
            A618CliRef1 = P00GA7_A618CliRef1[0];
            A160CliVend = P00GA7_A160CliVend[0];
            A613CliLim = P00GA7_A613CliLim[0];
            A137Conpcod = P00GA7_A137Conpcod[0];
            A627CliSts = P00GA7_A627CliSts[0];
            A159TipCCod = P00GA7_A159TipCCod[0];
            A637CliWeb = P00GA7_A637CliWeb[0];
            A609CliEma = P00GA7_A609CliEma[0];
            A575CliCel = P00GA7_A575CliCel[0];
            A611CliFax = P00GA7_A611CliFax[0];
            A630CliTel2 = P00GA7_A630CliTel2[0];
            A139PaiCod = P00GA7_A139PaiCod[0];
            A140EstCod = P00GA7_A140EstCod[0];
            A596CliDir = P00GA7_A596CliDir[0];
            A45CliCod = P00GA7_A45CliCod[0];
            A635CliVendDsc = P00GA7_A635CliVendDsc[0];
            A161CliDsc = P00GA7_A161CliDsc[0];
            A635CliVendDsc = P00GA7_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00GA7_A629CliTel1[0], A629CliTel1) == 0 ) )
            {
               BRKGA11 = false;
               A45CliCod = P00GA7_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA11 = true;
               pr_default.readNext(5);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A629CliTel1)) )
            {
               AV62Option = A629CliTel1;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA11 )
            {
               BRKGA11 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADCLITEL2OPTIONS' Routine */
         returnInSub = false;
         AV22TFCliTel2 = AV58SearchTxt;
         AV23TFCliTel2_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA8 */
         pr_default.execute(6, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKGA13 = false;
            A630CliTel2 = P00GA8_A630CliTel2[0];
            A624CliRef7 = P00GA8_A624CliRef7[0];
            A623CliRef6 = P00GA8_A623CliRef6[0];
            A622CliRef5 = P00GA8_A622CliRef5[0];
            A621CliRef4 = P00GA8_A621CliRef4[0];
            A620CliRef3 = P00GA8_A620CliRef3[0];
            A619CliRef2 = P00GA8_A619CliRef2[0];
            A618CliRef1 = P00GA8_A618CliRef1[0];
            A160CliVend = P00GA8_A160CliVend[0];
            A613CliLim = P00GA8_A613CliLim[0];
            A137Conpcod = P00GA8_A137Conpcod[0];
            A627CliSts = P00GA8_A627CliSts[0];
            A159TipCCod = P00GA8_A159TipCCod[0];
            A637CliWeb = P00GA8_A637CliWeb[0];
            A609CliEma = P00GA8_A609CliEma[0];
            A575CliCel = P00GA8_A575CliCel[0];
            A611CliFax = P00GA8_A611CliFax[0];
            A629CliTel1 = P00GA8_A629CliTel1[0];
            A139PaiCod = P00GA8_A139PaiCod[0];
            A140EstCod = P00GA8_A140EstCod[0];
            A596CliDir = P00GA8_A596CliDir[0];
            A45CliCod = P00GA8_A45CliCod[0];
            A635CliVendDsc = P00GA8_A635CliVendDsc[0];
            A161CliDsc = P00GA8_A161CliDsc[0];
            A635CliVendDsc = P00GA8_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P00GA8_A630CliTel2[0], A630CliTel2) == 0 ) )
            {
               BRKGA13 = false;
               A45CliCod = P00GA8_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA13 = true;
               pr_default.readNext(6);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A630CliTel2)) )
            {
               AV62Option = A630CliTel2;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA13 )
            {
               BRKGA13 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADCLIFAXOPTIONS' Routine */
         returnInSub = false;
         AV24TFCliFax = AV58SearchTxt;
         AV25TFCliFax_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA9 */
         pr_default.execute(7, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRKGA15 = false;
            A611CliFax = P00GA9_A611CliFax[0];
            A624CliRef7 = P00GA9_A624CliRef7[0];
            A623CliRef6 = P00GA9_A623CliRef6[0];
            A622CliRef5 = P00GA9_A622CliRef5[0];
            A621CliRef4 = P00GA9_A621CliRef4[0];
            A620CliRef3 = P00GA9_A620CliRef3[0];
            A619CliRef2 = P00GA9_A619CliRef2[0];
            A618CliRef1 = P00GA9_A618CliRef1[0];
            A160CliVend = P00GA9_A160CliVend[0];
            A613CliLim = P00GA9_A613CliLim[0];
            A137Conpcod = P00GA9_A137Conpcod[0];
            A627CliSts = P00GA9_A627CliSts[0];
            A159TipCCod = P00GA9_A159TipCCod[0];
            A637CliWeb = P00GA9_A637CliWeb[0];
            A609CliEma = P00GA9_A609CliEma[0];
            A575CliCel = P00GA9_A575CliCel[0];
            A630CliTel2 = P00GA9_A630CliTel2[0];
            A629CliTel1 = P00GA9_A629CliTel1[0];
            A139PaiCod = P00GA9_A139PaiCod[0];
            A140EstCod = P00GA9_A140EstCod[0];
            A596CliDir = P00GA9_A596CliDir[0];
            A45CliCod = P00GA9_A45CliCod[0];
            A635CliVendDsc = P00GA9_A635CliVendDsc[0];
            A161CliDsc = P00GA9_A161CliDsc[0];
            A635CliVendDsc = P00GA9_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P00GA9_A611CliFax[0], A611CliFax) == 0 ) )
            {
               BRKGA15 = false;
               A45CliCod = P00GA9_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA15 = true;
               pr_default.readNext(7);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A611CliFax)) )
            {
               AV62Option = A611CliFax;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA15 )
            {
               BRKGA15 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S201( )
      {
         /* 'LOADCLICELOPTIONS' Routine */
         returnInSub = false;
         AV26TFCliCel = AV58SearchTxt;
         AV27TFCliCel_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA10 */
         pr_default.execute(8, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRKGA17 = false;
            A575CliCel = P00GA10_A575CliCel[0];
            A624CliRef7 = P00GA10_A624CliRef7[0];
            A623CliRef6 = P00GA10_A623CliRef6[0];
            A622CliRef5 = P00GA10_A622CliRef5[0];
            A621CliRef4 = P00GA10_A621CliRef4[0];
            A620CliRef3 = P00GA10_A620CliRef3[0];
            A619CliRef2 = P00GA10_A619CliRef2[0];
            A618CliRef1 = P00GA10_A618CliRef1[0];
            A160CliVend = P00GA10_A160CliVend[0];
            A613CliLim = P00GA10_A613CliLim[0];
            A137Conpcod = P00GA10_A137Conpcod[0];
            A627CliSts = P00GA10_A627CliSts[0];
            A159TipCCod = P00GA10_A159TipCCod[0];
            A637CliWeb = P00GA10_A637CliWeb[0];
            A609CliEma = P00GA10_A609CliEma[0];
            A611CliFax = P00GA10_A611CliFax[0];
            A630CliTel2 = P00GA10_A630CliTel2[0];
            A629CliTel1 = P00GA10_A629CliTel1[0];
            A139PaiCod = P00GA10_A139PaiCod[0];
            A140EstCod = P00GA10_A140EstCod[0];
            A596CliDir = P00GA10_A596CliDir[0];
            A45CliCod = P00GA10_A45CliCod[0];
            A635CliVendDsc = P00GA10_A635CliVendDsc[0];
            A161CliDsc = P00GA10_A161CliDsc[0];
            A635CliVendDsc = P00GA10_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P00GA10_A575CliCel[0], A575CliCel) == 0 ) )
            {
               BRKGA17 = false;
               A45CliCod = P00GA10_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA17 = true;
               pr_default.readNext(8);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A575CliCel)) )
            {
               AV62Option = A575CliCel;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA17 )
            {
               BRKGA17 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
      }

      protected void S211( )
      {
         /* 'LOADCLIEMAOPTIONS' Routine */
         returnInSub = false;
         AV28TFCliEma = AV58SearchTxt;
         AV29TFCliEma_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(9, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA11 */
         pr_default.execute(9, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(9) != 101) )
         {
            BRKGA19 = false;
            A609CliEma = P00GA11_A609CliEma[0];
            A624CliRef7 = P00GA11_A624CliRef7[0];
            A623CliRef6 = P00GA11_A623CliRef6[0];
            A622CliRef5 = P00GA11_A622CliRef5[0];
            A621CliRef4 = P00GA11_A621CliRef4[0];
            A620CliRef3 = P00GA11_A620CliRef3[0];
            A619CliRef2 = P00GA11_A619CliRef2[0];
            A618CliRef1 = P00GA11_A618CliRef1[0];
            A160CliVend = P00GA11_A160CliVend[0];
            A613CliLim = P00GA11_A613CliLim[0];
            A137Conpcod = P00GA11_A137Conpcod[0];
            A627CliSts = P00GA11_A627CliSts[0];
            A159TipCCod = P00GA11_A159TipCCod[0];
            A637CliWeb = P00GA11_A637CliWeb[0];
            A575CliCel = P00GA11_A575CliCel[0];
            A611CliFax = P00GA11_A611CliFax[0];
            A630CliTel2 = P00GA11_A630CliTel2[0];
            A629CliTel1 = P00GA11_A629CliTel1[0];
            A139PaiCod = P00GA11_A139PaiCod[0];
            A140EstCod = P00GA11_A140EstCod[0];
            A596CliDir = P00GA11_A596CliDir[0];
            A45CliCod = P00GA11_A45CliCod[0];
            A635CliVendDsc = P00GA11_A635CliVendDsc[0];
            A161CliDsc = P00GA11_A161CliDsc[0];
            A635CliVendDsc = P00GA11_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(P00GA11_A609CliEma[0], A609CliEma) == 0 ) )
            {
               BRKGA19 = false;
               A45CliCod = P00GA11_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA19 = true;
               pr_default.readNext(9);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A609CliEma)) )
            {
               AV62Option = A609CliEma;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA19 )
            {
               BRKGA19 = true;
               pr_default.readNext(9);
            }
         }
         pr_default.close(9);
      }

      protected void S221( )
      {
         /* 'LOADCLIWEBOPTIONS' Routine */
         returnInSub = false;
         AV30TFCliWeb = AV58SearchTxt;
         AV31TFCliWeb_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(10, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA12 */
         pr_default.execute(10, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(10) != 101) )
         {
            BRKGA21 = false;
            A637CliWeb = P00GA12_A637CliWeb[0];
            A624CliRef7 = P00GA12_A624CliRef7[0];
            A623CliRef6 = P00GA12_A623CliRef6[0];
            A622CliRef5 = P00GA12_A622CliRef5[0];
            A621CliRef4 = P00GA12_A621CliRef4[0];
            A620CliRef3 = P00GA12_A620CliRef3[0];
            A619CliRef2 = P00GA12_A619CliRef2[0];
            A618CliRef1 = P00GA12_A618CliRef1[0];
            A160CliVend = P00GA12_A160CliVend[0];
            A613CliLim = P00GA12_A613CliLim[0];
            A137Conpcod = P00GA12_A137Conpcod[0];
            A627CliSts = P00GA12_A627CliSts[0];
            A159TipCCod = P00GA12_A159TipCCod[0];
            A609CliEma = P00GA12_A609CliEma[0];
            A575CliCel = P00GA12_A575CliCel[0];
            A611CliFax = P00GA12_A611CliFax[0];
            A630CliTel2 = P00GA12_A630CliTel2[0];
            A629CliTel1 = P00GA12_A629CliTel1[0];
            A139PaiCod = P00GA12_A139PaiCod[0];
            A140EstCod = P00GA12_A140EstCod[0];
            A596CliDir = P00GA12_A596CliDir[0];
            A45CliCod = P00GA12_A45CliCod[0];
            A635CliVendDsc = P00GA12_A635CliVendDsc[0];
            A161CliDsc = P00GA12_A161CliDsc[0];
            A635CliVendDsc = P00GA12_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(10) != 101) && ( StringUtil.StrCmp(P00GA12_A637CliWeb[0], A637CliWeb) == 0 ) )
            {
               BRKGA21 = false;
               A45CliCod = P00GA12_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA21 = true;
               pr_default.readNext(10);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A637CliWeb)) )
            {
               AV62Option = A637CliWeb;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA21 )
            {
               BRKGA21 = true;
               pr_default.readNext(10);
            }
         }
         pr_default.close(10);
      }

      protected void S231( )
      {
         /* 'LOADCLIVENDDSCOPTIONS' Routine */
         returnInSub = false;
         AV42TFCliVendDsc = AV58SearchTxt;
         AV43TFCliVendDsc_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(11, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA13 */
         pr_default.execute(11, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(11) != 101) )
         {
            BRKGA23 = false;
            A160CliVend = P00GA13_A160CliVend[0];
            A624CliRef7 = P00GA13_A624CliRef7[0];
            A623CliRef6 = P00GA13_A623CliRef6[0];
            A622CliRef5 = P00GA13_A622CliRef5[0];
            A621CliRef4 = P00GA13_A621CliRef4[0];
            A620CliRef3 = P00GA13_A620CliRef3[0];
            A619CliRef2 = P00GA13_A619CliRef2[0];
            A618CliRef1 = P00GA13_A618CliRef1[0];
            A613CliLim = P00GA13_A613CliLim[0];
            A137Conpcod = P00GA13_A137Conpcod[0];
            A627CliSts = P00GA13_A627CliSts[0];
            A159TipCCod = P00GA13_A159TipCCod[0];
            A637CliWeb = P00GA13_A637CliWeb[0];
            A609CliEma = P00GA13_A609CliEma[0];
            A575CliCel = P00GA13_A575CliCel[0];
            A611CliFax = P00GA13_A611CliFax[0];
            A630CliTel2 = P00GA13_A630CliTel2[0];
            A629CliTel1 = P00GA13_A629CliTel1[0];
            A139PaiCod = P00GA13_A139PaiCod[0];
            A140EstCod = P00GA13_A140EstCod[0];
            A596CliDir = P00GA13_A596CliDir[0];
            A45CliCod = P00GA13_A45CliCod[0];
            A635CliVendDsc = P00GA13_A635CliVendDsc[0];
            A161CliDsc = P00GA13_A161CliDsc[0];
            A635CliVendDsc = P00GA13_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(11) != 101) && ( P00GA13_A160CliVend[0] == A160CliVend ) )
            {
               BRKGA23 = false;
               A45CliCod = P00GA13_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA23 = true;
               pr_default.readNext(11);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A635CliVendDsc)) )
            {
               AV62Option = A635CliVendDsc;
               AV61InsertIndex = 1;
               while ( ( AV61InsertIndex <= AV63Options.Count ) && ( StringUtil.StrCmp(((string)AV63Options.Item(AV61InsertIndex)), AV62Option) < 0 ) )
               {
                  AV61InsertIndex = (int)(AV61InsertIndex+1);
               }
               AV63Options.Add(AV62Option, AV61InsertIndex);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), AV61InsertIndex);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA23 )
            {
               BRKGA23 = true;
               pr_default.readNext(11);
            }
         }
         pr_default.close(11);
      }

      protected void S241( )
      {
         /* 'LOADCLIREF1OPTIONS' Routine */
         returnInSub = false;
         AV44TFCliRef1 = AV58SearchTxt;
         AV45TFCliRef1_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(12, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA14 */
         pr_default.execute(12, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(12) != 101) )
         {
            BRKGA25 = false;
            A618CliRef1 = P00GA14_A618CliRef1[0];
            A624CliRef7 = P00GA14_A624CliRef7[0];
            A623CliRef6 = P00GA14_A623CliRef6[0];
            A622CliRef5 = P00GA14_A622CliRef5[0];
            A621CliRef4 = P00GA14_A621CliRef4[0];
            A620CliRef3 = P00GA14_A620CliRef3[0];
            A619CliRef2 = P00GA14_A619CliRef2[0];
            A160CliVend = P00GA14_A160CliVend[0];
            A613CliLim = P00GA14_A613CliLim[0];
            A137Conpcod = P00GA14_A137Conpcod[0];
            A627CliSts = P00GA14_A627CliSts[0];
            A159TipCCod = P00GA14_A159TipCCod[0];
            A637CliWeb = P00GA14_A637CliWeb[0];
            A609CliEma = P00GA14_A609CliEma[0];
            A575CliCel = P00GA14_A575CliCel[0];
            A611CliFax = P00GA14_A611CliFax[0];
            A630CliTel2 = P00GA14_A630CliTel2[0];
            A629CliTel1 = P00GA14_A629CliTel1[0];
            A139PaiCod = P00GA14_A139PaiCod[0];
            A140EstCod = P00GA14_A140EstCod[0];
            A596CliDir = P00GA14_A596CliDir[0];
            A45CliCod = P00GA14_A45CliCod[0];
            A635CliVendDsc = P00GA14_A635CliVendDsc[0];
            A161CliDsc = P00GA14_A161CliDsc[0];
            A635CliVendDsc = P00GA14_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(12) != 101) && ( StringUtil.StrCmp(P00GA14_A618CliRef1[0], A618CliRef1) == 0 ) )
            {
               BRKGA25 = false;
               A45CliCod = P00GA14_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA25 = true;
               pr_default.readNext(12);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A618CliRef1)) )
            {
               AV62Option = A618CliRef1;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA25 )
            {
               BRKGA25 = true;
               pr_default.readNext(12);
            }
         }
         pr_default.close(12);
      }

      protected void S251( )
      {
         /* 'LOADCLIREF2OPTIONS' Routine */
         returnInSub = false;
         AV46TFCliRef2 = AV58SearchTxt;
         AV47TFCliRef2_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(13, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA15 */
         pr_default.execute(13, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(13) != 101) )
         {
            BRKGA27 = false;
            A619CliRef2 = P00GA15_A619CliRef2[0];
            A624CliRef7 = P00GA15_A624CliRef7[0];
            A623CliRef6 = P00GA15_A623CliRef6[0];
            A622CliRef5 = P00GA15_A622CliRef5[0];
            A621CliRef4 = P00GA15_A621CliRef4[0];
            A620CliRef3 = P00GA15_A620CliRef3[0];
            A618CliRef1 = P00GA15_A618CliRef1[0];
            A160CliVend = P00GA15_A160CliVend[0];
            A613CliLim = P00GA15_A613CliLim[0];
            A137Conpcod = P00GA15_A137Conpcod[0];
            A627CliSts = P00GA15_A627CliSts[0];
            A159TipCCod = P00GA15_A159TipCCod[0];
            A637CliWeb = P00GA15_A637CliWeb[0];
            A609CliEma = P00GA15_A609CliEma[0];
            A575CliCel = P00GA15_A575CliCel[0];
            A611CliFax = P00GA15_A611CliFax[0];
            A630CliTel2 = P00GA15_A630CliTel2[0];
            A629CliTel1 = P00GA15_A629CliTel1[0];
            A139PaiCod = P00GA15_A139PaiCod[0];
            A140EstCod = P00GA15_A140EstCod[0];
            A596CliDir = P00GA15_A596CliDir[0];
            A45CliCod = P00GA15_A45CliCod[0];
            A635CliVendDsc = P00GA15_A635CliVendDsc[0];
            A161CliDsc = P00GA15_A161CliDsc[0];
            A635CliVendDsc = P00GA15_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(13) != 101) && ( StringUtil.StrCmp(P00GA15_A619CliRef2[0], A619CliRef2) == 0 ) )
            {
               BRKGA27 = false;
               A45CliCod = P00GA15_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA27 = true;
               pr_default.readNext(13);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A619CliRef2)) )
            {
               AV62Option = A619CliRef2;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA27 )
            {
               BRKGA27 = true;
               pr_default.readNext(13);
            }
         }
         pr_default.close(13);
      }

      protected void S261( )
      {
         /* 'LOADCLIREF3OPTIONS' Routine */
         returnInSub = false;
         AV48TFCliRef3 = AV58SearchTxt;
         AV49TFCliRef3_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(14, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA16 */
         pr_default.execute(14, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(14) != 101) )
         {
            BRKGA29 = false;
            A620CliRef3 = P00GA16_A620CliRef3[0];
            A624CliRef7 = P00GA16_A624CliRef7[0];
            A623CliRef6 = P00GA16_A623CliRef6[0];
            A622CliRef5 = P00GA16_A622CliRef5[0];
            A621CliRef4 = P00GA16_A621CliRef4[0];
            A619CliRef2 = P00GA16_A619CliRef2[0];
            A618CliRef1 = P00GA16_A618CliRef1[0];
            A160CliVend = P00GA16_A160CliVend[0];
            A613CliLim = P00GA16_A613CliLim[0];
            A137Conpcod = P00GA16_A137Conpcod[0];
            A627CliSts = P00GA16_A627CliSts[0];
            A159TipCCod = P00GA16_A159TipCCod[0];
            A637CliWeb = P00GA16_A637CliWeb[0];
            A609CliEma = P00GA16_A609CliEma[0];
            A575CliCel = P00GA16_A575CliCel[0];
            A611CliFax = P00GA16_A611CliFax[0];
            A630CliTel2 = P00GA16_A630CliTel2[0];
            A629CliTel1 = P00GA16_A629CliTel1[0];
            A139PaiCod = P00GA16_A139PaiCod[0];
            A140EstCod = P00GA16_A140EstCod[0];
            A596CliDir = P00GA16_A596CliDir[0];
            A45CliCod = P00GA16_A45CliCod[0];
            A635CliVendDsc = P00GA16_A635CliVendDsc[0];
            A161CliDsc = P00GA16_A161CliDsc[0];
            A635CliVendDsc = P00GA16_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(14) != 101) && ( StringUtil.StrCmp(P00GA16_A620CliRef3[0], A620CliRef3) == 0 ) )
            {
               BRKGA29 = false;
               A45CliCod = P00GA16_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA29 = true;
               pr_default.readNext(14);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A620CliRef3)) )
            {
               AV62Option = A620CliRef3;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA29 )
            {
               BRKGA29 = true;
               pr_default.readNext(14);
            }
         }
         pr_default.close(14);
      }

      protected void S271( )
      {
         /* 'LOADCLIREF4OPTIONS' Routine */
         returnInSub = false;
         AV50TFCliRef4 = AV58SearchTxt;
         AV51TFCliRef4_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(15, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA17 */
         pr_default.execute(15, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(15) != 101) )
         {
            BRKGA31 = false;
            A621CliRef4 = P00GA17_A621CliRef4[0];
            A624CliRef7 = P00GA17_A624CliRef7[0];
            A623CliRef6 = P00GA17_A623CliRef6[0];
            A622CliRef5 = P00GA17_A622CliRef5[0];
            A620CliRef3 = P00GA17_A620CliRef3[0];
            A619CliRef2 = P00GA17_A619CliRef2[0];
            A618CliRef1 = P00GA17_A618CliRef1[0];
            A160CliVend = P00GA17_A160CliVend[0];
            A613CliLim = P00GA17_A613CliLim[0];
            A137Conpcod = P00GA17_A137Conpcod[0];
            A627CliSts = P00GA17_A627CliSts[0];
            A159TipCCod = P00GA17_A159TipCCod[0];
            A637CliWeb = P00GA17_A637CliWeb[0];
            A609CliEma = P00GA17_A609CliEma[0];
            A575CliCel = P00GA17_A575CliCel[0];
            A611CliFax = P00GA17_A611CliFax[0];
            A630CliTel2 = P00GA17_A630CliTel2[0];
            A629CliTel1 = P00GA17_A629CliTel1[0];
            A139PaiCod = P00GA17_A139PaiCod[0];
            A140EstCod = P00GA17_A140EstCod[0];
            A596CliDir = P00GA17_A596CliDir[0];
            A45CliCod = P00GA17_A45CliCod[0];
            A635CliVendDsc = P00GA17_A635CliVendDsc[0];
            A161CliDsc = P00GA17_A161CliDsc[0];
            A635CliVendDsc = P00GA17_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(15) != 101) && ( StringUtil.StrCmp(P00GA17_A621CliRef4[0], A621CliRef4) == 0 ) )
            {
               BRKGA31 = false;
               A45CliCod = P00GA17_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA31 = true;
               pr_default.readNext(15);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A621CliRef4)) )
            {
               AV62Option = A621CliRef4;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA31 )
            {
               BRKGA31 = true;
               pr_default.readNext(15);
            }
         }
         pr_default.close(15);
      }

      protected void S281( )
      {
         /* 'LOADCLIREF5OPTIONS' Routine */
         returnInSub = false;
         AV52TFCliRef5 = AV58SearchTxt;
         AV53TFCliRef5_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(16, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA18 */
         pr_default.execute(16, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(16) != 101) )
         {
            BRKGA33 = false;
            A622CliRef5 = P00GA18_A622CliRef5[0];
            A624CliRef7 = P00GA18_A624CliRef7[0];
            A623CliRef6 = P00GA18_A623CliRef6[0];
            A621CliRef4 = P00GA18_A621CliRef4[0];
            A620CliRef3 = P00GA18_A620CliRef3[0];
            A619CliRef2 = P00GA18_A619CliRef2[0];
            A618CliRef1 = P00GA18_A618CliRef1[0];
            A160CliVend = P00GA18_A160CliVend[0];
            A613CliLim = P00GA18_A613CliLim[0];
            A137Conpcod = P00GA18_A137Conpcod[0];
            A627CliSts = P00GA18_A627CliSts[0];
            A159TipCCod = P00GA18_A159TipCCod[0];
            A637CliWeb = P00GA18_A637CliWeb[0];
            A609CliEma = P00GA18_A609CliEma[0];
            A575CliCel = P00GA18_A575CliCel[0];
            A611CliFax = P00GA18_A611CliFax[0];
            A630CliTel2 = P00GA18_A630CliTel2[0];
            A629CliTel1 = P00GA18_A629CliTel1[0];
            A139PaiCod = P00GA18_A139PaiCod[0];
            A140EstCod = P00GA18_A140EstCod[0];
            A596CliDir = P00GA18_A596CliDir[0];
            A45CliCod = P00GA18_A45CliCod[0];
            A635CliVendDsc = P00GA18_A635CliVendDsc[0];
            A161CliDsc = P00GA18_A161CliDsc[0];
            A635CliVendDsc = P00GA18_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(16) != 101) && ( StringUtil.StrCmp(P00GA18_A622CliRef5[0], A622CliRef5) == 0 ) )
            {
               BRKGA33 = false;
               A45CliCod = P00GA18_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA33 = true;
               pr_default.readNext(16);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A622CliRef5)) )
            {
               AV62Option = A622CliRef5;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA33 )
            {
               BRKGA33 = true;
               pr_default.readNext(16);
            }
         }
         pr_default.close(16);
      }

      protected void S291( )
      {
         /* 'LOADCLIREF6OPTIONS' Routine */
         returnInSub = false;
         AV54TFCliRef6 = AV58SearchTxt;
         AV55TFCliRef6_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(17, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA19 */
         pr_default.execute(17, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(17) != 101) )
         {
            BRKGA35 = false;
            A623CliRef6 = P00GA19_A623CliRef6[0];
            A624CliRef7 = P00GA19_A624CliRef7[0];
            A622CliRef5 = P00GA19_A622CliRef5[0];
            A621CliRef4 = P00GA19_A621CliRef4[0];
            A620CliRef3 = P00GA19_A620CliRef3[0];
            A619CliRef2 = P00GA19_A619CliRef2[0];
            A618CliRef1 = P00GA19_A618CliRef1[0];
            A160CliVend = P00GA19_A160CliVend[0];
            A613CliLim = P00GA19_A613CliLim[0];
            A137Conpcod = P00GA19_A137Conpcod[0];
            A627CliSts = P00GA19_A627CliSts[0];
            A159TipCCod = P00GA19_A159TipCCod[0];
            A637CliWeb = P00GA19_A637CliWeb[0];
            A609CliEma = P00GA19_A609CliEma[0];
            A575CliCel = P00GA19_A575CliCel[0];
            A611CliFax = P00GA19_A611CliFax[0];
            A630CliTel2 = P00GA19_A630CliTel2[0];
            A629CliTel1 = P00GA19_A629CliTel1[0];
            A139PaiCod = P00GA19_A139PaiCod[0];
            A140EstCod = P00GA19_A140EstCod[0];
            A596CliDir = P00GA19_A596CliDir[0];
            A45CliCod = P00GA19_A45CliCod[0];
            A635CliVendDsc = P00GA19_A635CliVendDsc[0];
            A161CliDsc = P00GA19_A161CliDsc[0];
            A635CliVendDsc = P00GA19_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(17) != 101) && ( StringUtil.StrCmp(P00GA19_A623CliRef6[0], A623CliRef6) == 0 ) )
            {
               BRKGA35 = false;
               A45CliCod = P00GA19_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA35 = true;
               pr_default.readNext(17);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A623CliRef6)) )
            {
               AV62Option = A623CliRef6;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA35 )
            {
               BRKGA35 = true;
               pr_default.readNext(17);
            }
         }
         pr_default.close(17);
      }

      protected void S301( )
      {
         /* 'LOADCLIREF7OPTIONS' Routine */
         returnInSub = false;
         AV56TFCliRef7 = AV58SearchTxt;
         AV57TFCliRef7_Sel = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = AV76DynamicFiltersSelector1;
         AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 = AV77DynamicFiltersOperator1;
         AV96Ventas_clienteswwds_3_clidsc1 = AV78CliDsc1;
         AV97Ventas_clienteswwds_4_clivenddsc1 = AV79CliVendDsc1;
         AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 = AV80DynamicFiltersEnabled2;
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = AV81DynamicFiltersSelector2;
         AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 = AV82DynamicFiltersOperator2;
         AV101Ventas_clienteswwds_8_clidsc2 = AV83CliDsc2;
         AV102Ventas_clienteswwds_9_clivenddsc2 = AV84CliVendDsc2;
         AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV106Ventas_clienteswwds_13_clidsc3 = AV88CliDsc3;
         AV107Ventas_clienteswwds_14_clivenddsc3 = AV89CliVendDsc3;
         AV108Ventas_clienteswwds_15_tfclicod = AV10TFCliCod;
         AV109Ventas_clienteswwds_16_tfclicod_sel = AV11TFCliCod_Sel;
         AV110Ventas_clienteswwds_17_tfclidsc = AV12TFCliDsc;
         AV111Ventas_clienteswwds_18_tfclidsc_sel = AV13TFCliDsc_Sel;
         AV112Ventas_clienteswwds_19_tfclidir = AV14TFCliDir;
         AV113Ventas_clienteswwds_20_tfclidir_sel = AV15TFCliDir_Sel;
         AV114Ventas_clienteswwds_21_tfestcod = AV16TFEstCod;
         AV115Ventas_clienteswwds_22_tfestcod_sel = AV17TFEstCod_Sel;
         AV116Ventas_clienteswwds_23_tfpaicod = AV18TFPaiCod;
         AV117Ventas_clienteswwds_24_tfpaicod_sel = AV19TFPaiCod_Sel;
         AV118Ventas_clienteswwds_25_tfclitel1 = AV20TFCliTel1;
         AV119Ventas_clienteswwds_26_tfclitel1_sel = AV21TFCliTel1_Sel;
         AV120Ventas_clienteswwds_27_tfclitel2 = AV22TFCliTel2;
         AV121Ventas_clienteswwds_28_tfclitel2_sel = AV23TFCliTel2_Sel;
         AV122Ventas_clienteswwds_29_tfclifax = AV24TFCliFax;
         AV123Ventas_clienteswwds_30_tfclifax_sel = AV25TFCliFax_Sel;
         AV124Ventas_clienteswwds_31_tfclicel = AV26TFCliCel;
         AV125Ventas_clienteswwds_32_tfclicel_sel = AV27TFCliCel_Sel;
         AV126Ventas_clienteswwds_33_tfcliema = AV28TFCliEma;
         AV127Ventas_clienteswwds_34_tfcliema_sel = AV29TFCliEma_Sel;
         AV128Ventas_clienteswwds_35_tfcliweb = AV30TFCliWeb;
         AV129Ventas_clienteswwds_36_tfcliweb_sel = AV31TFCliWeb_Sel;
         AV130Ventas_clienteswwds_37_tftipccod = AV32TFTipCCod;
         AV131Ventas_clienteswwds_38_tftipccod_to = AV33TFTipCCod_To;
         AV132Ventas_clienteswwds_39_tfclists = AV34TFCliSts;
         AV133Ventas_clienteswwds_40_tfclists_to = AV35TFCliSts_To;
         AV134Ventas_clienteswwds_41_tfconpcod = AV36TFConpcod;
         AV135Ventas_clienteswwds_42_tfconpcod_to = AV37TFConpcod_To;
         AV136Ventas_clienteswwds_43_tfclilim = AV38TFCliLim;
         AV137Ventas_clienteswwds_44_tfclilim_to = AV39TFCliLim_To;
         AV138Ventas_clienteswwds_45_tfclivend = AV40TFCliVend;
         AV139Ventas_clienteswwds_46_tfclivend_to = AV41TFCliVend_To;
         AV140Ventas_clienteswwds_47_tfclivenddsc = AV42TFCliVendDsc;
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = AV43TFCliVendDsc_Sel;
         AV142Ventas_clienteswwds_49_tfcliref1 = AV44TFCliRef1;
         AV143Ventas_clienteswwds_50_tfcliref1_sel = AV45TFCliRef1_Sel;
         AV144Ventas_clienteswwds_51_tfcliref2 = AV46TFCliRef2;
         AV145Ventas_clienteswwds_52_tfcliref2_sel = AV47TFCliRef2_Sel;
         AV146Ventas_clienteswwds_53_tfcliref3 = AV48TFCliRef3;
         AV147Ventas_clienteswwds_54_tfcliref3_sel = AV49TFCliRef3_Sel;
         AV148Ventas_clienteswwds_55_tfcliref4 = AV50TFCliRef4;
         AV149Ventas_clienteswwds_56_tfcliref4_sel = AV51TFCliRef4_Sel;
         AV150Ventas_clienteswwds_57_tfcliref5 = AV52TFCliRef5;
         AV151Ventas_clienteswwds_58_tfcliref5_sel = AV53TFCliRef5_Sel;
         AV152Ventas_clienteswwds_59_tfcliref6 = AV54TFCliRef6;
         AV153Ventas_clienteswwds_60_tfcliref6_sel = AV55TFCliRef6_Sel;
         AV154Ventas_clienteswwds_61_tfcliref7 = AV56TFCliRef7;
         AV155Ventas_clienteswwds_62_tfcliref7_sel = AV57TFCliRef7_Sel;
         pr_default.dynParam(18, new Object[]{ new Object[]{
                                              AV94Ventas_clienteswwds_1_dynamicfiltersselector1 ,
                                              AV95Ventas_clienteswwds_2_dynamicfiltersoperator1 ,
                                              AV96Ventas_clienteswwds_3_clidsc1 ,
                                              AV97Ventas_clienteswwds_4_clivenddsc1 ,
                                              AV98Ventas_clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV99Ventas_clienteswwds_6_dynamicfiltersselector2 ,
                                              AV100Ventas_clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV101Ventas_clienteswwds_8_clidsc2 ,
                                              AV102Ventas_clienteswwds_9_clivenddsc2 ,
                                              AV103Ventas_clienteswwds_10_dynamicfiltersenabled3 ,
                                              AV104Ventas_clienteswwds_11_dynamicfiltersselector3 ,
                                              AV105Ventas_clienteswwds_12_dynamicfiltersoperator3 ,
                                              AV106Ventas_clienteswwds_13_clidsc3 ,
                                              AV107Ventas_clienteswwds_14_clivenddsc3 ,
                                              AV109Ventas_clienteswwds_16_tfclicod_sel ,
                                              AV108Ventas_clienteswwds_15_tfclicod ,
                                              AV111Ventas_clienteswwds_18_tfclidsc_sel ,
                                              AV110Ventas_clienteswwds_17_tfclidsc ,
                                              AV113Ventas_clienteswwds_20_tfclidir_sel ,
                                              AV112Ventas_clienteswwds_19_tfclidir ,
                                              AV115Ventas_clienteswwds_22_tfestcod_sel ,
                                              AV114Ventas_clienteswwds_21_tfestcod ,
                                              AV117Ventas_clienteswwds_24_tfpaicod_sel ,
                                              AV116Ventas_clienteswwds_23_tfpaicod ,
                                              AV119Ventas_clienteswwds_26_tfclitel1_sel ,
                                              AV118Ventas_clienteswwds_25_tfclitel1 ,
                                              AV121Ventas_clienteswwds_28_tfclitel2_sel ,
                                              AV120Ventas_clienteswwds_27_tfclitel2 ,
                                              AV123Ventas_clienteswwds_30_tfclifax_sel ,
                                              AV122Ventas_clienteswwds_29_tfclifax ,
                                              AV125Ventas_clienteswwds_32_tfclicel_sel ,
                                              AV124Ventas_clienteswwds_31_tfclicel ,
                                              AV127Ventas_clienteswwds_34_tfcliema_sel ,
                                              AV126Ventas_clienteswwds_33_tfcliema ,
                                              AV129Ventas_clienteswwds_36_tfcliweb_sel ,
                                              AV128Ventas_clienteswwds_35_tfcliweb ,
                                              AV130Ventas_clienteswwds_37_tftipccod ,
                                              AV131Ventas_clienteswwds_38_tftipccod_to ,
                                              AV132Ventas_clienteswwds_39_tfclists ,
                                              AV133Ventas_clienteswwds_40_tfclists_to ,
                                              AV134Ventas_clienteswwds_41_tfconpcod ,
                                              AV135Ventas_clienteswwds_42_tfconpcod_to ,
                                              AV136Ventas_clienteswwds_43_tfclilim ,
                                              AV137Ventas_clienteswwds_44_tfclilim_to ,
                                              AV138Ventas_clienteswwds_45_tfclivend ,
                                              AV139Ventas_clienteswwds_46_tfclivend_to ,
                                              AV141Ventas_clienteswwds_48_tfclivenddsc_sel ,
                                              AV140Ventas_clienteswwds_47_tfclivenddsc ,
                                              AV143Ventas_clienteswwds_50_tfcliref1_sel ,
                                              AV142Ventas_clienteswwds_49_tfcliref1 ,
                                              AV145Ventas_clienteswwds_52_tfcliref2_sel ,
                                              AV144Ventas_clienteswwds_51_tfcliref2 ,
                                              AV147Ventas_clienteswwds_54_tfcliref3_sel ,
                                              AV146Ventas_clienteswwds_53_tfcliref3 ,
                                              AV149Ventas_clienteswwds_56_tfcliref4_sel ,
                                              AV148Ventas_clienteswwds_55_tfcliref4 ,
                                              AV151Ventas_clienteswwds_58_tfcliref5_sel ,
                                              AV150Ventas_clienteswwds_57_tfcliref5 ,
                                              AV153Ventas_clienteswwds_60_tfcliref6_sel ,
                                              AV152Ventas_clienteswwds_59_tfcliref6 ,
                                              AV155Ventas_clienteswwds_62_tfcliref7_sel ,
                                              AV154Ventas_clienteswwds_61_tfcliref7 ,
                                              A161CliDsc ,
                                              A635CliVendDsc ,
                                              A45CliCod ,
                                              A596CliDir ,
                                              A140EstCod ,
                                              A139PaiCod ,
                                              A629CliTel1 ,
                                              A630CliTel2 ,
                                              A611CliFax ,
                                              A575CliCel ,
                                              A609CliEma ,
                                              A637CliWeb ,
                                              A159TipCCod ,
                                              A627CliSts ,
                                              A137Conpcod ,
                                              A613CliLim ,
                                              A160CliVend ,
                                              A618CliRef1 ,
                                              A619CliRef2 ,
                                              A620CliRef3 ,
                                              A621CliRef4 ,
                                              A622CliRef5 ,
                                              A623CliRef6 ,
                                              A624CliRef7 } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV96Ventas_clienteswwds_3_clidsc1 = StringUtil.PadR( StringUtil.RTrim( AV96Ventas_clienteswwds_3_clidsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV97Ventas_clienteswwds_4_clivenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV97Ventas_clienteswwds_4_clivenddsc1), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV101Ventas_clienteswwds_8_clidsc2 = StringUtil.PadR( StringUtil.RTrim( AV101Ventas_clienteswwds_8_clidsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV102Ventas_clienteswwds_9_clivenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV102Ventas_clienteswwds_9_clivenddsc2), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV106Ventas_clienteswwds_13_clidsc3 = StringUtil.PadR( StringUtil.RTrim( AV106Ventas_clienteswwds_13_clidsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV107Ventas_clienteswwds_14_clivenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV107Ventas_clienteswwds_14_clivenddsc3), 100, "%");
         lV108Ventas_clienteswwds_15_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV108Ventas_clienteswwds_15_tfclicod), 20, "%");
         lV110Ventas_clienteswwds_17_tfclidsc = StringUtil.PadR( StringUtil.RTrim( AV110Ventas_clienteswwds_17_tfclidsc), 100, "%");
         lV112Ventas_clienteswwds_19_tfclidir = StringUtil.PadR( StringUtil.RTrim( AV112Ventas_clienteswwds_19_tfclidir), 100, "%");
         lV114Ventas_clienteswwds_21_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV114Ventas_clienteswwds_21_tfestcod), 4, "%");
         lV116Ventas_clienteswwds_23_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV116Ventas_clienteswwds_23_tfpaicod), 4, "%");
         lV118Ventas_clienteswwds_25_tfclitel1 = StringUtil.PadR( StringUtil.RTrim( AV118Ventas_clienteswwds_25_tfclitel1), 20, "%");
         lV120Ventas_clienteswwds_27_tfclitel2 = StringUtil.PadR( StringUtil.RTrim( AV120Ventas_clienteswwds_27_tfclitel2), 20, "%");
         lV122Ventas_clienteswwds_29_tfclifax = StringUtil.PadR( StringUtil.RTrim( AV122Ventas_clienteswwds_29_tfclifax), 20, "%");
         lV124Ventas_clienteswwds_31_tfclicel = StringUtil.PadR( StringUtil.RTrim( AV124Ventas_clienteswwds_31_tfclicel), 20, "%");
         lV126Ventas_clienteswwds_33_tfcliema = StringUtil.Concat( StringUtil.RTrim( AV126Ventas_clienteswwds_33_tfcliema), "%", "");
         lV128Ventas_clienteswwds_35_tfcliweb = StringUtil.PadR( StringUtil.RTrim( AV128Ventas_clienteswwds_35_tfcliweb), 50, "%");
         lV140Ventas_clienteswwds_47_tfclivenddsc = StringUtil.PadR( StringUtil.RTrim( AV140Ventas_clienteswwds_47_tfclivenddsc), 100, "%");
         lV142Ventas_clienteswwds_49_tfcliref1 = StringUtil.PadR( StringUtil.RTrim( AV142Ventas_clienteswwds_49_tfcliref1), 50, "%");
         lV144Ventas_clienteswwds_51_tfcliref2 = StringUtil.PadR( StringUtil.RTrim( AV144Ventas_clienteswwds_51_tfcliref2), 50, "%");
         lV146Ventas_clienteswwds_53_tfcliref3 = StringUtil.PadR( StringUtil.RTrim( AV146Ventas_clienteswwds_53_tfcliref3), 50, "%");
         lV148Ventas_clienteswwds_55_tfcliref4 = StringUtil.PadR( StringUtil.RTrim( AV148Ventas_clienteswwds_55_tfcliref4), 50, "%");
         lV150Ventas_clienteswwds_57_tfcliref5 = StringUtil.PadR( StringUtil.RTrim( AV150Ventas_clienteswwds_57_tfcliref5), 50, "%");
         lV152Ventas_clienteswwds_59_tfcliref6 = StringUtil.PadR( StringUtil.RTrim( AV152Ventas_clienteswwds_59_tfcliref6), 50, "%");
         lV154Ventas_clienteswwds_61_tfcliref7 = StringUtil.PadR( StringUtil.RTrim( AV154Ventas_clienteswwds_61_tfcliref7), 50, "%");
         /* Using cursor P00GA20 */
         pr_default.execute(18, new Object[] {lV96Ventas_clienteswwds_3_clidsc1, lV96Ventas_clienteswwds_3_clidsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV97Ventas_clienteswwds_4_clivenddsc1, lV101Ventas_clienteswwds_8_clidsc2, lV101Ventas_clienteswwds_8_clidsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV102Ventas_clienteswwds_9_clivenddsc2, lV106Ventas_clienteswwds_13_clidsc3, lV106Ventas_clienteswwds_13_clidsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV107Ventas_clienteswwds_14_clivenddsc3, lV108Ventas_clienteswwds_15_tfclicod, AV109Ventas_clienteswwds_16_tfclicod_sel, lV110Ventas_clienteswwds_17_tfclidsc, AV111Ventas_clienteswwds_18_tfclidsc_sel, lV112Ventas_clienteswwds_19_tfclidir, AV113Ventas_clienteswwds_20_tfclidir_sel, lV114Ventas_clienteswwds_21_tfestcod, AV115Ventas_clienteswwds_22_tfestcod_sel, lV116Ventas_clienteswwds_23_tfpaicod, AV117Ventas_clienteswwds_24_tfpaicod_sel, lV118Ventas_clienteswwds_25_tfclitel1, AV119Ventas_clienteswwds_26_tfclitel1_sel, lV120Ventas_clienteswwds_27_tfclitel2, AV121Ventas_clienteswwds_28_tfclitel2_sel, lV122Ventas_clienteswwds_29_tfclifax, AV123Ventas_clienteswwds_30_tfclifax_sel, lV124Ventas_clienteswwds_31_tfclicel, AV125Ventas_clienteswwds_32_tfclicel_sel, lV126Ventas_clienteswwds_33_tfcliema, AV127Ventas_clienteswwds_34_tfcliema_sel, lV128Ventas_clienteswwds_35_tfcliweb, AV129Ventas_clienteswwds_36_tfcliweb_sel, AV130Ventas_clienteswwds_37_tftipccod, AV131Ventas_clienteswwds_38_tftipccod_to, AV132Ventas_clienteswwds_39_tfclists, AV133Ventas_clienteswwds_40_tfclists_to, AV134Ventas_clienteswwds_41_tfconpcod, AV135Ventas_clienteswwds_42_tfconpcod_to, AV136Ventas_clienteswwds_43_tfclilim, AV137Ventas_clienteswwds_44_tfclilim_to, AV138Ventas_clienteswwds_45_tfclivend, AV139Ventas_clienteswwds_46_tfclivend_to, lV140Ventas_clienteswwds_47_tfclivenddsc, AV141Ventas_clienteswwds_48_tfclivenddsc_sel, lV142Ventas_clienteswwds_49_tfcliref1, AV143Ventas_clienteswwds_50_tfcliref1_sel, lV144Ventas_clienteswwds_51_tfcliref2, AV145Ventas_clienteswwds_52_tfcliref2_sel, lV146Ventas_clienteswwds_53_tfcliref3, AV147Ventas_clienteswwds_54_tfcliref3_sel, lV148Ventas_clienteswwds_55_tfcliref4, AV149Ventas_clienteswwds_56_tfcliref4_sel, lV150Ventas_clienteswwds_57_tfcliref5, AV151Ventas_clienteswwds_58_tfcliref5_sel, lV152Ventas_clienteswwds_59_tfcliref6, AV153Ventas_clienteswwds_60_tfcliref6_sel, lV154Ventas_clienteswwds_61_tfcliref7, AV155Ventas_clienteswwds_62_tfcliref7_sel});
         while ( (pr_default.getStatus(18) != 101) )
         {
            BRKGA37 = false;
            A624CliRef7 = P00GA20_A624CliRef7[0];
            A623CliRef6 = P00GA20_A623CliRef6[0];
            A622CliRef5 = P00GA20_A622CliRef5[0];
            A621CliRef4 = P00GA20_A621CliRef4[0];
            A620CliRef3 = P00GA20_A620CliRef3[0];
            A619CliRef2 = P00GA20_A619CliRef2[0];
            A618CliRef1 = P00GA20_A618CliRef1[0];
            A160CliVend = P00GA20_A160CliVend[0];
            A613CliLim = P00GA20_A613CliLim[0];
            A137Conpcod = P00GA20_A137Conpcod[0];
            A627CliSts = P00GA20_A627CliSts[0];
            A159TipCCod = P00GA20_A159TipCCod[0];
            A637CliWeb = P00GA20_A637CliWeb[0];
            A609CliEma = P00GA20_A609CliEma[0];
            A575CliCel = P00GA20_A575CliCel[0];
            A611CliFax = P00GA20_A611CliFax[0];
            A630CliTel2 = P00GA20_A630CliTel2[0];
            A629CliTel1 = P00GA20_A629CliTel1[0];
            A139PaiCod = P00GA20_A139PaiCod[0];
            A140EstCod = P00GA20_A140EstCod[0];
            A596CliDir = P00GA20_A596CliDir[0];
            A45CliCod = P00GA20_A45CliCod[0];
            A635CliVendDsc = P00GA20_A635CliVendDsc[0];
            A161CliDsc = P00GA20_A161CliDsc[0];
            A635CliVendDsc = P00GA20_A635CliVendDsc[0];
            AV70count = 0;
            while ( (pr_default.getStatus(18) != 101) && ( StringUtil.StrCmp(P00GA20_A624CliRef7[0], A624CliRef7) == 0 ) )
            {
               BRKGA37 = false;
               A45CliCod = P00GA20_A45CliCod[0];
               AV70count = (long)(AV70count+1);
               BRKGA37 = true;
               pr_default.readNext(18);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A624CliRef7)) )
            {
               AV62Option = A624CliRef7;
               AV63Options.Add(AV62Option, 0);
               AV68OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV70count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV63Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGA37 )
            {
               BRKGA37 = true;
               pr_default.readNext(18);
            }
         }
         pr_default.close(18);
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
         AV64OptionsJson = "";
         AV67OptionsDescJson = "";
         AV69OptionIndexesJson = "";
         AV63Options = new GxSimpleCollection<string>();
         AV66OptionsDesc = new GxSimpleCollection<string>();
         AV68OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV71Session = context.GetSession();
         AV73GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV74GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFCliCod = "";
         AV11TFCliCod_Sel = "";
         AV12TFCliDsc = "";
         AV13TFCliDsc_Sel = "";
         AV14TFCliDir = "";
         AV15TFCliDir_Sel = "";
         AV16TFEstCod = "";
         AV17TFEstCod_Sel = "";
         AV18TFPaiCod = "";
         AV19TFPaiCod_Sel = "";
         AV20TFCliTel1 = "";
         AV21TFCliTel1_Sel = "";
         AV22TFCliTel2 = "";
         AV23TFCliTel2_Sel = "";
         AV24TFCliFax = "";
         AV25TFCliFax_Sel = "";
         AV26TFCliCel = "";
         AV27TFCliCel_Sel = "";
         AV28TFCliEma = "";
         AV29TFCliEma_Sel = "";
         AV30TFCliWeb = "";
         AV31TFCliWeb_Sel = "";
         AV42TFCliVendDsc = "";
         AV43TFCliVendDsc_Sel = "";
         AV44TFCliRef1 = "";
         AV45TFCliRef1_Sel = "";
         AV46TFCliRef2 = "";
         AV47TFCliRef2_Sel = "";
         AV48TFCliRef3 = "";
         AV49TFCliRef3_Sel = "";
         AV50TFCliRef4 = "";
         AV51TFCliRef4_Sel = "";
         AV52TFCliRef5 = "";
         AV53TFCliRef5_Sel = "";
         AV54TFCliRef6 = "";
         AV55TFCliRef6_Sel = "";
         AV56TFCliRef7 = "";
         AV57TFCliRef7_Sel = "";
         AV75GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV76DynamicFiltersSelector1 = "";
         AV78CliDsc1 = "";
         AV79CliVendDsc1 = "";
         AV81DynamicFiltersSelector2 = "";
         AV83CliDsc2 = "";
         AV84CliVendDsc2 = "";
         AV86DynamicFiltersSelector3 = "";
         AV88CliDsc3 = "";
         AV89CliVendDsc3 = "";
         AV94Ventas_clienteswwds_1_dynamicfiltersselector1 = "";
         AV96Ventas_clienteswwds_3_clidsc1 = "";
         AV97Ventas_clienteswwds_4_clivenddsc1 = "";
         AV99Ventas_clienteswwds_6_dynamicfiltersselector2 = "";
         AV101Ventas_clienteswwds_8_clidsc2 = "";
         AV102Ventas_clienteswwds_9_clivenddsc2 = "";
         AV104Ventas_clienteswwds_11_dynamicfiltersselector3 = "";
         AV106Ventas_clienteswwds_13_clidsc3 = "";
         AV107Ventas_clienteswwds_14_clivenddsc3 = "";
         AV108Ventas_clienteswwds_15_tfclicod = "";
         AV109Ventas_clienteswwds_16_tfclicod_sel = "";
         AV110Ventas_clienteswwds_17_tfclidsc = "";
         AV111Ventas_clienteswwds_18_tfclidsc_sel = "";
         AV112Ventas_clienteswwds_19_tfclidir = "";
         AV113Ventas_clienteswwds_20_tfclidir_sel = "";
         AV114Ventas_clienteswwds_21_tfestcod = "";
         AV115Ventas_clienteswwds_22_tfestcod_sel = "";
         AV116Ventas_clienteswwds_23_tfpaicod = "";
         AV117Ventas_clienteswwds_24_tfpaicod_sel = "";
         AV118Ventas_clienteswwds_25_tfclitel1 = "";
         AV119Ventas_clienteswwds_26_tfclitel1_sel = "";
         AV120Ventas_clienteswwds_27_tfclitel2 = "";
         AV121Ventas_clienteswwds_28_tfclitel2_sel = "";
         AV122Ventas_clienteswwds_29_tfclifax = "";
         AV123Ventas_clienteswwds_30_tfclifax_sel = "";
         AV124Ventas_clienteswwds_31_tfclicel = "";
         AV125Ventas_clienteswwds_32_tfclicel_sel = "";
         AV126Ventas_clienteswwds_33_tfcliema = "";
         AV127Ventas_clienteswwds_34_tfcliema_sel = "";
         AV128Ventas_clienteswwds_35_tfcliweb = "";
         AV129Ventas_clienteswwds_36_tfcliweb_sel = "";
         AV140Ventas_clienteswwds_47_tfclivenddsc = "";
         AV141Ventas_clienteswwds_48_tfclivenddsc_sel = "";
         AV142Ventas_clienteswwds_49_tfcliref1 = "";
         AV143Ventas_clienteswwds_50_tfcliref1_sel = "";
         AV144Ventas_clienteswwds_51_tfcliref2 = "";
         AV145Ventas_clienteswwds_52_tfcliref2_sel = "";
         AV146Ventas_clienteswwds_53_tfcliref3 = "";
         AV147Ventas_clienteswwds_54_tfcliref3_sel = "";
         AV148Ventas_clienteswwds_55_tfcliref4 = "";
         AV149Ventas_clienteswwds_56_tfcliref4_sel = "";
         AV150Ventas_clienteswwds_57_tfcliref5 = "";
         AV151Ventas_clienteswwds_58_tfcliref5_sel = "";
         AV152Ventas_clienteswwds_59_tfcliref6 = "";
         AV153Ventas_clienteswwds_60_tfcliref6_sel = "";
         AV154Ventas_clienteswwds_61_tfcliref7 = "";
         AV155Ventas_clienteswwds_62_tfcliref7_sel = "";
         scmdbuf = "";
         lV96Ventas_clienteswwds_3_clidsc1 = "";
         l