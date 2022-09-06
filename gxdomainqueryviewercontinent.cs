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
   public class gxdomainqueryviewercontinent
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewercontinent ()
      {
         domain["Africa"] = "Africa";
         domain["Antarctica"] = "Antarctica";
         domain["Asia"] = "Asia";
         domain["Europe"] = "Europe";
         domain["NorthAmerica"] = "North America";
         domain["Oceania"] = "Oceania";
         domain["SouthAmerica"] = "South America";
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
            domainMap["Africa"] = "Africa";
            domainMap["Antarctica"] = "Antarctica";
            domainMap["Asia"] = "Asia";
            domainMap["Europe"] = "Europe";
            domainMap["NorthAmerica"] = "NorthAmerica";
            domainMap["Oceania"] = "Oceania";
            domainMap["SouthAmerica"] = "SouthAmerica";
         }
         return (string)domainMap[key] ;
      }

   }

}
