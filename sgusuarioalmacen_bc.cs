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
namespace GeneXus.Programs {
   public class sgusuarioalmacen_bc : GxSilentTrn, IGxSilentTrn
   {
      public sgusuarioalmacen_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarioalmacen_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0T28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0T28( ) ;
         standaloneModal( ) ;
         AddRow0T28( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z348UsuCod = A348UsuCod;
               Z349UsuAlmCod = A349UsuAlmCod;
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T28( ) ;
            }
            else
            {
               CheckExtendedTable0T28( ) ;
               if ( AnyError == 0 )
               {
                  ZM0T28( 2) ;
                  ZM0T28( 3) ;
               }
               CloseExtendedTableCursors0T28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0T28( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z2008UsuAlmSts = A2008UsuAlmSts;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2007UsuAlmDsc = A2007UsuAlmDsc;
         }
         if ( GX_JID == -1 )
         {
            Z2008UsuAlmSts = A2008UsuAlmSts;
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
            Z2007UsuAlmDsc = A2007UsuAlmDsc;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0T28( )
      {
         /* Using cursor BC000T6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound28 = 1;
            A2007UsuAlmDsc = BC000T6_A2007UsuAlmDsc[0];
            A2008UsuAlmSts = BC000T6_A2008UsuAlmSts[0];
            ZM0T28( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0T28( ) ;
      }

      protected void OnLoadActions0T28( )
      {
      }

      protected void CheckExtendedTable0T28( )
      {
         nIsDirty_28 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000T4 */
         pr_default.execute(2, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
         }
         pr_default.close(2);
         /* Using cursor BC000T5 */
         pr_default.execute(3, new Object[] {A349UsuAlmCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
            AnyError = 1;
         }
         A2007UsuAlmDsc = BC000T5_A2007UsuAlmDsc[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0T28( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T28( )
      {
         /* Using cursor BC000T7 */
         pr_default.execute(5, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000T3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A349UsuAlmCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T28( 1) ;
            RcdFound28 = 1;
            A2008UsuAlmSts = BC000T3_A2008UsuAlmSts[0];
            A348UsuCod = BC000T3_A348UsuCod[0];
            A349UsuAlmCod = BC000T3_A349UsuAlmCod[0];
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0T28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0T28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0T28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0T0( ) ;
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

      protected void CheckOptimisticConcurrency0T28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000T2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A349UsuAlmCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOALMACEN"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2008UsuAlmSts != BC000T2_A2008UsuAlmSts[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOALMACEN"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T28( )
      {
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T28( 0) ;
            CheckOptimisticConcurrency0T28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T8 */
                     pr_default.execute(6, new Object[] {A2008UsuAlmSts, A348UsuCod, A349UsuAlmCod});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load0T28( ) ;
            }
            EndLevel0T28( ) ;
         }
         CloseExtendedTableCursors0T28( ) ;
      }

      protected void Update0T28( )
      {
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T9 */
                     pr_default.execute(7, new Object[] {A2008UsuAlmSts, A348UsuCod, A349UsuAlmCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOALMACEN"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T28( ) ;
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
            EndLevel0T28( ) ;
         }
         CloseExtendedTableCursors0T28( ) ;
      }

      protected void DeferredUpdate0T28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0T28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T28( ) ;
            AfterConfirm0T28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000T10 */
                  pr_default.execute(8, new Object[] {A348UsuCod, A349UsuAlmCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOALMACEN");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0T28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0T28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000T11 */
            pr_default.execute(9, new Object[] {A349UsuAlmCod});
            A2007UsuAlmDsc = BC000T11_A2007UsuAlmDsc[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0T28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T28( ) ;
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

      public void ScanKeyStart0T28( )
      {
         /* Using cursor BC000T12 */
         pr_default.execute(10, new Object[] {A348UsuCod, A349UsuAlmCod});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound28 = 1;
            A2007UsuAlmDsc = BC000T12_A2007UsuAlmDsc[0];
            A2008UsuAlmSts = BC000T12_A2008UsuAlmSts[0];
            A348UsuCod = BC000T12_A348UsuCod[0];
            A349UsuAlmCod = BC000T12_A349UsuAlmCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0T28( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound28 = 0;
         ScanKeyLoad0T28( ) ;
      }

      protected void ScanKeyLoad0T28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound28 = 1;
            A2007UsuAlmDsc = BC000T12_A2007UsuAlmDsc[0];
            A2008UsuAlmSts = BC000T12_A2008UsuAlmSts[0];
            A348UsuCod = BC000T12_A348UsuCod[0];
            A349UsuAlmCod = BC000T12_A349UsuAlmCod[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0T28( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0T28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0T28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T28( )
      {
      }

      protected void send_integrity_lvl_hashes0T28( )
      {
      }

      protected void AddRow0T28( )
      {
         VarsToRow28( bcSGUSUARIOALMACEN) ;
      }

      protected void ReadRow0T28( )
      {
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
      }

      protected void InitializeNonKey0T28( )
      {
         A2007UsuAlmDsc = "";
         A2008UsuAlmSts = 0;
         Z2008UsuAlmSts = 0;
      }

      protected void InitAll0T28( )
      {
         A348UsuCod = "";
         A349UsuAlmCod = 0;
         InitializeNonKey0T28( ) ;
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

      public void VarsToRow28( SdtSGUSUARIOALMACEN obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Usualmdsc = A2007UsuAlmDsc;
         obj28.gxTpr_Usualmsts = A2008UsuAlmSts;
         obj28.gxTpr_Usucod = A348UsuCod;
         obj28.gxTpr_Usualmcod = A349UsuAlmCod;
         obj28.gxTpr_Usucod_Z = Z348UsuCod;
         obj28.gxTpr_Usualmcod_Z = Z349UsuAlmCod;
         obj28.gxTpr_Usualmdsc_Z = Z2007UsuAlmDsc;
         obj28.gxTpr_Usualmsts_Z = Z2008UsuAlmSts;
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtSGUSUARIOALMACEN obj28 )
      {
         obj28.gxTpr_Usucod = A348UsuCod;
         obj28.gxTpr_Usualmcod = A349UsuAlmCod;
         return  ;
      }

      public void RowToVars28( SdtSGUSUARIOALMACEN obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A2007UsuAlmDsc = obj28.gxTpr_Usualmdsc;
         A2008UsuAlmSts = obj28.gxTpr_Usualmsts;
         A348UsuCod = obj28.gxTpr_Usucod;
         A349UsuAlmCod = obj28.gxTpr_Usualmcod;
         Z348UsuCod = obj28.gxTpr_Usucod_Z;
         Z349UsuAlmCod = obj28.gxTpr_Usualmcod_Z;
         Z2007UsuAlmDsc = obj28.gxTpr_Usualmdsc_Z;
         Z2008UsuAlmSts = obj28.gxTpr_Usualmsts_Z;
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A348UsuCod = (string)getParm(obj,0);
         A349UsuAlmCod = (int)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0T28( ) ;
         ScanKeyStart0T28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000T13 */
            pr_default.execute(11, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000T11 */
            pr_default.execute(9, new Object[] {A349UsuAlmCod});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
               AnyError = 1;
            }
            A2007UsuAlmDsc = BC000T11_A2007UsuAlmDsc[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
         }
         ZM0T28( -1) ;
         OnLoadActions0T28( ) ;
         AddRow0T28( ) ;
         ScanKeyEnd0T28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcSGUSUARIOALMACEN, 0) ;
         ScanKeyStart0T28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000T13 */
            pr_default.execute(11, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(11) == 101) )
            {
               GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000T11 */
            pr_default.execute(9, new Object[] {A349UsuAlmCod});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "USUALMCOD");
               AnyError = 1;
            }
            A2007UsuAlmDsc = BC000T11_A2007UsuAlmDsc[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z348UsuCod = A348UsuCod;
            Z349UsuAlmCod = A349UsuAlmCod;
         }
         ZM0T28( -1) ;
         OnLoadActions0T28( ) ;
         AddRow0T28( ) ;
         ScanKeyEnd0T28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0T28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0T28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
               {
                  A348UsuCod = Z348UsuCod;
                  A349UsuAlmCod = Z349UsuAlmCod;
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
                  Update0T28( ) ;
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
                  if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
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
                        Insert0T28( ) ;
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
                        Insert0T28( ) ;
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
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcSGUSUARIOALMACEN) ;
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
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcSGUSUARIOALMACEN) ;
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
            SdtSGUSUARIOALMACEN auxBC = new SdtSGUSUARIOALMACEN(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A348UsuCod, A349UsuAlmCod);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSGUSUARIOALMACEN);
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
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
         UpdateImpl( ) ;
         VarsToRow28( bcSGUSUARIOALMACEN) ;
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
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T28( ) ;
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
         VarsToRow28( bcSGUSUARIOALMACEN) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcSGUSUARIOALMACEN, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0T28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
            {
               A348UsuCod = Z348UsuCod;
               A349UsuAlmCod = Z349UsuAlmCod;
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
            if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A349UsuAlmCod != Z349UsuAlmCod ) )
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
         pr_default.close(11);
         pr_default.close(9);
         context.RollbackDataStores("sgusuarioalmacen_bc",pr_default);
         VarsToRow28( bcSGUSUARIOALMACEN) ;
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
         Gx_mode = bcSGUSUARIOALMACEN.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSGUSUARIOALMACEN.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSGUSUARIOALMACEN )
         {
            bcSGUSUARIOALMACEN = (SdtSGUSUARIOALMACEN)(sdt);
            if ( StringUtil.StrCmp(bcSGUSUARIOALMACEN.gxTpr_Mode, "") == 0 )
            {
               bcSGUSUARIOALMACEN.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcSGUSUARIOALMACEN) ;
            }
            else
            {
               RowToVars28( bcSGUSUARIOALMACEN, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSGUSUARIOALMACEN.gxTpr_Mode, "") == 0 )
            {
               bcSGUSUARIOALMACEN.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcSGUSUARIOALMACEN, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtSGUSUARIOALMACEN SGUSUARIOALMACEN_BC
      {
         get {
            return bcSGUSUARIOALMACEN ;
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
         pr_default.close(11);
         pr_default.close(9);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z348UsuCod = "";
         A348UsuCod = "";
         Z2007UsuAlmDsc = "";
         A2007UsuAlmDsc = "";
         BC000T6_A2007UsuAlmDsc = new string[] {""} ;
         BC000T6_A2008UsuAlmSts = new short[1] ;
         BC000T6_A348UsuCod = new string[] {""} ;
         BC000T6_A349UsuAlmCod = new int[1] ;
         BC000T4_A348UsuCod = new string[] {""} ;
         BC000T5_A2007UsuAlmDsc = new string[] {""} ;
         BC000T7_A348UsuCod = new string[] {""} ;
         BC000T7_A349UsuAlmCod = new int[1] ;
         BC000T3_A2008UsuAlmSts = new short[1] ;
         BC000T3_A348UsuCod = new string[] {""} ;
         BC000T3_A349UsuAlmCod = new int[1] ;
         sMode28 = "";
         BC000T2_A2008UsuAlmSts = new short[1] ;
         BC000T2_A348UsuCod = new string[] {""} ;
         BC000T2_A349UsuAlmCod = new int[1] ;
         BC000T11_A2007UsuAlmDsc = new string[] {""} ;
         BC000T12_A2007UsuAlmDsc = new string[] {""} ;
         BC000T12_A2008UsuAlmSts = new short[1] ;
         BC000T12_A348UsuCod = new string[] {""} ;
         BC000T12_A349UsuAlmCod = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000T13_A348UsuCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioalmacen_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioalmacen_bc__default(),
            new Object[][] {
                new Object[] {
               BC000T2_A2008UsuAlmSts, BC000T2_A348UsuCod, BC000T2_A349UsuAlmCod
               }
               , new Object[] {
               BC000T3_A2008UsuAlmSts, BC000T3_A348UsuCod, BC000T3_A349UsuAlmCod
               }
               , new Object[] {
               BC000T4_A348UsuCod
               }
               , new Object[] {
               BC000T5_A2007UsuAlmDsc
               }
               , new Object[] {
               BC000T6_A2007UsuAlmDsc, BC000T6_A2008UsuAlmSts, BC000T6_A348UsuCod, BC000T6_A349UsuAlmCod
               }
               , new Object[] {
               BC000T7_A348UsuCod, BC000T7_A349UsuAlmCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000T11_A2007UsuAlmDsc
               }
               , new Object[] {
               BC000T12_A2007UsuAlmDsc, BC000T12_A2008UsuAlmSts, BC000T12_A348UsuCod, BC000T12_A349UsuAlmCod
               }
               , new Object[] {
               BC000T13_A348UsuCod
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z2008UsuAlmSts ;
      private short A2008UsuAlmSts ;
      private short RcdFound28 ;
      private short nIsDirty_28 ;
      private int trnEnded ;
      private int Z349UsuAlmCod ;
      private int A349UsuAlmCod ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z348UsuCod ;
      private string A348UsuCod ;
      private string Z2007UsuAlmDsc ;
      private string A2007UsuAlmDsc ;
      private string sMode28 ;
      private bool mustCommit ;
      private SdtSGUSUARIOALMACEN bcSGUSUARIOALMACEN ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000T6_A2007UsuAlmDsc ;
      private short[] BC000T6_A2008UsuAlmSts ;
      private string[] BC000T6_A348UsuCod ;
      private int[] BC000T6_A349UsuAlmCod ;
      private string[] BC000T4_A348UsuCod ;
      private string[] BC000T5_A2007UsuAlmDsc ;
      private string[] BC000T7_A348UsuCod ;
      private int[] BC000T7_A349UsuAlmCod ;
      private short[] BC000T3_A2008UsuAlmSts ;
      private string[] BC000T3_A348UsuCod ;
      private int[] BC000T3_A349UsuAlmCod ;
      private short[] BC000T2_A2008UsuAlmSts ;
      private string[] BC000T2_A348UsuCod ;
      private int[] BC000T2_A349UsuAlmCod ;
      private string[] BC000T11_A2007UsuAlmDsc ;
      private string[] BC000T12_A2007UsuAlmDsc ;
      private short[] BC000T12_A2008UsuAlmSts ;
      private string[] BC000T12_A348UsuCod ;
      private int[] BC000T12_A349UsuAlmCod ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string[] BC000T13_A348UsuCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class sgusuarioalmacen_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioalmacen_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
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
        Object[] prmBC000T6;
        prmBC000T6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T4;
        prmBC000T4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmBC000T5;
        prmBC000T5 = new Object[] {
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T7;
        prmBC000T7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T3;
        prmBC000T3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T2;
        prmBC000T2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T8;
        prmBC000T8 = new Object[] {
        new ParDef("@UsuAlmSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T9;
        prmBC000T9 = new Object[] {
        new ParDef("@UsuAlmSts",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T10;
        prmBC000T10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T12;
        prmBC000T12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmBC000T13;
        prmBC000T13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmBC000T11;
        prmBC000T11 = new Object[] {
        new ParDef("@UsuAlmCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000T2", "SELECT [UsuAlmSts], [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T3", "SELECT [UsuAlmSts], [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T4", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T5", "SELECT [AlmDsc] AS UsuAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T6", "SELECT T2.[AlmDsc] AS UsuAlmDsc, TM1.[UsuAlmSts], TM1.[UsuCod], TM1.[UsuAlmCod] AS UsuAlmCod FROM ([SGUSUARIOALMACEN] TM1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = TM1.[UsuAlmCod]) WHERE TM1.[UsuCod] = @UsuCod and TM1.[UsuAlmCod] = @UsuAlmCod ORDER BY TM1.[UsuCod], TM1.[UsuAlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T7", "SELECT [UsuCod], [UsuAlmCod] AS UsuAlmCod FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T8", "INSERT INTO [SGUSUARIOALMACEN]([UsuAlmSts], [UsuCod], [UsuAlmCod]) VALUES(@UsuAlmSts, @UsuCod, @UsuAlmCod)", GxErrorMask.GX_NOMASK,prmBC000T8)
           ,new CursorDef("BC000T9", "UPDATE [SGUSUARIOALMACEN] SET [UsuAlmSts]=@UsuAlmSts  WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod", GxErrorMask.GX_NOMASK,prmBC000T9)
           ,new CursorDef("BC000T10", "DELETE FROM [SGUSUARIOALMACEN]  WHERE [UsuCod] = @UsuCod AND [UsuAlmCod] = @UsuAlmCod", GxErrorMask.GX_NOMASK,prmBC000T10)
           ,new CursorDef("BC000T11", "SELECT [AlmDsc] AS UsuAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @UsuAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T12", "SELECT T2.[AlmDsc] AS UsuAlmDsc, TM1.[UsuAlmSts], TM1.[UsuCod], TM1.[UsuAlmCod] AS UsuAlmCod FROM ([SGUSUARIOALMACEN] TM1 INNER JOIN [CALMACEN] T2 ON T2.[AlmCod] = TM1.[UsuAlmCod]) WHERE TM1.[UsuCod] = @UsuCod and TM1.[UsuAlmCod] = @UsuAlmCod ORDER BY TM1.[UsuCod], TM1.[UsuAlmCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T13", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T13,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
