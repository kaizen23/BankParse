using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace BankParse
{
    class Provider
    {
        public List<String> GetReadAllLines()
        {
            var url = "http://www.nbp.pl/banki_w_polsce/ewidencja/dz_bank_jorg.txt";
            var client = new WebClient();
            Encoding encoding = System.Text.Encoding.GetEncoding("ibm852");

            var list = new List<string>();

            using (var stream = client.OpenRead(url))
            {
                using (var reader = new StreamReader(stream,encoding))
                {

                    while ((reader.ReadLine()) != null)
                    {
                        list.Add(reader.ReadLine());

                    }
                }
            }

            return list;
        }


        public RootBank SelectNameSortCode(List<string> AllLines)
        {
            var rootBank = new RootBank();
            rootBank.Banks = (from c in (
                         from item in AllLines
                         let columns = item.Split('\t')
                         select new Bank
                         {
                                SortCodes = columns[3].Trim(),
                                Name = columns[5].Trim()
    
                         }
                             )          
                        select c).ToList();

            rootBank.Banks = rootBank.Banks.GroupBy(bank => bank.SortCodes).Select(g => g.First()).ToList();

            return rootBank;
        }
    }
}
