using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRenting.Host.Common
{
    public abstract class BaseEntity
    {
        public  int Id { get; set; }

        public override string? ToString()
        {
            return "ID: " + Id;
        }
    }
}
