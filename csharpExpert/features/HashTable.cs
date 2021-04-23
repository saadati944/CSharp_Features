using System;
using System.Collections;
using System.Collections.Generic;

namespace csharpExpert.features
{
    public class HashTable : IFeature
    {
        public void ShowFeature()
        {
            "HashTable".WriteLine();
            
            "fixed type hash table (for example = string, int):".WriteLine();
            var fixedTypeDictionary = new Dictionary<string, int>();
            
            fixedTypeDictionary["hello"] = 12;
            fixedTypeDictionary["word"] = 54;
            fixedTypeDictionary["temp"] = 1;
            foreach (KeyValuePair<string, int> x in fixedTypeDictionary)
            {
                $"{x.Key} : {x.Value}".WriteLine();
            }
            
            
            "dynamic type hash table (for example = string, int):".WriteLine();
            var dynamicTypeDictionary = new Hashtable();
            
            dynamicTypeDictionary["hello"] = "how are you ?";
            dynamicTypeDictionary[12] = DictionaryToString(fixedTypeDictionary);
            
            
            foreach (DictionaryEntry x in dynamicTypeDictionary)
            {
                $"{x.Key} : {x.Value}".WriteLine();
            }
        }

        private string DictionaryToString<K, V>(Dictionary<K, V> dic)
        {
            Func<K, V, string> tostr = (K key, V value) => $" {{{key} : {value}}}, ";
            string output = "{";
            foreach (var v in dic)
                output += tostr(v.Key, v.Value);
            output += "}";
            return output;
        }
    }
}