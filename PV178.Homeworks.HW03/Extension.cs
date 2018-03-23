using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    public static class Extension
    {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<KeyValuePair<TKey, TValue>> objects)
        {
            foreach (var obj in objects)
            {
                if (dictionary.ContainsKey(obj.Key))
                { 
                    dictionary[obj.Key] = obj.Value;
                }
                else
                { 
                    dictionary.Add(obj.Key, obj.Value);
                }
            }
        }

        public static String GetInfo<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary.ContainsKey(key))
            {
                return dictionary[key].ToString();
            }
            return "Key not found.";
        }
    }
}
