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
namespace GeneXus.Programs.contabilidad {
   public class plancuentasloaddvcombo : GXProcedure
   {
      public plancuentasloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public plancuentasloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_CueCod ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV25CueCod = aP3_CueCod;
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
                                string aP3_CueCod ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CueCod, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_CueCod ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         plancuentasloaddvcombo objplancuentasloaddvcombo;
         objplancuentasloaddvcombo = new plancuentasloaddvcombo();
         objplancuentasloaddvcombo.AV16ComboName = aP0_ComboName;
         objplancuentasloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objplancuentasloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objplancuentasloaddvcombo.AV25CueCod = aP3_CueCod;
         objplancuentasloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objplancuentasloaddvcombo.AV15SelectedValue = "" ;
         objplancuentasloaddvcombo.AV20SelectedText = "" ;
         objplancuentasloaddvcombo.AV12Combo_DataJson = "" ;
         objplancuentasloaddvcombo.context.SetSubmitInitialConfig(context);
         objplancuentasloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objplancuentasloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((plancuentasloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "TipACod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_TIPACOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CueCierre") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUECIERRE' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CueMonDebe") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUEMONDEBE' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CueMonHaber") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUEMONHABER' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CueGasDebe") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUEGASDEBE' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "CueGasHaber") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CUEGASHABER' */
            S161 ();
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
         /* 'LOADCOMBOITEMS_TIPACOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1900TipADsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P006J2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1900TipADsc = P006J2_A1900TipADsc[0];
               A70TipACod = P006J2_A70TipACod[0];
               n70TipACod = P006J2_n70TipACod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A1900TipADsc;
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
                  /* Using cursor P006J3 */
                  pr_default.execute(1, new Object[] {AV25CueCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A91CueCod = P006J3_A91CueCod[0];
                     A70TipACod = P006J3_A70TipACod[0];
                     n70TipACod = P006J3_n70TipACod[0];
                     A1900TipADsc = P006J3_A1900TipADsc[0];
                     A1900TipADsc = P006J3_A1900TipADsc[0];
                     AV15SelectedValue = ((0==A70TipACod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A70TipACod), 6, 0)));
                     AV20SelectedText = A1900TipADsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV24TipACod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
                  /* Using cursor P006J4 */
                  pr_default.execute(2, new Object[] {AV24TipACod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A70TipACod = P006J4_A70TipACod[0];
                     n70TipACod = P006J4_n70TipACod[0];
                     A1900TipADsc = P006J4_A1900TipADsc[0];
                     AV20SelectedText = A1900TipADsc;
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
         /* 'LOADCOMBOITEMS_CUECIERRE' Routine */
         returnInSub = false;
         /* Using cursor P006J5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            A873CueSts = P006J5_A873CueSts[0];
            A867CueMov = P006J5_A867CueMov[0];
            A2098CueDscCompleto = P006J5_A2098CueDscCompleto[0];
            A91CueCod = P006J5_A91CueCod[0];
            A860CueDsc = P006J5_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(3);
         }
         pr_default.close(3);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J6 */
            pr_default.execute(4, new Object[] {AV25CueCod});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A91CueCod = P006J6_A91CueCod[0];
               A113CueCierre = P006J6_A113CueCierre[0];
               n113CueCierre = P006J6_n113CueCierre[0];
               AV15SelectedValue = A113CueCierre;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(4);
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_CUEMONDEBE' Routine */
         returnInSub = false;
         /* Using cursor P006J7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            A873CueSts = P006J7_A873CueSts[0];
            A867CueMov = P006J7_A867CueMov[0];
            A2098CueDscCompleto = P006J7_A2098CueDscCompleto[0];
            A91CueCod = P006J7_A91CueCod[0];
            A860CueDsc = P006J7_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(5);
         }
         pr_default.close(5);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J8 */
            pr_default.execute(6, new Object[] {AV25CueCod});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A91CueCod = P006J8_A91CueCod[0];
               A111CueMonDebe = P006J8_A111CueMonDebe[0];
               n111CueMonDebe = P006J8_n111CueMonDebe[0];
               AV15SelectedValue = A111CueMonDebe;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(6);
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_CUEMONHABER' Routine */
         returnInSub = false;
         /* Using cursor P006J9 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            A873CueSts = P006J9_A873CueSts[0];
            A867CueMov = P006J9_A867CueMov[0];
            A2098CueDscCompleto = P006J9_A2098CueDscCompleto[0];
            A91CueCod = P006J9_A91CueCod[0];
            A860CueDsc = P006J9_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(7);
         }
         pr_default.close(7);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J10 */
            pr_default.execute(8, new Object[] {AV25CueCod});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A91CueCod = P006J10_A91CueCod[0];
               A112CueMonHaber = P006J10_A112CueMonHaber[0];
               n112CueMonHaber = P006J10_n112CueMonHaber[0];
               AV15SelectedValue = A112CueMonHaber;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(8);
         }
      }

      protected void S151( )
      {
         /* 'LOADCOMBOITEMS_CUEGASDEBE' Routine */
         returnInSub = false;
         /* Using cursor P006J11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A873CueSts = P006J11_A873CueSts[0];
            A867CueMov = P006J11_A867CueMov[0];
            A2098CueDscCompleto = P006J11_A2098CueDscCompleto[0];
            A91CueCod = P006J11_A91CueCod[0];
            A860CueDsc = P006J11_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J12 */
            pr_default.execute(10, new Object[] {AV25CueCod});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A91CueCod = P006J12_A91CueCod[0];
               A109CueGasDebe = P006J12_A109CueGasDebe[0];
               n109CueGasDebe = P006J12_n109CueGasDebe[0];
               AV15SelectedValue = A109CueGasDebe;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
         }
      }

      protected void S161( )
      {
         /* 'LOADCOMBOITEMS_CUEGASHABER' Routine */
         returnInSub = false;
         /* Using cursor P006J13 */
         pr_default.execute(11);
         while ( (pr_default.getStatus(11) != 101) )
         {
            A873CueSts = P006J13_A873CueSts[0];
            A867CueMov = P006J13_A867CueMov[0];
            A2098CueDscCompleto = P006J13_A2098CueDscCompleto[0];
            A91CueCod = P006J13_A91CueCod[0];
            A860CueDsc = P006J13_A860CueDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = A91CueCod;
            AV14Combo_DataItem.gxTpr_Title = A2098CueDscCompleto;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(11);
         }
         pr_default.close(11);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P006J14 */
            pr_default.execute(12, new Object[] {AV25CueCod});
            while ( (pr_default.getStatus(12) != 101) )
            {
               A91CueCod = P006J14_A91CueCod[0];
               A110CueGasHaber = P006J14_A110CueGasHaber[0];
               n110CueGasHaber = P006J14_n110CueGasHaber[0];
               AV15SelectedValue = A110CueGasHaber;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(12);
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
         A1900TipADsc = "";
         P006J2_A1900TipADsc = new string[] {""} ;
         P006J2_A70TipACod = new int[1] ;
         P006J2_n70TipACod = new bool[] {false} ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P006J3_A91CueCod = new string[] {""} ;
         P006J3_A70TipACod = new int[1] ;
         P006J3_n70TipACod = new bool[] {false} ;
         P006J3_A1900TipADsc = new string[] {""} ;
         A91CueCod = "";
         P006J4_A70TipACod = new int[1] ;
         P006J4_n70TipACod = new bool[] {false} ;
         P006J4_A1900TipADsc = new string[] {""} ;
         P006J5_A873CueSts = new short[1] ;
         P006J5_A867CueMov = new short[1] ;
         P006J5_A2098CueDscCompleto = new string[] {""} ;
         P006J5_A91CueCod = new string[] {""} ;
         P006J5_A860CueDsc = new string[] {""} ;
         A2098CueDscCompleto = "";
         A860CueDsc = "";
         P006J6_A91CueCod = new string[] {""} ;
         P006J6_A113CueCierre = new string[] {""} ;
         P006J6_n113CueCierre = new bool[] {false} ;
         A113CueCierre = "";
         P006J7_A873CueSts = new short[1] ;
         P006J7_A867CueMov = new short[1] ;
         P006J7_A2098CueDscCompleto = new string[] {""} ;
         P006J7_A91CueCod = new string[] {""} ;
         P006J7_A860CueDsc = new string[] {""} ;
         P006J8_A91CueCod = new string[] {""} ;
         P006J8_A111CueMonDebe = new string[] {""} ;
         P006J8_n111CueMonDebe = new bool[] {false} ;
         A111CueMonDebe = "";
         P006J9_A873CueSts = new short[1] ;
         P006J9_A867CueMov = new short[1] ;
         P006J9_A2098CueDscCompleto = new string[] {""} ;
         P006J9_A91CueCod = new string[] {""} ;
         P006J9_A860CueDsc = new string[] {""} ;
         P006J10_A91CueCod = new string[] {""} ;
         P006J10_A112CueMonHaber = new string[] {""} ;
         P006J10_n112CueMonHaber = new bool[] {false} ;
         A112CueMonHaber = "";
         P006J11_A873CueSts = new short[1] ;
         P006J11_A867CueMov = new short[1] ;
         P006J11_A2098CueDscCompleto = new string[] {""} ;
         P006J11_A91CueCod = new string[] {""} ;
         P006J11_A860CueDsc = new string[] {""} ;
         P006J12_A91CueCod = new string[] {""} ;
         P006J12_A109CueGasDebe = new string[] {""} ;
         P006J12_n109CueGasDebe = new bool[] {false} ;
         A109CueGasDebe = "";
         P006J13_A873CueSts = new short[1] ;
         P006J13_A867CueMov = new short[1] ;
         P006J13_A2098CueDscCompleto = new string[] {""} ;
         P006J13_A91CueCod = new string[] {""} ;
         P006J13_A860CueDsc = new string[] {""} ;
         P006J14_A91CueCod = new string[] {""} ;
         P006J14_A110CueGasHaber = new string[] {""} ;
         P006J14_n110CueGasHaber = new bool[] {false} ;
         A110CueGasHaber = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.plancuentasloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P006J2_A1900TipADsc, P006J2_A70TipACod
               }
               , new Object[] {
               P006J3_A91CueCod, P006J3_A70TipACod, P006J3_n70TipACod, P006J3_A1900TipADsc
               }
               , new Object[] {
               P006J4_A70TipACod, P006J4_A1900TipADsc
               }
               , new Object[] {
               P006J5_A873CueSts, P006J5_A867CueMov, P006J5_A2098CueDscCompleto, P006J5_A91CueCod, P006J5_A860CueDsc
               }
               , new Object[] {
               P006J6_A91CueCod, P006J6_A113CueCierre, P006J6_n113CueCierre
               }
               , new Object[] {
               P006J7_A873CueSts, P006J7_A867CueMov, P006J7_A2098CueDscCompleto, P006J7_A91CueCod, P006J7_A860CueDsc
               }
               , new Object[] {
               P006J8_A91CueCod, P006J8_A111CueMonDebe, P006J8_n111CueMonDebe
               }
               , new Object[] {
               P006J9_A873CueSts, P006J9_A867CueMov, P006J9_A2098CueDscCompleto, P006J9_A91CueCod, P006J9_A860CueDsc
               }
               , new Object[] {
               P006J10_A91CueCod, P006J10_A112CueMonHaber, P006J10_n112CueMonHaber
               }
               , new Object[] {
               P006J11_A873CueSts, P006J11_A867CueMov, P006J11_A2098CueDscCompleto, P006J11_A91CueCod, P006J11_A860CueDsc
               }
               , new Object[] {
               P006J12_A91CueCod, P006J12_A109CueGasDebe, P006J12_n109CueGasDebe
               }
               , new Object[] {
               P006J13_A873CueSts, P006J13_A867CueMov, P006J13_A2098CueDscCompleto, P006J13_A91CueCod, P006J13_A860CueDsc
               }
               , new Object[] {
               P006J14_A91CueCod, P006J14_A110CueGasHaber, P006J14_n110CueGasHaber
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A873CueSts ;
      private short A867CueMov ;
      private int AV10MaxItems ;
      private int A70TipACod ;
      private int AV24TipACod ;
      private string AV18TrnMode ;
      private string AV25CueCod ;
      private string scmdbuf ;
      private string A1900TipADsc ;
      private string A91CueCod ;
      private string A2098CueDscCompleto ;
      private string A860CueDsc ;
      private string A113CueCierre ;
      private string A111CueMonDebe ;
      private string A112CueMonHaber ;
      private string A109CueGasDebe ;
      private string A110CueGasHaber ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n70TipACod ;
      private bool n113CueCierre ;
      private bool n111CueMonDebe ;
      private bool n112CueMonHaber ;
      private bool n109CueGasDebe ;
      private bool n110CueGasHaber ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006J2_A1900TipADsc ;
      private int[] P006J2_A70TipACod ;
      private bool[] P006J2_n70TipACod ;
      private string[] P006J3_A91CueCod ;
      private int[] P006J3_A70TipACod ;
      private bool[] P006J3_n70TipACod ;
      private string[] P006J3_A1900TipADsc ;
      private int[] P006J4_A70TipACod ;
      private bool[] P006J4_n70TipACod ;
      private string[] P006J4_A1900TipADsc ;
      private short[] P006J5_A873CueSts ;
      private short[] P006J5_A867CueMov ;
      private string[] P006J5_A2098CueDscCompleto ;
      private string[] P006J5_A91CueCod ;
      private string[] P006J5_A860CueDsc ;
      private string[] P006J6_A91CueCod ;
      private string[] P006J6_A113CueCierre ;
      private bool[] P006J6_n113CueCierre ;
      private short[] P006J7_A873CueSts ;
      private short[] P006J7_A867CueMov ;
      private string[] P006J7_A2098CueDscCompleto ;
      private string[] P006J7_A91CueCod ;
      private string[] P006J7_A860CueDsc ;
      private string[] P006J8_A91CueCod ;
      private string[] P006J8_A111CueMonDebe ;
      private bool[] P006J8_n111CueMonDebe ;
      private short[] P006J9_A873CueSts ;
      private short[] P006J9_A867CueMov ;
      private string[] P006J9_A2098CueDscCompleto ;
      private string[] P006J9_A91CueCod ;
      private string[] P006J9_A860CueDsc ;
      private string[] P006J10_A91CueCod ;
      private string[] P006J10_A112CueMonHaber ;
      private bool[] P006J10_n112CueMonHaber ;
      private short[] P006J11_A873CueSts ;
      private short[] P006J11_A867CueMov ;
      private string[] P006J11_A2098CueDscCompleto ;
      private string[] P006J11_A91CueCod ;
      private string[] P006J11_A860CueDsc ;
      private string[] P006J12_A91CueCod ;
      private string[] P006J12_A109CueGasDebe ;
      private bool[] P006J12_n109CueGasDebe ;
      private short[] P006J13_A873CueSts ;
      private short[] P006J13_A867CueMov ;
      private string[] P006J13_A2098CueDscCompleto ;
      private string[] P006J13_A91CueCod ;
      private string[] P006J13_A860CueDsc ;
      private string[] P006J14_A91CueCod ;
      private string[] P006J14_A110CueGasHaber ;
      private bool[] P006J14_n110CueGasHaber ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class plancuentasloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006J2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1900TipADsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipADsc], [TipACod] FROM [CBTIPAUXILIAR]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipADsc]";
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
                     return conditional_P006J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006J3;
          prmP006J3 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J4;
          prmP006J4 = new Object[] {
          new ParDef("@AV24TipACod",GXType.Int32,6,0)
          };
          Object[] prmP006J5;
          prmP006J5 = new Object[] {
          };
          Object[] prmP006J6;
          prmP006J6 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J7;
          prmP006J7 = new Object[] {
          };
          Object[] prmP006J8;
          prmP006J8 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J9;
          prmP006J9 = new Object[] {
          };
          Object[] prmP006J10;
          prmP006J10 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J11;
          prmP006J11 = new Object[] {
          };
          Object[] prmP006J12;
          prmP006J12 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J13;
          prmP006J13 = new Object[] {
          };
          Object[] prmP006J14;
          prmP006J14 = new Object[] {
          new ParDef("@AV25CueCod",GXType.NChar,15,0)
          };
          Object[] prmP006J2;
          prmP006J2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J3", "SELECT T1.[CueCod], T1.[TipACod], T2.[TipADsc] FROM ([CBPLANCUENTA] T1 LEFT JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod]) WHERE T1.[CueCod] = @AV25CueCod ORDER BY T1.[CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J4", "SELECT TOP 1 [TipACod], [TipADsc] FROM [CBTIPAUXILIAR] WHERE [TipACod] = @AV24TipACod ORDER BY [TipACod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J5", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J6", "SELECT [CueCod], [CueCierre] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV25CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J7", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J7,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J8", "SELECT [CueCod], [CueMonDebe] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV25CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J8,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J9", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J9,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J10", "SELECT [CueCod], [CueMonHaber] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV25CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J11", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J12", "SELECT [CueCod], [CueGasDebe] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV25CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006J13", "SELECT [CueSts], [CueMov], RTRIM(LTRIM([CueCod])) + ' - ' + RTRIM(LTRIM([CueDsc])) AS CueDscCompleto, [CueCod], [CueDsc] FROM [CBPLANCUENTA] WHERE ([CueSts] = 1) AND ([CueMov] = 1) ORDER BY [CueDscCompleto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J13,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006J14", "SELECT [CueCod], [CueGasHaber] FROM [CBPLANCUENTA] WHERE [CueCod] = @AV25CueCod ORDER BY [CueCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006J14,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
