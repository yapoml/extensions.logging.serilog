using Serilog;
using Yapoml.Extensions.Logging.Serilog;
using Yapoml.Framework.Options;

namespace Yapoml.Extensions
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions WithSerilog(this ISpaceOptions spaceOptions)
        {
            var logger = spaceOptions.Services.Get<Framework.Logging.ILogger>();

            var serilogAdapter = new SerilogAdapter(logger, Log.Logger);

            spaceOptions.Services.Register(serilogAdapter);

            return spaceOptions;
        }

        public static ISpaceOptions WithSerilog(this ISpaceOptions spaceOptions, ILogger serilogLogger)
        {
            var logger = spaceOptions.Services.Get<Framework.Logging.ILogger>();

            var serilogAdapter = new SerilogAdapter(logger, serilogLogger);

            spaceOptions.Services.Register(serilogAdapter);

            return spaceOptions;
        }
    }
}
