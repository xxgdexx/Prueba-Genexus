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
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gxdomainicononotificaciones
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainicononotificaciones ()
      {
         domain["fas fa-info NotificationFontIconInfoLight"] = "Informativo";
         domain["fas fa-clipboard-check NotificationFontIconInfo"] = "Verificación";
         domain["far fa-thumbs-up NotificationFontIconSuccess"] = "Conforme";
         domain["fas fa-exclamation-triangle NotificationFontIconDanger"] = "Urgente";
      }

      public static string getDescription( IGxContext context ,
                                           string key )
      {
         string rtkey;
         string value;
         rtkey = ((key==null) ? "" : StringUtil.Trim( (string)(key)));
         value = (string)(domain[rtkey]==null?"":domain[rtkey]);
         return value ;
      }

      public static GxSimpleCollection<string> getValues( )
      {
         GxSimpleCollection<string> value = new GxSimpleCollection<string>();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (string key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

      public static string getValue( string key )
      {
         if(domainMap == null)
         {
            domainMap = new Hashtable();
            domainMap["Informativo"] = "fas fa-info NotificationFontIconInfoLight";
            domainMap["Verificacion"] = "fas fa-clipboard-check NotificationFontIconInfo";
            domainMap["Conforme"] = "far fa-thumbs-up NotificationFontIconSuccess";
            domainMap["Urgente"] = "fas fa-exclamation-triangle NotificationFontIconDanger";
         }
         return (string)domainMap[key] ;
      }

   }

}
