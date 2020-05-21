using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Exercises._04_Collections
{
    public class DownloadManagerTests
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(10, false)]
        public void CanDownloadUpToFiveTimes(int downloadAttempts, bool success)
        {
            var downloadManager = new DownloadManager();
            var files = new IEnumerable<File>[downloadAttempts];
            Action action = () =>
            {
                for (var i = 0; i < downloadAttempts; i++)
                {
                    files[i] = downloadManager.Download();
                }
            };

            if (success)
            {
                action.Should().NotThrow();
                files.SelectMany(f => f).Should().HaveCount(downloadAttempts * 5);
            }
            else
            {
                action.Should().Throw<DomainException>();
            }
        }
    }
}