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
namespace GeneXus.Programs.almacen {
   public class productosloaddvcombo : GXProcedure
   {
      public productosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public productosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_ProdCod ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV30ProdCod = aP3_ProdCod;
         this.AV11SearchTxt = aP4_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                string aP3_ProdCod ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_ProdCod, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_ProdCod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         productosloaddvcombo objproductosloaddvcombo;
         objproductosloaddvcombo = new productosloaddvcombo();
         objproductosloaddvcombo.AV16ComboName = aP0_ComboName;
         objproductosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objproductosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objproductosloaddvcombo.AV30ProdCod = aP3_ProdCod;
         objproductosloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objproductosloaddvcombo.AV15SelectedValue = "" ;
         objproductosloaddvcombo.AV20SelectedText = "" ;
         objproductosloaddvcombo.AV12Combo_DataJson = "" ;
         objproductosloaddvcombo.context.SetSubmitInitialConfig(context);
         objproductosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objproductosloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((productosloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "LinCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_LINCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "SublCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_SUBLCOD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "FamCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_FAMCOD' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "UniCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_UNICOD' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ProdCuentaV") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODCUENTAV' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ProdCuentaC") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODCUENTAC' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "ProdCuentaA") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PRODCUENTAA' */
            S171 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CBSuCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CBSUCOD' */
            S181 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "cDetCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CDETCOD' */
            S191 ();
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
         /* 'LOADCOMBOITEMS_LINCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1153LinDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1153LinDsc = P00DS2_A1153LinDsc[0];
               A52LinCod = P00DS2_A52LinCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1153LinDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS3 */
                  pr_default.execute(1, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A28ProdCod = P00DS3_A28ProdCod[0];
                     A52LinCod = P00DS3_A52LinCod[0];
                     A1153LinDsc = P00DS3_A1153LinDsc[0];
                     A1153LinDsc = P00DS3_A1153LinDsc[0];
                     AV15SelectedValue = ((0==A52LinCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 6, 0)));
                     AV20SelectedText = A1153LinDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV23LinCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00DS4 */
                  pr_default.execute(2, new Object[] {AV23LinCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A52LinCod = P00DS4_A52LinCod[0];
                     A1153LinDsc = P00DS4_A1153LinDsc[0];
                     AV20SelectedText = A1153LinDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(2);
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_SUBLCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1892SublDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS5 */
            pr_default.execute(3, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A1892SublDsc = P00DS5_A1892SublDsc[0];
               A51SublCod = P00DS5_A51SublCod[0];
               n51SublCod = P00DS5_n51SublCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1892SublDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(3);
            }
            pr_default.close(3);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS6 */
                  pr_default.execute(4, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A28ProdCod = P00DS6_A28ProdCod[0];
                     A51SublCod = P00DS6_A51SublCod[0];
                     n51SublCod = P00DS6_n51SublCod[0];
                     A1892SublDsc = P00DS6_A1892SublDsc[0];
                     A1892SublDsc = P00DS6_A1892SublDsc[0];
                     AV15SelectedValue = ((0==A51SublCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A51SublCod), 6, 0)));
                     AV20SelectedText = A1892SublDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV24SublCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00DS7 */
                  pr_default.execute(5, new Object[] {AV24SublCod});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A51SublCod = P00DS7_A51SublCod[0];
                     n51SublCod = P00DS7_n51SublCod[0];
                     A1892SublDsc = P00DS7_A1892SublDsc[0];
                     AV20SelectedText = A1892SublDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(5);
               }
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_FAMCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A977FamDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS8 */
            pr_default.execute(6, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A977FamDsc = P00DS8_A977FamDsc[0];
               A50FamCod = P00DS8_A50FamCod[0];
               n50FamCod = P00DS8_n50FamCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A977FamDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(6);
            }
            pr_default.close(6);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS9 */
                  pr_default.execute(7, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A28ProdCod = P00DS9_A28ProdCod[0];
                     A50FamCod = P00DS9_A50FamCod[0];
                     n50FamCod = P00DS9_n50FamCod[0];
                     A977FamDsc = P00DS9_A977FamDsc[0];
                     A977FamDsc = P00DS9_A977FamDsc[0];
                     AV15SelectedValue = ((0==A50FamCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 6, 0)));
                     AV20SelectedText = A977FamDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV25FamCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00DS10 */
                  pr_default.execute(8, new Object[] {AV25FamCod});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A50FamCod = P00DS10_A50FamCod[0];
                     n50FamCod = P00DS10_n50FamCod[0];
                     A977FamDsc = P00DS10_A977FamDsc[0];
                     AV20SelectedText = A977FamDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(8);
               }
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_UNICOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(9, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1998UniDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS11 */
            pr_default.execute(9, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A1998UniDsc = P00DS11_A1998UniDsc[0];
               A49UniCod = P00DS11_A49UniCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A49UniCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1998UniDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(9);
            }
            pr_default.close(9);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS12 */
                  pr_default.execute(10, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(10) != 101) )
                  {
                     A28ProdCod = P00DS12_A28ProdCod[0];
                     A49UniCod = P00DS12_A49UniCod[0];
                     A1998UniDsc = P00DS12_A1998UniDsc[0];
                     A1998UniDsc = P00DS12_A1998UniDsc[0];
                     AV15SelectedValue = ((0==A49UniCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A49UniCod), 6, 0)));
                     AV20SelectedText = A1998UniDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(10);
               }
               else
               {
                  AV26UniCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00DS13 */
                  pr_default.execute(11, new Object[] {AV26UniCod});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A49UniCod = P00DS13_A49UniCod[0];
                     A1998UniDsc = P00DS13_A1998UniDsc[0];
                     AV20SelectedText = A1998UniDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(11);
               }
            }
         }
      }

      protected void S151( )
      {
         /* 'LOADCOMBOITEMS_PRODCUENTAV' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(12, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A860CueDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS14 */
            pr_default.execute(12, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(12) != 101) )
            {
               A860CueDsc = P00DS14_A860CueDsc[0];
               A91CueCod = P00DS14_A91CueCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A91CueCod;
               AV14Combo_DataItem.gxTpr_Title = A860CueDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(12);
            }
            pr_default.close(12);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS15 */
                  pr_default.execute(13, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(13) != 101) )
                  {
                     A28ProdCod = P00DS15_A28ProdCod[0];
                     A48ProdCuentaV = P00DS15_A48ProdCuentaV[0];
                     n48ProdCuentaV = P00DS15_n48ProdCuentaV[0];
                     AV15SelectedValue = A48ProdCuentaV;
                     AV27CueCod = A48ProdCuentaV;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(13);
               }
               else
               {
                  AV27CueCod = AV11SearchTxt;
               }
               /* Using cursor P00DS16 */
               pr_default.execute(14, new Object[] {AV27CueCod});
               while ( (pr_default.getStatus(14) != 101) )
               {
                  A91CueCod = P00DS16_A91CueCod[0];
                  A860CueDsc = P00DS16_A860CueDsc[0];
                  AV20SelectedText = A860CueDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(14);
            }
         }
      }

      protected void S161( )
      {
         /* 'LOADCOMBOITEMS_PRODCUENTAC' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(15, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A860CueDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS17 */
            pr_default.execute(15, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(15) != 101) )
            {
               A860CueDsc = P00DS17_A860CueDsc[0];
               A91CueCod = P00DS17_A91CueCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A91CueCod;
               AV14Combo_DataItem.gxTpr_Title = A860CueDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(15);
            }
            pr_default.close(15);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS18 */
                  pr_default.execute(16, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(16) != 101) )
                  {
                     A28ProdCod = P00DS18_A28ProdCod[0];
                     A53ProdCuentaC = P00DS18_A53ProdCuentaC[0];
                     n53ProdCuentaC = P00DS18_n53ProdCuentaC[0];
                     AV15SelectedValue = A53ProdCuentaC;
                     AV27CueCod = A53ProdCuentaC;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(16);
               }
               else
               {
                  AV27CueCod = AV11SearchTxt;
               }
               /* Using cursor P00DS19 */
               pr_default.execute(17, new Object[] {AV27CueCod});
               while ( (pr_default.getStatus(17) != 101) )
               {
                  A91CueCod = P00DS19_A91CueCod[0];
                  A860CueDsc = P00DS19_A860CueDsc[0];
                  AV20SelectedText = A860CueDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(17);
            }
         }
      }

      protected void S171( )
      {
         /* 'LOADCOMBOITEMS_PRODCUENTAA' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(18, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A860CueDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS20 */
            pr_default.execute(18, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(18) != 101) )
            {
               A860CueDsc = P00DS20_A860CueDsc[0];
               A91CueCod = P00DS20_A91CueCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A91CueCod;
               AV14Combo_DataItem.gxTpr_Title = A860CueDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(18);
            }
            pr_default.close(18);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS21 */
                  pr_default.execute(19, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(19) != 101) )
                  {
                     A28ProdCod = P00DS21_A28ProdCod[0];
                     A54ProdCuentaA = P00DS21_A54ProdCuentaA[0];
                     n54ProdCuentaA = P00DS21_n54ProdCuentaA[0];
                     AV15SelectedValue = A54ProdCuentaA;
                     AV27CueCod = A54ProdCuentaA;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(19);
               }
               else
               {
                  AV27CueCod = AV11SearchTxt;
               }
               /* Using cursor P00DS22 */
               pr_default.execute(20, new Object[] {AV27CueCod});
               while ( (pr_default.getStatus(20) != 101) )
               {
                  A91CueCod = P00DS22_A91CueCod[0];
                  A860CueDsc = P00DS22_A860CueDsc[0];
                  AV20SelectedText = A860CueDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(20);
            }
         }
      }

      protected void S181( )
      {
         /* 'LOADCOMBOITEMS_CBSUCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(21, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A505CBSuDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS23 */
            pr_default.execute(21, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(21) != 101) )
            {
               A505CBSuDsc = P00DS23_A505CBSuDsc[0];
               A47CBSuCod = P00DS23_A47CBSuCod[0];
               n47CBSuCod = P00DS23_n47CBSuCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A47CBSuCod;
               AV14Combo_DataItem.gxTpr_Title = A505CBSuDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(21);
            }
            pr_default.close(21);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS24 */
                  pr_default.execute(22, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(22) != 101) )
                  {
                     A28ProdCod = P00DS24_A28ProdCod[0];
                     A47CBSuCod = P00DS24_A47CBSuCod[0];
                     n47CBSuCod = P00DS24_n47CBSuCod[0];
                     A505CBSuDsc = P00DS24_A505CBSuDsc[0];
                     A505CBSuDsc = P00DS24_A505CBSuDsc[0];
                     AV15SelectedValue = A47CBSuCod;
                     AV20SelectedText = A505CBSuDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(22);
               }
               else
               {
                  AV28CBSuCod = AV11SearchTxt;
                  /* Using cursor P00DS25 */
                  pr_default.execute(23, new Object[] {AV28CBSuCod});
                  while ( (pr_default.getStatus(23) != 101) )
                  {
                     A47CBSuCod = P00DS25_A47CBSuCod[0];
                     n47CBSuCod = P00DS25_n47CBSuCod[0];
                     A505CBSuDsc = P00DS25_A505CBSuDsc[0];
                     AV20SelectedText = A505CBSuDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(23);
               }
            }
         }
      }

      protected void S191( )
      {
         /* 'LOADCOMBOITEMS_CDETCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(24, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A519cDetDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P00DS26 */
            pr_default.execute(24, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(24) != 101) )
            {
               A519cDetDsc = P00DS26_A519cDetDsc[0];
               A46cDetCod = P00DS26_A46cDetCod[0];
               n46cDetCod = P00DS26_n46cDetCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A46cDetCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A519cDetDsc;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(24);
            }
            pr_default.close(24);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00DS27 */
                  pr_default.execute(25, new Object[] {AV30ProdCod});
                  while ( (pr_default.getStatus(25) != 101) )
                  {
                     A28ProdCod = P00DS27_A28ProdCod[0];
                     A46cDetCod = P00DS27_A46cDetCod[0];
                     n46cDetCod = P00DS27_n46cDetCod[0];
                     A519cDetDsc = P00DS27_A519cDetDsc[0];
                     A519cDetDsc = P00DS27_A519cDetDsc[0];
                     AV15SelectedValue = ((0==A46cDetCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A46cDetCod), 6, 0)));
                     AV20SelectedText = A519cDetDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(25);
               }
               else
               {
                  AV29cDetCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P00DS28 */
                  pr_default.execute(26, new Object[] {AV29cDetCod});
                  while ( (pr_default.getStatus(26) != 101) )
                  {
                     A46cDetCod = P00DS28_A46cDetCod[0];
                     n46cDetCod = P00DS28_n46cDetCod[0];
                     A519cDetDsc = P00DS28_A519cDetDsc[0];
                     AV20SelectedText = A519cDetDsc;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(26);
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
         scmdbuf = "";
         lV11SearchTxt = "";
         A1153LinDsc = "";
         P00DS2_A1153LinDsc = new string[] {""} ;
         P00DS2_A52LinCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00DS3_A28ProdCod = new string[] {""} ;
         P00DS3_A52LinCod = new int[1] ;
         P00DS3_A1153LinDsc = new string[] {""} ;
         A28ProdCod = "";
         P00DS4_A52LinCod = new int[1] ;
         P00DS4_A1153LinDsc = new string[] {""} ;
         A1892SublDsc = "";
         P00DS5_A1892SublDsc = new string[] {""} ;
         P00DS5_A51SublCod = new int[1] ;
         P00DS5_n51SublCod = new bool[] {false} ;
         P00DS6_A28ProdCod = new string[] {""} ;
         P00DS6_A51SublCod = new int[1] ;
         P00DS6_n51SublCod = new bool[] {false} ;
         P00DS6_A1892SublDsc = new string[] {""} ;
         P00DS7_A51SublCod = new int[1] ;
         P00DS7_n51SublCod = new bool[] {false} ;
         P00DS7_A1892SublDsc = new string[] {""} ;
         A977FamDsc = "";
         P00DS8_A977FamDsc = new string[] {""} ;
         P00DS8_A50FamCod = new int[1] ;
         P00DS8_n50FamCod = new bool[] {false} ;
         P00DS9_A28ProdCod = new string[] {""} ;
         P00DS9_A50FamCod = new int[1] ;
         P00DS9_n50FamCod = new bool[] {false} ;
         P00DS9_A977FamDsc = new string[] {""} ;
         P00DS10_A50FamCod = new int[1] ;
         P00DS10_n50FamCod = new bool[] {false} ;
         P00DS10_A977FamDsc = new string[] {""} ;
         A1998UniDsc = "";
         P00DS11_A1998UniDsc = new string[] {""} ;
         P00DS11_A49UniCod = new int[1] ;
         P00DS12_A28ProdCod = new string[] {""} ;
         P00DS12_A49UniCod = new int[1] ;
         P00DS12_A1998UniDsc = new string[] {""} ;
         P00DS13_A49UniCod = new int[1] ;
         P00DS13_A1998UniDsc = new string[] {""} ;
         A860CueDsc = "";
         P00DS14_A860CueDsc = new string[] {""} ;
         P00DS14_A91CueCod = new string[] {""} ;
         A91CueCod = "";
         P00DS15_A28ProdCod = new string[] {""} ;
         P00DS15_A48ProdCuentaV = new string[] {""} ;
         P00DS15_n48ProdCuentaV = new bool[] {false} ;
         A48ProdCuentaV = "";
         AV27CueCod = "";
         P00DS16_A91CueCod = new string[] {""} ;
         P00DS16_A860CueDsc = new string[] {""} ;
         P00DS17_A860CueDsc = new string[] {""} ;
         P00DS17_A91CueCod = new string[] {""} ;
         P00DS18_A28ProdCod = new string[] {""} ;
         P00DS18_A53ProdCuentaC = new string[] {""} ;
         P00DS18_n53ProdCuentaC = new bool[] {false} ;
         A53ProdCuentaC = "";
         P00DS19_A91CueCod = new string[] {""} ;
         P00DS19_A860CueDsc = new string[] {""} ;
         P00DS20_A860CueDsc = new string[] {""} ;
         P00DS20_A91CueCod = new string[] {""} ;
         P00DS21_A28ProdCod = new string[] {""} ;
         P00DS21_A54ProdCuentaA = new string[] {""} ;
         P00DS21_n54ProdCuentaA = new bool[] {false} ;
         A54ProdCuentaA = "";
         P00DS22_A91CueCod = new string[] {""} ;
         P00DS22_A860CueDsc = new string[] {""} ;
         A505CBSuDsc = "";
         P00DS23_A505CBSuDsc = new string[] {""} ;
         P00DS23_A47CBSuCod = new string[] {""} ;
         P00DS23_n47CBSuCod = new bool[] {false} ;
         A47CBSuCod = "";
         P00DS24_A28ProdCod = new string[] {""} ;
         P00DS24_A47CBSuCod = new string[] {""} ;
         P00DS24_n47CBSuCod = new bool[] {false} ;
         P00DS24_A505CBSuDsc = new string[] {""} ;
         AV28CBSuCod = "";
         P00DS25_A47CBSuCod = new string[] {""} ;
         P00DS25_n47CBSuCod = new bool[] {false} ;
         P00DS25_A505CBSuDsc = new string[] {""} ;
         A519cDetDsc = "";
         P00DS26_A519cDetDsc = new string[] {""} ;
         P00DS26_A46cDetCod = new int[1] ;
         P00DS26_n46cDetCod = new bool[] {false} ;
         P00DS27_A28ProdCod = new string[] {""} ;
         P00DS27_A46cDetCod = new int[1] ;
         P00DS27_n46cDetCod = new bool[] {false} ;
         P00DS27_A519cDetDsc = new string[] {""} ;
         P00DS28_A46cDetCod = new int[1] ;
         P00DS28_n46cDetCod = new bool[] {false} ;
         P00DS28_A519cDetDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.almacen.productosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00DS2_A1153LinDsc, P00DS2_A52LinCod
               }
               , new Object[] {
               P00DS3_A28ProdCod, P00DS3_A52LinCod, P00DS3_A1153LinDsc
               }
               , new Object[] {
               P00DS4_A52LinCod, P00DS4_A1153LinDsc
               }
               , new Object[] {
               P00DS5_A1892SublDsc, P00DS5_A51SublCod
               }
               , new Object[] {
               P00DS6_A28ProdCod, P00DS6_A51SublCod, P00DS6_n51SublCod, P00DS6_A1892SublDsc
               }
               , new Object[] {
               P00DS7_A51SublCod, P00DS7_A1892SublDsc
               }
               , new Object[] {
               P00DS8_A977FamDsc, P00DS8_A50FamCod
               }
               , new Object[] {
               P00DS9_A28ProdCod, P00DS9_A50FamCod, P00DS9_n50FamCod, P00DS9_A977FamDsc
               }
               , new Object[] {
               P00DS10_A50FamCod, P00DS10_A977FamDsc
               }
               , new Object[] {
               P00DS11_A1998UniDsc, P00DS11_A49UniCod
               }
               , new Object[] {
               P00DS12_A28ProdCod, P00DS12_A49UniCod, P00DS12_A1998UniDsc
               }
               , new Object[] {
               P00DS13_A49UniCod, P00DS13_A1998UniDsc
               }
               , new Object[] {
               P00DS14_A860CueDsc, P00DS14_A91CueCod
               }
               , new Object[] {
               P00DS15_A28ProdCod, P00DS15_A48ProdCuentaV, P00DS15_n48ProdCuentaV
               }
               , new Object[] {
               P00DS16_A91CueCod, P00DS16_A860CueDsc
               }
               , new Object[] {
               P00DS17_A860CueDsc, P00DS17_A91CueCod
               }
               , new Object[] {
               P00DS18_A28ProdCod, P00DS18_A53ProdCuentaC, P00DS18_n53ProdCuentaC
               }
               , new Object[] {
               P00DS19_A91CueCod, P00DS19_A860CueDsc
               }
               , new Object[] {
               P00DS20_A860CueDsc, P00DS20_A91CueCod
               }
               , new Object[] {
               P00DS21_A28ProdCod, P00DS21_A54ProdCuentaA, P00DS21_n54ProdCuentaA
               }
               , new Object[] {
               P00DS22_A91CueCod, P00DS22_A860CueDsc
               }
               , new Object[] {
               P00DS23_A505CBSuDsc, P00DS23_A47CBSuCod
               }
               , new Object[] {
               P00DS24_A28ProdCod, P00DS24_A47CBSuCod, P00DS24_n47CBSuCod, P00DS24_A505CBSuDsc
               }
               , new Object[] {
               P00DS25_A47CBSuCod, P00DS25_A505CBSuDsc
               }
               , new Object[] {
               P00DS26_A519cDetDsc, P00DS26_A46cDetCod
               }
               , new Object[] {
               P00DS27_A28ProdCod, P00DS27_A46cDetCod, P00DS27_n46cDetCod, P00DS27_A519cDetDsc
               }
               , new Object[] {
               P00DS28_A46cDetCod, P00DS28_A519cDetDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10MaxItems ;
      private int A52LinCod ;
      private int AV23LinCod ;
      private int A51SublCod ;
      private int AV24SublCod ;
      private int A50FamCod ;
      private int AV25FamCod ;
      private int A49UniCod ;
      private int AV26UniCod ;
      private int A46cDetCod ;
      private int AV29cDetCod ;
      private string AV18TrnMode ;
      private string AV30ProdCod ;
      private string scmdbuf ;
      private string A1153LinDsc ;
      private string A28ProdCod ;
      private string A1892SublDsc ;
      private string A977FamDsc ;
      private string A1998UniDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private string A48ProdCuentaV ;
      private string AV27CueCod ;
      private string A53ProdCuentaC ;
      private string A54ProdCuentaA ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n51SublCod ;
      private bool n50FamCod ;
      private bool n48ProdCuentaV ;
      private bool n53ProdCuentaC ;
      private bool n54ProdCuentaA ;
      private bool n47CBSuCod ;
      private bool n46cDetCod ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private string A505CBSuDsc ;
      private string A47CBSuCod ;
      private string AV28CBSuCod ;
      private string A519cDetDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00DS2_A1153LinDsc ;
      private int[] P00DS2_A52LinCod ;
      private string[] P00DS3_A28ProdCod ;
      private int[] P00DS3_A52LinCod ;
      private string[] P00DS3_A1153LinDsc ;
      private int[] P00DS4_A52LinCod ;
      private string[] P00DS4_A1153LinDsc ;
      private string[] P00DS5_A1892SublDsc ;
      private int[] P00DS5_A51SublCod ;
      private bool[] P00DS5_n51SublCod ;
      private string[] P00DS6_A28ProdCod ;
      private int[] P00DS6_A51SublCod ;
      private bool[] P00DS6_n51SublCod ;
      private string[] P00DS6_A1892SublDsc ;
      private int[] P00DS7_A51SublCod ;
      private bool[] P00DS7_n51SublCod ;
      private string[] P00DS7_A1892SublDsc ;
      private string[] P00DS8_A977FamDsc ;
      private int[] P00DS8_A50FamCod ;
      private bool[] P00DS8_n50FamCod ;
      private string[] P00DS9_A28ProdCod ;
      private int[] P00DS9_A50FamCod ;
      private bool[] P00DS9_n50FamCod ;
      private string[] P00DS9_A977FamDsc ;
      private int[] P00DS10_A50FamCod ;
      private bool[] P00DS10_n50FamCod ;
      private string[] P00DS10_A977FamDsc ;
      private string[] P00DS11_A1998UniDsc ;
      private int[] P00DS11_A49UniCod ;
      private string[] P00DS12_A28ProdCod ;
      private int[] P00DS12_A49UniCod ;
      private string[] P00DS12_A1998UniDsc ;
      private int[] P00DS13_A49UniCod ;
      private string[] P00DS13_A1998UniDsc ;
      private string[] P00DS14_A860CueDsc ;
      private string[] P00DS14_A91CueCod ;
      private string[] P00DS15_A28ProdCod ;
      private string[] P00DS15_A48ProdCuentaV ;
      private bool[] P00DS15_n48ProdCuentaV ;
      private string[] P00DS16_A91CueCod ;
      private string[] P00DS16_A860CueDsc ;
      private string[] P00DS17_A860CueDsc ;
      private string[] P00DS17_A91CueCod ;
      private string[] P00DS18_A28ProdCod ;
      private string[] P00DS18_A53ProdCuentaC ;
      private bool[] P00DS18_n53ProdCuentaC ;
      private string[] P00DS19_A91CueCod ;
      private string[] P00DS19_A860CueDsc ;
      private string[] P00DS20_A860CueDsc ;
      private string[] P00DS20_A91CueCod ;
      private string[] P00DS21_A28ProdCod ;
      private string[] P00DS21_A54ProdCuentaA ;
      private bool[] P00DS21_n54ProdCuentaA ;
      private string[] P00DS22_A91CueCod ;
      private string[] P00DS22_A860CueDsc ;
      private string[] P00DS23_A505CBSuDsc ;
      private string[] P00DS23_A47CBSuCod ;
      private bool[] P00DS23_n47CBSuCod ;
      private string[] P00DS24_A28ProdCod ;
      private string[] P00DS24_A47CBSuCod ;
      private bool[] P00DS24_n47CBSuCod ;
      private string[] P00DS24_A505CBSuDsc ;
      private string[] P00DS25_A47CBSuCod ;
      private bool[] P00DS25_n47CBSuCod ;
      private string[] P00DS25_A505CBSuDsc ;
      private string[] P00DS26_A519cDetDsc ;
      private int[] P00DS26_A46cDetCod ;
      private bool[] P00DS26_n46cDetCod ;
      private string[] P00DS27_A28ProdCod ;
      private int[] P00DS27_A46cDetCod ;
      private bool[] P00DS27_n46cDetCod ;
      private string[] P00DS27_A519cDetDsc ;
      private int[] P00DS28_A46cDetCod ;
      private bool[] P00DS28_n46cDetCod ;
      private string[] P00DS28_A519cDetDsc ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class productosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DS2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1153LinDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [LinDsc], [LinCod] FROM [CLINEAPROD]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([LinDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [LinDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00DS5( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1892SublDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [SublDsc], [SublCod] FROM [CSUBLPROD]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SublDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00DS8( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A977FamDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [FamDsc], [FamCod] FROM [CFAMILIA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FamDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00DS11( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A1998UniDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[1];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [UniDsc], [UniCod] FROM [CUNIDADMEDIDA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UniDsc]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00DS14( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[1];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00DS17( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[1];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int11[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00DS20( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[1];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT [CueDsc], [CueCod] FROM [CBPLANCUENTA]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CueDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int13[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CueDsc]";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P00DS23( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A505CBSuDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[1];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT [CBSuDsc], [CBSuCod] FROM [CBPRODUCTOSSUNAT]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CBSuDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int15[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CBSuDsc]";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      protected Object[] conditional_P00DS26( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A519cDetDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int17 = new short[1];
         Object[] GXv_Object18 = new Object[2];
         scmdbuf = "SELECT [cDetDsc], [cDetCod] FROM [CDETRACCIONES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([cDetDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int17[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [cDetDsc]";
         GXv_Object18[0] = scmdbuf;
         GXv_Object18[1] = GXv_int17;
         return GXv_Object18 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DS2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P00DS5(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 6 :
                     return conditional_P00DS8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 9 :
                     return conditional_P00DS11(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 12 :
                     return conditional_P00DS14(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 15 :
                     return conditional_P00DS17(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 18 :
                     return conditional_P00DS20(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 21 :
                     return conditional_P00DS23(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 24 :
                     return conditional_P00DS26(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DS3;
          prmP00DS3 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS4;
          prmP00DS4 = new Object[] {
          new ParDef("@AV23LinCod",GXType.Int32,6,0)
          };
          Object[] prmP00DS6;
          prmP00DS6 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS7;
          prmP00DS7 = new Object[] {
          new ParDef("@AV24SublCod",GXType.Int32,6,0)
          };
          Object[] prmP00DS9;
          prmP00DS9 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS10;
          prmP00DS10 = new Object[] {
          new ParDef("@AV25FamCod",GXType.Int32,6,0)
          };
          Object[] prmP00DS12;
          prmP00DS12 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS13;
          prmP00DS13 = new Object[] {
          new ParDef("@AV26UniCod",GXType.Int32,6,0)
          };
          Object[] prmP00DS15;
          prmP00DS15 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS16;
          prmP00DS16 = new Object[] {
          new ParDef("@AV27CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS18;
          prmP00DS18 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS19;
          prmP00DS19 = new Object[] {
          new ParDef("@AV27CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS21;
          prmP00DS21 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS22;
          prmP00DS22 = new Object[] {
          new ParDef("@AV27CueCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS24;
          prmP00DS24 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS25;
          prmP00DS25 = new Object[] {
          new ParDef("@AV28CBSuCod",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS27;
          prmP00DS27 = new Object[] {
          new ParDef("@AV30ProdCod",GXType.NChar,15,0)
          };
          Object[] prmP00DS28;
          prmP00DS28 = new Object[] {
          new ParDef("@AV29cDetCod",GXType.Int32,6,0)
          };
          Object[] prmP00DS2;
          prmP00DS2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS5;
          prmP00DS5 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS8;
          prmP00DS8 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS11;
          prmP00DS11 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS14;
          prmP00DS14 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS17;
          prmP00DS17 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS20;
          prmP00DS20 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS23;
          prmP00DS23 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00DS26;
          prmP00DS26 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DS2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS3", "SELECT T1.[ProdCod], T1.[LinCod], T2.[LinDsc] FROM ([APRODUCTOS] T1 INNER JOIN [CLINEAPROD] T2 ON T2.[LinCod] = T1.[LinCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS4", "SELECT TOP 1 [LinCod], [LinDsc] FROM [CLINEAPROD] WHERE [LinCod] = @AV23LinCod ORDER BY [LinCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS6", "SELECT T1.[ProdCod], T1.[SublCod], T2.[SublDsc] FROM ([APRODUCTOS] T1 LEFT JOIN [CSUBLPROD] T2 ON T2.[SublCod] = T1.[SublCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS7", "SELECT TOP 1 [SublCod], [SublDsc] FROM [CSUBLPROD] WHERE [SublCod] = @AV24SublCod ORDER BY [SublCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS9", "SELECT T1.[ProdCod], T1.[FamCod], T2.[FamDsc] FROM ([APRODUCTOS] T1 LEFT JOIN [CFAMILIA] T2 ON T2.[FamCod] = T1.[FamCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS10", "SELECT TOP 1 [FamCod], [FamDsc] FROM [CFAMILIA] WHERE [FamCod] = @AV25FamCod ORDER BY [FamCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS12", "SELECT T1.[ProdCod], T1.[UniCod], T2.[UniDsc] FROM ([APRODUCTOS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[UniCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS13", "SELECT TOP 1 [UniCod], [UniDsc] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @AV26UniCod ORDER BY [UniCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS13,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS14,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS15", "SELECT [ProdCod], [ProdCuentaV] FROM [APRODUCTOS] WHERE [ProdCod] = @AV30ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS15,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS16", "SELECT TOP 1 [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV27CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS16,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS17", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS17,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS18", "SELECT [ProdCod], [ProdCuentaC] FROM [APRODUCTOS] WHERE [ProdCod] = @AV30ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS18,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS19", "SELECT TOP 1 [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV27CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS19,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS20", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS20,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS21", "SELECT [ProdCod], [ProdCuentaA] FROM [APRODUCTOS] WHERE [ProdCod] = @AV30ProdCod ORDER BY [ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS21,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS22", "SELECT TOP 1 [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV27CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS22,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS23,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS24", "SELECT T1.[ProdCod], T1.[CBSuCod], T2.[CBSuDsc] FROM ([APRODUCTOS] T1 LEFT JOIN [CBPRODUCTOSSUNAT] T2 ON T2.[CBSuCod] = T1.[CBSuCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS24,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS25", "SELECT TOP 1 [CBSuCod], [CBSuDsc] FROM [CBPRODUCTOSSUNAT] WHERE [CBSuCod] = @AV28CBSuCod ORDER BY [CBSuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS25,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS26", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS26,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00DS27", "SELECT T1.[ProdCod], T1.[cDetCod], T2.[cDetDsc] FROM ([APRODUCTOS] T1 LEFT JOIN [CDETRACCIONES] T2 ON T2.[cDetCod] = T1.[cDetCod]) WHERE T1.[ProdCod] = @AV30ProdCod ORDER BY T1.[ProdCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS27,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00DS28", "SELECT TOP 1 [cDetCod], [cDetDsc] FROM [CDETRACCIONES] WHERE [cDetCod] = @AV29cDetCod ORDER BY [cDetCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DS28,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
