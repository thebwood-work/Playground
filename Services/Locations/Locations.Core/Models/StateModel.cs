using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locations.Core.Models
{
    public class StateModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; }
    }
}
