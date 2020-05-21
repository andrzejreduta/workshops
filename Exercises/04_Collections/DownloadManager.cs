using System;
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

            _downloadsCount++;
            return GetFiles();
            // return new[]
            // {
            //     new File(),
            //     new File(),
            //     new File(),
            //     new File(),
            //     new File()
            // };
        }

        private IEnumerable<File> GetFiles()
        {
            yield return new File();
            yield return new File();
            yield return new File();
            yield return new File();
            yield return new File();
        }
    }
}