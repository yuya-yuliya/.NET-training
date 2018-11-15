using NLog;

namespace ConsoleShowBook.Logging
{
    /// <summary>
    /// Provides methods for saving logs using NLog
    /// </summary>
    public class NLogger : ILogger
    {
        /// <summary>
        /// Instance of Logger class for writing to log
        /// </summary>
        private Logger logger;

        /// <summary>
        /// Initialize new instance of NLogger class with given name
        /// </summary>
        /// <param name="name">Logger name</param>
        public NLogger(string name)
        {
            logger = LogManager.GetLogger(name);
        }

        /// <summary>
        /// Write Debug message to log
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// Write fatal message to log
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        /// <summary>
        /// Write info message to log
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Write trace message to log
        /// </summary>
        /// <param name="message"></param>
        public void Trace(string message)
        {
            logger.Trace(message);
        }

        /// <summary>
        /// Write warning message to log
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message)
        {
            logger.Warn(message);
        }
    }
}
