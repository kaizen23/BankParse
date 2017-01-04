using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BankParse
{
    public class ProviderTxtBank
    {
        private string readLine;
        public List<String> GetReadAllLines()
        {
            var url = "http://www.nbp.pl/banki_w_polsce/ewidencja/dz_bank_jorg.txt";
            var client = new WebClient();
            Encoding encoding = Encoding.GetEncoding("ibm852");

            var list = new List<string>();

            using (var stream = client.OpenRead(url))
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    while (((readLine = reader.ReadLine())) != null)
                    {
                        list.Add(readLine);
                    }
                }
            }
            return list;
        }

        public RootBank SelectNameSortCode(List<string> AllLines)
        {
            var rootBank = new RootBank();

            rootBank.Banks = AllLines.Select(line =>
            {
                var columns = line.Split('\t');
                var listSortCode = SplitSortCodes(columns[3]);

                return new Bank
                {
                    SortCodes = GetSortCodeFromListSortCode(listSortCode),
                    Name = GetNamesFromColumns(columns)
                };
            })
                                       .Where(b => !b.Name.Contains("upad") && !b.Name.Contains("likw"))
                                       .GroupBy(bank => new { bank.Name, bank.SortCodes })
                                       .Select(b => b.First())
                                       .ToList();
            return rootBank;
        }

        private static string GetNamesFromColumns(string[] columns)
        {
            return columns[1].Trim().Replace("  ", " ");
        }
        private List<string> SplitSortCodes( string SortCode)
        {
            List<string> list = new List<string>();
            list = SortCode.Trim().TrimEnd(',').Split(',').ToList();
     
            return list;
        }
        private string GetSortCodeFromListSortCode(List<string> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string s in list)
            {
                builder.Append(s.Trim().PadRight(4, '0') + ", ");
            }
            return builder.ToString().Remove(builder.Length - 2);
        }
    }
}
