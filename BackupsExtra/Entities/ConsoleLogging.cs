using Serilog;
using Serilog.Core;

namespace BackupsExtra.Entities
{
    public class ConsoleLogging : ILogging
    {
        public void Logging(string message)
        {
            Logger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            logger.Information(message);
        }
    }
}