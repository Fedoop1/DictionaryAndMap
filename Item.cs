using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryAndMap
{
    class Item<TKey, TValue>
    {
        public TValue value { get; set; }
        public TKey key { get; set; }

        public Item( TKey key, TValue data)
        {
            this.key = key;
            value = data;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
