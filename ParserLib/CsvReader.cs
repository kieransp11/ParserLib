using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ParserLib
{
    public class CsvReader : IDisposable, IAsyncDisposable, IEnumerable<CsvRecord>, IAsyncEnumerable<CsvRecord>
    {
        private static void Throw(ErrorCode errorCode, int recordCount)
        {

        }

        // TODO add setter checking here to see if it will actually be called.
        public Action<ErrorCode, int> ExtraValueAction { get; set; }
        public Action<ErrorCode, int> MissingValueAction { get; set; }

        public Action<ErrorCode, int> ErrorAction { get; set; }


        public CsvReader(CsvConfig config, TextReader reader, bool owner = false)
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerator<CsvRecord> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<CsvRecord> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // Actual methods

        public IReadOnlyCollection<string?> Headers { get; }
    }
}
