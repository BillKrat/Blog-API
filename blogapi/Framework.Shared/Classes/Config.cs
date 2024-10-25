using Framework.Shared.Enums;
using Framework.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
