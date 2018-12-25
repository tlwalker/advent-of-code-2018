using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    public class PackageFinder
    {
        private readonly IEnumerable<string> _packageIds;

        public PackageFinder(IEnumerable<string> packageIds)
        {
            _packageIds = packageIds;
        }

        public string FindCommonLetters()
        {
            (string package1, string package2) = FindCorrespondingPackages();
            return GetCommonLettersAsString(package1, package2);
        }

        private (string, string) FindCorrespondingPackages()
        {
            var package1 = _packageIds.First();
            var package2 = string.Empty;
            var rest = _packageIds.Skip(1).ToList();
            var found = false;
            while (!found)
            {
                foreach (var packageId in rest)
                {
                    var distance = GetDistance(package1, packageId);
                    if (distance != 1) continue;

                    package2 = packageId;
                    found = true;
                    break;
                }

                if (found) continue;
                package1 = rest.First();
                rest = rest.Skip(1).ToList();
            }
            

            return (package1, package2);
        }

        private static int GetDistance(string package1, string package2) => package1.Where((t, i) => t != package2[i]).Count();

        private static string GetCommonLettersAsString(string package1, string package2) => new string(package1.Where((t, i) => t == package2[i]).ToArray());
    }
}