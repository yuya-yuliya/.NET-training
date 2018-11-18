namespace ConsoleShowBook.Logging
{
    /// <summary>
    /// Interface for log types
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Write trace message to log
        /// </summary>
        /// <param name="message"></param>
        void Trace(string message);

        /// <summary>
        /// Write debug message to log
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);

        /// <summary>
        /// Write info message to log
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// Write warning message to log
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// Write error message to log
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// Write fatal message to log
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message);
    }
}
