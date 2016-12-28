using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace BankParse
{
    class Program
    {
        static void Main(string[] args)

        {
            var url = "http://www.nbp.pl/banki_w_polsce/ewidencja/dz_bank_jorg.txt";
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            {

                var list = new List<string>();

                using (var reader = new StreamReader(stream))
                {

                    while ((reader.ReadLine()) != null)
                    {
                        list.Add(reader.ReadLine());

                    }

                    //var items = (from c in
                    //             (from item in list
                    //              let columns = item.Split('\t')
                    //      select new
                    //              {
                    //                  SortCodes = columns[3].Trim(),
                    //                  Name = columns[5].Trim()
                    //              })
                    //             select c);
                    var items = (from c in
                                 (from item in list
                                  let columns = item.Split('\t')
                                
                                  select new { Bank =
                                  new 
                                  {
                                      SortCodes = columns[3].Trim(),
                                      Name = columns[5].Trim()
                                  }          }
                                  )
                                 select c);

                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    string json = jss.Serialize(items);

                    Console.WriteLine(json);
                    Console.ReadKey();



                    foreach (var item in items)
                    {
                        //System.Console.WriteLine(item.SortCodes);

                    }
                    Console.ReadKey();

                }
            }
        }
    }
}
