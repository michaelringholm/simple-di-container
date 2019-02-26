namespace simple_di_container
{
    public class PersonBO {
        private ILogger _logger;
        public PersonBO(ILogger logger) {
            _logger = logger;
        }
        public void CreatePerson() {
            _logger.LogMessage("Person created!");
        }
    }
}