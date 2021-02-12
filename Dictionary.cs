using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndMap
{
    class Dictionary<TKey, TValue> : IEnumerable
    {
        private Item<TKey, TValue>[] items;
        private List<TKey> keys = new List<TKey>();
        private int size;
        
        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public Dictionary(int Size)
        {
            size = Size;
            items = new Item<TKey, TValue>[size];
        }

        public void Add(Item<TKey, TValue> item)
        {
            int hashKey = GetHash(item.key);
            

            if(keys.Contains(item.key))
            {
                return;
            }

            keys.Add(item.key);

            if (items[hashKey] == null)
            {
                items[hashKey] = item;
                
            }
            else
            {
                for (int index = hashKey; index < size; index++)
                {
                    if(items[index] == null)
                    {
                        items[index] = item;
                        return;
                    }
                }

                for (int index = 0; index < hashKey; index++)
                {
                    if (items[index] == null)
                    {
                        items[index] = item;
                        return;
                    }
                }

                throw new Exception("Dictionary is full");
            }
        }

        public void Delete(TKey key)
        {
            if(!keys.Contains(key))
            {
                Console.WriteLine("Dictionary doesn't contain item with this key");
                return;
            }

            int hashKey = GetHash(key);
            keys.Remove(key);

            if (items[hashKey] == null)
            {
                for (int index = hashKey; index < size; index++)
                {
                    if(items[index] != null && items[index].key.Equals(key))
                    {
                        items[index] = null;
                        return;
                    }
                }

                for (int index = 0; index < hashKey; index++)
                {
                    if(items[index] != null && items[index].key.Equals(key))
                    {
                        items[index] = null;
                        return;
                    }
                }

                throw new ArgumentException("Dictionary doesnt contains item with this key"); 
            }

            if(items[hashKey].key.Equals(key))
            {
                items[hashKey] = null;
                return;
            }
        }

        public TValue Search(TKey key)
        {
            if(!keys.Contains(key))
            {
                Console.WriteLine("Dictionary doesn't contains item with this key");
                return default(TValue);
            }

            int hashKey = GetHash(key);

            if(items[hashKey] == null)
            {
                foreach (var collectionItem in items)
                {
                    if (collectionItem.key.Equals(key))
                    {
                        return collectionItem.value;
                    }
                }

                return default(TValue);
                
            }

            if(items[hashKey].key.Equals(key))
            {
                return items[hashKey].value;
            }
            else
            {
                for (int index = hashKey; index < size; index++)
                {
                    if(items[index] == null)
                    {
                        return default(TValue);
                    }
                    
                    if(items[index].key.Equals(key))
                    {
                        return items[index].value;
                    }
                }

                Console.WriteLine("Dictionary doesn't contains item with this key");
                return default(TValue);
            }
        }

        public int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }


    }
}
