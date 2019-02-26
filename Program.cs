using System;

namespace simple_di_container
{
    class Program
    {
        static void Main(string[] args)
        {
            //test1();
            test2();
        }

        private static void test2()
        {
            Console.WriteLine("Started...");
            var diContainer = new SimpleDIContainer();
            diContainer.Register<ILogger, FileLogger>();
            diContainer.Register<IMailService, SimpleMailService>();
            diContainer.Register<PersonBO, PersonBO>();
            var mailService = diContainer.GetInstance<IMailService>();
            var personBO = diContainer.GetInstance<PersonBO>();
            mailService.SendMail();
            personBO.CreatePerson();
            Console.WriteLine("Ended!");
        }

        private static void test1()
        {
            Console.WriteLine("Started...");
            var diContainer = new SimpleDIContainer2();
            diContainer.RegisterSingleton<ILogger>(new FileLogger());
            diContainer.Register<IMailService, SimpleMailService>();
            //container.Register<IUserRepository, SqlUserRepository>();
            //container.GetInstance(typeof(HomeController));
            var mailService = diContainer.GetInstance<IMailService>(typeof(IMailService));
            mailService.SendMail();
            Console.WriteLine("Ended!");
        }
    }
}
