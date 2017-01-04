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

            var providerTxtBank = new ProviderTxtBank();
            var GetReadAllLines = providerTxtBank.GetReadAllLines();

            var bankFromWWW = new RootBank();
            bankFromWWW = providerTxtBank.SelectNameSortCode(GetReadAllLines);

            var bankFromFile = new RootBank();
            bankFromFile = ProviderBilo.GetReadAllLines();

            IEnumerable<Bank> exceptBilo = bankFromFile.Banks.Except(bankFromWWW.Banks, new RootBiloComparer());
            var x = 0;
            Console.WriteLine("*************************************************************\nBanki znajdujące się w pliku json, a nie ma ich na stronie www:\n");
            foreach (var bank in exceptBilo)
            {
                Console.WriteLine(bank.Name + "," + bank.SortCodes);
                x++;
            }

            Console.WriteLine("\nRóżnica równa: {0}\n\n*************************************************************\n", x);

            IEnumerable<Bank> exceptBank = bankFromWWW.Banks.Except(bankFromFile.Banks, new RootBiloComparer());
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
