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
   public class usuariosopcionesloaddvcombo : GXProcedure
   {
      public usuariosopcionesloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuariosopcionesloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_UsuCod ,
                           int aP4_Cond_UsuMosBanCod ,
                           string aP5_SearchTxt ,
                           out string aP6_SelectedValue ,
                           out string aP7_SelectedText ,
                           out string aP8_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24UsuCod = aP3_UsuCod;
         this.AV28Cond_UsuMosBanCod = aP4_Cond_UsuMosBanCod;
         this.AV11SearchTxt = aP5_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                string aP3_UsuCod ,
                                int aP4_Cond_UsuMosBanCod ,
                                string aP5_SearchTxt ,
                                out string aP6_SelectedValue ,
                                out string aP7_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_UsuCod, aP4_Cond_UsuMosBanCod, aP5_SearchTxt, out aP6_SelectedValue, out aP7_SelectedText, out aP8_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_UsuCod ,
                                 int aP4_Cond_UsuMosBanCod ,
                                 string aP5_SearchTxt ,
                                 out string aP6_SelectedValue ,
                                 out string aP7_SelectedText ,
                                 out string aP8_Combo_DataJson )
      {
         usuariosopcionesloaddvcombo objusuariosopcionesloaddvcombo;
         objusuariosopcionesloaddvcombo = new usuariosopcionesloaddvcombo();
         objusuariosopcionesloaddvcombo.AV16ComboName = aP0_ComboName;
         objusuariosopcionesloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objusuariosopcionesloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objusuariosopcionesloaddvcombo.AV24UsuCod = aP3_UsuCod;
         objusuariosopcionesloaddvcombo.AV28Cond_UsuMosBanCod = aP4_Cond_UsuMosBanCod;
         objusuariosopcionesloaddvcombo.AV11SearchTxt = aP5_SearchTxt;
         objusuariosopcionesloaddvcombo.AV15SelectedValue = "" ;
         objusuariosopcionesloaddvcombo.AV20SelectedText = "" ;
         objusuariosopcionesloaddvcombo.AV12Combo_DataJson = "" ;
         objusuariosopcionesloaddvcombo.context.SetSubmitInitialConfig(context);
         objusuariosopcionesloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuariosopcionesloaddvcombo);
         aP6_SelectedValue=this.AV15SelectedValue;
         aP7_SelectedText=this.AV20SelectedText;
         aP8_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuariosopcionesloaddvcombo)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(AV16ComboName, "UsuMosBanCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUMOSBANCOD' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "UsuMosCBCod") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUMOSCBCOD' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "UsuMosConcepto") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUMOSCONCEPTO' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV16ComboName, "UsuPedMon") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUPEDMON' */
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
         /* 'LOADCOMBOITEMS_USUMOSBANCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A482BanDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P001K2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A482BanDsc = P001K2_A482BanDsc[0];
               A372BanCod = P001K2_A372BanCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A482BanDsc;
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
                  /* Using cursor P001K3 */
                  pr_default.execute(1, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A348UsuCod = P001K3_A348UsuCod[0];
                     A2016UsuMosBanCod = P001K3_A2016UsuMosBanCod[0];
                     n2016UsuMosBanCod = P001K3_n2016UsuMosBanCod[0];
                     AV15SelectedValue = ((0==A2016UsuMosBanCod) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2016UsuMosBanCod), 6, 0)));
                     AV25BanCod = A2016UsuMosBanCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV25BanCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P001K4 */
               pr_default.execute(2, new Object[] {AV25BanCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A372BanCod = P001K4_A372BanCod[0];
                  A482BanDsc = P001K4_A482BanDsc[0];
                  AV20SelectedText = A482BanDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_USUMOSCBCOD' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(3, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A377CBCod ,
                                                 AV28Cond_UsuMosBanCod ,
                                                 A372BanCod } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P001K5 */
            pr_default.execute(3, new Object[] {AV28Cond_UsuMosBanCod, lV11SearchTxt});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A377CBCod = P001K5_A377CBCod[0];
               A372BanCod = P001K5_A372BanCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = A377CBCod;
               AV14Combo_DataItem.gxTpr_Title = A377CBCod;
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
                  /* Using cursor P001K6 */
                  pr_default.execute(4, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(4) != 101) )
                  {
                     A348UsuCod = P001K6_A348UsuCod[0];
                     A2017UsuMosCBCod = P001K6_A2017UsuMosCBCod[0];
                     n2017UsuMosCBCod = P001K6_n2017UsuMosCBCod[0];
                     AV15SelectedValue = A2017UsuMosCBCod;
                     AV26CBCod = A2017UsuMosCBCod;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(4);
               }
               else
               {
                  AV26CBCod = AV11SearchTxt;
               }
               /* Using cursor P001K7 */
               pr_default.execute(5, new Object[] {AV26CBCod});
               while ( (pr_default.getStatus(5) != 101) )
               {
                  A377CBCod = P001K7_A377CBCod[0];
                  A372BanCod = P001K7_A372BanCod[0];
                  AV20SelectedText = A377CBCod;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(5);
               }
               pr_default.close(5);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_USUMOSCONCEPTO' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(6, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A745ConBDsc } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P001K8 */
            pr_default.execute(6, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(6) != 101) )
            {
               A745ConBDsc = P001K8_A745ConBDsc[0];
               A355ConBCod = P001K8_A355ConBCod[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A355ConBCod), 6, 0));
               AV14Combo_DataItem.gxTpr_Title = A745ConBDsc;
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
                  /* Using cursor P001K9 */
                  pr_default.execute(7, new Object[] {AV24UsuCod});
                  while ( (pr_default.getStatus(7) != 101) )
                  {
                     A348UsuCod = P001K9_A348UsuCod[0];
                     A350UsuMosConcepto = P001K9_A350UsuMosConcepto[0];
                     n350UsuMosConcepto = P001K9_n350UsuMosConcepto[0];
                     AV15SelectedValue = ((0==A350UsuMosConcepto) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A350UsuMosConcepto), 6, 0)));
                     AV23ConBCod = A350UsuMosConcepto;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(7);
               }
               else
               {
                  AV23ConBCod = (int)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P001K10 */
               pr_default.execute(8, new Object[] {AV23ConBCod});
               while ( (pr_default.getStatus(8) != 101) )
               {
                  A355ConBCod = P001K10_A355ConBCod[0];
                  A745ConBDsc = P001K10_A745ConBDsc[0];
                  AV20SelectedText = A745ConBDsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(8);
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_USUPEDMON' Routine */
         returnInSub = false;
         /* Using cursor P001K11 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            A180MonCod = P001K11_A180MonCod[0];
            A1234MonDsc = P001K11_A1234MonDsc[0];
            AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 6, 0));
            AV14Combo_DataItem.gxTpr_Title = A1234MonDsc;
            AV13Combo_Data.Add(AV14Combo_DataItem, 0);
            pr_default.readNext(9);
         }
         pr_default.close(9);
         AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
         {
            /* Using cursor P001K12 */
            pr_default.execute(10, new Object[] {AV24UsuCod});
            while ( (pr_default.getStatus(10) != 101) )
            {
               A348UsuCod = P001K12_A348UsuCod[0];
               A2026UsuPedMon = P001K12_A2026UsuPedMon[0];
               n2026UsuPedMon = P001K12_n2026UsuPedMon[0];
               AV15SelectedValue = ((0==A2026UsuPedMon) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2026UsuPedMon), 6, 0)));
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(10);
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
         A482BanDsc = "";
         P001K2_A482BanDsc = new string[] {""} ;
         P001K2_A372BanCod = new int[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P001K3_A348UsuCod = new string[] {""} ;
         P001K3_A2016UsuMosBanCod = new int[1] ;
         P001K3_n2016UsuMosBanCod = new bool[] {false} ;
         A348UsuCod = "";
         P001K4_A372BanCod = new int[1] ;
         P001K4_A482BanDsc = new string[] {""} ;
         A377CBCod = "";
         P001K5_A377CBCod = new string[] {""} ;
         P001K5_A372BanCod = new int[1] ;
         P001K6_A348UsuCod = new string[] {""} ;
         P001K6_A2017UsuMosCBCod = new string[] {""} ;
         P001K6_n2017UsuMosCBCod = new bool[] {false} ;
         A2017UsuMosCBCod = "";
         AV26CBCod = "";
         P001K7_A377CBCod = new string[] {""} ;
         P001K7_A372BanCod = new int[1] ;
         A745ConBDsc = "";
         P001K8_A745ConBDsc = new string[] {""} ;
         P001K8_A355ConBCod = new int[1] ;
         P001K9_A348UsuCod = new string[] {""} ;
         P001K9_A350UsuMosConcepto = new int[1] ;
         P001K9_n350UsuMosConcepto = new bool[] {false} ;
         P001K10_A355ConBCod = new int[1] ;
         P001K10_A745ConBDsc = new string[] {""} ;
         P001K11_A180MonCod = new int[1] ;
         P001K11_A1234MonDsc = new string[] {""} ;
         A1234MonDsc = "";
         P001K12_A348UsuCod = new string[] {""} ;
         P001K12_A2026UsuPedMon = new int[1] ;
         P001K12_n2026UsuPedMon = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosopcionesloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P001K2_A482BanDsc, P001K2_A372BanCod
               }
               , new Object[] {
               P001K3_A348UsuCod, P001K3_A2016UsuMosBanCod, P001K3_n2016UsuMosBanCod
               }
               , new Object[] {
               P001K4_A372BanCod, P001K4_A482BanDsc
               }
               , new Object[] {
               P001K5_A377CBCod, P001K5_A372BanCod
               }
               , new Object[] {
               P001K6_A348UsuCod, P001K6_A2017UsuMosCBCod, P001K6_n2017UsuMosCBCod
               }
               , new Object[] {
               P001K7_A377CBCod, P001K7_A372BanCod
               }
               , new Object[] {
               P001K8_A745ConBDsc, P001K8_A355ConBCod
               }
               , new Object[] {
               P001K9_A348UsuCod, P001K9_A350UsuMosConcepto, P001K9_n350UsuMosConcepto
               }
               , new Object[] {
               P001K10_A355ConBCod, P001K10_A745ConBDsc
               }
               , new Object[] {
               P001K11_A180MonCod, P001K11_A1234MonDsc
               }
               , new Object[] {
               P001K12_A348UsuCod, P001K12_A2026UsuPedMon, P001K12_n2026UsuPedMon
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV28Cond_UsuMosBanCod ;
      private int AV10MaxItems ;
      private int A372BanCod ;
      private int A2016UsuMosBanCod ;
      private int AV25BanCod ;
      private int A355ConBCod ;
      private int A350UsuMosConcepto ;
      private int AV23ConBCod ;
      private int A180MonCod ;
      private int A2026UsuPedMon ;
      private string AV18TrnMode ;
      private string AV24UsuCod ;
      private string scmdbuf ;
      private string A482BanDsc ;
      private string A348UsuCod ;
      private string A377CBCod ;
      private string A2017UsuMosCBCod ;
      private string AV26CBCod ;
      private string A745ConBDsc ;
      private string A1234MonDsc ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n2016UsuMosBanCod ;
      private bool n2017UsuMosCBCod ;
      private bool n350UsuMosConcepto ;
      private bool n2026UsuPedMon ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001K2_A482BanDsc ;
      private int[] P001K2_A372BanCod ;
      private string[] P001K3_A348UsuCod ;
      private int[] P001K3_A2016UsuMosBanCod ;
      private bool[] P001K3_n2016UsuMosBanCod ;
      private int[] P001K4_A372BanCod ;
      private string[] P001K4_A482BanDsc ;
      private string[] P001K5_A377CBCod ;
      private int[] P001K5_A372BanCod ;
      private string[] P001K6_A348UsuCod ;
      private string[] P001K6_A2017UsuMosCBCod ;
      private bool[] P001K6_n2017UsuMosCBCod ;
      private string[] P001K7_A377CBCod ;
      private int[] P001K7_A372BanCod ;
      private string[] P001K8_A745ConBDsc ;
      private int[] P001K8_A355ConBCod ;
      private string[] P001K9_A348UsuCod ;
      private int[] P001K9_A350UsuMosConcepto ;
      private bool[] P001K9_n350UsuMosConcepto ;
      private int[] P001K10_A355ConBCod ;
      private string[] P001K10_A745ConBDsc ;
      private int[] P001K11_A180MonCod ;
      private string[] P001K11_A1234MonDsc ;
      private string[] P001K12_A348UsuCod ;
      private int[] P001K12_A2026UsuPedMon ;
      private bool[] P001K12_n2026UsuPedMon ;
      private string aP6_SelectedValue ;
      private string aP7_SelectedText ;
      private string aP8_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class usuariosopcionesloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001K2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A482BanDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [BanDsc], [BanCod] FROM [TSBANCOS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001K5( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A377CBCod ,
                                             int AV28Cond_UsuMosBanCod ,
                                             int A372BanCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CBCod], [BanCod] FROM [TSCUENTABANCO]";
         AddWhere(sWhereString, "([BanCod] = @AV28Cond_UsuMosBanCod)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([CBCod] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanCod], [CBCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P001K8( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A745ConBDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ConBDsc], [ConBCod] FROM [TSCONCEPTOBANCOS]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([ConBDsc] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConBDsc]";
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
                     return conditional_P001K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 3 :
                     return conditional_P001K5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] );
               case 6 :
                     return conditional_P001K8(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001K3;
          prmP001K3 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP001K4;
          prmP001K4 = new Object[] {
          new ParDef("@AV25BanCod",GXType.Int32,6,0)
          };
          Object[] prmP001K6;
          prmP001K6 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP001K7;
          prmP001K7 = new Object[] {
          new ParDef("@AV26CBCod",GXType.NChar,20,0)
          };
          Object[] prmP001K9;
          prmP001K9 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP001K10;
          prmP001K10 = new Object[] {
          new ParDef("@AV23ConBCod",GXType.Int32,6,0)
          };
          Object[] prmP001K11;
          prmP001K11 = new Object[] {
          };
          Object[] prmP001K12;
          prmP001K12 = new Object[] {
          new ParDef("@AV24UsuCod",GXType.NChar,10,0)
          };
          Object[] prmP001K2;
          prmP001K2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP001K5;
          prmP001K5 = new Object[] {
          new ParDef("@AV28Cond_UsuMosBanCod",GXType.Int32,6,0) ,
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP001K8;
          prmP001K8 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001K3", "SELECT [UsuCod], [UsuMosBanCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K4", "SELECT TOP 1 [BanCod], [BanDsc] FROM [TSBANCOS] WHERE [BanCod] = @AV25BanCod ORDER BY [BanCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K5,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001K6", "SELECT [UsuCod], [UsuMosCBCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K6,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K7", "SELECT TOP 1 [CBCod], [BanCod] FROM [TSCUENTABANCO] WHERE [CBCod] = @AV26CBCod ORDER BY [BanCod], [CBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K8,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001K9", "SELECT [UsuCod], [UsuMosConcepto] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K9,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K10", "SELECT TOP 1 [ConBCod], [ConBDsc] FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @AV23ConBCod ORDER BY [ConBCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K10,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001K11", "SELECT [MonCod], [MonDsc] FROM [CMONEDAS] WHERE [MonCod] = 1 or [MonCod] = 2 ORDER BY [MonDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K11,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001K12", "SELECT [UsuCod], [UsuPedMon] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV24UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001K12,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
