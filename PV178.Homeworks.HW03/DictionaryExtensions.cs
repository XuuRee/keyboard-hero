using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW03
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds the elements of the specific collection to the Dictionary. 
        /// </summary>
        /// <param name="objects">objects</param>
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

        /// <summary>
        /// Return name and frequency of tone. Every tone is in
        /// dictionary with specific key.
        /// </summary>
        /// <param name="key">key</param>
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
