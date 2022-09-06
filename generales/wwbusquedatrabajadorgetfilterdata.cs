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
   public class wwbusquedatrabajadorgetfilterdata : GXProcedure
   {
      public wwbusquedatrabajadorgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwbusquedatrabajadorgetfilterdata( IGxContext context )
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
         wwbusquedatrabajadorgetfilterdata objwwbusquedatrabajadorgetfilterdata;
         objwwbusquedatrabajadorgetfilterdata = new wwbusquedatrabajadorgetfilterdata();
         objwwbusquedatrabajadorgetfilterdata.AV24DDOName = aP0_DDOName;
         objwwbusquedatrabajadorgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objwwbusquedatrabajadorgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objwwbusquedatrabajadorgetfilterdata.AV28OptionsJson = "" ;
         objwwbusquedatrabajadorgetfilterdata.AV31OptionsDescJson = "" ;
         objwwbusquedatrabajadorgetfilterdata.AV33OptionIndexesJson = "" ;
         objwwbusquedatrabajadorgetfilterdata.context.SetSubmitInitialConfig(context);
         objwwbusquedatrabajadorgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwbusquedatrabajadorgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwbusquedatrabajadorgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_TRABCODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADTRABCODIGOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_TRABCODINTERNO") == 0 )
         {
            /* Execute user subroutine: 'LOADTRABCODINTERNOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_TRABNOMBRES") == 0 )
         {
            /* Execute user subroutine: 'LOADTRABNOMBRESOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV35Session.Get("Generales.WWBusquedaTrabajadorGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Generales.WWBusquedaTrabajadorGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Generales.WWBusquedaTrabajadorGridState"), null, "", "");
         }
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV60FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABCODIGO") == 0 )
            {
               AV71TFTrabCodigo = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABCODIGO_SEL") == 0 )
            {
               AV72TFTrabCodigo_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABCODINTERNO") == 0 )
            {
               AV73TFTrabCodInterno = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABCODINTERNO_SEL") == 0 )
            {
               AV74TFTrabCodInterno_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABNOMBRES") == 0 )
            {
               AV75TFTrabNombres = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTRABNOMBRES_SEL") == 0 )
            {
               AV76TFTrabNombres_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV79GXV1 = (int)(AV79GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADTRABCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV71TFTrabCodigo = AV22SearchTxt;
         AV72TFTrabCodigo_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV72TFTrabCodigo_Sel ,
                                              AV71TFTrabCodigo ,
                                              AV74TFTrabCodInterno_Sel ,
                                              AV73TFTrabCodInterno ,
                                              AV76TFTrabNombres_Sel ,
                                              AV75TFTrabNombres ,
                                              A2417TrabCodigo ,
                                              A2528TrabCodInterno ,
                                              A2527TrabNombres ,
                                              A2524TrabEstado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV71TFTrabCodigo = StringUtil.Concat( StringUtil.RTrim( AV71TFTrabCodigo), "%", "");
         lV73TFTrabCodInterno = StringUtil.Concat( StringUtil.RTrim( AV73TFTrabCodInterno), "%", "");
         lV75TFTrabNombres = StringUtil.Concat( StringUtil.RTrim( AV75TFTrabNombres), "%", "");
         /* Using cursor P00GJ2 */
         pr_default.execute(0, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV71TFTrabCodigo, AV72TFTrabCodigo_Sel, lV73TFTrabCodInterno, AV74TFTrabCodInterno_Sel, lV75TFTrabNombres, AV76TFTrabNombres_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKGJ2 = false;
            A2417TrabCodigo = P00GJ2_A2417TrabCodigo[0];
            A2524TrabEstado = P00GJ2_A2524TrabEstado[0];
            n2524TrabEstado = P00GJ2_n2524TrabEstado[0];
            A2527TrabNombres = P00GJ2_A2527TrabNombres[0];
            n2527TrabNombres = P00GJ2_n2527TrabNombres[0];
            A2528TrabCodInterno = P00GJ2_A2528TrabCodInterno[0];
            n2528TrabCodInterno = P00GJ2_n2528TrabCodInterno[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00GJ2_A2417TrabCodigo[0], A2417TrabCodigo) == 0 ) )
            {
               BRKGJ2 = false;
               AV34count = (long)(AV34count+1);
               BRKGJ2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2417TrabCodigo)) )
            {
               AV26Option = A2417TrabCodigo;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGJ2 )
            {
               BRKGJ2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTRABCODINTERNOOPTIONS' Routine */
         returnInSub = false;
         AV73TFTrabCodInterno = AV22SearchTxt;
         AV74TFTrabCodInterno_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV72TFTrabCodigo_Sel ,
                                              AV71TFTrabCodigo ,
                                              AV74TFTrabCodInterno_Sel ,
                                              AV73TFTrabCodInterno ,
                                              AV76TFTrabNombres_Sel ,
                                              AV75TFTrabNombres ,
                                              A2417TrabCodigo ,
                                              A2528TrabCodInterno ,
                                              A2527TrabNombres ,
                                              A2524TrabEstado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV71TFTrabCodigo = StringUtil.Concat( StringUtil.RTrim( AV71TFTrabCodigo), "%", "");
         lV73TFTrabCodInterno = StringUtil.Concat( StringUtil.RTrim( AV73TFTrabCodInterno), "%", "");
         lV75TFTrabNombres = StringUtil.Concat( StringUtil.RTrim( AV75TFTrabNombres), "%", "");
         /* Using cursor P00GJ3 */
         pr_default.execute(1, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV71TFTrabCodigo, AV72TFTrabCodigo_Sel, lV73TFTrabCodInterno, AV74TFTrabCodInterno_Sel, lV75TFTrabNombres, AV76TFTrabNombres_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKGJ4 = false;
            A2524TrabEstado = P00GJ3_A2524TrabEstado[0];
            n2524TrabEstado = P00GJ3_n2524TrabEstado[0];
            A2528TrabCodInterno = P00GJ3_A2528TrabCodInterno[0];
            n2528TrabCodInterno = P00GJ3_n2528TrabCodInterno[0];
            A2527TrabNombres = P00GJ3_A2527TrabNombres[0];
            n2527TrabNombres = P00GJ3_n2527TrabNombres[0];
            A2417TrabCodigo = P00GJ3_A2417TrabCodigo[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00GJ3_A2528TrabCodInterno[0], A2528TrabCodInterno) == 0 ) )
            {
               BRKGJ4 = false;
               A2417TrabCodigo = P00GJ3_A2417TrabCodigo[0];
               AV34count = (long)(AV34count+1);
               BRKGJ4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2528TrabCodInterno)) )
            {
               AV26Option = A2528TrabCodInterno;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGJ4 )
            {
               BRKGJ4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTRABNOMBRESOPTIONS' Routine */
         returnInSub = false;
         AV75TFTrabNombres = AV22SearchTxt;
         AV76TFTrabNombres_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV72TFTrabCodigo_Sel ,
                                              AV71TFTrabCodigo ,
                                              AV74TFTrabCodInterno_Sel ,
                                              AV73TFTrabCodInterno ,
                                              AV76TFTrabNombres_Sel ,
                                              AV75TFTrabNombres ,
                                              A2417TrabCodigo ,
                                              A2528TrabCodInterno ,
                                              A2527TrabNombres ,
                                              A2524TrabEstado } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV71TFTrabCodigo = StringUtil.Concat( StringUtil.RTrim( AV71TFTrabCodigo), "%", "");
         lV73TFTrabCodInterno = StringUtil.Concat( StringUtil.RTrim( AV73TFTrabCodInterno), "%", "");
         lV75TFTrabNombres = StringUtil.Concat( StringUtil.RTrim( AV75TFTrabNombres), "%", "");
         /* Using cursor P00GJ4 */
         pr_default.execute(2, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV71TFTrabCodigo, AV72TFTrabCodigo_Sel, lV73TFTrabCodInterno, AV74TFTrabCodInterno_Sel, lV75TFTrabNombres, AV76TFTrabNombres_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKGJ6 = false;
            A2524TrabEstado = P00GJ4_A2524TrabEstado[0];
            n2524TrabEstado = P00GJ4_n2524TrabEstado[0];
            A2527TrabNombres = P00GJ4_A2527TrabNombres[0];
            n2527TrabNombres = P00GJ4_n2527TrabNombres[0];
            A2528TrabCodInterno = P00GJ4_A2528TrabCodInterno[0];
            n2528TrabCodInterno = P00GJ4_n2528TrabCodInterno[0];
            A2417TrabCodigo = P00GJ4_A2417TrabCodigo[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00GJ4_A2527TrabNombres[0], A2527TrabNombres) == 0 ) )
            {
               BRKGJ6 = false;
               A2417TrabCodigo = P00GJ4_A2417TrabCodigo[0];
               AV34count = (long)(AV34count+1);
               BRKGJ6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2527TrabNombres)) )
            {
               AV26Option = A2527TrabNombres;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGJ6 )
            {
               BRKGJ6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV71TFTrabCodigo = "";
         AV72TFTrabCodigo_Sel = "";
         AV73TFTrabCodInterno = "";
         AV74TFTrabCodInterno_Sel = "";
         AV75TFTrabNombres = "";
         AV76TFTrabNombres_Sel = "";
         scmdbuf = "";
         lV60FilterFullText = "";
         lV71TFTrabCodigo = "";
         lV73TFTrabCodInterno = "";
         lV75TFTrabNombres = "";
         A2417TrabCodigo = "";
         A2528TrabCodInterno = "";
         A2527TrabNombres = "";
         P00GJ2_A2417TrabCodigo = new string[] {""} ;
         P00GJ2_A2524TrabEstado = new short[1] ;
         P00GJ2_n2524TrabEstado = new bool[] {false} ;
         P00GJ2_A2527TrabNombres = new string[] {""} ;
         P00GJ2_n2527TrabNombres = new bool[] {false} ;
         P00GJ2_A2528TrabCodInterno = new string[] {""} ;
         P00GJ2_n2528TrabCodInterno = new bool[] {false} ;
         AV26Option = "";
         P00GJ3_A2524TrabEstado = new short[1] ;
         P00GJ3_n2524TrabEstado = new bool[] {false} ;
         P00GJ3_A2528TrabCodInterno = new string[] {""} ;
         P00GJ3_n2528TrabCodInterno = new bool[] {false} ;
         P00GJ3_A2527TrabNombres = new string[] {""} ;
         P00GJ3_n2527TrabNombres = new bool[] {false} ;
         P00GJ3_A2417TrabCodigo = new string[] {""} ;
         P00GJ4_A2524TrabEstado = new short[1] ;
         P00GJ4_n2524TrabEstado = new bool[] {false} ;
         P00GJ4_A2527TrabNombres = new string[] {""} ;
         P00GJ4_n2527TrabNombres = new bool[] {false} ;
         P00GJ4_A2528TrabCodInterno = new string[] {""} ;
         P00GJ4_n2528TrabCodInterno = new bool[] {false} ;
         P00GJ4_A2417TrabCodigo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.wwbusquedatrabajadorgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00GJ2_A2417TrabCodigo, P00GJ2_A2524TrabEstado, P00GJ2_n2524TrabEstado, P00GJ2_A2527TrabNombres, P00GJ2_n2527TrabNombres, P00GJ2_A2528TrabCodInterno, P00GJ2_n2528TrabCodInterno
               }
               , new Object[] {
               P00GJ3_A2524TrabEstado, P00GJ3_n2524TrabEstado, P00GJ3_A2528TrabCodInterno, P00GJ3_n2528TrabCodInterno, P00GJ3_A2527TrabNombres, P00GJ3_n2527TrabNombres, P00GJ3_A2417TrabCodigo
               }
               , new Object[] {
               P00GJ4_A2524TrabEstado, P00GJ4_n2524TrabEstado, P00GJ4_A2527TrabNombres, P00GJ4_n2527TrabNombres, P00GJ4_A2528TrabCodInterno, P00GJ4_n2528TrabCodInterno, P00GJ4_A2417TrabCodigo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A2524TrabEstado ;
      private int AV79GXV1 ;
      private long AV34count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRKGJ2 ;
      private bool n2524TrabEstado ;
      private bool n2527TrabNombres ;
      private bool n2528TrabCodInterno ;
      private bool BRKGJ4 ;
      private bool BRKGJ6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV60FilterFullText ;
      private string AV71TFTrabCodigo ;
      private string AV72TFTrabCodigo_Sel ;
      private string AV73TFTrabCodInterno ;
      private string AV74TFTrabCodInterno_Sel ;
      private string AV75TFTrabNombres ;
      private string AV76TFTrabNombres_Sel ;
      private string lV60FilterFullText ;
      private string lV71TFTrabCodigo ;
      private string lV73TFTrabCodInterno ;
      private string lV75TFTrabNombres ;
      private string A2417TrabCodigo ;
      private string A2528TrabCodInterno ;
      private string A2527TrabNombres ;
      private string AV26Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GJ2_A2417TrabCodigo ;
      private short[] P00GJ2_A2524TrabEstado ;
      private bool[] P00GJ2_n2524TrabEstado ;
      private string[] P00GJ2_A2527TrabNombres ;
      private bool[] P00GJ2_n2527TrabNombres ;
      private string[] P00GJ2_A2528TrabCodInterno ;
      private bool[] P00GJ2_n2528TrabCodInterno ;
      private short[] P00GJ3_A2524TrabEstado ;
      private bool[] P00GJ3_n2524TrabEstado ;
      private string[] P00GJ3_A2528TrabCodInterno ;
      private bool[] P00GJ3_n2528TrabCodInterno ;
      private string[] P00GJ3_A2527TrabNombres ;
      private bool[] P00GJ3_n2527TrabNombres ;
      private string[] P00GJ3_A2417TrabCodigo ;
      private short[] P00GJ4_A2524TrabEstado ;
      private bool[] P00GJ4_n2524TrabEstado ;
      private string[] P00GJ4_A2527TrabNombres ;
      private bool[] P00GJ4_n2527TrabNombres ;
      private string[] P00GJ4_A2528TrabCodInterno ;
      private bool[] P00GJ4_n2528TrabCodInterno ;
      private string[] P00GJ4_A2417TrabCodigo ;
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

   public class wwbusquedatrabajadorgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GJ2( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV72TFTrabCodigo_Sel ,
                                             string AV71TFTrabCodigo ,
                                             string AV74TFTrabCodInterno_Sel ,
                                             string AV73TFTrabCodInterno ,
                                             string AV76TFTrabNombres_Sel ,
                                             string AV75TFTrabNombres ,
                                             string A2417TrabCodigo ,
                                             string A2528TrabCodInterno ,
                                             string A2527TrabNombres ,
                                             short A2524TrabEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TrabCodigo], [TrabEstado], [TrabNombres], [TrabCodInterno] FROM [Trab_Trabajador]";
         AddWhere(sWhereString, "([TrabEstado] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [TrabCodigo] like '%' + @lV60FilterFullText) or ( [TrabCodInterno] like '%' + @lV60FilterFullText) or ( [TrabNombres] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFTrabCodigo)) ) )
         {
            AddWhere(sWhereString, "([TrabCodigo] like @lV71TFTrabCodigo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodigo] = @AV72TFTrabCodigo_Sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTrabCodInterno)) ) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] like @lV73TFTrabCodInterno)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] = @AV74TFTrabCodInterno_Sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFTrabNombres)) ) )
         {
            AddWhere(sWhereString, "([TrabNombres] like @lV75TFTrabNombres)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) )
         {
            AddWhere(sWhereString, "([TrabNombres] = @AV76TFTrabNombres_Sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TrabCodigo]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00GJ3( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV72TFTrabCodigo_Sel ,
                                             string AV71TFTrabCodigo ,
                                             string AV74TFTrabCodInterno_Sel ,
                                             string AV73TFTrabCodInterno ,
                                             string AV76TFTrabNombres_Sel ,
                                             string AV75TFTrabNombres ,
                                             string A2417TrabCodigo ,
                                             string A2528TrabCodInterno ,
                                             string A2527TrabNombres ,
                                             short A2524TrabEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TrabEstado], [TrabCodInterno], [TrabNombres], [TrabCodigo] FROM [Trab_Trabajador]";
         AddWhere(sWhereString, "([TrabEstado] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [TrabCodigo] like '%' + @lV60FilterFullText) or ( [TrabCodInterno] like '%' + @lV60FilterFullText) or ( [TrabNombres] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFTrabCodigo)) ) )
         {
            AddWhere(sWhereString, "([TrabCodigo] like @lV71TFTrabCodigo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodigo] = @AV72TFTrabCodigo_Sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTrabCodInterno)) ) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] like @lV73TFTrabCodInterno)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] = @AV74TFTrabCodInterno_Sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFTrabNombres)) ) )
         {
            AddWhere(sWhereString, "([TrabNombres] like @lV75TFTrabNombres)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) )
         {
            AddWhere(sWhereString, "([TrabNombres] = @AV76TFTrabNombres_Sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TrabCodInterno]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00GJ4( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV72TFTrabCodigo_Sel ,
                                             string AV71TFTrabCodigo ,
                                             string AV74TFTrabCodInterno_Sel ,
                                             string AV73TFTrabCodInterno ,
                                             string AV76TFTrabNombres_Sel ,
                                             string AV75TFTrabNombres ,
                                             string A2417TrabCodigo ,
                                             string A2528TrabCodInterno ,
                                             string A2527TrabNombres ,
                                             short A2524TrabEstado )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [TrabEstado], [TrabNombres], [TrabCodInterno], [TrabCodigo] FROM [Trab_Trabajador]";
         AddWhere(sWhereString, "([TrabEstado] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [TrabCodigo] like '%' + @lV60FilterFullText) or ( [TrabCodInterno] like '%' + @lV60FilterFullText) or ( [TrabNombres] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFTrabCodigo)) ) )
         {
            AddWhere(sWhereString, "([TrabCodigo] like @lV71TFTrabCodigo)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72TFTrabCodigo_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodigo] = @AV72TFTrabCodigo_Sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFTrabCodInterno)) ) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] like @lV73TFTrabCodInterno)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFTrabCodInterno_Sel)) )
         {
            AddWhere(sWhereString, "([TrabCodInterno] = @AV74TFTrabCodInterno_Sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFTrabNombres)) ) )
         {
            AddWhere(sWhereString, "([TrabNombres] like @lV75TFTrabNombres)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFTrabNombres_Sel)) )
         {
            AddWhere(sWhereString, "([TrabNombres] = @AV76TFTrabNombres_Sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TrabNombres]";
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
                     return conditional_P00GJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_P00GJ3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 2 :
                     return conditional_P00GJ4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GJ2;
          prmP00GJ2 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV71TFTrabCodigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV72TFTrabCodigo_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV73TFTrabCodInterno",GXType.NVarChar,20,0) ,
          new ParDef("@AV74TFTrabCodInterno_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV75TFTrabNombres",GXType.NVarChar,100,0) ,
          new ParDef("@AV76TFTrabNombres_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00GJ3;
          prmP00GJ3 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV71TFTrabCodigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV72TFTrabCodigo_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV73TFTrabCodInterno",GXType.NVarChar,20,0) ,
          new ParDef("@AV74TFTrabCodInterno_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV75TFTrabNombres",GXType.NVarChar,100,0) ,
          new ParDef("@AV76TFTrabNombres_Sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00GJ4;
          prmP00GJ4 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV71TFTrabCodigo",GXType.NVarChar,20,0) ,
          new ParDef("@AV72TFTrabCodigo_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV73TFTrabCodInterno",GXType.NVarChar,20,0) ,
          new ParDef("@AV74TFTrabCodInterno_Sel",GXType.NVarChar,20,0) ,
          new ParDef("@lV75TFTrabNombres",GXType.NVarChar,100,0) ,
          new ParDef("@AV76TFTrabNombres_Sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00GJ4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GJ4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
