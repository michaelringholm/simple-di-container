using System;

namespace DrupalService
{
    public abstract class DrupalServiceFactory
    {
        public static IDrupalService GetDrupalService()
        {
            return new DrupalService();
        }
    }
}
