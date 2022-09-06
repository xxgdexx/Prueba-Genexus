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
   public class clientesloaddvcombo : GXProcedure
   {
      public clientesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clientesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_CliCod ,
                           string aP4_Cond_PaiCod ,
                           string aP5_Cond_EstCod ,
                           string aP6_Cond_ProvCod ,
                           string aP7_SearchTxt ,
                           out string aP8_SelectedValue ,
                           out string aP9_SelectedText ,
                           out string aP10_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV33CliCod = aP3_CliCod;
         this.AV38Cond_PaiCod = aP4_Cond_PaiCod;
         this.AV39Cond_EstCod = aP5_Cond_EstCod;
         this.AV40Cond_ProvCod = aP6_Cond_ProvCod;
         this.AV11SearchTxt = aP7_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP8_SelectedValue=this.AV15SelectedValue;
         aP9_SelectedText=this.AV20SelectedText;
         aP10_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                string aP3_CliCod ,
                                string aP4_Cond_PaiCod ,
                                string aP5_Cond_EstCod ,
                                string aP6_Cond_ProvCod ,
                                string aP7_SearchTxt ,
                                out string aP8_SelectedValue ,
                                out string aP9_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CliCod, aP4_Cond_PaiCod, aP5_Cond_EstCod, aP6_Cond_ProvCod, aP7_SearchTxt, out aP8_SelectedValue, out aP9_SelectedText, out aP10_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_CliCod ,
                                 string aP4_Cond_PaiCod ,
                                 string aP5_Cond_EstCod ,
                                 string aP6_Cond_ProvCod ,
                                 string aP7_SearchTxt ,
                                 out string aP8_SelectedValue ,
                                 out string aP9_SelectedText ,
                                 out string aP10_Combo_DataJson )
      {
         clientesloaddvcombo objclientesloaddvcombo;
         objclientesloaddvcombo = new clientesloaddvcombo();
         objclientesloaddvcombo.AV16ComboName = aP0_ComboName;
         objclientesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objclientesloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objclientesloaddvcombo.AV33CliCod = aP3_CliCod;
         objclientesloaddvcombo.AV38Cond_PaiCod = aP4_Cond_PaiCod;
         objclientesloaddvcombo.AV39Cond_EstCod = aP5_Cond_EstCod;
         objclientesloaddvcombo.AV40Cond_ProvCod = aP6_Cond_ProvCod;
         objclientesloaddvcombo.AV11SearchTxt = aP7_SearchTxt;
         objclientesloaddvcombo.AV15SelectedValue = "" ;
         objclientesloaddvcombo.AV20SelectedText = "" ;
         objclientesloaddvcombo.AV12Combo_DataJson = "" ;
         objclientesloaddvcombo.context.SetSubmitInitialConfig(context);
         objclientesloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objclientesloaddvcombo);
         aP8_SelectedValue=this.AV15SelectedValue;
         aP9_SelectedText=this.AV20SelectedText;
         aP10_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientesloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 100;
         if ( StringUtil.StrCmp(AV16ComboName, "CliDirZonCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLIDIRZONCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "EstCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ESTCOD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "PaiCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PAICOD' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "TipCCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPCCOD' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "Conpcod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CONPCOD' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CliVend") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLIVEND' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "DisCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DISCOD' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ProvCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROVCOD' */
            S181 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ZonCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_ZONCOD' */
            S191 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CliTipLCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CLITIPLCOD' */
            S201 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "TipSCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPSCOD' */
            S211 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_CLIDIRZONCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "GET_DSC") == 0 )
            {
               AV35ValuesCollection.FromJSonString(AV11SearchTxt, null);
               AV34DscsCollection = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
               AV43GXV1 = 1;
               while ( AV43GXV1 <= AV35ValuesCollection.Count )
               {
                  AV36ValueItem = ((string)AV35ValuesCollection.Item(AV43GXV1));
                  AV37ZonCod_Filter = (int)(NumberUtil.Val( AV36ValueItem, "."));
                  AV44GXLvl46 = 0;
                  /* Using cursor P00G92 */
                  pr_default.execute(0, new Object[] {AV37ZonCod_Filter});
                  while ( (pr_default.getStatus(0) != 101) )
                  {
                     A158ZonCod = P00G92_A158ZonCod[0];
                     n158ZonCod = P00G92_n158ZonCod[0];
                     A2094ZonDsc = P00G92_A2094ZonDsc[0];
                     AV44GXLvl46 = 1;
                     AV34DscsCollection.Add(A2094ZonDsc, 0);
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(0);
                  if ( AV44GXLvl46 == 0 )
                  {
                     AV34DscsCollection.Add("", 0);
                  }
                  AV43GXV1 = (int)(AV43GXV1+1);
               }
               AV12Combo_DataJson = AV34DscsCollection.ToJSonString(false);
            }
            else
            {
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV11SearchTxt ,
                                                    A2094ZonDsc } ,
                                                    new int[]{
                                                    }
               });
               lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
               /* Using cursor P00G93 */
               pr_default.execute(1, new Object[] {lV11SearchTxt});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A2094ZonDsc = P00G93_A2094ZonDsc[0];
                  A158ZonCod = P00G93_A158ZonCod[0];
                  n158ZonCod = P00G93_n158ZonCod[0];
                  AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
                  AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0));
                  AV14Combo_DataItem.gxTpr_Title = A2094ZonDsc;
                  AV13Combo_Data.Add(AV14Combo_DataItem, 0);
                  if ( AV13Combo_Data.Count > AV10MaxItems )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
            }
         }
         else
         {
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_ESTCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A602EstDsc ,
                                                 A139PaiCod ,
                                                 AV38Cond_PaiCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G94 */
            pr_default.execute(2, new Object[] {AV38Cond_PaiCod, lV11SearchTxt});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A139PaiCod = P00G94_A139PaiCod[0];
               A602EstDsc = P00G94_A602EstDsc[0];
               A140EstCod = P00G94_A140EstCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A140EstCod;
               AV14Combo_DataItem.gxTpr_Title = A602EstDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G95 */
                  pr_default.execute(3, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A139PaiCod = P00G95_A139PaiCod[0];
                     A45CliCod = P00G95_A45CliCod[0];
                     A140EstCod = P00G95_A140EstCod[0];
                     A602EstDsc = P00G95_A602EstDsc[0];
                     A602EstDsc = P00G95_A602EstDsc[0];
                     AV15SelectedValue = A140EstCod;
                     AV20SelectedText = A602EstDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV23EstCod = AV11SearchTxt;
                  /* Using cursor P00G96 */
                  pr_default.execute(4, new Object[] {AV38Cond_PaiCod, AV23EstCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A139PaiCod = P00G96_A139PaiCod[0];
                     A140EstCod = P00G96_A140EstCod[0];
                     A602EstDsc = P00G96_A602EstDsc[0];
                     AV20SelectedText = A602EstDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_PAICOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1500PaiDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G97 */
            pr_default.execute(5, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A1500PaiDsc = P00G97_A1500PaiDsc[0];
               A139PaiCod = P00G97_A139PaiCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A139PaiCod;
               AV14Combo_DataItem.gxTpr_Title = A1500PaiDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G98 */
                  pr_default.execute(6, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A45CliCod = P00G98_A45CliCod[0];
                     A139PaiCod = P00G98_A139PaiCod[0];
                     A1500PaiDsc = P00G98_A1500PaiDsc[0];
                     A1500PaiDsc = P00G98_A1500PaiDsc[0];
                     AV15SelectedValue = A139PaiCod;
                     AV20SelectedText = A1500PaiDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
               else
               {
                  AV24PaiCod = AV11SearchTxt;
                  /* Using cursor P00G99 */
                  pr_default.execute(7, new Object[] {AV24PaiCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A139PaiCod = P00G99_A139PaiCod[0];
                     A1500PaiDsc = P00G99_A1500PaiDsc[0];
                     AV20SelectedText = A1500PaiDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_TIPCCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1905TipCDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G910 */
            pr_default.execute(8, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A1905TipCDsc = P00G910_A1905TipCDsc[0];
               A159TipCCod = P00G910_A159TipCCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A159TipCCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1905TipCDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(8);
            }
            pr_default.close(8);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G911 */
                  pr_default.execute(9, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A45CliCod = P00G911_A45CliCod[0];
                     A159TipCCod = P00G911_A159TipCCod[0];
                     A1905TipCDsc = P00G911_A1905TipCDsc[0];
                     A1905TipCDsc = P00G911_A1905TipCDsc[0];
                     AV15SelectedValue = ((0==A159TipCCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A159TipCCod), 6, 0)));
                     AV20SelectedText = A1905TipCDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(9);
               }
               else
               {
                  AV25TipCCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00G912 */
                  pr_default.execute(10, new Object[] {AV25TipCCod});
                  while ( (pr_default.getStatus(10) != 101) )
                  {
                     A159TipCCod = P00G912_A159TipCCod[0];
                     A1905TipCDsc = P00G912_A1905TipCDsc[0];
                     AV20SelectedText = A1905TipCDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(10);
               }
            }
         }
      }

      protected void S151( )
      {
         /* 'LOADCOMBOITEMS_CONPCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(11, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A753ConpDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G913 */
            pr_default.execute(11, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(11) != 101) )
            {
               A753ConpDsc = P00G913_A753ConpDsc[0];
               A137Conpcod = P00G913_A137Conpcod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A137Conpcod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A753ConpDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(11);
            }
            pr_default.close(11);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G914 */
                  pr_default.execute(12, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(12) != 101) )
                  {
                     A45CliCod = P00G914_A45CliCod[0];
                     A137Conpcod = P00G914_A137Conpcod[0];
                     A753ConpDsc = P00G914_A753ConpDsc[0];
                     A753ConpDsc = P00G914_A753ConpDsc[0];
                     AV15SelectedValue = ((0==A137Conpcod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A137Conpcod), 6, 0)));
                     AV20SelectedText = A753ConpDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(12);
               }
               else
               {
                  AV26Conpcod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00G915 */
                  pr_default.execute(13, new Object[] {AV26Conpcod});
                  while ( (pr_default.getStatus(13) != 101) )
                  {
                     A137Conpcod = P00G915_A137Conpcod[0];
                     A753ConpDsc = P00G915_A753ConpDsc[0];
                     AV20SelectedText = A753ConpDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(13);
               }
            }
         }
      }

      protected void S161( )
      {
         /* 'LOADCOMBOITEMS_CLIVEND' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(14, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A2045VenDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G916 */
            pr_default.execute(14, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(14) != 101) )
            {
               A2045VenDsc = P00G916_A2045VenDsc[0];
               A309VenCod = P00G916_A309VenCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A2045VenDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(14);
            }
            pr_default.close(14);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G917 */
                  pr_default.execute(15, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(15) != 101) )
                  {
                     A45CliCod = P00G917_A45CliCod[0];
                     A160CliVend = P00G917_A160CliVend[0];
                     AV15SelectedValue = ((0==A160CliVend) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A160CliVend), 6, 0)));
                     AV27VenCod = A160CliVend;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(15);
               }
               else
               {
                  AV27VenCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P00G918 */
               pr_default.execute(16, new Object[] {AV27VenCod});
               while ( (pr_default.getStatus(16) != 101) )
               {
                  A309VenCod = P00G918_A309VenCod[0];
                  A2045VenDsc = P00G918_A2045VenDsc[0];
                  AV20SelectedText = A2045VenDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(16);
            }
         }
      }

      protected void S171( )
      {
         /* 'LOADCOMBOITEMS_DISCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(17, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A604DisDsc ,
                                                 A139PaiCod ,
                                                 AV38Cond_PaiCod ,
                                                 A140EstCod ,
                                                 AV39Cond_EstCod ,
                                                 A141ProvCod ,
                                                 AV40Cond_ProvCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G919 */
            pr_default.execute(17, new Object[] {AV38Cond_PaiCod, AV39Cond_EstCod, AV40Cond_ProvCod, lV11SearchTxt});
            while ( (pr_default.getStatus(17) != 101) )
            {
               A139PaiCod = P00G919_A139PaiCod[0];
               A140EstCod = P00G919_A140EstCod[0];
               A141ProvCod = P00G919_A141ProvCod[0];
               A604DisDsc = P00G919_A604DisDsc[0];
               A142DisCod = P00G919_A142DisCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A142DisCod;
               AV14Combo_DataItem.gxTpr_Title = A604DisDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(17);
            }
            pr_default.close(17);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G920 */
                  pr_default.execute(18, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(18) != 101) )
                  {
                     A139PaiCod = P00G920_A139PaiCod[0];
                     A140EstCod = P00G920_A140EstCod[0];
                     A141ProvCod = P00G920_A141ProvCod[0];
                     A45CliCod = P00G920_A45CliCod[0];
                     A142DisCod = P00G920_A142DisCod[0];
                     A604DisDsc = P00G920_A604DisDsc[0];
                     A604DisDsc = P00G920_A604DisDsc[0];
                     AV15SelectedValue = A142DisCod;
                     AV20SelectedText = A604DisDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(18);
               }
               else
               {
                  AV28DisCod = AV11SearchTxt;
                  /* Using cursor P00G921 */
                  pr_default.execute(19, new Object[] {AV38Cond_PaiCod, AV39Cond_EstCod, AV40Cond_ProvCod, AV28DisCod});
                  while ( (pr_default.getStatus(19) != 101) )
                  {
                     A141ProvCod = P00G921_A141ProvCod[0];
                     A140EstCod = P00G921_A140EstCod[0];
                     A139PaiCod = P00G921_A139PaiCod[0];
                     A142DisCod = P00G921_A142DisCod[0];
                     A604DisDsc = P00G921_A604DisDsc[0];
                     AV20SelectedText = A604DisDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(19);
               }
            }
         }
      }

      protected void S181( )
      {
         /* 'LOADCOMBOITEMS_PROVCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(20, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A603ProvDsc ,
                                                 A139PaiCod ,
                                                 AV38Cond_PaiCod ,
                                                 A140EstCod ,
                                                 AV39Cond_EstCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G922 */
            pr_default.execute(20, new Object[] {AV38Cond_PaiCod, AV39Cond_EstCod, lV11SearchTxt});
            while ( (pr_default.getStatus(20) != 101) )
            {
               A139PaiCod = P00G922_A139PaiCod[0];
               A140EstCod = P00G922_A140EstCod[0];
               A603ProvDsc = P00G922_A603ProvDsc[0];
               A141ProvCod = P00G922_A141ProvCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A141ProvCod;
               AV14Combo_DataItem.gxTpr_Title = A603ProvDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(20);
            }
            pr_default.close(20);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G923 */
                  pr_default.execute(21, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(21) != 101) )
                  {
                     A139PaiCod = P00G923_A139PaiCod[0];
                     A140EstCod = P00G923_A140EstCod[0];
                     A45CliCod = P00G923_A45CliCod[0];
                     A141ProvCod = P00G923_A141ProvCod[0];
                     A603ProvDsc = P00G923_A603ProvDsc[0];
                     A603ProvDsc = P00G923_A603ProvDsc[0];
                     AV15SelectedValue = A141ProvCod;
                     AV20SelectedText = A603ProvDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(21);
               }
               else
               {
                  AV29ProvCod = AV11SearchTxt;
                  /* Using cursor P00G924 */
                  pr_default.execute(22, new Object[] {AV38Cond_PaiCod, AV39Cond_EstCod, AV29ProvCod});
                  while ( (pr_default.getStatus(22) != 101) )
                  {
                     A140EstCod = P00G924_A140EstCod[0];
                     A139PaiCod = P00G924_A139PaiCod[0];
                     A141ProvCod = P00G924_A141ProvCod[0];
                     A603ProvDsc = P00G924_A603ProvDsc[0];
                     AV20SelectedText = A603ProvDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(22);
               }
            }
         }
      }

      protected void S191( )
      {
         /* 'LOADCOMBOITEMS_ZONCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(23, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A2094ZonDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G925 */
            pr_default.execute(23, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(23) != 101) )
            {
               A2094ZonDsc = P00G925_A2094ZonDsc[0];
               A158ZonCod = P00G925_A158ZonCod[0];
               n158ZonCod = P00G925_n158ZonCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A2094ZonDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(23);
            }
            pr_default.close(23);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G926 */
                  pr_default.execute(24, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(24) != 101) )
                  {
                     A45CliCod = P00G926_A45CliCod[0];
                     A158ZonCod = P00G926_A158ZonCod[0];
                     n158ZonCod = P00G926_n158ZonCod[0];
                     A2094ZonDsc = P00G926_A2094ZonDsc[0];
                     A2094ZonDsc = P00G926_A2094ZonDsc[0];
                     AV15SelectedValue = ((0==A158ZonCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A158ZonCod), 6, 0)));
                     AV20SelectedText = A2094ZonDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(24);
               }
               else
               {
                  AV30ZonCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00G927 */
                  pr_default.execute(25, new Object[] {AV30ZonCod});
                  while ( (pr_default.getStatus(25) != 101) )
                  {
                     A158ZonCod = P00G927_A158ZonCod[0];
                     n158ZonCod = P00G927_n158ZonCod[0];
                     A2094ZonDsc = P00G927_A2094ZonDsc[0];
                     AV20SelectedText = A2094ZonDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(25);
               }
            }
         }
      }

      protected void S201( )
      {
         /* 'LOADCOMBOITEMS_CLITIPLCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(26, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1912TipLDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G928 */
            pr_default.execute(26, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(26) != 101) )
            {
               A1912TipLDsc = P00G928_A1912TipLDsc[0];
               A202TipLCod = P00G928_A202TipLCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A202TipLCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1912TipLDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(26);
            }
            pr_default.close(26);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G929 */
                  pr_default.execute(27, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(27) != 101) )
                  {
                     A45CliCod = P00G929_A45CliCod[0];
                     A156CliTipLCod = P00G929_A156CliTipLCod[0];
                     n156CliTipLCod = P00G929_n156CliTipLCod[0];
                     AV15SelectedValue = ((0==A156CliTipLCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A156CliTipLCod), 6, 0)));
                     AV31TipLCod = A156CliTipLCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(27);
               }
               else
               {
                  AV31TipLCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P00G930 */
               pr_default.execute(28, new Object[] {AV31TipLCod});
               while ( (pr_default.getStatus(28) != 101) )
               {
                  A202TipLCod = P00G930_A202TipLCod[0];
                  A1912TipLDsc = P00G930_A1912TipLDsc[0];
                  AV20SelectedText = A1912TipLDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(28);
            }
         }
      }

      protected void S211( )
      {
         /* 'LOADCOMBOITEMS_TIPSCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(29, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1917TipSDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00G931 */
            pr_default.execute(29, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(29) != 101) )
            {
               A1917TipSDsc = P00G931_A1917TipSDsc[0];
               A157TipSCod = P00G931_A157TipSCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A157TipSCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1917TipSDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(29);
            }
            pr_default.close(29);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00G932 */
                  pr_default.execute(30, new Object[] {AV33CliCod});
                  while ( (pr_default.getStatus(30) != 101) )
                  {
                     A45CliCod = P00G932_A45CliCod[0];
                     A157TipSCod = P00G932_A157TipSCod[0];
                     A1917TipSDsc = P00G932_A1917TipSDsc[0];
                     A1917TipSDsc = P00G932_A1917TipSDsc[0];
                     AV15SelectedValue = ((0==A157TipSCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A157TipSCod), 6, 0)));
                     AV20SelectedText = A1917TipSDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(30);
               }
               else
               {
                  AV32TipSCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00G933 */
                  pr_default.execute(31, new Object[] {AV32TipSCod});
                  while ( (pr_default.getStatus(31) != 101) )
                  {
                     A157TipSCod = P00G933_A157TipSCod[0];
                     A1917TipSDsc = P00G933_A1917TipSDsc[0];
                     AV20SelectedText = A1917TipSDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(31);
               }
            }
         }
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
         AV15SelectedValue = "";
         AV20SelectedText = "";
         AV12Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35ValuesCollection = new GxSimpleCollection<string>();
         AV34DscsCollection = new GxSimpleCollection<string>();
         AV36ValueItem = "";
         scmdbuf = "";
         P00G92_A158ZonCod = new int[1] ;
         P00G92_n158ZonCod = new bool[] {false} ;
         P00G92_A2094ZonDsc = new string[] {""} ;
         A2094ZonDsc = "";
         lV11SearchTxt = "";
         P00G93_A2094ZonDsc = new string[] {""} ;
         P00G93_A158ZonCod = new int[1] ;
         P00G93_n158ZonCod = new bool[] {false} ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A602EstDsc = "";
         A139PaiCod = "";
         P00G94_A139PaiCod = new string[] {""} ;
         P00G94_A602EstDsc = new string[] {""} ;
         P00G94_A140EstCod = new string[] {""} ;
         A140EstCod = "";
         P00G95_A139PaiCod = new string[] {""} ;
         P00G95_A45CliCod = new string[] {""} ;
         P00G95_A140EstCod = new string[] {""} ;
         P00G95_A602EstDsc = new string[] {""} ;
         A45CliCod = "";
         AV23EstCod = "";
         P00G96_A139PaiCod = new string[] {""} ;
         P00G96_A140EstCod = new string[] {""} ;
         P00G96_A602EstDsc = new string[] {""} ;
         A1500PaiDsc = "";
         P00G97_A1500PaiDsc = new string[] {""} ;
         P00G97_A139PaiCod = new string[] {""} ;
         P00G98_A45CliCod = new string[] {""} ;
         P00G98_A139PaiCod = new string[] {""} ;
         P00G98_A1500PaiDsc = new string[] {""} ;
         AV24PaiCod = "";
         P00G99_A139PaiCod = new string[] {""} ;
         P00G99_A1500PaiDsc = new string[] {""} ;
         A1905TipCDsc = "";
         P00G910_A1905TipCDsc = new string[] {""} ;
         P00G910_A159TipCCod = new int[1] ;
         P00G911_A45CliCod = new string[] {""} ;
         P00G911_A159TipCCod = new int[1] ;
         P00G911_A1905TipCDsc = new string[] {""} ;
         P00G912_A159TipCCod = new int[1] ;
         P00G912_A1905TipCDsc = new string[] {""} ;
         A753ConpDsc = "";
         P00G913_A753ConpDsc = new string[] {""} ;
         P00G913_A137Conpcod = new int[1] ;
         P00G914_A45CliCod = new string[] {""} ;
         P00G914_A137Conpcod = new int[1] ;
         P00G914_A753ConpDsc = new string[] {""} ;
         P00G915_A137Conpcod = new int[1] ;
         P00G915_A753ConpDsc = new string[] {""} ;
         A2045VenDsc = "";
         P00G916_A2045VenDsc = new string[] {""} ;
         P00G916_A309VenCod = new int[1] ;
         P00G917_A45CliCod = new string[] {""} ;
         P00G917_A160CliVend = new int[1] ;
         P00G918_A309VenCod = new int[1] ;
         P00G918_A2045VenDsc = new string[] {""} ;
         A604DisDsc = "";
         A141ProvCod = "";
         P00G919_A139PaiCod = new string[] {""} ;
         P00G919_A140EstCod = new string[] {""} ;
         P00G919_A141ProvCod = new string[] {""} ;
         P00G919_A604DisDsc = new string[] {""} ;
         P00G919_A142DisCod = new string[] {""} ;
         A142DisCod = "";
         P00G920_A139PaiCod = new string[] {""} ;
         P00G920_A140EstCod = new string[] {""} ;
         P00G920_A141ProvCod = new string[] {""} ;
         P00G920_A45CliCod = new string[] {""} ;
         P00G920_A142DisCod = new string[] {""} ;
         P00G920_A604DisDsc = new string[] {""} ;
         AV28DisCod = "";
         P00G921_A141ProvCod = new string[] {""} ;
         P00G921_A140EstCod = new string[] {""} ;
         P00G921_A139PaiCod = new string[] {""} ;
         P00G921_A142DisCod = new string[] {""} ;
         P00G921_A604DisDsc = new string[] {""} ;
         A603ProvDsc = "";
         P00G922_A139PaiCod = new string[] {""} ;
         P00G922_A140EstCod = new string[] {""} ;
         P00G922_A603ProvDsc = new string[] {""} ;
         P00G922_A141ProvCod = new string[] {""} ;
         P00G923_A139PaiCod = new string[] {""} ;
         P00G923_A140EstCod = new string[] {""} ;
         P00G923_A45CliCod = new string[] {""} ;
         P00G923_A141ProvCod = new string[] {""} ;
         P00G923_A603ProvDsc = new string[] {""} ;
         AV29ProvCod = "";
         P00G924_A140EstCod = new string[] {""} ;
         P00G924_A139PaiCod = new string[] {""} ;
         P00G924_A141ProvCod = new string[] {""} ;
         P00G924_A603ProvDsc = new string[] {""} ;
         P00G925_A2094ZonDsc = new string[] {""} ;
         P00G925_A158ZonCod = new int[1] ;
         P00G925_n158ZonCod = new bool[] {false} ;
         P00G926_A45CliCod = new string[] {""} ;
         P00G926_A158ZonCod = new int[1] ;
         P00G926_n158ZonCod = new bool[] {false} ;
         P00G926_A2094ZonDsc = new string[] {""} ;
         P00G927_A158ZonCod = new int[1] ;
         P00G927_n158ZonCod = new bool[] {false} ;
         P00G927_A2094ZonDsc = new string[] {""} ;
         A1912TipLDsc = "";
         P00G928_A1912TipLDsc = new string[] {""} ;
         P00G928_A202TipLCod = new int[1] ;
         P00G929_A45CliCod = new string[] {""} ;
         P00G929_A156CliTipLCod = new int[1] ;
         P00G929_n156CliTipLCod = new bool[] {false} ;
         P00G930_A202TipLCod = new int[1] ;
         P00G930_A1912TipLDsc = new string[] {""} ;
         A1917TipSDsc = "";
         P00G931_A1917TipSDsc = new string[] {""} ;
         P00G931_A157TipSCod = new int[1] ;
         P00G932_A45CliCod = new string[] {""} ;
         P00G932_A157TipSCod = new int[1] ;
         P00G932_A1917TipSDsc = new string[] {""} ;
         P00G933_A157TipSCod = new int[1] ;
         P00G933_A1917TipSDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ventas.clientesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00G92_A158ZonCod, P00G92_A2094ZonDsc
               }
               , new Object[] {
               P00G93_A2094ZonDsc, P00G93_A158ZonCod
               }
               , new Object[] {
               P00G94_A139PaiCod, P00G94_A602EstDsc, P00G94_A140EstCod
               }
               , new Object[] {
               P00G95_A139PaiCod, P00G95_A45CliCod, P00G95_A140EstCod, P00G95_A602EstDsc
               }
               , new Object[] {
               P00G96_A139PaiCod, P00G96_A140EstCod, P00G96_A602EstDsc
               }
               , new Object[] {
               P00G97_A1500PaiDsc, P00G97_A139PaiCod
               }
               , new Object[] {
               P00G98_A45CliCod, P00G98_A139PaiCod, P00G98_A1500PaiDsc
               }
               , new Object[] {
               P00G99_A139PaiCod, P00G99_A1500PaiDsc
               }
               , new Object[] {
               P00G910_A1905TipCDsc, P00G910_A159TipCCod
               }
               , new Object[] {
               P00G911_A45CliCod, P00G911_A159TipCCod, P00G911_A1905TipCDsc
               }
               , new Object[] {
               P00G912_A159TipCCod, P00G912_A1905TipCDsc
               }
               , new Object[] {
               P00G913_A753ConpDsc, P00G913_A137Conpcod
               }
               , new Object[] {
               P00G914_A45CliCod, P00G914_A137Conpcod, P00G914_A753ConpDsc
               }
               , new Object[] {
               P00G915_A137Conpcod, P00G915_A753ConpDsc
               }
               , new Object[] {
               P00G916_A2045VenDsc, P00G916_A309VenCod
               }
               , new Object[] {
               P00G917_A45CliCod, P00G917_A160CliVend
               }
               , new Object[] {
               P00G918_A309VenCod, P00G918_A2045VenDsc
               }
               , new Object[] {
               P00G919_A139PaiCod, P00G919_A140EstCod, P00G919_A141ProvCod, P00G919_A604DisDsc, P00G919_A142DisCod
               }
               , new Object[] {
               P00G920_A139PaiCod, P00G920_A140EstCod, P00G920_A141ProvCod, P00G920_A45CliCod, P00G920_A142DisCod, P00G920_A604DisDsc
               }
               , new Object[] {
               P00G921_A141ProvCod, P00G921_A140EstCod, P00G921_A139PaiCod, P00G921_A142DisCod, P00G921_A604DisDsc
               }
               , new Object[] {
               P00G922_A139PaiCod, P00G922_A140EstCod, P00G922_A603ProvDsc, P00G922_A141ProvCod
               }
               , new Object[] {
               P00G923_A139PaiCod, P00G923_A140EstCod, P00G923_A45CliCod, P00G923_A141ProvCod, P00G923_A603ProvDsc
               }
               , new Object[] {
               P00G924_A140EstCod, P00G924_A139PaiCod, P00G924_A141ProvCod, P00G924_A603ProvDsc
               }
               , new Object[] {
               P00G925_A2094ZonDsc, P00G925_A158ZonCod
               }
               , new Object[] {
               P00G926_A45CliCod, P00G926_A158ZonCod, P00G926_n158ZonCod, P00G926_A2094ZonDsc
               }
               , new Object[] {
               P00G927_A158ZonCod, P00G927_A2094ZonDsc
               }
               , new Object[] {
               P00G928_A1912TipLDsc, P00G928_A202TipLCod
               }
               , new Object[] {
               P00G929_A45CliCod, P00G929_A156CliTipLCod, P00G929_n156CliTipLCod
               }
               , new Object[] {
               P00G930_A202TipLCod, P00G930_A1912TipLDsc
               }
               , new Object[] {
               P00G931_A1917TipSDsc, P00G931_A157TipSCod
               }
               , new Object[] {
               P00G932_A45CliCod, P00G932_A157TipSCod, P00G932_A1917TipSDsc
               }
               , new Object[] {
               P00G933_A157TipSCod, P00G933_A1917TipSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV44GXLvl46 ;
      private int AV10MaxItems ;
      private int AV43GXV1 ;
      private int AV37ZonCod_Filter ;
      private int A158ZonCod ;
      private int A159TipCCod ;
      private int AV25TipCCod ;
      private int A137Conpcod ;
      private int AV26Conpcod ;
      private int A309VenCod ;
      private int A160CliVend ;
      private int AV27VenCod ;
      private int AV30ZonCod ;
      private int A202TipLCod ;
      private int A156CliTipLCod ;
      private int AV31TipLCod ;
      private int A157TipSCod ;
      private int AV32TipSCod ;
      private string AV18TrnMode ;
      private string AV33CliCod ;
      private string AV38Cond_PaiCod ;
      private string AV39Cond_EstCod ;
      private string AV40Cond_ProvCod ;
      private string scmdbuf ;
      private string A2094ZonDsc ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A45CliCod ;
      private string AV23EstCod ;
      private string A1500PaiDsc ;
      private string AV24PaiCod ;
      private string A1905TipCDsc ;
      private string A753ConpDsc ;
      private string A2045VenDsc ;
      private string A604DisDsc ;
      private string A141ProvCod ;
      private string A142DisCod ;
      private string AV28DisCod ;
      private string A603ProvDsc ;
      private string AV29ProvCod ;
      private string A1912TipLDsc ;
      private string A1917TipSDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n158ZonCod ;
      private bool n156CliTipLCod ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string AV36ValueItem ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00G92_A158ZonCod ;
      private bool[] P00G92_n158ZonCod ;
      private string[] P00G92_A2094ZonDsc ;
      private string[] P00G93_A2094ZonDsc ;
      private int[] P00G93_A158ZonCod ;
      private bool[] P00G93_n158ZonCod ;
      private string[] P00G94_A139PaiCod ;
      private string[] P00G94_A602EstDsc ;
      private string[] P00G94_A140EstCod ;
      private string[] P00G95_A139PaiCod ;
      private string[] P00G95_A45CliCod ;
      private string[] P00G95_A140EstCod ;
      private string[] P00G95_A602EstDsc ;
      private string[] P00G96_A139PaiCod ;
      private string[] P00G96_A140EstCod ;
      private string[] P00G96_A602EstDsc ;
      private string[] P00G97_A1500PaiDsc ;
      private string[] P00G97_A139PaiCod ;
      private string[] P00G98_A45CliCod ;
      private string[] P00G98_A139PaiCod ;
      private string[] P00G98_A1500PaiDsc ;
      private string[] P00G99_A139PaiCod ;
      private string[] P00G99_A1500PaiDsc ;
      private string[] P00G910_A1905TipCDsc ;
      private int[] P00G910_A159TipCCod ;
      private string[] P00G911_A45CliCod ;
      private int[] P00G911_A159TipCCod ;
      private string[] P00G911_A1905TipCDsc ;
      private int[] P00G912_A159TipCCod ;
      private string[] P00G912_A1905TipCDsc ;
      private string[] P00G913_A753ConpDsc ;
      private int[] P00G913_A137Conpcod ;
      private string[] P00G914_A45CliCod ;
      private int[] P00G914_A137Conpcod ;
      private string[] P00G914_A753ConpDsc ;
      private int[] P00G915_A137Conpcod ;
      private string[] P00G915_A753ConpDsc ;
      private string[] P00G916_A2045VenDsc ;
      private int[] P00G916_A309VenCod ;
      private string[] P00G917_A45CliCod ;
      private int[] P00G917_A160CliVend ;
      private int[] P00G918_A309VenCod ;
      private string[] P00G918_A2045VenDsc ;
      private string[] P00G919_A139PaiCod ;
      private string[] P00G919_A140EstCod ;
      private string[] P00G919_A141ProvCod ;
      private string[] P00G919_A604DisDsc ;
      private string[] P00G919_A142DisCod ;
      private string[] P00G920_A139PaiCod ;
      private string[] P00G920_A140EstCod ;
      private string[] P00G920_A141ProvCod ;
      private string[] P00G920_A45CliCod ;
      private string[] P00G920_A142DisCod ;
      private string[] P00G920_A604DisDsc ;
      private string[] P00G921_A141ProvCod ;
      private string[] P00G921_A140EstCod ;
      private string[] P00G921_A139PaiCod ;
      private string[] P00G921_A142DisCod ;
      private string[] P00G921_A604DisDsc ;
      private string[] P00G922_A139PaiCod ;
      private string[] P00G922_A140EstCod ;
      private string[] P00G922_A603ProvDsc ;
      private string[] P00G922_A141ProvCod ;
      private string[] P00G923_A139PaiCod ;
      private string[] P00G923_A140EstCod ;
      private string[] P00G923_A45CliCod ;
      private string[] P00G923_A141ProvCod ;
      private string[] P00G923_A603ProvDsc ;
      private string[] P00G924_A140EstCod ;
      private string[] P00G924_A139PaiCod ;
      private string[] P00G924_A141ProvCod ;
      private string[] P00G924_A603ProvDsc ;
      private string[] P00G925_A2094ZonDsc ;
      private int[] P00G925_A158ZonCod ;
      private bool[] P00G925_n158ZonCod ;
      private string[] P00G926_A45CliCod ;
      private int[] P00G926_A158ZonCod ;
      private bool[] P00G926_n158ZonCod ;
      private string[] P00G926_A2094ZonDsc ;
      private int[] P00G927_A158ZonCod ;
      private bool[] P00G927_n158ZonCod ;
      private string[] P00G927_A2094ZonDsc ;
      private string[] P00G928_A1912TipLDsc ;
      private int[] P00G928_A202TipLCod ;
      private string[] P00G929_A45CliCod ;
      private int[] P00G929_A156CliTipLCod ;
      private bool[] P00G929_n156CliTipLCod ;
      private int[] P00G930_A202TipLCod ;
      private string[] P00G930_A1912TipLDsc ;
      private string[] P00G931_A1917TipSDsc ;
      private int[] P00G931_A157TipSCod ;
      private string[] P00G932_A45CliCod ;
      private int[] P00G932_A157TipSCod ;
      private string[] P00G932_A1917TipSDsc ;
      private int[] P00G933_A157TipSCod ;
      private string[] P00G933_A1917TipSDsc ;
      private string aP8_SelectedValue ;
      private string aP9_SelectedText ;
      private string aP10_Combo_DataJson ;
      private GxSimpleCollection<string> AV35ValuesCollection ;
      private GxSimpleCollection<string> AV34DscsCollection ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class clientesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00G93( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A2094ZonDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ZonDsc], [ZonCod] FROM [CZONAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ZonDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00G94( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string AV38Cond_PaiCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstDsc], [EstCod] FROM [CESTADOS]";
         AddWhere(sWhereString, "([PaiCod] = @AV38Cond_PaiCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([EstDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EstDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00G97( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [PaiDsc], [PaiCod] FROM [CPAISES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaiDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00G910( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A1905TipCDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [TipCDsc], [TipCCod] FROM [CTIPOCLIENTE]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipCDsc]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00G913( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A753ConpDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[1];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [ConpDsc], [Conpcod] FROM [CCONDICIONPAGO]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConpDsc]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00G916( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A2045VenDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[1];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [VenDsc], [VenCod] FROM [CVENDEDORES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VenDsc]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00G919( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A604DisDsc ,
                                              string A139PaiCod ,
                                              string AV38Cond_PaiCod ,
                                              string A140EstCod ,
                                              string AV39Cond_EstCod ,
                                              string A141ProvCod ,
                                              string AV40Cond_ProvCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[4];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstCod], [ProvCod], [DisDsc], [DisCod] FROM [CDISTRITOS]";
         AddWhere(sWhereString, "([PaiCod] = @AV38Cond_PaiCod)");
         AddWhere(sWhereString, "([EstCod] = @AV39Cond_EstCod)");
         AddWhere(sWhereString, "([ProvCod] = @AV40Cond_ProvCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([DisDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DisDsc]";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P00G922( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A603ProvDsc ,
                                              string A139PaiCod ,
                                              string AV38Cond_PaiCod ,
                                              string A140EstCod ,
                                              string AV39Cond_EstCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[3];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstCod], [ProvDsc], [ProvCod] FROM [CPROVINCIA]";
         AddWhere(sWhereString, "([PaiCod] = @AV38Cond_PaiCod)");
         AddWhere(sWhereString, "([EstCod] = @AV39Cond_EstCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ProvDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int15[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProvDsc]";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      protected Object[] conditional_P00G925( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A2094ZonDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int17 = new short[1];
         Object[] GXv_Object18 = new Object[2];
         scmdbuf = "SELECT [ZonDsc], [ZonCod] FROM [CZONAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ZonDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int17[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ZonDsc]";
         GXv_Object18[0] = scmdbuf;
         GXv_Object18[1] = GXv_int17;
         return GXv_Object18 ;
      }

      protected Object[] conditional_P00G928( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A1912TipLDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int19 = new short[1];
         Object[] GXv_Object20 = new Object[2];
         scmdbuf = "SELECT [TipLDsc], [TipLCod] FROM [CTIPOSLISTAS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int19[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipLDsc]";
         GXv_Object20[0] = scmdbuf;
         GXv_Object20[1] = GXv_int19;
         return GXv_Object20 ;
      }

      protected Object[] conditional_P00G931( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A1917TipSDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int21 = new short[1];
         Object[] GXv_Object22 = new Object[2];
         scmdbuf = "SELECT [TipSDsc], [TipSCod] FROM [CTIPDOCS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipSDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int21[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipSDsc]";
         GXv_Object22[0] = scmdbuf;
         GXv_Object22[1] = GXv_int21;
         return GXv_Object22 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_P00G93(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 2 :
                     return conditional_P00G94(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 5 :
                     return conditional_P00G97(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 8 :
                     return conditional_P00G910(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 11 :
                     return conditional_P00G913(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 14 :
                     return conditional_P00G916(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 17 :
                     return conditional_P00G919(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
               case 20 :
                     return conditional_P00G922(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
               case 23 :
                     return conditional_P00G925(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 26 :
                     return conditional_P00G928(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 29 :
                     return conditional_P00G931(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00G92;
          prmP00G92 = new Object[] {
          new ParDef("@AV37ZonCod_Filter",GXType.Int32,6,0)
          };
          Object[] prmP00G95;
          prmP00G95 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G96;
          prmP00G96 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV23EstCod",GXType.NChar,4,0)
          };
          Object[] prmP00G98;
          prmP00G98 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G99;
          prmP00G99 = new Object[] {
          new ParDef("@AV24PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP00G911;
          prmP00G911 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G912;
          prmP00G912 = new Object[] {
          new ParDef("@AV25TipCCod",GXType.Int32,6,0)
          };
          Object[] prmP00G914;
          prmP00G914 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G915;
          prmP00G915 = new Object[] {
          new ParDef("@AV26Conpcod",GXType.Int32,6,0)
          };
          Object[] prmP00G917;
          prmP00G917 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G918;
          prmP00G918 = new Object[] {
          new ParDef("@AV27VenCod",GXType.Int32,6,0)
          };
          Object[] prmP00G920;
          prmP00G920 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G921;
          prmP00G921 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV39Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV40Cond_ProvCod",GXType.NChar,4,0) ,
          new ParDef("@AV28DisCod",GXType.NChar,4,0)
          };
          Object[] prmP00G923;
          prmP00G923 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G924;
          prmP00G924 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV39Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV29ProvCod",GXType.NChar,4,0)
          };
          Object[] prmP00G926;
          prmP00G926 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G927;
          prmP00G927 = new Object[] {
          new ParDef("@AV30ZonCod",GXType.Int32,6,0)
          };
          Object[] prmP00G929;
          prmP00G929 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G930;
          prmP00G930 = new Object[] {
          new ParDef("@AV31TipLCod",GXType.Int32,6,0)
          };
          Object[] prmP00G932;
          prmP00G932 = new Object[] {
          new ParDef("@AV33CliCod",GXType.NChar,20,0)
          };
          Object[] prmP00G933;
          prmP00G933 = new Object[] {
          new ParDef("@AV32TipSCod",GXType.Int32,6,0)
          };
          Object[] prmP00G93;
          prmP00G93 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G94;
          prmP00G94 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G97;
          prmP00G97 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G910;
          prmP00G910 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G913;
          prmP00G913 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G916;
          prmP00G916 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G919;
          prmP00G919 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV39Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV40Cond_ProvCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G922;
          prmP00G922 = new Object[] {
          new ParDef("@AV38Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV39Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G925;
          prmP00G925 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G928;
          prmP00G928 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00G931;
          prmP00G931 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00G92", "SELECT TOP 1 [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV37ZonCod_Filter ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G92,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G93,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G94", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G94,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G95", "SELECT T1.[PaiCod], T1.[CliCod], T1.[EstCod], T2.[EstDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CESTADOS] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G95,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G96", "SELECT TOP 1 [PaiCod], [EstCod], [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @AV38Cond_PaiCod and [EstCod] = @AV23EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G96,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G97", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G97,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G98", "SELECT T1.[CliCod], T1.[PaiCod], T2.[PaiDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G98,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G99", "SELECT TOP 1 [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV24PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G99,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G910", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G910,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G911", "SELECT T1.[CliCod], T1.[TipCCod], T2.[TipCDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CTIPOCLIENTE] T2 ON T2.[TipCCod] = T1.[TipCCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G911,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G912", "SELECT TOP 1 [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE] WHERE [TipCCod] = @AV25TipCCod ORDER BY [TipCCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G912,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G913", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G913,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G914", "SELECT T1.[CliCod], T1.[Conpcod], T2.[ConpDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CCONDICIONPAGO] T2 ON T2.[Conpcod] = T1.[Conpcod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G914,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G915", "SELECT TOP 1 [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO] WHERE [Conpcod] = @AV26Conpcod ORDER BY [Conpcod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G915,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G916", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G916,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G917", "SELECT [CliCod], [CliVend] FROM [CLCLIENTES] WHERE [CliCod] = @AV33CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G917,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G918", "SELECT TOP 1 [VenCod], [VenDsc] FROM [CVENDEDORES] WHERE [VenCod] = @AV27VenCod ORDER BY [VenCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G918,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G919", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G919,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G920", "SELECT T1.[PaiCod], T1.[EstCod], T1.[ProvCod], T1.[CliCod], T1.[DisCod], T2.[DisDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CDISTRITOS] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod] AND T2.[ProvCod] = T1.[ProvCod] AND T2.[DisCod] = T1.[DisCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G920,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G921", "SELECT TOP 1 [ProvCod], [EstCod], [PaiCod], [DisCod], [DisDsc] FROM [CDISTRITOS] WHERE [PaiCod] = @AV38Cond_PaiCod and [EstCod] = @AV39Cond_EstCod and [ProvCod] = @AV40Cond_ProvCod and [DisCod] = @AV28DisCod ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G921,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G922", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G922,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G923", "SELECT T1.[PaiCod], T1.[EstCod], T1.[CliCod], T1.[ProvCod], T2.[ProvDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CPROVINCIA] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod] AND T2.[ProvCod] = T1.[ProvCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G923,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G924", "SELECT TOP 1 [EstCod], [PaiCod], [ProvCod], [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @AV38Cond_PaiCod and [EstCod] = @AV39Cond_EstCod and [ProvCod] = @AV29ProvCod ORDER BY [PaiCod], [EstCod], [ProvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G924,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G925", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G925,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G926", "SELECT T1.[CliCod], T1.[ZonCod], T2.[ZonDsc] FROM ([CLCLIENTES] T1 LEFT JOIN [CZONAS] T2 ON T2.[ZonCod] = T1.[ZonCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G926,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G927", "SELECT TOP 1 [ZonCod], [ZonDsc] FROM [CZONAS] WHERE [ZonCod] = @AV30ZonCod ORDER BY [ZonCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G927,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G928", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G928,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G929", "SELECT [CliCod], [CliTipLCod] FROM [CLCLIENTES] WHERE [CliCod] = @AV33CliCod ORDER BY [CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G929,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G930", "SELECT TOP 1 [TipLCod], [TipLDsc] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @AV31TipLCod ORDER BY [TipLCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G930,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G931", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G931,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00G932", "SELECT T1.[CliCod], T1.[TipSCod], T2.[TipSDsc] FROM ([CLCLIENTES] T1 INNER JOIN [CTIPDOCS] T2 ON T2.[TipSCod] = T1.[TipSCod]) WHERE T1.[CliCod] = @AV33CliCod ORDER BY T1.[CliCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G932,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00G933", "SELECT TOP 1 [TipSCod], [TipSDsc] FROM [CTIPDOCS] WHERE [TipSCod] = @AV32TipSCod ORDER BY [TipSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00G933,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
