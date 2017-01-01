using System;



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


            foreach (var Bank in rootBank.Banks)
            {
                Console.WriteLine(Bank.Name);

            }
            //foreach (var bilobank2 in biloBank.Banks)
            //{
            //    Console.WriteLine(bilobank2.Name);
            //}
            Console.ReadKey();                         
        }
    }
}
