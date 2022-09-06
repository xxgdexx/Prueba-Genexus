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
   public class distritosloaddvcombo : GXProcedure
   {
      public distritosloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public distritosloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_PaiCod ,
                           string aP4_EstCod ,
                           string aP5_ProvCod ,
                           string aP6_DisCod ,
                           string aP7_Cond_PaiCod ,
                           string aP8_Cond_EstCod ,
                           string aP9_SearchTxt ,
                           out string aP10_SelectedValue ,
                           out string aP11_SelectedText ,
                           out string aP12_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV23PaiCod = aP3_PaiCod;
         this.AV24EstCod = aP4_EstCod;
         this.AV25ProvCod = aP5_ProvCod;
         this.AV26DisCod = aP6_DisCod;
         this.AV27Cond_PaiCod = aP7_Cond_PaiCod;
         this.AV28Cond_EstCod = aP8_Cond_EstCod;
         this.AV11SearchTxt = aP9_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP10_SelectedValue=this.AV15SelectedValue;
         aP11_SelectedText=this.AV20SelectedText;
         aP12_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                string aP3_PaiCod ,
                                string aP4_EstCod ,
                                string aP5_ProvCod ,
                                string aP6_DisCod ,
                                string aP7_Cond_PaiCod ,
                                string aP8_Cond_EstCod ,
                                string aP9_SearchTxt ,
                                out string aP10_SelectedValue ,
                                out string aP11_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_PaiCod, aP4_EstCod, aP5_ProvCod, aP6_DisCod, aP7_Cond_PaiCod, aP8_Cond_EstCod, aP9_SearchTxt, out aP10_SelectedValue, out aP11_SelectedText, out aP12_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_PaiCod ,
                                 string aP4_EstCod ,
                                 string aP5_ProvCod ,
                                 string aP6_DisCod ,
                                 string aP7_Cond_PaiCod ,
                                 string aP8_Cond_EstCod ,
                                 string aP9_SearchTxt ,
                                 out string aP10_SelectedValue ,
                                 out string aP11_SelectedText ,
                                 out string aP12_Combo_DataJson )
      {
         distritosloaddvcombo objdistritosloaddvcombo;
         objdistritosloaddvcombo = new distritosloaddvcombo();
         objdistritosloaddvcombo.AV16ComboName = aP0_ComboName;
         objdistritosloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objdistritosloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objdistritosloaddvcombo.AV23PaiCod = aP3_PaiCod;
         objdistritosloaddvcombo.AV24EstCod = aP4_EstCod;
         objdistritosloaddvcombo.AV25ProvCod = aP5_ProvCod;
         objdistritosloaddvcombo.AV26DisCod = aP6_DisCod;
         objdistritosloaddvcombo.AV27Cond_PaiCod = aP7_Cond_PaiCod;
         objdistritosloaddvcombo.AV28Cond_EstCod = aP8_Cond_EstCod;
         objdistritosloaddvcombo.AV11SearchTxt = aP9_SearchTxt;
         objdistritosloaddvcombo.AV15SelectedValue = "" ;
         objdistritosloaddvcombo.AV20SelectedText = "" ;
         objdistritosloaddvcombo.AV12Combo_DataJson = "" ;
         objdistritosloaddvcombo.context.SetSubmitInitialConfig(context);
         objdistritosloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdistritosloaddvcombo);
         aP10_SelectedValue=this.AV15SelectedValue;
         aP11_SelectedText=this.AV20SelectedText;
         aP12_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((distritosloaddvcombo)stateInfo).executePrivate();
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
            /* Using cursor P003Z2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1500PaiDsc = P003Z2_A1500PaiDsc[0];
               A139PaiCod = P003Z2_A139PaiCod[0];
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
               /* Using cursor P003Z3 */
               pr_default.execute(1, new Object[] {AV23PaiCod, AV24EstCod, AV25ProvCod, AV26DisCod});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A142DisCod = P003Z3_A142DisCod[0];
                  A141ProvCod = P003Z3_A141ProvCod[0];
                  A140EstCod = P003Z3_A140EstCod[0];
                  A139PaiCod = P003Z3_A139PaiCod[0];
                  A1500PaiDsc = P003Z3_A1500PaiDsc[0];
                  A1500PaiDsc = P003Z3_A1500PaiDsc[0];
                  AV15SelectedValue = A139PaiCod;
                  AV20SelectedText = A1500PaiDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(1);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23PaiCod)) )
               {
                  AV15SelectedValue = AV23PaiCod;
                  /* Using cursor P003Z4 */
                  pr_default.execute(2, new Object[] {AV23PaiCod});
                  while ( (pr_default.getStatus(2) != 101) )
                  {
                     A139PaiCod = P003Z4_A139PaiCod[0];
                     A1500PaiDsc = P003Z4_A1500PaiDsc[0];
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
                                                 AV27Cond_PaiCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P003Z5 */
            pr_default.execute(3, new Object[] {AV27Cond_PaiCod, lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A139PaiCod = P003Z5_A139PaiCod[0];
               A602EstDsc = P003Z5_A602EstDsc[0];
               A140EstCod = P003Z5_A140EstCod[0];
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
               /* Using cursor P003Z6 */
               pr_default.execute(4, new Object[] {AV23PaiCod, AV24EstCod, AV25ProvCod, AV26DisCod});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A142DisCod = P003Z6_A142DisCod[0];
                  A141ProvCod = P003Z6_A141ProvCod[0];
                  A140EstCod = P003Z6_A140EstCod[0];
                  A139PaiCod = P003Z6_A139PaiCod[0];
                  A602EstDsc = P003Z6_A602EstDsc[0];
                  A602EstDsc = P003Z6_A602EstDsc[0];
                  AV15SelectedValue = A140EstCod;
                  AV20SelectedText = A602EstDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV24EstCod)) )
               {
                  AV15SelectedValue = AV24EstCod;
                  /* Using cursor P003Z7 */
                  pr_default.execute(5, new Object[] {AV27Cond_PaiCod, AV24EstCod});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A139PaiCod = P003Z7_A139PaiCod[0];
                     A140EstCod = P003Z7_A140EstCod[0];
                     A602EstDsc = P003Z7_A602EstDsc[0];
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
                                                 AV27Cond_PaiCod ,
                                                 A140EstCod ,
                                                 AV28Cond_EstCod } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P003Z8 */
            pr_default.execute(6, new Object[] {AV27Cond_PaiCod, AV28Cond_EstCod, lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A139PaiCod = P003Z8_A139PaiCod[0];
               A140EstCod = P003Z8_A140EstCod[0];
               A603ProvDsc = P003Z8_A603ProvDsc[0];
               A141ProvCod = P003Z8_A141ProvCod[0];
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
               /* Using cursor P003Z9 */
               pr_default.execute(7, new Object[] {AV23PaiCod, AV24EstCod, AV25ProvCod, AV26DisCod});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A142DisCod = P003Z9_A142DisCod[0];
                  A141ProvCod = P003Z9_A141ProvCod[0];
                  A140EstCod = P003Z9_A140EstCod[0];
                  A139PaiCod = P003Z9_A139PaiCod[0];
                  A603ProvDsc = P003Z9_A603ProvDsc[0];
                  A603ProvDsc = P003Z9_A603ProvDsc[0];
                  AV15SelectedValue = A141ProvCod;
                  AV20SelectedText = A603ProvDsc;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(7);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ProvCod)) )
               {
                  AV15SelectedValue = AV25ProvCod;
                  /* Using cursor P003Z10 */
                  pr_default.execute(8, new Object[] {AV27Cond_PaiCod, AV28Cond_EstCod, AV25ProvCod});
                  while ( (pr_default.getStatus(8) != 101) )
                  {
                     A140EstCod = P003Z10_A140EstCod[0];
                     A139PaiCod = P003Z10_A139PaiCod[0];
                     A141ProvCod = P003Z10_A141ProvCod[0];
                     A603ProvDsc = P003Z10_A603ProvDsc[0];
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
         P003Z2_A1500PaiDsc = new string[] {""} ;
         P003Z2_A139PaiCod = new string[] {""} ;
         A139PaiCod = "";
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P003Z3_A142DisCod = new string[] {""} ;
         P003Z3_A141ProvCod = new string[] {""} ;
         P003Z3_A140EstCod = new string[] {""} ;
         P003Z3_A139PaiCod = new string[] {""} ;
         P003Z3_A1500PaiDsc = new string[] {""} ;
         A142DisCod = "";
         A141ProvCod = "";
         A140EstCod = "";
         P003Z4_A139PaiCod = new string[] {""} ;
         P003Z4_A1500PaiDsc = new string[] {""} ;
         A602EstDsc = "";
         P003Z5_A139PaiCod = new string[] {""} ;
         P003Z5_A602EstDsc = new string[] {""} ;
         P003Z5_A140EstCod = new string[] {""} ;
         P003Z6_A142DisCod = new string[] {""} ;
         P003Z6_A141ProvCod = new string[] {""} ;
         P003Z6_A140EstCod = new string[] {""} ;
         P003Z6_A139PaiCod = new string[] {""} ;
         P003Z6_A602EstDsc = new string[] {""} ;
         P003Z7_A139PaiCod = new string[] {""} ;
         P003Z7_A140EstCod = new string[] {""} ;
         P003Z7_A602EstDsc = new string[] {""} ;
         A603ProvDsc = "";
         P003Z8_A139PaiCod = new string[] {""} ;
         P003Z8_A140EstCod = new string[] {""} ;
         P003Z8_A603ProvDsc = new string[] {""} ;
         P003Z8_A141ProvCod = new string[] {""} ;
         P003Z9_A142DisCod = new string[] {""} ;
         P003Z9_A141ProvCod = new string[] {""} ;
         P003Z9_A140EstCod = new string[] {""} ;
         P003Z9_A139PaiCod = new string[] {""} ;
         P003Z9_A603ProvDsc = new string[] {""} ;
         P003Z10_A140EstCod = new string[] {""} ;
         P003Z10_A139PaiCod = new string[] {""} ;
         P003Z10_A141ProvCod = new string[] {""} ;
         P003Z10_A603ProvDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritosloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P003Z2_A1500PaiDsc, P003Z2_A139PaiCod
               }
               , new Object[] {
               P003Z3_A142DisCod, P003Z3_A141ProvCod, P003Z3_A140EstCod, P003Z3_A139PaiCod, P003Z3_A1500PaiDsc
               }
               , new Object[] {
               P003Z4_A139PaiCod, P003Z4_A1500PaiDsc
               }
               , new Object[] {
               P003Z5_A139PaiCod, P003Z5_A602EstDsc, P003Z5_A140EstCod
               }
               , new Object[] {
               P003Z6_A142DisCod, P003Z6_A141ProvCod, P003Z6_A140EstCod, P003Z6_A139PaiCod, P003Z6_A602EstDsc
               }
               , new Object[] {
               P003Z7_A139PaiCod, P003Z7_A140EstCod, P003Z7_A602EstDsc
               }
               , new Object[] {
               P003Z8_A139PaiCod, P003Z8_A140EstCod, P003Z8_A603ProvDsc, P003Z8_A141ProvCod
               }
               , new Object[] {
               P003Z9_A142DisCod, P003Z9_A141ProvCod, P003Z9_A140EstCod, P003Z9_A139PaiCod, P003Z9_A603ProvDsc
               }
               , new Object[] {
               P003Z10_A140EstCod, P003Z10_A139PaiCod, P003Z10_A141ProvCod, P003Z10_A603ProvDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV10MaxItems ;
      private string AV18TrnMode ;
      private string AV23PaiCod ;
      private string AV24EstCod ;
      private string AV25ProvCod ;
      private string AV26DisCod ;
      private string AV27Cond_PaiCod ;
      private string AV28Cond_EstCod ;
      private string scmdbuf ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A142DisCod ;
      private string A141ProvCod ;
      private string A140EstCod ;
      private string A602EstDsc ;
      private string A603ProvDsc ;
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
      private string[] P003Z2_A1500PaiDsc ;
      private string[] P003Z2_A139PaiCod ;
      private string[] P003Z3_A142DisCod ;
      private string[] P003Z3_A141ProvCod ;
      private string[] P003Z3_A140EstCod ;
      private string[] P003Z3_A139PaiCod ;
      private string[] P003Z3_A1500PaiDsc ;
      private string[] P003Z4_A139PaiCod ;
      private string[] P003Z4_A1500PaiDsc ;
      private string[] P003Z5_A139PaiCod ;
      private string[] P003Z5_A602EstDsc ;
      private string[] P003Z5_A140EstCod ;
      private string[] P003Z6_A142DisCod ;
      private string[] P003Z6_A141ProvCod ;
      private string[] P003Z6_A140EstCod ;
      private string[] P003Z6_A139PaiCod ;
      private string[] P003Z6_A602EstDsc ;
      private string[] P003Z7_A139PaiCod ;
      private string[] P003Z7_A140EstCod ;
      private string[] P003Z7_A602EstDsc ;
      private string[] P003Z8_A139PaiCod ;
      private string[] P003Z8_A140EstCod ;
      private string[] P003Z8_A603ProvDsc ;
      private string[] P003Z8_A141ProvCod ;
      private string[] P003Z9_A142DisCod ;
      private string[] P003Z9_A141ProvCod ;
      private string[] P003Z9_A140EstCod ;
      private string[] P003Z9_A139PaiCod ;
      private string[] P003Z9_A603ProvDsc ;
      private string[] P003Z10_A140EstCod ;
      private string[] P003Z10_A139PaiCod ;
      private string[] P003Z10_A141ProvCod ;
      private string[] P003Z10_A603ProvDsc ;
      private string aP10_SelectedValue ;
      private string aP11_SelectedText ;
      private string aP12_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class distritosloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Z2( IGxContext context ,
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

      protected Object[] conditional_P003Z5( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string AV27Cond_PaiCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstDsc], [EstCod] FROM [CESTADOS]";
         AddWhere(sWhereString, "([PaiCod] = @AV27Cond_PaiCod)");
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

      protected Object[] conditional_P003Z8( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A603ProvDsc ,
                                             string A139PaiCod ,
                                             string AV27Cond_PaiCod ,
                                             string A140EstCod ,
                                             string AV28Cond_EstCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[3];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [PaiCod], [EstCod], [ProvDsc], [ProvCod] FROM [CPROVINCIA]";
         AddWhere(sWhereString, "([PaiCod] = @AV27Cond_PaiCod)");
         AddWhere(sWhereString, "([EstCod] = @AV28Cond_EstCod)");
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

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P003Z5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] );
               case 6 :
                     return conditional_P003Z8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003Z3;
          prmP003Z3 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV25ProvCod",GXType.NChar,4,0) ,
          new ParDef("@AV26DisCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z4;
          prmP003Z4 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z6;
          prmP003Z6 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV25ProvCod",GXType.NChar,4,0) ,
          new ParDef("@AV26DisCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z7;
          prmP003Z7 = new Object[] {
          new ParDef("@AV27Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z9;
          prmP003Z9 = new Object[] {
          new ParDef("@AV23PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV25ProvCod",GXType.NChar,4,0) ,
          new ParDef("@AV26DisCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z10;
          prmP003Z10 = new Object[] {
          new ParDef("@AV27Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV28Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV25ProvCod",GXType.NChar,4,0)
          };
          Object[] prmP003Z2;
          prmP003Z2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP003Z5;
          prmP003Z5 = new Object[] {
          new ParDef("@AV27Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP003Z8;
          prmP003Z8 = new Object[] {
          new ParDef("@AV27Cond_PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV28Cond_EstCod",GXType.NChar,4,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003Z3", "SELECT T1.[DisCod], T1.[ProvCod], T1.[EstCod], T1.[PaiCod], T2.[PaiDsc] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod]) WHERE T1.[PaiCod] = @AV23PaiCod and T1.[EstCod] = @AV24EstCod and T1.[ProvCod] = @AV25ProvCod and T1.[DisCod] = @AV26DisCod ORDER BY T1.[PaiCod], T1.[EstCod], T1.[ProvCod], T1.[DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003Z4", "SELECT TOP 1 [PaiCod], [PaiDsc] FROM [CPAISES] WHERE [PaiCod] = @AV23PaiCod ORDER BY [PaiCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003Z5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003Z6", "SELECT T1.[DisCod], T1.[ProvCod], T1.[EstCod], T1.[PaiCod], T2.[EstDsc] FROM ([CDISTRITOS] T1 INNER JOIN [CESTADOS] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod]) WHERE T1.[PaiCod] = @AV23PaiCod and T1.[EstCod] = @AV24EstCod and T1.[ProvCod] = @AV25ProvCod and T1.[DisCod] = @AV26DisCod ORDER BY T1.[PaiCod], T1.[EstCod], T1.[ProvCod], T1.[DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003Z7", "SELECT TOP 1 [PaiCod], [EstCod], [EstDsc] FROM [CESTADOS] WHERE [PaiCod] = @AV27Cond_PaiCod and [EstCod] = @AV24EstCod ORDER BY [PaiCod], [EstCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003Z8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003Z9", "SELECT T1.[DisCod], T1.[ProvCod], T1.[EstCod], T1.[PaiCod], T2.[ProvDsc] FROM ([CDISTRITOS] T1 INNER JOIN [CPROVINCIA] T2 ON T2.[PaiCod] = T1.[PaiCod] AND T2.[EstCod] = T1.[EstCod] AND T2.[ProvCod] = T1.[ProvCod]) WHERE T1.[PaiCod] = @AV23PaiCod and T1.[EstCod] = @AV24EstCod and T1.[ProvCod] = @AV25ProvCod and T1.[DisCod] = @AV26DisCod ORDER BY T1.[PaiCod], T1.[EstCod], T1.[ProvCod], T1.[DisCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P003Z10", "SELECT TOP 1 [EstCod], [PaiCod], [ProvCod], [ProvDsc] FROM [CPROVINCIA] WHERE [PaiCod] = @AV27Cond_PaiCod and [EstCod] = @AV28Cond_EstCod and [ProvCod] = @AV25ProvCod ORDER BY [PaiCod], [EstCod], [ProvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z10,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
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
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
