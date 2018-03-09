using System;

namespace Infrastructure.Config
{
    public class ConfigException: Exception
    {
        public ConfigException()
        {
        }

        public ConfigException(string message) : base(message)
        {
        }
    }
}