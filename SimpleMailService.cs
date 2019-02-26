using System.Diagnostics;

namespace simple_di_container
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