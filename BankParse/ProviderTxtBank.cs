using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace BankParse
{
    class ProviderTxtBank
    {

        private string readLine;

        public List<String> GetReadAllLines()
        {
            //var url = "http://www.nbp.pl/banki_w_polsce/ewidencja/dz_bank_jorg.txt";
            var url = "dz_bank_jorg.txt";
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

                List<string> lista = new List<string>();
                lista = columns[3].Trim().TrimEnd(',').Split(',').ToList();

                StringBuilder builder = new StringBuilder();
                foreach (string l in lista)
                {
                    builder.Append(l.Trim().PadRight(4, '0') + ", ");
                }
                return new Bank
                {
                    SortCodes = builder.ToString().Remove(builder.Length - 2),
                    Name = columns[1].Trim().Replace(" ", "")
                };
            })
                                           .Where(c => !c.Name.Contains("likw"))
                                           .Where(c => !c.Name.Contains("upadł"))
                                           .GroupBy(bank => new { bank.Name, bank.SortCodes })
                                           .Select(g => g.First())
                                           .ToList();
            return rootBank;
        }
    }
}
