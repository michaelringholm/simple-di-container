using System.Diagnostics;

namespace console
{
    public class FileLogger : ILogger
    {
        public FileLogger()
        {

        }

        public void LogMessage(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}