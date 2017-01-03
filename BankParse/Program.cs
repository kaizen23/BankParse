using System;
using System.Collections.Generic;
using System.Linq;

namespace BankParse
{
    class Program
    {
        static void Main(string[] args)

        {


            var ProviderBilo = new ProviderJsonBilo();
            ProviderBilo.GetReadAllLines();

            var Provider = new ProviderTxtBank();
            var GetReadAllLines = Provider.GetReadAllLines();

            var rootBank = new RootBank();
            rootBank = Provider.SelectNameSortCode(GetReadAllLines);

            var biloBank = new RootBank();
            biloBank = ProviderBilo.GetReadAllLines();


            IEnumerable<Bank> exceptBilo = biloBank.Banks.Except(rootBank.Banks, new RootBiloComparer());
            var x = 0;
            Console.WriteLine("*************************************************************\nBanki znajdujące się w pliku json, a nie ma ich na stronie www:\n");
            foreach (var bank in exceptBilo)
            {
                Console.WriteLine(bank.Name + "," + bank.SortCodes);
                x++;
            }
            Console.WriteLine("\nRóżnica równa: {0}\n\n*************************************************************\n", x);


            IEnumerable<Bank> exceptBank = rootBank.Banks.Except(biloBank.Banks, new RootBiloComparer());
            var i = 0;
            Console.WriteLine("*************************************************************\nBanki znajdujące się na stronie www, a nie ma ich w pliku json:\n");
            foreach (var bank in exceptBank)
            {
                i++;
                Console.WriteLine(bank.Name + "," + bank.SortCodes);
            }
            Console.WriteLine("\nRóżnica równa: {0}\n\n*************************************************************\n", i);

            Console.ReadKey();                         
        }
    }
}
