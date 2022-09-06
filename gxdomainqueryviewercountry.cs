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
   public class gxdomainqueryviewercountry
   {
      private static Hashtable domain = new Hashtable();
      private static Hashtable domainMap;
      static gxdomainqueryviewercountry ()
      {
         domain["AF"] = "Afghanistan";
         domain["AL"] = "Albania";
         domain["DZ"] = "Algeria";
         domain["AD"] = "Andorra";
         domain["AO"] = "Angola";
         domain["AI"] = "Anguilla";
         domain["AG"] = "Antigua and Barbuda";
         domain["AR"] = "Argentina";
         domain["AM"] = "Armenia";
         domain["AU"] = "Australia";
         domain["AT"] = "Austria";
         domain["AZ"] = "Azerbaijan";
         domain["BH"] = "Bahrain";
         domain["BD"] = "Bangladesh";
         domain["BB"] = "Barbados";
         domain["BY"] = "Belarus";
         domain["BE"] = "Belgium";
         domain["BZ"] = "Belize";
         domain["BJ"] = "Benin";
         domain["BM"] = "Bermuda";
         domain["BT"] = "Bhutan";
         domain["BO"] = "Bolivia";
         domain["BA"] = "Bosnia and Herzegovina";
         domain["BW"] = "Botswana";
         domain["BR"] = "Brazil";
         domain["VG"] = "British Virgin Islands";
         domain["BN"] = "Brunei";
         domain["BG"] = "Bulgaria";
         domain["BF"] = "Burkina Faso";
         domain["BI"] = "Burundi";
         domain["KH"] = "Cambodia";
         domain["CM"] = "Cameroon";
         domain["CA"] = "Canada";
         domain["CV"] = "Cape Verde";
         domain["CF"] = "Central African Republic";
         domain["TD"] = "Chad";
         domain["CL"] = "Chile";
         domain["CN"] = "China";
         domain["CO"] = "Colombia";
         domain["KM"] = "Comoros";
         domain["CK"] = "Cook Islands";
         domain["CR"] = "Costa Rica";
         domain["HR"] = "Croatia";
         domain["CU"] = "Cuba";
         domain["CY"] = "Cyprus";
         domain["CZ"] = "Czech Republic";
         domain["CD"] = "Democratic Republic of the Congo";
         domain["DK"] = "Denmark";
         domain["DJ"] = "Djibouti";
         domain["DM"] = "Dominica";
         domain["DO"] = "Dominican Republic";
         domain["TL"] = "East Timor";
         domain["EC"] = "Ecuador";
         domain["EG"] = "Egypt";
         domain["SV"] = "El Salvador";
         domain["GQ"] = "Equatorial Guinea";
         domain["ER"] = "Eritrea";
         domain["EE"] = "Estonia";
         domain["SZ"] = "Eswatini";
         domain["ET"] = "Ethiopia";
         domain["FO"] = "Faroe Islands";
         domain["FJ"] = "Fiji";
         domain["FI"] = "Finland";
         domain["FR"] = "France";
         domain["GA"] = "Gabon";
         domain["GM"] = "Gambia";
         domain["GE"] = "Georgia";
         domain["DE"] = "Germany";
         domain["GH"] = "Ghana";
         domain["GR"] = "Greece";
         domain["GL"] = "Greenland";
         domain["GD"] = "Grenada";
         domain["GT"] = "Guatemala";
         domain["GN"] = "Guinea";
         domain["GW"] = "Guinea Bissau";
         domain["GY"] = "Guyana";
         domain["HT"] = "Haiti";
         domain["HN"] = "Honduras";
         domain["HU"] = "Hungary";
         domain["IS"] = "Iceland";
         domain["IN"] = "India";
         domain["ID"] = "Indonesia";
         domain["IR"] = "Iran";
         domain["IQ"] = "Iraq";
         domain["IE"] = "Ireland";
         domain["IL"] = "Israel";
         domain["IT"] = "Italy";
         domain["CI"] = "Ivory Coast";
         domain["JM"] = "Jamaica";
         domain["JP"] = "Japan";
         domain["JO"] = "Jordan";
         domain["KZ"] = "Kazakhstan";
         domain["KE"] = "Kenya";
         domain["KI"] = "Kiribati";
         domain["XK"] = "Kosovo";
         domain["KW"] = "Kuwait";
         domain["KG"] = "Kyrgyzstan";
         domain["LA"] = "Laos";
         domain["LV"] = "Latvia";
         domain["LB"] = "Lebanon";
         domain["LS"] = "Lesotho";
         domain["LR"] = "Liberia";
         domain["LY"] = "Libya";
         domain["LI"] = "Liechtenstein";
         domain["LT"] = "Lithuania";
         domain["LU"] = "Luxembourg";
         domain["MG"] = "Madagascar";
         domain["MW"] = "Malawi";
         domain["MY"] = "Malaysia";
         domain["MV"] = "Maldives";
         domain["ML"] = "Mali";
         domain["MT"] = "Malta";
         domain["MH"] = "Marshall Islands";
         domain["MR"] = "Mauritania";
         domain["MU"] = "Mauritius";
         domain["MX"] = "Mexico";
         domain["FM"] = "Micronesia";
         domain["MD"] = "Moldova";
         domain["MC"] = "Monaco";
         domain["MN"] = "Mongolia";
         domain["ME"] = "Montenegro";
         domain["MA"] = "Morocco";
         domain["MZ"] = "Mozambique";
         domain["MM"] = "Myanmar";
         domain["NA"] = "Namibia";
         domain["NR"] = "Nauru";
         domain["NP"] = "Nepal";
         domain["NL"] = "Netherlands";
         domain["NZ"] = "New Zealand";
         domain["NI"] = "Nicaragua";
         domain["NE"] = "Niger";
         domain["NG"] = "Nigeria";
         domain["KP"] = "North Korea";
         domain["MK"] = "North Macedonia";
         domain["NO"] = "Norway";
         domain["OM"] = "Oman";
         domain["PK"] = "Pakistan";
         domain["PW"] = "Palau";
         domain["PA"] = "Panama";
         domain["PS"] = "Palestine";
         domain["PG"] = "Papua New Guinea";
         domain["PY"] = "Paraguay";
         domain["PE"] = "Peru";
         domain["PH"] = "Philippines";
         domain["PL"] = "Poland";
         domain["PT"] = "Portugal";
         domain["PR"] = "Puerto Rico";
         domain["QA"] = "Qatar";
         domain["CG"] = "Republic of the Congo";
         domain["RO"] = "Romania";
         domain["RU"] = "Russia";
         domain["RW"] = "Rwanda";
         domain["KN"] = "Saint Kitts and Nevis";
         domain["LC"] = "Saint Lucia";
         domain["VC"] = "Saint Vincent and the Grenadines";
         domain["WS"] = "Samoa";
         domain["SM"] = "San Marino";
         domain["ST"] = "S�o Tom� and Pr�ncipe";
         domain["SA"] = "Saudi Arabia";
         domain["SN"] = "Senegal";
         domain["RS"] = "Serbia";
         domain["SC"] = "Seychelles";
         domain["SL"] = "Sierra Leone";
         domain["SG"] = "Singapore";
         domain["SK"] = "Slovakia";
         domain["SI"] = "Slovenia";
         domain["SB"] = "Solomon Islands";
         domain["SO"] = "Somalia";
         domain["ZA"] = "South Africa";
         domain["KR"] = "South Korea";
         domain["SS"] = "South Sudan";
         domain["ES"] = "Spain";
         domain["LK"] = "Sri Lanka";
         domain["SD"] = "Sudan";
         domain["SR"] = "Suriname";
         domain["SE"] = "Sweden";
         domain["CH"] = "Switzerland";
         domain["SY"] = "Syria";
         domain["TW"] = "Taiwan";
         domain["TJ"] = "Tajikistan";
         domain["TZ"] = "Tanzania";
         domain["TH"] = "Thailand";
         domain["BS"] = "The Bahamas";
         domain["TG"] = "Togo";
         domain["TK"] = "Tokelau";
         domain["TO"] = "Tonga";
         domain["TT"] = "Trinidad and Tobago";
         domain["TN"] = "Tunisia";
         domain["TR"] = "Turkey";
         domain["TM"] = "Turkmenistan";
         domain["TV"] = "Tuvalu";
         domain["UG"] = "Uganda";
         domain["UA"] = "Ukraine";
         domain["AE"] = "United Arab Emirates";
         domain["GB"] = "United Kingdom";
         domain["US"] = "United States of America";
         domain["UY"] = "Uruguay";
         domain["UZ"] = "Uzbekistan";
         domain["VU"] = "Vanuatu";
         domain["VA"] = "Vatican City";
         domain["VE"] = "Venezuela";
         domain["VN"] = "Vietnam";
         domain["EH"] = "Western Sahara";
         domain["YE"] = "Yemen";
         domain["ZM"] = "Zambia";
         domain["ZW"] = "Zimbabwe";
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
            domainMap["Afghanistan"] = "AF";
            domainMap["Albania"] = "AL";
            domainMap["Algeria"] = "DZ";
            domainMap["Andorra"] = "AD";
            domainMap["Angola"] = "AO";
            domainMap["Anguilla"] = "AI";
            domainMap["AntiguaAndBarbuda"] = "AG";
            domainMap["Argentina"] = "AR";
            domainMap["Armenia"] = "AM";
            domainMap["Australia"] = "AU";
            domainMap["Austria"] = "AT";
            domainMap["Azerbaijan"] = "AZ";
            domainMap["Bahrain"] = "BH";
            domainMap["Bangladesh"] = "BD";
            domainMap["Barbados"] = "BB";
            domainMap["Belarus"] = "BY";
            domainMap["Belgium"] = "BE";
            domainMap["Belize"] = "BZ";
            domainMap["Benin"] = "BJ";
            domainMap["Bermuda"] = "BM";
            domainMap["Bhutan"] = "BT";
            domainMap["Bolivia"] = "BO";
            domainMap["BosniaAndHerzegovina"] = "BA";
            domainMap["Botswana"] = "BW";
            domainMap["Brazil"] = "BR";
            domainMap["BritishVirginIslands"] = "VG";
            domainMap["Brunei"] = "BN";
            domainMap["Bulgaria"] = "BG";
            domainMap["BurkinaFaso"] = "BF";
            domainMap["Burundi"] = "BI";
            domainMap["Cambodia"] = "KH";
            domainMap["Cameroon"] = "CM";
            domainMap["Canada"] = "CA";
            domainMap["CapeVerde"] = "CV";
            domainMap["CentralAfricanRepublic"] = "CF";
            domainMap["Chad"] = "TD";
            domainMap["Chile"] = "CL";
            domainMap["China"] = "CN";
            domainMap["Colombia"] = "CO";
            domainMap["Comoros"] = "KM";
            domainMap["CookIslands"] = "CK";
            domainMap["CostaRica"] = "CR";
            domainMap["Croatia"] = "HR";
            domainMap["Cuba"] = "CU";
            domainMap["Cyprus"] = "CY";
            domainMap["CzechRepublic"] = "CZ";
            domainMap["DemocraticRepublicOfTheCongo"] = "CD";
            domainMap["Denmark"] = "DK";
            domainMap["Djibouti"] = "DJ";
            domainMap["Dominica"] = "DM";
            domainMap["DominicanRepublic"] = "DO";
            domainMap["EastTimor"] = "TL";
            domainMap["Ecuador"] = "EC";
            domainMap["Egypt"] = "EG";
            domainMap["ElSalvador"] = "SV";
            domainMap["EquatorialGuinea"] = "GQ";
            domainMap["Eritrea"] = "ER";
            domainMap["Estonia"] = "EE";
            domainMap["Eswatini"] = "SZ";
            domainMap["Ethiopia"] = "ET";
            domainMap["FaroeIslands"] = "FO";
            domainMap["Fiji"] = "FJ";
            domainMap["Finland"] = "FI";
            domainMap["France"] = "FR";
            domainMap["Gabon"] = "GA";
            domainMap["Gambia"] = "GM";
            domainMap["Georgia"] = "GE";
            domainMap["Germany"] = "DE";
            domainMap["Ghana"] = "GH";
            domainMap["Greece"] = "GR";
            domainMap["Greenland"] = "GL";
            domainMap["Grenada"] = "GD";
            domainMap["Guatemala"] = "GT";
            domainMap["Guinea"] = "GN";
            domainMap["GuineaBissau"] = "GW";
            domainMap["Guyana"] = "GY";
            domainMap["Haiti"] = "HT";
            domainMap["Honduras"] = "HN";
            domainMap["Hungary"] = "HU";
            domainMap["Iceland"] = "IS";
            domainMap["India"] = "IN";
            domainMap["Indonesia"] = "ID";
            domainMap["Iran"] = "IR";
            domainMap["Iraq"] = "IQ";
            domainMap["Ireland"] = "IE";
            domainMap["Israel"] = "IL";
            domainMap["Italy"] = "IT";
            domainMap["IvoryCoast"] = "CI";
            domainMap["Jamaica"] = "JM";
            domainMap["Japan"] = "JP";
            domainMap["Jordan"] = "JO";
            domainMap["Kazakhstan"] = "KZ";
            domainMap["Kenya"] = "KE";
            domainMap["Kiribati"] = "KI";
            domainMap["Kosovo"] = "XK";
            domainMap["Kuwait"] = "KW";
            domainMap["Kyrgyzstan"] = "KG";
            domainMap["Laos"] = "LA";
            domainMap["Latvia"] = "LV";
            domainMap["Lebanon"] = "LB";
            domainMap["Lesotho"] = "LS";
            domainMap["Liberia"] = "LR";
            domainMap["Libya"] = "LY";
            domainMap["Liechtenstein"] = "LI";
            domainMap["Lithuania"] = "LT";
            domainMap["Luxembourg"] = "LU";
            domainMap["Madagascar"] = "MG";
            domainMap["Malawi"] = "MW";
            domainMap["Malaysia"] = "MY";
            domainMap["Maldives"] = "MV";
            domainMap["Mali"] = "ML";
            domainMap["Malta"] = "MT";
            domainMap["MarshallIslands"] = "MH";
            domainMap["Mauritania"] = "MR";
            domainMap["Mauritius"] = "MU";
            domainMap["Mexico"] = "MX";
            domainMap["Micronesia"] = "FM";
            domainMap["Moldova"] = "MD";
            domainMap["Monaco"] = "MC";
            domainMap["Mongolia"] = "MN";
            domainMap["Montenegro"] = "ME";
            domainMap["Morocco"] = "MA";
            domainMap["Mozambique"] = "MZ";
            domainMap["Myanmar"] = "MM";
            domainMap["Namibia"] = "NA";
            domainMap["Nauru"] = "NR";
            domainMap["Nepal"] = "NP";
            domainMap["Netherlands"] = "NL";
            domainMap["NewZealand"] = "NZ";
            domainMap["Nicaragua"] = "NI";
            domainMap["Niger"] = "NE";
            domainMap["Nigeria"] = "NG";
            domainMap["NorthKorea"] = "KP";
            domainMap["NorthMacedonia"] = "MK";
            domainMap["Norway"] = "NO";
            domainMap["Oman"] = "OM";
            domainMap["Pakistan"] = "PK";
            domainMap["Palau"] = "PW";
            domainMap["Panama"] = "PA";
            domainMap["Palestine"] = "PS";
            domainMap["PapuaNewGuinea"] = "PG";
            domainMap["Paraguay"] = "PY";
            domainMap["Peru"] = "PE";
            domainMap["Philippines"] = "PH";
            domainMap["Poland"] = "PL";
            domainMap["Portugal"] = "PT";
            domainMap["PuertoRico"] = "PR";
            domainMap["Qatar"] = "QA";
            domainMap["RepublicOfTheCongo"] = "CG";
            domainMap["Romania"] = "RO";
            domainMap["Russia"] = "RU";
            domainMap["Rwanda"] = "RW";
            domainMap["SaintKittsAndNevis"] = "KN";
            domainMap["SaintLucia"] = "LC";
            domainMap["SaintVincentAndTheGrenadines"] = "VC";
            domainMap["Samoa"] = "WS";
            domainMap["SanMarino"] = "SM";
            domainMap["SaoTomeAndPrincipe"] = "ST";
            domainMap["SaudiArabia"] = "SA";
            domainMap["Senegal"] = "SN";
            domainMap["Serbia"] = "RS";
            domainMap["Seychelles"] = "SC";
            domainMap["SierraLeone"] = "SL";
            domainMap["Singapore"] = "SG";
            domainMap["Slovakia"] = "SK";
            domainMap["Slovenia"] = "SI";
            domainMap["SolomonIslands"] = "SB";
            domainMap["Somalia"] = "SO";
            domainMap["SouthAfrica"] = "ZA";
            domainMap["SouthKorea"] = "KR";
            domainMap["SouthSudan"] = "SS";
            domainMap["Spain"] = "ES";
            domainMap["SriLanka"] = "LK";
            domainMap["Sudan"] = "SD";
            domainMap["Suriname"] = "SR";
            domainMap["Sweden"] = "SE";
            domainMap["Switzerland"] = "CH";
            domainMap["Syria"] = "SY";
            domainMap["Taiwan"] = "TW";
            domainMap["Tajikistan"] = "TJ";
            domainMap["Tanzania"] = "TZ";
            domainMap["Thailand"] = "TH";
            domainMap["TheBahamas"] = "BS";
            domainMap["Togo"] = "TG";
            domainMap["Tokelau"] = "TK";
            domainMap["Tonga"] = "TO";
            domainMap["TrinidadAndTobago"] = "TT";
            domainMap["Tunisia"] = "TN";
            domainMap["Turkey"] = "TR";
            domainMap["Turkmenistan"] = "TM";
            domainMap["Tuvalu"] = "TV";
            domainMap["Uganda"] = "UG";
            domainMap["Ukraine"] = "UA";
            domainMap["UnitedArabEmirates"] = "AE";
            domainMap["UnitedKingdom"] = "GB";
            domainMap["UnitedStatesOfAmerica"] = "US";
            domainMap["Uruguay"] = "UY";
            domainMap["Uzbekistan"] = "UZ";
            domainMap["Vanuatu"] = "VU";
            domainMap["VaticanCity"] = "VA";
            domainMap["Venezuela"] = "VE";
            domainMap["Vietnam"] = "VN";
            domainMap["WesternSahara"] = "EH";
            domainMap["Yemen"] = "YE";
            domainMap["Zambia"] = "ZM";
            domainMap["Zimbabwe"] = "ZW";
         }
         return (string)domainMap[key] ;
      }

   }

}
