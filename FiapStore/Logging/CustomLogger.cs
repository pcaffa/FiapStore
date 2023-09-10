using static System.Net.Mime.MediaTypeNames;

namespace FiapStore.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;

        public CustomLogger(string name,
                            CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = name;
            _configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var msg = string.Format($"{logLevel}: {eventId}" +
                $" - {formatter(state, exception)}");

            WriteTextToFile(msg);
        }

        private void WriteTextToFile(string msg)
        {
            var filePath = $@"C:\Users\caffa\OneDrive\Documentos\Fiap\FiapStore\FiapStore\bin\LOG-{DateTime.Now:yyyy-MM-dd}.txt";

            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Create(filePath).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine(msg);
            streamWriter.Close();
        }
    }
}
