using Framework.Shared.Enums;

namespace Framework.Shared.Interfaces
{
    public interface IConfig
    {
        public DbProvidersEnum Provider { get; set; }
         
    }
}
