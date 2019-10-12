using Serilog;

namespace SerilogInNetCore
{
    public class LogHelper
    {
        public static void Debug(string message)
        {
            if (Log.IsEnabled(Serilog.Events.LogEventLevel.Debug))
                Log.Debug(message);
        }

        public static void Error(string message)
        {
            if (Log.IsEnabled(Serilog.Events.LogEventLevel.Error))
                Log.Error(message);
        }

        public static void Error(System.Exception exception, string message)
        {
            if (Log.IsEnabled(Serilog.Events.LogEventLevel.Error))
                Log.Error(exception, message);
        }

        public static void Info(string message)
        {
            if (Log.IsEnabled(Serilog.Events.LogEventLevel.Information))
                Log.Information(message);
        }

        public static void Warning(string message)
        {
            if (Log.IsEnabled(Serilog.Events.LogEventLevel.Warning))
                Log.Warning(message);
        }
    }
}
