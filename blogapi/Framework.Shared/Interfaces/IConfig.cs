using Framework.Shared.Enums;

namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: IConfig.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Configuration interface
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IConfig
    {
        public DbProvidersEnum Provider { get; set; }

    }
}
