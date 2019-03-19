using System.Diagnostics;

namespace console
{
    public class SimpleMailService : IMailService
    {
        private ILogger _logger;
        public SimpleMailService(ILogger logger) {
            _logger = logger;
        }

        public void SendMail()
        {
            _logger.LogMessage("Mail sent");
        }
    }
}