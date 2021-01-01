using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ParserLib
{
    public record CsvRecord : IReadOnlyCollection<string>, IReadOnlyDictionary<string, string>, IReadOnlyDictionary<int, string>
    {
        public string this[string key] => throw new NotImplementedException();

        public string this[int key] => throw new NotImplementedException();

        public IEnumerable<string> Keys => throw new NotImplementedException();

        public IEnumerable<string> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        IEnumerable<int> IReadOnlyDictionary<int, string>.Keys => throw new NotImplementedException();

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int key, [MaybeNullWhen(false)] out string value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<int, string>> IEnumerable<KeyValuePair<int, string>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
