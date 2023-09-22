using Serilog;
using System;
using System.Linq;

namespace Yapoml.Extensions.Logging.Serilog
{
    public class SerilogAdapter : IDisposable
    {
        private readonly ILogger _serilogLogger;

        private readonly Framework.Logging.ILogger _logger;

        public SerilogAdapter(Framework.Logging.ILogger logger, ILogger serilogLogger)
        {
            _logger = logger;
            _serilogLogger = serilogLogger;

            _logger.OnLogScopeBegin += Logger_OnLogScopeBegin;
            _logger.OnLogMessage += Logger_OnLogMessage;
            _logger.OnLogScopeEnd += Logger_OnLogScopeEnd;
        }

        private void Logger_OnLogScopeBegin(object sender, Framework.Logging.LogScopeEventArgs e)
        {
            var depth = (int)(e.LogScope?.Depth ?? 0);

            var prefix = string.Concat(Enumerable.Repeat("╎ ", depth)) + "• ";

            _serilogLogger.Verbose($"{prefix}{e.LogScope.Name}");
        }

        private void Logger_OnLogMessage(object sender, Framework.Logging.LogMessageEventArgs e)
        {
            var depth = (int)(e.LogScope?.Depth + 1 ?? 0);

            var prefix = string.Concat(Enumerable.Repeat("╎ ", depth));

            _serilogLogger.Verbose($"{prefix}{e.Message}");
        }

        private void Logger_OnLogScopeEnd(object sender, Framework.Logging.LogScopeEventArgs e)
        {
            var duration = e.LogScope.EndTime - e.LogScope.BeginTime;

            if (duration.TotalSeconds >= 1)
            {
                string message;

                var depth = (int)(e.LogScope?.Depth ?? 0);

                var prefix = string.Concat(Enumerable.Repeat("╎ ", depth));

                message = $"• {duration.TotalSeconds:0.#}s";

                _serilogLogger.Verbose($"{prefix}{message}");
            }
        }

        public void Dispose()
        {
            _logger.OnLogScopeBegin -= Logger_OnLogScopeBegin;
            _logger.OnLogMessage -= Logger_OnLogMessage;
            _logger.OnLogScopeEnd -= Logger_OnLogScopeEnd;
        }
    }
}
