using Framework.Shared.Enums;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Classes
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: Config.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Configuration file for framework use
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class Config : IConfig
    {
        /// <summary>
        /// Database provider - defaults to SQL server
        /// </summary>
        public DbProvidersEnum Provider { get; set; } = DbProvidersEnum.SqlServer;
    }
}
