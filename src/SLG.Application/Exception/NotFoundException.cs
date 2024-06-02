using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLG.Application.Exception
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string entityName, object key, object value) : base($"Entity {entityName} for {key} = {value} was not found") { }
    }
}
