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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.reloj_interface {
   public class reloj_bc : GxSilentTrn, IGxSilentTrn
   {
      public reloj_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public GXBCCollection<GeneXus.Programs.reloj_interface.SdtReloj> GetAll( int Start ,
                                                                               int Count )
      {
         GXPagingFrom212 = Start;
         GXPagingTo212 = Count;
         /* Using cursor BC007S4 */
         pr_default.execute(2, new Object[] {GXPagingFrom212, GXPagingTo212});
         RcdFound212 = 0;
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound212 = 1;
            A2430RelojID = BC007S4_A2430RelojID[0];
            A2425Reloj_Nom = BC007S4_A2425Reloj_Nom[0];
            A2426Reloj_Dsc = BC007S4_A2426Reloj_Dsc[0];
            A2427Reloj_IP = BC007S4_A2427Reloj_IP[0];
            A2428Reloj_Puerto = BC007S4_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = BC007S4_A2429Reloj_Estado[0];
         }
         bcreloj_interface_Reloj = new GeneXus.Programs.reloj_interface.SdtReloj(context);
         gx_restcollection.Clear();
         while ( RcdFound212 != 0 )
         {
            OnLoadActions7S212( ) ;
            AddRow7S212( ) ;
            gx_sdt_item = (GeneXus.Programs.reloj_interface.SdtReloj)(bcreloj_interface_Reloj.Clone());
            gx_restcollection.Add(gx_sdt_item, 0);
            pr_default.readNext(2);
            RcdFound212 = 0;
            sMode212 = Gx_mode;
            Gx_mode = "DSP";
            if ( (pr_default.getStatus(2) != 101) )
            {
               RcdFound212 = 1;
               A2430RelojID = BC007S4_A2430RelojID[0];
               A2425Reloj_Nom = BC007S4_A2425Reloj_Nom[0];
               A2426Reloj_Dsc = BC007S4_A2426Reloj_Dsc[0];
               A2427Reloj_IP = BC007S4_A2427Reloj_IP[0];
               A2428Reloj_Puerto = BC007S4_A2428Reloj_Puerto[0];
               A2429Reloj_Estado = BC007S4_A2429Reloj_Estado[0];
            }
            Gx_mode = sMode212;
         }
         pr_default.close(2);
         /* Load Subordinate Levels */
         return gx_restcollection ;
      }

      protected void SETSEUDOVARS( )
      {
         ZM7S212( 0) ;
      }

      public void GetInsDefault( )
      {
         ReadRow7S212( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey7S212( ) ;
         standaloneModal( ) ;
         AddRow7S212( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E117S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z2430RelojID = A2430RelojID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_7S0( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7S212( ) ;
            }
            else
            {
               CheckExtendedTable7S212( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors7S212( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E127S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E117S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM7S212( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z2425Reloj_Nom = A2425Reloj_Nom;
            Z2426Reloj_Dsc = A2426Reloj_Dsc;
            Z2427Reloj_IP = A2427Reloj_IP;
            Z2428Reloj_Puerto = A2428Reloj_Puerto;
            Z2429Reloj_Estado = A2429Reloj_Estado;
         }
         if ( GX_JID == -1 )
         {
            Z2430RelojID = A2430RelojID;
            Z2425Reloj_Nom = A2425Reloj_Nom;
            Z2426Reloj_Dsc = A2426Reloj_Dsc;
            Z2427Reloj_IP = A2427Reloj_IP;
            Z2428Reloj_Puerto = A2428Reloj_Puerto;
            Z2429Reloj_Estado = A2429Reloj_Estado;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load7S212( )
      {
         /* Using cursor BC007S5 */
         pr_default.execute(3, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound212 = 1;
            A2425Reloj_Nom = BC007S5_A2425Reloj_Nom[0];
            A2426Reloj_Dsc = BC007S5_A2426Reloj_Dsc[0];
            A2427Reloj_IP = BC007S5_A2427Reloj_IP[0];
            A2428Reloj_Puerto = BC007S5_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = BC007S5_A2429Reloj_Estado[0];
            ZM7S212( -1) ;
         }
         pr_default.close(3);
         OnLoadActions7S212( ) ;
      }

      protected void OnLoadActions7S212( )
      {
      }

      protected void CheckExtendedTable7S212( )
      {
         nIsDirty_212 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors7S212( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7S212( )
      {
         /* Using cursor BC007S6 */
         pr_default.execute(4, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound212 = 1;
         }
         else
         {
            RcdFound212 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC007S3 */
         pr_default.execute(1, new Object[] {A2430RelojID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7S212( 1) ;
            RcdFound212 = 1;
            A2430RelojID = BC007S3_A2430RelojID[0];
            A2425Reloj_Nom = BC007S3_A2425Reloj_Nom[0];
            A2426Reloj_Dsc = BC007S3_A2426Reloj_Dsc[0];
            A2427Reloj_IP = BC007S3_A2427Reloj_IP[0];
            A2428Reloj_Puerto = BC007S3_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = BC007S3_A2429Reloj_Estado[0];
            Z2430RelojID = A2430RelojID;
            sMode212 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load7S212( ) ;
            if ( AnyError == 1 )
            {
               RcdFound212 = 0;
               InitializeNonKey7S212( ) ;
            }
            Gx_mode = sMode212;
         }
         else
         {
            RcdFound212 = 0;
            InitializeNonKey7S212( ) ;
            sMode212 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode212;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7S212( ) ;
         if ( RcdFound212 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_7S0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency7S212( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC007S2 */
            pr_default.execute(0, new Object[] {A2430RelojID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2425Reloj_Nom, BC007S2_A2425Reloj_Nom[0]) != 0 ) || ( StringUtil.StrCmp(Z2426Reloj_Dsc, BC007S2_A2426Reloj_Dsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2427Reloj_IP, BC007S2_A2427Reloj_IP[0]) != 0 ) || ( StringUtil.StrCmp(Z2428Reloj_Puerto, BC007S2_A2428Reloj_Puerto[0]) != 0 ) || ( Z2429Reloj_Estado != BC007S2_A2429Reloj_Estado[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reloj"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7S212( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7S212( 0) ;
            CheckOptimisticConcurrency7S212( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7S212( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7S212( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007S7 */
                     pr_default.execute(5, new Object[] {A2430RelojID, A2425Reloj_Nom, A2426Reloj_Dsc, A2427Reloj_IP, A2428Reloj_Puerto, A2429Reloj_Estado});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load7S212( ) ;
            }
            EndLevel7S212( ) ;
         }
         CloseExtendedTableCursors7S212( ) ;
      }

      protected void Update7S212( )
      {
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7S212( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7S212( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7S212( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007S8 */
                     pr_default.execute(6, new Object[] {A2425Reloj_Nom, A2426Reloj_Dsc, A2427Reloj_IP, A2428Reloj_Puerto, A2429Reloj_Estado, A2430RelojID});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7S212( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel7S212( ) ;
         }
         CloseExtendedTableCursors7S212( ) ;
      }

      protected void DeferredUpdate7S212( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate7S212( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7S212( ) ;
            AfterConfirm7S212( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7S212( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC007S9 */
                  pr_default.execute(7, new Object[] {A2430RelojID});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Reloj");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode212 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel7S212( ) ;
         Gx_mode = sMode212;
      }

      protected void OnDeleteControls7S212( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7S212( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7S212( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart7S212( )
      {
         /* Scan By routine */
         /* Using cursor BC007S10 */
         pr_default.execute(8, new Object[] {A2430RelojID});
         RcdFound212 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound212 = 1;
            A2430RelojID = BC007S10_A2430RelojID[0];
            A2425Reloj_Nom = BC007S10_A2425Reloj_Nom[0];
            A2426Reloj_Dsc = BC007S10_A2426Reloj_Dsc[0];
            A2427Reloj_IP = BC007S10_A2427Reloj_IP[0];
            A2428Reloj_Puerto = BC007S10_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = BC007S10_A2429Reloj_Estado[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext7S212( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound212 = 0;
         ScanKeyLoad7S212( ) ;
      }

      protected void ScanKeyLoad7S212( )
      {
         sMode212 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound212 = 1;
            A2430RelojID = BC007S10_A2430RelojID[0];
            A2425Reloj_Nom = BC007S10_A2425Reloj_Nom[0];
            A2426Reloj_Dsc = BC007S10_A2426Reloj_Dsc[0];
            A2427Reloj_IP = BC007S10_A2427Reloj_IP[0];
            A2428Reloj_Puerto = BC007S10_A2428Reloj_Puerto[0];
            A2429Reloj_Estado = BC007S10_A2429Reloj_Estado[0];
         }
         Gx_mode = sMode212;
      }

      protected void ScanKeyEnd7S212( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm7S212( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7S212( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7S212( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7S212( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7S212( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7S212( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7S212( )
      {
      }

      protected void send_integrity_lvl_hashes7S212( )
      {
      }

      protected void AddRow7S212( )
      {
         VarsToRow212( bcreloj_interface_Reloj) ;
      }

      protected void ReadRow7S212( )
      {
         RowToVars212( bcreloj_interface_Reloj, 1) ;
      }

      protected void InitializeNonKey7S212( )
      {
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         A2429Reloj_Estado = 0;
         Z2425Reloj_Nom = "";
         Z2426Reloj_Dsc = "";
         Z2427Reloj_IP = "";
         Z2428Reloj_Puerto = "";
         Z2429Reloj_Estado = 0;
      }

      protected void InitAll7S212( )
      {
         A2430RelojID = 0;
         InitializeNonKey7S212( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow212( GeneXus.Programs.reloj_interface.SdtReloj obj212 )
      {
         obj212.gxTpr_Mode = Gx_mode;
         obj212.gxTpr_Reloj_nom = A2425Reloj_Nom;
         obj212.gxTpr_Reloj_dsc = A2426Reloj_Dsc;
         obj212.gxTpr_Reloj_ip = A2427Reloj_IP;
         obj212.gxTpr_Reloj_puerto = A2428Reloj_Puerto;
         obj212.gxTpr_Reloj_estado = A2429Reloj_Estado;
         obj212.gxTpr_Relojid = A2430RelojID;
         obj212.gxTpr_Relojid_Z = Z2430RelojID;
         obj212.gxTpr_Reloj_nom_Z = Z2425Reloj_Nom;
         obj212.gxTpr_Reloj_dsc_Z = Z2426Reloj_Dsc;
         obj212.gxTpr_Reloj_ip_Z = Z2427Reloj_IP;
         obj212.gxTpr_Reloj_puerto_Z = Z2428Reloj_Puerto;
         obj212.gxTpr_Reloj_estado_Z = Z2429Reloj_Estado;
         obj212.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow212( GeneXus.Programs.reloj_interface.SdtReloj obj212 )
      {
         obj212.gxTpr_Relojid = A2430RelojID;
         return  ;
      }

      public void RowToVars212( GeneXus.Programs.reloj_interface.SdtReloj obj212 ,
                                int forceLoad )
      {
         Gx_mode = obj212.gxTpr_Mode;
         A2425Reloj_Nom = obj212.gxTpr_Reloj_nom;
         A2426Reloj_Dsc = obj212.gxTpr_Reloj_dsc;
         A2427Reloj_IP = obj212.gxTpr_Reloj_ip;
         A2428Reloj_Puerto = obj212.gxTpr_Reloj_puerto;
         A2429Reloj_Estado = obj212.gxTpr_Reloj_estado;
         A2430RelojID = obj212.gxTpr_Relojid;
         Z2430RelojID = obj212.gxTpr_Relojid_Z;
         Z2425Reloj_Nom = obj212.gxTpr_Reloj_nom_Z;
         Z2426Reloj_Dsc = obj212.gxTpr_Reloj_dsc_Z;
         Z2427Reloj_IP = obj212.gxTpr_Reloj_ip_Z;
         Z2428Reloj_Puerto = obj212.gxTpr_Reloj_puerto_Z;
         Z2429Reloj_Estado = obj212.gxTpr_Reloj_estado_Z;
         Gx_mode = obj212.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A2430RelojID = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey7S212( ) ;
         ScanKeyStart7S212( ) ;
         if ( RcdFound212 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2430RelojID = A2430RelojID;
         }
         ZM7S212( -1) ;
         OnLoadActions7S212( ) ;
         AddRow7S212( ) ;
         ScanKeyEnd7S212( ) ;
         if ( RcdFound212 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars212( bcreloj_interface_Reloj, 0) ;
         ScanKeyStart7S212( ) ;
         if ( RcdFound212 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2430RelojID = A2430RelojID;
         }
         ZM7S212( -1) ;
         OnLoadActions7S212( ) ;
         AddRow7S212( ) ;
         ScanKeyEnd7S212( ) ;
         if ( RcdFound212 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey7S212( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert7S212( ) ;
         }
         else
         {
            if ( RcdFound212 == 1 )
            {
               if ( A2430RelojID != Z2430RelojID )
               {
                  A2430RelojID = Z2430RelojID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update7S212( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A2430RelojID != Z2430RelojID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert7S212( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert7S212( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars212( bcreloj_interface_Reloj, 1) ;
         SaveImpl( ) ;
         VarsToRow212( bcreloj_interface_Reloj) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars212( bcreloj_interface_Reloj, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert7S212( ) ;
         AfterTrn( ) ;
         VarsToRow212( bcreloj_interface_Reloj) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            GeneXus.Programs.reloj_interface.SdtReloj auxBC = new GeneXus.Programs.reloj_interface.SdtReloj(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A2430RelojID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcreloj_interface_Reloj);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars212( bcreloj_interface_Reloj, 1) ;
         UpdateImpl( ) ;
         VarsToRow212( bcreloj_interface_Reloj) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars212( bcreloj_interface_Reloj, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert7S212( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow212( bcreloj_interface_Reloj) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars212( bcreloj_interface_Reloj, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey7S212( ) ;
         if ( RcdFound212 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A2430RelojID != Z2430RelojID )
            {
               A2430RelojID = Z2430RelojID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A2430RelojID != Z2430RelojID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("reloj_interface.reloj_bc",pr_default);
         VarsToRow212( bcreloj_interface_Reloj) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcreloj_interface_Reloj.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcreloj_interface_Reloj.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcreloj_interface_Reloj )
         {
            bcreloj_interface_Reloj = (GeneXus.Programs.reloj_interface.SdtReloj)(sdt);
            if ( StringUtil.StrCmp(bcreloj_interface_Reloj.gxTpr_Mode, "") == 0 )
            {
               bcreloj_interface_Reloj.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow212( bcreloj_interface_Reloj) ;
            }
            else
            {
               RowToVars212( bcreloj_interface_Reloj, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcreloj_interface_Reloj.gxTpr_Mode, "") == 0 )
            {
               bcreloj_interface_Reloj.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars212( bcreloj_interface_Reloj, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtReloj Reloj_BC
      {
         get {
            return bcreloj_interface_Reloj ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         BC007S4_A2430RelojID = new short[1] ;
         BC007S4_A2425Reloj_Nom = new string[] {""} ;
         BC007S4_A2426Reloj_Dsc = new string[] {""} ;
         BC007S4_A2427Reloj_IP = new string[] {""} ;
         BC007S4_A2428Reloj_Puerto = new string[] {""} ;
         BC007S4_A2429Reloj_Estado = new short[1] ;
         A2425Reloj_Nom = "";
         A2426Reloj_Dsc = "";
         A2427Reloj_IP = "";
         A2428Reloj_Puerto = "";
         gx_restcollection = new GXBCCollection<GeneXus.Programs.reloj_interface.SdtReloj>( context, "Reloj", "SIGERP_ADVANCED");
         sMode212 = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z2425Reloj_Nom = "";
         Z2426Reloj_Dsc = "";
         Z2427Reloj_IP = "";
         Z2428Reloj_Puerto = "";
         BC007S5_A2430RelojID = new short[1] ;
         BC007S5_A2425Reloj_Nom = new string[] {""} ;
         BC007S5_A2426Reloj_Dsc = new string[] {""} ;
         BC007S5_A2427Reloj_IP = new string[] {""} ;
         BC007S5_A2428Reloj_Puerto = new string[] {""} ;
         BC007S5_A2429Reloj_Estado = new short[1] ;
         BC007S6_A2430RelojID = new short[1] ;
         BC007S3_A2430RelojID = new short[1] ;
         BC007S3_A2425Reloj_Nom = new string[] {""} ;
         BC007S3_A2426Reloj_Dsc = new string[] {""} ;
         BC007S3_A2427Reloj_IP = new string[] {""} ;
         BC007S3_A2428Reloj_Puerto = new string[] {""} ;
         BC007S3_A2429Reloj_Estado = new short[1] ;
         BC007S2_A2430RelojID = new short[1] ;
         BC007S2_A2425Reloj_Nom = new string[] {""} ;
         BC007S2_A2426Reloj_Dsc = new string[] {""} ;
         BC007S2_A2427Reloj_IP = new string[] {""} ;
         BC007S2_A2428Reloj_Puerto = new string[] {""} ;
         BC007S2_A2429Reloj_Estado = new short[1] ;
         BC007S10_A2430RelojID = new short[1] ;
         BC007S10_A2425Reloj_Nom = new string[] {""} ;
         BC007S10_A2426Reloj_Dsc = new string[] {""} ;
         BC007S10_A2427Reloj_IP = new string[] {""} ;
         BC007S10_A2428Reloj_Puerto = new string[] {""} ;
         BC007S10_A2429Reloj_Estado = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_bc__default(),
            new Object[][] {
                new Object[] {
               BC007S2_A2430RelojID, BC007S2_A2425Reloj_Nom, BC007S2_A2426Reloj_Dsc, BC007S2_A2427Reloj_IP, BC007S2_A2428Reloj_Puerto, BC007S2_A2429Reloj_Estado
               }
               , new Object[] {
               BC007S3_A2430RelojID, BC007S3_A2425Reloj_Nom, BC007S3_A2426Reloj_Dsc, BC007S3_A2427Reloj_IP, BC007S3_A2428Reloj_Puerto, BC007S3_A2429Reloj_Estado
               }
               , new Object[] {
               BC007S4_A2430RelojID, BC007S4_A2425Reloj_Nom, BC007S4_A2426Reloj_Dsc, BC007S4_A2427Reloj_IP, BC007S4_A2428Reloj_Puerto, BC007S4_A2429Reloj_Estado
               }
               , new Object[] {
               BC007S5_A2430RelojID, BC007S5_A2425Reloj_Nom, BC007S5_A2426Reloj_Dsc, BC007S5_A2427Reloj_IP, BC007S5_A2428Reloj_Puerto, BC007S5_A2429Reloj_Estado
               }
               , new Object[] {
               BC007S6_A2430RelojID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC007S10_A2430RelojID, BC007S10_A2425Reloj_Nom, BC007S10_A2426Reloj_Dsc, BC007S10_A2427Reloj_IP, BC007S10_A2428Reloj_Puerto, BC007S10_A2429Reloj_Estado
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E127S2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short RcdFound212 ;
      private short A2430RelojID ;
      private short A2429Reloj_Estado ;
      private short Z2430RelojID ;
      private short GX_JID ;
      private short Z2429Reloj_Estado ;
      private short nIsDirty_212 ;
      private int trnEnded ;
      private int Start ;
      private int Count ;
      private int GXPagingFrom212 ;
      private int GXPagingTo212 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sMode212 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string A2425Reloj_Nom ;
      private string A2426Reloj_Dsc ;
      private string A2427Reloj_IP ;
      private string A2428Reloj_Puerto ;
      private string Z2425Reloj_Nom ;
      private string Z2426Reloj_Dsc ;
      private string Z2427Reloj_IP ;
      private string Z2428Reloj_Puerto ;
      private IGxSession AV10WebSession ;
      private GXBCCollection<GeneXus.Programs.reloj_interface.SdtReloj> gx_restcollection ;
      private GeneXus.Programs.reloj_interface.SdtReloj bcreloj_interface_Reloj ;
      private GeneXus.Programs.reloj_interface.SdtReloj gx_sdt_item ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC007S4_A2430RelojID ;
      private string[] BC007S4_A2425Reloj_Nom ;
      private string[] BC007S4_A2426Reloj_Dsc ;
      private string[] BC007S4_A2427Reloj_IP ;
      private string[] BC007S4_A2428Reloj_Puerto ;
      private short[] BC007S4_A2429Reloj_Estado ;
      private short[] BC007S5_A2430RelojID ;
      private string[] BC007S5_A2425Reloj_Nom ;
      private string[] BC007S5_A2426Reloj_Dsc ;
      private string[] BC007S5_A2427Reloj_IP ;
      private string[] BC007S5_A2428Reloj_Puerto ;
      private short[] BC007S5_A2429Reloj_Estado ;
      private short[] BC007S6_A2430RelojID ;
      private short[] BC007S3_A2430RelojID ;
      private string[] BC007S3_A2425Reloj_Nom ;
      private string[] BC007S3_A2426Reloj_Dsc ;
      private string[] BC007S3_A2427Reloj_IP ;
      private string[] BC007S3_A2428Reloj_Puerto ;
      private short[] BC007S3_A2429Reloj_Estado ;
      private short[] BC007S2_A2430RelojID ;
      private string[] BC007S2_A2425Reloj_Nom ;
      private string[] BC007S2_A2426Reloj_Dsc ;
      private string[] BC007S2_A2427Reloj_IP ;
      private string[] BC007S2_A2428Reloj_Puerto ;
      private short[] BC007S2_A2429Reloj_Estado ;
      private short[] BC007S10_A2430RelojID ;
      private string[] BC007S10_A2425Reloj_Nom ;
      private string[] BC007S10_A2426Reloj_Dsc ;
      private string[] BC007S10_A2427Reloj_IP ;
      private string[] BC007S10_A2428Reloj_Puerto ;
      private short[] BC007S10_A2429Reloj_Estado ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
   }

   public class reloj_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class reloj_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC007S4;
        prmBC007S4 = new Object[] {
        new ParDef("@GXPagingFrom212",GXType.Int32,9,0) ,
        new ParDef("@GXPagingTo212",GXType.Int32,9,0)
        };
        Object[] prmBC007S5;
        prmBC007S5 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S6;
        prmBC007S6 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S3;
        prmBC007S3 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S2;
        prmBC007S2 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S7;
        prmBC007S7 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0) ,
        new ParDef("@Reloj_Nom",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@Reloj_IP",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Puerto",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Estado",GXType.Int16,1,0)
        };
        Object[] prmBC007S8;
        prmBC007S8 = new Object[] {
        new ParDef("@Reloj_Nom",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Dsc",GXType.NVarChar,100,0) ,
        new ParDef("@Reloj_IP",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Puerto",GXType.NVarChar,50,0) ,
        new ParDef("@Reloj_Estado",GXType.Int16,1,0) ,
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S9;
        prmBC007S9 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        Object[] prmBC007S10;
        prmBC007S10 = new Object[] {
        new ParDef("@RelojID",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC007S2", "SELECT [RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado] FROM [Reloj] WITH (UPDLOCK) WHERE [RelojID] = @RelojID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007S3", "SELECT [RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado] FROM [Reloj] WHERE [RelojID] = @RelojID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007S4", "SELECT TM1.[RelojID], TM1.[Reloj_Nom], TM1.[Reloj_Dsc], TM1.[Reloj_IP], TM1.[Reloj_Puerto], TM1.[Reloj_Estado] FROM [Reloj] TM1 ORDER BY TM1.[RelojID]  OFFSET @GXPagingFrom212 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo212 > 0 THEN @GXPagingTo212 ELSE 1e9 END) AS INTEGER) ROWS ONLY",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007S5", "SELECT TM1.[RelojID], TM1.[Reloj_Nom], TM1.[Reloj_Dsc], TM1.[Reloj_IP], TM1.[Reloj_Puerto], TM1.[Reloj_Estado] FROM [Reloj] TM1 WHERE TM1.[RelojID] = @RelojID ORDER BY TM1.[RelojID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007S6", "SELECT [RelojID] FROM [Reloj] WHERE [RelojID] = @RelojID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007S7", "INSERT INTO [Reloj]([RelojID], [Reloj_Nom], [Reloj_Dsc], [Reloj_IP], [Reloj_Puerto], [Reloj_Estado]) VALUES(@RelojID, @Reloj_Nom, @Reloj_Dsc, @Reloj_IP, @Reloj_Puerto, @Reloj_Estado)", GxErrorMask.GX_NOMASK,prmBC007S7)
           ,new CursorDef("BC007S8", "UPDATE [Reloj] SET [Reloj_Nom]=@Reloj_Nom, [Reloj_Dsc]=@Reloj_Dsc, [Reloj_IP]=@Reloj_IP, [Reloj_Puerto]=@Reloj_Puerto, [Reloj_Estado]=@Reloj_Estado  WHERE [RelojID] = @RelojID", GxErrorMask.GX_NOMASK,prmBC007S8)
           ,new CursorDef("BC007S9", "DELETE FROM [Reloj]  WHERE [RelojID] = @RelojID", GxErrorMask.GX_NOMASK,prmBC007S9)
           ,new CursorDef("BC007S10", "SELECT TM1.[RelojID], TM1.[Reloj_Nom], TM1.[Reloj_Dsc], TM1.[Reloj_IP], TM1.[Reloj_Puerto], TM1.[Reloj_Estado] FROM [Reloj] TM1 WHERE TM1.[RelojID] = @RelojID ORDER BY TM1.[RelojID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007S10,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
     }
  }

}

}
