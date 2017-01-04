using System;
using System.Collections.Generic;

namespace BankParse
{
   public class RootBiloComparer : IEqualityComparer<Bank>
    {
        public bool Equals(Bank x, Bank y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            {
                return false;
            }
           
            return x.Name == y.Name && x.SortCodes == y.SortCodes;
        }

        public int GetHashCode(Bank bank)
        {

            if (Object.ReferenceEquals(bank, null))
            {
                return 0;
            }
           
            int hashProductName = bank.Name == null ? 0 : bank.Name.GetHashCode();

         
            int hashProductSortCode = bank.SortCodes.GetHashCode();

            
            return hashProductName ^ hashProductSortCode;
        }
    }
}
