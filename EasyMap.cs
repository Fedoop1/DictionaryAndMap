using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndMap
{
    class EasyMap<TKey, TValue> : IEnumerable
    {
        private List<Item<TKey, TValue>> items = new List<Item<TKey, TValue>>();
        private List<TKey> keys = new List<TKey>();

        public void Add(Item<TKey, TValue> item)
        {

            if(keys.Contains(item.key))
            {
                return;
            }
            else
            {
                keys.Add(item.key);
                items.Add(item);
            }
        }

        public void Delete(TKey key)
        {
            if(keys.Contains(key))
            {
                items.Remove(items.Single(x => x.key.Equals(key)));
                keys.Remove(key);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public TValue Search(TKey key)
        {
            if(keys.Contains(key))
            {
                return items.Single(x => x.key.Equals(key)).value;
            }

            Console.Write("Объект с таким ключём не найден.");
            return default(TValue);
        }
    }
}
