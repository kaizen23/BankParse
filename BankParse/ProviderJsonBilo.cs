using Newtonsoft.Json;
using System.IO;
using System.Linq;


namespace BankParse
{
    class ProviderJsonBilo
    {
        public RootBank GetReadAllLines()
        {
            using (StreamReader file = File.OpenText("BanksContainer.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                RootBank banksContainer = (RootBank)serializer.Deserialize(file, typeof(RootBank));

                banksContainer.Banks.ForEach(x =>
                {
                    x.Name = x.Name.Trim().Replace("  ", " ");
                    x.SortCodes = x.SortCodes.Trim().TrimEnd(',');
                });

                return banksContainer;
            }
        }
    }
}

