using System;
using System.Configuration;
using WebMatrix.WebData;

namespace Warehouse.Providers.Security
{
    internal static class ConfigUtil
    {
        /// <summary>
        /// Gets a value indicating whether [MySqlSimpleMembershipEnabled].
        /// </summary>
        /// <value><c>true</c> if [MySqlSimpleMembershipEnabled]; otherwise, <c>false</c>.</value>
        public static bool MySqlSimpleMembershipEnabled
        {
            get
            {
                return IsMySqlSimpleMembershipEnabled();
            }
        }

        /// <summary>
        /// Gets the type of MySqlMembershipContext inherited context.
        /// </summary>
        /// <value>The type of MySqlMembershipContext inherited context.</value>
        public static string MySqlSecurityInheritedContextType
        {
            get
            {
                return GetMySqlSecurityInheritedContextType();
            }
        }

        private static string GetMySqlSecurityInheritedContextType()
        {
            var settingValue = ConfigurationManager.AppSettings[MySqlWebSecurity.MySqlSecurityInheritedContextType];

            if (string.IsNullOrEmpty(settingValue))
                throw new InvalidOperationException(Resources.Security.Security_InitializeMustBeAssignContext);

            return settingValue;
        }

        private static bool IsMySqlSimpleMembershipEnabled()
        {
            var settingValue = ConfigurationManager.AppSettings[MySqlWebSecurity.EnableMySqlSimpleMembershipKey];
            bool enabled;

            if (!String.IsNullOrEmpty(settingValue) && Boolean.TryParse(settingValue, out enabled))
            {
                return enabled;
            }
            // Simple Membership is enabled by default, but attempts to delegate to the current provider if not initialized.
            return true;
        }

        internal static bool ShouldPreserveLoginUrl()
        {
            string settingValue = ConfigurationManager.AppSettings[FormsAuthenticationSettings.PreserveLoginUrlKey];
            bool preserveLoginUrl;
            if (!String.IsNullOrEmpty(settingValue) && Boolean.TryParse(settingValue, out preserveLoginUrl))
            {
                return preserveLoginUrl;
            }

            // For backwards compatible with WebPages 1.0, we override the loginUrl value if 
            // the PreserveLoginUrl key is not present.
            return false;
        }
    }

}