using Framework.Shared.Enums;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Classes
{
    public class Config : IConfig
    {
        /// <summary>
        /// Database provider - defaults to SQL server
        /// </summary>
        public DbProvidersEnum Provider { get; set; } = DbProvidersEnum.SqlServer;
    }
}
