using Serilog;
using Yapoml.Extensions.Logging.Serilog;
using Yapoml.Framework.Options;

namespace Yapoml
{
    public static class SpaceOptionsExtension
    {
        public static ISpaceOptions UseSerilog(this ISpaceOptions spaceOptions)
        {
            spaceOptions.Register<Framework.Logging.ILogger>(new SerilogAdapter(Log.Logger));

            return spaceOptions;
        }

        public static ISpaceOptions UseSerilog(this ISpaceOptions spaceOptions, ILogger logger)
        {
            spaceOptions.Register<Framework.Logging.ILogger>(new SerilogAdapter(logger));

            return spaceOptions;
        }
    }
}
