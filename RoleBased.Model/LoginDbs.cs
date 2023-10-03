using RoleBased.Shared;
using RoleBased.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleBased.Model
{
    public class LoginDbs: BaseAuditableEntity, IEntity
    {
        public string RegNo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
    }
}
