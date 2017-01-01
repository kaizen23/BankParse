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

            var Provider = new Provider();
            var GetReadAllLines = Provider.GetReadAllLines();

            var rootBank = new RootBank();
            rootBank = Provider.SelectNameSortCode(GetReadAllLines);

            var biloBank = new RootBank();
            biloBank = ProviderBilo.GetReadAllLines();


            IEnumerable<Bank> except =biloBank.Banks.Except(rootBank.Banks, new RootBiloComparer());
            var x = 0;
            foreach (var bank in except)
            {
                Console.WriteLine(bank.Name + "," + bank.SortCodes);
                x++;
            }
            Console.WriteLine(x);


            IEnumerable<Bank> except2 = rootBank.Banks.Except(biloBank.Banks, new RootBiloComparer());
            var i = 0;
            foreach (var bank in except2)
            {
                i++;
                Console.WriteLine(bank.Name + "," + bank.SortCodes);
            }
            Console.WriteLine(i);

            Console.ReadKey();                         
        }
    }
}
