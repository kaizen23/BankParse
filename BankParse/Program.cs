using SourceCodeComparer;
using System;



namespace BankParse
{
    class Program
    {
        static void Main(string[] args)

        {
           
            var Provider = new Provider();
            var GetReadAllLines = Provider.GetReadAllLines();
            var rootbank = new RootBank();
            rootbank = Provider.SelectNameSortCode(GetReadAllLines);
            

            foreach(var Bank in rootbank.Banks)
            {
                Console.WriteLine(Bank.Name);
                Console.WriteLine(Bank.SortCodes);

            }
            //Console.WriteLine(GetReadAllLines);
            ////var Json = Provider.ConvertToJson(Banks);
            ////Console.WriteLine(Json);
            Console.ReadKey();                         
        }
    }
}
