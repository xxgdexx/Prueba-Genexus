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
namespace GeneXus.Programs.contabilidad {
   public class r_registroventasexcel : GXProcedure
   {
      public r_registroventasexcel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public r_registroventasexcel( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_Ano ,
                           ref short aP1_Mes ,
                           out string aP2_Filename ,
                           out string aP3_ErrorMessage )
      {
         this.AV8Ano = aP0_Ano;
         this.AV63Mes = aP1_Mes;
         this.AV39Filename = "" ;
         this.AV35ErrorMessage = "" ;
         initialize();
         executePrivate();
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV63Mes;
         aP2_Filename=this.AV39Filename;
         aP3_ErrorMessage=this.AV35ErrorMessage;
      }

      public string executeUdp( ref short aP0_Ano ,
                                ref short aP1_Mes ,
                                out string aP2_Filename )
      {
         execute(ref aP0_Ano, ref aP1_Mes, out aP2_Filename, out aP3_ErrorMessage);
         return AV35ErrorMessage ;
      }

      public void executeSubmit( ref short aP0_Ano ,
                                 ref short aP1_Mes ,
                                 out string aP2_Filename ,
                                 out string aP3_ErrorMessage )
      {
         r_registroventasexcel objr_registroventasexcel;
         objr_registroventasexcel = new r_registroventasexcel();
         objr_registroventasexcel.AV8Ano = aP0_Ano;
         objr_registroventasexcel.AV63Mes = aP1_Mes;
         objr_registroventasexcel.AV39Filename = "" ;
         objr_registroventasexcel.AV35ErrorMessage = "" ;
         objr_registroventasexcel.context.SetSubmitInitialConfig(context);
         objr_registroventasexcel.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objr_registroventasexcel);
         aP0_Ano=this.AV8Ano;
         aP1_Mes=this.AV63Mes;
         aP2_Filename=this.AV39Filename;
         aP3_ErrorMessage=this.AV35ErrorMessage;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((r_registroventasexcel)stateInfo).executePrivate();
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
         AV11Archivo.Source = "Excel/PlantillasVentas.xlsx";
         AV71Path = AV11Archivo.GetPath();
         AV40FilenameOrigen = StringUtil.Trim( AV71Path) + "\\PlantillasVentas.xlsx";
         AV39Filename = "Excel/RegistroVentas" + ".xlsx";
         AV36ExcelDocument.Clear();
         AV36ExcelDocument.Template = AV40FilenameOrigen;
         AV36ExcelDocument.Open(AV39Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV12CellRow = 3;
         AV41FirstColumn = 5;
         GXt_char1 = AV15cMes;
         new GeneXus.Programs.generales.pobtienenombremes(context ).execute( ref  AV63Mes, out  GXt_char1) ;
         AV15cMes = GXt_char1;
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+1, 1, 1).Text = "Año : "+StringUtil.Trim( StringUtil.Str( (decimal)(AV8Ano), 10, 0))+"   Mes : "+StringUtil.Trim( AV15cMes);
         AV12CellRow = 7;
         AV41FirstColumn = 1;
         /* Using cursor P008Y3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8Y2 = false;
            A149TipCod = P008Y3_A149TipCod[0];
            A232DocFec = P008Y3_A232DocFec[0];
            A230DocMonCod = P008Y3_A230DocMonCod[0];
            A1233MonAbr = P008Y3_A1233MonAbr[0];
            n1233MonAbr = P008Y3_n1233MonAbr[0];
            A306TipAbr = P008Y3_A306TipAbr[0];
            A931DocFVcto = P008Y3_A931DocFVcto[0];
            A929DocFecRef = P008Y3_A929DocFecRef[0];
            A231DocCliCod = P008Y3_A231DocCliCod[0];
            A887DocCliDsc = P008Y3_A887DocCliDsc[0];
            A936DocObs = P008Y3_A936DocObs[0];
            A941DocSts = P008Y3_A941DocSts[0];
            A939DocRef = P008Y3_A939DocRef[0];
            A946DocTipo = P008Y3_A946DocTipo[0];
            A890DocCosCod = P008Y3_A890DocCosCod[0];
            n890DocCosCod = P008Y3_n890DocCosCod[0];
            A950DocTRef = P008Y3_A950DocTRef[0];
            A511TipSigno = P008Y3_A511TipSigno[0];
            A24DocNum = P008Y3_A24DocNum[0];
            A1921TipVta = P008Y3_A1921TipVta[0];
            A943DocSubGratuitoIna = P008Y3_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = P008Y3_A942DocSubGratuito[0];
            A932DocICBPER = P008Y3_A932DocICBPER[0];
            A935DocRedondeo = P008Y3_A935DocRedondeo[0];
            A934DocPorIVA = P008Y3_A934DocPorIVA[0];
            A882DocAnticipos = P008Y3_A882DocAnticipos[0];
            A927DocSubExonerado = P008Y3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P008Y3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P008Y3_A921DocSubInafecto[0];
            A920DocSubAfecto = P008Y3_A920DocSubAfecto[0];
            A899DocDcto = P008Y3_A899DocDcto[0];
            A306TipAbr = P008Y3_A306TipAbr[0];
            A511TipSigno = P008Y3_A511TipSigno[0];
            A1921TipVta = P008Y3_A1921TipVta[0];
            A1233MonAbr = P008Y3_A1233MonAbr[0];
            n1233MonAbr = P008Y3_n1233MonAbr[0];
            A887DocCliDsc = P008Y3_A887DocCliDsc[0];
            A943DocSubGratuitoIna = P008Y3_A943DocSubGratuitoIna[0];
            A942DocSubGratuito = P008Y3_A942DocSubGratuito[0];
            A927DocSubExonerado = P008Y3_A927DocSubExonerado[0];
            A922DocSubSelectivo = P008Y3_A922DocSubSelectivo[0];
            A921DocSubInafecto = P008Y3_A921DocSubInafecto[0];
            A920DocSubAfecto = P008Y3_A920DocSubAfecto[0];
            A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
            A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
            A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
            A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
            AV81TipCod = A149TipCod;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008Y3_A149TipCod[0], A149TipCod) == 0 ) )
            {
               BRK8Y2 = false;
               A232DocFec = P008Y3_A232DocFec[0];
               A230DocMonCod = P008Y3_A230DocMonCod[0];
               A1233MonAbr = P008Y3_A1233MonAbr[0];
               n1233MonAbr = P008Y3_n1233MonAbr[0];
               A306TipAbr = P008Y3_A306TipAbr[0];
               A931DocFVcto = P008Y3_A931DocFVcto[0];
               A929DocFecRef = P008Y3_A929DocFecRef[0];
               A231DocCliCod = P008Y3_A231DocCliCod[0];
               A887DocCliDsc = P008Y3_A887DocCliDsc[0];
               A936DocObs = P008Y3_A936DocObs[0];
               A941DocSts = P008Y3_A941DocSts[0];
               A939DocRef = P008Y3_A939DocRef[0];
               A946DocTipo = P008Y3_A946DocTipo[0];
               A890DocCosCod = P008Y3_A890DocCosCod[0];
               n890DocCosCod = P008Y3_n890DocCosCod[0];
               A950DocTRef = P008Y3_A950DocTRef[0];
               A511TipSigno = P008Y3_A511TipSigno[0];
               A24DocNum = P008Y3_A24DocNum[0];
               A932DocICBPER = P008Y3_A932DocICBPER[0];
               A935DocRedondeo = P008Y3_A935DocRedondeo[0];
               A934DocPorIVA = P008Y3_A934DocPorIVA[0];
               A882DocAnticipos = P008Y3_A882DocAnticipos[0];
               A899DocDcto = P008Y3_A899DocDcto[0];
               A306TipAbr = P008Y3_A306TipAbr[0];
               A511TipSigno = P008Y3_A511TipSigno[0];
               A1233MonAbr = P008Y3_A1233MonAbr[0];
               n1233MonAbr = P008Y3_n1233MonAbr[0];
               A887DocCliDsc = P008Y3_A887DocCliDsc[0];
               if ( StringUtil.StrCmp(A149TipCod, AV81TipCod) == 0 )
               {
                  if ( DateTimeUtil.Year( A232DocFec) == AV8Ano )
                  {
                     if ( DateTimeUtil.Month( A232DocFec) == AV63Mes )
                     {
                        /* Using cursor P008Y5 */
                        pr_default.execute(1, new Object[] {A149TipCod, A24DocNum});
                        if ( (pr_default.getStatus(1) != 101) )
                        {
                           A943DocSubGratuitoIna = P008Y5_A943DocSubGratuitoIna[0];
                           A942DocSubGratuito = P008Y5_A942DocSubGratuito[0];
                           A927DocSubExonerado = P008Y5_A927DocSubExonerado[0];
                           A922DocSubSelectivo = P008Y5_A922DocSubSelectivo[0];
                           A921DocSubInafecto = P008Y5_A921DocSubInafecto[0];
                           A920DocSubAfecto = P008Y5_A920DocSubAfecto[0];
                        }
                        else
                        {
                           A921DocSubInafecto = 0;
                           A927DocSubExonerado = 0;
                           A943DocSubGratuitoIna = 0;
                           A942DocSubGratuito = 0;
                           A920DocSubAfecto = 0;
                           A922DocSubSelectivo = 0;
                        }
                        pr_default.close(1);
                        A919DocSub = (decimal)((A920DocSubAfecto+A921DocSubInafecto+A922DocSubSelectivo+A927DocSubExonerado));
                        A918DocDscto = NumberUtil.Round( (NumberUtil.Round( A919DocSub*A899DocDcto, 2)/ (decimal)(100)), 2);
                        A933DocIVA = (decimal)(NumberUtil.Round( (((A920DocSubAfecto+A922DocSubSelectivo)-(A918DocDscto+A882DocAnticipos))*A934DocPorIVA)/ (decimal)(100), 2)+A935DocRedondeo);
                        A948DocTot = (decimal)((A919DocSub-(A918DocDscto+A882DocAnticipos))+A933DocIVA+A932DocICBPER);
                        AV65MonCod = A230DocMonCod;
                        AV81TipCod = A149TipCod;
                        AV64MonAbr = A1233MonAbr;
                        AV82TipVenta = 1.00000m;
                        AV80TipCmb = "";
                        AV23DocAbr = A306TipAbr;
                        AV29DocNum = A24DocNum;
                        AV25DocFec = A232DocFec;
                        AV28DocFVcto = A931DocFVcto;
                        AV26DocFecRef = A929DocFecRef;
                        AV13CliCod = StringUtil.Trim( A231DocCliCod);
                        AV14CliDsc = ((StringUtil.StrCmp(A231DocCliCod, "0000000000")==0) ? StringUtil.Trim( A936DocObs) : StringUtil.Trim( A887DocCliDsc));
                        AV31DocSts = A941DocSts;
                        AV16ComRef = A939DocRef;
                        AV32DocTipo = A946DocTipo;
                        AV90DocCosCod = A890DocCosCod;
                        AV27DocFRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A939DocRef)) ? "" : context.localUtil.DToC( A929DocFecRef, 2, "/")) : "");
                        AV30DocRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? (String.IsNullOrEmpty(StringUtil.RTrim( A950DocTRef)) ? "" : A939DocRef) : "");
                        AV33DocTRef = ((StringUtil.StrCmp(A149TipCod, "NC")==0)||(StringUtil.StrCmp(A149TipCod, "ND")==0) ? A950DocTRef : "");
                        AV33DocTRef = ((StringUtil.StrCmp(AV33DocTRef, "")==0) ? "" : ((StringUtil.StrCmp(AV33DocTRef, "FAC")==0) ? "01" : "03"));
                        AV47Gratuita = 0.00m;
                        AV10Anticipos = 0.00m;
                        AV78SubTotal = 0.00m;
                        AV77SubIna = 0.00m;
                        AV76SubExone = 0.00m;
                        AV34Dscto = 0.00m;
                        AV59Igv = 0.00m;
                        AV60ISC = 0.00m;
                        AV83TotalMN = 0.00m;
                        /* Execute user subroutine: 'VALIDACENTROCOSTOS' */
                        S131 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           pr_default.close(1);
                           this.cleanup();
                           if (true) return;
                        }
                        if ( AV65MonCod != 1 )
                        {
                           GXt_decimal2 = AV82TipVenta;
                           GXt_char1 = "V";
                           new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV65MonCod, ref  AV25DocFec, ref  GXt_char1, out  GXt_decimal2) ;
                           AV82TipVenta = GXt_decimal2;
                           AV80TipCmb = StringUtil.Trim( StringUtil.Str( AV82TipVenta, 10, 5));
                           if ( ( StringUtil.StrCmp(AV81TipCod, "NC") == 0 ) || ( StringUtil.StrCmp(AV81TipCod, "ND") == 0 ) )
                           {
                              GXt_decimal2 = AV82TipVenta;
                              GXt_char1 = "V";
                              new GeneXus.Programs.configuracion.poptienetipocambio(context ).execute( ref  AV65MonCod, ref  AV26DocFecRef, ref  GXt_char1, out  GXt_decimal2) ;
                              AV82TipVenta = GXt_decimal2;
                              AV80TipCmb = StringUtil.Trim( StringUtil.Str( AV82TipVenta, 10, 5));
                           }
                        }
                        if ( StringUtil.StrCmp(AV31DocSts, "A") != 0 )
                        {
                           AV78SubTotal = (decimal)((A920DocSubAfecto*AV82TipVenta)*A511TipSigno);
                           AV34Dscto = (decimal)((NumberUtil.Round( A918DocDscto, 2)*AV82TipVenta)*A511TipSigno);
                           AV77SubIna = (decimal)((NumberUtil.Round( A921DocSubInafecto, 2)*AV82TipVenta)*A511TipSigno);
                           AV76SubExone = (decimal)((NumberUtil.Round( A927DocSubExonerado, 2)*AV82TipVenta)*A511TipSigno);
                           AV47Gratuita = (decimal)((NumberUtil.Round( A942DocSubGratuito+A943DocSubGratuitoIna, 2)*AV82TipVenta)*A511TipSigno);
                           AV24DocAnticipos = (decimal)((NumberUtil.Round( A882DocAnticipos, 2)*AV82TipVenta)*A511TipSigno);
                           AV59Igv = (decimal)((NumberUtil.Round( A933DocIVA, 2)*AV82TipVenta)*A511TipSigno);
                           AV91DocICBPER = (decimal)((NumberUtil.Round( A932DocICBPER, 2)*AV82TipVenta)*A511TipSigno);
                           AV60ISC = (decimal)((NumberUtil.Round( A922DocSubSelectivo, 2)*AV82TipVenta)*A511TipSigno);
                           AV83TotalMN = (decimal)((NumberUtil.Round( A948DocTot, 2)*AV82TipVenta)*A511TipSigno);
                           AV84TotalMO = (decimal)(NumberUtil.Round( A948DocTot, 2)*A511TipSigno);
                           if ( ! (Convert.ToDecimal(0)==AV34Dscto) || ! (Convert.ToDecimal(0)==AV24DocAnticipos) )
                           {
                              if ( ! (Convert.ToDecimal(0)==A920DocSubAfecto) )
                              {
                                 AV78SubTotal = (decimal)(AV78SubTotal-(AV34Dscto+AV24DocAnticipos));
                              }
                              if ( ! (Convert.ToDecimal(0)==A921DocSubInafecto) )
                              {
                                 AV77SubIna = (decimal)(AV77SubIna-(AV24DocAnticipos));
                              }
                              if ( ! (Convert.ToDecimal(0)==A927DocSubExonerado) )
                              {
                                 AV76SubExone = (decimal)(AV76SubExone-(AV24DocAnticipos));
                              }
                              if ( ! (Convert.ToDecimal(0)==A942DocSubGratuito) )
                              {
                                 AV47Gratuita = (decimal)(AV47Gratuita-(AV24DocAnticipos));
                              }
                           }
                           if ( StringUtil.StrCmp(AV32DocTipo, "A") == 0 )
                           {
                              AV10Anticipos = AV78SubTotal;
                              AV78SubTotal = 0.00m;
                           }
                        }
                        else
                        {
                           AV47Gratuita = 0.00m;
                           AV10Anticipos = 0.00m;
                           AV78SubTotal = 0.00m;
                           AV77SubIna = 0.00m;
                           AV76SubExone = 0.00m;
                           AV34Dscto = 0.00m;
                           AV59Igv = 0.00m;
                           AV60ISC = 0.00m;
                           AV83TotalMN = 0.00m;
                           AV84TotalMO = 0.00m;
                           AV91DocICBPER = 0.00m;
                           AV13CliCod = "";
                           AV14CliDsc = "ANULADO";
                        }
                        /* Execute user subroutine: 'DETALLEVENTAS' */
                        S121 ();
                        if ( returnInSub )
                        {
                           pr_default.close(0);
                           pr_default.close(1);
                           this.cleanup();
                           if (true) return;
                        }
                     }
                  }
               }
               BRK8Y2 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK8Y2 )
            {
               BRK8Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         AV12CellRow = (int)(AV12CellRow+1);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+0, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+1, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+2, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+3, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+4, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+5, 1, 1).Text = "";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+6, 1, 1).Text = "Total General";
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+7, 1, 1).Number = (double)(AV50GSubTotal);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+8, 1, 1).Number = (double)(AV49GSubIna);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+9, 1, 1).Number = (double)(AV48GSubExone);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+10, 1, 1).Number = (double)(AV44GGratuita);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+11, 1, 1).Number = (double)(AV42GAnticipos);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+12, 1, 1).Number = (double)(AV45GIgv);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+13, 1, 1).Number = (double)(AV92GDocICBPER);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+14, 1, 1).Number = (double)(AV46GISC);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+15, 1, 1).Number = (double)(AV51GTotalMN);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+16, 1, 1).Number = (double)(AV52GTotalMO);
         AV36ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV36ExcelDocument.Close();
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         returnInSub = false;
         if ( AV36ExcelDocument.ErrCode != 0 )
         {
            AV39Filename = "";
            AV35ErrorMessage = AV36ExcelDocument.ErrDescription;
            AV36ExcelDocument.Close();
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'DETALLEVENTAS' Routine */
         returnInSub = false;
         GXt_dtime3 = DateTimeUtil.ResetTime( AV25DocFec ) ;
         AV36ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+0, 1, 1).Date = GXt_dtime3;
         GXt_dtime3 = DateTimeUtil.ResetTime( AV28DocFVcto ) ;
         AV36ExcelDocument.SetDateFormat(context, 8, 5, 0, 3, "/", ":", " ");
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+1, 1, 1).Date = GXt_dtime3;
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+2, 1, 1).Text = StringUtil.Trim( AV23DocAbr);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+3, 1, 1).Text = StringUtil.Trim( AV29DocNum);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+4, 1, 1).Text = StringUtil.Trim( AV16ComRef);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+5, 1, 1).Text = StringUtil.Trim( AV13CliCod);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+6, 1, 1).Text = StringUtil.Trim( AV14CliDsc);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+7, 1, 1).Number = (double)(AV78SubTotal);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+8, 1, 1).Number = (double)(AV77SubIna);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+9, 1, 1).Number = (double)(AV76SubExone);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+10, 1, 1).Number = (double)(AV47Gratuita);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+11, 1, 1).Number = (double)(AV10Anticipos);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+12, 1, 1).Number = (double)(AV59Igv);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+13, 1, 1).Number = (double)(AV91DocICBPER);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+14, 1, 1).Number = (double)(AV60ISC);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+15, 1, 1).Number = (double)(AV83TotalMN);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+16, 1, 1).Number = (double)(AV84TotalMO);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+17, 1, 1).Text = AV80TipCmb;
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+18, 1, 1).Text = StringUtil.Trim( AV33DocTRef);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+19, 1, 1).Text = StringUtil.Trim( AV30DocRef);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+20, 1, 1).Text = StringUtil.Trim( AV27DocFRef);
         AV36ExcelDocument.get_Cells(AV12CellRow, AV41FirstColumn+21, 1, 1).Text = StringUtil.Trim( AV89CosDsc);
         AV50GSubTotal = (decimal)(AV50GSubTotal+AV78SubTotal);
         AV44GGratuita = (decimal)(AV44GGratuita+AV47Gratuita);
         AV42GAnticipos = (decimal)(AV42GAnticipos+AV10Anticipos);
         AV49GSubIna = (decimal)(AV49GSubIna+AV77SubIna);
         AV48GSubExone = (decimal)(AV48GSubExone+AV76SubExone);
         AV43GDscto = (decimal)(AV43GDscto+AV34Dscto);
         AV45GIgv = (decimal)(AV45GIgv+AV59Igv);
         AV92GDocICBPER = (decimal)(AV92GDocICBPER+AV91DocICBPER);
         AV46GISC = (decimal)(AV46GISC+AV60ISC);
         AV51GTotalMN = (decimal)(AV51GTotalMN+AV83TotalMN);
         AV52GTotalMO = (decimal)(AV52GTotalMO+AV84TotalMO);
         AV12CellRow = (int)(AV12CellRow+1);
      }

      protected void S131( )
      {
         /* 'VALIDACENTROCOSTOS' Routine */
         returnInSub = false;
         AV89CosDsc = "";
         /* Using cursor P008Y6 */
         pr_default.execute(2, new Object[] {AV90DocCosCod});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A79COSCod = P008Y6_A79COSCod[0];
            A761COSDsc = P008Y6_A761COSDsc[0];
            AV89CosDsc = StringUtil.Trim( A761COSDsc);
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         AV39Filename = "";
         AV35ErrorMessage = "";
         AV11Archivo = new GxFile(context.GetPhysicalPath());
         AV71Path = "";
         AV40FilenameOrigen = "";
         AV36ExcelDocument = new ExcelDocumentI();
         AV15cMes = "";
         scmdbuf = "";
         P008Y3_A149TipCod = new string[] {""} ;
         P008Y3_A232DocFec = new DateTime[] {DateTime.MinValue} ;
         P008Y3_A230DocMonCod = new int[1] ;
         P008Y3_A1233MonAbr = new string[] {""} ;
         P008Y3_n1233MonAbr = new bool[] {false} ;
         P008Y3_A306TipAbr = new string[] {""} ;
         P008Y3_A931DocFVcto = new DateTime[] {DateTime.MinValue} ;
         P008Y3_A929DocFecRef = new DateTime[] {DateTime.MinValue} ;
         P008Y3_A231DocCliCod = new string[] {""} ;
         P008Y3_A887DocCliDsc = new string[] {""} ;
         P008Y3_A936DocObs = new string[] {""} ;
         P008Y3_A941DocSts = new string[] {""} ;
         P008Y3_A939DocRef = new string[] {""} ;
         P008Y3_A946DocTipo = new string[] {""} ;
         P008Y3_A890DocCosCod = new string[] {""} ;
         P008Y3_n890DocCosCod = new bool[] {false} ;
         P008Y3_A950DocTRef = new string[] {""} ;
         P008Y3_A511TipSigno = new short[1] ;
         P008Y3_A24DocNum = new string[] {""} ;
         P008Y3_A1921TipVta = new short[1] ;
         P008Y3_A943DocSubGratuitoIna = new decimal[1] ;
         P008Y3_A942DocSubGratuito = new decimal[1] ;
         P008Y3_A932DocICBPER = new decimal[1] ;
         P008Y3_A935DocRedondeo = new decimal[1] ;
         P008Y3_A934DocPorIVA = new decimal[1] ;
         P008Y3_A882DocAnticipos = new decimal[1] ;
         P008Y3_A927DocSubExonerado = new decimal[1] ;
         P008Y3_A922DocSubSelectivo = new decimal[1] ;
         P008Y3_A921DocSubInafecto = new decimal[1] ;
         P008Y3_A920DocSubAfecto = new decimal[1] ;
         P008Y3_A899DocDcto = new decimal[1] ;
         A149TipCod = "";
         A232DocFec = DateTime.MinValue;
         A1233MonAbr = "";
         A306TipAbr = "";
         A931DocFVcto = DateTime.MinValue;
         A929DocFecRef = DateTime.MinValue;
         A231DocCliCod = "";
         A887DocCliDsc = "";
         A936DocObs = "";
         A941DocSts = "";
         A939DocRef = "";
         A946DocTipo = "";
         A890DocCosCod = "";
         A950DocTRef = "";
         A24DocNum = "";
         AV81TipCod = "";
         P008Y5_A943DocSubGratuitoIna = new decimal[1] ;
         P008Y5_A942DocSubGratuito = new decimal[1] ;
         P008Y5_A927DocSubExonerado = new decimal[1] ;
         P008Y5_A922DocSubSelectivo = new decimal[1] ;
         P008Y5_A921DocSubInafecto = new decimal[1] ;
         P008Y5_A920DocSubAfecto = new decimal[1] ;
         AV64MonAbr = "";
         AV80TipCmb = "";
         AV23DocAbr = "";
         AV29DocNum = "";
         AV25DocFec = DateTime.MinValue;
         AV28DocFVcto = DateTime.MinValue;
         AV26DocFecRef = DateTime.MinValue;
         AV13CliCod = "";
         AV14CliDsc = "";
         AV31DocSts = "";
         AV16ComRef = "";
         AV32DocTipo = "";
         AV90DocCosCod = "";
         AV27DocFRef = "";
         AV30DocRef = "";
         AV33DocTRef = "";
         GXt_char1 = "";
         GXt_dtime3 = (DateTime)(DateTime.MinValue);
         AV89CosDsc = "";
         P008Y6_A79COSCod = new string[] {""} ;
         P008Y6_A761COSDsc = new string[] {""} ;
         A79COSCod = "";
         A761COSDsc = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.r_registroventasexcel__default(),
            new Object[][] {
                new Object[] {
               P008Y3_A149TipCod, P008Y3_A232DocFec, P008Y3_A230DocMonCod, P008Y3_A1233MonAbr, P008Y3_n1233MonAbr, P008Y3_A306TipAbr, P008Y3_A931DocFVcto, P008Y3_A929DocFecRef, P008Y3_A231DocCliCod, P008Y3_A887DocCliDsc,
               P008Y3_A936DocObs, P008Y3_A941DocSts, P008Y3_A939DocRef, P008Y3_A946DocTipo, P008Y3_A890DocCosCod, P008Y3_n890DocCosCod, P008Y3_A950DocTRef, P008Y3_A511TipSigno, P008Y3_A24DocNum, P008Y3_A1921TipVta,
               P008Y3_A943DocSubGratuitoIna, P008Y3_A942DocSubGratuito, P008Y3_A932DocICBPER, P008Y3_A935DocRedondeo, P008Y3_A934DocPorIVA, P008Y3_A882DocAnticipos, P008Y3_A927DocSubExonerado, P008Y3_A922DocSubSelectivo, P008Y3_A921DocSubInafecto, P008Y3_A920DocSubAfecto,
               P008Y3_A899DocDcto
               }
               , new Object[] {
               P008Y5_A943DocSubGratuitoIna, P008Y5_A942DocSubGratuito, P008Y5_A927DocSubExonerado, P008Y5_A922DocSubSelectivo, P008Y5_A921DocSubInafecto, P008Y5_A920DocSubAfecto
               }
               , new Object[] {
               P008Y6_A79COSCod, P008Y6_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8Ano ;
      private short AV63Mes ;
      private short A511TipSigno ;
      private short A1921TipVta ;
      private int AV12CellRow ;
      private int AV41FirstColumn ;
      private int A230DocMonCod ;
      private int AV65MonCod ;
      private decimal A943DocSubGratuitoIna ;
      private decimal A942DocSubGratuito ;
      private decimal A932DocICBPER ;
      private decimal A935DocRedondeo ;
      private decimal A934DocPorIVA ;
      private decimal A882DocAnticipos ;
      private decimal A927DocSubExonerado ;
      private decimal A922DocSubSelectivo ;
      private decimal A921DocSubInafecto ;
      private decimal A920DocSubAfecto ;
      private decimal A899DocDcto ;
      private decimal A919DocSub ;
      private decimal A918DocDscto ;
      private decimal A933DocIVA ;
      private decimal A948DocTot ;
      private decimal AV82TipVenta ;
      private decimal AV47Gratuita ;
      private decimal AV10Anticipos ;
      private decimal AV78SubTotal ;
      private decimal AV77SubIna ;
      private decimal AV76SubExone ;
      private decimal AV34Dscto ;
      private decimal AV59Igv ;
      private decimal AV60ISC ;
      private decimal AV83TotalMN ;
      private decimal GXt_decimal2 ;
      private decimal AV24DocAnticipos ;
      private decimal AV91DocICBPER ;
      private decimal AV84TotalMO ;
      private decimal AV50GSubTotal ;
      private decimal AV49GSubIna ;
      private decimal AV48GSubExone ;
      private decimal AV44GGratuita ;
      private decimal AV42GAnticipos ;
      private decimal AV45GIgv ;
      private decimal AV92GDocICBPER ;
      private decimal AV46GISC ;
      private decimal AV51GTotalMN ;
      private decimal AV52GTotalMO ;
      private decimal AV43GDscto ;
      private string AV71Path ;
      private string AV15cMes ;
      private string scmdbuf ;
      private string A149TipCod ;
      private string A1233MonAbr ;
      private string A306TipAbr ;
      private string A231DocCliCod ;
      private string A887DocCliDsc ;
      private string A941DocSts ;
      private string A939DocRef ;
      private string A946DocTipo ;
      private string A890DocCosCod ;
      private string A950DocTRef ;
      private string A24DocNum ;
      private string AV81TipCod ;
      private string AV64MonAbr ;
      private string AV80TipCmb ;
      private string AV23DocAbr ;
      private string AV29DocNum ;
      private string AV13CliCod ;
      private string AV14CliDsc ;
      private string AV31DocSts ;
      private string AV16ComRef ;
      private string AV32DocTipo ;
      private string AV90DocCosCod ;
      private string AV30DocRef ;
      private string AV33DocTRef ;
      private string GXt_char1 ;
      private string AV89CosDsc ;
      private string A79COSCod ;
      private string A761COSDsc ;
      private DateTime GXt_dtime3 ;
      private DateTime A232DocFec ;
      private DateTime A931DocFVcto ;
      private DateTime A929DocFecRef ;
      private DateTime AV25DocFec ;
      private DateTime AV28DocFVcto ;
      private DateTime AV26DocFecRef ;
      private bool returnInSub ;
      private bool BRK8Y2 ;
      private bool n1233MonAbr ;
      private bool n890DocCosCod ;
      private string A936DocObs ;
      private string AV39Filename ;
      private string AV35ErrorMessage ;
      private string AV40FilenameOrigen ;
      private string AV27DocFRef ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP0_Ano ;
      private short aP1_Mes ;
      private IDataStoreProvider pr_default ;
      private string[] P008Y3_A149TipCod ;
      private DateTime[] P008Y3_A232DocFec ;
      private int[] P008Y3_A230DocMonCod ;
      private string[] P008Y3_A1233MonAbr ;
      private bool[] P008Y3_n1233MonAbr ;
      private string[] P008Y3_A306TipAbr ;
      private DateTime[] P008Y3_A931DocFVcto ;
      private DateTime[] P008Y3_A929DocFecRef ;
      private string[] P008Y3_A231DocCliCod ;
      private string[] P008Y3_A887DocCliDsc ;
      private string[] P008Y3_A936DocObs ;
      private string[] P008Y3_A941DocSts ;
      private string[] P008Y3_A939DocRef ;
      private string[] P008Y3_A946DocTipo ;
      private string[] P008Y3_A890DocCosCod ;
      private bool[] P008Y3_n890DocCosCod ;
      private string[] P008Y3_A950DocTRef ;
      private short[] P008Y3_A511TipSigno ;
      private string[] P008Y3_A24DocNum ;
      private short[] P008Y3_A1921TipVta ;
      private decimal[] P008Y3_A943DocSubGratuitoIna ;
      private decimal[] P008Y3_A942DocSubGratuito ;
      private decimal[] P008Y3_A932DocICBPER ;
      private decimal[] P008Y3_A935DocRedondeo ;
      private decimal[] P008Y3_A934DocPorIVA ;
      private decimal[] P008Y3_A882DocAnticipos ;
      private decimal[] P008Y3_A927DocSubExonerado ;
      private decimal[] P008Y3_A922DocSubSelectivo ;
      private decimal[] P008Y3_A921DocSubInafecto ;
      private decimal[] P008Y3_A920DocSubAfecto ;
      private decimal[] P008Y3_A899DocDcto ;
      private decimal[] P008Y5_A943DocSubGratuitoIna ;
      private decimal[] P008Y5_A942DocSubGratuito ;
      private decimal[] P008Y5_A927DocSubExonerado ;
      private decimal[] P008Y5_A922DocSubSelectivo ;
      private decimal[] P008Y5_A921DocSubInafecto ;
      private decimal[] P008Y5_A920DocSubAfecto ;
      private string[] P008Y6_A79COSCod ;
      private string[] P008Y6_A761COSDsc ;
      private string aP2_Filename ;
      private string aP3_ErrorMessage ;
      private ExcelDocumentI AV36ExcelDocument ;
      private GxFile AV11Archivo ;
   }

   public class r_registroventasexcel__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmP008Y3;
          prmP008Y3 = new Object[] {
          };
          Object[] prmP008Y5;
          prmP008Y5 = new Object[] {
          new ParDef("@TipCod",GXType.NChar,3,0) ,
          new ParDef("@DocNum",GXType.NChar,12,0)
          };
          Object[] prmP008Y6;
          prmP008Y6 = new Object[] {
          new ParDef("@AV90DocCosCod",GXType.NChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008Y3", "SELECT T1.[TipCod], T1.[DocFec], T1.[DocMonCod] AS DocMonCod, T3.[MonAbr], T2.[TipAbr], T1.[DocFVcto], T1.[DocFecRef], T1.[DocCliCod] AS DocCliCod, T4.[CliDsc] AS DocCliDsc, T1.[DocObs], T1.[DocSts], T1.[DocRef], T1.[DocTipo], T1.[DocCosCod], T1.[DocTRef], T2.[TipSigno], T1.[DocNum], T2.[TipVta], COALESCE( T5.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T5.[DocSubGratuito], 0) AS DocSubGratuito, T1.[DocICBPER], T1.[DocRedondeo], T1.[DocPorIVA], T1.[DocAnticipos], COALESCE( T5.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T5.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T5.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T5.[DocSubAfecto], 0) AS DocSubAfecto, T1.[DocDcto] FROM (((([CLVENTAS] T1 INNER JOIN [CTIPDOC] T2 ON T2.[TipCod] = T1.[TipCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[DocMonCod]) INNER JOIN [CLCLIENTES] T4 ON T4.[CliCod] = T1.[DocCliCod]) LEFT JOIN (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T5 ON T5.[TipCod] = T1.[TipCod] AND T5.[DocNum] = T1.[DocNum]) WHERE T2.[TipVta] = 1 ORDER BY T1.[TipCod], T1.[DocNum] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008Y5", "SELECT COALESCE( T1.[DocSubGratuitoIna], 0) AS DocSubGratuitoIna, COALESCE( T1.[DocSubGratuito], 0) AS DocSubGratuito, COALESCE( T1.[DocSubExonerado], 0) AS DocSubExonerado, COALESCE( T1.[DocSubSelectivo], 0) AS DocSubSelectivo, COALESCE( T1.[DocSubInafecto], 0) AS DocSubInafecto, COALESCE( T1.[DocSubAfecto], 0) AS DocSubAfecto FROM (SELECT [TipCod], [DocNum], SUM(CASE  WHEN [DocDIna] = 1 THEN [DocDTot] ELSE 0 END) AS DocSubInafecto, SUM(CASE  WHEN [DocDIna] = 2 THEN [DocDTot] ELSE 0 END) AS DocSubExonerado, SUM(CASE  WHEN [DocDIna] = 4 THEN [DocDTot] ELSE 0 END) AS DocSubGratuitoIna, SUM(CASE  WHEN [DocDIna] = 3 THEN [DocDTot] ELSE 0 END) AS DocSubGratuito, SUM(CASE  WHEN [DocDIna] = 0 THEN [DocDTot] ELSE 0 END) AS DocSubAfecto, SUM(( ROUND(CAST(( [DocDTot] * CAST([DocDPorSel] AS decimal( 28, 10))) AS decimal( 30, 10)) / 100, 2)) + ( [DocDCan] * CAST([DocDValSel] AS decimal( 25, 10)))) AS DocSubSelectivo FROM [CLVENTASDET] GROUP BY [TipCod], [DocNum] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[DocNum] = @DocNum ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008Y6", "SELECT [COSCod], [COSDsc] FROM [CBCOSTOS] WHERE [COSCod] = @AV90DocCosCod ORDER BY [COSCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008Y6,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((string[]) buf[9])[0] = rslt.getString(9, 100);
                ((string[]) buf[10])[0] = rslt.getLongVarchar(10);
                ((string[]) buf[11])[0] = rslt.getString(11, 1);
                ((string[]) buf[12])[0] = rslt.getString(12, 12);
                ((string[]) buf[13])[0] = rslt.getString(13, 1);
                ((string[]) buf[14])[0] = rslt.getString(14, 10);
                ((bool[]) buf[15])[0] = rslt.wasNull(14);
                ((string[]) buf[16])[0] = rslt.getString(15, 3);
                ((short[]) buf[17])[0] = rslt.getShort(16);
                ((string[]) buf[18])[0] = rslt.getString(17, 12);
                ((short[]) buf[19])[0] = rslt.getShort(18);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(22);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(26);
                ((decimal[]) buf[28])[0] = rslt.getDecimal(27);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                return;
             case 1 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
