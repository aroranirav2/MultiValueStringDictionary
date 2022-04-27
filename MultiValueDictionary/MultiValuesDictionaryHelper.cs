using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    public static class MultiValuesDictionaryHelper
    {
        public static void PrintCollections(IEnumerable<string> collection)
        {
            if (collection != null && collection.Any())
            {
                var i = 1;
                foreach (var item in collection)
                {
                    Console.WriteLine($"{i}) {item}");
                    i++;
                }
            }
            else
                PrintEmptySet();
        }
        public static void Remove(string[] commands, MultiStringValuesDictionary multiStringValuesDictionary)
        {
            if (commands.Length > 2)
                multiStringValuesDictionary.Remove(commands[1], commands[2]);
            else
                multiStringValuesDictionary.Remove(commands[1]);
            Console.WriteLine(") Removed");
        }

        public static void PrintCollectionsOfCollections(IEnumerable<IEnumerable<String>> collections)
        {
            if (collections != null && collections.Any())
            {
                var i = 1;
                foreach (var collection in collections)
                {
                    if (collection != null && collection.Any())
                    {
                        foreach (var item in collection)
                        {
                            Console.WriteLine($"{i}) {item}");
                            i++;
                        }
                    }
                }
            }
            else
                PrintEmptySet();
        }
        public static void PrintPairedValueCollections(IEnumerable<(string, string)> collection)
        {
            var i = 1;
            if (collection != null && collection.Any())
            {
                foreach (var item in collection)
                {
                    Console.WriteLine($"{i}) {item.Item1}: {item.Item2}");
                    i++;
                }
            }
            else
                PrintEmptySet();
        }
        private static void PrintEmptySet() => Console.WriteLine(") empty set");
    }
}
