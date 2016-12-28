using System;



namespace BankParse
{
    class Program
    {
        static void Main(string[] args)

        {
            var Provider = new Provider();
            var GetReadAllLines = Provider.GetReadAllLines();
            var Items = Provider.SelectNameSortCode(GetReadAllLines);
            var Json = Provider.ConvertToJson(Items);
            Console.WriteLine(Json);
            Console.ReadKey();                          
        }
    }
}
