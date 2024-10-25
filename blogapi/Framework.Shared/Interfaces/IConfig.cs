using Framework.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Interfaces
{
    public interface IConfig
    {
        public DbProvidersEnum Provider { get; set; }
         
    }
}
