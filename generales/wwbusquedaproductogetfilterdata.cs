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
namespace GeneXus.Programs.generales {
   public class wwbusquedaproductogetfilterdata : GXProcedure
   {
      public wwbusquedaproductogetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwbusquedaproductogetfilterdata( IGxContext context )
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
         wwbusquedaproductogetfilterdata objwwbusquedaproductogetfilterdata;
         objwwbusquedaproductogetfilterdata = new wwbusquedaproductogetfilterdata();
         objwwbusquedaproductogetfilterdata.AV24DDOName = aP0_DDOName;
         objwwbusquedaproductogetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objwwbusquedaproductogetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objwwbusquedaproductogetfilterdata.AV28OptionsJson = "" ;
         objwwbusquedaproductogetfilterdata.AV31OptionsDescJson = "" ;
         objwwbusquedaproductogetfilterdata.AV33OptionIndexesJson = "" ;
         objwwbusquedaproductogetfilterdata.context.SetSubmitInitialConfig(context);
         objwwbusquedaproductogetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwbusquedaproductogetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwbusquedaproductogetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PRODCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PRODDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_UNIABR") == 0 )
         {
            /* Execute user subroutine: 'LOADUNIABROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PRODREFERENCIAS") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODREFERENCIASOPTIONS' */
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
         if ( StringUtil.StrCmp(AV35Session.Get("Generales.WWBusquedaProductoGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Generales.WWBusquedaProductoGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Generales.WWBusquedaProductoGridState"), null, "", "");
         }
         AV68GXV1 = 1;
         while ( AV68GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV68GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV60FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV10TFProdCod = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV11TFProdCod_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODDSC") == 0 )
            {
               AV12TFProdDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODDSC_SEL") == 0 )
            {
               AV13TFProdDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUNIABR") == 0 )
            {
               AV61TFUniAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFUNIABR_SEL") == 0 )
            {
               AV62TFUniAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODREFERENCIAS") == 0 )
            {
               AV63TFProdReferencias = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPRODREFERENCIAS_SEL") == 0 )
            {
               AV64TFProdReferencias_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV68GXV1 = (int)(AV68GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRODCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFProdCod = AV22SearchTxt;
         AV11TFProdCod_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV11TFProdCod_Sel ,
                                              AV10TFProdCod ,
                                              AV13TFProdDsc_Sel ,
                                              AV12TFProdDsc ,
                                              AV62TFUniAbr_Sel ,
                                              AV61TFUniAbr ,
                                              AV64TFProdReferencias_Sel ,
                                              AV63TFProdReferencias ,
                                              AV65InTipo ,
                                              A28ProdCod ,
                                              A55ProdDsc ,
                                              A1997UniAbr ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV10TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV10TFProdCod), 15, "%");
         lV12TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV12TFProdDsc), 100, "%");
         lV61TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV61TFUniAbr), 5, "%");
         lV63TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV63TFProdReferencias), "%", "");
         /* Using cursor P007H2 */
         pr_default.execute(0, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV10TFProdCod, AV11TFProdCod_Sel, lV12TFProdDsc, AV13TFProdDsc_Sel, lV61TFUniAbr, AV62TFUniAbr_Sel, lV63TFProdReferencias, AV64TFProdReferencias_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A49UniCod = P007H2_A49UniCod[0];
            A1679ProdCmp = P007H2_A1679ProdCmp[0];
            A1724ProdVta = P007H2_A1724ProdVta[0];
            A1718ProdSts = P007H2_A1718ProdSts[0];
            A1997UniAbr = P007H2_A1997UniAbr[0];
            A55ProdDsc = P007H2_A55ProdDsc[0];
            A28ProdCod = P007H2_A28ProdCod[0];
            A1706ProdRef10 = P007H2_A1706ProdRef10[0];
            A1714ProdRef9 = P007H2_A1714ProdRef9[0];
            A1713ProdRef8 = P007H2_A1713ProdRef8[0];
            A1712ProdRef7 = P007H2_A1712ProdRef7[0];
            A1711ProdRef6 = P007H2_A1711ProdRef6[0];
            A1710ProdRef5 = P007H2_A1710ProdRef5[0];
            A1709ProdRef4 = P007H2_A1709ProdRef4[0];
            A1708ProdRef3 = P007H2_A1708ProdRef3[0];
            A1707ProdRef2 = P007H2_A1707ProdRef2[0];
            A1705ProdRef1 = P007H2_A1705ProdRef1[0];
            A1997UniAbr = P007H2_A1997UniAbr[0];
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A28ProdCod)) )
            {
               AV26Option = A28ProdCod;
               AV29OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")));
               AV27Options.Add(AV26Option, 0);
               AV30OptionsDesc.Add(AV29OptionDesc, 0);
            }
            if ( AV27Options.Count == 50 )
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
         /* 'LOADPRODDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFProdDsc = AV22SearchTxt;
         AV13TFProdDsc_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV11TFProdCod_Sel ,
                                              AV10TFProdCod ,
                                              AV13TFProdDsc_Sel ,
                                              AV12TFProdDsc ,
                                              AV62TFUniAbr_Sel ,
                                              AV61TFUniAbr ,
                                              AV64TFProdReferencias_Sel ,
                                              AV63TFProdReferencias ,
                                              AV65InTipo ,
                                              A28ProdCod ,
                                              A55ProdDsc ,
                                              A1997UniAbr ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV10TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV10TFProdCod), 15, "%");
         lV12TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV12TFProdDsc), 100, "%");
         lV61TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV61TFUniAbr), 5, "%");
         lV63TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV63TFProdReferencias), "%", "");
         /* Using cursor P007H3 */
         pr_default.execute(1, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV10TFProdCod, AV11TFProdCod_Sel, lV12TFProdDsc, AV13TFProdDsc_Sel, lV61TFUniAbr, AV62TFUniAbr_Sel, lV63TFProdReferencias, AV64TFProdReferencias_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7H3 = false;
            A49UniCod = P007H3_A49UniCod[0];
            A1718ProdSts = P007H3_A1718ProdSts[0];
            A55ProdDsc = P007H3_A55ProdDsc[0];
            A1679ProdCmp = P007H3_A1679ProdCmp[0];
            A1724ProdVta = P007H3_A1724ProdVta[0];
            A1997UniAbr = P007H3_A1997UniAbr[0];
            A28ProdCod = P007H3_A28ProdCod[0];
            A1706ProdRef10 = P007H3_A1706ProdRef10[0];
            A1714ProdRef9 = P007H3_A1714ProdRef9[0];
            A1713ProdRef8 = P007H3_A1713ProdRef8[0];
            A1712ProdRef7 = P007H3_A1712ProdRef7[0];
            A1711ProdRef6 = P007H3_A1711ProdRef6[0];
            A1710ProdRef5 = P007H3_A1710ProdRef5[0];
            A1709ProdRef4 = P007H3_A1709ProdRef4[0];
            A1708ProdRef3 = P007H3_A1708ProdRef3[0];
            A1707ProdRef2 = P007H3_A1707ProdRef2[0];
            A1705ProdRef1 = P007H3_A1705ProdRef1[0];
            A1997UniAbr = P007H3_A1997UniAbr[0];
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007H3_A55ProdDsc[0], A55ProdDsc) == 0 ) )
            {
               BRK7H3 = false;
               A28ProdCod = P007H3_A28ProdCod[0];
               AV34count = (long)(AV34count+1);
               BRK7H3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A55ProdDsc)) )
            {
               AV26Option = A55ProdDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7H3 )
            {
               BRK7H3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUNIABROPTIONS' Routine */
         returnInSub = false;
         AV61TFUniAbr = AV22SearchTxt;
         AV62TFUniAbr_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV11TFProdCod_Sel ,
                                              AV10TFProdCod ,
                                              AV13TFProdDsc_Sel ,
                                              AV12TFProdDsc ,
                                              AV62TFUniAbr_Sel ,
                                              AV61TFUniAbr ,
                                              AV64TFProdReferencias_Sel ,
                                              AV63TFProdReferencias ,
                                              AV65InTipo ,
                                              A28ProdCod ,
                                              A55ProdDsc ,
                                              A1997UniAbr ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV10TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV10TFProdCod), 15, "%");
         lV12TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV12TFProdDsc), 100, "%");
         lV61TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV61TFUniAbr), 5, "%");
         lV63TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV63TFProdReferencias), "%", "");
         /* Using cursor P007H4 */
         pr_default.execute(2, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV10TFProdCod, AV11TFProdCod_Sel, lV12TFProdDsc, AV13TFProdDsc_Sel, lV61TFUniAbr, AV62TFUniAbr_Sel, lV63TFProdReferencias, AV64TFProdReferencias_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7H5 = false;
            A49UniCod = P007H4_A49UniCod[0];
            A1718ProdSts = P007H4_A1718ProdSts[0];
            A1997UniAbr = P007H4_A1997UniAbr[0];
            A1679ProdCmp = P007H4_A1679ProdCmp[0];
            A1724ProdVta = P007H4_A1724ProdVta[0];
            A55ProdDsc = P007H4_A55ProdDsc[0];
            A28ProdCod = P007H4_A28ProdCod[0];
            A1706ProdRef10 = P007H4_A1706ProdRef10[0];
            A1714ProdRef9 = P007H4_A1714ProdRef9[0];
            A1713ProdRef8 = P007H4_A1713ProdRef8[0];
            A1712ProdRef7 = P007H4_A1712ProdRef7[0];
            A1711ProdRef6 = P007H4_A1711ProdRef6[0];
            A1710ProdRef5 = P007H4_A1710ProdRef5[0];
            A1709ProdRef4 = P007H4_A1709ProdRef4[0];
            A1708ProdRef3 = P007H4_A1708ProdRef3[0];
            A1707ProdRef2 = P007H4_A1707ProdRef2[0];
            A1705ProdRef1 = P007H4_A1705ProdRef1[0];
            A1997UniAbr = P007H4_A1997UniAbr[0];
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007H4_A1997UniAbr[0], A1997UniAbr) == 0 ) )
            {
               BRK7H5 = false;
               A49UniCod = P007H4_A49UniCod[0];
               A28ProdCod = P007H4_A28ProdCod[0];
               AV34count = (long)(AV34count+1);
               BRK7H5 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1997UniAbr)) )
            {
               AV26Option = A1997UniAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7H5 )
            {
               BRK7H5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPRODREFERENCIASOPTIONS' Routine */
         returnInSub = false;
         AV63TFProdReferencias = AV22SearchTxt;
         AV64TFProdReferencias_Sel = "";
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV11TFProdCod_Sel ,
                                              AV10TFProdCod ,
                                              AV13TFProdDsc_Sel ,
                                              AV12TFProdDsc ,
                                              AV62TFUniAbr_Sel ,
                                              AV61TFUniAbr ,
                                              AV64TFProdReferencias_Sel ,
                                              AV63TFProdReferencias ,
                                              AV65InTipo ,
                                              A28ProdCod ,
                                              A55ProdDsc ,
                                              A1997UniAbr ,
                                              A1705ProdRef1 ,
                                              A1707ProdRef2 ,
                                              A1708ProdRef3 ,
                                              A1709ProdRef4 ,
                                              A1710ProdRef5 ,
                                              A1711ProdRef6 ,
                                              A1712ProdRef7 ,
                                              A1713ProdRef8 ,
                                              A1714ProdRef9 ,
                                              A1706ProdRef10 ,
                                              A1724ProdVta ,
                                              A1679ProdCmp ,
                                              A1718ProdSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV10TFProdCod = StringUtil.PadR( StringUtil.RTrim( AV10TFProdCod), 15, "%");
         lV12TFProdDsc = StringUtil.PadR( StringUtil.RTrim( AV12TFProdDsc), 100, "%");
         lV61TFUniAbr = StringUtil.PadR( StringUtil.RTrim( AV61TFUniAbr), 5, "%");
         lV63TFProdReferencias = StringUtil.Concat( StringUtil.RTrim( AV63TFProdReferencias), "%", "");
         /* Using cursor P007H5 */
         pr_default.execute(3, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV10TFProdCod, AV11TFProdCod_Sel, lV12TFProdDsc, AV13TFProdDsc_Sel, lV61TFUniAbr, AV62TFUniAbr_Sel, lV63TFProdReferencias, AV64TFProdReferencias_Sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A49UniCod = P007H5_A49UniCod[0];
            A1679ProdCmp = P007H5_A1679ProdCmp[0];
            A1724ProdVta = P007H5_A1724ProdVta[0];
            A1718ProdSts = P007H5_A1718ProdSts[0];
            A1997UniAbr = P007H5_A1997UniAbr[0];
            A55ProdDsc = P007H5_A55ProdDsc[0];
            A28ProdCod = P007H5_A28ProdCod[0];
            A1706ProdRef10 = P007H5_A1706ProdRef10[0];
            A1714ProdRef9 = P007H5_A1714ProdRef9[0];
            A1713ProdRef8 = P007H5_A1713ProdRef8[0];
            A1712ProdRef7 = P007H5_A1712ProdRef7[0];
            A1711ProdRef6 = P007H5_A1711ProdRef6[0];
            A1710ProdRef5 = P007H5_A1710ProdRef5[0];
            A1709ProdRef4 = P007H5_A1709ProdRef4[0];
            A1708ProdRef3 = P007H5_A1708ProdRef3[0];
            A1707ProdRef2 = P007H5_A1707ProdRef2[0];
            A1705ProdRef1 = P007H5_A1705ProdRef1[0];
            A1997UniAbr = P007H5_A1997UniAbr[0];
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1715ProdReferencias)) )
            {
               AV26Option = A1715ProdReferencias;
               AV25InsertIndex = 1;
               while ( ( AV25InsertIndex <= AV27Options.Count ) && ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) )
               {
                  AV25InsertIndex = (int)(AV25InsertIndex+1);
               }
               if ( ( AV25InsertIndex <= AV27Options.Count ) && ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) == 0 ) )
               {
                  AV34count = (long)(NumberUtil.Val( ((string)AV32OptionIndexes.Item(AV25InsertIndex)), "."));
                  AV34count = (long)(AV34count+1);
                  AV32OptionIndexes.RemoveItem(AV25InsertIndex);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
               }
               else
               {
                  AV27Options.Add(AV26Option, AV25InsertIndex);
                  AV32OptionIndexes.Add("1", AV25InsertIndex);
               }
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(3);
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
         AV60FilterFullText = "";
         AV10TFProdCod = "";
         AV11TFProdCod_Sel = "";
         AV12TFProdDsc = "";
         AV13TFProdDsc_Sel = "";
         AV61TFUniAbr = "";
         AV62TFUniAbr_Sel = "";
         AV63TFProdReferencias = "";
         AV64TFProdReferencias_Sel = "";
         scmdbuf = "";
         lV60FilterFullText = "";
         lV10TFProdCod = "";
         lV12TFProdDsc = "";
         lV61TFUniAbr = "";
         lV63TFProdReferencias = "";
         AV65InTipo = "";
         A28ProdCod = "";
         A55ProdDsc = "";
         A1997UniAbr = "";
         A1705ProdRef1 = "";
         A1707ProdRef2 = "";
         A1708ProdRef3 = "";
         A1709ProdRef4 = "";
         A1710ProdRef5 = "";
         A1711ProdRef6 = "";
         A1712ProdRef7 = "";
         A1713ProdRef8 = "";
         A1714ProdRef9 = "";
         A1706ProdRef10 = "";
         P007H2_A49UniCod = new int[1] ;
         P007H2_A1679ProdCmp = new short[1] ;
         P007H2_A1724ProdVta = new short[1] ;
         P007H2_A1718ProdSts = new short[1] ;
         P007H2_A1997UniAbr = new string[] {""} ;
         P007H2_A55ProdDsc = new string[] {""} ;
         P007H2_A28ProdCod = new string[] {""} ;
         P007H2_A1706ProdRef10 = new string[] {""} ;
         P007H2_A1714ProdRef9 = new string[] {""} ;
         P007H2_A1713ProdRef8 = new string[] {""} ;
         P007H2_A1712ProdRef7 = new string[] {""} ;
         P007H2_A1711ProdRef6 = new string[] {""} ;
         P007H2_A1710ProdRef5 = new string[] {""} ;
         P007H2_A1709ProdRef4 = new string[] {""} ;
         P007H2_A1708ProdRef3 = new string[] {""} ;
         P007H2_A1707ProdRef2 = new string[] {""} ;
         P007H2_A1705ProdRef1 = new string[] {""} ;
         A1715ProdReferencias = "";
         AV26Option = "";
         AV29OptionDesc = "";
         P007H3_A49UniCod = new int[1] ;
         P007H3_A1718ProdSts = new short[1] ;
         P007H3_A55ProdDsc = new string[] {""} ;
         P007H3_A1679ProdCmp = new short[1] ;
         P007H3_A1724ProdVta = new short[1] ;
         P007H3_A1997UniAbr = new string[] {""} ;
         P007H3_A28ProdCod = new string[] {""} ;
         P007H3_A1706ProdRef10 = new string[] {""} ;
         P007H3_A1714ProdRef9 = new string[] {""} ;
         P007H3_A1713ProdRef8 = new string[] {""} ;
         P007H3_A1712ProdRef7 = new string[] {""} ;
         P007H3_A1711ProdRef6 = new string[] {""} ;
         P007H3_A1710ProdRef5 = new string[] {""} ;
         P007H3_A1709ProdRef4 = new string[] {""} ;
         P007H3_A1708ProdRef3 = new string[] {""} ;
         P007H3_A1707ProdRef2 = new string[] {""} ;
         P007H3_A1705ProdRef1 = new string[] {""} ;
         P007H4_A49UniCod = new int[1] ;
         P007H4_A1718ProdSts = new short[1] ;
         P007H4_A1997UniAbr = new string[] {""} ;
         P007H4_A1679ProdCmp = new short[1] ;
         P007H4_A1724ProdVta = new short[1] ;
         P007H4_A55ProdDsc = new string[] {""} ;
         P007H4_A28ProdCod = new string[] {""} ;
         P007H4_A1706ProdRef10 = new string[] {""} ;
         P007H4_A1714ProdRef9 = new string[] {""} ;
         P007H4_A1713ProdRef8 = new string[] {""} ;
         P007H4_A1712ProdRef7 = new string[] {""} ;
         P007H4_A1711ProdRef6 = new string[] {""} ;
         P007H4_A1710ProdRef5 = new string[] {""} ;
         P007H4_A1709ProdRef4 = new string[] {""} ;
         P007H4_A1708ProdRef3 = new string[] {""} ;
         P007H4_A1707ProdRef2 = new string[] {""} ;
         P007H4_A1705ProdRef1 = new string[] {""} ;
         P007H5_A49UniCod = new int[1] ;
         P007H5_A1679ProdCmp = new short[1] ;
         P007H5_A1724ProdVta = new short[1] ;
         P007H5_A1718ProdSts = new short[1] ;
         P007H5_A1997UniAbr = new string[] {""} ;
         P007H5_A55ProdDsc = new string[] {""} ;
         P007H5_A28ProdCod = new string[] {""} ;
         P007H5_A1706ProdRef10 = new string[] {""} ;
         P007H5_A1714ProdRef9 = new string[] {""} ;
         P007H5_A1713ProdRef8 = new string[] {""} ;
         P007H5_A1712ProdRef7 = new string[] {""} ;
         P007H5_A1711ProdRef6 = new string[] {""} ;
         P007H5_A1710ProdRef5 = new string[] {""} ;
         P007H5_A1709ProdRef4 = new string[] {""} ;
         P007H5_A1708ProdRef3 = new string[] {""} ;
         P007H5_A1707ProdRef2 = new string[] {""} ;
         P007H5_A1705ProdRef1 = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.wwbusquedaproductogetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007H2_A49UniCod, P007H2_A1679ProdCmp, P007H2_A1724ProdVta, P007H2_A1718ProdSts, P007H2_A1997UniAbr, P007H2_A55ProdDsc, P007H2_A28ProdCod, P007H2_A1706ProdRef10, P007H2_A1714ProdRef9, P007H2_A1713ProdRef8,
               P007H2_A1712ProdRef7, P007H2_A1711ProdRef6, P007H2_A1710ProdRef5, P007H2_A1709ProdRef4, P007H2_A1708ProdRef3, P007H2_A1707ProdRef2, P007H2_A1705ProdRef1
               }
               , new Object[] {
               P007H3_A49UniCod, P007H3_A1718ProdSts, P007H3_A55ProdDsc, P007H3_A1679ProdCmp, P007H3_A1724ProdVta, P007H3_A1997UniAbr, P007H3_A28ProdCod, P007H3_A1706ProdRef10, P007H3_A1714ProdRef9, P007H3_A1713ProdRef8,
               P007H3_A1712ProdRef7, P007H3_A1711ProdRef6, P007H3_A1710ProdRef5, P007H3_A1709ProdRef4, P007H3_A1708ProdRef3, P007H3_A1707ProdRef2, P007H3_A1705ProdRef1
               }
               , new Object[] {
               P007H4_A49UniCod, P007H4_A1718ProdSts, P007H4_A1997UniAbr, P007H4_A1679ProdCmp, P007H4_A1724ProdVta, P007H4_A55ProdDsc, P007H4_A28ProdCod, P007H4_A1706ProdRef10, P007H4_A1714ProdRef9, P007H4_A1713ProdRef8,
               P007H4_A1712ProdRef7, P007H4_A1711ProdRef6, P007H4_A1710ProdRef5, P007H4_A1709ProdRef4, P007H4_A1708ProdRef3, P007H4_A1707ProdRef2, P007H4_A1705ProdRef1
               }
               , new Object[] {
               P007H5_A49UniCod, P007H5_A1679ProdCmp, P007H5_A1724ProdVta, P007H5_A1718ProdSts, P007H5_A1997UniAbr, P007H5_A55ProdDsc, P007H5_A28ProdCod, P007H5_A1706ProdRef10, P007H5_A1714ProdRef9, P007H5_A1713ProdRef8,
               P007H5_A1712ProdRef7, P007H5_A1711ProdRef6, P007H5_A1710ProdRef5, P007H5_A1709ProdRef4, P007H5_A1708ProdRef3, P007H5_A1707ProdRef2, P007H5_A1705ProdRef1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1724ProdVta ;
      private short A1679ProdCmp ;
      private short A1718ProdSts ;
      private int AV68GXV1 ;
      private int A49UniCod ;
      private int AV25InsertIndex ;
      private long AV34count ;
      private string AV10TFProdCod ;
      private string AV11TFProdCod_Sel ;
      private string AV12TFProdDsc ;
      private string AV13TFProdDsc_Sel ;
      private string AV61TFUniAbr ;
      private string AV62TFUniAbr_Sel ;
      private string scmdbuf ;
      private string lV10TFProdCod ;
      private string lV12TFProdDsc ;
      private string lV61TFUniAbr ;
      private string A28ProdCod ;
      private string A55ProdDsc ;
      private string A1997UniAbr ;
      private string A1705ProdRef1 ;
      private string A1707ProdRef2 ;
      private string A1708ProdRef3 ;
      private string A1709ProdRef4 ;
      private string A1710ProdRef5 ;
      private string A1711ProdRef6 ;
      private string A1712ProdRef7 ;
      private string A1713ProdRef8 ;
      private string A1714ProdRef9 ;
      private string A1706ProdRef10 ;
      private bool returnInSub ;
      private bool BRK7H3 ;
      private bool BRK7H5 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV60FilterFullText ;
      private string AV63TFProdReferencias ;
      private string AV64TFProdReferencias_Sel ;
      private string lV60FilterFullText ;
      private string lV63TFProdReferencias ;
      private string AV65InTipo ;
      private string A1715ProdReferencias ;
      private string AV26Option ;
      private string AV29OptionDesc ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P007H2_A49UniCod ;
      private short[] P007H2_A1679ProdCmp ;
      private short[] P007H2_A1724ProdVta ;
      private short[] P007H2_A1718ProdSts ;
      private string[] P007H2_A1997UniAbr ;
      private string[] P007H2_A55ProdDsc ;
      private string[] P007H2_A28ProdCod ;
      private string[] P007H2_A1706ProdRef10 ;
      private string[] P007H2_A1714ProdRef9 ;
      private string[] P007H2_A1713ProdRef8 ;
      private string[] P007H2_A1712ProdRef7 ;
      private string[] P007H2_A1711ProdRef6 ;
      private string[] P007H2_A1710ProdRef5 ;
      private string[] P007H2_A1709ProdRef4 ;
      private string[] P007H2_A1708ProdRef3 ;
      private string[] P007H2_A1707ProdRef2 ;
      private string[] P007H2_A1705ProdRef1 ;
      private int[] P007H3_A49UniCod ;
      private short[] P007H3_A1718ProdSts ;
      private string[] P007H3_A55ProdDsc ;
      private short[] P007H3_A1679ProdCmp ;
      private short[] P007H3_A1724ProdVta ;
      private string[] P007H3_A1997UniAbr ;
      private string[] P007H3_A28ProdCod ;
      private string[] P007H3_A1706ProdRef10 ;
      private string[] P007H3_A1714ProdRef9 ;
      private string[] P007H3_A1713ProdRef8 ;
      private string[] P007H3_A1712ProdRef7 ;
      private string[] P007H3_A1711ProdRef6 ;
      private string[] P007H3_A1710ProdRef5 ;
      private string[] P007H3_A1709ProdRef4 ;
      private string[] P007H3_A1708ProdRef3 ;
      private string[] P007H3_A1707ProdRef2 ;
      private string[] P007H3_A1705ProdRef1 ;
      private int[] P007H4_A49UniCod ;
      private short[] P007H4_A1718ProdSts ;
      private string[] P007H4_A1997UniAbr ;
      private short[] P007H4_A1679ProdCmp ;
      private short[] P007H4_A1724ProdVta ;
      private string[] P007H4_A55ProdDsc ;
      private string[] P007H4_A28ProdCod ;
      private string[] P007H4_A1706ProdRef10 ;
      private string[] P007H4_A1714ProdRef9 ;
      private string[] P007H4_A1713ProdRef8 ;
      private string[] P007H4_A1712ProdRef7 ;
      private string[] P007H4_A1711ProdRef6 ;
      private string[] P007H4_A1710ProdRef5 ;
      private string[] P007H4_A1709ProdRef4 ;
      private string[] P007H4_A1708ProdRef3 ;
      private string[] P007H4_A1707ProdRef2 ;
      private string[] P007H4_A1705ProdRef1 ;
      private int[] P007H5_A49UniCod ;
      private short[] P007H5_A1679ProdCmp ;
      private short[] P007H5_A1724ProdVta ;
      private short[] P007H5_A1718ProdSts ;
      private string[] P007H5_A1997UniAbr ;
      private string[] P007H5_A55ProdDsc ;
      private string[] P007H5_A28ProdCod ;
      private string[] P007H5_A1706ProdRef10 ;
      private string[] P007H5_A1714ProdRef9 ;
      private string[] P007H5_A1713ProdRef8 ;
      private string[] P007H5_A1712ProdRef7 ;
      private string[] P007H5_A1711ProdRef6 ;
      private string[] P007H5_A1710ProdRef5 ;
      private string[] P007H5_A1709ProdRef4 ;
      private string[] P007H5_A1708ProdRef3 ;
      private string[] P007H5_A1707ProdRef2 ;
      private string[] P007H5_A1705ProdRef1 ;
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

   public class wwbusquedaproductogetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007H2( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV11TFProdCod_Sel ,
                                             string AV10TFProdCod ,
                                             string AV13TFProdDsc_Sel ,
                                             string AV12TFProdDsc ,
                                             string AV62TFUniAbr_Sel ,
                                             string AV61TFUniAbr ,
                                             string AV64TFProdReferencias_Sel ,
                                             string AV63TFProdReferencias ,
                                             string AV65InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [UniCod], NULL AS [ProdCmp], NULL AS [ProdVta], NULL AS [ProdSts], NULL AS [UniAbr], NULL AS [ProdDsc], [ProdCod], NULL AS [ProdRef10], NULL AS [ProdRef9], NULL AS [ProdRef8], NULL AS [ProdRef7], NULL AS [ProdRef6], NULL AS [ProdRef5], NULL AS [ProdRef4], NULL AS [ProdRef3], NULL AS [ProdRef2], NULL AS [ProdRef1] FROM ( SELECT TOP(100) PERCENT T1.[UniCod], T1.[ProdCmp], T1.[ProdVta], T1.[ProdSts], T2.[UniAbr], T1.[ProdDsc], T1.[ProdCod], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1] FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV10TFProdCod)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV11TFProdCod_Sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV12TFProdDsc)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV13TFProdDsc_Sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV61TFUniAbr)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV62TFUniAbr_Sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV63TFProdReferencias)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV64TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV65InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [ProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007H3( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV11TFProdCod_Sel ,
                                             string AV10TFProdCod ,
                                             string AV13TFProdDsc_Sel ,
                                             string AV12TFProdDsc ,
                                             string AV62TFUniAbr_Sel ,
                                             string AV61TFUniAbr ,
                                             string AV64TFProdReferencias_Sel ,
                                             string AV63TFProdReferencias ,
                                             string AV65InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[UniCod], T1.[ProdSts], T1.[ProdDsc], T1.[ProdCmp], T1.[ProdVta], T2.[UniAbr], T1.[ProdCod], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1] FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV10TFProdCod)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV11TFProdCod_Sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV12TFProdDsc)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV13TFProdDsc_Sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV61TFUniAbr)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV62TFUniAbr_Sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV63TFProdReferencias)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV64TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV65InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007H4( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV11TFProdCod_Sel ,
                                             string AV10TFProdCod ,
                                             string AV13TFProdDsc_Sel ,
                                             string AV12TFProdDsc ,
                                             string AV62TFUniAbr_Sel ,
                                             string AV61TFUniAbr ,
                                             string AV64TFProdReferencias_Sel ,
                                             string AV63TFProdReferencias ,
                                             string AV65InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[UniCod], T1.[ProdSts], T2.[UniAbr], T1.[ProdCmp], T1.[ProdVta], T1.[ProdDsc], T1.[ProdCod], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1] FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV10TFProdCod)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV11TFProdCod_Sel)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV12TFProdDsc)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV13TFProdDsc_Sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV61TFUniAbr)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV62TFUniAbr_Sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV63TFProdReferencias)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV64TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV65InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[UniAbr]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007H5( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV11TFProdCod_Sel ,
                                             string AV10TFProdCod ,
                                             string AV13TFProdDsc_Sel ,
                                             string AV12TFProdDsc ,
                                             string AV62TFUniAbr_Sel ,
                                             string AV61TFUniAbr ,
                                             string AV64TFProdReferencias_Sel ,
                                             string AV63TFProdReferencias ,
                                             string AV65InTipo ,
                                             string A28ProdCod ,
                                             string A55ProdDsc ,
                                             string A1997UniAbr ,
                                             string A1705ProdRef1 ,
                                             string A1707ProdRef2 ,
                                             string A1708ProdRef3 ,
                                             string A1709ProdRef4 ,
                                             string A1710ProdRef5 ,
                                             string A1711ProdRef6 ,
                                             string A1712ProdRef7 ,
                                             string A1713ProdRef8 ,
                                             string A1714ProdRef9 ,
                                             string A1706ProdRef10 ,
                                             short A1724ProdVta ,
                                             short A1679ProdCmp ,
                                             short A1718ProdSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[12];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[UniCod], T1.[ProdCmp], T1.[ProdVta], T1.[ProdSts], T2.[UniAbr], T1.[ProdDsc], T1.[ProdCod], T1.[ProdRef10], T1.[ProdRef9], T1.[ProdRef8], T1.[ProdRef7], T1.[ProdRef6], T1.[ProdRef5], T1.[ProdRef4], T1.[ProdRef3], T1.[ProdRef2], T1.[ProdRef1] FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod])";
         AddWhere(sWhereString, "(T1.[ProdSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( T1.[ProdCod] like '%' + @lV60FilterFullText) or ( T1.[ProdDsc] like '%' + @lV60FilterFullText) or ( T2.[UniAbr] like '%' + @lV60FilterFullText) or ( RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10TFProdCod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV10TFProdCod)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11TFProdCod_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV11TFProdCod_Sel)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12TFProdDsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] like @lV12TFProdDsc)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13TFProdDsc_Sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdDsc] = @AV13TFProdDsc_Sel)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFUniAbr)) ) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] like @lV61TFUniAbr)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFUniAbr_Sel)) )
         {
            AddWhere(sWhereString, "(T2.[UniAbr] = @AV62TFUniAbr_Sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFProdReferencias)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) like @lV63TFProdReferencias)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFProdReferencias_Sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T1.[ProdRef1])) + ' ' + RTRIM(LTRIM(T1.[ProdRef2])) + ' ' + RTRIM(LTRIM(T1.[ProdRef3])) + ' ' + RTRIM(LTRIM(T1.[ProdRef4])) + ' ' + RTRIM(LTRIM(T1.[ProdRef5])) + ' ' + RTRIM(LTRIM(T1.[ProdRef6])) + ' ' + RTRIM(LTRIM(T1.[ProdRef7])) + ' ' + RTRIM(LTRIM(T1.[ProdRef8])) + ' ' + RTRIM(LTRIM(T1.[ProdRef9])) + ' ' + RTRIM(LTRIM(T1.[ProdRef10])) = @AV64TFProdReferencias_Sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV65InTipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdVta] = 1)");
         }
         if ( StringUtil.StrCmp(AV65InTipo, "C") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProdCmp] = 1)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
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
                     return conditional_P007H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_P007H3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 2 :
                     return conditional_P007H4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
               case 3 :
                     return conditional_P007H5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP007H2;
          prmP007H2 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV10TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV12TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV13TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV61TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV62TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV63TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV64TFProdReferencias_Sel",GXType.VarChar,200,0)
          };
          Object[] prmP007H3;
          prmP007H3 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV10TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV12TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV13TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV61TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV62TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV63TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV64TFProdReferencias_Sel",GXType.VarChar,200,0)
          };
          Object[] prmP007H4;
          prmP007H4 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV10TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV12TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV13TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV61TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV62TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV63TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV64TFProdReferencias_Sel",GXType.VarChar,200,0)
          };
          Object[] prmP007H5;
          prmP007H5 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.VarChar,100,0) ,
          new ParDef("@lV10TFProdCod",GXType.NChar,15,0) ,
          new ParDef("@AV11TFProdCod_Sel",GXType.NChar,15,0) ,
          new ParDef("@lV12TFProdDsc",GXType.NChar,100,0) ,
          new ParDef("@AV13TFProdDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV61TFUniAbr",GXType.NChar,5,0) ,
          new ParDef("@AV62TFUniAbr_Sel",GXType.NChar,5,0) ,
          new ParDef("@lV63TFProdReferencias",GXType.VarChar,200,0) ,
          new ParDef("@AV64TFProdReferencias_Sel",GXType.VarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007H4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007H5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H5,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 5);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 15);
                ((string[]) buf[7])[0] = rslt.getString(8, 20);
                ((string[]) buf[8])[0] = rslt.getString(9, 20);
                ((string[]) buf[9])[0] = rslt.getString(10, 20);
                ((string[]) buf[10])[0] = rslt.getString(11, 20);
                ((string[]) buf[11])[0] = rslt.getString(12, 20);
                ((string[]) buf[12])[0] = rslt.getString(13, 20);
                ((string[]) buf[13])[0] = rslt.getString(14, 20);
                ((string[]) buf[14])[0] = rslt.getString(15, 20);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((string[]) buf[16])[0] = rslt.getString(17, 20);
                return;
       }
    }

 }

}
