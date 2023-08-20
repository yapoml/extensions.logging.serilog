using Serilog;
using System;

namespace Yapoml.Extensions.Logging.Serilog
{
    public class SerilogAdapter : Framework.Logging.Listeners.ILogListener, IDisposable
    {
        private readonly ILogger _serilogLogger;

        private Framework.Logging.ILogger _yapomlLogger;

        public SerilogAdapter(ILogger serilogLogger)
        {
            _serilogLogger = serilogLogger;
        }

        public void Initialize(Framework.Logging.ILogger logger)
        {
            _yapomlLogger = logger;

            _yapomlLogger.OnLogMessage += Logger_OnLogMessage;
        }

        private void Logger_OnLogMessage(object sender, Framework.Logging.LogMessageEventArgs e)
        {
            _serilogLogger.Verbose(e.Message);
        }

        public void Dispose()
        {
            _yapomlLogger.OnLogMessage -= Logger_OnLogMessage;
        }
    }
}
