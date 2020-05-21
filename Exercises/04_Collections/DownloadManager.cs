using System.Collections.Generic;

namespace Exercises._04_Collections
{
    public class DownloadManager
    {
        private int _downloadsCount;

        public IEnumerable<File> Download()
        {
            if (_downloadsCount >= 5)
                throw new DomainException();

            yield return new File();
            yield return new File();
            yield return new File();
            yield return new File();
            yield return new File();
            _downloadsCount++;
        }
    }
}