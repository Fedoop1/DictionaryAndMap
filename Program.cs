using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndMap
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(100);

            EasyMap<int,string> easyMap = new EasyMap<int,string>();

            dictionary.Add(new Item<int, string>(1, "Один"));
            dictionary.Add(new Item<int, string>(2, "Два"));
            dictionary.Add(new Item<int, string>(3, "Три"));
            dictionary.Add(new Item<int, string>(4, "Четыре"));
            dictionary.Add(new Item<int, string>(7, "Семь"));
            dictionary.Add(new Item<int, string>(101, "Сто один"));

            Console.WriteLine(dictionary.Search(7));
            Console.WriteLine(dictionary.Search(1));
            Console.WriteLine(dictionary.Search(0));
            Console.WriteLine(dictionary.Search(101));

            dictionary.Delete(7);

            foreach (var item in dictionary)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();

            easyMap.Add(new Item<int, string>(1, "Один"));
            easyMap.Add(new Item<int, string>(2, "Два"));
            easyMap.Add(new Item<int, string>(3, "Три"));
            easyMap.Add(new Item<int, string>(4, "Четыре"));
            easyMap.Add(new Item<int, string>(7, "Семь"));
            easyMap.Add(new Item<int, string>(9, "Тринадцать"));

            Console.WriteLine(easyMap.Search(7));
            Console.WriteLine(easyMap.Search(1));
            Console.WriteLine(easyMap.Search(0));
            Console.WriteLine(easyMap.Search(9));

            easyMap.Delete(7);

            Console.WriteLine();
            foreach (var item in easyMap)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }
    }
}
