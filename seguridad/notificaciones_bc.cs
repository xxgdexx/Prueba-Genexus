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
namespace GeneXus.Programs.seguridad {
   public class notificaciones_bc : GxSilentTrn, IGxSilentTrn
   {
      public notificaciones_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificaciones_bc( IGxContext context )
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
         ReadRow7A198( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey7A198( ) ;
         standaloneModal( ) ;
         AddRow7A198( ) ;
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
            E117A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z2237SGNotificacionID = A2237SGNotificacionID;
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

      protected void CONFIRM_7A0( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7A198( ) ;
            }
            else
            {
               CheckExtendedTable7A198( ) ;
               if ( AnyError == 0 )
               {
                  ZM7A198( 13) ;
               }
               CloseExtendedTableCursors7A198( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode198 = Gx_mode;
            CONFIRM_7A199( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode198;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode198;
         }
      }

      protected void CONFIRM_7A199( )
      {
         nGXsfl_199_idx = 0;
         while ( nGXsfl_199_idx < bcseguridad_Notificaciones.gxTpr_Level1.Count )
         {
            ReadRow7A199( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound199 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_199 != 0 ) )
            {
               GetKey7A199( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound199 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate7A199( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM7A199( 15) ;
                        }
                        CloseExtendedTableCursors7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound199 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey7A199( ) ;
                        Load7A199( ) ;
                        BeforeValidate7A199( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls7A199( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_199 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate7A199( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable7A199( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM7A199( 15) ;
                              }
                              CloseExtendedTableCursors7A199( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow199( ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)bcseguridad_Notificaciones.gxTpr_Level1.Item(nGXsfl_199_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E127A2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SGNotificacionUsuario") == 0 )
               {
                  AV11Insert_SGNotificacionUsuario = AV12TrnContextAtt.gxTpr_Attributevalue;
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E117A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM7A198( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z2238SGNotificacionTitulo = A2238SGNotificacionTitulo;
            Z2239SGNotificacionDescripcion = A2239SGNotificacionDescripcion;
            Z2240SGNotificacionFecha = A2240SGNotificacionFecha;
            Z2243SGNotificacionIconClass = A2243SGNotificacionIconClass;
            Z2244SGNotificacionTUsuario = A2244SGNotificacionTUsuario;
            Z2241SGNotificacionUsuario = A2241SGNotificacionUsuario;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z2242SGNotificacionUsuarioDsc = A2242SGNotificacionUsuarioDsc;
         }
         if ( GX_JID == -12 )
         {
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2238SGNotificacionTitulo = A2238SGNotificacionTitulo;
            Z2239SGNotificacionDescripcion = A2239SGNotificacionDescripcion;
            Z2240SGNotificacionFecha = A2240SGNotificacionFecha;
            Z2243SGNotificacionIconClass = A2243SGNotificacionIconClass;
            Z2244SGNotificacionTUsuario = A2244SGNotificacionTUsuario;
            Z2241SGNotificacionUsuario = A2241SGNotificacionUsuario;
            Z2242SGNotificacionUsuarioDsc = A2242SGNotificacionUsuarioDsc;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "Seguridad.Notificaciones_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load7A198( )
      {
         /* Using cursor BC007A8 */
         pr_default.execute(6, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound198 = 1;
            A2238SGNotificacionTitulo = BC007A8_A2238SGNotificacionTitulo[0];
            A2239SGNotificacionDescripcion = BC007A8_A2239SGNotificacionDescripcion[0];
            A2240SGNotificacionFecha = BC007A8_A2240SGNotificacionFecha[0];
            A2242SGNotificacionUsuarioDsc = BC007A8_A2242SGNotificacionUsuarioDsc[0];
            A2243SGNotificacionIconClass = BC007A8_A2243SGNotificacionIconClass[0];
            A2244SGNotificacionTUsuario = BC007A8_A2244SGNotificacionTUsuario[0];
            A2241SGNotificacionUsuario = BC007A8_A2241SGNotificacionUsuario[0];
            ZM7A198( -12) ;
         }
         pr_default.close(6);
         OnLoadActions7A198( ) ;
      }

      protected void OnLoadActions7A198( )
      {
      }

      protected void CheckExtendedTable7A198( )
      {
         nIsDirty_198 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2238SGNotificacionTitulo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Titulo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2239SGNotificacionDescripcion)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripción", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( (DateTime.MinValue==A2240SGNotificacionFecha) || ( A2240SGNotificacionFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (DateTime.MinValue==A2240SGNotificacionFecha) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Fecha Hora", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC007A7 */
         pr_default.execute(5, new Object[] {A2241SGNotificacionUsuario});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONUSUARIO");
            AnyError = 1;
         }
         A2242SGNotificacionUsuarioDsc = BC007A7_A2242SGNotificacionUsuarioDsc[0];
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2241SGNotificacionUsuario)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Usuario", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-info NotificationFontIconInfoLight") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-clipboard-check NotificationFontIconInfo") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "far fa-thumbs-up NotificationFontIconSuccess") == 0 ) || ( StringUtil.StrCmp(A2243SGNotificacionIconClass, "fas fa-exclamation-triangle NotificationFontIconDanger") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Notificación Icon Class fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2243SGNotificacionIconClass)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Notificación Icon Class", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors7A198( )
      {
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7A198( )
      {
         /* Using cursor BC007A9 */
         pr_default.execute(7, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound198 = 1;
         }
         else
         {
            RcdFound198 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC007A6 */
         pr_default.execute(4, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM7A198( 12) ;
            RcdFound198 = 1;
            A2237SGNotificacionID = BC007A6_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = BC007A6_A2238SGNotificacionTitulo[0];
            A2239SGNotificacionDescripcion = BC007A6_A2239SGNotificacionDescripcion[0];
            A2240SGNotificacionFecha = BC007A6_A2240SGNotificacionFecha[0];
            A2243SGNotificacionIconClass = BC007A6_A2243SGNotificacionIconClass[0];
            A2244SGNotificacionTUsuario = BC007A6_A2244SGNotificacionTUsuario[0];
            A2241SGNotificacionUsuario = BC007A6_A2241SGNotificacionUsuario[0];
            Z2237SGNotificacionID = A2237SGNotificacionID;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load7A198( ) ;
            if ( AnyError == 1 )
            {
               RcdFound198 = 0;
               InitializeNonKey7A198( ) ;
            }
            Gx_mode = sMode198;
         }
         else
         {
            RcdFound198 = 0;
            InitializeNonKey7A198( ) ;
            sMode198 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode198;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey7A198( ) ;
         if ( RcdFound198 == 0 )
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
         CONFIRM_7A0( ) ;
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

      protected void CheckOptimisticConcurrency7A198( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC007A5 */
            pr_default.execute(3, new Object[] {A2237SGNotificacionID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z2238SGNotificacionTitulo, BC007A5_A2238SGNotificacionTitulo[0]) != 0 ) || ( StringUtil.StrCmp(Z2239SGNotificacionDescripcion, BC007A5_A2239SGNotificacionDescripcion[0]) != 0 ) || ( Z2240SGNotificacionFecha != BC007A5_A2240SGNotificacionFecha[0] ) || ( StringUtil.StrCmp(Z2243SGNotificacionIconClass, BC007A5_A2243SGNotificacionIconClass[0]) != 0 ) || ( Z2244SGNotificacionTUsuario != BC007A5_A2244SGNotificacionTUsuario[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z2241SGNotificacionUsuario, BC007A5_A2241SGNotificacionUsuario[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7A198( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7A198( 0) ;
            CheckOptimisticConcurrency7A198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7A198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007A10 */
                     pr_default.execute(8, new Object[] {A2237SGNotificacionID, A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ProcessLevel7A198( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load7A198( ) ;
            }
            EndLevel7A198( ) ;
         }
         CloseExtendedTableCursors7A198( ) ;
      }

      protected void Update7A198( )
      {
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A198( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A198( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7A198( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007A11 */
                     pr_default.execute(9, new Object[] {A2238SGNotificacionTitulo, A2239SGNotificacionDescripcion, A2240SGNotificacionFecha, A2243SGNotificacionIconClass, A2244SGNotificacionTUsuario, A2241SGNotificacionUsuario, A2237SGNotificacionID});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7A198( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel7A198( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel7A198( ) ;
         }
         CloseExtendedTableCursors7A198( ) ;
      }

      protected void DeferredUpdate7A198( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate7A198( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A198( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7A198( ) ;
            AfterConfirm7A198( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7A198( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart7A199( ) ;
                  while ( RcdFound199 != 0 )
                  {
                     getByPrimaryKey7A199( ) ;
                     Delete7A199( ) ;
                     ScanKeyNext7A199( ) ;
                  }
                  ScanKeyEnd7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007A12 */
                     pr_default.execute(10, new Object[] {A2237SGNotificacionID});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONES");
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
         }
         sMode198 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel7A198( ) ;
         Gx_mode = sMode198;
      }

      protected void OnDeleteControls7A198( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC007A13 */
            pr_default.execute(11, new Object[] {A2241SGNotificacionUsuario});
            A2242SGNotificacionUsuarioDsc = BC007A13_A2242SGNotificacionUsuarioDsc[0];
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel7A199( )
      {
         nGXsfl_199_idx = 0;
         while ( nGXsfl_199_idx < bcseguridad_Notificaciones.gxTpr_Level1.Count )
         {
            ReadRow7A199( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound199 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_199 != 0 ) )
            {
               standaloneNotModal7A199( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert7A199( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete7A199( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update7A199( ) ;
                  }
               }
            }
            KeyVarsToRow199( ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)bcseguridad_Notificaciones.gxTpr_Level1.Item(nGXsfl_199_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_199_idx = 0;
            while ( nGXsfl_199_idx < bcseguridad_Notificaciones.gxTpr_Level1.Count )
            {
               ReadRow7A199( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound199 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcseguridad_Notificaciones.gxTpr_Level1.RemoveElement(nGXsfl_199_idx);
                  nGXsfl_199_idx = (int)(nGXsfl_199_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey7A199( ) ;
                  VarsToRow199( ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)bcseguridad_Notificaciones.gxTpr_Level1.Item(nGXsfl_199_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll7A199( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_199 = 0;
         nIsMod_199 = 0;
         Gxremove199 = 0;
      }

      protected void ProcessLevel7A198( )
      {
         /* Save parent mode. */
         sMode198 = Gx_mode;
         ProcessNestedLevel7A199( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode198;
         /* ' Update level parameters */
      }

      protected void EndLevel7A198( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7A198( ) ;
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

      public void ScanKeyStart7A198( )
      {
         /* Scan By routine */
         /* Using cursor BC007A14 */
         pr_default.execute(12, new Object[] {A2237SGNotificacionID});
         RcdFound198 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = BC007A14_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = BC007A14_A2238SGNotificacionTitulo[0];
            A2239SGNotificacionDescripcion = BC007A14_A2239SGNotificacionDescripcion[0];
            A2240SGNotificacionFecha = BC007A14_A2240SGNotificacionFecha[0];
            A2242SGNotificacionUsuarioDsc = BC007A14_A2242SGNotificacionUsuarioDsc[0];
            A2243SGNotificacionIconClass = BC007A14_A2243SGNotificacionIconClass[0];
            A2244SGNotificacionTUsuario = BC007A14_A2244SGNotificacionTUsuario[0];
            A2241SGNotificacionUsuario = BC007A14_A2241SGNotificacionUsuario[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext7A198( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound198 = 0;
         ScanKeyLoad7A198( ) ;
      }

      protected void ScanKeyLoad7A198( )
      {
         sMode198 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound198 = 1;
            A2237SGNotificacionID = BC007A14_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = BC007A14_A2238SGNotificacionTitulo[0];
            A2239SGNotificacionDescripcion = BC007A14_A2239SGNotificacionDescripcion[0];
            A2240SGNotificacionFecha = BC007A14_A2240SGNotificacionFecha[0];
            A2242SGNotificacionUsuarioDsc = BC007A14_A2242SGNotificacionUsuarioDsc[0];
            A2243SGNotificacionIconClass = BC007A14_A2243SGNotificacionIconClass[0];
            A2244SGNotificacionTUsuario = BC007A14_A2244SGNotificacionTUsuario[0];
            A2241SGNotificacionUsuario = BC007A14_A2241SGNotificacionUsuario[0];
         }
         Gx_mode = sMode198;
      }

      protected void ScanKeyEnd7A198( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm7A198( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int1 = AV21cSGNotificacionID;
            new GeneXus.Programs.seguridad.notificacionescorrelativo(context ).execute( out  GXt_int1) ;
            AV21cSGNotificacionID = GXt_int1;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A2237SGNotificacionID = AV21cSGNotificacionID;
         }
      }

      protected void BeforeInsert7A198( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7A198( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7A198( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7A198( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7A198( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7A198( )
      {
      }

      protected void ZM7A199( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
            Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z2247SGNotificacionDetUsuarioDsc = A2247SGNotificacionDetUsuarioDsc;
         }
         if ( GX_JID == -14 )
         {
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
            Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
            Z2247SGNotificacionDetUsuarioDsc = A2247SGNotificacionDetUsuarioDsc;
         }
      }

      protected void standaloneNotModal7A199( )
      {
      }

      protected void standaloneModal7A199( )
      {
      }

      protected void Load7A199( )
      {
         /* Using cursor BC007A15 */
         pr_default.execute(13, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound199 = 1;
            A2247SGNotificacionDetUsuarioDsc = BC007A15_A2247SGNotificacionDetUsuarioDsc[0];
            A2248SGNotificacionDetEstado = BC007A15_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = BC007A15_A2246SGNotificacionDetUsuario[0];
            ZM7A199( -14) ;
         }
         pr_default.close(13);
         OnLoadActions7A199( ) ;
      }

      protected void OnLoadActions7A199( )
      {
      }

      protected void CheckExtendedTable7A199( )
      {
         nIsDirty_199 = 0;
         Gx_BScreen = 1;
         standaloneModal7A199( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC007A4 */
         pr_default.execute(2, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONDETUSUARIO");
            AnyError = 1;
         }
         A2247SGNotificacionDetUsuarioDsc = BC007A4_A2247SGNotificacionDetUsuarioDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7A199( )
      {
         pr_default.close(2);
      }

      protected void enableDisable7A199( )
      {
      }

      protected void GetKey7A199( )
      {
         /* Using cursor BC007A16 */
         pr_default.execute(14, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound199 = 1;
         }
         else
         {
            RcdFound199 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey7A199( )
      {
         /* Using cursor BC007A3 */
         pr_default.execute(1, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7A199( 14) ;
            RcdFound199 = 1;
            InitializeNonKey7A199( ) ;
            A2245SGNotificacionDetID = BC007A3_A2245SGNotificacionDetID[0];
            A2248SGNotificacionDetEstado = BC007A3_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = BC007A3_A2246SGNotificacionDetUsuario[0];
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal7A199( ) ;
            Load7A199( ) ;
            Gx_mode = sMode199;
         }
         else
         {
            RcdFound199 = 0;
            InitializeNonKey7A199( ) ;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal7A199( ) ;
            Gx_mode = sMode199;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes7A199( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency7A199( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC007A2 */
            pr_default.execute(0, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2248SGNotificacionDetEstado != BC007A2_A2248SGNotificacionDetEstado[0] ) || ( StringUtil.StrCmp(Z2246SGNotificacionDetUsuario, BC007A2_A2246SGNotificacionDetUsuario[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7A199( )
      {
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A199( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7A199( 0) ;
            CheckOptimisticConcurrency7A199( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A199( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007A17 */
                     pr_default.execute(15, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID, A2248SGNotificacionDetEstado, A2246SGNotificacionDetUsuario});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load7A199( ) ;
            }
            EndLevel7A199( ) ;
         }
         CloseExtendedTableCursors7A199( ) ;
      }

      protected void Update7A199( )
      {
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7A199( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A199( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7A199( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7A199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC007A18 */
                     pr_default.execute(16, new Object[] {A2248SGNotificacionDetEstado, A2246SGNotificacionDetUsuario, A2237SGNotificacionID, A2245SGNotificacionDetID});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7A199( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey7A199( ) ;
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
            EndLevel7A199( ) ;
         }
         CloseExtendedTableCursors7A199( ) ;
      }

      protected void DeferredUpdate7A199( )
      {
      }

      protected void Delete7A199( )
      {
         Gx_mode = "DLT";
         BeforeValidate7A199( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7A199( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7A199( ) ;
            AfterConfirm7A199( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7A199( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC007A19 */
                  pr_default.execute(17, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode199 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel7A199( ) ;
         Gx_mode = sMode199;
      }

      protected void OnDeleteControls7A199( )
      {
         standaloneModal7A199( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC007A20 */
            pr_default.execute(18, new Object[] {A2246SGNotificacionDetUsuario});
            A2247SGNotificacionDetUsuarioDsc = BC007A20_A2247SGNotificacionDetUsuarioDsc[0];
            pr_default.close(18);
         }
      }

      protected void EndLevel7A199( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart7A199( )
      {
         /* Scan By routine */
         /* Using cursor BC007A21 */
         pr_default.execute(19, new Object[] {A2237SGNotificacionID});
         RcdFound199 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound199 = 1;
            A2245SGNotificacionDetID = BC007A21_A2245SGNotificacionDetID[0];
            A2247SGNotificacionDetUsuarioDsc = BC007A21_A2247SGNotificacionDetUsuarioDsc[0];
            A2248SGNotificacionDetEstado = BC007A21_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = BC007A21_A2246SGNotificacionDetUsuario[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext7A199( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound199 = 0;
         ScanKeyLoad7A199( ) ;
      }

      protected void ScanKeyLoad7A199( )
      {
         sMode199 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound199 = 1;
            A2245SGNotificacionDetID = BC007A21_A2245SGNotificacionDetID[0];
            A2247SGNotificacionDetUsuarioDsc = BC007A21_A2247SGNotificacionDetUsuarioDsc[0];
            A2248SGNotificacionDetEstado = BC007A21_A2248SGNotificacionDetEstado[0];
            A2246SGNotificacionDetUsuario = BC007A21_A2246SGNotificacionDetUsuario[0];
         }
         Gx_mode = sMode199;
      }

      protected void ScanKeyEnd7A199( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm7A199( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7A199( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7A199( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7A199( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7A199( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7A199( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7A199( )
      {
      }

      protected void send_integrity_lvl_hashes7A199( )
      {
      }

      protected void send_integrity_lvl_hashes7A198( )
      {
      }

      protected void AddRow7A198( )
      {
         VarsToRow198( bcseguridad_Notificaciones) ;
      }

      protected void ReadRow7A198( )
      {
         RowToVars198( bcseguridad_Notificaciones, 1) ;
      }

      protected void AddRow7A199( )
      {
         GeneXus.Programs.seguridad.SdtNotificaciones_Level1 obj199;
         obj199 = new GeneXus.Programs.seguridad.SdtNotificaciones_Level1(context);
         VarsToRow199( obj199) ;
         bcseguridad_Notificaciones.gxTpr_Level1.Add(obj199, 0);
         obj199.gxTpr_Mode = "UPD";
         obj199.gxTpr_Modified = 0;
      }

      protected void ReadRow7A199( )
      {
         nGXsfl_199_idx = (int)(nGXsfl_199_idx+1);
         RowToVars199( ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)bcseguridad_Notificaciones.gxTpr_Level1.Item(nGXsfl_199_idx)), 1) ;
      }

      protected void InitializeNonKey7A198( )
      {
         AV21cSGNotificacionID = 0;
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2241SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         A2243SGNotificacionIconClass = "";
         A2244SGNotificacionTUsuario = 0;
         Z2238SGNotificacionTitulo = "";
         Z2239SGNotificacionDescripcion = "";
         Z2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z2243SGNotificacionIconClass = "";
         Z2244SGNotificacionTUsuario = 0;
         Z2241SGNotificacionUsuario = "";
      }

      protected void InitAll7A198( )
      {
         A2237SGNotificacionID = 0;
         InitializeNonKey7A198( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey7A199( )
      {
         A2246SGNotificacionDetUsuario = "";
         A2247SGNotificacionDetUsuarioDsc = "";
         A2248SGNotificacionDetEstado = 0;
         Z2248SGNotificacionDetEstado = 0;
         Z2246SGNotificacionDetUsuario = "";
      }

      protected void InitAll7A199( )
      {
         A2245SGNotificacionDetID = 0;
         InitializeNonKey7A199( ) ;
      }

      protected void StandaloneModalInsert7A199( )
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

      public void VarsToRow198( GeneXus.Programs.seguridad.SdtNotificaciones obj198 )
      {
         obj198.gxTpr_Mode = Gx_mode;
         obj198.gxTpr_Sgnotificaciontitulo = A2238SGNotificacionTitulo;
         obj198.gxTpr_Sgnotificaciondescripcion = A2239SGNotificacionDescripcion;
         obj198.gxTpr_Sgnotificacionfecha = A2240SGNotificacionFecha;
         obj198.gxTpr_Sgnotificacionusuario = A2241SGNotificacionUsuario;
         obj198.gxTpr_Sgnotificacionusuariodsc = A2242SGNotificacionUsuarioDsc;
         obj198.gxTpr_Sgnotificacioniconclass = A2243SGNotificacionIconClass;
         obj198.gxTpr_Sgnotificaciontusuario = A2244SGNotificacionTUsuario;
         obj198.gxTpr_Sgnotificacionid = A2237SGNotificacionID;
         obj198.gxTpr_Sgnotificacionid_Z = Z2237SGNotificacionID;
         obj198.gxTpr_Sgnotificaciontitulo_Z = Z2238SGNotificacionTitulo;
         obj198.gxTpr_Sgnotificaciondescripcion_Z = Z2239SGNotificacionDescripcion;
         obj198.gxTpr_Sgnotificacionfecha_Z = Z2240SGNotificacionFecha;
         obj198.gxTpr_Sgnotificacionusuario_Z = Z2241SGNotificacionUsuario;
         obj198.gxTpr_Sgnotificacionusuariodsc_Z = Z2242SGNotificacionUsuarioDsc;
         obj198.gxTpr_Sgnotificacioniconclass_Z = Z2243SGNotificacionIconClass;
         obj198.gxTpr_Sgnotificaciontusuario_Z = Z2244SGNotificacionTUsuario;
         obj198.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow198( GeneXus.Programs.seguridad.SdtNotificaciones obj198 )
      {
         obj198.gxTpr_Sgnotificacionid = A2237SGNotificacionID;
         return  ;
      }

      public void RowToVars198( GeneXus.Programs.seguridad.SdtNotificaciones obj198 ,
                                int forceLoad )
      {
         Gx_mode = obj198.gxTpr_Mode;
         A2238SGNotificacionTitulo = obj198.gxTpr_Sgnotificaciontitulo;
         A2239SGNotificacionDescripcion = obj198.gxTpr_Sgnotificaciondescripcion;
         A2240SGNotificacionFecha = obj198.gxTpr_Sgnotificacionfecha;
         A2241SGNotificacionUsuario = obj198.gxTpr_Sgnotificacionusuario;
         A2242SGNotificacionUsuarioDsc = obj198.gxTpr_Sgnotificacionusuariodsc;
         A2243SGNotificacionIconClass = obj198.gxTpr_Sgnotificacioniconclass;
         A2244SGNotificacionTUsuario = obj198.gxTpr_Sgnotificaciontusuario;
         A2237SGNotificacionID = obj198.gxTpr_Sgnotificacionid;
         Z2237SGNotificacionID = obj198.gxTpr_Sgnotificacionid_Z;
         Z2238SGNotificacionTitulo = obj198.gxTpr_Sgnotificaciontitulo_Z;
         Z2239SGNotificacionDescripcion = obj198.gxTpr_Sgnotificaciondescripcion_Z;
         Z2240SGNotificacionFecha = obj198.gxTpr_Sgnotificacionfecha_Z;
         Z2241SGNotificacionUsuario = obj198.gxTpr_Sgnotificacionusuario_Z;
         Z2242SGNotificacionUsuarioDsc = obj198.gxTpr_Sgnotificacionusuariodsc_Z;
         Z2243SGNotificacionIconClass = obj198.gxTpr_Sgnotificacioniconclass_Z;
         Z2244SGNotificacionTUsuario = obj198.gxTpr_Sgnotificaciontusuario_Z;
         Gx_mode = obj198.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow199( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 obj199 )
      {
         obj199.gxTpr_Mode = Gx_mode;
         obj199.gxTpr_Sgnotificaciondetusuario = A2246SGNotificacionDetUsuario;
         obj199.gxTpr_Sgnotificaciondetusuariodsc = A2247SGNotificacionDetUsuarioDsc;
         obj199.gxTpr_Sgnotificaciondetestado = A2248SGNotificacionDetEstado;
         obj199.gxTpr_Sgnotificaciondetid = A2245SGNotificacionDetID;
         obj199.gxTpr_Sgnotificaciondetid_Z = Z2245SGNotificacionDetID;
         obj199.gxTpr_Sgnotificaciondetusuario_Z = Z2246SGNotificacionDetUsuario;
         obj199.gxTpr_Sgnotificaciondetusuariodsc_Z = Z2247SGNotificacionDetUsuarioDsc;
         obj199.gxTpr_Sgnotificaciondetestado_Z = Z2248SGNotificacionDetEstado;
         obj199.gxTpr_Modified = nIsMod_199;
         return  ;
      }

      public void KeyVarsToRow199( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 obj199 )
      {
         obj199.gxTpr_Sgnotificaciondetid = A2245SGNotificacionDetID;
         return  ;
      }

      public void RowToVars199( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 obj199 ,
                                int forceLoad )
      {
         Gx_mode = obj199.gxTpr_Mode;
         A2246SGNotificacionDetUsuario = obj199.gxTpr_Sgnotificaciondetusuario;
         A2247SGNotificacionDetUsuarioDsc = obj199.gxTpr_Sgnotificaciondetusuariodsc;
         A2248SGNotificacionDetEstado = obj199.gxTpr_Sgnotificaciondetestado;
         A2245SGNotificacionDetID = obj199.gxTpr_Sgnotificaciondetid;
         Z2245SGNotificacionDetID = obj199.gxTpr_Sgnotificaciondetid_Z;
         Z2246SGNotificacionDetUsuario = obj199.gxTpr_Sgnotificaciondetusuario_Z;
         Z2247SGNotificacionDetUsuarioDsc = obj199.gxTpr_Sgnotificaciondetusuariodsc_Z;
         Z2248SGNotificacionDetEstado = obj199.gxTpr_Sgnotificaciondetestado_Z;
         nIsMod_199 = obj199.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A2237SGNotificacionID = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey7A198( ) ;
         ScanKeyStart7A198( ) ;
         if ( RcdFound198 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2237SGNotificacionID = A2237SGNotificacionID;
         }
         ZM7A198( -12) ;
         OnLoadActions7A198( ) ;
         AddRow7A198( ) ;
         bcseguridad_Notificaciones.gxTpr_Level1.ClearCollection();
         if ( RcdFound198 == 1 )
         {
            ScanKeyStart7A199( ) ;
            nGXsfl_199_idx = 1;
            while ( RcdFound199 != 0 )
            {
               Z2237SGNotificacionID = A2237SGNotificacionID;
               Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
               ZM7A199( -14) ;
               OnLoadActions7A199( ) ;
               nRcdExists_199 = 1;
               nIsMod_199 = 0;
               AddRow7A199( ) ;
               nGXsfl_199_idx = (int)(nGXsfl_199_idx+1);
               ScanKeyNext7A199( ) ;
            }
            ScanKeyEnd7A199( ) ;
         }
         ScanKeyEnd7A198( ) ;
         if ( RcdFound198 == 0 )
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
         RowToVars198( bcseguridad_Notificaciones, 0) ;
         ScanKeyStart7A198( ) ;
         if ( RcdFound198 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z2237SGNotificacionID = A2237SGNotificacionID;
         }
         ZM7A198( -12) ;
         OnLoadActions7A198( ) ;
         AddRow7A198( ) ;
         bcseguridad_Notificaciones.gxTpr_Level1.ClearCollection();
         if ( RcdFound198 == 1 )
         {
            ScanKeyStart7A199( ) ;
            nGXsfl_199_idx = 1;
            while ( RcdFound199 != 0 )
            {
               Z2237SGNotificacionID = A2237SGNotificacionID;
               Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
               ZM7A199( -14) ;
               OnLoadActions7A199( ) ;
               nRcdExists_199 = 1;
               nIsMod_199 = 0;
               AddRow7A199( ) ;
               nGXsfl_199_idx = (int)(nGXsfl_199_idx+1);
               ScanKeyNext7A199( ) ;
            }
            ScanKeyEnd7A199( ) ;
         }
         ScanKeyEnd7A198( ) ;
         if ( RcdFound198 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey7A198( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert7A198( ) ;
         }
         else
         {
            if ( RcdFound198 == 1 )
            {
               if ( A2237SGNotificacionID != Z2237SGNotificacionID )
               {
                  A2237SGNotificacionID = Z2237SGNotificacionID;
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
                  Update7A198( ) ;
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
                  if ( A2237SGNotificacionID != Z2237SGNotificacionID )
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
                        Insert7A198( ) ;
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
                        Insert7A198( ) ;
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
         RowToVars198( bcseguridad_Notificaciones, 1) ;
         SaveImpl( ) ;
         VarsToRow198( bcseguridad_Notificaciones) ;
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
         RowToVars198( bcseguridad_Notificaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert7A198( ) ;
         AfterTrn( ) ;
         VarsToRow198( bcseguridad_Notificaciones) ;
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
            GeneXus.Programs.seguridad.SdtNotificaciones auxBC = new GeneXus.Programs.seguridad.SdtNotificaciones(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A2237SGNotificacionID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcseguridad_Notificaciones);
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
         RowToVars198( bcseguridad_Notificaciones, 1) ;
         UpdateImpl( ) ;
         VarsToRow198( bcseguridad_Notificaciones) ;
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
         RowToVars198( bcseguridad_Notificaciones, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert7A198( ) ;
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
         VarsToRow198( bcseguridad_Notificaciones) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars198( bcseguridad_Notificaciones, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey7A198( ) ;
         if ( RcdFound198 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A2237SGNotificacionID != Z2237SGNotificacionID )
            {
               A2237SGNotificacionID = Z2237SGNotificacionID;
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
            if ( A2237SGNotificacionID != Z2237SGNotificacionID )
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
         pr_default.close(4);
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(18);
         context.RollbackDataStores("seguridad.notificaciones_bc",pr_default);
         VarsToRow198( bcseguridad_Notificaciones) ;
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
         Gx_mode = bcseguridad_Notificaciones.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcseguridad_Notificaciones.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcseguridad_Notificaciones )
         {
            bcseguridad_Notificaciones = (GeneXus.Programs.seguridad.SdtNotificaciones)(sdt);
            if ( StringUtil.StrCmp(bcseguridad_Notificaciones.gxTpr_Mode, "") == 0 )
            {
               bcseguridad_Notificaciones.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow198( bcseguridad_Notificaciones) ;
            }
            else
            {
               RowToVars198( bcseguridad_Notificaciones, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcseguridad_Notificaciones.gxTpr_Mode, "") == 0 )
            {
               bcseguridad_Notificaciones.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars198( bcseguridad_Notificaciones, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtNotificaciones Notificaciones_BC
      {
         get {
            return bcseguridad_Notificaciones ;
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
         pr_default.close(18);
         pr_default.close(4);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode198 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV22Pgmname = "";
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV11Insert_SGNotificacionUsuario = "";
         Z2238SGNotificacionTitulo = "";
         A2238SGNotificacionTitulo = "";
         Z2239SGNotificacionDescripcion = "";
         A2239SGNotificacionDescripcion = "";
         Z2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         Z2243SGNotificacionIconClass = "";
         A2243SGNotificacionIconClass = "";
         Z2241SGNotificacionUsuario = "";
         A2241SGNotificacionUsuario = "";
         Z2242SGNotificacionUsuarioDsc = "";
         A2242SGNotificacionUsuarioDsc = "";
         BC007A8_A2237SGNotificacionID = new long[1] ;
         BC007A8_A2238SGNotificacionTitulo = new string[] {""} ;
         BC007A8_A2239SGNotificacionDescripcion = new string[] {""} ;
         BC007A8_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC007A8_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         BC007A8_A2243SGNotificacionIconClass = new string[] {""} ;
         BC007A8_A2244SGNotificacionTUsuario = new short[1] ;
         BC007A8_A2241SGNotificacionUsuario = new string[] {""} ;
         BC007A7_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         BC007A9_A2237SGNotificacionID = new long[1] ;
         BC007A6_A2237SGNotificacionID = new long[1] ;
         BC007A6_A2238SGNotificacionTitulo = new string[] {""} ;
         BC007A6_A2239SGNotificacionDescripcion = new string[] {""} ;
         BC007A6_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC007A6_A2243SGNotificacionIconClass = new string[] {""} ;
         BC007A6_A2244SGNotificacionTUsuario = new short[1] ;
         BC007A6_A2241SGNotificacionUsuario = new string[] {""} ;
         BC007A5_A2237SGNotificacionID = new long[1] ;
         BC007A5_A2238SGNotificacionTitulo = new string[] {""} ;
         BC007A5_A2239SGNotificacionDescripcion = new string[] {""} ;
         BC007A5_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC007A5_A2243SGNotificacionIconClass = new string[] {""} ;
         BC007A5_A2244SGNotificacionTUsuario = new short[1] ;
         BC007A5_A2241SGNotificacionUsuario = new string[] {""} ;
         BC007A13_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         BC007A14_A2237SGNotificacionID = new long[1] ;
         BC007A14_A2238SGNotificacionTitulo = new string[] {""} ;
         BC007A14_A2239SGNotificacionDescripcion = new string[] {""} ;
         BC007A14_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         BC007A14_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         BC007A14_A2243SGNotificacionIconClass = new string[] {""} ;
         BC007A14_A2244SGNotificacionTUsuario = new short[1] ;
         BC007A14_A2241SGNotificacionUsuario = new string[] {""} ;
         Z2246SGNotificacionDetUsuario = "";
         A2246SGNotificacionDetUsuario = "";
         Z2247SGNotificacionDetUsuarioDsc = "";
         A2247SGNotificacionDetUsuarioDsc = "";
         BC007A15_A2237SGNotificacionID = new long[1] ;
         BC007A15_A2245SGNotificacionDetID = new short[1] ;
         BC007A15_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         BC007A15_A2248SGNotificacionDetEstado = new short[1] ;
         BC007A15_A2246SGNotificacionDetUsuario = new string[] {""} ;
         BC007A4_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         BC007A16_A2237SGNotificacionID = new long[1] ;
         BC007A16_A2245SGNotificacionDetID = new short[1] ;
         BC007A3_A2237SGNotificacionID = new long[1] ;
         BC007A3_A2245SGNotificacionDetID = new short[1] ;
         BC007A3_A2248SGNotificacionDetEstado = new short[1] ;
         BC007A3_A2246SGNotificacionDetUsuario = new string[] {""} ;
         sMode199 = "";
         BC007A2_A2237SGNotificacionID = new long[1] ;
         BC007A2_A2245SGNotificacionDetID = new short[1] ;
         BC007A2_A2248SGNotificacionDetEstado = new short[1] ;
         BC007A2_A2246SGNotificacionDetUsuario = new string[] {""} ;
         BC007A20_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         BC007A21_A2237SGNotificacionID = new long[1] ;
         BC007A21_A2245SGNotificacionDetID = new short[1] ;
         BC007A21_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         BC007A21_A2248SGNotificacionDetEstado = new short[1] ;
         BC007A21_A2246SGNotificacionDetUsuario = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificaciones_bc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificaciones_bc__default(),
            new Object[][] {
                new Object[] {
               BC007A2_A2237SGNotificacionID, BC007A2_A2245SGNotificacionDetID, BC007A2_A2248SGNotificacionDetEstado, BC007A2_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               BC007A3_A2237SGNotificacionID, BC007A3_A2245SGNotificacionDetID, BC007A3_A2248SGNotificacionDetEstado, BC007A3_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               BC007A4_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               BC007A5_A2237SGNotificacionID, BC007A5_A2238SGNotificacionTitulo, BC007A5_A2239SGNotificacionDescripcion, BC007A5_A2240SGNotificacionFecha, BC007A5_A2243SGNotificacionIconClass, BC007A5_A2244SGNotificacionTUsuario, BC007A5_A2241SGNotificacionUsuario
               }
               , new Object[] {
               BC007A6_A2237SGNotificacionID, BC007A6_A2238SGNotificacionTitulo, BC007A6_A2239SGNotificacionDescripcion, BC007A6_A2240SGNotificacionFecha, BC007A6_A2243SGNotificacionIconClass, BC007A6_A2244SGNotificacionTUsuario, BC007A6_A2241SGNotificacionUsuario
               }
               , new Object[] {
               BC007A7_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               BC007A8_A2237SGNotificacionID, BC007A8_A2238SGNotificacionTitulo, BC007A8_A2239SGNotificacionDescripcion, BC007A8_A2240SGNotificacionFecha, BC007A8_A2242SGNotificacionUsuarioDsc, BC007A8_A2243SGNotificacionIconClass, BC007A8_A2244SGNotificacionTUsuario, BC007A8_A2241SGNotificacionUsuario
               }
               , new Object[] {
               BC007A9_A2237SGNotificacionID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC007A13_A2242SGNotificacionUsuarioDsc
               }
               , new Object[] {
               BC007A14_A2237SGNotificacionID, BC007A14_A2238SGNotificacionTitulo, BC007A14_A2239SGNotificacionDescripcion, BC007A14_A2240SGNotificacionFecha, BC007A14_A2242SGNotificacionUsuarioDsc, BC007A14_A2243SGNotificacionIconClass, BC007A14_A2244SGNotificacionTUsuario, BC007A14_A2241SGNotificacionUsuario
               }
               , new Object[] {
               BC007A15_A2237SGNotificacionID, BC007A15_A2245SGNotificacionDetID, BC007A15_A2247SGNotificacionDetUsuarioDsc, BC007A15_A2248SGNotificacionDetEstado, BC007A15_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               BC007A16_A2237SGNotificacionID, BC007A16_A2245SGNotificacionDetID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC007A20_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               BC007A21_A2237SGNotificacionID, BC007A21_A2245SGNotificacionDetID, BC007A21_A2247SGNotificacionDetUsuarioDsc, BC007A21_A2248SGNotificacionDetEstado, BC007A21_A2246SGNotificacionDetUsuario
               }
            }
         );
         AV22Pgmname = "Seguridad.Notificaciones_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E127A2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_199 ;
      private short RcdFound199 ;
      private short GX_JID ;
      private short Z2244SGNotificacionTUsuario ;
      private short A2244SGNotificacionTUsuario ;
      private short RcdFound198 ;
      private short nIsDirty_198 ;
      private short nRcdExists_199 ;
      private short Gxremove199 ;
      private short Z2248SGNotificacionDetEstado ;
      private short A2248SGNotificacionDetEstado ;
      private short Z2245SGNotificacionDetID ;
      private short A2245SGNotificacionDetID ;
      private short nIsDirty_199 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int nGXsfl_199_idx=1 ;
      private int AV23GXV1 ;
      private long Z2237SGNotificacionID ;
      private long A2237SGNotificacionID ;
      private long AV21cSGNotificacionID ;
      private long GXt_int1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode198 ;
      private string AV22Pgmname ;
      private string AV11Insert_SGNotificacionUsuario ;
      private string Z2241SGNotificacionUsuario ;
      private string A2241SGNotificacionUsuario ;
      private string Z2242SGNotificacionUsuarioDsc ;
      private string A2242SGNotificacionUsuarioDsc ;
      private string Z2246SGNotificacionDetUsuario ;
      private string A2246SGNotificacionDetUsuario ;
      private string Z2247SGNotificacionDetUsuarioDsc ;
      private string A2247SGNotificacionDetUsuarioDsc ;
      private string sMode199 ;
      private DateTime Z2240SGNotificacionFecha ;
      private DateTime A2240SGNotificacionFecha ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z2238SGNotificacionTitulo ;
      private string A2238SGNotificacionTitulo ;
      private string Z2239SGNotificacionDescripcion ;
      private string A2239SGNotificacionDescripcion ;
      private string Z2243SGNotificacionIconClass ;
      private string A2243SGNotificacionIconClass ;
      private IGxSession AV10WebSession ;
      private GeneXus.Programs.seguridad.SdtNotificaciones bcseguridad_Notificaciones ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC007A8_A2237SGNotificacionID ;
      private string[] BC007A8_A2238SGNotificacionTitulo ;
      private string[] BC007A8_A2239SGNotificacionDescripcion ;
      private DateTime[] BC007A8_A2240SGNotificacionFecha ;
      private string[] BC007A8_A2242SGNotificacionUsuarioDsc ;
      private string[] BC007A8_A2243SGNotificacionIconClass ;
      private short[] BC007A8_A2244SGNotificacionTUsuario ;
      private string[] BC007A8_A2241SGNotificacionUsuario ;
      private string[] BC007A7_A2242SGNotificacionUsuarioDsc ;
      private long[] BC007A9_A2237SGNotificacionID ;
      private long[] BC007A6_A2237SGNotificacionID ;
      private string[] BC007A6_A2238SGNotificacionTitulo ;
      private string[] BC007A6_A2239SGNotificacionDescripcion ;
      private DateTime[] BC007A6_A2240SGNotificacionFecha ;
      private string[] BC007A6_A2243SGNotificacionIconClass ;
      private short[] BC007A6_A2244SGNotificacionTUsuario ;
      private string[] BC007A6_A2241SGNotificacionUsuario ;
      private long[] BC007A5_A2237SGNotificacionID ;
      private string[] BC007A5_A2238SGNotificacionTitulo ;
      private string[] BC007A5_A2239SGNotificacionDescripcion ;
      private DateTime[] BC007A5_A2240SGNotificacionFecha ;
      private string[] BC007A5_A2243SGNotificacionIconClass ;
      private short[] BC007A5_A2244SGNotificacionTUsuario ;
      private string[] BC007A5_A2241SGNotificacionUsuario ;
      private string[] BC007A13_A2242SGNotificacionUsuarioDsc ;
      private long[] BC007A14_A2237SGNotificacionID ;
      private string[] BC007A14_A2238SGNotificacionTitulo ;
      private string[] BC007A14_A2239SGNotificacionDescripcion ;
      private DateTime[] BC007A14_A2240SGNotificacionFecha ;
      private string[] BC007A14_A2242SGNotificacionUsuarioDsc ;
      private string[] BC007A14_A2243SGNotificacionIconClass ;
      private short[] BC007A14_A2244SGNotificacionTUsuario ;
      private string[] BC007A14_A2241SGNotificacionUsuario ;
      private long[] BC007A15_A2237SGNotificacionID ;
      private short[] BC007A15_A2245SGNotificacionDetID ;
      private string[] BC007A15_A2247SGNotificacionDetUsuarioDsc ;
      private short[] BC007A15_A2248SGNotificacionDetEstado ;
      private string[] BC007A15_A2246SGNotificacionDetUsuario ;
      private string[] BC007A4_A2247SGNotificacionDetUsuarioDsc ;
      private long[] BC007A16_A2237SGNotificacionID ;
      private short[] BC007A16_A2245SGNotificacionDetID ;
      private long[] BC007A3_A2237SGNotificacionID ;
      private short[] BC007A3_A2245SGNotificacionDetID ;
      private short[] BC007A3_A2248SGNotificacionDetEstado ;
      private string[] BC007A3_A2246SGNotificacionDetUsuario ;
      private long[] BC007A2_A2237SGNotificacionID ;
      private short[] BC007A2_A2245SGNotificacionDetID ;
      private short[] BC007A2_A2248SGNotificacionDetEstado ;
      private string[] BC007A2_A2246SGNotificacionDetUsuario ;
      private string[] BC007A20_A2247SGNotificacionDetUsuarioDsc ;
      private long[] BC007A21_A2237SGNotificacionID ;
      private short[] BC007A21_A2245SGNotificacionDetID ;
      private string[] BC007A21_A2247SGNotificacionDetUsuarioDsc ;
      private short[] BC007A21_A2248SGNotificacionDetEstado ;
      private string[] BC007A21_A2246SGNotificacionDetUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class notificaciones_bc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class notificaciones_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC007A8;
        prmBC007A8 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A7;
        prmBC007A7 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A9;
        prmBC007A9 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A6;
        prmBC007A6 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A5;
        prmBC007A5 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A10;
        prmBC007A10 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A11;
        prmBC007A11 = new Object[] {
        new ParDef("@SGNotificacionTitulo",GXType.NVarChar,100,0) ,
        new ParDef("@SGNotificacionDescripcion",GXType.NVarChar,200,0) ,
        new ParDef("@SGNotificacionFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGNotificacionIconClass",GXType.NVarChar,60,0) ,
        new ParDef("@SGNotificacionTUsuario",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A12;
        prmBC007A12 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A13;
        prmBC007A13 = new Object[] {
        new ParDef("@SGNotificacionUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A14;
        prmBC007A14 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmBC007A15;
        prmBC007A15 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A4;
        prmBC007A4 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A16;
        prmBC007A16 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A3;
        prmBC007A3 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A2;
        prmBC007A2 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A17;
        prmBC007A17 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A18;
        prmBC007A18 = new Object[] {
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A19;
        prmBC007A19 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmBC007A20;
        prmBC007A20 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmBC007A21;
        prmBC007A21 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC007A2", "SELECT [SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A3", "SELECT [SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A4", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A5", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A6", "SELECT [SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario] AS SGNotificacionUsuario FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A7", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A8", "SELECT TM1.[SGNotificacionID], TM1.[SGNotificacionTitulo], TM1.[SGNotificacionDescripcion], TM1.[SGNotificacionFecha], T2.[UsuNom] AS SGNotificacionUsuarioDsc, TM1.[SGNotificacionIconClass], TM1.[SGNotificacionTUsuario], TM1.[SGNotificacionUsuario] AS SGNotificacionUsuario FROM ([SGNOTIFICACIONES] TM1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = TM1.[SGNotificacionUsuario]) WHERE TM1.[SGNotificacionID] = @SGNotificacionID ORDER BY TM1.[SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A9", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A10", "INSERT INTO [SGNOTIFICACIONES]([SGNotificacionID], [SGNotificacionTitulo], [SGNotificacionDescripcion], [SGNotificacionFecha], [SGNotificacionIconClass], [SGNotificacionTUsuario], [SGNotificacionUsuario]) VALUES(@SGNotificacionID, @SGNotificacionTitulo, @SGNotificacionDescripcion, @SGNotificacionFecha, @SGNotificacionIconClass, @SGNotificacionTUsuario, @SGNotificacionUsuario)", GxErrorMask.GX_NOMASK,prmBC007A10)
           ,new CursorDef("BC007A11", "UPDATE [SGNOTIFICACIONES] SET [SGNotificacionTitulo]=@SGNotificacionTitulo, [SGNotificacionDescripcion]=@SGNotificacionDescripcion, [SGNotificacionFecha]=@SGNotificacionFecha, [SGNotificacionIconClass]=@SGNotificacionIconClass, [SGNotificacionTUsuario]=@SGNotificacionTUsuario, [SGNotificacionUsuario]=@SGNotificacionUsuario  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmBC007A11)
           ,new CursorDef("BC007A12", "DELETE FROM [SGNOTIFICACIONES]  WHERE [SGNotificacionID] = @SGNotificacionID", GxErrorMask.GX_NOMASK,prmBC007A12)
           ,new CursorDef("BC007A13", "SELECT [UsuNom] AS SGNotificacionUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A14", "SELECT TM1.[SGNotificacionID], TM1.[SGNotificacionTitulo], TM1.[SGNotificacionDescripcion], TM1.[SGNotificacionFecha], T2.[UsuNom] AS SGNotificacionUsuarioDsc, TM1.[SGNotificacionIconClass], TM1.[SGNotificacionTUsuario], TM1.[SGNotificacionUsuario] AS SGNotificacionUsuario FROM ([SGNOTIFICACIONES] TM1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = TM1.[SGNotificacionUsuario]) WHERE TM1.[SGNotificacionID] = @SGNotificacionID ORDER BY TM1.[SGNotificacionID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A15", "SELECT T1.[SGNotificacionID], T1.[SGNotificacionDetID], T2.[UsuNom] AS SGNotificacionDetUsuarioDsc, T1.[SGNotificacionDetEstado], T1.[SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM ([SGNOTIFICACIONESDET] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionDetUsuario]) WHERE T1.[SGNotificacionID] = @SGNotificacionID and T1.[SGNotificacionDetID] = @SGNotificacionDetID ORDER BY T1.[SGNotificacionID], T1.[SGNotificacionDetID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A15,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A16", "SELECT [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A17", "INSERT INTO [SGNOTIFICACIONESDET]([SGNotificacionID], [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionDetUsuario]) VALUES(@SGNotificacionID, @SGNotificacionDetID, @SGNotificacionDetEstado, @SGNotificacionDetUsuario)", GxErrorMask.GX_NOMASK,prmBC007A17)
           ,new CursorDef("BC007A18", "UPDATE [SGNOTIFICACIONESDET] SET [SGNotificacionDetEstado]=@SGNotificacionDetEstado, [SGNotificacionDetUsuario]=@SGNotificacionDetUsuario  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmBC007A18)
           ,new CursorDef("BC007A19", "DELETE FROM [SGNOTIFICACIONESDET]  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmBC007A19)
           ,new CursorDef("BC007A20", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC007A21", "SELECT T1.[SGNotificacionID], T1.[SGNotificacionDetID], T2.[UsuNom] AS SGNotificacionDetUsuarioDsc, T1.[SGNotificacionDetEstado], T1.[SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM ([SGNOTIFICACIONESDET] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionDetUsuario]) WHERE T1.[SGNotificacionID] = @SGNotificacionID ORDER BY T1.[SGNotificacionID], T1.[SGNotificacionDetID]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC007A21,11, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
     }
  }

}

}
