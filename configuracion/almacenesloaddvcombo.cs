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
namespace GeneXus.Programs.configuracion {
   public class almacenesloaddvcombo : GXProcedure
   {
      public almacenesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public almacenesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           int aP3_AlmCod ,
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
         this.AV27AlmCod = aP3_AlmCod;
         this.AV28Cond_PaiCod = aP4_Cond_PaiCod;
         this.AV29Cond_EstCod = aP5_Cond_EstCod;
         this.AV30Cond_ProvCod = aP6_Cond_ProvCod;
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
                                int aP3_AlmCod ,
                                string aP4_Cond_PaiCod ,
                                string aP5_Cond_EstCod ,
                                string aP6_Cond_ProvCod ,
                                string aP7_SearchTxt ,
                                out string aP8_SelectedValue ,
                                out string aP9_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_AlmCod, aP4_Cond_PaiCod, aP5_Cond_EstCod, aP6_Cond_ProvCod, aP7_SearchTxt, out aP8_SelectedValue, out aP9_SelectedText, out aP10_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 int aP3_AlmCod ,
                                 string aP4_Cond_PaiCod ,
                                 string aP5_Cond_EstCod ,
                                 string aP6_Cond_ProvCod ,
                                 string aP7_SearchTxt ,
                                 out string aP8_SelectedValue ,
                                 out string aP9_SelectedText ,
                                 out string aP10_Combo_DataJson )
      {
         almacenesloaddvcombo objalmacenesloaddvcombo;
         objalmacenesloaddvcombo = new almacenesloaddvcombo();
         objalmacenesloaddvcombo.AV16ComboName = aP0_ComboName;
         objalmacenesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objalmacenesloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objalmacenesloaddvcombo.AV27AlmCod = aP3_AlmCod;
         objalmacenesloaddvcombo.AV28Cond_PaiCod = aP4_Cond_PaiCod;
         objalmacenesloaddvcombo.AV29Cond_EstCod = aP5_Cond_EstCod;
         objalmacenesloaddvcombo.AV30Cond_ProvCod = aP6_Cond_ProvCod;
         objalmacenesloaddvcombo.AV11SearchTxt = aP7_SearchTxt;
         objalmacenesloaddvcombo.AV15SelectedValue = "" ;
         objalmacenesloaddvcombo.AV20SelectedText = "" ;
         objalmacenesloaddvcombo.AV12Combo_DataJson = "" ;
         objalmacenesloaddvcombo.context.SetSubmitInitialConfig(context);
         objalmacenesloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objalmacenesloaddvcombo);
         aP8_SelectedValue=this.AV15SelectedValue;
         aP9_SelectedText=this.AV20SelectedText;
         aP10_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((almacenesloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "PaiCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PAICOD' */
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
         else if ( StringUtil.StrCmp(AV16ComboName, "ProvCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_PROVCOD' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "DisCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_DISCOD' */
            S141 ();
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
         /* 'LOADCOMBOITEMS_PAICOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1500PaiDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P002H2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1500PaiDsc = P002H2_A1500PaiDsc[0];
               A139PaiCod = P002H2_A139PaiCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A139PaiCod;
               AV14Combo_DataItem.gxTpr_Title = A1500PaiDsc;
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
                  /* Using cursor P002H3 */
                  pr_default.execute(1, new Object[] {AV27AlmCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A63AlmCod = P002H3_A63AlmCod[0];
                     A139PaiCod = P002H3_A139PaiCod[0];
                     A1500PaiDsc = P002H3_A1500PaiDsc[0];
                     A1500PaiDsc = P002H3_A1500PaiDsc[0];
                     AV15SelectedValue = A139PaiCod;
                     AV20SelectedText = A1500PaiDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV23PaiCod = AV11SearchTxt;
                  /* Using cursor P002H4 */
                  pr_default.execute(2, new Object[] {AV23PaiCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A139PaiCod = P002H4_A139PaiCod[0];
                     A1500PaiDsc = P002H4_A1500PaiDsc[0];
                     AV20SelectedText = A1500PaiDsc;
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
         /* 'LOADCOMBOITEMS_ESTCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A602EstDsc ,
                                                 A139PaiCod ,
                                                 AV28Cond_PaiCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P002H5 */
            pr_default.execute(3, new Object[] {AV28Cond_PaiCod, lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A139PaiCod = P002H5_A139PaiCod[0];
               A602EstDsc = P002H5_A602EstDsc[0];
               A140EstCod = P002H5_A140EstCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A140EstCod;
               AV14Combo_DataItem.gxTpr_Title = A602EstDsc;
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
                  /* Using cursor P002H6 */
                  pr_default.execute(4, new Object[] {AV27AlmCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A139PaiCod = P002H6_A139PaiCod[0];
                     A63AlmCod = P002H6_A63AlmCod[0];
                     A140EstCod = P002H6_A140EstCod[0];
                     A602EstDsc = P002H6_A602EstDsc[0];
                     A602EstDsc = P002H6_A602EstDsc[0];
                     AV15SelectedValue = A140EstCod;
                     AV20SelectedText = A602EstDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV24EstCod = AV11SearchTxt;
                  /* Using cursor P002H7 */
                  pr_default.execute(5, new Object[] {AV28Cond_PaiCod, AV24EstCod});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A139PaiCod = P002H7_A139PaiCod[0];
                     A140EstCod = P002H7_A140EstCod[0];
                     A602EstDsc = P002H7_A602EstDsc[0];
                     AV20SelectedText = A602EstDsc;
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
         /* 'LOADCOMBOITEMS_PROVCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A603ProvDsc ,
                                                 A139PaiCod ,
                                                 AV28Cond_PaiCod ,
                                                 A140EstCod ,
                                                 AV29Cond_EstCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P002H8 */
            pr_default.execute(6, new Object[] {AV28Cond_PaiCod, AV29Cond_EstCod, lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A139PaiCod = P002H8_A139PaiCod[0];
               A140EstCod = P002H8_A140EstCod[0];
               A603ProvDsc = P002H8_A603ProvDsc[0];
               A141ProvCod = P002H8_A141ProvCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A141ProvCod;
               AV14Combo_DataItem.gxTpr_Title = A603ProvDsc;
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
                  /* Using cursor P002H9 */
                  pr_default.execute(7, new Object[] {AV27AlmCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A139PaiCod = P002H9_A139PaiCod[0];
                     A140EstCod = P002H9_A140EstCod[0];
                     A63AlmCod = P002H9_A63AlmCod[0];
                     A141ProvCod = P002H9_A141ProvCod[0];
                     A603ProvDsc = P002H9_A603ProvDsc[0];
                     A603ProvDsc = P002H9_A603ProvDsc[0];
                     AV15SelectedValue = A141ProvCod;
                     AV20SelectedText = A603ProvDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV25ProvCod = AV11SearchTxt;
                  /* Using cursor P002H10 */
                  pr_default.execute(8, new Object[] {AV28Cond_PaiCod, AV29Cond_EstCod, AV25ProvCod});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A140EstCod = P002H10_A140EstCod[0];
                     A139PaiCod = P002H10_A139PaiCod[0];
                     A141ProvCod = P002H10_A141ProvCod[0];
                     A603ProvDsc = P002H10_A603ProvDsc[0];
                     AV20SelectedText = A603ProvDsc;
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
         /* 'LOADCOMBOITEMS_DISCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(9, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A604DisDsc ,
                                                 A139PaiCod ,
                                                 AV28Cond_PaiCod ,
                                                 A140EstCod ,
                                                 AV29Cond_EstCod ,
                                                 A141ProvCod ,
                                                 AV30Cond_ProvCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P002H11 */
            pr_default.execute(9, new Object[] {AV28Cond_PaiCod, AV29Cond_EstCod, AV30Cond_ProvCod, lV11SearchTxt});
            while ( (pr_default.getStatus(9) != 101) )
            {
               A139PaiCod = P002H11_A139PaiCod[0];
               A140EstCod = P002H11_A140EstCod[0];
               A141ProvCod = P002H11_A141ProvCod[0];
               A604DisDsc = P002H11_A604DisDsc[0];
               A142DisCod = P002H11_A142DisCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A142DisCod;
               AV14Combo_DataItem.gxTpr_Title = A604DisDsc;
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
                  /* Using cursor P002H12 */
                  pr_default.execute(10, new Object[] {AV27AlmCod});
                  while ( (pr_default.getStatus(10) != 101) )
                  {
                     A139PaiCod = P002H12_A139PaiCod[0];
                     A140EstCod = P002H12_A140EstCod[0];
                     A141ProvCod = P002H12_A141ProvCod[0];
                     A63AlmCod = P002H12_A63AlmCod[0];
                     A142DisCod = P002H12_A142DisCod[0];
                     A604DisDsc = P002H12_A604DisDsc[0];
                     A604DisDsc = P002H12_A604DisDsc[0];
                     AV15SelectedValue = A142DisCod;
                     AV20SelectedText = A604DisDsc;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(10);
               }
               else
               {
                  AV26DisCod = AV11SearchTxt;
                  /* Using cursor P002H13 */
                  pr_default.execute(11, new Object[] {AV28Cond_PaiCod, AV29Cond_EstCod, AV30Cond_ProvCod, AV26DisCod});
                  while ( (pr_default.getStatus(11) != 101) )
                  {
                     A141ProvCod = P002H13_A141ProvCod[0];
                     A140EstCod = P002H13_A140EstCod[0];
                     A139PaiCod = P002H13_A139PaiCod[0];
                     A142DisCod = P002H13_A142DisCod[0];
                     A604DisDsc = P002H13_A604DisDsc[0];
                     AV20SelectedText = A604DisDsc;
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
         A1500PaiDsc = "";
         P002H2_A1500PaiDsc = new string[] {""} ;
         P002H2_A139PaiCod = new string[] {""} ;
         A139PaiCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P002H3_A63AlmCod = new int[1] ;
         P002H3_A139PaiCod = new string[] {""} ;
         P002H3_A1500PaiDsc = new string[] {""} ;
         AV23PaiCod = "";
         P002H4_A139PaiCod = new string[] {""} ;
         P002H4_A1500PaiDsc = new string[] {""} ;
         A602EstDsc = "";
         P002H5_A139PaiCod = new string[] {""} ;
         P002H5_A602EstDsc = new string[] {""} ;
         P002H5_A140EstCod = new string[] {""} ;
         A140EstCod = "";
         P002H6_A139PaiCod = new string[] {""} ;
         P002H6_A63AlmCod = new int[1] ;
         P002H6_A140EstCod = new string[] {""} ;
         P002H6_A602EstDsc = new string[] {""} ;
         AV24EstCod = "";
         P002H7_A139PaiCod = new string[] {""} ;
         P002H7_A140EstCod = new string[] {""} ;
         P002H7_A602EstDsc = new string[] {""} ;
         A603ProvDsc = "";
         P002H8_A139PaiCod = new string[] {""} ;
         P002H8_A140EstCod = new string[] {""} ;
         P002H8_A603ProvDsc = new string[] {""} ;
         P002H8_A141ProvCod = new string[] {""} ;
         A141ProvCod = "";
         P002H9_A139PaiCod = new string[] {""} ;
         P002H9_A140EstCod = new string[] {""} ;
         P002H9_A63AlmCod = new int[1] ;
         P002H9_A141ProvCod = new string[] {""} ;
         P002H9_A603ProvDsc = new string[] {""} ;
         AV25ProvCod = "";
         P002H10_A140EstCod = new string[] {""} ;
         P002H10_A139PaiCod = new string[] {""} ;
         P002H10_A141ProvCod = new string[] {""} ;
         P002H10_A603ProvDsc = new string[] {""} ;
         A604DisDsc = "";
         P002H11_A139PaiCod = new string[] {""} ;
         P002H11_A140EstCod = new string[] {""} ;
         P002H11_A141ProvCod = new string[] {""} ;
         P002H11_A604DisDsc = new string[] {""} ;
         P002H11_A142DisCod = new string[] {""} ;
         A142DisCod = "";
         P002H12_A139PaiCod = new string[] {""} ;
         P002H12_A140EstCod = new string[] {""} ;
         P002H12_A141ProvCod = new string[] {""} ;
         P002H12_A63AlmCod = new int[1] ;
         P002H12_A142DisCod = new string[] {""} ;
         P002H12_A604DisDsc = new string[] {""} ;
         AV26DisCod = "";
         P002H13_A141ProvCod = new string[] {""} ;
         P002H13_A140EstCod = new string[] {""} ;
         P002H13_A139PaiCod = new string[] {""} ;
         P002H13_A142DisCod = new string[] {""} ;
         P002H13_A604DisDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almacenesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P002H2_A1500PaiDsc, P002H2_A139PaiCod
               }
               , new Object[] {
               P002H3_A63AlmCod, P002H3_A139PaiCod, P002H3_A1500PaiDsc
               }
               , new Object[] {
               P002H4_A139PaiCod, P002H4_A1500PaiDsc
               }
               , new Object[] {
               P002H5_A139PaiCod, P002H5_A602EstDsc, P002H5_A140EstCod
               }
               , new Object[] {
               P002H6_A139PaiCod, P002H6_A63AlmCod, P002H6_A140EstCod, P002H6_A602EstDsc
               }
               , new Object[] {
               P002H7_A139PaiCod, P002H7_A140EstCod, P002H7_A602EstDsc
               }
               , new Object[] {
               P002H8_A139PaiCod, P002H8_A140EstCod, P002H8_A603ProvDsc, P002H8_A141ProvCod
               }
               , new Object[] {
               P002H9_A139PaiCod, P002H9_A140EstCod, P002H9_A63AlmCod, P002H9_A141ProvCod, P002H9_A603ProvDsc
               }
               , new Object[] {
               P002H10_A140EstCod, P002H10_A139PaiCod, P002H10_A141ProvCod, P002H10_A603ProvDsc
               }
               , new Object[] {
               P002H11_A139PaiCod, P002H11_A140EstCod, P002H11_A141ProvCod, P002H11_A604DisDsc, P002H11_A142DisCod
               }
               , new Object[] {
               P002H12_A139PaiCod, P002H12_A140EstCod, P002H12_A141ProvCod, P002H12_A63AlmCod, P002H12_A142DisCod, P002H12_A604DisDsc
               }
               , new Object[] {
               P002H13_A141ProvCod, P002H13_A140EstCod, P002H13_A139PaiCod, P002H13_A142DisCod, P002H13_A604DisDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV27AlmCod ;
      private int AV10MaxItems ;
      private int A63AlmCod ;
      private string AV18TrnMode ;
      private string AV28Cond_PaiCod ;
      private string AV29Cond_EstCod ;
      private string AV30Cond_ProvCod ;
      private string scmdbuf ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string AV23PaiCod ;
      private string A602EstDsc ;
      private string A140EstCod ;
      private string AV24EstCod ;
      private string A603ProvDsc ;
      private string A141ProvCod ;
      private string AV25ProvCod ;
      private string A604DisDsc ;
      private string A142DisCod ;
      private string AV26DisCod ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002H2_A1500PaiDsc ;
      private string[] P002H2_A139PaiCod ;
      private int[] P002H3_A63AlmCod ;
      private string[] P002H3_A139PaiCod ;
      private string[] P002H3_A1500PaiDsc ;
      private string[] P002H4_A139PaiCod ;
      private string[] P002H4_A1500PaiDsc ;
      private string[] P002H5_A139PaiCod ;
      private string[] P002H5_A602EstDsc ;
      private string[] P002H5_A140EstCod ;
      private string[] P002H6_A139PaiCod ;
      private int[] P002H6_A63AlmCod ;
      private string[] P002H6_A140EstCod ;
      private string[] P002H6_A602EstDsc ;
      private string[] P002H7_A139PaiCod ;
      private string[] P002H7_A140EstCod ;
      private string[] P002H7_A602EstDsc ;
      private string[] P002H8_A139PaiCod ;
      private string[] P002H8_A140EstCod ;
      private string[] P002H8_A603ProvDsc ;
      private string[] P002H8_A141ProvCod ;
      private string[] P002H9_A139PaiCod ;
      private string[] P002H9_A140EstCod ;
      private int[] P002H9_A63AlmCod ;
      private string[] P002H9_A141ProvCod ;
      private string[] P002H9_A603ProvDsc ;
      private string[] P002H10_A140EstCod ;
      private string[] P002H10_A139PaiCod ;
      private string[] P002H10_A141ProvCod ;
      private string[] P002H10_A603ProvDsc ;
      private string[] P002H11_A139PaiCod ;
      private string[] P002H11_A140EstCod ;
      private string[] P002H11_A141ProvCod ;
      private string[] P002H11_A604DisDsc ;
      private string[] P002H11_A142DisCod ;
      private string[] P002H12_A139PaiCod ;
      private string[] P002H12_A140EstCod ;
      private string[] P002H12_A141ProvCod ;
      private int[] P002H12_A63AlmCod ;
      private string[] P002H12_A142DisCod ;
      private string[] P002H12_A604DisDsc ;
      private string[] P002H13_A141ProvCod ;
      private string[] P002H13_A140EstCod ;
      private string[] P002H13_A139PaiCod ;
      private string[] P002H13_A142DisCod ;
      private string[] P002H13_A604DisDsc ;
      private string aP8_SelectedValue ;
      private string aP9_SelectedText ;
      private string aP10_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class almacenesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002H2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PaiDsc], [PaiCod] FROM [CPAISES]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaiDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002H5( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string AV28Cond_PaiCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstDsc], [EstCod] FROM [CESTADOS]";
         AddWhere(sWhereString, "([PaiCod] = @AV28Cond_PaiCod)");
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

      protected Object[] conditional_P002H8( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A603ProvDsc ,
                                             string A139PaiCod ,
                                             string AV28Cond_PaiCod ,
                                             string A140EstCod ,
                                             string AV29Cond_EstCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[3];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstCod], [ProvDsc], [ProvCod] FROM [CPROVINCIA]";
         AddWhere(sWhereString, "([PaiCod] = @AV28Cond_PaiCod)");
         AddWhere(sWhereString, "([EstCod] = @AV29Cond_EstCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ProvDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ProvDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P002H11( IGxContext context ,
                                              string AV11SearchTxt ,
                                              string A604DisDsc ,
                                              string A139PaiCod ,
                                              string AV28Cond_PaiCod ,
                                              string A140EstCod ,
                                              string AV29Cond_EstCod ,
                                              string A141ProvCod ,
                                              string AV30Cond_ProvCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[4];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstCod], [ProvCod], [DisDsc], [DisCod] FROM [CDISTRITOS]";
         AddWhere(sWhereString, "([PaiCod] = @AV28Cond_PaiCod)");
         AddWhere(sWhereString, "([EstCod] = @AV29Cond_EstCod)");
         AddWhere(sWhereString, "([ProvCod] = @AV30Cond_ProvCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([DisDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DisDsc]";
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
                     return conditional_P002H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P002H5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 6 :
                     return conditional_P002H8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
               case 9 :
                     return conditional_P002H11(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002H3;
          prmP002H3 = new Object[] {
          new ParDef("@AV27AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP002H4;
          prmP002H4 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP002H6;
          prmP002H6 = new Object[] {
          new ParDef("@AV27AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP002H7;
          prmP002H7 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0)
          };
          Object[] prmP002H9;
          prmP002H9 = new Object[] {
          new ParDef("@AV27AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP002H10;
          prmP002H10 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV29Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV25ProvCod",GXType.NChar,4,0)
          };
          Object[] prmP002H12;
          prmP002H12 = new Object[] {
          new ParDef("@AV27AlmCod",GXType.Int32,6,0)
          };
          Object[] prmP002H13;
          prmP002H13 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV29Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV30Cond_ProvCod",GXType.NChar,4,0) ,
          new ParDef("@AV26DisCod",GXType.NChar,4,0)
          };
          Object[] prmP002H2;
          prmP002H2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP002H5;
          prmP002H5 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP002H8;
          prmP002H8 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV29Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP002H11;
          prmP002H11 = new Object[] {
          new ParDef("@AV28Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV29Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV30Cond_ProvCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002H3", "SELECT T1.[AlmCod], T1.[PaiCod], T2.[PaiDsc] FROM ([CALMACEN] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod]) WHERE T1.[AlmCod] = @AV27AlmCod ORDER BY T1.[AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H4", "SELECT TOP 1 [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV23PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002H6", "SELECT T1.[PaiCod], T1.[AlmCod], T1.[EstCod], T2.[EstDsc] FROM ([CALMACEN] T1 INNER JOIN [CESTADOS] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod]) WHERE T1.[AlmCod] = @AV27AlmCod ORDER BY T1.[AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H7", "SELECT TOP 1 [PaiCod], [EstCod], [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @AV28Cond_PaiCod and [EstCod] = @AV24EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002H9", "SELECT T1.[PaiCod], T1.[EstCod], T1.[AlmCod], T1.[ProvCod], T2.[ProvDsc] FROM ([CALMACEN] T1 INNER JOIN [CPROVINCIA] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod] AND T2.[ProvCod] = T1.[ProvCod]) WHERE T1.[AlmCod] = @AV27AlmCod ORDER BY T1.[AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H10", "SELECT TOP 1 [EstCod], [PaiCod], [ProvCod], [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @AV28Cond_PaiCod and [EstCod] = @AV29Cond_EstCod and [ProvCod] = @AV25ProvCod ORDER BY [PaiCod], [EstCod], [ProvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H11", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P002H12", "SELECT T1.[PaiCod], T1.[EstCod], T1.[ProvCod], T1.[AlmCod], T1.[DisCod], T2.[DisDsc] FROM ([CALMACEN] T1 INNER JOIN [CDISTRITOS] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod] AND T2.[ProvCod] = T1.[ProvCod] AND T2.[DisCod] = T1.[DisCod]) WHERE T1.[AlmCod] = @AV27AlmCod ORDER BY T1.[AlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P002H13", "SELECT TOP 1 [ProvCod], [EstCod], [PaiCod], [DisCod], [DisDsc] FROM [CDISTRITOS] WHERE [PaiCod] = @AV28Cond_PaiCod and [EstCod] = @AV29Cond_EstCod and [ProvCod] = @AV30Cond_ProvCod and [DisCod] = @AV26DisCod ORDER BY [PaiCod], [EstCod], [ProvCod], [DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H13,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
