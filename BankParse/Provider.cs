using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;


namespace BankParse
{
    class Provider
    {
        public List<String> GetReadAllLines()
        {
            var url = "http://www.nbp.pl/banki_w_polsce/ewidencja/dz_bank_jorg.txt";
            var client = new WebClient();
            var list = new List<string>();

            using (var stream = client.OpenRead(url))
            {


                using (var reader = new StreamReader(stream))
                {

                    while ((reader.ReadLine()) != null)
                    {
                        list.Add(reader.ReadLine());

                    }
                }
            }

            return list;
        }

        public IEnumerable SelectNameSortCode(List<string> AllLines)
        {
            var items = from c in (
                         from item in AllLines
                           let columns = item.Split('\t')
                           select new { Bank = new{
                                               SortCodes = columns[3].Trim(),
                                               Name = columns[5].Trim()
                                                  }
                                      }
                                   )
                        select c;

            return items;
        }

        public string ConvertToJson(IEnumerable NameSortCode)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string json = jss.Serialize(NameSortCode);

            return json;
        }
    }
}
