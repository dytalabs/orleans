using System;
using System.Collections.Generic;

namespace Orleans.Runtime
{
    internal class AssemblyLoaderPathNameCriterion : AssemblyLoaderCriterion
    {
#pragma warning disable 109
        internal new delegate bool Predicate(string pathName, out IEnumerable<string> complaints);
#pragma warning restore 109

        internal static AssemblyLoaderPathNameCriterion NewCriterion(Predicate predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            return new AssemblyLoaderPathNameCriterion(predicate);
        }

        private AssemblyLoaderPathNameCriterion(Predicate predicate) :
            base((object input, out IEnumerable<string> complaints) =>
                    predicate((string)input, out complaints))
        {}
    }
}
