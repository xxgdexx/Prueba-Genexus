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
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class rresumendocumentosexcel : GXProcedure
   {
      public rresumendocumentosexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rresumendocumentosexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref int aP0_TipCCod ,
                           ref string aP1_EstCod ,
                           ref string aP2_CliCod ,
                           ref string aP3_TipCod ,
                           ref string aP4_PaiCod ,
                           ref DateTime aP5_FDesde ,
                           ref DateTime aP6_FHasta ,
                           ref int aP7_DocMonCod ,
                           ref int aP8_DocConpCod ,
                           ref string aP9_Serie ,
                           ref string aP10_Tipo ,
                           ref int aP11_TieCod ,
                           ref int aP12_VenCod ,
                           out string aP13_Filename ,
                           out string aP14_ErrorMessage )
      {
         this.AV78TipCCod = aP0_TipCCod;
         this.AV30EstCod = aP1_EstCod;
         this.AV13CliCod = aP2_CliCod;
         this.AV79TipCod = aP3_TipCod;
         this.AV48PaiCod = aP4_PaiCod;
         this.AV33FDesde = aP5_FDesde;
         this.AV35FHasta = aP6_FHasta;
         this.AV24DocMonCod = aP7_DocMonCod;
         this.AV18DocConpCod = aP8_DocConpCod;
         this.AV71Serie = aP9_Serie;
         this.AV81Tipo = aP10_Tipo;
         this.AV76TieCod = aP11_TieCod;
         this.AV94VenCod = aP12_VenCod;
         this.AV36Filename = "" ;
         this.AV29ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_TipCCod=this.AV78TipCCod;
         aP1_EstCod=this.AV30EstCod;
         aP2_CliCod=this.AV13CliCod;
         aP3_TipCod=this.AV79TipCod;
         aP4_PaiCod=this.AV48PaiCod;
         aP5_FDesde=this.AV33FDesde;
         aP6_FHasta=this.AV35FHasta;
         aP7_DocMonCod=this.AV24DocMonCod;
         aP8_DocConpCod=this.AV18DocConpCod;
         aP9_Serie=this.AV71Serie;
         aP10_Tipo=this.AV81Tipo;
         aP11_TieCod=this.AV76TieCod;
         aP12_VenCod=this.AV94VenCod;
         aP13_Filename=this.AV36Filename;
         aP14_ErrorMessage=this.AV29ErrorMessage;
      }

      public string executeUdp( ref int aP0_TipCCod ,
                                ref string aP1_EstCod ,
                                ref string aP2_CliCod ,
                                ref string aP3_TipCod ,
                                ref string aP4_PaiCod ,
                                ref DateTime aP5_FDesde ,
                                ref DateTime aP6_FHasta ,
                                ref int aP7_DocMonCod ,
                                ref int aP8_DocConpCod ,
                                ref string aP9_Serie ,
                                ref string aP10_Tipo ,
                                ref int aP11_TieCod ,
                                ref int aP12_VenCod ,
                                out string aP13_Filename )
      {
         execute(ref aP0_TipCCod, ref aP1_EstCod, ref aP2_CliCod, ref aP3_TipCod, ref aP4_PaiCod, ref aP5_FDesde, ref aP6_FHasta, ref aP7_DocMonCod, ref aP8_DocConpCod, ref aP9_Serie, ref aP10_Tipo, ref aP11_TieCod, ref aP12_VenCod, out aP13_Filename, out aP14_ErrorMessage);
         return AV29ErrorMessage ;
      }

      public void executeSubmit( ref int aP0_TipCCod ,
                                 ref string aP1_EstCod ,
                                 ref string aP2_CliCod ,
                                 ref string aP3_TipCod ,
                                 ref string aP4_PaiCod ,
                                 ref DateTime aP5_FDesde ,
                                 ref DateTime aP6_FHasta ,
                                 ref int aP7_DocMonCod ,
                                 ref int aP8_DocConpCod ,
                                 ref string aP9_Serie ,
                                 ref string aP10_Tipo ,
                                 ref int aP11_TieCod ,
                                 ref int aP12_VenCod ,
                                 out string aP13_Filename ,
                                 out string aP14_ErrorMessage )
      {
         rresumendocumentosexcel objrresumendocumentosexcel;
         objrresumendocumentosexcel = new rresumendocumentosexcel();
         objrresumendocumentosexcel.AV78TipCCod = aP0_TipCCod;
         objrresumendocumentosexcel.AV30EstCod = aP1_EstCod;
         objrresumendocumentosexcel.AV13CliCod = aP2_CliCod;
         objrresumendocumentosexcel.AV79TipCod = aP3_TipCod;
         objrresumendocumentosexcel.AV48PaiCod = aP4_PaiCod;
         objrresumendocumentosexcel.AV33FDesde = aP5_FDesde;
         objrresumendocumentosexcel.AV35FHasta = aP6_FHasta;
         objrresumendocumentosexcel.AV24DocMonCod = aP7_DocMonCod;
         objrresumendocumentosexcel.AV18DocConpCod = aP8_DocConpCod;
         objrresumendocumentosexcel.AV71Serie = aP9_Serie;
         objrresumendocumentosexcel.AV81Tipo = aP10_Tipo;
         objrresumendocumentosexcel.AV76TieCod = aP11_TieCod;
         objrresumendocumentosexcel.AV94VenCod = aP12_VenCod;
         objrresumendocumentosexcel.AV36Filename = "" ;
         objrresumendocumentosexcel.AV29ErrorMessage = "" ;
         objrresumendocumentosexcel.context.SetSubmitInitialConfig(context);
         objrresumendocumentosexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrresumendocumentosexcel);
         aP0_TipCCod=this.AV78TipCCod;
         aP1_EstCod=this.AV30EstCod;
         aP2_CliCod=this.AV13CliCod;
         aP3_TipCod=this.AV79TipCod;
         aP4_PaiCod=this.AV48PaiCod;
         aP5_FDesde=this.AV33FDesde;
         aP6_FHasta=this.AV35FHasta;
         aP7_DocMonCod=this.AV24DocMonCod;
         aP8_DocConpCod=this.AV18DocConpCod;
         aP9_Serie=this.AV71Serie;
         aP10_Tipo=this.AV81Tipo;
         aP11_TieCod=this.AV76TieCod;
         aP12_VenCod=this.AV94VenCod;
         aP13_Filename=this.AV36Filename;
         aP14_ErrorMessage=this.AV29ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rresumendocumentosexcel)stateInfo).executePrivate();
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
         AV9Archivo.Source = "Excel/PlantillasResumenDocumentos.xlsx";
         AV49Path = AV9Archivo.GetPath();
         AV37FilenameOrigen = StringUtil.Trim( AV49Path) + "\\PlantillasResumenDocumentos.xlsx";
         AV36Filename = "Excel/ResumenDocumentos" + ".xlsx";
         AV31ExcelDocument.Clear();
         AV31ExcelDocument.Template = AV37FilenameOrigen;
         AV31ExcelDocument.Open(AV36Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV11CellRow = 5;
         AV41FirstColumn = 0;
         AV42Item = 0;
         AV38Filtro1 = "Del : " + context.localUtil.DToC( AV33FDesde, 2, "/") + " Al : " + context.localUtil.DToC( AV35FHasta, 2, "/");
         AV31ExcelDocument.get_Cells(3, 1, 1, 1).Text = StringUtil.Trim( AV38Filtro1);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV76TieCod ,
                                              AV78TipCCod ,
                                              AV30EstCod ,
                                              AV13CliCod ,
                                              AV79TipCod ,
                                              AV48PaiCod ,
                                              AV24DocMonCod ,
                                              AV18DocConpCod ,
                                              AV94VenCod ,
                                              AV81Tipo ,
                                              AV71Serie ,
                                              A178TieCod ,
                                              A159TipCCod ,
                                              A140EstCod ,
                                              A231DocCliCod ,
                                              A149TipCod ,
                                              A139PaiCod ,
                                              A230DocMonCod ,
                                              A229DocConpCod ,
                                              A227DocVendCod ,
                                              A946DocTipo ,
                                              A24DocNum ,
                                              A232DocFec ,
                                              AV33FDesde ,
                                              AV35FHasta } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor P009G3 */
         pr_default.execute(0, new Object[] {AV33FDesde, AV35FHasta, AV76TieCod, AV78TipCCod, AV30EstCod, AV13CliCod, AV79TipCod, AV48PaiCod, AV24DocMonCod, AV18DocConpCod, AV94VenCod, AV81Tipo, AV71Serie});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A232DocFec = P009G3_A232DocFec[0];
            A24DocNum = P009G3_A24DocNum[0];
            A946DocTipo = P009G3_A946DocTipo[0];
            A227DocVendCod = P009G3_A227DocVendCod[0];
            A229DocConpCod = P009G3_A229DocConpCod[0];
            A230DocMonCod = P009G3_A230DocMonCod[0];
            A139PaiCod = P009G3_A139PaiCod[0];
            n139PaiCod = P009G3_n139PaiCod[0];
            A149TipCod = P009G3_A149TipCod[0];
            A231DocCliCod = P009G3_A231DocCliCod[0];
            A140EstCod = P009G3_A140EstCod[0];
            n140EstCod = P009G3_n140EstCod[0];
            A159TipCCod = P009G3_A159TipCCod[0];
            n159TipCCod = P009G3_n159TipCCod[0];
            A178TieCod = P009G3_A178TieCod[0];
            n178TieCod = P009G3_n178TieCod[0];
            A306TipAbr = P009G3_A306TipAbr[0];
            A937DocPedCod = P009G3_A937DocPedCod[0];
            A890DocCosCod = P009G3_A890DocCosCod[0];
            n890DocCosCod = P009G3_n890DocCosCod[0];
            A931DocFVcto = P009G3_A931DocFVcto[0];
            A1234MonDsc = P009G3_A1234MonDsc[0];
            n1234MonDsc = P009G3_n1234MonDsc[0];
            A941DocSts = P009G3_A941DocSts[0];
            A887DocCliDsc = P009G3_A887DocCliDsc[0];
            A511TipSigno = P009G3_A511TipSigno[0];
            A936DocObs = P009G3_A936DocObs[0];
            A932DocICBPER = P009G3_A932DocICBPER[0];
            A935DocRedondeo = P009G3_A935DocRedondeo[0];
            A934DocPorIVA = P009G3_A934DocPorIVA[0];
            A882DocAnticipos = P009G3_A882DocAnticipos[0];
            A899DocDcto = P009G3_A899DocDcto[0];
            A927DocSubExonerado = P009G3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009G3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009G3_A921DocSubInafecto[0];
            A920DocSubAfecto = P009G3_A920DocSubAfecto[0];
            A1234MonDsc = P009G3_A1234MonDsc[0];
            n1234MonDsc = P009G3_n1234MonDsc[0];
            A306TipAbr = P009G3_A306TipAbr[0];
            A511TipSigno = P009G3_A511TipSigno[0];
            A927DocSubExonerado = P009G3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P009G3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P009G3_A921DocSubInafecto[0];
            A920DocSubAfecto = P009G3_A920DocSubAfecto[0];
            A139PaiCod = P009G3_A139PaiCod[0];
            n139PaiCod = P009G3_n139PaiCod[0];
            A140EstCod = P009G3_A140EstCod[0];
            n140EstCod = P009G3_n140EstCod[0];
            A159TipCCod = P009G3_A159TipCCod[0];
            n159TipCCod = P009G3_n159TipCCod[0];
            A887DocCliDsc = P009G3_A887DocCliDsc[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
            A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
            AV77TipAbr = A306TipAbr;
            AV25DocNum = A24DocNum;
            AV21DocFec = A232DocFec;
            AV26DocPedCod = A937DocPedCod;
            AV19DocCosCod = A890DocCosCod;
            /* Execute user subroutine: 'DATOSPEDIDOS' */
            S131 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            AV22DocFVcto = A931DocFVcto;
            AV46MonDsc = StringUtil.Trim( A1234MonDsc);
            AV27DocSts = A941DocSts;
            AV16DocCliCod = A231DocCliCod;
            AV17DocCliDsc = A887DocCliDsc;
            AV72Signo = A511TipSigno;
            AV28DocSub = (decimal)(A919DocSub*AV72Signo);
            AV20DocDscto = (decimal)(A918DocDscto*AV72Signo);
            AV23DocIVA = (decimal)(A933DocIVA*AV72Signo);
            AV90TotalVenta = (decimal)(A948DocTot*AV72Signo);
            AV28DocSub = (decimal)(AV28DocSub-AV20DocDscto);
            AV8DocObs = StringUtil.Trim( A936DocObs);
            AV82TipoVenta = ((StringUtil.StrCmp(A946DocTipo, "M")==0) ? "MUESTRA" : ((StringUtil.StrCmp(A946DocTipo, "A")==0) ? "ANTICIPO" : ((StringUtil.StrCmp(A946DocTipo, "E")==0) ? "EXPORTACION" : ((StringUtil.StrCmp(A946DocTipo, "X")==0) ? "MUESTRA EXPORTACION" : "NORMAL"))));
            if ( StringUtil.StrCmp(AV27DocSts, "A") == 0 )
            {
               AV16DocCliCod = "";
               AV17DocCliDsc = "ANULADO";
               AV72Signo = 1;
               AV28DocSub = 0.00m;
               AV23DocIVA = 0.00m;
               AV90TotalVenta = 0.00m;
            }
            /* Execute user subroutine: 'DETALLE' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               this.cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV31ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV31ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'DETALLE' Routine */
         returnInSub = false;
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+1), 1, 1).Text = StringUtil.Trim( AV77TipAbr);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+2), 1, 1).Text = StringUtil.Trim( AV25DocNum);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+3), 1, 1).Text = StringUtil.Trim( AV26DocPedCod);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+4), 1, 1).Text = StringUtil.Trim( AV93TPedDsc);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+5), 1, 1).Text = StringUtil.Trim( AV59PedRef);
         GXt_dtime1 = DateTimeUtil.ResetTime( AV21DocFec ) ;
         AV31ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+6), 1, 1).Date = GXt_dtime1;
         GXt_dtime1 = DateTimeUtil.ResetTime( AV22DocFVcto ) ;
         AV31ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+7), 1, 1).Date = GXt_dtime1;
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+8), 1, 1).Text = AV46MonDsc;
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+9), 1, 1).Text = StringUtil.Trim( AV17DocCliDsc);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+10), 1, 1).Number = (double)(AV28DocSub);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+11), 1, 1).Number = (double)(AV23DocIVA);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+12), 1, 1).Number = (double)(AV90TotalVenta);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+13), 1, 1).Text = AV82TipoVenta;
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+14), 1, 1).Text = StringUtil.Trim( AV8DocObs);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+15), 1, 1).Text = StringUtil.Trim( AV58PedObs);
         AV31ExcelDocument.get_Cells((int)(AV11CellRow), (int)(AV41FirstColumn+16), 1, 1).Text = StringUtil.Trim( AV15Costo);
         AV11CellRow = (long)(AV11CellRow+1);
      }

      protected void S121( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV31ExcelDocument.ErrCode != 0 )
         {
            AV36Filename = "";
            AV29ErrorMessage = AV31ExcelDocument.ErrDescription;
            AV31ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S131( )
      {
         /* 'DATOSPEDIDOS' Routine */
         returnInSub = false;
         AV93TPedDsc = "";
         AV59PedRef = "";
         AV58PedObs = "";
         AV15Costo = "";
         /* Using cursor P009G4 */
         pr_default.execute(1, new Object[] {AV26DocPedCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A212TPedCod = P009G4_A212TPedCod[0];
            A210PedCod = P009G4_A210PedCod[0];
            A1931TPedDsc = P009G4_A1931TPedDsc[0];
            A1605PedRef = P009G4_A1605PedRef[0];
            A1604PedObs = P009G4_A1604PedObs[0];
            A1931TPedDsc = P009G4_A1931TPedDsc[0];
            AV93TPedDsc = StringUtil.Trim( A1931TPedDsc);
            AV59PedRef = StringUtil.Trim( A1605PedRef);
            AV58PedObs = StringUtil.Trim( A1604PedObs);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P009G5 */
         pr_default.execute(2, new Object[] {AV19DocCosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A79COSCod = P009G5_A79COSCod[0];
            A761COSDsc = P009G5_A761COSDsc[0];
            AV15Costo = StringUtil.Trim( A761COSDsc);
            /* Exiting from a For First loop. */
            if (true) break;
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
         AV36Filename = "";
         AV29ErrorMessage = "";
         AV9Archivo = new GxFile(context.GetPhysicalPath());
         AV49Path = "";
         AV37FilenameOrigen = "";
         AV31ExcelDocument = new ExcelDocumentI();
         AV38Filtro1 = "";
         scmdbuf = "";
         A140EstCod = "";
         A231DocCliCod = "";
         A149TipCod = "";
         A139PaiCod = "";
         A946DocTipo = "";
         A24DocNum = "";
         A232DocFec = DateTime.MinValue;
         P009G3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P009G3_A24DocNum = new string[] {""} ;
         P009G3_A946DocTipo = new string[] {""} ;
         P009G3_A227DocVendCod = new int[1] ;
         P009G3_A229DocConpCod = new int[1] ;
         P009G3_A230DocMonCod = new int[1] ;
         P009G3_A139PaiCod = new string[] {""} ;
         P009G3_n139PaiCod = new bool[] {false} ;
         P009G3_A149TipCod = new string[] {""} ;
         P009G3_A231DocCliCod = new string[] {""} ;
         P009G3_A140EstCod = new string[] {""} ;
         P009G3_n140EstCod = new bool[] {false} ;
         P009G3_A159TipCCod = new int[1] ;
         P009G3_n159TipCCod = new bool[] {false} ;
         P009G3_A178TieCod = new int[1] ;
         P009G3_n178TieCod = new bool[] {false} ;
         P009G3_A306TipAbr = new string[] {""} ;
         P009G3_A937DocPedCod = new string[] {""} ;
         P009G3_A890DocCosCod = new string[] {""} ;
         P009G3_n890DocCosCod = new bool[] {false} ;
         P009G3_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         P009G3_A1234MonDsc = new string[] {""} ;
         P009G3_n1234MonDsc = new bool[] {false} ;
         P009G3_A941DocSts = new string[] {""} ;
         P009G3_A887DocCliDsc = new string[] {""} ;
         P009G3_A511TipSigno = new short[1] ;
         P009G3_A936DocObs = new string[] {""} ;
         P009G3_A932DocICBPER = new decimal[1] ;
         P009G3_A935DocRedondeo = new decimal[1] ;
         P009G3_A934DocPorIVA = new decimal[1] ;
         P009G3_A882DocAnticipos = new decimal[1] ;
         P009G3_A899DocDcto = new decimal[1] ;
         P009G3_A927DocSubExonerado = new decimal[1] ;
         P009G3_A922DocSubSelectivo = new decimal[1] ;
         P009G3_A921DocSubInafecto = new decimal[1] ;
         P009G3_A920DocSubAfecto = new decimal[1] ;
         A306TipAbr = "";
         A937DocPedCod = "";
         A890DocCosCod = "";
         A931DocFVcto = DateTime.MinValue;
         A1234MonDsc = "";
         A941DocSts = "";
         A887DocCliDsc = "";
         A936DocObs = "";
         AV77TipAbr = "";
         AV25DocNum = "";
         AV21DocFec = DateTime.MinValue;
         AV26DocPedCod = "";
         AV19DocCosCod = "";
         AV22DocFVcto = DateTime.MinValue;
         AV46MonDsc = "";
         AV27DocSts = "";
         AV16DocCliCod = "";
         AV17DocCliDsc = "";
         AV8DocObs = "";
         AV82TipoVenta = "";
         AV93TPedDsc = "";
         AV59PedRef = "";
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV58PedObs = "";
         AV15Costo = "";
         P009G4_A212TPedCod = new int[1] ;
         P009G4_A210PedCod = new string[] {""} ;
         P009G4_A1931TPedDsc = new string[] {""} ;
         P009G4_A1605PedRef = new string[] {""} ;
         P009G4_A1604PedObs = new string[] {""} ;
         A210PedCod = "";
         A1931TPedDsc = "";
         A1605PedRef = "";
         A1604PedObs = "";
         P009G5_A79COSCod = new string[] {""} ;
         P009G5_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rresumendocumentosexcel__default(),
            new Object[][] {
                new Object[] {
               P009G3_A232DocFec, P009G3_A24DocNum, P009G3_A946DocTipo, P009G3_A227DocVendCod, P009G3_A229DocConpCod, P009G3_A230DocMonCod, P009G3_A139PaiCod, P009G3_n139PaiCod, P009G3_A149TipCod, P009G3_A231DocCliCod,
               P009G3_A140EstCod, P009G3_n140EstCod, P009G3_A159TipCCod, P009G3_n159TipCCod, P009G3_A178TieCod, P009G3_n178TieCod, P009G3_A306TipAbr, P009G3_A937DocPedCod, P009G3_A890DocCosCod, P009G3_n890DocCosCod,
               P009G3_A931DocFVcto, P009G3_A1234MonDsc, P009G3_n1234MonDsc, P009G3_A941DocSts, P009G3_A887DocCliDsc, P009G3_A511TipSigno, P009G3_A936DocObs, P009G3_A932DocICBPER, P009G3_A935DocRedondeo, P009G3_A934DocPorIVA,
               P009G3_A882DocAnticipos, P009G3_A899DocDcto, P009G3_A927DocSubExonerado, P009G3_A922DocSubSelectivo, P009G3_A921DocSubInafecto, P009G3_A920DocSubAfecto
               }
               , new Object[] {
               P009G4_A212TPedCod, P009G4_A210PedCod, P009G4_A1931TPedDsc, P009G4_A1605PedRef, P009G4_A1604PedObs
               }
               , new Object[] {
               P009G5_A79COSCod, P009G5_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A511TipSigno ;
      private short AV72Signo ;
      private int AV78TipCCod ;
      private int AV24DocMonCod ;
      private int AV18DocConpCod ;
      private int AV76TieCod ;
      private int AV94VenCod ;
      private int AV42Item ;
      private int A178TieCod ;
      private int A159TipCCod ;
      private int A230DocMonCod ;
      private int A229DocConpCod ;
      private int A227DocVendCod ;
      private int A212TPedCod ;
      private long AV11CellRow ;
      private long AV41FirstColumn ;
      private decimal A932DocICBPER ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A882DocAnticipos ;
      private decimal A899DocDcto ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV28DocSub ;
      private decimal AV20DocDscto ;
      private decimal AV23DocIVA ;
      private decimal AV90TotalVenta ;
      private string AV30EstCod ;
      private string AV13CliCod ;
      private string AV79TipCod ;
      private string AV48PaiCod ;
      private string AV71Serie ;
      private string AV81Tipo ;
      private string AV49Path ;
      private string scmdbuf ;
      private string A140EstCod ;
      private string A231DocCliCod ;
      private string A149TipCod ;
      private string A139PaiCod ;
      private string A946DocTipo ;
      private string A24DocNum ;
      private string A306TipAbr ;
      private string A937DocPedCod ;
      private string A890DocCosCod ;
      private string A1234MonDsc ;
      private string A941DocSts ;
      private string A887DocCliDsc ;
      private string AV77TipAbr ;
      private string AV25DocNum ;
      private string AV26DocPedCod ;
      private string AV19DocCosCod ;
      private string AV46MonDsc ;
      private string AV27DocSts ;
      private string AV16DocCliCod ;
      private string AV17DocCliDsc ;
      private string AV82TipoVenta ;
      private string AV93TPedDsc ;
      private string AV59PedRef ;
      private string A210PedCod ;
      private string A1931TPedDsc ;
      private string A1605PedRef ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime1 ;
      private DateTime AV33FDesde ;
      private DateTime AV35FHasta ;
      private DateTime A232DocFec ;
      private DateTime A931DocFVcto ;
      private DateTime AV21DocFec ;
      private DateTime AV22DocFVcto ;
      private bool returnInSub ;
      private bool n139PaiCod ;
      private bool n140EstCod ;
      private bool n159TipCCod ;
      private bool n178TieCod ;
      private bool n890DocCosCod ;
      private bool n1234MonDsc ;
      private string A936DocObs ;
      private string AV8DocObs ;
      private string AV58PedObs ;
      private string A1604PedObs ;
      private string AV36Filename ;
      private string AV29ErrorMessage ;
      private string AV37FilenameOrigen ;
      private string AV38Filtro1 ;
      private string AV15Costo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private int aP0_TipCCod ;
      private string aP1_EstCod ;
      private string aP2_CliCod ;
      private string aP3_TipCod ;
      private string aP4_PaiCod ;
      private DateTime aP5_FDesde ;
      private DateTime aP6_FHasta ;
      private int aP7_DocMonCod ;
      private int aP8_DocConpCod ;
      private string aP9_Serie ;
      private string aP10_Tipo ;
      private int aP11_TieCod ;
      private int aP12_VenCod ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P009G3_A232DocFec ;
      private string[] P009G3_A24DocNum ;
      private string[] P009G3_A946DocTipo ;
      private int[] P009G3_A227DocVendCod ;
      private int[] P009G3_A229DocConpCod ;
      private int[] P009G3_A230DocMonCod ;
      private string[] P009G3_A139PaiCod ;
      private bool[] P009G3_n139PaiCod ;
      private string[] P009G3_A149TipCod ;
      private string[] P009G3_A231DocCliCod ;
      private string[] P009G3_A140EstCod ;
      private bool[] P009G3_n140EstCod ;
      private int[] P009G3_A159TipCCod ;
      private bool[] P009G3_n159TipCCod ;
      private int[] P009G3_A178TieCod ;
      private bool[] P009G3_n178TieCod ;
      private string[] P009G3_A306TipAbr ;
      private string[] P009G3_A937DocPedCod ;
      private string[] P009G3_A890DocCosCod ;
      private bool[] P009G3_n890DocCosCod ;
      private DateTime[] P009G3_A931DocFVcto ;
      private string[] P009G3_A1234MonDsc ;
      private bool[] P009G3_n1234MonDsc ;
      private string[] P009G3_A941DocSts ;
      private string[] P009G3_A887DocCliDsc ;
      private short[] P009G3_A511TipSigno ;
      private string[] P009G3_A936DocObs ;
      private decimal[] P009G3_A932DocICBPER ;
      private decimal[] P009G3_A935DocRedondeo ;
      private decimal[] P009G3_A934DocPorIVA ;
      private decimal[] P009G3_A882DocAnticipos ;
      private decimal[] P009G3_A899DocDcto ;
      private decimal[] P009G3_A927DocSubExonerado ;
      private decimal[] P009G3_A922DocSubSelectivo ;
      private decimal[] P009G3_A921DocSubInafecto ;
      private decimal[] P009G3_A920DocSubAfecto ;
      private int[] P009G4_A212TPedCod ;
      private string[] P009G4_A210PedCod ;
      private string[] P009G4_A1931TPedDsc ;
      private string[] P009G4_A1605PedRef ;
      private string[] P009G4_A1604PedObs ;
      private string[] P009G5_A79COSCod ;
      private string[] P009G5_A761COSDsc ;
      private string aP13_Filename ;
      private string aP14_ErrorMessage ;
      private ExcelDocumentI AV31ExcelDocument ;
      private GxFile AV9Archivo ;
   }

   public class rresumendocumentosexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009G3( IGxContext context ,
                                             int AV76TieCod ,
                                             int AV78TipCCod ,
                                             string AV30EstCod ,
                                             string AV13CliCod ,
                                             string AV79TipCod ,
                                             string AV48PaiCod ,
                                             int AV24DocMonCod ,
                                             int AV18DocConpCod ,
                                             int AV94VenCod ,
                                             string AV81Tipo ,
                                             string AV71Serie ,
                                             int A178TieCod ,
                                             int A159TipCCod ,
                                             string A140EstCod ,
                                             string A231DocCliCod ,
                                             string A149TipCod ,
                                             string A139PaiCod ,
                                             int A230DocMonCod ,
                                             int A229DocConpCod ,
                                             int A227DocVendCod ,
                                             string A946DocTipo ,
                                             string A24DocNum ,
                                             DateTime A232DocFec ,
                                             DateTime AV33FDesde ,
                                             DateTime AV35FHasta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DocFec], T1.[DocNum], T1.[DocTipo], T1.[DocVendCod], T1.[DocConpCod], T1.[DocMonCod] AS DocMonCod, T5.[PaiCod], T1.[TipCod], T1.[DocCliCod] AS DocCliCod, T5.[EstCod], T5.[TipCCod], T1.[TieCod], T3.[TipAbr], T1.[DocPedCod], T1.[DocCosCod], T1.[DocFVcto], T2.[MonDsc], T1.[DocSts], T5.[CliDsc] AS DocCliDsc, T3.[TipSigno], T1.[DocObs], T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], T1.[DocDcto], COALESCE( T4.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T4.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T4.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T4.[DocSubAfecto], 0) AS DocSubAfecto FROM (((([CLVENTAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[DocMonCod]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T4 ON T4.[TipCod] = T1.[TipCod] AND T4.[DocNum] = T1.[DocNum]) INNER JOIN [CLCLIENTES] T5 ON T5.[CliCod] = T1.[DocCliCod])";
         AddWhere(sWhereString, "(T1.[DocFec] >= @AV33FDesde and T1.[DocFec] <= @AV35FHasta)");
         if ( ! (0==AV76TieCod) )
         {
            AddWhere(sWhereString, "(T1.[TieCod] = @AV76TieCod)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV78TipCCod) )
         {
            AddWhere(sWhereString, "(T5.[TipCCod] = @AV78TipCCod)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30EstCod)) )
         {
            AddWhere(sWhereString, "(T5.[EstCod] = @AV30EstCod)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13CliCod)) )
         {
            AddWhere(sWhereString, "(T1.[DocCliCod] = @AV13CliCod)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TipCod)) )
         {
            AddWhere(sWhereString, "(T1.[TipCod] = @AV79TipCod)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48PaiCod)) )
         {
            AddWhere(sWhereString, "(T5.[PaiCod] = @AV48PaiCod)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV24DocMonCod) )
         {
            AddWhere(sWhereString, "(T1.[DocMonCod] = @AV24DocMonCod)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV18DocConpCod) )
         {
            AddWhere(sWhereString, "(T1.[DocConpCod] = @AV18DocConpCod)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV94VenCod) )
         {
            AddWhere(sWhereString, "(T1.[DocVendCod] = @AV94VenCod)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV81Tipo, "M") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] = @AV81Tipo)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'M')");
         }
         if ( StringUtil.StrCmp(AV81Tipo, "V") == 0 )
         {
            AddWhere(sWhereString, "(T1.[DocTipo] <> 'X')");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serie)) )
         {
            AddWhere(sWhereString, "(SUBSTRING(T1.[DocNum], 1, 3) = @AV71Serie)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipCod], T1.[DocNum]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P009G3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (DateTime)dynConstraints[22] , (DateTime)dynConstraints[23] , (DateTime)dynConstraints[24] );
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
          Object[] prmP009G4;
          prmP009G4 = new Object[] {
          new ParDef("@AV26DocPedCod",GXType.NChar,10,0)
          };
          Object[] prmP009G5;
          prmP009G5 = new Object[] {
          new ParDef("@AV19DocCosCod",GXType.NChar,10,0)
          };
          Object[] prmP009G3;
          prmP009G3 = new Object[] {
          new ParDef("@AV33FDesde",GXType.Date,8,0) ,
          new ParDef("@AV35FHasta",GXType.Date,8,0) ,
          new ParDef("@AV76TieCod",GXType.Int32,6,0) ,
          new ParDef("@AV78TipCCod",GXType.Int32,6,0) ,
          new ParDef("@AV30EstCod",GXType.NChar,4,0) ,
          new ParDef("@AV13CliCod",GXType.NChar,20,0) ,
          new ParDef("@AV79TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV48PaiCod",GXType.NChar,4,0) ,
          new ParDef("@AV24DocMonCod",GXType.Int32,6,0) ,
          new ParDef("@AV18DocConpCod",GXType.Int32,6,0) ,
          new ParDef("@AV94VenCod",GXType.Int32,6,0) ,
          new ParDef("@AV81Tipo",GXType.NChar,1,0) ,
          new ParDef("@AV71Serie",GXType.Char,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009G4", "SELECT T1.[TPedCod], T1.[PedCod], T2.[TPedDsc], T1.[PedRef], T1.[PedObs] FROM ([CLPEDIDOS] T1 INNER JOIN [CTIPPEDIDO] T2 ON T2.[TPedCod] = T1.[TPedCod]) WHERE T1.[PedCod] = @AV26DocPedCod ORDER BY T1.[PedCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009G5", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV19DocCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009G5,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 12);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((string[]) buf[9])[0] = rslt.getString(9, 20);
                ((string[]) buf[10])[0] = rslt.getString(10, 4);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((int[]) buf[12])[0] = rslt.getInt(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((int[]) buf[14])[0] = rslt.getInt(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((string[]) buf[16])[0] = rslt.getString(13, 5);
                ((string[]) buf[17])[0] = rslt.getString(14, 10);
                ((string[]) buf[18])[0] = rslt.getString(15, 10);
                ((bool[]) buf[19])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(16);
                ((string[]) buf[21])[0] = rslt.getString(17, 100);
                ((bool[]) buf[22])[0] = rslt.wasNull(17);
                ((string[]) buf[23])[0] = rslt.getString(18, 1);
                ((string[]) buf[24])[0] = rslt.getString(19, 100);
                ((short[]) buf[25])[0] = rslt.getShort(20);
                ((string[]) buf[26])[0] = rslt.getLongVarchar(21);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(30);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
