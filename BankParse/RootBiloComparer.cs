using System;
using System.Collections.Generic;
using System.Linq;

namespace BankParse
{
    class RootBiloComparer : IEqualityComparer<Bank>
    {

        public bool Equals(Bank x, Bank y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            //Check whether the products' properties are equal.
            return x.Name == y.Name && x.SortCodes == y.SortCodes;
        }

        public int GetHashCode(Bank bank)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(bank, null)) return 0;

            //Get hash code for the Name field if it is not null.
            int hashProductName = bank.Name == null ? 0 : bank.Name.GetHashCode();

            //Get hash code for the Code field.
            int hashProductSortCode = bank.SortCodes.GetHashCode();

            //Calculate the hash code for the product.
            return hashProductName ^ hashProductSortCode;
        }
    }
}
