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

            foreach (var bank in except)
                Console.WriteLine(bank.Name + " " + bank.SortCodes);


            //foreach (var Bank in rootBank.Banks)
            //{
            //    Console.WriteLine(Bank.Name);

            //}
            //foreach (var bilobank2 in biloBank.Banks)
            //{
            //    Console.WriteLine(bilobank2.Name);
            //}
            Console.ReadKey();                         
        }
    }
}
