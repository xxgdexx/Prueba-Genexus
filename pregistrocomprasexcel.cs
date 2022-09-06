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
   public class pregistrocomprasexcel : GXProcedure
   {
      public pregistrocomprasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public pregistrocomprasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           ref string aP2_Tipo ,
                           out string aP3_Filename ,
                           out string aP4_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV73Mes = aP1_Mes;
         this.AV97Tipo = aP2_Tipo;
         this.AV50Filename = "" ;
         this.AV42ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV73Mes;
         aP2_Tipo=this.AV97Tipo;
         aP3_Filename=this.AV50Filename;
         aP4_ErrorMessage=this.AV42ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                ref string aP2_Tipo ,
                                out string aP3_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, ref aP2_Tipo, out aP3_Filename, out aP4_ErrorMessage);
         return AV42ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 ref string aP2_Tipo ,
                                 out string aP3_Filename ,
                                 out string aP4_ErrorMessage )
      {
         pregistrocomprasexcel objpregistrocomprasexcel;
         objpregistrocomprasexcel = new pregistrocomprasexcel();
         objpregistrocomprasexcel.AV8Ano = aP0_Ano;
         objpregistrocomprasexcel.AV73Mes = aP1_Mes;
         objpregistrocomprasexcel.AV97Tipo = aP2_Tipo;
         objpregistrocomprasexcel.AV50Filename = "" ;
         objpregistrocomprasexcel.AV42ErrorMessage = "" ;
         objpregistrocomprasexcel.context.SetSubmitInitialConfig(context);
         objpregistrocomprasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpregistrocomprasexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV73Mes;
         aP2_Tipo=this.AV97Tipo;
         aP3_Filename=this.AV50Filename;
         aP4_ErrorMessage=this.AV42ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pregistrocomprasexcel)stateInfo).executePrivate();
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
         AV41Empresa = "RAZON SOCIAL : " + AV86Session.Get("Empresa");
         AV11Archivo.Source = "Excel/PlantillasCompras.xlsx";
         AV81Path = AV11Archivo.GetPath();
         AV51FilenameOrigen = StringUtil.Trim( AV81Path) + "\\PlantillasCompras.xlsx";
         AV50Filename = "Excel/RegistroCompras" + ".xlsx";
         AV45ExcelDocument.Clear();
         AV45ExcelDocument.Template = AV51FilenameOrigen;
         AV45ExcelDocument.Open(AV50Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV15CellRow = 3;
         AV52FirstColumn = 0;
         GXt_char1 = AV16cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV73Mes, out  GXt_char1) ;
         AV16cMes = GXt_char1;
         AV45ExcelDocument.get_Cells(1, 1+0, 1, 1).Text = StringUtil.Trim( AV41Empresa);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+1, 1, 1).Text = "Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0))+"   Mes : "+StringUtil.Trim( AV16cMes);
         AV15CellRow = 6;
         AV52FirstColumn = 1;
         if ( StringUtil.StrCmp(AV97Tipo, "R") == 0 )
         {
            /* Execute user subroutine: 'ORDENADOFECHAREGISTRO' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV97Tipo, "N") == 0 )
         {
            /* Execute user subroutine: 'ORDENADONUMEROREGISTRO' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV97Tipo, "F") == 0 )
         {
            /* Execute user subroutine: 'ORDENADOFECHAEMISION' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(AV97Tipo, "P") == 0 )
         {
            /* Execute user subroutine: 'ORDENADOPROVEEDOR' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV15CellRow = (int)(AV15CellRow+1);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+9, 1, 1).Text = "Total General";
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+10, 1, 1).Number = (double)(AV57GSubTotal);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+11, 1, 1).Number = (double)(AV54GIgv);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+12, 1, 1).Number = (double)(AV56GSubIna);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+13, 1, 1).Number = (double)(AV55GISC);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+14, 1, 1).Number = (double)(AV58GTotalMN);
         AV45ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV45ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV45ExcelDocument.ErrCode != 0 )
         {
            AV50Filename = "";
            AV42ErrorMessage = AV45ExcelDocument.ErrDescription;
            AV45ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLECOMPRAS' Routine */
         returnInSub = false;
         AV18ComDCueCod = "";
         AV19ComDDsc = "";
         /* Using cursor P008V2 */
         pr_default.execute(0, new Object[] {AV95TipCod, AV17ComCod, AV82PrvCod});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A244PrvCod = P008V2_A244PrvCod[0];
            A243ComCod = P008V2_A243ComCod[0];
            A149TipCod = P008V2_A149TipCod[0];
            A251ComDOrdCod = P008V2_A251ComDOrdCod[0];
            A254ComDProCod = P008V2_A254ComDProCod[0];
            n254ComDProCod = P008V2_n254ComDProCod[0];
            A253ComDCueCod = P008V2_A253ComDCueCod[0];
            n253ComDCueCod = P008V2_n253ComDCueCod[0];
            A694ComDDsc = P008V2_A694ComDDsc[0];
            A250ComDItem = P008V2_A250ComDItem[0];
            AV18ComDCueCod = (String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ? A254ComDProCod : A253ComDCueCod);
            AV19ComDDsc = StringUtil.Trim( A694ComDDsc);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P008V3 */
         pr_default.execute(1, new Object[] {AV95TipCod, AV17ComCod, AV82PrvCod});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A252ComCosCod = P008V3_A252ComCosCod[0];
            n252ComCosCod = P008V3_n252ComCosCod[0];
            A244PrvCod = P008V3_A244PrvCod[0];
            A243ComCod = P008V3_A243ComCod[0];
            A149TipCod = P008V3_A149TipCod[0];
            A761COSDsc = P008V3_A761COSDsc[0];
            n761COSDsc = P008V3_n761COSDsc[0];
            A250ComDItem = P008V3_A250ComDItem[0];
            A251ComDOrdCod = P008V3_A251ComDOrdCod[0];
            A761COSDsc = P008V3_A761COSDsc[0];
            n761COSDsc = P008V3_n761COSDsc[0];
            AV107CosDsc = StringUtil.Trim( A761COSDsc);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         AV43Estado = "PENDIENTE";
         /* Using cursor P008V4 */
         pr_default.execute(2, new Object[] {AV95TipCod, AV17ComCod, AV82PrvCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A262CPPrvCod = P008V4_A262CPPrvCod[0];
            A261CPComCod = P008V4_A261CPComCod[0];
            A260CPTipCod = P008V4_A260CPTipCod[0];
            A815CPEstado = P008V4_A815CPEstado[0];
            AV43Estado = (String.IsNullOrEmpty(StringUtil.RTrim( A815CPEstado)) ? "PENDIENTE" : "TERMINADO");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+0, 1, 1).Text = StringUtil.Trim( AV23ComRef);
         GXt_dtime2 = DateTimeUtil.ResetTime( AV37DocFec ) ;
         AV45ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+1, 1, 1).Date = GXt_dtime2;
         GXt_dtime2 = DateTimeUtil.ResetTime( AV20ComFecPago ) ;
         AV45ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+2, 1, 1).Date = GXt_dtime2;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV36DocAbr);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV85Serie);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV9AnoDua);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV38DocNum);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+7, 1, 1).Text = StringUtil.Trim( AV98TipSunat);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+8, 1, 1).Text = StringUtil.Trim( AV82PrvCod);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+9, 1, 1).Text = StringUtil.Trim( AV83PrvDsc);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+10, 1, 1).Number = (double)(AV89SubTotal1);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+11, 1, 1).Number = (double)(AV67IGV1);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+12, 1, 1).Number = (double)(AV87SubIna);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+13, 1, 1).Number = (double)(AV70ISC);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+14, 1, 1).Number = (double)(AV100TotalMN);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+15, 1, 1).Number = (double)(AV101TotalMO);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+16, 1, 1).Text = AV94TipCmb;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+17, 1, 1).Text = AV28ComRetFec;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+18, 1, 1).Text = AV27ComRetCod;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+19, 1, 1).Text = AV25ComRefFec;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+20, 1, 1).Text = AV102TRef;
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+21, 1, 1).Text = StringUtil.Trim( AV24ComRefDoc);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+22, 1, 1).Text = StringUtil.Trim( AV18ComDCueCod);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+23, 1, 1).Text = StringUtil.Trim( AV19ComDDsc);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+24, 1, 1).Text = StringUtil.Trim( AV96TipDsc);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+25, 1, 1).Text = StringUtil.Trim( AV107CosDsc);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+26, 1, 1).Text = StringUtil.Trim( AV108ComUsuC);
         AV45ExcelDocument.get_Cells(AV15CellRow, AV52FirstColumn+27, 1, 1).Text = StringUtil.Trim( AV43Estado);
         AV57GSubTotal = (decimal)(AV57GSubTotal+AV89SubTotal1);
         AV54GIgv = (decimal)(AV54GIgv+AV67IGV1);
         AV56GSubIna = (decimal)(AV56GSubIna+AV87SubIna);
         AV55GISC = (decimal)(AV55GISC+AV70ISC);
         AV53GDscto = (decimal)(AV53GDscto+AV40Dscto);
         AV58GTotalMN = (decimal)(AV58GTotalMN+AV100TotalMN);
         AV59GTotalMO = (decimal)(AV59GTotalMO+AV101TotalMO);
         AV15CellRow = (int)(AV15CellRow+1);
      }

      protected void S131( )
      {
         /* 'ORDENADOFECHAREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P008V6 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8V5 = false;
            A157TipSCod = P008V6_A157TipSCod[0];
            n157TipSCod = P008V6_n157TipSCod[0];
            A1906TipCmp = P008V6_A1906TipCmp[0];
            A306TipAbr = P008V6_A306TipAbr[0];
            A707ComFReg = P008V6_A707ComFReg[0];
            A708ComFVcto = P008V6_A708ComFVcto[0];
            A246ComMon = P008V6_A246ComMon[0];
            A149TipCod = P008V6_A149TipCod[0];
            A1910TipDsc = P008V6_A1910TipDsc[0];
            A1233MonAbr = P008V6_A1233MonAbr[0];
            n1233MonAbr = P008V6_n1233MonAbr[0];
            A1916TipSAbr = P008V6_A1916TipSAbr[0];
            A243ComCod = P008V6_A243ComCod[0];
            A248ComFec = P008V6_A248ComFec[0];
            A244PrvCod = P008V6_A244PrvCod[0];
            A247PrvDsc = P008V6_A247PrvDsc[0];
            A249ComRef = P008V6_A249ComRef[0];
            A704ComFecPago = P008V6_A704ComFecPago[0];
            A727ComRetCod = P008V6_A727ComRetCod[0];
            A730ComRetFec = P008V6_A730ComRetFec[0];
            A735ComTipReg = P008V6_A735ComTipReg[0];
            A725ComRefTDoc = P008V6_A725ComRefTDoc[0];
            A738ComUsuC = P008V6_A738ComUsuC[0];
            A722ComRefDoc = P008V6_A722ComRefDoc[0];
            A724ComRefFec = P008V6_A724ComRefFec[0];
            A511TipSigno = P008V6_A511TipSigno[0];
            A729ComRete2 = P008V6_A729ComRete2[0];
            A728ComRete1 = P008V6_A728ComRete1[0];
            A732ComSubIna = P008V6_A732ComSubIna[0];
            A719ComIVADUA = P008V6_A719ComIVADUA[0];
            A718ComRedondeo = P008V6_A718ComRedondeo[0];
            A717ComPorIva = P008V6_A717ComPorIva[0];
            A698ComDscto = P008V6_A698ComDscto[0];
            A713ComISC = P008V6_A713ComISC[0];
            A706ComFlete = P008V6_A706ComFlete[0];
            A716ComSubAfe = P008V6_A716ComSubAfe[0];
            A1233MonAbr = P008V6_A1233MonAbr[0];
            n1233MonAbr = P008V6_n1233MonAbr[0];
            A1906TipCmp = P008V6_A1906TipCmp[0];
            A306TipAbr = P008V6_A306TipAbr[0];
            A1910TipDsc = P008V6_A1910TipDsc[0];
            A511TipSigno = P008V6_A511TipSigno[0];
            A157TipSCod = P008V6_A157TipSCod[0];
            n157TipSCod = P008V6_n157TipSCod[0];
            A1916TipSAbr = P008V6_A1916TipSAbr[0];
            A732ComSubIna = P008V6_A732ComSubIna[0];
            A716ComSubAfe = P008V6_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV95TipCod = A149TipCod;
            AV93TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008V6_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK8V5 = false;
               A157TipSCod = P008V6_A157TipSCod[0];
               n157TipSCod = P008V6_n157TipSCod[0];
               A707ComFReg = P008V6_A707ComFReg[0];
               A708ComFVcto = P008V6_A708ComFVcto[0];
               A246ComMon = P008V6_A246ComMon[0];
               A149TipCod = P008V6_A149TipCod[0];
               A1910TipDsc = P008V6_A1910TipDsc[0];
               A1233MonAbr = P008V6_A1233MonAbr[0];
               n1233MonAbr = P008V6_n1233MonAbr[0];
               A1916TipSAbr = P008V6_A1916TipSAbr[0];
               A243ComCod = P008V6_A243ComCod[0];
               A248ComFec = P008V6_A248ComFec[0];
               A244PrvCod = P008V6_A244PrvCod[0];
               A247PrvDsc = P008V6_A247PrvDsc[0];
               A249ComRef = P008V6_A249ComRef[0];
               A704ComFecPago = P008V6_A704ComFecPago[0];
               A727ComRetCod = P008V6_A727ComRetCod[0];
               A730ComRetFec = P008V6_A730ComRetFec[0];
               A735ComTipReg = P008V6_A735ComTipReg[0];
               A725ComRefTDoc = P008V6_A725ComRefTDoc[0];
               A738ComUsuC = P008V6_A738ComUsuC[0];
               A722ComRefDoc = P008V6_A722ComRefDoc[0];
               A724ComRefFec = P008V6_A724ComRefFec[0];
               A511TipSigno = P008V6_A511TipSigno[0];
               A729ComRete2 = P008V6_A729ComRete2[0];
               A728ComRete1 = P008V6_A728ComRete1[0];
               A719ComIVADUA = P008V6_A719ComIVADUA[0];
               A718ComRedondeo = P008V6_A718ComRedondeo[0];
               A717ComPorIva = P008V6_A717ComPorIva[0];
               A698ComDscto = P008V6_A698ComDscto[0];
               A713ComISC = P008V6_A713ComISC[0];
               A706ComFlete = P008V6_A706ComFlete[0];
               A1233MonAbr = P008V6_A1233MonAbr[0];
               n1233MonAbr = P008V6_n1233MonAbr[0];
               A1910TipDsc = P008V6_A1910TipDsc[0];
               A511TipSigno = P008V6_A511TipSigno[0];
               A157TipSCod = P008V6_A157TipSCod[0];
               n157TipSCod = P008V6_n157TipSCod[0];
               A1916TipSAbr = P008V6_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV93TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV8Ano )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV73Mes )
                     {
                        /* Using cursor P008V8 */
                        pr_default.execute(4, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(4) != 101) )
                        {
                           A732ComSubIna = P008V8_A732ComSubIna[0];
                           A716ComSubAfe = P008V8_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(4);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV95TipCod = A149TipCod;
                        AV96TipDsc = A1910TipDsc;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV94TipCmb = "";
                        AV36DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV38DocNum = A243ComCod;
                        AV17ComCod = A243ComCod;
                        AV12AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV13AT1 = (short)(AV12AT-1);
                        AV14AT2 = (short)(AV12AT+1);
                        AV85Serie = ((AV12AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV13AT1));
                        AV38DocNum = ((AV12AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV14AT2, 20));
                        AV9AnoDua = ((StringUtil.StrCmp(AV36DocAbr, "50")==0)||(StringUtil.StrCmp(AV36DocAbr, "52")==0)||(StringUtil.StrCmp(AV36DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV37DocFec = A248ComFec;
                        AV82PrvCod = StringUtil.Trim( A244PrvCod);
                        AV83PrvDsc = StringUtil.Trim( A247PrvDsc);
                        GXt_char1 = AV39DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV95TipCod, ref  AV38DocNum, out  GXt_char1) ;
                        AV39DocSts = GXt_char1;
                        AV23ComRef = A249ComRef;
                        AV20ComFecPago = A704ComFecPago;
                        AV22ComPorIva = A717ComPorIva;
                        AV27ComRetCod = A727ComRetCod;
                        AV28ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV29ComTipReg = A735ComTipReg;
                        AV26ComRefTDoc = A725ComRefTDoc;
                        AV102TRef = "";
                        AV108ComUsuC = A738ComUsuC;
                        AV107CosDsc = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV102TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV102TRef = GXt_char1;
                        }
                        AV24ComRefDoc = A722ComRefDoc;
                        AV25ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P008V6_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV40Dscto = 0.00m;
                        AV67IGV1 = 0.00m;
                        AV68IGV2 = 0.00m;
                        AV69IGV3 = 0.00m;
                        AV100TotalMN = 0.00m;
                        AV101TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV22ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV46Fecha = (((StringUtil.StrCmp(AV36DocAbr, "07")==0)||(StringUtil.StrCmp(AV36DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV37DocFec);
                           if ( (DateTime.MinValue==AV20ComFecPago) )
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV46Fecha, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           else
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV20ComFecPago, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           AV94TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV39DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV40Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV89SubTotal1 = (decimal)(AV88SubTotal-AV40Dscto);
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV67IGV1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           AV68IGV2 = 0.00m;
                           AV69IGV3 = 0.00m;
                           AV100TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV101TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV21ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV21ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV21ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV22ComPorIva) ? (decimal)(1) : AV22ComPorIva)))*100, 2));
                           AV101TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                           AV100TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                        }
                        /* Execute user subroutine: 'DETALLECOMPRAS' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(3);
                           pr_default.close(4);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
               BRK8V5 = true;
               pr_default.readNext(3);
            }
            if ( ! BRK8V5 )
            {
               BRK8V5 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S141( )
      {
         /* 'ORDENADONUMEROREGISTRO' Routine */
         returnInSub = false;
         /* Using cursor P008V10 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK8V7 = false;
            A157TipSCod = P008V10_A157TipSCod[0];
            n157TipSCod = P008V10_n157TipSCod[0];
            A1906TipCmp = P008V10_A1906TipCmp[0];
            A306TipAbr = P008V10_A306TipAbr[0];
            A707ComFReg = P008V10_A707ComFReg[0];
            A708ComFVcto = P008V10_A708ComFVcto[0];
            A246ComMon = P008V10_A246ComMon[0];
            A149TipCod = P008V10_A149TipCod[0];
            A1910TipDsc = P008V10_A1910TipDsc[0];
            A1233MonAbr = P008V10_A1233MonAbr[0];
            n1233MonAbr = P008V10_n1233MonAbr[0];
            A1916TipSAbr = P008V10_A1916TipSAbr[0];
            A243ComCod = P008V10_A243ComCod[0];
            A248ComFec = P008V10_A248ComFec[0];
            A244PrvCod = P008V10_A244PrvCod[0];
            A247PrvDsc = P008V10_A247PrvDsc[0];
            A704ComFecPago = P008V10_A704ComFecPago[0];
            A727ComRetCod = P008V10_A727ComRetCod[0];
            A730ComRetFec = P008V10_A730ComRetFec[0];
            A735ComTipReg = P008V10_A735ComTipReg[0];
            A725ComRefTDoc = P008V10_A725ComRefTDoc[0];
            A738ComUsuC = P008V10_A738ComUsuC[0];
            A722ComRefDoc = P008V10_A722ComRefDoc[0];
            A724ComRefFec = P008V10_A724ComRefFec[0];
            A511TipSigno = P008V10_A511TipSigno[0];
            A249ComRef = P008V10_A249ComRef[0];
            A729ComRete2 = P008V10_A729ComRete2[0];
            A728ComRete1 = P008V10_A728ComRete1[0];
            A732ComSubIna = P008V10_A732ComSubIna[0];
            A719ComIVADUA = P008V10_A719ComIVADUA[0];
            A718ComRedondeo = P008V10_A718ComRedondeo[0];
            A717ComPorIva = P008V10_A717ComPorIva[0];
            A698ComDscto = P008V10_A698ComDscto[0];
            A713ComISC = P008V10_A713ComISC[0];
            A706ComFlete = P008V10_A706ComFlete[0];
            A716ComSubAfe = P008V10_A716ComSubAfe[0];
            A1233MonAbr = P008V10_A1233MonAbr[0];
            n1233MonAbr = P008V10_n1233MonAbr[0];
            A1906TipCmp = P008V10_A1906TipCmp[0];
            A306TipAbr = P008V10_A306TipAbr[0];
            A1910TipDsc = P008V10_A1910TipDsc[0];
            A511TipSigno = P008V10_A511TipSigno[0];
            A157TipSCod = P008V10_A157TipSCod[0];
            n157TipSCod = P008V10_n157TipSCod[0];
            A1916TipSAbr = P008V10_A1916TipSAbr[0];
            A732ComSubIna = P008V10_A732ComSubIna[0];
            A716ComSubAfe = P008V10_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV95TipCod = A149TipCod;
            AV93TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P008V10_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK8V7 = false;
               A157TipSCod = P008V10_A157TipSCod[0];
               n157TipSCod = P008V10_n157TipSCod[0];
               A707ComFReg = P008V10_A707ComFReg[0];
               A708ComFVcto = P008V10_A708ComFVcto[0];
               A246ComMon = P008V10_A246ComMon[0];
               A149TipCod = P008V10_A149TipCod[0];
               A1910TipDsc = P008V10_A1910TipDsc[0];
               A1233MonAbr = P008V10_A1233MonAbr[0];
               n1233MonAbr = P008V10_n1233MonAbr[0];
               A1916TipSAbr = P008V10_A1916TipSAbr[0];
               A243ComCod = P008V10_A243ComCod[0];
               A248ComFec = P008V10_A248ComFec[0];
               A244PrvCod = P008V10_A244PrvCod[0];
               A247PrvDsc = P008V10_A247PrvDsc[0];
               A704ComFecPago = P008V10_A704ComFecPago[0];
               A727ComRetCod = P008V10_A727ComRetCod[0];
               A730ComRetFec = P008V10_A730ComRetFec[0];
               A735ComTipReg = P008V10_A735ComTipReg[0];
               A725ComRefTDoc = P008V10_A725ComRefTDoc[0];
               A738ComUsuC = P008V10_A738ComUsuC[0];
               A722ComRefDoc = P008V10_A722ComRefDoc[0];
               A724ComRefFec = P008V10_A724ComRefFec[0];
               A511TipSigno = P008V10_A511TipSigno[0];
               A249ComRef = P008V10_A249ComRef[0];
               A729ComRete2 = P008V10_A729ComRete2[0];
               A728ComRete1 = P008V10_A728ComRete1[0];
               A719ComIVADUA = P008V10_A719ComIVADUA[0];
               A718ComRedondeo = P008V10_A718ComRedondeo[0];
               A717ComPorIva = P008V10_A717ComPorIva[0];
               A698ComDscto = P008V10_A698ComDscto[0];
               A713ComISC = P008V10_A713ComISC[0];
               A706ComFlete = P008V10_A706ComFlete[0];
               A1233MonAbr = P008V10_A1233MonAbr[0];
               n1233MonAbr = P008V10_n1233MonAbr[0];
               A1910TipDsc = P008V10_A1910TipDsc[0];
               A511TipSigno = P008V10_A511TipSigno[0];
               A157TipSCod = P008V10_A157TipSCod[0];
               n157TipSCod = P008V10_n157TipSCod[0];
               A1916TipSAbr = P008V10_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV93TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV8Ano )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV73Mes )
                     {
                        /* Using cursor P008V12 */
                        pr_default.execute(6, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(6) != 101) )
                        {
                           A732ComSubIna = P008V12_A732ComSubIna[0];
                           A716ComSubAfe = P008V12_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(6);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV95TipCod = A149TipCod;
                        AV96TipDsc = A1910TipDsc;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV94TipCmb = "";
                        AV36DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV38DocNum = A243ComCod;
                        AV17ComCod = A243ComCod;
                        AV12AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV13AT1 = (short)(AV12AT-1);
                        AV14AT2 = (short)(AV12AT+1);
                        AV85Serie = ((AV12AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV13AT1));
                        AV38DocNum = ((AV12AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV14AT2, 20));
                        AV9AnoDua = ((StringUtil.StrCmp(AV36DocAbr, "50")==0)||(StringUtil.StrCmp(AV36DocAbr, "52")==0)||(StringUtil.StrCmp(AV36DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV37DocFec = A248ComFec;
                        AV82PrvCod = StringUtil.Trim( A244PrvCod);
                        AV83PrvDsc = StringUtil.Trim( A247PrvDsc);
                        GXt_char1 = AV39DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV95TipCod, ref  AV38DocNum, out  GXt_char1) ;
                        AV39DocSts = GXt_char1;
                        AV23ComRef = A249ComRef;
                        AV20ComFecPago = A704ComFecPago;
                        AV22ComPorIva = A717ComPorIva;
                        AV27ComRetCod = A727ComRetCod;
                        AV28ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV29ComTipReg = A735ComTipReg;
                        AV26ComRefTDoc = A725ComRefTDoc;
                        AV102TRef = "";
                        AV108ComUsuC = A738ComUsuC;
                        AV107CosDsc = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV102TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV102TRef = GXt_char1;
                        }
                        AV24ComRefDoc = A722ComRefDoc;
                        AV25ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P008V10_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV40Dscto = 0.00m;
                        AV67IGV1 = 0.00m;
                        AV68IGV2 = 0.00m;
                        AV69IGV3 = 0.00m;
                        AV100TotalMN = 0.00m;
                        AV101TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV22ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV46Fecha = (((StringUtil.StrCmp(AV36DocAbr, "07")==0)||(StringUtil.StrCmp(AV36DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV37DocFec);
                           if ( (DateTime.MinValue==AV20ComFecPago) )
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV46Fecha, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           else
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV20ComFecPago, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           AV94TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV39DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV40Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV89SubTotal1 = (decimal)(AV88SubTotal-AV40Dscto);
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV67IGV1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           AV68IGV2 = 0.00m;
                           AV69IGV3 = 0.00m;
                           AV100TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV101TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV21ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV21ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV21ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV22ComPorIva) ? (decimal)(1) : AV22ComPorIva)))*100, 2));
                           AV101TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                           AV100TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                        }
                        /* Execute user subroutine: 'DETALLECOMPRAS' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(5);
                           pr_default.close(6);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
               BRK8V7 = true;
               pr_default.readNext(5);
            }
            if ( ! BRK8V7 )
            {
               BRK8V7 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S151( )
      {
         /* 'ORDENADOFECHAEMISION' Routine */
         returnInSub = false;
         /* Using cursor P008V14 */
         pr_default.execute(7);
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK8V9 = false;
            A157TipSCod = P008V14_A157TipSCod[0];
            n157TipSCod = P008V14_n157TipSCod[0];
            A1906TipCmp = P008V14_A1906TipCmp[0];
            A306TipAbr = P008V14_A306TipAbr[0];
            A707ComFReg = P008V14_A707ComFReg[0];
            A708ComFVcto = P008V14_A708ComFVcto[0];
            A246ComMon = P008V14_A246ComMon[0];
            A149TipCod = P008V14_A149TipCod[0];
            A1910TipDsc = P008V14_A1910TipDsc[0];
            A1233MonAbr = P008V14_A1233MonAbr[0];
            n1233MonAbr = P008V14_n1233MonAbr[0];
            A1916TipSAbr = P008V14_A1916TipSAbr[0];
            A243ComCod = P008V14_A243ComCod[0];
            A244PrvCod = P008V14_A244PrvCod[0];
            A247PrvDsc = P008V14_A247PrvDsc[0];
            A249ComRef = P008V14_A249ComRef[0];
            A704ComFecPago = P008V14_A704ComFecPago[0];
            A727ComRetCod = P008V14_A727ComRetCod[0];
            A730ComRetFec = P008V14_A730ComRetFec[0];
            A735ComTipReg = P008V14_A735ComTipReg[0];
            A725ComRefTDoc = P008V14_A725ComRefTDoc[0];
            A738ComUsuC = P008V14_A738ComUsuC[0];
            A722ComRefDoc = P008V14_A722ComRefDoc[0];
            A724ComRefFec = P008V14_A724ComRefFec[0];
            A511TipSigno = P008V14_A511TipSigno[0];
            A248ComFec = P008V14_A248ComFec[0];
            A729ComRete2 = P008V14_A729ComRete2[0];
            A728ComRete1 = P008V14_A728ComRete1[0];
            A732ComSubIna = P008V14_A732ComSubIna[0];
            A719ComIVADUA = P008V14_A719ComIVADUA[0];
            A718ComRedondeo = P008V14_A718ComRedondeo[0];
            A717ComPorIva = P008V14_A717ComPorIva[0];
            A698ComDscto = P008V14_A698ComDscto[0];
            A713ComISC = P008V14_A713ComISC[0];
            A706ComFlete = P008V14_A706ComFlete[0];
            A716ComSubAfe = P008V14_A716ComSubAfe[0];
            A1233MonAbr = P008V14_A1233MonAbr[0];
            n1233MonAbr = P008V14_n1233MonAbr[0];
            A1906TipCmp = P008V14_A1906TipCmp[0];
            A306TipAbr = P008V14_A306TipAbr[0];
            A1910TipDsc = P008V14_A1910TipDsc[0];
            A511TipSigno = P008V14_A511TipSigno[0];
            A157TipSCod = P008V14_A157TipSCod[0];
            n157TipSCod = P008V14_n157TipSCod[0];
            A1916TipSAbr = P008V14_A1916TipSAbr[0];
            A732ComSubIna = P008V14_A732ComSubIna[0];
            A716ComSubAfe = P008V14_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV95TipCod = A149TipCod;
            AV93TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P008V14_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK8V9 = false;
               A157TipSCod = P008V14_A157TipSCod[0];
               n157TipSCod = P008V14_n157TipSCod[0];
               A707ComFReg = P008V14_A707ComFReg[0];
               A708ComFVcto = P008V14_A708ComFVcto[0];
               A246ComMon = P008V14_A246ComMon[0];
               A149TipCod = P008V14_A149TipCod[0];
               A1910TipDsc = P008V14_A1910TipDsc[0];
               A1233MonAbr = P008V14_A1233MonAbr[0];
               n1233MonAbr = P008V14_n1233MonAbr[0];
               A1916TipSAbr = P008V14_A1916TipSAbr[0];
               A243ComCod = P008V14_A243ComCod[0];
               A244PrvCod = P008V14_A244PrvCod[0];
               A247PrvDsc = P008V14_A247PrvDsc[0];
               A249ComRef = P008V14_A249ComRef[0];
               A704ComFecPago = P008V14_A704ComFecPago[0];
               A727ComRetCod = P008V14_A727ComRetCod[0];
               A730ComRetFec = P008V14_A730ComRetFec[0];
               A735ComTipReg = P008V14_A735ComTipReg[0];
               A725ComRefTDoc = P008V14_A725ComRefTDoc[0];
               A738ComUsuC = P008V14_A738ComUsuC[0];
               A722ComRefDoc = P008V14_A722ComRefDoc[0];
               A724ComRefFec = P008V14_A724ComRefFec[0];
               A511TipSigno = P008V14_A511TipSigno[0];
               A248ComFec = P008V14_A248ComFec[0];
               A729ComRete2 = P008V14_A729ComRete2[0];
               A728ComRete1 = P008V14_A728ComRete1[0];
               A719ComIVADUA = P008V14_A719ComIVADUA[0];
               A718ComRedondeo = P008V14_A718ComRedondeo[0];
               A717ComPorIva = P008V14_A717ComPorIva[0];
               A698ComDscto = P008V14_A698ComDscto[0];
               A713ComISC = P008V14_A713ComISC[0];
               A706ComFlete = P008V14_A706ComFlete[0];
               A1233MonAbr = P008V14_A1233MonAbr[0];
               n1233MonAbr = P008V14_n1233MonAbr[0];
               A1910TipDsc = P008V14_A1910TipDsc[0];
               A511TipSigno = P008V14_A511TipSigno[0];
               A157TipSCod = P008V14_A157TipSCod[0];
               n157TipSCod = P008V14_n157TipSCod[0];
               A1916TipSAbr = P008V14_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV93TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV8Ano )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV73Mes )
                     {
                        /* Using cursor P008V16 */
                        pr_default.execute(8, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(8) != 101) )
                        {
                           A732ComSubIna = P008V16_A732ComSubIna[0];
                           A716ComSubAfe = P008V16_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(8);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV95TipCod = A149TipCod;
                        AV96TipDsc = A1910TipDsc;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV94TipCmb = "";
                        AV36DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV38DocNum = A243ComCod;
                        AV17ComCod = A243ComCod;
                        AV12AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV13AT1 = (short)(AV12AT-1);
                        AV14AT2 = (short)(AV12AT+1);
                        AV85Serie = ((AV12AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV13AT1));
                        AV38DocNum = ((AV12AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV14AT2, 20));
                        AV9AnoDua = ((StringUtil.StrCmp(AV36DocAbr, "50")==0)||(StringUtil.StrCmp(AV36DocAbr, "52")==0)||(StringUtil.StrCmp(AV36DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV37DocFec = A248ComFec;
                        AV82PrvCod = StringUtil.Trim( A244PrvCod);
                        AV83PrvDsc = StringUtil.Trim( A247PrvDsc);
                        GXt_char1 = AV39DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV95TipCod, ref  AV38DocNum, out  GXt_char1) ;
                        AV39DocSts = GXt_char1;
                        AV23ComRef = A249ComRef;
                        AV20ComFecPago = A704ComFecPago;
                        AV22ComPorIva = A717ComPorIva;
                        AV27ComRetCod = A727ComRetCod;
                        AV28ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV29ComTipReg = A735ComTipReg;
                        AV26ComRefTDoc = A725ComRefTDoc;
                        AV102TRef = "";
                        AV108ComUsuC = A738ComUsuC;
                        AV107CosDsc = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV102TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV102TRef = GXt_char1;
                        }
                        AV24ComRefDoc = A722ComRefDoc;
                        AV25ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P008V14_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV40Dscto = 0.00m;
                        AV67IGV1 = 0.00m;
                        AV68IGV2 = 0.00m;
                        AV69IGV3 = 0.00m;
                        AV100TotalMN = 0.00m;
                        AV101TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV22ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV46Fecha = (((StringUtil.StrCmp(AV36DocAbr, "07")==0)||(StringUtil.StrCmp(AV36DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV37DocFec);
                           if ( (DateTime.MinValue==AV20ComFecPago) )
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV46Fecha, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           else
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV20ComFecPago, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           AV94TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV39DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV40Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV89SubTotal1 = (decimal)(AV88SubTotal-AV40Dscto);
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV67IGV1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           AV68IGV2 = 0.00m;
                           AV69IGV3 = 0.00m;
                           AV100TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV101TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV21ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV21ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV21ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV22ComPorIva) ? (decimal)(1) : AV22ComPorIva)))*100, 2));
                           AV101TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                           AV100TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                        }
                        /* Execute user subroutine: 'DETALLECOMPRAS' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(7);
                           pr_default.close(8);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
               BRK8V9 = true;
               pr_default.readNext(7);
            }
            if ( ! BRK8V9 )
            {
               BRK8V9 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S161( )
      {
         /* 'ORDENADOPROVEEDOR' Routine */
         returnInSub = false;
         /* Using cursor P008V18 */
         pr_default.execute(9);
         while ( (pr_default.getStatus(9) != 101) )
         {
            BRK8V11 = false;
            A157TipSCod = P008V18_A157TipSCod[0];
            n157TipSCod = P008V18_n157TipSCod[0];
            A1906TipCmp = P008V18_A1906TipCmp[0];
            A306TipAbr = P008V18_A306TipAbr[0];
            A707ComFReg = P008V18_A707ComFReg[0];
            A708ComFVcto = P008V18_A708ComFVcto[0];
            A246ComMon = P008V18_A246ComMon[0];
            A149TipCod = P008V18_A149TipCod[0];
            A1910TipDsc = P008V18_A1910TipDsc[0];
            A1233MonAbr = P008V18_A1233MonAbr[0];
            n1233MonAbr = P008V18_n1233MonAbr[0];
            A1916TipSAbr = P008V18_A1916TipSAbr[0];
            A243ComCod = P008V18_A243ComCod[0];
            A248ComFec = P008V18_A248ComFec[0];
            A244PrvCod = P008V18_A244PrvCod[0];
            A249ComRef = P008V18_A249ComRef[0];
            A704ComFecPago = P008V18_A704ComFecPago[0];
            A727ComRetCod = P008V18_A727ComRetCod[0];
            A730ComRetFec = P008V18_A730ComRetFec[0];
            A735ComTipReg = P008V18_A735ComTipReg[0];
            A725ComRefTDoc = P008V18_A725ComRefTDoc[0];
            A738ComUsuC = P008V18_A738ComUsuC[0];
            A722ComRefDoc = P008V18_A722ComRefDoc[0];
            A724ComRefFec = P008V18_A724ComRefFec[0];
            A511TipSigno = P008V18_A511TipSigno[0];
            A247PrvDsc = P008V18_A247PrvDsc[0];
            A729ComRete2 = P008V18_A729ComRete2[0];
            A728ComRete1 = P008V18_A728ComRete1[0];
            A732ComSubIna = P008V18_A732ComSubIna[0];
            A719ComIVADUA = P008V18_A719ComIVADUA[0];
            A718ComRedondeo = P008V18_A718ComRedondeo[0];
            A717ComPorIva = P008V18_A717ComPorIva[0];
            A698ComDscto = P008V18_A698ComDscto[0];
            A713ComISC = P008V18_A713ComISC[0];
            A706ComFlete = P008V18_A706ComFlete[0];
            A716ComSubAfe = P008V18_A716ComSubAfe[0];
            A1233MonAbr = P008V18_A1233MonAbr[0];
            n1233MonAbr = P008V18_n1233MonAbr[0];
            A1906TipCmp = P008V18_A1906TipCmp[0];
            A306TipAbr = P008V18_A306TipAbr[0];
            A1910TipDsc = P008V18_A1910TipDsc[0];
            A511TipSigno = P008V18_A511TipSigno[0];
            A157TipSCod = P008V18_A157TipSCod[0];
            n157TipSCod = P008V18_n157TipSCod[0];
            A1916TipSAbr = P008V18_A1916TipSAbr[0];
            A732ComSubIna = P008V18_A732ComSubIna[0];
            A716ComSubAfe = P008V18_A716ComSubAfe[0];
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AV95TipCod = A149TipCod;
            AV93TipAbr = A306TipAbr;
            while ( (pr_default.getStatus(9) != 101) && ( StringUtil.StrCmp(P008V18_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK8V11 = false;
               A157TipSCod = P008V18_A157TipSCod[0];
               n157TipSCod = P008V18_n157TipSCod[0];
               A707ComFReg = P008V18_A707ComFReg[0];
               A708ComFVcto = P008V18_A708ComFVcto[0];
               A246ComMon = P008V18_A246ComMon[0];
               A149TipCod = P008V18_A149TipCod[0];
               A1910TipDsc = P008V18_A1910TipDsc[0];
               A1233MonAbr = P008V18_A1233MonAbr[0];
               n1233MonAbr = P008V18_n1233MonAbr[0];
               A1916TipSAbr = P008V18_A1916TipSAbr[0];
               A243ComCod = P008V18_A243ComCod[0];
               A248ComFec = P008V18_A248ComFec[0];
               A244PrvCod = P008V18_A244PrvCod[0];
               A249ComRef = P008V18_A249ComRef[0];
               A704ComFecPago = P008V18_A704ComFecPago[0];
               A727ComRetCod = P008V18_A727ComRetCod[0];
               A730ComRetFec = P008V18_A730ComRetFec[0];
               A735ComTipReg = P008V18_A735ComTipReg[0];
               A725ComRefTDoc = P008V18_A725ComRefTDoc[0];
               A738ComUsuC = P008V18_A738ComUsuC[0];
               A722ComRefDoc = P008V18_A722ComRefDoc[0];
               A724ComRefFec = P008V18_A724ComRefFec[0];
               A511TipSigno = P008V18_A511TipSigno[0];
               A247PrvDsc = P008V18_A247PrvDsc[0];
               A729ComRete2 = P008V18_A729ComRete2[0];
               A728ComRete1 = P008V18_A728ComRete1[0];
               A719ComIVADUA = P008V18_A719ComIVADUA[0];
               A718ComRedondeo = P008V18_A718ComRedondeo[0];
               A717ComPorIva = P008V18_A717ComPorIva[0];
               A698ComDscto = P008V18_A698ComDscto[0];
               A713ComISC = P008V18_A713ComISC[0];
               A706ComFlete = P008V18_A706ComFlete[0];
               A1233MonAbr = P008V18_A1233MonAbr[0];
               n1233MonAbr = P008V18_n1233MonAbr[0];
               A1910TipDsc = P008V18_A1910TipDsc[0];
               A511TipSigno = P008V18_A511TipSigno[0];
               A157TipSCod = P008V18_A157TipSCod[0];
               n157TipSCod = P008V18_n157TipSCod[0];
               A1916TipSAbr = P008V18_A1916TipSAbr[0];
               if ( StringUtil.StrCmp(A306TipAbr, AV93TipAbr) == 0 )
               {
                  if ( DateTimeUtil.Year( A707ComFReg) == AV8Ano )
                  {
                     if ( DateTimeUtil.Month( A707ComFReg) == AV73Mes )
                     {
                        /* Using cursor P008V20 */
                        pr_default.execute(10, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                        if ( (pr_default.getStatus(10) != 101) )
                        {
                           A732ComSubIna = P008V20_A732ComSubIna[0];
                           A716ComSubAfe = P008V20_A716ComSubAfe[0];
                        }
                        else
                        {
                           A716ComSubAfe = 0;
                           A732ComSubIna = 0;
                        }
                        pr_default.close(10);
                        A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
                        A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
                        A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
                        AV75MonCod = A246ComMon;
                        AV95TipCod = A149TipCod;
                        AV96TipDsc = A1910TipDsc;
                        AV74MonAbr = A1233MonAbr;
                        AV99TipVenta = 1.00000m;
                        AV94TipCmb = "";
                        AV36DocAbr = A306TipAbr;
                        AV98TipSunat = StringUtil.Trim( A1916TipSAbr);
                        AV38DocNum = A243ComCod;
                        AV17ComCod = A243ComCod;
                        AV12AT = (decimal)(StringUtil.StringSearch( A243ComCod, "-", 1));
                        AV13AT1 = (short)(AV12AT-1);
                        AV14AT2 = (short)(AV12AT+1);
                        AV85Serie = ((AV12AT==Convert.ToDecimal(0)) ? "" : StringUtil.Substring( A243ComCod, 1, AV13AT1));
                        AV38DocNum = ((AV12AT==Convert.ToDecimal(0)) ? A243ComCod : StringUtil.Substring( A243ComCod, AV14AT2, 20));
                        AV9AnoDua = ((StringUtil.StrCmp(AV36DocAbr, "50")==0)||(StringUtil.StrCmp(AV36DocAbr, "52")==0)||(StringUtil.StrCmp(AV36DocAbr, "53")==0) ? StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( A248ComFec)), 10, 0)) : "");
                        AV37DocFec = A248ComFec;
                        AV82PrvCod = StringUtil.Trim( A244PrvCod);
                        AV83PrvDsc = StringUtil.Trim( A247PrvDsc);
                        GXt_char1 = AV39DocSts;
                        new GeneXus.Programs.compras.pobtieneestadodocumento(context ).execute( ref  AV82PrvCod, ref  AV95TipCod, ref  AV38DocNum, out  GXt_char1) ;
                        AV39DocSts = GXt_char1;
                        AV23ComRef = A249ComRef;
                        AV20ComFecPago = A704ComFecPago;
                        AV22ComPorIva = A717ComPorIva;
                        AV27ComRetCod = A727ComRetCod;
                        AV28ComRetFec = ((DateTime.MinValue==A730ComRetFec) ? "" : context.localUtil.DToC( A730ComRetFec, 2, "/"));
                        AV29ComTipReg = A735ComTipReg;
                        AV26ComRefTDoc = A725ComRefTDoc;
                        AV102TRef = "";
                        AV108ComUsuC = A738ComUsuC;
                        AV107CosDsc = "";
                        if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A725ComRefTDoc)) )
                        {
                           GXt_char1 = AV102TRef;
                           new GeneXus.Programs.generales.obtienetipodocumentosunat(context ).execute( ref  A725ComRefTDoc, out  GXt_char1) ;
                           AV102TRef = GXt_char1;
                        }
                        AV24ComRefDoc = A722ComRefDoc;
                        AV25ComRefFec = ((DateTime.MinValue==A724ComRefFec)||P008V18_n724ComRefFec[0] ? "" : context.localUtil.DToC( A724ComRefFec, 2, "/"));
                        AV89SubTotal1 = 0.00m;
                        AV90SubTotal2 = 0.00m;
                        AV91SubTotal3 = 0.00m;
                        AV87SubIna = 0.00m;
                        AV40Dscto = 0.00m;
                        AV67IGV1 = 0.00m;
                        AV68IGV2 = 0.00m;
                        AV69IGV3 = 0.00m;
                        AV100TotalMN = 0.00m;
                        AV101TotalMO = 0.00m;
                        AV70ISC = 0.00m;
                        AV22ComPorIva = A717ComPorIva;
                        if ( AV75MonCod != 1 )
                        {
                           AV46Fecha = (((StringUtil.StrCmp(AV36DocAbr, "07")==0)||(StringUtil.StrCmp(AV36DocAbr, "08")==0))&&!(DateTime.MinValue==A724ComRefFec) ? A724ComRefFec : AV37DocFec);
                           if ( (DateTime.MinValue==AV20ComFecPago) )
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV46Fecha, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           else
                           {
                              GXt_decimal3 = AV99TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV75MonCod, ref  AV20ComFecPago, ref  GXt_char1, out  GXt_decimal3) ;
                              AV99TipVenta = GXt_decimal3;
                           }
                           AV94TipCmb = StringUtil.Trim( StringUtil.Str( AV99TipVenta, 10, 5));
                        }
                        if ( StringUtil.StrCmp(AV39DocSts, "A") != 0 )
                        {
                           AV88SubTotal = (decimal)((NumberUtil.Round( A716ComSubAfe, 2)*AV99TipVenta)*A511TipSigno);
                           AV87SubIna = (decimal)((NumberUtil.Round( A732ComSubIna, 2)*AV99TipVenta)*A511TipSigno);
                           AV40Dscto = (decimal)((NumberUtil.Round( A698ComDscto, 2)*AV99TipVenta)*A511TipSigno);
                           AV70ISC = (decimal)((NumberUtil.Round( A713ComISC, 2)*AV99TipVenta)*A511TipSigno);
                           AV89SubTotal1 = (decimal)(AV88SubTotal-AV40Dscto);
                           AV90SubTotal2 = 0.00m;
                           AV91SubTotal3 = 0.00m;
                           AV67IGV1 = (decimal)((NumberUtil.Round( A715ComIva, 2)*AV99TipVenta)*A511TipSigno);
                           AV68IGV2 = 0.00m;
                           AV69IGV3 = 0.00m;
                           AV100TotalMN = (decimal)((NumberUtil.Round( A736ComTotal, 2)*AV99TipVenta)*A511TipSigno);
                           AV101TotalMO = NumberUtil.Round( A736ComTotal, 2);
                        }
                        AV21ComIVADUA = (decimal)((NumberUtil.Round( A719ComIVADUA, 2)*AV99TipVenta)*A511TipSigno);
                        if ( ! (Convert.ToDecimal(0)==AV21ComIVADUA) )
                        {
                           AV89SubTotal1 = (decimal)(AV89SubTotal1+NumberUtil.Round( (AV21ComIVADUA/ (decimal)(((Convert.ToDecimal(0)==AV22ComPorIva) ? (decimal)(1) : AV22ComPorIva)))*100, 2));
                           AV101TotalMO = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                           AV100TotalMN = (decimal)(AV89SubTotal1+AV87SubIna+AV67IGV1+AV68IGV2+AV69IGV3);
                        }
                        /* Execute user subroutine: 'DETALLECOMPRAS' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(9);
                           pr_default.close(10);
                           returnInSub = true;
                           if (true) return;
                        }
                     }
                  }
               }
               BRK8V11 = true;
               pr_default.readNext(9);
            }
            if ( ! BRK8V11 )
            {
               BRK8V11 = true;
               pr_default.readNext(9);
            }
         }
         pr_default.close(9);
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
         pr_default.close(10);
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         AV50Filename = "";
         AV42ErrorMessage = "";
         AV41Empresa = "";
         AV86Session = context.GetSession();
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV81Path = "";
         AV51FilenameOrigen = "";
         AV45ExcelDocument = new ExcelDocumentI();
         AV16cMes = "";
         AV18ComDCueCod = "";
         AV19ComDDsc = "";
         scmdbuf = "";
         AV95TipCod = "";
         AV17ComCod = "";
         AV82PrvCod = "";
         P008V2_A244PrvCod = new string[] {""} ;
         P008V2_A243ComCod = new string[] {""} ;
         P008V2_A149TipCod = new string[] {""} ;
         P008V2_A251ComDOrdCod = new string[] {""} ;
         P008V2_A254ComDProCod = new string[] {""} ;
         P008V2_n254ComDProCod = new bool[] {false} ;
         P008V2_A253ComDCueCod = new string[] {""} ;
         P008V2_n253ComDCueCod = new bool[] {false} ;
         P008V2_A694ComDDsc = new string[] {""} ;
         P008V2_A250ComDItem = new short[1] ;
         A244PrvCod = "";
         A243ComCod = "";
         A149TipCod = "";
         A251ComDOrdCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A694ComDDsc = "";
         P008V3_A252ComCosCod = new string[] {""} ;
         P008V3_n252ComCosCod = new bool[] {false} ;
         P008V3_A244PrvCod = new string[] {""} ;
         P008V3_A243ComCod = new string[] {""} ;
         P008V3_A149TipCod = new string[] {""} ;
         P008V3_A761COSDsc = new string[] {""} ;
         P008V3_n761COSDsc = new bool[] {false} ;
         P008V3_A250ComDItem = new short[1] ;
         P008V3_A251ComDOrdCod = new string[] {""} ;
         A252ComCosCod = "";
         A761COSDsc = "";
         AV107CosDsc = "";
         AV43Estado = "";
         P008V4_A262CPPrvCod = new string[] {""} ;
         P008V4_A261CPComCod = new string[] {""} ;
         P008V4_A260CPTipCod = new string[] {""} ;
         P008V4_A815CPEstado = new string[] {""} ;
         A262CPPrvCod = "";
         A261CPComCod = "";
         A260CPTipCod = "";
         A815CPEstado = "";
         AV23ComRef = "";
         AV37DocFec = DateTime.MinValue;
         AV20ComFecPago = DateTime.MinValue;
         GXt_dtime2 = (DateTime)(DateTime.MinValue);
         AV36DocAbr = "";
         AV85Serie = "";
         AV9AnoDua = "";
         AV38DocNum = "";
         AV98TipSunat = "";
         AV83PrvDsc = "";
         AV94TipCmb = "";
         AV28ComRetFec = "";
         AV27ComRetCod = "";
         AV25ComRefFec = "";
         AV102TRef = "";
         AV24ComRefDoc = "";
         AV96TipDsc = "";
         AV108ComUsuC = "";
         P008V6_A157TipSCod = new int[1] ;
         P008V6_n157TipSCod = new bool[] {false} ;
         P008V6_A1906TipCmp = new short[1] ;
         P008V6_A306TipAbr = new string[] {""} ;
         P008V6_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P008V6_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P008V6_A246ComMon = new int[1] ;
         P008V6_A149TipCod = new string[] {""} ;
         P008V6_A1910TipDsc = new string[] {""} ;
         P008V6_A1233MonAbr = new string[] {""} ;
         P008V6_n1233MonAbr = new bool[] {false} ;
         P008V6_A1916TipSAbr = new string[] {""} ;
         P008V6_A243ComCod = new string[] {""} ;
         P008V6_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P008V6_A244PrvCod = new string[] {""} ;
         P008V6_A247PrvDsc = new string[] {""} ;
         P008V6_A249ComRef = new string[] {""} ;
         P008V6_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P008V6_A727ComRetCod = new string[] {""} ;
         P008V6_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P008V6_A735ComTipReg = new string[] {""} ;
         P008V6_A725ComRefTDoc = new string[] {""} ;
         P008V6_A738ComUsuC = new string[] {""} ;
         P008V6_A722ComRefDoc = new string[] {""} ;
         P008V6_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P008V6_A511TipSigno = new short[1] ;
         P008V6_A729ComRete2 = new decimal[1] ;
         P008V6_A728ComRete1 = new decimal[1] ;
         P008V6_A732ComSubIna = new decimal[1] ;
         P008V6_A719ComIVADUA = new decimal[1] ;
         P008V6_A718ComRedondeo = new decimal[1] ;
         P008V6_A717ComPorIva = new decimal[1] ;
         P008V6_A698ComDscto = new decimal[1] ;
         P008V6_A713ComISC = new decimal[1] ;
         P008V6_A706ComFlete = new decimal[1] ;
         P008V6_A716ComSubAfe = new decimal[1] ;
         A306TipAbr = "";
         A707ComFReg = DateTime.MinValue;
         A708ComFVcto = DateTime.MinValue;
         A1910TipDsc = "";
         A1233MonAbr = "";
         A1916TipSAbr = "";
         A248ComFec = DateTime.MinValue;
         A247PrvDsc = "";
         A249ComRef = "";
         A704ComFecPago = DateTime.MinValue;
         A727ComRetCod = "";
         A730ComRetFec = DateTime.MinValue;
         A735ComTipReg = "";
         A725ComRefTDoc = "";
         A738ComUsuC = "";
         A722ComRefDoc = "";
         A724ComRefFec = DateTime.MinValue;
         AV93TipAbr = "";
         P008V8_A732ComSubIna = new decimal[1] ;
         P008V8_A716ComSubAfe = new decimal[1] ;
         AV74MonAbr = "";
         AV39DocSts = "";
         AV29ComTipReg = "";
         AV26ComRefTDoc = "";
         P008V6_n724ComRefFec = new bool[] {false} ;
         AV46Fecha = DateTime.MinValue;
         P008V10_A157TipSCod = new int[1] ;
         P008V10_n157TipSCod = new bool[] {false} ;
         P008V10_A1906TipCmp = new short[1] ;
         P008V10_A306TipAbr = new string[] {""} ;
         P008V10_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P008V10_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P008V10_A246ComMon = new int[1] ;
         P008V10_A149TipCod = new string[] {""} ;
         P008V10_A1910TipDsc = new string[] {""} ;
         P008V10_A1233MonAbr = new string[] {""} ;
         P008V10_n1233MonAbr = new bool[] {false} ;
         P008V10_A1916TipSAbr = new string[] {""} ;
         P008V10_A243ComCod = new string[] {""} ;
         P008V10_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P008V10_A244PrvCod = new string[] {""} ;
         P008V10_A247PrvDsc = new string[] {""} ;
         P008V10_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P008V10_A727ComRetCod = new string[] {""} ;
         P008V10_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P008V10_A735ComTipReg = new string[] {""} ;
         P008V10_A725ComRefTDoc = new string[] {""} ;
         P008V10_A738ComUsuC = new string[] {""} ;
         P008V10_A722ComRefDoc = new string[] {""} ;
         P008V10_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P008V10_A511TipSigno = new short[1] ;
         P008V10_A249ComRef = new string[] {""} ;
         P008V10_A729ComRete2 = new decimal[1] ;
         P008V10_A728ComRete1 = new decimal[1] ;
         P008V10_A732ComSubIna = new decimal[1] ;
         P008V10_A719ComIVADUA = new decimal[1] ;
         P008V10_A718ComRedondeo = new decimal[1] ;
         P008V10_A717ComPorIva = new decimal[1] ;
         P008V10_A698ComDscto = new decimal[1] ;
         P008V10_A713ComISC = new decimal[1] ;
         P008V10_A706ComFlete = new decimal[1] ;
         P008V10_A716ComSubAfe = new decimal[1] ;
         P008V12_A732ComSubIna = new decimal[1] ;
         P008V12_A716ComSubAfe = new decimal[1] ;
         P008V10_n724ComRefFec = new bool[] {false} ;
         P008V14_A157TipSCod = new int[1] ;
         P008V14_n157TipSCod = new bool[] {false} ;
         P008V14_A1906TipCmp = new short[1] ;
         P008V14_A306TipAbr = new string[] {""} ;
         P008V14_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P008V14_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P008V14_A246ComMon = new int[1] ;
         P008V14_A149TipCod = new string[] {""} ;
         P008V14_A1910TipDsc = new string[] {""} ;
         P008V14_A1233MonAbr = new string[] {""} ;
         P008V14_n1233MonAbr = new bool[] {false} ;
         P008V14_A1916TipSAbr = new string[] {""} ;
         P008V14_A243ComCod = new string[] {""} ;
         P008V14_A244PrvCod = new string[] {""} ;
         P008V14_A247PrvDsc = new string[] {""} ;
         P008V14_A249ComRef = new string[] {""} ;
         P008V14_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P008V14_A727ComRetCod = new string[] {""} ;
         P008V14_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P008V14_A735ComTipReg = new string[] {""} ;
         P008V14_A725ComRefTDoc = new string[] {""} ;
         P008V14_A738ComUsuC = new string[] {""} ;
         P008V14_A722ComRefDoc = new string[] {""} ;
         P008V14_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P008V14_A511TipSigno = new short[1] ;
         P008V14_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P008V14_A729ComRete2 = new decimal[1] ;
         P008V14_A728ComRete1 = new decimal[1] ;
         P008V14_A732ComSubIna = new decimal[1] ;
         P008V14_A719ComIVADUA = new decimal[1] ;
         P008V14_A718ComRedondeo = new decimal[1] ;
         P008V14_A717ComPorIva = new decimal[1] ;
         P008V14_A698ComDscto = new decimal[1] ;
         P008V14_A713ComISC = new decimal[1] ;
         P008V14_A706ComFlete = new decimal[1] ;
         P008V14_A716ComSubAfe = new decimal[1] ;
         P008V16_A732ComSubIna = new decimal[1] ;
         P008V16_A716ComSubAfe = new decimal[1] ;
         P008V14_n724ComRefFec = new bool[] {false} ;
         P008V18_A157TipSCod = new int[1] ;
         P008V18_n157TipSCod = new bool[] {false} ;
         P008V18_A1906TipCmp = new short[1] ;
         P008V18_A306TipAbr = new string[] {""} ;
         P008V18_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         P008V18_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         P008V18_A246ComMon = new int[1] ;
         P008V18_A149TipCod = new string[] {""} ;
         P008V18_A1910TipDsc = new string[] {""} ;
         P008V18_A1233MonAbr = new string[] {""} ;
         P008V18_n1233MonAbr = new bool[] {false} ;
         P008V18_A1916TipSAbr = new string[] {""} ;
         P008V18_A243ComCod = new string[] {""} ;
         P008V18_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         P008V18_A244PrvCod = new string[] {""} ;
         P008V18_A249ComRef = new string[] {""} ;
         P008V18_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         P008V18_A727ComRetCod = new string[] {""} ;
         P008V18_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         P008V18_A735ComTipReg = new string[] {""} ;
         P008V18_A725ComRefTDoc = new string[] {""} ;
         P008V18_A738ComUsuC = new string[] {""} ;
         P008V18_A722ComRefDoc = new string[] {""} ;
         P008V18_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         P008V18_A511TipSigno = new short[1] ;
         P008V18_A247PrvDsc = new string[] {""} ;
         P008V18_A729ComRete2 = new decimal[1] ;
         P008V18_A728ComRete1 = new decimal[1] ;
         P008V18_A732ComSubIna = new decimal[1] ;
         P008V18_A719ComIVADUA = new decimal[1] ;
         P008V18_A718ComRedondeo = new decimal[1] ;
         P008V18_A717ComPorIva = new decimal[1] ;
         P008V18_A698ComDscto = new decimal[1] ;
         P008V18_A713ComISC = new decimal[1] ;
         P008V18_A706ComFlete = new decimal[1] ;
         P008V18_A716ComSubAfe = new decimal[1] ;
         P008V20_A732ComSubIna = new decimal[1] ;
         P008V20_A716ComSubAfe = new decimal[1] ;
         P008V18_n724ComRefFec = new bool[] {false} ;
         GXt_char1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pregistrocomprasexcel__default(),
            new Object[][] {
                new Object[] {
               P008V2_A244PrvCod, P008V2_A243ComCod, P008V2_A149TipCod, P008V2_A251ComDOrdCod, P008V2_A254ComDProCod, P008V2_n254ComDProCod, P008V2_A253ComDCueCod, P008V2_n253ComDCueCod, P008V2_A694ComDDsc, P008V2_A250ComDItem
               }
               , new Object[] {
               P008V3_A252ComCosCod, P008V3_n252ComCosCod, P008V3_A244PrvCod, P008V3_A243ComCod, P008V3_A149TipCod, P008V3_A761COSDsc, P008V3_n761COSDsc, P008V3_A250ComDItem, P008V3_A251ComDOrdCod
               }
               , new Object[] {
               P008V4_A262CPPrvCod, P008V4_A261CPComCod, P008V4_A260CPTipCod, P008V4_A815CPEstado
               }
               , new Object[] {
               P008V6_A157TipSCod, P008V6_n157TipSCod, P008V6_A1906TipCmp, P008V6_A306TipAbr, P008V6_A707ComFReg, P008V6_A708ComFVcto, P008V6_A246ComMon, P008V6_A149TipCod, P008V6_A1910TipDsc, P008V6_A1233MonAbr,
               P008V6_n1233MonAbr, P008V6_A1916TipSAbr, P008V6_A243ComCod, P008V6_A248ComFec, P008V6_A244PrvCod, P008V6_A247PrvDsc, P008V6_A249ComRef, P008V6_A704ComFecPago, P008V6_A727ComRetCod, P008V6_A730ComRetFec,
               P008V6_A735ComTipReg, P008V6_A725ComRefTDoc, P008V6_A738ComUsuC, P008V6_A722ComRefDoc, P008V6_A724ComRefFec, P008V6_A511TipSigno, P008V6_A729ComRete2, P008V6_A728ComRete1, P008V6_A732ComSubIna, P008V6_A719ComIVADUA,
               P008V6_A718ComRedondeo, P008V6_A717ComPorIva, P008V6_A698ComDscto, P008V6_A713ComISC, P008V6_A706ComFlete, P008V6_A716ComSubAfe
               }
               , new Object[] {
               P008V8_A732ComSubIna, P008V8_A716ComSubAfe
               }
               , new Object[] {
               P008V10_A157TipSCod, P008V10_n157TipSCod, P008V10_A1906TipCmp, P008V10_A306TipAbr, P008V10_A707ComFReg, P008V10_A708ComFVcto, P008V10_A246ComMon, P008V10_A149TipCod, P008V10_A1910TipDsc, P008V10_A1233MonAbr,
               P008V10_n1233MonAbr, P008V10_A1916TipSAbr, P008V10_A243ComCod, P008V10_A248ComFec, P008V10_A244PrvCod, P008V10_A247PrvDsc, P008V10_A704ComFecPago, P008V10_A727ComRetCod, P008V10_A730ComRetFec, P008V10_A735ComTipReg,
               P008V10_A725ComRefTDoc, P008V10_A738ComUsuC, P008V10_A722ComRefDoc, P008V10_A724ComRefFec, P008V10_A511TipSigno, P008V10_A249ComRef, P008V10_A729ComRete2, P008V10_A728ComRete1, P008V10_A732ComSubIna, P008V10_A719ComIVADUA,
               P008V10_A718ComRedondeo, P008V10_A717ComPorIva, P008V10_A698ComDscto, P008V10_A713ComISC, P008V10_A706ComFlete, P008V10_A716ComSubAfe
               }
               , new Object[] {
               P008V12_A732ComSubIna, P008V12_A716ComSubAfe
               }
               , new Object[] {
               P008V14_A157TipSCod, P008V14_n157TipSCod, P008V14_A1906TipCmp, P008V14_A306TipAbr, P008V14_A707ComFReg, P008V14_A708ComFVcto, P008V14_A246ComMon, P008V14_A149TipCod, P008V14_A1910TipDsc, P008V14_A1233MonAbr,
               P008V14_n1233MonAbr, P008V14_A1916TipSAbr, P008V14_A243ComCod, P008V14_A244PrvCod, P008V14_A247PrvDsc, P008V14_A249ComRef, P008V14_A704ComFecPago, P008V14_A727ComRetCod, P008V14_A730ComRetFec, P008V14_A735ComTipReg,
               P008V14_A725ComRefTDoc, P008V14_A738ComUsuC, P008V14_A722ComRefDoc, P008V14_A724ComRefFec, P008V14_A511TipSigno, P008V14_A248ComFec, P008V14_A729ComRete2, P008V14_A728ComRete1, P008V14_A732ComSubIna, P008V14_A719ComIVADUA,
               P008V14_A718ComRedondeo, P008V14_A717ComPorIva, P008V14_A698ComDscto, P008V14_A713ComISC, P008V14_A706ComFlete, P008V14_A716ComSubAfe
               }
               , new Object[] {
               P008V16_A732ComSubIna, P008V16_A716ComSubAfe
               }
               , new Object[] {
               P008V18_A157TipSCod, P008V18_n157TipSCod, P008V18_A1906TipCmp, P008V18_A306TipAbr, P008V18_A707ComFReg, P008V18_A708ComFVcto, P008V18_A246ComMon, P008V18_A149TipCod, P008V18_A1910TipDsc, P008V18_A1233MonAbr,
               P008V18_n1233MonAbr, P008V18_A1916TipSAbr, P008V18_A243ComCod, P008V18_A248ComFec, P008V18_A244PrvCod, P008V18_A249ComRef, P008V18_A704ComFecPago, P008V18_A727ComRetCod, P008V18_A730ComRetFec, P008V18_A735ComTipReg,
               P008V18_A725ComRefTDoc, P008V18_A738ComUsuC, P008V18_A722ComRefDoc, P008V18_A724ComRefFec, P008V18_A511TipSigno, P008V18_A247PrvDsc, P008V18_A729ComRete2, P008V18_A728ComRete1, P008V18_A732ComSubIna, P008V18_A719ComIVADUA,
               P008V18_A718ComRedondeo, P008V18_A717ComPorIva, P008V18_A698ComDscto, P008V18_A713ComISC, P008V18_A706ComFlete, P008V18_A716ComSubAfe
               }
               , new Object[] {
               P008V20_A732ComSubIna, P008V20_A716ComSubAfe
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV73Mes ;
      private short A250ComDItem ;
      private short A1906TipCmp ;
      private short A511TipSigno ;
      private short AV13AT1 ;
      private short AV14AT2 ;
      private int AV15CellRow ;
      private int AV52FirstColumn ;
      private int A157TipSCod ;
      private int A246ComMon ;
      private int AV75MonCod ;
      private decimal AV57GSubTotal ;
      private decimal AV54GIgv ;
      private decimal AV56GSubIna ;
      private decimal AV55GISC ;
      private decimal AV58GTotalMN ;
      private decimal AV89SubTotal1 ;
      private decimal AV67IGV1 ;
      private decimal AV87SubIna ;
      private decimal AV70ISC ;
      private decimal AV100TotalMN ;
      private decimal AV101TotalMO ;
      private decimal AV53GDscto ;
      private decimal AV40Dscto ;
      private decimal AV59GTotalMO ;
      private decimal A729ComRete2 ;
      private decimal A728ComRete1 ;
      private decimal A732ComSubIna ;
      private decimal A719ComIVADUA ;
      private decimal A718ComRedondeo ;
      private decimal A717ComPorIva ;
      private decimal A698ComDscto ;
      private decimal A713ComISC ;
      private decimal A706ComFlete ;
      private decimal A716ComSubAfe ;
      private decimal A733ComSubTotal ;
      private decimal A715ComIva ;
      private decimal A736ComTotal ;
      private decimal AV99TipVenta ;
      private decimal AV12AT ;
      private decimal AV22ComPorIva ;
      private decimal AV90SubTotal2 ;
      private decimal AV91SubTotal3 ;
      private decimal AV68IGV2 ;
      private decimal AV69IGV3 ;
      private decimal AV88SubTotal ;
      private decimal AV21ComIVADUA ;
      private decimal GXt_decimal3 ;
      private string AV97Tipo ;
      private string AV41Empresa ;
      private string AV81Path ;
      private string AV16cMes ;
      private string AV18ComDCueCod ;
      private string AV19ComDDsc ;
      private string scmdbuf ;
      private string AV95TipCod ;
      private string AV17ComCod ;
      private string AV82PrvCod ;
      private string A244PrvCod ;
      private string A243ComCod ;
      private string A149TipCod ;
      private string A251ComDOrdCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A694ComDDsc ;
      private string A252ComCosCod ;
      private string A761COSDsc ;
      private string AV107CosDsc ;
      private string A262CPPrvCod ;
      private string A261CPComCod ;
      private string A260CPTipCod ;
      private string A815CPEstado ;
      private string AV23ComRef ;
      private string AV36DocAbr ;
      private string AV38DocNum ;
      private string AV83PrvDsc ;
      private string AV94TipCmb ;
      private string AV28ComRetFec ;
      private string AV27ComRetCod ;
      private string AV25ComRefFec ;
      private string AV24ComRefDoc ;
      private string AV96TipDsc ;
      private string AV108ComUsuC ;
      private string A306TipAbr ;
      private string A1910TipDsc ;
      private string A1233MonAbr ;
      private string A1916TipSAbr ;
      private string A247PrvDsc ;
      private string A249ComRef ;
      private string A727ComRetCod ;
      private string A735ComTipReg ;
      private string A725ComRefTDoc ;
      private string A738ComUsuC ;
      private string A722ComRefDoc ;
      private string AV93TipAbr ;
      private string AV74MonAbr ;
      private string AV39DocSts ;
      private string AV29ComTipReg ;
      private string AV26ComRefTDoc ;
      private string GXt_char1 ;
      private DateTime GXt_dtime2 ;
      private DateTime AV37DocFec ;
      private DateTime AV20ComFecPago ;
      private DateTime A707ComFReg ;
      private DateTime A708ComFVcto ;
      private DateTime A248ComFec ;
      private DateTime A704ComFecPago ;
      private DateTime A730ComRetFec ;
      private DateTime A724ComRefFec ;
      private DateTime AV46Fecha ;
      private bool returnInSub ;
      private bool n254ComDProCod ;
      private bool n253ComDCueCod ;
      private bool n252ComCosCod ;
      private bool n761COSDsc ;
      private bool BRK8V5 ;
      private bool n157TipSCod ;
      private bool n1233MonAbr ;
      private bool BRK8V7 ;
      private bool BRK8V9 ;
      private bool BRK8V11 ;
      private string AV50Filename ;
      private string AV42ErrorMessage ;
      private string AV51FilenameOrigen ;
      private string AV43Estado ;
      private string AV85Serie ;
      private string AV9AnoDua ;
      private string AV98TipSunat ;
      private string AV102TRef ;
      private IGxSession AV86Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private string aP2_Tipo ;
      private IDataStoreProvider pr_default ;
      private string[] P008V2_A244PrvCod ;
      private string[] P008V2_A243ComCod ;
      private string[] P008V2_A149TipCod ;
      private string[] P008V2_A251ComDOrdCod ;
      private string[] P008V2_A254ComDProCod ;
      private bool[] P008V2_n254ComDProCod ;
      private string[] P008V2_A253ComDCueCod ;
      private bool[] P008V2_n253ComDCueCod ;
      private string[] P008V2_A694ComDDsc ;
      private short[] P008V2_A250ComDItem ;
      private string[] P008V3_A252ComCosCod ;
      private bool[] P008V3_n252ComCosCod ;
      private string[] P008V3_A244PrvCod ;
      private string[] P008V3_A243ComCod ;
      private string[] P008V3_A149TipCod ;
      private string[] P008V3_A761COSDsc ;
      private bool[] P008V3_n761COSDsc ;
      private short[] P008V3_A250ComDItem ;
      private string[] P008V3_A251ComDOrdCod ;
      private string[] P008V4_A262CPPrvCod ;
      private string[] P008V4_A261CPComCod ;
      private string[] P008V4_A260CPTipCod ;
      private string[] P008V4_A815CPEstado ;
      private int[] P008V6_A157TipSCod ;
      private bool[] P008V6_n157TipSCod ;
      private short[] P008V6_A1906TipCmp ;
      private string[] P008V6_A306TipAbr ;
      private DateTime[] P008V6_A707ComFReg ;
      private DateTime[] P008V6_A708ComFVcto ;
      private int[] P008V6_A246ComMon ;
      private string[] P008V6_A149TipCod ;
      private string[] P008V6_A1910TipDsc ;
      private string[] P008V6_A1233MonAbr ;
      private bool[] P008V6_n1233MonAbr ;
      private string[] P008V6_A1916TipSAbr ;
      private string[] P008V6_A243ComCod ;
      private DateTime[] P008V6_A248ComFec ;
      private string[] P008V6_A244PrvCod ;
      private string[] P008V6_A247PrvDsc ;
      private string[] P008V6_A249ComRef ;
      private DateTime[] P008V6_A704ComFecPago ;
      private string[] P008V6_A727ComRetCod ;
      private DateTime[] P008V6_A730ComRetFec ;
      private string[] P008V6_A735ComTipReg ;
      private string[] P008V6_A725ComRefTDoc ;
      private string[] P008V6_A738ComUsuC ;
      private string[] P008V6_A722ComRefDoc ;
      private DateTime[] P008V6_A724ComRefFec ;
      private short[] P008V6_A511TipSigno ;
      private decimal[] P008V6_A729ComRete2 ;
      private decimal[] P008V6_A728ComRete1 ;
      private decimal[] P008V6_A732ComSubIna ;
      private decimal[] P008V6_A719ComIVADUA ;
      private decimal[] P008V6_A718ComRedondeo ;
      private decimal[] P008V6_A717ComPorIva ;
      private decimal[] P008V6_A698ComDscto ;
      private decimal[] P008V6_A713ComISC ;
      private decimal[] P008V6_A706ComFlete ;
      private decimal[] P008V6_A716ComSubAfe ;
      private decimal[] P008V8_A732ComSubIna ;
      private decimal[] P008V8_A716ComSubAfe ;
      private bool[] P008V6_n724ComRefFec ;
      private int[] P008V10_A157TipSCod ;
      private bool[] P008V10_n157TipSCod ;
      private short[] P008V10_A1906TipCmp ;
      private string[] P008V10_A306TipAbr ;
      private DateTime[] P008V10_A707ComFReg ;
      private DateTime[] P008V10_A708ComFVcto ;
      private int[] P008V10_A246ComMon ;
      private string[] P008V10_A149TipCod ;
      private string[] P008V10_A1910TipDsc ;
      private string[] P008V10_A1233MonAbr ;
      private bool[] P008V10_n1233MonAbr ;
      private string[] P008V10_A1916TipSAbr ;
      private string[] P008V10_A243ComCod ;
      private DateTime[] P008V10_A248ComFec ;
      private string[] P008V10_A244PrvCod ;
      private string[] P008V10_A247PrvDsc ;
      private DateTime[] P008V10_A704ComFecPago ;
      private string[] P008V10_A727ComRetCod ;
      private DateTime[] P008V10_A730ComRetFec ;
      private string[] P008V10_A735ComTipReg ;
      private string[] P008V10_A725ComRefTDoc ;
      private string[] P008V10_A738ComUsuC ;
      private string[] P008V10_A722ComRefDoc ;
      private DateTime[] P008V10_A724ComRefFec ;
      private short[] P008V10_A511TipSigno ;
      private string[] P008V10_A249ComRef ;
      private decimal[] P008V10_A729ComRete2 ;
      private decimal[] P008V10_A728ComRete1 ;
      private decimal[] P008V10_A732ComSubIna ;
      private decimal[] P008V10_A719ComIVADUA ;
      private decimal[] P008V10_A718ComRedondeo ;
      private decimal[] P008V10_A717ComPorIva ;
      private decimal[] P008V10_A698ComDscto ;
      private decimal[] P008V10_A713ComISC ;
      private decimal[] P008V10_A706ComFlete ;
      private decimal[] P008V10_A716ComSubAfe ;
      private decimal[] P008V12_A732ComSubIna ;
      private decimal[] P008V12_A716ComSubAfe ;
      private bool[] P008V10_n724ComRefFec ;
      private int[] P008V14_A157TipSCod ;
      private bool[] P008V14_n157TipSCod ;
      private short[] P008V14_A1906TipCmp ;
      private string[] P008V14_A306TipAbr ;
      private DateTime[] P008V14_A707ComFReg ;
      private DateTime[] P008V14_A708ComFVcto ;
      private int[] P008V14_A246ComMon ;
      private string[] P008V14_A149TipCod ;
      private string[] P008V14_A1910TipDsc ;
      private string[] P008V14_A1233MonAbr ;
      private bool[] P008V14_n1233MonAbr ;
      private string[] P008V14_A1916TipSAbr ;
      private string[] P008V14_A243ComCod ;
      private string[] P008V14_A244PrvCod ;
      private string[] P008V14_A247PrvDsc ;
      private string[] P008V14_A249ComRef ;
      private DateTime[] P008V14_A704ComFecPago ;
      private string[] P008V14_A727ComRetCod ;
      private DateTime[] P008V14_A730ComRetFec ;
      private string[] P008V14_A735ComTipReg ;
      private string[] P008V14_A725ComRefTDoc ;
      private string[] P008V14_A738ComUsuC ;
      private string[] P008V14_A722ComRefDoc ;
      private DateTime[] P008V14_A724ComRefFec ;
      private short[] P008V14_A511TipSigno ;
      private DateTime[] P008V14_A248ComFec ;
      private decimal[] P008V14_A729ComRete2 ;
      private decimal[] P008V14_A728ComRete1 ;
      private decimal[] P008V14_A732ComSubIna ;
      private decimal[] P008V14_A719ComIVADUA ;
      private decimal[] P008V14_A718ComRedondeo ;
      private decimal[] P008V14_A717ComPorIva ;
      private decimal[] P008V14_A698ComDscto ;
      private decimal[] P008V14_A713ComISC ;
      private decimal[] P008V14_A706ComFlete ;
      private decimal[] P008V14_A716ComSubAfe ;
      private decimal[] P008V16_A732ComSubIna ;
      private decimal[] P008V16_A716ComSubAfe ;
      private bool[] P008V14_n724ComRefFec ;
      private int[] P008V18_A157TipSCod ;
      private bool[] P008V18_n157TipSCod ;
      private short[] P008V18_A1906TipCmp ;
      private string[] P008V18_A306TipAbr ;
      private DateTime[] P008V18_A707ComFReg ;
      private DateTime[] P008V18_A708ComFVcto ;
      private int[] P008V18_A246ComMon ;
      private string[] P008V18_A149TipCod ;
      private string[] P008V18_A1910TipDsc ;
      private string[] P008V18_A1233MonAbr ;
      private bool[] P008V18_n1233MonAbr ;
      private string[] P008V18_A1916TipSAbr ;
      private string[] P008V18_A243ComCod ;
      private DateTime[] P008V18_A248ComFec ;
      private string[] P008V18_A244PrvCod ;
      private string[] P008V18_A249ComRef ;
      private DateTime[] P008V18_A704ComFecPago ;
      private string[] P008V18_A727ComRetCod ;
      private DateTime[] P008V18_A730ComRetFec ;
      private string[] P008V18_A735ComTipReg ;
      private string[] P008V18_A725ComRefTDoc ;
      private string[] P008V18_A738ComUsuC ;
      private string[] P008V18_A722ComRefDoc ;
      private DateTime[] P008V18_A724ComRefFec ;
      private short[] P008V18_A511TipSigno ;
      private string[] P008V18_A247PrvDsc ;
      private decimal[] P008V18_A729ComRete2 ;
      private decimal[] P008V18_A728ComRete1 ;
      private decimal[] P008V18_A732ComSubIna ;
      private decimal[] P008V18_A719ComIVADUA ;
      private decimal[] P008V18_A718ComRedondeo ;
      private decimal[] P008V18_A717ComPorIva ;
      private decimal[] P008V18_A698ComDscto ;
      private decimal[] P008V18_A713ComISC ;
      private decimal[] P008V18_A706ComFlete ;
      private decimal[] P008V18_A716ComSubAfe ;
      private decimal[] P008V20_A732ComSubIna ;
      private decimal[] P008V20_A716ComSubAfe ;
      private bool[] P008V18_n724ComRefFec ;
      private string aP3_Filename ;
      private string aP4_ErrorMessage ;
      private ExcelDocumentI AV45ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class pregistrocomprasexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008V2;
          prmP008V2 = new Object[] {
          new ParDef("@AV95TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV17ComCod",GXType.NChar,15,0) ,
          new ParDef("@AV82PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V3;
          prmP008V3 = new Object[] {
          new ParDef("@AV95TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV17ComCod",GXType.NChar,15,0) ,
          new ParDef("@AV82PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V4;
          prmP008V4 = new Object[] {
          new ParDef("@AV95TipCod",GXType.NChar,3,0) ,
          new ParDef("@AV17ComCod",GXType.NChar,15,0) ,
          new ParDef("@AV82PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V6;
          prmP008V6 = new Object[] {
          };
          Object[] prmP008V8;
          prmP008V8 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V10;
          prmP008V10 = new Object[] {
          };
          Object[] prmP008V12;
          prmP008V12 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V14;
          prmP008V14 = new Object[] {
          };
          Object[] prmP008V16;
          prmP008V16 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          Object[] prmP008V18;
          prmP008V18 = new Object[] {
          };
          Object[] prmP008V20;
          prmP008V20 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@ComCod",GXType.NChar,15,0) ,
          new ParDef("@PrvCod",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008V2", "SELECT [PrvCod], [ComCod], [TipCod], [ComDOrdCod], [ComDProCod], [ComDCueCod], [ComDDsc], [ComDItem] FROM [CPCOMPRASDET] WHERE [TipCod] = @AV95TipCod and [ComCod] = @AV17ComCod and [PrvCod] = @AV82PrvCod ORDER BY [TipCod], [ComCod], [PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V3", "SELECT T1.[ComCosCod] AS ComCosCod, T1.[PrvCod], T1.[ComCod], T1.[TipCod], T2.[COSDsc], T1.[ComDItem], T1.[ComDOrdCod] FROM ([CPCOMPRASDET] T1 LEFT JOIN [CBCOSTOS] T2 ON T2.[COSCod] = T1.[ComCosCod]) WHERE (T1.[TipCod] = @AV95TipCod and T1.[ComCod] = @AV17ComCod and T1.[PrvCod] = @AV82PrvCod) AND (Not (T1.[ComCosCod] = '')) ORDER BY T1.[TipCod], T1.[ComCod], T1.[PrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P008V4", "SELECT [CPPrvCod], [CPComCod], [CPTipCod], [CPEstado] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @AV95TipCod and [CPComCod] = @AV17ComCod and [CPPrvCod] = @AV82PrvCod ORDER BY [CPTipCod], [CPComCod], [CPPrvCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V4,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P008V6", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T3.[TipDsc], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComUsuC], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFReg] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V8", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V10", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T3.[TipDsc], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[PrvDsc], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComUsuC], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComRef], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComRef] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V12", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V14", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T3.[TipDsc], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[PrvCod], T1.[PrvDsc], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComUsuC], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[ComFec], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[ComFec] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V16", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V18", "SELECT T4.[TipSCod], T3.[TipCmp], T3.[TipAbr], T1.[ComFReg], T1.[ComFVcto], T1.[ComMon] AS ComMon, T1.[TipCod], T3.[TipDsc], T2.[MonAbr], T5.[TipSAbr], T1.[ComCod], T1.[ComFec], T1.[PrvCod], T1.[ComRef], T1.[ComFecPago], T1.[ComRetCod], T1.[ComRetFec], T1.[ComTipReg], T1.[ComRefTDoc], T1.[ComUsuC], T1.[ComRefDoc], T1.[ComRefFec], T3.[TipSigno], T1.[PrvDsc], T1.[ComRete2], T1.[ComRete1], COALESCE( T6.[ComSubIna], 0) AS ComSubIna, T1.[ComIVADUA], T1.[ComRedondeo], T1.[ComPorIva], T1.[ComDscto], T1.[ComISC], T1.[ComFlete], COALESCE( T6.[ComSubAfe], 0) AS ComSubAfe FROM ((((([CPCOMPRAS] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[ComMon]) INNER JOIN [CTIPDOC] T3 ON T3.[TipCod] = T1.[TipCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = T1.[PrvCod]) LEFT JOIN [CTIPDOCS] T5 ON T5.[TipSCod] = T4.[TipSCod]) LEFT JOIN (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T6 ON T6.[TipCod] = T1.[TipCod] AND T6.[ComCod] = T1.[ComCod] AND T6.[PrvCod] = T1.[PrvCod]) WHERE T3.[TipCmp] = 1 ORDER BY T3.[TipAbr], T1.[PrvDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V18,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008V20", "SELECT COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe FROM (SELECT [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008V20,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 100);
                ((short[]) buf[9])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((string[]) buf[3])[0] = rslt.getString(3, 15);
                ((string[]) buf[4])[0] = rslt.getString(4, 3);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 5);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((string[]) buf[16])[0] = rslt.getString(15, 10);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 20);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(18);
                ((string[]) buf[20])[0] = rslt.getString(19, 1);
                ((string[]) buf[21])[0] = rslt.getString(20, 3);
                ((string[]) buf[22])[0] = rslt.getString(21, 10);
                ((string[]) buf[23])[0] = rslt.getString(22, 20);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(23);
                ((short[]) buf[25])[0] = rslt.getShort(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(33);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 5);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 100);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 1);
                ((string[]) buf[20])[0] = rslt.getString(19, 3);
                ((string[]) buf[21])[0] = rslt.getString(20, 10);
                ((string[]) buf[22])[0] = rslt.getString(21, 20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(22);
                ((short[]) buf[24])[0] = rslt.getShort(23);
                ((string[]) buf[25])[0] = rslt.getString(24, 10);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(33);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
                return;
             case 6 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 5);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                ((string[]) buf[13])[0] = rslt.getString(12, 20);
                ((string[]) buf[14])[0] = rslt.getString(13, 100);
                ((string[]) buf[15])[0] = rslt.getString(14, 10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 1);
                ((string[]) buf[20])[0] = rslt.getString(19, 3);
                ((string[]) buf[21])[0] = rslt.getString(20, 10);
                ((string[]) buf[22])[0] = rslt.getString(21, 20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(22);
                ((short[]) buf[24])[0] = rslt.getShort(23);
                ((DateTime[]) buf[25])[0] = rslt.getGXDate(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(33);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                ((int[]) buf[6])[0] = rslt.getInt(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((string[]) buf[8])[0] = rslt.getString(8, 100);
                ((string[]) buf[9])[0] = rslt.getString(9, 5);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 5);
                ((string[]) buf[12])[0] = rslt.getString(11, 15);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(12);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((string[]) buf[15])[0] = rslt.getString(14, 10);
                ((DateTime[]) buf[16])[0] = rslt.getGXDate(15);
                ((string[]) buf[17])[0] = rslt.getString(16, 20);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 1);
                ((string[]) buf[20])[0] = rslt.getString(19, 3);
                ((string[]) buf[21])[0] = rslt.getString(20, 10);
                ((string[]) buf[22])[0] = rslt.getString(21, 20);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(22);
                ((short[]) buf[24])[0] = rslt.getShort(23);
                ((string[]) buf[25])[0] = rslt.getString(24, 100);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(31);
                ((decimal[]) buf[33])[0] = rslt.getDecimal(32);
                ((decimal[]) buf[34])[0] = rslt.getDecimal(33);
                ((decimal[]) buf[35])[0] = rslt.getDecimal(34);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
       }
    }

 }

}
