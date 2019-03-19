using System;
using DrupalService;
using simple_di_container;

namespace console
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
            var drupalService = DrupalServiceFactory.GetDrupalService();
            diContainer.Register<IDrupalService>(drupalService);

            var mailService = diContainer.GetInstance<IMailService>();
            var personBO = diContainer.GetInstance<PersonBO>();
            var cmsService = diContainer.GetInstance<IDrupalService>();
            mailService.SendMail();
            personBO.CreatePerson();
            cmsService.UpdateArticleTitle("test");
            Console.WriteLine("Ended!");
        }
    }
}
