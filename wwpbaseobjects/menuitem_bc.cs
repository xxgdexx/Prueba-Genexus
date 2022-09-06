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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuitem_bc : GxSilentTrn, IGxSilentTrn
   {
      public menuitem_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitem_bc( IGxContext context )
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
         ReadRow0I19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I19( ) ;
         standaloneModal( ) ;
         AddRow0I19( ) ;
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
            E110I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z352MenuItemId = A352MenuItemId;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I19( ) ;
            }
            else
            {
               CheckExtendedTable0I19( ) ;
               if ( AnyError == 0 )
               {
                  ZM0I19( 11) ;
               }
               CloseExtendedTableCursors0I19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "MenuItemFatherId") == 0 )
               {
                  AV11Insert_MenuItemFatherId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E110I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV13MenuItemFatherId == 0 )
         {
         }
      }

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z1222MenuItemCaption = A1222MenuItemCaption;
            Z1229MenuItemOrder = A1229MenuItemOrder;
            Z1232MenuItemType = A1232MenuItemType;
            Z1226MenuItemLink = A1226MenuItemLink;
            Z1227MenuItemLinkParameters = A1227MenuItemLinkParameters;
            Z1228MenuItemLinkTarget = A1228MenuItemLinkTarget;
            Z1225MenuItemIconClass = A1225MenuItemIconClass;
            Z1230MenuItemShowDeveloperMenuOptio = A1230MenuItemShowDeveloperMenuOptio;
            Z1231MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
            Z353MenuItemFatherId = A353MenuItemFatherId;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z1223MenuItemFatherCaption = A1223MenuItemFatherCaption;
            Z1224MenuItemFatherType = A1224MenuItemFatherType;
         }
         if ( GX_JID == -10 )
         {
            Z352MenuItemId = A352MenuItemId;
            Z1222MenuItemCaption = A1222MenuItemCaption;
            Z1229MenuItemOrder = A1229MenuItemOrder;
            Z1232MenuItemType = A1232MenuItemType;
            Z1226MenuItemLink = A1226MenuItemLink;
            Z1227MenuItemLinkParameters = A1227MenuItemLinkParameters;
            Z1228MenuItemLinkTarget = A1228MenuItemLinkTarget;
            Z1225MenuItemIconClass = A1225MenuItemIconClass;
            Z1230MenuItemShowDeveloperMenuOptio = A1230MenuItemShowDeveloperMenuOptio;
            Z1231MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
            Z353MenuItemFatherId = A353MenuItemFatherId;
            Z1223MenuItemFatherCaption = A1223MenuItemFatherCaption;
            Z1224MenuItemFatherType = A1224MenuItemFatherType;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            GXt_int1 = A352MenuItemId;
            new GeneXus.Programs.wwpbaseobjects.obtieneitemmenu(context ).execute( out  GXt_int1) ;
            A352MenuItemId = GXt_int1;
         }
         AV24Pgmname = "WWPBaseObjects.MenuItem_BC";
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0I19( )
      {
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
            A1222MenuItemCaption = BC000I5_A1222MenuItemCaption[0];
            A1229MenuItemOrder = BC000I5_A1229MenuItemOrder[0];
            A1223MenuItemFatherCaption = BC000I5_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = BC000I5_A1224MenuItemFatherType[0];
            A1232MenuItemType = BC000I5_A1232MenuItemType[0];
            A1226MenuItemLink = BC000I5_A1226MenuItemLink[0];
            A1227MenuItemLinkParameters = BC000I5_A1227MenuItemLinkParameters[0];
            A1228MenuItemLinkTarget = BC000I5_A1228MenuItemLinkTarget[0];
            A1225MenuItemIconClass = BC000I5_A1225MenuItemIconClass[0];
            A1230MenuItemShowDeveloperMenuOptio = BC000I5_A1230MenuItemShowDeveloperMenuOptio[0];
            A1231MenuItemShowEditMenuOptions = BC000I5_A1231MenuItemShowEditMenuOptions[0];
            A353MenuItemFatherId = BC000I5_A353MenuItemFatherId[0];
            n353MenuItemFatherId = BC000I5_n353MenuItemFatherId[0];
            ZM0I19( -10) ;
         }
         pr_default.close(3);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         standaloneModal( ) ;
         if ( (0==A352MenuItemId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Id", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Caption", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A1229MenuItemOrder) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Menu Item Order", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A353MenuItemFatherId) ) )
            {
               GX_msglist.addItem("No existe 'Menu Item Father'.", "ForeignKeyNotFound", 1, "MENUITEMFATHERID");
               AnyError = 1;
            }
         }
         A1223MenuItemFatherCaption = BC000I4_A1223MenuItemFatherCaption[0];
         A1224MenuItemFatherType = BC000I4_A1224MenuItemFatherType[0];
         pr_default.close(2);
         if ( ! ( ( A1232MenuItemType == 1 ) || ( A1232MenuItemType == 2 ) ) )
         {
            GX_msglist.addItem("Campo Type fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0I19( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I19( )
      {
         /* Using cursor BC000I6 */
         pr_default.execute(4, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I19( 10) ;
            RcdFound19 = 1;
            A352MenuItemId = BC000I3_A352MenuItemId[0];
            A1222MenuItemCaption = BC000I3_A1222MenuItemCaption[0];
            A1229MenuItemOrder = BC000I3_A1229MenuItemOrder[0];
            A1232MenuItemType = BC000I3_A1232MenuItemType[0];
            A1226MenuItemLink = BC000I3_A1226MenuItemLink[0];
            A1227MenuItemLinkParameters = BC000I3_A1227MenuItemLinkParameters[0];
            A1228MenuItemLinkTarget = BC000I3_A1228MenuItemLinkTarget[0];
            A1225MenuItemIconClass = BC000I3_A1225MenuItemIconClass[0];
            A1230MenuItemShowDeveloperMenuOptio = BC000I3_A1230MenuItemShowDeveloperMenuOptio[0];
            A1231MenuItemShowEditMenuOptions = BC000I3_A1231MenuItemShowEditMenuOptions[0];
            A353MenuItemFatherId = BC000I3_A353MenuItemFatherId[0];
            n353MenuItemFatherId = BC000I3_n353MenuItemFatherId[0];
            Z352MenuItemId = A352MenuItemId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0I0( ) ;
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

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A352MenuItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SIGERPMenu"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1222MenuItemCaption, BC000I2_A1222MenuItemCaption[0]) != 0 ) || ( Z1229MenuItemOrder != BC000I2_A1229MenuItemOrder[0] ) || ( Z1232MenuItemType != BC000I2_A1232MenuItemType[0] ) || ( StringUtil.StrCmp(Z1226MenuItemLink, BC000I2_A1226MenuItemLink[0]) != 0 ) || ( StringUtil.StrCmp(Z1227MenuItemLinkParameters, BC000I2_A1227MenuItemLinkParameters[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1228MenuItemLinkTarget, BC000I2_A1228MenuItemLinkTarget[0]) != 0 ) || ( StringUtil.StrCmp(Z1225MenuItemIconClass, BC000I2_A1225MenuItemIconClass[0]) != 0 ) || ( Z1230MenuItemShowDeveloperMenuOptio != BC000I2_A1230MenuItemShowDeveloperMenuOptio[0] ) || ( Z1231MenuItemShowEditMenuOptions != BC000I2_A1231MenuItemShowEditMenuOptions[0] ) || ( Z353MenuItemFatherId != BC000I2_A353MenuItemFatherId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SIGERPMenu"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I7 */
                     pr_default.execute(5, new Object[] {A352MenuItemId, A1222MenuItemCaption, A1229MenuItemOrder, A1232MenuItemType, A1226MenuItemLink, A1227MenuItemLinkParameters, A1228MenuItemLinkTarget, A1225MenuItemIconClass, A1230MenuItemShowDeveloperMenuOptio, A1231MenuItemShowEditMenuOptions, n353MenuItemFatherId, A353MenuItemFatherId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new GeneXus.Programs.wwpbaseobjects.updatemenuitemorder(context ).execute( ref  A352MenuItemId) ;
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I8 */
                     pr_default.execute(6, new Object[] {A1222MenuItemCaption, A1229MenuItemOrder, A1232MenuItemType, A1226MenuItemLink, A1227MenuItemLinkParameters, A1228MenuItemLinkTarget, A1225MenuItemIconClass, A1230MenuItemShowDeveloperMenuOptio, A1231MenuItemShowEditMenuOptions, n353MenuItemFatherId, A353MenuItemFatherId, A352MenuItemId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SIGERPMenu"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
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
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I9 */
                  pr_default.execute(7, new Object[] {A352MenuItemId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000I10 */
            pr_default.execute(8, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
            A1223MenuItemFatherCaption = BC000I10_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = BC000I10_A1224MenuItemFatherType[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000I11 */
            pr_default.execute(9, new Object[] {A352MenuItemId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item de Menú"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
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

      public void ScanKeyStart0I19( )
      {
         /* Scan By routine */
         /* Using cursor BC000I12 */
         pr_default.execute(10, new Object[] {A352MenuItemId});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound19 = 1;
            A352MenuItemId = BC000I12_A352MenuItemId[0];
            A1222MenuItemCaption = BC000I12_A1222MenuItemCaption[0];
            A1229MenuItemOrder = BC000I12_A1229MenuItemOrder[0];
            A1223MenuItemFatherCaption = BC000I12_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = BC000I12_A1224MenuItemFatherType[0];
            A1232MenuItemType = BC000I12_A1232MenuItemType[0];
            A1226MenuItemLink = BC000I12_A1226MenuItemLink[0];
            A1227MenuItemLinkParameters = BC000I12_A1227MenuItemLinkParameters[0];
            A1228MenuItemLinkTarget = BC000I12_A1228MenuItemLinkTarget[0];
            A1225MenuItemIconClass = BC000I12_A1225MenuItemIconClass[0];
            A1230MenuItemShowDeveloperMenuOptio = BC000I12_A1230MenuItemShowDeveloperMenuOptio[0];
            A1231MenuItemShowEditMenuOptions = BC000I12_A1231MenuItemShowEditMenuOptions[0];
            A353MenuItemFatherId = BC000I12_A353MenuItemFatherId[0];
            n353MenuItemFatherId = BC000I12_n353MenuItemFatherId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I19( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound19 = 0;
         ScanKeyLoad0I19( ) ;
      }

      protected void ScanKeyLoad0I19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound19 = 1;
            A352MenuItemId = BC000I12_A352MenuItemId[0];
            A1222MenuItemCaption = BC000I12_A1222MenuItemCaption[0];
            A1229MenuItemOrder = BC000I12_A1229MenuItemOrder[0];
            A1223MenuItemFatherCaption = BC000I12_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = BC000I12_A1224MenuItemFatherType[0];
            A1232MenuItemType = BC000I12_A1232MenuItemType[0];
            A1226MenuItemLink = BC000I12_A1226MenuItemLink[0];
            A1227MenuItemLinkParameters = BC000I12_A1227MenuItemLinkParameters[0];
            A1228MenuItemLinkTarget = BC000I12_A1228MenuItemLinkTarget[0];
            A1225MenuItemIconClass = BC000I12_A1225MenuItemIconClass[0];
            A1230MenuItemShowDeveloperMenuOptio = BC000I12_A1230MenuItemShowDeveloperMenuOptio[0];
            A1231MenuItemShowEditMenuOptions = BC000I12_A1231MenuItemShowEditMenuOptions[0];
            A353MenuItemFatherId = BC000I12_A353MenuItemFatherId[0];
            n353MenuItemFatherId = BC000I12_n353MenuItemFatherId[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0I19( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
         if ( (0==A353MenuItemFatherId) )
         {
            A353MenuItemFatherId = 0;
            n353MenuItemFatherId = false;
            n353MenuItemFatherId = true;
         }
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I19( )
      {
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void AddRow0I19( )
      {
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
      }

      protected void ReadRow0I19( )
      {
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
      }

      protected void InitializeNonKey0I19( )
      {
         A1222MenuItemCaption = "";
         A1229MenuItemOrder = 0;
         A353MenuItemFatherId = 0;
         n353MenuItemFatherId = false;
         A1223MenuItemFatherCaption = "";
         A1224MenuItemFatherType = 0;
         A1232MenuItemType = 0;
         A1226MenuItemLink = "";
         A1227MenuItemLinkParameters = "";
         A1228MenuItemLinkTarget = "";
         A1225MenuItemIconClass = "";
         A1230MenuItemShowDeveloperMenuOptio = false;
         A1231MenuItemShowEditMenuOptions = false;
         Z1222MenuItemCaption = "";
         Z1229MenuItemOrder = 0;
         Z1232MenuItemType = 0;
         Z1226MenuItemLink = "";
         Z1227MenuItemLinkParameters = "";
         Z1228MenuItemLinkTarget = "";
         Z1225MenuItemIconClass = "";
         Z1230MenuItemShowDeveloperMenuOptio = false;
         Z1231MenuItemShowEditMenuOptions = false;
         Z353MenuItemFatherId = 0;
      }

      protected void InitAll0I19( )
      {
         A352MenuItemId = 0;
         InitializeNonKey0I19( ) ;
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

      public void VarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtMenuItem obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Menuitemcaption = A1222MenuItemCaption;
         obj19.gxTpr_Menuitemorder = A1229MenuItemOrder;
         obj19.gxTpr_Menuitemfatherid = A353MenuItemFatherId;
         obj19.gxTpr_Menuitemfathercaption = A1223MenuItemFatherCaption;
         obj19.gxTpr_Menuitemfathertype = A1224MenuItemFatherType;
         obj19.gxTpr_Menuitemtype = A1232MenuItemType;
         obj19.gxTpr_Menuitemlink = A1226MenuItemLink;
         obj19.gxTpr_Menuitemlinkparameters = A1227MenuItemLinkParameters;
         obj19.gxTpr_Menuitemlinktarget = A1228MenuItemLinkTarget;
         obj19.gxTpr_Menuitemiconclass = A1225MenuItemIconClass;
         obj19.gxTpr_Menuitemshowdevelopermenuoption = A1230MenuItemShowDeveloperMenuOptio;
         obj19.gxTpr_Menuitemshoweditmenuoptions = A1231MenuItemShowEditMenuOptions;
         obj19.gxTpr_Menuitemid = A352MenuItemId;
         obj19.gxTpr_Menuitemid_Z = Z352MenuItemId;
         obj19.gxTpr_Menuitemcaption_Z = Z1222MenuItemCaption;
         obj19.gxTpr_Menuitemorder_Z = Z1229MenuItemOrder;
         obj19.gxTpr_Menuitemfatherid_Z = Z353MenuItemFatherId;
         obj19.gxTpr_Menuitemfathercaption_Z = Z1223MenuItemFatherCaption;
         obj19.gxTpr_Menuitemfathertype_Z = Z1224MenuItemFatherType;
         obj19.gxTpr_Menuitemtype_Z = Z1232MenuItemType;
         obj19.gxTpr_Menuitemlink_Z = Z1226MenuItemLink;
         obj19.gxTpr_Menuitemlinkparameters_Z = Z1227MenuItemLinkParameters;
         obj19.gxTpr_Menuitemlinktarget_Z = Z1228MenuItemLinkTarget;
         obj19.gxTpr_Menuitemiconclass_Z = Z1225MenuItemIconClass;
         obj19.gxTpr_Menuitemshowdevelopermenuoption_Z = Z1230MenuItemShowDeveloperMenuOptio;
         obj19.gxTpr_Menuitemshoweditmenuoptions_Z = Z1231MenuItemShowEditMenuOptions;
         obj19.gxTpr_Menuitemfatherid_N = (short)(Convert.ToInt16(n353MenuItemFatherId));
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtMenuItem obj19 )
      {
         obj19.gxTpr_Menuitemid = A352MenuItemId;
         return  ;
      }

      public void RowToVars19( GeneXus.Programs.wwpbaseobjects.SdtMenuItem obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A1222MenuItemCaption = obj19.gxTpr_Menuitemcaption;
         A1229MenuItemOrder = obj19.gxTpr_Menuitemorder;
         A353MenuItemFatherId = obj19.gxTpr_Menuitemfatherid;
         n353MenuItemFatherId = false;
         A1223MenuItemFatherCaption = obj19.gxTpr_Menuitemfathercaption;
         A1224MenuItemFatherType = obj19.gxTpr_Menuitemfathertype;
         A1232MenuItemType = obj19.gxTpr_Menuitemtype;
         A1226MenuItemLink = obj19.gxTpr_Menuitemlink;
         A1227MenuItemLinkParameters = obj19.gxTpr_Menuitemlinkparameters;
         A1228MenuItemLinkTarget = obj19.gxTpr_Menuitemlinktarget;
         A1225MenuItemIconClass = obj19.gxTpr_Menuitemiconclass;
         A1230MenuItemShowDeveloperMenuOptio = obj19.gxTpr_Menuitemshowdevelopermenuoption;
         A1231MenuItemShowEditMenuOptions = obj19.gxTpr_Menuitemshoweditmenuoptions;
         A352MenuItemId = obj19.gxTpr_Menuitemid;
         Z352MenuItemId = obj19.gxTpr_Menuitemid_Z;
         Z1222MenuItemCaption = obj19.gxTpr_Menuitemcaption_Z;
         Z1229MenuItemOrder = obj19.gxTpr_Menuitemorder_Z;
         Z353MenuItemFatherId = obj19.gxTpr_Menuitemfatherid_Z;
         Z1223MenuItemFatherCaption = obj19.gxTpr_Menuitemfathercaption_Z;
         Z1224MenuItemFatherType = obj19.gxTpr_Menuitemfathertype_Z;
         Z1232MenuItemType = obj19.gxTpr_Menuitemtype_Z;
         Z1226MenuItemLink = obj19.gxTpr_Menuitemlink_Z;
         Z1227MenuItemLinkParameters = obj19.gxTpr_Menuitemlinkparameters_Z;
         Z1228MenuItemLinkTarget = obj19.gxTpr_Menuitemlinktarget_Z;
         Z1225MenuItemIconClass = obj19.gxTpr_Menuitemiconclass_Z;
         Z1230MenuItemShowDeveloperMenuOptio = obj19.gxTpr_Menuitemshowdevelopermenuoption_Z;
         Z1231MenuItemShowEditMenuOptions = obj19.gxTpr_Menuitemshoweditmenuoptions_Z;
         n353MenuItemFatherId = (bool)(Convert.ToBoolean(obj19.gxTpr_Menuitemfatherid_N));
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A352MenuItemId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I19( ) ;
         ScanKeyStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z352MenuItemId = A352MenuItemId;
         }
         ZM0I19( -10) ;
         OnLoadActions0I19( ) ;
         AddRow0I19( ) ;
         ScanKeyEnd0I19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcwwpbaseobjects_MenuItem, 0) ;
         ScanKeyStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z352MenuItemId = A352MenuItemId;
         }
         ZM0I19( -10) ;
         OnLoadActions0I19( ) ;
         AddRow0I19( ) ;
         ScanKeyEnd0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A352MenuItemId != Z352MenuItemId )
               {
                  A352MenuItemId = Z352MenuItemId;
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
                  Update0I19( ) ;
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
                  if ( A352MenuItemId != Z352MenuItemId )
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
                        Insert0I19( ) ;
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
                        Insert0I19( ) ;
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
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
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
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
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
            GeneXus.Programs.wwpbaseobjects.SdtMenuItem auxBC = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A352MenuItemId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_MenuItem);
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
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
         UpdateImpl( ) ;
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
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
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I19( ) ;
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
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars19( bcwwpbaseobjects_MenuItem, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0I19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A352MenuItemId != Z352MenuItemId )
            {
               A352MenuItemId = Z352MenuItemId;
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
            if ( A352MenuItemId != Z352MenuItemId )
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
         pr_default.close(8);
         context.RollbackDataStores("wwpbaseobjects.menuitem_bc",pr_default);
         VarsToRow19( bcwwpbaseobjects_MenuItem) ;
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
         Gx_mode = bcwwpbaseobjects_MenuItem.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_MenuItem.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_MenuItem )
         {
            bcwwpbaseobjects_MenuItem = (GeneXus.Programs.wwpbaseobjects.SdtMenuItem)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_MenuItem.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_MenuItem.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcwwpbaseobjects_MenuItem) ;
            }
            else
            {
               RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_MenuItem.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_MenuItem.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcwwpbaseobjects_MenuItem, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtMenuItem MenuItem_BC
      {
         get {
            return bcwwpbaseobjects_MenuItem ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV24Pgmname = "";
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z1222MenuItemCaption = "";
         A1222MenuItemCaption = "";
         Z1226MenuItemLink = "";
         A1226MenuItemLink = "";
         Z1227MenuItemLinkParameters = "";
         A1227MenuItemLinkParameters = "";
         Z1228MenuItemLinkTarget = "";
         A1228MenuItemLinkTarget = "";
         Z1225MenuItemIconClass = "";
         A1225MenuItemIconClass = "";
         Z1223MenuItemFatherCaption = "";
         A1223MenuItemFatherCaption = "";
         BC000I5_A352MenuItemId = new short[1] ;
         BC000I5_A1222MenuItemCaption = new string[] {""} ;
         BC000I5_A1229MenuItemOrder = new short[1] ;
         BC000I5_A1223MenuItemFatherCaption = new string[] {""} ;
         BC000I5_A1224MenuItemFatherType = new short[1] ;
         BC000I5_A1232MenuItemType = new short[1] ;
         BC000I5_A1226MenuItemLink = new string[] {""} ;
         BC000I5_A1227MenuItemLinkParameters = new string[] {""} ;
         BC000I5_A1228MenuItemLinkTarget = new string[] {""} ;
         BC000I5_A1225MenuItemIconClass = new string[] {""} ;
         BC000I5_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         BC000I5_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         BC000I5_A353MenuItemFatherId = new short[1] ;
         BC000I5_n353MenuItemFatherId = new bool[] {false} ;
         BC000I4_A1223MenuItemFatherCaption = new string[] {""} ;
         BC000I4_A1224MenuItemFatherType = new short[1] ;
         BC000I6_A352MenuItemId = new short[1] ;
         BC000I3_A352MenuItemId = new short[1] ;
         BC000I3_A1222MenuItemCaption = new string[] {""} ;
         BC000I3_A1229MenuItemOrder = new short[1] ;
         BC000I3_A1232MenuItemType = new short[1] ;
         BC000I3_A1226MenuItemLink = new string[] {""} ;
         BC000I3_A1227MenuItemLinkParameters = new string[] {""} ;
         BC000I3_A1228MenuItemLinkTarget = new string[] {""} ;
         BC000I3_A1225MenuItemIconClass = new string[] {""} ;
         BC000I3_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         BC000I3_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         BC000I3_A353MenuItemFatherId = new short[1] ;
         BC000I3_n353MenuItemFatherId = new bool[] {false} ;
         sMode19 = "";
         BC000I2_A352MenuItemId = new short[1] ;
         BC000I2_A1222MenuItemCaption = new string[] {""} ;
         BC000I2_A1229MenuItemOrder = new short[1] ;
         BC000I2_A1232MenuItemType = new short[1] ;
         BC000I2_A1226MenuItemLink = new string[] {""} ;
         BC000I2_A1227MenuItemLinkParameters = new string[] {""} ;
         BC000I2_A1228MenuItemLinkTarget = new string[] {""} ;
         BC000I2_A1225MenuItemIconClass = new string[] {""} ;
         BC000I2_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         BC000I2_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         BC000I2_A353MenuItemFatherId = new short[1] ;
         BC000I2_n353MenuItemFatherId = new bool[] {false} ;
         BC000I10_A1223MenuItemFatherCaption = new string[] {""} ;
         BC000I10_A1224MenuItemFatherType = new short[1] ;
         BC000I11_A353MenuItemFatherId = new short[1] ;
         BC000I11_n353MenuItemFatherId = new bool[] {false} ;
         BC000I12_A352MenuItemId = new short[1] ;
         BC000I12_A1222MenuItemCaption = new string[] {""} ;
         BC000I12_A1229MenuItemOrder = new short[1] ;
         BC000I12_A1223MenuItemFatherCaption = new string[] {""} ;
         BC000I12_A1224MenuItemFatherType = new short[1] ;
         BC000I12_A1232MenuItemType = new short[1] ;
         BC000I12_A1226MenuItemLink = new string[] {""} ;
         BC000I12_A1227MenuItemLinkParameters = new string[] {""} ;
         BC000I12_A1228MenuItemLinkTarget = new string[] {""} ;
         BC000I12_A1225MenuItemIconClass = new string[] {""} ;
         BC000I12_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         BC000I12_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         BC000I12_A353MenuItemFatherId = new short[1] ;
         BC000I12_n353MenuItemFatherId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitem_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitem_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A352MenuItemId, BC000I2_A1222MenuItemCaption, BC000I2_A1229MenuItemOrder, BC000I2_A1232MenuItemType, BC000I2_A1226MenuItemLink, BC000I2_A1227MenuItemLinkParameters, BC000I2_A1228MenuItemLinkTarget, BC000I2_A1225MenuItemIconClass, BC000I2_A1230MenuItemShowDeveloperMenuOptio, BC000I2_A1231MenuItemShowEditMenuOptions,
               BC000I2_A353MenuItemFatherId, BC000I2_n353MenuItemFatherId
               }
               , new Object[] {
               BC000I3_A352MenuItemId, BC000I3_A1222MenuItemCaption, BC000I3_A1229MenuItemOrder, BC000I3_A1232MenuItemType, BC000I3_A1226MenuItemLink, BC000I3_A1227MenuItemLinkParameters, BC000I3_A1228MenuItemLinkTarget, BC000I3_A1225MenuItemIconClass, BC000I3_A1230MenuItemShowDeveloperMenuOptio, BC000I3_A1231MenuItemShowEditMenuOptions,
               BC000I3_A353MenuItemFatherId, BC000I3_n353MenuItemFatherId
               }
               , new Object[] {
               BC000I4_A1223MenuItemFatherCaption, BC000I4_A1224MenuItemFatherType
               }
               , new Object[] {
               BC000I5_A352MenuItemId, BC000I5_A1222MenuItemCaption, BC000I5_A1229MenuItemOrder, BC000I5_A1223MenuItemFatherCaption, BC000I5_A1224MenuItemFatherType, BC000I5_A1232MenuItemType, BC000I5_A1226MenuItemLink, BC000I5_A1227MenuItemLinkParameters, BC000I5_A1228MenuItemLinkTarget, BC000I5_A1225MenuItemIconClass,
               BC000I5_A1230MenuItemShowDeveloperMenuOptio, BC000I5_A1231MenuItemShowEditMenuOptions, BC000I5_A353MenuItemFatherId, BC000I5_n353MenuItemFatherId
               }
               , new Object[] {
               BC000I6_A352MenuItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I10_A1223MenuItemFatherCaption, BC000I10_A1224MenuItemFatherType
               }
               , new Object[] {
               BC000I11_A353MenuItemFatherId
               }
               , new Object[] {
               BC000I12_A352MenuItemId, BC000I12_A1222MenuItemCaption, BC000I12_A1229MenuItemOrder, BC000I12_A1223MenuItemFatherCaption, BC000I12_A1224MenuItemFatherType, BC000I12_A1232MenuItemType, BC000I12_A1226MenuItemLink, BC000I12_A1227MenuItemLinkParameters, BC000I12_A1228MenuItemLinkTarget, BC000I12_A1225MenuItemIconClass,
               BC000I12_A1230MenuItemShowDeveloperMenuOptio, BC000I12_A1231MenuItemShowEditMenuOptions, BC000I12_A353MenuItemFatherId, BC000I12_n353MenuItemFatherId
               }
            }
         );
         AV24Pgmname = "WWPBaseObjects.MenuItem_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120I2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z352MenuItemId ;
      private short A352MenuItemId ;
      private short AV11Insert_MenuItemFatherId ;
      private short AV13MenuItemFatherId ;
      private short GX_JID ;
      private short Z1229MenuItemOrder ;
      private short A1229MenuItemOrder ;
      private short Z1232MenuItemType ;
      private short A1232MenuItemType ;
      private short Z353MenuItemFatherId ;
      private short A353MenuItemFatherId ;
      private short Z1224MenuItemFatherType ;
      private short A1224MenuItemFatherType ;
      private short GXt_int1 ;
      private short Gx_BScreen ;
      private short RcdFound19 ;
      private short nIsDirty_19 ;
      private int trnEnded ;
      private int AV25GXV1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string sMode19 ;
      private bool returnInSub ;
      private bool Z1230MenuItemShowDeveloperMenuOptio ;
      private bool A1230MenuItemShowDeveloperMenuOptio ;
      private bool Z1231MenuItemShowEditMenuOptions ;
      private bool A1231MenuItemShowEditMenuOptions ;
      private bool n353MenuItemFatherId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z1222MenuItemCaption ;
      private string A1222MenuItemCaption ;
      private string Z1226MenuItemLink ;
      private string A1226MenuItemLink ;
      private string Z1227MenuItemLinkParameters ;
      private string A1227MenuItemLinkParameters ;
      private string Z1228MenuItemLinkTarget ;
      private string A1228MenuItemLinkTarget ;
      private string Z1225MenuItemIconClass ;
      private string A1225MenuItemIconClass ;
      private string Z1223MenuItemFatherCaption ;
      private string A1223MenuItemFatherCaption ;
      private IGxSession AV10WebSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtMenuItem bcwwpbaseobjects_MenuItem ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000I5_A352MenuItemId ;
      private string[] BC000I5_A1222MenuItemCaption ;
      private short[] BC000I5_A1229MenuItemOrder ;
      private string[] BC000I5_A1223MenuItemFatherCaption ;
      private short[] BC000I5_A1224MenuItemFatherType ;
      private short[] BC000I5_A1232MenuItemType ;
      private string[] BC000I5_A1226MenuItemLink ;
      private string[] BC000I5_A1227MenuItemLinkParameters ;
      private string[] BC000I5_A1228MenuItemLinkTarget ;
      private string[] BC000I5_A1225MenuItemIconClass ;
      private bool[] BC000I5_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] BC000I5_A1231MenuItemShowEditMenuOptions ;
      private short[] BC000I5_A353MenuItemFatherId ;
      private bool[] BC000I5_n353MenuItemFatherId ;
      private string[] BC000I4_A1223MenuItemFatherCaption ;
      private short[] BC000I4_A1224MenuItemFatherType ;
      private short[] BC000I6_A352MenuItemId ;
      private short[] BC000I3_A352MenuItemId ;
      private string[] BC000I3_A1222MenuItemCaption ;
      private short[] BC000I3_A1229MenuItemOrder ;
      private short[] BC000I3_A1232MenuItemType ;
      private string[] BC000I3_A1226MenuItemLink ;
      private string[] BC000I3_A1227MenuItemLinkParameters ;
      private string[] BC000I3_A1228MenuItemLinkTarget ;
      private string[] BC000I3_A1225MenuItemIconClass ;
      private bool[] BC000I3_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] BC000I3_A1231MenuItemShowEditMenuOptions ;
      private short[] BC000I3_A353MenuItemFatherId ;
      private bool[] BC000I3_n353MenuItemFatherId ;
      private short[] BC000I2_A352MenuItemId ;
      private string[] BC000I2_A1222MenuItemCaption ;
      private short[] BC000I2_A1229MenuItemOrder ;
      private short[] BC000I2_A1232MenuItemType ;
      private string[] BC000I2_A1226MenuItemLink ;
      private string[] BC000I2_A1227MenuItemLinkParameters ;
      private string[] BC000I2_A1228MenuItemLinkTarget ;
      private string[] BC000I2_A1225MenuItemIconClass ;
      private bool[] BC000I2_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] BC000I2_A1231MenuItemShowEditMenuOptions ;
      private short[] BC000I2_A353MenuItemFatherId ;
      private bool[] BC000I2_n353MenuItemFatherId ;
      private string[] BC000I10_A1223MenuItemFatherCaption ;
      private short[] BC000I10_A1224MenuItemFatherType ;
      private short[] BC000I11_A353MenuItemFatherId ;
      private bool[] BC000I11_n353MenuItemFatherId ;
      private short[] BC000I12_A352MenuItemId ;
      private string[] BC000I12_A1222MenuItemCaption ;
      private short[] BC000I12_A1229MenuItemOrder ;
      private string[] BC000I12_A1223MenuItemFatherCaption ;
      private short[] BC000I12_A1224MenuItemFatherType ;
      private short[] BC000I12_A1232MenuItemType ;
      private string[] BC000I12_A1226MenuItemLink ;
      private string[] BC000I12_A1227MenuItemLinkParameters ;
      private string[] BC000I12_A1228MenuItemLinkTarget ;
      private string[] BC000I12_A1225MenuItemIconClass ;
      private bool[] BC000I12_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] BC000I12_A1231MenuItemShowEditMenuOptions ;
      private short[] BC000I12_A353MenuItemFatherId ;
      private bool[] BC000I12_n353MenuItemFatherId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class menuitem_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class menuitem_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000I5;
        prmBC000I5 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I4;
        prmBC000I4 = new Object[] {
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000I6;
        prmBC000I6 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I3;
        prmBC000I3 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I2;
        prmBC000I2 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I7;
        prmBC000I7 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0) ,
        new ParDef("@MenuItemCaption",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemOrder",GXType.Int16,4,0) ,
        new ParDef("@MenuItemType",GXType.Int16,1,0) ,
        new ParDef("@MenuItemLink",GXType.NVarChar,80,0) ,
        new ParDef("@MenuItemLinkParameters",GXType.NVarChar,100,0) ,
        new ParDef("@MenuItemLinkTarget",GXType.NVarChar,10,0) ,
        new ParDef("@MenuItemIconClass",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemShowDeveloperMenuOptio",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemShowEditMenuOptions",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000I8;
        prmBC000I8 = new Object[] {
        new ParDef("@MenuItemCaption",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemOrder",GXType.Int16,4,0) ,
        new ParDef("@MenuItemType",GXType.Int16,1,0) ,
        new ParDef("@MenuItemLink",GXType.NVarChar,80,0) ,
        new ParDef("@MenuItemLinkParameters",GXType.NVarChar,100,0) ,
        new ParDef("@MenuItemLinkTarget",GXType.NVarChar,10,0) ,
        new ParDef("@MenuItemIconClass",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemShowDeveloperMenuOptio",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemShowEditMenuOptions",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I9;
        prmBC000I9 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I10;
        prmBC000I10 = new Object[] {
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmBC000I11;
        prmBC000I11 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmBC000I12;
        prmBC000I12 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000I2", "SELECT [MenuItemId], [MenuItemCaption], [MenuItemOrder], [MenuItemType], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId] AS MenuItemFatherId FROM [SIGERPMenu] WITH (UPDLOCK) WHERE [MenuItemId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I3", "SELECT [MenuItemId], [MenuItemCaption], [MenuItemOrder], [MenuItemType], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId] AS MenuItemFatherId FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I4", "SELECT [MenuItemCaption] AS MenuItemFatherCaption, [MenuItemType] AS MenuItemFatherType FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemFatherId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I5", "SELECT TM1.[MenuItemId], TM1.[MenuItemCaption], TM1.[MenuItemOrder], T2.[MenuItemCaption] AS MenuItemFatherCaption, T2.[MenuItemType] AS MenuItemFatherType, TM1.[MenuItemType], TM1.[MenuItemLink], TM1.[MenuItemLinkParameters], TM1.[MenuItemLinkTarget], TM1.[MenuItemIconClass], TM1.[MenuItemShowDeveloperMenuOptio], TM1.[MenuItemShowEditMenuOptions], TM1.[MenuItemFatherId] AS MenuItemFatherId FROM ([SIGERPMenu] TM1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = TM1.[MenuItemFatherId]) WHERE TM1.[MenuItemId] = @MenuItemId ORDER BY TM1.[MenuItemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I6", "SELECT [MenuItemId] FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I7", "INSERT INTO [SIGERPMenu]([MenuItemId], [MenuItemCaption], [MenuItemOrder], [MenuItemType], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId]) VALUES(@MenuItemId, @MenuItemCaption, @MenuItemOrder, @MenuItemType, @MenuItemLink, @MenuItemLinkParameters, @MenuItemLinkTarget, @MenuItemIconClass, @MenuItemShowDeveloperMenuOptio, @MenuItemShowEditMenuOptions, @MenuItemFatherId)", GxErrorMask.GX_NOMASK,prmBC000I7)
           ,new CursorDef("BC000I8", "UPDATE [SIGERPMenu] SET [MenuItemCaption]=@MenuItemCaption, [MenuItemOrder]=@MenuItemOrder, [MenuItemType]=@MenuItemType, [MenuItemLink]=@MenuItemLink, [MenuItemLinkParameters]=@MenuItemLinkParameters, [MenuItemLinkTarget]=@MenuItemLinkTarget, [MenuItemIconClass]=@MenuItemIconClass, [MenuItemShowDeveloperMenuOptio]=@MenuItemShowDeveloperMenuOptio, [MenuItemShowEditMenuOptions]=@MenuItemShowEditMenuOptions, [MenuItemFatherId]=@MenuItemFatherId  WHERE [MenuItemId] = @MenuItemId", GxErrorMask.GX_NOMASK,prmBC000I8)
           ,new CursorDef("BC000I9", "DELETE FROM [SIGERPMenu]  WHERE [MenuItemId] = @MenuItemId", GxErrorMask.GX_NOMASK,prmBC000I9)
           ,new CursorDef("BC000I10", "SELECT [MenuItemCaption] AS MenuItemFatherCaption, [MenuItemType] AS MenuItemFatherType FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemFatherId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I11", "SELECT TOP 1 [MenuItemId] AS MenuItemFatherId FROM [SIGERPMenu] WHERE [MenuItemFatherId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000I12", "SELECT TM1.[MenuItemId], TM1.[MenuItemCaption], TM1.[MenuItemOrder], T2.[MenuItemCaption] AS MenuItemFatherCaption, T2.[MenuItemType] AS MenuItemFatherType, TM1.[MenuItemType], TM1.[MenuItemLink], TM1.[MenuItemLinkParameters], TM1.[MenuItemLinkTarget], TM1.[MenuItemIconClass], TM1.[MenuItemShowDeveloperMenuOptio], TM1.[MenuItemShowEditMenuOptions], TM1.[MenuItemFatherId] AS MenuItemFatherId FROM ([SIGERPMenu] TM1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = TM1.[MenuItemFatherId]) WHERE TM1.[MenuItemId] = @MenuItemId ORDER BY TM1.[MenuItemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I12,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              return;
     }
  }

}

}
