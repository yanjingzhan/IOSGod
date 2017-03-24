using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityLib
{
    public class CountryHelper
    {
        private static Random _rd = new Random();

        private static List<string> _countryValueList = new List<string>
        {
            "DZ","AF","AR","AE","AW","OM","AZ","EG","ET","IE","EE","AD","AO","AI","AG","AT","AX","AU","MO","BB","PG","BS","PK","PY","PS","BH","PA","BR","BY","BM","BG","MP","BJ","BE","IS","PR","PL","BA","BO","BZ","BW","BQ","BT","BF","BI","BV","KP","GQ","DK","DE","TL","TG","DO","DM","RU","EC","ER","FR","FO","PF","GF","TF","PH","FJ","FI","CV","FK","GM","CD","CG","CO","CR","GG","GD","GL","GE","CU","GP","GU","GY","KZ","HT","KR","NL","HM","ME","HN","KI","DJ","KG","GN","GW","CA","GH","GA","KH","CZ","ZW","CM","QA","KY","CC","KM","XK","CI","KW","HR","KE","CK","CW","LV","LS","LA","LB","LT","LR","LY","LI","RE","LU","RW","RO","MG","IM","MV","MT","MW","MY","ML","MH","MQ","YT","MU","MR","US","AS","UM","VI","MN","MS","BD","PE","FM","MM","MD","MA","MC","MZ","MX","NA","ZA","AQ","GS","NR","NP","NI","NE","NG","NU","NO","NF","PW","PN","PT","MK","JP","SE","CH","SV","WS","RS","SL","SN","CY","SC","XS","SA","BL","CX","ST","SH","KN","LC","MF","SX","SM","PM","VC","XE","VA","LK","SK","SI","SZ","SD","SR","SB","SO","TJ","TW","TH","TZ","TO","TC","TT","TN","TV","TR","TM","TK","WF","VU","GT","VG","VE","BN","UG","UA","UY","UZ","ES","GR","HK","SG","NC","NZ","HU","SY","JM","AM","SJ","YE","IQ","IR","IL","IT","IN","ID","UK","IO","JO","VN","ZM","JE","TD","GI","CL","CF","CN"
        };

        public static string GetRandomCountryValue()
        {
            return _countryValueList[_rd.Next(0, _countryValueList.Count - 1)];
        }
    }
}
