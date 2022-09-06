using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class GxFullTextSearchReindexer
   {
      public static int Reindex( IGxContext context )
      {
         GxSilentTrnSdt obj;
         IGxSilentTrn trn;
         bool result;
         obj = new GeneXus.Programs.seguridad.SdtNotificaciones(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new SdtSGUSUARIOALMACEN(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         obj = new GeneXus.Programs.reloj_interface.SdtReloj(context);
         trn = obj.getTransaction();
         result = trn.Reindex();
         return 1 ;
      }

   }

}
