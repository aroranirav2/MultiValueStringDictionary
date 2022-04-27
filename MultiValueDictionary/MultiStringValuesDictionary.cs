using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionary
{
    /// <summary>
    /// It is a multi member dictionary just for strings, no other types is supported
    /// </summary>
    public class MultiStringValuesDictionary
    {
        private readonly Dictionary<string, List<string>> _dictionary;

        public MultiStringValuesDictionary()
        {
            _dictionary = new Dictionary<string, List<string>>();
        }

        /// <summary>
        /// gets all keys from the dictionary
        /// </summary>
        public IEnumerable<string> Keys => _dictionary.Keys;

        /// <summary>
        /// Adds key value pair to the dictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(string key, string member)
        {
            if (KeyExists(key))
            {
                if (MemberExists(key, member))
                    throw new ArgumentException($") ERROR, member: {member} already exists for key.");

                _dictionary[key].Add(member);
            }
            else
                _dictionary.Add(key, new List<string> { member });
        }

        /// <summary>
        /// Lists out all the members of key
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <returns>List of members for the key</returns>
        public List<string> Members(string key)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException(KeyNotFoundMessage(key));

            return _dictionary[key];
        }

        /// <summary>
        /// Removes a selected member from a selected key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Remove(string key, string member)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException(KeyNotFoundMessage(key));

            if (!MemberExists(key, member))
                throw new ArgumentException($") Error, Member: {member} does not exist.");

            if (_dictionary[key].Count == 1)
                _dictionary.Remove(key);
            else
                _dictionary[key].Remove(member);

        }

        /// <summary>
        /// Removes a key and all it's members
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Remove(string key)
        {
            if (!KeyExists(key))
                throw new KeyNotFoundException(KeyNotFoundMessage(key));

            _dictionary.Remove(key);
        }

        /// <summary>
        /// clears the dictionary
        /// </summary>
        public void Clear() => _dictionary.Clear();

        /// <summary>
        /// checks if the key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns>true if key exists, false if key does not exist</returns>
        public bool KeyExists(string key) => _dictionary.ContainsKey(key);

        /// <summary>
        /// checks if member exists
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns>returns true if member exists, false if not</returns>
        public bool MemberExists(string key, string member)
        {
            if (!KeyExists(key))
                return false;
            return _dictionary[key].Contains(member);
        }

        /// <summary>
        /// returns all the members inside the dictionary
        /// </summary>
        /// <returns>all members for each key</returns>
        public List<List<string>> AllMembers()
        {
            if (!_dictionary.Any())
                return new List<List<string>>();
            return _dictionary.Values.ToList();
        }

        /// <summary>
        /// returns list of key value
        /// </summary>
        /// <returns>key values pairs per determined by value</returns>
        public List<(string, string)> Items()
        {
            var list = new List<(string, string)>();
            if (_dictionary.Any())
            {
                foreach (var key in _dictionary.Keys)
                {
                    foreach (var member in _dictionary[key])
                        list.Add((key, member));
                }
            }
            return list;
        }

        /// <summary>
        /// sets the message for key does not exist
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private string KeyNotFoundMessage(string key) => $") ERROR, Key: {key} does not exist.";
    }
}
