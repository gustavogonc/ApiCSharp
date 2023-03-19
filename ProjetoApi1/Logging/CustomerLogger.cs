using Microsoft.Extensions.Logging;
using NuGet.Common;

namespace ProjetoApi1.Logging
{
    /*public class CustomerLogger : Microsoft.Extensions.Logging.ILogger
    {
        public CustomerLogger(string name, CustomloggerProviderConfiguration config)
        {
            loggerName = name;
            loggerConfig = config;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(Microsoft.Extensions.Logging.LogLevel logLevel)
        {
            return logLevel == loggerConfig.Level;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, 
            TState state, Exception? exception, Func<TState, 
                Exception?, string> formatter)
        {
            string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

            EscreverTextoNoArquivo(mensagem);

        }

        public void Log<TState>(Microsoft.Extensions.Logging.LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            throw new NotImplementedException();
        }

        private void EscreverTextoNoArquivo(string mensagem)
        {
            string caminhoArquivoLog = @"E:\Gustavo\projetosCsharp\ProjetoApi1\logGustavo.txt";
            using (StreamWriter streamWriter = new StreamWriter(caminhoArquivoLog, ture))
            {
                try
                {
                    streamWriter.WriteLine(mensagem);
                    streamWriter.Close();
                }
                catch (Exception e )
                {

                    return;
                }
            }
        }
    }*/
}
