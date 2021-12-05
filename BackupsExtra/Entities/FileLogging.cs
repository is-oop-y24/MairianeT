using System.IO;
using Serilog;

namespace BackupsExtra.Entities
{
    public class FileLogging : ILogging
    {
        public FileLogging(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public void Logging(string massege)
        {
            var logger = new LoggerConfiguration()
                .WriteTo.File(Path)
                .CreateLogger();
            logger.Information(massege);
        }
    }
}