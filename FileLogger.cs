using System.Diagnostics;

namespace simple_di_container
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