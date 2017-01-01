using System.Collections.Generic;
using System.Linq;

namespace BankParse
{
    class RootBiloComparer
    {
        public List<Bank> ComparerRootBilo(RootBank root, RootBank bilo)
        {
            var firstNotSecond = root.Banks.Except(bilo.Banks).ToList();

            return firstNotSecond;
        }

        public List<Bank> ComparerBiloRoot(RootBank bilo, RootBank root)
        {
            
            var secondNotFirst = bilo.Banks.Except(root.Banks).ToList();

            return secondNotFirst;
        }
    }
}
