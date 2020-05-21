using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Exercises._08_Exceptions
{
    internal class FakeLogger : ILogger
    {
        private readonly List<(LogLevel, Exception, string)> _logs = new List<(LogLevel, Exception, string)>();
        public IEnumerable<(LogLevel Level, Exception Exception, string Message)> Logs => _logs;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter) =>
            _logs.Add((logLevel, exception, formatter(state, exception)));

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => throw new NotSupportedException();
    }
}