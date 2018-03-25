using System;

namespace Infrastructure.Configuration
{
    public class ConfigurationException: Exception
    {
        public ConfigurationException(string message) : base(message)
        {
        }
    }
}