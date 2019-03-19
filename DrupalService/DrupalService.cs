using System;

namespace DrupalService
{
    internal class DrupalService : IDrupalService
    {
        public void UpdateArticleTitle(string articleName)
        {
            Console.WriteLine("Updating article name");
        }
    }
}
