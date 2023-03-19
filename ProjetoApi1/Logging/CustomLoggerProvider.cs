using System.Collections.Concurrent;

namespace ProjetoApi1.Logging
{
    /*public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomloggerProviderConfiguration loggerConfig;
        readonly ConcurrentDictionary<string, CustomerLogger> loggers =
            new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggerProvider(CustomloggerProviderConfiguration config)
        {
            loggerConfig = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(name, loggerConfig));
        }

        public void Dispose()
        {
           loggers.Clear();
        }
    }*/
}
