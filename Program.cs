using System;

namespace simple_di_container
{
    class Program
    {
        static void Main(string[] args)
        {
            runDISample();
        }

        private static void runDISample()
        {
            Console.WriteLine("Started...");
            var diContainer = SimpleDIContainer.Instance;
            diContainer.Register<ILogger, FileLogger>();
            diContainer.Register<IMailService, SimpleMailService>();
            diContainer.Register<PersonBO, PersonBO>();
            var mailService = diContainer.GetInstance<IMailService>();
            var personBO = diContainer.GetInstance<PersonBO>();
            mailService.SendMail();
            personBO.CreatePerson();
            Console.WriteLine("Ended!");
        }
    }
}
