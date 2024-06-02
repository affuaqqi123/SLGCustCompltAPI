using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Domain.Entities
{
    internal class AuditableEntity
    {
        public DateTime ModifiedAt { get; set; }
    }
}
