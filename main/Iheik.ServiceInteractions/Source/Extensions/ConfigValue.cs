using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iheik.ServiceInteractions.Pocos;

namespace Iheik.ServiceInteractions.Extensions
{
    internal static class ConfigValue
    {

        /// <summary>
        /// Gets the configuration value from the System config collection.
        /// </summary>
        /// <param name="configKey">The config key.</param>
        /// <returns>String - Configuration value.</returns>
        internal static string GetValue(this IEnumerable<IntegrationSystemConfigurationPoco> systemConfigs, string configKey)
        {
            string configValue = systemConfigs.SingleOrDefault(x => x.ConfigKey.Equals(configKey, StringComparison.OrdinalIgnoreCase)).ConfigValue;

            return configValue;
        }
    }
}
