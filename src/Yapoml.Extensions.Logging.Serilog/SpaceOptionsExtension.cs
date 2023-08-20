using Serilog;
using Yapoml.Extensions.Logging.Serilog;
using Yapoml.Framework.Options;

namespace Yapoml
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions WithSerilog(this ISpaceOptions spaceOptions)
        {
            var serilogAdapter = new SerilogAdapter(Log.Logger);

            serilogAdapter.Initialize(spaceOptions.Services.Get<Framework.Logging.ILogger>());

            return spaceOptions;
        }

        public static ISpaceOptions WithSerilog(this ISpaceOptions spaceOptions, ILogger logger)
        {
            var serilogAdapter = new SerilogAdapter(logger);

            serilogAdapter.Initialize(spaceOptions.Services.Get<Framework.Logging.ILogger>());

            return spaceOptions;
        }
    }
}
