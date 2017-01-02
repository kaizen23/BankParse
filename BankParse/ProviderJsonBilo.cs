using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankParse
{
    class ProviderJsonBilo
    {

        public RootBank GetReadAllLines()
        {
            
            using (StreamReader file = File.OpenText("BanksContainer.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    RootBank banks = (RootBank)serializer.Deserialize(file, typeof(RootBank));

                banks.Banks = banks.Banks.Select(x => { x.Name = x.Name.Trim().Replace(" ",""); return x; })
                                         .Select(x => { x.SortCodes = x.SortCodes.Trim(); return x; })
                                         .ToList();
                return banks;
                }
           
        }
    }
}

