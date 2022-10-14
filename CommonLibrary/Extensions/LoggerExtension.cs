using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Enrichers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonLibrary.Extensions
{
    public static class LoggerExtension
    {
        public static void LogErrorDetails(this Microsoft.Extensions.Logging.ILogger logger, Exception exception) {
            logger.LogError(exception.Message);
        }

        public static Logger CreateLoggerConfiguration() {
            return new LoggerConfiguration().Enrich.With(new ThreadIdEnricher()).WriteTo.File(Path.Combine(new string[] { "Logs", "log.txt" }),
                outputTemplate: "{Timestamp:dd:MM:yyyy HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                .CreateLogger();
        }
    }
}
