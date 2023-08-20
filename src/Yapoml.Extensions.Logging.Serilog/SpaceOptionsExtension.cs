using Serilog;
using Yapoml.Extensions.Logging.Serilog;
using Yapoml.Framework.Options;

namespace Yapoml
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions UseSerilog(this ISpaceOptions spaceOptions)
        {
            var serilogAdapter = new SerilogAdapter(Log.Logger);

            serilogAdapter.Initialize(spaceOptions.Services.Get<Framework.Logging.ILogger>());

            return spaceOptions;
        }

        public static ISpaceOptions UseSerilog(this ISpaceOptions spaceOptions, ILogger serilogLogger)
        {
            var serilogAdapter = new SerilogAdapter(serilogLogger);

            serilogAdapter.Initialize(spaceOptions.Services.Get<Framework.Logging.ILogger>());

            return spaceOptions;
        }
    }
}
