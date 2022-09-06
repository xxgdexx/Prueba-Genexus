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
   public class reloj_codigoidloaddvcombo : GXProcedure
   {
      public reloj_codigoidloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoidloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           string aP3_CodigoId ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV15TrnMode = aP1_TrnMode;
         this.AV22IsDynamicCall = aP2_IsDynamicCall;
         this.AV17CodigoId = aP3_CodigoId;
         this.AV19SearchTxt = aP4_SearchTxt;
         this.AV12SelectedValue = "" ;
         this.AV21SelectedText = "" ;
         this.AV20Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV12SelectedValue;
         aP6_SelectedText=this.AV21SelectedText;
         aP7_Combo_DataJson=this.AV20Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                string aP3_CodigoId ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_CodigoId, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV20Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 string aP3_CodigoId ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         reloj_codigoidloaddvcombo objreloj_codigoidloaddvcombo;
         objreloj_codigoidloaddvcombo = new reloj_codigoidloaddvcombo();
         objreloj_codigoidloaddvcombo.AV13ComboName = aP0_ComboName;
         objreloj_codigoidloaddvcombo.AV15TrnMode = aP1_TrnMode;
         objreloj_codigoidloaddvcombo.AV22IsDynamicCall = aP2_IsDynamicCall;
         objreloj_codigoidloaddvcombo.AV17CodigoId = aP3_CodigoId;
         objreloj_codigoidloaddvcombo.AV19SearchTxt = aP4_SearchTxt;
         objreloj_codigoidloaddvcombo.AV12SelectedValue = "" ;
         objreloj_codigoidloaddvcombo.AV21SelectedText = "" ;
         objreloj_codigoidloaddvcombo.AV20Combo_DataJson = "" ;
         objreloj_codigoidloaddvcombo.context.SetSubmitInitialConfig(context);
         objreloj_codigoidloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_codigoidloaddvcombo);
         aP5_SelectedValue=this.AV12SelectedValue;
         aP6_SelectedText=this.AV21SelectedText;
         aP7_Combo_DataJson=this.AV20Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_codigoidloaddvcombo)stateInfo).executePrivate();
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
         AV18MaxItems = 100;
         if ( StringUtil.StrCmp(AV13ComboName, "CodigoId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_CODIGOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13ComboName, "Reloj_ID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RELOJ_ID' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13ComboName, "HorarioID") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_HORARIOID' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(AV13ComboName, "RHTrabajadorCodigo") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_RHTRABAJADORCODIGO' */
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
         /* 'LOADCOMBOITEMS_CODIGOID' Routine */
         returnInSub = false;
         /* Using cursor P00H52 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2578CodEmp_Lee = P00H52_A2578CodEmp_Lee[0];
            A2579NomEmp_Lee = P00H52_A2579NomEmp_Lee[0];
            A2577Id_Lee = P00H52_A2577Id_Lee[0];
            AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV11Combo_DataItem.gxTpr_Id = A2578CodEmp_Lee;
            AV11Combo_DataItem.gxTpr_Title = A2579NomEmp_Lee;
            AV10Combo_Data.Add(AV11Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV20Combo_DataJson = AV10Combo_Data.ToJSonString(false);
         if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
         {
            /* Using cursor P00H53 */
            pr_default.execute(1, new Object[] {AV17CodigoId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A2431CodigoId = P00H53_A2431CodigoId[0];
               AV12SelectedValue = A2431CodigoId;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17CodigoId)) )
            {
               AV12SelectedValue = AV17CodigoId;
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMBOITEMS_RELOJ_ID' Routine */
         returnInSub = false;
         if ( AV22IsDynamicCall )
         {
            pr_default.dynParam(2, new Object[]{ new Object[]{
                                                 AV19SearchTxt ,
                                                 A2425Reloj_Nom } ,
                                                 new int[]{
                                                 }
            });
            lV19SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV19SearchTxt), "%", "");
            /* Using cursor P00H54 */
            pr_default.execute(2, new Object[] {lV19SearchTxt});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A2425Reloj_Nom = P00H54_A2425Reloj_Nom[0];
               A2430RelojID = P00H54_A2430RelojID[0];
               AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A2430RelojID), 4, 0));
               AV11Combo_DataItem.gxTpr_Title = A2425Reloj_Nom;
               AV10Combo_Data.Add(AV11Combo_DataItem, 0);
               if ( AV10Combo_Data.Count > AV18MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            AV20Combo_DataJson = AV10Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV15TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00H55 */
                  pr_default.execute(3, new Object[] {AV17CodigoId});
                  while ( (pr_default.getStatus(3) != 101) )
                  {
                     A2431CodigoId = P00H55_A2431CodigoId[0];
                     A2498Reloj_ID = P00H55_A2498Reloj_ID[0];
                     AV12SelectedValue = ((0==A2498Reloj_ID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2498Reloj_ID), 4, 0)));
                     AV24RelojID = A2498Reloj_ID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(3);
               }
               else
               {
                  AV24RelojID = (short)(NumberUtil.Val( AV19SearchTxt, "."));
               }
               /* Using cursor P00H56 */
               pr_default.execute(4, new Object[] {AV24RelojID});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A2430RelojID = P00H56_A2430RelojID[0];
                  A2425Reloj_Nom = P00H56_A2425Reloj_Nom[0];
                  AV21SelectedText = A2425Reloj_Nom;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
            }
         }
      }

      protected void S131( )
      {
         /* 'LOADCOMBOITEMS_HORARIOID' Routine */
         returnInSub = false;
         if ( AV22IsDynamicCall )
         {
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV19SearchTxt ,
                                                 A2433Horario_Dsc } ,
                                                 new int[]{
                                                 }
            });
            lV19SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV19SearchTxt), "%", "");
            /* Using cursor P00H57 */
            pr_default.execute(5, new Object[] {lV19SearchTxt});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A2433Horario_Dsc = P00H57_A2433Horario_Dsc[0];
               A2432Horario_ID = P00H57_A2432Horario_ID[0];
               AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV11Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A2432Horario_ID), 4, 0));
               AV11Combo_DataItem.gxTpr_Title = A2433Horario_Dsc;
               AV10Combo_Data.Add(AV11Combo_DataItem, 0);
               if ( AV10Combo_Data.Count > AV18MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            AV20Combo_DataJson = AV10Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV15TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00H58 */
                  pr_default.execute(6, new Object[] {AV17CodigoId});
                  while ( (pr_default.getStatus(6) != 101) )
                  {
                     A2431CodigoId = P00H58_A2431CodigoId[0];
                     A2591HorarioID = P00H58_A2591HorarioID[0];
                     AV12SelectedValue = ((0==A2591HorarioID) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A2591HorarioID), 4, 0)));
                     AV25Horario_ID = A2591HorarioID;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(6);
               }
               else
               {
                  AV25Horario_ID = (short)(NumberUtil.Val( AV19SearchTxt, "."));
               }
               /* Using cursor P00H59 */
               pr_default.execute(7, new Object[] {AV25Horario_ID});
               while ( (pr_default.getStatus(7) != 101) )
               {
                  A2432Horario_ID = P00H59_A2432Horario_ID[0];
                  A2433Horario_Dsc = P00H59_A2433Horario_Dsc[0];
                  AV21SelectedText = A2433Horario_Dsc;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(7);
            }
         }
      }

      protected void S141( )
      {
         /* 'LOADCOMBOITEMS_RHTRABAJADORCODIGO' Routine */
         returnInSub = false;
         if ( AV22IsDynamicCall )
         {
            pr_default.dynParam(8, new Object[]{ new Object[]{
                                                 AV19SearchTxt ,
                                                 A2525TrabApePat } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV19SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV19SearchTxt), "%", "");
            /* Using cursor P00H510 */
            pr_default.execute(8, new Object[] {lV19SearchTxt});
            while ( (pr_default.getStatus(8) != 101) )
            {
               A2525TrabApePat = P00H510_A2525TrabApePat[0];
               n2525TrabApePat = P00H510_n2525TrabApePat[0];
               A2417TrabCodigo = P00H510_A2417TrabCodigo[0];
               AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV11Combo_DataItem.gxTpr_Id = A2417TrabCodigo;
               AV11Combo_DataItem.gxTpr_Title = A2525TrabApePat;
               AV10Combo_Data.Add(AV11Combo_DataItem, 0);
               if ( AV10Combo_Data.Count > AV18MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(8);
            }
            pr_default.close(8);
            AV20Combo_DataJson = AV10Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV15TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV15TrnMode, "GET") != 0 )
               {
                  /* Using cursor P00H511 */
                  pr_default.execute(9, new Object[] {AV17CodigoId});
                  while ( (pr_default.getStatus(9) != 101) )
                  {
                     A2431CodigoId = P00H511_A2431CodigoId[0];
                     A2589RHTrabajadorCodigo = P00H511_A2589RHTrabajadorCodigo[0];
                     AV12SelectedValue = A2589RHTrabajadorCodigo;
                     AV26TrabCodigo = A2589RHTrabajadorCodigo;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(9);
               }
               else
               {
                  AV26TrabCodigo = AV19SearchTxt;
               }
               /* Using cursor P00H512 */
               pr_default.execute(10, new Object[] {AV26TrabCodigo});
               while ( (pr_default.getStatus(10) != 101) )
               {
                  A2417TrabCodigo = P00H512_A2417TrabCodigo[0];
                  A2525TrabApePat = P00H512_A2525TrabApePat[0];
                  n2525TrabApePat = P00H512_n2525TrabApePat[0];
                  AV21SelectedText = A2525TrabApePat;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(10);
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
         AV12SelectedValue = "";
         AV21SelectedText = "";
         AV20Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         P00H52_A2578CodEmp_Lee = new string[] {""} ;
         P00H52_A2579NomEmp_Lee = new string[] {""} ;
         P00H52_A2577Id_Lee = new long[1] ;
         A2578CodEmp_Lee = "";
         A2579NomEmp_Lee = "";
         AV11Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV10Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P00H53_A2431CodigoId = new string[] {""} ;
         A2431CodigoId = "";
         lV19SearchTxt = "";
         A2425Reloj_Nom = "";
         P00H54_A2425Reloj_Nom = new string[] {""} ;
         P00H54_A2430RelojID = new short[1] ;
         P00H55_A2431CodigoId = new string[] {""} ;
         P00H55_A2498Reloj_ID = new short[1] ;
         P00H56_A2430RelojID = new short[1] ;
         P00H56_A2425Reloj_Nom = new string[] {""} ;
         A2433Horario_Dsc = "";
         P00H57_A2433Horario_Dsc = new string[] {""} ;
         P00H57_A2432Horario_ID = new short[1] ;
         P00H58_A2431CodigoId = new string[] {""} ;
         P00H58_A2591HorarioID = new short[1] ;
         P00H59_A2432Horario_ID = new short[1] ;
         P00H59_A2433Horario_Dsc = new string[] {""} ;
         A2525TrabApePat = "";
         P00H510_A2525TrabApePat = new string[] {""} ;
         P00H510_n2525TrabApePat = new bool[] {false} ;
         P00H510_A2417TrabCodigo = new string[] {""} ;
         A2417TrabCodigo = "";
         P00H511_A2431CodigoId = new string[] {""} ;
         P00H511_A2589RHTrabajadorCodigo = new string[] {""} ;
         A2589RHTrabajadorCodigo = "";
         AV26TrabCodigo = "";
         P00H512_A2417TrabCodigo = new string[] {""} ;
         P00H512_A2525TrabApePat = new string[] {""} ;
         P00H512_n2525TrabApePat = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoidloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00H52_A2578CodEmp_Lee, P00H52_A2579NomEmp_Lee, P00H52_A2577Id_Lee
               }
               , new Object[] {
               P00H53_A2431CodigoId
               }
               , new Object[] {
               P00H54_A2425Reloj_Nom, P00H54_A2430RelojID
               }
               , new Object[] {
               P00H55_A2431CodigoId, P00H55_A2498Reloj_ID
               }
               , new Object[] {
               P00H56_A2430RelojID, P00H56_A2425Reloj_Nom
               }
               , new Object[] {
               P00H57_A2433Horario_Dsc, P00H57_A2432Horario_ID
               }
               , new Object[] {
               P00H58_A2431CodigoId, P00H58_A2591HorarioID
               }
               , new Object[] {
               P00H59_A2432Horario_ID, P00H59_A2433Horario_Dsc
               }
               , new Object[] {
               P00H510_A2525TrabApePat, P00H510_n2525TrabApePat, P00H510_A2417TrabCodigo
               }
               , new Object[] {
               P00H511_A2431CodigoId, P00H511_A2589RHTrabajadorCodigo
               }
               , new Object[] {
               P00H512_A2417TrabCodigo, P00H512_A2525TrabApePat, P00H512_n2525TrabApePat
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2430RelojID ;
      private short A2498Reloj_ID ;
      private short AV24RelojID ;
      private short A2432Horario_ID ;
      private short A2591HorarioID ;
      private short AV25Horario_ID ;
      private int AV18MaxItems ;
      private long A2577Id_Lee ;
      private string AV15TrnMode ;
      private string scmdbuf ;
      private bool AV22IsDynamicCall ;
      private bool returnInSub ;
      private bool n2525TrabApePat ;
      private string AV20Combo_DataJson ;
      private string AV13ComboName ;
      private string AV17CodigoId ;
      private string AV19SearchTxt ;
      private string AV12SelectedValue ;
      private string AV21SelectedText ;
      private string A2578CodEmp_Lee ;
      private string A2579NomEmp_Lee ;
      private string A2431CodigoId ;
      private string lV19SearchTxt ;
      private string A2425Reloj_Nom ;
      private string A2433Horario_Dsc ;
      private string A2525TrabApePat ;
      private string A2417TrabCodigo ;
      private string A2589RHTrabajadorCodigo ;
      private string AV26TrabCodigo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00H52_A2578CodEmp_Lee ;
      private string[] P00H52_A2579NomEmp_Lee ;
      private long[] P00H52_A2577Id_Lee ;
      private string[] P00H53_A2431CodigoId ;
      private string[] P00H54_A2425Reloj_Nom ;
      private short[] P00H54_A2430RelojID ;
      private string[] P00H55_A2431CodigoId ;
      private short[] P00H55_A2498Reloj_ID ;
      private short[] P00H56_A2430RelojID ;
      private string[] P00H56_A2425Reloj_Nom ;
      private string[] P00H57_A2433Horario_Dsc ;
      private short[] P00H57_A2432Horario_ID ;
      private string[] P00H58_A2431CodigoId ;
      private short[] P00H58_A2591HorarioID ;
      private short[] P00H59_A2432Horario_ID ;
      private string[] P00H59_A2433Horario_Dsc ;
      private string[] P00H510_A2525TrabApePat ;
      private bool[] P00H510_n2525TrabApePat ;
      private string[] P00H510_A2417TrabCodigo ;
      private string[] P00H511_A2431CodigoId ;
      private string[] P00H511_A2589RHTrabajadorCodigo ;
      private string[] P00H512_A2417TrabCodigo ;
      private string[] P00H512_A2525TrabApePat ;
      private bool[] P00H512_n2525TrabApePat ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV10Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV11Combo_DataItem ;
   }

   public class reloj_codigoidloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00H54( IGxContext context ,
                                             string AV19SearchTxt ,
                                             string A2425Reloj_Nom )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [Reloj_Nom], [RelojID] FROM [Reloj]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxt)) )
         {
            AddWhere(sWhereString, "([Reloj_Nom] like '%' + @lV19SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Reloj_Nom]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00H57( IGxContext context ,
                                             string AV19SearchTxt ,
                                             string A2433Horario_Dsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[1];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [Horario_Dsc], [Horario_ID] FROM [Reloj_Horario]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxt)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like '%' + @lV19SearchTxt)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Horario_Dsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00H510( IGxContext context ,
                                              string AV19SearchTxt ,
                                              string A2525TrabApePat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[1];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [TrabApePat], [TrabCodigo] FROM [Trab_Trabajador]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19SearchTxt)) )
         {
            AddWhere(sWhereString, "([TrabApePat] like '%' + @lV19SearchTxt)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TrabApePat]";
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
               case 2 :
                     return conditional_P00H54(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 5 :
                     return conditional_P00H57(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
               case 8 :
                     return conditional_P00H510(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP00H52;
          prmP00H52 = new Object[] {
          };
          Object[] prmP00H53;
          prmP00H53 = new Object[] {
          new ParDef("@AV17CodigoId",GXType.NVarChar,25,0)
          };
          Object[] prmP00H55;
          prmP00H55 = new Object[] {
          new ParDef("@AV17CodigoId",GXType.NVarChar,25,0)
          };
          Object[] prmP00H56;
          prmP00H56 = new Object[] {
          new ParDef("@AV24RelojID",GXType.Int16,4,0)
          };
          Object[] prmP00H58;
          prmP00H58 = new Object[] {
          new ParDef("@AV17CodigoId",GXType.NVarChar,25,0)
          };
          Object[] prmP00H59;
          prmP00H59 = new Object[] {
          new ParDef("@AV25Horario_ID",GXType.Int16,4,0)
          };
          Object[] prmP00H511;
          prmP00H511 = new Object[] {
          new ParDef("@AV17CodigoId",GXType.NVarChar,25,0)
          };
          Object[] prmP00H512;
          prmP00H512 = new Object[] {
          new ParDef("@AV26TrabCodigo",GXType.NVarChar,20,0)
          };
          Object[] prmP00H54;
          prmP00H54 = new Object[] {
          new ParDef("@lV19SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00H57;
          prmP00H57 = new Object[] {
          new ParDef("@lV19SearchTxt",GXType.NVarChar,40,0)
          };
          Object[] prmP00H510;
          prmP00H510 = new Object[] {
          new ParDef("@lV19SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00H52", "SELECT [CodEmp_Lee], [NomEmp_Lee], [Id_Lee] FROM [Reloj_Lecturas] ORDER BY [NomEmp_Lee] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H52,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H53", "SELECT [CodigoId] FROM [Reloj_CodigoID] WHERE [CodigoId] = @AV17CodigoId ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H53,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H54", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H54,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H55", "SELECT [CodigoId], [Reloj_ID] FROM [Reloj_CodigoID] WHERE [CodigoId] = @AV17CodigoId ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H55,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H56", "SELECT TOP 1 [RelojID], [Reloj_Nom] FROM [Reloj] WHERE [RelojID] = @AV24RelojID ORDER BY [RelojID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H56,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H57", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H57,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H58", "SELECT [CodigoId], [HorarioID] FROM [Reloj_CodigoID] WHERE [CodigoId] = @AV17CodigoId ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H58,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H59", "SELECT TOP 1 [Horario_ID], [Horario_Dsc] FROM [Reloj_Horario] WHERE [Horario_ID] = @AV25Horario_ID ORDER BY [Horario_ID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H59,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H510", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H510,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H511", "SELECT [CodigoId], [RHTrabajadorCodigo] FROM [Reloj_CodigoID] WHERE [CodigoId] = @AV17CodigoId ORDER BY [CodigoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H511,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00H512", "SELECT TOP 1 [TrabCodigo], [TrabApePat] FROM [Trab_Trabajador] WHERE [TrabCodigo] = @AV26TrabCodigo ORDER BY [TrabCodigo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H512,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
